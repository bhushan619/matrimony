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

public partial class members_UserProfile_ViewProfile : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    DataTable dtq = new DataTable();
    public static int Id = 0;
    public static string memId = string.Empty;
    public static string age = string.Empty;
    public static string gen = string.Empty;
    public static string photo = string.Empty;
    public static string heightcm = string.Empty;
    string reqcount = 0.ToString();
    string msgcount = 0.ToString();
    //static Uri previousUri;

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
               // previousUri = Request.UrlReferrer;
                MemberBasicData();
                getrequestcount();
                getDataMessages();


                getMoreDetails();
                getReligiousInfo();
                getFamilyInfo();
                getLifeStyleInfo();
                getProfInfo();
                getPhysicalInfo();
                getLivingInInfo();
                getSimilarProfiles();
                getViwedProfileDetails();
                getPackage();
                getContactDetails();
                view();
                getMyGalleryData();
                //getGalleryData();
                InterestListview.Visible = false;
                notifications();

                dbc.insert_tblamnotifications("Session", Session["memberid"].ToString(), lblMemberName.Text, "Member", Session["SearchMemberId"].ToString(), "Member", "Your Profile is Recently Viewed By: " + lblMemberName.Text + "", "~/Members/SearchMatches/ViewProfile.aspx", Session["SearchMemberId"].ToString(), "Unread", "");
                lblcountfinalmsg.Text = (Convert.ToInt32(msgcount) + Convert.ToInt32(reqcount)).ToString();
                backLink();
            }
        }
    }
    public void backLink()
    {
        try
        {
            hypLinkBack.NavigateUrl = "~/Members/Activities/Home.aspx";// previousUri.ToString();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Register/Login.aspx");
        }
    }
    public void getGalleryData(string photo)
    {
        try
        {
            DataTable dtg = new DataTable();
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCaption, varUploadPath FROM tblammemberuploads WHERE varMemberId = '" + Session["SearchMemberId"].ToString() + "' and  varUploadType='Photo' and varApproval='Approved'", dbc.con);
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter dta = new MySqlDataAdapter(cmde);

            dta.Fill(dtg);
            if (dtg.Rows.Count == 0)
            {
                dtg.Columns.Add("caption");
                dtg.Columns.Add("photo");
                dtg.Rows.Add("Profile", "Noprofile.jpg");

                lstgallary.DataSource = dtg;
                lstgallary.DataBind();
                // dtg.Rows.Add(imgmember.AlternateText.ToString());
            }
            else
            {
                lstgallary.DataSource = dtg;
                lstgallary.DataBind();
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
    public void getMyGalleryData()
    {
        try
        {
            DataTable dtg = new DataTable();
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCaption, varUploadPath FROM tblammemberuploads WHERE varMemberId = '" + Session["SearchMemberId"].ToString() + "' and  varUploadType='Photo' and varApproval='Approved'", dbc.con);
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter dta = new MySqlDataAdapter(cmde);

            dta.Fill(dtg);
            if (dtg.Rows.Count == 0)
            {
                dtg.Columns.Add("caption");
                dtg.Columns.Add("photo");
                dtg.Rows.Add("Profile", "Noprofile.jpg");

                lstgallary.DataSource = dtg;
                lstgallary.DataBind();
                // dtg.Rows.Add(imgmember.AlternateText.ToString());
            }
            else
            {
                lstgallary.DataSource = dtg;
                lstgallary.DataBind();
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
    public void getRequest(string viewid,string logid,string photo,string protectedphoto)
    {
        
        try
        {
           
                dbc.con.Close();
                MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varFromMemberId, varFromMembarName, varFromMemberStatus, varToMemberId, varToMembarName, varToMemberStatus, varRequestType, varStatus, varDate, varTime FROM tblamrequests where (varFromMemberId = '" + logid + "')and varToMemberId ='" + viewid + "' and varStatus ='Accepted' ", dbc.con);
                dbc.con.Open();
                dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                imgmember.ImageUrl = "~/members/media/" + photo;
                imgmember.Enabled = false;
                getGalleryData(photo);
            }
            else
            {
                imgmember.ImageUrl = "~/members/media/" + protectedphoto;
                imgmember.Enabled = false;
                getGalleryData(protectedphoto);
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
    public void getPackage()
    {
        try
        {

            string dateto = string.Empty;

            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  tblampackages.varPackageName as pkname,varPurchaseDate,tblammembertransactions.ex2 FROM   tblammembertransactions INNER JOIN   tblampackages ON tblammembertransactions.varPackageId = tblampackages.varPackageId WHERE  tblammembertransactions.varMemberId ='" + Session["SearchMemberId"].ToString() + "' and varOrderStatus='Confirmed' ", dbc.con);
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
    public void getMoreDetails()
    {
        try
        {
            dbc.con.Open();
            //int id = Convert.ToInt32(e.CommandArgument);
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT CONCAT(varAgeDate ,' ', varAgeMonth ,' ', varYearMonth ) AS  DOB,varAgeToday ,  varMaritalStatus ,  varChildrenStatus ,  varChildrenNo ,  varAbout FROM tblammemberinformation WHERE varMemberId='" + Session["SearchMemberId"].ToString() + "' ", dbc.con);
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
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varMemberName,varPhoto,varMemberFor,varGender,ex3,varMobile,varEmail,varPhotoApprove FROM tblammemberregistration WHERE varMemberId='" + Session["SearchMemberId"].ToString() + "' and varMemberStatus='Verified' ", dbc.con);
            dbc.dr = cmd1.ExecuteReader();
            if (dbc.dr.Read())
            { 
                lblFullMembership.Text = dbc.dr["varMemberFor"].ToString();
                lblFullId.Text = dbc.dr["varMemberId"].ToString();
                lblFullName.Text = dbc.dr["varMemberName"].ToString();
                lblCreatedfor.Text = dbc.dr["varMemberFor"].ToString();
                lblMobile.Text = dbc.dr["varMobile"].ToString();
                lblEmail.Text = dbc.dr["varEmail"].ToString();
              photo = dbc.dr["varPhoto"].ToString();

              if (dbc.dr["varPhotoApprove"].ToString() == "Approved")
              {
                  gen = dbc.dr["varGender"].ToString();
                  if (gen == "Female")
                  {
                      if (dbc.dr["ex3"].ToString() == "Protected")
                      {

                          int already = dbc.check_already_tblamrequests(Session["SearchMemberId"].ToString(), Session["memberid"].ToString());
                          if (already != 1)
                          {
                              getRequest(Session["SearchMemberId"].ToString(), Session["memberid"].ToString(), photo, "FemaleNoProfileProtected.jpg");
                          }
                          else
                          {
                              imgmember.ImageUrl = "~/members/media/FemaleNoProfileProtected.jpg";
                          }

                      }
                      else if (dbc.dr["ex3"].ToString() == "Hidden")
                      {
                          int already = dbc.check_already_tblamrequests(Session["SearchMemberId"].ToString(), Session["memberid"].ToString());
                          if (already != 1)
                          {
                              getRequest(Session["SearchMemberId"].ToString(), Session["memberid"].ToString(), photo, "FemaleNoProfileProtected.jpg");
                          }
                          else
                          {
                              imgmember.ImageUrl = "~/members/media/FemaleNoProfileProtected.jpg";
                          }
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
                          int already = dbc.check_already_tblamrequests(Session["SearchMemberId"].ToString(), Session["memberid"].ToString());
                          if (already != 1)
                          {
                              getRequest(Session["SearchMemberId"].ToString(), Session["memberid"].ToString(), photo, "MaleNoProfileProtected.jpg");
                          }
                          else
                          {
                              imgmember.ImageUrl = "~/members/media/MaleNoProfileProtected.jpg";
                          }
                      }
                      else if (dbc.dr["ex3"].ToString() == "Hidden")
                      {
                          int already = dbc.check_already_tblamrequests(Session["SearchMemberId"].ToString(), Session["memberid"].ToString());
                          if (already != 1)
                          {
                              getRequest(Session["SearchMemberId"].ToString(), Session["memberid"].ToString(), photo, "MaleNoProfileProtected.jpg");
                          }
                          else
                          {
                              imgmember.ImageUrl = "~/members/media/MaleNoProfileProtected.jpg";
                          }
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
                          int already = dbc.check_already_tblamrequests(Session["SearchMemberId"].ToString(), Session["memberid"].ToString());
                          if (already != 1)
                          {
                              getRequest(Session["SearchMemberId"].ToString(), Session["memberid"].ToString(), photo, "MaleNoProfileProtected.jpg");
                          }
                          else
                          {
                              imgmember.ImageUrl = "~/members/media/MaleNoProfileProtected.jpg";
                          }
                      }
                      else if (dbc.dr["ex3"].ToString() == "Hidden")
                      {
                          int already = dbc.check_already_tblamrequests(Session["SearchMemberId"].ToString(), Session["memberid"].ToString());
                          if (already != 1)
                          {
                              getRequest(Session["SearchMemberId"].ToString(), Session["memberid"].ToString(), photo, "MaleNoProfileProtected.jpg");
                          }
                          else
                          {
                              imgmember.ImageUrl = "~/members/media/MaleNoProfileProtected.jpg";
                          }
                      }
                      else
                      {
                          imgmember.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();
                          imgmember.Enabled = false;
                      }
                  }
              }
              else
              {
                  imgmember.ImageUrl = "~/members/media/NotApproved.jpg";
                  
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

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varMemberId, varMotherTongue, varReligion, varCasteDivision, varSubcaste, varGotraGothram,  varManglik FROM tblammemberreligiousinfo WHERE varMemberId='" + Session["SearchMemberId"].ToString() + "' ", dbc.con);
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
    public void MemberBasicData()
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varMemberName,varGender,varMembershipType,varPhoto,varMemberFor FROM tblammemberregistration WHERE varMemberId='" + Session["memberid"].ToString() + "' and varMemberStatus='Verified' ", dbc.con);
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
    public void getPhysicalInfo()
    {
        try
        {
            dbc.con.Open();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId , varHeightFt, varHeightCm,varWeight, varBodyType, varComplexion, varBloodGroup,varSpecialCase FROM tblammemberphysicalinformation WHERE varMemberId='" + Session["SearchMemberId"].ToString() + "' ", dbc.con);
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
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varEducation, varAdditionalDegree,varEmployeeIn, varOccupation,concat( varAnnualIncome,' ', varIncomeCurrency ) AS Income FROM tblammemberprofessionalinfo WHERE varMemberId='" + Session["SearchMemberId"].ToString() + "' ", dbc.con);
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
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varCountry, varCitizenship,varState, varCity FROM tblammemberlivingin WHERE varMemberId='" + Session["SearchMemberId"].ToString() + "' ", dbc.con);
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
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varFamilystatus, varFamilytype, varFamilyvalue,varAboutfamily FROM tblammemberfamily WHERE varMemberId='" + Session["SearchMemberId"].ToString() + "' ", dbc.con);
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
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varEatingHabits, varSmoke, varDrink FROM tblammemberlifestyle WHERE varMemberId='" + Session["SearchMemberId"].ToString() + "' ", dbc.con);
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
    public void getSimilarProfiles()
    {
        try
        {
            string[] arry = heightcm.Split(new char[] { 'C' });
            string[] gender = dbc.getGender(Session["memberid"].ToString()).Split(new char[] { '\'' });
            int heigthfrom = Convert.ToInt32(arry[0].ToString()) - 6;
            int heigthto = Convert.ToInt32(arry[0].ToString()) + 6;
            int ageFrom = Convert.ToInt32(age) - 3;
            int ageTo = Convert.ToInt32(age) + 3;


            if (gender[1].ToString() == gen)
            {
                string query = "SELECT DISTINCT  tblammemberregistration.varMemberId AS Member,tblammemberregistration.varGender, tblammemberinformation.varAgeToday AS Age, tblammemberreligiousinfo.varReligion AS Religion, tblammemberreligiousinfo.varCasteDivision AS Caste, tblammemberlivingin.varCity AS City, tblammemberprofessionalinfo.varEducation AS Education, tblammemberphysicalinformation.varHeightFt AS Height, tblammemberregistration.varPhoto AS Photo FROM  tblammemberregistration INNER JOIN  tblammemberlivingin ON tblammemberregistration.varMemberId = tblammemberlivingin.varMemberId INNER JOIN tblammemberreligiousinfo ON tblammemberregistration.varMemberId = tblammemberreligiousinfo.varMemberId INNER JOIN    tblammemberinformation ON tblammemberregistration.varMemberId = tblammemberinformation.varMemberId INNER JOIN tblammemberprofessionalinfo ON tblammemberregistration.varMemberId = tblammemberprofessionalinfo.varMemberId INNER JOIN  tblammemberphysicalinformation ON tblammemberregistration.varMemberId = tblammemberphysicalinformation.varMemberId ";
                query = query + " WHERE  (tblammemberregistration.varGender = '" + gen + "')";
                query = query + " AND (CAST(tblammemberinformation.varAgeToday AS UNSIGNED) between CAST(" + ageFrom + " AS UNSIGNED) AND CAST(" + ageTo + " AS UNSIGNED))";
                query = query + " AND (tblammemberreligiousinfo.varReligion = '" + lblReligion.Text + "')";
                query = query + " AND (tblammemberreligiousinfo.varCasteDivision = '" + lblCaste.Text + "')";
                query = query + " AND (tblammemberlivingin.varCity = '" + lblCity.Text + "')";
                //query=query+" AND (tblammemberprofessionalinfo.varEducation = 'Aeronautical Engineering')";
                query = query + " AND  (CAST(tblammemberphysicalinformation.varHeightCm AS UNSIGNED)  between CAST(" + heigthfrom + " AS UNSIGNED) AND CAST(" + heigthto + " AS UNSIGNED))";
                query = query + " AND  (tblammemberregistration.varMemberId != '" + memId + "' and varMemberStatus='Verified') limit 6";
                dbc.con.Open();
                dbc.cmd = new MySqlCommand(query, dbc.con);
                MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(dbc.cmd);
                ad.Fill(dt);
                lstView.DataSource = dt;
                lstView.DataBind();
                dbc.con.Close();
            }
            else
            {

                similar.Visible = false;
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
    protected void OpenProfile(object sender, EventArgs e)
    {
        Session["SearchMemberId"] = (sender as LinkButton).CommandArgument;
        //Response.Redirect("~/members/UserProfile/ViewProfile.aspx");
        Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('ViewProfile.aspx','_blank');", true);
    }

    public void view()
    {
        try
        {
            dbc.insert_tblamemberview(Session["memberid"].ToString(), Session["SearchMemberId"].ToString());
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');window.location='../../register/login.aspx';</script>");
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
          
           // txtMessage.Text.Replace("'", "\'");
           
            String input = txtMessage.Text.Replace("'", "''");
            String pattern = @"(\S*)@\S*\.\S*";
            String result = Regex.Replace(input, pattern, "(Omitted)");

            pattern = @"\d";

            result= Regex.Replace(result, pattern, "x");

            string already = dbc.check_already_msg(Session["memberid"].ToString(), Session["SearchMemberId"].ToString());
            if (already != 0.ToString())
            {
                int idc = dbc.max_tblamconversation();
                idc = idc + 1;
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmdc = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamconversation VALUES (" + idc + ",'" + already + "','" + Session["memberid"].ToString() + "','" + result + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','Unread')", dbc.con);
                cmdc.ExecuteNonQuery();
                dbc.con.Close();
                cmdc.Dispose();
                dbc.insert_tblamnotifications("Page", Session["memberid"].ToString(), lblMemberName.Text, "Member", Session["SearchMemberId"].ToString(), "Member", "New Message from : " + lblMemberName.Text + "", "~/Members/Message/Inbox.aspx", "NA", "Unread", "");

                ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Message Sent Successfully...!!!'); ", true);
            }
            else
            {
                int ok = dbc.insert_message(Session["memberid"].ToString(), "Member", "Unpaid", dbc.get_member_name(Session["memberid"].ToString()), Session["SearchMemberId"].ToString(), "Member", "Unpaid", dbc.get_member_name(Session["SearchMemberId"].ToString()), txtMessage.Text);
                if (ok == 1)
                {
                    dbc.insert_tblamnotifications("Page", Session["memberid"].ToString(), lblMemberName.Text, "Member", Session["SearchMemberId"].ToString(), "Member", "New Message from : " + lblMemberName.Text + "", "~/Members/Message/Inbox.aspx", "NA", "Unread", "");

                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                    "alert('Message Sent Successfully...!!!'); ", true);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Please Enter Correct Member Details');", true);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void lnkInterest_Click(object sender, EventArgs e)
    {
        try
        {
            int already = dbc.check_already_interest(Session["memberid"].ToString(), Session["SearchMemberId"].ToString());
            if (already == 1)
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "MessageBox",
                    "alert('Oops...!!! Interest Already Sent....!!!'); ", true);
            }
            else
            {
                int ok = dbc.insert_tblammemberinterests(Session["memberid"].ToString(), Session["SearchMemberId"].ToString());
                if (ok == 1)
                {
                    dbc.insert_tblamnotifications("Session", Session["memberid"].ToString(), lblMemberName.Text, "Member", Session["SearchMemberId"].ToString(), "Member", "New Interest from : " + lblMemberName.Text + "", "~/Members/SearchMatches/ViewProfile.aspx", Session["SearchMemberId"].ToString(), "Unread", "");
                    sendmail(Session["memberid"].ToString(), Session["SearchMemberId"].ToString(),"Interest");
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Interest Sent Successfully...!!!'); ", true);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Some Problem Please try again later...!!!');", true);
                }
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void lnkShortlist_Click(object sender, EventArgs e)
    {
        try
        {
            int already = dbc.check_already_Shortlist(Session["memberid"].ToString(), Session["SearchMemberId"].ToString());
            if (already == 1)
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "MessageBox",
                 "alert('Oops...!!! Member Already Shortlisted...!!!'); ", true);
            }
            else
            {
                int ok = dbc.insert_tblammembershortlist(Session["memberid"].ToString(), Session["SearchMemberId"].ToString());
                if (ok == 1)
                {
                    dbc.insert_tblamnotifications("Session", Session["memberid"].ToString(), lblMemberName.Text, "Member", Session["SearchMemberId"].ToString(), "Member", "You are Shortlisted by : " + lblMemberName.Text + "", "~/Members/SearchMatches/ViewProfile.aspx", Session["SearchMemberId"].ToString(), "Unread", "");
                    sendmail(Session["memberid"].ToString(), Session["SearchMemberId"].ToString(), "Shortlist");
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Member Shortlisted Successfully...!!!'); ", true);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Some Problem Please try again later...!!!');", true);
                }
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void imgmember_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            int already = dbc.check_already_tblamrequests(Session["memberid"].ToString(), Session["SearchMemberId"].ToString());
            if (already == 1)
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "MessageBox",
                   "alert('Oops...!!! Request Already Sent...!!!'); ", true);
            }
            else
            {
                int ok = dbc.insert_tblamrequests(Session["memberid"].ToString(), Session["SearchMemberId"].ToString());
                if (ok == 1)
                {
                    dbc.insert_tblamnotifications("Session", Session["memberid"].ToString(), lblMemberName.Text, "Member", Session["SearchMemberId"].ToString(), "Member", "Photo Request from : " + lblMemberName.Text + "", "~/Members/SearchMatches/ViewProfile.aspx", Session["SearchMemberId"].ToString(), "Unread", "");
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Request Sent Successfully...!!!'); ", true);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Some Problem Please try again later...!!!');", true);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    public string listviewData(ListView gv)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gv.RenderControl(htw);

        return sb.ToString();
    }

    //public void getViwedProfileDetails()
    //{
    //    try{
    //    string query = "SELECT   tblammemberregistration.varMemberId AS Member,tblammemberregistration.varMemberName AS Name, tblammemberregistration.varEmail AS Email,(SELECT varEmailCode FROM tblammemberemailcode WHERE varMemberId= tblammemberregistration.varMemberId) as cde , tblammemberregistration.varGender, tblammemberinformation.varAgeToday AS Age, tblammemberreligiousinfo.varReligion AS Religion, tblammemberreligiousinfo.varCasteDivision AS Caste, tblammemberlivingin.varCity AS City,tblammemberlivingin.varstate AS State,tblammemberlivingin.varCountry AS Country, tblammemberprofessionalinfo.varEducation AS Education, tblammemberphysicalinformation.varHeightFt AS Height, tblammemberregistration.varPhoto AS Photo,tblammemberprofessionalinfo.varOccupation as Occupation FROM  tblammemberregistration INNER JOIN  tblammemberlivingin ON tblammemberregistration.varMemberId = tblammemberlivingin.varMemberId INNER JOIN tblammemberreligiousinfo ON tblammemberregistration.varMemberId = tblammemberreligiousinfo.varMemberId INNER JOIN    tblammemberinformation ON tblammemberregistration.varMemberId = tblammemberinformation.varMemberId INNER JOIN tblammemberprofessionalinfo ON tblammemberregistration.varMemberId = tblammemberprofessionalinfo.varMemberId INNER JOIN  tblammemberphysicalinformation ON tblammemberregistration.varMemberId = tblammemberphysicalinformation.varMemberId ";
    //    query = query + " WHERE  (tblammemberregistration.varMemberId  ='" + Session["memberid"].ToString() + "' and varMemberStatus='Verified') and (tblammemberregistration.varGender = '" + gen + "')";
    //    dbc.con.Open();
    //    dbc.cmd = new MySqlCommand(query, dbc.con);
    //    MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(dbc.cmd);
    //    ad.Fill(dt);

    //    lstviewedProfile.DataSource = dt;
    //    lstviewedProfile.DataBind();
    //    dbc.con.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        ScriptManager.RegisterStartupScript(
    //               this,
    //               this.GetType(),
    //               "MessageBox",
    //               "alert('" + ex.Message + "');", true);
    //    }
    //}
    public void getViwedProfileDetails()
    {
        try
        {

            string query = "SELECT   tblammemberregistration.varMemberId AS Member,tblammemberregistration.varMemberName AS Name, tblammemberregistration.varEmail AS Email,(SELECT varEmailCode FROM tblammemberemailcode WHERE varMemberId= tblammemberregistration.varMemberId) as cde , tblammemberregistration.varGender, tblammemberinformation.varAgeToday AS Age, tblammemberreligiousinfo.varReligion AS Religion, tblammemberreligiousinfo.varCasteDivision AS Caste, tblammemberlivingin.varCity AS City,tblammemberlivingin.varstate AS State,tblammemberlivingin.varCountry AS Country, tblammemberprofessionalinfo.varEducation AS Education, tblammemberphysicalinformation.varHeightFt AS Height, tblammemberregistration.varPhoto AS Photo,tblammemberprofessionalinfo.varOccupation as Occupation FROM  tblammemberregistration INNER JOIN  tblammemberlivingin ON tblammemberregistration.varMemberId = tblammemberlivingin.varMemberId INNER JOIN tblammemberreligiousinfo ON tblammemberregistration.varMemberId = tblammemberreligiousinfo.varMemberId INNER JOIN    tblammemberinformation ON tblammemberregistration.varMemberId = tblammemberinformation.varMemberId INNER JOIN tblammemberprofessionalinfo ON tblammemberregistration.varMemberId = tblammemberprofessionalinfo.varMemberId INNER JOIN  tblammemberphysicalinformation ON tblammemberregistration.varMemberId = tblammemberphysicalinformation.varMemberId ";
            query = query + " WHERE  (tblammemberregistration.varMemberId  ='" + Session["memberid"].ToString() + "' and varMemberStatus='Verified')";
            dbc.con.Open();
            dbc.cmd = new MySqlCommand(query, dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(dbc.cmd);
            ad.Fill(dt);

            lstviewedProfile.DataSource = dt;
            lstviewedProfile.DataBind();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                         "alert('Some Problem Please try again later...!!!');", true);
        }
    }
    public override void VerifyRenderingInServerForm(Control GridView)
    {
        /* Verifies that the control is rendered */
    }
    private string PopulateBody(string memid, string mname, string iname, string imemid, string arg)
    {
        string body = string.Empty;
        string path1 = string.Empty;
        if (arg == "Interest")
        {
            path1 = "~/Admin/emails/Interest.html";
        }
        else if (arg == "Shortlist")
        {
            path1 = "~/Admin/emails/Shortlist.html";
        }
        using (StreamReader reader = new StreamReader(Server.MapPath(path1)))
        {
            body = reader.ReadToEnd();
        }
        string datenow = DateTimeOffset.UtcNow.LocalDateTime.ToLongDateString();
        body = body.Replace("{mname}", mname);
        body = body.Replace("{memid}", Session["memberid"].ToString());
        body = body.Replace("{imemid}", Session["SearchMemberId"].ToString());
        body = body.Replace("{iname}", iname);
        body = body.Replace("{date}", datenow);
        body = body.Replace("{grid}", listviewData(lstviewedProfile));
        body = body.Replace("{viewProfile}", "http://swapnpurti.in/Admin/SubMemberLogin.aspx?mid=" + Session["memberid"].ToString() + "&eml=" + dbc.get_member_Email(Session["SearchMemberId"].ToString()) + "&cde=" + dbc.get_member_EmailCode(Session["SearchMemberId"].ToString()) + "&for=ViewMember&from=Member");
        //body = body.Replace("{age}", lblfullage.Text);
       // body = body.Replace("{date}", );
        //body = body.Replace("{trans}", trans);
        //body = body.Replace("{order}", order);
        //body = body.Replace("{pname}", pname);
        //body = body.Replace("{amt}", amt);
        return body;
    }
    protected void sendmail(string memid, string imemid,string arg)
    {
        try
        {  dbc.con.Open();
                string m_name = dbc.get_member_name(Session["memberid"].ToString());
                string i_name = dbc.get_member_name(Session["SearchMemberId"].ToString());
                string email = dbc.get_member_Email(Session["SearchMemberId"].ToString());
                dbc.con.Close();
                using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(email)))
                {
                    if (arg == "Interest")
                    {
                        mm.Subject = "Swapnpurti Matrimony : Interested In You !!!";
                        mm.Body = PopulateBody(memid, m_name, i_name, email, "Interest");
                    }
                    else if (arg == "Shortlist")
                    {
                        mm.Subject = "Swapnpurti Matrimony : Shortlisted You !!!";
                        mm.Body = PopulateBody(memid, m_name, i_name, email, "Shortlist");
                    }
                    mm.IsBodyHtml = true;

                System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient();
                // for server

                SmtpServer.Host = "relay-hosting.secureserver.net";
                SmtpServer.EnableSsl = false;
                //for server
                SmtpServer.Port = 25;


                //for local 

                //SmtpServer.Host = "smtp.gmail.com";
                //SmtpServer.EnableSsl = true;

                //SmtpServer.Port = 587;


                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                NetworkCredential NetworkCred = new NetworkCredential("swapnpurtimatrimony@gmail.com", "anuvaa2015");
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = NetworkCred;

                SmtpServer.Send(mm);


            }
        }
        catch (Exception rx)
        {
            //ScriptManager.RegisterStartupScript(
            //             this,
            //             this.GetType(),
            //             "MessageBox",
            //              "alert('not sent');", true);

        }
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        try
        {
            string dateto = string.Empty;
            if (btnView.Text == "View Contact Details")
            {
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varPurchaseDate,tblammembertransactions.ex2 FROM   tblammembertransactions INNER JOIN   tblampackages ON tblammembertransactions.varPackageId = tblampackages.varPackageId WHERE  tblammembertransactions.varMemberId ='" + Session["memberid"].ToString() + "'  and varOrderStatus='Confirmed' ", dbc.con);
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


                            if (dbc.count_tblmembercontactviewscountView(Session["memberid"].ToString()) == 0)
                            {
                                ScriptManager.RegisterStartupScript(
                                        this,
                                        this.GetType(),
                                        "MessageBox",
                                        "alert('Please upgrade to view details...!!!');", true);
                            }
                            else if (Convert.ToInt32(dbc.dr1["ex1"].ToString()) == dbc.count_tblmembercontactviewscountView(Session["memberid"].ToString()))
                            {
                                forPaidMember.Visible = true;
                                btnView.Text = "Hide contact Details";
                                dbc.update_tblmembercontactviewscountView(Session["memberid"].ToString(), 1.ToString());
                            }
                            else if (Convert.ToInt32(dbc.dr1["ex1"].ToString()) > dbc.count_tblmembercontactviewscountView(Session["memberid"].ToString()))
                            {
                                forPaidMember.Visible = true;
                                btnView.Text = "Hide contact Details";
                                dbc.update_tblmembercontactviewscountView(Session["memberid"].ToString(), 1.ToString());
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(
                                    this,
                                    this.GetType(),
                                    "MessageBox",
                                   "alert('Please upgrade to view details...!!!');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(
                                this,
                                this.GetType(),
                                "MessageBox",
                               "alert('Please upgrade to view details...!!!');", true);
                    }
                    dbc.con1.Close();
                    dbc.dr1.Dispose();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(
                            this,
                            this.GetType(),
                            "MessageBox",
                           "alert('Please upgrade to view details...!!!');", true);
                }
                dbc.con.Close();
                dbc.dr.Dispose();

            }
            else
            {
                btnView.Text = "View Contact Details";
                forPaidMember.Visible = false;
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void getContactDetails()
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberAlternateMobile1,varParentMobile, varPermanantAddress FROM tblammembercontactdetails WHERE varMemberId ='" + Session["SearchMemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblAddress.Text = dbc.dr["varMemberAlternateMobile1"].ToString();
               
            }
            
            dbc.con.Close();
            dbc.dr.Dispose();

            //dbc.con.Close();
            //dbc.con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmda = new MySql.Data.MySqlClient.MySqlCommand("SELECT varPermanantAddress FROM tblammembercontactdetails WHERE varMemberId ='" + Session["memberid"].ToString() + "' ", dbc.con);
            //dbc.dr = cmda.ExecuteReader();
            //if (dbc.dr.Read())
            //{

            //}

            //dbc.con.Close();
            //dbc.dr.Dispose();

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