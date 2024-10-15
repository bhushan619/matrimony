using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class Register_FranchiseeRegisterj : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    string gen = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new MySql.Data.MySqlClient.MySqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

        if (!IsPostBack)
        {
        }
    }

    private string PopulateBody(string name, string EmailId, string VerifyLink)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Admin/emails/register.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{name}", name);
        body = body.Replace("{EmailId}", EmailId);
        body = body.Replace("{VerifyLink}", VerifyLink);
        return body;
    }
    protected void sendmail(string verify)//, string cos)
    {
        try
        {
            string mess = string.Empty;
            string email = string.Empty;

            mess = "http://swapnpurti.in/Admin/verify.aspx?fvid=";
            email = txtEmail.Text;

            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(email)))
            {
                mm.Subject = "Swapnpurti Matrimony : Verification Email";

                mm.Body = PopulateBody(txtMemberName.Text, email, mess + verify);

                mm.IsBodyHtml = true;

              
                System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient();
                //for server

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

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {

            if (dbc.check_already_franchisee(txtEmail.Text) == 1)
            {
                // pass.Visible = true;
                lblError.Text = "This Email is already registered. Did You forget password? If yes please retrieve your password.";
            }

            else
            {
                string verify = dbc.CreateRandomPassword(8);
                string franid = string.Concat("SMFR", dbc.CreateRandomMemberId(7));
                int insert_ok = dbc.insert_tblRegisterFranchisee(franid, txtMemberName.Text, txtMobile.Text, verify, txtEmail.Text, verify, txtPassword.Text);

                if (insert_ok == 1)
                {
                    dbc.insert_tblamnotifications("Session", franid, txtMemberName.Text, "Franchisee", 1.ToString(), "Admin", "New Franchisee registeres", "~/Admin/Franchisee/ViewFranchiseeProfile.aspx", franid, "Unread", "");
                    sendmail(verify);
                    ScriptManager.RegisterStartupScript(
                       this,
                       this.GetType(),
                       "MessageBox",
                       "alert('Registration completed please check email for verification');window.location='../register/FranchiseeRegisterj.aspx';", true);

                    clear();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert(' Please try again...!!!');", true);
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
    public void clear()
    {
        txtEmail.Text = "";
        txtMemberName.Text = "";
        txtMobile.Text = "";
        txtPassword.Text = "";

    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        loginmethod();
    }
    public void loginmethod()
    {
        try
        {
            string uname = txtUsername.Text;
            string pass = txtpass.Text;
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varFranchiseeId, varName, varDesignation, varAddress, varCity, varState, varCountry, varPinCode, varEmail, varEmailVerify, varMobile, varMobileVerify, varLandline, varPassword, varStatus, varRegDate, varRegTime, varProfilePic, ex2 FROM tblampersonnel where varEmail='" + uname + "' and varEmailVerify='true'", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (dbc.dr["varPassword"].ToString() == pass)
                {
                    if (dbc.dr["varDesignation"].ToString() == "Admin")
                    {
                        Session.Add("adminid", dbc.dr["intId"].ToString());
                        Response.Redirect("~/Admin/Personal/Default.aspx");

                    }
                    else if (dbc.dr["varDesignation"].ToString() == "Franchisee")
                    {
                        //    Session.Add("adminid", dbc.dr["intId"].ToString());
                        //    Response.Redirect("~/Franchisee/Default.aspx");
                        if (dbc.dr["varStatus"].ToString() == "Approve")
                        {
                            string data = dbc.dr["varFranchiseeId"].ToString();
                            Session.Add("fid", data);
                            dbc.dr.Close();
                            Response.Redirect("~/Franchisee/Default.aspx",false);
                        }
                        else
                        {
                            Response.Write("<script>alert('Your login is being suspended.. Please contact support..');window.location='../Contact.aspx';</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Password Please Try Again');window.location='../register/FranchiseeRegisterj.aspx';</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Email Not recognised.. Please Try Again');window.location='../register/FranchiseeRegisterj.aspx';</script>");

            }
        }
        catch (Exception ex)
        {
           // Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    protected void btnforgetpassword_Click(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName, varMemberId,varEmail,varPassword FROM tblammemberregistration WHERE varEmail ='" + txtEmail.Text + "'", dbc.con);

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
              "alert('Please Check Email..');window.location='../register/FranchiseeRegisterj.aspx';", true);

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
                //for server

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