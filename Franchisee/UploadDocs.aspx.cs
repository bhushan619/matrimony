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

public partial class Franchisee_UploadDocs : System.Web.UI.Page
{

    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../register/FranchiseeRegisterj.aspx';</script>");
            Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
            FranchiseeBasicData();
            getDocument();
            notifications();
         

        }
    }
    public void FranchiseeBasicData()
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId, varName, varProfilePic FROM tblampersonnel WHERE varFranchiseeId ='" + Session["fid"].ToString() + "'", dbc.con);
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
    public void notifications()
    {
        try
        {
            lnkNotifications.Text = dbc.count_tblamnotifications(Session["fid"].ToString(), "Franchisee").ToString();
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
    public void getDocument()
    {
        try
        {
            dt.Clear();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varDocPath,varCaption,varStatus FROM tblampersonneldocuments WHERE varFranchiseeId='" + Session["fid"].ToString() + "'", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            ad1.Fill(dt);
           grddocument.DataSource = dt;
            grddocument.DataBind();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {

        try
        {
            int contentLength = fupProPic.PostedFile.ContentLength;//You may need it for validation
            string contentType = fupProPic.PostedFile.ContentType;//You may need it for validation
            string fileName = Session["fid"].ToString() + fupProPic.PostedFile.FileName;
            if (contentLength == 0)
            {
                string myStr = imgProPic.ImageUrl;
                string[] ssize = myStr.Split('/');
                fileName = ssize[3].ToString();
               
                int insert_ok = dbc.insert_tblampersonneldocuments(Session["fid"].ToString(), fileName,txtcaption.Text);

                if (insert_ok == 1)
                {
                    ScriptManager.RegisterStartupScript(
                       this,
                       this.GetType(),
                       "MessageBox",
                       "alert('Document Uploaded !!!');window.location='UploadDocs.aspx';", true);
                }
            }
            else
            {
                int insert_ok = dbc.insert_tblampersonneldocuments(Session["fid"].ToString(), fileName,txtcaption.Text);
                fupProPic.PostedFile.SaveAs(Server.MapPath("~/admin/media/frdocs/") + fileName);
                if (insert_ok == 1)
                {
                    ScriptManager.RegisterStartupScript(
                       this,
                       this.GetType(),
                       "MessageBox",
                       "alert('Document Uploaded  !!!');window.location='UploadDocs.aspx';", true);

                }

            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void grddocument_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName == "de")
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("DELETE  FROM anuvaa_matrimony.tblampersonneldocuments WHERE intId=" + e.CommandArgument + "", dbc.con);
            //dbc.con.Open();
            cmde.ExecuteNonQuery();
            dbc.con.Close();
            ScriptManager.RegisterStartupScript(
                this,
                this.GetType(),
                "MessageBox",
                "alert('Image Deleted');window.location='UploadDocs.aspx';", true);
        }
    }
}