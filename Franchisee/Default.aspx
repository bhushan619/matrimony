<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Franchisee_Default"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!--Author: Anuvaa Softech Pvt. Ltd
Author URL: http://anuvaasoft.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE HTML>
<html>
<head>
<title>Swapnpurti Matrimony | Franchisee Home </title>   <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" /> <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
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
				<div class="logo">
					<a href="Default.aspx"><img src="../images/lo.png" alt=""></a>
				</div>
				<div class="head-right-member">
					<ul>
                        <li> <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Franchisee/Notifications.aspx" ToolTip="Notification" runat="server" CssClass="notiff"> </asp:HyperLink></li>
						<li> <asp:Image ID="imgFranchiseePhoto" runat="server" Width="60px" Height="60px" /> </li>
						<li> <asp:Label ID="lblFranchiseeName" runat="server" Text=""></asp:Label><br />
                            <asp:Label ID="lblFranchiseeId" runat="server" Text=""></asp:Label>                              
						</li>
                     <%--   <li><a href="Registration.aspx"><i class="fa fa-registered"></i> Register</a></li>--%>
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
					<ul> 
						<li><a href="RegisterMember.aspx">Add New Members</a></li>	 
                        <li>
                            <asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click">Logout</asp:LinkButton></li>
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
<div class="franchisee">
	<div class="container">		    
           <div class="row">
               <div class="col-lg-2 bhoechie-tab-menu">
               <div class="list-group"> 
                <a href="Default.aspx" class="list-group-item active">
                 <i class="fa fa-user"></i>  Profile
                </a>
                <a href="PaidMembers.aspx" class="list-group-item ">
               <i class="fa fa-check-square-o"></i> Paid Members
                </a>
                <a href="UnpaidMembers.aspx" class="list-group-item ">
                  <i class="fa fa-crosshairs"></i> UnPaid Members
                </a>
                     <a href="BankDetails.aspx" class="list-group-item ">
                  <i class="fa fa-bank" ></i> Bank Details
                </a>
                      <a href="UploadDocs.aspx" class="list-group-item ">
                  <i class="fa fa-file-text-o" ></i> Upload Documents
                </a>
                <a href="ChangePassword.aspx" class="list-group-item">
                 <i class="fa fa-key"></i>   Change Password
                </a>
                <a href="Notifications.aspx" class="list-group-item">
                <i class="fa fa-bell"></i>   Notifications
                </a>
              </div>
            </div>
        <div class="col-lg-10 bhoechie-tab-container">
            
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 bhoechie-tab">
                <!-- flight section -->
                <div class="bhoechie-tab-content active">
                     <div class="row">  
                          <div class="col-md-12"> 
                 <ul class="breadcrumb text-left">
    <li><a href="Default.aspx">Home</a></li>
  
</ul>
		 </div>  </div> 
                    <div class="row">   
			 <div class="col-lg-10">
                 <asp:ListView ID="lstFranchisee" runat="server" > 
                     <EmptyDataTemplate>
                         <span>No data was returned.</span>
                     </EmptyDataTemplate>
                      
                     <ItemTemplate>
                         <div class="row">
                             <div class="col-lg-4">
                                <asp:Image ID="vimgSimilarPic" runat="server"  Height="250px" Width="250px"  ImageUrl='<%# "~/Admin/media/" + Eval("varProfilePic") %>'  BorderStyle="Solid" BorderWidth="1px" BorderColor="#DFDFDF"  />  
                             </div>
                              <div class="col-lg-8">
                                    <dl class="dl-horizontal">
	<dt>Name</dt>
	<dd>: <asp:Label ID="varNameLabel" runat="server" Text='<%# Eval("varName") %>'  /> </dd>
                                        <dt>Address</dt>
	<dd>: <asp:Label ID="varAddressLabel" runat="server" Text='<%# Eval("varAddress") %>'  /> </dd>
                                        <dt>City</dt>
	<dd>: <asp:Label ID="varCityLabel" runat="server"  Text='<%# Eval("varCity") %>' /> </dd>
                                        <dt>State</dt>
	<dd>: <asp:Label ID="varStateLabel" runat="server" Text='<%# Eval("varState") %>' /> </dd>
                                        <dt>Country</dt>
	<dd>: <asp:Label ID="Label4" runat="server" Text='<%# Eval("varCountry") %>' /> </dd>
                                        <dt>PinCode</dt>
	<dd>: <asp:Label ID="Label5" runat="server" Text='<%# Eval("varPinCode") %>'  /> </dd>
                                        <dt>Email</dt>
	<dd>: <asp:Label ID="Label6" runat="server" Text='<%# Eval("varEmail") %>' /> </dd>
                                        <dt>Mobile</dt>
	<dd>: <asp:Label ID="Label7" runat="server"  Text='<%# Eval("varMobile") %>' /> </dd>
                                        <dt>Landline</dt>
	<dd>: <asp:Label ID="Label8" runat="server" Text='<%# Eval("varLandline") %>'  /> </dd>  
                             <a href="EditProfile.aspx" class="btn btn-danger" >Edit Profile</a>
                                    </div>
                         </div> 
 </span>
                     </ItemTemplate>
                     <LayoutTemplate>
                         <div id="itemPlaceholderContainer" runat="server" style="">
                             <span runat="server" id="itemPlaceholder" />
                         </div>
                         <div style="">
                         </div>
                     </LayoutTemplate>
                      
                 </asp:ListView>
                 
               
			 </div>
                    
                     </div> 
                </div> 
            </div>
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

