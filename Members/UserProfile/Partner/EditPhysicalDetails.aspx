<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="EditPhysicalDetails.aspx.cs" Inherits="members_UserProfile_Partner_EditPhysicalDetails" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony |  Lifestyle Details</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../../images/favicon.ico" type="image/x-icon" />
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
                                <li><a href="../Self/EditPersonalDetails.aspx">Edit MyProfile</a></li>
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
  <li ><a href="../Self/EditPersonalDetails.aspx"> Edit My Profile</a></li>
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
                <a href="EditPhysicalDetails.aspx" class="list-group-item active">
                   <i class="fa fa-heart"></i>    Physical Details
                </a>
                    <a href="EditProfessionalDetails.aspx" class="list-group-item">
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
            
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 bhoechie-tab">
             
                <div class="bhoechie-tab-content active">
                     <div class="row">  
                          <div class="col-md-12"> 
                 <ul class="breadcrumb text-left">
    <li>Edit Partner Profile</li>
   <li><a href= "EditLifeStyleDetails.aspx">Edit Partner Physical Details</a></li>
</ul>
		 </div>  </div> 
                    <div class="row">
                      
                        <div class="col-lg-12 text-left"> 
               <div class="col-md-10" >

                     <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Height</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">  
                  <div class="row">
                        <div class="col-md-5"> 
      
          <asp:DropDownList ID="ddlHeighFrom" runat="server"    required="required"  CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlHeighFrom_SelectedIndexChanged" >
<asp:ListItem Value="0">--Feet/Inches--</asp:ListItem>
            <asp:ListItem   >4ft 6in</asp:ListItem>
        <asp:ListItem   >4ft 7in</asp:ListItem>
        <asp:ListItem  >4ft 8in</asp:ListItem>
        <asp:ListItem >4ft 9in</asp:ListItem>
        <asp:ListItem  >4ft 10in</asp:ListItem>
        <asp:ListItem  >4ft 11in</asp:ListItem>
        <asp:ListItem >5ft</asp:ListItem>
        <asp:ListItem >5ft 1in</asp:ListItem>
        <asp:ListItem  >5ft 2in</asp:ListItem>
        <asp:ListItem >5ft 3in</asp:ListItem>
        <asp:ListItem  >5ft 4in</asp:ListItem>
        <asp:ListItem  >5ft 5in</asp:ListItem>
        <asp:ListItem >5ft 6in</asp:ListItem>
        <asp:ListItem >5ft 7in</asp:ListItem>
        <asp:ListItem  >5ft 8in</asp:ListItem>
        <asp:ListItem  >5ft 9in</asp:ListItem>
        <asp:ListItem >5ft 10in</asp:ListItem>
        <asp:ListItem  >5ft 11in</asp:ListItem>
        <asp:ListItem  >6ft</asp:ListItem>
        <asp:ListItem  >6ft 1in</asp:ListItem>
        <asp:ListItem  >6ft 2in</asp:ListItem>
        <asp:ListItem  >6ft 3in</asp:ListItem>
        <asp:ListItem >6ft 4in</asp:ListItem>
        <asp:ListItem  >6ft 5in</asp:ListItem>
        <asp:ListItem  >6ft 6in</asp:ListItem>
        <asp:ListItem >6ft 7in</asp:ListItem>
        <asp:ListItem >6ft 8in</asp:ListItem>
        <asp:ListItem  >6ft 9in</asp:ListItem>
        <asp:ListItem >6ft 10in</asp:ListItem>
        <asp:ListItem >6ft 11in</asp:ListItem>
       

        </asp:DropDownList>

        </div>
         <div class="col-md-1">    <asp:Label ID="Label39" runat="server" Text="To"></asp:Label></div>
         <div class="col-md-5"> 
        <asp:DropDownList ID="ddlHeighTo" runat="server" required="required" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlHeighTo_SelectedIndexChanged" >
