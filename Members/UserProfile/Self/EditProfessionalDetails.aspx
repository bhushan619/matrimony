<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="EditProfessionalDetails.aspx.cs" Inherits="members_UserProfile_Self_EditProfessionalDetails" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony | Professional Details</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../../images/favicon.ico" type="image/x-icon" />
<link href="../../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all"/>
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
                    <a href="EditProfessionalDetails.aspx" class="list-group-item active">
                <i class="fa fa-briefcase"></i>  Professional Details
                </a>
                    <a href="EditReligiousDetails.aspx" class="list-group-item ">
                <i class="fa fa-arrows-alt"></i>   Religious Details
                </a> 
  <a href="EditLivingInDetails.aspx" class="list-group-item ">
                  <i class="fa fa-map-marker"></i> Living In Details
                </a>
 <a href="EditFamilyDetails.aspx" class="list-group-item ">
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
   <li><a href= "EditProfessionalDetails.aspx">Edit Professional Details</a></li>
</ul>
		 </div>  </div> 
                    <div class="row">
                      
                        <div class="col-lg-12 text-left"> 
               <div class="col-md-10" >
                   <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Highest qualification</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group">  
             	<asp:DropDownList CssClass="form-control" ID="ddlQualification" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select Highest qualification--</asp:ListItem>
        <asp:ListItem disabled="true" style="color:#CC3300">--Any Bachelors in Engineering/Computers--</asp:ListItem>
<asp:ListItem>Aeronautical Engineering</asp:ListItem>
<asp:ListItem>B.Arch</asp:ListItem>
<asp:ListItem>BCA</asp:ListItem>
<asp:ListItem>BE</asp:ListItem>
<asp:ListItem>B.Plan</asp:ListItem>
<asp:ListItem>B.Sc IT/ Computer Science</asp:ListItem>
<asp:ListItem>B.Tech.</asp:ListItem>
<asp:ListItem>Other Bachelor Degree in Engineering / Computers</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--Any Masters in Engineering/Computers--</asp:ListItem>
<asp:ListItem>M.Arch.</asp:ListItem>
<asp:ListItem>MCA</asp:ListItem>
<asp:ListItem>ME</asp:ListItem>
<asp:ListItem>M.Sc. IT/Computer Science</asp:ListItem>
<asp:ListItem>M.S.(Engg.)</asp:ListItem>
<asp:ListItem>M.Tech.</asp:ListItem>
<asp:ListItem>PGDCA</asp:ListItem>
<asp:ListItem>Other Masters Degree in Engineering / Computers</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--Any Bachelors in Arts/Science/Commerce--</asp:ListItem>
<asp:ListItem>Aviation Degree</asp:ListItem>
<asp:ListItem>B.A.</asp:ListItem>
<asp:ListItem>B.Com.</asp:ListItem>
<asp:ListItem>B.Ed.</asp:ListItem>
<asp:ListItem>BFA</asp:ListItem>
<asp:ListItem>BFT</asp:ListItem>
<asp:ListItem>BLIS</asp:ListItem>
<asp:ListItem>B.M.M.</asp:ListItem>
<asp:ListItem>B.Sc.</asp:ListItem>
<asp:ListItem>B.S.W</asp:ListItem>
<asp:ListItem>B.Phil.</asp:ListItem>
<asp:ListItem>Other Bachelor Degree in Arts / Science / Commerce</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyMastersinArts/Science/Commerce--</asp:ListItem>
<asp:ListItem>M.A.</asp:ListItem>
<asp:ListItem>MCom</asp:ListItem>
<asp:ListItem>M.Ed.</asp:ListItem>
<asp:ListItem>MFA</asp:ListItem>
<asp:ListItem>MLIS</asp:ListItem>
<asp:ListItem>M.Sc.</asp:ListItem>
<asp:ListItem>MSW</asp:ListItem>
<asp:ListItem>M.Phil.</asp:ListItem>
<asp:ListItem>Other Master Degree in Arts / Science / Commerce</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyBachelorsinManagement--</asp:ListItem>
<asp:ListItem>BBA</asp:ListItem>
<asp:ListItem>BFM (Financial Management)</asp:ListItem>
<asp:ListItem>BHM (Hotel Management)</asp:ListItem>
<asp:ListItem>Other Bachelor Degree in Management</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyMastersinManagement--</asp:ListItem>
<asp:ListItem>MBA</asp:ListItem>
<asp:ListItem>MFM (Financial Management)</asp:ListItem>
<asp:ListItem>MHM (Hotel Management)</asp:ListItem>
<asp:ListItem>MHRM (Human Resource Management)</asp:ListItem>
<asp:ListItem>PGDM</asp:ListItem>
<asp:ListItem>Other Master Degree in Management</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyBachelorsinMedicineinGeneral/Dental/Surgeon--</asp:ListItem>
<asp:ListItem>B.A.M.S.</asp:ListItem>
<asp:ListItem>BDS</asp:ListItem>
<asp:ListItem>BHMS</asp:ListItem>
<asp:ListItem>BSMS</asp:ListItem>
<asp:ListItem>BPharm</asp:ListItem>
<asp:ListItem>BPT</asp:ListItem>
<asp:ListItem>BUMS</asp:ListItem>
<asp:ListItem>BVSc</asp:ListItem>
<asp:ListItem>MBBS</asp:ListItem>
<asp:ListItem>B.Sc.Nursing</asp:ListItem>
<asp:ListItem>Other Bachelor Degree in Medicine</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyMastersinMedicine-General/Dental/Surgeon--</asp:ListItem>
<asp:ListItem>MDS</asp:ListItem>
<asp:ListItem>MD/MS (Medical)</asp:ListItem>
<asp:ListItem>M.Pharm</asp:ListItem>
<asp:ListItem>MPT</asp:ListItem>
<asp:ListItem>MVSc</asp:ListItem>
<asp:ListItem>Other Master Degree in Medicine</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyBachelorsinLegal--</asp:ListItem>
<asp:ListItem>BGL</asp:ListItem>
<asp:ListItem>B.L.</asp:ListItem>
<asp:ListItem>LL.B.</asp:ListItem>
<asp:ListItem>Other Bachelor Degree in Legal</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyMastersinLegal--</asp:ListItem>
<asp:ListItem>LL.M.</asp:ListItem>
<asp:ListItem>M.L.</asp:ListItem>
<asp:ListItem>Other Master Degree in Legal</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyFinancialQualification-ICWAI/CA/CS/CFA--</asp:ListItem>
<asp:ListItem>CA</asp:ListItem>
<asp:ListItem>CFA (Chartered Financial Analyst)</asp:ListItem>
<asp:ListItem>CS</asp:ListItem>
<asp:ListItem>ICWA</asp:ListItem>
<asp:ListItem>Other Degree in Finance</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--Service-IAS/IPS/IRS/IES/IFS--</asp:ListItem>
<asp:ListItem>IAS</asp:ListItem>
<asp:ListItem>IES</asp:ListItem>
<asp:ListItem>IFS</asp:ListItem>
<asp:ListItem>IRS</asp:ListItem>
<asp:ListItem>IPS</asp:ListItem>
<asp:ListItem>Other Degree in Service</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--Ph.D.--</asp:ListItem>
<asp:ListItem>Ph.D.</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyDiploma--</asp:ListItem>
<asp:ListItem>Diploma</asp:ListItem>
<asp:ListItem>Polytechnic</asp:ListItem>
<asp:ListItem>TradeSchool</asp:ListItem>
<asp:ListItem>Others in Diploma</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--HigherSecondary/Secondary--</asp:ListItem>
<asp:ListItem>Higher Secondary School</asp:ListItem>
<asp:ListItem>High School</asp:ListItem>
<asp:ListItem>Not Educated</asp:ListItem>


        </asp:DropDownList>
                 </div></div></div>
      
                    <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>College / Institution</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group">        
        <asp:TextBox ID="txtCollege" runat="server" CssClass="form-control"></asp:TextBox>
       </div></div></div>

                     <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Additional Degree</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group">

        <asp:TextBox ID="txtAdditional" runat="server" CssClass="form-control"></asp:TextBox>
