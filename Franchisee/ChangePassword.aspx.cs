using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Franchisee_ChangePassword : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fid"] == null)
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
                notifications();
                FranchiseeBasicData();
            }
        }
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
    public void FranchiseeBasicData()
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId, varName, varProfilePic FROM tblampersonnel WHERE varFranchiseeId ='" + Session["fid"] + "'", dbc.con);
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
            } dbc.con.Close();
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varName, varDesignation, varAddress, varCity, varState, varCountry, varPinCode, varEmail, varEmailVerify, varMobile, varMobileVerify, varLandline, varPassword, varStatus  FROM tblampersonnel WHERE varFranchiseeId ='" + Session["fid"] + "'", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (txtOld.Text == dbc.dr["varPassword"].ToString())
                {
                    if (txtNew.Text.Equals(txtNewCon.Text))
                    {
                        int insert_ok = dbc.update_FranchiseePass(Session["fid"].ToString(), txtNew.Text);

                        if (insert_ok == 1)
                        {
                            dbc.insert_tblamnotifications("Message", Session["fid"].ToString(), lblFranchiseeName.Text, "Franchisee", Session["fid"].ToString(), "Franchisee", "You recently changed your Password if not please contact support", "", "", "Unread", "");
                            ScriptManager.RegisterStartupScript(
                               this,
                               this.GetType(),
                               "MessageBox",
                               "alert('Password  Change Successfully...!!!');window.location='ChangePassword.aspx'", true);

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(
                          this,
                          this.GetType(),
                          "MessageBox",
                          "alert('Some problem Please try again...!!!');window.location='ChangePassword.aspx'", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(
                         this,
                         this.GetType(),
                         "MessageBox",
                         "alert('Please Enter Same New Passwords'...!!!);window.location='ChangePassword.aspx'", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                     this,
                     this.GetType(),
                     "MessageBox",
                     "alert('Please Enter Correct Old Password...!!!');window.location='ChangePassword.aspx'", true);
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