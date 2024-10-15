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
using System.Text.RegularExpressions;

public partial class members_UserProfile_Self_EditFamilyDetails : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    string Familystatus = string.Empty;
    string Familytype = string.Empty;
    string Familyvalue = string.Empty;
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
        {    //   varFatherOccupation, varMotherName, varMotherOccupation, varNoOfBrother, varBrotherMarried, varNoOfSister, varSisterMarried, varLiveWithParent,
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varFatherName,varFatherOccupation,varMotherName,varMotherOccupation,varNoOfBrother,varBrotherMarried,varNoOfSister,varSisterMarried,varLiveWithParent,varFamilystatus,varFamilytype,varFamilyvalue,varAboutfamily from anuvaa_matrimony.tblammemberfamily where varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (dbc.dr["varLiveWithParent"].ToString() == "Yes")
                {
                    rgbPYes.Checked = true;
                }
                else if (dbc.dr["varLiveWithParent"].ToString() == "No")
                {
                    rgbPNo.Checked = true;
                }
                //.................
                if (dbc.dr["varFamilystatus"].ToString() == "Middle class")
                {
                    rgbMiddleClass.Checked = true;
                }
                else if (dbc.dr["varFamilystatus"].ToString() == "Upper middle class")
                {
                    rgbUppermiddle.Checked = true;
                }
                else if (dbc.dr["varFamilystatus"].ToString() == "Rich")
                {
                    rgbRich.Checked = true;
                }
                else if (dbc.dr["varFamilystatus"].ToString() == "Affluent")
                {
                    rgbAffluent.Checked = true;
                }
                //...................complexsion
                if (dbc.dr["varFamilytype"].ToString() == "Joint")
                {
                    rgbJoint.Checked = true;
                }
                else if (dbc.dr["varFamilytype"].ToString() == "Nuclear")
                {
                    rgbNuclear.Checked = true;
                }
                else if (dbc.dr["varFamilytype"].ToString() == "Other")
                {
                    rgbOther.Checked = true;
                }
               
                //////////////////////////fvalue
                string famvalue = dbc.dr["varFamilyvalue"].ToString();
              
                 if (famvalue == "Traditional")
                {
                    rgbTraditional.Checked = true;
                }
                else if (famvalue == "Moderate")
                {
                    rgbModerate.Checked = true;
                }
                else if (famvalue == "Liberal")
                {
                    rgbLiberal.Checked = true;
                } 
                else if (famvalue == "Orthodox")
                {
                    rgbOrthodox.Checked = true;
                }

                txtAboutFamily.Text = dbc.dr["varAboutfamily"].ToString();
                txtFatherName.Text = dbc.dr["varFatherName"].ToString();
                txtMotherName.Text = dbc.dr["varMotherName"].ToString();
                ddlFatherOccupation.Text = dbc.dr["varFatherOccupation"].ToString();
                ddlMotherOccupation.Text = dbc.dr["varMotherOccupation"].ToString();
                ddlBrother.Text = dbc.dr["varNoOfBrother"].ToString();
                ddlBrotherMarried.Text = dbc.dr["varBrotherMarried"].ToString();
                ddlSister.Text = dbc.dr["varNoOfSister"].ToString();
                ddlSisterMarried.Text = dbc.dr["varSisterMarried"].ToString();
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
    protected void btnFamilySave_Click(object sender, EventArgs e)
    {
        try
        {    ///////////////////////////////////Familystatus
            if (rgbMiddleClass.Checked)
            {
                Familystatus = rgbMiddleClass.Text;
            }
            else if (rgbUppermiddle.Checked)
            {
                Familystatus = rgbUppermiddle.Text;
            }
            else if (rgbRich.Checked)
            {
                Familystatus = rgbRich.Text;
            }
            else if (rgbAffluent.Checked)
            {
                Familystatus = rgbAffluent.Text;
            }
            ///////////////////////////////////FamilyType
            if (rgbJoint.Checked)
            {
                Familytype = rgbJoint.Text;
            }
            else if (rgbNuclear.Checked)
            {
                Familytype = rgbNuclear.Text;
            }
            else if (rgbOther.Checked)
            {
                Familytype = rgbOther.Text;
            }
            ///////////////////////////////////Familyvalue
            if (rgbOrthodox.Checked)
            {
                Familyvalue = rgbOrthodox.Text;
            }
            else if (rgbTraditional.Checked)
            {
                Familyvalue = rgbTraditional.Text;
            }
            else if (rgbModerate.Checked)
            {
                Familyvalue = rgbModerate.Text;
            }
            else if (rgbLiberal.Checked)
            {
                Familyvalue = rgbLiberal.Text;
            }
            if (rgbPYes.Checked)
            {
                living = rgbPYes.Text;
            }
            else if (rgbPNo.Checked)
            {
                living = rgbPNo.Text;
            }

            String input = txtAboutFamily.Text.Replace("'", "''");
            String pattern = @"(\S*)@\S*\.\S*";
            String result = Regex.Replace(input, pattern, "(Omitted)");

            pattern = @"\d";

            result = Regex.Replace(result, pattern, "x");

            int insert_ok = dbc.update_tblammemberfamily(Session["memberid"].ToString(),txtFatherName.Text,ddlFatherOccupation.Text,txtMotherName.Text,ddlMotherOccupation.Text,ddlBrother.Text,ddlBrotherMarried.Text,ddlSister.Text,ddlSisterMarried.Text,living,Familystatus,Familytype,Familyvalue,result);

            if (insert_ok == 1)
            {
                // clear();
                ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('Family Details Updated Successfully...!!!');window.location='EditFamilyDetails.aspx';", true);
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
    public void dropDisable()
    {
        try
        {
            ListItem[] li = new ListItem[50];
            li[1] = ddlFatherOccupation.Items.FindByValue("--ADMIN--");
            li[2] = ddlFatherOccupation.Items.FindByValue("--AGRICULTURE--");
            li[3] = ddlFatherOccupation.Items.FindByValue("--AIRLINE--");
            li[4] = ddlFatherOccupation.Items.FindByValue("--ARCHITECT&DESIGN--");
            li[5] = ddlFatherOccupation.Items.FindByValue("--BANKING&FINANCE--");
            li[6] = ddlFatherOccupation.Items.FindByValue("--BEAUTY&FASHION--");
            li[7] = ddlFatherOccupation.Items.FindByValue("--CIVILSERVICES--");
            li[8] = ddlFatherOccupation.Items.FindByValue("--DEFENCE--");
            li[9] = ddlFatherOccupation.Items.FindByValue("--EDUCATION--");
            li[10] = ddlFatherOccupation.Items.FindByValue("--HOSPITALITY--");
            li[11] = ddlFatherOccupation.Items.FindByValue("--IT&ENGINEERING--");
            li[12] = ddlFatherOccupation.Items.FindByValue("--LEGAL--");
            li[13] = ddlFatherOccupation.Items.FindByValue("--LAWENFORCEMENT--");
            li[14] = ddlFatherOccupation.Items.FindByValue("--MEDICAL--");
            li[15] = ddlFatherOccupation.Items.FindByValue("--MARKETING&SALES--");
            li[16] = ddlFatherOccupation.Items.FindByValue("--MEDIA&ENTERTAINMENT--");
            li[17] = ddlFatherOccupation.Items.FindByValue("--SCIENTIST--");
            li[18] = ddlFatherOccupation.Items.FindByValue("--TOPMANAGEMENT--");
            li[19] = ddlFatherOccupation.Items.FindByValue("--OTHERS--");
            //.........................Occupation
         
            li[20] = ddlMotherOccupation.Items.FindByValue("--BEAUTY&FASHION--");
            li[21] = ddlMotherOccupation.Items.FindByValue("--CIVILSERVICES--");
            li[22] = ddlMotherOccupation.Items.FindByValue("--DEFENCE--");
            li[23] = ddlMotherOccupation.Items.FindByValue("--EDUCATION--");
            li[24] = ddlMotherOccupation.Items.FindByValue("--HOSPITALITY--");
            li[25] = ddlMotherOccupation.Items.FindByValue("--IT&ENGINEERING--");
            li[26] = ddlMotherOccupation.Items.FindByValue("--LEGAL--");
            li[27] = ddlMotherOccupation.Items.FindByValue("--LAWENFORCEMENT--");
            li[28] = ddlMotherOccupation.Items.FindByValue("--MEDICAL--");
            li[29] = ddlMotherOccupation.Items.FindByValue("--MARKETING&SALES--");
            li[30] = ddlMotherOccupation.Items.FindByValue("--MEDIA&ENTERTAINMENT--");
            li[31] = ddlMotherOccupation.Items.FindByValue("--SCIENTIST--");
            li[32] = ddlMotherOccupation.Items.FindByValue("--TOPMANAGEMENT--");
            li[33] = ddlMotherOccupation.Items.FindByValue("--OTHERS--");

            li[34] = ddlMotherOccupation.Items.FindByValue("--ADMIN--");
            li[35] = ddlMotherOccupation.Items.FindByValue("--AGRICULTURE--");
            li[36] = ddlMotherOccupation.Items.FindByValue("--AIRLINE--");
            li[37] = ddlMotherOccupation.Items.FindByValue("--ARCHITECT&DESIGN--");
            li[38] = ddlMotherOccupation.Items.FindByValue("--BANKING&FINANCE--");

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
}