</div></div></div>
        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Education in Detail</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group">
           
        <asp:TextBox ID="txtEducationDetails" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
</div></div></div>
         <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Employee In</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group">

        <asp:DropDownList ID="ddlEmployeeIn" runat="server"  CssClass="form-control">
        <asp:ListItem>--Select Employee In--</asp:ListItem>
        <asp:ListItem>Central Government</asp:ListItem>
        <asp:ListItem>State Government</asp:ListItem>
        <asp:ListItem>Private Sector</asp:ListItem>
        <asp:ListItem>Public Sector</asp:ListItem>
        <asp:ListItem>Self Employed</asp:ListItem>
        <asp:ListItem>Not Working</asp:ListItem>
        <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>
       </div></div></div>
         <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Occupation</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group">
<asp:DropDownList CssClass="form-control" ID="ddlOccupation" runat="server" required="required" AppendDataBoundItems="true">
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

        </asp:DropDownList>
        
    </div></div></div>
                   <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Occupation in Detail</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group">

        <asp:TextBox ID="txtOccupation" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
      </div></div></div>
                   <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Annual Income</span></div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group">
    <div class="row"> 
    <div class="col-md-4">  
        <asp:TextBox ID="txtAnnualIncome" runat="server" CssClass="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
        </div>                    
            
    <div class="col-md-8">    

        <asp:DropDownList ID="ddlCurrency" runat="server" required="required" AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem Value="">--Select Currency--</asp:ListItem>
     
