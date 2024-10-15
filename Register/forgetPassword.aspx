<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="forgetPassword.aspx.cs" Inherits="Register_forgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <section class="layer-overlay overlay-white-8" data-bg-img="images/bg/bg17.jpg">
    <div class="container">
        <div class="row">
             <div class="col-md-6 col-md-offset-3">
            <!-- popup modal -->
             
        <div class="border-1px p-25">
              <h3 class="text-theme-colored m-0">Can't Sign In? Forget Your Password</h3>
              <div class="line-bottom mb-30"></div>
            
              <h5>Please enter your email address below and we'll send your password Details...</h5>
              <div  class="newsletter-form mt-30">
          
                <div class="input-group">
                     <asp:TextBox ID="txtEmailforgetpassword"  data-height="40px" class="form-control input-lg" placeholder="Your Email" runat="server" type="email" pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum|in|co.in)"  required></asp:TextBox>   
               
               
                  <span class="input-group-btn">
                   
                 <asp:LinkButton ID="btnforgetpassword" runat="server" Text="" OnClick="btnforgetpassword_Click" type="submit" class="btn btn-colored btn-theme-colored btn-xs m-0" data-height="40px" style="height: 40px;font-size:20px">Get my password</asp:LinkButton>
                  </span>
                </div>
                  <br />

              </div>    </div>
</div>
            
        
        </div>
      </div>
           </section>
</asp:Content>

