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
using System.Globalization;
using System.Text.RegularExpressions;

public partial class Members_SearchMatches_Default : System.Web.UI.Page
{
  
    string[] ids;
    static string packageno = string.Empty;
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    public static int Id = 0;
    public static string memId = string.Empty;
    public static string age = string.Empty;
    public static string gen = string.Empty;
    public static string heightcm = string.Empty;
    string reqcount = 0.ToString();
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
        {
            if (!IsPostBack)
            {
                MemberBasicData();

                getMoreDetails();
                getReligiousInfo();
                getFamilyInfo();
                getLifeStyleInfo();
                getProfInfo();
                getPhysicalInfo();
                getLivingInInfo();
                //getSimilarProfiles();

                getPackage();
                getContactDetails();
                view();
                InterestListview.Visible = false;
                getrequestcount();
                getDataMessages();
                lblcountfinalmsg.Text = (Convert.ToInt32(msgcount) + Convert.ToInt32(reqcount)).ToString();
                notifications();
                getTransactionDetails();

            }
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
    public void getPackage()
    {
        try
        {

            string dateto = string.Empty;

            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  tblampackages.varPackageName as pkname,varPurchaseDate,tblammembertransactions.ex2 FROM   tblammembertransactions INNER JOIN   tblampackages ON tblammembertransactions.varPackageId = tblampackages.varPackageId WHERE  tblammembertransactions.varMemberId ='" + Session["memberid"].ToString() + "' and varOrderStatus='Confirmed' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                dbc.con1.Open();
                MySql.Data.MySqlClient.MySqlCommand cmds = new MySql.Data.MySqlClient.MySqlCommand("SELECT varPackageDuration, varPackageDurationTime, ex1 FROM tblampackagesdetails WHERE intId=" + Convert.ToInt32(dbc.dr["ex2"].ToString()) + "", dbc.con1);
                dbc.dr1 = cmds.ExecuteReader();
                if (dbc.dr1.Read())
                {
                    string dur = dbc.dr1["varPackageDurationTime"].ToString();
                    if (dur == "Month")
                    {
                        dateto = DateTime.ParseExact(dbc.dr["varPurchaseDate"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).AddMonths(Convert.ToInt32(dbc.dr1["varPackageDuration"].ToString())).ToString();
                    }
                    else if (dur == "Year")
                    {
                        dateto = DateTime.ParseExact(dbc.dr["varPurchaseDate"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).AddYears(Convert.ToInt32(dbc.dr1["varPackageDuration"].ToString())).ToString();
                    }
                    else if (dur == "Days")
                    {
                        dateto = DateTime.ParseExact(dbc.dr["varPurchaseDate"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).AddDays(Convert.ToInt32(dbc.dr1["varPackageDuration"].ToString())).ToString();
                    }
                    string chkDate = dbc.dr["varPurchaseDate"].ToString();
                    DateTime start = Convert.ToDateTime(chkDate);
                    DateTime end = Convert.ToDateTime(dateto);
                    DateTime now = DateTime.UtcNow;

                    if ((now > start) && (now < end))
                    {
                        lblPackageName.Text = dbc.dr["pkname"].ToString();
                    }
                    else
                    {
                        lblPackageName.Text = string.Empty;
                    }

                    dbc.con1.Close();
                    dbc.dr1.Dispose();
                }
                else
                {
                    lblPackageName.Text = string.Empty;
                }
                dbc.con.Close();
                dbc.dr.Dispose();

            }
            else
            {
                lblPackageName.Text = string.Empty;
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
    public void getContactDetails()
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varPermanantAddress FROM tblammembercontactdetails WHERE varMemberId ='" + Session["MemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblAddress.Text = dbc.dr["varPermanantAddress"].ToString(); 
            }
            
            dbc.con.Close();
            dbc.dr.Dispose();

            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("SELECT varPermanantAddress FROM tblammembercontactdetails WHERE varMemberId ='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.dr = cmda.ExecuteReader();
            if (dbc.dr.Read())
            {

            }

            dbc.con.Close();
            dbc.dr.Dispose();

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

    public void getMoreDetails()
    {
        try
        {
            dbc.con.Open();
            //int id = Convert.ToInt32(e.CommandArgument);
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT CONCAT(varAgeDate ,' ', varAgeMonth ,' ', varYearMonth ) AS  DOB,varAgeToday ,  varMaritalStatus ,  varChildrenStatus ,  varChildrenNo ,  varAbout FROM tblammemberinformation WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblDOB.Text = dbc.dr["DOB"].ToString();
                lblMaritalStatus.Text = dbc.dr["varMaritalStatus"].ToString();
                if (dbc.dr["varMaritalStatus"].ToString() == "Never Married")
                {
                    MStatusz.Visible = false;
                }
                lblNoOfChild.Text = dbc.dr["varChildrenNo"].ToString();
                lblChildrnStatus.Text = dbc.dr["varChildrenStatus"].ToString();
                lblMyself.Text = dbc.dr["varAbout"].ToString();

                age = dbc.dr["varAgeToday"].ToString();

                lblfullage.Text = dbc.dr["varAgeToday"].ToString();
            }
            dbc.dr.Dispose();
            dbc.con.Close();

            dbc.con.Open();
            //int id = Convert.ToInt32(e.CommandArgument);
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varMemberName,varPhoto,varMemberFor,varGender,ex3,varMobile,varEmail FROM tblammemberregistration WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd1.ExecuteReader();
            if (dbc.dr.Read())
            {
                 
                lblFullMembership.Text = dbc.dr["varMemberFor"].ToString();
                lblCreatedfor.Text = dbc.dr["varMemberFor"].ToString();
                lblFullId.Text = dbc.dr["varMemberId"].ToString();
                lblFullName.Text = dbc.dr["varMemberName"].ToString();

                lblMobile.Text = dbc.dr["varMobile"].ToString();
                lblEmail.Text = dbc.dr["varEmail"].ToString();

                gen = dbc.dr["varGender"].ToString();
                if (gen == "Female")
                {
                    if (dbc.dr["ex3"].ToString() == "Protected")
                    {
                        imgmember.ImageUrl = "~/members/media/FemaleNoProfileProtected.jpg";
                    }
                    else if (dbc.dr["ex3"].ToString() == "Hidden")
                    {
                        imgmember.ImageUrl = "~/members/media/FemaleNoProfileProtected.jpg";
                    }
                    else
                    {
                        imgmember.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();
                        imgmember.Enabled = false;
                    }
                }
                if (gen == "Male")
                {
                    if (dbc.dr["ex3"].ToString() == "Protected")
                    {
                        imgmember.ImageUrl = "~/members/media/MaleNoProfileProtected.jpg";
                    }
                    else if (dbc.dr["ex3"].ToString() == "Hidden")
                    {
                        imgmember.ImageUrl = "~/members/media/MaleNoProfileProtected.jpg";
                    }
                    else
                    {
                        imgmember.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();
                        imgmember.Enabled = false;
                    }
                }
                if (gen == "Other")
                {
                    if (dbc.dr["ex3"].ToString() == "Protected")
                    {
                        imgmember.ImageUrl = "~/members/media/MaleNoProfileProtected.jpg";
                    }
                    else if (dbc.dr["ex3"].ToString() == "Hidden")
                    {
                        imgmember.ImageUrl = "~/members/media/MaleNoProfileProtected.jpg";
                    }
                    else
                    {
                        imgmember.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();
                        imgmember.Enabled = false;
                    }
                }
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
        }
    }
    public void getReligiousInfo()
    {
        try
        {
            dbc.con.Open();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varMemberId, varMotherTongue, varReligion, varCasteDivision, varSubcaste, varGotraGothram,  varManglik FROM tblammemberreligiousinfo WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                memId = dbc.dr["varMemberId"].ToString();
                lblMotherTounge.Text = dbc.dr["varMotherTongue"].ToString();
                lblReligion.Text = dbc.dr["varReligion"].ToString();
                lblCaste.Text = dbc.dr["varCasteDivision"].ToString();
                lblSubcaste.Text = dbc.dr["varSubcaste"].ToString();
                lblGotra.Text = dbc.dr["varGotraGothram"].ToString();
                lblMangalik.Text = dbc.dr["varManglik"].ToString();
                lblfullReligion.Text = dbc.dr["varReligion"].ToString();
                lblfullcaste.Text = dbc.dr["varCasteDivision"].ToString();
                lblFullSubcaste.Text = dbc.dr["varSubcaste"].ToString();

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
        }
    }
    public void getPhysicalInfo()
    {
        try
        {
            dbc.con.Open();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId , varHeightFt, varHeightCm,varWeight, varBodyType, varComplexion, varBloodGroup,varSpecialCase FROM tblammemberphysicalinformation WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                memId = dbc.dr["varMemberId"].ToString();
                lblHeight.Text = dbc.dr["varHeightFt"].ToString();

                heightcm = dbc.dr["varHeightCm"].ToString();
                lblWeight.Text = dbc.dr["varWeight"].ToString();
                lblBodyType.Text = dbc.dr["varBodyType"].ToString();
                lblComplexion.Text = dbc.dr["varComplexion"].ToString();
                lblBloodGrp.Text = dbc.dr["varBloodGroup"].ToString();
                lblSpecialCase.Text = dbc.dr["varSpecialCase"].ToString();

                lblFullHeight.Text = dbc.dr["varHeightFt"].ToString();
            }
            dbc.con.Close();
            dbc.dr.Dispose();

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
    public void getProfInfo()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varEducation, varAdditionalDegree,varEmployeeIn, varOccupation,concat( varAnnualIncome,' ', varIncomeCurrency ) AS Income FROM tblammemberprofessionalinfo WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                memId = dbc.dr["varMemberId"].ToString();
                lblHighQualific.Text = dbc.dr["varEducation"].ToString();
                lblAddDegree.Text = dbc.dr["varAdditionalDegree"].ToString();
                lblEmpIn.Text = dbc.dr["varEmployeeIn"].ToString();
                lblOccupation.Text = dbc.dr["varOccupation"].ToString();
                lblAnnualIncome.Text = dbc.dr["Income"].ToString();
                lblFullEducation.Text = dbc.dr["varEducation"].ToString();
                lblfullProfession.Text = dbc.dr["varOccupation"].ToString();
                lblFullanualincome.Text = dbc.dr["Income"].ToString();
            }
            dbc.con.Close();
            dbc.dr.Dispose();


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
    public void getLivingInInfo()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varCountry, varCitizenship,varState, varCity FROM tblammemberlivingin WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                memId = dbc.dr["varMemberId"].ToString();
                lblCountry.Text = dbc.dr["varCountry"].ToString();
                lblCitizenship.Text = dbc.dr["varCitizenship"].ToString();
                lblState.Text = dbc.dr["varState"].ToString();
                lblCity.Text = dbc.dr["varCity"].ToString();
                lblFullstate.Text = dbc.dr["varState"].ToString();
                lblFullcity.Text = dbc.dr["varCity"].ToString();
            }
            dbc.con.Close();
            dbc.dr.Dispose();
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

    public void getFamilyInfo()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varFamilystatus, varFamilytype, varFamilyvalue,varAboutfamily FROM tblammemberfamily WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                memId = dbc.dr["varMemberId"].ToString();
                lblFamStatus.Text = dbc.dr["varFamilystatus"].ToString();
                lblFamType.Text = dbc.dr["varFamilytype"].ToString();
                lblFamValue.Text = dbc.dr["varFamilyvalue"].ToString();
                lblaboutfamily.Text = dbc.dr["varAboutfamily"].ToString();

            }
            dbc.con.Close();
            dbc.dr.Dispose();


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
    public void getLifeStyleInfo()
    {

        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varEatingHabits, varSmoke, varDrink FROM tblammemberlifestyle WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                memId = dbc.dr["varMemberId"].ToString();
                lblEatingHabits.Text = dbc.dr["varEatingHabits"].ToString();
                lblSmoke.Text = dbc.dr["varSmoke"].ToString();
                lblDrink.Text = dbc.dr["varDrink"].ToString();
            }
            dbc.con.Close();
            dbc.dr.Dispose();


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
    
    protected void OpenProfile(object sender, EventArgs e)
    {
        Session["MemberId"] = (sender as LinkButton).CommandArgument;
        //Response.Redirect("~/members/UserProfile/ViewProfile.aspx");
        Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('ViewProfile.aspx','_blank');", true);
    }

    public void view()
    {
        try
        {
            dbc.insert_tblamemberview(Session["memberid"].ToString(), Session["MemberId"].ToString());
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../register/login.aspx';</script>");
        }
    }
   
  
   
    public override void VerifyRenderingInServerForm(Control GridView)
    {
        /* Verifies that the control is rendered */
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
    public void getTransactionDetails()
    {

        try
        {

            dbc.con1.Close();
            dbc.con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT  tblampackages.varPackageName as pkname,varPurchaseDate,tblammembertransactions.ex2 FROM   tblammembertransactions INNER JOIN   tblampackages ON tblammembertransactions.varPackageId = tblampackages.varPackageId WHERE  tblammembertransactions.varMemberId ='" + Session["memberid"].ToString() + "' and varOrderStatus='Confirmed' ", dbc.con1);
            dbc.dr1 = cmd1.ExecuteReader();
            if (dbc.dr1.Read())
            {

                dbc.con.Close();//SELECT varOrderNovarPackageIdvarPurchaseDatevarPaymentAmountvarPaymentStatusvarTransactionId FROM tblammembertransactions WHERE   varMemberId ='" + ids[0].ToString() + "'and ex2='" + ids[1].ToString() + "' 
                MySql.Data.MySqlClient.MySqlCommand cmdp = new MySql.Data.MySqlClient.MySqlCommand("SELECT varPackageId, varPackageDescription, varPackageDuration, varPackagePrice, varBenifits, varPackageDurationTime FROM anuvaa_matrimony.tblampackagesdetails  WHERE (intId = '" + Convert.ToInt32(dbc.dr1["ex2"].ToString()) + "') ", dbc.con);
                dbc.con.Open();
                dbc.dr = cmdp.ExecuteReader();
                if (dbc.dr.Read())
                {
                    packageno = dbc.dr["varPackageId"].ToString();

                    Packamt.Text = dbc.dr["varPackagePrice"].ToString();
                    packbenefit.Text = dbc.dr["varPackageDescription"].ToString();
                    PackDuration.Text = dbc.dr["varPackageDuration"].ToString() + " " + dbc.dr["varPackageDurationTime"].ToString();

                }
                packName.Text = dbc.get_tblampackagesname(packageno);
                dbc.con.Close();
                dbc.dr.Close();


                dbc.con.Close();//SELECT varOrderNo,varPackageId,varPurchaseDate,varPaymentAmount,varPaymentStatus,varTransactionId FROM tblammembertransactions WHERE   varMemberId ='" + ids[0].ToString() + "'and ex2='" + ids[1].ToString() + "' 
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varOrderNo,varPackageId,varPurchaseDate,varPaymentAmount,varPaymentStatus,varPaymode,varTransactionId FROM anuvaa_matrimony.tblammembertransactions WHERE   varMemberId ='" + Session["memberid"].ToString() + "' and tblammembertransactions.varPaymentStatus='Paid'  ", dbc.con3);
                dbc.con3.Open();
                dbc.dr2 = cmd.ExecuteReader();
                if (dbc.dr2.Read())
                {
                    // mystr.Text = dbc.dr1["varOrderNo"].ToString() + "_" +  dbc.dr1["varPurchaseDate"].ToString() + "_" + dbc.dr1["varPaymentAmount"].ToString() + "_" + dbc.dr1["varPaymentStatus"].ToString() + "_" + dbc.dr1["varTransactionId"].ToString();

                    lblmydate.Text = dbc.dr2["varPurchaseDate"].ToString();
                    lblmyOrder.Text = dbc.dr2["varOrderNo"].ToString();
                    lblmytran.Text = dbc.dr2["varTransactionId"].ToString();
                    lblmyamt.Text = dbc.dr2["varPaymentAmount"].ToString();
                    lblmypaymode.Text = dbc.dr2["varPaymode"].ToString();

                }
                dbc.con3.Close();
                dbc.dr2.Close();

            }
            dbc.con1.Close();
            dbc.dr1.Close();
        }
        catch (Exception ex)
        {
            //ScriptManager.RegisterStartupScript(
            //          this,
            //          this.GetType(),
            //          "MessageBox",
            //          "alert('" + ex.Message + "');", true);
            dbc.con.Close();
        }
    }
}