﻿<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="ViewProfile.aspx.cs" Inherits="members_UserProfile_ViewProfile" %>
<%@ Register Assembly="GroupingView" Namespace="UNLV.IAP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html>

 <html xmlns="http://www.w3.org/1999/xhtml">
 <head>
<title>Swapnpurti Matrimony | Member Profile</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
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
     	<script type="text/javascript">
     	    jQuery(document).ready(function ($) {
     	        $(".scroll").click(function (event) {
     	            event.preventDefault();
     	            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
     	        });
     	    });

     	    $(document).ready(function () {
     	        $('li img').on('click', function () {
     	            var src = $(this).attr('src');
     	            var img = '<img src="' + src + '" class="img-responsive"/>';
     	            $('#myModal').modal();
     	            $('#myModal').on('shown.bs.modal', function () {
     	                $('#myModal .modal-body').html(img);
     	            });
     	            $('#myModal').on('hidden.bs.modal', function () {
     	                $('#myModal .modal-body').html('');
     	            });
     	        });
     	    })
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
     <!-- slider -->
     <link href="engine1/style.css" rel="stylesheet" />
<!-- animated-css -->
		<link href="../../css/animate.css" rel="stylesheet" type="text/css" media="all">
		<script src="../../js/wow.min.js"></script>
		<script>
		    new WOW().init();
		</script>
<!-- animated-css --> 
     
    <style type="text/css"> 
a.morelink {
	text-decoration:none;
	outline: none;
}
.morecontent span {
	display: none; 
}
</style>

<%--  start   gallagy css photo--%>
    <link href="css/visuallightbox.css" rel="stylesheet" />
        <link href="css/vlightbox1.css" rel="stylesheet" />
<script src="js/jquery.min.js" type="text/javascript"></script>
		<script src="js/visuallightbox.js" type="text/javascript"></script>
</head>
<body>
     <form id="form1" runat="server">
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-body">
          </div>
        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div>
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
                                <li  ><a href="../Activities/VisitorsProfile.aspx">Who viewed my profile</a></li>
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
                                    <li><a href="../Setting/ChangePassword.aspx">Change Password</a></li> 
                                    <li><a href="../Setting/DeleteProfile.aspx" >Delete Profile</a></li> 
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
</nav>
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
				 
				<div class="clearfix"> </div>
			 
		</div>
	 
         <div class="franchisee">
             <div class="container">
                   <div class="col-md-11"> 
                 <ul class="breadcrumb text-left">
    <li>Search</li>
                     
    <li>Member Profile</li>  
</ul>	 </div>   
                        <div class="col-lg-1 text-right" style="margin-top:3px">
                            <asp:HyperLink runat="server" ID="hypLinkBack" CssClass="loginbtn" NavigateUrl="~/Members/SearchMatches/AdvancedSearch.aspx"  >Back</asp:HyperLink>
                        </div>
