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
 


/// <summary>
/// Summary description for DatabaseConnection
/// </summary>
public class DatabaseConnection
{
    public MySql.Data.MySqlClient.MySqlConnection con, con1, con2,con3, conprofile;
    public MySql.Data.MySqlClient.MySqlCommand cmd, cmd1;
    public MySql.Data.MySqlClient.MySqlDataReader dr,dr1, dr2;

    public MySql.Data.MySqlClient.MySqlDataAdapter dataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter();
    public DataTable oDt, oDt1;
    public DataRow oDr;

    string tdt = string.Empty;

    public string begindate = new DateTime(DateTimeOffset.UtcNow.LocalDateTime.Year, DateTimeOffset.UtcNow.LocalDateTime.Month, 1).ToShortDateString();
    public string enddate = DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString();

    public DatabaseConnection()
    {
        //
        con = new MySql.Data.MySqlClient.MySqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;
        con1 = new MySql.Data.MySqlClient.MySqlConnection();
        con1.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;
        con2 = new MySql.Data.MySqlClient.MySqlConnection();
        con2.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

        con3 = new MySql.Data.MySqlClient.MySqlConnection();
        con3.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;

        conprofile = new MySql.Data.MySqlClient.MySqlConnection();
        conprofile.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;
        //
    }
    public string CreateRandomPassword(int PasswordLength)
    {
        string _allowedChars = "123456789";
        Random randNum = new Random();
        char[] chars = new char[PasswordLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < PasswordLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }
    public string CreateRandomMemberId(int IdLength)
    {
        string _allowedChars = "123456789";
        Random randNum = new Random();
        char[] chars = new char[IdLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < IdLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }
    /*..........................................get member all information from id)......................*/
   
     public int max_tblammemberregistration()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberregistration", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    /*................................Member max function................................*/
    public int check_already_Member(string email)
    {
        try
        {
            int schId = 0;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varEmail FROM anuvaa_matrimony.tblammemberregistration WHERE varEmail ='" + email + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                schId = 1;
            }
            else
            {
                schId = 0;
            }
            con.Close();
            return schId;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public string getGender(string memberid)
    {
        string gender = string.Empty;
        try
        {

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varGender FROM anuvaa_matrimony.tblammemberregistration WHERE varMemberId ='" + memberid + "' and varMemberStatus='Verified'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                gender = dr["varGender"].ToString();
                if (gender == "Male")
                {
                    gender = "varGender='Female'";
                }
                else if (gender == "Female")
                {
                    gender = "varGender='Male'";
                }
                //else
                //{
                //    gender = "varGender='Other'";
                //}
            }
            con.Close();
            return gender;
        }
        catch (Exception s)
        {
            con.Close();
            return gender;
        }
    }
    
    public int max_tblammemberemailcode()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberemailcode", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
            con.Close();
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblamemberview()
    {
        int chk = 0;
        try
        {
            con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblamemberview", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammembercontactdetails()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammembercontactdetails", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberfamily()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberfamily", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberinformation()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberinformation", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }

    public int max_tblammemberlifestyle()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberlifestyle", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberlivingin()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberlivingin", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberphysicalinformation()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberphysicalinformation", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberprofessionalinfo()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberprofessionalinfo", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberreligiousinfo()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberreligiousinfo", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberinterests()
    {
        int chk = 0;
        try
        {
            con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberinterests", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammembershortlist()
    {
        int chk = 0;
        try
        {
            con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammembershortlist", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammembertransactions()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammembertransactions", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberuploads()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberuploads", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblmembercontactviewscount()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblmembercontactviewscount", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }


    ///.................................Registration ......................
    public int insert_tblammemberregistration(string MId, string MembershipType, string MembershipFor, string Mname, string Gender, string mob, string mverify, string email, string everify, string Mstatus, string FId, string AId, string CreatorStatus, string Password,string img)//add extra 3 feild below
    {
        try
        {
            int id = max_tblammemberregistration();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberregistration VALUES(" + id + ",N'" + MId + "',N'" + MembershipType + "',N'" + MembershipFor + "',N'" + Mname + "',N'" + Gender + "',N'" + mob + "',N'" + mverify + "',N'" + email + "',N'" + everify + "',N'" + Mstatus + "',N'" + FId + "',N'" + AId + "',N'" + CreatorStatus + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "',N'" + Password + "','" + img + "','Approved','NA')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }  
     
    public int insert_tblCompaignRegistration(string MId, string day, string month, string year, string age, string Maritalstatus, string nochild, string childStatus, string AboutMyself, string MotherTongue, string Religion, string Caste, string SubCaste, string Gotra, string Manglik, string HeighFtIn, string HeightCms, string Weight, string Bloodgroup, string BodyType, string Complexion, string SpecialCase, string Qualification, string Additional, string EmployeeIn, string Occupation, string AnnualIncome, string Currency, string Country, string CitizenShip, string state, string city, string Familystatus, string Familytype, string Familyvalue, string eat, string smoke, string drink,string address,string weightlbs)
    {
        try
        {
            int eid = max_tblammemberemailcode() + 1;
            string email = CreateRandomPassword(15);

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("insert into anuvaa_matrimony.tblammemberemailcode VALUES('" + eid + "','" + MId + "','" + email + "','','','','','') ", con);
            cmd2.ExecuteNonQuery();
            con.Close();
            cmd2.Dispose();

            int Bid = max_tblammemberinformation();
            Bid = Bid + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberinformation VALUES(" + Bid + ",N'" + MId + "',N'" + day + "',N'" + month + "',N'" + year + "',N'" + age + "',N'" + Maritalstatus + "',N'" + childStatus + "',N'" + nochild + "',N'" + AboutMyself + "','','','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            int Rid = max_tblammemberreligiousinfo();
            Rid = Rid + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdr = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberreligiousinfo VALUES(" + Rid + ",N'" + MId + "',N'" + MotherTongue + "',N'" + Religion + "',N'" + Caste + "',N'" + SubCaste + "',N'" + Gotra + "','','',N'" + Manglik + "','','','','')", con);
            cmdr.ExecuteNonQuery();
            con.Close();
            cmdr.Dispose();

            int Phid = max_tblammemberphysicalinformation();
            Phid = Phid + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdph = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberphysicalinformation VALUES(" + Phid + ",N'" + MId + "',N'" + HeighFtIn + "',N'" + HeightCms + "',N'" + Weight + "',N'" + BodyType + "',N'" + Complexion + "',N'" + Bloodgroup + "',N'" + SpecialCase + "',N'" + weightlbs + "')", con);
            cmdph.ExecuteNonQuery();
            con.Close();
            cmdph.Dispose();

            int Prid = max_tblammemberprofessionalinfo();
            Prid = Prid + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdpr = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberprofessionalinfo VALUES(" + Prid + ",N'" + MId + "',N'" + Qualification + "',N'" + Additional + "','','',N'" + EmployeeIn + "',N'" + Occupation + "','',N'" + AnnualIncome + "',N'" + Currency + "','','','','')", con);
            cmdpr.ExecuteNonQuery();
            con.Close();
            cmdpr.Dispose();

            int LVid = max_tblammemberlivingin();
            LVid = LVid + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdlv = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberlivingin VALUES(" + LVid + ",N'" + MId + "',N'" + Country + "',N'" + CitizenShip + "',N'" + state + "',N'" + city + "','','')", con);
            cmdlv.ExecuteNonQuery();
            con.Close();
            cmdlv.Dispose();

            int Fid = max_tblammemberfamily();
            Fid = Fid + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdfm = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberfamily VALUES(" + Fid + ",N'" + MId + "','', '','','','','','','','',N'" + Familystatus + "',N'" + Familytype + "',N'" + Familyvalue + "','','','','')", con);
            cmdfm.ExecuteNonQuery();
            con.Close();
            cmdfm.Dispose();

            int LSdid = max_tblammemberlifestyle();
            LSdid = LSdid + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdls = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberlifestyle VALUES(" + LSdid + ",N'" + MId + "',N'" + eat + "',N'" + smoke + "',N'" + drink + "','', '','','','','','','','')", con);
            cmdls.ExecuteNonQuery();
            con.Close();
            cmdls.Dispose();

            int viewcount = max_tblmembercontactviewscount();
            viewcount = viewcount + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdcc = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblmembercontactviewscount VALUES(" + viewcount + ",'" + MId + "','0','0','','')", con);
            cmdcc.ExecuteNonQuery();
            con.Close();
            cmdcc.Dispose();
            ////////////////////////////////// Other Member table Info Insert like member id
            int Contactid = max_tblammembercontactdetails();
            Contactid = Contactid + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdcon = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammembercontactdetails VALUES(" + Contactid + ",N'" + MId + "','', '','','','','','" + address + "','','','','','','')", con);
            cmdcon.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            ///////////////////////////photo upload
            //int mupload = max_tblammemberuploads();
            //mupload = mupload + 1;
            //con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmdmup = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberuploads VALUES(" + mupload + ",N'" + MId + "','', '','','','','','')", con);
            //cmdmup.ExecuteNonQuery();
            //con.Close();
            //cmdmup.Dispose();          

            //////////////////////////////////////////Partener table 10aug

            //int ppcaste = max_tblamemberpartnercaste();
            //ppcaste = ppcaste + 1;
            //con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmdppc = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblamemberpartnercaste VALUES(" + ppcaste + ",N'" + MId + "','','','')", con);
            //cmdppc.ExecuteNonQuery();
            //con.Close();
            //cmdppc.Dispose();

            //int pplaung = max_tblamemberpartnerlanguages();
            //pplaung = pplaung + 1;
            //con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmdppl = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblamemberpartnerlanguages VALUES(" + pplaung + ",N'" + MId + "','','','')", con);
            //cmdppl.ExecuteNonQuery();
            //con.Close();
            //cmdppl.Dispose();

            //int ppmt = max_tblamemberpartnermothertongue();
            //ppmt = ppmt + 1;
            //con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmdppmt = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblamemberpartnermothertongue VALUES(" + ppmt + ",N'" + MId + "','','','')", con);
            //cmdppmt.ExecuteNonQuery();
            //con.Close();
            //cmdppmt.Dispose();

            //int ppst = max_tblamemberpartnersubcaste();
            //ppst = ppst + 1;
            //con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmdppst = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblamemberpartnersubcaste VALUES(" + ppst + ",N'" + MId + "','','','')", con);
            //cmdppst.ExecuteNonQuery();
            //con.Close();
            //cmdppst.Dispose();

            //int pparea = max_tblammemberpartnerarea();
            //pparea = pparea + 1;
            //con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmdpparea = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberpartnerarea VALUES(" + pparea + ",N'" + MId + "','','','','')", con);
            //cmdpparea.ExecuteNonQuery();
            //con.Close();
            //cmdpparea.Dispose();

            int ppbasic = max_tblammemberpartnerbasic();
            ppbasic = ppbasic + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdppbasic = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberpartnerbasic VALUES(" + ppbasic + ",N'" + MId + "','','','','','','','','','','','','','','','','','','','','','','')", con);
            cmdppbasic.ExecuteNonQuery();
            con.Close();
            cmdppbasic.Dispose();


            //int ppedu = max_tblammemberpartnereducation();
            //ppedu = ppedu + 1;
            //con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmdppedu = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberpartnereducation VALUES(" + ppedu + ",N'" + MId + "','')", con);
            //cmdppedu.ExecuteNonQuery();
            //con.Close();
            //cmdppedu.Dispose();

            //int ppemp = max_tblammemberpartneremploy();
            //ppemp = ppemp + 1;
            //con.Open();
            //MySql.Data.MySqlClient.MySqlCommand cmdppemp = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberpartneremploy VALUES(" + ppemp + ",N'" + MId + "','','','','')", con);
            //cmdppemp.ExecuteNonQuery();
            //con.Close();
            //cmdppemp.Dispose();

            int ppinc = max_tblammemberpartnerincome();
            ppinc = ppinc + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdppinc = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberpartnerincome VALUES(" + ppinc + ",N'" + MId + "','','','','','')", con);
            cmdppinc.ExecuteNonQuery();
            con.Close();
            cmdppinc.Dispose();

            int pprelg = max_tblammemberpartnerreligious();
            pprelg = pprelg + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdpprelg = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberpartnerreligious VALUES(" + pprelg + ",N'" + MId + "','','','','','','','')", con);
            cmdpprelg.ExecuteNonQuery();
            con.Close();
            cmdpprelg.Dispose();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int update_tblammemberregistration_Photo(string mid, string img,string visibility)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblammemberregistration SET varPhoto='" + img + "',varPhotoApprove='UnApproved',ex3='" + visibility + "' WHERE varMemberId='" + mid + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int update_tblamrequests(string tid, string fid, string Status)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblamrequests SET varStatus='" + Status + "' WHERE varFromMemberId='" + fid + "' and varToMemberId='" + tid + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int Update_tblammemberregistration(string mid, string mship, string mprofilefor, string mname, string mgen, string mstatus)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblammemberregistration SET varMembershipType='" + mship + "',varMemberFor='" + mprofilefor + "',varMemberName='" + mname + "',varGender='" + mgen + "',  varMemberStatus='" + mstatus + "' WHERE varMemberId='" + mid + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
        /*..............................Member Contact..........................*/
   
    public int update_tblammembercontactdetails(string id, string ParentsMb, string ParentsPhone, string MemberMb, string MemberMbAlt, string Email, string EmailAlt, string PAddress, string LAddress, string ContactPerson, string ContactPersonMb, string Profilerel)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammembercontactdetails SET varParentMobile = '" + ParentsMb + "',varParentLandline = '" + ParentsPhone + "',varMemberAlternateMobile1 = '" + MemberMb + "', varMemberAlternateMobile2='" + MemberMbAlt + "', varMemberAlternateEmail1= '" + Email + "',varMemberAlternateEmail2 = '" + EmailAlt + "',varPermanantAddress = '" + PAddress + "',varAlternateAddress = '" + LAddress + "',varContactPersonName = '" + ContactPerson + "',varContactPersonMobile = '" + ContactPersonMb + "',varRelationOfContactPerson = '" + Profilerel + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int update_tblammembercontactdetails_Address(string id, string address)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammembercontactdetails SET varPermanantAddress = '" + address + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    /*........................................Member Personal Info............................*/

    public int update_tblammemberinformation(string id, string day, string month, string year, string age, string Maritalstatus, string childStatus, string nochild, string AboutMyself)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberinformation SET varAgeDate = '" + day + "',varAgeMonth = '" + month + "',varYearMonth = '" + year + "', varAgeToday='" + age + "', varMaritalStatus= '" + Maritalstatus + "',varChildrenStatus = '" + childStatus + "',varChildrenNo = '" + nochild + "',varAbout = '" + AboutMyself + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    /*........................................Member Religious Info............................*/

    public int update_tblammemberreligiousinfo(string id, string MotherTongue, string Religion, string Caste, string SubCaste, string gothra, string Star, string Raashi, string Manglik, string Thour, string Tmin,string format)
    {
        try
        {
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberreligiousinfo SET varMotherTongue = '" + MotherTongue + "',varReligion = '" + Religion + "',varCasteDivision = '" + Caste + "', varSubcaste='" + SubCaste + "', varGotraGothram= '" + gothra + "',varStar = '" + Star + "',varRaasiMoonSign = '" + Raashi + "',varManglik = '" + Manglik + "',intHourOfBirth = '" + Thour + "',intMinOfBirth = '" + Tmin + "',ex1 = '" + format + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    /*........................................Member Professional Info............................*/
    public int update_tblammemberprofessionalinfo(string id, string Qualification, string Additional, string College, string EducationDetails, string EmployeeIn, string Occupation, string OccupationDetails, string AnnualIncome, string currency, string WorkExperience, string experienceIn)
    {
        try
        {
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberprofessionalinfo SET varEducation = '" + Qualification + "',varAdditionalDegree = '" + Additional + "',varCollegeOrInstitution = '" + College + "', varEducationDetail='" + EducationDetails + "', varEmployeeIn= '" + EmployeeIn + "',varOccupation = '" + Occupation + "',varOccupationDetail = '" + OccupationDetails + "',varAnnualIncome = '" + AnnualIncome + "',varIncomeCurrency = '" + currency + "', varExperience = '" + WorkExperience + "' , varExperienceIn = '" + experienceIn + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    /*........................................Member Physical Info............................*/
    public int update_tblammemberphysicalinformation(string id, string hft, string hcm, string weight, string bodytype, string complex, string bgroup, string specialcase)
    {
        try
        {
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberphysicalinformation SET varHeightFt = '" + hft + "',varHeightCm = '" + hcm + "',varWeight = '" + weight + "', varBodyType='" + bodytype + "', varComplexion= '" + complex + "',varBloodGroup = '" + bgroup + "',varSpecialCase = '" + specialcase + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    /*........................................Member Family Info............................*/

    public int update_tblammemberfamily(string id, string FName, string Foccupation, string MName, string Moccupation, string BroNo, string BroMarried, string SisNo, string SisMarried, string living, string FStatus, string FType, string FValue, string AboutFamily)
    {
        try
        {
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberfamily SET varFatherName = '" + FName + "',varFatherOccupation = '" + Foccupation + "',varMotherName = '" + MName + "', varMotherOccupation='" + Moccupation + "', varNoOfBrother= '" + BroNo + "',varBrotherMarried = '" + BroMarried + "',varNoOfSister = '" + SisNo + "',varSisterMarried = '" + SisMarried + "',varLiveWithParent = '" + living + "',varFamilystatus = '" + FStatus + "',varFamilytype = '" + FType + "',varFamilyvalue = '" + FValue + "',varAboutfamily = '" + AboutFamily + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    /*........................................Member LivingIn Info............................*/

    public int update_tblammemberlivingin(string id, string country, string citizenship, string state, string city)
    {
        try
        {
            con.Close();
            con.Open();                                                                                                                    //varCountry, varCitizenship, varState, varCity        
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberlivingin SET varCountry = '" + country + "',varCitizenship = '" + citizenship + "',varState = '" + state + "', varCity='" + city + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    /*........................................Member LifeStyle Info............................*/

    public int update_tblammemberlifestyle(string id, string eat, string smoke, string drink, string music, string destination, string book, string author, string hobby, string language)
    {
        try
        {
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberlifestyle SET varEatingHabits = '" + eat + "',varSmoke = '" + smoke + "',varDrink = '" + drink + "', varFavouriteMusic='" + music + "',varFavouriteDestination='" + destination + "',varFavouriteBook='" + book + "',varFavouriteAuthor='" + author + "',varHobbyInterest='" + hobby + "',varSpokenLanguages='" + language + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    /*........................................Member Messaging And Activity............................*/

    public int insert_message(string msgfrom, string frdesig, string frstatus, string fromname, string msgto, string todesig, string tostatus, string toname, string message)
    {
        try
        {
            con.Close();
            int id = max_tblamcommunication();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamcommunication VALUES (" + id + ",'" + msgfrom + "','" + frdesig + "','" + frstatus + "','" + fromname + "','" + msgto + "','" + todesig + "','" + tostatus + "','" + toname + "','','','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            int idc = max_tblamconversation();
            idc = idc + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdc = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamconversation VALUES (" + idc + ",'" + id + "','" + msgfrom + "','" + message + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','Unread')", con);
            cmdc.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int check_if_member(string fid)
    {
        try
        {
            int schId = 0;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberId FROM tblammemberregistration WHERE varMemberId='" + fid + "' and varMemberStatus='Verified'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                schId = 1;
            }
            else
            {
                schId = 0;
            }
            con.Close();
            return schId;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public string get_member_name(string fid)
    {
        try
        {
            con1.Close();
            string name = string.Empty;
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varMemberName FROM tblammemberregistration WHERE varMemberId='" + fid + "'", con1);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name = dr["varMemberName"].ToString();
            }
            con1.Close();
            return name;
        }
        catch (Exception s)
        {
            con.Close();
            return string.Empty;
        }
    }
    public string get_member_Email(string fid)
    {
        try
        {
            con1.Close();
            string name = string.Empty;
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varEmail FROM tblammemberregistration WHERE varMemberId='" + fid + "'", con1);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name = dr["varEmail"].ToString();
            }
            con1.Close();
            return name;
        }
        catch (Exception s)
        {
            con.Close();
            return string.Empty;
        }

    }
    public string get_member_EmailCode(string mid)
    {
        try
        {
            con1.Close();
            string name = string.Empty;
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varEmailCode as cde FROM tblammemberemailcode WHERE varMemberId='" + mid + "'", con1);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name = dr["cde"].ToString();
            }
            con1.Close();
            return name;
        }
        catch (Exception s)
        {
            con.Close();
            return string.Empty;
        }
    }
    public int max_tblamcommunication()
    {
        int chk = 0;
        try
        {
            con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblamcommunication", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int check_already_interest(string inOfid, string inInid)
    {
        int chk = 0;
        try
        {
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblammemberinterests WHERE varInterestOfId='" + inOfid + "' AND varInterestInId='" + inInid + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = 1;
            }
            con.Close();
            return chk;
        }
        catch (Exception s)
        {
            con.Close();
            return chk;
        }
    }
    public string check_already_msg(string inOfid, string inInid)
    {
        string chk = string.Empty;
        try
        {
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblamcommunication WHERE varMsgFrom='" + inOfid + "' AND varMsgto='" + inInid + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = dr["intId"].ToString();
            }
            else
            {
                con.Close();
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblamcommunication WHERE varMsgto='" + inOfid + "' AND varMsgFrom='" + inInid + "'", con);
                dr = cmd2.ExecuteReader();
                if (dr.Read())
                {
                    chk = dr["intId"].ToString();
                }
                else
                {
                    chk = 0.ToString();
                }
            }
            con.Close();
            return chk;
        }
        catch (Exception s)
        {
            con.Close();
            return chk;
        }
    }
    public int check_already_Shortlist(string shortby, string shortto)
    {
        int chk = 0;
        try
        {
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblammembershortlist WHERE varMemberId='" + shortby + "' AND 	varShortListMemberId='" + shortto + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = 1;
            }
            con.Close();
            return chk;
        }
        catch (Exception s)
        {
            con.Close();
            return chk;
        }
    }
    public int check_already_tblamrequests(string shortby, string shortto)
    {
        int chk = 0;
        try
        {
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblamrequests WHERE varFromMemberId='" + shortby + "' AND 	varToMemberId='" + shortto + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = 1;
            }
            con.Close();
            return chk;
        }
        catch (Exception s)
        {
            con.Close();
            return chk;
        }
    }
    public int insert_tblammemberinterests(string fromMember, string inMember)
    {
        int chk = 0;
        try
        {
            int id = max_tblammemberinterests();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblammemberinterests VALUES (" + id + ",'" + fromMember + "','" + inMember + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            chk = 1;
        }
        catch (Exception ex)
        {
            return chk;
        }
        con.Close();
        return chk;
    }
    public int insert_tblammembershortlist(string fromMember, string inMember)
    {
        int chk = 0;
        try
        {
            int id = max_tblammembershortlist();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblammembershortlist VALUES (" + id + ",'" + fromMember + "','" + inMember + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            chk = 1;
        }
        catch (Exception ex)
        {
            return chk;
        }
        con.Close();
        return chk;
    }
    public int insert_tblamrequests(string fromMember, string inMember)
    {
        int chk = 0;
        try
        {
            int id = max_tblamrequests();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamrequests VALUES (" + id + ",'" + fromMember + "','" + get_member_name(fromMember) + "','','" + inMember + "','" + get_member_name(inMember) + "','','Hi I am " + get_member_name(fromMember) + ".Can not exactly judge your personality, do you mind sharing a photograph?','Pending','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','Photo Upload','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            chk = 1;
        }
        catch (Exception ex)
        {
            return chk;
        }
        con.Close();
        return chk;
    }
    public void insert_tblamemberview(string viewBy, string viewTo)
    {
        
        try
        {
            int already = check_already_view(viewBy, viewTo);
            if (already == 1)
            {
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("update tblamemberview set varDate='" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "', varTime='" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "' where varMemberId='" + viewBy + "' and varViewedMemberId='" + viewTo + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
            }
            else
            {
                int id = max_tblamemberview();
                id = id + 1;
                con.Open();
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamemberview VALUES (" + id + ",'" + viewBy + "','" + viewTo + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','','')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose(); 
            }
        }
        catch (Exception ex)
        {
             
        }
        con.Close();
        
    }
    public int check_already_view(string viewByMember, string viewToMember)
    {
        int chk = 0;
        try
        {

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT intId FROM tblamemberview WHERE varMemberId='" + viewByMember + "' AND varViewedMemberId='" + viewToMember + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = 1;
            }
            con.Close();
            return chk;
        }
        catch (Exception s)
        {
            con.Close();
            return chk;
        }
    }

    /*................................Partner max function................................*/

    public int max_tblamemberpartnercaste()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblamemberpartnercaste", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblamemberpartnerlanguages()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblamemberpartnerlanguages", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblamemberpartnermothertongue()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblamemberpartnermothertongue", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblamemberpartnersubcaste()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblamemberpartnersubcaste", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberpartnerarea()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberpartnerarea", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberpartnerbasic()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberpartnerbasic", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberpartnereducation()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberpartnereducation", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberpartneremploy()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberpartneremploy", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberpartnerincome()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberpartnerincome", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammemberpartnerreligious()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberpartnerreligious", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    /*......................................Partner   update ....................................*/

    public int update_tblammemberpartnerbasic_Lifestyle(string id, string eat, string smoke, string drink)
    {
        try
        {
            con.Open();                                                                                                                          //varSmoking, varDrinking, varEating
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberpartnerbasic SET varEating = '" + eat + "',varSmoking = '" + smoke + "',varDrinking = '" + drink + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int update_tblammemberpartnerbasic_Personal(string id, string agefrom, string ageto, string mstatus, string havechild, string childlive, string aboutpartner)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberpartnerbasic SET varAgefrom = '" + agefrom + "',varAgeto = '" + ageto + "',varMaritalStatus = '" + mstatus + "',varHaveChildren = '" + havechild + "',varChildLive = '" + childlive + "',varAboutPartner = '" + aboutpartner + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int update_tblammemberpartnerbasic_Physical(string id, string hfrom, string hto, string wfrom, string wto, string complex, string btype, string special)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberpartnerbasic SET varHeightfrom = '" + hfrom + "',varHeightto = '" + hto + "',varWeightfrom = '" + wfrom + "',varWeightto = '" + wto + "',varComplexion = '" + complex + "',varBodytype = '" + btype + "',varSpecialCase='" + special + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int update_tblammemberpartnerbasic_Family(string id, string living, string fvalue, string ftype, string fstatus)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberpartnerbasic SET varLivingwithparents = '" + living + "',varFamilyvalues = '" + fvalue + "',varFamilytype = '" + ftype + "',varFamilystatus = '" + fstatus + "' WHERE varMemberId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
     
    /*................................Conversation................................*/
    public int max_tblamconversation()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblamconversation", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    /*................................loginentry................................*/
    public int max_tblamloginentry()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblamloginentry", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }

    public void FirstTimeLogin(string mid)
    {
        con.Open();
        MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblammemberregistration SET  varMemberStatus='Verified' where varMemberId='" + mid + "'", con);
        cmd1.ExecuteNonQuery();
        con.Close();

    }
    //.................................................notifications
    public int max_tblamnotifications()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblamnotifications", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    //..................................................personnel(admin/Franchisee)Registration
    public int max_tblampersonnel()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblampersonnel", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    //.............................................................packages
    public int max_tblampackages()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblampackages", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblampackagesdetails()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblampackagesdetails", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public string get_tblampackagesId(string pname)
    {
      string nme = string.Empty;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select varPackageId as pid from anuvaa_matrimony.tblampackages where varPackageName='" + pname + "'", con2);
            con2.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                nme = dr["pid"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        con2.Close();
        return nme;
    }
    public string get_tblampackagesname(string id)
    {
        string nme = string.Empty;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select  varPackageName  from anuvaa_matrimony.tblampackages where varPackageId='" + id + "'", con2);
            con2.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                nme = dr["varPackageName"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        con2.Close();
        return nme;
    }
    public int insert_tblampackages( string pname, string pduration, string pdurtime, string pprice, string pdescri, string pbenefit,string contacts)
    {
        try
        {
            string pac = get_tblampackagesId(pname);
            int id = max_tblampackagesdetails();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblampackagesdetails VALUES(" + id + ",N'" + pac + "',N'" + pdescri + "',N'" + pduration + "',N'" + pdurtime + "',N'" + pprice + "',N'" + pbenefit + "','" + contacts + "','')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
     
    public int insert_package_single(string package_name)
    {
        try
        {
            int id = max_tblampackages();
            id = id + 1;
            con.Open();
            string packageId = CreateRandomPassword(3);
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblampackages VALUES(" + id + ",N'" + packageId + "',N'" + package_name + "','')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception ex)
        {
            con.Close();
            return 0;
        }
    }
    //......................................................profilestatus
    public int max_tblamprofilestatus()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblamprofilestatus", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int max_tblammsendemaildetails()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammsendemaildetails", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    //...........................................................requests
    public int max_tblamrequests()
    {
        int chk = 0;
        try
        {
            con.Close();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblamrequests", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }

    /*................................Franchisee................................*/
    public int insert_tblRegisterFranchisee(string frid, string cname, string mob, string mverify, string email, string emailverify, string pass)
    {
        try
        {
            int id = max_tblampersonnel();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblampersonnel VALUES (" + id + ",'" + frid + "','" + cname + "','Franchisee','','','','','','" + email + "','" + emailverify + "','" + mob + "','" + mverify + "','','" + pass + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','Inactive','NoProfile.jpg','')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int update_tblRegisterFranchisee(string fid, string name, string address, string country, string state, string city, string pincode, string landline, string img)
    {
        try
        {

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblampersonnel SET varName='" + name + "',varAddress='" + address + "',varCity='" + city + "',varState='" + state + "',varCountry='" + country + "',varPinCode='" + pincode + "',varLandline='" + landline + "', varProfilePic ='" + img + "' WHERE varFranchiseeId='" + fid + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int update_FranchiseePass(string fid, string pass)
    {
        try
        {
            con.Close();
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblampersonnel SET varPassword='" + pass + "' WHERE varFranchiseeId='" + fid + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int delete_Message(string convid)
    {
        try
        {

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from anuvaa_matrimony.tblamconversation where intId=" + convid + "", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int check_already_franchisee(string email)
    {
        try
        {
            int schId = 0;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varEmail FROM anuvaa_matrimony.tblampersonnel WHERE varEmail ='" + email + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                schId = 1;
            }
            else
            {
                schId = 0;
            }
            con.Close();
            return schId;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int check_if_franchisee(string fid)
    {
        try
        {
            int schId = 0;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT varFranchiseeId FROM anuvaa_matrimony.tblampersonnel WHERE varFranchiseeId ='" + fid + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                schId = 1;
            }
            else
            {
                schId = 0;
            }
            con.Close();
            return schId;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int update_tblampersonnelFranchisee(string fid, string name, string address, string country, string state, string city, string pincode, string landline, string status)
    {
        try
        {

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblampersonnel SET varName='" + name + "',varAddress='" + address + "',varCity='" + city + "',varState='" + state + "',varCountry='" + country + "',varPinCode='" + pincode + "',varLandline='" + landline + "',varStatus='" + status + "' WHERE varFranchiseeId='" + fid + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public String select_FranchieeProfilePic(string id)
    {
        String name = String.Empty;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select varProfilePic from anuvaa_matrimony.tblampersonnel where varFranchiseeId ='" + id + "' ", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name = dr["varProfilePic"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return name;
    }
    ////////////////////////////////////Admin
    public int Update_ProfilePicadmin(int adminid, string fname)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblampersonnel SET varProfilePic='" + fname + "' WHERE intId=" + adminid + "", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }

    } 
    public int update_AdminPass(int fid, string pass)
      {
          try
          {
              con.Close();
              con.Open();
              MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblampersonnel SET varPassword='" + pass + "' WHERE intId=" + fid + "", con);

              cmd.ExecuteNonQuery();
              con.Close();
              cmd.Dispose();
              return 1;
          }
          catch (Exception s)
          {
              con.Close();
              return 0;
          }
      }
    public int update_tblRegisterAdmin(string fid, string name, string address, string country, string state, string city, string pincode, string landline, string email, string mb, string img)
    {
        try
        {

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblampersonnel SET varName='" + name + "',varAddress='" + address + "',varCity='" + city + "',varState='" + state + "',varCountry='" + country + "',varPinCode='" + pincode + "',varLandline='" + landline + "',varProfilePic='" + img + "' WHERE intId=" + fid + "", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public String select_adminProfilePic(int id)
    {
        String name = String.Empty;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select varProfilePic from anuvaa_matrimony.tblampersonnel where intId =" + id + " ", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name = dr["varProfilePic"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return name;
    }

    /*.........................................................Success Story*/

    public int max_tblamsuccessstories()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblamsuccessstories", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int insert_tblamsuccessstories(string MembetId, string PartnerMemberId, string MemberName, string PartnerName, string EngagementDate, string MarriageDate, string WeddingLocation, string LivingAddress, string Country, string state, string city, string Mobile, string Story, string filename,string email)
    {
        try
        {
            int id = max_tblamsuccessstories();
            id = id + 1;
            con.Open();                                                                                                                                         //MembetId,string PartnerMemberId,string MemberName ,string PartnerName,string EngagementDate,string MarriageDate,string WeddingLocation,string LivingAddress,string Country,string state, string city,string Mobile,string Story,string filename)
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblamsuccessstories VALUES(" + id + ",N'" + MembetId + "',N'" + PartnerMemberId + "',N'" + MemberName + "',N'" + PartnerName + "','NA','NA',N'" + EngagementDate + "',N'" + MarriageDate + "',N'" + WeddingLocation + "',N'" + LivingAddress + "',N'" + Country + "',N'" + state + "',N'" + city + "',N'" + Mobile + "',N'" + Story + "','" + filename + "','Unverified','" + email + "','')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    ////////////////////////prajakta

    public int max_tblammemberupload()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblammemberuploads", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int insert_tblammemberuploads(string MemberId, string MuploadType, string Mcaption, string Mphototype, string MuploadPath, string Mvisibility)
    {
        try
        {
            int id = max_tblammemberuploads();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblammemberuploads VALUES(" + id + ",N'" + MemberId + "',N'" + MuploadType + "',N'" + Mcaption + "',N'" + Mphototype + "',N'" + MuploadPath + "',N'" + Mvisibility + "','UnApproved','NA')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;

        }
        catch (Exception ex)
        {
            con.Close();
            return 0;
        }
    }
    public int select_ProfolePic(string MemberId, string Mphototype)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT anuvaa_matrimony.tblammemberuploads  varCaption, varPhotoType, varUploadPath WHERE varMemberId='" + MemberId + "' AND varPhotoType='" + Mphototype + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    /*.........................Notification..................*/
    public double getInActiveGridview(string memid)
    {
        string[] qstrings = new string[19];
        try
        {
            qstrings = new string[]{
             "SELECT * FROM tblammemberinformation WHERE varMemberId='"+memid+"'",
      "SELECT * FROM tblammembercontactdetails WHERE varMemberId='"+memid+"'" ,
       "SELECT * FROM tblammemberfamily WHERE varMemberId='"+memid+"'",
     "SELECT * FROM tblammemberlifestyle WHERE  varMemberId='"+memid+"' ",
  "SELECT * FROM tblammemberlivingin WHERE varMemberId='"+memid+"' ",
  "SELECT * FROM tblammemberphysicalinformation WHERE varMemberId='"+memid+"'",
    "SELECT * FROM tblammemberprofessionalinfo WHERE varMemberId='"+memid+"' ",
  "SELECT * FROM tblammemberreligiousinfo WHERE varMemberId='"+memid+"' ",
    "SELECT * FROM tblammemberregistration WHERE varMemberId='"+memid+"'",

             "SELECT * FROM tblammemberpartnerarea WHERE varMemberId='"+memid+"' ",
    "SELECT * FROM tblammemberpartnerbasic WHERE varMemberId='"+memid+"' ",
   " SELECT * FROM tblammemberpartnereducation WHERE varMemberId='"+memid+"'",
   " SELECT * FROM tblammemberpartneremploy WHERE varMemberId='"+memid+"' ",
  " SELECT * FROM tblammemberpartnerincome WHERE varMemberId='"+memid+"'  ",
   "SELECT * FROM tblammemberpartnerreligious WHERE varMemberId='"+memid+"' ",
    "SELECT * FROM tblamemberpartnercaste WHERE varMemberId='"+memid+"' ",
   " SELECT * FROM tblamemberpartnerlanguages WHERE   varMemberId='"+memid+"' ",
   "SELECT * FROM tblamemberpartnermothertongue WHERE varMemberId='"+memid+"'  ",
   "SELECT * FROM tblamemberpartnersubcaste WHERE varMemberId='"+memid+"' "

            };


            int emp = 0;
            double count = 0.0;
            DataTable dtq = new DataTable();
            MySql.Data.MySqlClient.MySqlCommand cmd1;
            MySql.Data.MySqlClient.MySqlDataAdapter ad1;
            double tablecount = 100 / Convert.ToDouble(qstrings.Count());
            double completeProgres = 0.0, progressInPercentage = 0.0;
            for (int k = 0; k < qstrings.Count(); k++)
            {

                dtq.Clear();
                conprofile.Open();


                cmd1 = new MySql.Data.MySqlClient.MySqlCommand(qstrings[k], conprofile);
                ad1 = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd1);
                ad1.Fill(dtq);
                count = tablecount / dtq.Columns.Count;

                for (int i = 0; i < dtq.Columns.Count; i++)
                {
                    if (dtq.Rows.Count == 0)
                    {

                    }
                    else
                    {
                        if (string.IsNullOrEmpty(dtq.Rows[0][i].ToString()))
                        {
                            // flag = true; //means there is an empty value
                            emp = emp + 1;
                            //After you check all the fields  

                        }
                        else
                        {
                            //means if it found non null or empty in rows of a particular column
                            // flag = false;

                            // completeProgres += 0.263;
                            completeProgres += count;                        // goto EXIT;
                        }
                    }

                }
                dtq.Rows.Clear();
                foreach (var column in dtq.Columns.Cast<DataColumn>().ToArray())
                {
                    if (dtq.AsEnumerable().All(dr => dr.IsNull(column)))
                        dtq.Columns.Remove(column);
                }
                ad1.Dispose();
                cmd1.Dispose();
                conprofile.Close();

            }

            progressInPercentage = Math.Ceiling((completeProgres));
            // emptycol.Text = progressInPercentage.ToString(); //emp.ToString();
            return progressInPercentage;

        }

        catch (Exception ex)
        {
            return 0;

        }

    }
    public int count_tblamnotifications(string toid, string desig)
    {
        int not = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select count(intId) as newid from anuvaa_matrimony.tblamnotifications  where varStatus='Unread' and intNotToId='" + toid + "' and varNotToDesig='" + desig + "'", con2);
            con2.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                not = Convert.ToInt32(dr["newid"].ToString());
            }
            con2.Close();
            return not;
        }
        catch (Exception ex)
        {
            con2.Close();
            return not;
        }
    }
   // update_tblampackagesdetails
    public int update_tblampackagesdetails(string id, string descr, string dur, string durtime,string price, string benefit,string contacts)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.tblampackagesdetails SET varPackageDescription = '" + descr + "',varPackageDuration = '" + dur + "',varPackageDurationTime = '" + durtime + "',varPackagePrice = '" + price + "' ,varBenifits='" + benefit + "',ex1='" + contacts + "' WHERE intId = '" + id + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    //9/9/2015insert_tblamprofilestatus
//INSERT INTO tblammsendemaildetails(intId, varEmailType, varEmailTo, varSubject, varContentTpye, varTextMatter, varimg, ex1, ex2, ex3)
    public int insert_tblammsendemaildetails(string etype, string eto, string esub, string econtent, string etext, string img)
    {
        int chk = 0;
        try
        {
            int id = max_tblammsendemaildetails();
           
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblammsendemaildetails VALUES (" + id + ",'" + etype + "','" + eto + "','" + esub + "','" + econtent + "','" + etext + "','" + img + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            chk = 1;
        }
        catch (Exception ex)
        {
            return chk;
        }
        con.Close();
        return chk;
    }
    public int insert_tblamprofilestatus(string mid, string reason, string mdate, string experience, string source)
    {
        int chk = 0;
        try
        {
            int id = max_tblamprofilestatus();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamprofilestatus VALUES (" + id + ",'" + mid + "','Member','Deleted','" + reason + "','" + mdate + "','" + experience + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortDateString() + "','" + DateTimeOffset.UtcNow.AddHours(12).LocalDateTime.ToShortTimeString() + "','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            chk = 1;
        }
        catch (Exception ex)
        {
            return chk;
        }
        con.Close();
        return chk;
    }
    public int Update_tblammemberregistration_DeleteProfile(string mid)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblammemberregistration SET   varMemberStatus='Deleted' WHERE varMemberId='" + mid + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    public int Update_tblammemberregistration_ActivateProfile(string mid)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblammemberregistration SET varMemberStatus='VerifiedFirstTime' WHERE varMemberId='" + mid + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            con.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamprofilestatus WHERE varMemberId='" + mid + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
    //10-9-2015
    public int max_tblampersonnelbankdetails()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblampersonnelbankdetails", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }                                                                    // ddlbankname.Text, txtbankcity.Text, txtbankbranch.Text, txtbankifsccode.Text, mcir.Text, txtbankaccholdername.Text, txtbankaccno, ddlacctype.Text
    public int insert_tblampersonnelbankdetails(string fid,string bname,string bcity,string bbranch,string bifsc,string bmcir,string accholname,string accno,string acctype)
    {
        try
        {
            int id = max_tblampersonnelbankdetails();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblampersonnelbankdetails VALUES(" + id + ",N'" + fid + "',N'" + bname + "',N'" + bcity + "',N'" + bbranch + "',N'" + bifsc + "',N'" + bmcir + "',N'" + accholname + "',N'" + accno + "',N'" + acctype + "','','','')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception ex)
        {
            con.Close();
            return 0;
        }
    }

    /* notifications */

    public void insert_tblamnotifications(string type, string fromid, string fromName, string fromDesig, string toId, string toDesig, string text, string link, string sesson, string status, string remark)
    {
        try
        {
            int id = max_tblamnotifications();
            id = id + 1;
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO anuvaa_matrimony.tblamnotifications VALUES(" + id + ",'" + type + "','" + fromid + "','" + fromName + "','" + fromDesig + "','" + toId + "','" + toDesig + "','" + text + "','" + link + "','" + sesson + "','" + status + "','" + remark + "','','')", con1);
            cmd1.ExecuteNonQuery();
            con1.Close();
            cmd1.Dispose();
            
        }
        catch (Exception ex)
        {
             
        }
    }
    public void delete_Notification(string idDel)
    {
        try
        {
            
            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("delete from anuvaa_matrimony.tblamnotifications where intId=" + idDel + "", con1);
            cmd1.ExecuteNonQuery();
            con1.Close();
            cmd1.Dispose();

        }
        catch (Exception ex)
        {

        }
    }
    public void deleteAll_Notification(string memId)
    {
        try
        {

            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("delete from anuvaa_matrimony.tblamnotifications where intNotToId='" + memId + "'", con1);
            cmd1.ExecuteNonQuery();
            con1.Close();
            cmd1.Dispose();

        }
        catch (Exception ex)
        {

        }
    }
    public void readAll_Notification(string memId)
    {
        try
        {

            con1.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand("update anuvaa_matrimony.tblamnotifications set varStatus='Read' where intNotToId='" + memId + "'", con1);
            cmd1.ExecuteNonQuery();
            con1.Close();
            cmd1.Dispose();

        }
        catch (Exception ex)
        {

        }
    }
    /* partner proffessional */
    public void Delete_tblammemberpartnereducation(string memid)
    {
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnereducation  WHERE varMemberId='" + memid + "'", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        catch (Exception s)
        {
            con.Close();

        }
    }
   
    public void insert_tblammemberpartnereducation(string memid, string edu)
    {

        try
        {

            int id = max_tblammemberpartnereducation();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblammemberpartnereducation VALUES (" + id + ",'" + memid + "','" + edu + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

        }
        catch (Exception ex)
        {

        }
        con.Close();

    }

    public void Delete_tblammemberpartnerarea(string memid)
    {
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnerarea  WHERE varMemberId='" + memid + "'", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        catch (Exception s)
        {
            con.Close();

        }
    }

    public void insert_tblammemberpartnerarea(string memid, string area)
    {

        try
        {

            int id = max_tblammemberpartnerarea();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblammemberpartnerarea VALUES (" + id + ",'" + memid + "','" + area + "','','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

        }
        catch (Exception ex)
        {

        }
        con.Close();

    }

    public void Delete_tblammemberpartneremploy(string memid)
    {
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblammemberpartnerarea  WHERE varMemberId='" + memid + "'", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        catch (Exception s)
        {
            con.Close();

        }
    }

    public void insert_tblammemberpartneremploy(string memid, string employ)
    {

        try
        {

            int id = max_tblammemberpartneremploy();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblammemberpartneremploy VALUES (" + id + ",'" + memid + "','" + employ + "','','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

        }
        catch (Exception ex)
        {

        }
        con.Close();

    }

    public int update_tblammemberpartnerincome(string memid, string curr,string inc)
    {

        try
        { 
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("update tblammemberpartnerincome set varCurrency='" + curr + "',varAnnualIncome='" + inc + "' where varMemberId='" + memid + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return 1;
        }
        catch (Exception ex)
        {
            return 0;
        } 
    }
    /* partner proffessional end */

    /* religious  */

    public void Delete_tblamemberpartnercaste(string memid)
    {
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberpartnercaste  WHERE varMemberId='" + memid + "'", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        catch (Exception s)
        {
            con.Close();

        }
    }

    public void insert_tblamemberpartnercaste(string memid, string caste)
    {

        try
        {

            int id = max_tblamemberpartnercaste();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamemberpartnercaste VALUES (" + id + ",'" + memid + "','" + caste + "','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

        }
        catch (Exception ex)
        {

        }
        con.Close();

    }

    public void Delete_tblamemberpartnermothertongue(string memid)
    {
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("delete from tblamemberpartnermothertongue  WHERE varMemberId='" + memid + "'", con);
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }
        catch (Exception s)
        {
            con.Close();

        }
    }

    public void insert_tblamemberpartnermothertongue(string memid, string lang)
    {

        try
        {

            int id = max_tblamemberpartnermothertongue();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblamemberpartnermothertongue VALUES (" + id + ",'" + memid + "','" + lang + "','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

        }
        catch (Exception ex)
        {

        }
        con.Close();

    }

    public int update_tblammemberpartnerreligious(string memid, string relig, string mang, string nak, string ras)
    {
        try
        {
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("update tblammemberpartnerreligious set varReligion='" + relig + "',varManglik='" + mang + "',varNakshatra='" + nak + "',varRaasiMoonSign='" + ras + "' where varMemberId='" + memid + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();

            return 1;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    /* views counts */
    public int update_tblmembercontactviewscount(string mid, string count)
    {
        try
        {
            string viewcount = (count_tblmembercontactviewscountView(mid) + Convert.ToInt32(count)).ToString();
            count = (Convert.ToInt32(count) + count_tblmembercontactviewscount(mid)).ToString();
           
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblmembercontactviewscount SET varToView='" + count + "',varViewed='" + viewcount + "' WHERE varMemberId='" + mid + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int count_tblmembercontactviewscount(string memid)
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select varToView as newid from anuvaa_matrimony.tblmembercontactviewscount where varMemberId='"+memid+"'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }

    public int update_tblmembercontactviewscountView(string mid, string count)
    {
        try
        {

            count = (count_tblmembercontactviewscountView(mid) - Convert.ToInt32(count)).ToString();

            con2.Open();
            MySql.Data.MySqlClient.MySqlCommand cmdxc = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblmembercontactviewscount SET varViewed='" + count + "' WHERE varMemberId='" + mid + "'", con2);

            cmdxc.ExecuteNonQuery();
            con2.Close();
            cmdxc.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }

    public int count_tblmembercontactviewscountView(string memid)
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmdcx = new MySql.Data.MySqlClient.MySqlCommand("select varViewed as newid from anuvaa_matrimony.tblmembercontactviewscount where varMemberId='" + memid + "'", con2);
            con2.Open();
            dr = cmdcx.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con2.Close();
        return chk;
    }
    public int getPackageContactCount(string packageId,string duration,string time)
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT ex1 as newid from tblampackagesdetails where varPackageId='" + packageId + "' and varPackageDuration='" + duration + "' and varPackageDurationTime='" + time + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }

   //15-10-2015
    public int max_tblampersonneldocuments()
    {
        int chk = 0;
        try
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("select max(intId) as newid from anuvaa_matrimony.tblampersonneldocuments", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                chk = Convert.ToInt32(dr["newid"].ToString());
            }
        }
        catch (Exception ex)
        {

        }
        con.Close();
        return chk;
    }
    public int insert_tblampersonneldocuments(string fid, string doc, string cap)
    {
        int chk = 0;
        try
        {
            int id = max_tblampersonneldocuments();
            id = id + 1;
            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO tblampersonneldocuments VALUES (" + id + ",'" + fid + "','" + cap + "','" + doc + "','Unapproved','','','','')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            chk = 1;
        }
        catch (Exception ex)
        {
            return chk;
        }
        con.Close();
        return chk;
    }

   
    public int update_tblampersonneldocuments(string fid, string doc,string cap)
    {
        try
        {

            con.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE tblampersonneldocuments SET varCaption='" + cap + "',varDocPath='" + doc + "' WHERE varFranchiseeId='" + fid + "'", con);

            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
            return 1;
        }
        catch (Exception s)
        {
            con.Close();
            return 0;
        }
    }
}

