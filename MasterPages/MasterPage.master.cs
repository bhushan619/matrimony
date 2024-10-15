using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public partial class MasterPages_MasterPage : System.Web.UI.MasterPage
{
    DatabaseConnection dbc = new DatabaseConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        gethitcount();

        if (IsPostBack)
        {

        }
        else if (!IsPostBack)
        {
            String activepage = Request.RawUrl;
            if (activepage.Contains("Default.aspx"))
            {
                home.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("cnt.aspx"))
            {
                cnt.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("FranchiseeRegisterj.aspx"))
            {
                franc.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("ser.aspx"))
            {
                service.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("SuccessStory.aspx"))
            {
                story.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("Login.aspx"))
            {
                login.Attributes.Add("class", "active");
            }
            else if (activepage.Contains("Registration.aspx"))
            {
                signup.Attributes.Add("class", "active");
            }

            Page.ClientScript.RegisterStartupScript
                 (this.GetType(), "", "getprev();", true);

        }
    }

       
    public void gethitcount()
    {
        lblUserCount.Text = "  Current user      :    " + Application["Online_UserCount"].ToString();

        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT Hits FROM anuvaa_matrimony.hitscount", dbc.con);

        using (dbc.con)
        {
            dbc.con.Open();
            dbc.dr = cmd.ExecuteReader();

            if (dbc.dr.Read())
            {
                lblHits.Text = "Total Visits  : " + dbc.dr["Hits"].ToString();
            }

        }
        dbc.con.Close();
    }
}
