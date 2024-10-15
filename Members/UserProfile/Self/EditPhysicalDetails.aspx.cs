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

public partial class members_UserProfile_Self_EditPhysicalDetails : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
     string BodyType = string.Empty;
  string Complexion = string.Empty;
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
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varHeightFt,varHeightCm,varWeight,varBodyType,varComplexion,varBloodGroup,varSpecialCase,varWeightlbs from anuvaa_matrimony.tblammemberphysicalinformation where varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                ddlHeighFtIn.Text = dbc.dr["varHeightFt"].ToString();
                ddlHeightCms.Text = dbc.dr["varHeightCm"].ToString();
                ddlWeight.Text = dbc.dr["varWeight"].ToString();
                ddlWeightLbs.Text = dbc.dr["varWeightlbs"].ToString();
                ddlBloodgroup.Text = dbc.dr["varBloodGroup"].ToString();
                ddlSpecialCase.Text = dbc.dr["varSpecialCase"].ToString();
                if (dbc.dr["varBodyType"].ToString() == "Slim")
                {
                    rgbBTSlim.Checked = true;
                }
                else if (dbc.dr["varBodyType"].ToString() == "Average")
                {
                    rgbBTAverage.Checked = true;
                }
                else if (dbc.dr["varBodyType"].ToString() == "Athletic")
                {
                    rgbBTAthletic.Checked = true;
                }
                else if (dbc.dr["varBodyType"].ToString() == "Heavy")
                {
                    rgbBTHeavy.Checked = true;
                }
                //...................complexsion
                if (dbc.dr["varComplexion"].ToString() == "Fair")
                {
                    rgbFair.Checked = true;
                }
                else if (dbc.dr["varComplexion"].ToString() == "Wheatish")
                {
                    rgbWheatish.Checked = true;
                }
                else if (dbc.dr["varComplexion"].ToString() == "Very Fair")
                {
                    rgbVeryFair.Checked = true;
                }
                else if (dbc.dr["varComplexion"].ToString() == "Wheatish Medium")
                {
                    rgbWheatishMedium.Checked = true;
                }
                else if (dbc.dr["varComplexion"].ToString() == "Dark")
                {
                    rgbDark.Checked = true;
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
    protected void btnPhysicalSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (rgbBTAthletic.Checked)
            {
                BodyType = rgbBTAthletic.Text;
            }
            else if (rgbBTAverage.Checked)
            {
                BodyType = rgbBTAverage.Text;
            }
            else if (rgbBTHeavy.Checked)
            {
                BodyType = rgbBTHeavy.Text;
            }
            else if (rgbBTSlim.Checked)
            {
                BodyType = rgbBTSlim.Text;
            }
            ///////////////////////////////////Complexion
            if (rgbFair.Checked)
            {
                Complexion = rgbFair.Text;
            }
            else if (rgbVeryFair.Checked)
            {
                Complexion = rgbVeryFair.Text;
            }
            else if (rgbWheatish.Checked)
            {
                Complexion = rgbWheatish.Text;
            }
            else if (rgbWheatishMedium.Checked)
            {
                Complexion = rgbWheatishMedium.Text;
            }
            else if (rgbDark.Checked)
            {
                Complexion = rgbDark.Text;
            }//varHeightFt, varHeightCm, varWeight, varBodyType, varComplexion, varBloodGroup, varSpecialCase, ex1 FROM tblammemberphysicalinformation
            int insert_ok = dbc.update_tblammemberphysicalinformation(Session["memberid"].ToString(), ddlHeighFtIn.Text, ddlHeightCms.Text, ddlWeight.Text, BodyType, Complexion, ddlBloodgroup.Text, ddlSpecialCase.Text);

            if (insert_ok == 1)
            {
                //clear();
                ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('Physical Details Updated Successfully...!!!');window.location='EditPhysicalDetails.aspx';", true);
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
    protected void ddlHeighFtIn_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlHeighFtIn.Text == "4ft 6in")
        {
            ddlHeightCms.Text = "137Cms";
        }
        else if (ddlHeighFtIn.Text == "4ft 7in")
        {
            ddlHeightCms.Text = "140Cms";
        }
        else if (ddlHeighFtIn.Text == "4ft 8in")
        {
            ddlHeightCms.Text = "142Cms";
        }
        else if (ddlHeighFtIn.Text == "4ft 9in")
        {
            ddlHeightCms.Text = "145Cms";
        }
        else if (ddlHeighFtIn.Text == "4ft 10in")
        {
            ddlHeightCms.Text = "147Cms";
        }
        else if (ddlHeighFtIn.Text == "4ft 11in")
        {
            ddlHeightCms.Text = "150Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft")
        {
            ddlHeightCms.Text = "152Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 1in")
        {
            ddlHeightCms.Text = "155Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 2in")
        {
            ddlHeightCms.Text = "157Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 3in")
        {
            ddlHeightCms.Text = "160Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 4in")
        {
            ddlHeightCms.Text = "162Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 5in")
        {
            ddlHeightCms.Text = "165Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 6in")
        {
            ddlHeightCms.Text = "167Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 7in")
        {
            ddlHeightCms.Text = "170Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 8in")
        {
            ddlHeightCms.Text = "172Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 9in")
        {
            ddlHeightCms.Text = "175Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 10in")
        {
            ddlHeightCms.Text = "177Cms";
        }
        else if (ddlHeighFtIn.Text == "5ft 11in")
        {
            ddlHeightCms.Text = "180Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft")
        {
            ddlHeightCms.Text = "183Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 1in")
        {
            ddlHeightCms.Text = "185Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 2in")
        {
            ddlHeightCms.Text = "188Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 3in")
        {
            ddlHeightCms.Text = "190Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 4in")
        {
            ddlHeightCms.Text = "193Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 5in")
        {
            ddlHeightCms.Text = "195Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 6in")
        {
            ddlHeightCms.Text = "198Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 7in")
        {
            ddlHeightCms.Text = "201Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 8in")
        {
            ddlHeightCms.Text = "203Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 9in")
        {
            ddlHeightCms.Text = "206Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 10in")
        {
            ddlHeightCms.Text = "208Cms";
        }
        else if (ddlHeighFtIn.Text == "6ft 11in")
        {
            ddlHeightCms.Text = "211Cms";
        }
        else if (ddlHeighFtIn.Text == "7ft")
        {
            ddlHeightCms.Text = "213Cms";
        }
    }
    protected void ddlHeightCms_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHeightCms.Text == "137Cms")
        {
            ddlHeighFtIn.Text = "4ft 6in";
        }
        else if (ddlHeightCms.Text == "138Cms")
        {
            ddlHeighFtIn.Text = "4ft 6in";
        }
        else if (ddlHeightCms.Text == "139Cms")
        {
            ddlHeighFtIn.Text = "4ft 7in";
        }
        else if (ddlHeightCms.Text == "140Cms")
        {
            ddlHeighFtIn.Text = "4ft 7in";
        }
        else if (ddlHeightCms.Text == "141Cms")
        {
            ddlHeighFtIn.Text = "4ft 8in";
        }
        else if (ddlHeightCms.Text == "142Cms")
        {
            ddlHeighFtIn.Text = "4ft 8in";
        }
        else if (ddlHeightCms.Text == "143Cms")
        {
            ddlHeighFtIn.Text = "4ft 8in";
        }
        else if (ddlHeightCms.Text == "144Cms")
        {
            ddlHeighFtIn.Text = "4ft 9in";
        }
        else if (ddlHeightCms.Text == "145Cms")
        {
            ddlHeighFtIn.Text = "4ft 9in";
        }
        else if (ddlHeightCms.Text == "146Cms")
        {
            ddlHeighFtIn.Text = "4ft 9in";
        }
        else if (ddlHeightCms.Text == "147Cms")
        {
            ddlHeighFtIn.Text = "4ft 10in";
        }
        else if (ddlHeightCms.Text == "148Cms")
        {
            ddlHeighFtIn.Text = "4ft 10in";
        }
        else if (ddlHeightCms.Text == "149Cms")
        {
            ddlHeighFtIn.Text = "4ft 11in";
        }
        else if (ddlHeightCms.Text == "150Cms")
        {
            ddlHeighFtIn.Text = "4ft 11in";
        }
        else if (ddlHeightCms.Text == "151Cms")
        {
            ddlHeighFtIn.Text = "4ft 11in";
        }
        else if (ddlHeightCms.Text == "152Cms")
        {
            ddlHeighFtIn.Text = "5ft";
        }
        else if (ddlHeightCms.Text == "153Cms")
        {
            ddlHeighFtIn.Text = "5ft";
        }
        else if (ddlHeightCms.Text == "154Cms")
        {
            ddlHeighFtIn.Text = "5ft 1in";
        }
        else if (ddlHeightCms.Text == "155Cms")
        {
            ddlHeighFtIn.Text = "5ft 1in";
        }
        else if (ddlHeightCms.Text == "156Cms")
        {
            ddlHeighFtIn.Text = "5ft 1in";
        }
        else if (ddlHeightCms.Text == "157Cms")
        {
            ddlHeighFtIn.Text = "5ft 2in";
        }
        else if (ddlHeightCms.Text == "158Cms")
        {
            ddlHeighFtIn.Text = "5ft 2in";
        }
        else if (ddlHeightCms.Text == "159Cms")
        {
            ddlHeighFtIn.Text = "5ft 3in";
        }
        else if (ddlHeightCms.Text == "160Cms")
        {
            ddlHeighFtIn.Text = "5ft 3in";
        }
        else if (ddlHeightCms.Text == "161Cms")
        {
            ddlHeighFtIn.Text = "5ft 3in";
        }
        else if (ddlHeightCms.Text == "162Cms")
        {
            ddlHeighFtIn.Text = "5ft 4in";
        }
        else if (ddlHeightCms.Text == "163Cms")
        {
            ddlHeighFtIn.Text = "5ft 4in";
        }
        else if (ddlHeightCms.Text == "164Cms")
        {
            ddlHeighFtIn.Text = "5ft 5in";
        }
        else if (ddlHeightCms.Text == "165Cms")
        {
            ddlHeighFtIn.Text = "5ft 5in";
        }
        else if (ddlHeightCms.Text == "166Cms")
        {
            ddlHeighFtIn.Text = "5ft 5in";
        }
        else if (ddlHeightCms.Text == "167Cms")
        {
            ddlHeighFtIn.Text = "5ft 6in";
        }
        else if (ddlHeightCms.Text == "168Cms")
        {
            ddlHeighFtIn.Text = "5ft 6in";
        }
        else if (ddlHeightCms.Text == "169Cms")
        {
            ddlHeighFtIn.Text = "5ft 6in";
        }
        else if (ddlHeightCms.Text == "170Cms")
        {
            ddlHeighFtIn.Text = "5ft 7in";
        }
        else if (ddlHeightCms.Text == "171Cms")
        {
            ddlHeighFtIn.Text = "5ft 7in";
        }
        else if (ddlHeightCms.Text == "172Cms")
        {
            ddlHeighFtIn.Text = "5ft 8in";
        }
        else if (ddlHeightCms.Text == "173Cms")
        {
            ddlHeighFtIn.Text = "5ft 8in";
        }
        else if (ddlHeightCms.Text == "174Cms")
        {
            ddlHeighFtIn.Text = "5ft 9in";
        }
        else if (ddlHeightCms.Text == "175Cms")
        {
            ddlHeighFtIn.Text = "5ft 9in";
        }
        else if (ddlHeightCms.Text == "176Cms")
        {
            ddlHeighFtIn.Text = "5ft 9in";
        }
        else if (ddlHeightCms.Text == "177Cms")
        {
            ddlHeighFtIn.Text = "5ft 10in";
        }
        else if (ddlHeightCms.Text == "178Cms")
        {
            ddlHeighFtIn.Text = "5ft 10in";
        }
        else if (ddlHeightCms.Text == "179Cms")
        {
            ddlHeighFtIn.Text = "5ft 10in";
        }
        else if (ddlHeightCms.Text == "180Cms")
        {
            ddlHeighFtIn.Text = "5ft 11in";
        }
        else if (ddlHeightCms.Text == "181Cms")
        {
            ddlHeighFtIn.Text = "5ft 11in";
        }
        else if (ddlHeightCms.Text == "182Cms")
        {
            ddlHeighFtIn.Text = "6ft";
        }
        else if (ddlHeightCms.Text == "183Cms")
        {
            ddlHeighFtIn.Text = "6ft";
        }
        else if (ddlHeightCms.Text == "184Cms")
        {
            ddlHeighFtIn.Text = "6ft";
        }
        else if (ddlHeightCms.Text == "185Cms")
        {
            ddlHeighFtIn.Text = "6ft 1in";
        }
        else if (ddlHeightCms.Text == "186Cms")
        {
            ddlHeighFtIn.Text = "6ft 1in";
        }
        else if (ddlHeightCms.Text == "187Cms")
        {
            ddlHeighFtIn.Text = "6ft 2in";
        }
        else if (ddlHeightCms.Text == "188Cms")
        {
            ddlHeighFtIn.Text = "6ft 2in";
        }
        else if (ddlHeightCms.Text == "189Cms")
        {
            ddlHeighFtIn.Text = "6ft 2in";
        }
        else if (ddlHeightCms.Text == "190Cms")
        {
            ddlHeighFtIn.Text = "6ft 3in";
        }
        else if (ddlHeightCms.Text == "190Cms")
        {
            ddlHeighFtIn.Text = "6ft 3in";
        }
        else if (ddlHeightCms.Text == "191Cms")
        {
            ddlHeighFtIn.Text = "6ft 3in";
        }
        else if (ddlHeightCms.Text == "192Cms")
        {
            ddlHeighFtIn.Text = "6ft 4in";
        }
        else if (ddlHeightCms.Text == "193Cms")
        {
            ddlHeighFtIn.Text = "6ft 4in";
        }
        else if (ddlHeightCms.Text == "194Cms")
        {
            ddlHeighFtIn.Text = "6ft 5in";
        }
        else if (ddlHeightCms.Text == "195Cms")
        {
            ddlHeighFtIn.Text = "6ft 5in";
        }
        else if (ddlHeightCms.Text == "196Cms")
        {
            ddlHeighFtIn.Text = "6ft 5in";
        }
        else if (ddlHeightCms.Text == "197Cms")
        {
            ddlHeighFtIn.Text = "6ft 6in";
        }
        else if (ddlHeightCms.Text == "198Cms")
        {
            ddlHeighFtIn.Text = "6ft 6in";
        }
        else if (ddlHeightCms.Text == "199Cms")
        {
            ddlHeighFtIn.Text = "6ft 6in";
        }
        else if (ddlHeightCms.Text == "200Cms")
        {
            ddlHeighFtIn.Text = "6ft 7in";
        }
        else if (ddlHeightCms.Text == "201Cms")
        {
            ddlHeighFtIn.Text = "6ft 7in";
        }
        else if (ddlHeightCms.Text == "202Cms")
        {
            ddlHeighFtIn.Text = "6ft 8in";
        }
        else if (ddlHeightCms.Text == "203Cms")
        {
            ddlHeighFtIn.Text = "6ft 8in";
        }
        else if (ddlHeightCms.Text == "204Cms")
        {
            ddlHeighFtIn.Text = "6ft 8in";
        }
        else if (ddlHeightCms.Text == "205Cms")
        {
            ddlHeighFtIn.Text = "6ft 9in";
        }
        else if (ddlHeightCms.Text == "206Cms")
        {
            ddlHeighFtIn.Text = "6ft 9in";
        }
        else if (ddlHeightCms.Text == "207Cms")
        {
            ddlHeighFtIn.Text = "6ft 9in";
        }
        else if (ddlHeightCms.Text == "208Cms")
        {
            ddlHeighFtIn.Text = "6ft 10in";
        }
        else if (ddlHeightCms.Text == "209Cms")
        {
            ddlHeighFtIn.Text = "6ft 10in";
        }
        else if (ddlHeightCms.Text == "210Cms")
        {
            ddlHeighFtIn.Text = "6ft 11in";
        }
        else if (ddlHeightCms.Text == "211Cms")
        {
            ddlHeighFtIn.Text = "6ft 11in";
        }
        else if (ddlHeightCms.Text == "212Cms")
        {
            ddlHeighFtIn.Text = "7ft";
        }
        else if (ddlHeightCms.Text == "213Cms")
        {
            ddlHeighFtIn.Text = "7ft";
        }
    }
    protected void ddlWeight_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string[] wt = ddlWeight.Text.Split('K');
            Double lbs = Convert.ToInt32(wt[0].ToString()) * 2.20462262185;
            string temp = Math.Ceiling(lbs).ToString();
            string temp1 = temp + "Lbs";
            ddlWeightLbs.Text = temp1;
        }
        catch (Exception ex)
        {
        }
    }
    protected void ddlWeightLbs_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string[] wt = ddlWeightLbs.Text.Split('L');
            Double lbs = Convert.ToInt32(wt[0].ToString()) * 0.45359237;
            string temp = Math.Ceiling(lbs).ToString();
            string temp1 = temp + "Kg";
            ddlWeight.Text = temp1;
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