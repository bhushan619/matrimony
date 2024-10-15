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
using System.Text;

public partial class Admin_Email : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    string[] arg = new string[2];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../register/FranchiseeRegisterj.aspx';</script>");
            Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else
        {
            if (!IsPostBack)
            {
                AdminBasicData();
                divimg.Visible = false;
                 divtext.Visible = false;
               // getDataInGridview();
                notifications();
            }
        }
        
    }
    public void AdminBasicData()
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varName, varProfilePic FROM tblampersonnel WHERE intId ='" + Session["adminid"] + "'", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {

                lblAdminName.Text = dbc.dr["varName"].ToString();
                string ImageUr = dbc.dr["varProfilePic"].ToString();
                if (ImageUr == "")
                {
                    imgAdminPhoto.ImageUrl = "~/admin/media/NoProfile.jpg";
                }
                else
                {

                    imgAdminPhoto.ImageUrl = "~/admin/media/" + ImageUr;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Some problem Please try again');", true);
            }
            dbc.dr.Dispose();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
            dbc.dr.Dispose();
            dbc.con.Close();
        }
    }
    public void notifications()
    {
        try
        {
            lnkNotifications.Text = dbc.count_tblamnotifications(Session["adminid"].ToString(), "Admin").ToString();
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
        Session["adminid"] = "";
        Session.Remove("adminid");

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("~/Default.aspx");
    }
    private string PopulateBody(string memid, string Name, string EmailId,string text)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Admin/emails/MatchProfile.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{Name}", Name);
        body = body.Replace("{EmailId}", EmailId);
        body = body.Replace("{TextMatter}", text);
        body = body.Replace("{emailtype}", ddlemailtype.Text);
        //body = body.Replace("{fileName}", fileName);
        return body;
    }
    private string PopulateBody(string memid, string Name, string EmailId, string text,string img,string visibility)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Admin/emails/MatchProfile.html")))
        {
            body = reader.ReadToEnd();
        }
        body = body.Replace("{Name}", Name);
        body = body.Replace("{EmailId}", EmailId);
        body = body.Replace("{TextMatter}", text);
        body = body.Replace("{ImageMatter}", img);
        body = body.Replace("{VisibilityImage}", visibility);
        body = body.Replace("{emailtype}", ddlemailtype.Text);

        return body;
    }
    protected void sendmail(string id, string name,string email,string text, string img)//, string cos)
    {
        try
        {
            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(email)))
            {
                mm.Subject = txtsubject.Text;

                if (img == "")
                {
                    mm.Body = PopulateBody(id, name, email, text, img, "hidden");
                }
                else
                {
                    mm.Body = PopulateBody(id, name, email, text, img, "");
                }


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

                ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                         "alert('Email sent Successfully');", true);
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
    
    protected void ddlContent_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlContent.Text == "Text")
            {
                divtext.Visible = true;
                divimg.Visible = false;

            }
            else if (ddlContent.Text == "Image")
            {
                divimg.Visible = true;
                divtext.Visible = false;
            }
            else if (ddlContent.Text == "Both")
            {
                divimg.Visible = true;
                divtext.Visible = true;
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
    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        string mat = string.Empty;
         string fileName= string.Empty;
        try
        {
          
            if (ddlContent.Text == "Text")
            {
                //divtext.Visible = true;
                // divimg.Visible = false;
                fileName = "Noimagefound.jpg";
                mat = txtmatter.Text;
                if (ddlemailto.Text == "All Member")
                {
                    SendTextEmail("SELECT varMemberId,varMemberName,varEmail FROM tblammemberregistration WHERE  varMemberStatus='Verified'");
                }
                else if (ddlemailto.Text == "Paid Member")
                {
                    SendTextEmail("SELECT varMemberId,varMemberName,varEmail FROM tblammemberregistration WHERE varMembershipType='Paid' and varMemberStatus='Verified'");
                }
                else if (ddlemailto.Text == "Unpaid Member")
                {
                    SendTextEmail("SELECT varMemberId,varMemberName,varEmail FROM tblammemberregistration WHERE varMembershipType='UnPaid' and varMemberStatus='Verified'");
                }
            }
            else if (ddlContent.Text == "Image")
            {
                int contentLength = fupProPic.PostedFile.ContentLength;//You may need it for validation
                string contentType = fupProPic.PostedFile.ContentType;//You may need it for validation
                 fileName = fupProPic.PostedFile.FileName;
                fupProPic.PostedFile.SaveAs(Server.MapPath("~/admin/media/email/") + fileName);
                if (ddlemailto.Text == "All Member")
                {
                    SendImageEmail("SELECT varMemberId,varMemberName,varEmail FROM tblammemberregistration WHERE  varMemberStatus='Verified'", "swapnpurti.in/Admin/media/email/" + fileName);
                }
                else if (ddlemailto.Text == "Paid Member")
                {

                    SendImageEmail("SELECT varMemberId,varMemberName,varEmail FROM tblammemberregistration WHERE varMembershipType='Paid' and varMemberStatus='Verified'", "swapnpurti.in/Admin/media/email/" + fileName);
                }
                else if (ddlemailto.Text == "Unpaid Member")
                {
                    SendImageEmail("SELECT varMemberId,varMemberName,varEmail FROM tblammemberregistration WHERE varMembershipType='Unpaid' and varMemberStatus='Verified'", "swapnpurti.in/Admin/media/email/" + fileName);

                }
            }
            else if (ddlContent.Text == "Both")
            {
                divimg.Visible = true;
                divtext.Visible = true;
                int contentLength = fupProPic.PostedFile.ContentLength;//You may need it for validation
                string contentType = fupProPic.PostedFile.ContentType;//You may need it for validation
                fileName = fupProPic.PostedFile.FileName;
                fupProPic.PostedFile.SaveAs(Server.MapPath("~/admin/media/email/") + fileName);
                
                if (ddlemailto.Text == "All Member")
                {
                    SendBothEmail("SELECT varMemberId,varMemberName,varEmail FROM tblammemberregistration WHERE  varMemberStatus='Verified'", txtmatter.Text, "http://swapnpurti.in/Admin/media/email/" + fileName);
                }
                else if (ddlemailto.Text == "Paid Member")
                {
                    SendBothEmail("SELECT varMemberId,varMemberName,varEmail FROM tblammemberregistration WHERE varMembershipType='Paid' and varMemberStatus='Verified'", txtmatter.Text, "http://swapnpurti.in/Admin/media/email/" + fileName);
                }
                else if (ddlemailto.Text == "Unpaid Member")
                {
                    SendBothEmail("SELECT varMemberId,varMemberName,varEmail FROM tblammemberregistration WHERE varMembershipType='Unpaid' and varMemberStatus='Verified'", txtmatter.Text, "http://swapnpurti.in/Admin/media/email/" + fileName);
                }
            }

            int insert_ok = dbc.insert_tblammsendemaildetails(ddlemailtype.Text, ddlemailto.Text, txtsubject.Text, ddlContent.Text, txtmatter.Text, fileName);

            if (insert_ok == 1)
            {

                ScriptManager.RegisterStartupScript(
                       this,
                       this.GetType(),
                       "MessageBox",
                        "alert('Email sent Successfully');", true);
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
        txtmatter.Text = "";
        txtsubject.Text = "";
        ddlContent.SelectedIndex = 0;
        ddlemailto.SelectedIndex = 0;
        ddlemailtype.SelectedIndex = 0;

    }
    public void SendTextEmail(string query)
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand(query + " and intId between 1 and 500 ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            while (dbc.dr.Read())
            {
                sendmail(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString(), txtmatter.Text, "");
                //  PopulateBody(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString());
            }
            dbc.con.Close();
            cmde.Dispose();
            dbc.con.Close();
            cmde = new MySql.Data.MySqlClient.MySqlCommand(query + " and intId between 501 and 1000 ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            while (dbc.dr.Read())
            {
                sendmail(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString(), txtmatter.Text, "");
                //  PopulateBody(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString());
            }
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
    public void SendImageEmail(string query,string imagepath)
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand(query + " and intId between 1 and 500 ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            while (dbc.dr.Read())
            {
                sendmail(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString(), "", imagepath);
                //  PopulateBody(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString());
            }
            dbc.con.Close();
            cmde.Dispose();
            dbc.con.Close();
            cmde = new MySql.Data.MySqlClient.MySqlCommand(query + " and intId between 501 and 1000 ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            while (dbc.dr.Read())
            {
                sendmail(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString(), "", imagepath);
                //  PopulateBody(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString());
            }
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
    public void SendBothEmail(string query, string textmatter, string imagepath)
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand(query + " and intId between 1 and 500 ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            while (dbc.dr.Read())
            {
                sendmail(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString(), textmatter, imagepath);
                //  PopulateBody(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString());
            }
            dbc.con.Close();
            cmde.Dispose();
            dbc.con.Close();
            cmde = new MySql.Data.MySqlClient.MySqlCommand(query + " and intId between 501 and 1000 ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            while (dbc.dr.Read())
            {
                sendmail(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString(), textmatter, imagepath);
                //  PopulateBody(dbc.dr["varMemberId"].ToString(), dbc.dr["varMemberName"].ToString(), dbc.dr["varEmail"].ToString());
            }
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