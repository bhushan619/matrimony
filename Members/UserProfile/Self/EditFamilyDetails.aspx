<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="EditFamilyDetails.aspx.cs" Inherits="members_UserProfile_Self_EditFamilyDetails" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony |  Family Details</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../../images/favicon.ico" type="image/x-icon" />
<link href="../../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="../../../js/jquery-1.11.0.min.js"></script>
<!-- Custom Theme files -->
<link href="../../../css/style.css" rel="stylesheet" type="text/css" media="all"/>
<!-- Custom Theme files -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); }>
</script>
<meta name="keywords" content="Matrimony Website, Maharashtra, India, Indian, Hindi, Marathi, Tamil, Telugu, Franchisee, Marriage" />
<!--Google Fonts-->
<!-- start-smoth-scrolling -->
<script type="text/javascript" src="../../../js/move-top.js"></script>
<script type="text/javascript" src="../../../js/easing.js"></script>
        <link href="../../../css/font-awesome.css" rel="stylesheet" /> 
     <script src="../../../js/bootstrap.js"></script>
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
		<link href="../../../css/animate.css" rel="stylesheet" type="text/css" media="all">
		<script src="../../../js/wow.min.js"></script>
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
					<a href="../../Activities/Home.aspx"><img src="../../../images/lo.png" alt=""/></a>  
				</div> 
                  <div class="logoutdiv">  
 <asp:LinkButton ID="lnkLogout" CssClass="logout" runat="server" OnClick="lnkLogout_Click" 
   ></asp:LinkButton>  
                </div>
                  <div class="notif">
                      <div class="icon-wrapper">
<a href="../../Activities/Notification.aspx"> <i class="fa fa-bell-o fa-2x iconcolor"></i>
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
                                <li  ><a href="../../Activities/VisitorsProfile.aspx">Who viewed my profile</a></li>
                                <li ><a href="../../Activities/ViewedProfile.aspx">Profiles I viewed</a></li> 
                                <li ><a href="../../Activities/ShortlistedProfile.aspx">Shortlisted profile</a></li>
                                 <li ><a href="../../Activities/WhoShortlistedMyProfile.aspx">Who Shortlisted me</a></li>
                                <li ><a href="../../Activities/InterestedInProfile.aspx">Interested In profile</a></li>                               
	                            <li ><a href="../../Activities/InterestInMeProfiles.aspx">Interested In Me</a></li>
	                            </ul>
						</li>	
                        	<li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Message&nbsp;<span class="badge"><asp:Label ID="lblcountfinalmsg" runat="server" Text="0"></asp:Label></span><b class="caret"></b></a>
                              <ul class="dropdown-menu">
                                <li ><a href="../../Message/Inbox.aspx">Recieved </a></li>                             
                                <li ><a href="../../Message/Send.aspx">Sent</a></li>   
                                  <li ><a href="../../Message/Request.aspx">Requests</a></li> 
                               <li ><a href="../../Activities/Notification.aspx">Notification</a></li> 
                        
	                            </ul>
                        	</li> 
                       <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >My Search<b class="caret"></b></a>
                               <ul class="dropdown-menu">
                                <li ><a href="../../SearchMatches/QuickSearch.aspx">Quick Search</a></li>
                                <li ><a href="../../SearchMatches/AdvancedSearch.aspx">Advanced Search</a></li> 
                                <li ><a href="../../SearchMatches/RecentlyViewedProfiles.aspx">Recently viewed profile</a></li>
                               
	                            </ul>
                        	</li> 
                         <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Profile<b class="caret"></b></a>
                               <ul class="dropdown-menu">
                                <li><a href="EditPersonalDetails.aspx"> Edit My Profile</a></li>
                                <li><a href="../Partner/EditPersonalDetails.aspx">Edit Partner Profile</a></li> 
                                    <li><a href="EditContactDetail.aspx">Edit Contact Details</a></li>   
                                    <li><a href="../../Photo/InfoUpload.aspx">Upload Photo/Biodata</a></li> 
                                    <li><a href="../../Setting/ChangePassword.aspx">Change Password</a></li> 
                                    <li><a href="../../Setting/DeleteProfile.aspx" >Delete Profile</a></li> 
	                            </ul> 
                        	</li> 
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Upgrade<b class="caret"></b></a>
                                 <ul class="dropdown-menu">
                                      <li ><a href="../../Subscription/ViewPackage.aspx">Payment Option</a></li>   <li ><a href="../../Subscription/ViewOrders.aspx">View Orders</a></li>                                                                                            
                               
	                            </ul>
                        	</li> 
                          <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Help<b class="caret"></b></a>
                                 <ul class="dropdown-menu">
                                <li ><a href="../../Activities/faq.aspx" >FAQ</a></li>                         
                                          
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
  <li class="active"><a href="EditPersonalDetails.aspx"> Edit My Profile</a></li>
  <li><a href="../Partner/EditPersonalDetails.aspx">Edit Partner Profile</a></li>
