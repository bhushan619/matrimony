<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="members_Activities_Home" %>

<!DOCTYPE html >

 <html xmlns="http://www.w3.org/1999/xhtml">
 <head>
<title>Swapnpurti Matrimony | Member Home</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
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
       <script src="https://connect.facebook.net/en_US/all.js" type="text/javascript"></script>
     <script src="../../js/JavaScript.js"></script>
        <link href="../../css/font-awesome.css" rel="stylesheet" /> 
     <script src="../../js/bootstrap.js"></script>
	<script type="text/javascript">
	    jQuery(document).ready(function ($) {
	        $(".scroll").click(function (event) {
	            event.preventDefault();
	            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
	        });
	    });

	    $(document).ready(function () {
	        $('li img').on('click', function () {
	            var src = $(this).attr('src');
	            var img = '<img src="' + src + '" class="img-responsive"/>';
	            $('#myModal').modal();
	            $('#myModal').on('shown.bs.modal', function () {
	                $('#myModal .modal-body').html(img);
	            });
	            $('#myModal').on('hidden.bs.modal', function () {
	                $('#myModal .modal-body').html('');
	            });
	        });
	    })
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
		<link href="../../css/animate.css" rel="stylesheet" type="text/css" media="all" />
		<script src="../../js/wow.min.js"></script>
		<script>
		    new WOW().init();
		</script>
       
      
</head>
<body>
     <form id="form1" runat="server">
          <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-body">
          </div>
        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
         <div class="bann-two">
	<div class="header">
			<div class="container">
		      <div class="header-main">
				<div class="logo">
					<a href="Home.aspx"><img src="../../images/lo.png" alt=""/></a>  
				</div> 
                  <div class="logoutdiv">  
 <asp:LinkButton ID="lnkLogout" CssClass="logout" runat="server" OnClick="lnkLogout_Click" 
   ></asp:LinkButton>  
                </div>
                  <div class="notif">
                      <div class="icon-wrapper">
