<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Register_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title><link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script type="text/javascript" language=javascript>
        try {
            // First, parse the query string
            var params = {}, queryString = location.hash.substring(1),
regex = /([^&=]+)=([^&]*)/g, m;
            while (m = regex.exec(queryString)) {
                params[decodeURIComponent(m[1])] = decodeURIComponent(m[2]);
            }
            var ss = queryString.split("&")

            window.location = "googlelogin.aspx?" + ss[1];


        } catch (exp) {
            alert(exp.message + " here 1");
        }
        </script>
    </div>
    </form>
</body>
</html>
