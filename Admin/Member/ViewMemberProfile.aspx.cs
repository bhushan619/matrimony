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
using System.IO;

public partial class Admin_ViewMemberProfile : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    public static int  Id=0;
    public static string  memId = string.Empty;
    string[] ids;
    static string packageno = string.Empty;
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
               // ids = Session["MemberIdandpackid"].ToString().Split(new char[] { ';' });
                AdminBasicData();
                notifications(); 
                getMoreDetails();
                getReligiousInfo();
                getFamilyInfo();
                getLifeStyleInfo();
                getProfInfo();
                getPhysicalInfo();
                getLivingInInfo();
                getContactDetails();
               // getTransactionDetails();
                
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
    public void getContactDetails()
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varPermanantAddress ,varAlternateAddress, varMemberAlternateMobile1,varMemberAlternateEmail1, varParentMobile, varParentLandline FROM tblammembercontactdetails WHERE varMemberId ='" +Session["MemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblpAddress.Text = dbc.dr["varPermanantAddress"].ToString();
                lblAAddress.Text = dbc.dr["varAlternateAddress"].ToString();
               // lblaltemailmem.Text = dbc.dr["varAlternateAddress"].ToString();
               lblaltmbmem.Text = dbc.dr["varMemberAlternateMobile1"].ToString();
               lblaltemailmem.Text = dbc.dr["varMemberAlternateEmail1"].ToString();
               lblpmb.Text = dbc.dr["varParentMobile"].ToString();
              lblpland.Text  = dbc.dr["varParentLandline"].ToString();
              
               
            }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(
            //           this,
            //           this.GetType(),
            //           "MessageBox",
            //           "alert('Contact Details Not Found');", true);
            //}
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
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT CONCAT(varAgeDate ,' ', varAgeMonth ,' ', varYearMonth ) AS  DOB,  varMaritalStatus ,  varChildrenStatus ,  varChildrenNo ,  varAbout FROM tblammemberinformation WHERE varMemberId='" +Session["MemberId"].ToString() + "' ", dbc.con);
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
              
            }
            dbc.dr.Dispose();
            dbc.con.Close();

            dbc.con.Open();
            //int id = Convert.ToInt32(e.CommandArgument);
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varMemberName,varPhoto,varMobile, varEmail FROM tblammemberregistration WHERE varMemberId='" +Session["MemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd1.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblFullId.Text = dbc.dr["varMemberId"].ToString();
                lblFullName.Text = dbc.dr["varMemberName"].ToString();  
                lblMobile.Text = dbc.dr["varMobile"].ToString();
                lblEmail.Text = dbc.dr["varEmail"].ToString(); 
                imgmember.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();
                     
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
            dbc.con.Close();
        } 
    }
    public void getReligiousInfo()
    {
        try
        {
            dbc.con.Open();
            
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varMemberId, varMotherTongue, varReligion, varCasteDivision, varSubcaste, varGotraGothram,  varManglik FROM tblammemberreligiousinfo WHERE varMemberId='" +Session["MemberId"].ToString()+ "' ", dbc.con);
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
            dbc.con.Close();
        }
    }
    public void getPhysicalInfo()
    {
        try
        {
              dbc.con.Open();

              MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId , varHeightFt, varWeight, varBodyType, varComplexion, varBloodGroup,varSpecialCase FROM tblammemberphysicalinformation WHERE varMemberId='" +Session["MemberId"].ToString() + "' ", dbc.con);
                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                { 
                    memId = dbc.dr["varMemberId"].ToString();
                    lblHeight.Text = dbc.dr["varHeightFt"].ToString();
                    lblWeight.Text = dbc.dr["varWeight"].ToString();
                    lblBodyType.Text = dbc.dr["varBodyType"].ToString();
                    lblComplexion.Text = dbc.dr["varComplexion"].ToString();
                    lblBloodGrp.Text = dbc.dr["varBloodGroup"].ToString();
                    lblSpecialCase.Text = dbc.dr["varSpecialCase"].ToString();
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
            dbc.con.Close();
        }

    }
    public void getProfInfo()
    {
        try
        {
               dbc.con.Open();
               MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varEducation, varAdditionalDegree,varEmployeeIn, varOccupation,concat( varAnnualIncome,' ', varIncomeCurrency ) AS Income FROM tblammemberprofessionalinfo WHERE varMemberId='" +Session["MemberId"].ToString() + "' ", dbc.con);
                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    memId = dbc.dr["varMemberId"].ToString();
                    lblHighQualific.Text = dbc.dr["varEducation"].ToString();
                    lblAddDegree.Text = dbc.dr["varAdditionalDegree"].ToString();
                    lblEmpIn.Text = dbc.dr["varEmployeeIn"].ToString();
                    lblOccupation.Text = dbc.dr["varOccupation"].ToString();
                    lblAnnualIncome.Text = dbc.dr["Income"].ToString();
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
            dbc.con.Close();
        }
    }
    public void getLivingInInfo()
    {
        try
        {
           dbc.con.Open();
           MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varCountry, varCitizenship,varState, varCity FROM tblammemberlivingin WHERE varMemberId='" +Session["MemberId"].ToString() + "' ", dbc.con);
                dbc.dr = cmd.ExecuteReader();
                if (dbc.dr.Read())
                {
                    memId = dbc.dr["varMemberId"].ToString();
                    lblCountry.Text = dbc.dr["varCountry"].ToString();
                    lblCitizenship.Text = dbc.dr["varCitizenship"].ToString();
                    lblState.Text = dbc.dr["varState"].ToString();
                    lblCity.Text = dbc.dr["varCity"].ToString();
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
            dbc.con.Close();
        }
    }

    public void getFamilyInfo()
    {
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varFamilystatus, varFamilytype, varFamilyvalue FROM tblammemberfamily WHERE varMemberId='" +Session["MemberId"].ToString() + "' ", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                memId = dbc.dr["varMemberId"].ToString();
                lblFamStatus.Text = dbc.dr["varFamilystatus"].ToString();
                lblFamType.Text = dbc.dr["varFamilytype"].ToString();
                lblFamValue.Text = dbc.dr["varFamilyvalue"].ToString();
              
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
            dbc.con.Close();
        }
    }
    public void getLifeStyleInfo()
    {
     
        try
        {
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varEatingHabits, varSmoke, varDrink FROM tblammemberlifestyle WHERE varMemberId='" +Session["MemberId"].ToString() + "' ", dbc.con);
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
            dbc.con.Close();
        }
    }



    protected void btndownloadbio_Click(object sender, EventArgs e)
    {
        string filePath=string.Empty;
        dbc.con.Close();
        dbc.con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varUploadPath FROM tblammemberuploads WHERE varUploadType='Biodata' and  varMemberId='" + Session["MemberId"].ToString() + "' ", dbc.con);
        dbc.dr = cmd1.ExecuteReader();
        if (dbc.dr.Read())
        {
            filePath = Server.MapPath("~/members/media/biodata/") + dbc.dr["varUploadPath"].ToString();
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filePath);
            Response.WriteFile(filePath);
            Response.End();
        }
        else
        {
            //filePath = "Not Available";
            ScriptManager.RegisterStartupScript(
                      this,
                      this.GetType(),
                      "MessageBox",
                      "alert('Sorry ,Biodata Not Available');", true);
        }
        dbc.con.Close(); dbc.dr.Dispose();
        // filePath = (sender as LinkButton).CommandArgument;
      
    }
}