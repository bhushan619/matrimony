<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="ApproveMembersPictures.aspx.cs" Inherits="ApproveMembersPictures" %>
<%@ Register Assembly="GroupingView" Namespace="UNLV.IAP.WebControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony |  Approve Member Pictures</title>  <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />   <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
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
                       <li ><a href="ApproveMembersPictures.aspx">Approve Members Pictures</a></li>      
                </ul>    
            </div>
            </div>  
        </div> 
           
         <div class="franchisee">
	<div class="container">	
         <div class="col-lg-12"> 
               
                <div class="col-lg-3"> 
                           <div class="panel panel-success center">
                                          <div class="panel-heading">
                                            <h3 class="panel-title">Profile Picture</h3>
                                              </div>  
                
                              <div class=" panel-body">                       
                                <asp:ListView ID="lstProfilePics" runat="server" OnPagePropertiesChanging="OnPagePropertiesChanging"    GroupPlaceholderID="groupPlaceHolder1">
              <EmptyDataTemplate>
                <span>No Profile Pics To Approve.</span>
            </EmptyDataTemplate> 
            <ItemTemplate>
           <asp:Label ID="LinkButton1" runat="server"   Text='<%# Eval("IntersestMemId") %>'></asp:Label>
 (<asp:Label ID="lblname" runat="server"   Text='<%# Eval("IntersestMemName") %>'></asp:Label>)<br />
  <asp:Image ID="imgSimilarPic" runat="server"  CssClass="img-thumbnail" Height="200px" Width="220px" ImageUrl='<%# "~/members/media/" + Eval("IntersestMemPhoto") %>' />
          
          <br />  <br />   <asp:LinkButton ID="lnkApprove" runat="server" OnClick="lnkApprove_Click" CommandArgument='<%# Eval("IntersestMemId") %>'   Text=" Approve" CssClass="fa  fa-check " ></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="lnkReject" runat="server" OnClick="lnkReject_Click" CommandArgument='<%# Eval("IntersestMemId") %>' Text=" Reject" CssClass="fa  fa-close " ></asp:LinkButton>

            </ItemTemplate>
            <LayoutTemplate>  <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
            <div ID="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
              
                <%--<asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstProfilePics" PageSize="50">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                    </Fields>
                </asp:DataPager>--%>
           
</LayoutTemplate>
        </asp:ListView>
                            </div>
                            </div>
             </div>
       
           <div class="col-lg-9"> 
                 <div class="panel panel-warning center">
                                          <div class="panel-heading">
                                            <h3 class="panel-title">Photo Album <a href="ViewMembers.aspx" class="backbtn">Back</a></h3>
                                              </div>  
                
                              <div class=" panel-body">    
                                  <cc1:GroupingView ID="GroupingViewPhotoAlbum" runat="server" GroupingDataField="IntersestMemPhotoType"
                           oncommand="GroupingViewPhotoAlbum_Command" >
            <GroupTemplate>
                   <div class="col-lg-12">  
                 <div class="section-heading">
               <h3>Album : <asp:Label ID="Label2" runat="server"   Text='<%# Eval("IntersestMemPhotoType") %>'></asp:Label><br /></h3>     
            
               <%--   <h5>Visibility : <asp:Label ID="Label1" runat="server" Text='<%# Eval("varVisibility") %>' /></h5>--%>
                        <div class="line"></div>
                </div>   
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" /> 
                       </div>
            </GroupTemplate>      
                                  <EmptyDataTemplate>
                                        No Pics To Approve...
                                  </EmptyDataTemplate>                     
            <ItemTemplate>  
          <div class="col-lg-4">  
                     <asp:Image ID="imgmemotherPic" runat="server"  Height="140px" Width="160px"  CssClass="img-thumbnail" ImageUrl='<%# "~/members/media/" + Eval("IntersestMemPhoto") %>'  />
              <br />  <asp:LinkButton ID="lnkApprove" runat="server" OnClick="lnkApprove_Click1" CommandArgument='<%# Eval("IntersestMemId")+ ";" +Eval("IntersestMemPhoto") %>'   Text="Approve" CssClass="fa  fa-check "></asp:LinkButton> &nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="lnkReject" runat="server" OnClick="lnkReject_Click1" CommandArgument='<%# Eval("IntersestMemId") + ";" +Eval("IntersestMemPhoto")%>' Text="Reject"  CssClass="fa  fa-close "></asp:LinkButton><br /><br />
    
               <%--  <asp:LinkButton ID="lnkDeleteFamily" runat="server"  CssClass="btn fa fa-times over iconcolor"   CommandName="Deletes" CommandArgument='<%# Eval("intId") %>' ></asp:LinkButton>--%>
              </div>
            </ItemTemplate> 
            <EmptyDataTemplate>
        
                              No Other Pictures To Approve.
            </EmptyDataTemplate>
        </cc1:GroupingView>
              <%--   <asp:Label ID="LinkButton1" runat="server"   Text='<%# Eval("IntersestMemId") %>'></asp:Label><br />    
 <asp:Label ID="lblname" runat="server"   Text='<%# Eval("IntersestMemName") %>'></asp:Label><br />--%>
                                    <%--<asp:ListView ID="lstOtherPics" runat="server" OnPagePropertiesChanging="OnPagePropertiesChangingOther"
             GroupPlaceholderID="groupPlaceHolder1" >
              <EmptyDataTemplate>
                <span>No Other Pictures To Approve.</span>
            </EmptyDataTemplate> 
            <ItemTemplate>
    
           <h4> <asp:Label ID="Label1" runat="server"   Text='<%# Eval("IntersestMemPhotoType") %>'></asp:Label><br /></h4>     
                
  <asp:Image ID="imgmemotherPic" runat="server"  Height="140px" Width="160px"  CssClass="img-thumbnail" ImageUrl='<%# "~/members/media/" + Eval("IntersestMemPhoto") %>'  />
      <br />   
 <asp:LinkButton ID="lnkApprove" runat="server" OnClick="lnkApprove_Click1" CommandArgument='<%# Eval("IntersestMemId")+ ";" +Eval("IntersestMemPhoto") %>'   Text="Approve" CssClass="fa  fa-check "></asp:LinkButton> &nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="lnkReject" runat="server" OnClick="lnkReject_Click1" CommandArgument='<%# Eval("IntersestMemId") + ";" +Eval("IntersestMemPhoto")%>' Text="Reject" CssClass="fa  fa-close "></asp:LinkButton><br /><br />

            </ItemTemplate>
            <LayoutTemplate>  <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
            <div ID="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
              
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstOtherPics" PageSize="50">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Link" />
                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                    </Fields>
                </asp:DataPager>
           
</LayoutTemplate>
        </asp:ListView>--%>

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
</div>   </form>
</body>
</html>
