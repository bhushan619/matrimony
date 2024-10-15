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

public partial class Admin_SubMemberLogin : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();

    protected void Page_Load(object sender, EventArgs e)
    {


        if (Request.QueryString["mid"] == null)
        {

        }
        else if (Request.QueryString["eml"] == null)
        {

        }
        else if (Request.QueryString["cde"] == null)
        {

        }
        else if (Request.QueryString["for"] == null)
        {

        }
        else if (Request.QueryString["from"] == null)
        {

        }
        else
        {
            ViewMember();
        }
    }


    public void ViewMember()
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varEmailCode,varMemberId FROM tblammemberemailcode WHERE varMemberId=(Select varMemberId from tblammemberregistration where varEmail='" + Request.QueryString["eml"].ToString() + "')", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (dbc.dr["varEmailCode"].ToString().Equals(Request.QueryString["cde"].ToString()))
                {
                    Session.Add("memberid", dbc.dr["varMemberId"].ToString());
                    Session.Add("SearchMemberId",Request.QueryString["mid"].ToString());
                    Response.Redirect("~/members/SearchMatches/ViewProfile.aspx");
                }
            }
            dbc.con.Close();
        }
        catch (Exception s)
        {
            
        }
    } 
}