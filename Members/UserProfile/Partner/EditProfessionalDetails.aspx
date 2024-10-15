<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="EditProfessionalDetails.aspx.cs" Inherits="members_UserProfile_Partner_EditProfessionalDetails" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony |  Professional Details</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../../images/favicon.ico" type="image/x-icon" />
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
    <!-- multiselect dropdown -->
 
    <link href="../../../css/select2.css" rel="stylesheet" />
    <script src="../../../css/select2.js"></script>
    <link href="../../../css/select2-bootstrap.css" rel="stylesheet" />
    <script>
        function myFunction() {
            var vals = $("#ddleducation").select2('val');
            document.getElementById("dtaSelect").value = vals;

            var vala = $("#ddlEmployeeIn").select2('val');
            document.getElementById("dtaEmployeeIn").value = vala;

            var vald = $("#ddlfunctional").select2('val');
            document.getElementById("dtafunctional").value = vald;
        }
    </script>
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
                                <li><a href="EditPersonalDetails.aspx">  Edit My Profile</a></li>
                                <li><a href="EditPersonalDetails.aspx">Edit Partner Profile</a></li> 
                                    <li><a href="../Self/EditContactDetail.aspx">Edit Contact Details</a></li>   
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
                                <li ><a href="#">FAQ</a></li>                         
                                          
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
  <li ><a href="../Self/EditPersonalDetails.aspx">  Edit My Profile</a></li>
  <li class="active"><a href="EditPersonalDetails.aspx">Edit Partner Profile</a></li>
<li> <a href="../../Setting/ChangePassword.aspx">Settings</a></li>
</ul>
               </div>
          <div class="row">
               <div class="col-lg-3 bhoechie-tab-menu">
          <div class="list-group"> 
                <a href="EditPersonalDetails.aspx" class="list-group-item ">
                 <i class="fa fa-user"></i>  Basic Details
                </a>
                <a href="EditPhysicalDetails.aspx" class="list-group-item">
                   <i class="fa fa-heart"></i>    Physical Details
                </a>
                    <a href="EditProfessionalDetails.aspx" class="list-group-item active">
             <i class="fa fa-briefcase"></i>   Professional Details
                </a>
                    <a href="EditReligiousDetails.aspx" class="list-group-item">
                    <i class="fa fa-arrows-alt"></i>  Religious Details
                </a> 
                    <a href="EditFamilyDetails.aspx" class="list-group-item ">
                <i class="fa fa-crosshairs"></i>Family Details
                </a> 
                     <a href="EditLifeStyleDetails.aspx" class="list-group-item">
         <i class="fa fa-glass"></i>   Lifestyle Details
                </a> 
              </div>
            </div>
        <div class="col-lg-9 bhoechie-tab-container">
            
            <div class="bhoechie-tab">
             
                <div class="bhoechie-tab-content active">
                     <div class="row">  
                          <div class="col-md-12"> 
                 <ul class="breadcrumb text-left">
    <li>Edit Partner Profile</li>
   <li><a href= "EditFamilyDetails.aspx">Edit Partner Professional  Details</a></li>
</ul>
		 </div>  </div> 
                    <div class="row">
                       <div class="col-md-1" ></div>
                         
               <div class="col-md-10" >
                    <div class="row"> 
                         <div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>Education</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
   <div class="form-group">  
       <select id="ddleducation" multiple="true"  style="width:280px" runat="server"  > 
           <option disabled="disabled" style="color:#CC3300">--Any Bachelors in Engineering/Computers--</option>
