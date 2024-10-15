<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="BankDetails.aspx.cs" Inherits="Franchisee_BankDetails" %>


<!--Author: Anuvaa Softech Pvt. Ltd
Author URL: http://anuvaasoft.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE HTML>
<html>
<head>
<title>Swapnpurti Matrimony | Bank Details</title>   <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" /> <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
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
				<div class="logo">
					<a href="Default.aspx"><img src="../images/lo.png" alt=""></a>
				</div>
				<div class="head-right-member">
					<ul>
                        <li> <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Franchisee/Notifications.aspx" ToolTip="Notification" runat="server" CssClass="notiff"> </asp:HyperLink></li>
						<li> <asp:Image ID="imgFranchiseePhoto" runat="server"  Height="60px" Width="60px"/> </li>
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
                <a href="Default.aspx" class="list-group-item ">
                 <i class="fa fa-user"></i>  Profile
                </a>
                <a href="PaidMembers.aspx" class="list-group-item ">
               <i class="fa fa-check-square-o"></i> Paid Members
                </a>
                <a href="UnpaidMembers.aspx" class="list-group-item ">
                  <i class="fa fa-crosshairs"></i> UnPaid Members
                </a>
                   <a href="BankDetails.aspx" class="list-group-item active">
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
                          <div class="col-md-12"> 
                 <ul class="breadcrumb text-left">
    <li><a href="Default.aspx">Home</a></li>
  <li><a href="#">Bank Details</a></li> 
</ul>
		 </div>  </div> 
                    <div class="row">   
			 <div class="col-lg-10">
                    <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Bank Name</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
                           <div class="form-group">
                          <asp:DropDownList ID="ddlbankname" CssClass="form-control" required="required" AppendDataBoundItems="true" runat="server">
        <asp:ListItem Value="">--Select Bank--</asp:ListItem>
                              <asp:ListItem>  Abhyudaya Co Op Bank Ltd
