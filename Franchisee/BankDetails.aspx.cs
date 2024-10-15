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

public partial class Franchisee_BankDetails : System.Web.UI.Page
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
           
            notifications();
            viewbankdetails.Visible = false;

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
              "alert('Some Problem Please try again...!!!');", true);
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
    public void notifications()
    {
        try
        {
            lnkNotifications.Text = dbc.count_tblamnotifications(Session["fid"].ToString(), "Franchisee").ToString();
        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(
            //       this,
            //       this.GetType(),
            //       "MessageBox",
            //       "alert('" + ex.Message + "');", true);
        }
    }

    public void clear()
    {
        txtbankaccno.Text = "";
        txtbankaccholdername.Text = "";
        txtbankbranch.Text = "";
        txtbankcity.Text = "";

        txtbankifsccode.Text = "";
        txtbankmcircode.Text = "";
        ddlacctype.SelectedIndex = 0;
        ddlbankname.SelectedIndex = 0;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            int insert_ok = dbc.insert_tblampersonnelbankdetails(Session["fid"].ToString(), ddlbankname.Text, txtbankcity.Text, txtbankbranch.Text, txtbankifsccode.Text, txtbankmcircode.Text, txtbankaccholdername.Text, txtbankaccno.Text, ddlacctype.Text);

            if (insert_ok == 1)
            {
               
                ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('Bank Details Added Successfully...!!!');", true);
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
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(
            //       this,
            //       this.GetType(),
            //       "MessageBox",
            //       "alert('" + ex.Message + "');", true);
        }
    }
    protected void btnview_Click(object sender, EventArgs e)
    {
        try
        {
            viewbankdetails.Visible = true;
            dbc.con.Open();

            dbc.cmd = new MySqlCommand("SELECT varBankName,varBankCity,varBankBranch,varBankIfsc,varBankMcir,varAccountHolderName,varAccountNumber,varAccountType FROM tblampersonnelbankdetails WHERE varFranchiseeId='" + Session["fid"].ToString() + "'", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(dbc.cmd);
            ad.Fill(dt);
            lstbankdetails.DataSource = dt;
            lstbankdetails.DataBind();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(
            //       this,
            //       this.GetType(),
            //       "MessageBox",
            //       "alert('" + ex.Message + "');", true);
        }
    }
}