<option>Aeronautical Engineering</option>
<option>B.Arch</option>
<option>BCA</option>
<option>BE</option>
<option>B.Plan</option>
<option>B.Sc IT/ Computer Science</option>
<option>B.Tech.</option>
<option>Other Bachelor Degree in Engineering / Computers</option>
<option disabled="disabled" style="color:#CC3300">--Any Masters in Engineering/Computers--</option>
<option>M.Arch.</option>
<option>MCA</option>
<option>ME</option>
<option>M.Sc. IT/Computer Science</option>
<option>M.S.(Engg.)</option>
<option>M.Tech.</option>
<option>PGDCA</option>
<option>Other Masters Degree in Engineering / Computers</option>
<option disabled="disabled" style="color:#CC3300">--Any Bachelors in Arts/Science/Commerce--</option>
<option>Aviation Degree</option>
<option>B.A.</option>
<option>B.Com.</option>
<option>B.Ed.</option>
<option>BFA</option>
<option>BFT</option>
<option>BLIS</option>
<option>B.M.M.</option>
<option>B.Sc.</option>
<option>B.S.W</option>
<option>B.Phil.</option>
<option>Other Bachelor Degree in Arts / Science / Commerce</option>
<option disabled="disabled" style="color:#CC3300">--AnyMastersinArts/Science/Commerce--</option>
<option>M.A.</option>
<option>MCom</option>
<option>M.Ed.</option>
<option>MFA</option>
<option>MLIS</option>
<option>M.Sc.</option>
<option>MSW</option>
<option>M.Phil.</option>
<option>Other Master Degree in Arts / Science / Commerce</option>
<option disabled="disabled" style="color:#CC3300">--AnyBachelorsinManagement--</option>
<option>BBA</option>
<option>BFM (Financial Management)</option>
<option>BHM (Hotel Management)</option>
<option>Other Bachelor Degree in Management</option>
<option disabled="disabled" style="color:#CC3300">--AnyMastersinManagement--</option>
<option>MBA</option>
<option>MFM (Financial Management)</option>
<option>MHM (Hotel Management)</option>
<option>MHRM (Human Resource Management)</option>
<option>PGDM</option>
<option>Other Master Degree in Management</option>
<option disabled="disabled" style="color:#CC3300">--AnyBachelorsinMedicineinGeneral/Dental/Surgeon--</option>
<option>B.A.M.S.</option>
<option>BDS</option>
<option>BHMS</option>
<option>BSMS</option>
<option>BPharm</option>
<option>BPT</option>
<option>BUMS</option>
<option>BVSc</option>
<option>MBBS</option>
<option>B.Sc.Nursing</option>
<option>Other Bachelor Degree in Medicine</option>
<option disabled="disabled" style="color:#CC3300">--AnyMastersinMedicine-General/Dental/Surgeon--</option>
<option>MDS</option>
<option>MD/MS (Medical)</option>
<option>M.Pharm</option>
<option>MPT</option>
<option>MVSc</option>
<option>Other Master Degree in Medicine</option>
<option disabled="disabled" style="color:#CC3300">--AnyBachelorsinLegal--</option>
<option>BGL</option>
<option>B.L.</option>
<option>LL.B.</option>
<option>Other Bachelor Degree in Legal</option>
<option disabled="disabled" style="color:#CC3300">--AnyMastersinLegal--</option>
<option>LL.M.</option>
<option>M.L.</option>
<option>Other Master Degree in Legal</option>
<option disabled="disabled" style="color:#CC3300">--AnyFinancialQualification-ICWAI/CA/CS/CFA--</option>
<option>CA</option>
<option>CFA (Chartered Financial Analyst)</option>
<option>CS</option>
<option>ICWA</option>
<option>Other Degree in Finance</option>
<option disabled="disabled" style="color:#CC3300">--Service-IAS/IPS/IRS/IES/IFS--</option>
<option>IAS</option>
<option>IES</option>
<option>IFS</option>
<option>IRS</option>
<option>IPS</option>
<option>Other Degree in Service</option>
<option disabled="disabled" style="color:#CC3300">--Ph.D.--</option>
<option>Ph.D.</option>
<option disabled="disabled" style="color:#CC3300">--AnyDiploma--</option>
<option>Diploma</option>
<option>Polytechnic</option>
<option>TradeSchool</option>
<option>Others in Diploma</option>
<option disabled="disabled" style="color:#CC3300">--HigherSecondary/Secondary--</option>
<option>Higher Secondary School</option>
<option>High School</option>
<option>Not Educated</option>

                               </select>
        <%-- Education --%>
         <asp:HiddenField ID="dtaSelect" runat="server"  />
       <script> 
          
          $(document).ready(function () {
              $("#ddleducation").select2({ placeholder: 'Find and Select Courses' });
          });
         
</script>
       <%-- Education end --%>
     </div></div></div>
                             <div class="row"> 
                         <div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>Employed sector</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
   <div class="form-group">
        
 
        <select id="ddlEmployeeIn" runat="server" multiple="true"  style="width:280px" >
         
        <option>Central Government</option>
        <option>State Government</option>
        <option>Private Sector</option>
        <option>Public Sector</option>
        <option>Self Employed</option>
        <option>Not Working</option>
        <option>Other</option>

        </select>
        <%-- EmployeeIn --%>
         <asp:HiddenField ID="dtaEmployeeIn" runat="server"  />
       <script> 
          
          $(document).ready(function () {
              $("#ddlEmployeeIn").select2({ placeholder: 'Find and Select EmployeeIn' });
          });
          
</script>
       <%-- EmployeeIn end --%>
          </div></div></div>
                             <div class="row"> 
                         <div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>Functional area</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
   <div class="form-group">
         
        <select id="ddlfunctional" runat="server" multiple="true"  style="width:280px"> 
