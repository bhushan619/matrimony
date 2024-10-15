<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="EditPhysicalDetails.aspx.cs" Inherits="members_UserProfile_Self_EditPhysicalDetails" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony | Physical Details</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../../images/favicon.ico" type="image/x-icon" />
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
                <a href="EditPhysicalDetails.aspx" class="list-group-item active">
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
   <li><a href= "EditPhysicalDetails.aspx">Edit Physical Details</a></li>
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
    <div class="col-md-4">  
        <asp:DropDownList ID="ddlHeighFtIn" runat="server" AutoPostBack="true" CssClass="form-control"
         required="required" OnSelectedIndexChanged="ddlHeighFtIn_SelectedIndexChanged"  >
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
        <asp:ListItem >7ft</asp:ListItem> 

        </asp:DropDownList></div>
     <div class="col-md-4">      <asp:DropDownList ID="ddlHeightCms" runat="server" AutoPostBack="true" CssClass="form-control"
  required="required" OnSelectedIndexChanged="ddlHeightCms_SelectedIndexChanged">
         <asp:ListItem Value="0"></asp:ListItem>
<asp:ListItem>137Cms</asp:ListItem>
<asp:ListItem>138Cms</asp:ListItem>
<asp:ListItem>139Cms</asp:ListItem>
<asp:ListItem>140Cms</asp:ListItem>
<asp:ListItem>141Cms</asp:ListItem>
<asp:ListItem>142Cms</asp:ListItem>
<asp:ListItem>143Cms</asp:ListItem>
<asp:ListItem>144Cms</asp:ListItem>
<asp:ListItem>145Cms</asp:ListItem>
<asp:ListItem>146Cms</asp:ListItem>
<asp:ListItem>147Cms</asp:ListItem>
<asp:ListItem>148Cms</asp:ListItem>
<asp:ListItem>149Cms</asp:ListItem>
<asp:ListItem>150Cms</asp:ListItem>
<asp:ListItem>151Cms</asp:ListItem>
<asp:ListItem>152Cms</asp:ListItem>
<asp:ListItem>153Cms</asp:ListItem>
<asp:ListItem>154Cms</asp:ListItem>
<asp:ListItem>155Cms</asp:ListItem>
<asp:ListItem>156Cms</asp:ListItem>
<asp:ListItem>157Cms</asp:ListItem>
<asp:ListItem>158Cms</asp:ListItem>
<asp:ListItem>159Cms</asp:ListItem>
<asp:ListItem>160Cms</asp:ListItem>
<asp:ListItem>161Cms</asp:ListItem>
<asp:ListItem>162Cms</asp:ListItem>
<asp:ListItem>163Cms</asp:ListItem>
<asp:ListItem>164Cms</asp:ListItem>
<asp:ListItem>165Cms</asp:ListItem>
<asp:ListItem>166Cms</asp:ListItem>
<asp:ListItem>167Cms</asp:ListItem>
<asp:ListItem>168Cms</asp:ListItem>
<asp:ListItem>169Cms</asp:ListItem>
<asp:ListItem>170Cms</asp:ListItem>
<asp:ListItem>171Cms</asp:ListItem>
<asp:ListItem>172Cms</asp:ListItem>
<asp:ListItem>173Cms</asp:ListItem>
<asp:ListItem>174Cms</asp:ListItem>
<asp:ListItem>175Cms</asp:ListItem>
<asp:ListItem>176Cms</asp:ListItem>
<asp:ListItem>177Cms</asp:ListItem>
<asp:ListItem>178Cms</asp:ListItem>
<asp:ListItem>179Cms</asp:ListItem>
<asp:ListItem>180Cms</asp:ListItem>
<asp:ListItem>181Cms</asp:ListItem>
<asp:ListItem>182Cms</asp:ListItem>
<asp:ListItem>183Cms</asp:ListItem>
<asp:ListItem>184Cms</asp:ListItem>
<asp:ListItem>185Cms</asp:ListItem>
<asp:ListItem>186Cms</asp:ListItem>
<asp:ListItem>187Cms</asp:ListItem>
<asp:ListItem>188Cms</asp:ListItem>
<asp:ListItem>189Cms</asp:ListItem>
<asp:ListItem>190Cms</asp:ListItem>
<asp:ListItem>191Cms</asp:ListItem>
<asp:ListItem>192Cms</asp:ListItem>
<asp:ListItem>193Cms</asp:ListItem>
<asp:ListItem>194Cms</asp:ListItem>
<asp:ListItem>195Cms</asp:ListItem>
<asp:ListItem>196Cms</asp:ListItem>
<asp:ListItem>197Cms</asp:ListItem>
<asp:ListItem>198Cms</asp:ListItem>
<asp:ListItem>199Cms</asp:ListItem>
<asp:ListItem>200Cms</asp:ListItem>
<asp:ListItem>201Cms</asp:ListItem>
<asp:ListItem>202Cms</asp:ListItem>
<asp:ListItem>203Cms</asp:ListItem>
<asp:ListItem>204Cms</asp:ListItem>
<asp:ListItem>205Cms</asp:ListItem>
<asp:ListItem>206Cms</asp:ListItem>
<asp:ListItem>207Cms</asp:ListItem>
<asp:ListItem>208Cms</asp:ListItem>
<asp:ListItem>209Cms</asp:ListItem>
<asp:ListItem>210Cms</asp:ListItem>
<asp:ListItem>211Cms</asp:ListItem>
<asp:ListItem>212Cms</asp:ListItem>
<asp:ListItem>213Cms</asp:ListItem>

        </asp:DropDownList></div>
        </div>
              
    <div class="col-md-4"> </div>
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
    <div class="col-md-4">
        <asp:DropDownList ID="ddlWeight" runat="server" required="required" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlWeight_SelectedIndexChanged">
        <asp:ListItem Value="">--Select Weight--</asp:ListItem>

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
        </asp:DropDownList>
        </div>
      <%--      <div class="col-md-2"> In Lbs</div>--%>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlWeightLbs" runat="server" CssClass="form-control" required="required" OnSelectedIndexChanged="ddlWeightLbs_SelectedIndexChanged" AutoPostBack="true">
                              <asp:ListItem Value="">--Lbs--</asp:ListItem>  
                              <asp:ListItem>91Lbs</asp:ListItem>
