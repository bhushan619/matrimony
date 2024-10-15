<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="ActivateDeletedProfile.aspx.cs" Inherits="Register_ActivateDeletedProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>
<title>Swapnpurti Matrimony | Activate Deleted Profile</title>   <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
<link href="../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="../js/jquery-1.11.0.min.js"></script>
<!-- Custom Theme files -->
<link href="../css/style.css" rel="stylesheet" type="text/css" media="all"/>
     <link href="../css/font-awesome.min.css" rel="stylesheet" />
     <link href="../css/font-awesome.css" rel="stylesheet" />
<!-- Custom Theme files -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); }>
</script>
<meta name="keywords" content="Matrimony Website, Maharashtra, India, Indian, Hindi, Marathi, Tamil, Telugu, Franchisee, Marriage" />
<!--Google Fonts-->
<!-- start-smoth-scrolling -->
<script type="text/javascript" src="../js/move-top.js"></script>
<script type="text/javascript" src="../js/easing.js"></script>
        <link href="../css/font-awesome.css" rel="stylesheet" />
	<script type="text/javascript">
	    jQuery(document).ready(function ($) {
	        $(".scroll").click(function (event) {
	            event.preventDefault();
	            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
	        });
	    });
	</script>
<!-- //end-smoth-scrolling -->
<!-- animated-css -->
		<link href="../css/animate.css" rel="stylesheet" type="text/css" media="all">
		<script src="../js/wow.min.js"></script>
		<script>
		    new WOW().init();
		</script>
<!-- animated-css --> 
</head>
<body >
    <form id="form1" runat="server">
   <div class="bann-two">
	<div class="header">
			<div class="container">
		      <div class="header-main">
				<div class="logo wow bounceInLeft" data-wow-delay="0.5s">
					<a href="Default.aspx"><img src="../images/lo.png" alt=""></a>
				</div>
				<div class="head-right wow bounceInRight" data-wow-delay="0.5s">
					<ul>
						
						<li><a href="Register/Login.aspx"><i class="fa fa-sign-in "></i> Login</a></li>
                        <li><a href="Register/Registration.aspx"><i class="fa fa-registered"></i> Register</a></li>
                         <li><a href="Admin/login.aspx" ><i class="fa fa-user"></i> Franchisee</a></li>
					</ul>
				</div>
			  <div class="clearfix"> </div>
			</div> 
			</div>
		</div>
	</div> 
<!--baner end here-->
<!--navgation start here-->
<div class="navgation">
	<div class="fixed-header">
				<div class="top-nav">
						<span class="menu"> </span>
                    <div class="phone" >
                          <ul >
						<li style="color: #FFFFFF"> <i class="fa fa-phone "></i> 0 9561421489</li>
                       </ul>
                      </div>
					<ul>
								<li><a href="../Default.aspx" >Home</a></li>
					    <li><a href="../WhoWeAre.aspx">Who We Are</a></li>
						<li><a href="../Services.aspx" class="active">Services</a></li>	
                        <li><a href="FranchiseeRegister.aspx">Work with Us</a></li>				
						<li><a href="../Contact.aspx">Contact</a></li>
					</ul>
				<!-- script-nav -->
			<script>
			    $("span.menu").click(function () {
			        $(".top-nav ul").slideToggle(500, function () {
			        });
			    });
			</script>
			<script type="text/javascript">
			    jQuery(document).ready(function ($) {
			        $(".scroll").click(function (event) {
			            event.preventDefault();
			            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
			        });
			    });
					</script>
				<!-- //script-nav -->
				</div>
				<div class="clearfix"> </div>
			</div>
		</div>
	<!--script-->
			<!-- script-for sticky-nav -->
		<script>
		    $(document).ready(function () {
		        var navoffeset = $(".navgation").offset().top;
		        $(window).scroll(function () {
		            var scrollpos = $(window).scrollTop();
		            if (scrollpos >= navoffeset) {
		                $(".navgation").addClass("fixed");
		            } else {
		                $(".navgation").removeClass("fixed");
		            }
		        });

		    });
		</script>
	
    <div class="services">
	<div class="container"> 
         <div class="col-lg-12 text-left"> 
               <h2>Thank you for coming back</h2>
             <br />
                            <div class="col-lg-4">
                                <img src="../images/goodbye.png" />
                            </div>
                <div class="col-lg-6">
                   
               <h4>We are happy to have you back...</h4>
                <p>Notes: Your Profile will be activated soon..</p>
                <p>You will recieve a mail of confirmation after Activation.</p>
             <br />
                      <div class="form-group">  
   <asp:Button ID="Button1"  runat="server" Text="Cancel"  CssClass="btn btn-success" OnClick="Button1_Click"    /> &nbsp;
                  <asp:Button ID="btnSubmit"  runat="server" Text="Activate"  CssClass="btn btn-danger" OnClick="btnSubmit_Click"  /> 
 </div>
                </div>
                        </div>
    </div></div>
<div class="footer">
	<div class="container">
		 
		<div class="copyright">
				<p>© 2015 Swapnpurti Matrimony All rights reserved by Swapnpurti Matrimony | Design by  <a href="http://anuvaasoft.com/" target="_blank">  Anuvaa Softech Pvt. Ltd </a></p>
		</div>
	</div>
</div>
<!--footer end here-->
						 
    </form> 
</body>
</html>
