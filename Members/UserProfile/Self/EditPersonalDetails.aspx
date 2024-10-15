<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="EditPersonalDetails.aspx.cs" Inherits="members_UserProfile_Self_EditPersonalDetails" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>
<title>Swapnpurti Matrimony |  Personal Details</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../../images/favicon.ico" type="image/x-icon" />
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
                <a href="EditPersonalDetails.aspx" class="list-group-item active">
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
   <li><a href= "EditPersonalDetails.aspx">Edit Personal Details</a></li>
</ul>
		 </div>  </div> 
                    <div class="row">
                      
                        <div class="col-lg-12 text-left"> 
               <div class="col-md-10" >
                   <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Date of birth</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">

             <div class="form-group">  
        
      <%--  <asp:Label ID="Label3" runat="server" Text="Full name"></asp:Label>
        <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
        <br />--%>
       <div class="row"> 
    <div class="col-md-4">     <asp:DropDownList ID="ddlDay" runat="server" required="required" AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem Value="">Day</asp:ListItem>
          <asp:ListItem>1</asp:ListItem> 
     <asp:ListItem>2</asp:ListItem> 
     <asp:ListItem>3</asp:ListItem>
     <asp:ListItem>4</asp:ListItem>
     <asp:ListItem>5</asp:ListItem>
     <asp:ListItem>6</asp:ListItem>
     <asp:ListItem>7</asp:ListItem>
     <asp:ListItem>8</asp:ListItem>
     <asp:ListItem>9</asp:ListItem>
     <asp:ListItem>10</asp:ListItem>
     <asp:ListItem>11</asp:ListItem>
     <asp:ListItem>12</asp:ListItem>
     <asp:ListItem>13</asp:ListItem>
     <asp:ListItem>14</asp:ListItem>
     <asp:ListItem>15</asp:ListItem>
     <asp:ListItem>16</asp:ListItem>
     <asp:ListItem>17</asp:ListItem>
     <asp:ListItem>18</asp:ListItem>
     <asp:ListItem>19</asp:ListItem>
     <asp:ListItem>20</asp:ListItem>
     <asp:ListItem>21</asp:ListItem>
     <asp:ListItem>22</asp:ListItem>
     <asp:ListItem>23</asp:ListItem>
     <asp:ListItem>24</asp:ListItem>
     <asp:ListItem>25</asp:ListItem>
     <asp:ListItem>26</asp:ListItem>
     <asp:ListItem>27</asp:ListItem>
     <asp:ListItem>28</asp:ListItem>
     <asp:ListItem>29</asp:ListItem>
     <asp:ListItem>30</asp:ListItem>
     <asp:ListItem>31</asp:ListItem>

        </asp:DropDownList></div>
               
   <div class="col-md-4">     <asp:DropDownList ID="ddlMonth" runat="server" required="required" AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem Value="">Month</asp:ListItem>
         <asp:ListItem>January</asp:ListItem>
        
      <asp:ListItem>February</asp:ListItem>
      <asp:ListItem>March</asp:ListItem>
      <asp:ListItem>April</asp:ListItem> 
      <asp:ListItem>May</asp:ListItem>
      <asp:ListItem>June</asp:ListItem>
      <asp:ListItem>July</asp:ListItem>
      <asp:ListItem>August</asp:ListItem>
      <asp:ListItem>September</asp:ListItem>
      <asp:ListItem>October</asp:ListItem>
      <asp:ListItem>November </asp:ListItem>
      <asp:ListItem>December</asp:ListItem>

        </asp:DropDownList></div>
   <div class="col-md-4">     <asp:DropDownList ID="ddlYear" runat="server" required="required" AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem Value="">Year</asp:ListItem>
 
           <asp:ListItem>1971</asp:ListItem>
         <asp:ListItem>1972</asp:ListItem>
         <asp:ListItem>1973</asp:ListItem>
         <asp:ListItem>1974</asp:ListItem>
         <asp:ListItem>1975</asp:ListItem>
         <asp:ListItem>1976</asp:ListItem>
         <asp:ListItem>1977</asp:ListItem>
         <asp:ListItem>1978</asp:ListItem>
         <asp:ListItem>1979</asp:ListItem>
         <asp:ListItem>1980</asp:ListItem>
         <asp:ListItem>1981</asp:ListItem>
         <asp:ListItem>1982</asp:ListItem>
         <asp:ListItem>1983</asp:ListItem>
         <asp:ListItem>1984</asp:ListItem>
         <asp:ListItem>1985</asp:ListItem>
         <asp:ListItem>1986</asp:ListItem>
         <asp:ListItem>1987</asp:ListItem>
         <asp:ListItem>1988</asp:ListItem>
         <asp:ListItem>1989</asp:ListItem>
         <asp:ListItem>1990</asp:ListItem>
         <asp:ListItem>1991</asp:ListItem>
         <asp:ListItem>1992</asp:ListItem>
         <asp:ListItem>1993</asp:ListItem>
         <asp:ListItem>1994</asp:ListItem>
         <asp:ListItem>1995</asp:ListItem>
         <asp:ListItem>1996</asp:ListItem>
         <asp:ListItem>1997</asp:ListItem>
         

        </asp:DropDownList></div>
     </div>    </div></div>
     </div>
   <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Marital status</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">                     
      
        <asp:RadioButton ID="rgbNeverMarrided" runat="server" GroupName="rgbMstatus"    Text="Never Married" oncheckedchanged="rgbNeverMarrided_CheckedChanged"    AutoPostBack="True" />
     &nbsp;&nbsp;   <asp:RadioButton ID="rgbWidow" runat="server" GroupName="rgbMstatus"   Text="Widow" oncheckedchanged="rgbWidow_CheckedChanged"   AutoPostBack="True" />
      &nbsp;&nbsp;  <asp:RadioButton ID="rgbDivorced" runat="server" GroupName="rgbMstatus"  Text="Divorced" oncheckedchanged="rgbDivorced_CheckedChanged"  AutoPostBack="True" />
       &nbsp;&nbsp; <asp:RadioButton ID="rgbAwaitingDivorce" runat="server" GroupName="rgbMstatus"             Text="Awaiting divorce"             oncheckedchanged="rgbAwaitingDivorce_CheckedChanged" AutoPostBack="True" />
       </div> </div></div>
                
                        <div id="MStatusz" runat="server"> 
                             <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>No. of children</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">   
  
           <asp:DropDownList ID="ddlNoOfChild" runat="server" required="required" AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem Value="">--Select --</asp:ListItem>
          <asp:ListItem>None</asp:ListItem>
          <asp:ListItem>1 </asp:ListItem>
          <asp:ListItem>2</asp:ListItem>
          <asp:ListItem>3</asp:ListItem>
          <asp:ListItem>4 and Above</asp:ListItem>
        </asp:DropDownList>

      </div></div></div>
   <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Living with children</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">   
 
        <asp:RadioButton ID="rgbCLive" runat="server" GroupName="rgbChildStatus"   Text="Yes" />&nbsp;&nbsp;
        <asp:RadioButton ID="rgbCNotLive" runat="server" GroupName="rgbChildStatus"    Text="No" />
      </div></div>

   </div>
 </div>
            <div class="row"> 
                         <div class="col-md-4"> 
                               <div class="form-group">   
                               <span>About myself</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">   
     
        <asp:TextBox ID="txtAboutMyself" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
     </div></div></div>  

                      <div class="row"> 
                         <div class="col-md-4"> 
                            
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">   
       
         <asp:Button ID="btnPersonalSave" runat="server" Text="Save"   onclick="btnPersonalSave_Click" CssClass="loginbtn"/>
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
