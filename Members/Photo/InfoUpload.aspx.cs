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

public partial class InfoUpload : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    string filename = string.Empty;
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
            hideControls();
            notifications();
        }
    }
    public void MemberBasicData()//not copy this additional functionality added
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varMemberName,varGender,varMembershipType,varPhoto,ex3 FROM tblammemberregistration WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblMemberId.Text = dbc.dr["varMemberId"].ToString();
                lblMemberName.Text = dbc.dr["varMemberName"].ToString();
                gen = dbc.dr["varGender"].ToString();
                imgMemberPhoto.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();
                imgProfilePic.ImageUrl = "~/members/media/" + dbc.dr["varPhoto"].ToString();
                lblprovisibility.Text = dbc.dr["ex3"].ToString();
              
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
                sqlfamilypic.SelectCommand = "SELECT intId,varPhotoType,varUploadPath,varVisibility,varApproval FROM  anuvaa_matrimony.tblammemberuploads where varMemberId='" + (Session["memberid"].ToString()) + "' and  varUploadType='Photo' ";
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

        Response.Redirect("~/Default.aspx");
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
    public void clear()
    {
        txtCaption.Text = "";
        ddlPhotoType.Text = "--PhotoType--";
        ddlVisibility.Text = "--Select Type--";
        ddlUploadType.Text = "--Select Type--";

    }
    public void hideControls()
    {
        lblCaption.Visible = false;
        lblphoto.Visible = false;
        lblPhototype.Visible = false;
        lblUploadBio.Visible = false;
        fupBiodata.Visible = false;
        fupPhoto.Visible = false;
        ddlPhotoType.Visible = false;
        txtCaption.Visible = false;
    }
    public void hidePhotoControls()
    {
        lblCaption.Visible = false;
        lblphoto.Visible = false;
        lblPhototype.Visible = false;
        fupPhoto.Visible = false;
        txtCaption.Visible = false;
        ddlPhotoType.Visible = false;
    }
    public void hideBiodataControls()
    {
        lblUploadBio.Visible = false;
        fupBiodata.Visible = false;
    }
    public void showPhotoControls()
    {
        lblCaption.Visible = true;
        txtCaption.Visible = true;
        lblphoto.Visible = true ;
        lblPhototype.Visible = true;
        fupPhoto.Visible = true;
        ddlPhotoType.Visible = true;
    }
    public void showBiodataControls()
    {
        lblUploadBio.Visible = true;
        fupBiodata.Visible = true;
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlUploadType.SelectedValue == "Photo")
            {
                if (!fupPhoto.HasFile)
                {
                    ScriptManager.RegisterStartupScript(
                     this,
                      this.GetType(),
                     "MessageBox",
                      "alert('Please select a File');", true);

                    return ;
                }
                else
                {
                    string ffileExt = System.IO.Path.GetExtension(fupPhoto.FileName);
                    if ((ffileExt == ".JPG") || (ffileExt == ".jpg") || (ffileExt == ".JPEG") || (ffileExt == ".jpeg") || (ffileExt == ".PNG") || (ffileExt == ".png"))
                    {
                        filename = Session["memberid"].ToString() + fupPhoto.FileName.ToString();
                        int insert_upload = dbc.insert_tblammemberuploads(Session["memberid"].ToString(), ddlUploadType.Text, txtCaption.Text, ddlPhotoType.Text, filename, ddlVisibility.Text);

                        if (insert_upload == 1)
                        {
                            fupPhoto.SaveAs(Server.MapPath("~/members/media/") + filename);
                           
                           ScriptManager.RegisterStartupScript(
                            this,
                            this.GetType(),
                            "MessageBox",
                            "alert('Photo Uploded');window.location='InfoUpload.aspx';", true);
                            clear();
                        }
                            
                        else
                        {
                            ScriptManager.RegisterStartupScript(
                            this,
                            this.GetType(),
                            "MessageBox",
                            "alert('Data Not Inserted');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(
                      this,
                      this.GetType(),
                      "MessageBox",
                      "alert('Please select proper image as .jpg or .png');", true);
                        return;
                    }
                }
               
            }
            else if (ddlUploadType.SelectedValue == "Biodata")
            {
                if (!fupBiodata.HasFile)
                {
                    ScriptManager.RegisterStartupScript(
                     this,
                      this.GetType(),
                     "MessageBox",
                      "alert('Please select a File');", true);

                    return;
                }
                else
                {

                    string ffileExt = System.IO.Path.GetExtension(fupBiodata.FileName);
                    if ((ffileExt == ".doc") || (ffileExt == ".docx") || (ffileExt == ".pdf") || (ffileExt == ".DOC") || (ffileExt == ".DOCX") || (ffileExt == ".PDF"))
                    {
                        filename = Session["memberid"].ToString() + fupBiodata.FileName.ToString();
                        int insert_upload = dbc.insert_tblammemberuploads(Session["memberid"].ToString(), ddlUploadType.Text, "NA", "NA", filename, ddlVisibility.Text);

                        if (insert_upload == 1)
                        {
                            fupBiodata.SaveAs(Server.MapPath("~/members/media/biodata/") + filename);
                          
                            ScriptManager.RegisterStartupScript(
                                this,
                                this.GetType(),
                                "MessageBox",
                                "alert('Biodata Uploded');window.location='InfoUpload.aspx';", true);
                            clear();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(
                            this,
                            this.GetType(),
                            "MessageBox",
                            "alert('Data Not Inserted');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(
                      this,
                      this.GetType(),
                      "MessageBox",
                      "alert('Please select proper file as .doc,.docx or .pdf');", true);
                        return;
                    }

                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(
                 this,
                 this.GetType(),
                 "MessageBox",
                 "alert('Please select UploadType');", true);
                return;
            }
        }
        catch(Exception ex)
        {
            string str = ex.Message;
        }
        
    }
    protected void ddlUploadType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUploadType.Text == "Photo")
        {
            showPhotoControls();
            hideBiodataControls();
           
        }

        else if (ddlUploadType.Text == "Biodata")
        {
            showBiodataControls();
            hidePhotoControls();
            
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            string photo = string.Empty;
            if (gen == "Male")
            {
                photo = "MaleNoProfile.jpg";
            }
            else if (gen == "Female")
            {
                photo = "FemaleNoProfile.jpg";
            }
            else if (gen == "Other")
            {
                photo = "NoProfile.jpg";
            }
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("update   anuvaa_matrimony.tblammemberregistration set varPhoto ='" + photo + "',varPhotoApprove='UnApproved' WHERE varMemberId='" + (Session["memberid"].ToString()) + "'   ", dbc.con);
            //dbc.con.Open();
            cmde.ExecuteNonQuery();

            dbc.con.Close();
            ScriptManager.RegisterStartupScript(
          this,
          this.GetType(),
          "MessageBox",
          "alert('Profile Image Deleted');window.location='InfoUpload.aspx';", true);
        }
        catch (Exception ex)
        {
            string st = ex.Message;
            dbc.con.Close();
        }
    }

    protected void GroupingView3_Command(object o, GroupingViewCommandEventArgs e)
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("DELETE  FROM anuvaa_matrimony.tblammemberuploads WHERE intId=" + e.CommandArgument + "", dbc.con);
            //dbc.con.Open();
            cmde.ExecuteNonQuery();
            dbc.con.Close();
            ScriptManager.RegisterStartupScript(
                this,
                this.GetType(),
                "MessageBox",
                "alert('Image Deleted');window.location='InfoUpload.aspx';", true);

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
}