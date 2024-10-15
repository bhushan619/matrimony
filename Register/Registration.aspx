<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Register_Registrationj" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%--       <script src="../js/JavaScript.js"></script>--%>
    <script src="https://connect.facebook.net/en_US/all.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Section: Registration Form -->
    <section class="divider parallax layer-overlay overlay-light" data-stellar-background-ratio="0.5" data-bg-img="../OutsideDesign/images/bg/bg1.jpg">
      <div class="container-fluid">
        <div class="row">
          <div class="col-md-6 col-md-offset-3 bg-lightest-transparent p-30 pt-10">
            <h3 class="text-center text-theme-colored mb-20">Register Now</h3>
            <form id="job_apply_form" name="job_apply_form" action="includes/job.htm" method="post" enctype="multipart/form-data">
              <div class="row">
                <div class="col-sm-6">
                  <div class="form-group">
                    <label for="form_name">Name <small>*</small></label>
                   <asp:TextBox ID="txtMemberName" runat="server" required="required" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
 </div>
                </div>
                <div class="col-sm-6">
                  <div class="form-group">
                    <label for="form_email">Email <small>*</small></label>
                    <asp:TextBox ID="txtEmail" required="required" runat="server" placeholder="Valid E-mail" CssClass="form-control" pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum|in|co.in)" ></asp:TextBox>
  </div>
                </div>
              </div>
              <div class="row">      
                   <div class="col-sm-6">
                  <div class="form-group">
                    <label for="form_name">Mobile <small>*</small></label>
                   <asp:TextBox ID="txtMobile" required="required"  pattern="[7-9]{1}[0-9]{9}" runat="server" placeholder="Mobile"  CssClass="form-control"></asp:TextBox>
    </div>
                </div>         
                <div class="col-sm-6">
                  <div class="form-group">
                    <label for="form_sex">Gender <small>*</small></label>
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control"
        required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">-- Gender --</asp:ListItem>
     <asp:ListItem>Male</asp:ListItem>
      <asp:ListItem>Female</asp:ListItem>
      <%-- <asp:ListItem>Other</asp:ListItem> --%>
        </asp:DropDownList>
                  </div>
                </div>
                
              </div>
                <div class="row">
               <div class="col-sm-6">
                  <div class="form-group">
                    <label for="form_post">Profile For <small>*</small></label>
                   <asp:DropDownList ID="ddlProfileFor" runat="server" CssClass="form-control"
        required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">-- Matrimony Profile for--</asp:ListItem>
     <asp:ListItem>Myself</asp:ListItem>
      <asp:ListItem>Son</asp:ListItem>
       <asp:ListItem>Daughter</asp:ListItem>
        <asp:ListItem>Brother</asp:ListItem>
         <asp:ListItem>Sister</asp:ListItem>
          <asp:ListItem>Relative</asp:ListItem>
           <asp:ListItem>Friend</asp:ListItem>
        </asp:DropDownList>
                  </div>
                </div>
                <div class="col-sm-6">
                  <div class="form-group">
                    <label for="form_email">Franchisee <small></small></label>
                   <asp:TextBox ID="txtFranchisee" runat="server" placeholder="Franchisee (If Any)" CssClass="form-control" ></asp:TextBox>
   <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                    MinimumPrefixLength="1" CompletionInterval="1" 
                    EnableCaching="true"
                        DelimiterCharacters=""
                        Enabled="True" 
                        ServiceMethod="GetCompletionList" 
                        CompletionSetCount="1" 
                        TargetControlID="txtFranchisee" UseContextKey="True">
                        </cc1:AutoCompleteExtender>    </div>
                </div>
              </div>
                <div class="row">
                     <div class="col-sm-6">
                         <div class="form-group">
            <asp:TextBox ID="txtPassword" required="required"   CssClass="form-control"  placeholder="Password"
       runat="server" TextMode="Password"></asp:TextBox>
                             </div>
             </div>
                      <div class="col-sm-6">   
                           <div class="form-group">
                <label for="form_attachment">Biodata Upload</label>
                           <asp:FileUpload ID="fupBiodata" runat="server" Width="200px" CssClass="file" ToolTip="Upload BioData"  data-show-upload="false" data-show-caption="true"/>
                           <%--    <small>Maximum upload file size: 12 MB</small>--%>
              </div>
                          
                    </div> 
                   
                    </div>
                  <div class="row">  
                        <div class="col-sm-12">
<div class="checkbox pull-left mt-10">
                    <label for="form_checkbox">                  
                    Please read to the <a href="../TandC.aspx" target="_blank" class="text-theme-colored">Terms of Use</a> & <a href="../PrivacyPolicy.aspx" target="_blank" class="text-theme-colored">Privacy policy</a> before registering. </label> 
                  </div>
                            </div>
                      </div>
                   <div class="row">  
                        <div class="col-sm-12">
                                     <div class="form-group ">
                                         <asp:Button ID="btnRegister" runat="server" Text="Register Free" Width="100%" CssClass="btn  btn-theme-colored"
            onclick="btnRegister_Click" />
 <br />
                                           <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                        
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>                       </div>
                                    </div>        
                       </div>
                       <div class="row">                   
                              <div class="separator" style="color:#000">
  <span>Or Register With</span>
</div>
                               <div class="clear text-center pt-10">
                                   <div class="row">
                                       <div class="col-lg-12">
                                       <div class="col-lg-6 ">
<div class="fb-login-button"  data-max-rows="1" data-size="xlarge" data-show-faces="false" autologoutlink="true" scope="user_birthday,email" >
     Register with FB </div> 
                                       </div>
                                       <div class="col-lg-6" >

 <a href="#"   id="A1"      onclick="OpenGoogleLoginPopup();" name="butrequest" class="btn"  style="background-color:rgb(215, 22, 25);color: #fff;font-size: 24px;padding: 0px 5px 5px 5px;font-weight: 600;"   >Register with G+</a>
                    
                                       </div>
                                           </div>
                                   </div>
                                    
                                   <div id="fb-root"></div> <!-- This initializes the FB controls-->     

                  
                     
  <!-- FB Login Button -->  
             <script type="text/javascript">
                  function ValidateCheckBox(sender, args) {
            if (document.getElementById("ContentPlaceHolder1_cbkTC").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }

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
               
            </form>
         
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
          </div>
        </div>
      </div>
    </section>
</asp:Content>

