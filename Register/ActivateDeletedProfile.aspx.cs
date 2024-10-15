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

public partial class Register_ActivateDeletedProfile : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["memberid"] == null)
        {

            Response.Write("<script>alert('Please Try Again');window.location='../register/login.aspx';</script>");
            Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session["memberid"] = "";
        Session.Remove("memberid");

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        Response.Redirect("../Default.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int insert_ok = dbc.Update_tblammemberregistration_ActivateProfile(Session["memberid"].ToString());

            if (insert_ok == 1)
            {
                sendmail( Session["memberid"].ToString());
                Response.Write("<script>alert('Your Profile has been Activated');window.location='../register/login.aspx';</script>");
               
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
    private string PopulateBody(string iname, string imemid)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Admin/emails/DeleteProfile.html")))
        {
            body = reader.ReadToEnd();
        } string datenow = DateTimeOffset.UtcNow.LocalDateTime.ToLongDateString();

        body = body.Replace("{imemid}", Session["memberid"].ToString());
        body = body.Replace("{iname}", iname);
        body = body.Replace("{date}", datenow);
        body = body.Replace("{Status}", "Activated");

        return body;
    }
    protected void sendmail( string imemid)
    {
        try
        {
            string email = dbc.get_member_Email(imemid);
            string iname = dbc.get_member_name(imemid);
            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(email)))
            {

                mm.Subject = "Swapnpurti Matrimony : Profile Activation !!!";
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
}