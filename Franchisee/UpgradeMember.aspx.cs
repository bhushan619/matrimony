using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Franchisee_UpgradeMember : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    static string mId = string.Empty;
    string gen = string.Empty;
    string IdIn = string.Empty;
    string status = string.Empty;
    static string state = string.Empty;
    static string city = string.Empty;
    static string productinfo = string.Empty;
    static string packageno = string.Empty;
    static string amount = string.Empty;
    static int mypackintid = 0;
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
                HideControl();
                getData();
                notifications();
                FranchiseeBasicData();
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
    public void getData()
    {
        dbc.con.Open();
        // int id = Convert.ToInt32(e.CommandArgument);
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varMemberId, varMembershipType, varMemberFor, varMemberName, varGender, varMobile,  varEmail,  varMemberStatus, varFranchiseeId, varCreatorDesignation  FROM tblammemberregistration WHERE  varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
        dbc.dr = cmd.ExecuteReader();
        if (dbc.dr.Read())
        {

            mId = dbc.dr["varMemberId"].ToString();
            lblmemId.Text = dbc.dr["varMemberId"].ToString();
            txtMemshipType.Text = dbc.dr["varMembershipType"].ToString();
            ddlProfileFor.Text = dbc.dr["varMemberFor"].ToString();
            txtMemName.Text = dbc.dr["varMemberName"].ToString();
            lblGen.Text = dbc.dr["varGender"].ToString();
         
            lbldesig.Text = dbc.dr["varCreatorDesignation"].ToString();

            lblMobNo.Text = dbc.dr["varMobile"].ToString();
            lblEmail.Text = dbc.dr["varEmail"].ToString();
            ddlMemStatus.Text = dbc.dr["varMemberStatus"].ToString();
            lblFranId.Text = dbc.dr["varFranchiseeId"].ToString();

            dbc.con.Close();
            dbc.dr.Close();

        }
    }
   
    public void ShowControl()
    {
        lblpackName.Visible = true;
        lblpriceamt.Visible = true;
        
    }
    public void HideControl()
    {
        lblpackName.Visible = false;
        lblpriceamt.Visible = false; 
    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            packageselection.Visible = true;
            string[] packge = e.CommandArgument.ToString().Split(';');
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmdp = new MySql.Data.MySqlClient.MySqlCommand("SELECT DISTINCT tblampackages.varPackageId, tblampackages.varPackageName,tblampackagesdetails.intId, tblampackagesdetails.varPackageDescription, tblampackagesdetails.varPackageDuration, tblampackagesdetails.varPackagePrice, tblampackagesdetails.varBenifits, tblampackagesdetails.varPackageDurationTime, tblampackagesdetails.ex1 FROM tblampackages INNER JOIN tblampackagesdetails ON tblampackages.varPackageId = tblampackagesdetails.varPackageId where tblampackages.varPackageName='" + packge[0].ToString() + "' and tblampackagesdetails.varPackageDuration='" + packge[1].ToString() + "' and tblampackagesdetails.varPackageDurationTime='" + packge[2].ToString() + "'", dbc.con);
            dbc.con.Open();
            dbc.dr = cmdp.ExecuteReader();
            if (dbc.dr.Read())
            {
                ShowControl();
                mypackintid = Convert.ToInt16(dbc.dr["intId"]);
                lblpackName.Text = dbc.dr["varPackageName"].ToString();
                lblpriceamt.Text = dbc.dr["varPackagePrice"].ToString();
                lblDuration.Text = dbc.dr["varPackageDuration"].ToString() + " " + dbc.dr["varPackageDurationTime"].ToString();
                lblContacts.Text = dbc.dr["ex1"].ToString();
                packageno = dbc.dr["varPackageId"].ToString();
                amount = dbc.dr["varPackagePrice"].ToString();
                productinfo = dbc.dr["varPackageDescription"].ToString();

            }
            dbc.con.Close();
            dbc.dr.Close();
            ListView1.Visible = false;
            btnOther.Visible = true;
        }
        catch (Exception ex)
        {
            packageselection.Visible = false;
            Response.Write("<script>alert('Please Try Again');window.location='../register/FranchiseeRegisterj.aspx';</script>");
        }
    }
    static string country = string.Empty;
    static string address = string.Empty;
    static string pin = string.Empty;
    protected void btnPay_Click(object sender, EventArgs e)
    {
        dbc.con.Close();
        MySql.Data.MySqlClient.MySqlCommand cmdpa = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varState, varCountry,varCity FROM anuvaa_matrimony.tblammemberlivingin  WHERE (varMemberId = '" + mId + "')", dbc.con);
        dbc.con.Open();
        dbc.dr = cmdpa.ExecuteReader();
        if (dbc.dr.Read())
        {
            state = dbc.dr["varState"].ToString();
            city = dbc.dr["varCity"].ToString();
            country = dbc.dr["varCountry"].ToString();
        }
        dbc.con.Close();
        dbc.dr.Close();

        MySql.Data.MySqlClient.MySqlCommand cmdc = new MySql.Data.MySqlClient.MySqlCommand("SELECT varParentMobile, varParentLandline, varMemberAlternateMobile1, varMemberAlternateMobile2, varMemberAlternateEmail1, varMemberAlternateEmail2, varPermanantAddress, varAlternateAddress, varContactPersonName, varContactPersonMobile, varRelationOfContactPerson, ex1, ex2 FROM tblammembercontactdetails WHERE varMemberId='" + mId + "'", dbc.con1);

        dbc.con1.Open();
        dbc.dr1 = cmdc.ExecuteReader();
        if (dbc.dr1.Read())
        {
            address = dbc.dr1["varPermanantAddress"].ToString();
            pin = "NA";
        }
        dbc.con1.Close();
        dbc.dr1.Close();
        string orderno = dbc.CreateRandomPassword(6);
        int intid = dbc.max_tblammembertransactions();
        intid = intid + 1;
        MySql.Data.MySqlClient.MySqlCommand cmdo = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblammembertransactions VALUES (" + intid + ",'" + orderno + "','" + Session["memberid"].ToString() + "','" + txtMemName.Text + "','" + city + "','','" + state + "','" + packageno + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','" + amount + "','Unpaid','','','NA','Started','','" + mypackintid.ToString() + "')", dbc.con1);
        dbc.con1.Open();
        cmdo.ExecuteNonQuery();
        dbc.con1.Close();

        string[] dtme = lblDuration.Text.Split(' ');
        Response.Redirect("ccavRequestHandler.aspx?&billing_address=" + address + "&billing_city=" + city + "&billing_state=" + state + "&billing_zip=" + pin + "&billing_country=" + country + "&merchant_id=53386&order_id=" +orderno + "&currency=INR&amount=" + amount + "&redirect_url=http://swapnpurti.in/Franchisee/ccavResponseHandler.aspx&cancel_url=http://swapnpurti.in/Franchisee/ccavResponseHandler.aspx&billing_name=" + txtMemName.Text + "&billing_email=" + lblEmail.Text + "&billing_tel=" + lblMobNo.Text + "&merchant_param1=" + packageno + "&merchant_param2=" + mId + "&merchant_param3=" + lblpackName.Text + "&merchant_param4=" + dtme[0].ToString() + "&merchant_param5=" + dtme[1].ToString() + "");
    }
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        try
        {
             int Update_Ok = dbc.Update_tblammemberregistration(mId, txtMemshipType.Text, ddlProfileFor.Text, txtMemName.Text, lblGen.Text, ddlMemStatus.Text);
            if (Update_Ok != 0)
            {
                dbc.con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmdpa = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varState, varCity FROM anuvaa_matrimony.tblammemberlivingin  WHERE (varMemberId = '" + mId + "')", dbc.con);
                dbc.con.Open();
                dbc.dr = cmdpa.ExecuteReader();
                if (dbc.dr.Read())
                {
                    state = dbc.dr["varState"].ToString();
                    city = dbc.dr["varCity"].ToString();

                }
                dbc.con.Close();
                dbc.dr.Close();

                int intid = dbc.max_tblammembertransactions();
                intid = intid + 1;
                MySql.Data.MySqlClient.MySqlCommand cmdo = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblammembertransactions VALUES (" + intid + ",'" + dbc.CreateRandomPassword(6) + "','" + mId + "','" + txtMemName.Text + "','" + city + "','','" + state + "','" + packageno + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','" + amount + "','Paid','" + txtTransactionId.Text + "','Success','Cash Payment','Confirmed','" + Session["fid"].ToString() + "','" + mypackintid.ToString() + "')", dbc.con);
                dbc.con.Open();
                cmdo.ExecuteNonQuery();
                dbc.con.Close();

                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmdr = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberregistration SET varMembershipType = 'Paid' WHERE varMemberId = '" + mId + "'", dbc.con);
                cmdr.ExecuteNonQuery();
                dbc.con.Close();

                string[] dtme = lblDuration.Text.Split(' ');

                dbc.update_tblmembercontactviewscount(Session["memberid"].ToString(), dbc.getPackageContactCount(packageno, dtme[0].ToString(), dtme[1].ToString()).ToString());
                //  dbc.insert_tblamnotifications("Message", Session["fid"].ToString(), lblFranchiseeName.Text, "Franchisee", mId, "Admin", " Member Upgradation Done By Franchise :" + lblFranchiseeName.Text + " " + Session["fid"].ToString(), "", "", "Unread", "");

                //int Update_Ok = dbc.Update_tblammemberregistration(mId, txtMemshipType.Text, ddlProfileFor.Text, txtMemName.Text, gen, ddlMemStatus.Text);
                ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Member Upgraded');window.location='PaidMembers.aspx';", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                 this,
                 this.GetType(),
                 "MessageBox",
                 "alert('Data Not Updated');window.location='UpgradeMember.aspx';", true);
        }
    }
    protected void ddlPayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPayMode.Text == "Online Payment")
            {
                online.Visible = true;
                cashpay.Visible = false;
                btnOther.Visible = true;
            }
            else if (ddlPayMode.Text == "Cash Payment")
            {
                cashpay.Visible = true;
                online.Visible = false;
                btnOther.Visible = true;
            }
            else
            {
                online.Visible = false;
                cashpay.Visible = false;
                btnOther.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }
      
    protected void brnOther_Click(object sender, EventArgs e)
    {
        online.Visible = false;
        cashpay.Visible = false;
        
        btnOther.Visible = false;
        ListView1.Visible = true;
        lblpackName.Text = "";
        lblDuration.Text = "";
        lblpriceamt.Text = "";
    }
}