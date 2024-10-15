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

public partial class members_UserProfile_Self_EditLifeStyleDetails : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    string eat = string.Empty;
    string smoke = string.Empty;
    string drink = string.Empty;
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
    public void getdata()
    {
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varEatingHabits,varSmoke,varDrink,varSpokenLanguages,varFavouriteMusic,varHobbyInterest from anuvaa_matrimony.tblammemberlifestyle where varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (dbc.dr["varEatingHabits"].ToString() == "Vegetarian")
                {
                    rgbVegetarian.Checked = true;
                }
                else if (dbc.dr["varEatingHabits"].ToString() == "Non-Vegetarian")
                {
                    rgbNonVegetarian.Checked = true;
                }
                else if (dbc.dr["varEatingHabits"].ToString() == "Eggetarian")
                {
                    rgbEggetarian.Checked = true;
                }
                else if (dbc.dr["varEatingHabits"].ToString() == "Jain")
                {
                    rgbJain.Checked = true;
                }
                //...................varSmoke
                if (dbc.dr["varSmoke"].ToString() == "Yes")
                {
                    rgbSYes.Checked = true;
                }
                else if (dbc.dr["varSmoke"].ToString() == "No")
                {
                    rgbSNo.Checked = true;
                }
                else if (dbc.dr["varSmoke"].ToString() == "Occasionally")
                {
                    rgbSOccasionally.Checked = true;
                }
                //////////////////////////varDrink
                if (dbc.dr["varDrink"].ToString() == "Yes")
                {
                    rgbDYes.Checked = true;
                }
                else if (dbc.dr["varDrink"].ToString() == "No")
                {
                    rgbDNo.Checked = true;
                }
                else if (dbc.dr["varDrink"].ToString() == "Occasionally")
                {
                    rgbDOccasionally.Checked = true;
                }
                /////////////////////////// Spoken Languages
                string langu = dbc.dr["varSpokenLanguages"].ToString();
                string[] arry = langu.Split(new char[] { ';' });

                string[] languages = new string[] { "English", "Hindi", "Marathi", "Telegu", "Tamil", "Gujrathi", "Kannada", "Urdu", "Malyalam" };
                for (int i = 0; i < arry.Length; i++)
                {
                    for (int j = 0; j < languages.Length; j++)
                    {
                        if (arry[i].ToString() == languages[j].ToString())
                        {
                            if (arry[i].ToString() == "English")
                            {
                                ckhSlEng.Checked = true;
                            }
                            else if (arry[i].ToString() == "Hindi")
                            {
                                ckhSlHin.Checked = true;
                            }
                            else if (arry[i].ToString() == "Marathi")
                            {
                                ckhSlMar.Checked = true;
                            }
                            else if (arry[i].ToString() == "Telegu")
                            {
                                ckhSlTel.Checked = true;
                            }
                            else if (arry[i].ToString() == "Tamil")
                            {
                                ckhSlTam.Checked = true;
                            }
                            else if (arry[i].ToString() == "Gujrathi")
                            {
                                ckhSlGuj.Checked = true;
                            }
                            else if (arry[i].ToString() == "Kannada")
                            {
                                ckhSlKan.Checked = true;
                            }
                            else if (arry[i].ToString() == "Urdu")
                            {
                                ckhSlUrdu.Checked = true;
                            }
                            else if (arry[i].ToString() == "Malyalam")
                            {
                                chkSlMal.Checked = true;
                            }
                        }
                        txtSlOther.Text = arry[i].ToString();
                    }
                }
                //////////////////////////////////Fav Music
                string music = dbc.dr["varFavouriteMusic"].ToString();
                string[] marry = music.Split(new char[] { ';' });

                string[] fmusic = new string[] { "Film songs", "Indian / Classical Music", "Western Music"};
                for (int i = 0; i < marry.Length; i++)
                {
                    for (int j = 0; j < fmusic.Length; j++)
                    {
                        if (marry[i].ToString() == fmusic[j].ToString())
                        {
                            if (marry[i].ToString() == "Film songs")
                            {
                                chkfilmy.Checked = true;
                            }
                            else if (marry[i].ToString() == "Indian / Classical Music")
                            {
                                chkIndianclassic.Checked = true;
                            }
                            else if (marry[i].ToString() == "Western Music")
                            {
                                chkWestern.Checked = true;
                            }                          
                        }
                        txtFmusic.Text = marry[i].ToString();
                    }
                }
                //..............................fav hobby /Interest
                string hobby = dbc.dr["varHobbyInterest"].ToString();
                string[] Harry = hobby.Split(new char[] { ';' });

                string[] HobbyInterest = new string[] { "Cooking", "Painting", "Photography", "Dancing", "Traveling", "Internet Surfing", "Art / Handicraft", "Playing Musical Instruments", "Listening to Music", "Movies", "Pets", "Gardening / Landscaping" };
                for (int i = 0; i < Harry.Length; i++)
                {
                    for (int j = 0; j < HobbyInterest.Length; j++)
                    {
                        if (Harry[i].ToString() == HobbyInterest[j].ToString())
                        {
                            if (Harry[i].ToString() == "Cooking")
                            {
                                chkHcook.Checked = true;
                            }
                            else if (Harry[i].ToString() == "Painting")
                            {
                                chkHpaint.Checked = true;
                            }
                            else if (Harry[i].ToString() == "Photography")
                            {
                                chkHphoto.Checked = true;
                            }
                            else if (Harry[i].ToString() == "Dancing")
                            {
                                chkHdance.Checked = true;
                            }
                            else if (Harry[i].ToString() == "Traveling")
                            {
                                chkHtravel.Checked = true;
                            }
                            else if (Harry[i].ToString() == "Internet Surfing")
                            {
                                chkHinternet.Checked = true;
                            }
                            else if (Harry[i].ToString() == "Art / Handicraft")
                            {
                                chkHart.Checked = true;
                            }
                            else if (Harry[i].ToString() == "Playing Musical Instruments")
                            {
                                chkHplaymusic.Checked = true;
                            }
                            else if (Harry[i].ToString() == "Listening to Music")
                            {
                                chkHListenmusic.Checked = true;
                            }
                            else if (Harry[i].ToString() == "Movies")
                            {
                                chkHmovie.Checked = true;
                            }
                            else if (Harry[i].ToString() == "Pets")
                            {
                                chkHpets.Checked = true;
                            }
                            else if (Harry[i].ToString() == "Gardening / Landscaping")
                            {
                                chkHgarden.Checked = true;
                            }
                        }
                        txtHobby.Text = Harry[i].ToString();
                    }
                }
                //....................................

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
  
    protected void btnLifeStyleSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (rgbVegetarian.Checked)
            {
                eat = rgbVegetarian.Text;
            }
            else if (rgbNonVegetarian.Checked)
            {
                eat = rgbNonVegetarian.Text;
            }
            else if (rgbEggetarian.Checked)
            {
                eat = rgbEggetarian.Text;
            }
            else if (rgbJain.Checked)
            {
                eat = rgbJain.Text;
            }
            ///////////////////////////////////smoke
            if (rgbSYes.Checked)
            {
                smoke = rgbSYes.Text;
            }
            else if (rgbSNo.Checked)
            {
                smoke = rgbSNo.Text;
            }
            else if (rgbSOccasionally.Checked)
            {
                smoke = rgbSOccasionally.Text;
            }
            ///////////////////////////////////drink
            if (rgbDYes.Checked)
            {
                drink = rgbDYes.Text;
            }
            else if (rgbDNo.Checked)
            {
                drink = rgbDNo.Text;
            }
            else if (rgbDOccasionally.Checked)
            {
                drink = rgbDOccasionally.Text;
            }
            string spoke= GetSpokenLanguages();
            //GetFavMusic();
            //GetHobby();
            int insert_ok = dbc.update_tblammemberlifestyle(Session["memberid"].ToString(), eat, smoke, drink, GetFavMusic(), txtFavDestination.Text, txtFavBook.Text, txtFavAuthor.Text, GetHobby(), spoke);

            if (insert_ok == 1)
            {
                // clear();
                ScriptManager.RegisterStartupScript(
                   this,
                   this.GetType(),
                   "MessageBox",
                   "alert('Lifestyle Details Updated Successfully...!!!');window.location='EditLifeStyleDetails.aspx';", true);
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
    public string GetSpokenLanguages()
    {
        string lang = string.Empty;
        if (ckhSlEng.Checked == true)
        {
            lang = lang + ckhSlEng.Text + ";";
        }
        if (ckhSlHin.Checked == true)
        {
            lang = lang + ckhSlHin.Text + ";";
        }
        if (ckhSlMar.Checked == true)
        {
            lang = lang + ckhSlMar.Text + ";";
        }
        if (ckhSlTel.Checked == true)
        {
            lang = lang + ckhSlTel.Text + ";";
        }
        if (ckhSlTam.Checked == true)
        {
            lang = lang + ckhSlTam.Text + ";";
        }
        if (ckhSlGuj.Checked == true)
        {
            lang = lang + ckhSlGuj.Text + ";";
        }
        if (ckhSlKan.Checked == true)
        {
            lang = lang + ckhSlKan.Text + ";";
        }
        if (ckhSlUrdu.Checked == true)
        {
            lang = lang + ckhSlUrdu.Text + ";";
        }
        if (chkSlMal.Checked == true)
        {
            lang = lang + chkSlMal.Text + ";";
        }
        lang = lang + txtSlOther.Text;
        return lang;
    }
    public string GetFavMusic()
    {
        string Music = string.Empty;
        if (chkfilmy.Checked == true)
        {
            Music = Music + chkfilmy.Text + ";";
        }
        if (chkIndianclassic.Checked == true)
        {
            Music = Music + chkIndianclassic.Text + ";";
        }
        if (chkWestern.Checked == true)
        {
            Music = Music + chkWestern.Text + ";";
        }
        Music = Music + txtFmusic.Text;
        return Music;
    }
    public string GetHobby()
    {
        string hobby = string.Empty;
        if (chkHart.Checked == true)
        {
            hobby = hobby + chkHart.Text + ";";
        }
        if (chkHcook.Checked == true)
        {
            hobby = hobby + chkHcook.Text + ";";
        }
        if (chkHdance.Checked == true)
        {
            hobby = hobby + chkHdance.Text + ";";
        }
        if (chkHgarden.Checked == true)
        {
            hobby = hobby + chkHgarden.Text + ";";
        }
        if (chkHinternet.Checked == true)
        {
            hobby = hobby + chkHinternet.Text + ";";
        }
        if (chkHListenmusic.Checked == true)
        {
            hobby = hobby + chkHListenmusic.Text + ";";
        }
        if (chkHmovie.Checked == true)
        {
            hobby = hobby + chkHmovie.Text + ";";
        }
        if (chkHpaint.Checked == true)
        {
            hobby = hobby + chkHpaint.Text + ";";
        }
        if (chkHpets.Checked == true)
        {
            hobby = hobby + chkHpets.Text + ";";
        }
        if (chkHphoto.Checked == true)
        {
            hobby = hobby + chkHphoto.Text + ";";
        }
        if (chkHplaymusic.Checked == true)
        {
            hobby = hobby + chkHplaymusic.Text + ";";
        }
        if (chkHtravel.Checked == true)
        {
            hobby = hobby + chkHtravel.Text + ";";
        }
        hobby = hobby + txtHobby.Text;
        return hobby;
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