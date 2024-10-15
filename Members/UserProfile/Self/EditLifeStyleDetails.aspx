<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="EditLifeStyleDetails.aspx.cs" Inherits="members_UserProfile_Self_EditLifeStyleDetails" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony |  Life Style Details</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../../images/favicon.ico" type="image/x-icon" />
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

 <%-- <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/members/Activities/Notification.aspx" ToolTip="Notification" runat="server" CssClass="notif"> </asp:HyperLink>  --%>
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
 <a href="EditFamilyDetails.aspx" class="list-group-item ">
                  <i class="fa fa-crosshairs"></i> Family Details
                </a>
                                
                    <a href="EditLifeStyleDetails.aspx" class="list-group-item active">
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
   <li><a href= "EditLifeStyleDetails.aspx">Edit Lifestyle Details</a></li>
</ul>
		 </div>  </div> 
                    <div class="row">
                      
                        <div class="col-lg-12 text-left"> 
               <div class="col-md-10" >
                   <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Eating habits</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">         
        <asp:RadioButton ID="rgbVegetarian" runat="server" GroupName="rgbEat"   Text="Vegetarian" />
      &nbsp;   &nbsp;  <asp:RadioButton ID="rgbNonVegetarian" runat="server" GroupName="rgbEat"  Text="Non-Vegetarian" />
      &nbsp;   &nbsp;    <asp:RadioButton ID="rgbEggetarian" runat="server" GroupName="rgbEat"  Text="Eggetarian" />
     &nbsp;   &nbsp;     <asp:RadioButton ID="rgbJain" runat="server" GroupName="rgbEat" Text="Jain" />
                 </div>
      </div></div>
                    <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Smoking </span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">         
       
        <asp:RadioButton ID="rgbSYes" runat="server" GroupName="rgbSmoke" Text="Yes" />
        <asp:RadioButton ID="rgbSNo" runat="server" GroupName="rgbSmoke" Text="No" />
        <asp:RadioButton ID="rgbSOccasionally" runat="server" GroupName="rgbSmoke"   Text="Occasionally" />
        </div></div>
                    </div>
 <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Drinking  </span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">         

              
        <asp:RadioButton ID="rgbDYes" runat="server" GroupName="rgbDrink" Text="Yes" />
   &nbsp;   &nbsp;       <asp:RadioButton ID="rgbDNo" runat="server" GroupName="rgbDrink" Text="No" />
    &nbsp;   &nbsp;      <asp:RadioButton ID="rgbDOccasionally" runat="server" GroupName="rgbDrink"  Text="Occasionally" />
       </div></div>
</div>
   <div class="row"> 
            <div class="col-md-4"> 
                      <div class="form-group">   
                            <span> Spoken Languages</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">        
         
    <asp:CheckBox ID="ckhSlEng" runat="server" Text="English" /> &nbsp; 
    <asp:CheckBox ID="ckhSlHin" runat="server" Text="Hindi" /> &nbsp; 
    <asp:CheckBox ID="ckhSlMar" runat="server" Text="Marathi" /> &nbsp; 
    <asp:CheckBox ID="ckhSlTel" runat="server" Text="Telugu" /> &nbsp; 
    <asp:CheckBox ID="ckhSlTam" runat="server" Text="Tamil" /> &nbsp; 
    <asp:CheckBox ID="ckhSlGuj" runat="server" Text="Gujrathi" /> &nbsp; 
      <asp:CheckBox ID="ckhSlKan" runat="server" Text="Kannada" /> &nbsp; 
    <asp:CheckBox ID="ckhSlUrdu" runat="server" Text="Urdu" /> &nbsp; 
      <asp:CheckBox ID="chkSlMal" runat="server" Text="Malyalam" /> &nbsp; 
  <br />  <asp:TextBox ID="txtSlOther" runat="server" CssClass="form-control" placeholder="Other"></asp:TextBox>

      </div></div>

   </div>
    <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Hobbies/Interest </span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">         
    
         <asp:CheckBox ID="chkHcook" runat="server" Text="Cooking" /> &nbsp; 
    <asp:CheckBox ID="chkHpaint" runat="server" Text="Painting" /> &nbsp; 
    <asp:CheckBox ID="chkHphoto" runat="server" Text="Photography" /> &nbsp; 
    <asp:CheckBox ID="chkHdance" runat="server" Text="Dancing" /> &nbsp; 
     <asp:CheckBox ID="chkHtravel" runat="server" Text="Traveling" /> &nbsp; 
    <asp:CheckBox ID="chkHinternet" runat="server" Text="Internet Surfing" /> &nbsp;    
      <asp:CheckBox ID="chkHart" runat="server" Text="Art / Handicraft" /> &nbsp;   
    <asp:CheckBox ID="chkHListenmusic" runat="server" Text="Listening to Music" /> &nbsp; 
       <asp:CheckBox ID="chkHmovie" runat="server" Text="Movies" /> &nbsp; 
       <asp:CheckBox ID="chkHpets" runat="server" Text="Pets" />  &nbsp; 
      <asp:CheckBox ID="chkHgarden" runat="server" Text="Gardening / Landscaping" /> &nbsp; 
  <asp:CheckBox ID="chkHplaymusic" runat="server" Text="Playing Musical Instruments" /> &nbsp; 
   <br /> <asp:TextBox ID="txtHobby" runat="server" CssClass="form-control" placeholder="Other"></asp:TextBox>
   </div></div>
 </div>
  <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Favourite  Music </span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">         
     
        <asp:CheckBox ID="chkfilmy" runat="server" Text="Film songs" /> &nbsp; 
        <asp:CheckBox ID="chkIndianclassic" runat="server" Text="Indian / Classical Music" /> &nbsp; 
        <asp:CheckBox ID="chkWestern" runat="server" Text="Western Music" /> &nbsp; 
      <br />  <asp:TextBox ID="txtFmusic" runat="server" CssClass="form-control" placeholder="Other" ></asp:TextBox>
      </div>
   </div></div>
 <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Favourite destination </span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group"> 
    
        <asp:TextBox ID="txtFavDestination" runat="server" CssClass="form-control" ></asp:TextBox>
       </div></div>

 </div>
                    <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Favourite book  </span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group"> 

        <asp:TextBox ID="txtFavBook" runat="server" CssClass="form-control" ></asp:TextBox>
</div></div>
</div>
 <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Favourite  author </span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group"> 
   
        <asp:TextBox ID="txtFavAuthor" runat="server" CssClass="form-control" ></asp:TextBox>
       </div></div>
 </div>
                    <div class="row"> 
                         <div class="col-md-4"> 
                                
                             </div> 
                      <div class="col-md-8">
             <div class="form-group"> 
        <asp:Button ID="btnLifeStyleSave" runat="server" Text="Save"   CssClass="loginbtn"   onclick="btnLifeStyleSave_Click" />
      </div></div>

                    </div>
                   </div></div></div></div></div></div>
  </div></div>
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
