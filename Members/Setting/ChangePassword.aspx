﻿<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="members_Setting" %>

<!DOCTYPE html >

<html>
<head>
<title>Swapnpurti Matrimony | Change Password</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
<link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="../../js/jquery-1.11.0.min.js"></script>
<!-- Custom Theme files -->
<link href="../../css/style.css" rel="stylesheet" type="text/css" media="all"/>
<!-- Custom Theme files -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); }>
</script>
<meta name="keywords" content="Matrimony Website, Maharashtra, India, Indian, Hindi, Marathi, Tamil, Telugu, Franchisee, Marriage" />
<!--Google Fonts-->
<!-- start-smoth-scrolling -->
<script type="text/javascript" src="../../js/move-top.js"></script>
<script type="text/javascript" src="../../js/easing.js"></script>
        <link href="../../css/font-awesome.css" rel="stylesheet" /> 
     <script src="../../js/bootstrap.js"></script>
	<script type="text/javascript">
	    jQuery(document).ready(function ($) {
	        $(".scroll").click(function (event) {
	            event.preventDefault();
	            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
	        });
	    });
	</script>
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
<!-- //end-smoth-scrolling -->
<!-- animated-css -->
		<link href="../../css/animate.css" rel="stylesheet" type="text/css" media="all">
		<script src="../../js/wow.min.js"></script>
		<script>
		    new WOW().init();
		</script>
<!-- animated-css --> 
</head>
<body>
    <form id="form1" runat="server">
        <div class="bann-two">
	 <div class="header">
			<div class="container">
		      <div class="header-main">
				<div class="logo">
					<a href="../Activities/Home.aspx"><img src="../../images/lo.png" alt=""/></a>  
				</div> 
                  <div class="logoutdiv">  
 <asp:LinkButton ID="lnkLogout" CssClass="logout" runat="server" OnClick="lnkLogout_Click" 
   ></asp:LinkButton>  
                </div>
                  <div class="notif">
                      <div class="icon-wrapper">
<a href="../Activities/Notification.aspx"> <i class="fa fa-bell-o fa-2x iconcolor"></i>
      <asp:Label ID="lnkNotifications" CssClass="badges"  ToolTip="Notification" runat="server"> </asp:Label> </a>
    </div></div>
                 
				<div class="head-right-member">
					<ul> 
                        <li> 
                            <asp:Image ID="imgMemberPhoto"  runat="server"  Height="60px" Width="60px"/> 
                        </li> 
                           <li>  
                                 <asp:HyperLink ID="lblMemberName" runat="server" Text=""  NavigateUrl="~/Members/SearchMatches/Default.aspx"></asp:HyperLink>&nbsp;&nbsp;(<asp:Label ID="lblMemberId" runat="server" Text="" Font-Size="Smaller"></asp:Label>)<br />
                              <asp:Label ID="dddd" ForeColor="GrayText"  Text="Account Type:" Font-Size="Smaller" runat="server"></asp:Label> <asp:HyperLink Text="Free Upgrade Now" Font-Size="Smaller"   runat="server" ID="lnkUpgrade" NavigateUrl="~/members/Subscription/ViewPackage.aspx"></asp:HyperLink>
                              <asp:Label ID="lblmemUpgrade" runat="server"  ></asp:Label>  
                   </li>  
                          <li>   <div class="progress-bar bigfont"  runat="server" id="lblcomplet" data-duration="1000" data-color="#FF7E5E,#d65679  "></div>
 
	 
	<script>
	    $(".progress-bar").loading();

	</script>   </li> 
                  </ul>
                    
				</div>  
				</div>
                <br />
			  <div class="clearfix"> </div>
			</div>  
		</div>
	</div> 

         <div class="navgation"> 
                    <nav class="navbar navbar-default navbar-right" role="navigation">
   <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" 
         data-target="#example-navbar-collapse">
         <span class="sr-only">Toggle navigation</span>
         <span class="icon-bar"></span>
         <span class="icon-bar"></span>
         <span class="icon-bar"></span>
      </button> 
   </div>
   <div class="collapse navbar-collapse" id="example-navbar-collapse">
      <ul class="nav navbar-nav">
         <li class="dropdown"> <a class="dropdown-toggle" data-toggle="dropdown"  href="#">Activity
                            <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li  ><a href="../Activities/Home.aspx">Who viewed my profile</a></li>
                                <li ><a href="../Activities/ViewedProfile.aspx">Profiles I viewed</a></li> 
                                <li ><a href="../Activities/ShortlistedProfile.aspx">Shortlisted profile</a></li>
                                 <li ><a href="../Activities/WhoShortlistedMyProfile.aspx">Who Shortlisted me</a></li>
                                <li ><a href="../Activities/InterestedInProfile.aspx">Interested In profile</a></li>                               
	                            <li ><a href="../Activities/InterestInMeProfiles.aspx">Interested In Me</a></li>
	                            </ul>
						</li>	
                        	<li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Message&nbsp;<span class="badge"><asp:Label ID="lblcountfinalmsg" runat="server" Text="0"></asp:Label></span><b class="caret"></b></a>
                              <ul class="dropdown-menu">
                                <li ><a href="../Message/Inbox.aspx">Recieved </a></li>                             
                                <li ><a href="../Message/Send.aspx">Sent</a></li>   
                                  <li ><a href="../Message/Request.aspx">Requests</a></li> 
                                <li ><a href="../Message/Notification.aspx">Notification</a></li>
                        
	                            </ul>
                        	</li> 
                       <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >My Search<b class="caret"></b></a>
                               <ul class="dropdown-menu">
                                <li ><a href="../SearchMatches/QuickSearch.aspx">Quick Search</a></li>
                                <li ><a href="../SearchMatches/AdvancedSearch.aspx">Advanced Search</a></li> 
                                <li ><a href="../SearchMatches/RecentlyViewedProfiles.aspx">Recently viewed profile</a></li>
                               
	                            </ul>
                        	</li> 
                         <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Profile<b class="caret"></b></a>
                               <ul class="dropdown-menu">
                                <li><a href="../UserProfile/Self/EditPersonalDetails.aspx"> Edit My Profile</a></li>
                                <li><a href="../UserProfile/Partner/EditPersonalDetails.aspx">Edit Partner Profile</a></li> 
                                    <li><a href="../UserProfile/Self/EditContactDetail.aspx">Edit Contact Details</a></li>   
                                    <li><a href="../Photo/InfoUpload.aspx">Upload Photo/Biodata</a></li> 
                                    <li><a href="ChangePassword.aspx">Change Password</a></li> 
                                    <li><a href="DeleteProfile.aspx" >Delete Profile</a></li> 
	                            </ul> 
                        	</li> 
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Upgrade<b class="caret"></b></a>
                                 <ul class="dropdown-menu">
                                   <li ><a href="../Subscription/ViewPackage.aspx">Payment Option</a></li>    <li ><a href="../Subscription/ViewOrders.aspx">View Orders</a></li>                                              
                               
	                            </ul>
                        	</li> 
                          <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Help<b class="caret"></b></a>
                                 <ul class="dropdown-menu">
                                <li ><a href="../Activities/faq.aspx" >FAQ</a></li>                         
                                          
	                            </ul>
                        	</li> 
      </ul>
   </div>
