<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="EditFranchisee.aspx.cs" Inherits="Admin_EditFranchisee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony |  Edit Franchisee</title> 
      <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />   <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
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
                                <li  ><a href="../Member/ViewMembers.aspx">View Member</a></li>
                              
	                            </ul>
						</li>	
                        	<li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Franchisee<b class="caret"></b></a>
                              <ul class="dropdown-menu">
                                <li ><a href="ViewFranchisee.aspx">View Franchisee </a></li>                             

                        
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
                    <li ><a href="ViewFranchisee.aspx">View Franchisee</a></li> 
                       <li class="active"><a href="EditFranchisee.aspx">Edit Franchisee</a></li>
                </ul>   
		</div></div>
                 </div>
        
           <div class="franchisee">
	<div class="container">	
   <div class="row">
        <div class="col-md-2">  </div>
               
            <div class="col-md-8"> 
                  <div class="panel panel-danger center">
            <div class="panel-heading">
              <h3 class="panel-title">Edit Franchisee Details <a href="ViewFranchisee.aspx" class="backbtn">Back</a></h3>
            </div>  
                
            <div class=" panel-body">
         <div class="col-lg-12"> 
               
                <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>  Franchisee ID</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                           <asp:Label ID="lblFranId" runat="server" Text="Label" CssClass="form-control"></asp:Label>
                              </div>
                       </div>
             </div>
   <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>  Name</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                       <asp:TextBox ID="txtFraName" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                       </div>
             </div>

     
       <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>  Address</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                          <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                       </div>
             </div>
       
    
     
         <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>Country</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                           <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" CssClass="form-control"
            onselectedindexchanged="ddlCountry_SelectedIndexChanged">
             <asp:ListItem Value="">--Select Country--</asp:ListItem>
            <asp:ListItem>Afghanistan</asp:ListItem>
