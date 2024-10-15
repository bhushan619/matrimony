<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="ViewMemberProfile.aspx.cs" Inherits="Franchisee_ViewMemberProfile"  %>

<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!--Author: Anuvaa Softech Pvt. Ltd
Author URL: http://anuvaasoft.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->

<html>
<head>
<title>Swapnpurti Matrimony | View Member Profile </title>   <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" /> <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" /> <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
    
    <style type="text/css"> 
a.morelink {
	text-decoration:none;
	outline: none;
}
.morecontent span {
	display: none; 
}
</style>
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
                <a href="Default.aspx" class="list-group-item">
                 <i class="fa fa-user"></i>  Profile
                </a>
                <a href="PaidMembers.aspx" class="list-group-item">
               <i class="fa fa-check-square-o"></i> Paid Members
                </a>
                <a href="UnpaidMembers.aspx" class="list-group-item">
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
                          <div class="col-md-11"> 
                 <ul class="breadcrumb text-left">
    <li><a href="Default.aspx">Home</a></li>
                     <li>Members</li>
    <li><a href="ViewMemberProfile.aspx">View Member Profile</a></li>  
</ul>	 </div>   
                        <div class="col-lg-1 text-right" style="margin-top:3px">
                            <asp:HyperLink runat="server" ID="hypLinkBack" CssClass="loginbtn "  >Back</asp:HyperLink>
                        </div>
                        
                    <div class="row">    
                     <div class="col-lg-12"> 
            <div class="col-lg-5">  
          <div class="form-group">
               <asp:Label ID="lblFullName" runat="server"  Font-Bold="True" Font-Size="Large" />  (<asp:Label ID="lblFullId" runat="server" Font-Size="Small"/>)
                <asp:Label ID="lblPackageName" runat="server" Font-Bold="True"></asp:Label>   <br />            
         
            <asp:Label ID="Label2" runat="server" Text="Profile Created For" Font-Size="Small"></asp:Label> 
                 <asp:Label ID="lblFullMembership" runat="server" Font-Size="Small" />
           </div>
    
       </div>
                    </div>
          </div>
                         <div class="row">    
                               <div class="col-lg-12"> 
            <div class="col-lg-3">  
            <asp:Image ID="imgmember" runat="server" Width="150px"   Height="170px"   />
               
           </div>
            <div  class="col-lg-6">
                <dl class="dl-horizontal">
	<dt>Age</dt>
	<dd>: <asp:Label ID="lblfullage" runat="server" /></ dd>
<dt> Height </dt>
                    <dd>: <asp:Label ID="lblFullHeight" runat="server" />  </dd>
    <dt>Religion</dt>
	<dd>: <asp:Label ID="lblfullReligion" runat="server" /></dd>
                    <dt>Caste</dt>
	<dd>: <asp:Label ID="lblfullcaste" runat="server" /></dd>
                    <dt>Subcaste</dt>
	<dd>: <asp:Label ID="lblFullSubcaste" runat="server" /></dd>
                    <dt>Location</dt>
	<dd>: <asp:Label ID="lblFullstate" runat="server" />, <asp:Label ID="lblFullcity" runat="server" /></dd>
                    <dt>Education</dt>
	<dd>: <asp:Label ID="lblFullEducation" runat="server" /></dd>
                    <dt>Occupation</dt>
	<dd>: <asp:Label ID="lblfullProfession" runat="server" /></dd>
                    <dt>Annual Income</dt>
	<dd>: <asp:Label ID="lblFullanualincome" runat="server" /></dd>
                    