<asp:ListItem Value="0">--Feet/Inches--</asp:ListItem>
           
        <asp:ListItem   >4ft 7in</asp:ListItem>
        <asp:ListItem  >4ft 8in</asp:ListItem>
        <asp:ListItem >4ft 9in</asp:ListItem>
        <asp:ListItem  >4ft 10in</asp:ListItem>
        <asp:ListItem  >4ft 11in</asp:ListItem>
        <asp:ListItem >5ft</asp:ListItem>
        <asp:ListItem >5ft 1in</asp:ListItem>
        <asp:ListItem  >5ft 2in</asp:ListItem>
        <asp:ListItem >5ft 3in</asp:ListItem>
        <asp:ListItem  >5ft 4in</asp:ListItem>
        <asp:ListItem  >5ft 5in</asp:ListItem>
        <asp:ListItem >5ft 6in</asp:ListItem>
        <asp:ListItem >5ft 7in</asp:ListItem>
        <asp:ListItem  >5ft 8in</asp:ListItem>
        <asp:ListItem  >5ft 9in</asp:ListItem>
        <asp:ListItem >5ft 10in</asp:ListItem>
        <asp:ListItem  >5ft 11in</asp:ListItem>
        <asp:ListItem  >6ft</asp:ListItem>
        <asp:ListItem  >6ft 1in</asp:ListItem>
        <asp:ListItem  >6ft 2in</asp:ListItem>
        <asp:ListItem  >6ft 3in</asp:ListItem>
        <asp:ListItem >6ft 4in</asp:ListItem>
        <asp:ListItem  >6ft 5in</asp:ListItem>
        <asp:ListItem  >6ft 6in</asp:ListItem>
        <asp:ListItem >6ft 7in</asp:ListItem>
        <asp:ListItem >6ft 8in</asp:ListItem>
        <asp:ListItem  >6ft 9in</asp:ListItem>
        <asp:ListItem >6ft 10in</asp:ListItem>
        <asp:ListItem >6ft 11in</asp:ListItem>
        <asp:ListItem >7ft</asp:ListItem> 

</asp:DropDownList>
        </div>
          

  </div>
           </div></div></div>
                      <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Weight</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">      
 <div class="row">
                        <div class="col-md-5"> 
        <asp:DropDownList ID="ddlWeightFrom" runat="server" CssClass="form-control">
        <asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>31Kg</asp:ListItem>
