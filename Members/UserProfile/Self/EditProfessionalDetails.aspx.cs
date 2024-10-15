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

public partial class members_UserProfile_Self_EditProfessionalDetails : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
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
        else  if (!IsPostBack)
        {
            MemberBasicData();
            getdata();
           // dropDisable();
           
            getrequestcount();
            getDataMessages();
            lblcountfinalmsg.Text = (Convert.ToInt32(msgcount) + Convert.ToInt32(reqcount)).ToString(); 
            notifications();
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
    public void getdata()
    {
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varEducation,varAdditionalDegree,varEmployeeIn,varOccupation,varAnnualIncome,varIncomeCurrency,varCollegeOrInstitution,varEducationDetail,varOccupationDetail,varExperience,varExperienceIn from anuvaa_matrimony.tblammemberprofessionalinfo where varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                ddlQualification.Text = dbc.dr["varEducation"].ToString();
                txtAdditional.Text = dbc.dr["varAdditionalDegree"].ToString();
              
                ddlOccupation.Text = dbc.dr["varOccupation"].ToString();
                txtAnnualIncome.Text = dbc.dr["varAnnualIncome"].ToString();
                ddlCurrency.Text = dbc.dr["varIncomeCurrency"].ToString();

                txtCollege.Text = dbc.dr["varCollegeOrInstitution"].ToString();
                txtEducationDetails.Text = dbc.dr["varEducationDetail"].ToString();
                txtOccupation.Text = dbc.dr["varOccupationDetail"].ToString();
                txtWorkExperience.Text = dbc.dr["varExperience"].ToString();
                ddlexperiance.Text = dbc.dr["varExperienceIn"].ToString();
string empin = dbc.dr["varEmployeeIn"].ToString();
ddlEmployeeIn.Text = empin.ToString();
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
    protected void btnProfessionSave_Click(object sender, EventArgs e)
    {
        try
        {
            txtEducationDetails.Text.Replace("'", "\'");
            int insert_ok = dbc.update_tblammemberprofessionalinfo(Session["memberid"].ToString(), ddlQualification.Text, txtAdditional.Text, txtCollege.Text, txtEducationDetails.Text, ddlEmployeeIn.Text, ddlOccupation.Text, txtOccupation.Text, txtAnnualIncome.Text, ddlCurrency.Text, txtWorkExperience.Text,ddlexperiance.Text);

            if (insert_ok == 1)
            {
                //clear();
                ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('Professional Details Updated Successfully...!!!');window.location='EditProfessionalDetails.aspx';", true);
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
    public void dropDisable()
    {
        try
        {
            ListItem[] li = new ListItem[50];
            li[0] = ddlQualification.Items.FindByValue("--Any Bachelors in Engineering/Computers--");
            li[1] = ddlQualification.Items.FindByValue("--Any Masters in Engineering/Computers--");
            li[2] = ddlQualification.Items.FindByValue("--Any Bachelors in Arts/Science/Commerce--");
            li[3] = ddlQualification.Items.FindByValue("--AnyMastersinArts/Science/Commerce--");
            li[4] = ddlQualification.Items.FindByValue("--AnyBachelorsinManagement--");
            li[5] = ddlQualification.Items.FindByValue("--AnyMastersinManagement--");
            li[6] = ddlQualification.Items.FindByValue("--AnyBachelorsinMedicineinGeneral/Dental/Surgeon--");
            li[7] = ddlQualification.Items.FindByValue("--AnyMastersinMedicine-General/Dental/Surgeon--");
            li[8] = ddlQualification.Items.FindByValue("--AnyBachelorsinLegal--");
            li[9] = ddlQualification.Items.FindByValue("--AnyMastersinLegal--");
            li[10] = ddlQualification.Items.FindByValue("--AnyFinancialQualification-ICWAI/CA/CS/CFA--");
            li[11] = ddlQualification.Items.FindByValue("--Service-IAS/IPS/IRS/IES/IFS--");
            li[12] = ddlQualification.Items.FindByValue("--Ph.D.--");
            li[13] = ddlQualification.Items.FindByValue("--AnyDiploma--");
            li[14] = ddlQualification.Items.FindByValue("--HigherSecondary/Secondary--");
            //.........................Occupation
            li[15] = ddlOccupation.Items.FindByValue("--ADMIN--");
            li[16] = ddlOccupation.Items.FindByValue("--AGRICULTURE--");
            li[17] = ddlOccupation.Items.FindByValue("--AIRLINE--");
            li[18] = ddlOccupation.Items.FindByValue("--ARCHITECT&DESIGN--");
            li[19] = ddlOccupation.Items.FindByValue("--BANKING&FINANCE--");
            li[20] = ddlOccupation.Items.FindByValue("--BEAUTY&FASHION--");
            li[21] = ddlOccupation.Items.FindByValue("--CIVILSERVICES--");
            li[22] = ddlOccupation.Items.FindByValue("--DEFENCE--");
            li[23] = ddlOccupation.Items.FindByValue("--EDUCATION--");
            li[24] = ddlOccupation.Items.FindByValue("--HOSPITALITY--");
            li[25] = ddlOccupation.Items.FindByValue("--IT&ENGINEERING--");
            li[26] = ddlOccupation.Items.FindByValue("--LEGAL--");
            li[27] = ddlOccupation.Items.FindByValue("--LAWENFORCEMENT--");
            li[28] = ddlOccupation.Items.FindByValue("--MEDICAL--");
            li[29] = ddlOccupation.Items.FindByValue("--MARKETING&SALES--");
            li[30] = ddlOccupation.Items.FindByValue("--MEDIA&ENTERTAINMENT--");
            li[31] = ddlOccupation.Items.FindByValue("--SCIENTIST--");
            li[32] = ddlOccupation.Items.FindByValue("--TOPMANAGEMENT--");
            li[33] = ddlOccupation.Items.FindByValue("--OTHERS--");
           
            for (int j = 0; j <= li.Length; j++)
            {
                li[j].Attributes.Add("style", "color:#CC3300;");
                li[j].Attributes.Add("disabled", "true");
                li[j].Value = "-1";
            }
        }
        catch (Exception ex)
        {
        }
    }
   
}