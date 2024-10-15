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


public partial class members_Message_Send : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
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
            //SqlDataSourceSent.SelectCommand = "SELECT tblamcommunication.varMsgTo, tblamconversation.varMsgText, tblamconversation.varDate, tblamconversation.varTime, tblamcommunication.varMsgFrom AS Expr1 FROM tblamcommunication INNER JOIN tblamconversation ON tblamcommunication.intId = tblamconversation.varMessageId WHERE (tblamcommunication.varMsgFrom =  '" + Session["memberid"].ToString() + "')";
          
            MemberBasicData();
            getSentData();
            getrequestcount();
            getDataMessages();
            lblcountfinalmsg.Text = (Convert.ToInt32(lblcountmsg.Text) + Convert.ToInt32(lblrequest.Text)).ToString();   
            notifications();
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
    string MsgId = string.Empty;
    string ConId = string.Empty;
    string SentMemName = string.Empty;
    string SentMsg = string.Empty; 
    string SentDate = string.Empty;
    string SentTime = string.Empty;
    string SentPhoto = string.Empty;

    public void getSentData()
    {
        try
        {
            MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr2,rdr3;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] {          
                 new DataColumn("ConId", typeof(string)),     
                        new DataColumn("SentMemName", typeof(string)),                         
                        new DataColumn("SentMsg", typeof(string)),
                        new DataColumn("SentDate", typeof(string)),
                          new DataColumn("SentTime", typeof(string)),
                            new DataColumn("SentPhoto", typeof(string)),
                       
                                 
        });

            DataRow dr = dt.NewRow();

            MySql.Data.MySqlClient.MySqlConnection cnn1 = new MySql.Data.MySqlClient.MySqlConnection();
            cnn1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;
            cnn1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct tblamcommunication.intId AS MsgId, tblamcommunication.varMsgFrom, tblamcommunication.varMsgFromName FROM tblamcommunication INNER JOIN tblamconversation ON tblamcommunication.intId = tblamconversation.varMessageId WHERE (tblamcommunication.varMsgto = '" + Session["memberid"].ToString() + "')  ", cnn1);
            using (cnn1)
            {
                //read data from the table to our data reader
                rdr1 = cmd1.ExecuteReader();
                //loop through each row we have read
                while (rdr1.Read())
                {
                    MsgId = rdr1["MsgId"].ToString();

                    MySql.Data.MySqlClient.MySqlConnection cnn2 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;
                    cnn2.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblamconversation.intId, tblamcommunication.varMsgFromName, tblamconversation.varMsgText, tblamconversation.varDate, tblamconversation.varTime, tblamcommunication.varMsgFrom AS Expr1 FROM tblamcommunication INNER JOIN tblamconversation ON tblamcommunication.intId = tblamconversation.varMessageId WHERE tblamcommunication.intId='" + Convert.ToInt32(MsgId) + "' AND tblamconversation.varMsgFrom='" + Session["memberid"].ToString() + "' ", cnn2);
                    using (cnn2)
                    {
                        //read data from the table to our data reader
                        rdr2 = cmd2.ExecuteReader();
                        //loop through each row we have read
                        while (rdr2.Read())
                        {
                            ConId = rdr2["intId"].ToString();
                            SentMemName = rdr2["varMsgFromName"].ToString();
                            SentDate = rdr2["varDate"].ToString();
                            SentTime = rdr2["varTime"].ToString();
                            SentMsg = rdr2["varMsgText"].ToString();

                            MySql.Data.MySqlClient.MySqlConnection cnn3 = new MySql.Data.MySqlClient.MySqlConnection();
                            cnn3.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                            MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName as IntersestMemName,varMemberFor as IntersestMemAccFor,varPhoto as IntersestMemPhoto,ex3,varGender,varPhotoApprove FROM tblammemberregistration WHERE (varMemberId = '" + rdr2["Expr1"].ToString() + "') and varMemberStatus='Verified'", cnn3);
                            cmd3.CommandType = CommandType.Text;

                            using (cnn3)
                            {
                                cnn3.Open();
                                rdr3 = cmd3.ExecuteReader();
                                while (rdr3.Read())
                                {
                                    if (rdr3["varPhotoApprove"].ToString() == "Approved")
                                    {
                                        if (rdr3["varGender"].ToString() == "Female")
                                        {
                                            if (rdr3["ex3"].ToString() == "Protected")
                                            {
                                                SentPhoto = "FemaleNoProfileProtected.jpg";
                                            }
                                            else if (rdr3["ex3"].ToString() == "Hidden")
                                            {
                                                SentPhoto = "FemaleNoProfileProtected.jpg";
                                            }
                                            else
                                            {
                                                SentPhoto = rdr3["IntersestMemPhoto"].ToString();
                                            }
                                        }
                                        else if (rdr3["varGender"].ToString() == "Male")
                                        {
                                            if (rdr3["ex3"].ToString() == "Protected")
                                            {
                                                SentPhoto = "MaleNoProfileProtected.jpg";
                                            }
                                            else if (rdr3["ex3"].ToString() == "Hidden")
                                            {
                                                SentPhoto = "MaleNoProfileProtected.jpg";
                                            }
                                            else
                                            {
                                                SentPhoto = rdr3["IntersestMemPhoto"].ToString();
                                            }
                                        }
                                        else if (rdr3["varGender"].ToString() == "Other")
                                        {
                                            if (rdr3["ex3"].ToString() == "Protected")
                                            {
                                                SentPhoto = "MaleNoProfileProtected.jpg";
                                            }
                                            else if (rdr3["ex3"].ToString() == "Hidden")
                                            {
                                                SentPhoto = "MaleNoProfileProtected.jpg";
                                            }
                                            else
                                            {
                                                SentPhoto = rdr3["IntersestMemPhoto"].ToString();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        SentPhoto = "NotApproved.jpg";
                                    }
                                }
                                dt.Rows.Add(ConId, SentMemName, SentMsg, SentDate, SentTime, SentPhoto);
                                cnn3.Close();
                                rdr3.Close();
                            }
                          
                        }
                        cnn2.Close();
                        rdr2.Close();
                        // Empty strings
                        MsgId = string.Empty;
                        ConId = string.Empty;
                        SentMemName = string.Empty;
                        SentMsg = string.Empty;
                        SentDate = string.Empty;
                        SentTime = string.Empty;

                    }
                    cnn2.Close();
                }
            }
            cnn1.Close();
            cmd1.Dispose();
             
            cnn1.Open();
            cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct tblamcommunication.intId AS MsgId, tblamcommunication.varMsgto, tblamcommunication.varMsgtoName FROM tblamcommunication INNER JOIN tblamconversation ON tblamcommunication.intId = tblamconversation.varMessageId WHERE (tblamcommunication.varMsgFrom = '" + Session["memberid"].ToString() + "')", cnn1);
            using (cnn1)
            {
                //read data from the table to our data reader
                rdr1 = cmd1.ExecuteReader();
                //loop through each row we have read
                while (rdr1.Read())
                {
                    MsgId = rdr1["MsgId"].ToString();

                    MySql.Data.MySqlClient.MySqlConnection cnn2 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;
                    cnn2.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblamconversation.intId, tblamcommunication.varMsgFromName, tblamconversation.varMsgText, tblamconversation.varDate, tblamconversation.varTime, tblamcommunication.varMsgFrom AS Expr1 FROM tblamcommunication INNER JOIN tblamconversation ON tblamcommunication.intId = tblamconversation.varMessageId WHERE tblamcommunication.intId='" + Convert.ToInt32(MsgId) + "' AND tblamconversation.varMsgFrom='" + Session["memberid"].ToString() + "'", cnn2);
                    using (cnn2)
                    {
                        //read data from the table to our data reader
                        rdr2 = cmd2.ExecuteReader();
                        //loop through each row we have read
                        while (rdr2.Read())
                        {
                            ConId = rdr2["intId"].ToString();
                            SentMemName = rdr2["varMsgFromName"].ToString();
                            SentDate = rdr2["varDate"].ToString();
                            SentTime = rdr2["varTime"].ToString();
                            SentMsg = rdr2["varMsgText"].ToString();
                            MySql.Data.MySqlClient.MySqlConnection cnn3 = new MySql.Data.MySqlClient.MySqlConnection();
                            cnn3.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                            MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName as IntersestMemName,varMemberFor as IntersestMemAccFor,varPhoto as IntersestMemPhoto,ex3,varGender FROM tblammemberregistration WHERE (varMemberId = '" + rdr2["Expr1"].ToString() + "') and varMemberStatus='Verified'", cnn3);
                            cmd3.CommandType = CommandType.Text;

                            using (cnn3)
                            {
                                cnn3.Open();
                                rdr3 = cmd3.ExecuteReader();
                                while (rdr3.Read())
                                {
                                    if (rdr3["varPhotoApprove"].ToString() == "Approved")
                                    {
                                        if (rdr3["varGender"].ToString() == "Female")
                                        {
                                            if (rdr3["ex3"].ToString() == "Protected")
                                            {
                                                SentPhoto = "FemaleNoProfileProtected.jpg";
                                            }
                                            else if (rdr3["ex3"].ToString() == "Hidden")
                                            {
                                                SentPhoto = "FemaleNoProfileProtected.jpg";
                                            }
                                            else
                                            {
                                                SentPhoto = rdr3["IntersestMemPhoto"].ToString();
                                            }
                                        }
                                        else if (rdr3["varGender"].ToString() == "Male")
                                        {
                                            if (rdr3["ex3"].ToString() == "Protected")
                                            {
                                                SentPhoto = "MaleNoProfileProtected.jpg";
                                            }
                                            else if (rdr3["ex3"].ToString() == "Hidden")
                                            {
                                                SentPhoto = "MaleNoProfileProtected.jpg";
                                            }
                                            else
                                            {
                                                SentPhoto = rdr3["IntersestMemPhoto"].ToString();
                                            }
                                        }
                                        else if (rdr3["varGender"].ToString() == "Other")
                                        {
                                            if (rdr3["ex3"].ToString() == "Protected")
                                            {
                                                SentPhoto = "MaleNoProfileProtected.jpg";
                                            }
                                            else if (rdr3["ex3"].ToString() == "Hidden")
                                            {
                                                SentPhoto = "MaleNoProfileProtected.jpg";
                                            }
                                            else
                                            {
                                                SentPhoto = rdr3["IntersestMemPhoto"].ToString();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        SentPhoto = "NotApproved.jpg";
                                    }

                                } 
                                dt.Rows.Add(ConId, SentMemName, SentMsg, SentDate, SentTime, SentPhoto);
                                cnn3.Close();
                                rdr3.Close();
                            }
                           
                        }
                        cnn2.Close();
                        rdr2.Close();
                        // Empty strings
                        MsgId = string.Empty;
                        ConId = string.Empty;
                        SentMemName = string.Empty;
                        SentMsg = string.Empty;
                        SentDate = string.Empty;
                        SentTime = string.Empty;
                        SentPhoto=string.Empty;
                    }
                    cnn2.Close();
                }
            }
            cnn1.Close();
            cmd1.Dispose();

            lstSentMessages.DataSource = dt;
            lstSentMessages.DataBind();
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
    protected void lstSentMessages_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "delet")
            {
                int insert_ok = dbc.delete_Message(e.CommandArgument.ToString());
                if (insert_ok == 1)
                {
                    ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "window.location='Send.aspx';", true);
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
}