<asp:ListItem>32Kg</asp:ListItem>
<asp:ListItem>33Kg</asp:ListItem>
<asp:ListItem>34Kg</asp:ListItem>
<asp:ListItem>35Kg</asp:ListItem>
<asp:ListItem>36Kg</asp:ListItem>
<asp:ListItem>37Kg</asp:ListItem>
<asp:ListItem>38Kg</asp:ListItem>
<asp:ListItem>39Kg</asp:ListItem>
<asp:ListItem>40Kg</asp:ListItem>
<asp:ListItem>41Kg</asp:ListItem>
<asp:ListItem>42Kg</asp:ListItem>
<asp:ListItem>43Kg</asp:ListItem>
<asp:ListItem>44Kg</asp:ListItem>
<asp:ListItem>45Kg</asp:ListItem>
<asp:ListItem>46Kg</asp:ListItem>
<asp:ListItem>47Kg</asp:ListItem>
<asp:ListItem>48Kg</asp:ListItem>
<asp:ListItem>49Kg</asp:ListItem>
<asp:ListItem>50Kg</asp:ListItem>
<asp:ListItem>51Kg</asp:ListItem>
<asp:ListItem>52Kg</asp:ListItem>
<asp:ListItem>53Kg</asp:ListItem>
<asp:ListItem>54Kg</asp:ListItem>
<asp:ListItem>55Kg</asp:ListItem>
<asp:ListItem>56Kg</asp:ListItem>
<asp:ListItem>57Kg</asp:ListItem>
<asp:ListItem>58Kg</asp:ListItem>
<asp:ListItem>59Kg</asp:ListItem>
<asp:ListItem>60Kg</asp:ListItem>
<asp:ListItem>61Kg</asp:ListItem>
<asp:ListItem>62Kg</asp:ListItem>
<asp:ListItem>63Kg</asp:ListItem>
<asp:ListItem>64Kg</asp:ListItem>
<asp:ListItem>65Kg</asp:ListItem>
<asp:ListItem>66Kg</asp:ListItem>
<asp:ListItem>67Kg</asp:ListItem>
<asp:ListItem>68Kg</asp:ListItem>
<asp:ListItem>69Kg</asp:ListItem>
<asp:ListItem>70Kg</asp:ListItem>
<asp:ListItem>71Kg</asp:ListItem>
<asp:ListItem>72Kg</asp:ListItem>
<asp:ListItem>73Kg</asp:ListItem>
<asp:ListItem>74Kg</asp:ListItem>
<asp:ListItem>75Kg</asp:ListItem>
<asp:ListItem>76Kg</asp:ListItem>
<asp:ListItem>77Kg</asp:ListItem>
<asp:ListItem>78Kg</asp:ListItem>
<asp:ListItem>79Kg</asp:ListItem>
<asp:ListItem>80Kg</asp:ListItem>
<asp:ListItem>81Kg</asp:ListItem>
<asp:ListItem>82Kg</asp:ListItem>
<asp:ListItem>83Kg</asp:ListItem>
<asp:ListItem>84Kg</asp:ListItem>
<asp:ListItem>85Kg</asp:ListItem>
<asp:ListItem>86Kg</asp:ListItem>
<asp:ListItem>87Kg</asp:ListItem>
<asp:ListItem>88Kg</asp:ListItem>
<asp:ListItem>89Kg</asp:ListItem>
<asp:ListItem>90Kg</asp:ListItem>
<asp:ListItem>91Kg</asp:ListItem>
<asp:ListItem>92Kg</asp:ListItem>
<asp:ListItem>93Kg</asp:ListItem>
<asp:ListItem>94Kg</asp:ListItem>
<asp:ListItem>95Kg</asp:ListItem>
<asp:ListItem>96Kg</asp:ListItem>
<asp:ListItem>97Kg</asp:ListItem>
<asp:ListItem>98Kg</asp:ListItem>
<asp:ListItem>99Kg</asp:ListItem>
<asp:ListItem>100Kg</asp:ListItem>
<asp:ListItem>101Kg</asp:ListItem>
<asp:ListItem>102Kg</asp:ListItem>
<asp:ListItem>103Kg</asp:ListItem>
<asp:ListItem>104Kg</asp:ListItem>
<asp:ListItem>105Kg</asp:ListItem>
<asp:ListItem>106Kg</asp:ListItem>
<asp:ListItem>107Kg</asp:ListItem>
<asp:ListItem>108Kg</asp:ListItem>
<asp:ListItem>109Kg</asp:ListItem>
<asp:ListItem>110Kg</asp:ListItem>
<asp:ListItem>111Kg</asp:ListItem>
<asp:ListItem>112Kg</asp:ListItem>
<asp:ListItem>113Kg</asp:ListItem>
<asp:ListItem>114Kg</asp:ListItem>
<asp:ListItem>115Kg</asp:ListItem>
<asp:ListItem>116Kg</asp:ListItem>
<asp:ListItem>117Kg</asp:ListItem>
<asp:ListItem>118Kg</asp:ListItem>
<asp:ListItem>119Kg</asp:ListItem>
<asp:ListItem>120Kg</asp:ListItem>
<asp:ListItem>121Kg</asp:ListItem>
<asp:ListItem>122Kg</asp:ListItem>
<asp:ListItem>123Kg</asp:ListItem>
<asp:ListItem>124Kg</asp:ListItem>
<asp:ListItem>125Kg</asp:ListItem>
<asp:ListItem>126Kg</asp:ListItem>
<asp:ListItem>127Kg</asp:ListItem>
<asp:ListItem>128Kg</asp:ListItem>
<asp:ListItem>129Kg</asp:ListItem>
<asp:ListItem>130Kg</asp:ListItem>
<asp:ListItem>131Kg</asp:ListItem>
<asp:ListItem>132Kg</asp:ListItem>
<asp:ListItem>133Kg</asp:ListItem>
<asp:ListItem>134Kg</asp:ListItem>
<asp:ListItem>135Kg</asp:ListItem>
<asp:ListItem>136Kg</asp:ListItem>
<asp:ListItem>137Kg</asp:ListItem>
<asp:ListItem>138Kg</asp:ListItem>
<asp:ListItem>139Kg</asp:ListItem>
<asp:ListItem>140Kg</asp:ListItem>
<asp:ListItem>141Kg</asp:ListItem>
<asp:ListItem>142Kg</asp:ListItem>
<asp:ListItem>143Kg</asp:ListItem>
<asp:ListItem>144Kg</asp:ListItem>
<asp:ListItem>145Kg</asp:ListItem>
<asp:ListItem>146Kg</asp:ListItem>
<asp:ListItem>147Kg</asp:ListItem>
<asp:ListItem>148Kg</asp:ListItem>
<asp:ListItem>149Kg</asp:ListItem>
<asp:ListItem>150Kg</asp:ListItem>
        </asp:DropDownList>
                            </div>
      <div class="col-md-1">    <asp:Label ID="Label1" runat="server" Text="To"></asp:Label></div>
         <div class="col-md-5"> 
        <asp:DropDownList ID="ddlWeightTo" runat="server" CssClass="form-control">
        <asp:ListItem>Select</asp:ListItem>
            <asp:ListItem>31Kg</asp:ListItem>
