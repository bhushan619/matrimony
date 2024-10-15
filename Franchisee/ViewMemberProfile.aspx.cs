using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Franchisee_ViewMemberProfile : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    public static int Id = 0;
    
    public static string memId = string.Empty;
    public static string age = string.Empty;
    public static string gen = string.Empty;
    public static string heightcm = string.Empty;
    
static Uri previousUri;
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
                previousUri = Request.UrlReferrer;
                getMoreDetails();
                getReligiousInfo();
                getFamilyInfo();
                getLifeStyleInfo();
                getProfInfo();
                getPhysicalInfo();
                getLivingInInfo();
                FranchiseeBasicData();
                notifications();
                backLink();
               
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
                //lblMemId.Text = dbc.dr["varMemberId"].ToString();
                memId=dbc.dr["varMemberId"].ToString();
                //lblMemName.Text = dbc.dr["varMemberName"].ToString();
               // lblmembership.Text = dbc.dr["varMemberFor"].ToString();
                lblFullMembership.Text = dbc.dr["varMemberFor"].ToString();
                lblCreatedfor.Text = dbc.dr["varMemberFor"].ToString();
                lblFullId.Text = dbc.dr["varMemberId"].ToString();
                lblFullName.Text = dbc.dr["varMemberName"].ToString();

              
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
               // lblaboutfamily.Text = dbc.dr["varAboutfamily"].ToString();

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
    public void backLink()
    {
        try
        {
            hypLinkBack.NavigateUrl = previousUri.ToString();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Franchisee/Default.aspx");
        }
    }

    //public void getMoreDetails()
    //{
    //    try
    //    {
    //        dbc.con.Open();
    //        //int id = Convert.ToInt32(e.CommandArgument);
    //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT CONCAT(varAgeDate ,' ', varAgeMonth ,' ', varYearMonth ) AS  DOB,   varMaritalStatus ,  varChildrenStatus ,  varChildrenNo ,  varAbout FROM tblammemberinformation WHERE varMemberId='" + Session["memberId"].ToString() + "' ", dbc.con);
    //        dbc.dr = cmd.ExecuteReader();
    //        if (dbc.dr.Read())
    //        {
    //            lblDOB.Text = dbc.dr["DOB"].ToString();
    //            lblMaritalStatus.Text = dbc.dr["varMaritalStatus"].ToString();
    //            if (dbc.dr["varMaritalStatus"].ToString() == "Never Married")
    //            {
    //                MStatusz.Visible = false;
    //            }
    //            lblNoOfChild.Text = dbc.dr["varChildrenNo"].ToString();
    //            lblChildrnStatus.Text = dbc.dr["varChildrenStatus"].ToString();
    //            lblMyself.Text = dbc.dr["varAbout"].ToString();
    //        }
    //        dbc.dr.Dispose();
    //        dbc.con.Close();

    //        dbc.con.Open();
    //        //int id = Convert.ToInt32(e.CommandArgument);
    //        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varMemberName,varPhoto FROM tblammemberregistration WHERE varMemberId='" + Session["memberId"].ToString() + "' ", dbc.con);
    //        dbc.dr = cmd1.ExecuteReader();
    //        if (dbc.dr.Read())
    //        {
    //            lblMemId.Text = dbc.dr["varMemberId"].ToString();
    //            lblMemName.Text = dbc.dr["varMemberName"].ToString();
    //            imgmember.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();
    //        }
    //        dbc.dr.Dispose();
    //        dbc.con.Close();
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
    //public void getReligiousInfo()
    //{
    //    try
    //    {
    //        dbc.con.Open();

    //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varMemberId, varMotherTongue, varReligion, varCasteDivision, varSubcaste, varGotraGothram,  varManglik FROM tblammemberreligiousinfo WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
    //        dbc.dr = cmd.ExecuteReader();
    //        if (dbc.dr.Read())
    //        {
    //            memId = dbc.dr["varMemberId"].ToString();
    //            lblMotherTounge.Text = dbc.dr["varMotherTongue"].ToString();
    //            lblReligion.Text = dbc.dr["varReligion"].ToString();
    //            lblCaste.Text = dbc.dr["varCasteDivision"].ToString();
    //            lblSubcaste.Text = dbc.dr["varSubcaste"].ToString();
    //            lblGotra.Text = dbc.dr["varGotraGothram"].ToString();
    //            lblMangalik.Text = dbc.dr["varManglik"].ToString();

    //        }
    //        dbc.dr.Dispose();
    //        dbc.con.Close();

    //    }
    //    catch (Exception ex)
    //    {
    //        dbc.con.Close();
    //        ScriptManager.RegisterStartupScript(
    //               this,
    //               this.GetType(),
    //               "MessageBox",
    //               "alert('" + ex.Message + "');", true);
    //    }
    //}
    //public void getPhysicalInfo()
    //{
    //    try
    //    {
    //        dbc.con.Open();

    //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId , varHeightFt, varWeight, varBodyType, varComplexion, varBloodGroup,varSpecialCase FROM tblammemberphysicalinformation WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
    //        dbc.dr = cmd.ExecuteReader();
    //        if (dbc.dr.Read())
    //        {
    //            memId = dbc.dr["varMemberId"].ToString();
    //            lblHeight.Text = dbc.dr["varHeightFt"].ToString();
    //            lblWeight.Text = dbc.dr["varWeight"].ToString();
    //            lblBodyType.Text = dbc.dr["varBodyType"].ToString();
    //            lblComplexion.Text = dbc.dr["varComplexion"].ToString();
    //            lblBloodGrp.Text = dbc.dr["varBloodGroup"].ToString();
    //            lblSpecialCase.Text = dbc.dr["varSpecialCase"].ToString();
    //        }
    //        dbc.con.Close();
    //        dbc.dr.Dispose();

    //    }
    //    catch (Exception ex)
    //    {
    //        ScriptManager.RegisterStartupScript(
    //                  this,
    //                  this.GetType(),
    //                  "MessageBox",
    //                  "alert('" + ex.Message + "');", true);
    //        dbc.con.Close();
    //    }

    //}
    //public void getProfInfo()
    //{
    //    try
    //    {
    //        dbc.con.Open();
    //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varEducation, varAdditionalDegree,varEmployeeIn, varOccupation,concat( varAnnualIncome,' ', varIncomeCurrency ) AS Income FROM tblammemberprofessionalinfo WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
    //        dbc.dr = cmd.ExecuteReader();
    //        if (dbc.dr.Read())
    //        {
    //            memId = dbc.dr["varMemberId"].ToString();
    //            lblHighQualific.Text = dbc.dr["varEducation"].ToString();
    //            lblAddDegree.Text = dbc.dr["varAdditionalDegree"].ToString();
    //            lblEmpIn.Text = dbc.dr["varEmployeeIn"].ToString();
    //            lblOccupation.Text = dbc.dr["varOccupation"].ToString();
    //            lblAnnualIncome.Text = dbc.dr["Income"].ToString();
    //        }
    //        dbc.con.Close();
    //        dbc.dr.Dispose();


    //    }
    //    catch (Exception ex)
    //    {
    //        ScriptManager.RegisterStartupScript(
    //                  this,
    //                  this.GetType(),
    //                  "MessageBox",
    //                  "alert('" + ex.Message + "');", true);
    //        dbc.con.Close();
    //    }
    //}
    //public void getLivingInInfo()
    //{
    //    try
    //    {
    //        dbc.con.Open();
    //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varCountry, varCitizenship,varState, varCity FROM tblammemberlivingin WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
    //        dbc.dr = cmd.ExecuteReader();
    //        if (dbc.dr.Read())
    //        {
    //            memId = dbc.dr["varMemberId"].ToString();
    //            lblCountry.Text = dbc.dr["varCountry"].ToString();
    //            lblCitizenship.Text = dbc.dr["varCitizenship"].ToString();
    //            lblState.Text = dbc.dr["varState"].ToString();
    //            lblCity.Text = dbc.dr["varCity"].ToString();
    //        }
    //        dbc.con.Close();
    //        dbc.dr.Dispose();


    //    }
    //    catch (Exception ex)
    //    {
    //        ScriptManager.RegisterStartupScript(
    //                  this,
    //                  this.GetType(),
    //                  "MessageBox",
    //                  "alert('" + ex.Message + "');", true);
    //        dbc.con.Close();
    //    }
    //}

    //public void getFamilyInfo()
    //{
    //    try
    //    {
    //        dbc.con.Open();
    //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varFamilystatus, varFamilytype, varFamilyvalue FROM tblammemberfamily WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
    //        dbc.dr = cmd.ExecuteReader();
    //        if (dbc.dr.Read())
    //        {
    //            memId = dbc.dr["varMemberId"].ToString();
    //            lblFamStatus.Text = dbc.dr["varFamilystatus"].ToString();
    //            lblFamType.Text = dbc.dr["varFamilytype"].ToString();
    //            lblFamValue.Text = dbc.dr["varFamilyvalue"].ToString();

    //        }
    //        dbc.con.Close();
    //        dbc.dr.Dispose();


    //    }
    //    catch (Exception ex)
    //    {
    //        ScriptManager.RegisterStartupScript(
    //                 this,
    //                 this.GetType(),
    //                 "MessageBox",
    //                 "alert('" + ex.Message + "');", true); dbc.con.Close();
    //    }
    //}
    //public void getLifeStyleInfo()
    //{

    //    try
    //    {
    //        dbc.con.Open();
    //        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varEatingHabits, varSmoke, varDrink FROM tblammemberlifestyle WHERE varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
    //        dbc.dr = cmd.ExecuteReader();
    //        if (dbc.dr.Read())
    //        {
    //            memId = dbc.dr["varMemberId"].ToString();
    //            lblEatingHabits.Text = dbc.dr["varEatingHabits"].ToString();
    //            lblSmoke.Text = dbc.dr["varSmoke"].ToString();
    //            lblDrink.Text = dbc.dr["varDrink"].ToString();
    //        }
    //        dbc.con.Close();
    //        dbc.dr.Dispose();


    //    }
    //    catch (Exception ex)
    //    {
    //        ScriptManager.RegisterStartupScript(
    //                  this,
    //                  this.GetType(),
    //                  "MessageBox",
    //                  "alert('" + ex.Message + "');", true);
    //        dbc.con.Close();
    //    }
    //}
}