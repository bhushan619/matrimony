using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class Franchisee_Default : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
    static string frid = string.Empty;
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
                frid = Session["fid"].ToString();  
                FranchiseeBasicData();
                notifications();
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
            DataTable dt = new DataTable();
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId, varName, varAddress, varCity, varState, varCountry, varPinCode, varEmail, varMobile, varLandline, varProfilePic FROM tblampersonnel WHERE varFranchiseeId ='" + Session["fid"] + "'", dbc.con);
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
            }
            dbc.con.Close();
            cmde.Dispose();
            dbc.con.Open();
            dbc.dataAdapter = new MySqlDataAdapter(cmde);
            dbc.dataAdapter.Fill(dt);
            lstFranchisee.DataSource = dt;
            lstFranchisee.DataBind();
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
}