<option disabled="disabled" style="color:#CC3300">--ADMIN--</option>
<option>Manager</option>
<option>Supervisor</option>
<option>Officer</option>
<option>Administrative Professional</option>
<option>Executive</option>
<option>Clerk</option>
<option>Human Resources Professional</option>
<option disabled="disabled" style="color:#CC3300">--AGRICULTURE--</option>
<option>Agriculture & Farming Professional</option>
<option disabled="disabled" style="color:#CC3300">--AIRLINE--</option>
<option>Pilot</option>
<option>Air Hostess</option>
<option>Airline Professional</option>
<option disabled="disabled" style="color:#CC3300">--ARCHITECT&DESIGN--</option>
<option>Architect</option>
<option>Interior Designer</option>
<option disabled="disabled" style="color:#CC3300">--BANKING&FINANCE--</option>
<option>Chartered Accountant</option>
<option>Company Secretary</option>
<option>Accounts / FinanceProfessional</option>
<option>Banking Service Professional</option>
<option>Auditor</option>
<option>Financia lAccountant</option>
<option>Financial Analyst / Planning</option>
<option disabled="disabled" style="color:#CC3300">--BEAUTY&FASHION--</option>
<option>Fashion Designer</option>
<option>Beautician</option>
<option disabled="disabled" style="color:#CC3300">--CIVILSERVICES--</option>
<option>Civil Services (IAS/IPS/IRS/IES/IFS)</option>
<option disabled="disabled" style="color:#CC3300">--DEFENCE--</option>
<option>Army</option>
<option>Navy</option>
<option>Airforce</option>
<option disabled="disabled" style="color:#CC3300">--EDUCATION--</option>
<option>Professor / Lecturer</option>
<option>Teaching / Academician</option>
<option>Education Professional</option>
<option disabled="disabled" style="color:#CC3300">--HOSPITALITY--</option>
<option>Hotel / Hospitality Professional</option>
<option disabled="disabled" style="color:#CC3300">--IT&ENGINEERING--</option>
<option>Software Professional</option>
<option>Hardware Professional</option>
<option>Engineer -NonIT</option>
<option>Designer -IT&Engineering</option>
<option disabled="disabled" style="color:#CC3300">--LEGAL--</option>
<option>Lawyer & Legal Professional</option>
<option disabled="disabled" style="color:#CC3300">--LAWENFORCEMENT--</option>
<option>Law Enforcement Officer</option>
<option disabled="disabled" style="color:#CC3300">--MEDICAL--</option>
<option>Doctor</option>
<option>Health Care Professional</option>
<option>Paramedical Professional</option>
<option>Nurse</option>
<option disabled="disabled" style="color:#CC3300">--MARKETING&SALES--</option>
<option>Marketing Professional</option>
<option>Sales Professional</option>
<option disabled="disabled" style="color:#CC3300">--MEDIA&ENTERTAINMENT--</option>
<option>Journalist</option>
<option>Media Professional</option>
<option>Entertainment Professional</option>
<option>Event Management Professional</option>
<option>Advertising / PRProfessional Designer</option>
<option>Media & Entertainment</option>

<option>Mariner / MerchantNavy</option>
<option disabled="disabled" style="color:#CC3300">--SCIENTIST--</option>
<option>Scientist / Researcher</option>
<option disabled="disabled" style="color:#CC3300">--TOPMANAGEMENT--</option>
<option>CXO / President</option>
<option>Director</option>
<option>Chairman</option>
<option>Business Analyst</option>
<option disabled="disabled" style="color:#CC3300">--OTHERS--</option>
<option>Consultant</option>
<option>Customer Care Professional</option>
<option>Social Worker</option>
<option>Sportsman</option>
<option>Technician</option>
<option>Arts & Craftsman</option>
<option>Student</option>
<option>Librarian</option>
<option>Not Working</option>

        </select>
        <%-- EmployeeIn --%>
         <asp:HiddenField ID="dtafunctional" runat="server"  />
       <script> 
          
          $(document).ready(function () {
              $("#ddlfunctional").select2({ placeholder: 'Find and Select Functional area' });
          });
          
</script>
       <%-- EmployeeIn end --%>
        </div></div></div>
                             <div class="row"> 
                         <div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>Annual Income</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
   <div class="form-group">
          <div class="row">
                        <div class="col-md-3"> 
        <asp:TextBox ID="txtAnnualIncome" runat="server" CssClass="form-control"
             onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox></div>

     <div class="col-md-4">    
           <asp:DropDownList ID="ddlCurrency" runat="server"  AppendDataBoundItems="true" CssClass="form-control">
    <asp:ListItem Value="">-- Please Select--</asp:ListItem> 
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

        </asp:DropDownList>
         </div></div>
        </div></div></div>
          <div class="row"> 
                         <div class="col-md-3"> 
                                 
                             </div> 
                      <div class="col-md-8">
   <div class="form-group">
         <asp:Button ID="btnProfessionSave" runat="server" Text="Save"  onclick="btnProfessionSave_Click" OnClientClick="myFunction()" CssClass="loginbtn" />
       </div></div></div>
                   </div>
                      </div></div></div></div></div></div>
        </div>
           </div>
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
