<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="home" class="divider">
      <div class="container-fluid p-0">

        <!-- template -->
        <div class="ms-fullscreen-template" id="slider1-wrapper">
          <!-- masterslider -->
          <div class="master-slider ms-skin-default" id="masterslider">

            <!-- Slide 1 -->
            <div class="ms-slide custom-slide slide-1">
              <img src="" data-src="../OutsideDesign/images/bg/bg4.jpg" alt="lorem ipsum dolor sit"/>  
                
               <h1 class="ms-layer text-white bsmall-text  font-playfair font-40"
              data-type="text"
              data-effect="rotate3dtop(70,0,0,80)"
              data-duration="2000"
              data-ease="easeInOutBack"
              >Welcome To Swapnpurti  </h1>
              
              <h1 class="ms-layer text-white small-text font-playfair font-40"
              data-type="text"
              data-effect="rotate3dbottom(70,0,0,180)"
              data-duration="2000"
              data-ease="easeInOutBack"
              >For Happy Weddings</h1>
            </div>

            <!-- Slide 2 -->
            <div class="ms-slide custom-slide slide-1">
              <img src="" data-src="../OutsideDesign/images/bg/bg5.jpg" alt=""/>
                 <h1 class="ms-layer text-white bsmall-text  font-playfair font-40"
              data-type="text"
              data-effect="rotate3dtop(70,0,0,80)"
              data-duration="2000"
              data-ease="easeInOutBack"
              >Search for Perfect Partner  </h1>
              
              <h1 class="ms-layer text-white small-text font-playfair font-40"
              data-type="text"
              data-effect="rotate3dbottom(70,0,0,180)"
              data-duration="2000"
              data-ease="easeInOutBack"
              >For Happy Weddings</h1>
            </div>
            
            <!-- Slide 3 -->
            <div class="ms-slide custom-slide slide-1">
              <img src="" data-src="../OutsideDesign/images/bg/bg16.jpg" />
                 <h1 class="ms-layer text-white bsmall-text  font-playfair font-40"
              data-type="text"
              data-effect="rotate3dtop(70,0,0,80)"
              data-duration="2000"
              data-ease="easeInOutBack"
              >Understand Life Partner </h1>              
              <h1 class="ms-layer text-white small-text font-playfair font-40"
              data-type="text"
              data-effect="rotate3dbottom(70,0,0,180)"
              data-duration="2000"
              data-ease="easeInOutBack"
              >For Happy Weddings</h1> 
            </div>
            <!-- end of masterslider -->
        </div>
        <!-- end of template -->

        <!-- jQuery Code -->
        <script>
          $(document).ready(function(){ 
            var slider = new MasterSlider();
            slider.setup('masterslider' , {
              width:1024,
              height:768,
              space:5,
              view:'parallaxMask',
              autofill:true,
              speed:30,
              loop: true
            });                    
            slider.control('arrows' ,{insertTo:'#masterslider'}); 
            slider.control('bullets');
            var wrapper = $('#slider1-wrapper');
              wrapper.height(window.innerHeight - 118);
              $(window).resize(function(event) {
              wrapper.height(window.innerHeight - 118);
            });
            MSScrollParallax.setup(slider,50,80,true);
          });
        </script>
      </div>
    </section>


    
       <section class="divider bg-img-center-bottom" data-bg-img="../outsidedesign/images/bg/bg20.png" style="background-image: url('../outsidedesign/images/bg/bg20.png');">
      <div class="container ">
        <div class="section-content">
                 <div class="row ">
            <div class="col-md-6 col-md-offset-3 text-center pb-30 wow fadeInUp animation-delay1" style="visibility: visible;">
              <h2>About Us</h2>
              <img src="../outsidedesign/images/section-title-after.png" alt="">
              <p>The main objective of this site is to provide grooms and brides with excellent matchmaking experience by exploring the opportunities and resources to meet true potential partner. </p>
            </div>
          </div>
          <div class="row features-style1 text-center mt-20">
            <div class="col-sm-4">
              <div class="icon-box left media p-0"> <a  class="media-left pull-left icon icon-gray icon-sm icon-bordered"><i class="pe-7s-star text-theme-colored"></i></a>
                <div class="media-body">
                  <h5 class="media-heading heading">Our goal</h5>
                  <p>To provide the best matchmaking service with interactive and user-friendly platform for brides and grooms to help, find their ideal life partner for their marriage.</p>
                </div>
              </div>
            </div>
            <div class="col-sm-4">
              <div class="icon-box left media p-0"> <a  class="media-left pull-left icon icon-gray icon-sm icon-bordered"><i class="fa fa-diamond text-theme-colored"></i></a>
                <div class="media-body">
                  <h5 class="media-heading heading">Our mission</h5>
                  <p>To create incredible matrimony site and provide transparent clients satisfactory services to bring success & happiness in life of clients.</p>
                </div>
              </div>
            </div>
            <div class="col-sm-4">
              <div class="icon-box left media p-0"> <a  class="media-left pull-left icon icon-gray icon-sm icon-bordered"><i class="fa fa-thumbs-up text-theme-colored"></i></a>
                <div class="media-body">
                  <h5 class="media-heading heading">Our Speciality</h5>
                  <p>“TRUST, TRANSPARANCY & TRANSFER” is what we believe.We transfer genuine profile to perfect matches who are waiting for it.</p>
                </div>
              </div>
            </div>
            
          </div>
        </div>
      </div>
           </section>
    <section class="text-center layer-overlay overlay-dark" data-stellar-background-ratio="0.5" data-bg-img="../OutsideDesign/images/bg/bg8.jpg" style="background-image: url(&quot;../OutsideDesign/images/bg/bg8.jpg&quot;);"> 
      <div class="container ">
      
        <div class="row ">
          <div class="col-sm-4">
            <div class="icon-box iconbox-theme-colored">
              <a class="icon icon-white icon-bordered icon-border-effect effect-flat" >
                <i class="fa fa-male"></i>
              </a>
              <h5 class="icon-box-title text-white">Search for Groom</h5>
              <p class="text-gray">Genuine and verified profiles available on single click.</p>
            </div>
          </div>
          <div class="col-sm-4">
            <div class="icon-box iconbox-theme-colored">
                           <a class="icon icon-white icon-bordered icon-border-effect effect-flat" >
                <i class="fa fa-female"></i>
              </a>
              <h5 class="icon-box-title text-white">Search for Bride</h5>
              <p class="text-gray">Genuine and verified profiles available on single click.</p>
            </div>
          </div>
          <div class="col-sm-4">
            <div class="icon-box iconbox-theme-colored">
                          <a class="icon icon-white icon-bordered icon-border-effect effect-flat" >
                <i class="pe-7s-chat"></i>
              </a>
              <h5 class="icon-box-title text-white">Talk with Members</h5>
              <p class="text-gray">Online and offline chat for paid members.</p>
            </div>
          </div>
        </div>
      </div>
    </section>
  <!-- Divider: Divider -->
    
    
    
  
    <!-- Diver: Google Map  -->
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


