using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ChangePassword : System.Web.UI.Page
{
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varName, varDesignation, varAddress, varCity, varState, varCountry, varPinCode, varEmail, varEmailVerify, varMobile, varMobileVerify, varLandline, varPassword, varStatus, varRegDate, varRegTime FROM tblampersonnel WHERE intId =" + Session["adminid"] + "", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (txtOld.Text == dbc.dr["varPassword"].ToString())
                {
                    if (txtNew.Text.Equals(txtNewCon.Text))
                    {
                        int insert_ok = dbc.update_AdminPass(Convert.ToInt32(Session["adminid"].ToString()), txtNew.Text);

                        if (insert_ok == 1)
                        {
                            dbc.insert_tblamnotifications("Message", Session["adminid"].ToString(), lblAdminName.Text, "Admin", Session["adminid"].ToString(), "Admin", "You recently changed your Password.", "", "", "Unread", "");
                            ScriptManager.RegisterStartupScript(
                               this,
                               this.GetType(),
                               "MessageBox",
                               "alert('Password change Completed !!!');window.location='Default.aspx'", true);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(
                          this,
                          this.GetType(),
                          "MessageBox",
                          "alert('Some problem Please try again');window.location='ChangePassword.aspx'", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(
                         this,
                         this.GetType(),
                         "MessageBox",
                         "alert('Please Enter Same New Passwords');window.location='ChangePassword.aspx'", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                     this,
                     this.GetType(),
                     "MessageBox",
                     "alert('Please Enter Correct Old Password');window.location='ChangePassword.aspx'", true);
                }
            }
            dbc.con.Close();

        }
        catch (Exception s)
        {
            dbc.con.Close();

        }

    }
   
}
      //MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varMemberName,varMemberCity,varPaymentAmount,varPaymentStatus,(SELECT varPackageId, concat(varPackageDuration,';',varPackageDurationTime)as Package FROM tblampackagesdetails where varPackageId=tblammembertransactions.varPackageId) as PackageName,varOrderStatus FROM tblammembertransactions WHERE varPaymentStatus='Paid' order by varPurchaseDate desc ", dbc.con);