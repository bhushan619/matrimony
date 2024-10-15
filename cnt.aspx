<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="cnt.aspx.cs" Inherits="cnt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!-- Divider: Contact -->  <script type='text/javascript' src='//go.oclaserver.com/apu.php?zoneid=718853'></script>
    <script async="async" type="text/javascript" src="//go.mobisla.com/notice.php?p=718879&interactive=1&pushup=1"></script>
   
    <section class="divider layer-overlay overlay-white-9" data-bg-img="../OutsideDesign/images/bg/bg1.jpg">
      <div class="container">
          
        <div class="row pt-30">
          <div class="col-md-8">
          <%--     <h3 class="text-theme-colored mt-0">Our Services</h3>--%>
            <h3 class="mt-0 mb-30">Interested in discussing?</h3>
            <!-- Contact Form -->
            <form id="contact_form" name="contact_form" class="form-transparent">
              <div class="row">
                <div class="col-sm-6">
                  <div class="form-group">
                    <label for="form_name">Name <small>*</small></label>
                         <asp:TextBox ID="txtName" CssClass="form-control" runat="server" required="required" class="name" Placeholder="Enter Name" ></asp:TextBox> 
                   <%-- <input id="form_name" name="form_name" class="form-control" type="text" placeholder="Enter Name" required="">--%>
                  </div>
                </div>
                <div class="col-sm-6">
                  <div class="form-group">
                    <label for="form_email">Email <small>*</small></label>
                       <asp:TextBox ID="txtEmail" CssClass="form-control required email" runat="server" required="required" pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum|in|co.in)" placeholder="Enter Email"></asp:TextBox> 
                
                   <%-- <input id="form_email" name="form_email" class="form-control required email" type="email" placeholder="Enter Email">--%>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-sm-6">
                  <div class="form-group">
                    <label for="form_name">Subject <small>*</small></label>
                       <asp:TextBox ID="txtsubject" CssClass="form-control required" runat="server" required="required" class="name" Placeholder="Enter Subject" ></asp:TextBox> 
                  
<%--                    <input id="form_subject" name="form_subject" class="form-control required" type="text" placeholder="Enter Subject">--%>
                  </div>
                </div>
                <div class="col-sm-6">
                  <div class="form-group">
                    <label for="form_phone">Mobile</label>
                       <asp:TextBox ID="txtmobile" CssClass="form-control" runat="server" required="required" class="name" Placeholder="Enter Mobile No." ></asp:TextBox> 
                  
<%--                    <input id="form_phone" name="form_phone" class="form-control" type="text" placeholder="Enter Phone">--%>
                  </div>
                </div>
              </div>
              <div class="form-group">
                <label for="form_name">Message</label>
                   <asp:TextBox ID="txtMessage" CssClass="form-control required" runat="server" TextMode="MultiLine" required="required" placeholder="Enter Message"></asp:TextBox> 
              
               <%-- <textarea id="form_message" name="form_message" class="form-control required" rows="5" placeholder="Enter Message"></textarea>--%>
              </div>
              <div class="form-group">
                <input id="form_botcheck" name="form_botcheck" class="form-control" type="hidden" value="" />
                <asp:Button ID="btnSubmit" runat="server" Text="Send" class="btn btn-dark btn-theme-colored btn-flat mr-5" data-loading-text="Please wait..." OnClick="btnSubmit_Click" /> 
<%--                    <button type="submit" class="btn btn-dark btn-theme-colored btn-flat mr-5" data-loading-text="Please wait...">Send your message</button>--%>
                <a type="reset" class="btn btn-default btn-flat btn-theme-colored" href="cnt.aspx">Reset</a>
              </div>
            </form>
            <!-- Contact Form Validation-->
            <script type="text/javascript">
              $("#contact_form").validate({
                submitHandler: function(form) {
                  var form_btn = $(form).find('button[type="submit"]');
                  var form_result_div = '#form-result';
                  $(form_result_div).remove();
                  form_btn.before('<div id="form-result" class="alert alert-success" role="alert" style="display: none;"></div>');
                  var form_btn_old_msg = form_btn.html();
                  form_btn.html(form_btn.prop('disabled', true).data("loading-text"));
                  $(form).ajaxSubmit({
                    dataType:  'json',
                    success: function(data) {
                      if( data.status == 'true' ) {
                        $(form).find('.form-control').val('');
                      }
                      form_btn.prop('disabled', false).html(form_btn_old_msg);
                      $(form_result_div).html(data.message).fadeIn('slow');
                      setTimeout(function(){ $(form_result_div).fadeOut('slow') }, 6000);
                    }
                  });
                }
              });
            </script>
          </div>
          <div class="col-md-4">
            <div class="row">
              <div class="col-xs-12 col-sm-12 col-md-12">
                <div class="icon-box left media bg-light p-30 mb-20"> <a class="media-left pull-left" href="page-contact2.html#"> <i class="pe-7s-map-2 text-theme-colored"></i></a>
                  <div class="media-body"> <strong class="">OUR OFFICE LOCATION</strong>
                    <p>Flat No. 1, Akshay Chambers, Samarth Colony, Near Prabhat Chowk, Jalgaon Maharashtra (India).</p>
                  </div>
                </div>
              </div>
              <div class="col-xs-12 col-sm-6 col-md-12">
                <div class="icon-box left media bg-light p-30 mb-20"> <a class="media-left pull-left" href="page-contact2.html#"> <i class="pe-7s-call text-theme-colored"></i></a>
                  <div class="media-body"> <strong class="">OUR CONTACT NUMBER</strong>
                    <p>+91 257-606-6999</p>
                  </div>
                </div>
              </div>
              <div class="col-xs-12 col-sm-6 col-md-12">
                <div class="icon-box left media bg-light p-30 mb-20"> <a class="media-left pull-left" href="page-contact2.html#"> <i class="pe-7s-mail text-theme-colored"></i></a>
                  <div class="media-body"> <strong class="">OUR CONTACT E-MAIL</strong>
                    <p>contact@anuvaasoft.com</p>
                  </div>
                </div>
              </div>
              
            </div>
          </div>
        </div>
      </div>
    </section>
    
    <!-- Divider: Google Map -->
        <section>
      <div class="container-fluid p-0">
        <div class="row">
          <div class="col-sm-12 col-md-12">
            <!-- Google Map HTML Codes -->
            
            <div class="" >
                <div class="map-popupstring">
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3724.7702701312182!2d75.55429531423411!3d21.001843994074072!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3bd90fb6ac338fed%3A0x40cf465335102115!2sAnuvaa+Softech+Pvt+Ltd!5e0!3m2!1sen!2sin!4v1449659483052"  frameborder="0" style="border:0;height:350px" allowfullscreen></iframe>
  
  </div>
            </div>

          
          </div>
        </div>
     </div>
    </section>
</asp:Content>

