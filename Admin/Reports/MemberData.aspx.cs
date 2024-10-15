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


using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


using Ionic.Zip;


public partial class Admin_Reports_MemberData : System.Web.UI.Page
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

                // PopulateCheckBoxArray();
                notifications();

                getmembersdata();
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

    public void getmembersdata()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varMembershipType,  varMemberName, varGender, varMobile,	varEmail, varPhoto ,varMemberStatus,varCreatorDesignation   FROM tblammemberregistration", dbc.con);// WHERE varMembershipType='Unpaid' and  varMemberStatus='Verified'", dbc.con);
            //for  img in excel//
            // MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varMembershipType,  varMemberName, varGender, varMobile,varMemberStatus,varCreatorDesignation, concat('http://localhost:4076/swapnpurti.in/Members/media/',varPhoto) as varPhoto   FROM tblammemberregistration WHERE varMembershipType='Unpaid' and  varMemberStatus='Verified'", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            ad1.Fill(dt);
            grdUpdaidMember.DataSource = dt;
            grdUpdaidMember.DataBind();
            dbc.con.Close();

            cmd1.Dispose();
            ad1.Dispose();
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
    public void ExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb.Columns.AddRange(new DataColumn[8] {
                        new DataColumn("MemberId", typeof(string)),
                        new DataColumn("MembershipType", typeof(string)),
                        new DataColumn("MemberName", typeof(string)),
                        new DataColumn("Gender", typeof(string)),
                        new DataColumn("Mobile", typeof(string)),
                        new DataColumn("EmailId", typeof(string)),
                        new DataColumn("MemberStatus", typeof(string)),
                        new DataColumn("CreatorDesignation", typeof(string)),
                       

        });
        Response.Clear();
        Response.Buffer = true;
        dt.Clear();
        dbc.con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct varMemberId as MemberId, varMembershipType as MembershipType,  varMemberName as MemberName, varGender as Gender, varMobile as Mobile,	varEmail as EmailId,varMemberStatus as MemberStatus,varCreatorDesignation as CreatorDesignation   FROM tblammemberregistration", dbc.con);// WHERE varMembershipType='Unpaid' and  varMemberStatus='Verified'", dbc.con);
        //for  img in excel//
        // MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varMembershipType,  varMemberName, varGender, varMobile,varMemberStatus,varCreatorDesignation, concat('http://localhost:4076/swapnpurti.in/Members/media/',varPhoto) as varPhoto   FROM tblammemberregistration WHERE varMembershipType='Unpaid' and  varMemberStatus='Verified'", dbc.con);
        MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
        ad1.Fill(dt);

           
        for (int i = 0; i < dt.Rows.Count; i++)
        {
 string filename = "AnuvaaMatrimonyMemberData" + DateTime.UtcNow.ToString("dd-MMM-yyyy-HHmmss") + ".xls";
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            GridView dgGrid = new GridView();
            
            GridViewRow row = grdUpdaidMember.Rows[i];

            foreach (TableCell cell in row.Cells)
            {
                if (cell.HasControls() == true)
                {
                    CheckBox myTextBox = row.FindControl("CheckBox1") as CheckBox;
                    if (myTextBox.Checked == true)
                    {
                        dtb.Rows.Add(grdUpdaidMember.Rows[i].Cells[0].Text, grdUpdaidMember.Rows[i].Cells[1].Text, grdUpdaidMember.Rows[i].Cells[2].Text, grdUpdaidMember.Rows[i].Cells[3].Text, grdUpdaidMember.Rows[i].Cells[4].Text, grdUpdaidMember.Rows[i].Cells[5].Text, grdUpdaidMember.Rows[i].Cells[6].Text, grdUpdaidMember.Rows[i].Cells[7].Text); 
                    }
                    else
                    {
                        // Do something here.  Default value for the post id?
                    }
                }
            }
            //Get the HTML for the control.
            dgGrid.DataSource = dtb;
            dgGrid.DataBind();
            dgGrid.RenderControl(hw);
            //Write the HTML back to the browser.
            //Response.ContentType = application/vnd.ms-excel;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
            this.EnableViewState = false;
            Response.Write(tw.ToString());
            Response.End();
        }


        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct varMemberId as MemberId, varMembershipType as MembershipType,  varMemberName as MemberName, varGender as Gender, varMobile as Mobile,	varEmail as EmailId,varMemberStatus as MemberStatus,varCreatorDesignation as CreatorDesignation   FROM tblammemberregistration", dbc.con);// WHERE varMembershipType='Unpaid' and  varMemberStatus='Verified'", dbc.con);
        //    MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
        //    ad1.Fill(dt);
        //    GridView dgGrid = new GridView();
        //    dgGrid.DataSource = dt;
        //    dgGrid.DataBind();

        //    dgGrid.AllowPaging = false;

        //    for (int i = 0; i <= dgGrid.Rows.Count - 1; i++)
        //    {
        //        GridViewRow row = dgGrid.Rows[i];
        //        foreach (TableCell cell in row.Cells)
        //        {
        //            if (cell.HasControls() == true)
        //            {
        //                if (cell.Controls[0].GetType().ToString() == "System.Web.UI.WebControls.CheckBox")
        //                {
        //                    CheckBox chk = (CheckBox)cell.Controls[0];
        //                    if (chk.Checked)
        //                    {
        //                        cell.Text = "True";
        //                    }
        //                    else
        //                    {
        //                        cell.Text = "False";
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    dgGrid.HeaderRow.Style.Add("background-color", "#FFFFFF");

        //    dgGrid.RenderControl(hw);
        //    Response.Output.Write(sw);
        //    Response.Flush();
        //    Response.End();
        //}


    } 
    
    public override void VerifyRenderingInServerForm(Control control)
    {
    /* Verifies that the control is rendered */
    //return;
    }
    protected void btnimages_Click(object sender, EventArgs e)
    {
       
 
        dbc.con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT   concat('D:/matrimony/swapnpurti.in/Members/media/',varPhoto) as varPhoto    FROM tblammemberregistration where varPhoto!='FemaleNoProfile.jpg' and varPhoto!='MaleNoProfile.jpg' and varPhoto!='FemaleNoProfileProtected.jpg' and varPhoto!='MaleNoProfileProtected.jpg' and varPhoto!='NoProfile.jpg' ", dbc.con);// WHERE varMembershipType='Unpaid' and  varMemberStatus='Verified'", dbc.con);
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
            string zipName = String.Format("AnuvaaMatrimonyMemberImages_{0}.zip", DateTime.UtcNow.ToString("dd-MMM-yyyy-HHmmss"));
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
    protected void grdUpdaidMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdUpdaidMember.PageIndex = e.NewPageIndex;
        getmembersdata();
        //ResetCheckBoxes(); 
    }

    private void PopulateCheckBoxArray()
    {
        ArrayList CheckBoxArray;
        if (ViewState["CheckBoxArray"] != null)
        {
            CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
        }
        else
        {
            CheckBoxArray = new ArrayList();
        }

        int CheckBoxIndex;
        bool CheckAllWasChecked = false;
        CheckBox chkAll = (CheckBox)grdUpdaidMember.HeaderRow.Cells[0].FindControl("chkAll");
        string checkAllIndex = "chkAll-" + grdUpdaidMember.PageIndex;
        if (chkAll.Checked)
        {
            if (CheckBoxArray.IndexOf(checkAllIndex) == -1)
            {
                CheckBoxArray.Add(checkAllIndex);
            }
        }
        else
        {
            if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
            {
                CheckBoxArray.Remove(checkAllIndex);
                CheckAllWasChecked = true;
            }
        }
        for (int i = 0; i < grdUpdaidMember.Rows.Count; i++)
        {
            if (grdUpdaidMember.Rows[i].RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (CheckBox)grdUpdaidMember.Rows[i].Cells[0].FindControl("CheckBox1");
                CheckBoxIndex = grdUpdaidMember.PageSize * grdUpdaidMember.PageIndex + (i + 1);
                if (chk.Checked)
                {
                    if (CheckBoxArray.IndexOf(CheckBoxIndex) == -1 && !CheckAllWasChecked)
                    {
                        CheckBoxArray.Add(CheckBoxIndex);
                    }
                }
                else
                {
                    if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1 || CheckAllWasChecked)
                    {
                        CheckBoxArray.Remove(CheckBoxIndex);
                    }
                }
            }
        }
        ViewState["CheckBoxArray"] = CheckBoxArray;
    }
    private void ResetCheckBoxes()
    {
        if (ViewState["CheckBoxArray"] != null)
        {
            ArrayList CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
            string checkAllIndex = "chkAll-" + grdUpdaidMember.PageIndex;

            if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
            {
                CheckBox chkAll = (CheckBox)grdUpdaidMember.HeaderRow.Cells[0].FindControl("chkAll");
                chkAll.Checked = true;
            }
            for (int i = 0; i < grdUpdaidMember.Rows.Count; i++)
            {

                if (grdUpdaidMember.Rows[i].RowType == DataControlRowType.DataRow)
                {
                    if (CheckBoxArray.IndexOf(checkAllIndex) != -1)
                    {
                        CheckBox chk = (CheckBox)grdUpdaidMember.Rows[i].Cells[0].FindControl("CheckBox1");
                        chk.Checked = true;
                    }
                    else
                    {
                        int CheckBoxIndex = grdUpdaidMember.PageSize * (grdUpdaidMember.PageIndex) + (i + 1);
                        if (CheckBoxArray.IndexOf(CheckBoxIndex) != -1)
                        {
                            CheckBox chk = (CheckBox)grdUpdaidMember.Rows[i].Cells[0].FindControl("CheckBox1");
                            chk.Checked = true;
                        }
                    }
                }
            }
        }
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;

        Response.AddHeader("content-disposition",
         "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        grdUpdaidMember.AllowPaging = false;
        grdUpdaidMember.DataBind();

        GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
        GridView1.HeaderRow.Cells[0].Visible = false;
        GridView1.HeaderRow.Cells[1].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[2].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[3].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[4].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[5].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[6].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[7].Style.Add("background-color", "green");
        GridView1.HeaderRow.Cells[8].Style.Add("background-color", "green");
        if (ViewState["CheckBoxArray"] != null)
        {
            ArrayList CheckBoxArray = (ArrayList)ViewState["CheckBoxArray"];
            string checkAllIndex = "chkAll-" + grdUpdaidMember.PageIndex;
            int rowIdx = 0;
            for (int i = 0; i < grdUpdaidMember.Rows.Count; i++)
            {
                GridViewRow row = grdUpdaidMember.Rows[i];
                row.Visible = false;

                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (CheckBoxArray.IndexOf(i + 1) != -1)
                    {
                        row.Visible = true;
                        row.BackColor = System.Drawing.Color.White;
                        row.Cells[0].Visible = false;
                        row.Attributes.Add("class", "textmode");
                        if (rowIdx % 2 != 0)
                        {

                            row.Cells[1].Style.Add("background-color", "#C2D69B");
                            row.Cells[2].Style.Add("background-color", "#C2D69B");
                            row.Cells[3].Style.Add("background-color", "#C2D69B");
                            row.Cells[4].Style.Add("background-color", "#C2D69B");

                            row.Cells[5].Style.Add("background-color", "#C2D69B");
                            row.Cells[6].Style.Add("background-color", "#C2D69B");
                            row.Cells[7].Style.Add("background-color", "#C2D69B");
                            row.Cells[8].Style.Add("background-color", "#C2D69B");
                        }
                        rowIdx++;
                    }
                }
            }
        }
        grdUpdaidMember.RenderControl(hw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.End();
    }
}