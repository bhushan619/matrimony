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


public partial class Register_googlelogin : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();

    string IdIn = string.Empty;
    string memberId = string.Empty;
    string status = string.Empty;
    string img = string.Empty;
    string filename = string.Empty;

    public string Email_address = "";
    public string Google_ID = "";
    public string firstName = "";
    public string LastName = "";
    public string Client_ID = "";
    public string Return_url = "";

    public string FullName = "";
    public string googlelink = "";
    public string gphoto = "";
    public string gender = "";
    static string UppercaseFirst(string s)
    {
        // Check for empty string.
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        // Return char and concat substring.
        return char.ToUpper(s[0]) + s.Substring(1);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            //if (!this.IsPostBack)
            //{

            Client_ID = ConfigurationManager.AppSettings["google_clientId"].ToString();
            Return_url = ConfigurationManager.AppSettings["google_RedirectUrl"].ToString();


            if (Request.QueryString["access_token"] != null)
            {
                String URI = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + Request.QueryString["access_token"].ToString();


                WebClient webClient = new WebClient();
                Stream stream = webClient.OpenRead(URI);
                string b;

                /*I have not used any JSON parser because I do not want to use any extra dll/3rd party dll*/
                using (StreamReader br = new StreamReader(stream))
                {
                    b = br.ReadToEnd();
                }

                b = b.Replace("id", "").Replace("email", "");
                b = b.Replace("given_name", "");
                b = b.Replace("family_name", "").Replace("link", "").Replace("picture", "");
                b = b.Replace("gender", "").Replace("locale", "").Replace(":", "");
                b = b.Replace("\"", "").Replace("name", "").Replace("{", "").Replace("}", "");

                Array ar = b.Split(",".ToCharArray());
                for (int p = 0; p < ar.Length; p++)
                {
                    ar.SetValue(ar.GetValue(p).ToString().Trim(), p);

                }
                Email_address = ar.GetValue(1).ToString();
                Google_ID = ar.GetValue(0).ToString();
                firstName = ar.GetValue(4).ToString();
                LastName = ar.GetValue(5).ToString();

                FullName = ar.GetValue(3).ToString();
                googlelink = ar.GetValue(6).ToString();
                gphoto = ar.GetValue(7).ToString();
                gender = UppercaseFirst(ar.GetValue(8).ToString());


            }
            /* login code */
            if (dbc.check_already_Member(Email_address) == 1)
            {
                string uname = Email_address;

                MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select intId,varMemberId,varEmail,varPassword,varMemberStatus,varCreatorDesignation from anuvaa_matrimony.tblammemberregistration where varEmail='" + uname + "' ", dbc.con);
                dbc.con.Open();
                dbc.dr = cmde.ExecuteReader();
                if (dbc.dr.Read())
                {

                    if (dbc.dr["varMemberStatus"].ToString() == "VerifiedFirstTime")
                    {
                        string data = dbc.dr["varMemberId"].ToString();
                        Session.Add("memberid", data);
                        Response.Redirect("~/members/UserProfile/campaignRegistration.aspx");
                        // dbc.FirstTimeLogin(data); call it after filling compaign Registration

                    }
                    else if (dbc.dr["varMemberStatus"].ToString() == "Verified")
                    {

                        Session.Add("memberid", dbc.dr["varMemberId"].ToString());
                        Response.Redirect("~/members/Activities/Home.aspx");

                    }
                    else if (dbc.dr["varMemberStatus"].ToString() == "Deleted")
                    {

                        Session.Add("memberid", dbc.dr["varMemberId"].ToString());
                        Response.Redirect("~/Register/ActivateDeletedProfile.aspx");

                    }
                    else
                    {
                        Response.Write("<script>alert('Please Try Again');window.location='login.aspx';</script>");
                    }
                    dbc.dr.Close();
                }
            }

        /* Registration Code */

            else
            {
                if (gender == "Female")
                {
                    IdIn = "SMF";
                    img = "FemaleNoProfile.jpg";
                }
                else if (gender == "Male")
                {
                    IdIn = "SMM";
                    img = "MaleNoProfile.jpg";
                }
                //else if (ddlGender.Text == "Other")
                //{
                //    IdIn = "SMO";
                //    img = "NoProfile.jpg";
                //}

                string verify = dbc.CreateRandomPassword(8);
                memberId = string.Concat(IdIn, dbc.CreateRandomMemberId(7));
                string passcode = dbc.CreateRandomPassword(8);
                int insert_ok = dbc.insert_tblammemberregistration(memberId, "Unpaid", "Myself", FullName, gender, "", verify, Email_address, "true", "VerifiedFirstTime", "Member", "NA", "Member", passcode, img);

                if (insert_ok == 1)
                {

                    sendmail(passcode);
                    Session.Add("memberid", memberId);

                    ScriptManager.RegisterStartupScript(
                       this,
                       this.GetType(),
                       "MessageBox",
                       "alert('Registration completed please Check your Email for Password...');window.location='../Members/UserProfile/campaignRegistration.aspx';", true);

                    //  clear();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Some problem Please try again');window.location='Registration.aspx';", true);
                }
            }
            /* registration code end */
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
    private string PopulateBody(string name, string EmailId, string pass,string memid)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Admin/emails/forget.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{Name}", name);
        body = body.Replace("{memid}", memid);
        body = body.Replace("{EmailId}", EmailId);
        body = body.Replace("{pass}", pass);
        return body;
    }
    protected void sendmail(string pass)
    {
        try
        {

            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(Email_address)))
            {
                mm.Subject = "Swapnpurti Matrimony : Login Details";

                mm.Body = PopulateBody(FullName, Email_address, pass, memberId);

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
            Response.Write("<script>alert('Please Try Again');window.location='Registration.aspx';</script>");
        }
    }
       
}