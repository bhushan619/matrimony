using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_login : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void loginmethod()
    {
        try
        {
            string uname = txtUsername.Text;
            string pass = txtPassword.Text;
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId,varFranchiseeId, varName, varDesignation, varAddress, varCity, varState, varCountry, varPinCode, varEmail, varEmailVerify, varMobile, varMobileVerify, varLandline, varPassword, varStatus, varRegDate, varRegTime, varProfilePic, ex2 FROM tblampersonnel where varEmail='" + uname + "' and varEmailVerify='true'", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            {
                if (dbc.dr["varPassword"].ToString() == pass)
                {
                    if (dbc.dr["varDesignation"].ToString() == "Admin")
                    {
                        Session.Add("adminid", dbc.dr["intId"].ToString());
                        Response.Redirect("~/Admin/Personal/Default.aspx");

                    }
                    else if (dbc.dr["varDesignation"].ToString() == "Franchisee")
                    {
                        //    Session.Add("adminid", dbc.dr["intId"].ToString());
                        //    Response.Redirect("~/Franchisee/Default.aspx");
                        if (dbc.dr["varStatus"].ToString() == "Approve")
                        {
                            string data = dbc.dr["varFranchiseeId"].ToString();
                            Session.Add("fid", data);
                            dbc.dr.Close();
                            Response.Redirect("~/Franchisee/Default.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('Your login is being suspended.. Please contact support..');window.location='../Contact.aspx';</script>");
                        }
                    } 
                }
                else
                {
                    Response.Write("<script>alert('Incorrect Password Please Try Again');window.location='login.aspx';</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Email Not recognised.. Please Try Again');window.location='login.aspx';</script>");

            } 
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        loginmethod(); 
    }
}