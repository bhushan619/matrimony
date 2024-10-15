<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="UpgradeMember.aspx.cs" Inherits="Franchisee_UpgradeMember"  %>

<!DOCTYPE html>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!--Author: Anuvaa Softech Pvt. Ltd
Author URL: http://anuvaasoft.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->

<html>
<head>
<title>Swapnpurti Matrimony | Upgrade Member </title>   <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" /> <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
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
<div class="col-lg-2 bhoechie-tab-menu">
              <div class="list-group"> 
                <a href="Default.aspx" class="list-group-item">
                 <i class="fa fa-user"></i>  Profile
                </a>
                <a href="PaidMembers.aspx" class="list-group-item">
               <i class="fa fa-check-square-o"></i> Paid Members
                </a>
                <a href="UnpaidMembers.aspx" class="list-group-item active">
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
         
        <div class=" col-lg-10 bhoechie-tab-container"> 
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 bhoechie-tab">
                <!-- flight section -->
                <div class="bhoechie-tab-content active">
                    <div class="row">  
                          <div class="col-md-11"> 
                 <ul class="breadcrumb text-left">
    <li><a href="Default.aspx">Home</a></li>
    <li><a href="UnpaidMembers.aspx">Unpaid Member</a></li> 
    <li><a href="#">Upgrade Member</a></li> 
</ul>

                          </div> 
                           <div class="col-lg-1 text-right" style="margin-top:3px">
                            <asp:HyperLink runat="server" ID="hypLinkBack" NavigateUrl="~/Franchisee/UnpaidMembers.aspx" CssClass="loginbtn "  >Back</asp:HyperLink>
                        </div>
		 </div>    
                       
                    <div class="row">
                          <div class="col-lg-12">
          <span>Upgrade Member of Name : </span> <asp:Label ID="txtMemName" runat="server" Font-Bold="true"></asp:Label> 
              
              and <span> ID : </span><asp:Label Font-Bold="true" ID="lblmemId" runat="server" ></asp:Label> <br />
     <span>Mobile No  : </span><asp:Label ID="lblMobNo" runat="server" Text="Label"></asp:Label><br />
  <span>  Email ID  : </span><asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label> <br />
                  <asp:Label ID="lbldesig" runat="server" Text="Label"  Visible="false"></asp:Label> 
         <asp:Label ID="lblFranId" runat="server" Text="Label"  Visible="false"></asp:Label> 
    <asp:Label ID="ddlProfileFor" runat="server" Text=""  Visible="false"></asp:Label> 
   
   <asp:Label ID="lblGen" runat="server"  Visible="false"></asp:Label>
        <asp:RadioButton ID="rdbMale" runat="server" Text="Male" GroupName="rdbgen"  Visible="false" />  
        <asp:RadioButton ID="rdbFemale" runat="server" Text="Female"  Visible="false"
            GroupName="rdbgen"/>  <asp:RadioButton ID="rdbOther" runat="server"  Visible="false"
            Text="Other" GroupName="rdbgen"/>
  <asp:Label ID="ddlMemStatus" runat="server" Text="" Visible="false"></asp:Label>
   
 <asp:Label ID="txtMemshipType" runat="server" Text="" Visible="false"></asp:Label> 
                              <br />
             </div>
                       </div>
                       <div class="row">
                          <div class="col-lg-12">
         <asp:SqlDataSource ID="SqlDataSource1" runat="server"
              ConnectionString="<%$ ConnectionStrings:matrimonyConnectionString %>" 
             ProviderName="<%$ ConnectionStrings:matrimonyConnectionString.ProviderName %>" 
             SelectCommand="SELECT tblampackages.varPackageName, tblampackagesdetails.varPackageDescription, tblampackagesdetails.varPackageDuration, tblampackagesdetails.varPackagePrice, tblampackagesdetails.varBenifits, tblampackagesdetails.varPackageDurationTime FROM tblampackages INNER JOIN tblampackagesdetails ON tblampackages.varPackageId = tblampackagesdetails.varPackageId"></asp:SqlDataSource>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" onitemcommand="ListView1_ItemCommand">
             
             
            <EmptyDataTemplate>
                <span>No data was returned.</span>
            </EmptyDataTemplate>
             
            <ItemTemplate>
                <span style=""> 
                    <div class="col-md-4 text-center">
                    <div class="panel panel-danger panel-pricing">
                        <div class="panel-heading">
                            <i class="fa fa-desktop"></i>
                            <h3><asp:Label ID="varPackageNameLabel" runat="server" Text='<%# Eval("varPackageName") %>' /></h3>
                        </div>
                        <div class="panel-body text-center">
                            <p><strong> <i class="fa fa-inr"></i>   <asp:Label ID="varPackagePriceLabel" runat="server" Text='<%# Eval("varPackagePrice") %>' /></strong></p>
                        </div>
                        <ul class="list-group text-center">
                            <li class="list-group-item"><i class="fa fa-check"></i> <asp:Label ID="varPackageDescriptionLabel" runat="server" Text='<%# Eval("varPackageDescription") %>' /></li>
                            <li class="list-group-item"><i class="fa fa-check"></i>  <asp:Label ID="varPackageDurationLabel" runat="server" Text='<%# Eval("varPackageDuration") %>' /> <asp:Label ID="varPackageDurationTimeLabel" runat="server" Text='<%# Eval("varPackageDurationTime") %>' /></li>
                            <li class="list-group-item"><i class="fa fa-check"></i>  <asp:Label ID="varBenifitsLabel" runat="server" Text='<%# Eval("varBenifits") %>' /></li>
                        </ul>
                        <div class="panel-footer">
                            <asp:LinkButton ID="LinkButton1" class="btn btn-lg btn-block loginbtn" runat="server" CommandArgument='<%# Eval("varPackageName") +";"+Eval("varPackageDuration")+";"+Eval("varPackageDurationTime") %>' CommandName="buy">Select</asp:LinkButton> 
                        </div>
                    </div>
                </div>

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
          
                              </div>

                       </div>
                          <div class="row"> 
                                <div class="col-lg-3"></div>
                          <div class="col-lg-6">
                       
                                  <div id="packageselection" runat="server" visible="false">
                                    <span class="headings"> Package Selected </span>
                                          <dl class="dl-horizontal">
	<dt>Package </dt>
	<dd>: <asp:Label ID="lblpackName" runat="server" Text="" required="required"></asp:Label></dd>
                                         <dt> Amount </dt>
	<dd>: <asp:Label ID="lblpriceamt" runat="server" Text="" required="required"></asp:Label></dd>
                                         <dt> Duration </dt>
	<dd>: <asp:Label ID="lblDuration" runat="server" Text="" required="required"></asp:Label></dd>
                                              <dt> Contacts View </dt>
	<dd>: <asp:Label ID="lblContacts" runat="server" Text="" required="required"></asp:Label></dd>
                                          </dl>
                                    <div class="form-group">
