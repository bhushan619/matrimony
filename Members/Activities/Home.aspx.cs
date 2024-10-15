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

public partial class members_Activities_Home : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    static string gender = string.Empty;
    DataTable dt = new DataTable();
    public static int Id = 0;
    static string Ememid = string.Empty;
    static string education = string.Empty;
    static string Occupation = string.Empty;
    static string Familyvalue = string.Empty;
    static string gen = string.Empty;
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
        else if (!IsPostBack)
        {
            MemberBasicData();
            getrequestcount();
            getDataMessages();
            lblcountfinalmsg.Text = (Convert.ToInt32(msgcount) + Convert.ToInt32(reqcount)).ToString();
            getProfiles();
           
            getWhoViewedMyProfiles();
            getShortProfiles();
            getLoginEducation();
            getLoginFamily();
            getInterestedInMeProfiles();
            getViwedProfileDetails();
            InterestListview1.Visible = false;
            notifications();
           
        }
    }

    public void MemberBasicData()//do not copy this additional functionality added
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

                lbljid.Text = dbc.dr["varMemberId"].ToString();
                lbljname.Text = dbc.dr["varMemberName"].ToString();

                gen = dbc.dr["varGender"].ToString();
                imgMemberPhoto.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();

                imgjmypropic.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();
                if (dbc.dr["varMembershipType"].ToString() == "Paid")
                {
                    MySql.Data.MySqlClient.MySqlCommand cmdm = new MySql.Data.MySqlClient.MySqlCommand("SELECT (SELECT distinct varPackageName FROM tblampackages WHERE varPackageId=tblammembertransactions.varPackageId) as ViewMemPackage FROM tblammembertransactions WHERE varMemberId='" + Session["memberid"].ToString() + "' and varOrderStatus='Confirmed'  order by intId DESC", dbc.con1);

                    dbc.con1.Open();
                    dbc.dr1 = cmdm.ExecuteReader();
                    if (dbc.dr1.Read())
                    {
                        lblmemUpgrade.Visible = true;
                        lblPay.Visible = true;

                        lnkUpgrade.Visible = false;
                        hypPay.Visible = false;

                        lblmemUpgrade.Text = dbc.dr1["ViewMemPackage"].ToString();
                        lblPay.Text = lblmemUpgrade.Text;
                    }
                    dbc.con1.Close();
                    dbc.dr1.Close();
                }
                else if (dbc.dr["varMembershipType"].ToString() == "Unpaid")
                {
                    lblmemUpgrade.Visible = false;
                    lnkUpgrade.Visible = true;
                    lblPay.Visible = false;
                    hypPay.Visible = true;
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

       // ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>fblgt();window.location='../../register/FranchiseeRegisterj.aspx';</script>", false);

       // Response.Write("<script>alert('Please Try Again');window.location='../../register/login.aspx';</script>");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int ok = dbc.check_if_member(txtmemberId.Text);
           if (txtmemberId.Text==lblMemberId.Text)
            {
                Response.Redirect("~/members/SearchMatches/", false);
                txtmemberId.Text = "";
            }  
            else if (ok == 1)
            {
                Session.Add("SearchMemberId", txtmemberId.Text);
                Response.Redirect("~/members/SearchMatches/ViewProfile.aspx", false);
                txtmemberId.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Please Enter Proper Member ID');</script>");
            }
            //dbc.con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varMemberId, varMembershipType,  varMemberName, varGender, varMobile,varMemberStatus,varCreatorDesignation FROM tblammemberregistration WHERE varMemberStatus='Verified' AND varMemberId='" + txtmemberId.Text + "'", dbc.con);
            //MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            //ad.Fill(dt);
            //grdPaidMember.DataSource = dt;
            //grdPaidMember.DataBind();
            //dbc.con.Close();

        }
        catch (Exception ex)
        {
            dbc.con.Close();
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }

    public void getProfiles()
    {
        gender = dbc.getGender(Session["memberid"].ToString());
        // SqlDataSourceMembers.SelectCommand = "SELECT varMemberId, varMemberName, varGender,varMemberStatus FROM tblammemberregistration where " + gender + " AND varMemberId!='" + Session["memberid"].ToString() + "' and varMemberStatus='Verified' ORDER BY RAND() LIMIT 0,3";
    }
    protected void lstMembers_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        Session.Add("SearchMemberId", e.CommandArgument);
        Response.Redirect("~/members/SearchMatches/ViewProfile.aspx");
    }

    protected void OpenProfile(object sender, EventArgs e)
    {

        Session["SearchMemberId"] = (sender as LinkButton).CommandArgument;
        //Response.Redirect("~/members/UserProfile/ViewProfile.aspx");
        Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('../SearchMatches/ViewProfile.aspx','_blank');", true);

    }

    string ViewMemId = string.Empty;
    //string ViewMemDate = string.Empty;
    //string ViewMemName = string.Empty;
    //string ViewMemAccFor = string.Empty;
    //string ViewMemAbout = string.Empty;
    string ViewMemAge = string.Empty;
    string ViewMemReligion = string.Empty;
    string ViewMemCaste = string.Empty;
    //string ViewMemSCaste = string.Empty;
    string ViewMemCity = string.Empty;
    //string ViewMemState = string.Empty;
    //string ViewMemCountry = string.Empty;
    //string ViewMemEducation = string.Empty;
    //string ViewMemOccupation = string.Empty;
    string ViewMemHeight = string.Empty;
    //string ViewMemHeightcm = string.Empty;
    string ViewMemPhoto = string.Empty;
    //string ViewMemPackage = string.Empty;

    protected void lstView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (lstshortlist.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.getWhoViewedMyProfiles();
    }
    public void getWhoViewedMyProfiles()
    {
        try
        {
            ////data reader we will use to read data from our tables
            MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr2, rdr3, rdr4, rdr5, rdr6, rdr7, rdr8;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[7] {             
                        new DataColumn("ViewMemId", typeof(string)),                         
                        //new DataColumn("ViewMemDate", typeof(string)),
                        //new DataColumn("ViewMemName", typeof(string)),
                        //new DataColumn("ViewMemAccFor", typeof(string)), 
                        new DataColumn("ViewMemPhoto", typeof(string)),  
                        //new DataColumn("ViewMemAbout", typeof(string)),  
                        new DataColumn("ViewMemAge", typeof(string)), 
                        new DataColumn("ViewMemReligion", typeof(string)), 
                        new DataColumn("ViewMemCaste", typeof(string)),   
                        //new DataColumn("ViewMemSCaste", typeof(string)),    
                        new DataColumn("ViewMemCity", typeof(string)),  
                        //new DataColumn("ViewMemState", typeof(string)), 
                        //new DataColumn("ViewMemCountry", typeof(string)),    
                        //new DataColumn("ViewMemEducation", typeof(string)),    
                        //new DataColumn("ViewMemOccupation", typeof(string)),    
                        new DataColumn("ViewMemHeight", typeof(string)),    
                        //new DataColumn("ViewMemHeightcm", typeof(string)),                           
                       // new DataColumn("ViewMemPackage", typeof(string)),    
                                 
        });

            DataRow dr = dt.NewRow();

            MySql.Data.MySqlClient.MySqlConnection cnn1 = new MySql.Data.MySqlClient.MySqlConnection();
            cnn1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

            //get Visitors profiles
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId as ViewMemId, varDate as ViewMemDate FROM tblamemberview WHERE (varViewedMemberId = '" + Session["memberid"].ToString() + "') ORDER BY RAND() LIMIT 0,3", cnn1);
            cmd1.CommandType = CommandType.Text;

  
            using (cnn1)
            {
                //open connection
                cnn1.Open();
                //read data from the table to our data reader
                rdr1 = cmd1.ExecuteReader();
                //loop through each row we have read 
             
                while (rdr1.Read())
                {

                    ViewMemId = rdr1["ViewMemId"].ToString();
                    // ViewMemDate = rdr1["ViewMemDate"].ToString();
                  string[] gender = dbc.getGender(ViewMemId).Split(new char[] { '\'' });
                    if (gender[1] == gen)
                    {
                        // get data from table tblammemberregistration

                        MySql.Data.MySqlClient.MySqlConnection cnn2 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName as ViewMemName,varMemberFor as ViewMemAccFor,varPhoto as ViewMemPhoto,ex3,varGender,varPhotoApprove FROM tblammemberregistration WHERE (varMemberId = '" + ViewMemId + "') and varMemberStatus='Verified'", cnn2);
                        cmd2.CommandType = CommandType.Text;

                        using (cnn2)
                        {
                            cnn2.Open();
                            rdr2 = cmd2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                // ViewMemName = rdr2["ViewMemName"].ToString();
                                // ViewMemAccFor = rdr2["ViewMemAccFor"].ToString();
                                if (rdr2["varPhotoApprove"].ToString() == "Approved")
                                {
                                    if (rdr2["varGender"].ToString() == "Female")
                                    {
                                        if (rdr2["ex3"].ToString() == "Protected")
                                        {
                                            ViewMemPhoto = "FemaleNoProfileProtected.jpg";
                                        }
                                        else if (rdr2["ex3"].ToString() == "Hidden")
                                        {
                                            ViewMemPhoto = "FemaleNoProfileProtected.jpg";
                                        }
                                        else
                                        {
                                            ViewMemPhoto = rdr2["ViewMemPhoto"].ToString();
                                        }
                                    }
                                    else if (rdr2["varGender"].ToString() == "Male")
                                    {
                                        if (rdr2["ex3"].ToString() == "Protected")
                                        {
                                            ViewMemPhoto = "MaleNoProfileProtected.jpg";
                                        }
                                        else if (rdr2["ex3"].ToString() == "Hidden")
                                        {
                                            ViewMemPhoto = "MaleNoProfileProtected.jpg";
                                        }
                                        else
                                        {
                                            ViewMemPhoto = rdr2["ViewMemPhoto"].ToString();
                                        }
                                    }
                                    else if (rdr2["varGender"].ToString() == "Other")
                                    {
                                        if (rdr2["ex3"].ToString() == "Protected")
                                        {
                                            ViewMemPhoto = "MaleNoProfileProtected.jpg";
                                        }
                                        else if (rdr2["ex3"].ToString() == "Hidden")
                                        {
                                            ViewMemPhoto = "MaleNoProfileProtected.jpg";
                                        }
                                        else
                                        {
                                            ViewMemPhoto = rdr2["ViewMemPhoto"].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    ViewMemPhoto = "NotApproved.jpg";

                                }


                            }
                            cnn2.Close();
                            rdr2.Close();
                        }

                        //end data from table tblammemberregistration

                        // get data from table tblammemberinformation

                        MySql.Data.MySqlClient.MySqlConnection cnn3 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn3.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varAgeToday as ViewMemAge, varAbout as ViewMemAbout FROM tblammemberinformation WHERE varMemberId = '" + ViewMemId + "' ", cnn3);
                        cmd3.CommandType = CommandType.Text;

                        using (cnn3)
                        {
                            cnn3.Open();
                            rdr3 = cmd3.ExecuteReader();
                            while (rdr3.Read())
                            {
                                ViewMemAge = rdr3["ViewMemAge"].ToString();
                                // ViewMemAbout = rdr3["ViewMemAbout"].ToString();
                            }
                            cnn3.Close();
                            rdr3.Close();
                        }

                        //end data from table tblammemberinformation

                        // get data from table tblammemberreligiousinfo

                        MySql.Data.MySqlClient.MySqlConnection cnn4 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn4.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd4 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varReligion as ViewMemReligion, varCasteDivision as ViewMemCaste, varSubcaste as ViewMemSCaste FROM tblammemberreligiousinfo WHERE (varMemberId = '" + ViewMemId + "')", cnn4);
                        cmd4.CommandType = CommandType.Text;

                        using (cnn4)
                        {
                            cnn4.Open();
                            rdr4 = cmd4.ExecuteReader();
                            while (rdr4.Read())
                            {
                                ViewMemReligion = rdr4["ViewMemReligion"].ToString();
                                ViewMemCaste = rdr4["ViewMemCaste"].ToString();
                                // ViewMemSCaste = rdr4["ViewMemSCaste"].ToString();
                            }
                            cnn4.Close();
                            rdr4.Close();
                        }

                        //end data from table tblammemberreligiousinfo

                        // get data from table tblammemberlivingin

                        MySql.Data.MySqlClient.MySqlConnection cnn5 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn5.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd5 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCity as ViewMemCity, varState as ViewMemState, varCountry as ViewMemCountry FROM tblammemberlivingin WHERE (varMemberId = '" + ViewMemId + "')", cnn5);
                        cmd5.CommandType = CommandType.Text;

                        using (cnn5)
                        {
                            cnn5.Open();
                            rdr5 = cmd5.ExecuteReader();
                            while (rdr5.Read())
                            {
                                ViewMemCity = rdr5["ViewMemCity"].ToString();
                                // ViewMemState = rdr5["ViewMemState"].ToString();
                                //ViewMemCountry = rdr5["ViewMemCountry"].ToString();

                            }
                            cnn5.Close();
                            rdr5.Close();
                        }

                        //end data from table tblammemberlivingin

                        // get data from table tblammemberprofessionalinfo

                        MySql.Data.MySqlClient.MySqlConnection cnn6 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn6.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd6 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varEducation as ViewMemEducation, varOccupation as ViewMemOccupation FROM tblammemberprofessionalinfo WHERE (varMemberId = '" + ViewMemId + "')", cnn6);
                        cmd6.CommandType = CommandType.Text;


                        using (cnn6)
                        {
                            cnn6.Open();
                            rdr6 = cmd6.ExecuteReader();
                            while (rdr6.Read())
                            {
                                //ViewMemOccupation = rdr6["ViewMemOccupation"].ToString();
                                //  ViewMemEducation = rdr6["ViewMemEducation"].ToString();
                            }
                            cnn6.Close();
                            rdr6.Close();
                        }

                        //end data from table tblammemberprofessionalinfo

                        // get data from table tblammemberphysicalinformation

                        MySql.Data.MySqlClient.MySqlConnection cnn7 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn7.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd7 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varHeightFt as ViewMemHeight, varHeightCm as ViewMemHeightcm FROM tblammemberphysicalinformation WHERE (varMemberId = '" + ViewMemId + "')", cnn7);
                        cmd7.CommandType = CommandType.Text;


                        using (cnn7)
                        {
                            cnn7.Open();
                            rdr7 = cmd7.ExecuteReader();
                            while (rdr7.Read())
                            {
                                ViewMemHeight = rdr7["ViewMemHeight"].ToString();
                                // ViewMemHeightcm = rdr7["ViewMemHeightcm"].ToString();
                            }
                            cnn7.Close();
                            rdr7.Close();
                        }

                        //end data from table tblammemberphysicalinformation

                        // get data from table tblampackages

                        MySql.Data.MySqlClient.MySqlConnection cnn8 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn8.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd8 = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblampackages.varPackageName as ViewMemPackage FROM tblammembertransactions, tblampackages WHERE (tblammembertransactions.varMemberId = '" + ViewMemId + "')", cnn8);
                        cmd8.CommandType = CommandType.Text;

                        using (cnn8)
                        {
                            cnn8.Open();
                            rdr8 = cmd8.ExecuteReader();
                            while (rdr8.Read())
                            {
                                //  ViewMemPackage = rdr8["ViewMemPackage"].ToString();
                            }
                            cnn8.Close();
                            rdr8.Close();
                        }

                        //end data from table tblampackages

                        // add row to datatable
                        // dt.Rows.Add(ViewMemId, ViewMemDate, ViewMemName, ViewMemAccFor, ViewMemPhoto, ViewMemAbout, ViewMemAge, ViewMemReligion, ViewMemCaste, ViewMemSCaste, ViewMemCity, ViewMemState, ViewMemCountry, ViewMemEducation, ViewMemOccupation, ViewMemHeight, ViewMemHeightcm, ViewMemPackage);
                        dt.Rows.Add(ViewMemId, ViewMemPhoto, ViewMemAge, ViewMemReligion, ViewMemCaste, ViewMemCity, ViewMemHeight);
                        // Empty strings
                        ViewMemId = string.Empty;
                        //ViewMemDate = string.Empty;
                        //ViewMemName = string.Empty;
                        //ViewMemAccFor = string.Empty;
                        //ViewMemAbout = string.Empty;
                        ViewMemAge = string.Empty;
                        //ViewMemReligion = string.Empty;
                        //ViewMemCaste = string.Empty;
                        //ViewMemSCaste = string.Empty;
                        //ViewMemCity = string.Empty;
                        //ViewMemState = string.Empty;
                        //ViewMemCountry = string.Empty;
                        //ViewMemEducation = string.Empty;
                        //ViewMemOccupation = string.Empty;
                        ViewMemHeight = string.Empty;
                        // ViewMemHeightcm = string.Empty;
                        ViewMemPhoto = string.Empty;
                        //ViewMemPackage = string.Empty;
                    }
                }
                cnn1.Close();
                rdr1.Close();
            }


            lstView.DataSource = dt;
            lstView.DataBind();
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

    string SlstMemId = string.Empty;
    //string SlstMemDate = string.Empty;
    //string SlstMemName = string.Empty;
    //string SlstMemAccFor = string.Empty;
    //string SlstMemAbout = string.Empty;
    string SlstMemAge = string.Empty;
    //string SlstMemReligion = string.Empty;
    //string SlstMemCaste = string.Empty;
    //string SlstMemSCaste = string.Empty;
    //string SlstMemCity = string.Empty;
    //string SlstMemState = string.Empty;
    //string SlstMemCountry = string.Empty;
    //string SlstMemEducation = string.Empty;
    //string SlstMemOccupation = string.Empty;
    string SlstMemHeight = string.Empty;
    //string SlstMemHeightcm = string.Empty;
    string SlstMemPhoto = string.Empty;
    //string SlstMemPackage = string.Empty;


    public void getShortProfiles()
    {
        try
        {
            ////data reader we will use to read data from our tables
            MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr2, rdr3, rdr4, rdr5, rdr6, rdr7, rdr8;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] {             
                        new DataColumn("SlstMemId", typeof(string)),                         
                        //new DataColumn("SlstMemDate", typeof(string)),
                        //new DataColumn("SlstMemName", typeof(string)),
                        //new DataColumn("SlstMemAccFor", typeof(string)), 
                        new DataColumn("SlstMemPhoto", typeof(string)),  
                        //new DataColumn("SlstMemAbout", typeof(string)),  
                        new DataColumn("SlstMemAge", typeof(string)), 
                        //new DataColumn("SlstMemReligion", typeof(string)), 
                        //new DataColumn("SlstMemCaste", typeof(string)),   
                        //new DataColumn("SlstMemSCaste", typeof(string)),    
                        //new DataColumn("SlstMemCity", typeof(string)),  
                        //new DataColumn("SlstMemState", typeof(string)), 
                        //new DataColumn("SlstMemCountry", typeof(string)),    
                        //new DataColumn("SlstMemEducation", typeof(string)),    
                        //new DataColumn("SlstMemOccupation", typeof(string)),    
                        new DataColumn("SlstMemHeight", typeof(string)),    
                        //new DataColumn("SlstMemHeightcm", typeof(string)),                           
                       // new DataColumn("SlstMemPackage", typeof(string)),    
                                 
        });

            DataRow dr = dt.NewRow();

            MySql.Data.MySqlClient.MySqlConnection cnn1 = new MySql.Data.MySqlClient.MySqlConnection();
            cnn1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

            //get shortlisted profiles
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId as SlstMemId, varDate as SlstMemDate FROM tblammembershortlist WHERE (varShortListMemberId = '" + Session["memberid"].ToString() + "') ORDER BY RAND() LIMIT 0,3", cnn1);
            cmd1.CommandType = CommandType.Text;

            using (cnn1)
            {
                //open connection
                cnn1.Open();
                //read data from the table to our data reader
                rdr1 = cmd1.ExecuteReader();
                //loop through each row we have read
                while (rdr1.Read())
                {
                    SlstMemId = rdr1["SlstMemId"].ToString();
                    // SlstMemDate = rdr1["SlstMemDate"].ToString();

                    // get data from table tblammemberregistration

                    MySql.Data.MySqlClient.MySqlConnection cnn2 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName as SlstMemName,varMemberFor as SlstMemAccFor,varPhoto as SlstMemPhoto,ex3,varGender,varPhotoApprove FROM tblammemberregistration WHERE (varMemberId = '" + SlstMemId + "') and varMemberStatus='Verified'", cnn2);
                    cmd2.CommandType = CommandType.Text;

                    using (cnn2)
                    {
                        cnn2.Open();
                        rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            // SlstMemName = rdr2["SlstMemName"].ToString();
                            // SlstMemAccFor = rdr2["SlstMemAccFor"].ToString();
                            if (rdr2["varPhotoApprove"].ToString() == "Approved")
                            {

                                if (rdr2["varGender"].ToString() == "Female")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        SlstMemPhoto = "FemaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        SlstMemPhoto = "FemaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        SlstMemPhoto = rdr2["SlstMemPhoto"].ToString();
                                    }
                                }
                                else if (rdr2["varGender"].ToString() == "Male")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        SlstMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        SlstMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        SlstMemPhoto = rdr2["SlstMemPhoto"].ToString();
                                    }
                                }
                                else if (rdr2["varGender"].ToString() == "Other")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        SlstMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        SlstMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        SlstMemPhoto = rdr2["SlstMemPhoto"].ToString();
                                    }
                                }
                            }
                            else
                            {
                                SlstMemPhoto = "NotApproved.jpg";
                            }

                        }
                        cnn2.Close();
                        rdr2.Close();
                    }

                    //end data from table tblammemberregistration

                    // get data from table tblammemberinformation

                    MySql.Data.MySqlClient.MySqlConnection cnn3 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn3.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varAgeToday as SlstMemAge, varAbout as SlstMemAbout FROM tblammemberinformation WHERE (varMemberId = '" + SlstMemId + "')", cnn3);
                    cmd3.CommandType = CommandType.Text;

                    using (cnn3)
                    {
                        cnn3.Open();
                        rdr3 = cmd3.ExecuteReader();
                        while (rdr3.Read())
                        {
                            SlstMemAge = rdr3["SlstMemAge"].ToString();
                            // SlstMemAbout = rdr3["SlstMemAbout"].ToString();
                        }
                        cnn3.Close();
                        rdr3.Close();
                    }

                    //end data from table tblammemberinformation

                    // get data from table tblammemberreligiousinfo

                    MySql.Data.MySqlClient.MySqlConnection cnn4 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn4.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd4 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varReligion as SlstMemReligion, varCasteDivision as SlstMemCaste, varSubcaste as SlstMemSCaste FROM tblammemberreligiousinfo WHERE (varMemberId = '" + SlstMemId + "')", cnn4);
                    cmd4.CommandType = CommandType.Text;

                    using (cnn4)
                    {
                        cnn4.Open();
                        rdr4 = cmd4.ExecuteReader();
                        while (rdr4.Read())
                        {
                            //  SlstMemReligion = rdr4["SlstMemReligion"].ToString();
                            // SlstMemCaste = rdr4["SlstMemCaste"].ToString();
                            // SlstMemSCaste = rdr4["SlstMemSCaste"].ToString();
                        }
                        cnn4.Close();
                        rdr4.Close();
                    }

                    //end data from table tblammemberreligiousinfo

                    // get data from table tblammemberlivingin

                    MySql.Data.MySqlClient.MySqlConnection cnn5 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn5.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd5 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCity as SlstMemCity, varState as SlstMemState, varCountry as SlstMemCountry FROM tblammemberlivingin WHERE (varMemberId = '" + SlstMemId + "')", cnn5);
                    cmd5.CommandType = CommandType.Text;

                    using (cnn5)
                    {
                        cnn5.Open();
                        rdr5 = cmd5.ExecuteReader();
                        while (rdr5.Read())
                        {
                            // SlstMemCity = rdr5["SlstMemCity"].ToString();
                            // SlstMemState = rdr5["SlstMemState"].ToString();
                            //SlstMemCountry = rdr5["SlstMemCountry"].ToString();

                        }
                        cnn5.Close();
                        rdr5.Close();
                    }

                    //end data from table tblammemberlivingin

                    // get data from table tblammemberprofessionalinfo

                    MySql.Data.MySqlClient.MySqlConnection cnn6 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn6.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd6 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varEducation as SlstMemEducation, varOccupation as SlstMemOccupation FROM tblammemberprofessionalinfo WHERE (varMemberId = '" + SlstMemId + "')", cnn6);
                    cmd6.CommandType = CommandType.Text;


                    using (cnn6)
                    {
                        cnn6.Open();
                        rdr6 = cmd6.ExecuteReader();
                        while (rdr6.Read())
                        {
                            //SlstMemOccupation = rdr6["SlstMemOccupation"].ToString();
                            //  SlstMemEducation = rdr6["SlstMemEducation"].ToString();
                        }
                        cnn6.Close();
                        rdr6.Close();
                    }

                    //end data from table tblammemberprofessionalinfo

                    // get data from table tblammemberphysicalinformation

                    MySql.Data.MySqlClient.MySqlConnection cnn7 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn7.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd7 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varHeightFt as SlstMemHeight, varHeightCm as SlstMemHeightcm FROM tblammemberphysicalinformation WHERE (varMemberId = '" + SlstMemId + "')", cnn7);
                    cmd7.CommandType = CommandType.Text;


                    using (cnn7)
                    {
                        cnn7.Open();
                        rdr7 = cmd7.ExecuteReader();
                        while (rdr7.Read())
                        {
                            SlstMemHeight = rdr7["SlstMemHeight"].ToString();
                            // SlstMemHeightcm = rdr7["SlstMemHeightcm"].ToString();
                        }
                        cnn7.Close();
                        rdr7.Close();
                    }

                    //end data from table tblammemberphysicalinformation

                    // get data from table tblampackages

                    MySql.Data.MySqlClient.MySqlConnection cnn8 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn8.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd8 = new MySql.Data.MySqlClient.MySqlCommand("SELECT DISTINCT tblampackages.varPackageName as SlstMemPackage FROM tblammembertransactions, tblampackages WHERE (tblammembertransactions.varMemberId = '" + SlstMemId + "')", cnn8);
                    cmd8.CommandType = CommandType.Text;

                    using (cnn8)
                    {
                        cnn8.Open();
                        rdr8 = cmd8.ExecuteReader();
                        while (rdr8.Read())
                        {
                            //  SlstMemPackage = rdr8["SlstMemPackage"].ToString();
                        }
                        cnn8.Close();
                        rdr8.Close();
                    }

                    //end data from table tblampackages

                    // add row to datatable
                    // dt.Rows.Add(SlstMemId, SlstMemDate, SlstMemName, SlstMemAccFor, SlstMemPhoto, SlstMemAbout, SlstMemAge, SlstMemReligion, SlstMemCaste, SlstMemSCaste, SlstMemCity, SlstMemState, SlstMemCountry, SlstMemEducation, SlstMemOccupation, SlstMemHeight, SlstMemHeightcm, SlstMemPackage);
                    dt.Rows.Add(SlstMemId, SlstMemPhoto, SlstMemAge, SlstMemHeight);
                    // Empty strings
                    SlstMemId = string.Empty;
                    //SlstMemDate = string.Empty;
                    //SlstMemName = string.Empty;
                    //SlstMemAccFor = string.Empty;
                    //SlstMemAbout = string.Empty;
                    SlstMemAge = string.Empty;
                    //SlstMemReligion = string.Empty;
                    //SlstMemCaste = string.Empty;
                    //SlstMemSCaste = string.Empty;
                    //SlstMemCity = string.Empty;
                    //SlstMemState = string.Empty;
                    //SlstMemCountry = string.Empty;
                    //SlstMemEducation = string.Empty;
                    //SlstMemOccupation = string.Empty;
                    SlstMemHeight = string.Empty;
                    // SlstMemHeightcm = string.Empty;
                    SlstMemPhoto = string.Empty;
                    //SlstMemPackage = string.Empty;
                }
                cnn1.Close();
                rdr1.Close();
            }

            lstshortlist.DataSource = dt;
            lstshortlist.DataBind();
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
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {

    }

    // get Prefered Education
    string EduMemId = string.Empty;
    //string EduMemDate = string.Empty;
    //string EduMemName = string.Empty;
    //string EduMemAccFor = string.Empty;
    //string EduMemAbout = string.Empty;
    string EduMemAge = string.Empty;
    //string EduMemReligion = string.Empty;
    //string EduMemCaste = string.Empty;
    //string EduMemSCaste = string.Empty;
    //string EduMemCity = string.Empty;
    //string EduMemState = string.Empty;
    //string EduMemCountry = string.Empty;
    string EduMemEducation = string.Empty;
    //string EduMemOccupation = string.Empty;
    string EduMemHeight = string.Empty;
    //string EduMemHeightcm = string.Empty;
    string EduMemPhoto = string.Empty;
    //string EduMemPackage = string.Empty;

    public void getLoginEducation()
    {
        try
        {
            dbc.con1.Open();
            MySql.Data.MySqlClient.MySqlCommand ecmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId, varEducation,  varOccupation FROM tblammemberprofessionalinfo WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con1);
            dbc.dr = ecmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                education = dbc.dr["varEducation"].ToString();
                Occupation = dbc.dr["varOccupation"].ToString();
            }
            dbc.con1.Close();
            dbc.dr.Dispose();

            getShowProfiles("SELECT varMemberId as EduMemId FROM tblammemberprofessionalinfo WHERE varEducation='" + education + "' ORDER BY RAND() LIMIT 0,2", "EduMemEducation", lstViewEducation);
            getShowProfiles("SELECT varMemberId as EduMemId FROM tblammemberprofessionalinfo WHERE varOccupation='" + Occupation + "' ORDER BY RAND() LIMIT 0,2", "EduMemOccupation", lstOccupation);
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
    public void getLoginFamily()
    {
        try
        {
            dbc.con2.Open();
            MySql.Data.MySqlClient.MySqlCommand fcmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId,varFamilyvalue FROM tblammemberfamily WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con2);
            dbc.dr = fcmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                Familyvalue = dbc.dr["varFamilyvalue"].ToString();

            }
            dbc.con2.Close();
            dbc.dr.Dispose();

            getShowProfiles("SELECT varMemberId as EduMemId FROM tblammemberfamily WHERE varFamilyvalue='" + Familyvalue + "' ORDER BY RAND() LIMIT 0,2", "FamilyValue", lstViewfamily);
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

    public void getShowProfiles(string query, string column, ListView lstShow)
    {
        try
        {
            ////data reader we will use to read data from our tables
            MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr2, rdr3, rdr4, rdr5, rdr6, rdr7, rdr8;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[5] {             
                        new DataColumn("EduMemId", typeof(string)),                         
                        //new DataColumn("EduMemDate", typeof(string)),
                        //new DataColumn("EduMemName", typeof(string)),
                        //new DataColumn("EduMemAccFor", typeof(string)), 
                        new DataColumn("EduMemPhoto", typeof(string)),  
                        //new DataColumn("EduMemAbout", typeof(string)),  
                        new DataColumn("EduMemAge", typeof(string)), 
                        //new DataColumn("EduMemReligion", typeof(string)), 
                        //new DataColumn("EduMemCaste", typeof(string)),   
                        //new DataColumn("EduMemSCaste", typeof(string)),    
                        //new DataColumn("EduMemCity", typeof(string)),  
                        //new DataColumn("EduMemState", typeof(string)), 
                        //new DataColumn("EduMemCountry", typeof(string)),    
                        new DataColumn(column, typeof(string)),    
                        //new DataColumn("EduMemOccupation", typeof(string)),    
                        new DataColumn("EduMemHeight", typeof(string)),    
                        //new DataColumn("EduMemHeightcm", typeof(string)),                           
                       // new DataColumn("EduMemPackage", typeof(string)),    
                                 
        });

            DataRow dr = dt.NewRow();


            MySql.Data.MySqlClient.MySqlConnection cnn1 = new MySql.Data.MySqlClient.MySqlConnection();
            cnn1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

            //get education


            //get shortlisted profiles
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand(query, cnn1);
            cmd1.CommandType = CommandType.Text;
            using (cnn1)
            {
                //open connection
                cnn1.Open();
                //read data from the table to our data reader
                rdr1 = cmd1.ExecuteReader();
                //loop through each row we have read
                while (rdr1.Read())
                {
                    EduMemId = rdr1["EduMemId"].ToString();
                    // EduMemDate = rdr1["EduMemDate"].ToString();
                    string[] gender = dbc.getGender(EduMemId).Split(new char[] { '\'' });
                    if (gender[1] == gen)
                    {
                        // get data from table tblammemberregistration

                        MySql.Data.MySqlClient.MySqlConnection cnn2 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName as EduMemName,varMemberFor as EduMemAccFor,varPhoto as EduMemPhoto,ex3,varGender,varPhotoApprove FROM tblammemberregistration WHERE (varMemberId = '" + EduMemId + "') and varMemberStatus='Verified' ORDER BY RAND() LIMIT 0,3", cnn2);
                        cmd2.CommandType = CommandType.Text;

                        using (cnn2)
                        {
                            cnn2.Open();
                            rdr2 = cmd2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                // EduMemName = rdr2["EduMemName"].ToString();
                                // EduMemAccFor = rdr2["EduMemAccFor"].ToString();
                                if (rdr2["varPhotoApprove"].ToString() == "Approved")
                                {

                                    if (rdr2["varGender"].ToString() == "Female")
                                    {
                                        if (rdr2["ex3"].ToString() == "Protected")
                                        {
                                            EduMemPhoto = "FemaleNoProfileProtected.jpg";
                                        }
                                        else if (rdr2["ex3"].ToString() == "Hidden")
                                        {
                                            EduMemPhoto = "FemaleNoProfileProtected.jpg";
                                        }
                                        else
                                        {
                                            EduMemPhoto = rdr2["EduMemPhoto"].ToString();
                                        }
                                    }
                                    else if (rdr2["varGender"].ToString() == "Male")
                                    {
                                        if (rdr2["ex3"].ToString() == "Protected")
                                        {
                                            EduMemPhoto = "MaleNoProfileProtected.jpg";
                                        }
                                        else if (rdr2["ex3"].ToString() == "Hidden")
                                        {
                                            EduMemPhoto = "MaleNoProfileProtected.jpg";
                                        }
                                        else
                                        {
                                            EduMemPhoto = rdr2["EduMemPhoto"].ToString();
                                        }
                                    }
                                    else if (rdr2["varGender"].ToString() == "Other")
                                    {
                                        if (rdr2["ex3"].ToString() == "Protected")
                                        {
                                            EduMemPhoto = "MaleNoProfileProtected.jpg";
                                        }
                                        else if (rdr2["ex3"].ToString() == "Hidden")
                                        {
                                            EduMemPhoto = "MaleNoProfileProtected.jpg";
                                        }
                                        else
                                        {
                                            EduMemPhoto = rdr2["EduMemPhoto"].ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    EduMemPhoto = "NotApproved.jpg";
                                }

                            }

                            cnn2.Close();
                            rdr2.Close();
                        }

                        //end data from table tblammemberregistration

                        // get data from table tblammemberinformation

                        MySql.Data.MySqlClient.MySqlConnection cnn3 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn3.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varAgeToday as EduMemAge, varAbout as EduMemAbout FROM tblammemberinformation WHERE (varMemberId = '" + EduMemId + "')", cnn3);
                        cmd3.CommandType = CommandType.Text;

                        using (cnn3)
                        {
                            cnn3.Open();
                            rdr3 = cmd3.ExecuteReader();
                            while (rdr3.Read())
                            {
                                EduMemAge = rdr3["EduMemAge"].ToString();
                                // EduMemAbout = rdr3["EduMemAbout"].ToString();
                            }
                            cnn3.Close();
                            rdr3.Close();
                        }

                        //end data from table tblammemberinformation

                        // get data from table tblammemberreligiousinfo

                        MySql.Data.MySqlClient.MySqlConnection cnn4 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn4.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd4 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varReligion as EduMemReligion, varCasteDivision as EduMemCaste, varSubcaste as EduMemSCaste FROM tblammemberreligiousinfo WHERE (varMemberId = '" + EduMemId + "')", cnn4);
                        cmd4.CommandType = CommandType.Text;

                        using (cnn4)
                        {
                            cnn4.Open();
                            rdr4 = cmd4.ExecuteReader();
                            while (rdr4.Read())
                            {
                                //  EduMemReligion = rdr4["EduMemReligion"].ToString();
                                // EduMemCaste = rdr4["EduMemCaste"].ToString();
                                // EduMemSCaste = rdr4["EduMemSCaste"].ToString();
                            }
                            cnn4.Close();
                            rdr4.Close();
                        }

                        //end data from table tblammemberreligiousinfo

                        // get data from table tblammemberlivingin

                        MySql.Data.MySqlClient.MySqlConnection cnn5 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn5.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd5 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCity as EduMemCity, varState as EduMemState, varCountry as EduMemCountry FROM tblammemberlivingin WHERE (varMemberId = '" + EduMemId + "')", cnn5);
                        cmd5.CommandType = CommandType.Text;

                        using (cnn5)
                        {
                            cnn5.Open();
                            rdr5 = cmd5.ExecuteReader();
                            while (rdr5.Read())
                            {
                                // EduMemCity = rdr5["EduMemCity"].ToString();
                                // EduMemState = rdr5["EduMemState"].ToString();
                                //EduMemCountry = rdr5["EduMemCountry"].ToString();

                            }
                            cnn5.Close();
                            rdr5.Close();
                        }

                        //end data from table tblammemberlivingin

                        // get data from table tblammemberprofessionalinfo

                        MySql.Data.MySqlClient.MySqlConnection cnn6 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn6.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;
                        string condition = string.Empty;
                        if (column == "EduMemEducation")
                        {
                            condition = " varEducation as EduMemEducation ";
                        }
                        else if (column == "EduMemOccupation")
                        {
                            condition = " varOccupation as EduMemOccupation ";
                        }
                        else
                        {
                            condition = " varOccupation as EduMemOccupation ";
                        }

                        MySql.Data.MySqlClient.MySqlCommand cmd6 = new MySql.Data.MySqlClient.MySqlCommand("SELECT  " + condition + " FROM tblammemberprofessionalinfo WHERE (varMemberId = '" + EduMemId + "')", cnn6);
                        cmd6.CommandType = CommandType.Text;


                        using (cnn6)
                        {
                            cnn6.Open();
                            rdr6 = cmd6.ExecuteReader();
                            while (rdr6.Read())
                            {
                                if (column == "FamilyValue")
                                { }
                                else
                                {
                                    EduMemEducation = rdr6[column].ToString();
                                }
                            }
                            cnn6.Close();
                            rdr6.Close();
                        }

                        //end data from table tblammemberprofessionalinfo

                        // get data from table tblammemberphysicalinformation

                        MySql.Data.MySqlClient.MySqlConnection cnn7 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn7.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd7 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varHeightFt as EduMemHeight, varHeightCm as EduMemHeightcm FROM tblammemberphysicalinformation WHERE (varMemberId = '" + EduMemId + "')", cnn7);
                        cmd7.CommandType = CommandType.Text;


                        using (cnn7)
                        {
                            cnn7.Open();
                            rdr7 = cmd7.ExecuteReader();
                            while (rdr7.Read())
                            {
                                EduMemHeight = rdr7["EduMemHeight"].ToString();
                                // EduMemHeightcm = rdr7["EduMemHeightcm"].ToString();
                            }
                            cnn7.Close();
                            rdr7.Close();
                        }

                        //end data from table tblammemberphysicalinformation

                        // get data from table tblampackages

                        MySql.Data.MySqlClient.MySqlConnection cnn8 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn8.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd8 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFamilyvalue as FamilyValue FROM tblammemberfamily WHERE (varMemberId = '" + EduMemId + "')", cnn8);
                        cmd8.CommandType = CommandType.Text;

                        using (cnn8)
                        {
                            cnn8.Open();
                            rdr8 = cmd8.ExecuteReader();
                            while (rdr8.Read())
                            {
                                if (column == "EduMemEducation")
                                { }
                                else if (column == "EduMemOccupation")
                                { }
                                else
                                {
                                    EduMemEducation = rdr8[column].ToString();
                                }
                            }
                            cnn8.Close();
                            rdr8.Close();
                        }

                        //end data from table tblampackages

                        // add row to datatable
                        // dt.Rows.Add(EduMemId, EduMemDate, EduMemName, EduMemAccFor, EduMemPhoto, EduMemAbout, EduMemAge, EduMemReligion, EduMemCaste, EduMemSCaste, EduMemCity, EduMemState, EduMemCountry, EduMemEducation, EduMemOccupation, EduMemHeight, EduMemHeightcm, EduMemPackage);
                        dt.Rows.Add(EduMemId, EduMemPhoto, EduMemAge, EduMemEducation, EduMemHeight);
                        // Empty strings
                        EduMemId = string.Empty;
                        //EduMemDate = string.Empty;
                        //EduMemName = string.Empty;
                        //EduMemAccFor = string.Empty;
                        //EduMemAbout = string.Empty;
                        EduMemAge = string.Empty;
                        //EduMemReligion = string.Empty;
                        //EduMemCaste = string.Empty;
                        //EduMemSCaste = string.Empty;
                        //EduMemCity = string.Empty;
                        //EduMemState = string.Empty;
                        //EduMemCountry = string.Empty;
                        EduMemEducation = string.Empty;
                        //EduMemOccupation = string.Empty;
                        EduMemHeight = string.Empty;
                        // EduMemHeightcm = string.Empty;
                        EduMemPhoto = string.Empty;
                        //EduMemPackage = string.Empty;
                    }
                }
                cnn1.Close();
                rdr1.Close();

            }

            lstShow.DataSource = dt;
            lstShow.DataBind();
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

    //including the original helper from the question with changes in signature
    protected string Limit(object Desc, int length)
    {
        StringBuilder strDesc = new StringBuilder();
        strDesc.Insert(0, Desc.ToString());

        if (strDesc.Length > length)
            return strDesc.ToString().Substring(0, length) + "...";
        else return strDesc.ToString();
    }

    protected void imgmember_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string[] commandarguement = (sender as ImageButton).CommandArgument.ToString().Split(';');
        string pictype  = commandarguement[1].ToString();
        if (pictype == "FemaleNoProfileProtected.jpg")
            {

                int already = dbc.check_already_tblamrequests(Session["memberid"].ToString(), commandarguement[0].ToString());
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
                    int ok = dbc.insert_tblamrequests(Session["memberid"].ToString(), commandarguement[0].ToString());
                    if (ok == 1)
                    {
                        dbc.insert_tblamnotifications("Session", Session["memberid"].ToString(), lblMemberName.Text, "Member", commandarguement[0].ToString(), "Member", "Photo Request from : " + lblMemberName.Text + "", "~/Members/SearchMatches/ViewProfile.aspx", commandarguement[0].ToString(), "Unread", "");
                        ScriptManager.RegisterStartupScript(
                      this,
                      this.GetType(),
                      "MessageBox",
                     "alert('Great ! Your request for photograph has been successfully sent. You will be intimated when your request is accepted.'); ", true);
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
        else if (pictype == "MaleNoProfileProtected.jpg")
            {

                int already = dbc.check_already_tblamrequests(Session["memberid"].ToString(), commandarguement[0].ToString());
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
                    int ok = dbc.insert_tblamrequests(Session["memberid"].ToString(), commandarguement[0].ToString());
                    dbc.insert_tblamnotifications("Session", Session["memberid"].ToString(), lblMemberName.Text, "Member", commandarguement[0].ToString(), "Member", "Photo Request from : " + lblMemberName.Text + "", "~/Members/SearchMatches/ViewProfile.aspx", commandarguement[0].ToString(), "Unread", "");
                    if (ok == 1)
                    {
                        ScriptManager.RegisterStartupScript(
                      this,
                      this.GetType(),
                      "MessageBox",
                     "alert('Great ! Your request for photograph has been successfully sent. You will be intimated when your request is accepted.'); ", true);
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
    protected void lnkInterest_Click(object sender, EventArgs e)
    {
        try
        {
            int already = dbc.check_already_interest(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument);
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
                int ok = dbc.insert_tblammemberinterests(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument);
                if (ok == 1)
                {
                    dbc.insert_tblamnotifications("Session", Session["memberid"].ToString(), lblMemberName.Text, "Member", (sender as LinkButton).CommandArgument, "Member", "New Interest from : " + lblMemberName.Text + "", "~/Members/SearchMatches/ViewProfile.aspx", (sender as LinkButton).CommandArgument, "Unread", "");
                    sendmail(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument);
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
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
        }

    }
    protected void lnkShortlist_Click(object sender, EventArgs e)
    {
        try
        {
            int already = dbc.check_already_Shortlist(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument);
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
                int ok = dbc.insert_tblammembershortlist(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument);
                if (ok == 1)
                {
                    dbc.insert_tblamnotifications("Session", Session["memberid"].ToString(), lblMemberName.Text, "Member", (sender as LinkButton).CommandArgument, "Member", "You are Shortlisted by : " + lblMemberName.Text + "", "~/Members/SearchMatches/ViewProfile.aspx", (sender as LinkButton).CommandArgument, "Unread", "");
                    sendmailshort(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument);
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
            ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('" + ex.Message + "');", true);
        }

    }
    //Mail
    private string PopulateBodyshort(string memid, string mname, string iname, string email, string imemid)//, string age, string height, string religion, string caste, string city, string state,string country, string edu,string occp)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Admin/emails/Shortlist.html")))
        {
            body = reader.ReadToEnd();
        }
        string datenow = DateTimeOffset.UtcNow.LocalDateTime.ToLongDateString();
        body = body.Replace("{mname}", mname);
        body = body.Replace("{memid}", Session["memberid"].ToString());
        body = body.Replace("{email}", email);
        body = body.Replace("{imemid}", imemid);
        body = body.Replace("{iname}", iname);
        body = body.Replace("{date}", datenow);
        body = body.Replace("{grid}", listviewData(lstviewedProfileForEmail));
        body = body.Replace("{viewProfile}", "http://swapnpurti.in/Admin/SubMemberLogin.aspx?mid=" + Session["memberid"].ToString() + "&eml=" + dbc.get_member_Email(imemid) + "&cde=" + dbc.get_member_EmailCode(imemid) + "&for=ViewMember&from=Member");

        return body;
    }
    protected void sendmailshort(string memid, string imemid)
    {
        try
        {
            dbc.con.Open();
            string m_name = dbc.get_member_name(Session["memberid"].ToString());
            string i_name = dbc.get_member_name(imemid);
            string email = dbc.get_member_Email(imemid);
            dbc.con.Close();
            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(email)))
            {

                mm.Subject = "Swapnpurti Matrimony : Shortlisted You !!!";
                string datenow = DateTimeOffset.UtcNow.LocalDateTime.ToLongDateString();

                mm.Body = PopulateBodyshort(memid, m_name, i_name, email, imemid);

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
    public string listviewData(ListView gv)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gv.RenderControl(htw);

        return sb.ToString();
    }

    string IntersestMemInId = string.Empty;
    string IntersestMemInDate = string.Empty;
    string IntersestMemInName = string.Empty;
    string IntersestMemInAccFor = string.Empty;
    string IntersestMemInAbout = string.Empty;
    string IntersestMemInAge = string.Empty;
    string IntersestMemInReligion = string.Empty;
    string IntersestMemInCaste = string.Empty;
    string IntersestMemInSCaste = string.Empty;
    string IntersestMemInCity = string.Empty;
    string IntersestMemInState = string.Empty;
    string IntersestMemInCountry = string.Empty;
    string IntersestMemInEducation = string.Empty;
    string IntersestMemInOccupation = string.Empty;
    string IntersestMemInHeight = string.Empty;
    string IntersestMemInHeightcm = string.Empty;
    string IntersestMemInPhoto = string.Empty;
    string IntersestMemInPackage = string.Empty;

    public void       getInterestedInMeProfiles()
    {

        ////data reader we will use to read data from our tables
        MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr2, rdr3, rdr4, rdr5, rdr6, rdr7, rdr8;

        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[18] {             
                        new DataColumn("IntersestMemInId", typeof(string)),                         
                        new DataColumn("IntersestMemInDate", typeof(string)),
                        new DataColumn("IntersestMemInName", typeof(string)),
                        new DataColumn("IntersestMemInAccFor", typeof(string)), 
                        new DataColumn("IntersestMemInPhoto", typeof(string)),  
                        new DataColumn("IntersestMemInAbout", typeof(string)),  
                        new DataColumn("IntersestMemInAge", typeof(string)), 
                        new DataColumn("IntersestMemInReligion", typeof(string)), 
                        new DataColumn("IntersestMemInCaste", typeof(string)),   
                        new DataColumn("IntersestMemInSCaste", typeof(string)),    
                        new DataColumn("IntersestMemInCity", typeof(string)),  
                        new DataColumn("IntersestMemInState", typeof(string)), 
                        new DataColumn("IntersestMemInCountry", typeof(string)),    
                        new DataColumn("IntersestMemInEducation", typeof(string)),    
                        new DataColumn("IntersestMemInOccupation", typeof(string)),    
                        new DataColumn("IntersestMemInHeight", typeof(string)),    
                        new DataColumn("IntersestMemInHeightcm", typeof(string)),                           
                        new DataColumn("IntersestMemInPackage", typeof(string)),    
                                 
        });

        DataRow dr = dt.NewRow();

        MySql.Data.MySqlClient.MySqlConnection cnn1 = new MySql.Data.MySqlClient.MySqlConnection();
        cnn1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

        //get shortlisted profiles
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varInterestOfId as IntersestMemInId, varDate as IntersestMemInDate FROM tblammemberinterests WHERE (varInterestInId = '" + Session["memberid"].ToString() + "') ORDER BY RAND() LIMIT 0,2", cnn1);
        cmd1.CommandType = CommandType.Text;

        using (cnn1)
        {
            //open connection
            cnn1.Open();
            //read data from the table to our data reader
            rdr1 = cmd1.ExecuteReader();
            //loop through each row we have read
            while (rdr1.Read())
            {
                IntersestMemInId = rdr1["IntersestMemInId"].ToString();
                IntersestMemInDate = rdr1["IntersestMemInDate"].ToString();

                string[] gender = dbc.getGender(IntersestMemInId).Split(new char[] { '\'' });
                if (gender[1] == gen)
                {
                    // get data from table tblammemberregistration

                    MySql.Data.MySqlClient.MySqlConnection cnn2 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName as IntersestMemInName,varMemberFor as IntersestMemInAccFor,varPhoto as IntersestMemInPhoto,ex3,varGender,varPhotoApprove FROM tblammemberregistration WHERE (varMemberId = '" + IntersestMemInId + "') and varMemberStatus='Verified'", cnn2);
                    cmd2.CommandType = CommandType.Text;

                    using (cnn2)
                    {
                        cnn2.Open();
                        rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            IntersestMemInName = rdr2["IntersestMemInName"].ToString();
                            IntersestMemInAccFor = rdr2["IntersestMemInAccFor"].ToString();
                            if (rdr2["varPhotoApprove"].ToString() == "Approved")
                            {
                                if (rdr2["varGender"].ToString() == "Female")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        IntersestMemInPhoto = "FemaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        IntersestMemInPhoto = "FemaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        IntersestMemInPhoto = rdr2["IntersestMemInPhoto"].ToString();
                                    }
                                }
                                else if (rdr2["varGender"].ToString() == "Male")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        IntersestMemInPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        IntersestMemInPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        IntersestMemInPhoto = rdr2["IntersestMemInPhoto"].ToString();
                                    }
                                }
                                else if (rdr2["varGender"].ToString() == "Other")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        IntersestMemInPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        IntersestMemInPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        IntersestMemInPhoto = rdr2["IntersestMemInPhoto"].ToString();
                                    }
                                }
                            }
                            else
                            {
                                IntersestMemInPhoto = "NotApproved.jpg";
                            }
                        }
                        cnn2.Close();
                        rdr2.Close();
                    }

                    //end data from table tblammemberregistration

                    // get data from table tblammemberinformation

                    MySql.Data.MySqlClient.MySqlConnection cnn3 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn3.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varAgeToday as IntersestMemInAge, varAbout as IntersestMemInAbout FROM tblammemberinformation WHERE (varMemberId = '" + IntersestMemInId + "')", cnn3);
                    cmd3.CommandType = CommandType.Text;

                    using (cnn3)
                    {
                        cnn3.Open();
                        rdr3 = cmd3.ExecuteReader();
                        while (rdr3.Read())
                        {
                            IntersestMemInAge = rdr3["IntersestMemInAge"].ToString();
                            IntersestMemInAbout = rdr3["IntersestMemInAbout"].ToString();
                        }
                        cnn3.Close();
                        rdr3.Close();
                    }

                    //end data from table tblammemberinformation

                    // get data from table tblammemberreligiousinfo

                    MySql.Data.MySqlClient.MySqlConnection cnn4 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn4.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd4 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varReligion as IntersestMemInReligion, varCasteDivision as IntersestMemInCaste, varSubcaste as IntersestMemInSCaste FROM tblammemberreligiousinfo WHERE (varMemberId = '" + IntersestMemInId + "')", cnn4);
                    cmd4.CommandType = CommandType.Text;

                    using (cnn4)
                    {
                        cnn4.Open();
                        rdr4 = cmd4.ExecuteReader();
                        while (rdr4.Read())
                        {
                            IntersestMemInReligion = rdr4["IntersestMemInReligion"].ToString();
                            IntersestMemInCaste = rdr4["IntersestMemInCaste"].ToString();
                            IntersestMemInSCaste = rdr4["IntersestMemInSCaste"].ToString();
                        }
                        cnn4.Close();
                        rdr4.Close();
                    }

                    //end data from table tblammemberreligiousinfo

                    // get data from table tblammemberlivingin

                    MySql.Data.MySqlClient.MySqlConnection cnn5 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn5.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd5 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCity as IntersestMemInCity, varState as IntersestMemInState, varCountry as IntersestMemInCountry FROM tblammemberlivingin WHERE (varMemberId = '" + IntersestMemInId + "')", cnn5);
                    cmd5.CommandType = CommandType.Text;

                    using (cnn5)
                    {
                        cnn5.Open();
                        rdr5 = cmd5.ExecuteReader();
                        while (rdr5.Read())
                        {
                            IntersestMemInCity = rdr5["IntersestMemInCity"].ToString();
                            IntersestMemInState = rdr5["IntersestMemInState"].ToString();
                            IntersestMemInCountry = rdr5["IntersestMemInCountry"].ToString();

                        }
                        cnn5.Close();
                        rdr5.Close();
                    }

                    //end data from table tblammemberlivingin

                    // get data from table tblammemberprofessionalinfo

                    MySql.Data.MySqlClient.MySqlConnection cnn6 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn6.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd6 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varEducation as IntersestMemInEducation, varOccupation as IntersestMemInOccupation FROM tblammemberprofessionalinfo WHERE (varMemberId = '" + IntersestMemInId + "')", cnn6);
                    cmd6.CommandType = CommandType.Text;


                    using (cnn6)
                    {
                        cnn6.Open();
                        rdr6 = cmd6.ExecuteReader();
                        while (rdr6.Read())
                        {
                            IntersestMemInOccupation = rdr6["IntersestMemInOccupation"].ToString();
                            IntersestMemInEducation = rdr6["IntersestMemInEducation"].ToString();
                        }
                        cnn6.Close();
                        rdr6.Close();
                    }

                    //end data from table tblammemberprofessionalinfo

                    // get data from table tblammemberphysicalinformation

                    MySql.Data.MySqlClient.MySqlConnection cnn7 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn7.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd7 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varHeightFt as IntersestMemInHeight, varHeightCm as IntersestMemInHeightcm FROM tblammemberphysicalinformation WHERE (varMemberId = '" + IntersestMemInId + "')", cnn7);
                    cmd7.CommandType = CommandType.Text;


                    using (cnn7)
                    {
                        cnn7.Open();
                        rdr7 = cmd7.ExecuteReader();
                        while (rdr7.Read())
                        {
                            IntersestMemInHeight = rdr7["IntersestMemInHeight"].ToString();
                            IntersestMemInHeightcm = rdr7["IntersestMemInHeightcm"].ToString();
                        }
                        cnn7.Close();
                        rdr7.Close();
                    }

                    //end data from table tblammemberphysicalinformation

                    // get data from table tblampackages

                    MySql.Data.MySqlClient.MySqlConnection cnn8 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn8.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd8 = new MySql.Data.MySqlClient.MySqlCommand("SELECT DISTINCT tblampackages.varPackageName as IntersestMemInPackage FROM tblammembertransactions, tblampackages WHERE (tblammembertransactions.varMemberId = '" + IntersestMemInId + "')", cnn8);
                    cmd8.CommandType = CommandType.Text;

                    using (cnn8)
                    {
                        cnn8.Open();
                        rdr8 = cmd8.ExecuteReader();
                        while (rdr8.Read())
                        {
                            IntersestMemInPackage = rdr8["IntersestMemInPackage"].ToString();
                        }
                        cnn8.Close();
                        rdr8.Close();
                    }

                    //end data from table tblampackages

                    // add row to datatable
                    dt.Rows.Add(IntersestMemInId, IntersestMemInDate, IntersestMemInName, IntersestMemInAccFor, IntersestMemInPhoto, IntersestMemInAbout, IntersestMemInAge, IntersestMemInReligion, IntersestMemInCaste, IntersestMemInSCaste, IntersestMemInCity, IntersestMemInState, IntersestMemInCountry, IntersestMemInEducation, IntersestMemInOccupation, IntersestMemInHeight, IntersestMemInHeightcm, IntersestMemInPackage);
                    // Empty strings

                    IntersestMemInName = string.Empty;
                    IntersestMemInAccFor = string.Empty;
                    IntersestMemInAbout = string.Empty;
                    IntersestMemInAge = string.Empty;
                    IntersestMemInReligion = string.Empty;
                    IntersestMemInCaste = string.Empty;
                    IntersestMemInSCaste = string.Empty;
                    IntersestMemInCity = string.Empty;
                    IntersestMemInState = string.Empty;
                    IntersestMemInCountry = string.Empty;
                    IntersestMemInEducation = string.Empty;
                    IntersestMemInOccupation = string.Empty;
                    IntersestMemInHeight = string.Empty;
                    IntersestMemInHeightcm = string.Empty;
                    IntersestMemInPhoto = string.Empty;
                    IntersestMemInPackage = string.Empty;
                }
            }
            cnn1.Close();
            rdr1.Close();
        }

        InterestListview.DataSource = dt;
        InterestListview.DataBind();

    }
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

            lstviewedProfileForEmail.DataSource = dt;
            lstviewedProfileForEmail.DataBind();
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
    private string PopulateBody(string memid, string mname, string iname, string email, string imemid)//, string age, string height, string religion, string caste, string city, string state,string country, string edu,string occp)
    {
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Admin/emails/Interest.html")))
        {
            body = reader.ReadToEnd();
        } string datenow = DateTimeOffset.UtcNow.LocalDateTime.ToLongDateString();
        body = body.Replace("{mname}", mname);
        body = body.Replace("{memid}", Session["memberid"].ToString());
        body = body.Replace("{email}", email);
        body = body.Replace("{imemid}", imemid);
        body = body.Replace("{iname}", iname);
        body = body.Replace("{date}", datenow);
        body = body.Replace("{grid}", listviewData(lstviewedProfileForEmail));
        body = body.Replace("{viewProfile}", "http://swapnpurti.in/Admin/SubMemberLogin.aspx?mid=" + Session["memberid"].ToString() + "&eml=" + dbc.get_member_Email(imemid) + "&cde=" + dbc.get_member_EmailCode(imemid) + "&for=ViewMember&from=Member");

        return body;
    }
    protected void sendmail(string memid, string imemid)
    {
        try
        {
            dbc.con.Open();
            string m_name = dbc.get_member_name(Session["memberid"].ToString());
            string i_name = dbc.get_member_name(imemid);
            string email = dbc.get_member_Email(imemid);
            dbc.con.Close();
            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(email)))
            {

                mm.Subject = "Swapnpurti Matrimony : Interested In You !!!";
                string datenow = DateTimeOffset.UtcNow.LocalDateTime.ToLongDateString();

                mm.Body = PopulateBody(memid, m_name, i_name, email, imemid);

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


    protected void uploadpic_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/UserProfile/UploadPic.aspx");
    }
    protected void editprofile_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Members/UserProfile/Self/EditPersonalDetails.aspx");
    }

    
}