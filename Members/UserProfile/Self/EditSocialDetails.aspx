<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="EditSocialDetails.aspx.cs" Inherits="members_UserProfile_Self_Social" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../../images/favicon.ico" type="image/x-icon" />
</head>
<body oncontextmenu="return false;">
    <form id="form1" runat="server">
           <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/members/Activities/Notification.aspx" ToolTip="Notification" runat="server"> </asp:HyperLink>
  
   <div id="fb-root"></div>
<script>    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.4&appId=1158134130915249";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));
    </script>


    <div class="fb-login-button" data-max-rows="1" data-size="medium" data-show-faces="false" data-auto-logout-link="false">
        <asp:Label ID="Label1" runat="server" Text="Social Media"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Twitter" />
&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Facebook" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Social Profile Id/Link"></asp:Label>
        :(get Automatic)<br />
        <asp:Label ID="Label3" runat="server" Text="Profile Name"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="What's Up No."></asp:Label>
        <asp:TextBox ID="txtwhatsup" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Submit" />
    </div>


    </form>
</body>
</html>
