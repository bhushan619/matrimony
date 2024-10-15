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
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text;


using Ionic.Zip;
 

public partial class Admin_Reports_FranchiseeData : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
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
                getActiveGridview();

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
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
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
    public void getActiveGridview()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId,  varName,  varMobile,varEmail ,varAddress, varCity,varState , varStatus, varProfilePic  FROM tblampersonnel WHERE varDesignation='Franchisee' and varStatus!='Inactive' order by varRegDate desc", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dt);
            grdActiveFranchisee.DataSource = dt;
            grdActiveFranchisee.DataBind();


            dbc.con.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    public void ExportToExcel()
    {
        dt.Clear();
        dbc.con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId as FranchiseeId,  varName as Name, varAddress as Address,varMobile as Mobile ,varLandline as Landline,varEmail as EmailId, varCity as City,varState as State, varStatus as Status,varRegDate as RegistrationDate FROM tblampersonnel WHERE varDesignation='Franchisee' and varStatus!='Inactive'", dbc.con);// WHERE varMembershipType='Unpaid' and  varMemberStatus='Verified'", dbc.con);
        //for  img in excel//
        // MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varMembershipType,  varMemberName, varGender, varMobile,varMemberStatus,varCreatorDesignation, concat('http://localhost:4076/swapnpurti.in/Members/media/',varPhoto) as varPhoto   FROM tblammemberregistration WHERE varMembershipType='Unpaid' and  varMemberStatus='Verified'", dbc.con);
        MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
        ad1.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            string filename = "AnuvaaMatrimonyFranchiseeData" + DateTime.UtcNow.ToString("dd-MMM-yyyy-HHmmss") + ".xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            DataGrid dgGrid = new DataGrid();
            dgGrid.DataSource = dt;
            dgGrid.DataBind();

            //Get the HTML for the control.
            dgGrid.RenderControl(hw);
            //Write the HTML back to the browser.
            //Response.ContentType = application/vnd.ms-excel;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }
    }
    protected void grdActiveFranchisee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdActiveFranchisee.PageIndex = e.NewPageIndex;
        getActiveGridview();
       
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnimages_Click(object sender, EventArgs e)
    {


        dbc.con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT   concat('D:/matrimony/swapnpurti.in/admin/media/',varProfilePic) as varProfilePic    FROM tblampersonnel where varProfilePic!='NoProfile.jpg'", dbc.con);// WHERE varMembershipType='Unpaid' and  varMemberStatus='Verified'", dbc.con);
        DataTable dt = new DataTable();
        MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
        ad1.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        dbc.con.Close();

        using (ZipFile zip = new ZipFile())
        {
            zip.AlternateEncodingUsage = ZipOption.AsNecessary;
            zip.AddDirectoryByName("Files");

            string filePath = string.Empty;
            foreach (GridViewRow dr in GridView1.Rows)
            {

                filePath = dr.Cells[0].Text.ToString();

                zip.AddFile(filePath, "Files");

            }
            Response.Clear();
            Response.BufferOutput = false;
            string zipName = String.Format("AnuvaaMatrimonyFranchiseeImages_{0}.zip", DateTime.UtcNow.ToString("dd-MMM-yyyy-HHmmss"));
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
            zip.Save(Response.OutputStream);
            Response.End();
        }
    }
    protected void btnExportUnpaid_Click(object sender, EventArgs e)
    {
        ExportToExcel();
    }
}