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
public partial class Register_facebooklogin : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    string IdIn = string.Empty;
    string memberId = string.Empty;
    string status = string.Empty;
    string img = string.Empty;
    string filename = string.Empty;
    string gender = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {


            if (Request.QueryString["emls"] == null)
            {
            }
            else if (Request.QueryString["nmes"] == null)
            {
            }
            else if (Request.QueryString["grns"] == null)
            {
            }
            else if (Request.QueryString["idsf"] == null)
            {
            }
            else
            {
                /* login code */
                if (dbc.check_already_Member(Request.QueryString["emls"].ToString()) == 1)
                {
                    string uname = Request.QueryString["emls"].ToString();

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
                    gender = UppercaseFirst(Request.QueryString["grns"].ToString());

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
                    int insert_ok = dbc.insert_tblammemberregistration(memberId, "Unpaid", "Myself", Request.QueryString["nmes"].ToString(), gender, "", verify, Request.QueryString["emls"].ToString(), "true", "VerifiedFirstTime", "Member", "NA", "Member", passcode, img);

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
    private string PopulateBody(string name, string EmailId, string pass, string memid)
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

            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(Request.QueryString["emls"].ToString())))
            {
                mm.Subject = "Swapnpurti Matrimony : Login Details";

                mm.Body = PopulateBody(Request.QueryString["nmes"].ToString(), Request.QueryString["emls"].ToString(), pass, memberId);

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