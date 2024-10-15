<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Register_Loginj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <!--Google  fb Fonts-->  
<%--    <script src="../js/JavaScript.js"></script>--%>
    <script src="https://connect.facebook.net/en_US/all.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- Section: Registration Form -->
    <section class="divider parallax layer-overlay overlay-light" data-stellar-background-ratio="0.5" data-bg-img="../OutsideDesign/images/bg/bg1.jpg">
      <div class="container-fluid">
        <div class="row">
          <div class="col-md-4 col-md-offset-4 bg-lightest-transparent p-30 pt-10">
            <h3 class="text-center text-theme-colored mb-20">Login </h3>
             <div class="row">
                <div class="col-sm-12">
                  <div class="form-group">
                    <label for="form_name">Username/Email-Id </label>
               
                       <asp:TextBox ID="txtEmail" required="required" runat="server" placeholder="Username/Email-Id " CssClass="form-control" pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum|in|co.in)" ></asp:TextBox>
 
                  </div>
                </div>
              
              </div>
              <div class="row">               
                <div class="col-sm-12">
                  <div class="form-group">
                       <label for="form_email">Password </label>
              
                       <asp:TextBox ID="txtPassword" required="required"   CssClass="form-control"  placeholder="Password"
       runat="server" TextMode="Password"></asp:TextBox>
                  </div>
                </div>
                
              </div>
           <div class="checkbox pull-left mt-10">
                    <label for="form_checkbox">
                      <input id="form_checkbox" name="form_checkbox" type="checkbox">
                      Remember me </label>
                  </div>
                  <div class="form-group pull-right mt-10">
                   <asp:LinkButton ID="btnLogin" runat="server" Text="Login" Width="100%" CssClass="btn btn-theme-colored"
            onclick="btnLogin_Click"  />
  
                  </div>
                  <div class="clear text-center pt-10">
                    <a class="text-theme-colored font-weight-600 font-12"  href="forgetPassword.aspx" >Forgot Your Password?</a>
                  </div>
 <div class="separator" style="color:#000">
  <span>Or Login With</span>
</div>
                               <div class="clear text-center pt-10">
                                   <div class="row">
                                       <div class="col-lg-12">
                                       <div class="col-lg-6 ">
<div class="fb-login-button"   onclick="return fblogin();" data-max-rows="1" data-size="xlarge" data-show-faces="false" autologoutlink="true" scope="user_birthday,email" >
     Login </div> 
                                       </div>
                                       <div class="col-lg-6" >

 <a href="#"   id="A1"      onclick="OpenGoogleLoginPopup();" name="butrequest" class="btn"  style="background-color:rgb(215, 22, 25);color: #fff;font-size: 24px;padding: 0px 5px 5px 5px;font-weight: 600;"   >G+ Login</a>
                    
                                       </div>
                                           </div>
                                   </div>
                                    
                                   <div id="fb-root"></div> <!-- This initializes the FB controls-->     

                  
                     
  <!-- FB Login Button -->  
             <script type="text/javascript">


                 $("document").ready(function () {
                     // Initialize the SDK upon load
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
                     
                 });

                 function fblogin() {
                     FB.init({

                         appId: '1158134130915249', // App ID
                         channelUrl: '//' + window.location.hostname + '/channel', // Path to your Channel File
                         scope: 'id,name,gender,user_birthday,email', // This to get the user details back from Facebook
                         status: true, // check login status
                         cookie: true, // enable cookies to allow the server to access the session
                         xfbml: true  // parse XFBML
                     });

                     //// listen for and handle auth.statusChange events
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


    </script>  <!-- FB Login Button -->  
                  </div>
          
              
     
          </div>
        </div>
      </div>
          
                  
                         
       <%-- google plus login script start --%>
	       <script type="text/javascript" language=javascript>


           function OpenGoogleLoginPopup() {


               var url = "https://accounts.google.com/o/oauth2/auth?";
               url += "scope=https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email&";
               url += "state=%2Fprofile&"
               url += "redirect_uri=<%=Return_url %>&"
            url += "response_type=token&"
            url += "client_id=<%=Client_ID %>";

            window.location = url;
        }


    </script>
     <%-- google plus login script end --%>
    </section>
</asp:Content>