<li> <a href="../../Setting/ChangePassword.aspx">Settings</a></li>
</ul>
               </div>
          <div class="row">
                <div class="col-lg-3 bhoechie-tab-menu">
               <div class="list-group"> 
                <a href="EditPersonalDetails.aspx" class="list-group-item ">
                 <i class="fa fa-user"></i>  Personal Details
                </a>               
                <a href="EditPhysicalDetails.aspx" class="list-group-item ">
                <i class="fa fa-heart"></i>   Physical Details
                </a>
                    <a href="EditProfessionalDetails.aspx" class="list-group-item ">
                <i class="fa fa-briefcase"></i>  Professional Details
                </a>
                    <a href="EditReligiousDetails.aspx" class="list-group-item ">
                <i class="fa fa-arrows-alt"></i>   Religious Details
                </a> 
  <a href="EditLivingInDetails.aspx" class="list-group-item ">
                  <i class="fa fa-map-marker"></i> Living In Details
                </a>
 <a href="EditFamilyDetails.aspx" class="list-group-item active">
                  <i class="fa fa-crosshairs"></i> Family Details
                </a>
                                
                    <a href="EditLifeStyleDetails.aspx" class="list-group-item ">
                <i class="fa fa-glass"></i>   Lifestyle Details
                </a> 
 <a href="EditContactDetail.aspx" class="list-group-item ">
            <i class="fa fa-file-text"></i> Contact Details
                </a>
               
              </div>
            </div>
        <div class="col-lg-9 bhoechie-tab-container">
            
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 bhoechie-tab">
             
                <div class="bhoechie-tab-content active">
                     <div class="row">  
                          <div class="col-md-12"> 
                 <ul class="breadcrumb text-left">
    <li>Edit My Profile</li>
   <li><a href= "EditFamilyDetails.aspx">Edit Family Details</a></li>
</ul>
		 </div>  </div> 
                    <div class="row">
                      
                        <div class="col-lg-12 text-left"> 
               <div class="col-md-10" >
  
                   <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Family Status</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
                          <asp:RadioButton ID="rgbMiddleClass" runat="server" GroupName="rgbFStatus"   Text="Middle class" />
                         &nbsp;     <asp:RadioButton ID="rgbUppermiddle" runat="server" GroupName="rgbFStatus"   Text="Upper middle class" />
                           &nbsp;       <asp:RadioButton ID="rgbRich" runat="server" GroupName="rgbFStatus"  Text="Rich " />
                           &nbsp;     <asp:RadioButton ID="rgbAffluent" runat="server" GroupName="rgbFStatus"    Text="Affluent" />
                     </div>
                 </div>
                   
                    <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>Family type</span>
                          </div>
                             </div>
     <div class="col-md-8">
 
        <div class="form-group">     <asp:RadioButton ID="rgbJoint" runat="server" GroupName="rgbFType" 
            Text="Joint" />
        &nbsp;      <asp:RadioButton ID="rgbNuclear" runat="server" GroupName="rgbFType" 
            Text="Nuclear" />
       &nbsp;      <asp:RadioButton ID="rgbOther" runat="server" GroupName="rgbFType" 
            Text="Other" />
            </div>
         </div></div>
                   
                    <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>Family value</span>
                          </div>
                             </div>
     <div class="col-md-8">
       
        <asp:RadioButton ID="rgbOrthodox" runat="server" GroupName="rgbFValue" 
            Text=" Orthodox" />
        &nbsp;     <asp:RadioButton ID="rgbTraditional" runat="server" GroupName="rgbFValue" 
            Text="Traditional" />
        &nbsp;     <asp:RadioButton ID="rgbModerate" runat="server" GroupName="rgbFValue" 
            Text="Moderate" />
         &nbsp;     <asp:RadioButton ID="rgbLiberal" runat="server" GroupName="rgbFValue" 
            Text="Liberal" />
       </div>
                        </div>

                   
                    <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>Father Name</span>
                          </div>
                             </div>
     <div class="col-md-8">
              <div class="form-group">    <asp:TextBox ID="txtFatherName" runat="server"  CssClass="form-control"></asp:TextBox></div>
      
                   </div></div>
                    <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>Father occupation</span>
                          </div>
                             </div>
     <div class="col-md-8">
      <div class="form-group">     
            <asp:DropDownList CssClass="form-control" ID="ddlFatherOccupation" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select Occupation--</asp:ListItem>