<a href="Notification.aspx"> <i class="fa fa-bell-o fa-2x iconcolor"></i>
      <asp:Label ID="lnkNotifications" CssClass="badges"  ToolTip="Notification" runat="server"> </asp:Label> </a>
    </div></div>
                 
				<div class="head-right-member">
					<ul> 
                        <li> 
                            <asp:Image ID="imgMemberPhoto"  runat="server"  Height="60px" Width="60px"/> 
                        </li> 
                           <li>  
                                 <asp:HyperLink ID="lblMemberName" runat="server" Text=""  NavigateUrl="~/Members/SearchMatches/Default.aspx"></asp:HyperLink>&nbsp;&nbsp;(<asp:Label ID="lblMemberId" runat="server" Text="" Font-Size="Smaller"></asp:Label>)<br />
                              <asp:Label ID="dddd" ForeColor="GrayText"  Text="Account Type:" Font-Size="Smaller" runat="server"></asp:Label> <asp:HyperLink Text="Free Upgrade Now" Font-Size="Smaller"   runat="server" ID="lnkUpgrade" NavigateUrl="~/members/Subscription/ViewPackage.aspx"></asp:HyperLink>
                              <asp:Label ID="lblmemUpgrade" runat="server"  ></asp:Label>  
                   </li>  
                          <li>   <div class="progress-bar bigfont"  runat="server" id="lblcomplet" data-duration="1000" data-color="#FF7E5E,#d65679  "></div>
 
	 
	<script>
	    $(".progress-bar").loading();

	</script>   </li> 
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
         <li class="dropdown"> <a class="dropdown-toggle" data-toggle="dropdown"  href="#">Activity
                            <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li  ><a href="VisitorsProfile.aspx">Who viewed my profile</a></li>
                                <li ><a href="ViewedProfile.aspx">Profiles I viewed</a></li> 
                                <li ><a href="ShortlistedProfile.aspx">Shortlisted profile</a></li>
                                 <li ><a href="WhoShortlistedMyProfile.aspx">Who Shortlisted me</a></li>
                                <li ><a href="InterestedInProfile.aspx">Interested In profile</a></li>                               
	                            <li ><a href="InterestInMeProfiles.aspx">Interested In Me</a></li>
	                            </ul>
						</li>	
                        	<li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Message&nbsp;<span class="badge"><asp:Label ID="lblcountfinalmsg" runat="server" Text="0"></asp:Label></span><b class="caret"></b></a>
                              <ul class="dropdown-menu">
                                <li ><a href="../Message/Inbox.aspx">Recieved </a></li>                             
                                <li ><a href="../Message/Send.aspx">Sent</a></li>   
                                  <li ><a href="../Message/Request.aspx">Requests</a></li> 
                                <li ><a href="../Activities/Notification.aspx">Notification</a></li>
                        
	                            </ul>
                        	</li> 
                       <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >My Search<b class="caret"></b></a>
                               <ul class="dropdown-menu">
                                <li ><a href="../SearchMatches/QuickSearch.aspx">Quick Search</a></li>
                                <li ><a href="../SearchMatches/AdvancedSearch.aspx">Advanced Search</a></li> 
                                <li ><a href="../SearchMatches/RecentlyViewedProfiles.aspx">Recently viewed profile</a></li>
                               
	                            </ul>
                        	</li> 
                         <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Profile<b class="caret"></b></a>
                               <ul class="dropdown-menu">
                                <li><a href="../UserProfile/Self/EditPersonalDetails.aspx"> Edit My Profile</a></li>
                                <li><a href="../UserProfile/Partner/EditPersonalDetails.aspx">Edit Partner Profile</a></li> 
                                    <li><a href="../UserProfile/Self/EditContactDetail.aspx">Edit Contact Details</a></li>   
                                    <li><a href="../Photo/InfoUpload.aspx">Upload Photo/Biodata</a></li> 
                                    <li><a href="../Setting/ChangePassword.aspx">Change Password</a></li> 
                                    <li><a href="../Setting/DeleteProfile.aspx" >Delete Profile</a></li> 
	                            </ul> 
                        	</li> 
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Upgrade<b class="caret"></b></a>
                                 <ul class="dropdown-menu">
                                   <li ><a href="../Subscription/ViewPackage.aspx">Payment Option</a></li>    <li ><a href="../Subscription/ViewOrders.aspx">View Orders</a></li>                                              
                               
	                            </ul>
                        	</li> 
                          <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Help<b class="caret"></b></a>
                                 <ul class="dropdown-menu">
                                <li ><a href="faq.aspx">FAQ</a></li>           
	                            </ul>
                        	</li> 
      </ul>
   </div>
</nav><div class="clearfix"> </div>

         </div>
           <div class="franchisee">
	<div class="container">		
        <div class="row">
            <div class="col-lg-3">

               <div class="row" style="padding:10px; margin:0px; border:solid 1px #DBDBDB;background-color:#fff;margin-bottom:7px;" >
<div class="col-md-5 text-center" >
  
<asp:ImageButton ID="imgjmypropic"  runat="server" CssClass="img-thumbnail"   />
              <asp:LinkButton ID="uploadpic" runat="server" OnClick="uploadpic_Click" CssClass="btn btn-sm btn-default" Text="Upload New"/>  
           
