<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpgradeMember.aspx.cs" Inherits="Admin_Member_UpgradeMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony |  Edit Members</title>  <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />   <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
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
                      <li ><a href="EditMembers.aspx">Edit Member Details</a></li> 
                    
                      
                </ul>   
		</div>
                </div>
                  </div>
         
          
        
           <div class="franchisee">
	<div class="container">     
             
                   <div class="panel panel-danger center">
            <div class="panel-heading">
              <h3 class="panel-title"> View Member Details
                <a href="ViewMembers.aspx" class="backbtn">Back</a></h3>
            </div>  
                
            <div class=" panel-body">
           <div class="col-lg-1"></div> 
              <div class="col-lg-10">

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
                      
                       </div></div>
        
  </div></div>
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