<asp:ListItem disabled="true" style="color:#CC3300">--ADMIN--</asp:ListItem>
<asp:ListItem>Manager</asp:ListItem>
<asp:ListItem>Supervisor</asp:ListItem>
<asp:ListItem>Officer</asp:ListItem>
<asp:ListItem>Administrative Professional</asp:ListItem>
<asp:ListItem>Executive</asp:ListItem>
<asp:ListItem>Clerk</asp:ListItem>
<asp:ListItem>Human Resources Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AGRICULTURE--</asp:ListItem>
<asp:ListItem>Agriculture & Farming Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AIRLINE--</asp:ListItem>
<asp:ListItem>Pilot</asp:ListItem>
<asp:ListItem>Air Hostess</asp:ListItem>
<asp:ListItem>Airline Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--ARCHITECT&DESIGN--</asp:ListItem>
<asp:ListItem>Architect</asp:ListItem>
<asp:ListItem>Interior Designer</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--BANKING&FINANCE--</asp:ListItem>
<asp:ListItem>Chartered Accountant</asp:ListItem>
<asp:ListItem>Company Secretary</asp:ListItem>
<asp:ListItem>Accounts / FinanceProfessional</asp:ListItem>
<asp:ListItem>Banking Service Professional</asp:ListItem>
<asp:ListItem>Auditor</asp:ListItem>
<asp:ListItem>Financia lAccountant</asp:ListItem>
<asp:ListItem>Financial Analyst / Planning</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--BEAUTY&FASHION--</asp:ListItem>
<asp:ListItem>Fashion Designer</asp:ListItem>
<asp:ListItem>Beautician</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--CIVILSERVICES--</asp:ListItem>
<asp:ListItem>Civil Services (IAS/IPS/IRS/IES/IFS)</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--DEFENCE--</asp:ListItem>
<asp:ListItem>Army</asp:ListItem>
<asp:ListItem>Navy</asp:ListItem>
<asp:ListItem>Airforce</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--EDUCATION--</asp:ListItem>
<asp:ListItem>Professor / Lecturer</asp:ListItem>
<asp:ListItem>Teaching / Academician</asp:ListItem>
<asp:ListItem>Education Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--HOSPITALITY--</asp:ListItem>
<asp:ListItem>Hotel / Hospitality Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--IT&ENGINEERING--</asp:ListItem>
<asp:ListItem>Software Professional</asp:ListItem>
<asp:ListItem>Hardware Professional</asp:ListItem>
<asp:ListItem>Engineer -NonIT</asp:ListItem>
<asp:ListItem>Designer -IT&Engineering</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--LEGAL--</asp:ListItem>
<asp:ListItem>Lawyer & Legal Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--LAWENFORCEMENT--</asp:ListItem>
<asp:ListItem>Law Enforcement Officer</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--MEDICAL--</asp:ListItem>
<asp:ListItem>Doctor</asp:ListItem>
<asp:ListItem>Health Care Professional</asp:ListItem>
<asp:ListItem>Paramedical Professional</asp:ListItem>
<asp:ListItem>Nurse</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--MARKETING&SALES--</asp:ListItem>
<asp:ListItem>Marketing Professional</asp:ListItem>
<asp:ListItem>Sales Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--MEDIA&ENTERTAINMENT--</asp:ListItem>
<asp:ListItem>Journalist</asp:ListItem>
<asp:ListItem>Media Professional</asp:ListItem>
<asp:ListItem>Entertainment Professional</asp:ListItem>
<asp:ListItem>Event Management Professional</asp:ListItem>
<asp:ListItem>Advertising / PRProfessional Designer</asp:ListItem>
<asp:ListItem>Media & Entertainment</asp:ListItem>