</div>
                  <div class="col-lg-7" >  
                      <asp:Label ID="lbljname" runat="server" CssClass=""  ></asp:Label><br /> <asp:Label ID="lbljid" runat="server"  />
                     <%--<div class="progress-bar"></div> What's Next?--%><br />   <asp:Label ID="lblPay" runat="server"  ></asp:Label>  <br />
                    <div style="padding-top:10px">   <asp:LinkButton ID="editprofile" CssClass="btn btn-sm btn-default fa fa-edit" runat="server" OnClick="editprofile_Click"  /> 
            <asp:HyperLink CssClass="btn btn-sm btn-default fa fa-inr"  runat="server" ID="hypPay" NavigateUrl="~/members/Subscription/ViewPackage.aspx"></asp:HyperLink>
           </div>
                      </div> 
                      
                   </div>
      
            
                <div class="row" style="padding:10px; margin:0px; border:solid 1px #DBDBDB;background-color:#fff;margin-bottom:7px;" >
                 
                      <h4>Search Member by ID</h4>
                   
                    <div class="col-lg-8">  <asp:TextBox ID="txtmemberId" runat="server" placeholder="Enter Profile ID" CssClass="form-control"   ></asp:TextBox></div>
                    <div class="col-lg-4">     <asp:Button ID="Button1" runat="server" Text="Search" onclick="Button1_Click" CssClass="jsearchbtn" /> </div>
                     
         

                 </div>
              
               <div class="row" style="padding:10px; margin:0px; border:solid 1px #DBDBDB;background-color:#fff;margin-bottom:7px;" >
                <img src="../../images/ad1.jpg" height="170" width="240"   />
                    </div>
            </div>
               
            <div class="col-lg-6" >
                   <div class="row" style="padding:10px; margin:0px; border:solid 1px #DBDBDB;background-color:#fff;margin-bottom:7px;" >
      
                          <div class="row col-lg-12"  >
                <div class="col-md-10"  >    
                     <h4> Members who Shortlisted your Profile </h4>
                    </div>
          <div class="col-md-2" style="float:right"  >
              <a href="WhoShortlistedMyProfile.aspx" class="btn btn-theme">View more</a>
              </div>
         </div>
                          <div class="col-lg-12" style="border:0;border-top:solid 1px #eee;margin:5px 0px"  >
                              </div>    
                      
                       <div class="col-md-12">
                    <asp:ListView ID="lstshortlist" runat="server" >  
            <EmptyDataTemplate>
                <span>No  Profiles Found.</span></EmptyDataTemplate>
                <ItemTemplate>
                      
                                <div class="row" style="border:solid 1px #DBDBDB;padding:5px 0;margin-bottom:7px;">
                                    
<div class="col-md-3" >
             <asp:ImageButton ID="imgSimilarPic" runat="server"    CssClass="img-thumbnail" OnClick="imgmember_Click"  CommandArgument='<%# Eval("SlstMemId") +";"+ Eval("SlstMemPhoto") %>'      ImageUrl='<%# "~/members/media/" + Eval("SlstMemPhoto") %>' /> <br />  
    </div>
                  <div class="col-md-9" >
       <asp:LinkButton ID="lblCollege" runat="server"     CommandArgument='<%# Eval("SlstMemId") %>' OnClick="OpenProfile" Text='<%# Eval("SlstMemId") %>'></asp:LinkButton><br />
                    <asp:Label ID="AgeLabel" runat="server"    Text='<%# Eval("SlstMemAge") %>' />, 
                        <asp:Label ID="HeightLabel" runat="server"   Text='<%# Eval("SlstMemHeight") %>' /> <br />
                    <asp:LinkButton ID="lnkInterest" runat="server" OnClick="lnkInterest_Click"  CommandArgument='<%# Eval("SlstMemId") %>' CssClass="btn btn-success" Text="Send Interest">
 </asp:LinkButton>   </div>

                     </div>
                         </ItemTemplate>
                        <LayoutTemplate>
                <div id="itemPlaceholderContainer" runat="server" style="">
                               <span runat="server" id="itemPlaceholder" />
                           </div>
                          
              
            </LayoutTemplate>
        </asp:ListView>
                       </div>
                        </div>
                  
                   
                <div class="row" style="padding:10px; margin:0px; border:solid 1px #DBDBDB;background-color:#fff;margin-bottom:7px;" >
      <div class="row col-lg-12"  >
                <div class="col-md-10"  >    
                     <h4>Members who Viewed your Profile</h4> 
                    </div>
          <div class="col-md-2"  style="float:right"  >
              <a href="VisitorsProfile.aspx" class="btn btn-theme" >View more</a>
              </div>
         </div>
                          <div class="col-lg-12" style="border:0;border-top:solid 1px #eee;margin:5px 0px"  >
                              </div>            
                                     <div class="col-lg-12"  >
                    <asp:ListView ID="lstView" runat="server"> 
                       <EmptyDataTemplate>
                           <span>No data was returned.</span>
                       </EmptyDataTemplate>
                        
                       <ItemTemplate>
                        <div class="row" style="border:solid 1px #DBDBDB;padding:5px 0;margin-bottom:7px;">
                                
                                    
