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

public partial class members_UserProfile_Partner_EditFamilyDetails : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
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
    public void getdata()
    {
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varLivingwithparents, varFamilyvalues, varFamilytype, varFamilystatus from anuvaa_matrimony.tblammemberpartnerbasic where varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (dbc.dr["varLivingwithparents"].ToString() == "Yes")
                {
                    rgbPYes.Checked = true;
                }
                else if (dbc.dr["varLivingwithparents"].ToString() == "No")
                {
                    rgbPNo.Checked = true;
                }
                else if (dbc.dr["varLivingwithparents"].ToString() == "Does Not Matter")
                {
                    rgbPDnot.Checked = true;
                }
                ddlFstatus.Text = dbc.dr["varFamilystatus"].ToString();
                ddlFtype.Text = dbc.dr["varFamilytype"].ToString();
                ddlFvalue.Text = dbc.dr["varFamilyvalues"].ToString();
            }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(
            //  this,
            //  this.GetType(),
            //  "MessageBox",
            //  "alert('Some problem Please try again...!!!');", true);
            //}
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
        {
            if (rgbPYes.Checked)
            {
                living = rgbPYes.Text;
            }
            else if (rgbPNo.Checked)
            {
                living = rgbPNo.Text;
            }
            else if (rgbPDnot.Checked)
            {
                living = rgbPDnot.Text;
            }
            int insert_ok = dbc.update_tblammemberpartnerbasic_Family(Session["memberid"].ToString(),living, ddlFvalue.Text, ddlFtype.Text, ddlFstatus.Text);

            if (insert_ok == 1)
            {
                // clear();
                ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('Partner Family Details Updated Successfully...!!!');window.location='EditFamilyDetails.aspx';", true);
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
}