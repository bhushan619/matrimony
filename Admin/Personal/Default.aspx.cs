﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class Admin_Default : System.Web.UI.Page
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
                getDataInGridview();
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
    public void getDataInGridview()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varMemberName,varMemberCity,varPaymentAmount,varPaymentStatus,varPaymode,(SELECT distinct varPackageName FROM tblampackages WHERE varPackageId=tblammembertransactions.varPackageId) as PackageName,varOrderStatus,varTransactionId,ex2  FROM tblammembertransactions WHERE varPaymentStatus='Paid' order by varPurchaseDate desc ", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dt);
            grdPaidMember.DataSource = dt;
            grdPaidMember.DataBind();

            //MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varMembershipType,  varMemberName, varGender, varMobile,varMemberStatus,varCreatorDesignation FROM tblammemberregistration WHERE varMembershipType='Unpaid' and  varMemberStatus='Verified' and  varFranchiseeId='" + frid + "'", dbc.con);
            //MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            //ad1.Fill(dt1);
            //grdUpdaidMember.DataSource = dt1;
            //grdUpdaidMember.DataBind();


            dbc.con.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string[] arry = txtmembername.Text.Split(new char[] { ';' });
            dt.Clear();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varMemberName,varMemberCity,varPaymentAmount,varPaymentStatus,varPaymode,(SELECT distinct varPackageName FROM tblampackages WHERE varPackageId=tblammembertransactions.varPackageId) as PackageName,varOrderStatus,varTransactionId,ex2  FROM tblammembertransactions WHERE varMemberId='" + arry[0].ToString() + "'", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dt);
            grdPaidMember.DataSource = dt;
            grdPaidMember.DataBind();


            //MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varMembershipType,  varMemberName, varGender, varMobile,varMemberStatus,varCreatorDesignation FROM tblammemberregistration WHERE varMembershipType='Unpaid' and  varMemberStatus='Verified' and varFranchiseeId='" + frid + "' AND varMemberId='" + arry[0].ToString() + "'", dbc.con);
            //MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            //ad1.Fill(dt1);
            //grdUpdaidMember.DataSource = dt1;
            //grdUpdaidMember.DataBind();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            dbc.con.Close();
            //Response.Write(""+ex.Message+"");
             Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtmembername.Text = "";
        getDataInGridview();
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
    {
        String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);
        con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varMemberId,';',varMemberName) AS Member FROM  anuvaa_matrimony.tblammemberregistration  where varMemberName like '%" + prefixText + "%' and  varMembershipType='Paid' ", con);
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

    protected void grdPaidMember_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        //if (e.CommandName == "Upgrade")
        //{
        //    Session.Add("MemberId", id);
        //    Response.Redirect("UpgradeMember.aspx");
        //}
        //else 
        if (e.CommandName == "Views")
        {
            Session.Add("MemberIdandpackid", id);


            Response.Redirect("~/Admin/Personal/ViewMemberProfile.aspx");
        }
    }

    protected void grdPaidMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdPaidMember.PageIndex = e.NewPageIndex;
        getDataInGridview();
    }
}