<asp:ListItem>Mariner / MerchantNavy</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--SCIENTIST--</asp:ListItem>
<asp:ListItem>Scientist / Researcher</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--TOPMANAGEMENT--</asp:ListItem>
<asp:ListItem>CXO / President</asp:ListItem>
<asp:ListItem>Director</asp:ListItem>
<asp:ListItem>Chairman</asp:ListItem>
<asp:ListItem>Business Analyst</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--OTHERS--</asp:ListItem>
<asp:ListItem>Consultant</asp:ListItem>
<asp:ListItem>Customer Care Professional</asp:ListItem>
<asp:ListItem>Social Worker</asp:ListItem>
<asp:ListItem>Sportsman</asp:ListItem>
<asp:ListItem>Technician</asp:ListItem>
<asp:ListItem>Arts & Craftsman</asp:ListItem>
<asp:ListItem>Student</asp:ListItem>
<asp:ListItem>Librarian</asp:ListItem>
<asp:ListItem>Not Working</asp:ListItem>
                <asp:ListItem>Farmer</asp:ListItem>
<asp:ListItem>Retired</asp:ListItem>

        </asp:DropDownList>
    </div>  </div> </div>
    
                        
                    <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>Mother Name </span>
                          </div>
                             </div>
     <div class="col-md-8">
        <div class="form-group">     <asp:TextBox ID="txtMotherName" runat="server" CssClass="form-control"></asp:TextBox></div>
       </div>
                        </div>
                        
                    <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>Mother occupation</span>
                          </div>
                             </div>
     <div class="col-md-8">
       
      <div class="form-group">    <asp:DropDownList CssClass="form-control" ID="ddlMotherOccupation" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select Occupation--</asp:ListItem>

<asp:ListItem disabled="true" style="color:#CC3300">--ADMIN--</asp:ListItem>
<asp:ListItem>Manager</asp:ListItem>
<asp:ListItem>Supervisor</asp:ListItem>
<asp:ListItem>Officer</asp:ListItem>
<asp:ListItem>Administrative Professional</asp:ListItem>
<asp:ListItem>Executive</asp:ListItem>
<asp:ListItem>Clerk</asp:ListItem>
<asp:ListItem>Human Resources Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AGRICULTURE--</asp:ListItem>
<asp:ListItem>Agriculture & Farming Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AIRLINE--</asp:ListItem>
<asp:ListItem>Pilot</asp:ListItem>
<asp:ListItem>Air Hostess</asp:ListItem>
<asp:ListItem>Airline Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--ARCHITECT&DESIGN--</asp:ListItem>
<asp:ListItem>Architect</asp:ListItem>
<asp:ListItem>Interior Designer</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--BANKING&FINANCE--</asp:ListItem>
<asp:ListItem>Chartered Accountant</asp:ListItem>
<asp:ListItem>Company Secretary</asp:ListItem>
<asp:ListItem>Accounts / FinanceProfessional</asp:ListItem>
<asp:ListItem>Banking Service Professional</asp:ListItem>
<asp:ListItem>Auditor</asp:ListItem>
<asp:ListItem>Financia lAccountant</asp:ListItem>
<asp:ListItem>Financial Analyst / Planning</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--BEAUTY&FASHION--</asp:ListItem>
<asp:ListItem>Fashion Designer</asp:ListItem>
<asp:ListItem>Beautician</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--CIVILSERVICES--</asp:ListItem>
<asp:ListItem>Civil Services (IAS/IPS/IRS/IES/IFS)</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--DEFENCE--</asp:ListItem>
<asp:ListItem>Army</asp:ListItem>
<asp:ListItem>Navy</asp:ListItem>
<asp:ListItem>Airforce</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--EDUCATION--</asp:ListItem>
<asp:ListItem>Professor / Lecturer</asp:ListItem>
<asp:ListItem>Teaching / Academician</asp:ListItem>
<asp:ListItem>Education Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--HOSPITALITY--</asp:ListItem>
<asp:ListItem>Hotel / Hospitality Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--IT&ENGINEERING--</asp:ListItem>
<asp:ListItem>Software Professional</asp:ListItem>
<asp:ListItem>Hardware Professional</asp:ListItem>
<asp:ListItem>Engineer -NonIT</asp:ListItem>
<asp:ListItem>Designer -IT&Engineering</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--LEGAL--</asp:ListItem>
<asp:ListItem>Lawyer & Legal Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--LAWENFORCEMENT--</asp:ListItem>
<asp:ListItem>Law Enforcement Officer</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--MEDICAL--</asp:ListItem>
<asp:ListItem>Doctor</asp:ListItem>
<asp:ListItem>Health Care Professional</asp:ListItem>
<asp:ListItem>Paramedical Professional</asp:ListItem>
<asp:ListItem>Nurse</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--MARKETING&SALES--</asp:ListItem>
<asp:ListItem>Marketing Professional</asp:ListItem>
<asp:ListItem>Sales Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--MEDIA&ENTERTAINMENT--</asp:ListItem>
<asp:ListItem>Journalist</asp:ListItem>
<asp:ListItem>Media Professional</asp:ListItem>
<asp:ListItem>Entertainment Professional</asp:ListItem>
<asp:ListItem>Event Management Professional</asp:ListItem>
<asp:ListItem>Advertising / PRProfessional Designer</asp:ListItem>
<asp:ListItem>Media & Entertainment</asp:ListItem>