<asp:DropDownList ID="ddlPayMode" required="required" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPayMode_SelectedIndexChanged" > 
                                  <asp:ListItem Value="">-- Select Payment Mode --</asp:ListItem>
                                  <asp:ListItem>Online Payment</asp:ListItem>
                                  <asp:ListItem>Cash Payment</asp:ListItem>
                              </asp:DropDownList> 
                                  </div>  

                                  </div>
                              

                                  <div id="cashpay" runat="server" visible="false" style="vertical-align:middle"> 
      <div class="form-group">
<asp:Label ID="Label2" runat="server" Text="Transaction/Receipt No."  ></asp:Label>
                             <asp:TextBox ID="txtTransactionId" runat="server" required="required" CssClass="form-control" ></asp:TextBox>     

      </div>   
      <div class="form-group">
 <asp:Button ID="btnUpdate" CssClass="btn btn-success" runat="server" Text="Upgrade" OnClick="btnUpdate_Click1" />
<asp:HyperLink ID="HyperLink2" CssClass="btn btn-danger" runat="server" Text="Cancel"  NavigateUrl="~/Franchisee/UnpaidMembers.aspx"/>
       
                                  </div>

                                  </div>
                                        <div id="online" runat="server" visible="false" style="vertical-align:middle">
                                        <div class="form-group">
  <asp:Button ID="btnPay" CssClass="btn btn-success" runat="server" Text="Proceed To Pay" OnClick="btnPay_Click" /> <asp:HyperLink ID="HyperLink1" CssClass="btn btn-danger" runat="server" Text="Cancel"  NavigateUrl="~/Franchisee/UnpaidMembers.aspx"/>
                                  </div> 
                                    </div>    <asp:LinkButton ID="btnOther" CssClass="btn btn-warning" runat="server" Text="Select Another" OnClick="brnOther_Click" Visible="false" />
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
