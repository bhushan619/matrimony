﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class Admin_EditFranchisee : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    static string fid = string.Empty;
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
                getFranchiseeData();
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

    //public void clear()
    //{
    //    lblFranId.Text = "";
    //    txtAddress.Text = "";
    //    txtFraName.Text = "";
    //    txtlandline.Text = "";
    //    txtPincode.Text = "";
    //    ddlCity.Text = "--Select City--";
    //    ddlState.Text = "--Select State--";
    //    ddlCountry.Text = "--Select Country--";
       
    //}
    public void getFranchiseeData()
    {
        try
        {
            //dbc.con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  intId,varFranchiseeId, varName, varDesignation, varAddress, varMobile, varLandline FROM tblampersonnel ", dbc.con);
            //MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            //ad.Fill(dt);
            ////grdFranchisee.DataSource = dt;
            ////grdFranchisee.DataBind();
            //dbc.con.Close();
            dbc.con.Open();
            // int id = Convert.ToInt32(e.CommandArgument);
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId,  varName, varAddress, varCity,varState, varCountry, varPinCode,varLandline,varStatus FROM tblampersonnel  WHERE  varFranchiseeId='" + Session["fid"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {

                mId = dbc.dr["varFranchiseeId"].ToString();
                lblFranId.Text = dbc.dr["varFranchiseeId"].ToString();
                txtFraName.Text = dbc.dr["varName"].ToString();
                txtAddress.Text = dbc.dr["varAddress"].ToString();              
                ddlCountry.Text = dbc.dr["varCountry"].ToString();
                ddlState.Text = dbc.dr["varState"].ToString();
                changecity(dbc.dr["varState"].ToString());
                ddlCity.Text = dbc.dr["varCity"].ToString();
                txtPincode.Text = dbc.dr["varPinCode"].ToString();
                txtlandline.Text = dbc.dr["varLandline"].ToString();
                ddlfraStatus.Text = dbc.dr["varStatus"].ToString(); 
                dbc.con.Close();
                dbc.dr.Close();
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    protected void grdFranchisee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Selects")
            {
                dbc.con.Open();
                int id = Convert.ToInt32(e.CommandArgument);
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varFranchiseeId,varName,  varCity, varState, varAddress, varCountry,  varPinCode,  varMobile, varLandline FROM tblampersonnel WHERE varFranchiseeId=" + id + " ", dbc.con);
                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {

                    fid = dbc.dr["varFranchiseeId"].ToString();
                    lblFranId.Text = dbc.dr["varFranchiseeId"].ToString();
                    txtFraName.Text = dbc.dr["varName"].ToString();
                    txtAddress.Text = dbc.dr["varAddress"].ToString();
                    ddlCountry.Text = dbc.dr["varCountry"].ToString();


                    txtPincode.Text = dbc.dr["varPinCode"].ToString();
                    txtlandline.Text = dbc.dr["varLandline"].ToString();
                    ddlState.Text = dbc.dr["varState"].ToString();
                    changecity(dbc.dr["varState"].ToString());
                    ddlCity.Text = dbc.dr["varCity"].ToString();
                    dbc.con.Close();
                    dbc.dr.Close();

                }

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                     this,
                     this.GetType(),
                     "MessageBox",
                      "alert('Some problem occured');", true);
            dbc.con.Close();
        }



    }
    protected void grdFranchisee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //grdFranchisee.PageIndex = e.NewPageIndex;
        //getFranchiseeData();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //(string fid, string name, string address, string country, string state, string city, string pincode, string landline)
            int Update_Ok = dbc.update_tblampersonnelFranchisee(lblFranId.Text, txtFraName.Text, txtAddress.Text, ddlCountry.Text, ddlState.Text, ddlCity.Text, txtPincode.Text, txtlandline.Text, ddlfraStatus.Text);
            if (Update_Ok != 0)
            {
                dbc.insert_tblamnotifications("Message", Session["adminid"].ToString(), lblAdminName.Text, "Admin", mId, "Franchisee", "Your Profile is Edited By  :" + lblAdminName.Text, "", "", "Unread", "");
                ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Franchisee Data Updated');window.location='viewFranchisee.aspx';", true);
                //clear();

            }


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                 this,
                 this.GetType(),
                 "MessageBox",
                 "alert('Data Not Updated');window.location='EditFranchisee.aspx';", true);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewFranchisee.aspx");
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        changeState(ddlCountry.Text);
    }
    
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        changecity(ddlState.Text);
    }
    public void changeState(string country)
    {
        if (country == "India")
        {
            ddlState.Items.Clear();
            ddlState.Items.Add("--Select State--");
            ddlState.Items.Add("Andhra Pradesh");
            ddlState.Items.Add("Arunachal Pradesh");
            ddlState.Items.Add("Assam");
            ddlState.Items.Add("Bihar");
            ddlState.Items.Add("Chattisgardh");
            ddlState.Items.Add("Goa");
            ddlState.Items.Add("Gujrat");
            ddlState.Items.Add("Haryana");
            ddlState.Items.Add("Himachal Pradesh");
            ddlState.Items.Add("Jammu and Kashmir");
            ddlState.Items.Add("Jharkhand");
            ddlState.Items.Add("Karnataka");
            ddlState.Items.Add("Kerala");
            ddlState.Items.Add("Madhya Pradesh");
            ddlState.Items.Add("Maharashtra");
            ddlState.Items.Add("Manipur");
            ddlState.Items.Add("Meghalaya");
            ddlState.Items.Add("Mizoram");
            ddlState.Items.Add("Nagaland");
            ddlState.Items.Add("Orissa");
            ddlState.Items.Add("Punjab");
            ddlState.Items.Add("Rajastan");
            ddlState.Items.Add("Sikkim");
            ddlState.Items.Add("Tamil Nadu");
            ddlState.Items.Add("Tripura");
            ddlState.Items.Add("Uttar Pradesh");
            ddlState.Items.Add("Uttarakhand");
            ddlState.Items.Add("West Bengal");
          
        }
    }
    public void changecity(string state)
    {
        if (state == "Andhra Pradesh")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Adilabad");
            ddlCity.Items.Add("Anantapur");
            ddlCity.Items.Add("Chittor");
            ddlCity.Items.Add("East Godavari");
            ddlCity.Items.Add("Guntur");
            ddlCity.Items.Add("Hyderabad");
            ddlCity.Items.Add("Karimnagar");
            ddlCity.Items.Add("Khammam");
            ddlCity.Items.Add("Krishna");
            ddlCity.Items.Add("Kurnool");
            ddlCity.Items.Add("Mahbubnagar");
            ddlCity.Items.Add("Medak");
            ddlCity.Items.Add("Nalgonda");
            ddlCity.Items.Add("Nellore");
            ddlCity.Items.Add("Nizamabad");
            ddlCity.Items.Add("Prakasam");
            ddlCity.Items.Add("Rangareddy");
            ddlCity.Items.Add("Srikakulam");

            ddlCity.Items.Add("Vishakapattanam");
            ddlCity.Items.Add("Vizianagaram");
            ddlCity.Items.Add("Warangal");
            ddlCity.Items.Add("West Godavari");
            ddlCity.Items.Add("YSR Kadapa");

        }
        else if (state == "Arunachal Pradesh")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Anjaw");
            ddlCity.Items.Add("Changlang");
            ddlCity.Items.Add("East Kameng");
            ddlCity.Items.Add("East Godavari");
            ddlCity.Items.Add("Pasighat");
            ddlCity.Items.Add("Lohit");
            ddlCity.Items.Add("Lower Subansiri");
            ddlCity.Items.Add("Papum Pare");
            ddlCity.Items.Add("Tawang Town");
            ddlCity.Items.Add("Tirap");
            ddlCity.Items.Add("Lower Dibang Valley");
            ddlCity.Items.Add("Upper Siang");
            ddlCity.Items.Add("Upper Subansiri");
            ddlCity.Items.Add("West Kameng");
            ddlCity.Items.Add("West Siang");
            ddlCity.Items.Add("Upper Dibang Valley");
            ddlCity.Items.Add("Kurung Kumey");


        }
        else if (state == "Assam")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Baksa");
            ddlCity.Items.Add("Barpeta");
            ddlCity.Items.Add("Bongaigaon");
            ddlCity.Items.Add("Cachar");
            ddlCity.Items.Add("Chirang");
            ddlCity.Items.Add("Darrang");
            ddlCity.Items.Add("Dhemaji");
            ddlCity.Items.Add("Dhubri");
            ddlCity.Items.Add("Dibrugarh");
            ddlCity.Items.Add("Goalpara");
            ddlCity.Items.Add("Golaghat");
            ddlCity.Items.Add("Hailakandi");
            ddlCity.Items.Add("Jorhat");
            //    ddlCity.Items.Add("Kamrup");
            ddlCity.Items.Add("Karbi Anglong");
            ddlCity.Items.Add("Karimganj");
            ddlCity.Items.Add("Kokrajhar");
            ddlCity.Items.Add("Lakhimpur ");

            ddlCity.Items.Add("Marigaon");
            ddlCity.Items.Add("Nagaon");
            ddlCity.Items.Add("Nalbari");
            ddlCity.Items.Add("Dima Hasao");
            ddlCity.Items.Add("Sivasagar");
            ddlCity.Items.Add("Sonitpur");
            ddlCity.Items.Add("Tinsukia");
            ddlCity.Items.Add("Kamrup Metro");
            ddlCity.Items.Add("Udalguri");
        }

        else if (state == "Bihar")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Araria");
            ddlCity.Items.Add("Arwal");
            ddlCity.Items.Add("Aurangabad");
            ddlCity.Items.Add("Banka");
            ddlCity.Items.Add("Begusarai");
            ddlCity.Items.Add("Bhagalpur");
            ddlCity.Items.Add("Bhojpur");
            ddlCity.Items.Add("Buxar");
            ddlCity.Items.Add("East Champaran");
            ddlCity.Items.Add("Gaya");
            ddlCity.Items.Add(" Gopalganj");
            ddlCity.Items.Add("Jamui");
            ddlCity.Items.Add("Jehanabad");
            //    ddlCity.Items.Add("Kamrup");
            ddlCity.Items.Add("Kaimur");
            ddlCity.Items.Add("Katihar");
            ddlCity.Items.Add("Khagaria");
            ddlCity.Items.Add("Kishanganj ");

            ddlCity.Items.Add("Lakhisarai");
            ddlCity.Items.Add("Madhepura");


            ddlCity.Items.Add("Madhubani");
            ddlCity.Items.Add("Munger");
            ddlCity.Items.Add("Muzaffarpur");
            ddlCity.Items.Add("Nalanda");
            ddlCity.Items.Add("Nawada");
            ddlCity.Items.Add("Patna");
            ddlCity.Items.Add("Purnia");

            ddlCity.Items.Add("Rohtas");
            ddlCity.Items.Add("Saharsa");
            ddlCity.Items.Add("Samastipur");
            ddlCity.Items.Add("Saran");
            ddlCity.Items.Add("Sheikhpura");
            ddlCity.Items.Add("Sheohar");
            ddlCity.Items.Add("Sitamarhi");

            ddlCity.Items.Add("Siwan");
            ddlCity.Items.Add("Supaul");
            ddlCity.Items.Add("Vaishali");
            ddlCity.Items.Add("West Champaran");

        }
        else if (state == "Chattisgardh")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Balod");
            ddlCity.Items.Add("Baloda Bazar");
            ddlCity.Items.Add("Balrampur");
            ddlCity.Items.Add("Bastar");
            ddlCity.Items.Add("Bemetara");
            ddlCity.Items.Add("Bijapur");
            ddlCity.Items.Add("Bilaspur");
            ddlCity.Items.Add("Dantewada");
            ddlCity.Items.Add("Dhamtari");
            ddlCity.Items.Add("Durg");
            ddlCity.Items.Add("Gariaband");
            ddlCity.Items.Add("Janjgir-Champa");
            ddlCity.Items.Add("Jashpur");
            //    ddlCity.Items.Add("Kamrup");
            ddlCity.Items.Add("Kanker");
            ddlCity.Items.Add("Kawardha");
            ddlCity.Items.Add("Kondagaon");
            ddlCity.Items.Add("Korba ");

            ddlCity.Items.Add("Koriya");
            ddlCity.Items.Add("Mahasamund");
            ddlCity.Items.Add("Mungeli");
            ddlCity.Items.Add("Narayanpur");
            ddlCity.Items.Add("Raigarh");
            ddlCity.Items.Add("Raipur");
            ddlCity.Items.Add("Sukma");
            ddlCity.Items.Add("Surajpur");
            ddlCity.Items.Add("Surguja");
        }
        else if (state == "Goa")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("North Goa");
            ddlCity.Items.Add("South Goa");
        }
        else if (state == "Gujarat")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Ahmedabad");
            ddlCity.Items.Add("Amreli District");
            ddlCity.Items.Add("Anand");
            ddlCity.Items.Add("Banaskantha");
            ddlCity.Items.Add("Bharuch");
            ddlCity.Items.Add("Bhavnagar");
            ddlCity.Items.Add("Dahod");
            ddlCity.Items.Add("Gandhinagar");
            ddlCity.Items.Add("Jamnagar");
            ddlCity.Items.Add("Junagadh");
            ddlCity.Items.Add("Kheda");
            ddlCity.Items.Add("Mehsana");
            ddlCity.Items.Add("Narmada");
            //    ddlCity.Items.Add("Kamrup");
            ddlCity.Items.Add("Navsari");
            ddlCity.Items.Add("Panchmahal");
            ddlCity.Items.Add("Patan");
            ddlCity.Items.Add("Porbandar ");
            ddlCity.Items.Add("Rajkot");
            ddlCity.Items.Add("Sabarkantha");
            ddlCity.Items.Add("Surat");
            ddlCity.Items.Add("Surendranagar");
            ddlCity.Items.Add("Tapi");
            ddlCity.Items.Add("The Dangs");
            ddlCity.Items.Add("Vadodara");
            ddlCity.Items.Add("Valsad");
        }

        else if (state == "Haryana")
        {

            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Ambala");
            ddlCity.Items.Add("Bhiwani");
            ddlCity.Items.Add("Faridabad");
            ddlCity.Items.Add("Fatehabad");
            ddlCity.Items.Add("Hisar");
            ddlCity.Items.Add("Jhajjar");
            ddlCity.Items.Add("Jind");
            ddlCity.Items.Add("Kaithal");
            ddlCity.Items.Add("Karnal");
            ddlCity.Items.Add("Kurukshetra");
            ddlCity.Items.Add("Mahendragarh");
            ddlCity.Items.Add("Mewat");
            ddlCity.Items.Add("Palwal");
            //    ddlCity.Items.Add("Kamrup");
            ddlCity.Items.Add("Panchkula");
            ddlCity.Items.Add("Panipat");
            ddlCity.Items.Add("Rohtak");
            ddlCity.Items.Add("Sirsa");
            ddlCity.Items.Add("Sonipat");
            ddlCity.Items.Add(" Yamuna Nagar");
        }

        else if (state == "Himachal Pradesh")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Bilaspur");
            ddlCity.Items.Add("Chamba");
            ddlCity.Items.Add("Kangra");
            ddlCity.Items.Add("Kinnaur");
            ddlCity.Items.Add("Kullu");
            ddlCity.Items.Add("Lahaul and Spiti");
            ddlCity.Items.Add("Mandi");
            ddlCity.Items.Add("Shimla");
            ddlCity.Items.Add("Sirmaur");
            ddlCity.Items.Add("Solan");
            ddlCity.Items.Add("Una");
        }
        else if (state == "Jammu and Kashmir")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Anantnag");
            ddlCity.Items.Add("Bandipora");
            ddlCity.Items.Add("Baramulla");
            ddlCity.Items.Add("Budgam");
            ddlCity.Items.Add("Doda");
            ddlCity.Items.Add("Ganderbal");
            ddlCity.Items.Add("Jammu");
            ddlCity.Items.Add("Kargil");
            ddlCity.Items.Add("Kathua");
            ddlCity.Items.Add("Kishtwar");
            ddlCity.Items.Add("Kulgam");

            ddlCity.Items.Add("Kupwara");
            ddlCity.Items.Add("Leh");
            ddlCity.Items.Add("Poonch");
            ddlCity.Items.Add("Pulwama");
            ddlCity.Items.Add("Rajouri");
            ddlCity.Items.Add("Ramban");
            ddlCity.Items.Add("Reasi");
            ddlCity.Items.Add("Samba");
            ddlCity.Items.Add("Shopian");
            ddlCity.Items.Add("Srinagar");
            ddlCity.Items.Add("Udhampur");
        }

        else if (state == "Jharkhand")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Bokaro");
            ddlCity.Items.Add("Chaibasa(West Singhbhum)");
            ddlCity.Items.Add("Chatra");
            ddlCity.Items.Add("Dhanbad");
            ddlCity.Items.Add("Dumka");
            ddlCity.Items.Add("Garhwa");
            ddlCity.Items.Add("Giridih");
            ddlCity.Items.Add("Godda");
            ddlCity.Items.Add("Gumla");
            ddlCity.Items.Add("Hazaribagh ");
            ddlCity.Items.Add("Jamshedpur(East Singhbhum)");
            ddlCity.Items.Add("Jamtara");
            ddlCity.Items.Add("Kharsawan");
            ddlCity.Items.Add("Koderma");
            ddlCity.Items.Add("Latehar");
            ddlCity.Items.Add("Lohardaga");
            ddlCity.Items.Add("Pakur");
            ddlCity.Items.Add("Palamu");
            ddlCity.Items.Add("Ranchi");
            ddlCity.Items.Add("Sahebganj");
            ddlCity.Items.Add("Saraikela");
            ddlCity.Items.Add("Simdega");
        }
        else if (state == "Karnataka")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Bagalkot");
            ddlCity.Items.Add("Bangalore Urban");
            ddlCity.Items.Add("Bangalore Rural");
            ddlCity.Items.Add("Bellary");
            ddlCity.Items.Add("Bidar");
            ddlCity.Items.Add("Bijapur");
            ddlCity.Items.Add("Chamarajanagar");
            ddlCity.Items.Add("Chikballapur");
            ddlCity.Items.Add("Chikmagalur");
            ddlCity.Items.Add("Chitradurga");
            ddlCity.Items.Add("Dakshina Kannada");
            ddlCity.Items.Add("Davanagere");
            ddlCity.Items.Add("Dharwad");
            ddlCity.Items.Add("Gadag");
            ddlCity.Items.Add("Gulbarga");
            ddlCity.Items.Add("Hassan");
            ddlCity.Items.Add("Haveri");
            ddlCity.Items.Add("Kodagu");
            ddlCity.Items.Add("Kolar");
            ddlCity.Items.Add("Koppal");
            ddlCity.Items.Add("Mandya");
            ddlCity.Items.Add("Mysore");
            ddlCity.Items.Add("Raichur");
            ddlCity.Items.Add("Ramanagara");
            ddlCity.Items.Add("Shimoga");
            ddlCity.Items.Add("Tumkur");
            ddlCity.Items.Add("Udupi");
            ddlCity.Items.Add("Uttara Kannada");
            ddlCity.Items.Add("Yadgir");
        }
        else if (state == "Kerala")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Alappuzha");
            ddlCity.Items.Add("Eranakulam");
            ddlCity.Items.Add("Idukki");
            ddlCity.Items.Add("Kannur");
            ddlCity.Items.Add("Kasargod");
            ddlCity.Items.Add("Kollam");
            ddlCity.Items.Add("Kottayam");
            ddlCity.Items.Add("Kozhikode");
            ddlCity.Items.Add("Mallapuram");
            ddlCity.Items.Add("Palakkad");
            ddlCity.Items.Add("Pathanamthitta");
            ddlCity.Items.Add("Thiruvananthapuram");
            ddlCity.Items.Add("Thrissur");
            ddlCity.Items.Add("Wayanad");

        }
        else if (state == "Madhya Pradesh")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Alirajpur");
            ddlCity.Items.Add("Anuppur");
            ddlCity.Items.Add("Ashoknagar");
            ddlCity.Items.Add("Balaghat");
            ddlCity.Items.Add("Barwani");
            ddlCity.Items.Add("Betul");
            ddlCity.Items.Add("Bhind");
            ddlCity.Items.Add("Bhopal ");
            ddlCity.Items.Add("Burhanpur");
            ddlCity.Items.Add("Chhatarpur");
            ddlCity.Items.Add("Chhindwara");
            ddlCity.Items.Add("Damoh");
            ddlCity.Items.Add("Datia");
            //    ddlCity.Items.Add("Kamrup");
            ddlCity.Items.Add("Dewas");
            ddlCity.Items.Add("Dhar");
            ddlCity.Items.Add("Dindori");
            ddlCity.Items.Add("Guna");

            ddlCity.Items.Add("Gwalior");
            ddlCity.Items.Add("Harda");
            ddlCity.Items.Add("Hoshangabad");
            ddlCity.Items.Add("Indore");

            ddlCity.Items.Add("Jabalpur");
            ddlCity.Items.Add("Jhabua");
            ddlCity.Items.Add("Katni");
            ddlCity.Items.Add("Khandwa");
            ddlCity.Items.Add("Khargone");
            ddlCity.Items.Add("Mandla");
            ddlCity.Items.Add("Mandsaur");
            ddlCity.Items.Add("Morena");
            ddlCity.Items.Add("Narsinghpur");
            ddlCity.Items.Add("Neemuch");
            ddlCity.Items.Add("Panna");
            ddlCity.Items.Add("Raisen");
            ddlCity.Items.Add("Rajgarh");
            ddlCity.Items.Add("Ratlam");
            ddlCity.Items.Add("Rewa");
            ddlCity.Items.Add("Sagar");
            ddlCity.Items.Add("Satna");
            ddlCity.Items.Add("Sehore");
            ddlCity.Items.Add("Seoni");
            ddlCity.Items.Add("Singrauli");

            ddlCity.Items.Add("Shahdol");
            ddlCity.Items.Add("Shajapur");
            ddlCity.Items.Add("Sheopur");
            ddlCity.Items.Add("Shivpuri");

            ddlCity.Items.Add("Sidhi");
            ddlCity.Items.Add("Tikamgarh");
            ddlCity.Items.Add("Ujjain");
            ddlCity.Items.Add("Umaria");
            ddlCity.Items.Add("Vidisha");
        }
        else if (state == "Maharashtra")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Ahmednagar");
            ddlCity.Items.Add("Akola");
            ddlCity.Items.Add("Amravati");
            ddlCity.Items.Add("Aurangabad");
            ddlCity.Items.Add("Beed");
            ddlCity.Items.Add("Bhandara");
            ddlCity.Items.Add("Buldhana");
            ddlCity.Items.Add("Chandrapur");
            ddlCity.Items.Add("Dhule");
            ddlCity.Items.Add("Gadchiroli");
            ddlCity.Items.Add("Gondia");
            ddlCity.Items.Add("Hingoli");
            ddlCity.Items.Add("Jalgaon");
            ddlCity.Items.Add("Jalna");
            ddlCity.Items.Add("Kolhapur");
            ddlCity.Items.Add("Latur");
            ddlCity.Items.Add("Mumbai Surburban");
            ddlCity.Items.Add("Nagpur");

            ddlCity.Items.Add("Nanded");
            ddlCity.Items.Add("Nashik");
            ddlCity.Items.Add("Nundarbar");
            ddlCity.Items.Add("Osmanabad");
            ddlCity.Items.Add("Parbhani");
            ddlCity.Items.Add("Pune");
            ddlCity.Items.Add("Raigarh");
            ddlCity.Items.Add("Ratnagiri");
            ddlCity.Items.Add("Sangli");
            ddlCity.Items.Add("Satara");
            ddlCity.Items.Add("Sindhudurg");
            ddlCity.Items.Add("Solapur");
            ddlCity.Items.Add("Thane");
            ddlCity.Items.Add("Wardha");
            ddlCity.Items.Add("Washim");
            ddlCity.Items.Add("Yavatmal");
        }
        else if (state == "Manipur")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Bishnupur");
            ddlCity.Items.Add("Chandel");
            ddlCity.Items.Add("Churachandpur");
            ddlCity.Items.Add("Imphal East");
            ddlCity.Items.Add("Imphal West");
            ddlCity.Items.Add("Senapati");
            ddlCity.Items.Add("Tamenglong");
            ddlCity.Items.Add("Thoubal");
            ddlCity.Items.Add("Ukhrul");



        }
        else if (state == "Meghalaya")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("East Garo Hills/North Garo Hills");
            ddlCity.Items.Add("East Khasi Hills");
            ddlCity.Items.Add("Jaintia Hills/East Jaintia Hills");
            ddlCity.Items.Add("Ri-Bhoi");
            ddlCity.Items.Add("South Garo Hills");
            ddlCity.Items.Add("West Garo Hills/South West Garo Hills");
            ddlCity.Items.Add("West Khasi Hills/South West Khasi Hills");




        }
        else if (state == "Mizoram")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Aizawl");
            ddlCity.Items.Add("Champhai");

            ddlCity.Items.Add("Kolasib");
            ddlCity.Items.Add("Lawngtlai");
            ddlCity.Items.Add("Lunglei");
            ddlCity.Items.Add("Mamit");
            ddlCity.Items.Add("Saiha");

            ddlCity.Items.Add("Serchhip");

        }

        else if (state == "Nagaland")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Dimapur");
            ddlCity.Items.Add("Kiphire");

            ddlCity.Items.Add("Kohima");
            ddlCity.Items.Add("Longleng");
            ddlCity.Items.Add("Mokokchung");
            ddlCity.Items.Add("Mon");
            ddlCity.Items.Add("Peren");

            ddlCity.Items.Add("Phek");
            ddlCity.Items.Add("Tuensang");
            ddlCity.Items.Add("Wokha");

            ddlCity.Items.Add("Zunheboto");

        }
        else if (state == "Orissa")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Angul");
            ddlCity.Items.Add("Balangir");

            ddlCity.Items.Add("Balasore");
            ddlCity.Items.Add("Bargarh");
            ddlCity.Items.Add("Bhadrak");
            ddlCity.Items.Add("Boudh (Bauda)");
            ddlCity.Items.Add("Cuttack");

            ddlCity.Items.Add("Debagarh (Deogarh)");
            ddlCity.Items.Add("Dhenkanal");
            ddlCity.Items.Add("Gajapati");

            ddlCity.Items.Add("Ganjam");

            ddlCity.Items.Add("Jagatsinghpur");

            ddlCity.Items.Add("Jajapur (Jajpur)");
            ddlCity.Items.Add("Jharsuguda");
            ddlCity.Items.Add("Kalahandi");

            ddlCity.Items.Add("Kandhamal");

            ddlCity.Items.Add("Kendrapara");

            ddlCity.Items.Add("Kendujhar (Keonjhar)");
            ddlCity.Items.Add("Khordha");
            ddlCity.Items.Add("Koraput");

            ddlCity.Items.Add("Malkangiri");

            ddlCity.Items.Add("Mayurbhanj");
            ddlCity.Items.Add("Nabarangpur");
            ddlCity.Items.Add("Nayagarh");

            ddlCity.Items.Add("Nuapada");
            ddlCity.Items.Add("Puri");
            ddlCity.Items.Add("Rayagada");
            ddlCity.Items.Add("Sambalpur");

            ddlCity.Items.Add("Subarnapur");
            ddlCity.Items.Add("Sundergarh");

        }


        else if (state == "Punjab")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Amritsar");
            ddlCity.Items.Add("Barnala");

            ddlCity.Items.Add("Bathinda");
            ddlCity.Items.Add("Faridkot");
            ddlCity.Items.Add("Fatehgarh Sahib");
            ddlCity.Items.Add("Ferozepur");
            ddlCity.Items.Add("Fazilka");

            ddlCity.Items.Add("Gurdaspur");
            ddlCity.Items.Add("Hoshiarpur");
            ddlCity.Items.Add("Jalandhar");

            ddlCity.Items.Add("Kapurthala");

            ddlCity.Items.Add("Ludhiana");

            ddlCity.Items.Add("Mansa");
            ddlCity.Items.Add("Moga");
            ddlCity.Items.Add("Muktsar");

            ddlCity.Items.Add("Pathankot");

            ddlCity.Items.Add("Rupnagar");

            ddlCity.Items.Add("Mohali");
            ddlCity.Items.Add("Shahid Bhagat Singh Nagar (Nawanshahr)");
            ddlCity.Items.Add("Tarn Taran");

        }
        else if (state == "Rajastan")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Ajmer");
            ddlCity.Items.Add("Alwar");

            ddlCity.Items.Add("Banswara");
            ddlCity.Items.Add("Baran");
            ddlCity.Items.Add("Barmer");
            ddlCity.Items.Add("Bharatpur");
            ddlCity.Items.Add("Bhilwara");

            ddlCity.Items.Add("Bikaner");
            ddlCity.Items.Add("Bundi");
            ddlCity.Items.Add("Chittorgarh");

            ddlCity.Items.Add("Churu");

            ddlCity.Items.Add("Dausa");

            ddlCity.Items.Add("Dholpur");
            ddlCity.Items.Add("Dungarpur");

            ddlCity.Items.Add("Hanumangarh");

            ddlCity.Items.Add("Jaipur");

            ddlCity.Items.Add("Jaisalmer");

            ddlCity.Items.Add("Jalor");
            ddlCity.Items.Add("Jhalawar");
            ddlCity.Items.Add("Jhunjhunu");

            ddlCity.Items.Add("Jodhpur");
            ddlCity.Items.Add("Karauli");
            ddlCity.Items.Add("Kota");

            ddlCity.Items.Add("Nagaur");
            ddlCity.Items.Add("Pali");
            ddlCity.Items.Add("Pratapgarh");

            ddlCity.Items.Add("Rajsamand");
            ddlCity.Items.Add("Sawai Madhopur");
            ddlCity.Items.Add("Sikar  Sirohi");
            ddlCity.Items.Add("Sri Ganganagar");
            ddlCity.Items.Add("Tonk");
            ddlCity.Items.Add("Udaipur");
            ddlCity.Items.Add("Rajasthan");
        }
        else if (state == "Sikkim")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("East Sikkim");
            ddlCity.Items.Add("North Sikkim");

            ddlCity.Items.Add("South Sikkim");
            ddlCity.Items.Add("West Sikkim");
        }

        else if (state == "Tamil Nadu")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Ariyalur");
            ddlCity.Items.Add("Chennai");

            ddlCity.Items.Add("Coimbatore");
            ddlCity.Items.Add("Cuddalore");
            ddlCity.Items.Add("Dharmapuri");
            ddlCity.Items.Add("Dindigul");

            ddlCity.Items.Add("Erode");
            ddlCity.Items.Add("Kanchipuram");
            ddlCity.Items.Add("Kanniyakumari");
            ddlCity.Items.Add("Karur");

            ddlCity.Items.Add("Krishnagiri");
            ddlCity.Items.Add("Madurai");
            ddlCity.Items.Add("Nagapattinam");
            ddlCity.Items.Add("Namakkal");

            ddlCity.Items.Add("Nilgiris");
            ddlCity.Items.Add("Perambalur");


            ddlCity.Items.Add("Pudukkottai");
            ddlCity.Items.Add("Ramanathapuram");
            ddlCity.Items.Add("Salem");
            ddlCity.Items.Add("Sivaganga");

            ddlCity.Items.Add("Thanjavur");
            ddlCity.Items.Add("Theni");
            ddlCity.Items.Add("Thoothukudi");
            ddlCity.Items.Add("Thiruvarur");

            ddlCity.Items.Add("Tirunelveli");
            ddlCity.Items.Add("Tiruchirappalli");

            ddlCity.Items.Add("Thiruvallur");
            ddlCity.Items.Add("Tiruppur");
            ddlCity.Items.Add("Tiruvannamalai");
            ddlCity.Items.Add(" Vellore");

            ddlCity.Items.Add("Villupuram");
            ddlCity.Items.Add("Virudhunagar");


        }

        else if (state == "Tripura")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Dhalai");
            ddlCity.Items.Add("Gomati");
            ddlCity.Items.Add("Khowai");
            ddlCity.Items.Add("North Tripura");

            ddlCity.Items.Add("Sipahijala");

            ddlCity.Items.Add("South Tripura");

            ddlCity.Items.Add("Unakoti");


            ddlCity.Items.Add("West Tripura");
        }


        else if (state == "Uttar Pradesh")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Agra");
            ddlCity.Items.Add("Aligarh");
            ddlCity.Items.Add("Allahabad");
            ddlCity.Items.Add("Auraiya");
            ddlCity.Items.Add("Azamgarh");
            ddlCity.Items.Add("Baghpat");
            ddlCity.Items.Add("Bahraich");
            ddlCity.Items.Add("Ballia");

            ddlCity.Items.Add("Balrampur");
            ddlCity.Items.Add("Banda");
            ddlCity.Items.Add("Barabanki");
            ddlCity.Items.Add("Bareilly");
            ddlCity.Items.Add("Basti");
            ddlCity.Items.Add("Bijnor");
            ddlCity.Items.Add("Budaun");
            ddlCity.Items.Add("Bulandshahar");
            ddlCity.Items.Add("Chandauli");
            ddlCity.Items.Add("Chitrakoot");
            ddlCity.Items.Add("Deoria");
            ddlCity.Items.Add("Etah ");
            ddlCity.Items.Add("Etawah");
            ddlCity.Items.Add("Faizabad");
            ddlCity.Items.Add("Farukkhabad");
            ddlCity.Items.Add("Fatehpur");

            ddlCity.Items.Add("Firozabad");
            ddlCity.Items.Add("Gautam Buddha Nagar");
            ddlCity.Items.Add("Ghaziabad");
            ddlCity.Items.Add("Ghazipur");
            ddlCity.Items.Add("Gonda");
            ddlCity.Items.Add("Gorakhpur");
            ddlCity.Items.Add("Hamirpur");
            ddlCity.Items.Add("Hardoi");
            ddlCity.Items.Add("Hathras");
            ddlCity.Items.Add("Jalaun");

            ddlCity.Items.Add("Jaunpur");
            ddlCity.Items.Add("Jhansi");
            ddlCity.Items.Add("Jyotiba Phoole Nagar");
            ddlCity.Items.Add("Kannauj");
            ddlCity.Items.Add("Kanpur Dehat");
            ddlCity.Items.Add("Kanpur Nagar");
            ddlCity.Items.Add("Kaushambi");
            ddlCity.Items.Add("Kushi Nagar (Padrauna)");
            ddlCity.Items.Add("Hathras");
            ddlCity.Items.Add(" Lakhimpur Kheri");
            ddlCity.Items.Add("Lalitpur");
            ddlCity.Items.Add("Lucknow");
            ddlCity.Items.Add("Maharajganj");
            ddlCity.Items.Add("Mahoba");
            ddlCity.Items.Add("Mainpuri");
            ddlCity.Items.Add("Mathura");
            ddlCity.Items.Add("MAU");
            ddlCity.Items.Add("Meerut");
            ddlCity.Items.Add("Mirzapur");
            ddlCity.Items.Add("Moradabad");

            ddlCity.Items.Add("Muzaffar Nagar");
            ddlCity.Items.Add("Pilibhit");
            ddlCity.Items.Add("Pratapgarh");

            ddlCity.Items.Add("Raebareli");
            ddlCity.Items.Add("Rampur");
            ddlCity.Items.Add("Saharanpur");
            ddlCity.Items.Add("Sant Kabir Nagar");
            ddlCity.Items.Add("Sant Ravidas Nagar");
            ddlCity.Items.Add("Shahjahanpur");

            ddlCity.Items.Add("Shravasti");
            ddlCity.Items.Add("Siddharth Nagar");
            ddlCity.Items.Add("Sitapur");
            ddlCity.Items.Add("Sonbhadra");

            ddlCity.Items.Add("Sultanpur");
            ddlCity.Items.Add("Unnao");
            ddlCity.Items.Add("Varanasi");
        }
        else if (state == "Uttarakhand")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Almora");
            ddlCity.Items.Add("Bageshwar");
            ddlCity.Items.Add("Chamoli");
            ddlCity.Items.Add("Champawat");

            ddlCity.Items.Add("Dehradun");
            ddlCity.Items.Add("Haridwar");
            ddlCity.Items.Add("Nainital");
            ddlCity.Items.Add("Pauri Garhwal");

            ddlCity.Items.Add("Pithoragarh");
            ddlCity.Items.Add("Rudra Prayag");
            ddlCity.Items.Add("Udham Singh Nagar");
            ddlCity.Items.Add("Uttarkashi");
        }
        else if (state == "West Bengal")
        {
            ddlCity.Items.Clear();
            ddlCity.Items.Add("--Select City--");
            ddlCity.Items.Add("Bankura");
            ddlCity.Items.Add("Bardhaman");
            ddlCity.Items.Add("Birbhum");
            ddlCity.Items.Add("Cooch Behar");

            ddlCity.Items.Add("Darjeeling");
            ddlCity.Items.Add("East Midnapore");


            ddlCity.Items.Add("Hooghly");
            ddlCity.Items.Add("Howrah");

            ddlCity.Items.Add("Maldah");
            ddlCity.Items.Add("Murshidabad");
            ddlCity.Items.Add("Nadia");
            ddlCity.Items.Add("North 24 Parganas");

            ddlCity.Items.Add("North Dinajpur");
            ddlCity.Items.Add("Purulia");
            ddlCity.Items.Add("South 24 Parganas");
            ddlCity.Items.Add("South Dinajpur");

            ddlCity.Items.Add("West Midnapore");


        }
    }

  
}