<div class="col-md-3" >
              <asp:ImageButton ID="imgSimilarPic" runat="server"  CssClass="img-thumbnail" OnClick="imgmember_Click"    CommandArgument='<%# Eval("ViewMemId") +";"+ Eval("ViewMemPhoto") %>'  
                   ImageUrl='<%# "~/members/media/" + Eval("ViewMemPhoto") %>' /> 
     
</div>
                  <div class="col-md-9" >
       <asp:LinkButton ID="lblCollege" runat="server" CommandArgument='<%# Eval("ViewMemId") %>'
         OnClick="OpenProfile" Text='<%# Eval("ViewMemId") %>'></asp:LinkButton><br />
                    <asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("ViewMemAge") %>' />,
                     <asp:Label ID="HeightLabel" runat="server" Text='<%# Eval("ViewMemHeight") %>' />, <br /> 
                    <asp:Label ID="ReligionLabel" runat="server" Text='<%# Eval("ViewMemReligion") %>' />,
                    <asp:Label ID="CasteLabel" runat="server" Text='<%# Eval("ViewMemCaste") %>' />, <br />
                    <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("ViewMemCity") %>' />  
                  </div>  
                         </div>
                          
                       </ItemTemplate>
                       <LayoutTemplate>
                           
                               <div runat="server" id="itemPlaceholder" />
                          
                           
                       </LayoutTemplate>
                        
                   </asp:ListView></div>
                </div>
               
                                  <div class="row" style="padding:10px; margin:0px; border:solid 1px #DBDBDB;background-color:#fff;margin-bottom:7px;" >
      <div class="row col-lg-12"  >
                <div class="col-md-10"  >    
                   <h4>Members Interested in You </h4>
                    </div>
          <div class="col-md-2"  style="float:right"  >
              <a href="InterestInMeProfiles.aspx" class="btn btn-theme" >View more</a>
              </div>
         </div>
                          <div class="col-lg-12" style="border:0;border-top:solid 1px #eee;margin:5px 0px"  >
                              </div>  
                    
   
                                       <div class="col-md-12"  style="border:solid 1px #DBDBDB;margin-bottom:10px;">
<asp:ListView ID="InterestListview" runat="server" >  
 <ItemTemplate>
    
      <div class="row " style="margin-top:5px" >
        
           <div class="col-md-3" >
               	<asp:Image ID="vimgSimilarPic" runat="server" CssClass="img-thumbnail"   ImageUrl='<%# "~/members/media/" + Eval("IntersestMemInPhoto") %>'  CommandArgument='<%# Eval("IntersestMemInId")+";"+ Eval("IntersestMemInPhoto") %>'    OnClick="imgmember_Click"    BorderStyle="Solid" BorderWidth="1px" BorderColor="#DFDFDF"  />
                    </div>
						  <div class="col-md-9 " >                              				