<div id="getMemberDatas" runat="server" >
                      
	   <div class="col-lg-8 bhoechie-tab-container">
            
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 bhoechie-tab">
                <!-- flight section -->
                <div class="bhoechie-tab-content active">
                   <div style="background-image: url('../../images/pat.jpg');  border:1px solid #ddd; padding: 10px 20px;    margin-top: 10px;">
         <div class="row">    
                     <div class="col-lg-12"> 
            <div class="col-lg-5">  
          <div class="form-group">
             <asp:Label ID="lblFullId" runat="server" Font-Bold="True" Font-Size="Large" />
                &nbsp;<asp:Label ID="lblPackageName" runat="server" Font-Bold="True" ForeColor="#d65679 "></asp:Label>  <br />            
         
  
           </div>
    
       </div>
                         <div class="col-lg-7">
                                  <div style="float:right;padding-top:8px;">   
                <asp:Label ID="Label2" runat="server" Text="Profile Created For" Font-Size="Small"></asp:Label> 
                 <asp:Label ID="lblFullMembership" runat="server" Font-Size="Small" /></div>
                         </div>
                    </div>
          </div>
                         <div class="row">    
                               <div class="col-lg-12"> 
            <div class="col-lg-3">  
            <asp:Image ID="imgmember" runat="server"  CssClass="img-thumbnail"  Height="170px"  /><br />
                  <asp:Label ID="lblFullName" runat="server"  Font-Bold="True" Font-Size="Large" /> 
           </div>
            <div  class="col-lg-9">
                 
         <asp:Label ID="lblfullage" runat="server" />,  
           <asp:Label ID="lblFullHeight" runat="server" />, 
        <asp:Label ID="lblfullReligion" runat="server" />,
          <asp:Label ID="lblfullcaste" runat="server" />,
        <asp:Label ID="lblFullSubcaste" runat="server" />,
         <asp:Label ID="lblFullstate" runat="server" />,  
           <asp:Label ID="lblFullcity" runat="server" />,
         <asp:Label ID="lblFullEducation" runat="server" />,
          <asp:Label ID="lblfullProfession" runat="server" />,
        <asp:Label ID="lblFullanualincome" runat="server" />,
         
     <div id="forPaidMember" runat="server" Visible="False">
         <asp:Label ID="Label4" runat="server" Text="  Contact At :: "></asp:Label>&nbsp;
          <i class="fa fa-phone  iconcolor "></i>   <asp:Label ID="lblMobile" runat="server" Text="Label"></asp:Label>&nbsp;
       <i class="fa fa-envelope  iconcolor "></i>    <asp:Label ID="lblEmail" runat="server" Text="Label"  ></asp:Label>&nbsp;
      <i class="fa fa-mobile  iconcolor "></i>     <asp:Label ID="lblAddress" runat="server" Text="Label" ></asp:Label></div>
                  <asp:Button ID="btnView" runat="server" Text="View Contact Details" OnClick="btnView_Click" CssClass="btn btn-warning btn-xs" /><br /><br />
                      <div class="form-group">
   <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" required="required" TextMode="MultiLine" Text="Hi! I like your profile. Wish to connect with you to know you better."></asp:TextBox>
                      </div>
             <div class="form-group">
        <asp:Button ID="btnSend" runat="server" Text="Send Message" OnClick="btnSend_Click" CssClass="loginbtn"  />
             <div style="float:right;padding-top:8px;">   <asp:LinkButton ID="lnkInterest" runat="server" OnClick="lnkInterest_Click" CssClass="btn btn-success" > Send Interest</asp:LinkButton>
                 <asp:LinkButton ID="lnkShortlist" runat="server" onclick="lnkShortlist_Click" CssClass="btn btn-danger" >Shortlist</asp:LinkButton> 
<%--            <a href="../Activities/ViewedProfile.aspx" class="btn btn-primary">Viewed Profiles</a> --%>
              
             </div> </div> 
                               
             </div>  
                             </div>
                             </div>
</div> 
                   <div class="row">    
                <div class="col-lg-12"> 
                    <br />
                     <div class="form-group">
         <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="About myself "  ></asp:Label>
        : <asp:Label ID="lblMyself" runat="server" CssClass="label-font-size comment more"></asp:Label>
                         <br /> <br />
             <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="About Family "  ></asp:Label>: <asp:Label ID="lblaboutfamily" runat="server" CssClass="label-font-size comment more"></asp:Label>
     </div>           
              </div> </div>
                         <div class="row">    
                      <div class="col-lg-12">
             
                   <h4><img src="../../images/icon%20squares.png" height="20" width="20"/>&nbsp;&nbsp;Basic Details</h4>
                     <div class="col-lg-1 img-circle img-thumbnail proicon">
                         <i class="fa fa-user fa-2x iconcolor "></i>
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
                                                      <dt>Living with children</dt>
	                        <dd>:  <asp:Label ID="lblChildrnStatus" runat="server"></asp:Label></dd>
                              </div>
                         </dl> 
                    </div> 
              </div>  
                              </div>
                         <div class="row">    
        <div class="col-lg-12">
              <h4><img src="../../images/icon%20squares.png" height="20" width="20"/>&nbsp;&nbsp;Religious Information</h4>
                    <div class="col-lg-1 img-circle img-thumbnail proicon">
                         <i class="fa fa-recycle fa-2x iconcolor"></i>
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
           <h4><img src="../../images/icon%20squares.png" height="20" width="20"/>&nbsp;&nbsp;Physical Appearance</h4>
       <div class="col-lg-1 img-circle img-thumbnail proicon">
                         <i><img src="../../images/physical.jpg" height="30" width="30" style="margin:10px 0px" /></i>
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
          <h4><img src="../../images/icon%20squares.png" height="20" width="20"/>&nbsp;&nbsp;Professional Information</h4>
           
               <div class="col-lg-1 img-circle img-thumbnail proicon">
                         <i><img src="../../images/proffessional.jpg"  height="30" width="30" style="margin:10px 0px" /></i>
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
     <h4><img src="../../images/icon%20squares.png" height="20" width="20"/>&nbsp;&nbsp;Living In</h4>
        <div class="col-lg-1 img-circle img-thumbnail proicon">
                         <i class="fa fa-globe fa-2x iconcolor"></i>
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
                       <h4><img src="../../images/icon%20squares.png" height="20" width="20"/>&nbsp;&nbsp;Family Information</h4>
                  <div class="col-lg-1 img-circle img-thumbnail proicon">
                         <i class="fa fa-users fa-2x iconcolor"></i>
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
                      <h4><img src="../../images/icon%20squares.png" height="20" width="20"/>&nbsp;&nbsp;About your lifestyle</h4>
        <div class="col-lg-1 img-circle img-thumbnail proicon">
                         <i class="fa fa-building fa-2x iconcolor"></i>
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
                   </div>
                  
                    </div>
                </div>
           
        </div >
                    <div class="col-lg-1"></div>
    <div class="col-lg-3">
        <div id="asasd"><h3 class="text-center">Photo Gallery</h3><div class="borsolid"></div><br /> </div>
         	<div id="wowslider-container1">
	<div class="ws_images">
        <ul>

        <asp:ListView ID="lstgallary" runat="server" >
         
         
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
         
        <ItemTemplate>
            <span style=""> 
		<li><img src='<%# "../media/"+ Eval("varUploadPath") %>' alt='<%# Eval("varCaption") %>' title='<%# Eval("varCaption") %>' id="wows1_0"/></li>
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
            </ul>
        </div>
	
	</div>
	<script type="text/javascript" src="engine1/wowslider.js"></script>
	<script type="text/javascript" src="engine1/script.js"></script>
       <div class="clearfix"> </div><br />
           <div id="similar" runat="server">

           <h3 class="text-center">Similar Profiles</h3><div class="borsolid"></div><br /> 
        <asp:ListView ID="lstView" runat="server" 
           >  
            <EmptyDataTemplate>
                <span>No Similar Profiles Found.</span>
            </EmptyDataTemplate> 
            <ItemTemplate>
                <div class="row justborder" >
