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

public partial class Admin_ViewFranchisee : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DataTable dt1 = new DataTable();
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
                getActiveGridview();
                getInActiveGridview();
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

    public void getInActiveGridview()
    {
        try
        {
            dbc.con.Open();


            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId,  varName, varAddress, varCity, varMobile FROM tblampersonnel WHERE varDesignation='Franchisee' and varStatus='Inactive' order by varRegDate desc", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            ad1.Fill(dt1);
            grdInActiveFranchisee.DataSource = dt1;
            grdInActiveFranchisee.DataBind();

            dbc.con.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    public void getActiveGridview()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId,  varName, varAddress, varCity, varMobile,varStatus FROM tblampersonnel WHERE varDesignation='Franchisee' and varStatus!='Inactive' order by varRegDate desc", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dt);
            grdActiveFranchisee.DataSource = dt;
            grdActiveFranchisee.DataBind();

          
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

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varFranchiseeId,  varName, varAddress, varCity, varMobile,varStatus FROM tblampersonnel WHERE varDesignation='Franchisee' and varStatus='Active' AND varFranchiseeId='" + arry[0].ToString() + "'", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dt);
            grdActiveFranchisee.DataSource = dt;
            grdActiveFranchisee.DataBind();


            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varFranchiseeId,  varName, varAddress, varCity, varMobile,varStatus FROM tblampersonnel WHERE varDesignation='Franchisee' and varStatus='Inactive' AND varFranchiseeId='" + arry[0].ToString() + "'", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            ad1.Fill(dt1);
            grdInActiveFranchisee.DataSource = dt1;
            grdInActiveFranchisee.DataBind();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            dbc.con.Close();
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtmembername.Text = "";
        getActiveGridview();
        getInActiveGridview();
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
    {
        String connStr = System.Configuration.ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

        MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(connStr);
        con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct concat(varFranchiseeId,';',varName) AS Member FROM  anuvaa_matrimony.tblampersonnel  where varFranchiseeId like '%" + prefixText + "%' OR varName like '%" + prefixText + "%'", con);
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
        if (e.CommandName == "Edits")
        {
            Session.Add("fid", id);
            Response.Redirect("EditFranchisee.aspx");
        }
        else if (e.CommandName == "Views")
        {
            Session.Add("fid", id);
            Response.Redirect("ViewFranchiseeProfile.aspx");
        }
        else if (e.CommandName == "Apporve")
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblampersonnel SET varStatus='Approve' WHERE varFranchiseeId='" + id + "'", dbc.con);

            cmd.ExecuteNonQuery();
            dbc.con.Close();
            dbc.insert_tblamnotifications("Message", Session["adminid"].ToString(), lblAdminName.Text, "Admin", id, "Franchisee", " Congratulations !!! Your Profile is Approved...", "", "", "Unread", "");
            ScriptManager.RegisterStartupScript(
                this,
                this.GetType(),
                "MessageBox",
                "alert('Franchisee Approve!!!');window.location='ViewFranchisee.aspx';", true);
        }
        else if (e.CommandName == "picapprove")
        {
            Session.Add("fid", id);
            Response.Redirect("ApproveDocs.aspx");
        }
    }
    protected void grdUpdaidMember_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = e.CommandArgument.ToString();
        if (e.CommandName == "Edits")
        {
            Session.Add("fid", id);
            Response.Redirect("EditFranchisee.aspx");
        }
        else if (e.CommandName == "Views")
        {
            Session.Add("fid", id);
            Response.Redirect("ViewFranchiseeProfile.aspx");
        }
        
    }

    protected void grdInActiveFranchisee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdInActiveFranchisee.PageIndex = e.NewPageIndex;
        getInActiveGridview();
        //DataView dvfran = GetdataInAcitve();
        //grdInActiveFranchisee.DataSource = dvfran;
        //grdInActiveFranchisee.DataBind();
        //dbc.con.Close();
    }
  
    protected void grdActiveFranchisee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdActiveFranchisee.PageIndex = e.NewPageIndex;
        getActiveGridview();
        //dbc.con.Open();
        //MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId,  varName, varAddress, varCity, varMobile FROM tblampersonnel WHERE varDesignation='Franchisee' and varStatus='Active'", dbc.con);
        //MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
        //ad1.Fill(dt1);
        //grdActiveFranchisee.DataSource = dt1;
        //grdActiveFranchisee.DataBind();
        //dbc.con.Close();
    }
     private DataView GetdataInAcitve()
    {
        using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ToString()))
        {
            DataSet InactiveFran = new DataSet();

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId,  varName, varAddress, varCity, varMobile FROM tblampersonnel WHERE varDesignation='Franchisee' and varStatus='Inactive'", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
            ad1.Fill(InactiveFran, "Inactive");

            DataView dvfran = InactiveFran.Tables["Inactive"].DefaultView;
            // dvEmp.Sort = ViewState["SortExpr"].ToString();
            return dvfran;
        }
    }
}