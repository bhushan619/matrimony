<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadDocs.aspx.cs" Inherits="Franchisee_UploadDocs" %>

<!DOCTYPE html>

<!DOCTYPE HTML>
<html>
<head>
<title>Swapnpurti Matrimony | Bank Ducument Details</title>   <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" /> <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../images/favicon.ico" type="image/x-icon" />
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
                   <a href="BankDetails.aspx" class="list-group-item ">
                  <i class="fa fa-bank" ></i> Bank Details
                </a>
                   <a href="UploadDocs.aspx" class="list-group-item active">
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
  <li><a href="#">Bank Documents</a></li> 
</ul>
		 </div>  </div> 
                    <div class="row">   
			 <div class="col-lg-6">
                    
                 <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Document Name </span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
                           <div class="form-group">
                               <asp:TextBox ID="txtcaption" runat="server" CssClass="form-control"></asp:TextBox>
                  </div>

                      </div>
                 </div>
               <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span> Upload Document </span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
                                         <div class="form-group">
               <div class="fileupload fileupload-new" data-provides="fileupload">            
               <%-- <span class="btn btn-file" ><span class="fileupload-new"></span>--%>
                <input id="fupProPic" runat="server" class="form-control" accept="image/*" name="file" onchange="previewFile()" type="file" /> 
                  </div>
                   <div class="form-group">
                       
                <asp:Image ID="imgProPic" runat="server"  CssClass="fileupload-preview thumbnail" ImageUrl="~/Admin/media/frdocs/Noimagefound.jpg" 
                    style="width: 150px; height: 150px;float:none;margin-top:5px" />
                                <script type="text/javascript">
                                    function previewFile() {

                                        var preview = document.querySelector('#<%=imgProPic.ClientID %>');
                                        var file = document.querySelector('#<%=fupProPic.ClientID %>').files[0];
                                        var reader = new FileReader();

                                        reader.onloadend = function () {
                                            preview.src = reader.result;
                                        }

                                        if (file) {
                                            reader.readAsDataURL(file);
                                        } else {
                                            preview.src = "";
                                        }
                                    }
                              </script>  
                                </div>
             </div>
                     </div>
                 </div>
                 
               
                   <div class="row"> 
                         <div class="col-md-4"> 
                                
                             </div> 
                      <div class="col-md-8">
                    <div class="form-group">    
                           <asp:Button ID="btnsave" runat="server" Text="Upload" CssClass="loginbtn" OnClick="btnsave_Click" />
              
                        </div>
                     </div>

                 </div>
   
			 </div>
                       
                    <div class="col-lg-6">
                           <span>Your Bank Documents Details</span> <br />
                     
                        <div class="table-responsive">
                               <asp:GridView ID="grddocument" runat="server" AllowPaging="True"   AutoGenerateColumns="False" CssClass="table table-bordered"
      PageSize="10" OnRowCommand="grddocument_RowCommand"    >
            <Columns>
                             
          
            <asp:BoundField DataField="varCaption" HeaderText="Document Name" SortExpression="varCaption" />            
            <asp:BoundField DataField="varStatus" HeaderText="Status" SortExpression="varStatus" />            
          
            <asp:TemplateField>
                   <HeaderTemplate>Operation</HeaderTemplate>
                <ItemTemplate>
               
                      <asp:Image  ImageUrl='<%# "~/Admin/media/frdocs/"+Eval("varDocPath") %>' runat="server"   CssClass="img-thumbnail" Height="50px"  Width="50px"></asp:Image>
                
                    <asp:LinkButton ID="lnkbtnEdit" runat="server" ToolTip="Delete Document" CommandName="de"  CommandArgument='<%#Eval("intId") %>'  CssClass="fa fa-times btn btn-danger  "/>
           

                </ItemTemplate> 
                </asp:TemplateField>  
        </Columns>   <EmptyDataTemplate>

              No Documents Uploaded.  

        </EmptyDataTemplate> <PagerSettings Mode="Numeric" />
        </asp:GridView>
                            </div>
                    </div>
                     </div>
                    <div class="row">
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