<asp:ListItem>AED - Emirati Dirham</asp:ListItem>
<asp:ListItem>ARS - Argentine Peso</asp:ListItem>
<asp:ListItem>AUD - Australian Dollar</asp:ListItem>
<asp:ListItem>BGN - Bulgarian Lev</asp:ListItem>
<asp:ListItem>BHD - Bahraini Dinar</asp:ListItem>
<asp:ListItem>BND - Bruneian Dollar</asp:ListItem>
<asp:ListItem>BRL - Brazilian Real</asp:ListItem>
<asp:ListItem>BWP - Botswana Pula</asp:ListItem>
<asp:ListItem>CAD - Canadian Dollar</asp:ListItem>
<asp:ListItem>CHF - Swiss Franc</asp:ListItem>
<asp:ListItem>CLP - Chilean Peso</asp:ListItem>
<asp:ListItem>CNY - Chinese Yuan Renminbi</asp:ListItem>
<asp:ListItem>COP - Colombian Peso</asp:ListItem>
<asp:ListItem>CZK - Czech Koruna</asp:ListItem>
<asp:ListItem>DKK - Danish Krone</asp:ListItem>
<asp:ListItem>EUR - Euro</asp:ListItem>
<asp:ListItem>GBP - British Pound</asp:ListItem>
<asp:ListItem>HKD - Hong Kong Dollar</asp:ListItem>
<asp:ListItem>HRK - Croatian Kuna</asp:ListItem>
<asp:ListItem>HUF - Hungarian Forint</asp:ListItem>
<asp:ListItem>IDR - Indonesian Rupiah</asp:ListItem>
<asp:ListItem>ILS - Israeli Shekel</asp:ListItem>
<asp:ListItem>INR - Indian Rupee</asp:ListItem>
<asp:ListItem>IRR - Iranian Rial</asp:ListItem>
<asp:ListItem>ISK - Icelandic Krona</asp:ListItem>
<asp:ListItem>JPY - Japanese Yen</asp:ListItem>
<asp:ListItem>KRW - South Korean Won</asp:ListItem>
<asp:ListItem>KWD - Kuwaiti Dinar</asp:ListItem>
<asp:ListItem>KZT - Kazakhstani Tenge</asp:ListItem>
<asp:ListItem>LKR - Sri Lankan Rupee</asp:ListItem>
<asp:ListItem>LTL - Lithuanian Litas</asp:ListItem>
<asp:ListItem>LVL - Latvian Lat</asp:ListItem>
<asp:ListItem>LYD - Libyan Dinar</asp:ListItem>
<asp:ListItem>MUR - Mauritian Rupee</asp:ListItem>
<asp:ListItem>MXN - Mexican Peso</asp:ListItem>
<asp:ListItem>MYR - Malaysian Ringgit</asp:ListItem>
<asp:ListItem>NOK - Norwegian Krone</asp:ListItem>
<asp:ListItem>NPR - Nepalese Rupee</asp:ListItem>
<asp:ListItem>NZD - New Zealand Dollar</asp:ListItem>
<asp:ListItem>OMR - Omani Rial</asp:ListItem>
<asp:ListItem>PHP - Philippine Peso</asp:ListItem>
<asp:ListItem>PKR - Pakistani Rupee</asp:ListItem>
<asp:ListItem>PLN - Polish Zloty</asp:ListItem>
<asp:ListItem>QAR - Qatari Riyal</asp:ListItem>
<asp:ListItem>RON - Romanian New Leu</asp:ListItem>
<asp:ListItem>RUB - Russian Ruble</asp:ListItem>
<asp:ListItem>SAR - Saudi Arabian Riyal</asp:ListItem>
<asp:ListItem>SEK - Swedish Krona</asp:ListItem>
<asp:ListItem>SGD - Singapore Dollar</asp:ListItem>
<asp:ListItem>THB - Thai Baht</asp:ListItem>
<asp:ListItem>TRY - Turkish Lira</asp:ListItem>
<asp:ListItem>TTD - Trinidadian Dollar</asp:ListItem>
<asp:ListItem>TWD - Taiwan New Dollar</asp:ListItem>
<asp:ListItem>USD - US Dollar</asp:ListItem>
<asp:ListItem>VEF - Venezuelan Bolivar</asp:ListItem>
<asp:ListItem>ZAR - South African Rand</asp:ListItem>

        </asp:DropDownList></div>
 
  </div></div></div></div>
 <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Work  Experience</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group">
                   <div class="row"> 
    <div class="col-md-4">  
        <asp:TextBox ID="txtWorkExperience" runat="server" CssClass="form-control" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox></div>
       <div class="col-md-4">      <asp:DropDownList ID="ddlexperiance" runat="server" required="required" AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem Value="">--Select --</asp:ListItem>
     <asp:ListItem>Month</asp:ListItem>
<asp:ListItem>Year</asp:ListItem>
     </asp:DropDownList></div> <div class="col-md-4">  </div>
       </div></div></div></div>
                    <div class="row"> 
                         <div class="col-md-4"> 
                                
                       </div> 
                             
                      <div class="col-md-8">

             <div class="form-group">
          <asp:Button ID="btnProfessionSave" runat="server" Text="Save"   onclick="btnProfessionSave_Click" CssClass="loginbtn" />
      </div></div></div>

 </div></div></div></div></div></div></div></div>

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
