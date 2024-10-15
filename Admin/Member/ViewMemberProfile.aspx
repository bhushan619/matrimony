<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="ViewMemberProfile.aspx.cs" Inherits="Admin_ViewMemberProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony |  View Member Profile</title>  <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />   <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
<link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all"/>
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
		<link href="../../css/animate.css" rel="stylesheet" type="text/css" media="all"/>
		<script src="../../js/wow.min.js"></script>
		<script>
		    new WOW().init();
		</script>
         
    <style type="text/css"> 
a.morelink {
	text-decoration:none;
	outline: none;
}
.morecontent span {
	display: none; 
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="bann-two">
	<div class="header">
			<div class="container">
		      <div class="header-main">
				<div class="logo">
					     <a href="../Personal/Default.aspx"><img src="../../images/lo.png" alt=""/></a>
				</div>
				<div class="head-right-member">
					<ul>
   
            <li>     
      <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Admin/Communication/Notification.aspx" ToolTip="Notification" runat="server" CssClass="notiff"> </asp:HyperLink>
        </li>
<li>   <asp:Image ID="imgAdminPhoto"   runat="server"  Height="60px" Width="60px"/></li>
                   <li>  <asp:Label ID="lblAdminName" runat="server" Text="" ></asp:Label> <br />
<asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click">Logout</asp:LinkButton>
                       
                   </li> 
     
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
         <li class="dropdown"> <a class="dropdown-toggle" data-toggle="dropdown"  href="#">Member   <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li  ><a href="ViewMembers.aspx">View Member</a></li>
                              
	                            </ul>
						</li>	
                        	<li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Franchisee<b class="caret"></b></a>
                              <ul class="dropdown-menu">
                                <li ><a href="../Franchisee/ViewFranchisee.aspx">View Franchisee </a></li>                             

                        
	                            </ul>
                        	</li> 
                       <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Package<b class="caret"></b></a>
                               <ul class="dropdown-menu">
                                <li ><a href="../Package/PackageRegister.aspx">Add Package</a></li>
                                <li ><a href="../Package/ViewPackage.aspx">View Package</a></li> 
                               
	                            </ul>
                        	</li> 
                         <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Setting<b class="caret"></b></a>
                               <ul class="dropdown-menu">
                                <li><a href="../Personal/EditProfile.aspx"> Edit  Profile</a></li>                             
                                    <li><a href="../Personal/ChangePassword.aspx">Change Password</a></li> 
                                  
	                            </ul> 
                        	</li> 
            <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Communication<b class="caret"></b></a>
                                 <ul class="dropdown-menu">
                                <li ><a href="../Communication/Email.aspx">Send Email</a></li>  
                                     <li ><a href="../Communication/SendSms.aspx">Send Sms</a></li>  
                                     <li ><a href="../Communication/Notification.aspx">Notification</a></li>                         
                               
	                            </ul>
                        	</li> 
            <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Success Story<b class="caret"></b></a>
                                 <ul class="dropdown-menu">
                                <li ><a href="../SuccessStory/SuccessStory.aspx">View Story</a></li>     
 <li ><a href="../SuccessStory/ApproveSuccessStory.aspx">Approve Story</a></li>    
 <li ><a href="../SuccessStory/RejectSuccessStory.aspx">Reject Story</a></li>        
	                            </ul>
                        	</li> 
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Report<b class="caret"></b></a>
                                 <ul class="dropdown-menu">
                                <li ><a href="../Reports/ViewReports.aspx">View Reports</a></li>                         
                               
	                            </ul>
                        	</li> 
                        
      </ul>
   </div>
</nav><div class="clearfix"> </div>

         </div>
            <div class="row bg">
            <div class="container">
<div class="col-lg-12">
                 <ul class="breadcrumb bg text-left">
                     
                 <li ><a href="../Personal/Default.aspx">Home</a></li> 
                    <li ><a href="ViewMembers.aspx">View Members</a></li> 
                      <li ><a href="ViewMemberProfile.aspx">View Member Profile</a></li> 
                    
                      
                </ul>   
		</div>
        </div>
                </div>
           <div class="franchisee">
	<div class="container">     
      
                   <div class="panel panel-danger center">
            <div class="panel-heading">
              <h3 class="panel-title"> View Member Details
                  <asp:Button ID="btndownloadbio" runat="server" Text="Download Biodata" OnClick="btndownloadbio_Click"  class="btn btn-info dnld"/>
                <a href="ViewMembers.aspx" class="backbtn">Back</a></h3>
            </div>  
                
            <div class=" panel-body">
           <div class="col-lg-1"></div> 
             <div class="col-lg-10"> 
                     <div class="row">   
            <div class="col-lg-5">  
          <div class="form-group">
               <asp:Label ID="lblFullName" runat="server"  Font-Bold="True" Font-Size="Large" />  (<asp:Label ID="lblFullId" runat="server" Font-Size="Small"/>)
          <%--      <asp:Label ID="lblPackageName" runat="server" Font-Bold="True"></asp:Label> --%>  <br /> 
           </div>
    
       </div>
                         <div class="col-lg-7">
                                  <div style="float:right;padding-top:8px;">      </div>
                         </div>
                    </div>
       
         <div class="row">   
                <div class="col-lg-2">  
              <asp:Image ID="imgmember" runat="server" CssClass="img-thumbnail" Width="170px"   Height="175px"   />

                </div>
                <div class="col-lg-4 "> 
                
                   <h4><img src="../../images/icon%20squares.png" height="20" width="20"/>&nbsp;&nbsp;Basic Details</h4>
                    <%-- <div class="col-lg-1 img-circle img-thumbnail proicon">
                         <i class="fa fa-user fa-2x iconcolor "></i>
                     </div>--%>
                   <%-- <div class="col-lg-5">--%>
                       
                          <dl class="dl-horizontal"> 
                              <dt>Profile Created For</dt>
                 <dd>:   <asp:Label ID="lblFullMembership" runat="server" /></dd>
	                        <dt>Date Of Birth</dt>
	                        <dd>:  <asp:Label ID="lblDOB" runat="server"></asp:Label></dd>
                            <dt>Marital Status</dt>
	                        <dd>:  <asp:Label ID="lblMaritalStatus" runat="server"></asp:Label></dd>
                            <dt>Profile For</dt>
	                        <dd>:  <asp:Label ID="lblCreatedfor" runat="server"></asp:Label></dd>
                             <div id="MStatusz" runat="server">
                                   <dt>No. of children</dt>
	                        <dd>:  <asp:Label ID="lblNoOfChild" runat="server"></asp:Label></dd>
                                                      <dt>Children status</dt>
	                        <dd>:  <asp:Label ID="lblChildrnStatus" runat="server"></asp:Label></dd>
                              </div>
                         </dl> 
                 <%--   </div> --%>
                     
              </div> 
               <div class="col-lg-6">
<div class="form-group">
          <h4><img src="../../images/icon%20squares.png" height="20" width="20"/>&nbsp;&nbsp;About Myself And Family</h4>
                            <dl class="dl-horizontal"> 
       <dt> About myself   </dt>
       <dd>:  <asp:Label ID="lblMyself" runat="server" CssClass="label-font-size comment more"></asp:Label></dd>
                  
                         
               <dt>About Family</dt>
        <dd>:  <asp:Label ID="lblaboutfamily" runat="server" CssClass="label-font-size comment more"></asp:Label></dd>
   <dt>Permanant Address</dt> <dd> : <asp:Label ID="lblpAddress" runat="server"  ></asp:Label></dd>
       <dt>Alternate Address</dt> <dd>  : <asp:Label ID="lblAAddress" runat="server"  ></asp:Label></dd></dl>    </div>
                       
         </div>      </div>
                                <br />   

               <br />
                         <div class="row">    
                      <div class="col-lg-12">
             <h4><img src="../../images/icon%20squares.png" height="20" width="20"/>&nbsp;&nbsp;Contact  Details</h4>
              
                 <div class="col-lg-1 img-circle img-thumbnail proicon">
                         <i class="fa fa-map-marker fa-2x iconcolor"></i>
                     </div>
                          <div class="col-lg-5">  
                       <dl class="dl-horizontal"> 
       <dt>Member Mobile   </dt>      <dd>:      <asp:Label ID="lblMobile" runat="server" ></asp:Label></dd>
      <dt>Alternate Mobile </dt>      <dd>:      <asp:Label ID="lblaltmbmem" runat="server"  ></asp:Label></dd>
           <dt>Email Id</dt>  <dd> :          <asp:Label ID="lblEmail" runat="server"   ></asp:Label></dd>
            <dt>Alternate Email</dt>  <dd> :     <asp:Label ID="lblaltemailmem" runat="server"   ></asp:Label></dd>
                  <dt>Parent Mobile</dt>  <dd> :     <asp:Label ID="lblpmb" runat="server"  ></asp:Label></dd>
                <dt>Parent Landline</dt>  <dd> :    <asp:Label ID="lblpland" runat="server"   ></asp:Label></dd>
               
           </dl>
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
                         <i><img src="../../images/physical.jpg" height="30" width="30"  /></i>
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
                         <i><img src="../../images/proffessional.jpg"  height="30" width="30"  /></i>
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
                       <h4><img src="../../images/icon%20squares.png" height="20" width="20"/>&nbsp;&nbsp;Family & Lifestyle Information</h4>
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
            </div><div class="col-lg-5">
                      
                             <dl class="dl-horizontal"> 
                     <dt>Eating habits</dt>
	                            <dd>:  <asp:Label ID="lblEatingHabits" runat="server"></asp:Label></dd>   
                     <dt>Smoke</dt>
	                            <dd>:  <asp:Label ID="lblSmoke" runat="server"></asp:Label></dd> 
                     <dt>Drink</dt>
	                            <dd>:  <asp:Label ID="lblDrink" runat="server"></asp:Label></dd>                                 
                     </dl>
            </div></div>
                 </div>
                 </div>
                </div>
                       
                      
   </div> 
        </div></div>
         <div class="footer">
	<div class="container">
		
		<div class="copyright">
			 <p>© 2015 Swapnpurti Matrimony All rights reserved by Swapnpurti Matrimony | Design by  <a href="http://anuvaasoft.com/" target="_blank">  Anuvaa Softech Pvt. Ltd </a></p>
		</div>
	</div>
</div>      </form>
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
  <%-- For notification
     
                <div class="row">    
                                     <div class="col-lg-12">
                       <h4><img src="../../images/icon%20squares.png" height="20" width="20"/>&nbsp;&nbsp; Transaction Details</h4>
                  <div class="col-lg-1 img-circle img-thumbnail proicon">
                         <i class="fa fa-university fa-2x iconcolor"></i>
                     </div>
                             <div class="col-lg-5">  
                            <dl class="dl-horizontal">
	                           
                     <dt>Package Name</dt>
	                            <dd>:  <asp:Label ID="packName" runat="server"></asp:Label></dd>
                            <dt> Duration</dt>
	                            <dd>:  <asp:Label ID="PackDuration" runat="server"></asp:Label></dd>
                                 <dt> Amount</dt>
	                            <dd>:  <asp:Label ID="Packamt" runat="server"></asp:Label></dd>
                            <dt> Benefits</dt>
	                            <dd>:  <asp:Label ID="packbenefit" runat="server"></asp:Label></dd>
                                
                            </dl>
            </div>
                <div class="col-lg-5">
                      
                             <dl class="dl-horizontal"> 
                               <dt>Purchase Date</dt>
	                            <dd>:     <asp:Label ID="lblmydate" runat="server"></asp:Label></dd>   
                     <dt>Order Id</dt>
	                            <dd>:  <asp:Label ID="lblmyOrder" runat="server"></asp:Label></dd>   
                     <dt>Transaction Id</dt>
	                            <dd>:  <asp:Label ID="lblmytran" runat="server"></asp:Label></dd> 
                     <dt>Paid Amount</dt>
	                            <dd>:  <asp:Label ID="lblmyamt" runat="server"></asp:Label></dd>                                 
                     </dl>
             </div>

     </div>
                 </div>--%>
    <%-- <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Admin/Communication/Notification.aspx" ToolTip="Notification" runat="server"> </asp:HyperLink>
  
<div>
        &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" 
            Text="Personal Information"></asp:Label>
        <br />
        <br />
       
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" 
            Text="More Personal Details"></asp:Label>
        <br />
        <asp:Label ID="Label53" runat="server" Text="MemberID"></asp:Label>
        :-
        <asp:Label ID="lblMemId" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label54" runat="server" Text="Member Name"></asp:Label>
        :-
        <asp:Label ID="lblMemName" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Date of birth"></asp:Label>
        &nbsp;:-
        <asp:Label ID="lblDOB" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Marital status"></asp:Label>
        :-
        <asp:Label ID="lblMaritalStatus" runat="server"></asp:Label>
        <br />
        <div id="MStatusz" runat="server">
        <asp:Label ID="Label6" runat="server" Text="No. of children"></asp:Label>
            :-
            <asp:Label ID="lblNoOfChild" runat="server" Text="0"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Children status"></asp:Label>
            :-
            <asp:Label ID="lblChildrnStatus" runat="server"></asp:Label>
        </div>
        <br />
        <asp:Label ID="Label38" runat="server" Text="About myself"></asp:Label>
        :-
        <asp:Label ID="lblMyself" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label30" runat="server" Text="Religious Information" 
            Font-Bold="True"></asp:Label>
        <br />
        <asp:Label ID="Label31" runat="server" Text="Mother Tongue"></asp:Label>
        :-
        <asp:Label ID="lblMotherTounge" runat="server"></asp:Label>
  
        <br />
        <asp:Label ID="Label32" runat="server" Text="Religion"></asp:Label>
        :-
        <asp:Label ID="lblReligion" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label33" runat="server" Text="Caste/Division"></asp:Label>
        :-
        <asp:Label ID="lblCaste" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label34" runat="server" Text="Sub Caste"></asp:Label>
         :-
        <asp:Label ID="lblSubcaste" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label35" runat="server" Text="Gotra /Gothram"></asp:Label>
        :-
        <asp:Label ID="lblGotra" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label39" runat="server" Text="Manglik"></asp:Label>
        :-
        <asp:Label ID="lblMangalik" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label14" runat="server" Font-Bold="True" 
            Text="Physical Appearance "></asp:Label>
        <br />
        <asp:Label ID="Label15" runat="server" Text="Height"></asp:Label>
        :-
        <asp:Label ID="lblHeight" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label16" runat="server" Text="Weight"></asp:Label>
        :-
        <asp:Label ID="lblWeight" runat="server"></asp:Label>
        <br />   
         <asp:Label ID="Label19" runat="server" Text="Bloodgroup"></asp:Label> 
          :-
        <asp:Label ID="lblBloodGrp" runat="server"></asp:Label>
          <br />  
        <asp:Label ID="Label17" runat="server" Text="Bodytype"></asp:Label>
     
            :-
        <asp:Label ID="lblBodyType" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label18" runat="server" Text="Complexion"></asp:Label>
        :-
        <asp:Label ID="lblComplexion" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label20" runat="server" Text="Special Case"></asp:Label>
        :-
        <asp:Label ID="lblSpecialCase" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label21" runat="server" Text="Professional Information " 
            Font-Bold="True"></asp:Label>
        <br />
        <asp:Label ID="Label22" runat="server" Text="Highest qualification"></asp:Label>
        :-
        <asp:Label ID="lblHighQualific" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label49" runat="server" Text="Additional Degree"></asp:Label>
        :-
        <asp:Label ID="lblAddDegree" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label25" runat="server" Text="Employee In"></asp:Label>
        :-
        <asp:Label ID="lblEmpIn" runat="server"></asp:Label>
        <br />
       
        <asp:Label ID="Label26" runat="server" Text="Occupation"></asp:Label>
        :-
        <asp:Label ID="lblOccupation" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label28" runat="server" Text="Annual Income"></asp:Label>
        :-
        <asp:Label ID="lblAnnualIncome" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Living in"></asp:Label>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Country"></asp:Label>
        :-
        <asp:Label ID="lblCountry" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Citizenship"></asp:Label>
        :-
        <asp:Label ID="lblCitizenship" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label11" runat="server" Text="State"></asp:Label>
          :-
        <asp:Label ID="lblState" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label12" runat="server" Text="City"></asp:Label>
        :-
        <asp:Label ID="lblCity" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label42" runat="server" Font-Bold="True" 
            Text="Family Information"></asp:Label>
        <br />
        <asp:Label ID="Label43" runat="server" Text="Family status"></asp:Label>
        :-
        <asp:Label ID="lblFamStatus" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label44" runat="server" Text="Family type"></asp:Label>
        :-
        <asp:Label ID="lblFamType" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label45" runat="server" Text="Family value"></asp:Label>
        :-
        <asp:Label ID="lblFamValue" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label46" runat="server" Font-Bold="True" 
            Text="About your lifestyle"></asp:Label>
        <br />
        <asp:Label ID="Label47" runat="server" Text="Eating habits"></asp:Label>
        :-
        <asp:Label ID="lblEatingHabits" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label48" runat="server" Text="Smoke"></asp:Label>
        :-
        <asp:Label ID="lblSmoke" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label50" runat="server" Text="Drink"></asp:Label>
              
        :-
        <asp:Label ID="lblDrink" runat="server"></asp:Label>
&nbsp;<br />
        <br />
    </div>--%>