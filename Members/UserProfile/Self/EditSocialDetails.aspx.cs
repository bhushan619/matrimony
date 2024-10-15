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

public partial class members_UserProfile_Self_Social : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        notifications();
    }
    public void notifications()
    {
        lnkNotifications.Text = dbc.count_tblamnotifications(Session["memberid"].ToString(), "Member").ToString();
       // lblcomplet.Attributes.Add("data-percent", dbc.getInActiveGridview(Session["memberid"].ToString()).ToString());
    }
}