<asp:ListItem>Mariner / MerchantNavy</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--SCIENTIST--</asp:ListItem>
<asp:ListItem>Scientist / Researcher</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--TOPMANAGEMENT--</asp:ListItem>
<asp:ListItem>CXO / President</asp:ListItem>
<asp:ListItem>Director</asp:ListItem>
<asp:ListItem>Chairman</asp:ListItem>
<asp:ListItem>Business Analyst</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--OTHERS--</asp:ListItem>
<asp:ListItem>Consultant</asp:ListItem>
<asp:ListItem>Customer Care Professional</asp:ListItem>
<asp:ListItem>Social Worker</asp:ListItem>
<asp:ListItem>Sportsman</asp:ListItem>
<asp:ListItem>Technician</asp:ListItem>
<asp:ListItem>Arts & Craftsman</asp:ListItem>
<asp:ListItem>Student</asp:ListItem>
<asp:ListItem>Librarian</asp:ListItem>
<asp:ListItem>Not Working</asp:ListItem>
<asp:ListItem>Housewife</asp:ListItem>

        </asp:DropDownList>
       </div></div>
                        </div>
         
                                
                    <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>No.of brother</span>
                          </div>
                             </div>
     <div class="col-md-8">
                   
           <div class="form-group">    
      <asp:DropDownList ID="ddlBrother" runat="server" CssClass="form-control">
        <asp:ListItem>--Select--</asp:ListItem>
        <asp:ListItem>none</asp:ListItem>
          <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
              <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                  <asp:ListItem>5 & Above</asp:ListItem>               
        </asp:DropDownList>
               </div>
           </div>
                        </div>
     
                                
                    <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>Brother married</span>
                          </div>
                             </div>
     <div class="col-md-8">
                  <div class="form-group"> 

        <asp:DropDownList ID="ddlBrotherMarried" runat="server" CssClass="form-control">
          <asp:ListItem>--Select--</asp:ListItem>
        <asp:ListItem>none</asp:ListItem>
          <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
              <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                  <asp:ListItem>5 & Above</asp:ListItem>
        </asp:DropDownList>
   </div>
         </div></div>
                                
                    <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>No. of sister</span>
                          </div>
                             </div>
     <div class="col-md-8">       
         <div class="form-group">   
        <asp:DropDownList ID="ddlSister" runat="server" CssClass="form-control">
          <asp:ListItem>--Select--</asp:ListItem>
        <asp:ListItem>none</asp:ListItem>
          <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
              <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                  <asp:ListItem>5 & Above</asp:ListItem>
        </asp:DropDownList>
             </div>
         </div></div>
     
                                
                    <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>Sister married</span>
                          </div>
                             </div>
     <div class="col-md-8">
                        
  <div class="form-group">
        <asp:DropDownList ID="ddlSisterMarried" runat="server" CssClass="form-control">
          <asp:ListItem>--Select--</asp:ListItem>
        <asp:ListItem>none</asp:ListItem>
          <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
              <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                  <asp:ListItem>5 & Above</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div></div>
                           
                    <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>Do you live with parents?</span>
                          </div>
                             </div>
     <div class="col-md-8">
       
            <div class="form-group"> 
      
        <asp:RadioButton ID="rgbPYes" runat="server" GroupName="rgbParentsLiving" Text="Yes"/>
        <asp:RadioButton ID="rgbPNo" runat="server" GroupName="rgbParentsLiving" Text="No" />
      </div></div></div>
                        
                    <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span> About family</span>
                          </div>
                             </div>
     <div class="col-md-8">
  <div class="form-group">  <asp:TextBox ID="txtAboutFamily" runat="server" TextMode="MultiLine"  CssClass="form-control"></asp:TextBox>       </div>
         </div>
                        </div>
                      <div class="row"> 
 <div class="col-md-4">  
                     </div>
     <div class="col-md-8">
     <div class="form-group">     <asp:Button ID="btnFamilySave" runat="server" Text="Save"  CssClass="loginbtn"  onclick="btnFamilySave_Click" /></div>
</div> </div>

	</div>
                            </div></div></div></div></div></div>
        </div>
           </div></div>
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
