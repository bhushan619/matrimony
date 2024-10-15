using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;

public partial class campaignRegistration : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    string gen = string.Empty;
    string Maritalstatus = string.Empty;
    string nochild = string.Empty;
    string childStatus = string.Empty;
    string Manglik = string.Empty;
    string BodyType = string.Empty;
    string Complexion = string.Empty;
    string Familystatus = string.Empty;
    string Familytype = string.Empty;
    string Familyvalue = string.Empty;

    string eat = string.Empty;
    string smoke = string.Empty;
    string drink = string.Empty;
    string age = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["memberid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../register/login.aspx';</script>");
            Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }


        if (!IsPostBack)
        {
            MStatusz.Visible = false;
            MemberBasicData();
        }

    }
    public void MemberBasicData()
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varMemberName,varGender,varMembershipType,varPhoto FROM tblammemberregistration WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblMemberId.Text = dbc.dr["varMemberId"].ToString();
                lblMemberName.Text = dbc.dr["varMemberName"].ToString();
                imgMemberPhoto.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();
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
            dbc.dr.Close();
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
        Session["memberid"] = "";
        Session.Remove("memberid");

        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("~/Default.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (rgbManglikYes.Checked)
            {
                Manglik = rgbManglikYes.Text;
            }
            else if (rgbManglikNo.Checked)
            {
                Manglik = rgbManglikNo.Text;
            }
            else if (rgbManglikNotKnow.Checked)
            {
                Manglik = rgbManglikNotKnow.Text;
            }
            //////////////////////////////////////BodyType
            if (rgbBTAthletic.Checked)
            {
                BodyType = rgbBTAthletic.Text;
            }
            else if (rgbBTAverage.Checked)
            {
                BodyType = rgbBTAverage.Text;
            }
            else if (rgbBTHeavy.Checked)
            {
                BodyType = rgbBTHeavy.Text;
            }
            else if (rgbBTSlim.Checked)
            {
                BodyType = rgbBTSlim.Text;
            }
            ///////////////////////////////////Complexion
            if (rgbFair.Checked)
            {
                Complexion = rgbFair.Text;
            }
            else if (rgbWheatish.Checked)
            {
                Complexion = rgbWheatish.Text;
            }
            else if (rgbWheatishMedium.Checked)
            {
                Complexion = rgbWheatishMedium.Text;
            }
            else if (rgbDark.Checked)
            {
                Complexion = rgbDark.Text;
            }

            ///////////////////////////////////Familystatus
            if (rgbMiddleClass.Checked)
            {
                Familystatus = rgbMiddleClass.Text;
            }
            else if (rgbUppermiddle.Checked)
            {
                Familystatus = rgbUppermiddle.Text;
            }
            else if (rgbRich.Checked)
            {
                Familystatus = rgbRich.Text;
            }
            else if (rgbAffluent.Checked)
            {
                Familystatus = rgbAffluent.Text;
            }
            ///////////////////////////////////FamilyType
            if (rgbJoint.Checked)
            {
                Familytype = rgbJoint.Text;
            }
            else if (rgbNuclear.Checked)
            {
                Familytype = rgbNuclear.Text;
            }
            else if (rgbOther.Checked)
            {
                Familytype = rgbOther.Text;
            }
            ///////////////////////////////////Familyvalue
            if (rgbOrthodox.Checked)
            {
                Familyvalue = rgbOrthodox.Text;
            }
            else if (rgbTraditional.Checked)
            {
                Familyvalue = rgbTraditional.Text;
            }
            else if (rgbModerate.Checked)
            {
                Familyvalue = rgbModerate.Text;
            }
            else if (rgbLiberal.Checked)
            {
                Familyvalue = rgbLiberal.Text;
            }
            ///////////////////////////////////eat
            if (rgbVegetarian.Checked)
            {
                eat = rgbVegetarian.Text;
            }
            else if (rgbNonVegetarian.Checked)
            {
                eat = rgbNonVegetarian.Text;
            }
            else if (rgbEggetarian.Checked)
            {
                eat = rgbEggetarian.Text;
            }
            else if (rgbJain.Checked)
            {
                eat = rgbJain.Text;
            }
            ///////////////////////////////////smoke
            if (rgbSYes.Checked)
            {
                smoke = rgbSYes.Text;
            }
            else if (rgbSNo.Checked)
            {
                smoke = rgbSNo.Text;
            }
            else if (rgbSOccasionally.Checked)
            {
                smoke = rgbSOccasionally.Text;
            }
            ///////////////////////////////////drink
            if (rgbDYes.Checked)
            {
                drink = rgbDYes.Text;
            }
            else if (rgbDNo.Checked)
            {
                drink = rgbDNo.Text;
            }
            else if (rgbDOccasionally.Checked)
            {
                drink = rgbDOccasionally.Text;
            }
            /////////////////////////////////////Maritalstatus
            if (rgbNeverMarrided.Checked)
            {
                Maritalstatus = rgbNeverMarrided.Text;
                nochild = "NA";
                childStatus = "NA";
            }
            else if (rgbWidow.Checked)
            {
                Maritalstatus = rgbWidow.Text;
                nochild = ddlNoOfChild.Text;
                if (rgbCLive.Checked)
                {
                    childStatus = rgbCLive.Text;
                }
                else if (rgbCNotLive.Checked)
                {
                    childStatus = rgbCNotLive.Text;
                }
            }
            else if (rgbDivorced.Checked)
            {
                Maritalstatus = rgbDivorced.Text;
                nochild = ddlNoOfChild.Text;
                if (rgbCLive.Checked)
                {
                    childStatus = rgbCLive.Text;
                }
                else if (rgbCNotLive.Checked)
                {
                    childStatus = rgbCNotLive.Text;
                }

            }
            else if (rgbAwaitingDivorce.Checked)
            {
                Maritalstatus = rgbAwaitingDivorce.Text;
                nochild = ddlNoOfChild.Text;
                if (rgbCLive.Checked)
                {
                    childStatus = rgbCLive.Text;
                }
                else if (rgbCNotLive.Checked)
                {
                    childStatus = rgbCNotLive.Text;
                }
            }
            String input = txtAboutMyself.Text.Replace("'", "''");
            String pattern = @"(\S*)@\S*\.\S*";
            String result = Regex.Replace(input, pattern, "(Omitted)");

            pattern = @"\d";

            result = Regex.Replace(result, pattern, "x");

            int a = new DateTime((DateTime.Now - Convert.ToDateTime(ddlDay.Text + ddlMonth.Text + ddlYear.Text)).Ticks).Year;
            age = Convert.ToString(a);
            int insert_ok = dbc.insert_tblCompaignRegistration(Session["memberid"].ToString(), ddlDay.Text, ddlMonth.Text, ddlYear.Text, age, Maritalstatus, nochild, childStatus, result, ddlMotherTongue.Text, ddlReligion.Text, ddlCaste.Text, txtSubCaste.Text, txtGotra.Text, Manglik, ddlHeighFtIn.Text, ddlHeightCms.Text, ddlWeight.Text, ddlBloodgroup.Text, BodyType, Complexion, ddlSpecialCase.Text, ddlQualification.Text, txtAdditional.Text, ddlEmployeeIn.Text, ddlOccupation.Text, txtAnnualIncome.Text, ddlCurrency.Text, ddlCountry.Text, ddlCitizenShip.Text, cmbstate.Text, cmbcity.Text, Familystatus, Familytype, Familyvalue, eat, smoke, drink, txtAddress.Text,ddlWeightLbs.Text);

            if (insert_ok == 1)
            {
                dbc.FirstTimeLogin(Session["memberid"].ToString());
              
                ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('Profile Completed !!!');window.location='UploadPic.aspx';", true);
            
               
            }
            else
            {
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Some problem Please try again...!!!');", true);
            }
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
        txtAboutMyself.Text = "";
        txtAdditional.Text = "";
        txtAnnualIncome.Text = "";
        txtGotra.Text = "";
        txtSubCaste.Text = "";
        ddlBloodgroup.SelectedIndex = 0;
        ddlCaste.SelectedIndex = 0;
        ddlCitizenShip.SelectedIndex = 0;
        ddlCurrency.SelectedIndex = 0;
        ddlDay.SelectedIndex = 0;
        ddlEmployeeIn.SelectedIndex = 0;
        ddlHeighFtIn.SelectedIndex = 0;
        ddlHeightCms.SelectedIndex = 0;
        ddlMonth.SelectedIndex = 0;
        ddlMotherTongue.SelectedIndex = 0;
        ddlNoOfChild.SelectedIndex = 0;
        ddlOccupation.SelectedIndex = 0;
        ddlQualification.SelectedIndex = 0;
        ddlReligion.SelectedIndex = 0;
        ddlSpecialCase.SelectedIndex = 0;
        ddlWeight.SelectedIndex = 0;
        ddlYear.SelectedIndex = 0;
        ddlCountry.SelectedIndex = 0;
    }
    protected void lnkLogoutUp_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session["memberid"] = "";
        Session.Remove("memberid");

        Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();

        Response.Redirect("~/login.aspx");
    }
    protected void state_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cmbstate.Text == "Andhra Pradesh")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Adilabad");
                cmbcity.Items.Add("Anantapur");
                cmbcity.Items.Add("Chittor");
                cmbcity.Items.Add("East Godavari");
                cmbcity.Items.Add("Guntur");
                cmbcity.Items.Add("Hyderabad");
                cmbcity.Items.Add("Karimnagar");
                cmbcity.Items.Add("Khammam");
                cmbcity.Items.Add("Krishna");
                cmbcity.Items.Add("Kurnool");
                cmbcity.Items.Add("Mahbubnagar");
                cmbcity.Items.Add("Medak");
                cmbcity.Items.Add("Nalgonda");
                cmbcity.Items.Add("Nellore");
                cmbcity.Items.Add("Nizamabad");
                cmbcity.Items.Add("Prakasam");
                cmbcity.Items.Add("Rangareddy");
                cmbcity.Items.Add("Srikakulam");

                cmbcity.Items.Add("Vishakapattanam");
                cmbcity.Items.Add("Vizianagaram");
                cmbcity.Items.Add("Warangal");
                cmbcity.Items.Add("West Godavari");
                cmbcity.Items.Add("YSR Kadapa");

            }
            else if (cmbstate.Text == "Arunachal Pradesh")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Anjaw");
                cmbcity.Items.Add("Changlang");
                cmbcity.Items.Add("East Kameng");
                cmbcity.Items.Add("East Godavari");
                cmbcity.Items.Add("Pasighat");
                cmbcity.Items.Add("Lohit");
                cmbcity.Items.Add("Lower Subansiri");
                cmbcity.Items.Add("Papum Pare");
                cmbcity.Items.Add("Tawang Town");
                cmbcity.Items.Add("Tirap");
                cmbcity.Items.Add("Lower Dibang Valley");
                cmbcity.Items.Add("Upper Siang");
                cmbcity.Items.Add("Upper Subansiri");
                cmbcity.Items.Add("West Kameng");
                cmbcity.Items.Add("West Siang");
                cmbcity.Items.Add("Upper Dibang Valley");
                cmbcity.Items.Add("Kurung Kumey");


            }
            else if (cmbstate.Text == "Assam")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Baksa");
                cmbcity.Items.Add("Barpeta");
                cmbcity.Items.Add("Bongaigaon");
                cmbcity.Items.Add("Cachar");
                cmbcity.Items.Add("Chirang");
                cmbcity.Items.Add("Darrang");
                cmbcity.Items.Add("Dhemaji");
                cmbcity.Items.Add("Dhubri");
                cmbcity.Items.Add("Dibrugarh");
                cmbcity.Items.Add("Goalpara");
                cmbcity.Items.Add("Golaghat");
                cmbcity.Items.Add("Hailakandi");
                cmbcity.Items.Add("Jorhat");
                //    cmbcity.Items.Add("Kamrup");
                cmbcity.Items.Add("Karbi Anglong");
                cmbcity.Items.Add("Karimganj");
                cmbcity.Items.Add("Kokrajhar");
                cmbcity.Items.Add("Lakhimpur ");

                cmbcity.Items.Add("Marigaon");
                cmbcity.Items.Add("Nagaon");
                cmbcity.Items.Add("Nalbari");
                cmbcity.Items.Add("Dima Hasao");
                cmbcity.Items.Add("Sivasagar");
                cmbcity.Items.Add("Sonitpur");
                cmbcity.Items.Add("Tinsukia");
                cmbcity.Items.Add("Kamrup Metro");
                cmbcity.Items.Add("Udalguri");
            }

            else if (cmbstate.Text == "Bihar")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Araria");
                cmbcity.Items.Add("Arwal");
                cmbcity.Items.Add("Aurangabad");
                cmbcity.Items.Add("Banka");
                cmbcity.Items.Add("Begusarai");
                cmbcity.Items.Add("Bhagalpur");
                cmbcity.Items.Add("Bhojpur");
                cmbcity.Items.Add("Buxar");
                cmbcity.Items.Add("East Champaran");
                cmbcity.Items.Add("Gaya");
                cmbcity.Items.Add(" Gopalganj");
                cmbcity.Items.Add("Jamui");
                cmbcity.Items.Add("Jehanabad");
                //    cmbcity.Items.Add("Kamrup");
                cmbcity.Items.Add("Kaimur");
                cmbcity.Items.Add("Katihar");
                cmbcity.Items.Add("Khagaria");
                cmbcity.Items.Add("Kishanganj ");

                cmbcity.Items.Add("Lakhisarai");
                cmbcity.Items.Add("Madhepura");


                cmbcity.Items.Add("Madhubani");
                cmbcity.Items.Add("Munger");
                cmbcity.Items.Add("Muzaffarpur");
                cmbcity.Items.Add("Nalanda");
                cmbcity.Items.Add("Nawada");
                cmbcity.Items.Add("Patna");
                cmbcity.Items.Add("Purnia");

                cmbcity.Items.Add("Rohtas");
                cmbcity.Items.Add("Saharsa");
                cmbcity.Items.Add("Samastipur");
                cmbcity.Items.Add("Saran");
                cmbcity.Items.Add("Sheikhpura");
                cmbcity.Items.Add("Sheohar");
                cmbcity.Items.Add("Sitamarhi");

                cmbcity.Items.Add("Siwan");
                cmbcity.Items.Add("Supaul");
                cmbcity.Items.Add("Vaishali");
                cmbcity.Items.Add("West Champaran");

            }
            else if (cmbstate.Text == "Chattisgardh")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Balod");
                cmbcity.Items.Add("Baloda Bazar");
                cmbcity.Items.Add("Balrampur");
                cmbcity.Items.Add("Bastar");
                cmbcity.Items.Add("Bemetara");
                cmbcity.Items.Add("Bijapur");
                cmbcity.Items.Add("Bilaspur");
                cmbcity.Items.Add("Dantewada");
                cmbcity.Items.Add("Dhamtari");
                cmbcity.Items.Add("Durg");
                cmbcity.Items.Add("Gariaband");
                cmbcity.Items.Add("Janjgir-Champa");
                cmbcity.Items.Add("Jashpur");
                //    cmbcity.Items.Add("Kamrup");
                cmbcity.Items.Add("Kanker");
                cmbcity.Items.Add("Kawardha");
                cmbcity.Items.Add("Kondagaon");
                cmbcity.Items.Add("Korba ");

                cmbcity.Items.Add("Koriya");
                cmbcity.Items.Add("Mahasamund");
                cmbcity.Items.Add("Mungeli");
                cmbcity.Items.Add("Narayanpur");
                cmbcity.Items.Add("Raigarh");
                cmbcity.Items.Add("Raipur");
                cmbcity.Items.Add("Sukma");
                cmbcity.Items.Add("Surajpur");
                cmbcity.Items.Add("Surguja");
            }
            else if (cmbstate.Text == "Goa")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("North Goa");
                cmbcity.Items.Add("South Goa");
            }
            else if (cmbstate.Text == "Gujarat")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Ahmedabad");
                cmbcity.Items.Add("Amreli District");
                cmbcity.Items.Add("Anand");
                cmbcity.Items.Add("Banaskantha");
                cmbcity.Items.Add("Bharuch");
                cmbcity.Items.Add("Bhavnagar");
                cmbcity.Items.Add("Dahod");
                cmbcity.Items.Add("Gandhinagar");
                cmbcity.Items.Add("Jamnagar");
                cmbcity.Items.Add("Junagadh");
                cmbcity.Items.Add("Kheda");
                cmbcity.Items.Add("Mehsana");
                cmbcity.Items.Add("Narmada");
                //    cmbcity.Items.Add("Kamrup");
                cmbcity.Items.Add("Navsari");
                cmbcity.Items.Add("Panchmahal");
                cmbcity.Items.Add("Patan");
                cmbcity.Items.Add("Porbandar ");
                cmbcity.Items.Add("Rajkot");
                cmbcity.Items.Add("Sabarkantha");
                cmbcity.Items.Add("Surat");
                cmbcity.Items.Add("Surendranagar");
                cmbcity.Items.Add("Tapi");
                cmbcity.Items.Add("The Dangs");
                cmbcity.Items.Add("Vadodara");
                cmbcity.Items.Add("Valsad");
            }

            else if (cmbstate.Text == "Haryana")
            {

                cmbcity.Items.Clear();

                cmbcity.Items.Add("Ambala");
                cmbcity.Items.Add("Bhiwani");
                cmbcity.Items.Add("Faridabad");
                cmbcity.Items.Add("Fatehabad");
                cmbcity.Items.Add("Hisar");
                cmbcity.Items.Add("Jhajjar");
                cmbcity.Items.Add("Jind");
                cmbcity.Items.Add("Kaithal");
                cmbcity.Items.Add("Karnal");
                cmbcity.Items.Add("Kurukshetra");
                cmbcity.Items.Add("Mahendragarh");
                cmbcity.Items.Add("Mewat");
                cmbcity.Items.Add("Palwal");
                //    cmbcity.Items.Add("Kamrup");
                cmbcity.Items.Add("Panchkula");
                cmbcity.Items.Add("Panipat");
                cmbcity.Items.Add("Rohtak");
                cmbcity.Items.Add("Sirsa");
                cmbcity.Items.Add("Sonipat");
                cmbcity.Items.Add(" Yamuna Nagar");
            }

            else if (cmbstate.Text == "Himachal Pradesh")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Bilaspur");
                cmbcity.Items.Add("Chamba");
                cmbcity.Items.Add("Kangra");
                cmbcity.Items.Add("Kinnaur");
                cmbcity.Items.Add("Kullu");
                cmbcity.Items.Add("Lahaul and Spiti");
                cmbcity.Items.Add("Mandi");
                cmbcity.Items.Add("Shimla");
                cmbcity.Items.Add("Sirmaur");
                cmbcity.Items.Add("Solan");
                cmbcity.Items.Add("Una");
            }
            else if (cmbstate.Text == "Jammu and Kashmir")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Anantnag");
                cmbcity.Items.Add("Bandipora");
                cmbcity.Items.Add("Baramulla");
                cmbcity.Items.Add("Budgam");
                cmbcity.Items.Add("Doda");
                cmbcity.Items.Add("Ganderbal");
                cmbcity.Items.Add("Jammu");
                cmbcity.Items.Add("Kargil");
                cmbcity.Items.Add("Kathua");
                cmbcity.Items.Add("Kishtwar");
                cmbcity.Items.Add("Kulgam");

                cmbcity.Items.Add("Kupwara");
                cmbcity.Items.Add("Leh");
                cmbcity.Items.Add("Poonch");
                cmbcity.Items.Add("Pulwama");
                cmbcity.Items.Add("Rajouri");
                cmbcity.Items.Add("Ramban");
                cmbcity.Items.Add("Reasi");
                cmbcity.Items.Add("Samba");
                cmbcity.Items.Add("Shopian");
                cmbcity.Items.Add("Srinagar");
                cmbcity.Items.Add("Udhampur");
            }

            else if (cmbstate.Text == "Jharkhand")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Bokaro");
                cmbcity.Items.Add("Chaibasa(West Singhbhum)");
                cmbcity.Items.Add("Chatra");
                cmbcity.Items.Add("Dhanbad");
                cmbcity.Items.Add("Dumka");
                cmbcity.Items.Add("Garhwa");
                cmbcity.Items.Add("Giridih");
                cmbcity.Items.Add("Godda");
                cmbcity.Items.Add("Gumla");
                cmbcity.Items.Add("Hazaribagh ");
                cmbcity.Items.Add("Jamshedpur (East Singhbhum)");
                cmbcity.Items.Add("Jamtara");
                cmbcity.Items.Add("Kharsawan");
                cmbcity.Items.Add("Koderma");
                cmbcity.Items.Add("Latehar");
                cmbcity.Items.Add("Lohardaga");
                cmbcity.Items.Add("Pakur");
                cmbcity.Items.Add("Palamu");
                cmbcity.Items.Add("Ranchi");
                cmbcity.Items.Add("Sahebganj");
                cmbcity.Items.Add("Saraikela");
                cmbcity.Items.Add("Simdega");
            }
            else if (cmbstate.Text == "Karnataka")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Bagalkot");
                cmbcity.Items.Add("Bangalore Urban");
                cmbcity.Items.Add("Bangalore Rural");
                cmbcity.Items.Add("Bellary");
                cmbcity.Items.Add("Bidar");
                cmbcity.Items.Add("Bijapur");
                cmbcity.Items.Add("Chamarajanagar");
                cmbcity.Items.Add("Chikballapur");
                cmbcity.Items.Add("Chikmagalur");
                cmbcity.Items.Add("Chitradurga");
                cmbcity.Items.Add("Dakshina Kannada");
                cmbcity.Items.Add("Davanagere");
                cmbcity.Items.Add("Dharwad");
                cmbcity.Items.Add("Gadag");
                cmbcity.Items.Add("Gulbarga");
                cmbcity.Items.Add("Hassan");
                cmbcity.Items.Add("Haveri");
                cmbcity.Items.Add("Kodagu");
                cmbcity.Items.Add("Kolar");
                cmbcity.Items.Add("Koppal");
                cmbcity.Items.Add("Mandya");
                cmbcity.Items.Add("Mysore");
                cmbcity.Items.Add("Raichur");
                cmbcity.Items.Add("Ramanagara");
                cmbcity.Items.Add("Shimoga");
                cmbcity.Items.Add("Tumkur");
                cmbcity.Items.Add("Udupi");
                cmbcity.Items.Add("Uttara Kannada");
                cmbcity.Items.Add("Yadgir");
            }
            else if (cmbstate.Text == "Kerala")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Alappuzha");
                cmbcity.Items.Add("Eranakulam");
                cmbcity.Items.Add("Idukki");
                cmbcity.Items.Add("Kannur");
                cmbcity.Items.Add("Kasargod");
                cmbcity.Items.Add("Kollam");
                cmbcity.Items.Add("Kottayam");
                cmbcity.Items.Add("Kozhikode");
                cmbcity.Items.Add("Mallapuram");
                cmbcity.Items.Add("Palakkad");
                cmbcity.Items.Add("Pathanamthitta");
                cmbcity.Items.Add("Thiruvananthapuram");
                cmbcity.Items.Add("Thrissur");
                cmbcity.Items.Add("Wayanad");

            }
            else if (cmbstate.Text == "Madhya Pradesh")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Alirajpur");
                cmbcity.Items.Add("Anuppur");
                cmbcity.Items.Add("Ashoknagar");
                cmbcity.Items.Add("Balaghat");
                cmbcity.Items.Add("Barwani");
                cmbcity.Items.Add("Betul");
                cmbcity.Items.Add("Bhind");
                cmbcity.Items.Add("Bhopal ");
                cmbcity.Items.Add("Burhanpur");
                cmbcity.Items.Add("Chhatarpur");
                cmbcity.Items.Add("Chhindwara");
                cmbcity.Items.Add("Damoh");
                cmbcity.Items.Add("Datia");
                //    cmbcity.Items.Add("Kamrup");
                cmbcity.Items.Add("Dewas");
                cmbcity.Items.Add("Dhar");
                cmbcity.Items.Add("Dindori");
                cmbcity.Items.Add("Guna");

                cmbcity.Items.Add("Gwalior");
                cmbcity.Items.Add("Harda");
                cmbcity.Items.Add("Hoshangabad");
                cmbcity.Items.Add("Indore");

                cmbcity.Items.Add("Jabalpur");
                cmbcity.Items.Add("Jhabua");
                cmbcity.Items.Add("Katni");
                cmbcity.Items.Add("Khandwa");
                cmbcity.Items.Add("Khargone");
                cmbcity.Items.Add("Mandla");
                cmbcity.Items.Add("Mandsaur");
                cmbcity.Items.Add("Morena");
                cmbcity.Items.Add("Narsinghpur");
                cmbcity.Items.Add("Neemuch");
                cmbcity.Items.Add("Panna");
                cmbcity.Items.Add("Raisen");
                cmbcity.Items.Add("Rajgarh");
                cmbcity.Items.Add("Ratlam");
                cmbcity.Items.Add("Rewa");
                cmbcity.Items.Add("Sagar");
                cmbcity.Items.Add("Satna");
                cmbcity.Items.Add("Sehore");
                cmbcity.Items.Add("Seoni");
                cmbcity.Items.Add("Singrauli");

                cmbcity.Items.Add("Shahdol");
                cmbcity.Items.Add("Shajapur");
                cmbcity.Items.Add("Sheopur");
                cmbcity.Items.Add("Shivpuri");

                cmbcity.Items.Add("Sidhi");
                cmbcity.Items.Add("Tikamgarh");
                cmbcity.Items.Add("Ujjain");
                cmbcity.Items.Add("Umaria");
                cmbcity.Items.Add("Vidisha");
            }
            else if (cmbstate.Text == "Maharashtra")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Ahmednagar");
                cmbcity.Items.Add("Akola");
                cmbcity.Items.Add("Amravati");
                cmbcity.Items.Add("Aurangabad");
                cmbcity.Items.Add("Beed");
                cmbcity.Items.Add("Bhandara");
                cmbcity.Items.Add("Buldhana");
                cmbcity.Items.Add("Chandrapur");
                cmbcity.Items.Add("Dhule");
                cmbcity.Items.Add("Gadchiroli");
                cmbcity.Items.Add("Gondia");
                cmbcity.Items.Add("Hingoli");
                cmbcity.Items.Add("Jalgaon");
                cmbcity.Items.Add("Jalna");
                cmbcity.Items.Add("Kolhapur");
                cmbcity.Items.Add("Latur");
                cmbcity.Items.Add("Mumbai Surburban");
                cmbcity.Items.Add("Nagpur");

                cmbcity.Items.Add("Nanded");
                cmbcity.Items.Add("Nashik");
                cmbcity.Items.Add("Nundarbar");
                cmbcity.Items.Add("Osmanabad");
                cmbcity.Items.Add("Parbhani");
                cmbcity.Items.Add("Pune");
                cmbcity.Items.Add("Raigarh");
                cmbcity.Items.Add("Ratnagiri");
                cmbcity.Items.Add("Sangli");
                cmbcity.Items.Add("Satara");
                cmbcity.Items.Add("Sindhudurg");
                cmbcity.Items.Add("Solapur");
                cmbcity.Items.Add("Thane");
                cmbcity.Items.Add("Wardha");
                cmbcity.Items.Add("Washim");
                cmbcity.Items.Add("Yavatmal");
            }
            else if (cmbstate.Text == "Manipur")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Bishnupur");
                cmbcity.Items.Add("Chandel");
                cmbcity.Items.Add("Churachandpur");
                cmbcity.Items.Add("Imphal East");
                cmbcity.Items.Add("Imphal West");
                cmbcity.Items.Add("Senapati");
                cmbcity.Items.Add("Tamenglong");
                cmbcity.Items.Add("Thoubal");
                cmbcity.Items.Add("Ukhrul");



            }
            else if (cmbstate.Text == "Meghalaya")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("East Garo Hills / North Garo Hills");
                cmbcity.Items.Add("East Khasi Hills");
                cmbcity.Items.Add("Jaintia Hills / East Jaintia Hills");
                cmbcity.Items.Add("Ri-Bhoi");
                cmbcity.Items.Add("South Garo Hills");
                cmbcity.Items.Add("West Garo Hills / South West Garo Hills");
                cmbcity.Items.Add("West Khasi Hills / South West Khasi Hills");




            }
            else if (cmbstate.Text == "Mizoram")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Aizawl");
                cmbcity.Items.Add("Champhai");

                cmbcity.Items.Add("Kolasib");
                cmbcity.Items.Add("Lawngtlai");
                cmbcity.Items.Add("Lunglei");
                cmbcity.Items.Add("Mamit");
                cmbcity.Items.Add("Saiha");

                cmbcity.Items.Add("Serchhip");

            }

            else if (cmbstate.Text == "Nagaland")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Dimapur");
                cmbcity.Items.Add("Kiphire");

                cmbcity.Items.Add("Kohima");
                cmbcity.Items.Add("Longleng");
                cmbcity.Items.Add("Mokokchung");
                cmbcity.Items.Add("Mon");
                cmbcity.Items.Add("Peren");

                cmbcity.Items.Add("Phek");
                cmbcity.Items.Add("Tuensang");
                cmbcity.Items.Add("Wokha");

                cmbcity.Items.Add("Zunheboto");

            }
            else if (cmbstate.Text == "Orissa")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Angul");
                cmbcity.Items.Add("Balangir");

                cmbcity.Items.Add("Balasore");
                cmbcity.Items.Add("Bargarh");
                cmbcity.Items.Add("Bhadrak");
                cmbcity.Items.Add("Boudh (Bauda)");
                cmbcity.Items.Add("Cuttack");

                cmbcity.Items.Add("Debagarh (Deogarh)");
                cmbcity.Items.Add("Dhenkanal");
                cmbcity.Items.Add("Gajapati");

                cmbcity.Items.Add("Ganjam");

                cmbcity.Items.Add("Jagatsinghpur");

                cmbcity.Items.Add("Jajapur (Jajpur)");
                cmbcity.Items.Add("Jharsuguda");
                cmbcity.Items.Add("Kalahandi");

                cmbcity.Items.Add("Kandhamal");

                cmbcity.Items.Add("Kendrapara");

                cmbcity.Items.Add("Kendujhar (Keonjhar)");
                cmbcity.Items.Add("Khordha");
                cmbcity.Items.Add("Koraput");

                cmbcity.Items.Add("Malkangiri");

                cmbcity.Items.Add("Mayurbhanj");
                cmbcity.Items.Add("Nabarangpur");
                cmbcity.Items.Add("Nayagarh");

                cmbcity.Items.Add("Nuapada");
                cmbcity.Items.Add("Puri");
                cmbcity.Items.Add("Rayagada");
                cmbcity.Items.Add("Sambalpur");

                cmbcity.Items.Add("Subarnapur");
                cmbcity.Items.Add("Sundergarh");

            }


            else if (cmbstate.Text == "Punjab")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Amritsar");
                cmbcity.Items.Add("Barnala");

                cmbcity.Items.Add("Bathinda");
                cmbcity.Items.Add("Faridkot");
                cmbcity.Items.Add("Fatehgarh Sahib");
                cmbcity.Items.Add("Ferozepur");
                cmbcity.Items.Add("Fazilka");

                cmbcity.Items.Add("Gurdaspur");
                cmbcity.Items.Add("Hoshiarpur");
                cmbcity.Items.Add("Jalandhar");

                cmbcity.Items.Add("Kapurthala");

                cmbcity.Items.Add("Ludhiana");

                cmbcity.Items.Add("Mansa");
                cmbcity.Items.Add("Moga");
                cmbcity.Items.Add("Muktsar");

                cmbcity.Items.Add("Pathankot");

                cmbcity.Items.Add("Rupnagar");

                cmbcity.Items.Add("Mohali");
                cmbcity.Items.Add("Shahid Bhagat Singh Nagar (Nawanshahr)");
                cmbcity.Items.Add("Tarn Taran");

            }
            else if (cmbstate.Text == "Rajastan")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Ajmer");
                cmbcity.Items.Add("Alwar");

                cmbcity.Items.Add("Banswara");
                cmbcity.Items.Add("Baran");
                cmbcity.Items.Add("Barmer");
                cmbcity.Items.Add("Bharatpur");
                cmbcity.Items.Add("Bhilwara");

                cmbcity.Items.Add("Bikaner");
                cmbcity.Items.Add("Bundi");
                cmbcity.Items.Add("Chittorgarh");

                cmbcity.Items.Add("Churu");

                cmbcity.Items.Add("Dausa");

                cmbcity.Items.Add("Dholpur");
                cmbcity.Items.Add("Dungarpur");

                cmbcity.Items.Add("Hanumangarh");

                cmbcity.Items.Add("Jaipur");

                cmbcity.Items.Add("Jaisalmer");

                cmbcity.Items.Add("Jalor");
                cmbcity.Items.Add("Jhalawar");
                cmbcity.Items.Add("Jhunjhunu");

                cmbcity.Items.Add("Jodhpur");
                cmbcity.Items.Add("Karauli");
                cmbcity.Items.Add("Kota");

                cmbcity.Items.Add("Nagaur");
                cmbcity.Items.Add("Pali");
                cmbcity.Items.Add("Pratapgarh");

                cmbcity.Items.Add("Rajsamand");
                cmbcity.Items.Add("Sawai Madhopur");
                cmbcity.Items.Add("Sikar  Sirohi");
                cmbcity.Items.Add("Sri Ganganagar");
                cmbcity.Items.Add("Tonk");
                cmbcity.Items.Add("Udaipur");
                cmbcity.Items.Add("Rajasthan");
            }
            else if (cmbstate.Text == "Sikkim")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("East Sikkim");
                cmbcity.Items.Add("North Sikkim");

                cmbcity.Items.Add("South Sikkim");
                cmbcity.Items.Add("West Sikkim");
            }

            else if (cmbstate.Text == "Tamil Nadu")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Ariyalur");
                cmbcity.Items.Add("Chennai");

                cmbcity.Items.Add("Coimbatore");
                cmbcity.Items.Add("Cuddalore");
                cmbcity.Items.Add("Dharmapuri");
                cmbcity.Items.Add("Dindigul");

                cmbcity.Items.Add("Erode");
                cmbcity.Items.Add("Kanchipuram");
                cmbcity.Items.Add("Kanniyakumari");
                cmbcity.Items.Add("Karur");

                cmbcity.Items.Add("Krishnagiri");
                cmbcity.Items.Add("Madurai");
                cmbcity.Items.Add("Nagapattinam");
                cmbcity.Items.Add("Namakkal");

                cmbcity.Items.Add("Nilgiris");
                cmbcity.Items.Add("Perambalur");


                cmbcity.Items.Add("Pudukkottai");
                cmbcity.Items.Add("Ramanathapuram");
                cmbcity.Items.Add("Salem");
                cmbcity.Items.Add("Sivaganga");

                cmbcity.Items.Add("Thanjavur");
                cmbcity.Items.Add("Theni");
                cmbcity.Items.Add("Thoothukudi");
                cmbcity.Items.Add("Thiruvarur");

                cmbcity.Items.Add("Tirunelveli");
                cmbcity.Items.Add("Tiruchirappalli");

                cmbcity.Items.Add("Thiruvallur");
                cmbcity.Items.Add("Tiruppur");
                cmbcity.Items.Add("Tiruvannamalai");
                cmbcity.Items.Add(" Vellore");

                cmbcity.Items.Add("Villupuram");
                cmbcity.Items.Add("Virudhunagar");


            }

            else if (cmbstate.Text == "Tripura")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Dhalai");
                cmbcity.Items.Add("Gomati");
                cmbcity.Items.Add("Khowai");
                cmbcity.Items.Add("North Tripura");

                cmbcity.Items.Add("Sipahijala");

                cmbcity.Items.Add("South Tripura");

                cmbcity.Items.Add("Unakoti");


                cmbcity.Items.Add("West Tripura");
            }


            else if (cmbstate.Text == "Uttar Pradesh")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Agra");
                cmbcity.Items.Add("Aligarh");
                cmbcity.Items.Add("Allahabad");
                cmbcity.Items.Add("Auraiya");
                cmbcity.Items.Add("Azamgarh");
                cmbcity.Items.Add("Baghpat");
                cmbcity.Items.Add("Bahraich");
                cmbcity.Items.Add("Ballia");

                cmbcity.Items.Add("Balrampur");
                cmbcity.Items.Add("Banda");
                cmbcity.Items.Add("Barabanki");
                cmbcity.Items.Add("Bareilly");
                cmbcity.Items.Add("Basti");
                cmbcity.Items.Add("Bijnor");
                cmbcity.Items.Add("Budaun");
                cmbcity.Items.Add("Bulandshahar");
                cmbcity.Items.Add("Chandauli");
                cmbcity.Items.Add("Chitrakoot");
                cmbcity.Items.Add("Deoria");
                cmbcity.Items.Add("Etah ");
                cmbcity.Items.Add("Etawah");
                cmbcity.Items.Add("Faizabad");
                cmbcity.Items.Add("Farukkhabad");
                cmbcity.Items.Add("Fatehpur");

                cmbcity.Items.Add("Firozabad");
                cmbcity.Items.Add("Gautam Buddha Nagar");
                cmbcity.Items.Add("Ghaziabad");
                cmbcity.Items.Add("Ghazipur");
                cmbcity.Items.Add("Gonda");
                cmbcity.Items.Add("Gorakhpur");
                cmbcity.Items.Add("Hamirpur");
                cmbcity.Items.Add("Hardoi");
                cmbcity.Items.Add("Hathras");
                cmbcity.Items.Add("Jalaun");

                cmbcity.Items.Add("Jaunpur");
                cmbcity.Items.Add("Jhansi");
                cmbcity.Items.Add("Jyotiba Phoole Nagar");
                cmbcity.Items.Add("Kannauj");
                cmbcity.Items.Add("Kanpur Dehat");
                cmbcity.Items.Add("Kanpur Nagar");
                cmbcity.Items.Add("Kaushambi");
                cmbcity.Items.Add("Kushi Nagar (Padrauna)");
                cmbcity.Items.Add("Hathras");
                cmbcity.Items.Add(" Lakhimpur Kheri");
                cmbcity.Items.Add("Lalitpur");
                cmbcity.Items.Add("Lucknow");
                cmbcity.Items.Add("Maharajganj");
                cmbcity.Items.Add("Mahoba");
                cmbcity.Items.Add("Mainpuri");
                cmbcity.Items.Add("Mathura");
                cmbcity.Items.Add("MAU");
                cmbcity.Items.Add("Meerut");
                cmbcity.Items.Add("Mirzapur");
                cmbcity.Items.Add("Moradabad");

                cmbcity.Items.Add("Muzaffar Nagar");
                cmbcity.Items.Add("Pilibhit");
                cmbcity.Items.Add("Pratapgarh");

                cmbcity.Items.Add("Raebareli");
                cmbcity.Items.Add("Rampur");
                cmbcity.Items.Add("Saharanpur");
                cmbcity.Items.Add("Sant Kabir Nagar");
                cmbcity.Items.Add("Sant Ravidas Nagar");
                cmbcity.Items.Add("Shahjahanpur");

                cmbcity.Items.Add("Shravasti");
                cmbcity.Items.Add("Siddharth Nagar");
                cmbcity.Items.Add("Sitapur");
                cmbcity.Items.Add("Sonbhadra");

                cmbcity.Items.Add("Sultanpur");
                cmbcity.Items.Add("Unnao");
                cmbcity.Items.Add("Varanasi");
            }
            else if (cmbstate.Text == "Uttarakhand")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Almora");
                cmbcity.Items.Add("Bageshwar");
                cmbcity.Items.Add("Chamoli");
                cmbcity.Items.Add("Champawat");

                cmbcity.Items.Add("Dehradun");
                cmbcity.Items.Add("Haridwar");
                cmbcity.Items.Add("Nainital");
                cmbcity.Items.Add("Pauri Garhwal");

                cmbcity.Items.Add("Pithoragarh");
                cmbcity.Items.Add("Rudra Prayag");
                cmbcity.Items.Add("Udham Singh Nagar");
                cmbcity.Items.Add("Uttarkashi");
            }
            else if (cmbstate.Text == "West Bengal")
            {
                cmbcity.Items.Clear();

                cmbcity.Items.Add("Bankura");
                cmbcity.Items.Add("Bardhaman");
                cmbcity.Items.Add("Birbhum");
                cmbcity.Items.Add("Cooch Behar");

                cmbcity.Items.Add("Darjeeling");
                cmbcity.Items.Add("East Midnapore");


                cmbcity.Items.Add("Hooghly");
                cmbcity.Items.Add("Howrah");

                cmbcity.Items.Add("Maldah");
                cmbcity.Items.Add("Murshidabad");
                cmbcity.Items.Add("Nadia");
                cmbcity.Items.Add("North 24 Parganas");

                cmbcity.Items.Add("North Dinajpur");
                cmbcity.Items.Add("Purulia");
                cmbcity.Items.Add("South 24 Parganas");
                cmbcity.Items.Add("South Dinajpur");

                cmbcity.Items.Add("West Midnapore");
            }
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


    protected void rgbWidow_CheckedChanged(object sender, EventArgs e)
    {
        MStatusz.Visible = true;
        
    }
    protected void rgbDivorced_CheckedChanged(object sender, EventArgs e)
    {
        MStatusz.Visible = true;
        
    }
    protected void rgbAwaitingDivorce_CheckedChanged(object sender, EventArgs e)
    {
        MStatusz.Visible = true;
        
    }
    protected void rgbNeverMarrided_CheckedChanged(object sender, EventArgs e)
    {
        MStatusz.Visible = false;
        
    } 

    protected void ddlHeighFtIn_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlHeighFtIn.Text == "4ft 6in")
        {
            ddlHeightCms.Text = "137Cms";
        }
        else if (ddlHeighFtIn.Text == "4ft 7in")
        {
            ddlHeightCms.Text = "140Cms";
        }
        else if (ddlHeighFtIn.Text == "4ft 8in")
        {
            ddlHeightCms.Text = "142Cms";
        }
        else if (ddlHeighFtIn.Text == "4ft 9in")
        {
            ddlHeightCms.Text = "145Cms";
        }
        else if (ddlHeighFtIn.Text == "4ft 10in")
        {
            ddlHeightCms.Text = "147Cms";
        }
        else if (ddlHeighFtIn.Text == "4ft 11in")
        {
            ddlHeightCms.Text = "150Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft")
        {
            ddlHeightCms.Text = "152Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 1in")
        {
            ddlHeightCms.Text = "155Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 2in")
        {
            ddlHeightCms.Text = "157Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 3in")
        {
            ddlHeightCms.Text = "160Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 4in")
        {
            ddlHeightCms.Text = "162Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 5in")
        {
            ddlHeightCms.Text = "165Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 6in")
        {
            ddlHeightCms.Text = "167Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 7in")
        {
            ddlHeightCms.Text = "170Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 8in")
        {
            ddlHeightCms.Text = "172Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 9in")
        {
            ddlHeightCms.Text = "175Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 10in")
        {
            ddlHeightCms.Text = "177Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 11in")
        {
            ddlHeightCms.Text = "180Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft")
        {
            ddlHeightCms.Text = "183Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 1in")
        {
            ddlHeightCms.Text = "185Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 2in")
        {
            ddlHeightCms.Text = "188Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 3in")
        {
            ddlHeightCms.Text = "190Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 4in")
        {
            ddlHeightCms.Text = "193Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 5in")
        {
            ddlHeightCms.Text = "195Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 6in")
        {
            ddlHeightCms.Text = "198Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 7in")
        {
            ddlHeightCms.Text = "201Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 8in")
        {
            ddlHeightCms.Text = "203Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 9in")
        {
            ddlHeightCms.Text = "206Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 10in")
        {
            ddlHeightCms.Text = "208Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 11in")
        {
            ddlHeightCms.Text = "211Cms";
        }
        else if (ddlHeighFtIn.Text == "7ft")
        {
            ddlHeightCms.Text = "213Cms";
        }
        
    }
    protected void ddlHeightCms_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHeightCms.Text == "137Cms")
        {
            ddlHeighFtIn.Text = "4ft 6in";
        }
        else if (ddlHeightCms.Text == "138Cms")
        {
            ddlHeighFtIn.Text = "4ft 6in";
        }
        else if (ddlHeightCms.Text == "139Cms")
        {
            ddlHeighFtIn.Text = "4ft 7in";
        }
        else if (ddlHeightCms.Text == "140Cms")
        {
            ddlHeighFtIn.Text = "4ft 7in";
        }
        else if (ddlHeightCms.Text == "141Cms")
        {
            ddlHeighFtIn.Text = "4ft 8in";
        }
        else if (ddlHeightCms.Text == "142Cms")
        {
            ddlHeighFtIn.Text = "4ft 8in";
        }
        else if (ddlHeightCms.Text == "143Cms")
        {
            ddlHeighFtIn.Text = "4ft 8in";
        }
        else if (ddlHeightCms.Text == "144Cms")
        {
            ddlHeighFtIn.Text = "4ft 9in";
        }
        else if (ddlHeightCms.Text == "145Cms")
        {
            ddlHeighFtIn.Text = "4ft 9in";
        }
        else if (ddlHeightCms.Text == "146Cms")
        {
            ddlHeighFtIn.Text = "4ft 9in";
        }
        else if (ddlHeightCms.Text == "147Cms")
        {
            ddlHeighFtIn.Text = "4ft 10in";
        }
        else if (ddlHeightCms.Text == "148Cms")
        {
            ddlHeighFtIn.Text = "4ft 10in";
        }
        else if (ddlHeightCms.Text == "149Cms")
        {
            ddlHeighFtIn.Text = "4ft 11in";
        }
        else if (ddlHeightCms.Text == "150Cms")
        {
            ddlHeighFtIn.Text = "4ft 11in";
        }
        else if (ddlHeightCms.Text == "151Cms")
        {
            ddlHeighFtIn.Text = "4ft 11in";
        }
        else if (ddlHeightCms.Text == "152Cms")
        {
            ddlHeighFtIn.Text = "5ft";
        }
        else if (ddlHeightCms.Text == "153Cms")
        {
            ddlHeighFtIn.Text = "5ft";
        }
        else if (ddlHeightCms.Text == "154Cms")
        {
            ddlHeighFtIn.Text = "5ft 1in";
        }
        else if (ddlHeightCms.Text == "155Cms")
        {
            ddlHeighFtIn.Text = "5ft 1in";
        }
        else if (ddlHeightCms.Text == "156Cms")
        {
            ddlHeighFtIn.Text = "5ft 1in";
        }
        else if (ddlHeightCms.Text == "157Cms")
        {
            ddlHeighFtIn.Text = "5ft 2in";
        }
        else if (ddlHeightCms.Text == "158Cms")
        {
            ddlHeighFtIn.Text = "5ft 2in";
        }
        else if (ddlHeightCms.Text == "159Cms")
        {
            ddlHeighFtIn.Text = "5ft 3in";
        }
        else if (ddlHeightCms.Text == "160Cms")
        {
            ddlHeighFtIn.Text = "5ft 3in";
        }
        else if (ddlHeightCms.Text == "161Cms")
        {
            ddlHeighFtIn.Text = "5ft 3in";
        }
        else if (ddlHeightCms.Text == "162Cms")
        {
            ddlHeighFtIn.Text = "5ft 4in";
        }
        else if (ddlHeightCms.Text == "163Cms")
        {
            ddlHeighFtIn.Text = "5ft 4in";
        }
        else if (ddlHeightCms.Text == "164Cms")
        {
            ddlHeighFtIn.Text = "5ft 5in";
        }
        else if (ddlHeightCms.Text == "165Cms")
        {
            ddlHeighFtIn.Text = "5ft 5in";
        }
        else if (ddlHeightCms.Text == "166Cms")
        {
            ddlHeighFtIn.Text = "5ft 5in";
        }
        else if (ddlHeightCms.Text == "167Cms")
        {
            ddlHeighFtIn.Text = "5ft 6in";
        }
        else if (ddlHeightCms.Text == "168Cms")
        {
            ddlHeighFtIn.Text = "5ft 6in";
        }
        else if (ddlHeightCms.Text == "169Cms")
        {
            ddlHeighFtIn.Text = "5ft 6in";
        }
        else if (ddlHeightCms.Text == "170Cms")
        {
            ddlHeighFtIn.Text = "5ft 7in";
        }
        else if (ddlHeightCms.Text == "171Cms")
        {
            ddlHeighFtIn.Text = "5ft 7in";
        }
        else if (ddlHeightCms.Text == "172Cms")
        {
            ddlHeighFtIn.Text = "5ft 8in";
        }
        else if (ddlHeightCms.Text == "173Cms")
        {
            ddlHeighFtIn.Text = "5ft 8in";
        }
        else if (ddlHeightCms.Text == "174Cms")
        {
            ddlHeighFtIn.Text = "5ft 9in";
        }
        else if (ddlHeightCms.Text == "175Cms")
        {
            ddlHeighFtIn.Text = "5ft 9in";
        }
        else if (ddlHeightCms.Text == "176Cms")
        {
            ddlHeighFtIn.Text = "5ft 9in";
        }
        else if (ddlHeightCms.Text == "177Cms")
        {
            ddlHeighFtIn.Text = "5ft 10in";
        }
        else if (ddlHeightCms.Text == "178Cms")
        {
            ddlHeighFtIn.Text = "5ft 10in";
        }
        else if (ddlHeightCms.Text == "179Cms")
        {
            ddlHeighFtIn.Text = "5ft 10in";
        }
        else if (ddlHeightCms.Text == "180Cms")
        {
            ddlHeighFtIn.Text = "5ft 11in";
        }
        else if (ddlHeightCms.Text == "181Cms")
        {
            ddlHeighFtIn.Text = "5ft 11in";
        }
        else if (ddlHeightCms.Text == "182Cms")
        {
            ddlHeighFtIn.Text = "6ft";
        }
        else if (ddlHeightCms.Text == "183Cms")
        {
            ddlHeighFtIn.Text = "6ft";
        }
        else if (ddlHeightCms.Text == "184Cms")
        {
            ddlHeighFtIn.Text = "6ft";
        }
        else if (ddlHeightCms.Text == "185Cms")
        {
            ddlHeighFtIn.Text = "6ft 1in";
        }
        else if (ddlHeightCms.Text == "186Cms")
        {
            ddlHeighFtIn.Text = "6ft 1in";
        }
        else if (ddlHeightCms.Text == "187Cms")
        {
            ddlHeighFtIn.Text = "6ft 2in";
        }
        else if (ddlHeightCms.Text == "188Cms")
        {
            ddlHeighFtIn.Text = "6ft 2in";
        }
        else if (ddlHeightCms.Text == "189Cms")
        {
            ddlHeighFtIn.Text = "6ft 2in";
        }
        else if (ddlHeightCms.Text == "190Cms")
        {
            ddlHeighFtIn.Text = "6ft 3in";
        }
        else if (ddlHeightCms.Text == "190Cms")
        {
            ddlHeighFtIn.Text = "6ft 3in";
        }
        else if (ddlHeightCms.Text == "191Cms")
        {
            ddlHeighFtIn.Text = "6ft 3in";
        }
        else if (ddlHeightCms.Text == "192Cms")
        {
            ddlHeighFtIn.Text = "6ft 4in";
        }
        else if (ddlHeightCms.Text == "193Cms")
        {
            ddlHeighFtIn.Text = "6ft 4in";
        }
        else if (ddlHeightCms.Text == "194Cms")
        {
            ddlHeighFtIn.Text = "6ft 5in";
        }
        else if (ddlHeightCms.Text == "195Cms")
        {
            ddlHeighFtIn.Text = "6ft 5in";
        }
        else if (ddlHeightCms.Text == "196Cms")
        {
            ddlHeighFtIn.Text = "6ft 5in";
        }
        else if (ddlHeightCms.Text == "197Cms")
        {
            ddlHeighFtIn.Text = "6ft 6in";
        }
        else if (ddlHeightCms.Text == "198Cms")
        {
            ddlHeighFtIn.Text = "6ft 6in";
        }
        else if (ddlHeightCms.Text == "199Cms")
        {
            ddlHeighFtIn.Text = "6ft 6in";
        }
        else if (ddlHeightCms.Text == "200Cms")
        {
            ddlHeighFtIn.Text = "6ft 7in";
        }
        else if (ddlHeightCms.Text == "201Cms")
        {
            ddlHeighFtIn.Text = "6ft 7in";
        }
        else if (ddlHeightCms.Text == "202Cms")
        {
            ddlHeighFtIn.Text = "6ft 8in";
        }
        else if (ddlHeightCms.Text == "203Cms")
        {
            ddlHeighFtIn.Text = "6ft 8in";
        }
        else if (ddlHeightCms.Text == "204Cms")
        {
            ddlHeighFtIn.Text = "6ft 8in";
        }
        else if (ddlHeightCms.Text == "205Cms")
        {
            ddlHeighFtIn.Text = "6ft 9in";
        }
        else if (ddlHeightCms.Text == "206Cms")
        {
            ddlHeighFtIn.Text = "6ft 9in";
        }
        else if (ddlHeightCms.Text == "207Cms")
        {
            ddlHeighFtIn.Text = "6ft 9in";
        }
        else if (ddlHeightCms.Text == "208Cms")
        {
            ddlHeighFtIn.Text = "6ft 10in";
        }
        else if (ddlHeightCms.Text == "209Cms")
        {
            ddlHeighFtIn.Text = "6ft 10in";
        }
        else if (ddlHeightCms.Text == "210Cms")
        {
            ddlHeighFtIn.Text = "6ft 11in";
        }
        else if (ddlHeightCms.Text == "211Cms")
        {
            ddlHeighFtIn.Text = "6ft 11in";
        }
        else if (ddlHeightCms.Text == "212Cms")
        {
            ddlHeighFtIn.Text = "7ft";
        }
        else if (ddlHeightCms.Text == "213Cms")
        {
            ddlHeighFtIn.Text = "7ft";
        }
        
    }
    protected void ddlWeight_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string[] wt = ddlWeight.Text.Split('K');
            Double lbs = Convert.ToInt32(wt[0].ToString()) * 2.20462262185;
            string temp = Math.Ceiling(lbs).ToString();
            string temp1 = temp + "Lbs";
            ddlWeightLbs.Text = temp1;
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlWeightLbs_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string[] wt = ddlWeightLbs.Text.Split('L');
            Double lbs = Convert.ToInt32(wt[0].ToString()) * 0.45359237;
            string temp = Math.Ceiling(lbs).ToString();
            string temp1 = temp + "Kg";
            ddlWeight.Text = temp1;
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlReligion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReligion.Text == "Hindu")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
          
            ddlCaste.Items.Add("Ad Dharmi");
            ddlCaste.Items.Add("Adi Dravida");
            ddlCaste.Items.Add("Adi Karnataka");
            ddlCaste.Items.Add("Agarwal");
            ddlCaste.Items.Add("Agnikula Kshatriya");
            ddlCaste.Items.Add("Agri");
            ddlCaste.Items.Add("Ahir Shimpi");
            ddlCaste.Items.Add("Ahom");
            ddlCaste.Items.Add("Ambalavasi");
            ddlCaste.Items.Add("Arekatica");
            ddlCaste.Items.Add("Arora");
            ddlCaste.Items.Add("Arunthathiyar");
            ddlCaste.Items.Add("AryaVysya");
            ddlCaste.Items.Add("Ayyaraka");
            ddlCaste.Items.Add("Badaga");
            ddlCaste.Items.Add("Bagdi");
            ddlCaste.Items.Add("Baidya");
            ddlCaste.Items.Add("Baishnab");
            ddlCaste.Items.Add("Baishya");
            ddlCaste.Items.Add("Bajantri");
            ddlCaste.Items.Add("Balija");
            ddlCaste.Items.Add("Banayat Oriya");
            ddlCaste.Items.Add("Banik");
            ddlCaste.Items.Add("Baniya");
            ddlCaste.Items.Add("Baniya-Bania");
            ddlCaste.Items.Add("Baniya-Kumuti");
            ddlCaste.Items.Add("Banjara");
            ddlCaste.Items.Add("Barai");
            ddlCaste.Items.Add("Bari");
            ddlCaste.Items.Add("Baria");
            ddlCaste.Items.Add("Barujibi");
            ddlCaste.Items.Add("Besta");
            ddlCaste.Items.Add("Bhandari");
            ddlCaste.Items.Add("Bhatia");
            ddlCaste.Items.Add("Bhatraju");
            ddlCaste.Items.Add("Bhavasar Kshatriya");
            ddlCaste.Items.Add("Bhoi");
            ddlCaste.Items.Add("Bhovi");
            ddlCaste.Items.Add("Bhoyar");
            ddlCaste.Items.Add("Billava");
            ddlCaste.Items.Add("Bishnoi/Vishnoi");
            ddlCaste.Items.Add("Bondili");
            ddlCaste.Items.Add("Boyar");
            ddlCaste.Items.Add("Brahmbatt");
            ddlCaste.Items.Add("Brahmin-Anavil");
            ddlCaste.Items.Add("Brahmin-Audichya");
            ddlCaste.Items.Add("Brahmin-Barendra");
            ddlCaste.Items.Add("Brahmin-Bhatt");
            ddlCaste.Items.Add("Brahmin-Bhumihar");
            ddlCaste.Items.Add("Brahmin-Daivadnya");
            ddlCaste.Items.Add("Brahmin-Danua");
            ddlCaste.Items.Add("Brahmin-Deshastha");
            ddlCaste.Items.Add("Brahmin-Dhiman");
            ddlCaste.Items.Add("Brahmin-Dravida");
            ddlCaste.Items.Add("Brahmin-Embrandiri");
            ddlCaste.Items.Add("Brahmin-Garhwali");
            ddlCaste.Items.Add("Brahmin-Gaur");
            ddlCaste.Items.Add("Brahmin-Goswami/Gosavi");
            ddlCaste.Items.Add("Brahmin-GujarGaur");
            ddlCaste.Items.Add("Brahmin-Gurukkal");
            ddlCaste.Items.Add("Brahmin-Halua");
            ddlCaste.Items.Add("Brahmin-Havyaka");
            ddlCaste.Items.Add("Brahmin-Hoysala");
            ddlCaste.Items.Add("Brahmin-Iyengar");
            ddlCaste.Items.Add("Brahmin-Iyer");
            ddlCaste.Items.Add("Brahmin-Jangid");
            ddlCaste.Items.Add("Brahmin-Jhadua");
            ddlCaste.Items.Add("Brahmin-Jyotish");
            ddlCaste.Items.Add("Brahmin-Kanyakubj");
            ddlCaste.Items.Add("Brahmin-Karhade");
            ddlCaste.Items.Add("Brahmin-Khandelwal");
            ddlCaste.Items.Add("Brahmin-Kokanastha");
            ddlCaste.Items.Add("Brahmin-Kota");
            ddlCaste.Items.Add("Brahmin-Kulin");
            ddlCaste.Items.Add("Brahmin-Kumaoni");
            ddlCaste.Items.Add("Brahmin-Madhwa");
            ddlCaste.Items.Add("Brahmin-Maithil");
            ddlCaste.Items.Add("Brahmin-Modh");
            ddlCaste.Items.Add("Brahmin-Mohyal");
            ddlCaste.Items.Add("Brahmin-Nagar");
            ddlCaste.Items.Add("Brahmin-Namboodiri");
            ddlCaste.Items.Add("Brahmin-Narmadiya");
            ddlCaste.Items.Add("Brahmin-Niyogi");
            ddlCaste.Items.Add("Brahmin-Others");
            ddlCaste.Items.Add("Brahmin-Paliwal");
            ddlCaste.Items.Add("Brahmin-Panda");
            ddlCaste.Items.Add("Brahmin-Pandit");
            ddlCaste.Items.Add("Brahmin-Pareek");
            ddlCaste.Items.Add("Brahmin-Pushkarna");
            ddlCaste.Items.Add("Brahmin-Rarhi");
            ddlCaste.Items.Add("Brahmin-Rigvedi");
            ddlCaste.Items.Add("Brahmin-Rudraj");
            ddlCaste.Items.Add("Brahmin-Sakaldwipi");
            ddlCaste.Items.Add("Brahmin-Sanadya");
            ddlCaste.Items.Add("Brahmin-Sanketi");
            ddlCaste.Items.Add("Brahmin-Saraswat");
            ddlCaste.Items.Add("Brahmin-Saryuparin");
            ddlCaste.Items.Add("Brahmin-Shivhalli");
            ddlCaste.Items.Add("Brahmin-Shrimali");
            ddlCaste.Items.Add("Brahmin-Sikhwal");
            ddlCaste.Items.Add("Brahmin-Smartha");
            ddlCaste.Items.Add("Brahmin-SriVaishnava");
            ddlCaste.Items.Add("Brahmin-Stanika");
            ddlCaste.Items.Add("Brahmin-Tyagi");
            ddlCaste.Items.Add("Brahmin-Vaidiki");
            ddlCaste.Items.Add("Brahmin-Vaikhanasa");
            ddlCaste.Items.Add("Brahmin-Velanadu");
            ddlCaste.Items.Add("Brahmin-Vyas");
            ddlCaste.Items.Add("BrajasthaMaithil");
            ddlCaste.Items.Add("BrajasthaMaithil");
            ddlCaste.Items.Add("Bunt(Shetty)");
            ddlCaste.Items.Add("CKP");
            ddlCaste.Items.Add("Chalawadi and Holeya");
            ddlCaste.Items.Add("Chambhar");
            ddlCaste.Items.Add("Chandravanshi Kahar");
            ddlCaste.Items.Add("Chasa");
            ddlCaste.Items.Add("Chattada Sri Vaishnava");
            ddlCaste.Items.Add("Chaudary");
            ddlCaste.Items.Add("Chaurasia");
            ddlCaste.Items.Add("Chennadasar");
            ddlCaste.Items.Add("Chettiar");
            ddlCaste.Items.Add("Chhetri");
            ddlCaste.Items.Add("Chippolu(Mera)");
            ddlCaste.Items.Add("Coorgi");
            ddlCaste.Items.Add("Devadiga");
            ddlCaste.Items.Add("Devandra Kula Vellalar");
            ddlCaste.Items.Add("Devang Koshthi");
            ddlCaste.Items.Add("Devanga");
            ddlCaste.Items.Add("Devar/Thevar/Mukkulathor");
            ddlCaste.Items.Add("Devrukhe Brahmin");
            ddlCaste.Items.Add("Dhangar");
            ddlCaste.Items.Add("Dheevara");
            ddlCaste.Items.Add("Dhiman");
            ddlCaste.Items.Add("Dhoba");
            ddlCaste.Items.Add("Dhobi");
            ddlCaste.Items.Add("Dhor/Kakkayya");
            ddlCaste.Items.Add("Dommala");
            ddlCaste.Items.Add("Dumal");
            ddlCaste.Items.Add("Dusadh(Paswan)");
            ddlCaste.Items.Add("Ediga");
            ddlCaste.Items.Add("Ezhava");
            ddlCaste.Items.Add("Ezhuthachan");
            ddlCaste.Items.Add("Gabit");
            ddlCaste.Items.Add("Ganda");
            ddlCaste.Items.Add("Gandla");
            ddlCaste.Items.Add("Ganiga");
            ddlCaste.Items.Add("Garhwali");
            ddlCaste.Items.Add("Gatti");
            ddlCaste.Items.Add("Gavara");
            ddlCaste.Items.Add("Gawali");
            ddlCaste.Items.Add("Ghisadi");
            ddlCaste.Items.Add("Ghumar");
            ddlCaste.Items.Add("Goala");
            ddlCaste.Items.Add("Goan");
            ddlCaste.Items.Add("Gomantak");
            ddlCaste.Items.Add("Gondhali");
            ddlCaste.Items.Add("Goud");
            ddlCaste.Items.Add("Gounder");
            ddlCaste.Items.Add("Gowda");
            ddlCaste.Items.Add("Gramani");
            ddlCaste.Items.Add("Gudia");
            ddlCaste.Items.Add("Gujjar");
            ddlCaste.Items.Add("Gupta");
            ddlCaste.Items.Add("Guptan");
            ddlCaste.Items.Add("Gurav");
            ddlCaste.Items.Add("Gurjar");
            ddlCaste.Items.Add("Halba Koshti");
            ddlCaste.Items.Add("Helava");
            ddlCaste.Items.Add("Hugar(Jeer)");
            ddlCaste.Items.Add("Intercaste");
            ddlCaste.Items.Add("Irani");
            ddlCaste.Items.Add("Jaalari");
            ddlCaste.Items.Add("Jaiswal");
            ddlCaste.Items.Add("Jandra");
            ddlCaste.Items.Add("Jangam");
            ddlCaste.Items.Add("Jangra-Brahmin");
            ddlCaste.Items.Add("Jat");
            ddlCaste.Items.Add("Jatav");
            ddlCaste.Items.Add("Jetty/Malla");
            ddlCaste.Items.Add("Jijhotia Brahmin");
            ddlCaste.Items.Add("Jogi(Nath)");
            ddlCaste.Items.Add("Kachara");
            ddlCaste.Items.Add("Kadava Patel");
            ddlCaste.Items.Add("Kahar");
            ddlCaste.Items.Add("Kaibarta");
            ddlCaste.Items.Add("Kalal");
            ddlCaste.Items.Add("Kalanji");
            ddlCaste.Items.Add("Kalar");
            ddlCaste.Items.Add("Kalinga");
            ddlCaste.Items.Add("Kalinga Vysya");
            ddlCaste.Items.Add("Kalita");
            ddlCaste.Items.Add("Kalwar");
            ddlCaste.Items.Add("Kamboj");
            ddlCaste.Items.Add("Kamma");
            ddlCaste.Items.Add("Kansari");
            ddlCaste.Items.Add("Kapu");
            ddlCaste.Items.Add("Karana");
            ddlCaste.Items.Add("Karmakar");
            ddlCaste.Items.Add("Karuneegar");
            ddlCaste.Items.Add("Kasar");
            ddlCaste.Items.Add("Kashyap");
            ddlCaste.Items.Add("Katiya");
            ddlCaste.Items.Add("Kavuthiyya/Ezhavathy");
            ddlCaste.Items.Add("Kayastha");
            ddlCaste.Items.Add("Khandayat");
            ddlCaste.Items.Add("Khandelwal");
            ddlCaste.Items.Add("Kharwa");
            ddlCaste.Items.Add("Kharwar");
            ddlCaste.Items.Add("Khatri");
            ddlCaste.Items.Add("Kirar");
            ddlCaste.Items.Add("Kokanastha Maratha");
            ddlCaste.Items.Add("Koli");
            ddlCaste.Items.Add("KoliMahadev");
            ddlCaste.Items.Add("KoliPatel");
            ddlCaste.Items.Add("Kongu Vellala Gounder");
            ddlCaste.Items.Add("Konkani");
            ddlCaste.Items.Add("Korama");
            ddlCaste.Items.Add("Kori");
            ddlCaste.Items.Add("Kosthi");
            ddlCaste.Items.Add("Krishnavaka");
            ddlCaste.Items.Add("Kshatriya");
            ddlCaste.Items.Add("Kudumbi");
            ddlCaste.Items.Add("Kulal");
            ddlCaste.Items.Add("Kulalar");
            ddlCaste.Items.Add("Kulita");
            ddlCaste.Items.Add("Kumawat");
            ddlCaste.Items.Add("Kumbhakar");
            ddlCaste.Items.Add("Kumbhar");
            ddlCaste.Items.Add("Kumhar");

            ddlCaste.Items.Add("Kunbi");
            ddlCaste.Items.Add("Kuravan");
            ddlCaste.Items.Add("Kurmi/Kurmi Kshatriya");
            ddlCaste.Items.Add("Kuruba");
            ddlCaste.Items.Add("KuruhinaShetty");
            ddlCaste.Items.Add("Kurumbar");
            ddlCaste.Items.Add("Kushwaha(Koiri)");
            ddlCaste.Items.Add("Kutchi");
            ddlCaste.Items.Add("Lambadi");
            ddlCaste.Items.Add("Levapatel");
            ddlCaste.Items.Add("Levapatil");
            ddlCaste.Items.Add("Lingayath");
            ddlCaste.Items.Add("LodhiRajput");
            ddlCaste.Items.Add("Lohana");
            ddlCaste.Items.Add("Lohar");
            ddlCaste.Items.Add("Loniya");
            ddlCaste.Items.Add("Lubana");
            ddlCaste.Items.Add("Madiga");
            ddlCaste.Items.Add("Mahajan");
            ddlCaste.Items.Add("Mahar");
            ddlCaste.Items.Add("Mahendra");
            ddlCaste.Items.Add("Maheshwari");
            ddlCaste.Items.Add("Mahishya");
            ddlCaste.Items.Add("Majabi");
            ddlCaste.Items.Add("Mala");
            ddlCaste.Items.Add("Mali");
            ddlCaste.Items.Add("Mallah");
            ddlCaste.Items.Add("Malviya Brahmin");
            ddlCaste.Items.Add("Mangalorean");
            ddlCaste.Items.Add("Manipuri");
            ddlCaste.Items.Add("Mapila");
            ddlCaste.Items.Add("Maratha");
            ddlCaste.Items.Add("Maruthuvar");
            ddlCaste.Items.Add("Matang");
            ddlCaste.Items.Add("Mathur");
            ddlCaste.Items.Add("Maurya/Shakya");
            ddlCaste.Items.Add("Meena");
            ddlCaste.Items.Add("Meenavar");
            ddlCaste.Items.Add("Mehra");
            ddlCaste.Items.Add("MeruDarji");
            ddlCaste.Items.Add("Mochi");
            ddlCaste.Items.Add("Modak");
            ddlCaste.Items.Add("Mogaveera");
            ddlCaste.Items.Add("Mudaliyar");
            ddlCaste.Items.Add("Mudiraj");
            ddlCaste.Items.Add("Munnuru Kapu");
            ddlCaste.Items.Add("Muthuraja");
            ddlCaste.Items.Add("Naagavamsam");
            ddlCaste.Items.Add("Nadar");
            ddlCaste.Items.Add("Nagaralu");
            ddlCaste.Items.Add("Nai");
            ddlCaste.Items.Add("Naicker");
            ddlCaste.Items.Add("Naidu");
            ddlCaste.Items.Add("Naik");
            ddlCaste.Items.Add("Nair");
            ddlCaste.Items.Add("Namasudra/Namassej");
            ddlCaste.Items.Add("Nambiar");
            ddlCaste.Items.Add("Napit");
            ddlCaste.Items.Add("Nayaka");
            ddlCaste.Items.Add("Neeli");
            ddlCaste.Items.Add("Nepali");
            ddlCaste.Items.Add("Nhavi");
            ddlCaste.Items.Add("Oswal");
            ddlCaste.Items.Add("Otari");
            ddlCaste.Items.Add("Padmasali");
            ddlCaste.Items.Add("Pal");
            ddlCaste.Items.Add("Panchal");
            ddlCaste.Items.Add("Pandaram");
            ddlCaste.Items.Add("Panicker");
            ddlCaste.Items.Add("Parkava Kulam");
            ddlCaste.Items.Add("Parsi");
            ddlCaste.Items.Add("Partraj");
            ddlCaste.Items.Add("Pasi");
            ddlCaste.Items.Add("Patel");
            ddlCaste.Items.Add("Pathare Prabhu");
            ddlCaste.Items.Add("Patnaick/Sistakaranam");
            ddlCaste.Items.Add("Patra");
            ddlCaste.Items.Add("Perika");
            ddlCaste.Items.Add("Pillai");
            ddlCaste.Items.Add("Poosala");
            ddlCaste.Items.Add("Porwal");
            ddlCaste.Items.Add("Prajapati");
            ddlCaste.Items.Add("Raigar");
            ddlCaste.Items.Add("Rajaka");
            ddlCaste.Items.Add("Rajastani");
            ddlCaste.Items.Add("Rajbhar");
            ddlCaste.Items.Add("Rajbonshi");
            ddlCaste.Items.Add("Rajpurohit");
            ddlCaste.Items.Add("Rajput");
            ddlCaste.Items.Add("Ramanandi");
            ddlCaste.Items.Add("Ramdasia");
            ddlCaste.Items.Add("Ramgariah");
            ddlCaste.Items.Add("Ramoshi");
            ddlCaste.Items.Add("Ravidasia");
            ddlCaste.Items.Add("Rawat");
            ddlCaste.Items.Add("Reddy");
            ddlCaste.Items.Add("Relli");
            ddlCaste.Items.Add("Ror");
            ddlCaste.Items.Add("SC");
            ddlCaste.Items.Add("SKP");
            ddlCaste.Items.Add("ST");
            ddlCaste.Items.Add("Sadgope");
            ddlCaste.Items.Add("Sagara(Uppara)");
            ddlCaste.Items.Add("Saha");
            ddlCaste.Items.Add("Sahu");
            ddlCaste.Items.Add("Saini");
            ddlCaste.Items.Add("Saliya");
            ddlCaste.Items.Add("Sathwara");
            ddlCaste.Items.Add("Savji");
            ddlCaste.Items.Add("Senai Thalaivar");
            ddlCaste.Items.Add("Senguntha Mudaliyar");
            ddlCaste.Items.Add("Settibalija");
            ddlCaste.Items.Add("Shimpi/Namdev");
            ddlCaste.Items.Add("Sindhi");
            ddlCaste.Items.Add("Sindhi-Amil");
            ddlCaste.Items.Add("Sindhi-Baibhand");
            ddlCaste.Items.Add("Sindhi-Bhanusali");
            ddlCaste.Items.Add("Sindhi-Bhatia");
            ddlCaste.Items.Add("Sindhi-Chhapru");
            ddlCaste.Items.Add("Sindhi-Dadu");
            ddlCaste.Items.Add("Sindhi-Hyderabadi");
            ddlCaste.Items.Add("Sindhi-Larai");
            ddlCaste.Items.Add("Sindhi-Larkana");
            ddlCaste.Items.Add("Sindhi-Lohana");
            ddlCaste.Items.Add("Sindhi-Rohiri");
            ddlCaste.Items.Add("Sindhi-Sahiti");
            ddlCaste.Items.Add("Sindhi-Sakkhar");
            ddlCaste.Items.Add("Sindhi-Sehwani");
            ddlCaste.Items.Add("Sindhi-Shikarpuri");
            ddlCaste.Items.Add("Sindhi-Thatai");
            ddlCaste.Items.Add("Sonar");
            ddlCaste.Items.Add("Soni");
            ddlCaste.Items.Add("Sourashtra");
            ddlCaste.Items.Add("Sozhiya Vellalar");
            ddlCaste.Items.Add("Srisayana");
            ddlCaste.Items.Add("Sugali(Naika)");
            ddlCaste.Items.Add("Sunari");
            ddlCaste.Items.Add("Sundhi");
            ddlCaste.Items.Add("Surya Balija");
            ddlCaste.Items.Add("Suthar");
            ddlCaste.Items.Add("Swakula Sali");
            ddlCaste.Items.Add("Tamboli");
            ddlCaste.Items.Add("Tanti");
            ddlCaste.Items.Add("Tantubai");
            ddlCaste.Items.Add("Telaga");
            ddlCaste.Items.Add("Teli");
            ddlCaste.Items.Add("Thakkar");
            ddlCaste.Items.Add("Thakore");
            ddlCaste.Items.Add("Thakur");
            ddlCaste.Items.Add("Thigala");
            ddlCaste.Items.Add("Thiyya");
            ddlCaste.Items.Add("Tili");
            ddlCaste.Items.Add("Togata");
            ddlCaste.Items.Add("Tonk Kshatriya");
            ddlCaste.Items.Add("Turupu Kapu");
            ddlCaste.Items.Add("Urali Gounder");
            ddlCaste.Items.Add("Urs");
            ddlCaste.Items.Add("VadaBalija");
            ddlCaste.Items.Add("Vaddera");
            ddlCaste.Items.Add("Vaish");
            ddlCaste.Items.Add("Vaishnav");
            ddlCaste.Items.Add("Vaishnava");
            ddlCaste.Items.Add("Vaishya");
            ddlCaste.Items.Add("Vaishya Vani");
            ddlCaste.Items.Add("Valluvan");
            ddlCaste.Items.Add("Valmiki");
            ddlCaste.Items.Add("Vania");
            ddlCaste.Items.Add("Vanika Vyshya");
            ddlCaste.Items.Add("Vaniya");
            ddlCaste.Items.Add("Vanjara");
            ddlCaste.Items.Add("Vanjari");
            ddlCaste.Items.Add("Vankar");
            ddlCaste.Items.Add("Vannar");
            ddlCaste.Items.Add("Vannia Kula Kshatriyar");
            ddlCaste.Items.Add("Variar");
            ddlCaste.Items.Add("Varshney");
            ddlCaste.Items.Add("Veera Saivam");
            ddlCaste.Items.Add("Velaan");
            ddlCaste.Items.Add("Velama");
            ddlCaste.Items.Add("Vellalar");
            ddlCaste.Items.Add("Veluthedathu Nair");
            ddlCaste.Items.Add("Vettuva Gounder");
            ddlCaste.Items.Add("Vilakkithala Nair");
            ddlCaste.Items.Add("Vishwakarma");
            ddlCaste.Items.Add("Viswabrahmin");
            ddlCaste.Items.Add("Vokkaliga");
            ddlCaste.Items.Add("Vysya");
            ddlCaste.Items.Add("Yadav");
            ddlCaste.Items.Add("Yellapu");


        }
        else if (ddlReligion.Text == "Muslim")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
          
            ddlCaste.Items.Add("Shia");
            ddlCaste.Items.Add("Sunni");
            ddlCaste.Items.Add("Muslim-Other");

        }
        else if (ddlReligion.Text == "Christian")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
          
            ddlCaste.Items.Add("Catholic");
            ddlCaste.Items.Add("Orthodox");
            ddlCaste.Items.Add("Protestant");
            ddlCaste.Items.Add("Christian-Others");
        }
        else if (ddlReligion.Text == "Sikh")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
          
            ddlCaste.Items.Add("Sikh-Alhuwalia");
            ddlCaste.Items.Add("Sikh-Arora");
            ddlCaste.Items.Add("Sikh-Bhatia");
            ddlCaste.Items.Add("Sikh-Gursikh");
            ddlCaste.Items.Add("Sikh-Jat");
            ddlCaste.Items.Add("Sikh-Kamboj");
            ddlCaste.Items.Add("Sikh-Kesadhari");
            ddlCaste.Items.Add("Sikh-Khashap Rajpoot");
            ddlCaste.Items.Add("Sikh-Khatri");
            ddlCaste.Items.Add("Sikh-Labana");
            ddlCaste.Items.Add("Sikh-Mazhbi");
            ddlCaste.Items.Add("Sikh-Rajput");
            ddlCaste.Items.Add("Sikh-Ramdasia");
            ddlCaste.Items.Add("Sikh-Ramgarhia");
            ddlCaste.Items.Add("Sikh-Saini");
            ddlCaste.Items.Add("Sikh-Other");
        }
        else if (ddlReligion.Text == "Jain")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
          
            ddlCaste.Items.Add("Digamber");
            ddlCaste.Items.Add("Shwetamber");

            ddlCaste.Items.Add("Jain-Others");
        }
        else if (ddlReligion.Text == "Buddhist")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
          
            ddlCaste.Items.Add("Caste no bar");
        }
        else if (ddlReligion.Text == "Spiritual")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
          
            ddlCaste.Items.Add("Caste no bar");
        }
        else if (ddlReligion.Text == "Parsi")
        {
            ddlCaste.Items.Clear();
          
            ddlCaste.Items.Add("Caste no bar");
        }
        else if (ddlReligion.Text == "Jewish")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
          
            ddlCaste.Items.Add("Caste no bar");
        }
        else if (ddlReligion.Text == "other")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
          
            ddlCaste.Items.Add("Caste no bar");
        }
        else if (ddlReligion.Text == "Inter-Religion")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
          
            ddlCaste.Items.Add("Ad Dharmi");
            ddlCaste.Items.Add("Adi Dravida");
            ddlCaste.Items.Add("Adi Karnataka");
            ddlCaste.Items.Add("Agarwal");
            ddlCaste.Items.Add("Agnikula Kshatriya");
            ddlCaste.Items.Add("Agri");
            ddlCaste.Items.Add("Ahir Shimpi");
            ddlCaste.Items.Add("Ahom");
            ddlCaste.Items.Add("Ambalavasi");
            ddlCaste.Items.Add("Arekatica");
            ddlCaste.Items.Add("Arora");
            ddlCaste.Items.Add("Arunthathiyar");
            ddlCaste.Items.Add("AryaVysya");
            ddlCaste.Items.Add("Ayyaraka");
            ddlCaste.Items.Add("Badaga");
            ddlCaste.Items.Add("Bagdi");
            ddlCaste.Items.Add("Baidya");
            ddlCaste.Items.Add("Baishnab");
            ddlCaste.Items.Add("Baishya");
            ddlCaste.Items.Add("Bajantri");
            ddlCaste.Items.Add("Balija");
            ddlCaste.Items.Add("Banayat Oriya");
            ddlCaste.Items.Add("Banik");
            ddlCaste.Items.Add("Baniya");
            ddlCaste.Items.Add("Baniya-Bania");
            ddlCaste.Items.Add("Baniya-Kumuti");
            ddlCaste.Items.Add("Banjara");
            ddlCaste.Items.Add("Barai");
            ddlCaste.Items.Add("Bari");
            ddlCaste.Items.Add("Baria");
            ddlCaste.Items.Add("Barujibi");
            ddlCaste.Items.Add("Besta");
            ddlCaste.Items.Add("Bhandari");
            ddlCaste.Items.Add("Bhatia");
            ddlCaste.Items.Add("Bhatraju");
            ddlCaste.Items.Add("Bhavasar Kshatriya");
            ddlCaste.Items.Add("Bhoi");
            ddlCaste.Items.Add("Bhovi");
            ddlCaste.Items.Add("Bhoyar");
            ddlCaste.Items.Add("Billava");
            ddlCaste.Items.Add("Bishnoi/Vishnoi");
            ddlCaste.Items.Add("Bondili");
            ddlCaste.Items.Add("Boyar");
            ddlCaste.Items.Add("Brahmbatt");
            ddlCaste.Items.Add("Brahmin-Anavil");
            ddlCaste.Items.Add("Brahmin-Audichya");
            ddlCaste.Items.Add("Brahmin-Barendra");
            ddlCaste.Items.Add("Brahmin-Bhatt");
            ddlCaste.Items.Add("Brahmin-Bhumihar");
            ddlCaste.Items.Add("Brahmin-Daivadnya");
            ddlCaste.Items.Add("Brahmin-Danua");
            ddlCaste.Items.Add("Brahmin-Deshastha");
            ddlCaste.Items.Add("Brahmin-Dhiman");
            ddlCaste.Items.Add("Brahmin-Dravida");
            ddlCaste.Items.Add("Brahmin-Embrandiri");
            ddlCaste.Items.Add("Brahmin-Garhwali");
            ddlCaste.Items.Add("Brahmin-Gaur");
            ddlCaste.Items.Add("Brahmin-Goswami/Gosavi");
            ddlCaste.Items.Add("Brahmin-GujarGaur");
            ddlCaste.Items.Add("Brahmin-Gurukkal");
            ddlCaste.Items.Add("Brahmin-Halua");
            ddlCaste.Items.Add("Brahmin-Havyaka");
            ddlCaste.Items.Add("Brahmin-Hoysala");
            ddlCaste.Items.Add("Brahmin-Iyengar");
            ddlCaste.Items.Add("Brahmin-Iyer");
            ddlCaste.Items.Add("Brahmin-Jangid");
            ddlCaste.Items.Add("Brahmin-Jhadua");
            ddlCaste.Items.Add("Brahmin-Jyotish");
            ddlCaste.Items.Add("Brahmin-Kanyakubj");
            ddlCaste.Items.Add("Brahmin-Karhade");
            ddlCaste.Items.Add("Brahmin-Khandelwal");
            ddlCaste.Items.Add("Brahmin-Kokanastha");
            ddlCaste.Items.Add("Brahmin-Kota");
            ddlCaste.Items.Add("Brahmin-Kulin");
            ddlCaste.Items.Add("Brahmin-Kumaoni");
            ddlCaste.Items.Add("Brahmin-Madhwa");
            ddlCaste.Items.Add("Brahmin-Maithil");
            ddlCaste.Items.Add("Brahmin-Modh");
            ddlCaste.Items.Add("Brahmin-Mohyal");
            ddlCaste.Items.Add("Brahmin-Nagar");
            ddlCaste.Items.Add("Brahmin-Namboodiri");
            ddlCaste.Items.Add("Brahmin-Narmadiya");
            ddlCaste.Items.Add("Brahmin-Niyogi");
            ddlCaste.Items.Add("Brahmin-Others");
            ddlCaste.Items.Add("Brahmin-Paliwal");
            ddlCaste.Items.Add("Brahmin-Panda");
            ddlCaste.Items.Add("Brahmin-Pandit");
            ddlCaste.Items.Add("Brahmin-Pareek");
            ddlCaste.Items.Add("Brahmin-Pushkarna");
            ddlCaste.Items.Add("Brahmin-Rarhi");
            ddlCaste.Items.Add("Brahmin-Rigvedi");
            ddlCaste.Items.Add("Brahmin-Rudraj");
            ddlCaste.Items.Add("Brahmin-Sakaldwipi");
            ddlCaste.Items.Add("Brahmin-Sanadya");
            ddlCaste.Items.Add("Brahmin-Sanketi");
            ddlCaste.Items.Add("Brahmin-Saraswat");
            ddlCaste.Items.Add("Brahmin-Saryuparin");
            ddlCaste.Items.Add("Brahmin-Shivhalli");
            ddlCaste.Items.Add("Brahmin-Shrimali");
            ddlCaste.Items.Add("Brahmin-Sikhwal");
            ddlCaste.Items.Add("Brahmin-Smartha");
            ddlCaste.Items.Add("Brahmin-SriVaishnava");
            ddlCaste.Items.Add("Brahmin-Stanika");
            ddlCaste.Items.Add("Brahmin-Tyagi");
            ddlCaste.Items.Add("Brahmin-Vaidiki");
            ddlCaste.Items.Add("Brahmin-Vaikhanasa");
            ddlCaste.Items.Add("Brahmin-Velanadu");
            ddlCaste.Items.Add("Brahmin-Vyas");
            ddlCaste.Items.Add("BrajasthaMaithil");
            ddlCaste.Items.Add("BrajasthaMaithil");
            ddlCaste.Items.Add("Bunt(Shetty)");
            ddlCaste.Items.Add("CKP");
            ddlCaste.Items.Add("Chalawadi and Holeya");
            ddlCaste.Items.Add("Chambhar");
            ddlCaste.Items.Add("Chandravanshi Kahar");
            ddlCaste.Items.Add("Chasa");
            ddlCaste.Items.Add("Chattada Sri Vaishnava");
            ddlCaste.Items.Add("Chaudary");
            ddlCaste.Items.Add("Chaurasia");
            ddlCaste.Items.Add("Chennadasar");
            ddlCaste.Items.Add("Chettiar");
            ddlCaste.Items.Add("Chhetri");
            ddlCaste.Items.Add("Chippolu(Mera)");
            ddlCaste.Items.Add("Coorgi");
            ddlCaste.Items.Add("Devadiga");
            ddlCaste.Items.Add("Devandra Kula Vellalar");
            ddlCaste.Items.Add("Devang Koshthi");
            ddlCaste.Items.Add("Devanga");
            ddlCaste.Items.Add("Devar/Thevar/Mukkulathor");
            ddlCaste.Items.Add("Devrukhe Brahmin");
            ddlCaste.Items.Add("Dhangar");
            ddlCaste.Items.Add("Dheevara");
            ddlCaste.Items.Add("Dhiman");
            ddlCaste.Items.Add("Dhoba");
            ddlCaste.Items.Add("Dhobi");
            ddlCaste.Items.Add("Dhor/Kakkayya");
            ddlCaste.Items.Add("Dommala");
            ddlCaste.Items.Add("Dumal");
            ddlCaste.Items.Add("Dusadh(Paswan)");
            ddlCaste.Items.Add("Ediga");
            ddlCaste.Items.Add("Ezhava");
            ddlCaste.Items.Add("Ezhuthachan");
            ddlCaste.Items.Add("Gabit");
            ddlCaste.Items.Add("Ganda");
            ddlCaste.Items.Add("Gandla");
            ddlCaste.Items.Add("Ganiga");
            ddlCaste.Items.Add("Garhwali");
            ddlCaste.Items.Add("Gatti");
            ddlCaste.Items.Add("Gavara");
            ddlCaste.Items.Add("Gawali");
            ddlCaste.Items.Add("Ghisadi");
            ddlCaste.Items.Add("Ghumar");
            ddlCaste.Items.Add("Goala");
            ddlCaste.Items.Add("Goan");
            ddlCaste.Items.Add("Gomantak");
            ddlCaste.Items.Add("Gondhali");
            ddlCaste.Items.Add("Goud");
            ddlCaste.Items.Add("Gounder");
            ddlCaste.Items.Add("Gowda");
            ddlCaste.Items.Add("Gramani");
            ddlCaste.Items.Add("Gudia");
            ddlCaste.Items.Add("Gujjar");
            ddlCaste.Items.Add("Gupta");
            ddlCaste.Items.Add("Guptan");
            ddlCaste.Items.Add("Gurav");
            ddlCaste.Items.Add("Gurjar");
            ddlCaste.Items.Add("Halba Koshti");
            ddlCaste.Items.Add("Helava");
            ddlCaste.Items.Add("Hugar(Jeer)");
            ddlCaste.Items.Add("Intercaste");
            ddlCaste.Items.Add("Irani");
            ddlCaste.Items.Add("Jaalari");
            ddlCaste.Items.Add("Jaiswal");
            ddlCaste.Items.Add("Jandra");
            ddlCaste.Items.Add("Jangam");
            ddlCaste.Items.Add("Jangra-Brahmin");
            ddlCaste.Items.Add("Jat");
            ddlCaste.Items.Add("Jatav");
            ddlCaste.Items.Add("Jetty/Malla");
            ddlCaste.Items.Add("Jijhotia Brahmin");
            ddlCaste.Items.Add("Jogi(Nath)");
            ddlCaste.Items.Add("Kachara");
            ddlCaste.Items.Add("Kadava Patel");
            ddlCaste.Items.Add("Kahar");
            ddlCaste.Items.Add("Kaibarta");
            ddlCaste.Items.Add("Kalal");
            ddlCaste.Items.Add("Kalanji");
            ddlCaste.Items.Add("Kalar");
            ddlCaste.Items.Add("Kalinga");
            ddlCaste.Items.Add("Kalinga Vysya");
            ddlCaste.Items.Add("Kalita");
            ddlCaste.Items.Add("Kalwar");
            ddlCaste.Items.Add("Kamboj");
            ddlCaste.Items.Add("Kamma");
            ddlCaste.Items.Add("Kansari");
            ddlCaste.Items.Add("Kapu");
            ddlCaste.Items.Add("Karana");
            ddlCaste.Items.Add("Karmakar");
            ddlCaste.Items.Add("Karuneegar");
            ddlCaste.Items.Add("Kasar");
            ddlCaste.Items.Add("Kashyap");
            ddlCaste.Items.Add("Katiya");
            ddlCaste.Items.Add("Kavuthiyya/Ezhavathy");
            ddlCaste.Items.Add("Kayastha");
            ddlCaste.Items.Add("Khandayat");
            ddlCaste.Items.Add("Khandelwal");
            ddlCaste.Items.Add("Kharwa");
            ddlCaste.Items.Add("Kharwar");
            ddlCaste.Items.Add("Khatri");
            ddlCaste.Items.Add("Kirar");
            ddlCaste.Items.Add("Kokanastha Maratha");
            ddlCaste.Items.Add("Koli");
            ddlCaste.Items.Add("KoliMahadev");
            ddlCaste.Items.Add("KoliPatel");
            ddlCaste.Items.Add("Kongu Vellala Gounder");
            ddlCaste.Items.Add("Konkani");
            ddlCaste.Items.Add("Korama");
            ddlCaste.Items.Add("Kori");
            ddlCaste.Items.Add("Kosthi");
            ddlCaste.Items.Add("Krishnavaka");
            ddlCaste.Items.Add("Kshatriya");
            ddlCaste.Items.Add("Kudumbi");
            ddlCaste.Items.Add("Kulal");
            ddlCaste.Items.Add("Kulalar");
            ddlCaste.Items.Add("Kulita");
            ddlCaste.Items.Add("Kumawat");
            ddlCaste.Items.Add("Kumbhakar");
            ddlCaste.Items.Add("Kumbhar");
            ddlCaste.Items.Add("Kumhar");

            ddlCaste.Items.Add("Kunbi");
            ddlCaste.Items.Add("Kuravan");
            ddlCaste.Items.Add("Kurmi/Kurmi Kshatriya");
            ddlCaste.Items.Add("Kuruba");
            ddlCaste.Items.Add("KuruhinaShetty");
            ddlCaste.Items.Add("Kurumbar");
            ddlCaste.Items.Add("Kushwaha(Koiri)");
            ddlCaste.Items.Add("Kutchi");
            ddlCaste.Items.Add("Lambadi");
            ddlCaste.Items.Add("Levapatel");
            ddlCaste.Items.Add("Levapatil");
            ddlCaste.Items.Add("Lingayath");
            ddlCaste.Items.Add("LodhiRajput");
            ddlCaste.Items.Add("Lohana");
            ddlCaste.Items.Add("Lohar");
            ddlCaste.Items.Add("Loniya");
            ddlCaste.Items.Add("Lubana");
            ddlCaste.Items.Add("Madiga");
            ddlCaste.Items.Add("Mahajan");
            ddlCaste.Items.Add("Mahar");
            ddlCaste.Items.Add("Mahendra");
            ddlCaste.Items.Add("Maheshwari");
            ddlCaste.Items.Add("Mahishya");
            ddlCaste.Items.Add("Majabi");
            ddlCaste.Items.Add("Mala");
            ddlCaste.Items.Add("Mali");
            ddlCaste.Items.Add("Mallah");
            ddlCaste.Items.Add("Malviya Brahmin");
            ddlCaste.Items.Add("Mangalorean");
            ddlCaste.Items.Add("Manipuri");
            ddlCaste.Items.Add("Mapila");
            ddlCaste.Items.Add("Maratha");
            ddlCaste.Items.Add("Maruthuvar");
            ddlCaste.Items.Add("Matang");
            ddlCaste.Items.Add("Mathur");
            ddlCaste.Items.Add("Maurya/Shakya");
            ddlCaste.Items.Add("Meena");
            ddlCaste.Items.Add("Meenavar");
            ddlCaste.Items.Add("Mehra");
            ddlCaste.Items.Add("MeruDarji");
            ddlCaste.Items.Add("Mochi");
            ddlCaste.Items.Add("Modak");
            ddlCaste.Items.Add("Mogaveera");
            ddlCaste.Items.Add("Mudaliyar");
            ddlCaste.Items.Add("Mudiraj");
            ddlCaste.Items.Add("Munnuru Kapu");
            ddlCaste.Items.Add("Muthuraja");
            ddlCaste.Items.Add("Naagavamsam");
            ddlCaste.Items.Add("Nadar");
            ddlCaste.Items.Add("Nagaralu");
            ddlCaste.Items.Add("Nai");
            ddlCaste.Items.Add("Naicker");
            ddlCaste.Items.Add("Naidu");
            ddlCaste.Items.Add("Naik");
            ddlCaste.Items.Add("Nair");
            ddlCaste.Items.Add("Namasudra/Namassej");
            ddlCaste.Items.Add("Nambiar");
            ddlCaste.Items.Add("Napit");
            ddlCaste.Items.Add("Nayaka");
            ddlCaste.Items.Add("Neeli");
            ddlCaste.Items.Add("Nepali");
            ddlCaste.Items.Add("Nhavi");
            ddlCaste.Items.Add("Oswal");
            ddlCaste.Items.Add("Otari");
            ddlCaste.Items.Add("Padmasali");
            ddlCaste.Items.Add("Pal");
            ddlCaste.Items.Add("Panchal");
            ddlCaste.Items.Add("Pandaram");
            ddlCaste.Items.Add("Panicker");
            ddlCaste.Items.Add("Parkava Kulam");
            ddlCaste.Items.Add("Parsi");
            ddlCaste.Items.Add("Partraj");
            ddlCaste.Items.Add("Pasi");
            ddlCaste.Items.Add("Patel");
            ddlCaste.Items.Add("Pathare Prabhu");
            ddlCaste.Items.Add("Patnaick/Sistakaranam");
            ddlCaste.Items.Add("Patra");
            ddlCaste.Items.Add("Perika");
            ddlCaste.Items.Add("Pillai");
            ddlCaste.Items.Add("Poosala");
            ddlCaste.Items.Add("Porwal");
            ddlCaste.Items.Add("Prajapati");
            ddlCaste.Items.Add("Raigar");
            ddlCaste.Items.Add("Rajaka");
            ddlCaste.Items.Add("Rajastani");
            ddlCaste.Items.Add("Rajbhar");
            ddlCaste.Items.Add("Rajbonshi");
            ddlCaste.Items.Add("Rajpurohit");
            ddlCaste.Items.Add("Rajput");
            ddlCaste.Items.Add("Ramanandi");
            ddlCaste.Items.Add("Ramdasia");
            ddlCaste.Items.Add("Ramgariah");
            ddlCaste.Items.Add("Ramoshi");
            ddlCaste.Items.Add("Ravidasia");
            ddlCaste.Items.Add("Rawat");
            ddlCaste.Items.Add("Reddy");
            ddlCaste.Items.Add("Relli");
            ddlCaste.Items.Add("Ror");
            ddlCaste.Items.Add("SC");
            ddlCaste.Items.Add("SKP");
            ddlCaste.Items.Add("ST");
            ddlCaste.Items.Add("Sadgope");
            ddlCaste.Items.Add("Sagara(Uppara)");
            ddlCaste.Items.Add("Saha");
            ddlCaste.Items.Add("Sahu");
            ddlCaste.Items.Add("Saini");
            ddlCaste.Items.Add("Saliya");
            ddlCaste.Items.Add("Sathwara");
            ddlCaste.Items.Add("Savji");
            ddlCaste.Items.Add("Senai Thalaivar");
            ddlCaste.Items.Add("Senguntha Mudaliyar");
            ddlCaste.Items.Add("Settibalija");
            ddlCaste.Items.Add("Shimpi/Namdev");
            ddlCaste.Items.Add("Sindhi");
            ddlCaste.Items.Add("Sindhi-Amil");
            ddlCaste.Items.Add("Sindhi-Baibhand");
            ddlCaste.Items.Add("Sindhi-Bhanusali");
            ddlCaste.Items.Add("Sindhi-Bhatia");
            ddlCaste.Items.Add("Sindhi-Chhapru");
            ddlCaste.Items.Add("Sindhi-Dadu");
            ddlCaste.Items.Add("Sindhi-Hyderabadi");
            ddlCaste.Items.Add("Sindhi-Larai");
            ddlCaste.Items.Add("Sindhi-Larkana");
            ddlCaste.Items.Add("Sindhi-Lohana");
            ddlCaste.Items.Add("Sindhi-Rohiri");
            ddlCaste.Items.Add("Sindhi-Sahiti");
            ddlCaste.Items.Add("Sindhi-Sakkhar");
            ddlCaste.Items.Add("Sindhi-Sehwani");
            ddlCaste.Items.Add("Sindhi-Shikarpuri");
            ddlCaste.Items.Add("Sindhi-Thatai");
            ddlCaste.Items.Add("Sonar");
            ddlCaste.Items.Add("Soni");
            ddlCaste.Items.Add("Sourashtra");
            ddlCaste.Items.Add("Sozhiya Vellalar");
            ddlCaste.Items.Add("Srisayana");
            ddlCaste.Items.Add("Sugali(Naika)");
            ddlCaste.Items.Add("Sunari");
            ddlCaste.Items.Add("Sundhi");
            ddlCaste.Items.Add("Surya Balija");
            ddlCaste.Items.Add("Suthar");
            ddlCaste.Items.Add("Swakula Sali");
            ddlCaste.Items.Add("Tamboli");
            ddlCaste.Items.Add("Tanti");
            ddlCaste.Items.Add("Tantubai");
            ddlCaste.Items.Add("Telaga");
            ddlCaste.Items.Add("Teli");
            ddlCaste.Items.Add("Thakkar");
            ddlCaste.Items.Add("Thakore");
            ddlCaste.Items.Add("Thakur");
            ddlCaste.Items.Add("Thigala");
            ddlCaste.Items.Add("Thiyya");
            ddlCaste.Items.Add("Tili");
            ddlCaste.Items.Add("Togata");
            ddlCaste.Items.Add("Tonk Kshatriya");
            ddlCaste.Items.Add("Turupu Kapu");
            ddlCaste.Items.Add("Urali Gounder");
            ddlCaste.Items.Add("Urs");
            ddlCaste.Items.Add("VadaBalija");
            ddlCaste.Items.Add("Vaddera");
            ddlCaste.Items.Add("Vaish");
            ddlCaste.Items.Add("Vaishnav");
            ddlCaste.Items.Add("Vaishnava");
            ddlCaste.Items.Add("Vaishya");
            ddlCaste.Items.Add("Vaishya Vani");
            ddlCaste.Items.Add("Valluvan");
            ddlCaste.Items.Add("Valmiki");
            ddlCaste.Items.Add("Vania");
            ddlCaste.Items.Add("Vanika Vyshya");
            ddlCaste.Items.Add("Vaniya");
            ddlCaste.Items.Add("Vanjara");
            ddlCaste.Items.Add("Vanjari");
            ddlCaste.Items.Add("Vankar");
            ddlCaste.Items.Add("Vannar");
            ddlCaste.Items.Add("Vannia Kula Kshatriyar");
            ddlCaste.Items.Add("Variar");
            ddlCaste.Items.Add("Varshney");
            ddlCaste.Items.Add("Veera Saivam");
            ddlCaste.Items.Add("Velaan");
            ddlCaste.Items.Add("Velama");
            ddlCaste.Items.Add("Vellalar");
            ddlCaste.Items.Add("Veluthedathu Nair");
            ddlCaste.Items.Add("Vettuva Gounder");
            ddlCaste.Items.Add("Vilakkithala Nair");
            ddlCaste.Items.Add("Vishwakarma");
            ddlCaste.Items.Add("Viswabrahmin");
            ddlCaste.Items.Add("Vokkaliga");
            ddlCaste.Items.Add("Vysya");
            ddlCaste.Items.Add("Yadav");
            ddlCaste.Items.Add("Yellapu");


        }
        else if (ddlReligion.Text == "No-Religious Belief")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
          
            ddlCaste.Items.Add("Ad Dharmi");
            ddlCaste.Items.Add("Adi Dravida");
            ddlCaste.Items.Add("Adi Karnataka");
            ddlCaste.Items.Add("Agarwal");
            ddlCaste.Items.Add("Agnikula Kshatriya");
            ddlCaste.Items.Add("Agri");
            ddlCaste.Items.Add("Ahir Shimpi");
            ddlCaste.Items.Add("Ahom");
            ddlCaste.Items.Add("Ambalavasi");
            ddlCaste.Items.Add("Arekatica");
            ddlCaste.Items.Add("Arora");
            ddlCaste.Items.Add("Arunthathiyar");
            ddlCaste.Items.Add("AryaVysya");
            ddlCaste.Items.Add("Ayyaraka");
            ddlCaste.Items.Add("Badaga");
            ddlCaste.Items.Add("Bagdi");
            ddlCaste.Items.Add("Baidya");
            ddlCaste.Items.Add("Baishnab");
            ddlCaste.Items.Add("Baishya");
            ddlCaste.Items.Add("Bajantri");
            ddlCaste.Items.Add("Balija");
            ddlCaste.Items.Add("Banayat Oriya");
            ddlCaste.Items.Add("Banik");
            ddlCaste.Items.Add("Baniya");
            ddlCaste.Items.Add("Baniya-Bania");
            ddlCaste.Items.Add("Baniya-Kumuti");
            ddlCaste.Items.Add("Banjara");
            ddlCaste.Items.Add("Barai");
            ddlCaste.Items.Add("Bari");
            ddlCaste.Items.Add("Baria");
            ddlCaste.Items.Add("Barujibi");
            ddlCaste.Items.Add("Besta");
            ddlCaste.Items.Add("Bhandari");
            ddlCaste.Items.Add("Bhatia");
            ddlCaste.Items.Add("Bhatraju");
            ddlCaste.Items.Add("Bhavasar Kshatriya");
            ddlCaste.Items.Add("Bhoi");
            ddlCaste.Items.Add("Bhovi");
            ddlCaste.Items.Add("Bhoyar");
            ddlCaste.Items.Add("Billava");
            ddlCaste.Items.Add("Bishnoi/Vishnoi");
            ddlCaste.Items.Add("Bondili");
            ddlCaste.Items.Add("Boyar");
            ddlCaste.Items.Add("Brahmbatt");
            ddlCaste.Items.Add("Brahmin-Anavil");
            ddlCaste.Items.Add("Brahmin-Audichya");
            ddlCaste.Items.Add("Brahmin-Barendra");
            ddlCaste.Items.Add("Brahmin-Bhatt");
            ddlCaste.Items.Add("Brahmin-Bhumihar");
            ddlCaste.Items.Add("Brahmin-Daivadnya");
            ddlCaste.Items.Add("Brahmin-Danua");
            ddlCaste.Items.Add("Brahmin-Deshastha");
            ddlCaste.Items.Add("Brahmin-Dhiman");
            ddlCaste.Items.Add("Brahmin-Dravida");
            ddlCaste.Items.Add("Brahmin-Embrandiri");
            ddlCaste.Items.Add("Brahmin-Garhwali");
            ddlCaste.Items.Add("Brahmin-Gaur");
            ddlCaste.Items.Add("Brahmin-Goswami/Gosavi");
            ddlCaste.Items.Add("Brahmin-GujarGaur");
            ddlCaste.Items.Add("Brahmin-Gurukkal");
            ddlCaste.Items.Add("Brahmin-Halua");
            ddlCaste.Items.Add("Brahmin-Havyaka");
            ddlCaste.Items.Add("Brahmin-Hoysala");
            ddlCaste.Items.Add("Brahmin-Iyengar");
            ddlCaste.Items.Add("Brahmin-Iyer");
            ddlCaste.Items.Add("Brahmin-Jangid");
            ddlCaste.Items.Add("Brahmin-Jhadua");
            ddlCaste.Items.Add("Brahmin-Jyotish");
            ddlCaste.Items.Add("Brahmin-Kanyakubj");
            ddlCaste.Items.Add("Brahmin-Karhade");
            ddlCaste.Items.Add("Brahmin-Khandelwal");
            ddlCaste.Items.Add("Brahmin-Kokanastha");
            ddlCaste.Items.Add("Brahmin-Kota");
            ddlCaste.Items.Add("Brahmin-Kulin");
            ddlCaste.Items.Add("Brahmin-Kumaoni");
            ddlCaste.Items.Add("Brahmin-Madhwa");
            ddlCaste.Items.Add("Brahmin-Maithil");
            ddlCaste.Items.Add("Brahmin-Modh");
            ddlCaste.Items.Add("Brahmin-Mohyal");
            ddlCaste.Items.Add("Brahmin-Nagar");
            ddlCaste.Items.Add("Brahmin-Namboodiri");
            ddlCaste.Items.Add("Brahmin-Narmadiya");
            ddlCaste.Items.Add("Brahmin-Niyogi");
            ddlCaste.Items.Add("Brahmin-Others");
            ddlCaste.Items.Add("Brahmin-Paliwal");
            ddlCaste.Items.Add("Brahmin-Panda");
            ddlCaste.Items.Add("Brahmin-Pandit");
            ddlCaste.Items.Add("Brahmin-Pareek");
            ddlCaste.Items.Add("Brahmin-Pushkarna");
            ddlCaste.Items.Add("Brahmin-Rarhi");
            ddlCaste.Items.Add("Brahmin-Rigvedi");
            ddlCaste.Items.Add("Brahmin-Rudraj");
            ddlCaste.Items.Add("Brahmin-Sakaldwipi");
            ddlCaste.Items.Add("Brahmin-Sanadya");
            ddlCaste.Items.Add("Brahmin-Sanketi");
            ddlCaste.Items.Add("Brahmin-Saraswat");
            ddlCaste.Items.Add("Brahmin-Saryuparin");
            ddlCaste.Items.Add("Brahmin-Shivhalli");
            ddlCaste.Items.Add("Brahmin-Shrimali");
            ddlCaste.Items.Add("Brahmin-Sikhwal");
            ddlCaste.Items.Add("Brahmin-Smartha");
            ddlCaste.Items.Add("Brahmin-SriVaishnava");
            ddlCaste.Items.Add("Brahmin-Stanika");
            ddlCaste.Items.Add("Brahmin-Tyagi");
            ddlCaste.Items.Add("Brahmin-Vaidiki");
            ddlCaste.Items.Add("Brahmin-Vaikhanasa");
            ddlCaste.Items.Add("Brahmin-Velanadu");
            ddlCaste.Items.Add("Brahmin-Vyas");
            ddlCaste.Items.Add("BrajasthaMaithil");
            ddlCaste.Items.Add("BrajasthaMaithil");
            ddlCaste.Items.Add("Bunt(Shetty)");
            ddlCaste.Items.Add("CKP");
            ddlCaste.Items.Add("Chalawadi and Holeya");
            ddlCaste.Items.Add("Chambhar");
            ddlCaste.Items.Add("Chandravanshi Kahar");
            ddlCaste.Items.Add("Chasa");
            ddlCaste.Items.Add("Chattada Sri Vaishnava");
            ddlCaste.Items.Add("Chaudary");
            ddlCaste.Items.Add("Chaurasia");
            ddlCaste.Items.Add("Chennadasar");
            ddlCaste.Items.Add("Chettiar");
            ddlCaste.Items.Add("Chhetri");
            ddlCaste.Items.Add("Chippolu(Mera)");
            ddlCaste.Items.Add("Coorgi");
            ddlCaste.Items.Add("Devadiga");
            ddlCaste.Items.Add("Devandra Kula Vellalar");
            ddlCaste.Items.Add("Devang Koshthi");
            ddlCaste.Items.Add("Devanga");
            ddlCaste.Items.Add("Devar/Thevar/Mukkulathor");
            ddlCaste.Items.Add("Devrukhe Brahmin");
            ddlCaste.Items.Add("Dhangar");
            ddlCaste.Items.Add("Dheevara");
            ddlCaste.Items.Add("Dhiman");
            ddlCaste.Items.Add("Dhoba");
            ddlCaste.Items.Add("Dhobi");
            ddlCaste.Items.Add("Dhor/Kakkayya");
            ddlCaste.Items.Add("Dommala");
            ddlCaste.Items.Add("Dumal");
            ddlCaste.Items.Add("Dusadh(Paswan)");
            ddlCaste.Items.Add("Ediga");
            ddlCaste.Items.Add("Ezhava");
            ddlCaste.Items.Add("Ezhuthachan");
            ddlCaste.Items.Add("Gabit");
            ddlCaste.Items.Add("Ganda");
            ddlCaste.Items.Add("Gandla");
            ddlCaste.Items.Add("Ganiga");
            ddlCaste.Items.Add("Garhwali");
            ddlCaste.Items.Add("Gatti");
            ddlCaste.Items.Add("Gavara");
            ddlCaste.Items.Add("Gawali");
            ddlCaste.Items.Add("Ghisadi");
            ddlCaste.Items.Add("Ghumar");
            ddlCaste.Items.Add("Goala");
            ddlCaste.Items.Add("Goan");
            ddlCaste.Items.Add("Gomantak");
            ddlCaste.Items.Add("Gondhali");
            ddlCaste.Items.Add("Goud");
            ddlCaste.Items.Add("Gounder");
            ddlCaste.Items.Add("Gowda");
            ddlCaste.Items.Add("Gramani");
            ddlCaste.Items.Add("Gudia");
            ddlCaste.Items.Add("Gujjar");
            ddlCaste.Items.Add("Gupta");
            ddlCaste.Items.Add("Guptan");
            ddlCaste.Items.Add("Gurav");
            ddlCaste.Items.Add("Gurjar");
            ddlCaste.Items.Add("Halba Koshti");
            ddlCaste.Items.Add("Helava");
            ddlCaste.Items.Add("Hugar(Jeer)");
            ddlCaste.Items.Add("Intercaste");
            ddlCaste.Items.Add("Irani");
            ddlCaste.Items.Add("Jaalari");
            ddlCaste.Items.Add("Jaiswal");
            ddlCaste.Items.Add("Jandra");
            ddlCaste.Items.Add("Jangam");
            ddlCaste.Items.Add("Jangra-Brahmin");
            ddlCaste.Items.Add("Jat");
            ddlCaste.Items.Add("Jatav");
            ddlCaste.Items.Add("Jetty/Malla");
            ddlCaste.Items.Add("Jijhotia Brahmin");
            ddlCaste.Items.Add("Jogi(Nath)");
            ddlCaste.Items.Add("Kachara");
            ddlCaste.Items.Add("Kadava Patel");
            ddlCaste.Items.Add("Kahar");
            ddlCaste.Items.Add("Kaibarta");
            ddlCaste.Items.Add("Kalal");
            ddlCaste.Items.Add("Kalanji");
            ddlCaste.Items.Add("Kalar");
            ddlCaste.Items.Add("Kalinga");
            ddlCaste.Items.Add("Kalinga Vysya");
            ddlCaste.Items.Add("Kalita");
            ddlCaste.Items.Add("Kalwar");
            ddlCaste.Items.Add("Kamboj");
            ddlCaste.Items.Add("Kamma");
            ddlCaste.Items.Add("Kansari");
            ddlCaste.Items.Add("Kapu");
            ddlCaste.Items.Add("Karana");
            ddlCaste.Items.Add("Karmakar");
            ddlCaste.Items.Add("Karuneegar");
            ddlCaste.Items.Add("Kasar");
            ddlCaste.Items.Add("Kashyap");
            ddlCaste.Items.Add("Katiya");
            ddlCaste.Items.Add("Kavuthiyya/Ezhavathy");
            ddlCaste.Items.Add("Kayastha");
            ddlCaste.Items.Add("Khandayat");
            ddlCaste.Items.Add("Khandelwal");
            ddlCaste.Items.Add("Kharwa");
            ddlCaste.Items.Add("Kharwar");
            ddlCaste.Items.Add("Khatri");
            ddlCaste.Items.Add("Kirar");
            ddlCaste.Items.Add("Kokanastha Maratha");
            ddlCaste.Items.Add("Koli");
            ddlCaste.Items.Add("KoliMahadev");
            ddlCaste.Items.Add("KoliPatel");
            ddlCaste.Items.Add("Kongu Vellala Gounder");
            ddlCaste.Items.Add("Konkani");
            ddlCaste.Items.Add("Korama");
            ddlCaste.Items.Add("Kori");
            ddlCaste.Items.Add("Kosthi");
            ddlCaste.Items.Add("Krishnavaka");
            ddlCaste.Items.Add("Kshatriya");
            ddlCaste.Items.Add("Kudumbi");
            ddlCaste.Items.Add("Kulal");
            ddlCaste.Items.Add("Kulalar");
            ddlCaste.Items.Add("Kulita");
            ddlCaste.Items.Add("Kumawat");
            ddlCaste.Items.Add("Kumbhakar");
            ddlCaste.Items.Add("Kumbhar");
            ddlCaste.Items.Add("Kumhar");

            ddlCaste.Items.Add("Kunbi");
            ddlCaste.Items.Add("Kuravan");
            ddlCaste.Items.Add("Kurmi/Kurmi Kshatriya");
            ddlCaste.Items.Add("Kuruba");
            ddlCaste.Items.Add("KuruhinaShetty");
            ddlCaste.Items.Add("Kurumbar");
            ddlCaste.Items.Add("Kushwaha(Koiri)");
            ddlCaste.Items.Add("Kutchi");
            ddlCaste.Items.Add("Lambadi");
            ddlCaste.Items.Add("Levapatel");
            ddlCaste.Items.Add("Levapatil");
            ddlCaste.Items.Add("Lingayath");
            ddlCaste.Items.Add("LodhiRajput");
            ddlCaste.Items.Add("Lohana");
            ddlCaste.Items.Add("Lohar");
            ddlCaste.Items.Add("Loniya");
            ddlCaste.Items.Add("Lubana");
            ddlCaste.Items.Add("Madiga");
            ddlCaste.Items.Add("Mahajan");
            ddlCaste.Items.Add("Mahar");
            ddlCaste.Items.Add("Mahendra");
            ddlCaste.Items.Add("Maheshwari");
            ddlCaste.Items.Add("Mahishya");
            ddlCaste.Items.Add("Majabi");
            ddlCaste.Items.Add("Mala");
            ddlCaste.Items.Add("Mali");
            ddlCaste.Items.Add("Mallah");
            ddlCaste.Items.Add("Malviya Brahmin");
            ddlCaste.Items.Add("Mangalorean");
            ddlCaste.Items.Add("Manipuri");
            ddlCaste.Items.Add("Mapila");
            ddlCaste.Items.Add("Maratha");
            ddlCaste.Items.Add("Maruthuvar");
            ddlCaste.Items.Add("Matang");
            ddlCaste.Items.Add("Mathur");
            ddlCaste.Items.Add("Maurya/Shakya");
            ddlCaste.Items.Add("Meena");
            ddlCaste.Items.Add("Meenavar");
            ddlCaste.Items.Add("Mehra");
            ddlCaste.Items.Add("MeruDarji");
            ddlCaste.Items.Add("Mochi");
            ddlCaste.Items.Add("Modak");
            ddlCaste.Items.Add("Mogaveera");
            ddlCaste.Items.Add("Mudaliyar");
            ddlCaste.Items.Add("Mudiraj");
            ddlCaste.Items.Add("Munnuru Kapu");
            ddlCaste.Items.Add("Muthuraja");
            ddlCaste.Items.Add("Naagavamsam");
            ddlCaste.Items.Add("Nadar");
            ddlCaste.Items.Add("Nagaralu");
            ddlCaste.Items.Add("Nai");
            ddlCaste.Items.Add("Naicker");
            ddlCaste.Items.Add("Naidu");
            ddlCaste.Items.Add("Naik");
            ddlCaste.Items.Add("Nair");
            ddlCaste.Items.Add("Namasudra/Namassej");
            ddlCaste.Items.Add("Nambiar");
            ddlCaste.Items.Add("Napit");
            ddlCaste.Items.Add("Nayaka");
            ddlCaste.Items.Add("Neeli");
            ddlCaste.Items.Add("Nepali");
            ddlCaste.Items.Add("Nhavi");
            ddlCaste.Items.Add("Oswal");
            ddlCaste.Items.Add("Otari");
            ddlCaste.Items.Add("Padmasali");
            ddlCaste.Items.Add("Pal");
            ddlCaste.Items.Add("Panchal");
            ddlCaste.Items.Add("Pandaram");
            ddlCaste.Items.Add("Panicker");
            ddlCaste.Items.Add("Parkava Kulam");
            ddlCaste.Items.Add("Parsi");
            ddlCaste.Items.Add("Partraj");
            ddlCaste.Items.Add("Pasi");
            ddlCaste.Items.Add("Patel");
            ddlCaste.Items.Add("Pathare Prabhu");
            ddlCaste.Items.Add("Patnaick/Sistakaranam");
            ddlCaste.Items.Add("Patra");
            ddlCaste.Items.Add("Perika");
            ddlCaste.Items.Add("Pillai");
            ddlCaste.Items.Add("Poosala");
            ddlCaste.Items.Add("Porwal");
            ddlCaste.Items.Add("Prajapati");
            ddlCaste.Items.Add("Raigar");
            ddlCaste.Items.Add("Rajaka");
            ddlCaste.Items.Add("Rajastani");
            ddlCaste.Items.Add("Rajbhar");
            ddlCaste.Items.Add("Rajbonshi");
            ddlCaste.Items.Add("Rajpurohit");
            ddlCaste.Items.Add("Rajput");
            ddlCaste.Items.Add("Ramanandi");
            ddlCaste.Items.Add("Ramdasia");
            ddlCaste.Items.Add("Ramgariah");
            ddlCaste.Items.Add("Ramoshi");
            ddlCaste.Items.Add("Ravidasia");
            ddlCaste.Items.Add("Rawat");
            ddlCaste.Items.Add("Reddy");
            ddlCaste.Items.Add("Relli");
            ddlCaste.Items.Add("Ror");
            ddlCaste.Items.Add("SC");
            ddlCaste.Items.Add("SKP");
            ddlCaste.Items.Add("ST");
            ddlCaste.Items.Add("Sadgope");
            ddlCaste.Items.Add("Sagara(Uppara)");
            ddlCaste.Items.Add("Saha");
            ddlCaste.Items.Add("Sahu");
            ddlCaste.Items.Add("Saini");
            ddlCaste.Items.Add("Saliya");
            ddlCaste.Items.Add("Sathwara");
            ddlCaste.Items.Add("Savji");
            ddlCaste.Items.Add("Senai Thalaivar");
            ddlCaste.Items.Add("Senguntha Mudaliyar");
            ddlCaste.Items.Add("Settibalija");
            ddlCaste.Items.Add("Shimpi/Namdev");
            ddlCaste.Items.Add("Sindhi");
            ddlCaste.Items.Add("Sindhi-Amil");
            ddlCaste.Items.Add("Sindhi-Baibhand");
            ddlCaste.Items.Add("Sindhi-Bhanusali");
            ddlCaste.Items.Add("Sindhi-Bhatia");
            ddlCaste.Items.Add("Sindhi-Chhapru");
            ddlCaste.Items.Add("Sindhi-Dadu");
            ddlCaste.Items.Add("Sindhi-Hyderabadi");
            ddlCaste.Items.Add("Sindhi-Larai");
            ddlCaste.Items.Add("Sindhi-Larkana");
            ddlCaste.Items.Add("Sindhi-Lohana");
            ddlCaste.Items.Add("Sindhi-Rohiri");
            ddlCaste.Items.Add("Sindhi-Sahiti");
            ddlCaste.Items.Add("Sindhi-Sakkhar");
            ddlCaste.Items.Add("Sindhi-Sehwani");
            ddlCaste.Items.Add("Sindhi-Shikarpuri");
            ddlCaste.Items.Add("Sindhi-Thatai");
            ddlCaste.Items.Add("Sonar");
            ddlCaste.Items.Add("Soni");
            ddlCaste.Items.Add("Sourashtra");
            ddlCaste.Items.Add("Sozhiya Vellalar");
            ddlCaste.Items.Add("Srisayana");
            ddlCaste.Items.Add("Sugali(Naika)");
            ddlCaste.Items.Add("Sunari");
            ddlCaste.Items.Add("Sundhi");
            ddlCaste.Items.Add("Surya Balija");
            ddlCaste.Items.Add("Suthar");
            ddlCaste.Items.Add("Swakula Sali");
            ddlCaste.Items.Add("Tamboli");
            ddlCaste.Items.Add("Tanti");
            ddlCaste.Items.Add("Tantubai");
            ddlCaste.Items.Add("Telaga");
            ddlCaste.Items.Add("Teli");
            ddlCaste.Items.Add("Thakkar");
            ddlCaste.Items.Add("Thakore");
            ddlCaste.Items.Add("Thakur");
            ddlCaste.Items.Add("Thigala");
            ddlCaste.Items.Add("Thiyya");
            ddlCaste.Items.Add("Tili");
            ddlCaste.Items.Add("Togata");
            ddlCaste.Items.Add("Tonk Kshatriya");
            ddlCaste.Items.Add("Turupu Kapu");
            ddlCaste.Items.Add("Urali Gounder");
            ddlCaste.Items.Add("Urs");
            ddlCaste.Items.Add("VadaBalija");
            ddlCaste.Items.Add("Vaddera");
            ddlCaste.Items.Add("Vaish");
            ddlCaste.Items.Add("Vaishnav");
            ddlCaste.Items.Add("Vaishnava");
            ddlCaste.Items.Add("Vaishya");
            ddlCaste.Items.Add("Vaishya Vani");
            ddlCaste.Items.Add("Valluvan");
            ddlCaste.Items.Add("Valmiki");
            ddlCaste.Items.Add("Vania");
            ddlCaste.Items.Add("Vanika Vyshya");
            ddlCaste.Items.Add("Vaniya");
            ddlCaste.Items.Add("Vanjara");
            ddlCaste.Items.Add("Vanjari");
            ddlCaste.Items.Add("Vankar");
            ddlCaste.Items.Add("Vannar");
            ddlCaste.Items.Add("Vannia Kula Kshatriyar");
            ddlCaste.Items.Add("Variar");
            ddlCaste.Items.Add("Varshney");
            ddlCaste.Items.Add("Veera Saivam");
            ddlCaste.Items.Add("Velaan");
            ddlCaste.Items.Add("Velama");
            ddlCaste.Items.Add("Vellalar");
            ddlCaste.Items.Add("Veluthedathu Nair");
            ddlCaste.Items.Add("Vettuva Gounder");
            ddlCaste.Items.Add("Vilakkithala Nair");
            ddlCaste.Items.Add("Vishwakarma");
            ddlCaste.Items.Add("Viswabrahmin");
            ddlCaste.Items.Add("Vokkaliga");
            ddlCaste.Items.Add("Vysya");
            ddlCaste.Items.Add("Yadav");
            ddlCaste.Items.Add("Yellapu");


        }
    }
}