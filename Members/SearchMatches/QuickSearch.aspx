<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true" CodeFile="QuickSearch.aspx.cs" Inherits="Search_QuickSearch" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony | Quick Search</title>    
     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
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
<!-- animated-css --> 
</head>
<body>
    <form id="form1" runat="server">
         <div class="bann-two">
<div class="header">
			<div class="container">
		      <div class="header-main">
				<div class="logo">
					<a href="../Activities/Home.aspx"><img src="../../images/lo.png" alt=""/></a>  
				</div> 
                  <div class="logoutdiv">  
 <asp:LinkButton ID="lnkLogout" CssClass="logout" runat="server" OnClick="lnkLogout_Click" 
   ></asp:LinkButton>  
                </div>
                  <div class="notif">
                      <div class="icon-wrapper">
<a href="../Activities/Notification.aspx"> <i class="fa fa-bell-o fa-2x iconcolor"></i>
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
                                 <li  ><a href="../Activities/VisitorsProfile.aspx">Who viewed my profile</a></li>
                                <li ><a href="../Activities/ViewedProfile.aspx">Profiles I viewed</a></li> 
                                <li ><a href="../Activities/ShortlistedProfile.aspx">Shortlisted profile</a></li>
                                 <li ><a href="../Activities/WhoShortlistedMyProfile.aspx">Who Shortlisted me</a></li>
                                <li ><a href="../Activities/InterestedInProfile.aspx">Interested In profile</a></li>                               
	                            <li ><a href="../Activities/InterestInMeProfiles.aspx">Interested In Me</a></li>
	                            </ul>
						</li>	
                        	<li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" href="#">Message&nbsp;<span class="badge"><asp:Label ID="lblcountfinalmsg" runat="server" Text="0"></asp:Label></span><b class="caret"></b></a>
                              <ul class="dropdown-menu">
                                <li ><a href="../Message/Inbox.aspx">Recieved </a></li>                             
                                <li ><a href="../Message/Send.aspx">Sent</a></li>   
                                  <li ><a href="../Message/Request.aspx">Requests</a></li> 
                                <li ><a href="../Message/Notification.aspx">Notification</a></li>
                        
	                            </ul>
                        	</li> 
                       <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >My Search<b class="caret"></b></a>
                                    <ul class="dropdown-menu">
                                <li ><a href="QuickSearch.aspx">Quick Search</a></li>
                                <li ><a href="AdvancedSearch.aspx">Advanced Search</a></li> 
                                <li ><a href="RecentlyViewedProfiles.aspx">Recently viewed profile</a></li>
                               
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
                                <li ><a href="../Activities/faq.aspx" >FAQ</a></li>                         
                                          
	                            </ul>
                        	</li> 
      </ul>
   </div>
</nav><div class="clearfix"> </div>

         </div>
          <div class="franchisee">
	<div class="container">	
    <div class="col-lg-8">
    <h3>  Quick Search </h3> 
                      <div class="borsolid"></div>  
   <span class="j10font"> Quick Search is the most popular search based on a few important criteria one would look for in a life partner. </span> <br />
        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Age </span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">      
    
        <div class="row"> 

                         <div class="col-md-4"> 
                             <asp:DropDownList ID="ddlagefrom" runat="server"  AppendDataBoundItems="True" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlagefrom_SelectedIndexChanged">
        <asp:ListItem>--Select--</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
