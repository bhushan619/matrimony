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

public partial class Register_Registrationj : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {

        //if (!this.IsPostBack)
        //{

        Client_ID = ConfigurationManager.AppSettings["google_clientId"].ToString();
        Return_url = ConfigurationManager.AppSettings["google_RedirectUrl"].ToString();

        //}

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
    protected void sendmail(string verify)
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
                mm.Subject = "Swapnpurti Matrimony : Verification Email...!!!";

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
           // Response.Write("<script>alert('Please Try Again');window.location='Registration.aspx';</script>");
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
            if (ddlGender.Text == "Female")
            {
                IdIn = "SMF";
                img = "FemaleNoProfile.jpg";
            }
            else if (ddlGender.Text == "Male")
            {
                IdIn = "SMM";
                img = "MaleNoProfile.jpg";
            }
            //else if (ddlGender.Text == "Other")
            //{
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
                if (txtFranchisee.Text == "")
                {
                    insert("NA", "Member");
                }
                else
                {
                    string[] arry = txtFranchisee.Text.Split(new char[] { ';' });
                    int ok = dbc.check_if_franchisee(arry[0].ToString());
                    if (ok == 1)
                    {
                        insert(arry[0].ToString(), "Franchisee");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(
                            this,
                            this.GetType(),
                            "MessageBox",
                            "alert('Please Enter Correct Franchisee Details...!!!');window.location='Registration.aspx';", true);
                    }
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
    public void insert(string franchisee, string desig)
    {

        try
        {
            string verify = dbc.CreateRandomPassword(8);
            memberId = string.Concat(IdIn, dbc.CreateRandomMemberId(7));

            int insert_ok = dbc.insert_tblammemberregistration(memberId, "Unpaid", ddlProfileFor.Text, txtMemberName.Text, ddlGender.Text, txtMobile.Text, verify, txtEmail.Text, verify, "Unverified", franchisee, "NA", desig, txtPassword.Text, img);

            if (insert_ok == 1)
            {
                biodata();
                sendmail(verify);


                ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('Registration completed please check email for verification...!!!');window.location='Registration.aspx';", true);

                clear();
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
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
        }
    }

    public void biodata()
    {

        try
        {
            int contentLength = fupBiodata.PostedFile.ContentLength;//You may need it for validation
            string contentType = fupBiodata.PostedFile.ContentType;//You may need it for validation
            string fileName = fupBiodata.PostedFile.FileName;

            string ffileExt = System.IO.Path.GetExtension(fupBiodata.FileName);
            if (contentLength == 0)
            {

            }
            else
            {
                if ((ffileExt == ".doc") || (ffileExt == ".docx") || (ffileExt == ".pdf") || (ffileExt == ".DOC") || (ffileExt == ".DOCX") || (ffileExt == ".PDF"))
                {
                    filename = memberId + fupBiodata.FileName.ToString();
                    int insert_upload = dbc.insert_tblammemberuploads(memberId, "Biodata", "NA", "NA", filename, "Protected");

                    if (insert_upload == 1)
                    {
                        fupBiodata.SaveAs(Server.MapPath("~/members/media/biodata/") + filename);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Please select proper file as .doc,.docx or .pdf ...!!!');", true);
                    return;
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
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
    {
        String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);
        con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varFranchiseeId,';',varAddress,';',varCity) AS Franchisee FROM  anuvaa_matrimony.tblampersonnel  where varFranchiseeId like '%" + prefixText + "%' OR varCity like '%" + prefixText + "%'", con);
        //     cmd.Parameters.AddWithValue("@Name", prefixText);
        MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
        DataTable dtc = new DataTable();
        da.Fill(dtc);

        List<string> CompanyName = new List<string>();
        for (int i = 0; i < dtc.Rows.Count; i++)
        {
            CompanyName.Add(dtc.Rows[i][0].ToString());
            //  CompanyName[j++] =dt.Rows[i][0].ToString();
        }
        con.Close();
        return CompanyName;
    }
    public void clear()
    {
        txtEmail.Text = "";
        txtMemberName.Text = "";
        txtMobile.Text = "";
        txtPassword.Text = "";
        ddlProfileFor.SelectedIndex = 0;
    }

    protected void btngooglelodin_Click(object sender, ImageClickEventArgs e)
    {

        //try
        //{

        //  if (Request.QueryString["access_token"] != null)
        //{
        //    String URI = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + Request.QueryString["access_token"].ToString();


        //    WebClient webClient = new WebClient();
        //    Stream stream = webClient.OpenRead(URI);
        //    string b;

        //    /*I have not used any JSON parser because I do not want to use any extra dll/3rd party dll*/
        //    using (StreamReader br = new StreamReader(stream))
        //    {
        //        b = br.ReadToEnd();
        //    }

        //    b = b.Replace("id", "").Replace("email", "");
        //    b = b.Replace("given_name", "");
        //    b = b.Replace("family_name", "").Replace("link", "").Replace("picture", "");
        //    b = b.Replace("gender", "").Replace("locale", "").Replace(":", "");
        //    b = b.Replace("\"", "").Replace("name", "").Replace("{", "").Replace("}", "");

        //    Array ar = b.Split(",".ToCharArray());
        //    for (int p = 0; p < ar.Length; p++)
        //    {
        //        ar.SetValue(ar.GetValue(p).ToString().Trim(), p);

        //    }
        //    Email_address = ar.GetValue(1).ToString();
        //    Google_ID = ar.GetValue(0).ToString();
        //    firstName = ar.GetValue(4).ToString();
        //    LastName = ar.GetValue(5).ToString();

        //    FullName = ar.GetValue(3).ToString();
        //    googlelink = ar.GetValue(6).ToString();
        //    gphoto = ar.GetValue(7).ToString();
        //    gender = ar.GetValue(8).ToString();

        //  }

        //    string verify = dbc.CreateRandomPassword(8);
        //    memberId = string.Concat(IdIn, dbc.CreateRandomMemberId(7));
        //    string passcode = dbc.CreateRandomPassword(8);
        //    int insert_ok = dbc.insert_tblammemberregistration(memberId, "Unpaid", "", FullName, gender, "", verify, Email_address, verify, "Unverified", "Member", "NA", "Member", passcode, gphoto);

        //    if (insert_ok == 1)
        //    {

        //        sendmail(verify);


        //        ScriptManager.RegisterStartupScript(
        //           this,
        //           this.GetType(),
        //           "MessageBox",
        //           "alert('Registration completed please check email for verification');window.location='Registration.aspx';", true);

        //        clear();
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(
        //      this,
        //      this.GetType(),
        //      "MessageBox",
        //      "alert('Some problem Please try again');window.location='Registration.aspx';", true);
        //    }
        //}
        //catch (Exception ex)
        //{
        //    ScriptManager.RegisterStartupScript(
        //           this,
        //           this.GetType(),
        //           "MessageBox",
        //           "alert('" + ex.Message + "');", true);
        //}
    }
}