<asp:Label ID="Label51" runat="server" Text='<%# Eval("IntersestMemInName") %>' style="color:#0274CB;text-decoration:none;" />
  (<asp:Label ID="lblView" runat="server"  Text='<%# Eval("IntersestMemInId")%>' style="color:#0274CB;text-decoration:none;" target="_blank"></asp:Label>)<br />
           <asp:Label ID="vage" runat="server" Text='<%# Eval("IntersestMemInAge") %>' />, 
                                    <asp:Label ID="vheight" runat="server" Text='<%# Eval("IntersestMemInHeight") %>' /> /    
                              <asp:Label ID="Label1" runat="server" Text='<%# Eval("IntersestMemInHeightcm") %>' /> 
                                  <br />  <b>Religion:</b>  <asp:Label ID="Label41" runat="server" Text='<%# Eval("IntersestMemInReligion") %>' /> ,
                                      <asp:Label ID="CasteLabel" runat="server" Text='<%# Eval("IntersestMemInSCaste") %>' /> 
                                        <br /><b>Location:</b> <asp:Label ID="vcity" runat="server" Text='<%# Eval("IntersestMemInCity") %>' />, 
                                         <asp:Label ID="vState" runat="server" Text='<%# Eval("IntersestMemInState") %>' /> ,  
                                         
                                       <br /><b>Education:</b>    <asp:Label ID="vEducation" runat="server" Text='<%# Eval("IntersestMemInEducation") %>' /> 
                                         <br /><b>Occupation:</b>  <asp:Label ID="vOccupation" runat="server" Text='<%# Eval("IntersestMemInOccupation") %>' /> 
</div>
                 
                        
    
         </div> 
      <div class="row " style=" margin-bottom: 5px;">
   <div class="bordex"></div>  
          <div class="jsideright ">  
       <asp:LinkButton ID="ReadMoreLinkButton" runat="server"   Text="Read More"  CommandArgument='<%# Eval("IntersestMemInId") %>'     OnClick="OpenProfile" class="btn btn-info btn-xs"> </asp:LinkButton> &nbsp;&nbsp;
        <asp:LinkButton ID="lnkShortlist" runat="server" onclick="lnkShortlist_Click"  CommandArgument='<%# Eval("IntersestMemInId") %>' Text="Shortlist" class="btn btn-warning btn-xs"></asp:LinkButton>
     </div>     <%-- <asp:Label ID="varemail" runat="server" Text='<%# Eval("Email") %>'  Visible="false"/>--%>
																		
</div> 
         
</ItemTemplate>
            <LayoutTemplate>
                <div ID="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
                <div style="">
                </div>
            </LayoutTemplate>
             
        </asp:ListView>
                                            </div>
                                      </div>
        </div>
        

     
            <div class="col-lg-3"> 
                <h3 style="text-align:center">Quick Matches</h3>
       <div class="row" style="padding:10px; margin:0px; border:solid 1px #DBDBDB;background-color:#fff;margin-bottom:7px;" >
              <h4>On Family Values </h4>
                <div class="col-md-12">
           <asp:ListView ID="lstViewfamily" runat="server" 
           ><EmptyDataTemplate>
                <span>No  Profiles Found.</span></EmptyDataTemplate>
               <ItemTemplate>
                  <div class="row" style="border:solid 1px #DBDBDB;padding:5px 0;margin-bottom:7px;">
                   <div class="col-lg-5" >
                   <asp:ImageButton ID="imgSimilarPic" runat="server"   CssClass="img-thumbnail" OnClick="imgmember_Click"  CommandArgument='<%# Eval("EduMemId")+";"+ Eval("EduMemPhoto") %>'   
                   ImageUrl='<%# "~/members/media/" + Eval("EduMemPhoto") %>' /> 
                       <asp:LinkButton ID="lnkInterest" runat="server" OnClick="lnkInterest_Click"  CommandArgument='<%# Eval("EduMemId") %>' Text="Interest"></asp:LinkButton>
                </div>
                    <div class="col-lg-7" >
       <asp:LinkButton ID="lblCollege" runat="server"    CommandArgument='<%# Eval("EduMemId") %>'
         OnClick="OpenProfile" Text='<%# Eval("EduMemId") %>'></asp:LinkButton><br />
                    <asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("EduMemAge") %>' />,
                     <asp:Label ID="HeightLabel" runat="server" Text='<%# Eval("EduMemHeight") %>' />, <br />
                       <asp:Label ID="EducationLabel" runat="server" Text='<%# Eval("FamilyValue") %>' /> <br />
                        </div>
                       </div>
        </ItemTemplate><LayoutTemplate>
                <div ID="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
             
            </LayoutTemplate>
        </asp:ListView>
                    <hr />
                    </div>
             <div class="clearfix"></div>
              <h4>On Preferred Education </h4>
            <div class="col-md-12">
           <asp:ListView ID="lstViewEducation" runat="server" ><EmptyDataTemplate>
                <span>No Profiles Found.</span></EmptyDataTemplate>
               <ItemTemplate>
                      <div class="row" style="border:solid 1px #DBDBDB;padding:5px 0;margin-bottom:7px;">
                  
