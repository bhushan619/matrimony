using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

public partial class members_UserProfile_MVerify : System.Web.UI.Page
{

    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        notifications();
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblamnotifications(Session["memberid"].ToString(), "Member").ToString();
    }
   
}