</nav><div class="clearfix"> </div>

         </div>
              <div class="container">
           <div class="franchisee">
	<div class="container">	
        <div class="row">
      
               <ul class="nav nav-tabs">
  <li ><a href="../UserProfile/Self/EditPersonalDetails.aspx"> Edit My Profile</a></li>
  <li><a href="../UserProfile/Partner/EditPersonalDetails.aspx">Edit Partner Profile</a></li>
  <li class="active"> <a href="ChangePassword.aspx">Settings</a></li>
</ul>
               </div>
          <div class="row">
               <div class="col-lg-3 bhoechie-tab-menu">
               <div class="list-group"> 
                <a href="ChangePassword.aspx" class="list-group-item active">
                 <i class="fa fa-user"></i>  Change Password
                </a>
                <a href="DeleteProfile.aspx" class="list-group-item ">
               <i class="fa fa-check-square-o"></i> Delete Profile
                </a>
               
              </div>
            </div>
        <div class="col-lg-9 bhoechie-tab-container">
            
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 bhoechie-tab">
             
                <div class="bhoechie-tab-content active">
                     <div class="row">  
                          <div class="col-md-12"> 
                 <ul class="breadcrumb text-left">
    <li>Setting</li>
   <li><a href= "ChangePassword.aspx">Change Password</a></li>
</ul>
		 </div>  </div> 
                    <div class="row">
                      
                        <div class="col-lg-12 text-left"> 
               <div class="col-md-10" >     
            
                    <div class="col-lg-10">  
                           <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Change Password</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

			 <div class="form-group"> 
                           <asp:TextBox ID="txtOld" runat="server" required="required" placeholder="Old Password" CssClass="form-control" TextMode="Password"></asp:TextBox>
                       </div></div></div>
                        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Enter New Password</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

 <div class="form-group">
                <asp:TextBox ID="txtNew" runat="server" required="required" placeholder="New Password" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                          </div></div>
                        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Confirm Password</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

                        <div class="form-group">
                <asp:TextBox ID="txtNewCon" CssClass="form-control" runat="server" required="required" placeholder="Confirm Password"   TextMode="Password"></asp:TextBox>
                   </div></div></div>
                        <div class="row"> 
                         <div class="col-md-4"> 
                              
                             </div> 
                      <div class="col-md-8">

                        <div class="form-group">
                       <asp:Button ID="btnSubmit"  runat="server" Text="Change Password"  CssClass="loginbtn" OnClick="btnSubmit_Click" /> 
                      </div></div>  </div> 
                  </div>
                    </div>
               </div></div></div></div></div></div></div></div></div>
                  <div class="footer">
	<div class="container">
		
		<div class="copyright">
			 <p>© 2015 Swapnpurti Matrimony All rights reserved by Swapnpurti Matrimony | Design by  <a href="http://anuvaasoft.com/" target="_blank">  Anuvaa Softech Pvt. Ltd </a></p>
		</div>
	</div>
</div> 
 </form>
</body>
</html>
