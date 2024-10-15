<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="EditMember.aspx.cs" Inherits="Franchisee_EditMember"  %>

<!DOCTYPE html>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!--Author: Anuvaa Softech Pvt. Ltd
Author URL: http://anuvaasoft.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->

<html>
<head>
<title>Swapnpurti Matrimony | Edit Member </title>   <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" /> <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
<link href="../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="../js/jquery-1.11.0.min.js"></script>
<!-- Custom Theme files -->
<link href="../css/style.css" rel="stylesheet" type="text/css" media="all"/>
<!-- Custom Theme files -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); }>
</script>
<meta name="keywords" content="Matrimony Website, Maharashtra, India, Indian, Hindi, Marathi, Tamil, Telugu, Franchisee, Marriage" />
<!--Google Fonts-->
<!-- start-smoth-scrolling -->
<script type="text/javascript" src="../js/move-top.js"></script>
<script type="text/javascript" src="../js/easing.js"></script>
        <link href="../css/font-awesome.css" rel="stylesheet" />
	<script type="text/javascript">
	    jQuery(document).ready(function ($) {
	        $(".scroll").click(function (event) {
	            event.preventDefault();
	            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
	        });
	    });
	</script>
<!-- //end-smoth-scrolling -->
<!-- animated-css -->
		<link href="../css/animate.css" rel="stylesheet" type="text/css" media="all">
		<script src="../js/wow.min.js"></script>
		<script>
		    new WOW().init();
		</script>
<!-- animated-css -->
</head>
<body>
     <form id="form1" runat="server">
<!--banner start here-->
<div class="bann-two">
	<div class="header">
			<div class="container">
		      <div class="header-main">
				<div class="logo ">
					<a href="Default.aspx"><img src="../images/lo.png" alt=""></a>
				</div>
				<div class="head-right-member">
					<ul>
                        <li> <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Franchisee/Notifications.aspx" ToolTip="Notification" runat="server" CssClass="notiff"> </asp:HyperLink></li>
						
                        <li> <asp:Image ID="imgFranchiseePhoto" runat="server" Width="60px" Height="60px" /> </li>
						<li> <asp:Label ID="lblFranchiseeName" runat="server" Text=""></asp:Label><br />
                            <asp:Label ID="lblFranchiseeId" runat="server" Text=""></asp:Label>                              
						</li>
                     <%--   <li><a href="Registration.aspx"><i class="fa fa-registered"></i> Register</a></li>--%>
					</ul>
				</div>
			  <div class="clearfix"> </div>
			</div>  
		</div>
	</div>