<asp:ListItem>32Kg</asp:ListItem>
<asp:ListItem>33Kg</asp:ListItem>
<asp:ListItem>34Kg</asp:ListItem>
<asp:ListItem>35Kg</asp:ListItem>
<asp:ListItem>36Kg</asp:ListItem>
<asp:ListItem>37Kg</asp:ListItem>
<asp:ListItem>38Kg</asp:ListItem>
<asp:ListItem>39Kg</asp:ListItem>
<asp:ListItem>40Kg</asp:ListItem>
<asp:ListItem>41Kg</asp:ListItem>
<asp:ListItem>42Kg</asp:ListItem>
<asp:ListItem>43Kg</asp:ListItem>
<asp:ListItem>44Kg</asp:ListItem>
<asp:ListItem>45Kg</asp:ListItem>
<asp:ListItem>46Kg</asp:ListItem>
<asp:ListItem>47Kg</asp:ListItem>
<asp:ListItem>48Kg</asp:ListItem>
<asp:ListItem>49Kg</asp:ListItem>
<asp:ListItem>50Kg</asp:ListItem>
<asp:ListItem>51Kg</asp:ListItem>
<asp:ListItem>52Kg</asp:ListItem>
<asp:ListItem>53Kg</asp:ListItem>
<asp:ListItem>54Kg</asp:ListItem>
<asp:ListItem>55Kg</asp:ListItem>
<asp:ListItem>56Kg</asp:ListItem>
<asp:ListItem>57Kg</asp:ListItem>
<asp:ListItem>58Kg</asp:ListItem>
<asp:ListItem>59Kg</asp:ListItem>
<asp:ListItem>60Kg</asp:ListItem>
<asp:ListItem>61Kg</asp:ListItem>
<asp:ListItem>62Kg</asp:ListItem>
<asp:ListItem>63Kg</asp:ListItem>
<asp:ListItem>64Kg</asp:ListItem>
<asp:ListItem>65Kg</asp:ListItem>
<asp:ListItem>66Kg</asp:ListItem>
<asp:ListItem>67Kg</asp:ListItem>
<asp:ListItem>68Kg</asp:ListItem>
<asp:ListItem>69Kg</asp:ListItem>
<asp:ListItem>70Kg</asp:ListItem>
<asp:ListItem>71Kg</asp:ListItem>
<asp:ListItem>72Kg</asp:ListItem>
<asp:ListItem>73Kg</asp:ListItem>
<asp:ListItem>74Kg</asp:ListItem>
<asp:ListItem>75Kg</asp:ListItem>
<asp:ListItem>76Kg</asp:ListItem>
<asp:ListItem>77Kg</asp:ListItem>
<asp:ListItem>78Kg</asp:ListItem>
<asp:ListItem>79Kg</asp:ListItem>
<asp:ListItem>80Kg</asp:ListItem>
<asp:ListItem>81Kg</asp:ListItem>
<asp:ListItem>82Kg</asp:ListItem>
<asp:ListItem>83Kg</asp:ListItem>
<asp:ListItem>84Kg</asp:ListItem>
<asp:ListItem>85Kg</asp:ListItem>
<asp:ListItem>86Kg</asp:ListItem>
<asp:ListItem>87Kg</asp:ListItem>
<asp:ListItem>88Kg</asp:ListItem>
<asp:ListItem>89Kg</asp:ListItem>
<asp:ListItem>90Kg</asp:ListItem>
<asp:ListItem>91Kg</asp:ListItem>
<asp:ListItem>92Kg</asp:ListItem>
<asp:ListItem>93Kg</asp:ListItem>
<asp:ListItem>94Kg</asp:ListItem>
<asp:ListItem>95Kg</asp:ListItem>
<asp:ListItem>96Kg</asp:ListItem>
<asp:ListItem>97Kg</asp:ListItem>
<asp:ListItem>98Kg</asp:ListItem>
<asp:ListItem>99Kg</asp:ListItem>
<asp:ListItem>100Kg</asp:ListItem>
<asp:ListItem>101Kg</asp:ListItem>
<asp:ListItem>102Kg</asp:ListItem>
<asp:ListItem>103Kg</asp:ListItem>
<asp:ListItem>104Kg</asp:ListItem>
<asp:ListItem>105Kg</asp:ListItem>
<asp:ListItem>106Kg</asp:ListItem>
<asp:ListItem>107Kg</asp:ListItem>
<asp:ListItem>108Kg</asp:ListItem>
<asp:ListItem>109Kg</asp:ListItem>
<asp:ListItem>110Kg</asp:ListItem>
<asp:ListItem>111Kg</asp:ListItem>
<asp:ListItem>112Kg</asp:ListItem>
<asp:ListItem>113Kg</asp:ListItem>
<asp:ListItem>114Kg</asp:ListItem>
<asp:ListItem>115Kg</asp:ListItem>
<asp:ListItem>116Kg</asp:ListItem>
<asp:ListItem>117Kg</asp:ListItem>
<asp:ListItem>118Kg</asp:ListItem>
<asp:ListItem>119Kg</asp:ListItem>
<asp:ListItem>120Kg</asp:ListItem>
<asp:ListItem>121Kg</asp:ListItem>
<asp:ListItem>122Kg</asp:ListItem>
<asp:ListItem>123Kg</asp:ListItem>
<asp:ListItem>124Kg</asp:ListItem>
<asp:ListItem>125Kg</asp:ListItem>
<asp:ListItem>126Kg</asp:ListItem>
<asp:ListItem>127Kg</asp:ListItem>
<asp:ListItem>128Kg</asp:ListItem>
<asp:ListItem>129Kg</asp:ListItem>
<asp:ListItem>130Kg</asp:ListItem>
<asp:ListItem>131Kg</asp:ListItem>
<asp:ListItem>132Kg</asp:ListItem>
<asp:ListItem>133Kg</asp:ListItem>
<asp:ListItem>134Kg</asp:ListItem>
<asp:ListItem>135Kg</asp:ListItem>
<asp:ListItem>136Kg</asp:ListItem>
<asp:ListItem>137Kg</asp:ListItem>
<asp:ListItem>138Kg</asp:ListItem>
<asp:ListItem>139Kg</asp:ListItem>
<asp:ListItem>140Kg</asp:ListItem>
<asp:ListItem>141Kg</asp:ListItem>
<asp:ListItem>142Kg</asp:ListItem>
<asp:ListItem>143Kg</asp:ListItem>
<asp:ListItem>144Kg</asp:ListItem>
<asp:ListItem>145Kg</asp:ListItem>
<asp:ListItem>146Kg</asp:ListItem>
<asp:ListItem>147Kg</asp:ListItem>
<asp:ListItem>148Kg</asp:ListItem>
<asp:ListItem>149Kg</asp:ListItem>
<asp:ListItem>150Kg</asp:ListItem>
        </asp:DropDownList>
      </div></div>
