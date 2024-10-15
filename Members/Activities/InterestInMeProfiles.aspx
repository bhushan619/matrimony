<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="InterestInMeProfiles.aspx.cs" Inherits="members_Activities_InterestInMeProfiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony | Interested In Me Profiles</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
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
     <script src="../../js/bootstrap.js"></script>
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
					<a href="Home.aspx"><img src="../../images/lo.png" alt=""/></a>  
				</div> 
                  <div class="logoutdiv">  
 <asp:LinkButton ID="lnkLogout" CssClass="logout" runat="server" OnClick="lnkLogout_Click" 
   ></asp:LinkButton>  
                </div>
                  <div class="notif">
                      <div class="icon-wrapper">
<a href="Notification.aspx"> <i class="fa fa-bell-o fa-2x iconcolor"></i>
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
                                <li  ><a href="VisitorsProfile.aspx">Who viewed my profile</a></li>
                                <li ><a href="ViewedProfile.aspx">Profiles I viewed</a></li> 
                                <li ><a href="ShortlistedProfile.aspx">Shortlisted profile</a></li>
                                 <li ><a href="WhoShortlistedMyProfile.aspx">Who Shortlisted me</a></li>
                                <li ><a href="InterestedInProfile.aspx">Interested In profile</a></li>                               
	                            <li ><a href="InterestInMeProfiles.aspx">Interested In Me</a></li>
	                            </ul>
						</li>	
                        	<li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Message&nbsp;<span class="badge"><asp:Label ID="lblcountfinalmsg" runat="server" Text="0"></asp:Label></span><b class="caret"></b></a>
                              <ul class="dropdown-menu">
                                <li ><a href="../Message/Inbox.aspx">Recieved </a></li>                             
                                <li ><a href="../Message/Send.aspx">Sent</a></li>   
                                  <li ><a href="../Message/Request.aspx">Requests</a></li> 
                                <li ><a href="../Activities/Notification.aspx">Notification</a></li>
                        
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
                                <li ><a href="faq.aspx">FAQ</a></li>                         
                                          
	                            </ul>
                        	</li> 
      </ul>
   </div>
</nav>
						
				 
				<div class="clearfix"> </div>
			 
		</div>
   
      <div class="franchisee">
	<div class="container">		      
               <div class="col-lg-8">
    <h3>    Interested In My Profile </h3>    <div class="borsolid"></div>  
                   <span class="j10font"> The members that are Interested In you displayed here.</span>    <br /> 
                
                <div class="bsideright" >   
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstViewedProfiles" PageSize="10">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                    </Fields>
                </asp:DataPager>
                    </div>   
                   <br />

        <asp:ListView ID="lstViewedProfiles" runat="server" OnPagePropertiesChanging="OnPagePropertiesChanging"
             GroupPlaceholderID="groupPlaceHolder1">
              <EmptyDataTemplate>
                <div class="well"><span>No  Profiles Found.</span></div>  
            </EmptyDataTemplate> 
 <ItemTemplate>
     <div style="border: 1px solid #dfdfdf; background-image: url('../../images/pat.jpg');   padding: 0px 15px 5px;    margin-top: 10px;" >
          <div class="row j10fontAbout " >
         <div class="col-lg-12" >
             <div class="row "> 
                   <br />
                 <div class="col-lg-8 ">
                     <div class="jsideleft">  &nbsp; <asp:Label ID="Label10" runat="server" Text='<%# Eval("IntersestMemName") %>' Font-Bold="true" Font-Size="17px"/>  ( <asp:LinkButton ID="lblCollege" runat="server"    CommandArgument='<%# Eval("IntersestMemId") %>'   OnClick="OpenProfile" Text='<%# Eval("IntersestMemId") %>' Font-Bold="true" Font-Size="17px"></asp:LinkButton> )
  &nbsp;&nbsp; <asp:LinkButton ID="lblname" runat="server"  CssClass="label label-success"     CommandArgument='<%# Eval("IntersestMemId") %>' OnClick="OpenProfile" Text='<%# Eval("IntersestMemPackage") %>'></asp:LinkButton>&nbsp;&nbsp;
   <%--  Shown Interest On: <asp:Label ID="Label7" runat="server" Text='<%# Eval("IntersestMemDate") %>' />&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;--%>
 </div> </div> 
   <div class="col-lg-4 "> 
       <div class="jsideright">
            <asp:LinkButton ID="LinkButton2" runat="server"    CommandArgument='<%# Eval("IntersestMemId") %>'   OnClick="OpenProfile" Text="View  Profile"></asp:LinkButton> <br />
    <br /></div> </div>
             </div>
   <div class="col-lg-2 bsideleft" >
        <asp:ImageButton ID="imgSimilarPic"  runat="server"   CssClass="img-thumbnail" Height="110px" Width="110px" OnClick="imgmember_Click"      CommandArgument='<%# Eval("IntersestMemId")+";"+Eval("IntersestMemPhoto") %>'    ImageUrl='<%# "~/members/media/" + Eval("IntersestMemPhoto") %>' /> 
          
      </div>
   
              <div class="col-lg-3 " > <div >
                   Shown Interest On:<br /> <asp:Label ID="Label7" runat="server" Text='<%# Eval("IntersestMemDate") %>' /><br /><br />
    About <asp:Label ID="Label11" runat="server" Text='<%# Eval("IntersestMemAccFor") %>' />: 
  <p class="j10fontAbout"> <asp:Label ID="lblDescription" runat="server"  Text='<%# Limit(Eval("IntersestMemAbout"),60) %>'   Tooltip='<%# Eval("IntersestMemAbout") %>'>      </asp:Label>
  <br /> <asp:LinkButton ID="ReadMoreLinkButton" runat="server"    Text="..Read More"  CommandArgument='<%# Eval("IntersestMemId") %>'       OnClick="OpenProfile">      </asp:LinkButton>
 </p>  </div>
                  </div>
