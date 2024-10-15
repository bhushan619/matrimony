<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="EditMembers.aspx.cs" Inherits="Admin_EditMembers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
              <h3 class="panel-title"> Edit Member Details
                <a href="ViewMembers.aspx" class="backbtn">Back</a></h3>
            </div>  
                
            <div class=" panel-body">
           <div class="col-lg-2"></div> 
             <div class="col-lg-8"> 
               
                <div class="row"> 
                         <div class="col-md-5"> 
                                 <div class="form-group">   
                               <span>    Franchisee ID </span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                          <asp:Label ID="lblFranId" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                              </div>
                       </div>
             </div>


                 <div class="row"> 
                         <div class="col-md-5"> 
                                 <div class="form-group">   
                               <span>  Member Id  </span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                          <asp:Label ID="lblmemId" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                              </div>
                       </div>
             </div>

                 <div class="row"> 
                         <div class="col-md-5"> 
                                 <div class="form-group">   
                               <span>Designation </span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                          <asp:Label ID="lbldesig" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                              </div>
                       </div>
             </div>

                 <div class="row"> 
                         <div class="col-md-5"> 
                                 <div class="form-group">   
                               <span>    Mobile No </span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                          <asp:Label ID="lblMobNo" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                              </div>
                       </div>
             </div>
<%--    Password  :-<asp:Label ID="lblPass" runat="server" Text="Label"></asp:Label><br />--%>

 <div class="row"> 
                         <div class="col-md-5"> 
                                 <div class="form-group">   
                               <span>  Email ID </span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                           <asp:Label ID="lblEmail" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                              </div>
                       </div>
             </div>

                  <div class="row"> 
                         <div class="col-md-5"> 
                                 <div class="form-group">   
                               <span>    Member Name </span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                          <asp:TextBox ID="txtMemName" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                       </div>
             </div>

                  <div class="row"> 
                         <div class="col-md-5"> 
                                 <div class="form-group">   
                               <span>  Member Gender </span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                          <asp:RadioButton ID="rdbMale" runat="server" Text="Male" GroupName="rdbgen" />  
        <asp:RadioButton ID="rdbFemale" runat="server" Text="Female" 
            GroupName="rdbgen"/>  <asp:RadioButton ID="rdbOther" runat="server" 
            Text="Other" GroupName="rdbgen"/>
                              </div>
                       </div>
             </div>
   
                  <div class="row"> 
                         <div class="col-md-5"> 
                                 <div class="form-group">   
                               <span>    MemberShip Type </span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                           <asp:Label ID="txtMemshipType" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                              </div>
                       </div>
             </div> 
                 <div class="row"> 
                         <div class="col-md-5"> 
                                 <div class="form-group">   
                               <span>Profile For </span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                         <asp:DropDownList ID="ddlProfileFor" runat="server" CssClass="form-control"
        required="required" AppendDataBoundItems="true" AutoPostBack="True">
        <asp:ListItem Value="">--Select Matrimony Profile for--</asp:ListItem>
     <asp:ListItem>Myself</asp:ListItem>
      <asp:ListItem>Son</asp:ListItem>
       <asp:ListItem>Daughter</asp:ListItem>
        <asp:ListItem>Brother</asp:ListItem>
         <asp:ListItem>Sister</asp:ListItem>
          <asp:ListItem>Relative</asp:ListItem>
           <asp:ListItem>Friend</asp:ListItem>
        </asp:DropDownList> </div>
                       </div>
             </div>
 
   
        <div class="row"> 
                         <div class="col-md-5"> 
                                 <div class="form-group">   
                               <span> Member Status </span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                          <asp:DropDownList ID="ddlMemStatus" runat="server" CssClass="form-control"  AutoPostBack="True">
     <asp:ListItem Value="">--Select Status--</asp:ListItem>
    <asp:ListItem>Verified</asp:ListItem>
      <asp:ListItem>NotVerified</asp:ListItem>
        </asp:DropDownList>
                              </div>
                       </div>
             </div>

   
 <div class="row"> 
                         <div class="col-md-5"> 
                                  
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" onclick="btnUpdate_Click" CssClass="btn btn-warning"> </asp:Button>      
                                <asp:Button ID="btnCancel" runat="server"   Text="Cancel" onclick="btnCancel_Click" CssClass="btn btn-danger"/>  </div>
                       </div>
             </div>

   
    </div></div></div>
          
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
    
     <%--   <asp:GridView ID="grdEditMembers" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" 
            onpageindexchanging="grdEditMembers_PageIndexChanging" 
            onrowcommand="grdEditMembers_RowCommand" >
              <Columns> 
                <asp:BoundField DataField="varMemberId" HeaderText="Member ID" SortExpression="varMemberId" />
                <asp:BoundField DataField="varMembershipType" HeaderText="Membership Type" SortExpression="varMembershipType" />
                <asp:BoundField DataField="varMemberFor" HeaderText="Member For" SortExpression="varMemberFor" />
                <asp:BoundField DataField="varMemberName" HeaderText="Member Name" SortExpression="varMemberName" />
                <asp:BoundField DataField="varGender" HeaderText="Gender" SortExpression="varGender" />
                <asp:BoundField DataField="varMobile" HeaderText="Mobile No" SortExpression="varMobile" />
                
                <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="btnEdit" runat="server" Text="Select" CommandName="Selects"  CommandArgument='<%#Eval("intId") %>' CssClass="btn btn-link"/>
                </ItemTemplate> 
                </asp:TemplateField>   
              </Columns>
        </asp:GridView>--%>