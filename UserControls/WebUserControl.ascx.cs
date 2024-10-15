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
using System.Collections;

public partial class UserControls_WebUserControl : System.Web.UI.UserControl
{
    DatabaseConnection dbc = new DatabaseConnection();
    static string gen = string.Empty;
    DataTable dt = new DataTable();
    string reqcount = 0.ToString();
    string msgcount = 0.ToString();
    string querystr = string.Empty;
    static string hht = string.Empty;
    string IntersestMemId = string.Empty;
    string IntersestMemDate = string.Empty;
    string IntersestMemName = string.Empty;
    string IntersestMemAccFor = string.Empty;
    string IntersestMemAbout = string.Empty;
    string IntersestMemAge = string.Empty;
    string IntersestMemReligion = string.Empty;
    string IntersestMemCaste = string.Empty;
    string IntersestMemSCaste = string.Empty;
    string IntersestMemCity = string.Empty;
    string IntersestMemState = string.Empty;
    string IntersestMemCountry = string.Empty;
    string IntersestMemEducation = string.Empty;
    string IntersestMemOccupation = string.Empty;
    string IntersestMemHeight = string.Empty;
    string IntersestMemHeightcm = string.Empty;
    string IntersestMemPhoto = string.Empty;
    string IntersestMemPackage = string.Empty;
    DataRow dr;
    MySql.Data.MySqlClient.MySqlDataReader rdr1, rdr2, rdr3, rdr4, rdr5, rdr6, rdr7, rdr8;
    public static int PageSize = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
        AddDataTable();
        if (!IsPostBack)
        {
            MemberBasicData();
            getSearchBy(10);
            PageSize = 10;
        }
    }
    protected void OpenProfile(object sender, EventArgs e)
    {

        Session["SearchMemberId"] = (sender as LinkButton).CommandArgument;
        //Response.Redirect("~/members/UserProfile/ViewProfile.aspx");
        Page.ClientScript.RegisterStartupScript(
            this.GetType(), "OpenWindow", "window.open('../SearchMatches/ViewProfile.aspx','_blank');", true);

    }

    public void MemberBasicData()
    {
        try
        {
            dbc.con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmde = new MySql.Data.MySqlClient.MySqlCommand("select varMemberId,varMemberName,varGender,varMembershipType,varPhoto FROM tblammemberregistration WHERE varMemberId='" + Session["memberid"].ToString() + "' ", dbc.con);
            dbc.con.Open();
            dbc.dr = cmde.ExecuteReader();
            if (dbc.dr.Read())
            { 
                gen = dbc.dr["varGender"].ToString(); 
            }
            else
            {
                ScriptManager.RegisterStartupScript(
              this,
              this.GetType(),
              "MessageBox",
              "alert('Some problem Please try again');", true);
            }
            dbc.con.Close();
            dbc.dr.Close();
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

   
 
    protected string Limit(object Desc, int length)
    {
        StringBuilder strDesc = new StringBuilder();
        strDesc.Insert(0, Desc.ToString());

        if (strDesc.Length > length)
            return strDesc.ToString().Substring(0, length) + "...";
        else return strDesc.ToString();
    }
    protected void imgmember_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string[] commandarguement = (sender as ImageButton).CommandArgument.ToString().Split(';');
            string pictype = commandarguement[1].ToString();
            if (pictype == "FemaleNoProfileProtected.jpg")
            {

                int already = dbc.check_already_tblamrequests(Session["memberid"].ToString(), commandarguement[0].ToString());
                if (already == 1)
                {
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Request Already Sent'); ", true);
                }
                else
                {
                    int ok = dbc.insert_tblamrequests(Session["memberid"].ToString(), commandarguement[0].ToString());
                    if (ok == 1)
                    {
                        ScriptManager.RegisterStartupScript(
                      this,
                      this.GetType(),
                      "MessageBox",
                     "alert('Great ! Your request for photograph has been successfully sent. You will be intimated when your request is accepted.'); ", true);
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(
                            this,
                            this.GetType(),
                            "MessageBox",
                            "alert('Some Problem Please try again later');", true);
                    }
                }
            }
            else if (pictype == "MaleNoProfileProtected.jpg")
            {

                int already = dbc.check_already_tblamrequests(Session["memberid"].ToString(), commandarguement[0].ToString());
                if (already == 1)
                {
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Request Already Sent'); ", true);
                }
                else
                {
                    int ok = dbc.insert_tblamrequests(Session["memberid"].ToString(), commandarguement[0].ToString());
                    if (ok == 1)
                    {
                        ScriptManager.RegisterStartupScript(
                      this,
                      this.GetType(),
                      "MessageBox",
                     "alert('Great ! Your request for photograph has been successfully sent. You will be intimated when your request is accepted.'); ", true);
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(
                            this,
                            this.GetType(),
                            "MessageBox",
                            "alert('Some Problem Please try again later');", true);
                    }
                }
            }


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
    protected void lnkInterest_Click(object sender, EventArgs e)
    {
        try
        {
            int already = dbc.check_already_interest(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument);
            if (already == 1)
            {

                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "MessageBox",
                    "alert('Interest Already Sent'); ", true);
            }
            else
            {
                int ok = dbc.insert_tblammemberinterests(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument);
                if (ok == 1)
                {
                    sendmail(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument, "Interest");
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Interest Sent'); ", true);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Some Problem Please try again later');", true);
                }
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void lnkShortlist_Click(object sender, EventArgs e)
    {
        try
        {
            int already = dbc.check_already_Shortlist(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument);
            if (already == 1)
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "MessageBox",
                    "alert('Member Already Shortlisted'); ", true);
            }
            else
            {
                int ok = dbc.insert_tblammembershortlist(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument);
                if (ok == 1)
                {
                    sendmail(Session["memberid"].ToString(), (sender as LinkButton).CommandArgument, "Shortlist");
                    ScriptManager.RegisterStartupScript(
                  this,
                  this.GetType(),
                  "MessageBox",
                  "alert('Member Shortlisted'); ", true);
                }

                else
                {
                    ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                        "alert('Some Problem Please try again later');", true);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(
                        this,
                        this.GetType(),
                        "MessageBox",
                         "alert('Some Problem Please try again later');", true);
        }

    }
    private string PopulateBody(string memid, string mname, string iname, string email, string imemid, string arg)
    {
        string body = string.Empty;
        string path1 = string.Empty;
        if (arg == "Interest")
        {
            path1 = "~/Admin/emails/Interest.html";
        }
        else if (arg == "Shortlist")
        {
            path1 = "~/Admin/emails/Shortlist.html";
        }
        using (StreamReader reader = new StreamReader(Server.MapPath(path1)))
        {
            body = reader.ReadToEnd();
        }
        string datenow = DateTimeOffset.UtcNow.LocalDateTime.ToLongDateString();
        body = body.Replace("{mname}", mname);
        body = body.Replace("{memid}", Session["memberid"].ToString());
        body = body.Replace("{email}", email);
        body = body.Replace("{imemid}", imemid);
        body = body.Replace("{iname}", iname);
        body = body.Replace("{date}", datenow);
        body = body.Replace("{grid}", listviewData(lstviewedProfile));
        body = body.Replace("{viewProfile}", "http://swapnpurti.in/Admin/SubMemberLogin.aspx?mid=" + Session["memberid"].ToString() + "&eml=" + dbc.get_member_Email(imemid) + "&cde=" + dbc.get_member_EmailCode(imemid) + "&for=ViewMember&from=Member");

        return body;
    }
    protected void sendmail(string memid, string imemid, string arg)
    {
        try
        {
            dbc.con.Open();
            string m_name = dbc.get_member_name(Session["memberid"].ToString());
            string i_name = dbc.get_member_name(imemid);
            string email = dbc.get_member_Email(imemid);
            dbc.con.Close();
            using (MailMessage mm = new MailMessage(new MailAddress("Swapnpurti Matrimony <swapnpurtimatrimony@gmail.com>"), new MailAddress(email)))
            {

                if (arg == "Interest")
                {
                    mm.Subject = "Swapnpurti Matrimony : Interested In You !!!";
                    mm.Body = PopulateBody(memid, m_name, i_name, email, imemid, "Interest");
                }
                else if (arg == "Shortlist")
                {
                    mm.Subject = "Swapnpurti Matrimony : Shortlisted You !!!";
                    mm.Body = PopulateBody(memid, m_name, i_name, email, imemid, "Shortlist");
                }

                mm.IsBodyHtml = true;

                System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient();
                // for server

                SmtpServer.Host = "relay-hosting.secureserver.net";
                SmtpServer.EnableSsl = false;
                //for server
                SmtpServer.Port = 25;


                //for local 

                //SmtpServer.Host = "smtp.gmail.com";
                //SmtpServer.EnableSsl = true;

                //SmtpServer.Port = 587;


                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                NetworkCredential NetworkCred = new NetworkCredential("swapnpurtimatrimony@gmail.com", "anuvaa2015");
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = NetworkCred;

                SmtpServer.Send(mm);


            }
        }
        catch (Exception rx)
        {
            //ScriptManager.RegisterStartupScript(
            //             this,
            //             this.GetType(),
            //             "MessageBox",
            //              "alert('not sent');", true);

        }
    }

    public string getCms(string ft)
    {
        if (ft == "4ft 6in")
        {
            return hht = "137Cms";
        }
        else if (ft == "4ft 7in")
        {
            return hht = "140Cms";
        }
        else if (ft == "4ft 8in")
        {
            return hht = "142Cms";
        }
        else if (ft == "4ft 9in")
        {
            return hht = "145Cms";
        }
        else if (ft == "4ft 10in")
        {
            return hht = "147Cms";
        }
        else if (ft == "4ft 11in")
        {
            return hht = "150Cms";
        }
        else if (ft == "5ft")
        {
            return hht = "152Cms";
        }
        else if (ft == "5ft 1in")
        {
            return hht = "155Cms";
        }
        else if (ft == "5ft 2in")
        {
            return hht = "157Cms";
        }
        else if (ft == "5ft 3in")
        {
            return hht = "160Cms";
        }
        else if (ft == "5ft 4in")
        {
            return hht = "162Cms";
        }
        else if (ft == "5ft 5in")
        {
            return hht = "165Cms";
        }
        else if (ft == "5ft 6in")
        {
            return hht = "167Cms";
        }
        else if (ft == "5ft 7in")
        {
            return hht = "170Cms";
        }
        else if (ft == "5ft 8in")
        {
            return hht = "172Cms";
        }
        else if (ft == "5ft 9in")
        {
            return hht = "175Cms";
        }
        else if (ft == "5ft 10in")
        {
            return hht = "177Cms";
        }
        else if (ft == "5ft 11in")
        {
            return hht = "180Cms";
        }
        else if (ft == "6ft")
        {
            return hht = "183Cms";
        }
        else if (ft == "6ft 1in")
        {
            return hht = "185Cms";
        }
        else if (ft == "6ft 2in")
        {
            return hht = "188Cms";
        }
        else if (ft == "6ft 3in")
        {
            return hht = "190Cms";
        }
        else if (ft == "6ft 4in")
        {
            return hht = "193Cms";
        }
        else if (ft == "6ft 5in")
        {
            return hht = "195Cms";
        }
        else if (ft == "6ft 6in")
        {
            return hht = "198Cms";
        }
        else if (ft == "6ft 7in")
        {
            return hht = "201Cms";
        }
        else if (ft == "6ft 8in")
        {
            return hht = "203Cms";
        }
        else if (ft == "6ft 9in")
        {
            return hht = "206Cms";
        }
        else if (ft == "6ft 10in")
        {
            return hht = "208Cms";
        }
        else if (ft == "6ft 11in")
        {
            return hht = "211Cms";
        }
        else
        {
            return hht = "213Cms";
        }
    }
    public string listviewData(ListView gv)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gv.RenderControl(htw);

        return sb.ToString();
    }  

    public void AddDataTable()
    {
        ////data reader we will use to read data from our tables 
        dt.Columns.AddRange(new DataColumn[17] {
                        new DataColumn("IntersestMemId", typeof(string)),
                        new DataColumn("IntersestMemName", typeof(string)),
                        new DataColumn("IntersestMemAccFor", typeof(string)),
                        new DataColumn("IntersestMemPhoto", typeof(string)),
                        new DataColumn("IntersestMemAbout", typeof(string)),
                        new DataColumn("IntersestMemAge", typeof(string)),
                        new DataColumn("IntersestMemReligion", typeof(string)),
                        new DataColumn("IntersestMemCaste", typeof(string)),
                        new DataColumn("IntersestMemSCaste", typeof(string)),
                        new DataColumn("IntersestMemCity", typeof(string)),
                        new DataColumn("IntersestMemState", typeof(string)),
                        new DataColumn("IntersestMemCountry", typeof(string)),
                        new DataColumn("IntersestMemEducation", typeof(string)),
                        new DataColumn("IntersestMemOccupation", typeof(string)),
                        new DataColumn("IntersestMemHeight", typeof(string)),
                        new DataColumn("IntersestMemHeightcm", typeof(string)),
                        new DataColumn("IntersestMemPackage", typeof(string)),

        });


    }
    protected void LoadMore_Click(object sender, EventArgs e)
    {
        PageSize+=10;
        getSearchBy(PageSize);
    }

    public void getSearchBy(int limits)
    {
        string search = Request.QueryString["SearchBy"].ToString();
        string[] searchby = search.Split('_');
        for (int i = 1; i < searchby.Length; i++)
        {
            if (searchby[i].ToString() == "age")
            {
                querystr = " AND (CAST(tblammemberinformation.varAgeToday AS UNSIGNED) between CAST(" + Request.QueryString["AgeFrom"].ToString() + " AS UNSIGNED) AND CAST(" + Request.QueryString["AgeTo"].ToString() + " AS UNSIGNED))";
                getProfiles(querystr, "tblammemberinformation", limits);
            }
            if (searchby[i].ToString() == "height")
            {
                string from = getCms(Request.QueryString["HeightFrom"].ToString());
                string to = getCms(Request.QueryString["HeightTo"].ToString());

                querystr = " AND  (CAST(SUBSTRING(tblammemberphysicalinformation.varHeightCm  FROM 1 FOR 3) AS UNSIGNED)  between CAST(" + from.Substring(0, 3) + " AS UNSIGNED) AND CAST(" + to.Substring(0, 3) + " AS UNSIGNED))";
                getProfiles(querystr, "tblammemberphysicalinformation", limits);
            }
            if (searchby[i].ToString() == "marital")
            {
                querystr = "  AND (tblammemberinformation.varMaritalStatus = '" + Request.QueryString["MStatus"].ToString() + "')";
                getProfiles(querystr, "tblammemberinformation", limits);
            }
            if (searchby[i].ToString() == "mothertong")
            {
                string jmothertong = Request.QueryString["Mothertong"].ToString();
                string[] jmothertongsearch = jmothertong.Split('-');
                for (int m = 0; m < jmothertongsearch.Count(); m++)
                {

                    querystr = " AND (tblammemberreligiousinfo.varMotherTongue = '" + jmothertongsearch[m] + "')";
                    getProfiles(querystr, "tblammemberreligiousinfo", limits);
                }
            }
            if (searchby[i].ToString() == "religion")
            {
                querystr = " AND (tblammemberreligiousinfo.varReligion = '" + Request.QueryString["Religion"].ToString() + "')";
                getProfiles(querystr, "tblammemberreligiousinfo", limits);
            }
            if (searchby[i].ToString() == "caste")
            {
                string jcast = Request.QueryString["Caste"].ToString();
                string[] jcastesearch = jcast.Split('-');
                for (int m = 0; m < jcastesearch.Count(); m++)
                {
                    querystr = " AND (tblammemberreligiousinfo.varCasteDivision = '" + jcastesearch[m] + "')";
                    getProfiles(querystr, "tblammemberreligiousinfo", limits);
                }

            }
            if (searchby[i].ToString() == "city")
            {
                string jcity = Request.QueryString["City"].ToString();
                string[] jcitysearch = jcity.Split('-');
                for (int m = 0; m < jcitysearch.Count(); m++)
                {
                    querystr = " AND tblammemberlivingin.varCity = '" + jcitysearch[m] + "'";
                    getProfiles(querystr, "tblammemberlivingin", limits);
                }
            }
            ////////////////////////////////////////////extra added
            if (searchby[i].ToString() == "specialCase")
            {
                querystr = " AND (tblammemberphysicalinformation.varSpecialCase = '" + Request.QueryString["SpecialCase"].ToString() + "')";
                getProfiles(querystr, "tblammemberphysicalinformation", limits);
            }
            if (searchby[i].ToString() == "state")
            {
                querystr = " AND (tblammemberlivingin.varState = '" + Request.QueryString["State"].ToString() + "')";
                getProfiles(querystr, "tblammemberlivingin", limits);
            }
            if (searchby[i].ToString() == "manglik")
            {
                querystr = " AND (tblammemberreligiousinfo.varManglik = '" + Request.QueryString["Manglik"].ToString() + "')";
                getProfiles(querystr, "tblammemberreligiousinfo", limits);
            }
            if (searchby[i].ToString() == "eat")
            {
                querystr = " AND (tblammemberlifestyle.varEatingHabits = '" + Request.QueryString["Eat"].ToString() + "')";
                getProfiles(querystr, "tblammemberlifestyle", limits);
            }
            if (searchby[i].ToString() == "smoke")
            {
                querystr = " AND (tblammemberlifestyle.varSmoke = '" + Request.QueryString["Smoke"].ToString() + "')";
                getProfiles(querystr, "tblammemberlifestyle", limits);
            }
            if (searchby[i].ToString() == "drink")
            {
                querystr = " AND (tblammemberlifestyle.varDrink = '" + Request.QueryString["Drink"].ToString() + "')";
                getProfiles(querystr, "tblammemberlifestyle", limits);
            }


            if (searchby[i].ToString() == "country")
            {
                string jcountry = Request.QueryString["Country"].ToString();
                string[] jcountrysearch = jcountry.Split('-');
                for (int m = 0; m < jcountrysearch.Count(); m++)
                {
                    querystr = " AND tblammemberlivingin.varCountry = '" + jcountrysearch[m] + "'";
                    getProfiles(querystr, "tblammemberlivingin", limits);
                }
            }
            if (searchby[i].ToString() == "education")
            {
                string jeducation = Request.QueryString["Education"].ToString();
                string[] jeducationsearch = jeducation.Split('-');
                for (int m = 0; m < jeducationsearch.Count(); m++)
                {
                    querystr = " AND (tblammemberprofessionalinfo.varEducation = '" + jeducationsearch[m] + "')";
                    getProfiles(querystr, "tblammemberprofessionalinfo", limits);
                }

            }
            if (searchby[i].ToString() == "occupation")
            {
                string joccupation = Request.QueryString["Occupation"].ToString();
                string[] joccupationsearch = joccupation.Split('-');
                for (int m = 0; m < joccupationsearch.Count(); m++)
                {
                    querystr = " AND (tblammemberprofessionalinfo.varOccupation = '" + joccupationsearch[m] + "')";
                    getProfiles(querystr, "tblammemberprofessionalinfo", limits);
                }

            }
            if (searchby[i].ToString() == "star")
            {
                string jstar = Request.QueryString["Star"].ToString();
                string[] jstarsearch = jstar.Split('-');
                for (int m = 0; m < jstarsearch.Count(); m++)
                {
                    querystr = " AND (tblammemberreligiousinfo.varStar = '" + jstarsearch[m] + "')";
                    getProfiles(querystr, "tblammemberreligiousinfo", limits);
                }

            }
        }
        RemoveDuplicateRows(dt, "IntersestMemId");
        lblCountPeople.Text = dt.Rows.Count.ToString();
        lstViewedProfiles.DataSource = dt;
        lstViewedProfiles.DataBind();
    }
    public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

        //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
        //And add duplicate item value in arraylist.
        foreach (DataRow drow in dTable.Rows)
        {
            if (hTable.Contains(drow[colName]))
                duplicateList.Add(drow);
            else
                hTable.Add(drow[colName], string.Empty);
        }

        //Removing a list of duplicate items from datatable.
        foreach (DataRow dRow in duplicateList)
            dTable.Rows.Remove(dRow);

        /////////////////////randomise row
        int index;
        System.Random rnd = new Random();
        // Remove and throw to the end random rows until we have done so n*3 times (shuffles the dataset)
        for (int i = 0; i < 10; i++)
        {
            if (dTable.Rows.Count == 0)
            {

            }
            else
            {
                index = rnd.Next(0, dTable.Rows.Count - 1);
                dTable.Rows.Add(dTable.Rows[index].ItemArray);
                dTable.Rows.RemoveAt(index);
            }
        }

        //Datatable which contains unique records will be return as output.
        return dTable;
    }
    public void getProfiles(string querystring, string tablesearch,int limits)
    {
        dr = dt.NewRow();


        MySql.Data.MySqlClient.MySqlConnection cnn1 = new MySql.Data.MySqlClient.MySqlConnection();
        cnn1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

        //get shortlisted profiles

        string query = "SELECT DISTINCT tblammemberregistration.varMemberId AS IntersestMemId, tblammemberregistration.varGender FROM tblammemberregistration INNER JOIN ";

        query = query + tablesearch + " ON tblammemberregistration.varMemberId = " + tablesearch + ".varMemberId";

        query = query + " WHERE  (tblammemberregistration.varGender != '" + gen + "')";

        query = query + querystring;

        query = query + " AND  (tblammemberregistration.varMemberStatus='Verified')" + "LIMIT " + limits + "";
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand(query, cnn1);
        cmd1.CommandType = CommandType.Text;

        using (cnn1)
        {
            //open connection
            cnn1.Open();
            //read data from the table to our data reader
            rdr1 = cmd1.ExecuteReader();
            //loop through each row we have read
            while (rdr1.Read())
            {
                IntersestMemId = rdr1["IntersestMemId"].ToString();
                //IntersestMemDate = rdr1["IntersestMemDate"].ToString();

                string[] gender = dbc.getGender(IntersestMemId).Split(new char[] { '\'' });
                if (gender[1] == gen)
                {
                    // get data from table tblammemberregistration

                    MySql.Data.MySqlClient.MySqlConnection cnn2 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName as IntersestMemName,varMemberFor as IntersestMemAccFor,varPhoto as IntersestMemPhoto,ex3,varGender,varPhotoApprove FROM tblammemberregistration WHERE (varMemberId = '" + IntersestMemId + "') and varMemberStatus='Verified'", cnn2);
                    cmd2.CommandType = CommandType.Text;

                    using (cnn2)
                    {
                        cnn2.Open();
                        rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            IntersestMemName = rdr2["IntersestMemName"].ToString();
                            IntersestMemAccFor = rdr2["IntersestMemAccFor"].ToString();
                            if (rdr2["varPhotoApprove"].ToString() == "Approved")
                            {
                                if (rdr2["varGender"].ToString() == "Female")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        IntersestMemPhoto = "FemaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        IntersestMemPhoto = "FemaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        IntersestMemPhoto = rdr2["IntersestMemPhoto"].ToString();
                                    }
                                }
                                else if (rdr2["varGender"].ToString() == "Male")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        IntersestMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        IntersestMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        IntersestMemPhoto = rdr2["IntersestMemPhoto"].ToString();
                                    }
                                }
                                else if (rdr2["varGender"].ToString() == "Other")
                                {
                                    if (rdr2["ex3"].ToString() == "Protected")
                                    {
                                        IntersestMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else if (rdr2["ex3"].ToString() == "Hidden")
                                    {
                                        IntersestMemPhoto = "MaleNoProfileProtected.jpg";
                                    }
                                    else
                                    {
                                        IntersestMemPhoto = rdr2["IntersestMemPhoto"].ToString();
                                    }

                                }
                            }
                            else
                            {
                                IntersestMemPhoto = "NotApproved.jpg";
                            }

                        }
                        cnn2.Close();
                        rdr2.Close();
                    }

                    //end data from table tblammemberregistration

                    // get data from table tblammemberinformation

                    MySql.Data.MySqlClient.MySqlConnection cnn3 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn3.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varAgeToday as IntersestMemAge, varAbout as IntersestMemAbout FROM tblammemberinformation WHERE (varMemberId = '" + IntersestMemId + "')", cnn3);
                    cmd3.CommandType = CommandType.Text;

                    using (cnn3)
                    {
                        cnn3.Open();
                        rdr3 = cmd3.ExecuteReader();
                        while (rdr3.Read())
                        {
                            IntersestMemAge = rdr3["IntersestMemAge"].ToString();
                            IntersestMemAbout = rdr3["IntersestMemAbout"].ToString();
                        }
                        cnn3.Close();
                        rdr3.Close();
                    }

                    //end data from table tblammemberinformation

                    // get data from table tblammemberreligiousinfo

                    MySql.Data.MySqlClient.MySqlConnection cnn4 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn4.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd4 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varReligion as IntersestMemReligion, varCasteDivision as IntersestMemCaste, varSubcaste as IntersestMemSCaste FROM tblammemberreligiousinfo WHERE  (varMemberId = '" + IntersestMemId + "')", cnn4);
                    cmd4.CommandType = CommandType.Text;

                    using (cnn4)
                    {
                        cnn4.Open();
                        rdr4 = cmd4.ExecuteReader();
                        while (rdr4.Read())
                        {
                            IntersestMemReligion = rdr4["IntersestMemReligion"].ToString();
                            IntersestMemCaste = rdr4["IntersestMemCaste"].ToString();
                            IntersestMemSCaste = rdr4["IntersestMemSCaste"].ToString();
                        }
                        cnn4.Close();
                        rdr4.Close();
                    }

                    //end data from table tblammemberreligiousinfo

                    // get data from table tblammemberlivingin

                    MySql.Data.MySqlClient.MySqlConnection cnn5 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn5.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd5 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varCity as IntersestMemCity, varState as IntersestMemState, varCountry as IntersestMemCountry FROM tblammemberlivingin WHERE (varMemberId = '" + IntersestMemId + "')", cnn5);
                    cmd5.CommandType = CommandType.Text;

                    using (cnn5)
                    {
                        cnn5.Open();
                        rdr5 = cmd5.ExecuteReader();
                        while (rdr5.Read())
                        {
                            IntersestMemCity = rdr5["IntersestMemCity"].ToString();
                            IntersestMemState = rdr5["IntersestMemState"].ToString();
                            IntersestMemCountry = rdr5["IntersestMemCountry"].ToString();

                        }
                        cnn5.Close();
                        rdr5.Close();
                    }

                    //end data from table tblammemberlivingin

                    // get data from table tblammemberprofessionalinfo

                    MySql.Data.MySqlClient.MySqlConnection cnn6 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn6.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd6 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varEducation as IntersestMemEducation, varOccupation as IntersestMemOccupation FROM tblammemberprofessionalinfo WHERE (varMemberId = '" + IntersestMemId + "')", cnn6);
                    cmd6.CommandType = CommandType.Text;


                    using (cnn6)
                    {
                        cnn6.Open();
                        rdr6 = cmd6.ExecuteReader();
                        while (rdr6.Read())
                        {
                            IntersestMemOccupation = rdr6["IntersestMemOccupation"].ToString();
                            IntersestMemEducation = rdr6["IntersestMemEducation"].ToString();
                        }
                        cnn6.Close();
                        rdr6.Close();
                    }

                    //end data from table tblammemberprofessionalinfo

                    // get data from table tblammemberphysicalinformation

                    MySql.Data.MySqlClient.MySqlConnection cnn7 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn7.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd7 = new MySql.Data.MySqlClient.MySqlCommand("SELECT varHeightFt as IntersestMemHeight, varHeightCm as IntersestMemHeightcm FROM tblammemberphysicalinformation WHERE (varMemberId = '" + IntersestMemId + "')", cnn7);
                    cmd7.CommandType = CommandType.Text;


                    using (cnn7)
                    {
                        cnn7.Open();
                        rdr7 = cmd7.ExecuteReader();
                        while (rdr7.Read())
                        {
                            IntersestMemHeight = rdr7["IntersestMemHeight"].ToString();
                            IntersestMemHeightcm = rdr7["IntersestMemHeightcm"].ToString();
                        }
                        cnn7.Close();
                        rdr7.Close();
                    }

                    //end data from table tblammemberphysicalinformation

                    // get data from table tblampackages

                    MySql.Data.MySqlClient.MySqlConnection cnn8 = new MySql.Data.MySqlClient.MySqlConnection();
                    cnn8.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

                    MySql.Data.MySqlClient.MySqlCommand cmd8 = new MySql.Data.MySqlClient.MySqlCommand("SELECT DISTINCT tblampackages.varPackageName as IntersestMemPackage FROM tblammembertransactions, tblampackages WHERE (tblammembertransactions.varMemberId = '" + IntersestMemId + "')", cnn8);
                    cmd8.CommandType = CommandType.Text;

                    using (cnn8)
                    {
                        cnn8.Open();
                        rdr8 = cmd8.ExecuteReader();
                        while (rdr8.Read())
                        {
                            IntersestMemPackage = rdr8["IntersestMemPackage"].ToString();
                        }
                        cnn8.Close();
                        rdr8.Close();
                    }

                    //end data from table tblampackages

                    // add row to datatable
                    dt.Rows.Add(IntersestMemId, IntersestMemName, IntersestMemAccFor, IntersestMemPhoto, IntersestMemAbout, IntersestMemAge, IntersestMemReligion, IntersestMemCaste, IntersestMemSCaste, IntersestMemCity, IntersestMemState, IntersestMemCountry, IntersestMemEducation, IntersestMemOccupation, IntersestMemHeight, IntersestMemHeightcm, IntersestMemPackage);
                    // Empty strings

                    IntersestMemName = string.Empty;
                    IntersestMemAccFor = string.Empty;
                    IntersestMemAbout = string.Empty;
                    IntersestMemAge = string.Empty;
                    IntersestMemReligion = string.Empty;
                    IntersestMemCaste = string.Empty;
                    IntersestMemSCaste = string.Empty;
                    IntersestMemCity = string.Empty;
                    IntersestMemState = string.Empty;
                    IntersestMemCountry = string.Empty;
                    IntersestMemEducation = string.Empty;
                    IntersestMemOccupation = string.Empty;
                    IntersestMemHeight = string.Empty;
                    IntersestMemHeightcm = string.Empty;
                    IntersestMemPhoto = string.Empty;
                    IntersestMemPackage = string.Empty;
                }
            }
            cnn1.Close();
            rdr1.Close();
        }
    }
}