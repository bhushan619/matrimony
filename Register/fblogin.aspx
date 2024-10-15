<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fblogin.aspx.cs" Inherits="Register_fblogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
    <%-- Facebook.login --%>
    <script src="../js/JavaScript.js"></script>
    <script src="https://connect.facebook.net/en_US/all.js" type="text/javascript"></script>
    <script type="text/javascript">
       

        //$("document").ready(function () {
        //    // Initialize the SDK upon load
        //    FB.init({

        //        appId: '1158134130915249', // App ID
        //        channelUrl: '//' + window.location.hostname + '/channel', // Path to your Channel File
        //        scope: 'id,name,gender,user_birthday,email', // This to get the user details back from Facebook
        //        status: true, // check login status
        //        cookie: true, // enable cookies to allow the server to access the session
        //        xfbml: true  // parse XFBML
        //    });

        //    // listen for and handle auth.statusChange events
        //    FB.Event.subscribe('auth.statusChange', OnLogin);

        //});

        function fblogin() {
            FB.init({

                appId: '1158134130915249', // App ID
                channelUrl: '//' + window.location.hostname + '/channel', // Path to your Channel File
                scope: 'id,name,gender,user_birthday,email', // This to get the user details back from Facebook
                status: true, // check login status
                cookie: true, // enable cookies to allow the server to access the session
                xfbml: true  // parse XFBML
            });

            // listen for and handle auth.statusChange events
            FB.Event.subscribe('auth.statusChange', OnLogin);
        }
            // This method will be called after the user login into facebook.
            function OnLogin(response) {
                if (response.authResponse) {
                    FB.api('/me?fields=id,name,gender,email,birthday', LoadValues);
                }
            }
            //This method will load the values to the labels
            function LoadValues(me) {
                if (me.name) {
                    window.location = "facebooklogin.aspx?emls=" + me.email + "&nmes=" + me.name + "&grns=" + me.gender + "&idsf=" + me.id + "";
                    //document.getElementById('displayname').innerHTML = me.name;
                    //document.getElementById('FBId').innerHTML = me.id;
                    //document.getElementById('DisplayEmail').innerHTML = me.email;
                    //document.getElementById('Gender').innerHTML = me.gender;
                    //document.getElementById('DOB').innerHTML = me.birthday;
                    //document.getElementById('auth-loggedin').style.display = 'block';
                }
            }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div id="fb-root"></div> <!-- This initializes the FB controls-->     

    <div class="fb-login-button" onclick="return fblogin();" autologoutlink="true" scope="user_birthday,email" >

      Login with Facebook

     </div> <!-- FB Login Button -->  
    </div>
    </form>
</body>
</html>