<asp:ListItem>20</asp:ListItem>
<asp:ListItem>21</asp:ListItem>
<asp:ListItem>22</asp:ListItem>
<asp:ListItem>23</asp:ListItem>
<asp:ListItem>24</asp:ListItem>
<asp:ListItem>25</asp:ListItem>
<asp:ListItem>26</asp:ListItem>
<asp:ListItem>27</asp:ListItem>
<asp:ListItem>28</asp:ListItem>
<asp:ListItem>29</asp:ListItem>
<asp:ListItem>30</asp:ListItem>
<asp:ListItem>31</asp:ListItem>
<asp:ListItem>32</asp:ListItem>
<asp:ListItem>33</asp:ListItem>
<asp:ListItem>34</asp:ListItem>
<asp:ListItem>35</asp:ListItem>
<asp:ListItem>36</asp:ListItem>
<asp:ListItem>37</asp:ListItem>
<asp:ListItem>38</asp:ListItem>
<asp:ListItem>39</asp:ListItem>
<asp:ListItem>40</asp:ListItem>
<asp:ListItem>41</asp:ListItem>
<asp:ListItem>42</asp:ListItem>
<asp:ListItem>43</asp:ListItem>
<asp:ListItem>44</asp:ListItem>
<asp:ListItem>45</asp:ListItem>
<asp:ListItem>46</asp:ListItem>
<asp:ListItem>47</asp:ListItem>
<asp:ListItem>48</asp:ListItem>
<asp:ListItem>49</asp:ListItem>
<asp:ListItem>50</asp:ListItem>
<asp:ListItem>51</asp:ListItem>
<asp:ListItem>52</asp:ListItem>
<asp:ListItem>53</asp:ListItem>
<asp:ListItem>54</asp:ListItem>
<asp:ListItem>55</asp:ListItem>
<asp:ListItem>56</asp:ListItem>
<asp:ListItem>57</asp:ListItem>
<asp:ListItem>58</asp:ListItem>
<asp:ListItem>59</asp:ListItem>
<asp:ListItem>60</asp:ListItem>
<asp:ListItem>61</asp:ListItem>
<asp:ListItem>62</asp:ListItem>
<asp:ListItem>63</asp:ListItem>
<asp:ListItem>64</asp:ListItem>
<asp:ListItem>65</asp:ListItem>
<asp:ListItem>66</asp:ListItem>
<asp:ListItem>67</asp:ListItem>
<asp:ListItem>68</asp:ListItem>
<asp:ListItem>69</asp:ListItem>
<asp:ListItem>70</asp:ListItem>

        </asp:DropDownList>              
</div>
         <div class="col-md-1">    <asp:Label ID="Label39" runat="server" Text="To"></asp:Label></div>
         <div class="col-md-4"> 
                <asp:DropDownList ID="ddlageto" runat="server" CssClass="form-control" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select--</asp:ListItem>
      
        </asp:DropDownList>
      </div>
          

  </div>
           </div></div></div>
        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Height</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">  
                  <div class="row">
                        <div class="col-md-4"> 
      
         <asp:DropDownList ID="ddlHeighFrom" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlHeighFrom_SelectedIndexChanged" >
<asp:ListItem>--Feet/Inches--</asp:ListItem>
            <asp:ListItem   >4ft 6in</asp:ListItem>
        <asp:ListItem   >4ft 7in</asp:ListItem>
        <asp:ListItem  >4ft 8in</asp:ListItem>
        <asp:ListItem >4ft 9in</asp:ListItem>
        <asp:ListItem  >4ft 10in</asp:ListItem>
        <asp:ListItem  >4ft 11in</asp:ListItem>
        <asp:ListItem >5ft 0in</asp:ListItem>
        <asp:ListItem >5ft 1in</asp:ListItem>
        <asp:ListItem  >5ft 2in</asp:ListItem>
        <asp:ListItem >5ft 3in</asp:ListItem>
        <asp:ListItem  >5ft 4in</asp:ListItem>
        <asp:ListItem  >5ft 5in</asp:ListItem>
        <asp:ListItem >5ft 6in</asp:ListItem>
        <asp:ListItem >5ft 7in</asp:ListItem>
        <asp:ListItem  >5ft 8in</asp:ListItem>
        <asp:ListItem  >5ft 9in</asp:ListItem>
        <asp:ListItem >5ft 10in</asp:ListItem>
        <asp:ListItem  >5ft 11in</asp:ListItem>
        <asp:ListItem  >6ft 0in</asp:ListItem>
        <asp:ListItem  >6ft 1in</asp:ListItem>
        <asp:ListItem  >6ft 2in</asp:ListItem>
        <asp:ListItem  >6ft 3in</asp:ListItem>
        <asp:ListItem >6ft 4in</asp:ListItem>
        <asp:ListItem  >6ft 5in</asp:ListItem>
        <asp:ListItem  >6ft 6in</asp:ListItem>
        <asp:ListItem >6ft 7in</asp:ListItem>
        <asp:ListItem >6ft 8in</asp:ListItem>
        <asp:ListItem  >6ft 9in</asp:ListItem>
        <asp:ListItem >6ft 10in</asp:ListItem>
        <asp:ListItem >6ft 11in</asp:ListItem>
       

        </asp:DropDownList>

        </div>
         <div class="col-md-1">    <asp:Label ID="Label1" runat="server" Text="To"></asp:Label></div>
         <div class="col-md-4"> 
         <asp:DropDownList ID="ddlHeighTo" runat="server"  CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlHeighTo_SelectedIndexChanged" >
