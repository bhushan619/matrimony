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


public partial class Register_Loginj : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();

    RegexUtilities rex = new RegexUtilities();

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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            Client_ID = ConfigurationSettings.AppSettings["google_clientId"].ToString();
            Return_url = ConfigurationSettings.AppSettings["google_RedirectUrl"].ToString();

        }
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

            /*
                 
            "id": "109124950535374******"
              "email": "usernamil@gmail.com"
              "verified_email": true
              "name": "firstname lastname"
              "given_name": "firstname"
              "family_name": "lastname"
              "link": "https://plus.google.com/10912495053537********"
              "picture": "https://lh3.googleusercontent.com/......./photo.jpg"
              "gender": "male"
              "locale": "en" } 
           */

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
            gender = ar.GetValue(8).ToString();

        }
       

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (rex.IsValidEmail(txtEmail.Text))
            {
                loginmethod();
            }
            else
            {
                loginmethodbyuserid();
            }
        }
        catch (Exception rx)
        {
            ScriptManager.RegisterStartupScript(
                         this,
                         this.GetType(),
                         "MessageBox",
                          "alert('Please Try Again...!!!);", true);

        }
    }
    public void loginmethod()
    {
        try
        {
            string uname = txtEmail.Text;
            string pass = txtPassword.Text;
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select intId,varMemberId,varEmail,varPassword,varMemberStatus,varCreatorDesignation from anuvaa_matrimony.tblammemberregistration where varEmail='" + uname + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (dbc.dr["varPassword"].ToString() == pass)
                {
                    //if (dbc.dr["varCreatorDesignation"].ToString() == "Admin")
                    //{
                    //    Session.Add("adminid", dbc.dr["intId"].ToString());
                    //    Response.Redirect("~/Admin/Default.aspx");

                    //}
                    //else 
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
                        Response.Write("<script>alert('Please Try Again...!!!');window.location='login.aspx';</script>");
                    }
                    dbc.dr.Close();
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Password Please Try Again...!!!');window.location='login.aspx';</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Email Not Recognised. Please Try Again...!!!');window.location='login.aspx';</script>");

            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    public void loginmethodbyuserid()
    {
        try
        {
            string uname = txtEmail.Text;
            string pass =  txtPassword.Text;;
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select intId,varMemberId,varEmail,varPassword,varMemberStatus,varCreatorDesignation from anuvaa_matrimony.tblammemberregistration where varMemberId='" + uname + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (dbc.dr["varPassword"].ToString() == pass)
                {
                    //if (dbc.dr["varCreatorDesignation"].ToString() == "Admin")
                    //{
                    //    Session.Add("adminid", dbc.dr["intId"].ToString());
                    //    Response.Redirect("~/Admin/Default.aspx");

                    //}
                    //else 
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
                        Response.Write("<script>alert('Please Try Again...!!!');window.location='login.aspx';</script>");
                    }
                    dbc.dr.Close();
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Password Please Try Again...!!!');window.location='login.aspx';</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Member ID Not Recognised. Please Try Again');window.location='login.aspx';</script>");

            }

        }
        catch (Exception ex)
        {
           // Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }
  




}