</div>
<!--baner end here-->
<!--navgation start here-->
<div class="navgation">
	<div class="fixed-header">
				<div class="top-nav">
						<span class="menu"> </span>
					<ul> 
						<li><a href="RegisterMember.aspx">Add New Members</a></li>	 
                        <li>
                            <asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click">Logout</asp:LinkButton></li>
					</ul>
				<!-- script-nav -->
			<script>
			    $("span.menu").click(function () {
			        $(".top-nav ul").slideToggle(500, function () {
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
					</script>
				<!-- //script-nav -->
				</div>
				<div class="clearfix"> </div>
			</div>
		</div>
	<!--script-->
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
<!--navgaton end here-->
<!--login start here-->

         <div class="franchisee">
	<div class="container">	
        <div class="row">
          <div class="col-lg-2 bhoechie-tab-menu">
               <div class="list-group"> 
                <a href="Default.aspx" class="list-group-item">
                 <i class="fa fa-user"></i>  Profile
                </a>
                <a href="PaidMembers.aspx" class="list-group-item">
               <i class="fa fa-check-square-o"></i> Paid Members
                </a>
                <a href="UnpaidMembers.aspx" class="list-group-item">
                  <i class="fa fa-crosshairs"></i> UnPaid Members
                </a>
                     <a href="BankDetails.aspx" class="list-group-item ">
                  <i class="fa fa-bank" ></i> Bank Details
                </a>
                      <a href="UploadDocs.aspx" class="list-group-item ">
                  <i class="fa fa-file-text-o" ></i> Upload Documents
                </a>
                <a href="ChangePassword.aspx" class="list-group-item">
                 <i class="fa fa-key"></i>   Change Password
                </a>
                <a href="Notifications.aspx" class="list-group-item">
                <i class="fa fa-bell"></i>   Notifications
                </a>
              </div>
            </div>
        <div class="col-lg-10 bhoechie-tab-container">            
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 bhoechie-tab">
                <!-- flight section -->
                <div class="bhoechie-tab-content active">
                     <div class="row">  
                          <div class="col-md-11"> 
                 <ul class="breadcrumb text-left">
    <li><a href="Default.aspx">Home</a></li>
                     <li>Members</li>
    <li><a href="EditMember.aspx">Edit Members</a></li> 
</ul>
		 </div>   <div class="col-lg-1 text-right" style="margin-top:3px">
                            <asp:HyperLink runat="server" ID="hypLinkBack" NavigateUrl="~/Franchisee/UnpaidMembers.aspx" CssClass="loginbtn "  >Back</asp:HyperLink>
                        </div> </div>
                    <div class="row">    
                     <div class="col-lg-6">
                         <div class="form-group">
                         <span> Member Id  :- </span><asp:Label ID="lblmemId" runat="server" Text="Label"></asp:Label> 
                    </div>
   <div class="form-group">
     <asp:TextBox ID="txtMemName" runat="server" CssClass="form-control"></asp:TextBox> 
           </div>
  <div class="form-group">
                        <span> Mobile No   :- </span><asp:Label ID="lblMobNo" runat="server" Text="Label"></asp:Label> 
          </div>
  <div class="form-group">
                        <span> Email ID    :- </span><asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label> 
      </div>
    <div class="form-group">
        <span> Member Gender :- 
        <asp:RadioButton ID="rdbMale" runat="server" Text="Male" GroupName="rdbgen" />  
        <asp:RadioButton ID="rdbFemale" runat="server" Text="Female" 
            GroupName="rdbgen"/>  <asp:RadioButton ID="rdbOther" runat="server" 
            Text="Other" GroupName="rdbgen"/> </span>
            </div>
  <div class="form-group">
                       <span> MemberShip   :-</span>
        <asp:Label ID="txtMemshipType" runat="server" Text="Label"></asp:Label>  

  </div>
 <div class="form-group">
      <asp:DropDownList ID="ddlProfileFor" runat="server" CssClass="form-control"
        required="required">
        <asp:ListItem Value="">--Select Matrimony Profile for--</asp:ListItem>
     <asp:ListItem>Myself</asp:ListItem>
      <asp:ListItem>Son</asp:ListItem>
       <asp:ListItem>Daughter</asp:ListItem>
        <asp:ListItem>Brother</asp:ListItem>
         <asp:ListItem>Sister</asp:ListItem>
          <asp:ListItem>Relative</asp:ListItem>
           <asp:ListItem>Friend</asp:ListItem>
        </asp:DropDownList> 
   
           </div>
   <div class="form-group">
      <asp:DropDownList ID="ddlMemStatus" runat="server" CssClass="form-control">
     <asp:ListItem Value="">--Select Status--</asp:ListItem>
    <asp:ListItem >Verified</asp:ListItem>
      <asp:ListItem>UnVerified</asp:ListItem>
          <asp:ListItem  disabled="true" style="color:#CC3300">Deleted</asp:ListItem>
        </asp:DropDownList> 
       </div>
   <div class="form-group">

     <asp:Button ID="btnUpdate" runat="server" Text="Update" onclick="btnUpdate_Click" CssClass="btn btn-success"> </asp:Button>     
            <a href="Default.aspx" class="btn btn-danger">Cancel</a> 
                         </div>
                     </div> 
                </div> 
            </div>
        </div> 
			</div> 
	 </div>	  
        </div> 
             </div>
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
						 
    </form>
</body>
</html>
