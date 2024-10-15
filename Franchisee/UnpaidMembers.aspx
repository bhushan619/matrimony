<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="UnpaidMembers.aspx.cs" Inherits="Franchisee_UnpaidMembers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!--Author: Anuvaa Softech Pvt. Ltd
Author URL: http://anuvaasoft.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE HTML>
<html>
<head>
<title>Swapnpurti Matrimony | Unpaid Members </title>   <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" /> <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
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
						
                        <li> <asp:Image ID="imgFranchiseePhoto" runat="server" Width="60px" Height="60px" /> </li>
						<li> <asp:Label ID="lblFranchiseeName" runat="server" Text=""></asp:Label><br />
                            <asp:Label ID="lblFranchiseeId" runat="server" Text=""></asp:Label>                              
						</li>
                     <%--   <li><a href="Registration.aspx"><i class="fa fa-registered"></i> Register</a></li>--%>
					</ul>
				</div>
			  <div class="clearfix"> </div>
			</div> 
                <%--<div class="bann-two-main">
				<h2>Unpaid Members registered By you</h2>
			</div>--%>
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
                          <div class="col-md-12"> 
                 <ul class="breadcrumb text-left">
    <li><a href="Default.aspx">Home</a></li>
    <li><a href="UnpaidMembers.aspx">Unpaid Member</a></li> 
</ul>
		 </div>    
                        </div>
                 <div class="row">         
                   <div class="col-md-8">  
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:TextBox ID="txtmembername" runat="server" CssClass="form-control" placeholder="Search Member by Name"></asp:TextBox>
        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
        MinimumPrefixLength="1" CompletionInterval="1" 
                    EnableCaching="true"
                        DelimiterCharacters=""
                        Enabled="True" 
                        ServiceMethod="GetCompletionList" 
                        CompletionSetCount="1" 
         TargetControlID="txtmembername" UseContextKey="True">
        </cc1:AutoCompleteExtender>
    </div>
                        <div class="col-md-1"> 
			<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-success"
            onclick="btnSearch_Click" />  </div>   
           <div class="col-md-1"> 
			  <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-danger"
            onclick="btnClear_Click"/>  </div>
                     </div>
 
                <br />
                    <div class="row"> 
                 <div class="col-md-12"> 
            <div class="table-responsive table">             
          <asp:GridView ID="grdUpdaidMember" runat="server" AllowPaging="True" CssClass="table table-bordered" 
            AllowSorting="True" AutoGenerateColumns="False" 
            onrowcommand="grdUpdaidMember_RowCommand" OnSorting="grdUpdaidMember_Sorting">
            <Columns>
                             
            <asp:BoundField DataField="varMemberId" HeaderText="ID" SortExpression="varMemberId" />      
            <asp:BoundField DataField="varMemberName" HeaderText="Name" SortExpression="varMemberName" />            
            <asp:BoundField DataField="varGender" HeaderText="Gender" SortExpression="varGender" />            
            <asp:BoundField DataField="varMobile" HeaderText="Mobile No." SortExpression="varMobile" />  
            <asp:BoundField DataField="varEmail" HeaderText="E-Mail" SortExpression="varEmail" />     
            <asp:TemplateField>
                  <HeaderTemplate>Operation</HeaderTemplate>
                <ItemTemplate>
                <asp:LinkButton ID="lnkbtnEdit" runat="server"  CommandName="Upgrade"  CommandArgument='<%#Eval("varMemberId") %>' ToolTip="Upgrade"  CssClass="btn fa fa fa-university btn-success" />
              <asp:LinkButton ID="lnkbtnSelect" runat="server"  CommandName="Views"  CommandArgument='<%#Eval("varMemberId") %>'  ToolTip="View" CssClass="btn fa fa-eye btn-warning" />
                     <asp:LinkButton ID="LinkButton1" runat="server"  CommandName="Edits"  CommandArgument='<%#Eval("varMemberId") %>' ToolTip="Edit" CssClass="btn fa fa-pencil  btn-danger" />
                </ItemTemplate> 
                </asp:TemplateField>  
        </Columns>
               <EmptyDataTemplate>No Member Found</EmptyDataTemplate>
        </asp:GridView>
        </div>
    </div>
                         <%--     <div class="col-md-6">
                    
               <h3 class="text-center">Paid Members</h3>
                     <asp:GridView ID="grdPaidMember" runat="server" AllowPaging="True" CssClass="table table-bordered" 
            AllowSorting="True" AutoGenerateColumns="False" 
            onrowcommand="grdPaidMember_RowCommand" OnSorting="grdPaidMember_Sorting" >

            <Columns>
                                       
            <asp:BoundField DataField="varMemberId" HeaderText="ID" SortExpression="varMemberId" />           
            <asp:BoundField DataField="varMemberName" HeaderText="Name" SortExpression="varMemberName" />            
            <asp:BoundField DataField="varGender" HeaderText="Gender" SortExpression="varGender" />            
            <asp:BoundField DataField="varMobile" HeaderText="Mobile No." SortExpression="varMobile" />     
            <asp:TemplateField>
            <HeaderTemplate>Operation</HeaderTemplate>
                <ItemTemplate> 
              <asp:LinkButton ID="lnkbtnSelect" runat="server"  CommandName="Views"  CommandArgument='<%#Eval("varMemberId") %>'  ToolTip="View" CssClass=" fa fa-eye  btn-success"  />
               <asp:LinkButton ID="LinkButton1" runat="server"  CommandName="Edits"  CommandArgument='<%#Eval("varMemberId") %>'  ToolTip="Edit" CssClass=" fa fa-pencil btn-danger " />

                </ItemTemplate> 
                </asp:TemplateField>  
                 </Columns> 
                         <EmptyDataTemplate>No Member Found</EmptyDataTemplate>
        </asp:GridView>

                 </div>--%>
		
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