<div class="col-lg-5 " >
<asp:ImageButton ID="imgSimilarPic"  runat="server"    CssClass="img-thumbnail" OnClick="imgmember_Click"   CommandArgument='<%# Eval("EduMemId")+";"+ Eval("EduMemPhoto") %>'   
                   ImageUrl='<%# "~/members/media/" + Eval("EduMemPhoto") %>' /> 
    <asp:LinkButton ID="lnkInterest" runat="server" OnClick="lnkInterest_Click"  CommandArgument='<%# Eval("EduMemId") %>' Text="Interest"></asp:LinkButton>
   
</div>
                  <div class="col-lg-7" >
<asp:LinkButton ID="lblCollege" runat="server"    CommandArgument='<%# Eval("EduMemId") %>'
         OnClick="OpenProfile" Text='<%# Eval("EduMemId") %>'></asp:LinkButton><br />
                    <asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("EduMemAge") %>' />,
                     <asp:Label ID="HeightLabel" runat="server" Text='<%# Eval("EduMemHeight") %>' />, <br />
                       <asp:Label ID="EducationLabel" runat="server" Text='<%# Eval("EduMemEducation") %>' /><br />
                     
                       </div>  
                   </div>
                    
        </ItemTemplate><LayoutTemplate>
                <div ID="itemPlaceholderContainer" runat="server" >
                    <span runat="server" id="itemPlaceholder" />
                </div>
              
            </LayoutTemplate>
        </asp:ListView>
       <hr />
                </div>
             <div class="clearfix"></div>
                  
             <h4>On Preferred Occupation  </h4>
           <div class="col-md-12">
           <asp:ListView ID="lstOccupation" runat="server"  >
               <EmptyDataTemplate>
                <span>No Profiles Found.</span></EmptyDataTemplate>
               <ItemTemplate>
                     <div class="row" style="border:solid 1px #DBDBDB;padding:5px 0;margin-bottom:7px;">
                         <div class="col-lg-5" >
 <asp:ImageButton ID="imgSimilarPic" runat="server"   CssClass="img-thumbnail" OnClick="imgmember_Click"     CommandArgument='<%# Eval("EduMemId")+";"+ Eval("EduMemPhoto") %>'
                   ImageUrl='<%# "~/members/media/" + Eval("EduMemPhoto") %>' />
                             <asp:LinkButton ID="lnkInterest" runat="server" OnClick="lnkInterest_Click"  CommandArgument='<%# Eval("EduMemId") %>' Text="Interest"></asp:LinkButton>
                               </div>
                 <div class="col-lg-7" >
       <asp:LinkButton ID="lblCollege" runat="server"    CommandArgument='<%# Eval("EduMemId") %>'
         OnClick="OpenProfile" Text='<%# Eval("EduMemId") %>'></asp:LinkButton><br />
                    <asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("EduMemAge") %>' />,
                     <asp:Label ID="HeightLabel" runat="server" Text='<%# Eval("EduMemHeight") %>' />, <br />
                       <asp:Label ID="EducationLabel" runat="server" Text='<%# Eval("EduMemOccupation") %>' /> <br />
                      
                               </div>
        </ItemTemplate><LayoutTemplate>
                <div ID="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
              
            </LayoutTemplate>
        </asp:ListView> <hr />
               </div>
             <div class="clearfix"></div>
              
  </div>
           <div class="row">
               <div class="col-lg-3" >

                   <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
