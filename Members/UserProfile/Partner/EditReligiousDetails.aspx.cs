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
using System.Net.Mail;
using System.Net;
using System.IO;

using System.Text;

public partial class members_UserProfile_Partner_EditReligiousDetails : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    string living = string.Empty;
    string reqcount = 0.ToString();
    string msgcount = 0.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["memberid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../../register/login.aspx';</script>");
            Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
            MemberBasicData();

            getrequestcount();
            getDataMessages();
            lblcountfinalmsg.Text = (Convert.ToInt32(msgcount) + Convert.ToInt32(reqcount)).ToString();
            notifications();
            BindDataMultipleDropdowns();
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
                // gen = dbc.dr["varGender"].ToString();
                imgMemberPhoto.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();

                if (dbc.dr["varMembershipType"].ToString() == "Paid")
                {
                    MySql.Data.MySqlClient.MySqlCommand cmdm = new MySql.Data.MySqlClient.MySqlCommand("SELECT (SELECT distinct varPackageName FROM tblampackages WHERE varPackageId=tblammembertransactions.varPackageId) as ViewMemPackage FROM tblammembertransactions WHERE varMemberId='" + Session["memberid"].ToString() + "' and varOrderStatus='Confirmed'  order by intId DESC", dbc.con1);

                    dbc.con1.Open();
                    dbc.dr1 = cmdm.ExecuteReader();
                    if (dbc.dr1.Read())
                    {
                        lblmemUpgrade.Visible = true;
                        lnkUpgrade.Visible = false;
                        lblmemUpgrade.Text = dbc.dr1["ViewMemPackage"].ToString();
                    }
                    dbc.con1.Close();
                    dbc.dr1.Close();
                }
                else if (dbc.dr["varMembershipType"].ToString() == "Unpaid")
                {
                    lblmemUpgrade.Visible = false;
                    lnkUpgrade.Visible = true;
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
    public void notifications()
    {
        try
        {
            lnkNotifications.Text = dbc.count_tblamnotifications(Session["memberid"].ToString(), "Member").ToString();
            lblcomplet.Attributes.Add("data-percent", dbc.getInActiveGridview(Session["memberid"].ToString()).ToString());

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
    public void getrequestcount()
    {
        try
        {
            dbc.con.Close();
           MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT count( intId)as myrequest, varFromMemberId, varFromMembarName, varFromMemberStatus, varToMemberId, varToMembarName, varToMemberStatus, varRequestType, varStatus, varDate, varTime FROM tblamrequests where (varToMemberId = '" + Session["memberid"].ToString() + "') and varStatus='Pending'     ORDER BY intId", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                reqcount = (Convert.ToInt32(reqcount.ToString()) + Convert.ToInt32(dbc.dr["myrequest"].ToString())).ToString();
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
    string MsgId = string.Empty;
    public void getDataMessages()
    {
        try
        {
            MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr3;


            MySql.Data.MySqlClient.MySqlConnection cnn1 = new MySql.Data.MySqlClient.MySqlConnection();
            cnn1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;
            cnn1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct tblamcommunication.intId AS MsgId, tblamcommunication.varMsgFrom, tblamcommunication.varMsgFromName FROM tblamcommunication INNER JOIN tblamconversation ON tblamcommunication.intId = tblamconversation.varMessageId WHERE (tblamcommunication.varMsgto = '" + Session["memberid"].ToString() + "') ", cnn1);
            using (cnn1)
            {
                //read data from the table to our data reader
                rdr1 = cmd.ExecuteReader();
                //loop through each row we have read
                while (rdr1.Read())
                {
                    MsgId = rdr1["MsgId"].ToString();

                    // count unread //
                    MySql.Data.MySqlClient.MySqlConnection cnn3 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn3.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(intId)as mycount FROM tblamconversation WHERE ex1='Unread' and varMessageId=" + Convert.ToInt32(MsgId) + " and varMsgFrom!='" + Session["memberid"].ToString() + "'", cnn3);
                    cmd3.CommandType = CommandType.Text;

                    using (cnn3)
                    {
                        cnn3.Open();
                        rdr3 = cmd3.ExecuteReader();
                        if (rdr3.Read())
                        {

                            msgcount = (Convert.ToInt32(msgcount) + Convert.ToInt32(rdr3["mycount"].ToString())).ToString();


                        }
                        cnn3.Close();
                        rdr3.Close();

                    }
                }

                // Empty strings
                MsgId = string.Empty;


            }
            cnn1.Close();
            cmd.Dispose();

            cnn1.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct tblamcommunication.intId AS MsgId, tblamcommunication.varMsgto, tblamcommunication.varMsgtoName FROM tblamcommunication INNER JOIN tblamconversation ON tblamcommunication.intId = tblamconversation.varMessageId WHERE (tblamcommunication.varMsgFrom = '" + Session["memberid"].ToString() + "')  ORDER BY tblamconversation.intId DESC  ", cnn1);
            using (cnn1)
            {
                //read data from the table to our data reader
                rdr1 = cmd.ExecuteReader();
                //loop through each row we have read
                while (rdr1.Read())
                {
                    MsgId = rdr1["MsgId"].ToString();
                    // count unread //
                    MySql.Data.MySqlClient.MySqlConnection cnn3 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn3.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(intId)as mycount FROM tblamconversation WHERE ex1='Unread' and varMessageId=" + Convert.ToInt32(MsgId) + " and varMsgFrom!='" + Session["memberid"].ToString() + "'", cnn3);
                    cmd3.CommandType = CommandType.Text;

                    using (cnn3)
                    {
                        cnn3.Open();
                        rdr3 = cmd3.ExecuteReader();
                        if (rdr3.Read())
                        {

                            msgcount = (Convert.ToInt32(msgcount) + Convert.ToInt32(rdr3["mycount"].ToString())).ToString();


                        }
                        cnn3.Close();
                        rdr3.Close();

                    }
                }

                // Empty strings
                MsgId = string.Empty;


            }
            cnn1.Close();

        }
        catch (Exception ex)
        {

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
    private void BindDataMultipleDropdowns()
    {
        ddlMotherTongue.Multiple = true;
        ddlCaste.Multiple = true; 
        int i = 0;

        /* Religious */

        MySql.Data.MySqlClient.MySqlCommand cmdpro = new MySql.Data.MySqlClient.MySqlCommand("SELECT varReligion, varManglik, varNakshatra, varRaasiMoonSign FROM tblammemberpartnerreligious WHERE varMemberId = '" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        dbc.dr = cmdpro.ExecuteReader();
        if (dbc.dr.Read())
        {
            ddlReligion.Text = dbc.dr["varReligion"].ToString();
            setCastes(dbc.dr["varReligion"].ToString());
            ddlStar.Text = dbc.dr["varNakshatra"].ToString();
            ddlRaashi.Text = dbc.dr["varRaasiMoonSign"].ToString();
            if (dbc.dr["varManglik"].ToString() == "Yes")
            {
                rgbManglikYes.Checked = true;
                rgbManglikNo.Checked = false;
                rgbManglikNotKnow.Checked = false;
            }
            else if (dbc.dr["varManglik"].ToString() == "No")
            {
                rgbManglikYes.Checked = false;
                rgbManglikNo.Checked = true;
                rgbManglikNotKnow.Checked = false;
            }
            else if (dbc.dr["varManglik"].ToString() == "Does not matter")
            {
                rgbManglikYes.Checked = false;
                rgbManglikNo.Checked = false;
                rgbManglikNotKnow.Checked = true;
            }
        }
        dbc.con.Close();
        dbc.dr.Close();
        
        /* Religious end */

        /* MotherTongue */
        cmdpro = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMotherTongue FROM tblamemberpartnermothertongue WHERE varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        dbc.dr = cmdpro.ExecuteReader();
        while (dbc.dr.Read())
        {
            if (dbc.dr["varMotherTongue"].ToString() == "")
            {
            }
            else
            {
                i = ddlMotherTongue.Items.IndexOf(((ListItem)ddlMotherTongue.Items.FindByText(dbc.dr["varMotherTongue"].ToString())));

                ddlMotherTongue.Items[i].Selected = true;
            }

        }
        i = 0;
        dbc.con.Close();
        cmdpro.Dispose();

        /* MotherTongue end */

        /* Caste */
        cmdpro = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCaste FROM tblamemberpartnercaste WHERE varMemberId='" + Session["memberid"].ToString() + "'", dbc.con);
        dbc.con.Open();
        dbc.dr = cmdpro.ExecuteReader();
        while (dbc.dr.Read())
        {
            if (dbc.dr["varCaste"].ToString() == "")
            {
            }
            else
            {
                i = ddlCaste.Items.IndexOf(((ListItem)ddlCaste.Items.FindByText(dbc.dr["varCaste"].ToString())));

                ddlCaste.Items[i].Selected = true;
            }

        }
        i = 0;
        dbc.con.Close();
        cmdpro.Dispose();
        /* Caste end */

       

    }
    protected void btnreligiousSave_Click(object sender, EventArgs e)
    {
        try
        {
            string Manglik = string.Empty;
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
            string[] caste = dtaCaste.Value.Split(',');
            dbc.Delete_tblamemberpartnercaste(Session["memberid"].ToString());
            for (int i = 0; i < caste.Count(); i++)
            {
                dbc.insert_tblamemberpartnercaste(Session["memberid"].ToString(), caste[i].ToString());
            }

            string[] motng = dtaMotherTongue.Value.Split(',');
            dbc.Delete_tblamemberpartnermothertongue(Session["memberid"].ToString());
            for (int i = 0; i < motng.Count(); i++)
            {
                dbc.insert_tblamemberpartnermothertongue(Session["memberid"].ToString(), motng[i].ToString());
            }

            if (dbc.update_tblammemberpartnerreligious(Session["memberid"].ToString(), ddlReligion.Text, Manglik, ddlStar.Text, ddlRaashi.Text) == 1)
            {
                ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('Data Updated');window.location='EditReligiousDetails.aspx';", true);
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

    protected void ddlReligion_SelectedIndexChanged(object sender, EventArgs e)
    {
        setCastes(ddlReligion.Text);
    }

    public void setCastes(string caste)
    {
        if (caste == "Hindu")
        {
            ddlCaste.Items.Clear();

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
        else if (caste == "Muslim")
        {
            ddlCaste.Items.Clear();


            ddlCaste.Items.Add("Shia");
            ddlCaste.Items.Add("Sunni");
            ddlCaste.Items.Add("Muslim-Other");

        }
        else if (caste == "Christian")
        {
            ddlCaste.Items.Clear();


            ddlCaste.Items.Add("Catholic");
            ddlCaste.Items.Add("Orthodox");
            ddlCaste.Items.Add("Protestant");
            ddlCaste.Items.Add("Christian-Others");
        }
        else if (caste == "Sikh")
        {
            ddlCaste.Items.Clear();


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
        else if (caste == "Jain")
        {
            ddlCaste.Items.Clear();


            ddlCaste.Items.Add("Digamber");
            ddlCaste.Items.Add("Shwetamber");

            ddlCaste.Items.Add("Jain-Others");
        }
        else if (caste == "Buddhist")
        {
            ddlCaste.Items.Clear();


            ddlCaste.Items.Add("Caste no bar");
        }
        else if (caste == "Spiritual")
        {
            ddlCaste.Items.Clear();


            ddlCaste.Items.Add("Caste no bar");
        }
        else if (caste == "Parsi")
        {
            ddlCaste.Items.Clear();

            ddlCaste.Items.Add("Caste no bar");
        }
        else if (caste == "Jewish")
        {
            ddlCaste.Items.Clear();


            ddlCaste.Items.Add("Caste no bar");
        }
        else if (caste == "other")
        {
            ddlCaste.Items.Clear();


            ddlCaste.Items.Add("Caste no bar");
        }
        else if (caste == "Inter-Religion")
        {
            ddlCaste.Items.Clear();


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
        else if (caste == "No-Religious Belief")
        {
            ddlCaste.Items.Clear();


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