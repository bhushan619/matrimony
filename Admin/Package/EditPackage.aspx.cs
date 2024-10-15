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
using MySql.Data.MySqlClient;
using System.Text;

public partial class Admin_EditPackage : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    string mId = string.Empty;
    string pId = string.Empty;
       static string[] packag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../register/FranchiseeRegisterj.aspx';</script>");
            Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
            AdminBasicData();
            packag = Session["packid"].ToString().Split(';');
            getPackage();
            notifications();
           // SqlDataSource1.SelectCommand = "SELECT DISTINCT tblampackages.varPackageId, tblampackages.varPackageName, tblampackagesdetails.varPackageDescription, tblampackagesdetails.varPackageDuration, tblampackagesdetails.varPackagePrice, tblampackagesdetails.varBenifits, tblampackagesdetails.varPackageDurationTime FROM tblampackages INNER JOIN tblampackagesdetails ON tblampackages.varPackageId = tblampackagesdetails.varPackageId where tblampackages.varPackageId='" + packag[0].ToString() + "' and tblampackagesdetails.varPackageDuration='" + packag[2].ToString() + "' and tblampackagesdetails.varPackageDurationTime='" + packag[3].ToString() + "'";

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
    public void getPackage()
    {
        try
        {
            dbc.con.Open();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT DISTINCT tblampackages.varPackageId, tblampackages.varPackageName, tblampackagesdetails.varPackageDescription, tblampackagesdetails.varPackageDuration, tblampackagesdetails.varPackagePrice, tblampackagesdetails.varBenifits, tblampackagesdetails.varPackageDurationTime,tblampackagesdetails.ex1 FROM tblampackages INNER JOIN tblampackagesdetails ON tblampackages.varPackageId = tblampackagesdetails.varPackageId where tblampackages.varPackageId='" + packag[0].ToString() + "' and tblampackagesdetails.varPackageDuration='" + packag[2].ToString() + "' and tblampackagesdetails.varPackageDurationTime='" + packag[3].ToString() + "'", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {

                mId = dbc.dr["varPackageId"].ToString();
                // pId = dbc.dr["intId"].ToString();
                dbc.con1.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varPackageName FROM tblampackages WHERE varPackageId='" + dbc.dr["varPackageId"].ToString() + "' ", dbc.con1);
                dbc.dr1 = cmd1.ExecuteReader();
                dbc.dr1.Read();
                ddlPackageN.Text = dbc.dr["varPackageName"].ToString(); ;
                dbc.con1.Close();
                dbc.dr1.Close();

                txtDescription.Text = dbc.dr["varPackageDescription"].ToString();
                txtDuration.Text = dbc.dr["varPackageDuration"].ToString();
                ddlDuration.Text = dbc.dr["varPackageDurationTime"].ToString();
                txtPrice.Text = dbc.dr["varPackagePrice"].ToString();
                txtBenefit.Text = dbc.dr["varBenifits"].ToString();
                txtContact.Text = dbc.dr["ex1"].ToString();
                dbc.con.Close();
                dbc.dr.Close();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                         "alert('Some Problem Please try again later');", true);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //(string fid, string name, string address, string country, string state, string city, string pincode, string landline)
            int Update_Ok = dbc.update_tblampackagesdetails(pId, txtDescription.Text, txtDuration.Text, ddlDuration.Text, txtPrice.Text, txtBenefit.Text, txtContact.Text);
            if (Update_Ok != 0)
            {
                dbc.con2.Close();
                dbc.con2.Open();
                MySql.Data.MySqlClient.MySqlCommand cmdn1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varFranchiseeId,varDesignation FROM tblampersonnel where varDesignation = 'Franchisee'", dbc.con2);

                MySql.Data.MySqlClient.MySqlDataReader drn1;
                drn1 = cmdn1.ExecuteReader();
                while (drn1.Read())
                {
                    dbc.insert_tblamnotifications("Message", Session["adminid"].ToString(), lblAdminName.Text, "Admin", drn1["varFranchiseeId"].ToString(), "Franchisee", "Packages are Upgraded,Please Inform the Members..." + lblAdminName.Text, "", "", "Unread", "");
                 
                }
                dbc.con2.Close();
               //drn1.Close();
                ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Package  Updated');window.location='ViewPackage.aspx';", true);
                //clear();

            }


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                 this,
                 this.GetType(),
                 "MessageBox",
                 "alert('Package Not Updated');window.location='EditPackage.aspx';", true);
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewPackage.aspx");
    }
}