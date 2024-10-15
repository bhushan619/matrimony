<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="Enquiry.aspx.cs" Inherits="Register_Enquiry" %>

<!DOCTYPE html>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {   Uri previousUri = Request.UrlReferrer; 
        try
        {
         
            
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");

            mail.From = new System.Net.Mail.MailAddress("swapnpurtimatrimony@gmail.com");;
            mail.To.Add("swapnpurtimatrimony@gmail.com");      
                        
          
           mail.Subject = "Enquiry on Swapnpurti Matrimony from Enquiry Page";
            
             // done HTML formatting in the next line to display my logo 

           mail.Body = "Enquiry at Swapnpurti Matrimony by \n \n Name :" + Request["nm"].ToString() + "\n E-Mail : " + Request["eml"].ToString() + "\n Mobile : " + Request["mob"].ToString() + "\n Message : " + Request["enq"].ToString();
           
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("swapnpurtimatrimony@gmail.com", "anuvaa2015");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

          
            ClientScript.RegisterStartupScript(this.GetType(),
                    "popup",
                    "alert('Message sent successfully.');window.location='" + previousUri.ToString() + "';",
                    true);
           // Response.Redirect("");
        }
        catch (Exception ass)
        {
            ClientScript.RegisterStartupScript(this.GetType(),
                      "popup",
                      "alert('" + ass.Message + "');window.location='" + previousUri.ToString() + "';",
                      true);          
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>   <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
