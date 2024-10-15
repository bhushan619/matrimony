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

public partial class Register_ForgetpasswordPersonal : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["memberid"] == null)
        //{
        //    //Response.Write("<script>alert('Please Try Again');window.location='../register/FranchiseeRegisterj.aspx';</script>");
        //    //Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
        //    //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    //Response.Cache.SetNoStore();
        //}
        //else
        if (!IsPostBack)
        {

        }


    }

    private string PopulateBody(string Name, string EmailId, string memid, string pass)
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
    protected void sendmail(string name, string pass, string id, string email)
    {
        try
        {

            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(email)))
            {
                mm.Subject = " Your Swapnpurti Matrimony Password";

                mm.Body = PopulateBody(name, email, id, pass);

                mm.IsBodyHtml = true;

                System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient();
                //// for server

                //SmtpServer.Host = "relay-hosting.secureserver.net";
                //SmtpServer.EnableSsl = false;
                ////for server
                //SmtpServer.Port = 25;


               //// for local

                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;

                SmtpServer.Port = 587;


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
    protected void btnRetrieve_Click(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varName,varFranchiseeId,varEmail,varPassword FROM tblampersonnel WHERE varEmail ='" + txtEmail.Text + "'", dbc.con);

            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                string name = dbc.dr["varName"].ToString();
                string pass = dbc.dr["varPassword"].ToString();
                string id = dbc.dr["varFranchiseeId"].ToString();
                string email = txtEmail.Text;
                sendmail(name, pass, id, email);
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Please Check Email..');window.location='Login.aspx';", true);

            }
            else
            {
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Some problem Please try again...!!!');", true);
            }
            dbc.dr.Close();
            dbc.con.Close();
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