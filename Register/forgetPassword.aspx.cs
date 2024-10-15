using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

using System.Text;
using System.Data;
using System.Configuration;
using System.Net.Mail;

public partial class Register_forgetPassword : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();

    RegexUtilities rex = new RegexUtilities();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnforgetpassword_Click(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName, varMemberId,varEmail,varPassword FROM tblammemberregistration WHERE varEmail ='" + txtEmailforgetpassword.Text + "'", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                string name = dbc.dr["varMemberName"].ToString();
                string pass = dbc.dr["varPassword"].ToString();
                string id = dbc.dr["varMemberId"].ToString();
                string email = txtEmailforgetpassword.Text;
                sendmailForgetPassword(name, pass, id, email);
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Please Check Email..!!!');window.location='Login.aspx';", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Please try again...!!!');", true);
            }
            dbc.dr.Close();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(
            //       this,
            //       this.GetType(),
            //       "MessageBox",
            //       "alert('" + ex.Message + "');", true);
        }

    }
    private string PopulateBodyForgetPassword(string Name, string EmailId, string memid, string pass)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Admin/emails/forget.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{Name}", Name);
        body = body.Replace("{EmailId}", EmailId);
        body = body.Replace("{memid}", memid);
        body = body.Replace("{pass}", pass);
        return body;
    }
    protected void sendmailForgetPassword(string name, string pass, string id, string email)
    {
        try
        {

            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(email)))
            {
                mm.Subject = " Your Swapnpurti Matrimony Password";

                mm.Body = PopulateBodyForgetPassword(name, email, id, pass);

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
            ScriptManager.RegisterStartupScript(
                         this,
                         this.GetType(),
                         "MessageBox",
                          "alert('Email Not Sent...Please Try Again...!!!);", true);

        }
    }


}