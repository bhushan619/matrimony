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

public partial class Admin_Delete : System.Web.UI.Page
{
    DatabaseConnection dbc = new DatabaseConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        alldelet();
    }
    public void alldelet()
    {
        try
        {

            MySql.Data.MySqlClient.MySqlCommand cmd1zz = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamcommunication", dbc.con);
            dbc.con.Open();
            cmd1zz.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamconversation", dbc.con);
            dbc.con.Open();
            cmd.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberpartnercaste", dbc.con);
            dbc.con.Open();
            cmd1.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberpartnerlanguages", dbc.con);
            dbc.con.Open();
            cmd2.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberpartnermothertongue", dbc.con);
            dbc.con.Open();
            cmd3.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd4 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberpartnersubcaste", dbc.con);
            dbc.con.Open();
            cmd4.ExecuteReader();
            dbc.con.Close();

         
            MySql.Data.MySqlClient.MySqlCommand cmd7 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberview", dbc.con);
            dbc.con.Open();
            cmd7.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd8 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamloginentry", dbc.con);
            dbc.con.Open();
            cmd8.ExecuteReader();
            dbc.con.Close();


            MySql.Data.MySqlClient.MySqlCommand cmd10 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammembercontactdetails", dbc.con);
            dbc.con.Open();
            cmd10.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd11 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberfamily", dbc.con);
            dbc.con.Open();
            cmd11.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd12 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberinformation", dbc.con);
            dbc.con.Open();
            cmd12.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd13 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberinterests", dbc.con);
            dbc.con.Open();
            cmd13.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd14 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberlifestyle", dbc.con);
            dbc.con.Open();
            cmd14.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd15 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberlivingin", dbc.con);
            dbc.con.Open();
            cmd15.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd16 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnerarea", dbc.con);
            dbc.con.Open();
            cmd16.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd17 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnerbasic", dbc.con);
            dbc.con.Open();
            cmd17.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd5 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnereducation", dbc.con);
            dbc.con.Open();
            cmd5.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd6 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartneremploy", dbc.con);
            dbc.con.Open();
            cmd6.ExecuteNonQuery();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd9 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnerincome", dbc.con);
            dbc.con.Open();
            cmd9.ExecuteReader();
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmd41 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnerreligious", dbc.con);
            dbc.con.Open();
            cmd41.ExecuteNonQuery();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd42 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberphysicalinformation", dbc.con);
            dbc.con.Open();
            cmd42.ExecuteReader();
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmd43 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberprofessionalinfo", dbc.con);
            dbc.con.Open();
            cmd43.ExecuteNonQuery();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd45 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberregistration", dbc.con);
            dbc.con.Open();
            cmd45.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd46 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberreligiousinfo", dbc.con);
            dbc.con.Open();
            cmd46.ExecuteNonQuery();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd47 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammembershortlist", dbc.con);
            dbc.con.Open();
            cmd47.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd48 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammembertransactions", dbc.con);
            dbc.con.Open();
            cmd48.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd49 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberuploads", dbc.con);
            dbc.con.Open();
            cmd49.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd50 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamnotifications", dbc.con);
            dbc.con.Open();
            cmd50.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd51 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblampackages", dbc.con);
            dbc.con.Open();
            cmd51.ExecuteReader();

            //MySql.Data.MySqlClient.MySqlCommand cmd52 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblampersonnel", dbc.con);
            //dbc.con.Open();
            //cmd52.ExecuteReader();
            //dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd53 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamprofilestatus", dbc.con);
            dbc.con.Open();
            cmd53.ExecuteReader();
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmd54 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamrequests", dbc.con);
            dbc.con.Open();
            cmd54.ExecuteReader();
            dbc.con.Close();

            MySql.Data.MySqlClient.MySqlCommand cmd55 = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamsuccessstories", dbc.con);
            dbc.con.Open();
            cmd55.ExecuteReader();
            dbc.con.Close();


            dbc.con.Close();



        }
        catch (Exception ex)
        {

        }
    }
}