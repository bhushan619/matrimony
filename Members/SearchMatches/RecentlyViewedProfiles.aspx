<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="RecentlyViewedProfiles.aspx.cs" Inherits="members_SearchMatches_RecentlyViewedProfiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony | search</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
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
<!-- animated-css -->
		<link href="../../css/animate.css" rel="stylesheet" type="text/css" media="all" />
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
                                <li ><a href="QuickSearch.aspx">Quick Search</a></li>
                                <li ><a href="AdvancedSearch.aspx">Advanced Search</a></li> 
                                <li ><a href="RecentlyViewedProfiles.aspx">Recently viewed profile</a></li>
                               
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
</nav><div class="clearfix"> </div>

         </div>
              
           <div class="franchisee">
	<div class="container">	
    <div class="col-lg-8">
    <h3>  Recently Viewed Profiles </h3> 
                      <div class="borsolid"></div>  
   <span class="j10font"> The members that you recently viewed are displayed here.</span> <br />
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
                 <div class="row j10fontAbout  " >
         <div class="col-lg-12" style="background-color: #fcf8e3 ;    border-color: #faebcc;">
             <div class="row "> 
                 <br />
                 <div class="col-lg-6 ">
                     <div class="jsideleft"> &nbsp;&nbsp;
             <asp:LinkButton ID="lblCollege" runat="server"    CommandArgument='<%# Eval("ViewMemId") %>'   OnClick="OpenProfile" Text='<%# Eval("ViewMemId") %>' Font-Bold="true" Font-Size="17px"></asp:LinkButton> 
  &nbsp; <asp:LinkButton ID="lblname" runat="server"  CssClass="label label-success"   CommandArgument='<%# Eval("ViewMemId") %>' OnClick="OpenProfile" Text='<%# Eval("ViewMemPackage") %>'></asp:LinkButton>&nbsp;&nbsp;
   
                         </div> </div> 
   <div class="col-lg-6 "> <%--<div class="jsideright">     
<asp:LinkButton ID="LinkButton2" runat="server"    CommandArgument='<%# Eval("ViewMemId") %>'  OnClick="OpenProfile" Text="View  Profile"></asp:LinkButton>
        </div>--%> </div>
             </div>
  
   <div class="col-lg-2 bsideleft" >
     <asp:ImageButton ID="imgSimilarPic" runat="server"  CssClass="img-rounded" Height="110px" Width="110px" OnClick="imgmember_Click"  CommandArgument='<%# Eval("ViewMemId") %>'        ImageUrl='<%# "~/members/media/" + Eval("ViewMemPhoto") %>' /> 
      </div>
   
              <div class="col-lg-3 " > <div >
   Viewed On: <asp:Label ID="Label7" runat="server" Text='<%# Eval("ViewMemDate") %>' /><br /><br />
 About <asp:Label ID="Label11" runat="server" Text='<%# Eval("ViewMemAccFor") %>' />: 
      <p class="j10fontAbout"> <asp:Label ID="lblDescription" runat="server"  Text='<%# Limit(Eval("ViewMemAbout"),60) %>'                 Tooltip='<%# Eval("ViewMemAbout") %>'>      </asp:Label>
    <br />  <asp:LinkButton ID="ReadMoreLinkButton" runat="server"   Text="Read More"  CommandArgument='<%# Eval("ViewMemId") %>'    OnClick="OpenProfile">    </asp:LinkButton>
 </p>  </div>
                  </div>
<div class="col-lg-7" >
Profile Created For <asp:Label ID="Label9" runat="server" Text='<%# Eval("ViewMemAccFor") %>' />,<br /> 
Name:<asp:Label ID="Label10" runat="server" Text='<%# Eval("ViewMemName") %>' /><br /> 
Age,Height :<asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("ViewMemAge") %>' />,
   <asp:Label ID="HeightLabel" runat="server" Text='<%# Eval("ViewMemHeight") %>' />/ 
           <asp:Label ID="Label6" runat="server" Text='<%# Eval("ViewMemHeightcm") %>' />, <br />  
Religion :    <asp:Label ID="ReligionLabel" runat="server" Text='<%# Eval("ViewMemReligion") %>' /><br /> 
 Caste :     <asp:Label ID="CasteLabel" runat="server" Text='<%# Eval("ViewMemCaste") %>' /> <br /> 
 Subcaste :     <asp:Label ID="Label5" runat="server" Text='<%# Eval("ViewMemSCaste") %>' />  <br /> 
  Location : <asp:Label ID="Label3" runat="server" Text='<%# Eval("ViewMemCity") %>' />,  
       <asp:Label ID="Label2" runat="server" Text='<%# Eval("ViewMemState") %>' /> ,
         <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("ViewMemCountry") %>' />  <br />
 Education :   <asp:Label ID="EducationLabel" runat="server" Text='<%# Eval("ViewMemEducation") %>' /> <br />
    Occupation :        <asp:Label ID="Label4" runat="server" Text='<%# Eval("ViewMemOccupation") %>' />  <br />
    </div>
               
             </div>                          
    
         </div> 
      <div class="row " style="background-color: #fcf8e3;margin-bottom: 7px;padding-bottom: 7px;     border-color: #faebcc;">
   <div class="bordex"></div>  
          <div class="jsideright "> 
           <asp:LinkButton ID="LinkButton1" runat="server"    CommandArgument='<%# Eval("ViewMemId") %>' OnClick="OpenProfile" Text="View Full Profile" class="btn btn-info btn-xs"></asp:LinkButton>&nbsp;&nbsp;
               <asp:LinkButton ID="lnkInterest" runat="server" OnClick="lnkInterest_Click"  CommandArgument='<%# Eval("ViewMemId") %>' Text="Send Interest" class="btn btn-danger btn-xs"></asp:LinkButton> &nbsp;&nbsp;
        <asp:LinkButton ID="lnkShortlist" runat="server" onclick="lnkShortlist_Click"  CommandArgument='<%# Eval("ViewMemId") %>' Text="Shortlist" class="btn btn-warning btn-xs"></asp:LinkButton>     
                       </div>
      </div>   
             
          </ItemTemplate>
            <LayoutTemplate>  <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
            <div ID="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
              
                
           
</LayoutTemplate>
        </asp:ListView>
    </div>    
    </div></div>
                       <div class="footer">
	<div class="container">
		
		<div class="copyright">
			 <p>© 2015 Swapnpurti Matrimony All rights reserved by Swapnpurti Matrimony | Design by  <a href="http://anuvaasoft.com/" target="_blank">  Anuvaa Softech Pvt. Ltd </a></p>
		</div>
	</div>
</div> <div id="InterestListview" runat="server"> 
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
    </form>
</body>
</html>
