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

public partial class Package_PackageRegister : System.Web.UI.Page
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
          else if (!IsPostBack)
          {
              AdminBasicData();
              getPackage();
              notifications();

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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            txtDescription.Text.Replace("'", "\'");
            txtBenefit.Text.Replace("'", "\'");

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intId from anuvaa_matrimony.tblampackagesdetails where varPackageId='" + dbc.get_tblampackagesId(ddlPackageName.Text) + "' and varPackageDuration='" + txtDuration.Text + "' and varPackageDurationTime='" + ddlDuration.Text + "'", dbc.con1);
            dbc.con1.Open();
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                ScriptManager.RegisterStartupScript(
                     this,
                     this.GetType(),
                     "MessageBox",
                     "alert('Package already added');", true);

            }

            else
            {
                int insert_ok = dbc.insert_tblampackages(ddlPackageName.Text, txtDuration.Text, ddlDuration.Text, txtPrice.Text, txtDescription.Text, txtBenefit.Text,txtContact.Text);

                if (insert_ok == 1)
                {
                    dbc.con2.Close();
                    dbc.con2.Open();
                    MySql.Data.MySqlClient.MySqlCommand cmdn1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varFranchiseeId,varDesignation FROM tblampersonnel where varDesignation = 'Franchisee'", dbc.con2);

                    MySql.Data.MySqlClient.MySqlDataReader drn1;
                    drn1 = cmdn1.ExecuteReader();
                    while (drn1.Read())
                    {
                        dbc.insert_tblamnotifications("Message", Session["adminid"].ToString(), lblAdminName.Text, "Admin", drn1["varFranchiseeId"].ToString(), "Franchisee", "New Package Added,Please Inform the Members..." + lblAdminName.Text, "", "", "Unread", "");

                    }
                    dbc.con2.Close();
                    ScriptManager.RegisterStartupScript(
                       this,
                       this.GetType(),
                       "MessageBox",
                       "alert('Package Details Added Successfully');window.location='PackageRegister.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Some problem Please try again');", true);
                }
            }
              
            dbc.con1.Close();
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
        txtBenefit.Text = "";
        txtDescription.Text = "";
        txtDuration.SelectedIndex = 0;
        ddlPackageName.SelectedIndex = 0;
        txtPrice.Text = "";
        ddlDuration.SelectedIndex = 0;
    }
  
    protected void btnadd_Click(object sender, EventArgs e)
    {
        try
        {
            other.Visible = false;
            packtext.Visible = true;          
           
        }
        catch (Exception s)
        {
                       
        }
    }
    public void getPackage()
    {
        try
        {

            string query = "SELECT distinct varPackageName FROM anuvaa_matrimony.tblampackages";
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dt);

            ddlPackageName.DataSource = dt; 
            ddlPackageName.DataTextField = "varPackageName"; 
            ddlPackageName.DataValueField = "varPackageName";
            ddlPackageName.DataBind();
            dbc.con.Close();
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PackageRegister.aspx");
    }
    protected void btnAddpack_Click(object sender, EventArgs e)
    {
        try
        {

            int insert_ok = dbc.insert_package_single(txtpackage.Text);

            if (insert_ok == 1)
            {
                ScriptManager.RegisterStartupScript(
                            this,
                            this.GetType(),
                            "MessageBox",
                             "alert('Package Added');window.location='PackageRegister.aspx';", true);
                other.Visible = true;
                packtext.Visible = false;

            }
        }
        catch (Exception s)
        {
            ScriptManager.RegisterStartupScript(
                      this,
                      this.GetType(),
                      "MessageBox",
                       "alert('Some Problem Please try again later');", true);
            dbc.con.Close();

        }
    }
}