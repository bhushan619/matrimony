<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony |  Home</title>  <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />   <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
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
<!-- animated-css --> 
</head>
<body>
    <form id="form1" runat="server">
  <div class="bann-two">
	<div class="header">
			<div class="container">
		      <div class="header-main">
				<div class="logo">
					<a href="Default.aspx"><img src="../../images/lo.png" alt=""/></a>
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
                                <li  ><a href="../Member/ViewMembers.aspx">View Member</a></li>
                              
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
                                <li><a href="EditProfile.aspx"> Edit  Profile</a></li>                             
                                    <li><a href="ChangePassword.aspx">Change Password</a></li> 
                                  
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
                     
                </ul>   
		</div></div>
                </div>
        <div class="franchisee">
	<div class="container">     

          <div class="row "> 
                        <div class="col-md-3">                               
                          </div> 
                      <div class="col-md-4">
                             <div class="form-group"> 
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <asp:TextBox ID="txtmembername" runat="server" CssClass="form-control" placeholder="Search Member by name"></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
        MinimumPrefixLength="1" CompletionInterval="1"    EnableCaching="true"         DelimiterCharacters=""      Enabled="True"    ServiceMethod="GetCompletionList" 
                        CompletionSetCount="1"      TargetControlID="txtmembername" UseContextKey="True">
        </cc1:AutoCompleteExtender>
                             </div>
                       </div>
       <div class="col-md-4">
               <div class="form-group">    <asp:Button ID="btnSearch" runat="server" Text="Search"  onclick="btnSearch_Click"  CssClass=" btn btn-success"/>
             <asp:Button ID="btnClear" runat="server" Text="Clear"    onclick="btnClear_Click" CssClass="btn btn-warning"/> 
  </div>
       </div>
      <div class="col-md-1">  </div> 
        </div>
<%--            
            Transcation Member<br />
            <asp:label ID="Label1" runat="server" text="Search Member by name:-"></asp:label>
       
        <asp:Button ID="btnSearch" runat="server" Text="Search" 
            onclick="btnSearch_Click" />
             <asp:Button ID="btnClear" runat="server" Text="Clear" 
            onclick="btnClear_Click"/>
       <br />--%>
     <br />  <div class="row ">
             <div class="col-md-1">  </div> 
            <div class="col-md-10">  
              <div class="panel panel-success center">
            <div class="panel-heading">
              <h3 class="panel-title">Members Transaction   Details</h3>
            </div>  
                
            <div class=" panel-body">
                  <div class="table-responsive"> 
        <asp:GridView ID="grdPaidMember" runat="server" AllowPaging="True" CssClass="table table-responsive table-bordered"  PageSize="15"
           AutoGenerateColumns="False" OnRowCommand="grdPaidMember_RowCommand" OnPageIndexChanging="grdPaidMember_PageIndexChanging" >

            <Columns>
                                       
            <asp:BoundField DataField="varMemberId" HeaderText="Member ID" SortExpression="varMemberId" />  
                            <asp:BoundField DataField="varTransactionId" HeaderText="Transaction ID" SortExpression="varTransactionId" />              
            <asp:BoundField DataField="varMemberName" HeaderText="Member Name" SortExpression="varMemberName" />            
                     <asp:BoundField DataField="varMemberCity" HeaderText="City" SortExpression="varMemberCity" />
                   <asp:BoundField DataField="varPaymentAmount" HeaderText="Paid" SortExpression="varPaymentAmount" />           
                   <asp:BoundField DataField="PackageName" HeaderText="Package" SortExpression="PackageName" />           
            <asp:BoundField DataField="varPaymentStatus" HeaderText="Status " SortExpression="varPaymentStatus" /> 
                           
                 <asp:BoundField DataField="varPaymode" HeaderText="Paymode " SortExpression="varPaymode" /> 
            <asp:BoundField DataField="varOrderStatus" HeaderText="O_Status " SortExpression="varOrderStatus"  />   
                            <asp:BoundField DataField="ex2" HeaderText="packdetailsid " SortExpression="ex2"  Visible="false"/>           
<%--            <asp:BoundField DataField="varMemberStatus" HeaderText="Member Status" SortExpression="varMemberStatus" />--%>
             
                  
            <asp:TemplateField>
            <HeaderTemplate>View</HeaderTemplate>
                <ItemTemplate>
               
              <asp:LinkButton ID="lnkbtnSelect" runat="server" Text="View" CommandName="Views"  CommandArgument='<%#Eval("varMemberId")+";"+Eval("ex2") %>'  CssClass=" fa fa-eye btn btn-link  "  />
                </ItemTemplate> 
                </asp:TemplateField>  
                 </Columns> <EmptyDataTemplate>

              No Data Found.  

        </EmptyDataTemplate> <PagerSettings Mode="Numeric" /> 
        </asp:GridView>  
          </div>
                </div></div></div></div></div></div>
        <div class="footer">
	<div class="container">
		
		<div class="copyright">
			 <p>© 2015 Swapnpurti Matrimony All rights reserved by Swapnpurti Matrimony | Design by  <a href="http://anuvaasoft.com/" target="_blank">  Anuvaa Softech Pvt. Ltd </a></p>
		</div>
	</div>
</div>   </form>
</body>
</html>