<div class="col-lg-3 jsideleft" >
              <asp:Image ID="imgSimilarPic" runat="server"  Height="70px" Width="70px"   CssClass="justborder"
                               ImageUrl='<%# "~/members/media/" + Eval("Photo") %>' /> 
    <br /> <asp:LinkButton ID="LinkButton1" runat="server"    CommandArgument='<%# Eval("Member") %>'
       OnClick="OpenProfile" Text="ViewProfile"></asp:LinkButton>
        
</div>
                  <div class="col-lg-8 jsideright" >
                      <asp:LinkButton ID="LinkButton2" runat="server"    CommandArgument='<%# Eval("Member") %>'   OnClick="OpenProfile" Text='<%# Eval("Member") %>'></asp:LinkButton>
 <br />    <asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("Age") %>' />,<asp:Label ID="HeightLabel" runat="server" Text='<%# Eval("Height") %>' />,   
            <asp:Label ID="EducationLabel" runat="server" Text='<%# Eval("Education") %>' />, 
      <asp:Label ID="ReligionLabel" runat="server" Text='<%# Eval("Religion") %>' />,
                         <asp:Label ID="CasteLabel" runat="server" Text='<%# Eval("Caste") %>' /> , 
         <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />   <br />
          
                  </div>
                       </div> 
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
              <br /> <div class="borsolid">   <img src="../../images/Advertising.jpg" width="250px"/></div></div>
    </div>        </div>
             </div>
                   
				<div class="clearfix"> </div>
			 <br /><br />
 
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
				<div id="InterestListview" runat="server"> 
                    <asp:ListView ID="lstviewedProfile" runat="server" >  
           
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" width="513">
																<tbody>
                                                                    
                                                                    <tr><td>&nbsp;</td></tr>
                                                                    <tr>
																	<td align="left" valign="top" width="15"></td>
																	<td align="left" valign="top" width="102">	<asp:Image ID="vimgSimilarPic" runat="server"    ImageUrl='<%# "http://swapnpurti.in/members/media/" + Eval("Photo") %>'  Height="90px" Width="90px" BorderStyle="Solid" BorderWidth="1px" BorderColor="#DFDFDF"  /></td><td align="left" valign="top" width="15"></td>
																	<td align="left" valign="top" width="384">
																		<table border="0" cellpadding="0" cellspacing="0" width="384">
																			<tbody>
                                                                                <tr>
																				<td style="font:bold 13px arial;color:#363636;line-height:20px;" align="left" valign="top"><asp:Label ID="Label51" runat="server" Text='<%# Eval("Name") %>' /> (<asp:Label ID="lblView" runat="server"    Text='<%# Eval("Member")%>'  style="color:#0274CB;text-decoration:none;" target="_blank"></asp:Label>)
																				</td>
																			</tr>
																			<tr><td align="left" height="5" valign="top"></td></tr>
                                                                             <tr><td style="font:normal 13px/21px arial;color:#777777;" align="left" valign="top">
                                                                                  <asp:Label ID="vage" runat="server" Text='<%# Eval("Age") %>' />, 
                                                                                 <asp:Label ID="vheight" runat="server" Text='<%# Eval("Height") %>' /> |  
                                                                                  <asp:Label ID="Label41" runat="server" Text='<%# Eval("Religion") %>' /> : <asp:Label ID="CasteLabel" runat="server" Text='<%# Eval("Caste") %>' /> |
                                                                                  <b>Location:</b> <asp:Label ID="vcity" runat="server" Text='<%# Eval("City") %>' />, 
                                                                                 <asp:Label ID="vState" runat="server" Text='<%# Eval("State") %>' /> ,  
                                                                                 <asp:Label ID="vCountry" runat="server" Text='<%# Eval("Country") %>' /> |
                                                                                  <b>Education:</b>    <asp:Label ID="vEducation" runat="server" Text='<%# Eval("Education") %>' /> |
                                                                                  <b>Occupation:</b>  <asp:Label ID="vOccupation" runat="server" Text='<%# Eval("Occupation") %>' /> </td>
																			</tr> 
																		</tbody></table>
																	</td>
																</tr>
																
																<tr><td align="left" height="5" valign="top">   <asp:Label ID="varemail" runat="server" Text='<%# Eval("Email") %>'  Visible="false"/></td></tr>
															</tbody></table>
               
          </ItemTemplate>
            <LayoutTemplate>
                <div ID="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
                <div style="">
                </div>
            </LayoutTemplate>
             
        </asp:ListView>

        <%--<asp:ListView ID="lstviewedProfile" runat="server" >  
           
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" width="513">
																<tbody>
                                                                    
                                                                    <tr><td>&nbsp;</td></tr>
                                                                    <tr>
																	<td align="left" valign="top" width="15"></td>
																	<td align="left" valign="top" width="102"><asp:Image ID="vimgSimilarPic" runat="server"    ImageUrl='<%# "http://swapnpurti.in/members/media/" + Eval("Photo") %>'  Height="90px" Width="90px" BorderStyle="Solid" BorderWidth="1px" BorderColor="#DFDFDF"  /></td><td align="left" valign="top" width="15"></td>
																	<td align="left" valign="top" width="384">
																		<table border="0" cellpadding="0" cellspacing="0" width="384">
																			<tbody>
                                                                                <tr>
																				<td style="font:bold 13px arial;color:#363636;line-height:20px;" align="left" valign="top"><asp:Label ID="Label51" runat="server" Text='<%# Eval("Name") %>' /> (<asp:Label ID="lblView" runat="server"    Text='<%# Eval("Member")%>'  style="color:#0274CB;text-decoration:none;" target="_blank"></asp:Label>)
																				</td>
																			</tr>
																			<tr><td align="left" height="5" valign="top"></td></tr>
                                                                             <tr><td style="font:normal 13px/21px arial;color:#777777;" align="left" valign="top">
                                                                                  <asp:Label ID="vage" runat="server" Text='<%# Eval("Age") %>' />, 
                                                                                 <asp:Label ID="vheight" runat="server" Text='<%# Eval("Height") %>' /> |  
                                                                                  <asp:Label ID="Label41" runat="server" Text='<%# Eval("Religion") %>' /> : <asp:Label ID="CasteLabel" runat="server" Text='<%# Eval("Caste") %>' /> |
                                                                                  <b>Location:</b> <asp:Label ID="vcity" runat="server" Text='<%# Eval("City") %>' />, 
                                                                                 <asp:Label ID="vState" runat="server" Text='<%# Eval("State") %>' /> ,  
                                                                                 <asp:Label ID="vCountry" runat="server" Text='<%# Eval("Country") %>' /> |
                                                                                  <b>Education:</b>    <asp:Label ID="vEducation" runat="server" Text='<%# Eval("Education") %>' /> |
                                                                                  <b>Occupation:</b>  <asp:Label ID="vOccupation" runat="server" Text='<%# Eval("Occupation") %>' /> </td>
																			</tr> 
																		</tbody></table>
																	</td>
																</tr>
																
																<tr><td align="left" height="5" valign="top">   <asp:Label ID="varemail" runat="server" Text='<%# Eval("Email") %>'  Visible="false"/></td></tr>
															</tbody></table>
               
          </ItemTemplate>
            <LayoutTemplate>
                <div ID="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
                <div style="">
                </div>
            </LayoutTemplate>
             
        </asp:ListView>--%>
      </div>		 
    </form> 
    <script>
        $(document).ready(function () {
            var showChar = 80;
            var ellipsestext = "";
            var moretext = "...more";
            var lesstext = "...less";
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
