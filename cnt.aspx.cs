using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cnt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {


            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
           // System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");

            System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient();
            //for server

            SmtpServer.Host = "relay-hosting.secureserver.net";
            SmtpServer.EnableSsl = false;

            //for local 

            //SmtpServer.Host = "smtp.gmail.com";
            //SmtpServer.EnableSsl = true;

            mail.From = new System.Net.Mail.MailAddress("swapnpurtimatrimony@gmail.com");
            mail.To.Add("swapnpurtimatrimony@gmail.com");


            mail.Subject = "Enquiry at Swapnpurti Matrimony from Contact";

            // done HTML formatting in the next line to display my logo 

            mail.Body = "Enquiry at Swapnpurti Matrimony by \n \n Name :" + txtName.Text + "\n E-Mail : " + txtEmail.Text + "\n Mobile Number : " + txtmobile.Text + "\n Subject : " + txtsubject.Text + "\n Message : " + txtMessage.Text;

            //for server
            SmtpServer.Port = 25;
            //for local
            //SmtpServer.Port = 587;

           
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("swapnpurtimatrimony@gmail.com", "anuvaa2015");
           

            SmtpServer.Send(mail);


            ClientScript.RegisterStartupScript(this.GetType(),
                    "popup",
                    "alert('Message sent successfully.');window.location='Cnt.aspx';",
                    true);
            txtsubject.Text = "";
            txtName.Text = "";
            txtmobile.Text = "";
            txtMessage.Text = "";
            txtEmail.Text = "";

            // Response.Redirect("");
        }
        catch (Exception ass)
        {
            ClientScript.RegisterStartupScript(this.GetType(),
                      "popup",
                      "alert('" + ass.Message + "');window.location='Cnt.aspx';",
                      true);
        }
    }
}