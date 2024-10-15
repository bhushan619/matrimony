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
using UNLV.IAP.WebControls;

public partial class ApproveMembersPictures : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    string[] arg = new string[2];
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
                AdminBasicData();
                notifications();
                getProfileProfiles();
                getOtherPics();
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
            dbc.dr.Dispose();
            dbc.con.Close();
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


    string IntersestMemId = string.Empty;
    
    string IntersestMemName = string.Empty;
  
    string IntersestMemPhoto = string.Empty;
    string IntersestMemPhotoType = string.Empty;
   

    public void getProfileProfiles()
    {

        ////data reader we will use to read data from our tables
        MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr2;

        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] {             
                        new DataColumn("IntersestMemId", typeof(string)),                         
                      
                        new DataColumn("IntersestMemName", typeof(string)),
                      
                        new DataColumn("IntersestMemPhoto", typeof(string)),   
        });

        DataRow dr = dt.NewRow();

        MySql.Data.MySqlClient.MySqlConnection cnn1 = new MySql.Data.MySqlClient.MySqlConnection();
        cnn1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

        //get shortlisted profiles
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId as IntersestMemId FROM tblammemberregistration WHERE varMemberId= '" + Session["MemberId"].ToString() + "' and varPhotoApprove!='Approved'", cnn1);
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
                IntersestMemId = rdr1["IntersestMemId"].ToString();

                MySql.Data.MySqlClient.MySqlConnection cnn2 = new MySql.Data.MySqlClient.MySqlConnection();
                cnn2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName as IntersestMemName,varMemberFor as IntersestMemAccFor,varPhoto as IntersestMemPhoto,ex3,varGender FROM tblammemberregistration WHERE (varMemberId = '" + IntersestMemId + "')", cnn2);
                cmd2.CommandType = CommandType.Text;

                using (cnn2)
                {
                    cnn2.Open();
                    rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        IntersestMemName = rdr2["IntersestMemName"].ToString();

                        IntersestMemPhoto = rdr2["IntersestMemPhoto"].ToString();
                    }
                    cnn2.Close();
                    rdr2.Close();
                }

                //end data from table tblammemberregistration



                // add row to datatable
                dt.Rows.Add(IntersestMemId, IntersestMemName, IntersestMemPhoto);
                // Empty strings
                IntersestMemId = string.Empty;

                IntersestMemName = string.Empty;

                IntersestMemPhoto = string.Empty;
            }
            cnn1.Close();
            rdr1.Close();
        }

        lstProfilePics.DataSource = dt;
        lstProfilePics.DataBind();

    }
    protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (lstProfilePics.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        this.getProfileProfiles();
    }

    public void getOtherPics()
    {

        ////data reader we will use to read data from our tables
        MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr2;

        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[4] {             
                        new DataColumn("IntersestMemId", typeof(string)),                         
                      
                        new DataColumn("IntersestMemName", typeof(string)),
                      
                        new DataColumn("IntersestMemPhoto", typeof(string)), 
                         new DataColumn("IntersestMemPhotoType", typeof(string)),
                    
                                 
        });
        
        DataRow dr = dt.NewRow();

        MySql.Data.MySqlClient.MySqlConnection cnn1 = new MySql.Data.MySqlClient.MySqlConnection();
        cnn1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

        //get shortlisted profiles
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId as IntersestMemId,varUploadPath as IntersestMemPhoto,varPhotoType as IntersestMemPhotoType  FROM tblammemberuploads WHERE varMemberId= '" + Session["MemberId"].ToString() + "' and varApproval!='Approved' AND varUploadType='Photo' ", cnn1);
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
                IntersestMemId = rdr1["IntersestMemId"].ToString();
                IntersestMemPhoto = rdr1["IntersestMemPhoto"].ToString();
                IntersestMemPhotoType = rdr1["IntersestMemPhotoType"].ToString();

                MySql.Data.MySqlClient.MySqlConnection cnn2 = new MySql.Data.MySqlClient.MySqlConnection();
                cnn2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName as IntersestMemName FROM tblammemberregistration WHERE (varMemberId = '" + IntersestMemId + "')", cnn2);
                cmd2.CommandType = CommandType.Text;

                using (cnn2)
                {
                    cnn2.Open();
                    rdr2 = cmd2.ExecuteReader();
                    while (rdr2.Read())
                    {
                        IntersestMemName = rdr2["IntersestMemName"].ToString();

                    }
                    cnn2.Close();
                    rdr2.Close();
                }

                //end data from table tblammemberregistration 

                // add row to datatable
                dt.Rows.Add(IntersestMemId, IntersestMemName, IntersestMemPhoto, IntersestMemPhotoType);
                // Empty strings
                IntersestMemId = string.Empty;

                IntersestMemName = string.Empty;

                IntersestMemPhoto = string.Empty;
                IntersestMemPhotoType = string.Empty;
            }
            cnn1.Close();
            rdr1.Close();
        }

        GroupingViewPhotoAlbum.DataSource = dt;
        GroupingViewPhotoAlbum.DataBind();

    }

    //protected void OnPagePropertiesChangingOther(object sender, PagePropertiesChangingEventArgs e)
    //{
    //    (lstOtherPics.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
    //    this.getOtherPics();
    //}

    protected void lnkApprove_Click(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberregistration SET varPhotoApprove='Approved' WHERE varMemberId='" + (sender as LinkButton).CommandArgument + "'", dbc.con);

            cmd.ExecuteNonQuery();
            dbc.con.Close();
            cmd.Dispose();
            dbc.insert_tblamnotifications("Message", Session["adminid"].ToString(), lblAdminName.Text, "Admin", (sender as LinkButton).CommandArgument, "Member", "Congratulations !!! Your Profile Photo is Approved...", "", "", "Unread", "");
            ScriptManager.RegisterStartupScript(
                              this,
                              this.GetType(),
                              "MessageBox",
                              "alert(' Profile Photo Approved !!!');window.location='ApproveMembersPictures.aspx';", true);
           // Response.Redirect("ApproveMembersPictures.aspx");
        }
        catch (Exception s)
        {
            dbc.con.Close();
           
        }
    }
    protected void lnkReject_Click(object sender, EventArgs e)
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberregistration SET varPhotoApprove='Rejected' WHERE varMemberId='" + (sender as LinkButton).CommandArgument + "'", dbc.con);

            cmd.ExecuteNonQuery();
            dbc.con.Close();
            cmd.Dispose();
            dbc.insert_tblamnotifications("Page", Session["adminid"].ToString(), lblAdminName.Text, "Admin", (sender as LinkButton).CommandArgument, "Member", " Your Profile Photo is Rejected...Please Upload Valid Photo..", "~/Members/UserProfile/UploadPic.aspx", "", "Unread", "");
            ScriptManager.RegisterStartupScript(
                             this,
                             this.GetType(),
                             "MessageBox",
                             "alert(' Profile Photo Rejected !!!');window.location='ApproveMembersPictures.aspx';", true);
        }
        catch (Exception s)
        {
            dbc.con.Close();
        }
    }
    protected void lnkApprove_Click1(object sender, EventArgs e)
    {
        try
        {

            arg = (sender as LinkButton).CommandArgument.ToString().Split(';');
            //arg = e.CommandArgument.ToString().Split(';');
            //Session["IdTemplate"] = arg[0];
            //Session["IdEntity"] = arg[1];
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberuploads SET varApproval='Approved' WHERE varMemberId='" + arg[0] + "' and varUploadPath='"+arg[1]+"'", dbc.con);

            cmd.ExecuteNonQuery();
            dbc.con.Close();
            cmd.Dispose();
            dbc.insert_tblamnotifications("Page", Session["adminid"].ToString(), lblAdminName.Text, "Admin", arg[0], "Member", "Congratulations !!! Your Photo " + arg[1] + " is Approved...", "~/members/Photo/InfoUpload.aspx", "", "Unread", "");
            ScriptManager.RegisterStartupScript(
                               this,
                               this.GetType(),
                               "MessageBox",
                               "alert('  Photo Approved !!!');window.location='ApproveMembersPictures.aspx';", true);
           // Response.Redirect("ApproveMembersPictures.aspx");
        }
        catch (Exception s)
        {
            dbc.con.Close();
           
        }
    }
    protected void lnkReject_Click1(object sender, EventArgs e)
    {
        try
        {
            arg = (sender as LinkButton).CommandArgument.ToString().Split(';');
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberuploads SET varApproval='Rejected' WHERE  varMemberId='" + arg[0] + "' and varUploadPath='" + arg[1] + "'", dbc.con);

            cmd.ExecuteNonQuery();
            dbc.con.Close();
            cmd.Dispose();
            dbc.insert_tblamnotifications("Page", Session["adminid"].ToString(), lblAdminName.Text, "Admin", arg[0], "Member", "Your Photo " + arg[1] + " is Rejected...Please Add Valid Photo", "~/members/Photo/InfoUpload.aspx", "", "Unread", "");
            ScriptManager.RegisterStartupScript(
                              this,
                              this.GetType(),
                              "MessageBox",
                              "alert('  Photo Rejected !!!');window.location='ApproveMembersPictures.aspx';", true);
        }
        catch (Exception s)
        {
            dbc.con.Close(); 
        }

    }
    protected void GroupingViewPhotoAlbum_Command(object o, GroupingViewCommandEventArgs e)
    {

    }
}