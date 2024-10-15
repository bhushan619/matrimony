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
using MySql.Data.MySqlClient;
using System.Text;

public partial class members_Activities_WhoShortlistedMyProfile : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable(); static string gen = string.Empty;
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
           
            getShortProfiles();
            getViwedProfileDetails();
            InterestListview.Visible = false;
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
               // lblMembership.Text = dbc.dr["varMembershipType"].ToString();

                gen = dbc.dr["varGender"].ToString();
                imgMemberPhoto.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();
                if (dbc.dr["varMembershipType"].ToString() == "Paid")
                {
                    MySql.Data.MySqlClient.MySqlCommand cmdm = new MySql.Data.MySqlClient.MySqlCommand("SELECT DISTINCT tblampackages.varPackageName as ViewMemPackage FROM tblammembertransactions, tblampackages WHERE (tblammembertransactions.varMemberId = '" + lblMemberId.Text + "')", dbc.con1);

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
            lblmyprofilecompletness.Text = dbc.getInActiveGridview(Session["memberid"].ToString()).ToString();
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
    protected void OpenProfile(object sender, EventArgs e)
    {

        Session["SearchMemberId"] = (sender as LinkButton).CommandArgument;
        //Response.Redirect("~/members/UserProfile/ViewProfile.aspx");
        Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('../SearchMatches/ViewProfile.aspx','_blank');", true);

    }

    string SlstMemId = string.Empty;
    string SlstMemDate = string.Empty;
    string SlstMemName = string.Empty;
    string SlstMemAccFor = string.Empty;
    string SlstMemAbout = string.Empty;
    string SlstMemAge = string.Empty;
    string SlstMemReligion = string.Empty;
    string SlstMemCaste = string.Empty;
    string SlstMemSCaste = string.Empty;
    string SlstMemCity = string.Empty;
    string SlstMemState = string.Empty;
    string SlstMemCountry = string.Empty;
    string SlstMemEducation = string.Empty;
    string SlstMemOccupation = string.Empty;
    string SlstMemHeight = string.Empty;
    string SlstMemHeightcm = string.Empty;
    string SlstMemPhoto = string.Empty;
    string SlstMemPackage = string.Empty;


    public void getShortProfiles()
    {

        ////data reader we will use to read data from our tables
        MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr2, rdr3, rdr4, rdr5, rdr6, rdr7, rdr8;

        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[18] {             
                        new DataColumn("SlstMemId", typeof(string)),                         
                        new DataColumn("SlstMemDate", typeof(string)),
                        new DataColumn("SlstMemName", typeof(string)),
                        new DataColumn("SlstMemAccFor", typeof(string)), 
                        new DataColumn("SlstMemPhoto", typeof(string)),  
                        new DataColumn("SlstMemAbout", typeof(string)),  
                        new DataColumn("SlstMemAge", typeof(string)), 
                        new DataColumn("SlstMemReligion", typeof(string)), 
                        new DataColumn("SlstMemCaste", typeof(string)),   
                        new DataColumn("SlstMemSCaste", typeof(string)),    
                        new DataColumn("SlstMemCity", typeof(string)),  
                        new DataColumn("SlstMemState", typeof(string)), 
                        new DataColumn("SlstMemCountry", typeof(string)),    
                        new DataColumn("SlstMemEducation", typeof(string)),    
                        new DataColumn("SlstMemOccupation", typeof(string)),    
                        new DataColumn("SlstMemHeight", typeof(string)),    
                        new DataColumn("SlstMemHeightcm", typeof(string)),                           
                        new DataColumn("SlstMemPackage", typeof(string)),    
                                 
        });

        DataRow dr = dt.NewRow();

        MySql.Data.MySqlClient.MySqlConnection cnn1 = new MySql.Data.MySqlClient.MySqlConnection();
        cnn1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

        //get shortlisted profiles
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId  as SlstMemId, varDate as SlstMemDate FROM tblammembershortlist WHERE (varShortListMemberId = '" + Session["memberid"].ToString() + "') ORDER BY RAND() LIMIT 0,9", cnn1);
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
                SlstMemDate = rdr1["SlstMemDate"].ToString();

                string[] gender = dbc.getGender(SlstMemId).Split(new char[] { '\'' });
                if (gender[1] == gen)
                {
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
                            SlstMemName = rdr2["SlstMemName"].ToString();
                            SlstMemAccFor = rdr2["SlstMemAccFor"].ToString();
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
                            SlstMemAbout = rdr3["SlstMemAbout"].ToString();
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
                            SlstMemReligion = rdr4["SlstMemReligion"].ToString();
                            SlstMemCaste = rdr4["SlstMemCaste"].ToString();
                            SlstMemSCaste = rdr4["SlstMemSCaste"].ToString();
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
                            SlstMemCity = rdr5["SlstMemCity"].ToString();
                            SlstMemState = rdr5["SlstMemState"].ToString();
                            SlstMemCountry = rdr5["SlstMemCountry"].ToString();

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
                            SlstMemOccupation = rdr6["SlstMemOccupation"].ToString();
                            SlstMemEducation = rdr6["SlstMemEducation"].ToString();
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
                            SlstMemHeightcm = rdr7["SlstMemHeightcm"].ToString();
                        }
                        cnn7.Close();
                        rdr7.Close();
                    }

                    //end data from table tblammemberphysicalinformation

                    // get data from table tblampackages

                    MySql.Data.MySqlClient.MySqlConnection cnn8 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn8.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd8 = new MySql.Data.MySqlClient.MySqlCommand("SELECT (SELECT distinct varPackageName FROM tblampackages WHERE varPackageId=tblammembertransactions.varPackageId) as SlstMemPackage FROM tblammembertransactions WHERE varMemberId='" + SlstMemId + "' order by intId asc", cnn8);
                    cmd8.CommandType = CommandType.Text;

                    using (cnn8)
                    {
                        cnn8.Open();
                        rdr8 = cmd8.ExecuteReader();
                        while (rdr8.Read())
                        {
                            SlstMemPackage = rdr8["SlstMemPackage"].ToString();
                        }
                        cnn8.Close();
                        rdr8.Close();
                    }

                    //end data from table tblampackages

                    // add row to datatable
                    dt.Rows.Add(SlstMemId, SlstMemDate, SlstMemName, SlstMemAccFor, SlstMemPhoto, SlstMemAbout, SlstMemAge, SlstMemReligion, SlstMemCaste, SlstMemSCaste, SlstMemCity, SlstMemState, SlstMemCountry, SlstMemEducation, SlstMemOccupation, SlstMemHeight, SlstMemHeightcm, SlstMemPackage);
                    // Empty strings
                    SlstMemId = string.Empty;
                    SlstMemDate = string.Empty;
                    SlstMemName = string.Empty;
                    SlstMemAccFor = string.Empty;
                    SlstMemAbout = string.Empty;
                    SlstMemAge = string.Empty;
                    SlstMemReligion = string.Empty;
                    SlstMemCaste = string.Empty;
                    SlstMemSCaste = string.Empty;
                    SlstMemCity = string.Empty;
                    SlstMemState = string.Empty;
                    SlstMemCountry = string.Empty;
                    SlstMemEducation = string.Empty;
                    SlstMemOccupation = string.Empty;
                    SlstMemHeight = string.Empty;
                    SlstMemHeightcm = string.Empty;
                    SlstMemPhoto = string.Empty;
                    SlstMemPackage = string.Empty;
                }
            }
            cnn1.Close();
            rdr1.Close();
        }

        lstShortProfiles.DataSource = dt;
        lstShortProfiles.DataBind();

    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (lstShortProfiles.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.getShortProfiles();
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
            string pictype = commandarguement[1].ToString();
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
                     sendmail(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument, "Interest");
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
                    sendmail(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument, "Shortlist");
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
    //Mail
    public string listviewData(ListView gv)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gv.RenderControl(htw);

        return sb.ToString();
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
    private string PopulateBody(string memid, string mname, string iname, string email, string imemid, string arg)
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
        }   string datenow = DateTimeOffset.UtcNow.LocalDateTime.ToLongDateString();
        body = body.Replace("{mname}", mname);
        body = body.Replace("{memid}", Session["memberid"].ToString());
        body = body.Replace("{email}", email);
        body = body.Replace("{imemid}", imemid);
        body = body.Replace("{iname}", iname);
        body = body.Replace("{date}", datenow);
        body = body.Replace("{grid}", listviewData(lstviewedProfile));
        body = body.Replace("{viewProfile}", "http://swapnpurti.in/Admin/SubMemberLogin.aspx?mid=" + Session["memberid"].ToString() + "&eml=" + dbc.get_member_Email(imemid) + "&cde=" + dbc.get_member_EmailCode(imemid) + "&for=ViewMember&from=Member");

        return body;
    }
    protected void sendmail(string memid, string imemid, string arg)
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

                if (arg == "Interest")
                {
                    mm.Subject = "Swapnpurti Matrimony : Interested In You !!!";
                    mm.Body = PopulateBody(memid, m_name, i_name, email, imemid, "Interest");
                }
                else if (arg == "Shortlist")
                {
                    mm.Subject = "Swapnpurti Matrimony : Shortlisted You !!!";
                    mm.Body = PopulateBody(memid, m_name, i_name, email, imemid, "Shortlist");
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