using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register_Log : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    RegexUtilities rex = new RegexUtilities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["uname"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='login.aspx';</script>");
        }
        else if (Request["pass"] == null)
        {
            Response.Write("<script>alert('Please Try Again');window.location='login.aspx';</script>");
        }
        else if(rex.IsValidEmail(Request["uname"].ToString()))
        {
            loginmethod();
        }
        else
        {
            loginmethodbyuserid();
        }
    }

    public void loginmethod()
    {
        try
        {
            string uname = Request["uname"].ToString();
            string pass = Request["pass"].ToString();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select intId,varMemberId,varEmail,varPassword,varMemberStatus,varCreatorDesignation from anuvaa_matrimony.tblammemberregistration where varEmail='" + uname + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (dbc.dr["varPassword"].ToString() == pass)
                {
                    //if (dbc.dr["varCreatorDesignation"].ToString() == "Admin")
                    //{
                    //    Session.Add("adminid", dbc.dr["intId"].ToString());
                    //    Response.Redirect("~/Admin/Default.aspx");

                    //}
                    //else 
                    if (dbc.dr["varMemberStatus"].ToString() == "VerifiedFirstTime")
                    {
                        string data = dbc.dr["varMemberId"].ToString();
                        Session.Add("memberid", data);
                        Response.Redirect("~/members/UserProfile/campaignRegistration.aspx");
                        // dbc.FirstTimeLogin(data); call it after filling compaign Registration

                    }
                    else if (dbc.dr["varMemberStatus"].ToString() == "Verified")
                    {

                        Session.Add("memberid", dbc.dr["varMemberId"].ToString());
                        Response.Redirect("~/members/Activities/Home.aspx");

                    }
                    else if (dbc.dr["varMemberStatus"].ToString() == "Deleted")
                    {

                        Session.Add("memberid", dbc.dr["varMemberId"].ToString());
                        Response.Redirect("~/Register/ActivateDeletedProfile.aspx");

                    }
                    else
                    {
                        Response.Write("<script>alert('Please Try Again');window.location='login.aspx';</script>");
                    }
                    dbc.dr.Close();
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Password Please Try Again');window.location='login.aspx';</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Email Not Recognised. Please Try Again');window.location='login.aspx';</script>");

            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    public void loginmethodbyuserid()
    {
        try
        {
            string uname = Request["uname"].ToString();
            string pass = Request["pass"].ToString();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select intId,varMemberId,varEmail,varPassword,varMemberStatus,varCreatorDesignation from anuvaa_matrimony.tblammemberregistration where varMemberId='" + uname + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (dbc.dr["varPassword"].ToString() == pass)
                {
                    //if (dbc.dr["varCreatorDesignation"].ToString() == "Admin")
                    //{
                    //    Session.Add("adminid", dbc.dr["intId"].ToString());
                    //    Response.Redirect("~/Admin/Default.aspx");

                    //}
                    //else 
                    if (dbc.dr["varMemberStatus"].ToString() == "VerifiedFirstTime")
                    {
                        string data = dbc.dr["varMemberId"].ToString();
                        Session.Add("memberid", data);
                        Response.Redirect("~/members/UserProfile/campaignRegistration.aspx");
                        // dbc.FirstTimeLogin(data); call it after filling compaign Registration

                    }
                    else if (dbc.dr["varMemberStatus"].ToString() == "Verified")
                    {

                        Session.Add("memberid", dbc.dr["varMemberId"].ToString());
                        Response.Redirect("~/members/Activities/Home.aspx");

                    }
                    else if (dbc.dr["varMemberStatus"].ToString() == "Deleted")
                    {

                        Session.Add("memberid", dbc.dr["varMemberId"].ToString());
                        Response.Redirect("~/Register/ActivateDeletedProfile.aspx");

                    }
                    else
                    {
                        Response.Write("<script>alert('Please Try Again');window.location='login.aspx';</script>");
                    }
                    dbc.dr.Close();
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Password Please Try Again');window.location='login.aspx';</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Member ID Not Recognised. Please Try Again');window.location='login.aspx';</script>");

            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }
}