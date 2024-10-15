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
public partial class members_UserProfile_MyProfile : System.Web.UI.Page
{

    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    public static int Id = 0;
    public static string memId = string.Empty;
    public static string age = string.Empty;
    public static string gen = string.Empty;
    public static string heightcm = string.Empty;

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
                notifications();
                getMoreDetails();
                getReligiousInfo();
                getFamilyInfo();
                getLifeStyleInfo();
                getProfInfo();
                getPhysicalInfo();
                getLivingInInfo();
                
                getPackage();
              
                MemberBasicData();
                InterestListview.Visible = false;

            }
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblamnotifications(Session["memberid"].ToString(), "Member").ToString();
    }
    public void getPackage()
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT    tblammembertransactions.varMemberId, tblampackages.varPackageName FROM   tblammembertransactions INNER JOIN   tblampackages ON tblammembertransactions.varPackageId = tblampackages.varPackageId WHERE  tblammembertransactions.varMemberId ='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblPackageName.Text = dbc.dr["varPackageName"].ToString();
            }
            dbc.con.Close();
            dbc.dr.Dispose();

            dbc.con.Close();
            dbc.con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT    tblammembertransactions.varMemberId, tblampackages.varPackageName FROM   tblammembertransactions INNER JOIN   tblampackages ON tblammembertransactions.varPackageId = tblampackages.varPackageId WHERE  tblammembertransactions.varMemberId ='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                getContactDetails();
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
    public void getContactDetails()
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varPermanantAddress FROM tblammembercontactdetails WHERE varMemberId ='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblAddress.Text = dbc.dr["varPermanantAddress"].ToString();
                forPaidMember.Visible = true;
            }
            else
            {
                forPaidMember.Visible = false;
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
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT CONCAT(varAgeDate ,' ', varAgeMonth ,' ', varYearMonth ) AS  DOB,varAgeToday ,  varMaritalStatus ,  varChildrenStatus ,  varChildrenNo ,  varAbout FROM tblammemberinformation WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
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
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varMemberName,varPhoto,varMemberFor,varGender,ex3,varMobile,varEmail FROM tblammemberregistration WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.dr = cmd1.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblFullMembership.Text = dbc.dr["varMemberFor"].ToString();
                lblFullId.Text = dbc.dr["varMemberId"].ToString();
                lblFullName.Text = dbc.dr["varMemberName"].ToString();
                lblCreatedfor.Text = dbc.dr["varMemberFor"].ToString();
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

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varMemberId, varMotherTongue, varReligion, varCasteDivision, varSubcaste, varGotraGothram,  varManglik FROM tblammemberreligiousinfo WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
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
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varMemberName,varGender,varMembershipType,varPhoto,varMemberFor FROM tblammemberregistration WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
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

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId , varHeightFt, varHeightCm,varWeight, varBodyType, varComplexion, varBloodGroup,varSpecialCase FROM tblammemberphysicalinformation WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
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
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varEducation, varAdditionalDegree,varEmployeeIn, varOccupation,concat( varAnnualIncome,' ', varIncomeCurrency ) AS Income FROM tblammemberprofessionalinfo WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
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
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varCountry, varCitizenship,varState, varCity FROM tblammemberlivingin WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
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
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varFamilystatus, varFamilytype, varFamilyvalue,varAboutfamily FROM tblammemberfamily WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
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
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varEatingHabits, varSmoke, varDrink FROM tblammemberlifestyle WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
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
     public string listviewData(ListView gv)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gv.RenderControl(htw);

        return sb.ToString();
    }
       
    public override void VerifyRenderingInServerForm(Control GridView)
    {
        /* Verifies that the control is rendered */
    }
   
}