<div class="col-lg-7" >
Profile Created For <asp:Label ID="Label9" runat="server" Text='<%# Eval("IntersestMemAccFor") %>' />  <br /> 
Age,Height :<asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("IntersestMemAge") %>' />,
   <asp:Label ID="HeightLabel" runat="server" Text='<%# Eval("IntersestMemHeight") %>' />/ 
           <asp:Label ID="Label6" runat="server" Text='<%# Eval("IntersestMemHeightcm") %>' />, <br />  
Religion :    <asp:Label ID="ReligionLabel" runat="server" Text='<%# Eval("IntersestMemReligion") %>' /><br /> 
 Caste :     <asp:Label ID="CasteLabel" runat="server" Text='<%# Eval("IntersestMemCaste") %>' /> <br /> 
 Subcaste :     <asp:Label ID="Label5" runat="server" Text='<%# Eval("IntersestMemSCaste") %>' />  <br /> 
  Location : <asp:Label ID="Label3" runat="server" Text='<%# Eval("IntersestMemCity") %>' />,  
       <asp:Label ID="Label2" runat="server" Text='<%# Eval("IntersestMemState") %>' /> ,
         <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("IntersestMemCountry") %>' />  <br />
 Education :   <asp:Label ID="EducationLabel" runat="server" Text='<%# Eval("IntersestMemEducation") %>' /> <br />
    Occupation :        <asp:Label ID="Label4" runat="server" Text='<%# Eval("IntersestMemOccupation") %>' />  <br />
  </div>    
             </div>     
         </div> 
      <div class="row " >
   <div class="bordex"></div>  
          <div class="jsideright ">   
        <%--   <asp:LinkButton ID="LinkButton1" runat="server"    CommandArgument='<%# Eval("IntersestMemId") %>'  OnClick="OpenProfile" Text="View Full Profile"></asp:LinkButton>
             --%>
              <asp:LinkButton ID="lnkInterest" runat="server" OnClick="lnkInterest_Click"  CommandArgument='<%# Eval("IntersestMemId") %>' Text="Send Interest" class="btn btn-danger btn-xs"></asp:LinkButton> &nbsp;&nbsp;
        <asp:LinkButton ID="lnkShortlist" runat="server" onclick="lnkShortlist_Click"  CommandArgument='<%# Eval("IntersestMemId") %>' Text="Shortlist" class="btn btn-warning btn-xs"></asp:LinkButton>     
              
            </div></div>
      </div>   </ItemTemplate>
            <LayoutTemplate>  <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
            <div ID="itemPlaceholderContainer" runat="server"  >
                    <span runat="server" id="itemPlaceholder" />
                </div>
