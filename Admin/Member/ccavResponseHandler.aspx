<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ccavResponseHandler.aspx.cs" Inherits="ccavResponseHandler" %>

<!DOCTYPE html >

 <html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony | Confirm Payment</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
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
		<link href="../../css/animate.css" rel="stylesheet" type="text/css" media="all">
		<script src="../../js/wow.min.js"></script>
		<script>
		    new WOW().init();
		</script>
<!-- animated-css --> 
</head>
<body >

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
                      <li ><a href="#">Order Status</a></li> 
                    
                      
                </ul>   
		</div>
                </div>
                  </div>
   <div class="container">
           <div class="franchisee">
	<div class="container">	
        <div class="row"> 
             <h3>Order No. : <asp:Label ID="lblOrderNo" runat="server" Text=""></asp:Label> &nbsp; for Member ID: <asp:Label ID="lblMemId" runat="server" Text=""></asp:Label> &nbsp; and Member Name:<asp:Label ID="lblMemName" runat="server" Text=""></asp:Label>   &nbsp; is &nbsp; <asp:Label ID="lblOrderStatus" runat="server" Text="Label"></asp:Label></h3>
                            
                <div class="col-lg-1"></div>
            <div  class="col-lg-4">
                 <div> 
                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:matrimonyConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:matrimonyConnectionString.ProviderName %>" 
       >
    </asp:SqlDataSource>
     <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" 
         > 
        <EmptyDataTemplate>
            <table id="Table1" runat="server" style="">
                <tr>
                    <td>
                        No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
         
        <ItemTemplate>
           <span>
              <div class="panel panel-danger panel-pricing">
                        <div class="panel-heading text-center">
                            <i class="fa fa-desktop"></i>
                            <h3><asp:Label ID="varPackageNameLabel" runat="server" Text='<%# Eval("varPackageName") %>' /></h3>
                        </div>
                        <div class="panel-body text-left"> 
                  <dl class="dl-horizontal">
                      <dt>Amount</dt>
                      <dd>:<i class="fa fa-inr"></i>   <asp:Label ID="varPackagePriceLabel" runat="server" Text='<%# Eval("varPackagePrice") %>' /></dd>
                 <dt>Description</dt>
                      <dd>: <asp:Label ID="varPackageDescriptionLabel" runat="server" Text='<%# Eval("varPackageDescription") %>' /></dd>
               <dt>Duration</dt>
                      <dd>: <asp:Label ID="Label1" runat="server" Text='<%# Eval("varPackageDuration") %>' /> <asp:Label ID="varPackageDurationTimeLabel" runat="server" Text='<%# Eval("varPackageDurationTime") %>' /></dd>
             
                      <dt>Benifits</dt>
                      <dd>: <asp:Label ID="Label2" runat="server" Text='<%# Eval("varBenifits") %>' /></dd>
              
                         </dl>
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
             <%-- <div class="col-lg-4">
    <a href="ViewOrders.aspx" class="loginbtn fa-2x fa text-center"  >View Orders</a>
                  <br />
               <a href="../Activities/Home.aspx" class="btn-primary btn fa-2x fa" >Go To Home</a>
           </div>--%>
             </div>
           
          </div>
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