</asp:ListItem><asp:ListItem>  Abu Dhabi Commercial Bank
</asp:ListItem><asp:ListItem>  Allahabad Bank
</asp:ListItem><asp:ListItem>  Andhra Bank
</asp:ListItem><asp:ListItem>  Axis Bank
</asp:ListItem><asp:ListItem>  Bank Of America
</asp:ListItem><asp:ListItem>  Bank Of Bahrain And Kuwait
</asp:ListItem><asp:ListItem>  Bank Of Baroda
</asp:ListItem><asp:ListItem>  Bank Of Ceylon
</asp:ListItem><asp:ListItem>  Bank Of India
</asp:ListItem><asp:ListItem>  Bank Of Maharashtra
</asp:ListItem><asp:ListItem>  Bank Of Tokyo Mitsubishi Ufj Ltd
</asp:ListItem><asp:ListItem>  Barclays Bank Plc
</asp:ListItem><asp:ListItem>  Bassein Catholic Co Op Bank Ltd
</asp:ListItem><asp:ListItem>  Bnp Paribas
</asp:ListItem><asp:ListItem>  Canara Bank
</asp:ListItem><asp:ListItem>  Catholic Syrian Bank Ltd
</asp:ListItem><asp:ListItem>  Central Bank Of India
</asp:ListItem><asp:ListItem>  Chinatrust Commercial Bank
</asp:ListItem><asp:ListItem>  Citibank
</asp:ListItem><asp:ListItem>  Citizen Credit Co Op Bank Ltd
</asp:ListItem><asp:ListItem>  City Union Bank Ltd
</asp:ListItem><asp:ListItem>  Corporation Bank
</asp:ListItem><asp:ListItem>  Credit Agricole Corp N Invsmnt Bank
</asp:ListItem><asp:ListItem>  Dbs Bank Ltd
</asp:ListItem><asp:ListItem>  Dena Bank
</asp:ListItem><asp:ListItem>  Deutsche Bank Ag
</asp:ListItem><asp:ListItem>  Development Credit Bank Limited
</asp:ListItem><asp:ListItem>  Dhanlaxmi Bank Ltd
</asp:ListItem><asp:ListItem>  Dicgc
</asp:ListItem><asp:ListItem>  Dombivli Nagari Sahakari Bank Limited
</asp:ListItem><asp:ListItem>  Firstrand Bank Limited
</asp:ListItem><asp:ListItem>  Hdfc Bank Ltd
</asp:ListItem><asp:ListItem>  Hsbc Bank Ltd
</asp:ListItem><asp:ListItem>  Icici Bank Ltd
</asp:ListItem><asp:ListItem>  Idbi Bank Ltd
</asp:ListItem><asp:ListItem>  Indian Bank
</asp:ListItem><asp:ListItem>  Indian Overseas Bank
</asp:ListItem><asp:ListItem>  Indusind Bank Ltd
</asp:ListItem><asp:ListItem>  Janakalyan Sahakari Bank Ltd
</asp:ListItem><asp:ListItem>  Janata Sahakari Bank Ltd
</asp:ListItem><asp:ListItem>  Jp Morgan Chase Bank
</asp:ListItem><asp:ListItem>  Kapol Co Op Bank
</asp:ListItem><asp:ListItem>  Karnataka Bank Ltd
</asp:ListItem><asp:ListItem>  Karur Vysya Bank
</asp:ListItem><asp:ListItem>  Kotak Mahindra Bank
</asp:ListItem><asp:ListItem>  Mahanagar Co Op Bank Ltd
</asp:ListItem><asp:ListItem>  Maharashtra State Co Operative Bank
</asp:ListItem><asp:ListItem>  Mashreq Bank Psc
</asp:ListItem><asp:ListItem>  Mizuho Corporate Bank Ltd
</asp:ListItem><asp:ListItem>  New India Co Operative Bank Ltd
</asp:ListItem><asp:ListItem>  Nkgsb Co Op Bank Ltd
</asp:ListItem><asp:ListItem>  Nutan Nagarik Sahakari Bank Ltd
</asp:ListItem><asp:ListItem>  Oman International Bank Saog
</asp:ListItem><asp:ListItem>  Oriental Bank Of Commerce
</asp:ListItem><asp:ListItem>  Parsik Janata Sahakari Bank Ltd
</asp:ListItem><asp:ListItem>  Punjab And Maharashtra Co Op Bank Ltd
</asp:ListItem><asp:ListItem>  Punjab And Sind Bank
</asp:ListItem><asp:ListItem>  Punjab National Bank
</asp:ListItem><asp:ListItem>  Rajkot Nagarik Sahakari Bank Ltd
</asp:ListItem><asp:ListItem>  Reserve Bank Of India
</asp:ListItem><asp:ListItem>  Standard Chartered Bank
</asp:ListItem><asp:ListItem>  State Bank Of Bikaner And Jaipur
</asp:ListItem><asp:ListItem>  State Bank Of Hyderabad
</asp:ListItem><asp:ListItem>  State Bank Of India
</asp:ListItem><asp:ListItem>  State Bank Of Mysore
</asp:ListItem><asp:ListItem>  State Bank Of Travancore
</asp:ListItem><asp:ListItem>  The Ahmedabad Mercantile Co Operative Bank Ltd
</asp:ListItem><asp:ListItem>  The Bank Of Nova Scotia
</asp:ListItem><asp:ListItem>  The Bharat Co Operative Bank Mumbai Ltd
</asp:ListItem><asp:ListItem>  The Cosmos Co Operative Bank Ltd
</asp:ListItem><asp:ListItem>  The Federal Bank Ltd
</asp:ListItem><asp:ListItem>  The Jammu And Kashmir Bank Ltd
</asp:ListItem><asp:ListItem>  The Kalupur Commercial Co Op Bank Ltd
</asp:ListItem><asp:ListItem>  The Kalyan Janata Sahakari Bank Ltd
</asp:ListItem><asp:ListItem>  The Karad Urban Co Op Bank Ltd
</asp:ListItem><asp:ListItem>  The Karnataka State Co Operative Apex Bank Ltd Ba
</asp:ListItem><asp:ListItem>  The Lakshmi Vilas Bank Ltd
</asp:ListItem><asp:ListItem>  The Mehsana Urban Co Operative Bank Ltd
</asp:ListItem><asp:ListItem>  The Mumbai Sub Urban Co Op Bank Ltd
</asp:ListItem><asp:ListItem>  The Nainital Bank Limited
</asp:ListItem><asp:ListItem>  The Nashik Merchants Co Op Bank Ltd
</asp:ListItem><asp:ListItem>  The Ratnakar Bank Ltd
</asp:ListItem><asp:ListItem>  The Royal Bank Of Scotland</asp:ListItem>

                          </asp:DropDownList>
                  </div>

                      </div>
                 </div>
                 
               <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Bank City</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
                           <div class="form-group">    <asp:TextBox ID="txtbankcity" runat="server" CssClass="form-control"></asp:TextBox></div>
                     </div>
                 </div>
                 <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Bank Branch</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
                  <div class="form-group">         <asp:TextBox ID="txtbankbranch" runat="server" CssClass="form-control"></asp:TextBox></div>
                     </div>
                 </div>
                 <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Bank IFSC code</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
         <div class="form-group">      <asp:TextBox ID="txtbankifsccode" runat="server" CssClass="form-control"></asp:TextBox></div>
                     </div>
                 </div>
                 <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Bank MCIR Code</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
        <div class="form-group">  <asp:TextBox ID="txtbankmcircode" runat="server" CssClass="form-control"></asp:TextBox></div>
                     </div>
                 </div>
                 <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Account Holder Name</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
           <div class="form-group">  <asp:TextBox ID="txtbankaccholdername" runat="server" CssClass="form-control"></asp:TextBox></div>
                     </div>
                 </div>
                 <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Account Number</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
      <div class="form-group"> <asp:TextBox ID="txtbankaccno" runat="server" CssClass="form-control"></asp:TextBox></div>
                     </div>
                 </div>
                 <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Account Type</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
 <div class="form-group"> <asp:DropDownList ID="ddlacctype" runat="server" CssClass="form-control" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select Account--</asp:ListItem>  
                               <asp:ListItem>Current Account</asp:ListItem>
                              <asp:ListItem>Savings Account</asp:ListItem> 
                              <asp:ListItem>Recurring Deposit Account</asp:ListItem> 
                              <asp:ListItem>Fixed Deposit Account</asp:ListItem> 
                         <asp:ListItem>Other Account</asp:ListItem> 
                          </asp:DropDownList>
              </div>       </div>

                 </div>
                   <div class="row"> 
                         <div class="col-md-4"> 
                                
                             </div> 
                      <div class="col-md-8">
                    <div class="form-group">    
                           <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="loginbtn" OnClick="btnsave_Click"/>
                   &nbsp;     <asp:LinkButton ID="btnview" runat="server" Text="View" CssClass="loginbtn" OnClick="btnview_Click" CausesValidation="False" />
                        </div>
                     </div>

                 </div>
   <div id="viewbankdetails" runat="server">
                  <div class="row"> 
                         <div class="col-md-12"> 
                           <div class="form-group">  
                                <span>Your Bank Accounts Details</span> <br />
                               <asp:ListView ID="lstbankdetails" runat="server" 
             GroupPlaceholderID="groupPlaceHolder1">
              <EmptyDataTemplate>
              <div class="well"><span>No Bank Accounts Details Found.</span></div>  
            </EmptyDataTemplate>
            <ItemTemplate>
                  <div class="row j10fontAbout " >
         <div class="col-lg-12" style="background-color: #FEF8FB">
        