<!-- swapnpurti -->
<ins class="adsbygoogle"
     style="display:inline-block;width:250px;height:400px"
     data-ad-client="ca-pub-3214116742908229"
     data-ad-slot="7433745395"></ins>
<script>
(adsbygoogle = window.adsbygoogle || []).push({});
</script>
               </div>
               
               
           </div> 

                </div>   
            </div>
        <div class="row">
            <div class="col-lg-12 col-lg-offset-2" style="height=100px">
             <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
<!-- swapnpurti bottom new -->
<ins class="adsbygoogle"
     style="display:block"
     data-ad-client="ca-pub-3214116742908229"
     data-ad-slot="1108010193"
     data-ad-format="auto"></ins>
<script>
(adsbygoogle = window.adsbygoogle || []).push({});
</script>
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
		    <div id="InterestListview1" runat="server" > 
<asp:ListView ID="lstviewedProfileForEmail" runat="server" >  
           
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" width="513">
																<tbody>
                                                                    
                                                                    <tr><td>&nbsp;</td></tr>
                                                                    <tr>
																	<td align="left" valign="top" width="15"></td>
																	<td align="left" valign="top" width="102">	<asp:Image ID="vimgSimilarPic" runat="server"    ImageUrl='<%# "http://swapnpurti.in/members/media/" + Eval("Photo") %>'  Height="90px" Width="90px" BorderStyle="Solid" BorderWidth="1px" BorderColor="#DFDFDF"  /></td><td align="left" valign="top" width="15"></td>
																	<td align="left" valign="top" width="384">
																		<table border="0" cellpadding="0" cellspacing="0" width="384">
																			<tbody>
                                                                                <tr>
																				<td style="font:bold 13px arial;color:#363636;line-height:20px;" align="left" valign="top"><asp:Label ID="Label51" runat="server" Text='<%# Eval("Name") %>' /> (<asp:Label ID="lblView" runat="server"    Text='<%# Eval("Member")%>'  style="color:#0274CB;text-decoration:none;" target="_blank"></asp:Label>)
																				</td>
																			</tr>
																			<tr><td align="left" height="5" valign="top"></td></tr>
                                                                             <tr><td style="font:normal 13px/21px arial;color:#777777;" align="left" valign="top">
                                                                                  <asp:Label ID="vage" runat="server" Text='<%# Eval("Age") %>' />, 
                                                                                 <asp:Label ID="vheight" runat="server" Text='<%# Eval("Height") %>' /> |  
                                                                                  <asp:Label ID="Label41" runat="server" Text='<%# Eval("Religion") %>' /> : <asp:Label ID="CasteLabel" runat="server" Text='<%# Eval("Caste") %>' /> |
                                                                                  <b>Location:</b> <asp:Label ID="vcity" runat="server" Text='<%# Eval("City") %>' />, 
                                                                                 <asp:Label ID="vState" runat="server" Text='<%# Eval("State") %>' /> ,  
                                                                                 <asp:Label ID="vCountry" runat="server" Text='<%# Eval("Country") %>' /> |
                                                                                  <b>Education:</b>    <asp:Label ID="vEducation" runat="server" Text='<%# Eval("Education") %>' /> |
                                                                                  <b>Occupation:</b>  <asp:Label ID="vOccupation" runat="server" Text='<%# Eval("Occupation") %>' /> </td>
																			</tr> 
																		</tbody></table>
																	</td>
																</tr>
																
																<tr><td align="left" height="5" valign="top">   <asp:Label ID="varemail" runat="server" Text='<%# Eval("Email") %>'  Visible="false"/></td></tr>
															</tbody></table>
               
          </ItemTemplate>
            <LayoutTemplate>
                <div ID="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
                <div style="">
                </div>
            </LayoutTemplate>
             
        </asp:ListView>
        </div>				 
    </form>
</body>
</html>

      
        
