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
using System.Text;

public partial class members_Message_Request : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    static string gen = string.Empty;
    static string imgpic = string.Empty;
    static string fid = string.Empty;
    static string tid = string.Empty;

    DatabaseConnection dbc = new DatabaseConnection();

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
            getRequestProfiles();
            getrequestcount();  
            getDataMessages();   
            lblcountfinalmsg.Text =(Convert.ToInt32(lblcountmsg.Text) + Convert.ToInt32(lblrequest.Text)).ToString();   
         
         
           notifications();
        }
    }

    //public void listdatabind()
    //{
    //    try
    //    {
    //        dbc.con.Close();
    //        MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varFromMemberId, varFromMembarName, varFromMemberStatus, varToMemberId, varToMembarName, varToMemberStatus, varRequestType, varStatus, varDate, varTime FROM tblamrequests where (varToMemberId = '" + Session["memberid"].ToString() + "') and varStatus!='Accepted'    ORDER BY varDate", dbc.con);
    //        dbc.con.Open();

    //        MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmde);
    //        ad.Fill(dt);
    //       // lstInbox.DataSource = dt;
    //       // lstInbox.DataBind();
    //        dbc.dr = cmde.ExecuteReader();
    //        if (dbc.dr.Read())
    //        {
    //            fid = dbc.dr["varFromMemberId"].ToString();
    //            tid = dbc.dr["varToMemberId"].ToString();
              
    //        }
           
    //        dbc.con.Close();
    //        dbc.dr.Close();
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
    protected void DeleteShortlistedProfile(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Close();
            string delId = (sender as LinkButton).CommandArgument;
            MySql.Data.MySqlClient.MySqlCommand cmd47 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamrequests where varFromMemberId='" + delId + "'", dbc.con);

            dbc.con.Open();
            cmd47.ExecuteReader();
            dbc.con.Close();
            dbc.insert_tblamnotifications("Message", Session["memberid"].ToString(), lblMemberName.Text, "Member", delId, "Member", "Request Declined from : " + lblMemberName.Text + "", "", "", "Unread", "");
            Response.Redirect("Request.aspx");
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
            this.GetType(), "OpenWindow", "window.open('../SearchMatches/ViewProfile.aspx','_blank');", true);

    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (lstShortProfiles.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.getRequestProfiles();
    } 
    string SlstMemId = string.Empty;
    string SlstMemDate = string.Empty;
    string SlstMemName = string.Empty;
   
    string SlstMemAge = string.Empty;
   
    string SlstMemCaste = string.Empty;
   
    string SlstMemCity = string.Empty;
    
    string SlstMemReqType = string.Empty;//for heht  req type
    string SlstMemReqFor = string.Empty;//for heht cm req for
    string SlstMemPhoto = string.Empty;
    string SlstMemTime = string.Empty;//for pack time


    public void getRequestProfiles()
    {
        try
        {

            ////data reader we will use to read data from our tables
            MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr2, rdr3, rdr4, rdr5, rdr6, rdr7, rdr8;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[10] {             
                        new DataColumn("SlstMemId", typeof(string)),                         
                        new DataColumn("SlstMemDate", typeof(string)),
                        new DataColumn("SlstMemName", typeof(string)),
                       
                        new DataColumn("SlstMemPhoto", typeof(string)),  
                       
                        new DataColumn("SlstMemAge", typeof(string)), 
                      
                        new DataColumn("SlstMemCaste", typeof(string)),   
                       
                        new DataColumn("SlstMemCity", typeof(string)),  
                      
                        new DataColumn("SlstMemReqType", typeof(string)),    
                        new DataColumn("SlstMemReqFor", typeof(string)),                           
                        new DataColumn("SlstMemTime", typeof(string)),    
                                 
        });

            DataRow dr = dt.NewRow();

            MySql.Data.MySqlClient.MySqlConnection cnn1 = new MySql.Data.MySqlClient.MySqlConnection();
            cnn1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

            //get shortlisted profiles                                                                            //SELECT intId, varFromMemberId  as SlstMemId, varFromMembarName, varFromMemberStatus, varToMemberId, varToMembarName, varToMemberStatus, varRequestType, varStatus, varDate, varTime FROM tblamrequests where (varToMemberId = '" + Session["memberid"].ToString() + "') and varStatus!='Accepted'    ORDER BY varDate
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId, varFromMemberId  as SlstMemId, varFromMembarName, varFromMemberStatus, varToMemberId, varToMembarName, varToMemberStatus, varRequestType as SlstMemReqType, varStatus, varDate as SlstMemDate, varTime as SlstMemTime,varRequestShortType as SlstMemReqFor FROM tblamrequests where (varToMemberId = '" + Session["memberid"].ToString() + "') and varStatus!='Accepted'    ORDER BY varDate", cnn1);
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

                    SlstMemReqType = rdr1["SlstMemReqType"].ToString();
                    SlstMemReqFor = rdr1["SlstMemReqFor"].ToString();

                    SlstMemTime = rdr1["SlstMemTime"].ToString();
                    fid = rdr1["SlstMemId"].ToString();
                    tid = rdr1["varToMemberId"].ToString();
                    string[] gender = dbc.getGender(SlstMemId).Split(new char[] { '\'' });
                    if (gender[1] == gen)
                    {
                        // get data from table tblammemberregistration

                        MySql.Data.MySqlClient.MySqlConnection cnn2 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT  varMemberName as SlstMemName,varMemberFor as SlstMemAccFor,varPhoto as SlstMemPhoto,ex3,varGender,varPhotoApprove FROM tblammemberregistration WHERE (varMemberId = '" + SlstMemId + "') and varMemberStatus='Verified'", cnn2);
                        cmd2.CommandType = CommandType.Text;

                        using (cnn2)
                        {
                            cnn2.Open();
                            rdr2 = cmd2.ExecuteReader();
                            while (rdr2.Read())
                            {
                                SlstMemName = rdr2["SlstMemName"].ToString();
                                
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
                              //  SlstMemAbout = rdr3["SlstMemAbout"].ToString();
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
                               // SlstMemReligion = rdr4["SlstMemReligion"].ToString();
                                SlstMemCaste = rdr4["SlstMemCaste"].ToString();
                              //  SlstMemSCaste = rdr4["SlstMemSCaste"].ToString();
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
                               // SlstMemState = rdr5["SlstMemState"].ToString();
                               // SlstMemCountry = rdr5["SlstMemCountry"].ToString();

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
                               // SlstMemOccupation = rdr6["SlstMemOccupation"].ToString();
                               // SlstMemEducation = rdr6["SlstMemEducation"].ToString();
                            }
                            cnn6.Close();
                            rdr6.Close();
                        }

                        //end data from table tblammemberprofessionalinfo

                        // get data from table tblammemberphysicalinformation

                        MySql.Data.MySqlClient.MySqlConnection cnn7 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn7.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd7 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varHeightFt as SlstMemReqType, varHeightCm as SlstMemReqFor FROM tblammemberphysicalinformation WHERE (varMemberId = '" + SlstMemId + "')", cnn7);
                        cmd7.CommandType = CommandType.Text;


                        using (cnn7)
                        {
                            cnn7.Open();
                            rdr7 = cmd7.ExecuteReader();
                            while (rdr7.Read())
                            {
                               // SlstMemReqType = rdr7["SlstMemReqType"].ToString();
                               // SlstMemReqFor = rdr7["SlstMemReqFor"].ToString();
                            }
                            cnn7.Close();
                            rdr7.Close();
                        }

                        //end data from table tblammemberphysicalinformation

                        // get data from table tblampackages

                        MySql.Data.MySqlClient.MySqlConnection cnn8 = new MySql.Data.MySqlClient.MySqlConnection();
                        cnn8.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                        MySql.Data.MySqlClient.MySqlCommand cmd8 = new MySql.Data.MySqlClient.MySqlCommand("SELECT tblampackages.varPackageName as SlstMemTime FROM tblammembertransactions, tblampackages WHERE (tblammembertransactions.varMemberId = '" + SlstMemId + "')", cnn8);
                        cmd8.CommandType = CommandType.Text;

                        using (cnn8)
                        {
                            cnn8.Open();
                            rdr8 = cmd8.ExecuteReader();
                            while (rdr8.Read())
                            {
                               // SlstMemTime = rdr8["SlstMemTime"].ToString();
                            }
                            cnn8.Close();
                            rdr8.Close();
                        }

                        //end data from table tblampackages
                       
                        // add row to datatable
                        dt.Rows.Add(SlstMemId, SlstMemDate,SlstMemName,  SlstMemPhoto, SlstMemAge, SlstMemCaste, SlstMemCity, SlstMemReqType,SlstMemReqFor,  SlstMemTime);
                        // Empty strings
                          SlstMemId = string.Empty;
                        SlstMemDate = string.Empty;
                        SlstMemName = string.Empty;
                      
                        SlstMemAge = string.Empty;
                       
                        SlstMemCaste = string.Empty;
                       
                        SlstMemCity = string.Empty;
                      
                        SlstMemReqType = string.Empty;
                        SlstMemReqFor = string.Empty;
                        SlstMemPhoto = string.Empty;
                        SlstMemTime = string.Empty;
                    }
                }
                cnn1.Close();
                rdr1.Close();
            }

            lstShortProfiles.DataSource = dt;
            lstShortProfiles.DataBind();
         
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
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varMemberName,varGender,varMembershipType,varPhoto FROM tblammemberregistration WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblMemberId.Text = dbc.dr["varMemberId"].ToString();
                lblMemberName.Text = dbc.dr["varMemberName"].ToString();
             
                imgpic = dbc.dr["varPhoto"].ToString();
                gen = dbc.dr["varGender"].ToString();
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
                lblrequest.Text = (Convert.ToInt32(lblrequest.Text) + Convert.ToInt32(dbc.dr["myrequest"].ToString())).ToString();
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

                            lblcountmsg.Text = (Convert.ToInt32(lblcountmsg.Text) + Convert.ToInt32(rdr3["mycount"].ToString())).ToString();


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

                            lblcountmsg.Text = (Convert.ToInt32(lblcountmsg.Text) + Convert.ToInt32(rdr3["mycount"].ToString())).ToString();


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
    protected void lnkphoto_Click(object sender, EventArgs e)
    {
        try
        {
            int insert_ok = dbc.update_tblamrequests(tid, fid, "Accepted");//dbc.update_tblammemberregistration_Photo(Session["memberid"].ToString(), imgpic, "Viewable");
            if (insert_ok == 1)
            {
                dbc.insert_tblamnotifications("Session", Session["memberid"].ToString(), lblMemberName.Text, "Member", fid, "Member", "Request Accepted from : " + lblMemberName.Text + "", "~/Members/SearchMatches/ViewProfile.aspx", Session["memberid"].ToString(), "Unread", "");
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Photo Request is Accepted !!! Profile Photo is now Viewable');window.location='Request.aspx'; ", true);
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
    protected void lnkDeclined_Click(object sender, EventArgs e)
    {
        try
        {
            int insert_ok= dbc.update_tblamrequests(tid, fid, "Rejected");
            if (insert_ok == 1)
            {
                dbc.insert_tblamnotifications("Message", Session["memberid"].ToString(), lblMemberName.Text, "Member", fid, "Member", "Request Declined from : " + lblMemberName.Text + "", "", "", "Unread", "");
                ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Photo Request has been Declined');window.location='Request.aspx'; ", true);
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
}