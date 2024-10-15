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

public partial class Franchisee_RegisterMember : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    string gen = string.Empty;
    string IdIn = string.Empty;
    string memberId = string.Empty;
    string status = string.Empty;
    string img = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../register/FranchiseeRegisterj.aspx';</script>");
            Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else
            if (!IsPostBack)
            {
                notifications();
                FranchiseeBasicData();
            }


    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblamnotifications(Session["fid"].ToString(), "Franchisee").ToString();
    }
    public void FranchiseeBasicData()
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId, varName, varProfilePic FROM tblampersonnel WHERE varFranchiseeId ='" + Session["fid"] + "'", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblFranchiseeId.Text = dbc.dr["varFranchiseeId"].ToString();
                lblFranchiseeName.Text = dbc.dr["varName"].ToString();
                string ImageUr = dbc.dr["varProfilePic"].ToString();
                if (ImageUr == "")
                {
                    imgFranchiseePhoto.ImageUrl = "~/admin/media/NoProfile.jpg";
                }
                else
                {

                    imgFranchiseePhoto.ImageUrl = "~/admin/media/" + ImageUr;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Some problem Please try again...!!!');", true);
            } dbc.con.Close();
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
        Session["fid"] = "";
        Session.Remove("fid");

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("~/Default.aspx");
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
            //if (cos == "c")
            //{
            mess = "http://swapnpurti.in/Admin/verify.aspx?mvid=";
            email = txtEmail.Text;
            //}
            //else
            //{
            //    mess = "http://swapnpurti.in/Admin/verify.aspx?evid=";
            //    email = txtEmail.Text;
            //}
            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(email)))
            {
                mm.Subject = "Swapnpurti Matrimony : Verification Email";

                mm.Body = PopulateBody(txtMemberName.Text, email, mess + verify);

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
    public void sendsms()
    {
        try
        {
            string strUrl = string.Empty;//= "http://www.txtguru.in/imobile/api.php?username=amitmanore21&password=amit2107&source=senderid&dmobile=91" + dbc.select_TahsildarNo(Session["tal"].ToString()) + "&message=The SI " + Session["name"].ToString() + " of your taluka has completed a checking. Please check your portal and approve until tomorrow 5 PM.";
            WebRequest request = HttpWebRequest.Create(strUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            response.Close();
            s.Close();
            readStream.Close();
        }
        catch (Exception ex)
        {

        }

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            
            if (rgbFemale.Checked)
            {
                gen = rgbFemale.Text;
                IdIn = "SMF";
                img = "FemaleNoProfile.jpg";
            }
            else if (rgbMale.Checked)
            {
                gen = rgbMale.Text;
                IdIn = "SMM";
                img = "MaleNoProfile.jpg";
            }
            //else if (rgbOther.Checked)
            //{
            //    gen = rgbOther.Text;
            //    IdIn = "SMO";
            //    img = "NoProfile.jpg";
            //}
            if (dbc.check_already_Member(txtEmail.Text) == 1)
            {
                // pass.Visible = true;
                lblError.Text = "This Email is already registered. Did You forget password? If yes please retrieve your password.";
            }

            else
            {
                string verify = dbc.CreateRandomPassword(8);

                memberId = string.Concat(IdIn, dbc.CreateRandomMemberId(7));

                int insert_ok = dbc.insert_tblammemberregistration(memberId, "Unpaid", ddlProfileFor.Text, txtMemberName.Text, gen.ToString(), txtMobile.Text, verify, txtEmail.Text, verify, "UnVerified", Session["fid"].ToString(), "NA", "Franchisee", txtPassword.Text, img);

                if (insert_ok == 1)
                {
                  //  dbc.insert_tblamnotifications("Message", Session["fid"].ToString(), lblFranchiseeName.Text, "Franchisee", memberId, "Admin", "New Member Added By Franchise :" + lblFranchiseeName.Text + " " + Session["fid"].ToString(), "", "", "Unread", "");
                    sendmail(verify);
                    ScriptManager.RegisterStartupScript(
                       this,
                       this.GetType(),
                       "MessageBox",
                       "alert('Registration completed please check email for verification');", true);

                    clear();
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
    public void clear()
    {
        txtEmail.Text = "";
        txtMemberName.Text = "";
        txtMobile.Text = "";
        txtPassword.Text = "";
        ddlProfileFor.SelectedIndex = 0;
    }
}