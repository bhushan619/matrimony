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
public partial class members_Subscription_NewOrder : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    static string amount = string.Empty;
    static string firstname = string.Empty;
    static string email = string.Empty;
    static string phone = string.Empty;
    static string productinfo = string.Empty;
    static string packageno = string.Empty;
    static string packageduration = string.Empty;
    static string packagedurationtime = string.Empty;
    static string state = string.Empty;
    static string city = string.Empty;
    static string address = string.Empty;
    static string pin = string.Empty;
    static string country = string.Empty;
    static string orderid = string.Empty;
    static string pname = string.Empty;
    static string[] packag;
    string reqcount = 0.ToString();
    string msgcount = 0.ToString();
    static int mypackintid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["memberid"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../register/login.aspx';</script>");
            Response.Cache.SetExpires(DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }
        else if (!IsPostBack)
        {
            MemberBasicData();
            notifications();
            getrequestcount();
            getDataMessages();
            lblcountfinalmsg.Text = (Convert.ToInt32(msgcount) + Convert.ToInt32(reqcount)).ToString();
            packag = Session["packid"].ToString().Split(';');
            lblOrderNo.Text = Session["orderid"].ToString();
            getdata();
            //SqlDataSource1.SelectCommand = "SELECT DISTINCT tblampackages.varPackageId, tblampackages.varPackageName, tblampackagesdetails.varPackageDescription, tblampackagesdetails.varPackageDuration, tblampackagesdetails.varPackagePrice, tblampackagesdetails.varBenifits, tblampackagesdetails.varPackageDurationTime FROM tblampackages INNER JOIN tblampackagesdetails ON tblampackages.varPackageId = tblampackagesdetails.varPackageId where tblampackages.varPackageId='" + packag[0].ToString() + "' and tblampackagesdetails.varPackageDuration='" + packag[2].ToString() + "' and tblampackagesdetails.varPackageDurationTime='" + packag[3].ToString() + "'";

        }

    }
    public void getdata()
    {
        try
        {
            DataTable dts = new DataTable();

            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT DISTINCT tblampackages.varPackageId, tblampackages.varPackageName, tblampackagesdetails.varPackageDescription, tblampackagesdetails.varPackageDuration, tblampackagesdetails.varPackagePrice, tblampackagesdetails.varBenifits, tblampackagesdetails.varPackageDurationTime FROM tblampackages INNER JOIN tblampackagesdetails ON tblampackages.varPackageId = tblampackagesdetails.varPackageId where tblampackages.varPackageId = '" + packag[0].ToString() + "' and tblampackagesdetails.varPackageDuration = '" + packag[2].ToString() + "' and tblampackagesdetails.varPackageDurationTime = '" + packag[3].ToString() + "'", dbc.con);
            dbc.con.Open();
            MySqlDataAdapter ad = new MySqlDataAdapter(cmde);
            ad.Fill(dts);
            ListView1.DataSource = dts;
            ListView1.DataBind();
            dbc.con.Close();
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

                MySql.Data.MySqlClient.MySqlCommand cmdc = new MySql.Data.MySqlClient.MySqlCommand("SELECT varParentMobile, varParentLandline, varMemberAlternateMobile1, varMemberAlternateMobile2, varMemberAlternateEmail1, varMemberAlternateEmail2, varPermanantAddress, varAlternateAddress, varContactPersonName, varContactPersonMobile, varRelationOfContactPerson, ex1, ex2 FROM tblammembercontactdetails WHERE varMemberId='" + Session["memberid"].ToString() + "'", dbc.con1);

                dbc.con1.Open();
                dbc.dr1 = cmdc.ExecuteReader();
                if (dbc.dr1.Read())
                {
                    address = dbc.dr1["varPermanantAddress"].ToString();
                    pin = "NA";
                }
                dbc.con1.Close();
                dbc.dr1.Close();

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
    public void notifications()
    {
        try
        {
            lnkNotifications.Text = dbc.count_tblamnotifications(Session["memberid"].ToString(), "Member").ToString();
            lblcomplet.Attributes.Add("data-percent", dbc.getInActiveGridview(Session["memberid"].ToString()).ToString());
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../register/login.aspx';</script>");

        }
    }

    protected void lnkProceed_Click(object sender, EventArgs e)
    {

        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmdc = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varMemberName,varEmail,varMobile from anuvaa_matrimony.tblammemberregistration where (varMemberId = '" + Session["memberid"].ToString() + "')", dbc.con);
            dbc.con.Open();
            dbc.dr = cmdc.ExecuteReader();
            if (dbc.dr.Read())
            {
                firstname = dbc.dr["varMemberName"].ToString();
                email = dbc.dr["varEmail"].ToString();
                phone = dbc.dr["varMobile"].ToString();
            }
            dbc.con.Close();
            dbc.dr.Close();

            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmdp = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varPackageId, varPackageDescription, varPackageDuration, varPackagePrice, varBenifits, varPackageDurationTime FROM anuvaa_matrimony.tblampackagesdetails  WHERE (varPackageId = '" + packag[0].ToString() + "') and varPackageDuration='" + packag[2].ToString() + "' and varPackageDurationTime='" + packag[3].ToString() + "'", dbc.con);
            dbc.con.Open();
            dbc.dr = cmdp.ExecuteReader();
            if (dbc.dr.Read())
            {
                mypackintid = Convert.ToInt16(dbc.dr["intId"]);
                packageno = dbc.dr["varPackageId"].ToString();
                pname = packag[1].ToString();
                amount = dbc.dr["varPackagePrice"].ToString();
                productinfo = dbc.dr["varPackageDescription"].ToString();
                packageduration = dbc.dr["varPackageDuration"].ToString();
                packagedurationtime = dbc.dr["varPackageDurationTime"].ToString();
            }
            dbc.con.Close();
            dbc.dr.Close();

            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmdpa = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varCountry,varState, varCity FROM anuvaa_matrimony.tblammemberlivingin  WHERE (varMemberId = '" + Session["memberid"].ToString() + "')", dbc.con);
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

            int intid = dbc.max_tblammembertransactions();
            intid = intid + 1;
            MySql.Data.MySqlClient.MySqlCommand cmdo = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblammembertransactions VALUES (" + intid + ",'" + lblOrderNo.Text + "','" + Session["memberid"].ToString() + "','" + firstname + "','" + city + "','','" + state + "','" + packageno + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','" + amount + "','Unpaid','','','NA','Started','','" + mypackintid.ToString() + "')", dbc.con);
            dbc.con.Open();
            cmdo.ExecuteNonQuery();
            dbc.con.Close();
            //Response.Redirect("ccavRequestHandler.aspx?&billing_address=" + address + "&billing_city=" + city + "&billing_state=" + state + "&billing_zip=" + pin + "&billing_country=" + country + "&merchant_id=53386&order_id=" + lblOrderNo.Text + "&currency=INR&amount=" + amount + "&redirect_url=http://swapnpurti.in/Members/Subscription/ccavResponseHandler.aspx&cancel_url=http://swapnpurti.in/Members/Subscription/ccavResponseHandler.aspx&billing_name=" + firstname + "&billing_email=" + email + "&billing_tel=" + phone + "&merchant_param1=" + packageno + "&merchant_param2=" + Session["memberid"].ToString() + "&merchant_param3=" + pname + "&merchant_param4=" + packageduration + "&merchant_param5=" + packagedurationtime + "");
            Response.Redirect("PaymentProcess.aspx?amount=" + amount + "&firstname=" + firstname + "&email=" + email + "&phone=" + phone + "&productinfo=" + packageno + "&udf1=" + lblOrderNo.Text + "&udf2=" + pname + "&udf3=" + packageduration + "&udf4=" + packagedurationtime + "");
            dbc.insert_tblamnotifications("Message", Session["memberid"].ToString(), lblMemberName.Text, "Member", Session["memberid"].ToString(), "Member", "Your Order Transaction is Being in Process...!!!", "", "", "Unread", "");
        }
        catch (Exception ex)
        {


        }
    }
}