<asp:ListItem>Åland Islands</asp:ListItem>
<asp:ListItem>Albania</asp:ListItem>
<asp:ListItem>Algeria</asp:ListItem>
<asp:ListItem>American Samoa</asp:ListItem>
<asp:ListItem>Andorra</asp:ListItem>
<asp:ListItem>Angola</asp:ListItem>
<asp:ListItem>Anguilla</asp:ListItem>
<asp:ListItem>Antarctica</asp:ListItem>
<asp:ListItem>Antigua and Barbuda</asp:ListItem>
<asp:ListItem>Argentina</asp:ListItem>
<asp:ListItem>Armenia</asp:ListItem>
<asp:ListItem>Aruba</asp:ListItem>
<asp:ListItem>Australia</asp:ListItem>
<asp:ListItem>Austria</asp:ListItem>
<asp:ListItem>Azerbaijan</asp:ListItem>
<asp:ListItem>Bahamas</asp:ListItem>
<asp:ListItem>Bahrain</asp:ListItem>
<asp:ListItem>Bangladesh</asp:ListItem>
<asp:ListItem>Barbados</asp:ListItem>
<asp:ListItem>Belarus</asp:ListItem>
<asp:ListItem>Belgium</asp:ListItem>
<asp:ListItem>Belize</asp:ListItem>
<asp:ListItem>Benin</asp:ListItem>
<asp:ListItem>Bermuda</asp:ListItem>
<asp:ListItem>Bhutan</asp:ListItem>
<asp:ListItem>Bolivia, Plurinational State of</asp:ListItem>
<asp:ListItem>Bonaire, Sint Eustatius and Saba</asp:ListItem>
<asp:ListItem>Bosnia and Herzegovina</asp:ListItem>
<asp:ListItem>Botswana</asp:ListItem>
<asp:ListItem>Bouvet Island</asp:ListItem>
<asp:ListItem>Brazil</asp:ListItem>
<asp:ListItem>British Indian Ocean Territory</asp:ListItem>
<asp:ListItem>Brunei Darussalam</asp:ListItem>
<asp:ListItem>Bulgaria</asp:ListItem>
<asp:ListItem>Burkina Faso</asp:ListItem>
<asp:ListItem>Burundi</asp:ListItem>
<asp:ListItem>Cabo Verde</asp:ListItem>
<asp:ListItem>Cambodia</asp:ListItem>
<asp:ListItem>Cameroon</asp:ListItem>
<asp:ListItem>Canada</asp:ListItem>
<asp:ListItem>Cayman Islands</asp:ListItem>
<asp:ListItem>Central African Republic</asp:ListItem>
<asp:ListItem>Chad</asp:ListItem>
<asp:ListItem>Chile</asp:ListItem>
<asp:ListItem>China</asp:ListItem>
<asp:ListItem>Christmas Island</asp:ListItem>
<asp:ListItem>Cocos (Keeling) Islands</asp:ListItem>
<asp:ListItem>Colombia</asp:ListItem>
<asp:ListItem>Comoros</asp:ListItem>
<asp:ListItem>Congo</asp:ListItem>
<asp:ListItem>Congo, Democratic Republic of the</asp:ListItem>
<asp:ListItem>Cook Islands</asp:ListItem>
<asp:ListItem>Costa Rica</asp:ListItem>
<asp:ListItem>Côte D'Ivoire</asp:ListItem>
<asp:ListItem>Croatia</asp:ListItem>
<asp:ListItem>Cuba</asp:ListItem>
<asp:ListItem>Curaço</asp:ListItem>
<asp:ListItem>Cyprus</asp:ListItem>
<asp:ListItem>Czech Republic</asp:ListItem>
<asp:ListItem>Denmark</asp:ListItem>
<asp:ListItem>Djibouti</asp:ListItem>
<asp:ListItem>Dominica</asp:ListItem>
<asp:ListItem>Dominican Republic</asp:ListItem>
<asp:ListItem>Ecuador</asp:ListItem>
<asp:ListItem>Egypt</asp:ListItem>
<asp:ListItem>El Salvador</asp:ListItem>
<asp:ListItem>Equatorial Guinea</asp:ListItem>
<asp:ListItem>Eritrea</asp:ListItem>
<asp:ListItem>Estonia</asp:ListItem>
<asp:ListItem>Ethiopia</asp:ListItem>
<asp:ListItem>European Economic and Monetary Union area</asp:ListItem>
<asp:ListItem>Falkland Islands (Malvinas)</asp:ListItem>
<asp:ListItem>Faroe Islands</asp:ListItem>
<asp:ListItem>Fiji</asp:ListItem>
<asp:ListItem>Finland</asp:ListItem>
<asp:ListItem>France</asp:ListItem>
<asp:ListItem>French Guiana</asp:ListItem>
<asp:ListItem>French Polynesia</asp:ListItem>
<asp:ListItem>French Southern Territories</asp:ListItem>
<asp:ListItem>Gabon</asp:ListItem>
<asp:ListItem>Gambia</asp:ListItem>
<asp:ListItem>Georgia</asp:ListItem>
<asp:ListItem>Germany</asp:ListItem>
<asp:ListItem>Ghana</asp:ListItem>
<asp:ListItem>Gibraltar</asp:ListItem>
<asp:ListItem>Greece</asp:ListItem>
<asp:ListItem>Greenland</asp:ListItem>
<asp:ListItem>Grenada</asp:ListItem>
<asp:ListItem>Guadeloupe</asp:ListItem>
<asp:ListItem>Guam</asp:ListItem>
<asp:ListItem>Guatemala</asp:ListItem>
<asp:ListItem>Guernsey</asp:ListItem>
<asp:ListItem>Guinea</asp:ListItem>
<asp:ListItem>Guinea-Bissau</asp:ListItem>
<asp:ListItem>Guyana</asp:ListItem>
<asp:ListItem>Haiti</asp:ListItem>
<asp:ListItem>Heard Island and McDonald Islands</asp:ListItem>
<asp:ListItem>Holy See (Vatican City State)</asp:ListItem>
<asp:ListItem>Honduras</asp:ListItem>
<asp:ListItem>Hong Kong</asp:ListItem>
<asp:ListItem>Hungary</asp:ListItem>
<asp:ListItem>Iceland</asp:ListItem>
<asp:ListItem>India</asp:ListItem>

