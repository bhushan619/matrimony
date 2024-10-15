<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="Email.aspx.cs" Inherits="Admin_Email" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony |  Emails</title>    <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />
<link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all"/>
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="../../js/jquery-1.11.0.min.js"></script>
<!-- Custom Theme files -->
    <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />  
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

    <script language ="javascript" type="text/javascript" >
        //Sets the visibility of the Div to 'visible'
        // Displays the  'In-Process' message  and the Image through the innerHTML 
        ShowProcessMessage = function (PanelName) {
            document.getElementById(PanelName).style.visibility = "visible";
            document.getElementById(PanelName).innerHTML = "<h2><img src='http://swapnpurti.in/admin/InProcess.gif' />  Please Wait ...</h2> ";
           // DisableAllControls('btnSendEmail');
            return true;
        } 

        DisableAllControls = function (CtrlName) {
            var elm;
            //Loop for all the controls of the page.
            for (i = 0; i <= document.forms[0].elements.length - 1; i++) {
                elm = document.forms[0].elements[i];
                /* 1.Check for the Controls with type 'hidden' - These are the ASP.Net hidden controls for Viewstate and EventHandlers.
                It is very important that these are always enabled, for ASP.NET page to be working.
                2. Also Check for the control which raised the event (Button) - It should be active. */
                if ((elm.name == CtrlName) || (elm.type == 'hidden')) {
                    elm.disabled = false;
                }
                else {
                    elm.disabled = true; //Disables all the other controls
                }
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
         <%--<asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Admin/Communication/Notification.aspx" ToolTip="Notification" runat="server"> </asp:HyperLink>
  --%>
            <div class="bann-two">
	<div class="header">
			<div class="container">
		      <div class="header-main">
				<div class="logo">
					<a href="../Personal/Default.aspx"><img src="../../images/lo.png" alt=""/></a>
				</div>
				<div class="head-right-member">
					<ul>
   
            <li>      <asp:HyperLink ID="lnkNotifications" NavigateUrl="~/Admin/Communication/Notification.aspx" ToolTip="Notification" runat="server" CssClass="notiff"> </asp:HyperLink></li>
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
                                <li><a href="../Personal/EditProfile.aspx"> Edit  Profile</a></li>                             
                                    <li><a href="../Personal/ChangePassword.aspx">Change Password</a></li> 
                                  
	                            </ul> 
                        	</li> 
            <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Communication<b class="caret"></b></a>
                                 <ul class="dropdown-menu">
                                <li ><a href="Email.aspx">Send Email</a></li>  
                                     <li ><a href="SendSms.aspx">Send Sms</a></li>  
                                     <li ><a href="Notification.aspx">Notification</a></li>                         
                               
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
                       <li class="active"><a href="Email.aspx">Send Emails</a></li>
                </ul>   
		</div>
                </div>
                   </div>

        
           <div class="franchisee">
	<div class="container">	
      <div class="row">
         <div class="col-md-2">  </div>
               
            <div class="col-md-8"> 
                  <div class="panel panel-danger center">
            <div class="panel-heading">
              <h3 class="panel-title">Send Emails</h3>
            </div>  
                
            <div class=" panel-body">
          
               
                <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>Select Email</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                            <asp:DropDownList ID="ddlemailtype" runat="server"  required="required" AppendDataBoundItems="true" CssClass="form-control"><%--AutoPostBack="True" OnSelectedIndexChanged="ddlemailtype_SelectedIndexChanged"--%>
                                <asp:ListItem Value="">--Select Promotional Email--</asp:ListItem>
                                                    <asp:ListItem>Special Offer</asp:ListItem>
                                                    <asp:ListItem>Event Annoucement</asp:ListItem>
                                                    <asp:ListItem>Upgrade</asp:ListItem>
                             </asp:DropDownList>
                              </div>
                       </div>
             </div>
<%--<asp:Label runat="server" Text="Select Email" ID="gh"></asp:Label>--%>
        
     <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>Send Email To</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                           <asp:DropDownList ID="ddlemailto" runat="server" required="required" AppendDataBoundItems="true" CssClass="form-control"><%-- AutoPostBack="True" OnSelectedIndexChanged="ddlemailto_SelectedIndexChanged"--%>
             <asp:ListItem Value="">--Send Email To--</asp:ListItem>
            <asp:ListItem>All Member</asp:ListItem>
<asp:ListItem>Paid Member</asp:ListItem>
 <asp:ListItem>Unpaid Member</asp:ListItem>
        </asp:DropDownList>
                              </div>
                       </div>
             </div>
          
          <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>Subject</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                              <asp:TextBox ID="txtsubject" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                       </div>
             </div>       
    
  <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>Select Content Type</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                          <asp:DropDownList ID="ddlContent" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlContent_SelectedIndexChanged" required="required" AppendDataBoundItems="true" >
             <asp:ListItem Value="">--Select Content Type--</asp:ListItem>
            <asp:ListItem>Text</asp:ListItem>
<asp:ListItem>Image</asp:ListItem>
 <asp:ListItem>Both</asp:ListItem>
        </asp:DropDownList>
                              </div>
                       </div>
             </div>
        <div runat="server" id="divtext">
          <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>Text Matter</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                             <asp:TextBox ID="txtmatter" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                              </div>
                       </div>
             </div>
           
        
        </div>
            <div runat="server" id="divimg">
                <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>Upload Image</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                          <div class="fileupload fileupload-new" data-provides="fileupload">
           
                <span class="btn btn-file btn-success"><span class="fileupload-new"></span>
                <input id="fupProPic" runat="server" accept="image/*" name="file" 
                    onchange="previewFile()" type="file" /></span>
                <br />     <br />
                <asp:Image ID="imgProPic" runat="server" 
                    CssClass="fileupload-preview thumbnail" ImageUrl="../media/email/Noimagefound.jpg" 
                    style="width: 200px; height: 150px;float:none" />
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

                  
        </div>
                <div id="ProcessingWindow" visible ="false" style="visibility:hidden;" > </div>
             <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                            <asp:Button ID="btnSendEmail" runat="server" Text="Send Email" OnClick="btnSendEmail_Click"  OnClientClick ="ShowProcessMessage('ProcessingWindow')" CssClass="loginbtn"/>
                              </div>
                       </div>
             </div>
      
    </div></div>
            </div>  
                  <div class="col-md-2"> </div>
      </div>
          </div>   
          </div>
                <div class="footer">
	<div class="container">
		
		<div class="copyright">
			 <p>© 2015 Swapnpurti Matrimony All rights reserved by Swapnpurti Matrimony | Design by  <a href="http://anuvaasoft.com/" target="_blank">  Anuvaa Softech Pvt. Ltd </a></p>
		</div>
	</div>
</div>      </form>
</body>
</html>