<asp:ListItem>--Feet/Inches--</asp:ListItem>
           
        <asp:ListItem   >4ft 7in</asp:ListItem>
        <asp:ListItem  >4ft 8in</asp:ListItem>
        <asp:ListItem >4ft 9in</asp:ListItem>
        <asp:ListItem  >4ft 10in</asp:ListItem>
        <asp:ListItem  >4ft 11in</asp:ListItem>
        <asp:ListItem >5ft 0in</asp:ListItem>
        <asp:ListItem >5ft 1in</asp:ListItem>
        <asp:ListItem  >5ft 2in</asp:ListItem>
        <asp:ListItem >5ft 3in</asp:ListItem>
        <asp:ListItem  >5ft 4in</asp:ListItem>
        <asp:ListItem  >5ft 5in</asp:ListItem>
        <asp:ListItem >5ft 6in</asp:ListItem>
        <asp:ListItem >5ft 7in</asp:ListItem>
        <asp:ListItem  >5ft 8in</asp:ListItem>
        <asp:ListItem  >5ft 9in</asp:ListItem>
        <asp:ListItem >5ft 10in</asp:ListItem>
        <asp:ListItem  >5ft 11in</asp:ListItem>
        <asp:ListItem  >6ft 0in</asp:ListItem>
        <asp:ListItem  >6ft 1in</asp:ListItem>
        <asp:ListItem  >6ft 2in</asp:ListItem>
        <asp:ListItem  >6ft 3in</asp:ListItem>
        <asp:ListItem >6ft 4in</asp:ListItem>
        <asp:ListItem  >6ft 5in</asp:ListItem>
        <asp:ListItem  >6ft 6in</asp:ListItem>
        <asp:ListItem >6ft 7in</asp:ListItem>
        <asp:ListItem >6ft 8in</asp:ListItem>
        <asp:ListItem  >6ft 9in</asp:ListItem>
        <asp:ListItem >6ft 10in</asp:ListItem>
        <asp:ListItem >6ft 11in</asp:ListItem>
        <asp:ListItem >7ft 0in</asp:ListItem> 

</asp:DropDownList>
        </div>
  </div>
           </div></div></div>
                      <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Marital status</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">
             <div class="form-group">      
 
        <asp:DropDownList ID="ddlMstatus" runat="server"   AppendDataBoundItems="true"  
               CssClass="form-control"  AutoPostBack="True">
        <asp:ListItem>--Select--</asp:ListItem>
        <asp:ListItem>Never Married</asp:ListItem>
<asp:ListItem>Widow</asp:ListItem>
<asp:ListItem>Divorced</asp:ListItem>
<asp:ListItem>Awaiting divorce</asp:ListItem>
<asp:ListItem>Does Not Matter</asp:ListItem>
            </asp:DropDownList>
                 </div></div></div>

        <div class="row"> 
 <div class="col-md-4">  
                      <div class="form-group">    
                          <span>Mother Tongue</span>
                          </div>
                             </div>
     <div class="col-md-8"> 
        <div class="form-group">  
   <asp:DropDownList ID="ddlMotherTongue" runat="server"  AppendDataBoundItems="true" CssClass="form-control">
    <asp:ListItem>--Select Mother Tongue--</asp:ListItem>
