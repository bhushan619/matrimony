﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.IO;
using MySql.Data.MySqlClient;
using CCA.Util;
using System.Collections.Specialized;

public partial class ccavResponseHandler : System.Web.UI.Page
{ 
    string transactionid = string.Empty;
    string productinfo = string.Empty;
    string orderid = string.Empty;
    string amt = string.Empty;
    string pname = string.Empty;
    string duration = string.Empty;
    string time = string.Empty;

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
        else if (!IsPostBack)
        {
            string workingKey = "406C70BF1B3E1896553A64BDBB77A019";//put in the 32bit alpha numeric key in the quotes provided here
            CCACrypto ccaCrypto = new CCACrypto();
            string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
            NameValueCollection Params = new NameValueCollection();
            string[] segments = encResponse.Split('&');
            foreach (string seg in segments)
            {
                string[] parts = seg.Split('=');
                if (parts.Length > 0)
                {
                    string Key = parts[0].Trim();
                    string Value = parts[1].Trim();
                    Params.Add(Key, Value);
                }
            }

            //for (int i = 0; i < Params.Count; i++)
            //{
            //    Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
            //}
            orderid = Params[0];
            if (Params[3] == "Success")
            {
                // orderid = Params[0];
                transactionid = Params[1];
                productinfo = Params[26];
                amt = Params[10];
                pname = Params[11];
                duration = Params[29];
                time = Params[30];
                //OK Done

                SqlDataSource1.SelectCommand = "SELECT DISTINCT tblampackages.varPackageId, tblampackages.varPackageName, tblampackagesdetails.varPackageDescription, tblampackagesdetails.varPackageDuration, tblampackagesdetails.varPackagePrice, tblampackagesdetails.varBenifits, tblampackagesdetails.varPackageDurationTime FROM tblampackages INNER JOIN tblampackagesdetails ON tblampackages.varPackageId = tblampackagesdetails.varPackageId where tblampackages.varPackageId='" + productinfo + "' and tblampackagesdetails.varPackageDuration='" + duration + "' and tblampackagesdetails.varPackageDurationTime='" + time + "'";
                // Response.Write("value matched") 

                lblOrderStatus.Text = "Confirmed";

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammembertransactions SET varTransactionId = '" + transactionid + "',varTransactionStatus = 'Success',varPaymode = 'Online Payment',varPaymentStatus ='Paid' ,varOrderStatus='" + lblOrderStatus.Text + "' WHERE varOrderNo = '" + orderid + "'", dbc.con);
                cmd.ExecuteNonQuery();
                dbc.con.Close();

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmdr = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberregistration SET varMembershipType = 'Paid' WHERE varMemberId = '" + Session["memberid"].ToString() + "'", dbc.con);
                cmdr.ExecuteNonQuery();
                dbc.con.Close();

                dbc.con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmdc = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varMemberName,varEmail,varMobile from anuvaa_matrimony.tblammemberregistration where (varMemberId = '" + Session["memberid"].ToString() + "')", dbc.con);
                dbc.con.Open();
                dbc.dr = cmdc.ExecuteReader();
                if (dbc.dr.Read())
                {
                    sendmail(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString(), transactionid, orderid, pname, amt, duration, time);

                }
                dbc.con.Close();
                dbc.dr.Close();

                dbc.update_tblmembercontactviewscount(Session["memberid"].ToString(), dbc.getPackageContactCount(productinfo, duration, time).ToString());

                dbc.insert_tblamnotifications("Message", Session["memberid"].ToString(), lblMemberName.Text, "Member", Session["memberid"].ToString(), "Member", "You Package Order is Confirmed...!!!", "", "", "Unread", "");
            }
            else
            {
                //aborted or pending 
                ListView1.Visible = false;
                 
            }
            lblOrderNo.Text = orderid;
            lblOrderStatus.Text = Params[3];
            MemberBasicData();
            getrequestcount();
            getDataMessages(); notifications();
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
    public void notifications()
    {
        try
        {
            lnkNotifications.Text = dbc.count_tblamnotifications(Session["memberid"].ToString(), "Member").ToString();
            lblcomplet.Attributes.Add("data-percent", dbc.getInActiveGridview(Session["memberid"].ToString()).ToString());
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../register/login.aspx';</script>");

        }
    }
   

    private string PopulateBody(string memid, string Name, string EmailId, string trans, string order, string pname, string amt, string date, string duration, string time)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Admin/emails/Upgrade.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{memid}", memid);
        body = body.Replace("{Name}", Name);
        body = body.Replace("{EmailId}", EmailId);
        body = body.Replace("{date}", date);
        body = body.Replace("{trans}", trans);
        body = body.Replace("{order}", order);
        body = body.Replace("{pname}", pname);
        body = body.Replace("{amt}", amt);
        body = body.Replace("{duration}", duration);
        body = body.Replace("{time}", time);


        return body;
    }
    protected void sendmail(string memid, string name, string email, string trans, string order, string pname, string amt, string duration, string time)
    {
        try
        {
            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(email)))
            {
                mm.Subject = "Swapnpurti Matrimony : Upgrade Successfully !!!";
                string datenow = DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString();
                mm.Body = PopulateBody(memid, name, email, trans, order, pname, amt, datenow, duration, time);

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
}