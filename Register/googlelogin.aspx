<%@ Page Language="C#" AutoEventWireup="true" CodeFile="googlelogin.aspx.cs" Inherits="Register_googlelogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title><link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
</head>
<body>
     <form id="form1" runat="server">
        <%--<div>
            
            <h1>Login With google using asp.net application</h1>
                <br />
                    <a href="#" class="button"  id="A1"
                                      onclick="OpenGoogleLoginPopup();" name="butrequest"> <span>Login with google</span></a>
            <br />
            <a href="http://accounts.google.com/logout?&continue=http://www.google.com"> google account logout</a>
            <table>
                <tr>
                    <td>Google ID</td>
                    <td><%=Google_ID%></td>
                 </tr>
                 <tr>
                    <td>Email/user name</td>
                    <td><%=Email_address%></td>
                 </tr>
                 <tr>
                    <td>first name</td>
                    <td><%=firstName%></td>
                 </tr>
                 <tr>
                    <td>Last name</td>
                    <td><%=LastName%></td>
                 </tr>

                  <tr>
                    <td>Google FullName</td>
                    <td><%=FullName%></td>
                 </tr>
                 <tr>
                    <td>link</td>
                    <td><%=googlelink%></td>
                 </tr>
                 <tr>
                    <td>photo</td>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl=' <%=gphoto%>'/></td>
                 </tr>
                 <tr>
                    <td> gender</td>
                    <td><%=gender%></td>
                 </tr>
            </table>
        </div>--%>
    </form>
    <%--<script type="text/javascript" language=javascript>


        function OpenGoogleLoginPopup() {


            var url = "https://accounts.google.com/o/oauth2/auth?";
            url += "scope=https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email&";
            url += "state=%2Fprofile&"
            url += "redirect_uri=<%=Return_url %>&"
            url += "response_type=token&"
            url += "client_id=<%=Client_ID %>";

            window.location = url;
        }


    </script>--%>
</body>
</html>
