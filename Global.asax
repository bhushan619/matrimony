<%@ Application Language="C#" %>

<script runat="server">
    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        System.Globalization.CultureInfo newCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
        newCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
        newCulture.DateTimeFormat.ShortTimePattern = "hh : mm : ss";
        newCulture.DateTimeFormat.DateSeparator = "-";         
        System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;
    }
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Application["Online_UserCount"] = 0;
    }
    public MySql.Data.MySqlClient.MySqlConnection con;
    public MySql.Data.MySqlClient.MySqlCommand cmd;
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        Application.Lock();

        Application["Online_UserCount"] = (int)Application["Online_UserCount"] + 1;
        con = new MySql.Data.MySqlClient.MySqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["matrimonyConnectionString"].ConnectionString;
        cmd = new MySql.Data.MySqlClient.MySqlCommand("UPDATE anuvaa_matrimony.hitscount SET Hits = Hits+1", con);
        cmd.CommandType = System.Data.CommandType.Text;

        using (con)
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
        con.Close();
        Application.UnLock();
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Application.Lock();
        Application["Online_UserCount"] = (int)Application["Online_UserCount"] - 1;
        Application.UnLock();
    }
       
</script>