<asp:ListItem>Angika</asp:ListItem>
<asp:ListItem>Arunachali</asp:ListItem>
<asp:ListItem>Assamese</asp:ListItem>
<asp:ListItem>Awadhi</asp:ListItem>
<asp:ListItem>Bengali</asp:ListItem>
<asp:ListItem>Bhojpuri</asp:ListItem>
<asp:ListItem>Brij</asp:ListItem>
<asp:ListItem>Bihari</asp:ListItem>
<asp:ListItem>Badaga</asp:ListItem>
<asp:ListItem>Chatisgarhi</asp:ListItem>
<asp:ListItem>Dogri</asp:ListItem>
<asp:ListItem>English</asp:ListItem>
<asp:ListItem>French</asp:ListItem>
<asp:ListItem>Garhwali</asp:ListItem>
<asp:ListItem>Garo</asp:ListItem>
<asp:ListItem>Gujarati</asp:ListItem>
<asp:ListItem>Haryanvi</asp:ListItem>
<asp:ListItem>Himachali/Pahari</asp:ListItem>
<asp:ListItem>Hindi</asp:ListItem>
<asp:ListItem>Kanauji</asp:ListItem>
<asp:ListItem>Kannada</asp:ListItem>
<asp:ListItem>Kashmiri</asp:ListItem>
<asp:ListItem>Khandesi</asp:ListItem>
<asp:ListItem>Khasi</asp:ListItem>
<asp:ListItem>Konkani</asp:ListItem>
<asp:ListItem>Koshali</asp:ListItem>
<asp:ListItem>Kumaoni</asp:ListItem>
<asp:ListItem>Kutchi</asp:ListItem>
<asp:ListItem>Lepcha</asp:ListItem>
<asp:ListItem>Ladacki</asp:ListItem>
<asp:ListItem>Magahi</asp:ListItem>
<asp:ListItem>Maithili</asp:ListItem>
<asp:ListItem>Malayalam</asp:ListItem>
<asp:ListItem>Manipuri</asp:ListItem>
<asp:ListItem>Marathi</asp:ListItem>
<asp:ListItem>Marwari</asp:ListItem>
<asp:ListItem>Miji</asp:ListItem>
<asp:ListItem>Mizo</asp:ListItem>
<asp:ListItem>Monpa</asp:ListItem>
<asp:ListItem>Nicobarese</asp:ListItem>
<asp:ListItem>Nepali</asp:ListItem>
<asp:ListItem>Oriya</asp:ListItem>
<asp:ListItem>Punjabi</asp:ListItem>
<asp:ListItem>Rajasthani</asp:ListItem>
<asp:ListItem>Sanskrit</asp:ListItem>
<asp:ListItem>Santhali</asp:ListItem>
<asp:ListItem>Sindhi</asp:ListItem>
<asp:ListItem>Sourashtra</asp:ListItem>
<asp:ListItem>Tamil</asp:ListItem>
<asp:ListItem>Telugu</asp:ListItem>
<asp:ListItem>Tripuri</asp:ListItem>
<asp:ListItem>Tulu</asp:ListItem>
<asp:ListItem>Urdu</asp:ListItem>

        </asp:DropDownList>
           </div>
         </div></div>
          <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Religion</span> 
                       </div> 
                             </div> 
                      <div class="col-md-8">     
 
       <div class="form-group">
             <asp:DropDownList ID="ddlReligion" runat="server"  AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddlReligion_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem>--Select Religion--</asp:ListItem>
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
             <asp:DropDownList ID="ddlCaste" runat="server"  AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem>--Select--</asp:ListItem>
   
        </asp:DropDownList>
      
          </div></div>
                        </div>

             <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>City</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                                    <asp:DropDownList ID="ddlcity" runat="server"  AppendDataBoundItems="true" CssClass="form-control"  DataTextField="varCity"      DataValueField="varCity">
        <asp:ListItem>--Select City--</asp:ListItem></asp:DropDownList>
                                             </div>
                                        </div>
             </div>
          
          <div class="row"> 
                         <div class="col-md-4"> 
                                
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group">  
                                                <asp:Button ID="btnSearch" runat="server" Text="Search Now"   CssClass="loginbtn" OnClick="btnSearch_Click" />
                                             </div>
                                        </div>
             </div>

        </div></div></div>
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