<div class="col-lg-5">
           <dl class="dl-horizontal">
	             <dt>Bank Name</dt> <dd>:  <asp:Label ID="lblReligion" runat="server" Text='<%# Eval("varBankName") %>'></asp:Label></dd>
                <dt>Bank City</dt>  <dd>:  <asp:Label ID="lblCaste" runat="server" Text='<%# Eval("varBankCity") %>'></asp:Label></dd>
                <dt>Bank Branch</dt>  <dd>:  <asp:Label ID="lblSubcaste" runat="server" Text='<%# Eval("varBankBranch") %>'></asp:Label></dd>
                <dt>IFSC Code</dt>  <dd>:  <asp:Label ID="Label4" runat="server" Text='<%# Eval("varBankIfsc") %>'></asp:Label></dd>
                <dt>MCIR Code</dt>  <dd>:  <asp:Label ID="Label5" runat="server" Text='<%# Eval("varBankMcir") %>'></asp:Label></dd>
                </dl>
  </div>  
             <div class="col-lg-7">
           <dl class="dl-horizontal">
	             <dt>Account Holder Name</dt> <dd>:  <asp:Label ID="Label1" runat="server" Text='<%# Eval("varAccountHolderName") %>'></asp:Label></dd>
                <dt>Account Number</dt>  <dd>:  <asp:Label ID="Label2" runat="server" Text='<%# Eval("varAccountNumber") %>'></asp:Label></dd>
                <dt>Account Type</dt>  <dd>:  <asp:Label ID="Label3" runat="server" Text='<%# Eval("varAccountType") %>'></asp:Label></dd>
                </dl>
  </div> 

         </div> 
         </div> 
         </ItemTemplate>
            <LayoutTemplate>  <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
            <div ID="itemPlaceholderContainer" runat="server">
                    <span runat="server" id="itemPlaceholder" />
                </div>
         
                
           
</LayoutTemplate>
        </asp:ListView>
                        </div>  </div>
                   </div>

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
