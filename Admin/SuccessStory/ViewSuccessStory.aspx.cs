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


public partial class Admin_ViewSuccessStory : System.Web.UI.Page
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
                notifications();
                Successstory();
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
    public void Successstory()
    {
        try
        {
            DataTable dt = new DataTable();
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varPartnerId,varMemberName,varPartnerName,varUploaderDesignation,varEngagementDate,varWeddingDate,varWeddingLocation,varCurrentAdddress,vaCurrentrCountry,varCurrentState,varCurrentCity,varCurrentContact,varDescription,varPhoto,varEmail FROM anuvaa_matrimony.tblamsuccessstories WHERE  varMemberId ='" + Session["MemberId"] + "'", dbc.con);
            dbc.con.Open();      
           
            dbc.dataAdapter = new MySqlDataAdapter(cmde);
            dbc.dataAdapter.Fill(dt);
            lststory.DataSource = dt;
            lststory.DataBind();
            dbc.con.Close();
            //SelectCommand="SELECT varFranchiseeId, varName, varAddress, varCity, varState, varCountry, varPinCode, varEmail, varMobile, varLandline, varProfilePic FROM tblampersonnel WHERE (varFranchiseeId = '1')"
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


    protected void lststory_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName == "Approve")
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblamsuccessstories SET varStatus='Approve' WHERE varMemberId='" + id + "'", dbc.con);

            cmd.ExecuteNonQuery();
            dbc.con.Close();
            ScriptManager.RegisterStartupScript(
                this,
                this.GetType(),
                "MessageBox",
                "alert('Success Story Approve!!!');", true);
        }
        else if (e.CommandName == "Reject")
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblamsuccessstories SET varStatus='Reject' WHERE varMemberId='" + id + "'", dbc.con);

            cmd.ExecuteNonQuery();
            dbc.con.Close();
            ScriptManager.RegisterStartupScript(
                this,
                this.GetType(),
                "MessageBox",
                "alert('Success Story Reject!!!');", true);
        }
    }
}