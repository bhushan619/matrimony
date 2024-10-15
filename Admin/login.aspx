<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Admin_login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!--Author: Anuvaa Softech Pvt. Ltd
Author URL: http://anuvaasoft.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE HTML>
<html>
<head>
<title>Swapnpurti Matrimony | Registration </title>  <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />   <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
<link href="../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="../js/jquery-1.11.0.min.js"></script>
<!-- Custom Theme files -->
<link href="../css/style.css" rel="stylesheet" type="text/css" media="all"/>
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
<body>
     <form id="form1" runat="server">
<!--banner start here-->
<div class="bann-two">
	<div class="header">
			<div class="container">
		      <div class="header-main">
				<div class="logo wow bounceInLeft" data-wow-delay="0.5s">
					<a href="../Default.aspx"><img src="../images/lo.png" alt=""></a>
				</div>
				<div class="head-right wow bounceInRight" data-wow-delay="0.5s">
					<ul>
						
						<li><a href="../Register/Login.aspx"><i class="fa fa-sign-in "></i> Login</a></li>
                        <li><a href="../Register/Registration.aspx"><i class="fa fa-registered"></i> Register</a></li>
                         <li><a href="login.aspx" ><i class="fa fa-user"></i> Franchisee</a></li>
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
						<li><a href="../Services.aspx">Services</a></li>	
                        <li><a href="../Register/FranchiseeRegister.aspx">Work with Us</a></li>					
						<li><a href="../Contact.aspx" >Contact</a></li>
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
		<!-- /script-for sticky-nav -->
<!--navgaton end here-->
<!--login start here-->
<div class="services">
	<div class="container">
		<div class="services-main">
			<div class="service-top"> 
				 <h2> Login to view your panel</h2> 
			</div>
			<div class="service-bottom"> 
                 <div class="col-md-3"></div>
			                	 <div class="col-md-6 services-right wow bounceInLeft" data-wow-delay="0.5s"> 
      
        <asp:TextBox ID="txtUsername" CssClass="login" placeholder="Franchisee E-Mail" runat="server" type="email" pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum|in|co.in)"  required></asp:TextBox>   
         
        <asp:TextBox ID="txtPassword" runat="server" CssClass="login" placeholder="Password" TextMode="Password" required></asp:TextBox>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="loginbtn" /> 
                 <a href="RetrievePassword.aspx">Forget Password?? Retrieve Here.</a>Or <a href="../Register/FranchiseeRegister.aspx" >Register Here.</a> <br />
			  <div class="clearfix"> </div>
			</div>
		 
		  		<div class="clearfix"> </div> 
	</div>
            </div>

</div>

</div>
<!--Login end here-->
<!--footer start here-->
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

