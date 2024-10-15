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

public partial class Franchisee_Notifications : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fid"] == null)
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
                notifications();
                FranchiseeBasicData();
                getNotifications(); 
            }
        }
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblamnotifications(Session["fid"].ToString(), "Franchisee").ToString();
    }
    public void FranchiseeBasicData()
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId, varName, varProfilePic FROM tblampersonnel WHERE varFranchiseeId ='" + Session["fid"] + "'", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                lblFranchiseeId.Text = dbc.dr["varFranchiseeId"].ToString();
                lblFranchiseeName.Text = dbc.dr["varName"].ToString();
                string ImageUr = dbc.dr["varProfilePic"].ToString();
                if (ImageUr == "")
                {
                    imgFranchiseePhoto.ImageUrl = "~/admin/media/NoProfile.jpg";
                }
                else
                {

                    imgFranchiseePhoto.ImageUrl = "~/admin/media/" + ImageUr;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Some problem Please try again...!!!');", true);
            } dbc.con.Close();
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
        Session["fid"] = "";
        Session.Remove("fid");

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
            string memberid = commandArgs[2];
            string sesson = commandArgs[3];
            string remark = commandArgs[4];
            string type = commandArgs[5];
            string textmatter = commandArgs[6];


            if (e.CommandName == "Views")
            {
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("update anuvaa_matrimony.tblamnotifications  set varStatus='Read' WHERE intId=" + id + "", dbc.con);
                cmd.ExecuteReader();
                dbc.con.Close();
                if (type == "Message")
                {
                    Response.Write("<script>alert('" + textmatter + "');window.location='Notifications.aspx';</script>");
                    //Response.Write("<script>alert('" + textmatter + "');</script>");
                }
                else if (type == "Page")
                {
                    Response.Redirect(link);
                }
                //else if (type == "Session")
                //{
                //    Session.Add("SearchMemberId", memberid);
                //    Response.Redirect(link);

                //}
            }
            else if (e.CommandName == "Deletes")
            {
                dbc.delete_Notification(id.ToString());
                Response.Redirect("~/Franchisee/Notifications.aspx");
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
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varNotType,varNotText, varLink, varSession, varStatus, intId,varRemark,intNotFromId FROM tblamnotifications where (intNotToId = '" + Session["fid"].ToString() + "') order by intId desc", dbc.con);
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
        dbc.deleteAll_Notification(Session["fid"].ToString());
        Response.Redirect("~/Franchisee/Notifications.aspx");
    }
    protected void btnReadAll_Click(object sender, EventArgs e)
    {
        dbc.readAll_Notification(Session["fid"].ToString());
        Response.Redirect("~/Franchisee/Notifications.aspx");
    }
}