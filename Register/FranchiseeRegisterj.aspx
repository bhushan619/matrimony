<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="FranchiseeRegisterj.aspx.cs" Inherits="Register_FranchiseeRegisterj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
  <!-- Start main-content -->

    <!-- Section: inner-header -->
    

 
      <div class="container">
            <div class="row"> 
            <div class="col-md-12">
              <h3 class="title text-theme-colored text-center ">Franchisee Login/Register</h3>
            </div><div class="separator">
  <i class="fa fa-cog fa-spin"></i>
</div>
          </div>
          
        <div class="row">
          <div class="col-md-4 mb-40">
              <div class="icon-box mb-0 p-0">
                <a  class="icon icon-bordered icon-rounded icon-sm pull-left mb-0 mr-10">
                  <i class="pe-7s-lock"></i>
                </a>
                <h4 class="text-gray pt-10 mt-0 mb-30">Login to view your panel.</h4>
              </div>
           <%-- <h4 class="text-gray mt-0 pt-5"> Login</h4>--%>
            <hr>
          <%--  <p>Lorem ipsum dolor sit amet, consectetur elit.</p>--%>
            <div  class="clearfix">
              <div class="row">
                <div class="form-group col-md-12">
                  <label for="form_username_email">Username/Email-Id</label>
                    <asp:TextBox ID="txtUsername"  CssClass="form-control" placeholder="Franchisee E-Mail" runat="server" type="email" pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum|in|co.in)"  required></asp:TextBox>   
                </div>
              </div>
              <div class="row">
                <div class="form-group col-md-12">
                  <label for="form_password">Password</label>
                     <asp:TextBox ID="txtpass" runat="server"  CssClass="form-control" placeholder="Password" TextMode="Password" required></asp:TextBox>
                </div>
              </div>
              <div class="checkbox pull-left mt-15">
                <label for="form_checkbox">
                  <input id="form_checkbox" name="form_checkbox" type="checkbox">
                  Remember me </label>
              </div>
              <div class="form-group pull-right mt-10">
                <asp:LinkButton ID="btnlogin" runat="server" OnClick="btnlogin_Click"  class="btn  btn-dark btn-theme-colored btn-sm" Text="Login"/>
              </div>
              <div class="clear text-center pt-10"><!-- popup modal click trigger -->
                <a class="text-theme-colored font-weight-600 font-12"  href="ForgetpasswordPersonal.aspx">Forgot Your Password?</a>
              </div>
           
            </div>
          </div>
          <div class="col-md-7 col-md-offset-1">
            <div  class="register-form" >
              <div class="icon-box mb-0 p-0">
                <a  class="icon icon-bordered icon-rounded icon-sm pull-left mb-0 mr-10">
                  <i class="pe-7s-users"></i>
                </a>
                <h4 class="text-gray pt-10 mt-0 mb-30">Don't have an Account? Register Now.</h4>
              </div>
              <hr>
             <%-- <p class="text-gray">Register and start an amazing journey...</p>--%>
              <div class="row">
                <div class="form-group col-md-6">
                  <label for="form_name">Name</label>
                         <asp:TextBox ID="txtMemberName" runat="server" required="required"  CssClass="form-control" placeholder="Franchisee Name"></asp:TextBox>
             
                </div>
                <div class="form-group col-md-6">
                  <label>Mobile Number</label>
                    <asp:TextBox ID="txtMobile" required="required"  pattern="[7-9]{1}[0-9]{9}" runat="server" placeholder="Mobile"   CssClass="form-control"></asp:TextBox>
                </div>
              </div>   
              <div class="row">
                <div class="form-group col-md-6">
                  <label for="form_choose_username">Username/Email-Id</label>
                    <asp:TextBox ID="txtEmail" required="required" runat="server" placeholder="Valid E-mail"  CssClass="form-control" pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum|in|co.in)" ></asp:TextBox>
                </div>
             
                <div class="form-group col-md-6">
                  <label for="form_choose_password"> Password</label>
                 <asp:TextBox ID="txtPassword" required="required"   CssClass="form-control" placeholder="Password eg. abD45cp"  pattern="^(?![0-9]{6})[0-9a-zA-Z]{6}$" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                
              </div>
              <div class="form-group">
                <asp:LinkButton ID="btnRegister" runat="server" OnClick="btnRegister_Click" class="btn  btn-dark btn-theme-colored btn-lg btn-block mt-15"  Text="Register Now" />
                  <br />
                   <asp:Label ID="lblError" runat="server"></asp:Label>
              </div>

                <div class="container">
        <div class="row">
          <div class="col-md-12">
            <!-- popup modal -->
            <div id="promoModal1" class="modal-promo-box bg-img-cover mfp-hide" data-bg-img="../OutsideDesign/images/bg/bg1.jpg">
              <h3 class="mt-0">Can't Sign In? Forget Your Password</h3>
              <h5>Please enter your email address below and we'll send you password...</h5>
              <div id="mailchimp-subscription-form" class="newsletter-form mt-30">
              	<label for="mce-EMAIL"></label>
                <div class="input-group">
                     <asp:TextBox ID="txtEmailforgetpassword"  data-height="40px" class="form-control input-lg" placeholder="Your Email" runat="server" type="email" pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum|in|co.in)"  required></asp:TextBox>   
               
               
                  <span class="input-group-btn">
                   
                 <asp:LinkButton ID="btnforgetpassword" runat="server" Text="" OnClick="btnforgetpassword_Click" type="submit" class="btn btn-colored btn-theme-colored btn-xs m-0" data-height="40px" style="height: 40px;font-size:20px">Get my password</asp:LinkButton>
                  </span>
                </div>
              </div>

              <!-- Mailchimp Subscription Form Validation-->
              <script type="text/javascript">
                $('#mailchimp-subscription-form').ajaxChimp({
                    callback: mailChimpCallBack,
                    url: '//thememascot.us9.list-manage.com/subscribe/post?u=a01f440178e35febc8cf4e51f&amp;id=49d6d30e1e'
                });

                function mailChimpCallBack(resp) {
                    // Hide any previous response text
                    var $mailchimpform = $('#mailchimp-subscription-form'),
                        $response = '';
                    $mailchimpform.children(".alert").remove();
                    console.log(resp);
                    if (resp.result === 'success') {
                        $response = '<div class="alert alert-success"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>' + resp.msg + '</div>';
                    } else if (resp.result === 'error') {
                        $response = '<div class="alert alert-danger"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>' + resp.msg + '</div>';
                    }
                    $mailchimpform.prepend($response);
                }
              </script>

              <a href="FranchiseeRegisterj.aspx#" class="button" onClick="$.magnificPopup.close(); return false;">Don't Show me Again</a>
            </div>

          </div>
        </div>
      </div>
               
            </div>
          </div>
        </div>    
      </div>
         

  <!-- end main-content -->
</asp:Content>

