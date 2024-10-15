using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;


public partial class Admin_EditMembers : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    static string mId = string.Empty;
    string gen = string.Empty;
    string IdIn = string.Empty;
    string status = string.Empty;
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
                notifications();
                getData();
                AdminBasicData();
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
    public void clear()
    {

        lbldesig.Text = "";
        lblEmail.Text = "";
        lblFranId.Text = "";
        lblmemId.Text = "";
        lblMobNo.Text = "";
        // lblPass.Text = "";
        txtMemName.Text = "";
        txtMemshipType.Text = "";
        ddlMemStatus.SelectedItem.Text = "--Select Status--";
        ddlProfileFor.SelectedItem.Text = "--Select Matrimony Profile for--";
    }
    public void getData()
    {
        dbc.con.Open();
        // int id = Convert.ToInt32(e.CommandArgument);
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varMemberId, varMembershipType, varMemberFor, varMemberName, varGender, varMobile,  varEmail,  varMemberStatus, varFranchiseeId, varCreatorDesignation, varPassword FROM tblammemberregistration WHERE  varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
        dbc.dr = cmd.ExecuteReader();
        if (dbc.dr.Read())
        {

            mId = dbc.dr["varMemberId"].ToString();
            lblmemId.Text = dbc.dr["varMemberId"].ToString();
            txtMemshipType.Text = dbc.dr["varMembershipType"].ToString();
            ddlProfileFor.Text = dbc.dr["varMemberFor"].ToString();
            txtMemName.Text = dbc.dr["varMemberName"].ToString();
            string str = dbc.dr["varGender"].ToString();
            if (str == "Male")
            {
                rdbMale.Checked = true;
            }
            else if (str == "Female")
            {
                rdbFemale.Checked = true;

            }
            else
            {
                rdbOther.Checked = true;
            }

            lbldesig.Text = dbc.dr["varCreatorDesignation"].ToString();
            //lblPass.Text = dbc.dr["varPassword"].ToString();
            lblMobNo.Text = dbc.dr["varMobile"].ToString();
            lblEmail.Text = dbc.dr["varEmail"].ToString();
            ddlMemStatus.Text = dbc.dr["varMemberStatus"].ToString();
            lblFranId.Text = dbc.dr["varFranchiseeId"].ToString();
            dbc.con.Close();
            dbc.dr.Close();

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            if (rdbFemale.Checked)
            {
                gen = rdbFemale.Text;
                IdIn = "F";
            }
            else if (rdbMale.Checked)
            {
                gen = rdbMale.Text;
                IdIn = "M";
            }
            else if (rdbOther.Checked)
            {
                gen = rdbOther.Text;
                IdIn = "O";
            }
            int Update_Ok = dbc.Update_tblammemberregistration(mId, txtMemshipType.Text, ddlProfileFor.Text, txtMemName.Text, gen, ddlMemStatus.Text);
            if (Update_Ok != 0)
            {
                dbc.insert_tblamnotifications("Page", Session["adminid"].ToString(), lblAdminName.Text, "Admin", mId, "Member", "Congratulations...!!! Your Profile is Successfully Verified By AnuvaaMatrimony" , "~/members/SearchMatches/", "", "Unread", "");
                ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Member Data Updated');window.location='ViewMembers.aspx';", true);
                clear();

            }


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                 this,
                 this.GetType(),
                 "MessageBox",
                 "alert('Data Not Updated');window.location='EditMembers.aspx';", true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewMembers.aspx");
    }
}
    //public void getMemberDataInGridView()
    //{
    //    try
    //    {
    //        dbc.con.Open();
    //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varMemberId, varMembershipType, varMemberFor, varMemberName, varGender, varMobile FROM tblammemberregistration ", dbc.con);
    //        MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
    //        ad.Fill(dt);
    //        grdEditMembers.DataSource = dt;
    //        grdEditMembers.DataBind();
    //        dbc.con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write("<script>alert('Please Try Again');</script>");
    //    }
    //}
   
    //protected void grdEditMembers_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        if (e.CommandName == "Selects")
    //        {
    //            dbc.con.Open();
    //            int id = Convert.ToInt32(e.CommandArgument);
    //            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varMemberId, varMembershipType, varMemberFor, varMemberName, varGender, varMobile,  varEmail,  varMemberStatus, varFranchiseeId, varCreatorDesignation, varPassword FROM tblammemberregistration WHERE  varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
    //            dbc.dr = cmd.ExecuteReader();
    //            if (dbc.dr.Read())
    //            {

    //                mId =dbc.dr["intId"].ToString();
    //                lblmemId.Text = dbc.dr["varMemberId"].ToString();
    //                txtMemshipType.Text = dbc.dr["varMembershipType"].ToString();
    //                ddlProfileFor.Text = dbc.dr["varMemberFor"].ToString();
    //                txtMemName.Text = dbc.dr["varMemberName"].ToString();
    //                string str = dbc.dr["varGender"].ToString();
    //                if (str=="Male")
    //                {
    //                    rdbMale.Checked = true;
    //                }
    //                else if (str== "Female")
    //                {
    //                    rdbFemale.Checked = true;

    //                }
    //                else
    //                {
    //                    rdbOther.Checked = true;
    //                }

    //                lbldesig.Text = dbc.dr["varCreatorDesignation"].ToString();
    //                lblPass.Text = dbc.dr["varPassword"].ToString();
    //                lblMobNo.Text = dbc.dr["varMobile"].ToString();
    //                lblEmail.Text = dbc.dr["varEmail"].ToString();
    //                ddlMemStatus.Text = dbc.dr["varMemberStatus"].ToString();
    //                lblFranId.Text = dbc.dr["varFranchiseeId"].ToString();
                  


    //                dbc.con.Close();
    //                dbc.dr.Close();

    //            }
                
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ScriptManager.RegisterStartupScript(
    //                    this,
    //                    this.GetType(),
    //                    "MessageBox",
    //                     "alert('Some problem occured');", true);
    //        dbc.con.Close();
    //    }
    
    //}
    //protected void grdEditMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    grdEditMembers.PageIndex = e.NewPageIndex;
    //    getMemberDataInGridView();
    //}

