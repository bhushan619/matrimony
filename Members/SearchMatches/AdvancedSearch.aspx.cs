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

public partial class Search_AdvancedSearch : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection(); string reqcount = 0.ToString();
    DataTable dt = new DataTable();
    string msgcount = 0.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["memberid"] == null)
        {

            Response.Write("<script>alert('Please Try Again');window.location='../../register/login.aspx';</script>");
            Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else
            if (!IsPostBack)
            {
                MemberBasicData();
                //getOldPass();
                cityBind();

                getrequestcount();
                getDataMessages();
                lblcountfinalmsg.Text = (Convert.ToInt32(msgcount) + Convert.ToInt32(reqcount)).ToString();
                notifications();

            }
    }
    public void cityBind()
    {
        //try
        //{
        //    dbc.con.Open();
        //    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT distinct varCity FROM tblammemberlivingin", dbc.con);
        //    MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
        //    ad.Fill(dt);
        //    ddlcity.DataSource = dt;
        //    ddlcity.DataTextField = "varCity";
        //    ddlcity.DataValueField = "varCity";
        //    ddlcity.DataBind();
        //    dbc.con.Close();
        //}
        //catch (Exception ex)
        //{
        //    ScriptManager.RegisterStartupScript(
        //           this,
        //           this.GetType(),
        //           "MessageBox",
        //           "alert('" + ex.Message + "');", true);
        //}
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
    protected void ddlagefrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlagefrom.Text == "--Select--")
        {
            ddlageto.Items.Clear();
            ddlageto.Items.Add("--Select--");
        }
        else if (ddlagefrom.Text == ddlagefrom.Text)
        {
            ddlageto.Items.Clear();
            int min = Convert.ToInt32(ddlagefrom.Text);
            int max = 70;
            int temp = 0;
            int[] arr = new int[max - min + 1];
            for (int i = min; i <= max; i++)
            {
                arr[temp] = i;
                temp++;

                ddlageto.Items.Add(Convert.ToString(i));
            }
            //ddlageto.DataSource = Convert.ToString(arr);
            //ddlageto.DataBind();
            //ddlageto.Items.Clear();
        }
    }
    protected void ddlReligion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReligion.Text == "Hindu")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
            ddlCaste.Items.Add("Any");
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
            ddlCaste.Items.Add("Any");
            ddlCaste.Items.Add("Shia");
            ddlCaste.Items.Add("Sunni");
            ddlCaste.Items.Add("Muslim-Other");

        }
        else if (ddlReligion.Text == "Christian")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
            ddlCaste.Items.Add("Any");
            ddlCaste.Items.Add("Catholic");
            ddlCaste.Items.Add("Orthodox");
            ddlCaste.Items.Add("Protestant");
            ddlCaste.Items.Add("Christian-Others");
        }
        else if (ddlReligion.Text == "Sikh")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
            ddlCaste.Items.Add("Any");
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
            ddlCaste.Items.Add("Any");
            ddlCaste.Items.Add("Digamber");
            ddlCaste.Items.Add("Shwetamber");

            ddlCaste.Items.Add("Jain-Others");
        }
        else if (ddlReligion.Text == "Buddhist")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
            ddlCaste.Items.Add("Any");
            ddlCaste.Items.Add("Caste no bar");
        }
        else if (ddlReligion.Text == "Spiritual")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
            ddlCaste.Items.Add("Any");
            ddlCaste.Items.Add("Caste no bar");
        }
        else if (ddlReligion.Text == "Parsi")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("Any");
            ddlCaste.Items.Add("Caste no bar");
        }
        else if (ddlReligion.Text == "Jewish")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
            ddlCaste.Items.Add("Any");
            ddlCaste.Items.Add("Caste no bar");
        }
        else if (ddlReligion.Text == "other")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
            ddlCaste.Items.Add("Any");
            ddlCaste.Items.Add("Caste no bar");
        }
        else if (ddlReligion.Text == "Inter-Religion")
        {
            ddlCaste.Items.Clear();
            ddlCaste.Items.Add("--Select--");
            ddlCaste.Items.Add("Any");
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
            ddlCaste.Items.Add("Any");
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
    protected void ddlHeighFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHeighFrom.Text == "--Feet/Inches--")
        {
            ddlHeighTo.SelectedIndex = 0;
        }
        else if (ddlHeighFrom.Text != ddlHeighTo.Text)
        {
            string[] bf = new string[2];
            string[] cf = new string[2];
            string[] et = new string[2];
            string[] ft = new string[2];

            ddlHeighTo.SelectedIndex = ddlHeighFrom.SelectedIndex;

            string[] af = ddlHeighFrom.Text.Split(' ');
            string[] dt = ddlHeighTo.Text.Split(' ');


            bf = af[0].Split('f');
            cf = af[1].Split('i');
            et = dt[0].Split('f');
            ft = dt[1].Split('i');

            if (bf[0].ToString().Equals(et[0].ToString()))
            {
                if (cf[0].ToString().Equals(ft[0].ToString()))
                {
                    ddlHeighTo.Text = et[0].ToString() + "ft " + ft[0].ToString() + "in";
                }
            }
        }
    }

    protected void ddlHeighTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHeighTo.SelectedIndex < ddlHeighFrom.SelectedIndex)
        {
            ddlHeighFrom.SelectedIndex = 0;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string searchby = string.Empty;
        string query = string.Empty;
        if (ddlagefrom.Text == "--Select--")
        {
        }
        else
        {
            query = "&AgeFrom=" + ddlagefrom.Text + "&AgeTo=" + ddlageto.Text;
            searchby = searchby + "_age";
        }
        if (ddlHeighFrom.Text == "--Feet/Inches--")
        {

        }
        else
        {
            query = query + "&HeightFrom=" + ddlHeighFrom.Text + "&HeightTo=" + ddlHeighTo.Text;
            searchby = searchby + "_height";
        }

        if (ddlMstatus.Text == "--Select--")
        {

        }
        else
        {
            query = query + "&MStatus=" + ddlMstatus.Text;
            searchby = searchby + "_marital";
        }
        string motng = dtaMotherTongue.Value.Replace(',', '-');
        if (motng == "")
        { }
        else
        {
            query = query + "&Mothertoung=" + motng;
            searchby = searchby + "_mothertoung";
        }
        if (ddlReligion.Text == "--Select Religion--")
        {

        }
        else
        {
            query = query + "&Religion=" + ddlReligion.Text;
            searchby = searchby + "_religion";
        }
        
        string caste = dtaCaste.Value.ToString().Replace(',', '-');
        if (caste == "")
        {
        }
        else
        {
            query = query + "&Caste=" + caste;
            searchby = searchby + "_caste";
        }
        string city = dtacmbcity.Value.Replace(',', '-');
        if (city == "")
        { }
        else
        {
            query = query + "&City=" + city;
            searchby = searchby + "_city";
        }
        // .......................................................extra feild......................
        if (ddlSpecialCase.Text == "--Select Special Case--")
        {

        }
        else
        {
            query = query + "&SpecialCase=" + ddlSpecialCase.Text;
            searchby = searchby + "_specialcase";
        }
        string country = dtacountry.Value.Replace(',', '-');
        if (country == "")
        { }
        else
        {
            query = query + "&Country=" + country;
            searchby = searchby + "_country";
        }
        if (cmbstate.Text == "--Select State--")
        {

        }
        else
        {
            query = query + "&State=" + cmbstate.Text;
            searchby = searchby + "_state";
        }
        string education = dtaSelect.Value.Replace(',', '-');
        if (education == "")
        { }
        else
        {
            query = query + "&Education=" + education;
            searchby = searchby + "_education";
        }

        string occupation = dtafunctional.Value.Replace(',', '-');
        if (occupation == "")
        { }
        else
        {
            query = query + "&Occupation=" + occupation;
            searchby = searchby + "_occupation";
        }
        string star = dtaddlStar.Value.Replace(',', '-');
        if (star == "")
        { }
        else
        {
            query = query + "&Star=" + star;
            searchby = searchby + "_star";
        }
        if (ddlManglik.Text == "--Select--")
        {

        }
        else
        {
            query = query + "&Manglik=" + ddlManglik.Text;
            searchby = searchby + "_manglik";
        }
        if (ddleat.Text == "--Select--")
        {

        }
        else
        {
            query = query + "&Eat=" + ddleat.Text;
            searchby = searchby + "_eat";
        }
        if (ddlsmoke.Text == "--Select--")
        {

        }
        else
        {
            query = query + "&Smoke=" + ddlsmoke.Text;
            searchby = searchby + "_smoke";
        }
        if (ddldrink.Text == "--Select--")
        {

        }
        else
        {
            query = query + "&Drink=" + ddldrink.Text;
            searchby = searchby + "_drink";
        }
        if (ddlshowProfile.Text == "--Select--")
        {

        }
        else
        {
            query = query + "&ShowProfile=" + ddlshowProfile.Text;
            searchby = searchby + "_showprofile";
        }
        
        Response.Redirect("AdvancedSearchResult.aspx?" + query + "&SearchBy=" + searchby + "");
    }
    public void changecity(string state)
    {
        if (state == "Andhra Pradesh")
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
        else if (state == "Arunachal Pradesh")
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
        else if (state == "Assam")
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

        else if (state == "Bihar")
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
        else if (state == "Chattisgardh")
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
        else if (state == "Goa")
        {
            cmbcity.Items.Clear();
            cmbcity.Items.Add("--Select--");
            cmbcity.Items.Add("North Goa");
            cmbcity.Items.Add("South Goa");
        }
        else if (state == "Gujarat")
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

        else if (state == "Haryana")
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

        else if (state == "Himachal Pradesh")
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
        else if (state == "Jammu and Kashmir")
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

        else if (state == "Jharkhand")
        {
            cmbcity.Items.Clear();
            cmbcity.Items.Add("--Select--");
            cmbcity.Items.Add("Bokaro");
            cmbcity.Items.Add("Chaibasa (West Singhbhum)");
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
        else if (state == "Karnataka")
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
        else if (state == "Kerala")
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
        else if (state == "Madhya Pradesh")
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
        else if (state == "Maharashtra")
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
        else if (state == "Manipur")
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
        else if (state == "Meghalaya")
        {
            cmbcity.Items.Clear();
            cmbcity.Items.Add("--Select--");
            cmbcity.Items.Add("East Garo Hills / North Garo Hills");
            cmbcity.Items.Add("East Khasi Hills");
            cmbcity.Items.Add("Jaintia Hills / East Jaintia Hills");
            cmbcity.Items.Add("Ri-Bhoi");
            cmbcity.Items.Add("South Garo Hills");
            cmbcity.Items.Add("West Garo Hills / South West Garo Hills");
            cmbcity.Items.Add("West Khasi Hills / South West Khasi Hills");




        }
        else if (state == "Mizoram")
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

        else if (state == "Nagaland")
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
        else if (state == "Orissa")
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


        else if (state == "Punjab")
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
        else if (state == "Rajastan")
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
        else if (state == "Sikkim")
        {
            cmbcity.Items.Clear();
            cmbcity.Items.Add("--Select--");
            cmbcity.Items.Add("East Sikkim");
            cmbcity.Items.Add("North Sikkim");

            cmbcity.Items.Add("South Sikkim");
            cmbcity.Items.Add("West Sikkim");
        }

        else if (state == "Tamil Nadu")
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

        else if (state == "Tripura")
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


        else if (state == "Uttar Pradesh")
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
        else if (state == "Uttarakhand")
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
        else if (state == "West Bengal")
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
}