</div></div></div>
         <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Bodytype</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group"> 
      
         <asp:DropDownList ID="ddlBtype" runat="server" CssClass="form-control">
         <asp:ListItem>Does Not Matter</asp:ListItem>
         <asp:ListItem>Slim</asp:ListItem>
         <asp:ListItem>Average</asp:ListItem>
         <asp:ListItem>Athletic</asp:ListItem>
         <asp:ListItem>Heavy</asp:ListItem>
                  </asp:DropDownList>
        </div></div></div>
                   <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Complexion</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group"> 
        <asp:Label ID="Label18" runat="server" Text=""></asp:Label>
        <%--<asp:RadioButton ID="rgbFair" runat="server" Text="Fair"  GroupName="rgbComplexion"/>
        <asp:RadioButton ID="rgbWheatish" runat="server" Text="Wheatish" GroupName="rgbComplexion"/>
        <asp:RadioButton ID="rgbWheatishMedium" runat="server" Text="Wheatish Medium" GroupName="rgbComplexion"/>
         <asp:RadioButton ID="rgbDark" runat="server" Text="Dark" GroupName="rgbComplexion"/>--%>
         <asp:DropDownList ID="ddlComplexion" runat="server" CssClass="form-control">
           <asp:ListItem>Does Not Matter</asp:ListItem>
             <asp:ListItem>Very Fair</asp:ListItem>
          <asp:ListItem>Fair</asp:ListItem>
           <asp:ListItem>Wheatish</asp:ListItem>
            <asp:ListItem>Wheatish Medium</asp:ListItem>
             <asp:ListItem>Dark</asp:ListItem>
         </asp:DropDownList>

       </div></div></div>
                   <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Special Case</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group"> 
 
        <asp:DropDownList ID="ddlSpecialCase" runat="server"  AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem Value="">Does not Matter</asp:ListItem>
 <asp:ListItem>None</asp:ListItem>
   <asp:ListItem>Physically challenged from birth</asp:ListItem> 
      <asp:ListItem>Hiv positive</asp:ListItem> 
 <asp:ListItem>Mentally challenged from birth</asp:ListItem>         
     <asp:ListItem>Accidental / Physical abnormality affecting only looks</asp:ListItem>
 <asp:ListItem>Physical abnormality affecting bodily functions due to accident</asp:ListItem>
 <asp:ListItem>Physically challenged due to accident</asp:ListItem>
 <asp:ListItem>Medically challenged condition of one or more vital organs</asp:ListItem>
        </asp:DropDownList>
        </div></div></div>
 <div class="row"> 
                         <div class="col-md-4"> 
                                 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group"> 
          <asp:Button ID="btnPhysicalSave" runat="server" Text="Save"    onclick="btnPhysicalSave_Click" CssClass="loginbtn"/>
      </div></div></div>
</div></div></div>
 </div></div></div>
 </div></div></div></div>
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
