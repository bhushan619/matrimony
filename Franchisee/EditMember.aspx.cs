using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Franchisee_EditMember : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    static string mId = string.Empty;
    string gen = string.Empty;
    string IdIn = string.Empty;
    string status = string.Empty;

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
                getData();
            }
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblamnotifications(Session["fid"].ToString(), "Franchisee").ToString();
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
    public void clear()
    {

        
        lblEmail.Text = "";
         
        lblmemId.Text = "";
        lblMobNo.Text = "";
        
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

           
            lblMobNo.Text = dbc.dr["varMobile"].ToString();
            lblEmail.Text = dbc.dr["varEmail"].ToString();
            ddlMemStatus.Text = dbc.dr["varMemberStatus"].ToString();
             
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
                IdIn = "SMF";
                
            }
            else if (rdbMale.Checked)
            {
                gen = rdbMale.Text;
                IdIn = "SMM";
                
            }
            else if (rdbOther.Checked)
            {
                gen = rdbOther.Text;
                IdIn = "SMO";
             
            }
            if (ddlMemStatus.Text == "Verified")
            {
                ScriptManager.RegisterStartupScript(
                            this,
                            this.GetType(),
                            "MessageBox",
                            "alert('You cannot verify the member');window.location='EditMember.aspx';", true);
            }
            else
            {
                int Update_Ok = dbc.Update_tblammemberregistration(mId, txtMemshipType.Text, ddlProfileFor.Text, txtMemName.Text, gen, ddlMemStatus.Text);
                if (Update_Ok != 0)
                {
                    dbc.insert_tblamnotifications("Message", Session["fid"].ToString(), lblFranchiseeName.Text, "Franchisee", mId, "Member", "Your Profile is Edited By Franchise :" + lblFranchiseeName.Text + " " + Session["fid"].ToString(), "", "", "Unread", "");
                    ScriptManager.RegisterStartupScript(
                            this,
                            this.GetType(),
                            "MessageBox",
                            "alert('Data Updated');window.location='EditMember.aspx';", true);
                    

                }
            }


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                 this,
                 this.GetType(),
                 "MessageBox",
                 "alert('Data Not Updated');window.location='EditMember.aspx';", true);
        }
    }
}