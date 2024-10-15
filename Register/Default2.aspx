<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Register_Default2" %>

<!DOCTYPE html>

<html>
<head>
<title>Facebook Login Authentication Example</title>
<script type="text/javascript" src="http://code.jquery.com/jquery-latest.js"></script><link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
</head>
<body>
<script>
    // Load the SDK Asynchronously
    (function (d) {
        var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement('script'); js.id = id; js.async = true;
        js.src = "//connect.facebook.net/en_US/all.js";
        ref.parentNode.insertBefore(js, ref);
    }(document));

    // Init the SDK upon load
    window.fbAsyncInit = function () {
        FB.init({
            appId: '1158134130915249', // App ID
            channelUrl: '//' + window.location.hostname + '/channel', // Path to your Channel File
            status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true  // parse XFBML
        });

        // listen for and handle auth.statusChange events
        FB.Event.subscribe('auth.statusChange', function (response) {
            if (response.authResponse) {
                // user has auth'd your app and is logged into Facebook
                FB.api('/me', function (me) {
                    if (me.name) {
                        document.getElementById('auth-displayname').innerHTML = me.name;

                    }
                })
                document.getElementById('auth-loggedout').style.display = 'none';
                document.getElementById('auth-loggedin').style.display = 'block';
            } else {
                // user has not auth'd your app, or is not logged into Facebook
                document.getElementById('auth-loggedout').style.display = 'block';
                document.getElementById('auth-loggedin').style.display = 'none';
            }
        });
        $("#auth-loginlink").click(function () { FB.login(); });
        $("#auth-logoutlink").click(function () { FB.logout(function () { window.location.reload(); }); });
    }
</script>
<h1>
Facebook Login Authentication Example</h1>
<div id="auth-status">
<div id="auth-loggedout">
<a href="#" id="auth-loginlink"> <img src="fb-login-button.png" style=" border:0px"/></a>
</div>
<div id="auth-loggedin" style="display: none">
Hi, <span id="auth-displayname"></span>(<a href="#" id="auth-logoutlink">logout</a>)
</div>
</div>
</body>
</html>
