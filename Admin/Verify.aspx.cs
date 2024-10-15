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

public partial class Admin_Verify : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlDataReader dr;
    DatabaseConnection dbc = new DatabaseConnection();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["mvid"] != null)
        {
            Member();

        }
        else if (Request.QueryString["fvid"] != null)
        {
            Franchisee();
        }
       
    }
    

    public void Member()
    {
        try
        {
            dbc.con.Close();
            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intId as newid ,varMemberId as memid from anuvaa_matrimony.tblammemberregistration where varEmailVerification='" + Request.QueryString["mvid"].ToString() + "'", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                int upd = Convert.ToInt32(dbc.dr["newid"].ToString());
                string memid = dbc.dr["memid"].ToString();
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberregistration SET varEmailVerification='true', varMemberStatus='VerifiedFirstTime' where intId='" + upd + "'", dbc.con);
                cmd1.ExecuteNonQuery();
                dbc.con.Close();

             
                //ClientScript.RegisterStartupScript(this.GetType(),
                //        "popup",
                //        "alert('Verified now!!!Please login ');window.location='../Register/login.aspx';",  
                //        true);
                Response.Write("<script>alert('Verified now!!!Please login ');window.location='../Register/login.aspx';</script>");
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(),
                //         "popup",
                //         "alert('Please try again');window.location='../register/FranchiseeRegisterj.aspx';",
                //         true);
                Response.Write("<script>alert('Please contact support');window.location='../Contact.aspx';</script>");
            }

        }
        catch (Exception s)
        {
            //ClientScript.RegisterStartupScript(this.GetType(),
            //             "popup",
            //             "alert('Please contact support');window.location='../Contact.aspx';",
            //             true);
            Response.Write("<script>alert('Please contact support');window.location='../Contact.aspx';</script>");
        }
    }

    public void Franchisee()
    {
        try
        {

            dbc.con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select intId as newid from anuvaa_matrimony.tblampersonnel where varEmailVerify='" + Request.QueryString["fvid"].ToString() + "'", dbc.con);
            dbc.dr = cmd.ExecuteReader();
            if (dbc.dr.Read())
            {
                int upd = Convert.ToInt32(dbc.dr["newid"].ToString());
                dbc.con.Close();
                dbc.con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblampersonnel SET varEmailVerify='true',varStatus='Active' where intId='" + upd + "'", dbc.con);
                cmd1.ExecuteNonQuery();
                dbc.con.Close();
                ClientScript.RegisterStartupScript(this.GetType(),
                        "popup",
                        "alert('Verified now!!!Please login ');window.location='../register/FranchiseeRegisterj.aspx';",
                        true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(),
                         "popup",
                         "alert('Please try again');window.location='../register/FranchiseeRegisterj.aspx';",
                         true);
            }

        }
        catch (Exception s)
        {
            ClientScript.RegisterStartupScript(this.GetType(),
                         "popup",
                         "alert('Please contact support');window.location='../Contact.aspx';",
                         true);
        }
    }
}