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

public partial class Admin_Franchisee_ApproveDocs : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    DatabaseConnection dbc = new DatabaseConnection();


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
                notifications();
                getDocument();
            }
        }

    }
    public void getDocument()
    {
        try
        {
            dt.Clear();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varDocPath,varCaption,varStatus FROM tblampersonneldocuments WHERE varFranchiseeId='" + Session["fid"].ToString() + "' ", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            ad1.Fill(dt);
            grdFranchDocument.DataSource = dt;
            grdFranchDocument.DataBind();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
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
    protected void lnkApprove_Click(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblampersonneldocuments SET varStatus='Approved' WHERE 	intId='" + (sender as LinkButton).CommandArgument + "' and varFranchiseeId='" + Session["fid"].ToString() + "'", dbc.con);

            cmd.ExecuteNonQuery();
            dbc.con.Close();
            cmd.Dispose();
            dbc.insert_tblamnotifications("Message", Session["adminid"].ToString(), lblAdminName.Text, "Admin", Session["fid"].ToString(), "Franchisee", "Congratulations !!! Your Document is Approved...", "", "", "Unread", "");
            ScriptManager.RegisterStartupScript(
                              this,
                              this.GetType(),
                              "MessageBox",
                              "alert(' Document Approved !!!');window.location='ApproveDocs.aspx';", true);
            // Response.Redirect("ApproveMembersPictures.aspx");
        }
        catch (Exception s)
        {
            dbc.con.Close();

        }
    }
    protected void lnkReject_Click(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblampersonneldocuments SET varStatus='Rejected' WHERE 	intId='" + (sender as LinkButton).CommandArgument + "' and varFranchiseeId='" + Session["fid"].ToString() + "'", dbc.con);

            cmd.ExecuteNonQuery();
            dbc.con.Close();
            cmd.Dispose();
            dbc.insert_tblamnotifications("Page", Session["adminid"].ToString(), lblAdminName.Text, "Admin", Session["fid"].ToString(), "Franchisee", " Your Document is Rejected...Please Upload Valid Document..", "~/Franchisee/UploadDocs.aspx", "", "Unread", "");
            ScriptManager.RegisterStartupScript(
                             this,
                             this.GetType(),
                             "MessageBox",
                             "alert(' Document Rejected !!!');window.location='ApproveDocs.aspx';", true);
        }
        catch (Exception s)
        {
            dbc.con.Close();
        }
    }

   
}