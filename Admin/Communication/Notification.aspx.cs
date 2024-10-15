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


public partial class Notification : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();

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
                getNotifications();
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
    protected void lstNotification_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        (FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        getNotifications();
    }
    protected void lstNotification_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        try
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });

            string id = commandArgs[0];
            string link = commandArgs[1];
            string fid = commandArgs[2];
            string sesson = commandArgs[3];
            string remark = commandArgs[4];
            string type = commandArgs[5];
            string textmatter = commandArgs[6];
            string design = commandArgs[7];

            if (e.CommandName == "Views")
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("update anuvaa_matrimony.tblamnotifications  set varStatus='Read' WHERE intId=" + id + "", dbc.con);
                cmd.ExecuteReader();
                dbc.con.Close();
                if (type == "Message")
                {
                    Response.Write("<script>alert('" + textmatter + "');window.location='Notification.aspx';</script>");
                    //Response.Write("<script>alert('" + textmatter + "');</script>");
                }
                else if (type == "Page")
                {
                    Response.Redirect(link);
                }
                else if (type == "Session")
                {
                    if (design == "Franchisee")
                    {
                        Session.Add("fid", fid);
                        Response.Redirect(link);
                    }
                    else if (design == "Member")
                    {
                        Session.Add("memberid", fid);
                        Response.Redirect(link);
                    }

                }
            }
            else if (e.CommandName == "Deletes")
            {
                dbc.delete_Notification(id.ToString());
                Response.Redirect("~/Admin/Communication/Notification.aspx");
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void lstNotification_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        Panel notifpanal;
        string notification = string.Empty;
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            notifpanal = (Panel)e.Item.FindControl("notificationpanel");
            System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
            notification = rowView["varStatus"].ToString();
            if (notification == "Unread")
            {
                notifpanal.CssClass = "alert alert-danger";
            }
            else if (notification == "Read")
            {
                notifpanal.CssClass = "alert alert-success";
            }

        }
    }
    public void getNotifications()
    {
        try
        {
            DataTable dt = new DataTable();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varNotType,varNotText, varLink, varSession, varStatus, intId,varRemark,intNotFromId,varNotFromDesig FROM tblamnotifications where (intNotToId = '" + Session["adminid"].ToString() + "') order by intId desc", dbc.con);
            MySql.Data.MySqlClient.MySqlDataAdapter ad = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            ad.Fill(dt);
            lstNotification.DataSource = dt;
            lstNotification.DataBind();
            dbc.con.Close();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Please Try Again');</script>");
        }
    }
    protected void lnkDeleteAll_Click(object sender, EventArgs e)
    {
        dbc.deleteAll_Notification(Session["adminid"].ToString());
        Response.Redirect("~/Admin/Communication/Notification.aspx");
    }
    protected void btnReadAll_Click(object sender, EventArgs e)
    {
        dbc.readAll_Notification(Session["adminid"].ToString());
        Response.Redirect("~/Admin/Communication/Notification.aspx");
    }
     

}