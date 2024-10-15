using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Mail;
using System.Net;
using System.IO;

using System.Text;

public partial class Members_Setting_ConfirmDelete : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    string reqcount = 0.ToString();
    string msgcount = 0.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["memberid"] == null)
        {

            Response.Write("<script>alert('Please Try Again');window.location='../../register/login.aspx';</script>");
            Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else
            if (!IsPostBack)
            {
                MemberBasicData();
                notifications();
                getrequestcount();
                getDataMessages();
                lblcountfinalmsg.Text = (Convert.ToInt32(msgcount) + Convert.ToInt32(reqcount)).ToString();

            }

    }
    public void MemberBasicData()
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varMemberName,varGender,varMembershipType,varPhoto FROM tblammemberregistration WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblMemberId.Text = dbc.dr["varMemberId"].ToString();
                lblMemberName.Text = dbc.dr["varMemberName"].ToString();



                // gen = dbc.dr["varGender"].ToString();
                imgMemberPhoto.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();


                if (dbc.dr["varMembershipType"].ToString() == "Paid")
                {
                    MySql.Data.MySqlClient.MySqlCommand cmdm = new MySql.Data.MySqlClient.MySqlCommand("SELECT (SELECT distinct varPackageName FROM tblampackages WHERE varPackageId=tblammembertransactions.varPackageId) as ViewMemPackage FROM tblammembertransactions WHERE varMemberId='" + Session["memberid"].ToString() + "' and varOrderStatus='Confirmed'  order by intId DESC", dbc.con1);

                    dbc.con1.Open();
                    dbc.dr1 = cmdm.ExecuteReader();
                    if (dbc.dr1.Read())
                    {
                        lblmemUpgrade.Visible = true;
                        lnkUpgrade.Visible = false;
                        lblmemUpgrade.Text = dbc.dr1["ViewMemPackage"].ToString();
                    }
                    dbc.con1.Close();
                    dbc.dr1.Close();
                }
                else if (dbc.dr["varMembershipType"].ToString() == "Unpaid")
                {
                    lblmemUpgrade.Visible = false;
                    lnkUpgrade.Visible = true;
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Some problem Please try again...!!!');", true);
            }
            dbc.con.Close();
            dbc.dr.Close();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
        }
    }
    public void notifications()
    {
        try
        {
            lnkNotifications.Text = dbc.count_tblamnotifications(Session["memberid"].ToString(), "Member").ToString();
            lblcomplet.Attributes.Add("data-percent", dbc.getInActiveGridview(Session["memberid"].ToString()).ToString());
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
        }
    }
    public void getrequestcount()
    {
        try
        {
            dbc.con.Close();
           MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT count( intId)as myrequest, varFromMemberId, varFromMembarName, varFromMemberStatus, varToMemberId, varToMembarName, varToMemberStatus, varRequestType, varStatus, varDate, varTime FROM tblamrequests where (varToMemberId = '" + Session["memberid"].ToString() + "') and varStatus='Pending'     ORDER BY intId", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                reqcount = (Convert.ToInt32(reqcount.ToString()) + Convert.ToInt32(dbc.dr["myrequest"].ToString())).ToString();
            }

            dbc.con.Close();
            dbc.dr.Close();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
        }

    }
    string MsgId = string.Empty;
    public void getDataMessages()
    {
        try
        {
            MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr3;


            MySql.Data.MySqlClient.MySqlConnection cnn1 = new MySql.Data.MySqlClient.MySqlConnection();
            cnn1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;
            cnn1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct tblamcommunication.intId AS MsgId, tblamcommunication.varMsgFrom, tblamcommunication.varMsgFromName FROM tblamcommunication INNER JOIN tblamconversation ON tblamcommunication.intId = tblamconversation.varMessageId WHERE (tblamcommunication.varMsgto = '" + Session["memberid"].ToString() + "') ", cnn1);
            using (cnn1)
            {
                //read data from the table to our data reader
                rdr1 = cmd.ExecuteReader();
                //loop through each row we have read
                while (rdr1.Read())
                {
                    MsgId = rdr1["MsgId"].ToString();

                    // count unread //
                    MySql.Data.MySqlClient.MySqlConnection cnn3 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn3.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(intId)as mycount FROM tblamconversation WHERE ex1='Unread' and varMessageId=" + Convert.ToInt32(MsgId) + " and varMsgFrom!='" + Session["memberid"].ToString() + "'", cnn3);
                    cmd3.CommandType = CommandType.Text;

                    using (cnn3)
                    {
                        cnn3.Open();
                        rdr3 = cmd3.ExecuteReader();
                        if (rdr3.Read())
                        {

                            msgcount = (Convert.ToInt32(msgcount) + Convert.ToInt32(rdr3["mycount"].ToString())).ToString();


                        }
                        cnn3.Close();
                        rdr3.Close();

                    }
                }

                // Empty strings
                MsgId = string.Empty;


            }
            cnn1.Close();
            cmd.Dispose();

            cnn1.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct tblamcommunication.intId AS MsgId, tblamcommunication.varMsgto, tblamcommunication.varMsgtoName FROM tblamcommunication INNER JOIN tblamconversation ON tblamcommunication.intId = tblamconversation.varMessageId WHERE (tblamcommunication.varMsgFrom = '" + Session["memberid"].ToString() + "')  ORDER BY tblamconversation.intId DESC  ", cnn1);
            using (cnn1)
            {
                //read data from the table to our data reader
                rdr1 = cmd.ExecuteReader();
                //loop through each row we have read
                while (rdr1.Read())
                {
                    MsgId = rdr1["MsgId"].ToString();
                    // count unread //
                    MySql.Data.MySqlClient.MySqlConnection cnn3 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn3.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(intId)as mycount FROM tblamconversation WHERE ex1='Unread' and varMessageId=" + Convert.ToInt32(MsgId) + " and varMsgFrom!='" + Session["memberid"].ToString() + "'", cnn3);
                    cmd3.CommandType = CommandType.Text;

                    using (cnn3)
                    {
                        cnn3.Open();
                        rdr3 = cmd3.ExecuteReader();
                        if (rdr3.Read())
                        {

                            msgcount = (Convert.ToInt32(msgcount) + Convert.ToInt32(rdr3["mycount"].ToString())).ToString();


                        }
                        cnn3.Close();
                        rdr3.Close();

                    }
                }

                // Empty strings
                MsgId = string.Empty;


            }
            cnn1.Close();

        }
        catch (Exception ex)
        {

        }
    }
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session["memberid"] = "";
        Session.Remove("memberid");

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("~/Default.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int insert_ok = dbc.Update_tblammemberregistration_DeleteProfile(Session["memberid"].ToString());

            if (insert_ok == 1)
            {
                sendmail(lblMemberName.Text, Session["memberid"].ToString());
                Response.Write("<script>alert('Your Profile has been deleted');window.location='../../Default.aspx';</script>");
                deletedata();
                Session.Abandon();
                Session.Clear();
                Session["memberid"] = "";
                Session.Remove("memberid");

                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
            }
            else
            {
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Some problem Please try again...!!!');", true);
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/Activities/Home.aspx");
    }
    private string PopulateBody( string iname,  string imemid)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Admin/emails/DeleteProfile.html")))
        {
            body = reader.ReadToEnd();
        } string datenow = DateTimeOffset.UtcNow.LocalDateTime.ToLongDateString();
    
        body = body.Replace("{imemid}", Session["memberid"].ToString());
        body = body.Replace("{iname}", iname);
        body = body.Replace("{date}", datenow);
        body = body.Replace("{Status}", "Deleted");
        return body;
    }
    protected void sendmail(string iname, string imemid)
    {
        try
        {
            string email=dbc.get_member_Email(imemid);
            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(email)))
            {

                mm.Subject = "Swapnpurti Matrimony : Profile Deleted !!!";
                string datenow = DateTimeOffset.UtcNow.LocalDateTime.ToLongDateString();

                mm.Body = PopulateBody(iname, imemid);

                mm.IsBodyHtml = true;

                System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient();
                // for server

                SmtpServer.Host = "relay-hosting.secureserver.net";
                SmtpServer.EnableSsl = false;
                //for server
                SmtpServer.Port = 25;


                //for local 

                //SmtpServer.Host = "smtp.gmail.com";
                //SmtpServer.EnableSsl = true;

                //SmtpServer.Port = 587;


                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                NetworkCredential NetworkCred = new NetworkCredential("swapnpurtimatrimony@gmail.com", "anuvaa2015");
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = NetworkCred;

                SmtpServer.Send(mm);


            }
        }
        catch (Exception rx)
        {
            //ScriptManager.RegisterStartupScript(
            //             this,
            //             this.GetType(),
            //             "MessageBox",
            //              "alert('not sent');", true);

        }
    }
    public void deletedata()
    {
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberpartnercaste where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd1.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberpartnerlanguages where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd2.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberpartnermothertongue where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd3.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd4 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberpartnersubcaste where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd4.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd10 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammembercontactdetails where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd10.ExecuteReader();
        dbc.con.Close();

        //MySql.Data.MySqlClient.MySqlCommand cmd10a = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberemailcode", dbc.con);
        //dbc.con.Open();
        //cmd10a.ExecuteReader();
        //dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd11 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberfamily where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd11.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd12 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberinformation where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd12.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd13 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberinterests where varInterestOfId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd13.ExecuteReader();
        dbc.con.Close();
        MySql.Data.MySqlClient.MySqlCommand cmd130 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberinterests where varInterestInId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd130.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd14 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberlifestyle where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd14.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd15 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberlivingin where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd15.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd16 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnerarea where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd16.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd17 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnerbasic where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd17.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd5 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnereducation where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd5.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd6 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartneremploy where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd6.ExecuteNonQuery();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd9 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnerincome where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd9.ExecuteReader();
        dbc.con.Close();
        MySql.Data.MySqlClient.MySqlCommand cmd41 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnerreligious where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd41.ExecuteNonQuery();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd42 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberphysicalinformation where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd42.ExecuteReader();
        dbc.con.Close();
        MySql.Data.MySqlClient.MySqlCommand cmd43 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberprofessionalinfo where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd43.ExecuteNonQuery();
        dbc.con.Close();

        //MySql.Data.MySqlClient.MySqlCommand cmd45 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberregistration", dbc.con);
        //dbc.con.Open();
        //cmd45.ExecuteReader();
        //dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd46 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberreligiousinfo where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd46.ExecuteNonQuery();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd47 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammembershortlist where varMemberId ='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd47.ExecuteReader();
        dbc.con.Close();
        MySql.Data.MySqlClient.MySqlCommand cmd447 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammembershortlist where varShortListMemberId ='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd447.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd48 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammembertransactions where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd48.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd49 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberuploads where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd49.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd54 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamrequests where varFromMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd54.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd5400 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamrequests where 	varToMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd5400.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd1zz = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamcommunication where varMsgFrom='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd1zz.ExecuteReader();
        dbc.con.Close();


        MySql.Data.MySqlClient.MySqlCommand cmd1zz0 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamcommunication where varMsgTo='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd1zz0.ExecuteReader();
        dbc.con.Close();


        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamconversation where varMsgFrom='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd7 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberview where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd7.ExecuteReader();
        dbc.con.Close();
        MySql.Data.MySqlClient.MySqlCommand cmd777 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberview where varViewedMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd777.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd798 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamnotifications where intNotFromId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd798.ExecuteReader();
        dbc.con.Close();
        MySql.Data.MySqlClient.MySqlCommand cmd7778 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamnotifications where intNotToId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd7778.ExecuteReader();
        dbc.con.Close();

        MySql.Data.MySqlClient.MySqlCommand cmd7980 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamsuccessstories where varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd7980.ExecuteReader();
        dbc.con.Close();
        MySql.Data.MySqlClient.MySqlCommand cmd77780 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamsuccessstories where varPartnerId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        cmd77780.ExecuteReader();
        dbc.con.Close();
    }
}