</dl>
               
          
    </div>
                               
             </div>  
                             </div>
                         <div class="row">    
                <div class="col-lg-12"> 
                     <div class="form-group">
         <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="About myself"  ></asp:Label>
        : <asp:Label ID="lblMyself" runat="server" CssClass="label-font-size comment more"></asp:Label>
     </div>           
              </div> </div>
                         <div class="row">    
                      <div class="col-lg-12">
             
                   <h4><i class="fa fa-arrows-alt"></i>Basic Details</h4>
                     <div class="col-lg-1">
                         <i class="fa fa-user fa-3x iconcolor"></i>
                     </div>
                    <div class="col-lg-5">
                          <dl class="dl-horizontal">
	                        <dt>Date Of Birth</dt>
	                        <dd>:  <asp:Label ID="lblDOB" runat="server"></asp:Label></dd>
                            <dt>Marital Status</dt>
	                        <dd>:  <asp:Label ID="lblMaritalStatus" runat="server"></asp:Label></dd>
                            <dt>Profile For</dt>
	                        <dd>:  <asp:Label ID="lblCreatedfor" runat="server"></asp:Label></dd>
                             <div id="MStatusz" runat="server">
                                   <dt>No. of children</dt>
	                        <dd>:  <asp:Label ID="lblNoOfChild" runat="server"></asp:Label></dd>
                                                      <dt>Children status</dt>
	                        <dd>:  <asp:Label ID="lblChildrnStatus" runat="server"></asp:Label></dd>
                              </div>
                         </dl> 
                    </div> 
              </div>  
                              </div>
                         <div class="row">    
        <div class="col-lg-12">
              <h4><i class="fa fa-arrows-alt"></i>Religious Information</h4>
                   <div class="col-lg-1">
                         <i class="fa fa-recycle fa-3x iconcolor"></i>
                     </div>
                    <div class="col-lg-5">
           <dl class="dl-horizontal">
	                        <dt>Religion</dt>
	                        <dd>:  <asp:Label ID="lblReligion" runat="server"></asp:Label></dd>
                <dt>Caste/Division</dt>
	                        <dd>:  <asp:Label ID="lblCaste" runat="server"></asp:Label></dd>
                <dt>Sub Caste</dt>
	                        <dd>:  <asp:Label ID="lblSubcaste" runat="server"></asp:Label></dd>
                </dl>
                        </div> 
            
             <div class="col-lg-5">
                <dl class="dl-horizontal">
	                <dt>Mother Tongue</dt>
	                <dd>:  <asp:Label ID="lblMotherTounge" runat="server"></asp:Label></dd>
                      <dt>Gotra/Gothram</dt>
	                        <dd>:  <asp:Label ID="lblGotra" runat="server"></asp:Label></dd>
                      <dt>Manglik</dt>
	                        <dd>:  <asp:Label ID="lblMangalik" runat="server"></asp:Label></dd>
                    </dl> 
                 </div> 
        </div>
 </div>
                         <div class="row">    
    
        <div class="col-lg-12"> <br />
           <h4><i class="fa fa-arrows-alt"></i>Physical Appearance</h4>
        <div class="col-lg-1">
            <img src="../images/physical.jpg" height="60" width="60" />
                     </div>
            <div class="col-lg-5">
                  <dl class="dl-horizontal">
	                <dt>Height</dt>
	                <dd>:  <asp:Label ID="lblHeight" runat="server"></asp:Label></dd>
                      <dt>Weight</dt>
	                <dd>:  <asp:Label ID="lblWeight" runat="server"></asp:Label></dd>
                      <dt>Bloodgroup</dt>
	                <dd>:  <asp:Label ID="lblBloodGrp" runat="server"></asp:Label></dd>
                    </dl>    
            </div>
            <div class="col-lg-5">
               <dl class="dl-horizontal">
	                            <dt>Body Type</dt>
	                            <dd>:  <asp:Label ID="lblBodyType" runat="server"></asp:Label></dd>
                                 <dt>Complexion</dt>
	                            <dd>:  <asp:Label ID="lblComplexion" runat="server"></asp:Label></dd>
                      <dt>Special Case</dt>
	                            <dd>:  <asp:Label ID="lblSpecialCase" runat="server"></asp:Label></dd>
                   </dl> 
            </div>
             
        </div>
       </div>
                         <div class="row">    
        <div class="col-lg-12">
          <h4><i class="fa fa-arrows-alt"></i>Professional Information</h4>
           
              <div class="col-lg-1">
                  <img src="../images/proffessional.jpg"  height="60" width="60" />
                     </div>
              <div class="col-lg-5">
                <dl class="dl-horizontal"> 
                     <dt> Qualification</dt>
	                            <dd>:  <asp:Label ID="lblHighQualific" runat="server"></asp:Label></dd>
                     <dt>Addn. Degree</dt>
	                            <dd>:  <asp:Label ID="lblAddDegree" runat="server"></asp:Label></dd>
                     <dt>Employee In</dt>
	                            <dd>:  <asp:Label ID="lblEmpIn" runat="server"></asp:Label></dd> 
                    </dl>
            </div>
             <div class="col-lg-5">
               <dl class="dl-horizontal">
	                           
                     <dt>Occupation</dt>
	                            <dd>:  <asp:Label ID="lblOccupation" runat="server"></asp:Label></dd>
                    <dt>Annual Income</dt>
	                            <dd>:  <asp:Label ID="lblAnnualIncome" runat="server"></asp:Label></dd>
        </dl>
            </div> 
        </div>
                              </div>
                         <div class="row">    
   <div class="col-lg-12">
       <h4><i class="fa fa-arrows-alt"></i>Living In</h4>
        <div class="col-lg-1">
                         <i class="fa fa-globe fa-3x iconcolor"></i>
                     </div>
              <div class="col-lg-5">
                   <dl class="dl-horizontal">
	                           
                     <dt>Country</dt>
	                            <dd>:  <asp:Label ID="lblCountry" runat="server"></asp:Label></dd>
         <dt>Citizenship</dt>
	                            <dd>:  <asp:Label ID="lblCitizenship" runat="server"></asp:Label></dd>
                         <dt>State</dt>
	                            <dd>:  <asp:Label ID="lblState" runat="server"></asp:Label></dd> 
                         <dt>City</dt>
	                            <dd>:  <asp:Label ID="lblCity" runat="server"></asp:Label></dd>
                  </dl>
            </div> 
        </div>
            </div>
                         <div class="row">    
                                     <div class="col-lg-12">
                       <h4><i class="fa fa-arrows-alt"></i>Family Information</h4>
                   <div class="col-lg-1">
                         <i class="fa fa-users fa-3x iconcolor"></i>
                     </div>
                             <div class="col-lg-5">  
                            <dl class="dl-horizontal">
	                           
                     <dt>Family status</dt>
	                            <dd>:  <asp:Label ID="lblFamStatus" runat="server"></asp:Label></dd>
                            <dt>Family type</dt>
	                            <dd>:  <asp:Label ID="lblFamType" runat="server"></asp:Label></dd>
                            <dt>Family value</dt>
	                            <dd>:  <asp:Label ID="lblFamValue" runat="server"></asp:Label></dd>
                            </dl>
            </div></div>
                 </div>
                         <div class="row">    
                 <div class="col-lg-12">
                      <h4><i class="fa fa-arrows-alt"></i>About your lifestyle</h4>
       <div class="col-lg-1">
                         <i class="fa fa-building-o fa-3x iconcolor"></i>
                     </div>
                       <div class="col-lg-5">
                        
                             <dl class="dl-horizontal"> 
                     <dt>Eating habits</dt>
	                            <dd>:  <asp:Label ID="lblEatingHabits" runat="server"></asp:Label></dd>   
                     <dt>Smoke</dt>
	                            <dd>:  <asp:Label ID="lblSmoke" runat="server"></asp:Label></dd> 
                     <dt>Drink</dt>
	                            <dd>:  <asp:Label ID="lblDrink" runat="server"></asp:Label></dd>                                 
                     </dl>
            </div> 

			  <div class="clearfix"> </div>
			</div> 
                   </div>  </div> 
                </div> 
            </div>
        </div> 
		</div>

	</div>     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
    <script>
        $(document).ready(function () {
            var showChar = 270;
            var ellipsestext = "";
            var moretext = "more";
            var lesstext = "less";
            $('.more').each(function () {
                var content = $(this).html();

                if (content.length > showChar) {

                    var c = content.substr(0, showChar);
                    var h = content.substr(showChar - 1, content.length - showChar);

                    var html = c + '<span class="moreelipses">' + ellipsestext + '</span><span class="morecontent"><span>' + h + '</span><a href="" class="morelink">' + moretext + '</a></span>';

                    $(this).html(html);
                }

            });

            $(".morelink").click(function () {
                if ($(this).hasClass("less")) {
                    $(this).removeClass("less");
                    $(this).html(moretext);
                } else {
                    $(this).addClass("less");
                    $(this).html(lesstext);
                }
                $(this).parent().prev().toggle();
                $(this).prev().toggle();
                return false;
            });
        });
</script>
</body>
</html>