</LayoutTemplate>
        </asp:ListView>
        
      </div> 
          <div class="col-lg-1"></div>
               <div class="col-lg-3 jactivitylink">
                  
  <h4> Activity Profile Views</h4> 
                   <p><a href="ShortlistedProfile.aspx" runat="server">Profiles shortlisted by me</a></p><div class="jbottom"></div>
                    <p><a href="InterestedInProfile.aspx" runat="server">Profiles you interested </a></p><div class="jbottom"></div>
               
  
                    <p><a href="VisitorsProfile.aspx" runat="server">Who viewed my profile</a></p><div class="jbottom"></div>
                    <p><a href="WhoShortlistedMyProfile.aspx" runat="server">Who shortlisted my profile</a></p><div class="jbottom"></div>
                    <p><a href="InterestInMeProfiles.aspx" runat="server">Who interested in my profile</a></p><div class="jbottom"></div>
 <br />
                    <h5 class="btn-warning text-center">Your profile is <asp:Label ID="lblmyprofilecompletness" runat="server" Style=" color:white;" ></asp:Label>% complete</h5> 
                   <h4>Complete your profile quickly</h4>
                     <p><a class="fa fa-picture-o" href="~/Members/Photo/InfoUpload.aspx" runat="server">&nbsp;&nbsp;Add Photos</a></p><div class="jbottom"></div>
                     <p><a class="fa fa-graduation-cap" href="~/Members/UserProfile/Self/EditProfessionalDetails.aspx" runat="server">&nbsp;&nbsp;Add Educational Details</a></p><div class="jbottom"></div>
                                        <p><a class="fa fa-briefcase" href="~/Members/UserProfile/Self/EditProfessionalDetails.aspx" runat="server">&nbsp;&nbsp;Add Occupational Details</a></p><div class="jbottom"></div>
                                        <p><a  class="fa fa-users" href="~/Members/UserProfile/Self/EditReligiousDetails.aspx" runat="server">&nbsp;&nbsp;Add Religious Details</a></p><div class="jbottom"></div>
                                        <p><a  class="fa fa-phone" href="~/Members/UserProfile/Self/EditContactDetail.aspx" runat="server">&nbsp;&nbsp;Add Contact Details</a></p><div class="jbottom"></div>
                   <img src="../../images/Advertising.jpg" width="260px"  />                         
    </div> 
         <div id="InterestListview" runat="server"> 
<asp:ListView ID="lstviewedProfile" runat="server" >  
           
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
             
        </asp:ListView>
        </div>
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
<%--        <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/members/Activities/Notification.aspx" ToolTip="Notification" runat="server" CssClass="notif"> </asp:HyperLink>
<asp:Image ID="imgMemberPhoto"  runat="server"  Height="50px" Width="50px"/>

       <br />
       <br />
     <asp:HyperLink ID="lblMemberName" runat="server" Text=""  NavigateUrl="~/Members/SearchMatches/Default.aspx"></asp:HyperLink>
   ( <asp:Label ID="lblMemberId" runat="server" Text=""></asp:Label>)
       <br />
    <asp:Label ID="Label13" runat="server" Text=" Account Type:"></asp:Label>
    <asp:Label ID="lblMembership" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
       <asp:HyperLink Text="Upgrade Now" runat="server" ID="lnkUpgrade" NavigateUrl="~/members/Subscription/ViewPackage.aspx"></asp:HyperLink>
        <asp:Label ID="lblmemUpgrade" runat="server" Text="" ForeColor="#2C2CFE"></asp:Label>
        <hr />
<asp:ListView ID="lstView" runat="server" DataSourceID="SqlDataSourceInterested">
           
            <EmptyDataTemplate>
                <span>No data was returned.</span>
            </EmptyDataTemplate>
        
            <ItemTemplate>
                <span style="">varInterestOfId:
                <asp:Label ID="varInterestOfIdLabel" runat="server" Text='<%# Eval("varInterestInId") %>' />
                <br />
                varMemberName:
                <asp:Label ID="varMemberNameLabel" runat="server" Text='<%# Eval("varMemberName") %>' />
                <br />
<br /></span>
            </ItemTemplate>
            <LayoutTemplate>
                <div id="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
                <div style="">
                </div>
            </LayoutTemplate>
           
        </asp:ListView>
        <asp:SqlDataSource ID="SqlDataSourceInterested" runat="server" 
            ConnectionString="<%$ ConnectionStrings:matrimonyConnectionString %>"
             ProviderName="<%$ ConnectionStrings:matrimonyConnectionString.ProviderName %>"
            ></asp:SqlDataSource>--%>