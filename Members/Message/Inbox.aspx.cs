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
using MySql.Data.MySqlClient;
using System.Text;
using System.Text.RegularExpressions;

public partial class members_Message_Inbox : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    static string mem = string.Empty;
    static string memid = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["memberid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../register/login.aspx';</script>");
            Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
            MemberBasicData();

            getDataInbox();

            getrequestcount();
            getDataMessages();
            lblcountfinalmsg.Text = (Convert.ToInt32(lblcountmsg.Text) + Convert.ToInt32(lblrequest.Text)).ToString();
            notifications();
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
                lblrequest.Text = (Convert.ToInt32(lblrequest.Text) + Convert.ToInt32(dbc.dr["myrequest"].ToString())).ToString();
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

                            lblcountmsg.Text = (Convert.ToInt32(lblcountmsg.Text) + Convert.ToInt32(rdr3["mycount"].ToString())).ToString();


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

                            lblcountmsg.Text = (Convert.ToInt32(lblcountmsg.Text) + Convert.ToInt32(rdr3["mycount"].ToString())).ToString();


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
    public void MemberBasicData()
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varMemberName,varGender,varMembershipType,varPhoto,varPhotoApprove FROM tblammemberregistration WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblMemberId.Text = dbc.dr["varMemberId"].ToString();
                lblMemberName.Text = dbc.dr["varMemberName"].ToString();

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

    string MsgId = string.Empty;
    string InboxMsgMember = string.Empty;
    string InboxMemName = string.Empty;
    string InboxMemPhoto = string.Empty;


    public void getDataInbox()
    {
        try
        {
            MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr2, rdr3;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] {             
                        new DataColumn("MsgId", typeof(string)),                         
                        new DataColumn("InboxMsgMember", typeof(string)),
                        new DataColumn("InboxMemName", typeof(string)),
                         new DataColumn("InboxMemPhoto", typeof(string)),
                       
                                 
        });

            DataRow dr = dt.NewRow();

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
                    InboxMsgMember = rdr1["varMsgFrom"].ToString();
                    InboxMemName = rdr1["varMsgFromName"].ToString();
                    MySql.Data.MySqlClient.MySqlConnection cnn2 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName as IntersestMemName,varMemberFor as IntersestMemAccFor,varPhoto as IntersestMemPhoto,ex3,varGender,varPhotoApprove FROM tblammemberregistration WHERE (varMemberId = '" + InboxMsgMember + "') and varMemberStatus='Verified'", cnn2);
                    cmd2.CommandType = CommandType.Text;

                    using (cnn2)
                    {
                        cnn2.Open();
                        rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            if (rdr2["varPhotoApprove"].ToString() == "Approved")
                            {


                                if (rdr2["varGender"].ToString() == "Female")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        InboxMemPhoto = "FemaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        InboxMemPhoto = "FemaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        InboxMemPhoto = rdr2["IntersestMemPhoto"].ToString();
                                    }
                                }
                                else if (rdr2["varGender"].ToString() == "Male")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        InboxMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        InboxMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        InboxMemPhoto = rdr2["IntersestMemPhoto"].ToString();
                                    }
                                }
                                else if (rdr2["varGender"].ToString() == "Other")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        InboxMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        InboxMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        InboxMemPhoto = rdr2["IntersestMemPhoto"].ToString();
                                    }
                                }
                            }
                            else
                            {
                                InboxMemPhoto = "NotApproved.jpg";
                            }

                        }
                        cnn2.Close();
                        rdr2.Close();
                    }

                    dt.Rows.Add(MsgId, InboxMsgMember, InboxMemName, InboxMemPhoto);
                }

                // Empty strings
                MsgId = string.Empty;
                InboxMsgMember = string.Empty;
                InboxMemName = string.Empty;

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
                    InboxMsgMember = rdr1["varMsgto"].ToString();
                    InboxMemName = rdr1["varMsgtoName"].ToString();

                    MySql.Data.MySqlClient.MySqlConnection cnn2 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName as IntersestMemName,varMemberFor as IntersestMemAccFor,varPhoto as IntersestMemPhoto,ex3,varGender,varPhotoApprove FROM tblammemberregistration WHERE (varMemberId = '" + InboxMsgMember + "') and varMemberStatus='Verified'", cnn2);
                    cmd2.CommandType = CommandType.Text;

                    using (cnn2)
                    {
                        cnn2.Open();
                        rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {

                            if (rdr2["varPhotoApprove"].ToString() == "Approved")
                            {
                                if (rdr2["varGender"].ToString() == "Female")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        InboxMemPhoto = "FemaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        InboxMemPhoto = "FemaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        InboxMemPhoto = rdr2["IntersestMemPhoto"].ToString();
                                    }
                                }
                                else if (rdr2["varGender"].ToString() == "Male")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        InboxMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        InboxMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        InboxMemPhoto = rdr2["IntersestMemPhoto"].ToString();
                                    }
                                }
                                else if (rdr2["varGender"].ToString() == "Other")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        InboxMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        InboxMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        InboxMemPhoto = rdr2["IntersestMemPhoto"].ToString();
                                    }
                                }
                            }
                            else
                            {
                                InboxMemPhoto = "NotApproved.jpg";
                            }

                        }
                        cnn2.Close();
                        rdr2.Close();
                    }
                    dt.Rows.Add(MsgId, InboxMsgMember, InboxMemName, InboxMemPhoto);
                }

                // Empty strings
                MsgId = string.Empty;
                InboxMsgMember = string.Empty;
                InboxMemName = string.Empty;

            }
            cnn1.Close();
            lstInbox.DataSource = dt;
            lstInbox.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    protected void lstInbox_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            string[] commandarguement = e.CommandArgument.ToString().Split(';');
            SqlDataSourceConversation.SelectCommand = "SELECT tblammemberregistration.varMemberName, tblammemberregistration.varPhoto,tblamconversation.varMsgText, tblamconversation.varDate, tblamconversation.varTime FROM tblamconversation INNER JOIN tblammemberregistration ON tblamconversation.varMsgFrom = tblammemberregistration.varMemberId WHERE (tblamconversation.varMessageId ='" + commandarguement[0].ToString() + "') ORDER BY tblamconversation.intId desc";
            getDataInbox();
            mem = commandarguement[0].ToString();
            memid = commandarguement[1].ToString();
            if (e.CommandName == "Views")
            {
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblamconversation SET ex1='Read' WHERE varMessageId='" + mem + "' and varMsgFrom='" + memid+ "'", dbc.con);
                cmd.ExecuteNonQuery();
                dbc.con.Close();
            }

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
    protected void btnSend_Click(object sender, EventArgs e)
    {

        try
        {
            if (mem == "")
            {

                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "MessageBox",
                    "alert('Please select an conversation');", true);
            }
            else
            {
                String input = txtMessage.Text.Replace("'", "''");
                String pattern = @"(\S*)@\S*\.\S*";
                String result = Regex.Replace(input, pattern, "(Omitted)");

                pattern = @"\d";

                result = Regex.Replace(result, pattern, "x");

                int idc = dbc.max_tblamconversation();
                idc = idc + 1;
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmdc = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamconversation VALUES (" + idc + ",'" + mem + "','" + Session["memberid"].ToString() + "','" + result + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','Unread')", dbc.con);
                cmdc.ExecuteNonQuery();
                dbc.con.Close();
                cmdc.Dispose();
                dbc.insert_tblamnotifications("Page", Session["memberid"].ToString(), lblMemberName.Text, "Member",memid, "Member", " Message Reply from : " + lblMemberName.Text + "", "~/Members/Message/Inbox.aspx", "NA", "Unread", "");
                ScriptManager.RegisterStartupScript(
                 this,
                 this.GetType(),
                 "MessageBox",
                 "alert('Reply Sent');window.location='Inbox.aspx'; ", true);
            }
        }
        catch (Exception ex)
        {
        }
    }
}