<asp:ListItem>Indonesia</asp:ListItem>
<asp:ListItem>Iran, Islamic Republic Of</asp:ListItem>
<asp:ListItem>Iraq</asp:ListItem>
<asp:ListItem>Ireland</asp:ListItem>
<asp:ListItem>Isle of Man</asp:ListItem>
<asp:ListItem>Israel</asp:ListItem>
<asp:ListItem>Italy</asp:ListItem>
<asp:ListItem>Jamaica</asp:ListItem>
<asp:ListItem>Japan</asp:ListItem>
<asp:ListItem>Jersey</asp:ListItem>
<asp:ListItem>Jordan</asp:ListItem>
<asp:ListItem>Kazakhstan</asp:ListItem>
<asp:ListItem>Kenya</asp:ListItem>
<asp:ListItem>Kiribati</asp:ListItem>
<asp:ListItem>Korea, Democratic People's Republic of</asp:ListItem>
<asp:ListItem>Korea, Republic of</asp:ListItem>
<asp:ListItem>Kuwait</asp:ListItem>
<asp:ListItem>Kyrgyzstan</asp:ListItem>
<asp:ListItem>Lao People's Democratic Republic</asp:ListItem>
<asp:ListItem>Latvia</asp:ListItem>
<asp:ListItem>Lebanon</asp:ListItem>
<asp:ListItem>Lesotho</asp:ListItem>
<asp:ListItem>Liberia</asp:ListItem>
<asp:ListItem>Libya</asp:ListItem>
<asp:ListItem>Liechtenstein</asp:ListItem>
<asp:ListItem>Lithuania</asp:ListItem>
<asp:ListItem>Luxembourg</asp:ListItem>
<asp:ListItem>Macao</asp:ListItem>
<asp:ListItem>Macedonia, The Former Yugoslav Republic of</asp:ListItem>
<asp:ListItem>Madagascar</asp:ListItem>
<asp:ListItem>Malawi</asp:ListItem>
<asp:ListItem>Malaysia</asp:ListItem>
<asp:ListItem>Maldives</asp:ListItem>
<asp:ListItem>Mali</asp:ListItem>
<asp:ListItem>Malta</asp:ListItem>
<asp:ListItem>Marshall Islands</asp:ListItem>
<asp:ListItem>Martinique</asp:ListItem>
<asp:ListItem>Mauritania</asp:ListItem>
<asp:ListItem>Mauritius</asp:ListItem>
<asp:ListItem>Mayotte</asp:ListItem>
<asp:ListItem>Mexico</asp:ListItem>
<asp:ListItem>Micronesia, Federated States of</asp:ListItem>
<asp:ListItem>Moldova, Republic of</asp:ListItem>
<asp:ListItem>Monaco</asp:ListItem>
<asp:ListItem>Mongolia</asp:ListItem>
<asp:ListItem>Montenegro</asp:ListItem>
<asp:ListItem>Montserrat</asp:ListItem>
<asp:ListItem>Morocco</asp:ListItem>
<asp:ListItem>Mozambique</asp:ListItem>
<asp:ListItem>Myanmar</asp:ListItem>
<asp:ListItem>Namibia</asp:ListItem>
<asp:ListItem>Nauru</asp:ListItem>
<asp:ListItem>Nepal</asp:ListItem>
<asp:ListItem>Netherlands</asp:ListItem>
<asp:ListItem>Netherlands Antilles</asp:ListItem>
<asp:ListItem>New Caledonia</asp:ListItem>
<asp:ListItem>New Zealand</asp:ListItem>
<asp:ListItem>Nicaragua</asp:ListItem>
<asp:ListItem>Niger</asp:ListItem>
<asp:ListItem>Nigeria</asp:ListItem>
<asp:ListItem>Niue</asp:ListItem>
<asp:ListItem>Norfolk Island</asp:ListItem>
<asp:ListItem>Northern Mariana Islands</asp:ListItem>
<asp:ListItem>Norway</asp:ListItem>
<asp:ListItem>Oman</asp:ListItem>
<asp:ListItem>Pakistan</asp:ListItem>
<asp:ListItem>Palau</asp:ListItem>
<asp:ListItem>Palestine, State of</asp:ListItem>
<asp:ListItem>Panama</asp:ListItem>
<asp:ListItem>Papua New Guinea</asp:ListItem>
<asp:ListItem>Paraguay</asp:ListItem>
<asp:ListItem>Peru</asp:ListItem>
<asp:ListItem>Philippines</asp:ListItem>
<asp:ListItem>Pitcairn</asp:ListItem>
<asp:ListItem>Poland</asp:ListItem>
<asp:ListItem>Portugal</asp:ListItem>
<asp:ListItem>Puerto Rico</asp:ListItem>
<asp:ListItem>Qatar</asp:ListItem>
<asp:ListItem>Réunion</asp:ListItem>
<asp:ListItem>Romania</asp:ListItem>
<asp:ListItem>Russian Federation</asp:ListItem>
<asp:ListItem>Rwanda</asp:ListItem>
<asp:ListItem>Saint Barthélemy</asp:ListItem>
<asp:ListItem>Saint Helena, Ascension and Tristan Da Cunha</asp:ListItem>
<asp:ListItem>Saint Kitts and Nevis</asp:ListItem>
<asp:ListItem>Saint Lucia</asp:ListItem>
<asp:ListItem>Saint Martin (French part)</asp:ListItem>
<asp:ListItem>Saint Pierre and Miquelon</asp:ListItem>
<asp:ListItem>Saint Vincent and The Grenadines</asp:ListItem>
<asp:ListItem>Samoa</asp:ListItem>
<asp:ListItem>San Marino</asp:ListItem>
<asp:ListItem>Sao Tome and Principe</asp:ListItem>
<asp:ListItem>Saudi Arabia</asp:ListItem>
<asp:ListItem>Senegal</asp:ListItem>
<asp:ListItem>Serbia</asp:ListItem>
<asp:ListItem>Seychelles</asp:ListItem>
<asp:ListItem>Sierra Leone</asp:ListItem>
<asp:ListItem>Singapore</asp:ListItem>
<asp:ListItem>Sint Maarten (Dutch part)</asp:ListItem>
<asp:ListItem>Slovakia</asp:ListItem>
<asp:ListItem>Slovenia</asp:ListItem>
<asp:ListItem>Solomon Islands</asp:ListItem>
<asp:ListItem>Somalia</asp:ListItem>
<asp:ListItem>South Africa</asp:ListItem>
<asp:ListItem>South Georgia and the South Sandwich Islands</asp:ListItem>
<asp:ListItem>South Sudan</asp:ListItem>
<asp:ListItem>Spain</asp:ListItem>
<asp:ListItem>Sri Lanka</asp:ListItem>
<asp:ListItem>Sudan</asp:ListItem>
<asp:ListItem>Suriname</asp:ListItem>
<asp:ListItem>Svalbard and Jan Mayen</asp:ListItem>
<asp:ListItem>Swaziland</asp:ListItem>
<asp:ListItem>Sweden</asp:ListItem>
<asp:ListItem>Switzerland</asp:ListItem>
<asp:ListItem>Syrian Arab Republic</asp:ListItem>
<asp:ListItem>Taiwan, Province of China</asp:ListItem>
<asp:ListItem>Tajikistan</asp:ListItem>
<asp:ListItem>Tanzania, United Republic of</asp:ListItem>
<asp:ListItem>Thailand</asp:ListItem>
<asp:ListItem>Timor-Leste</asp:ListItem>
<asp:ListItem>Togo</asp:ListItem>
<asp:ListItem>Tokelau</asp:ListItem>
<asp:ListItem>Tonga</asp:ListItem>
<asp:ListItem>Trinidad and Tobago</asp:ListItem>
<asp:ListItem>Tunisia</asp:ListItem>
<asp:ListItem>Turkey</asp:ListItem>
<asp:ListItem>Turkmenistan</asp:ListItem>
<asp:ListItem>Turks and Caicos Islands</asp:ListItem>
<asp:ListItem>Tuvalu</asp:ListItem>
<asp:ListItem>Uganda</asp:ListItem>
<asp:ListItem>Ukraine</asp:ListItem>
<asp:ListItem>United Arab Emirates</asp:ListItem>
<asp:ListItem>United Kingdom</asp:ListItem>
<asp:ListItem>United States</asp:ListItem>
<asp:ListItem>United States Minor Outlying Islands</asp:ListItem>
<asp:ListItem>Uruguay</asp:ListItem>
<asp:ListItem>Uzbekistan</asp:ListItem>
<asp:ListItem>Vanuatu</asp:ListItem>
<asp:ListItem>Venezuela, Bolivarian Republic of</asp:ListItem>
<asp:ListItem>Viet Nam</asp:ListItem>
<asp:ListItem>Virgin Islands, British</asp:ListItem>
<asp:ListItem>Virgin Islands, U.S.</asp:ListItem>
<asp:ListItem>Wallis And Futuna</asp:ListItem>
<asp:ListItem>Western Sahara</asp:ListItem>
<asp:ListItem>Yemen</asp:ListItem>
<asp:ListItem>Zambia</asp:ListItem>
<asp:ListItem>Zimbabwe</asp:ListItem>
        
        </asp:DropDownList>
                              </div>
                       </div>
             </div>
     
        
        <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span> State</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True"  CssClass="form-control"
            onselectedindexchanged="ddlState_SelectedIndexChanged">
               <asp:ListItem>--Select State--</asp:ListItem>
                       <asp:ListItem>Andhra Pradesh</asp:ListItem>
                                    <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                    <asp:ListItem>Assam</asp:ListItem>
                                    <asp:ListItem>Bihar</asp:ListItem>
                                    <asp:ListItem>Chattisgardh</asp:ListItem>
                                    <asp:ListItem>Goa</asp:ListItem>
                                    <asp:ListItem>Gujarat</asp:ListItem>
                                    <asp:ListItem>Haryana</asp:ListItem>
                                    <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                    <asp:ListItem>Jammu and Kashmir</asp:ListItem>
                                    <asp:ListItem>Jharkhand</asp:ListItem>
                                    <asp:ListItem>Karnataka</asp:ListItem>
                                    <asp:ListItem>Kerala</asp:ListItem>
                                    <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                    <asp:ListItem>Maharashtra</asp:ListItem>
                                    <asp:ListItem>Manipur</asp:ListItem>
                                    <asp:ListItem>Meghalaya</asp:ListItem>
                                    <asp:ListItem>Mizoram</asp:ListItem>
                                    <asp:ListItem>Nagaland</asp:ListItem>
                                    <asp:ListItem>Orissa</asp:ListItem>
                                    <asp:ListItem>Punjab</asp:ListItem>
                                    <asp:ListItem>Rajastan</asp:ListItem>
                                    <asp:ListItem>Sikkim</asp:ListItem>
                                    <asp:ListItem>Tamil Nadu</asp:ListItem>
                                    <asp:ListItem>Tripura</asp:ListItem>
                                    <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                    <asp:ListItem>Uttarakhand</asp:ListItem>
                                    <asp:ListItem>West Bengal</asp:ListItem>
                    </asp:DropDownList>
                              </div>
                       </div>
             </div>
         
       <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>City</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                             <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" CssClass="form-control">
        </asp:DropDownList>
                              </div>
                       </div>
             </div>
        
      
          <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>  Pincode</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                     <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control"></asp:TextBox>
                              </div>
                       </div>
             </div>
       
         <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span>Landline No</span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                         <asp:TextBox ID="txtlandline" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>
                              </div>
                       </div>
             </div>
     
        <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                 <div class="form-group">   
                               <span> Franchisee Status </span> 
                                 </div> 
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                          <asp:DropDownList ID="ddlfraStatus" runat="server" CssClass="form-control"  AutoPostBack="True">
     <asp:ListItem Value="">--Select Status--</asp:ListItem>
    <asp:ListItem>Active</asp:ListItem>
      <asp:ListItem>Inactive</asp:ListItem>
        </asp:DropDownList>
                              </div>
                       </div>
             </div>
          <div class="row"> 
                         <div class="col-md-1"> </div><div class="col-md-3"> 
                                
                          </div> 
                      <div class="col-md-7">
                             <div class="form-group"> 
                          <asp:Button ID="btnUpdate" runat="server" Text="Update"    onclick="btnUpdate_Click"  CssClass="btn btn-warning"/>  
              <asp:Button ID="btnCancel" runat="server"   Text="Cancel" onclick="btnCancel_Click" CssClass="btn btn-danger"/>
                              </div>
                       </div>
             </div>
      
        <%--<asp:GridView ID="grdFranchisee" runat="server" AllowSorting="True" 
            AutoGenerateColumns="False" 
            onpageindexchanging="grdFranchisee_PageIndexChanging" 
            onrowcommand="grdFranchisee_RowCommand"  >
              <Columns>               
                <asp:BoundField DataField="varFranchiseeId" HeaderText="Franchisee ID" SortExpression="intId" />
                <asp:BoundField DataField="varName" HeaderText="Franchisee Name" SortExpression="varName" />
                <asp:BoundField DataField="varDesignation" HeaderText="Designation" SortExpression="varDesignation" />
                <asp:BoundField DataField="varAddress" HeaderText="Address" SortExpression="varAddress" />
                <asp:BoundField DataField="varLandline" HeaderText="Landline" SortExpression="varGender" />
                <asp:BoundField DataField="varMobile" HeaderText="Mobile No" SortExpression="varMobile" />
                
                <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="btnEdit" runat="server" Text="Select" CommandName="Selects"  CommandArgument='<%#Eval("intId") %>' CssClass="btn btn-link"/>
                </ItemTemplate> 
                </asp:TemplateField>   
              </Columns>
        </asp:GridView>--%>
    </div>
                </div></div></div> 
       <div class="col-md-2">  </div>
        </div></div></div>
        <div class="footer">
	<div class="container">
		
		<div class="copyright">
			 <p>© 2015 Swapnpurti Matrimony All rights reserved by Swapnpurti Matrimony | Design by  <a href="http://anuvaasoft.com/" target="_blank">  Anuvaa Softech Pvt. Ltd </a></p>
		</div>
	</div>
</div>   </form>
</body>
</html>
