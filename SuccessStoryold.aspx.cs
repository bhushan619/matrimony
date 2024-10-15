﻿using System;
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

public partial class SuccessStory : System.Web.UI.Page
{
    
    DatabaseConnection dbc = new DatabaseConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        //ListItem[] i = new ListItem[50];
        //i[0]=ddlCountry.Items.FindByValue("--Select Country--");
        //i[0].Attributes.Add("style", "color:Red;");
        //i[0].Attributes.Add("disabled", "true");
        //i[0].Value = "-1";

        //ddlCountry.SelectedIndex = 0;

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string filename = string.Empty;

            if (!fupProPic.HasFile)
            {
                ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('Please select a picture');", true);

                return;
            }
            else
            {
                string ffileExt = System.IO.Path.GetExtension(fupProPic.FileName);
                if ((ffileExt == ".JPG") || (ffileExt == ".jpg") || (ffileExt == ".JPEG") || (ffileExt == ".jpeg") || (ffileExt == ".PNG") || (ffileExt == ".png"))
                {
                    filename =dbc.CreateRandomPassword(4)+fupProPic.FileName.ToString();

                    int insert_ok = dbc.insert_tblamsuccessstories(txtMembetId.Text, txtPartnerMemberId.Text, txtMemberName.Text, txtPartnerName.Text, txtEngagementDate.Text, txtMarriageDate.Text, txtWeddingLocation.Text, txtLivingAddress.Text, ddlCountry.Text, cmbstate.Text, cmbcity.Text, txtMobile.Text, txtStory.Text, filename, txtEmail.Text);

                    if (insert_ok == 1)
                    {
                        fupProPic.SaveAs(Server.MapPath("~/media/SuccessStory/") + filename);
                        ScriptManager.RegisterStartupScript(
                      this,
                      this.GetType(),
                      "MessageBox",
                      "alert('Success Story Added!!!');", true);

                        clear();
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
                else
                {
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Please select proper image as .jpg or .png');", true);
                    return;
                }
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
        txtEmail.Text = "";
        txtPartnerName.Text = "";
        txtMobile.Text = "";
        txtMembetId.Text = "";
        txtStory.Text = "";
   
        txtMemberName.Text = "";
        txtEngagementDate.Text = "";
        txtLivingAddress.Text = "";
        txtMarriageDate.Text = "";
        txtPartnerMemberId.Text = "";
        txtWeddingLocation.Text = "";
        ddlCountry.SelectedIndex = 0;
        cmbstate.SelectedIndex = 0;
        cmbcity.SelectedIndex = 0;
        
    }
    protected void txtMembetId_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtPartnerMemberId.Text != txtMembetId.Text)
            {
                MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varGender,varMemberName from anuvaa_matrimony.tblammemberregistration where varMemberId='" + txtMembetId.Text + "' and varMemberStatus='Verified'", dbc.con);
                dbc.con.Open();
                dbc.dr = cmde.ExecuteReader();
                if (dbc.dr.Read())
                {
                    txtMemberName.Text = dbc.dr["varMemberName"].ToString();
                }
                else
                {
                    clear();
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Member ID not available');", true);

                }
                dbc.con.Close();
            }
            else
            {
                clear();
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
    protected void txtPartnerMemberId_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtPartnerMemberId.Text != txtMembetId.Text)
            {
                MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varGender,varMemberName from anuvaa_matrimony.tblammemberregistration where varMemberId='" + txtPartnerMemberId.Text + "' and varMemberStatus='Verified'", dbc.con);
                dbc.con.Open();
                dbc.dr = cmde.ExecuteReader();
                if (dbc.dr.Read())
                {
                    txtPartnerName.Text = dbc.dr["varMemberName"].ToString();
                }
                else
                {
                    clear();
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Member ID not available');", true);

                }
                dbc.con.Close();
            }
            else
            {
                clear();
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
    protected void state_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cmbstate.Text == "Andhra Pradesh")
            {
                cmbcity.Items.Clear();
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
                cmbcity.Items.Add("North Goa");
                cmbcity.Items.Add("South Goa");
            }
            else if (cmbstate.Text == "Gujarat")
            {
                cmbcity.Items.Clear();
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("Jamshedpur(East Singhbhum)");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
                cmbcity.Items.Add("East Garo Hills/North Garo Hills");
                cmbcity.Items.Add("East Khasi Hills");
                cmbcity.Items.Add("Jaintia Hills/East Jaintia Hills");
                cmbcity.Items.Add("Ri-Bhoi");
                cmbcity.Items.Add("South Garo Hills");
                cmbcity.Items.Add("West Garo Hills/South West Garo Hills");
                cmbcity.Items.Add("West Khasi Hills/South West Khasi Hills");




            }
            else if (cmbstate.Text == "Mizoram")
            {
                cmbcity.Items.Clear();
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
                cmbcity.Items.Add("East Sikkim");
                cmbcity.Items.Add("North Sikkim");

                cmbcity.Items.Add("South Sikkim");
                cmbcity.Items.Add("West Sikkim");
            }

            else if (cmbstate.Text == "Tamil Nadu")
            {
                cmbcity.Items.Clear();
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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
                cmbcity.Items.Add("--Select--");
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

}