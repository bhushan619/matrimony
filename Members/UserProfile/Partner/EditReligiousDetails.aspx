<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="EditReligiousDetails.aspx.cs" Inherits="members_UserProfile_Partner_EditReligiousDetails" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony |  Religious Details</title>   
      <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../../images/favicon.ico" type="image/x-icon" />
<link href="../../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="../../../js/jquery-1.11.0.min.js"></script>
<!-- Custom Theme files -->
<link href="../../../css/style.css" rel="stylesheet" type="text/css" media="all"/>
<!-- Custom Theme files -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); }>
</script>
<meta name="keywords" content="Matrimony Website, Maharashtra, India, Indian, Hindi, Marathi, Tamil, Telugu, Franchisee, Marriage" />
<!--Google Fonts-->
<!-- start-smoth-scrolling -->
<script type="text/javascript" src="../../../js/move-top.js"></script>
<script type="text/javascript" src="../../../js/easing.js"></script>
        <link href="../../../css/font-awesome.css" rel="stylesheet" /> 
     <script src="../../../js/bootstrap.js"></script>
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
		<link href="../../../css/animate.css" rel="stylesheet" type="text/css" media="all">
		<script src="../../../js/wow.min.js"></script>
		<script>
		    new WOW().init();
		</script>
    <!-- multiselect dropdown -->
 
    <link href="../../../css/select2.css" rel="stylesheet" />
    <script src="../../../css/select2.js"></script>
    <link href="../../../css/select2-bootstrap.css" rel="stylesheet" />
    <script>
        function myFunction() {
            var vals = $("#ddlMotherTongue").select2('val');
            document.getElementById("dtaMotherTongue").value = vals;

            var vala = $("#ddlCaste").select2('val');
            document.getElementById("dtaCaste").value = vala;

           
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="bann-two">
	<div class="header">
			<div class="container">
		      <div class="header-main">
				<div class="logo">
					<a href="../../Activities/Home.aspx"><img src="../../../images/lo.png" alt=""/></a>  
				</div> 
                  <div class="logoutdiv">  
 <asp:LinkButton ID="lnkLogout" CssClass="logout" runat="server" OnClick="lnkLogout_Click" 
   ></asp:LinkButton>  
                </div>
                  <div class="notif">
                      <div class="icon-wrapper">
<a href="../../Activities/Notification.aspx"> <i class="fa fa-bell-o fa-2x iconcolor"></i>
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
                                <li  ><a href="../../Activities/VisitorsProfile.aspx">Who viewed my profile</a></li>
                                <li ><a href="../../Activities/ViewedProfile.aspx">Profiles I viewed</a></li> 
                                <li ><a href="../../Activities/ShortlistedProfile.aspx">Shortlisted profile</a></li>
                                 <li ><a href="../../Activities/WhoShortlistedMyProfile.aspx">Who Shortlisted me</a></li>
                                <li ><a href="../../Activities/InterestedInProfile.aspx">Interested In profile</a></li>                               
	                            <li ><a href="../../Activities/InterestInMeProfiles.aspx">Interested In Me</a></li>
	                            </ul>
						</li>	
                        	<li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Message&nbsp;<span class="badge"><asp:Label ID="lblcountfinalmsg" runat="server" Text="0"></asp:Label></span><b class="caret"></b></a>
                              <ul class="dropdown-menu">
                                <li ><a href="../../Message/Inbox.aspx">Recieved </a></li>                             
                                <li ><a href="../../Message/Send.aspx">Sent</a></li>   
                                  <li ><a href="../../Message/Request.aspx">Requests</a></li> 
                              <li ><a href="../../Activities/Notification.aspx">Notification</a></li> 
                        
	                            </ul>
                        	</li> 
                       <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >My Search<b class="caret"></b></a>
                               <ul class="dropdown-menu">
                                <li ><a href="../../SearchMatches/QuickSearch.aspx">Quick Search</a></li>
                                <li ><a href="../../SearchMatches/AdvancedSearch.aspx">Advanced Search</a></li> 
                                <li ><a href="../../SearchMatches/RecentlyViewedProfiles.aspx">Recently viewed profile</a></li>
                               
	                            </ul>
                        	</li> 
                         <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Profile<b class="caret"></b></a>
                               <ul class="dropdown-menu">
                                <li><a href="../Self/EditPersonalDetails.aspx">Edit MyProfile</a></li>
                                <li><a href="EditPersonalDetails.aspx">Edit Partner Profile</a></li> 
                                    <li><a href="../Self/EditContactDetail.aspx">Edit Contact Details</a></li>   
                                    <li><a href="../../Photo/InfoUpload.aspx">Upload Photo/Biodata</a></li> 
                                    <li><a href="../../Setting/ChangePassword.aspx">Change Password</a></li> 
                                    <li><a href="../../Setting/DeleteProfile.aspx" >Delete Profile</a></li> 
	                            </ul> 
                        	</li> 
                        <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Upgrade<b class="caret"></b></a>
                                 <ul class="dropdown-menu">
                                      <li ><a href="../../Subscription/ViewPackage.aspx">Payment Option</a></li>   <li ><a href="../../Subscription/ViewOrders.aspx">View Orders</a></li>                                                                                            
                               
	                            </ul>
                        	</li> 
                          <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Help<b class="caret"></b></a>
                                 <ul class="dropdown-menu">
                                <li ><a href="#">FAQ</a></li>                         
                                          
	                            </ul>
                        	</li> 
      </ul>
   </div>
</nav><div class="clearfix"> </div>

         </div>

        <div class="container">
           <div class="franchisee">
	<div class="container">	
        <div class="row">
      
               <ul class="nav nav-tabs">
  <li ><a href="../Self/EditPersonalDetails.aspx"> Edit My Profile</a></li>
  <li class="active"><a href="EditPersonalDetails.aspx">Edit Partner Profile</a></li>
<li> <a href="../../Setting/ChangePassword.aspx">Settings</a></li>
</ul>
               </div>
          <div class="row">
               <div class="col-lg-3 bhoechie-tab-menu">
               <div class="list-group"> 
                <a href="EditPersonalDetails.aspx" class="list-group-item ">
                 <i class="fa fa-user"></i>  Basic Details
                </a>
                <a href="EditPhysicalDetails.aspx" class="list-group-item">
                   <i class="fa fa-heart"></i>    Physical Details
                </a>
                    <a href="EditProfessionalDetails.aspx" class="list-group-item">
             <i class="fa fa-briefcase"></i>   Professional Details
                </a>
                    <a href="EditReligiousDetails.aspx" class="list-group-item active">
                    <i class="fa fa-arrows-alt"></i>  Religious Details
                </a> 
                    <a href="EditFamilyDetails.aspx" class="list-group-item ">
                <i class="fa fa-crosshairs"></i>Family Details
                </a> 
                     <a href="EditLifeStyleDetails.aspx" class="list-group-item">
         <i class="fa fa-glass"></i>   Lifestyle Details
                </a> 
              </div>
            </div>
         <div class="col-lg-9 bhoechie-tab-container">
            
            <div class="bhoechie-tab">
             
                <div class="bhoechie-tab-content active">
                     <div class="row">  
                          <div class="col-md-12"> 
                 <ul class="breadcrumb text-left">
   <li>Edit Partner Profile</li>
   <li><a href= "EditFamilyDetails.aspx">Edit Partner Religious Details</a></li>

</ul>
		 </div>  </div> 
                    <div class="row">
                       <div class="col-md-1" ></div>
                         
                <div class="col-md-10" >                   
                   <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>Mother Tongue</span>
                          </div>
                             </div>
     <div class="col-md-8"> 
        <div class="form-group">  
   <select id="ddlMotherTongue" runat="server"  multiple="true"  style="width:280px">
    
<option>Angika</option>
<option>Arunachali</option>
<option>Assamese</option>
<option>Awadhi</option>
<option>Bengali</option>
<option>Bhojpuri</option>
<option>Brij</option>
<option>Bihari</option>
<option>Badaga</option>
<option>Chatisgarhi</option>
<option>Dogri</option>
<option>English</option>
<option>French</option>
<option>Garhwali</option>
<option>Garo</option>
<option>Gujarati</option>
<option>Haryanvi</option>
<option>Himachali/Pahari</option>
<option>Hindi</option>
<option>Kanauji</option>
<option>Kannada</option>
<option>Kashmiri</option>
<option>Khandesi</option>
<option>Khasi</option>
<option>Konkani</option>
<option>Koshali</option>
<option>Kumaoni</option>
<option>Kutchi</option>
<option>Lepcha</option>
<option>Ladacki</option>
<option>Magahi</option>
<option>Maithili</option>
<option>Malayalam</option>
<option>Manipuri</option>
<option>Marathi</option>
<option>Marwari</option>
<option>Miji</option>
<option>Mizo</option>
<option>Monpa</option>
<option>Nicobarese</option>
<option>Nepali</option>
<option>Oriya</option>
<option>Punjabi</option>
<option>Rajasthani</option>
<option>Sanskrit</option>
<option>Santhali</option>
<option>Sindhi</option>
<option>Sourashtra</option>
<option>Tamil</option>
<option>Telugu</option>
<option>Tripuri</option>
<option>Tulu</option>
<option>Urdu</option>


        </select>
            <%-- MotherTongue --%>
         <asp:HiddenField ID="dtaMotherTongue" runat="server"  />
       <script> 
          
          $(document).ready(function () {
              $("#ddlMotherTongue").select2({ placeholder: 'Find and Select Mother Tongue' });
          });
          
</script>
       <%-- MotherTongue end --%>
           </div>
         </div></div>
                     <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Religion</span> 
                       </div> 
                             </div> 
                      <div class="col-md-5">     
 
       <div class="form-group">  <asp:DropDownList ID="ddlReligion" runat="server"  OnSelectedIndexChanged="ddlReligion_SelectedIndexChanged" required="required" AppendDataBoundItems="true" CssClass="form-control" AutoPostBack="True">
        <asp:ListItem Value="">--Select Religion--</asp:ListItem>
     <asp:ListItem>Hindu</asp:ListItem>
<asp:ListItem>Muslim</asp:ListItem>
<asp:ListItem>Christian</asp:ListItem>
<asp:ListItem>Sikh</asp:ListItem>
<asp:ListItem>Jain</asp:ListItem>
<asp:ListItem>Buddhist</asp:ListItem>
<asp:ListItem>Spiritual</asp:ListItem>
<asp:ListItem>Parsi</asp:ListItem>
<asp:ListItem>Jewish </asp:ListItem>
<asp:ListItem>other</asp:ListItem>
<asp:ListItem>Inter-Religion</asp:ListItem>
<asp:ListItem>No-Religious Belief</asp:ListItem>

        </asp:DropDownList>
       
           </div></div>
                 </div>                 
                     <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>Caste/Division</span>
                          </div>
                             </div>
     <div class="col-md-8">
       <div class="form-group">
             <select id="ddlCaste" runat="server" multiple="true"  style="width:280px"> 
        </select>
       <%-- MotherTongue --%>
         <asp:HiddenField ID="dtaCaste" runat="server"  />
       <script> 
          
          $(document).ready(function () {
              $("#ddlCaste").select2({ placeholder: 'Find and Select Caste' });
          });
          
</script>
       <%-- MotherTongue end --%>
          </div></div>
                        </div><%--<div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Languages</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group"> 
 
         <asp:TextBox ID="txtSubCaste" runat="server" CssClass="form-control"></asp:TextBox>
       </div></div></div>--%>
                        
                    <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Manglik</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
   <div class="form-group"> 
   
        <asp:RadioButton ID="rgbManglikYes" runat="server" GroupName="rgbManglik" 
            Text="Yes" />
    &nbsp;&nbsp;    <asp:RadioButton ID="rgbManglikNo" runat="server" GroupName="rgbManglik" 
            Text="No" />
    &nbsp;&nbsp;    <asp:RadioButton ID="rgbManglikNotKnow" runat="server" GroupName="rgbManglik" 
            Text="Does not matter" />
      </div></div></div>
                   <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Star</span> 
                       </div> 
                             </div> 
                      <div class="col-md-5">
             <div class="form-group"> 
         
        <asp:DropDownList ID="ddlStar" runat="server" AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem Value="">--Select Star--</asp:ListItem>
        <asp:ListItem>Aswini</asp:ListItem>
<asp:ListItem>Bharani</asp:ListItem>
<asp:ListItem>Kruthiga</asp:ListItem>
 <asp:ListItem>Mrigasira</asp:ListItem>
<asp:ListItem>Arudra</asp:ListItem>
<asp:ListItem>Punarvasu</asp:ListItem>
<asp:ListItem>Pushya</asp:ListItem>
<asp:ListItem>Asilesha</asp:ListItem>
<asp:ListItem>Magha</asp:ListItem>
<asp:ListItem>Poorvaphalguni</asp:ListItem>
<asp:ListItem>Uthiraphalgunu</asp:ListItem>
<asp:ListItem>Hastha</asp:ListItem>
<asp:ListItem>Chitra</asp:ListItem>
<asp:ListItem>Swathi</asp:ListItem>
<asp:ListItem>Visaka</asp:ListItem>
<asp:ListItem>Anuradha</asp:ListItem>
<asp:ListItem>Jyeshta</asp:ListItem>
<asp:ListItem>Mula</asp:ListItem>
<asp:ListItem>Poorvashada</asp:ListItem>
<asp:ListItem>Uthrashada</asp:ListItem>
<asp:ListItem>Sravan</asp:ListItem>
<asp:ListItem>Dhanishta</asp:ListItem>
<asp:ListItem>Shatataraka</asp:ListItem>
<asp:ListItem>Poorvabhadra</asp:ListItem>
<asp:ListItem>Uthirabhadra</asp:ListItem>
<asp:ListItem>Revathi</asp:ListItem>

        </asp:DropDownList>
                 </div></div></div>
                   <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Raashi/Moon Sign</span> 
                       </div> 
                             </div> 
                      <div class="col-md-5">
             <div class="form-group">     
        <asp:DropDownList ID="ddlRaashi" runat="server" AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem Value="">--Select Raashi/Moon Sign--</asp:ListItem>
                <asp:ListItem>Mesha (Aries)</asp:ListItem>
<asp:ListItem>Vrishabha (Taurus)</asp:ListItem>
<asp:ListItem>Mithun (Gemini)</asp:ListItem>
<asp:ListItem>Karka (Cancer)</asp:ListItem>
<asp:ListItem>Simha / Sinh (Leo)</asp:ListItem>
<asp:ListItem>Kanya (Vigro)</asp:ListItem>
<asp:ListItem>Tula (Libra)</asp:ListItem>
<asp:ListItem>Vruschika (Scorpius)</asp:ListItem>
<asp:ListItem>Dhanu (Sagittarius)</asp:ListItem>
<asp:ListItem>Makar (Capricorn)</asp:ListItem>
<asp:ListItem>Kumbha (Aquarius)</asp:ListItem>
<asp:ListItem>Meena (Pisces)</asp:ListItem>

        </asp:DropDownList>
       </div></div></div>
                   <div class="row"> 
 <div class="col-md-4">  
                     </div>
     <div class="col-md-8">
     <div class="form-group"> 
        <asp:Button ID="btnreligiousSave" runat="server" Text="Save"  OnClientClick="myFunction()" CssClass="loginbtn" OnClick="btnreligiousSave_Click"/>
       </div> </div></div>

	</div>

                      </div></div></div></div>

          </div></div>
        </div>
           </div>
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