<asp:ListItem>93Lbs</asp:ListItem>
<asp:ListItem>94Lbs</asp:ListItem>
<asp:ListItem>95Lbs</asp:ListItem>
<asp:ListItem>96Lbs</asp:ListItem>
<asp:ListItem>97Lbs</asp:ListItem>
<asp:ListItem>98Lbs</asp:ListItem>
<asp:ListItem>99Lbs</asp:ListItem>
<asp:ListItem>100Lbs</asp:ListItem>
<asp:ListItem>101Lbs</asp:ListItem>
<asp:ListItem>102Lbs</asp:ListItem>
<asp:ListItem>103Lbs</asp:ListItem>
<asp:ListItem>104Lbs</asp:ListItem>
<asp:ListItem>105Lbs</asp:ListItem>
<asp:ListItem>106Lbs</asp:ListItem>
<asp:ListItem>107Lbs</asp:ListItem>
<asp:ListItem>108Lbs</asp:ListItem>
<asp:ListItem>109Lbs</asp:ListItem>
<asp:ListItem>110Lbs</asp:ListItem>
<asp:ListItem>111Lbs</asp:ListItem>
<asp:ListItem>112Lbs</asp:ListItem>
<asp:ListItem>113Lbs</asp:ListItem>
<asp:ListItem>114Lbs</asp:ListItem>
<asp:ListItem>115Lbs</asp:ListItem>
<asp:ListItem>116Lbs</asp:ListItem>
<asp:ListItem>117Lbs</asp:ListItem>
<asp:ListItem>118Lbs</asp:ListItem>
<asp:ListItem>119Lbs</asp:ListItem>
<asp:ListItem>120Lbs</asp:ListItem>
<asp:ListItem>121Lbs</asp:ListItem>
<asp:ListItem>122Lbs</asp:ListItem>
<asp:ListItem>123Lbs</asp:ListItem>
<asp:ListItem>124Lbs</asp:ListItem>
<asp:ListItem>125Lbs</asp:ListItem>
<asp:ListItem>126Lbs</asp:ListItem>
<asp:ListItem>127Lbs</asp:ListItem>
<asp:ListItem>128Lbs</asp:ListItem>
<asp:ListItem>129Lbs</asp:ListItem>
<asp:ListItem>130Lbs</asp:ListItem>
<asp:ListItem>131Lbs</asp:ListItem>
<asp:ListItem>132Lbs</asp:ListItem>
<asp:ListItem>133Lbs</asp:ListItem>
<asp:ListItem>134Lbs</asp:ListItem>
<asp:ListItem>135Lbs</asp:ListItem>
<asp:ListItem>136Lbs</asp:ListItem>
<asp:ListItem>137Lbs</asp:ListItem>
<asp:ListItem>138Lbs</asp:ListItem>
<asp:ListItem>139Lbs</asp:ListItem>
<asp:ListItem>140Lbs</asp:ListItem>
<asp:ListItem>141Lbs</asp:ListItem>
<asp:ListItem>142Lbs</asp:ListItem>
<asp:ListItem>143Lbs</asp:ListItem>
<asp:ListItem>144Lbs</asp:ListItem>
<asp:ListItem>145Lbs</asp:ListItem>
<asp:ListItem>146Lbs</asp:ListItem>
<asp:ListItem>147Lbs</asp:ListItem>
<asp:ListItem>148Lbs</asp:ListItem>
<asp:ListItem>149Lbs</asp:ListItem>
<asp:ListItem>150Lbs</asp:ListItem>
<asp:ListItem>151Lbs</asp:ListItem>
<asp:ListItem>152Lbs</asp:ListItem>
<asp:ListItem>153Lbs</asp:ListItem>
<asp:ListItem>154Lbs</asp:ListItem>
<asp:ListItem>155Lbs</asp:ListItem>
<asp:ListItem>156Lbs</asp:ListItem>
<asp:ListItem>157Lbs</asp:ListItem>
<asp:ListItem>158Lbs</asp:ListItem>
<asp:ListItem>159Lbs</asp:ListItem>
<asp:ListItem>160Lbs</asp:ListItem>
<asp:ListItem>161Lbs</asp:ListItem>
<asp:ListItem>162Lbs</asp:ListItem>
<asp:ListItem>163Lbs</asp:ListItem>
<asp:ListItem>164Lbs</asp:ListItem>
<asp:ListItem>165Lbs</asp:ListItem>
<asp:ListItem>166Lbs</asp:ListItem>
<asp:ListItem>167Lbs</asp:ListItem>
<asp:ListItem>168Lbs</asp:ListItem>
<asp:ListItem>169Lbs</asp:ListItem>
<asp:ListItem>170Lbs</asp:ListItem>
<asp:ListItem>171Lbs</asp:ListItem>
<asp:ListItem>172Lbs</asp:ListItem>
<asp:ListItem>173Lbs</asp:ListItem>
<asp:ListItem>174Lbs</asp:ListItem>
<asp:ListItem>175Lbs</asp:ListItem>
<asp:ListItem>176Lbs</asp:ListItem>
<asp:ListItem>177Lbs</asp:ListItem>
<asp:ListItem>178Lbs</asp:ListItem>
<asp:ListItem>179Lbs</asp:ListItem>
<asp:ListItem>180Lbs</asp:ListItem>
<asp:ListItem>181Lbs</asp:ListItem>
<asp:ListItem>182Lbs</asp:ListItem>
<asp:ListItem>183Lbs</asp:ListItem>
<asp:ListItem>184Lbs</asp:ListItem>
<asp:ListItem>185Lbs</asp:ListItem>
<asp:ListItem>186Lbs</asp:ListItem>
<asp:ListItem>187Lbs</asp:ListItem>
<asp:ListItem>188Lbs</asp:ListItem>
<asp:ListItem>189Lbs</asp:ListItem>
<asp:ListItem>190Lbs</asp:ListItem>
<asp:ListItem>191Lbs</asp:ListItem>
<asp:ListItem>192Lbs</asp:ListItem>
<asp:ListItem>193Lbs</asp:ListItem>
<asp:ListItem>194Lbs</asp:ListItem>
<asp:ListItem>195Lbs</asp:ListItem>
<asp:ListItem>196Lbs</asp:ListItem>
<asp:ListItem>197Lbs</asp:ListItem>
<asp:ListItem>198Lbs</asp:ListItem>
<asp:ListItem>199Lbs</asp:ListItem>
<asp:ListItem>200Lbs</asp:ListItem>
<asp:ListItem>201Lbs</asp:ListItem>
<asp:ListItem>202Lbs</asp:ListItem>
<asp:ListItem>203Lbs</asp:ListItem>
<asp:ListItem>204Lbs</asp:ListItem>
<asp:ListItem>205Lbs</asp:ListItem>
<asp:ListItem>206Lbs</asp:ListItem>
<asp:ListItem>207Lbs</asp:ListItem>
<asp:ListItem>208Lbs</asp:ListItem>
<asp:ListItem>209Lbs</asp:ListItem>
<asp:ListItem>210Lbs</asp:ListItem>
<asp:ListItem>211Lbs</asp:ListItem>
<asp:ListItem>212Lbs</asp:ListItem>
<asp:ListItem>213Lbs</asp:ListItem>
<asp:ListItem>214Lbs</asp:ListItem>
<asp:ListItem>215Lbs</asp:ListItem>
<asp:ListItem>216Lbs</asp:ListItem>
<asp:ListItem>217Lbs</asp:ListItem>
<asp:ListItem>218Lbs</asp:ListItem>
<asp:ListItem>219Lbs</asp:ListItem>
<asp:ListItem>220Lbs</asp:ListItem>
<asp:ListItem>221Lbs</asp:ListItem>
<asp:ListItem>222Lbs</asp:ListItem>
<asp:ListItem>223Lbs</asp:ListItem>
<asp:ListItem>224Lbs</asp:ListItem>
<asp:ListItem>225Lbs</asp:ListItem>
<asp:ListItem>226Lbs</asp:ListItem>
<asp:ListItem>227Lbs</asp:ListItem>
<asp:ListItem>228Lbs</asp:ListItem>
<asp:ListItem>229Lbs</asp:ListItem>
<asp:ListItem>230Lbs</asp:ListItem>
<asp:ListItem>231Lbs</asp:ListItem>
<asp:ListItem>232Lbs</asp:ListItem>
<asp:ListItem>233Lbs</asp:ListItem>
<asp:ListItem>234Lbs</asp:ListItem>
<asp:ListItem>235Lbs</asp:ListItem>
<asp:ListItem>236Lbs</asp:ListItem>
<asp:ListItem>237Lbs</asp:ListItem>
<asp:ListItem>238Lbs</asp:ListItem>
<asp:ListItem>239Lbs</asp:ListItem>
<asp:ListItem>240Lbs</asp:ListItem>
<asp:ListItem>241Lbs</asp:ListItem>
<asp:ListItem>242Lbs</asp:ListItem>
<asp:ListItem>243Lbs</asp:ListItem>
<asp:ListItem>244Lbs</asp:ListItem>
<asp:ListItem>245Lbs</asp:ListItem>
<asp:ListItem>246Lbs</asp:ListItem>
<asp:ListItem>247Lbs</asp:ListItem>
<asp:ListItem>248Lbs</asp:ListItem>
<asp:ListItem>249Lbs</asp:ListItem>
<asp:ListItem>250Lbs</asp:ListItem>
<asp:ListItem>251Lbs</asp:ListItem>
<asp:ListItem>252Lbs</asp:ListItem>
<asp:ListItem>253Lbs</asp:ListItem>
<asp:ListItem>254Lbs</asp:ListItem>
<asp:ListItem>255Lbs</asp:ListItem>
<asp:ListItem>256Lbs</asp:ListItem>
<asp:ListItem>257Lbs</asp:ListItem>
<asp:ListItem>258Lbs</asp:ListItem>
<asp:ListItem>259Lbs</asp:ListItem>
<asp:ListItem>260Lbs</asp:ListItem>
<asp:ListItem>261Lbs</asp:ListItem>
<asp:ListItem>262Lbs</asp:ListItem>
<asp:ListItem>263Lbs</asp:ListItem>
<asp:ListItem>264Lbs</asp:ListItem>
<asp:ListItem>265Lbs</asp:ListItem>
<asp:ListItem>266Lbs</asp:ListItem>
<asp:ListItem>267Lbs</asp:ListItem>
<asp:ListItem>268Lbs</asp:ListItem>
<asp:ListItem>269Lbs</asp:ListItem>
<asp:ListItem>270Lbs</asp:ListItem>
<asp:ListItem>271Lbs</asp:ListItem>
<asp:ListItem>272Lbs</asp:ListItem>
<asp:ListItem>273Lbs</asp:ListItem>
<asp:ListItem>274Lbs</asp:ListItem>
<asp:ListItem>275Lbs</asp:ListItem>
<asp:ListItem>276Lbs</asp:ListItem>
<asp:ListItem>277Lbs</asp:ListItem>
<asp:ListItem>278Lbs</asp:ListItem>
<asp:ListItem>279Lbs</asp:ListItem>
<asp:ListItem>280Lbs</asp:ListItem>
<asp:ListItem>281Lbs</asp:ListItem>
<asp:ListItem>282Lbs</asp:ListItem>
<asp:ListItem>283Lbs</asp:ListItem>
<asp:ListItem>284Lbs</asp:ListItem>
<asp:ListItem>285Lbs</asp:ListItem>
<asp:ListItem>286Lbs</asp:ListItem>
<asp:ListItem>287Lbs</asp:ListItem>
<asp:ListItem>288Lbs</asp:ListItem>
<asp:ListItem>289Lbs</asp:ListItem>
<asp:ListItem>290Lbs</asp:ListItem>
<asp:ListItem>291Lbs</asp:ListItem>
<asp:ListItem>292Lbs</asp:ListItem>
<asp:ListItem>293Lbs</asp:ListItem>
<asp:ListItem>294Lbs</asp:ListItem>
<asp:ListItem>295Lbs</asp:ListItem>
<asp:ListItem>296Lbs</asp:ListItem>
<asp:ListItem>297Lbs</asp:ListItem>
<asp:ListItem>298Lbs</asp:ListItem>
<asp:ListItem>299Lbs</asp:ListItem>
<asp:ListItem>300Lbs</asp:ListItem>

                          </asp:DropDownList>
                    </div></div>
      </div></div></div>
                       <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Bloodgroup</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group"> 
       
          <asp:DropDownList ID="ddlBloodgroup" runat="server" required="required" AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem Value="">--Select Bloodgroup--</asp:ListItem>
          <asp:ListItem>A+</asp:ListItem>
<asp:ListItem>A-</asp:ListItem>
<asp:ListItem>B+</asp:ListItem>
<asp:ListItem>B-</asp:ListItem>
<asp:ListItem>AB+</asp:ListItem>
<asp:ListItem>AB-</asp:ListItem>
<asp:ListItem>O+</asp:ListItem>
<asp:ListItem>O-</asp:ListItem>	

        </asp:DropDownList>
        </div></div></div>
                       <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Bodytype</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group"> 
    
            <asp:RadioButton    ID="rgbBTSlim" runat="server" Text="Slim"  GroupName="rgbBodyType" />
      &nbsp;&nbsp;  <asp:RadioButton ID="rgbBTAverage" runat="server" Text="Average"  GroupName="rgbBodyType"/>
      &nbsp;&nbsp;  <asp:RadioButton ID="rgbBTAthletic" runat="server" Text="Athletic" GroupName="rgbBodyType"/>
      &nbsp;&nbsp;  <asp:RadioButton ID="rgbBTHeavy" runat="server" Text="Heavy" GroupName="rgbBodyType"/>
        </div></div></div>

                       <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Complexion</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group"> 
      
        <asp:RadioButton ID="rgbFair" runat="server" Text="Fair"  GroupName="rgbComplexion"/>
         &nbsp;&nbsp;         <asp:RadioButton ID="rgbVeryFair" runat="server" Text="Very Fair"  GroupName="rgbComplexion"/>     
     &nbsp;&nbsp;   <asp:RadioButton ID="rgbWheatish" runat="server" Text="Wheatish" GroupName="rgbComplexion"/>
     &nbsp;&nbsp;   <asp:RadioButton ID="rgbWheatishMedium" runat="server" Text="Wheatish Medium" GroupName="rgbComplexion"/>
      &nbsp;&nbsp;   <asp:RadioButton ID="rgbDark" runat="server" Text="Dark" GroupName="rgbComplexion"/>
      </div></div></div>
                       <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Special Case</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group"> 
      
        <asp:DropDownList ID="ddlSpecialCase" runat="server" required="required" AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem Value="">--Select Special Case(if Any)--</asp:ListItem> 
 <asp:ListItem>None</asp:ListItem>
 <asp:ListItem>Does not Matter</asp:ListItem>
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
                   <asp:Button ID="btnPhysicalSave" runat="server" Text="Save"  CssClass="loginbtn"
             onclick="btnPhysicalSave_Click" />
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
