<%@ Page MaintainScrollPositionOnPostback="true"    Language="C#" AutoEventWireup="true" CodeFile="AdvancedSearch.aspx.cs" Inherits="Search_AdvancedSearch" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony |Advanced search</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
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
        <link href="../css/font-awesome.css" rel="stylesheet" /> 
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
      <!-- multiselect dropdown -->
    
    <link href="../../css/select2.css" rel="stylesheet" />
    <script src="../../css/select2.js"></script>
    <link href="../../css/select2-bootstrap.css" rel="stylesheet" />
    <script>
        function myFunction() {
            var vals = $("#ddlMotherTongue").select2('val');
            document.getElementById("dtaMotherTongue").value = vals;

            var vala = $("#ddlCaste").select2('val');
            document.getElementById("dtaCaste").value = vala;

            var vals = $("#ddleducation").select2('val');
            document.getElementById("dtaSelect").value = vals;

            //var vala = $("#ddlEmployeeIn").select2('val');
            //document.getElementById("dtaEmployeeIn").value = vala;

            var vald = $("#ddlfunctional").select2('val');
            document.getElementById("dtafunctional").value = vald;

            var valco = $("#ddlCountry").select2('val');
            document.getElementById("dtacountry").value = valco;

            var valci = $("#cmbcity").select2('val');
            document.getElementById("dtacmbcity").value = valci;

            var valst = $("#ddlStar").select2('val');
            document.getElementById("dtaddlStar").value = valst;

        }
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
              <div class="container">
                  <div class="franchisee">
	<div class="container">	
    <div class="col-lg-8">
    <h3>  Advanced Search </h3> 
                      <div class="borsolid"></div>  
   <span class="j10font"> Advanced Search is the most popular search based on a few important criteria one would look for in a life partner. </span> <br /><br />
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
        <asp:ListItem >--Select--</asp:ListItem>
      
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
              <select id="ddlCaste" runat="server" multiple="true"  style="width:280px"> 
        </select>
       <%-- caste --%>
         <asp:HiddenField ID="dtaCaste" runat="server"  />
       <script> 
          
          $(document).ready(function () {
              $("#ddlCaste").select2({ placeholder: 'Find and Select Caste' });
          });
          
</script>
      
          </div></div>
                        </div>
        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Physical Status</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                                    <asp:DropDownList ID="ddlSpecialCase" runat="server"  AppendDataBoundItems="true" CssClass="form-control">
         <asp:ListItem>--Select Special Case--</asp:ListItem>
   <asp:ListItem >Does not Matter</asp:ListItem>
 <asp:ListItem>None</asp:ListItem>
   <asp:ListItem>Physically challenged from birth</asp:ListItem> 
      <asp:ListItem>Hiv positive</asp:ListItem> 
 <asp:ListItem>Mentally challenged from birth</asp:ListItem>         
     <asp:ListItem>Accidental / Physical abnormality affecting only looks</asp:ListItem>
 <asp:ListItem>Physical abnormality affecting bodily functions due to accident</asp:ListItem>
 <asp:ListItem>Physically challenged due to accident</asp:ListItem>
 <asp:ListItem>Medically challenged condition of one or more vital organs</asp:ListItem>
        </asp:DropDownList>
                                             </div>
                                        </div>
             </div>
        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Country Living In</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                              <select id="ddlCountry" runat="server"  multiple="true"  style="width:280px">
            <option>Afghanistan</option>
<option>Aland Islands</option>
<option>Albania</option>
<option>Algeria</option>
<option>American Samoa</option>
<option>Andorra</option>
<option>Angola</option>
<option>Anguilla</option>
<option>Antarctica</option>
<option>Antigua and Barbuda</option>
<option>Argentina</option>
<option>Armenia</option>
<option>Aruba</option>
<option>Australia</option>
<option>Austria</option>
<option>Azerbaijan</option>
<option>Bahamas</option>
<option>Bahrain</option>
<option>Bangladesh</option>
<option>Barbados</option>
<option>Belarus</option>
<option>Belgium</option>
<option>Belize</option>
<option>Benin</option>
<option>Bermuda</option>
<option>Bhutan</option>
<option>Bolivia, Plurinational State of</option>
<option>Bonaire, Sint Eustatius and Saba</option>
<option>Bosnia and Herzegovina</option>
<option>Botswana</option>
<option>Bouvet Island</option>
<option>Brazil</option>
<option>British Indian Ocean Territory</option>
<option>Brunei Darussalam</option>
<option>Bulgaria</option>
<option>Burkina Faso</option>
<option>Burundi</option>
<option>Cabo Verde</option>
<option>Cambodia</option>
<option>Cameroon</option>
<option>Canada</option>
<option>Cayman Islands</option>
<option>Central African Republic</option>
<option>Chad</option>
<option>Chile</option>
<option>China</option>
<option>Christmas Island</option>
<option>Cocos (Keeling) Islands</option>
<option>Colombia</option>
<option>Comoros</option>
<option>Congo</option>
<option>Congo, Democratic Republic of the</option>
<option>Cook Islands</option>
<option>Costa Rica</option>
<option>Côte D'Ivoire</option>
<option>Croatia</option>
<option>Cuba</option>
<option>Curaço</option>
<option>Cyprus</option>
<option>Czech Republic</option>
<option>Denmark</option>
<option>Djibouti</option>
<option>Dominica</option>
<option>Dominican Republic</option>
<option>Ecuador</option>
<option>Egypt</option>
<option>El Salvador</option>
<option>Equatorial Guinea</option>
<option>Eritrea</option>
<option>Estonia</option>
<option>Ethiopia</option>
<option>European Economic and Monetary Union area</option>
<option>Falkland Islands (Malvinas)</option>
<option>Faroe Islands</option>
<option>Fiji</option>
<option>Finland</option>
<option>France</option>
<option>French Guiana</option>
<option>French Polynesia</option>
<option>French Southern Territories</option>
<option>Gabon</option>
<option>Gambia</option>
<option>Georgia</option>
<option>Germany</option>
<option>Ghana</option>
<option>Gibraltar</option>
<option>Greece</option>
<option>Greenland</option>
<option>Grenada</option>
<option>Guadeloupe</option>
<option>Guam</option>
<option>Guatemala</option>
<option>Guernsey</option>
<option>Guinea</option>
<option>Guinea-Bissau</option>
<option>Guyana</option>
<option>Haiti</option>
<option>Heard Island and McDonald Islands</option>
<option>Holy See (Vatican City State)</option>
<option>Honduras</option>
<option>Hong Kong</option>
<option>Hungary</option>
<option>Iceland</option>
<option>India</option>

<option>Indonesia</option>
<option>Iran, Islamic Republic Of</option>
<option>Iraq</option>
<option>Ireland</option>
<option>Isle of Man</option>
<option>Israel</option>
<option>Italy</option>
<option>Jamaica</option>
<option>Japan</option>
<option>Jersey</option>
<option>Jordan</option>
<option>Kazakhstan</option>
<option>Kenya</option>
<option>Kiribati</option>
<option>Korea, Democratic People's Republic of</option>
<option>Korea, Republic of</option>
<option>Kuwait</option>
<option>Kyrgyzstan</option>
<option>Lao People's Democratic Republic</option>
<option>Latvia</option>
<option>Lebanon</option>
<option>Lesotho</option>
<option>Liberia</option>
<option>Libya</option>
<option>Liechtenstein</option>
<option>Lithuania</option>
<option>Luxembourg</option>
<option>Macao</option>
<option>Macedonia, The Former Yugoslav Republic of</option>
<option>Madagascar</option>
<option>Malawi</option>
<option>Malaysia</option>
<option>Maldives</option>
<option>Mali</option>
<option>Malta</option>
<option>Marshall Islands</option>
<option>Martinique</option>
<option>Mauritania</option>
<option>Mauritius</option>
<option>Mayotte</option>
<option>Mexico</option>
<option>Micronesia, Federated States of</option>
<option>Moldova, Republic of</option>
<option>Monaco</option>
<option>Mongolia</option>
<option>Montenegro</option>
<option>Montserrat</option>
<option>Morocco</option>
<option>Mozambique</option>
<option>Myanmar</option>
<option>Namibia</option>
<option>Nauru</option>
<option>Nepal</option>
<option>Netherlands</option>
<option>Netherlands Antilles</option>
<option>New Caledonia</option>
<option>New Zealand</option>
<option>Nicaragua</option>
<option>Niger</option>
<option>Nigeria</option>
<option>Niue</option>
<option>Norfolk Island</option>
<option>Northern Mariana Islands</option>
<option>Norway</option>
<option>Oman</option>
<option>Pakistan</option>
<option>Palau</option>
<option>Palestine, State of</option>
<option>Panama</option>
<option>Papua New Guinea</option>
<option>Paraguay</option>
<option>Peru</option>
<option>Philippines</option>
<option>Pitcairn</option>
<option>Poland</option>
<option>Portugal</option>
<option>Puerto Rico</option>
<option>Qatar</option>
<option>Réunion</option>
<option>Romania</option>
<option>Russian Federation</option>
<option>Rwanda</option>
<option>Saint Barthélemy</option>
<option>Saint Helena, Ascension and Tristan Da Cunha</option>
<option>Saint Kitts and Nevis</option>
<option>Saint Lucia</option>
<option>Saint Martin (French part)</option>
<option>Saint Pierre and Miquelon</option>
<option>Saint Vincent and The Grenadines</option>
<option>Samoa</option>
<option>San Marino</option>
<option>Sao Tome and Principe</option>
<option>Saudi Arabia</option>
<option>Senegal</option>
<option>Serbia</option>
<option>Seychelles</option>
<option>Sierra Leone</option>
<option>Singapore</option>
<option>Sint Maarten (Dutch part)</option>
<option>Slovakia</option>
<option>Slovenia</option>
<option>Solomon Islands</option>
<option>Somalia</option>
<option>South Africa</option>
<option>South Georgia and the South Sandwich Islands</option>
<option>South Sudan</option>
<option>Spain</option>
<option>Sri Lanka</option>
<option>Sudan</option>
<option>Suriname</option>
<option>Svalbard and Jan Mayen</option>
<option>Swaziland</option>
<option>Sweden</option>
<option>Switzerland</option>
<option>Syrian Arab Republic</option>
<option>Taiwan, Province of China</option>
<option>Tajikistan</option>
<option>Tanzania, United Republic of</option>
<option>Thailand</option>
<option>Timor-Leste</option>
<option>Togo</option>
<option>Tokelau</option>
<option>Tonga</option>
<option>Trinidad and Tobago</option>
<option>Tunisia</option>
<option>Turkey</option>
<option>Turkmenistan</option>
<option>Turks and Caicos Islands</option>
<option>Tuvalu</option>
<option>Uganda</option>
<option>Ukraine</option>
<option>United Arab Emirates</option>
<option>United Kingdom</option>
<option>United States</option>
<option>United States Minor Outlying Islands</option>
<option>Uruguay</option>
<option>Uzbekistan</option>
<option>Vanuatu</option>
<option>Venezuela, Bolivarian Republic of</option>
<option>Viet Nam</option>
<option>Virgin Islands, British</option>
<option>Virgin Islands, U.S.</option>
<option>Wallis And Futuna</option>
<option>Western Sahara</option>
<option>Yemen</option>
<option>Zambia</option>
<option>Zimbabwe</option>
           </select>
  <%-- country start --%>
         <asp:HiddenField ID="dtacountry" runat="server"  />
       <script> 
          
          $(document).ready(function () {
              $("#ddlCountry").select2({ placeholder: 'Find and Select Country' });
          });
          
</script>
       <%-- country end  --%>                                       </div>
                                        </div>
             </div>
        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>State</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                                     <asp:DropDownList ID="cmbstate" runat="server" 
                        onselectedindexchanged="state_SelectedIndexChanged" AutoPostBack="True" 
                         CssClass="form-control"  AppendDataBoundItems="true">
        <asp:ListItem >--Select State--</asp:ListItem>
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
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>City/District</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                                 <select id="cmbcity" runat="server" multiple="true"  style="width:280px"> 
        </select>
       <%-- caste --%>
         <asp:HiddenField ID="dtacmbcity" runat="server"  />
       <script> 
          
          $(document).ready(function () {
              $("#cmbcity").select2({ placeholder: 'Find and Select City' });
          });
          
</script>
                                                   
                                             </div>
                                        </div>
             </div>
          <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Education</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                                      <select id="ddleducation" multiple="true"  style="width:280px" runat="server"  > 
           <option disabled="disabled" style="color:#CC3300">--Any Bachelors in Engineering/Computers--</option>
<option>Aeronautical Engineering</option>
<option>B.Arch</option>
<option>BCA</option>
<option>BE</option>
<option>B.Plan</option>
<option>B.Sc IT/ Computer Science</option>
<option>B.Tech.</option>
<option>Other Bachelor Degree in Engineering / Computers</option>
<option disabled="disabled" style="color:#CC3300">--Any Masters in Engineering/Computers--</option>
<option>M.Arch.</option>
<option>MCA</option>
<option>ME</option>
<option>M.Sc. IT/Computer Science</option>
<option>M.S.(Engg.)</option>
<option>M.Tech.</option>
<option>PGDCA</option>
<option>Other Masters Degree in Engineering / Computers</option>
<option disabled="disabled" style="color:#CC3300">--Any Bachelors in Arts/Science/Commerce--</option>
<option>Aviation Degree</option>
<option>B.A.</option>
<option>B.Com.</option>
<option>B.Ed.</option>
<option>BFA</option>
<option>BFT</option>
<option>BLIS</option>
<option>B.M.M.</option>
<option>B.Sc.</option>
<option>B.S.W</option>
<option>B.Phil.</option>
<option>Other Bachelor Degree in Arts / Science / Commerce</option>
<option disabled="disabled" style="color:#CC3300">--AnyMastersinArts/Science/Commerce--</option>
<option>M.A.</option>
<option>MCom</option>
<option>M.Ed.</option>
<option>MFA</option>
<option>MLIS</option>
<option>M.Sc.</option>
<option>MSW</option>
<option>M.Phil.</option>
<option>Other Master Degree in Arts / Science / Commerce</option>
<option disabled="disabled" style="color:#CC3300">--AnyBachelorsinManagement--</option>
<option>BBA</option>
<option>BFM (Financial Management)</option>
<option>BHM (Hotel Management)</option>
<option>Other Bachelor Degree in Management</option>
<option disabled="disabled" style="color:#CC3300">--AnyMastersinManagement--</option>
<option>MBA</option>
<option>MFM (Financial Management)</option>
<option>MHM (Hotel Management)</option>
<option>MHRM (Human Resource Management)</option>
<option>PGDM</option>
<option>Other Master Degree in Management</option>
<option disabled="disabled" style="color:#CC3300">--AnyBachelorsinMedicineinGeneral/Dental/Surgeon--</option>
<option>B.A.M.S.</option>
<option>BDS</option>
<option>BHMS</option>
<option>BSMS</option>
<option>BPharm</option>
<option>BPT</option>
<option>BUMS</option>
<option>BVSc</option>
<option>MBBS</option>
<option>B.Sc.Nursing</option>
<option>Other Bachelor Degree in Medicine</option>
<option disabled="disabled" style="color:#CC3300">--AnyMastersinMedicine-General/Dental/Surgeon--</option>
<option>MDS</option>
<option>MD/MS (Medical)</option>
<option>M.Pharm</option>
<option>MPT</option>
<option>MVSc</option>
<option>Other Master Degree in Medicine</option>
<option disabled="disabled" style="color:#CC3300">--AnyBachelorsinLegal--</option>
<option>BGL</option>
<option>B.L.</option>
<option>LL.B.</option>
<option>Other Bachelor Degree in Legal</option>
<option disabled="disabled" style="color:#CC3300">--AnyMastersinLegal--</option>
<option>LL.M.</option>
<option>M.L.</option>
<option>Other Master Degree in Legal</option>
<option disabled="disabled" style="color:#CC3300">--AnyFinancialQualification-ICWAI/CA/CS/CFA--</option>
<option>CA</option>
<option>CFA (Chartered Financial Analyst)</option>
<option>CS</option>
<option>ICWA</option>
<option>Other Degree in Finance</option>
<option disabled="disabled" style="color:#CC3300">--Service-IAS/IPS/IRS/IES/IFS--</option>
<option>IAS</option>
<option>IES</option>
<option>IFS</option>
<option>IRS</option>
<option>IPS</option>
<option>Other Degree in Service</option>
<option disabled="disabled" style="color:#CC3300">--Ph.D.--</option>
<option>Ph.D.</option>
<option disabled="disabled" style="color:#CC3300">--AnyDiploma--</option>
<option>Diploma</option>
<option>Polytechnic</option>
<option>TradeSchool</option>
<option>Others in Diploma</option>
<option disabled="disabled" style="color:#CC3300">--HigherSecondary/Secondary--</option>
<option>Higher Secondary School</option>
<option>High School</option>
<option>Not Educated</option>

                               </select>
        <%-- Education --%>
         <asp:HiddenField ID="dtaSelect" runat="server"  />
       <script> 
          
          $(document).ready(function () {
              $("#ddleducation").select2({ placeholder: 'Find and Select Courses' });
          });
         
</script>
                                             </div>
                                        </div>
             </div>
        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Occupation</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                                       
        <select id="ddlfunctional" runat="server" multiple="true"  style="width:280px"> 
<option disabled="disabled" style="color:#CC3300">--ADMIN--</option>
<option>Manager</option>
<option>Supervisor</option>
<option>Officer</option>
<option>Administrative Professional</option>
<option>Executive</option>
<option>Clerk</option>
<option>Human Resources Professional</option>
<option disabled="disabled" style="color:#CC3300">--AGRICULTURE--</option>
<option>Agriculture & Farming Professional</option>
<option disabled="disabled" style="color:#CC3300">--AIRLINE--</option>
<option>Pilot</option>
<option>Air Hostess</option>
<option>Airline Professional</option>
<option disabled="disabled" style="color:#CC3300">--ARCHITECT&DESIGN--</option>
<option>Architect</option>
<option>Interior Designer</option>
<option disabled="disabled" style="color:#CC3300">--BANKING&FINANCE--</option>
<option>Chartered Accountant</option>
<option>Company Secretary</option>
<option>Accounts / FinanceProfessional</option>
<option>Banking Service Professional</option>
<option>Auditor</option>
<option>Financia lAccountant</option>
<option>Financial Analyst / Planning</option>
<option disabled="disabled" style="color:#CC3300">--BEAUTY&FASHION--</option>
<option>Fashion Designer</option>
<option>Beautician</option>
<option disabled="disabled" style="color:#CC3300">--CIVILSERVICES--</option>
<option>Civil Services (IAS/IPS/IRS/IES/IFS)</option>
<option disabled="disabled" style="color:#CC3300">--DEFENCE--</option>
<option>Army</option>
<option>Navy</option>
<option>Airforce</option>
<option disabled="disabled" style="color:#CC3300">--EDUCATION--</option>
<option>Professor / Lecturer</option>
<option>Teaching / Academician</option>
<option>Education Professional</option>
<option disabled="disabled" style="color:#CC3300">--HOSPITALITY--</option>
<option>Hotel / Hospitality Professional</option>
<option disabled="disabled" style="color:#CC3300">--IT&ENGINEERING--</option>
<option>Software Professional</option>
<option>Hardware Professional</option>
<option>Engineer -NonIT</option>
<option>Designer -IT&Engineering</option>
<option disabled="disabled" style="color:#CC3300">--LEGAL--</option>
<option>Lawyer & Legal Professional</option>
<option disabled="disabled" style="color:#CC3300">--LAWENFORCEMENT--</option>
<option>Law Enforcement Officer</option>
<option disabled="disabled" style="color:#CC3300">--MEDICAL--</option>
<option>Doctor</option>
<option>Health Care Professional</option>
<option>Paramedical Professional</option>
<option>Nurse</option>
<option disabled="disabled" style="color:#CC3300">--MARKETING&SALES--</option>
<option>Marketing Professional</option>
<option>Sales Professional</option>
<option disabled="disabled" style="color:#CC3300">--MEDIA&ENTERTAINMENT--</option>
<option>Journalist</option>
<option>Media Professional</option>
<option>Entertainment Professional</option>
<option>Event Management Professional</option>
<option>Advertising / PRProfessional Designer</option>
<option>Media & Entertainment</option>

<option>Mariner / MerchantNavy</option>
<option disabled="disabled" style="color:#CC3300">--SCIENTIST--</option>
<option>Scientist / Researcher</option>
<option disabled="disabled" style="color:#CC3300">--TOPMANAGEMENT--</option>
<option>CXO / President</option>
<option>Director</option>
<option>Chairman</option>
<option>Business Analyst</option>
<option disabled="disabled" style="color:#CC3300">--OTHERS--</option>
<option>Consultant</option>
<option>Customer Care Professional</option>
<option>Social Worker</option>
<option>Sportsman</option>
<option>Technician</option>
<option>Arts & Craftsman</option>
<option>Student</option>
<option>Librarian</option>
<option>Not Working</option>

        </select>
        <%-- funIn --%>
         <asp:HiddenField ID="dtafunctional" runat="server"  />
       <script> 
          
          $(document).ready(function () {
              $("#ddlfunctional").select2({ placeholder: 'Find and Select Functional area' });
          });
          
</script>
       <%-- fun end --%>
                                             </div>
                                        </div>
             </div>
        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Star</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                                   <select id="ddlStar" runat="server"  multiple="true"  style="width:280px">
        <option>Aswini</option>
<option>Bharani</option>
<option>Kruthiga</option>
 <option>Mrigasira</option>
<option>Arudra</option>
<option>Punarvasu</option>
<option>Pushya</option>
<option>Asilesha</option>
<option>Magha</option>
<option>Poorvaphalguni</option>
<option>Uthiraphalgunu</option>
<option>Hastha</option>
<option>Chitra</option>
<option>Swathi</option>
<option>Visaka</option>
<option>Anuradha</option>
<option>Jyeshta</option>
<option>Mula</option>
<option>Poorvashada</option>
<option>Uthrashada</option>
<option>Sravan</option>
<option>Dhanishta</option>
<option>Shatataraka</option>
<option>Poorvabhadra</option>
<option>Uthirabhadra</option>
<option>Revathi</option>
        </select>
          <%-- funIn --%>
         <asp:HiddenField ID="dtaddlStar" runat="server"  />
       <script> 
          
          $(document).ready(function () {
              $("#ddlStar").select2({ placeholder: 'Find and Select Star' });
          });
          
</script>
       <%-- fun end --%>                                     </div>
                                        </div>
             </div>
        
         <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Manglik</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                                 <asp:DropDownList ID="ddlManglik" runat="server" AppendDataBoundItems="true" CssClass="form-control">
        <asp:ListItem >--Select--</asp:ListItem>
        <asp:ListItem>Yes</asp:ListItem>
<asp:ListItem>No</asp:ListItem>
<asp:ListItem>Does not matter</asp:ListItem>
                                                </asp:DropDownList>
                                             </div>
                                        </div>
             </div>
        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Habits:Eating</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                                  <asp:DropDownList ID="ddleat" runat="server" CssClass="form-control">
                                                       <asp:ListItem >--Select--</asp:ListItem>
        <asp:ListItem>Does Not Matter</asp:ListItem>
        <asp:ListItem>Vegetarian </asp:ListItem>
        <asp:ListItem>Non-Vegetarian</asp:ListItem>
        <asp:ListItem>Eggetarian</asp:ListItem>
        <asp:ListItem>Jain</asp:ListItem>
    </asp:DropDownList>
                                             </div>
                                        </div>
             </div>
         <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Habits:Smoking</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                                    <asp:DropDownList ID="ddlsmoke" runat="server" CssClass="form-control">
                                                         <asp:ListItem >--Select--</asp:ListItem>
         <asp:ListItem>Does Not Matter</asp:ListItem>
        <asp:ListItem>Yes </asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
        <asp:ListItem>Occasionally</asp:ListItem>
      
    </asp:DropDownList>
                                             </div>
                                        </div>
             </div>
        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Habits:Drinking</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                                 <asp:DropDownList ID="ddldrink" runat="server" CssClass="form-control">
                                                      <asp:ListItem >--Select--</asp:ListItem>
            <asp:ListItem>Does Not Matter</asp:ListItem>
        <asp:ListItem>Yes </asp:ListItem>
        <asp:ListItem>No</asp:ListItem>
        <asp:ListItem>Occasionally</asp:ListItem>
    </asp:DropDownList>
                                             </div>
                                        </div>
             </div>
        <div class="row"> 
                         <div class="col-md-4"> 
                                 <div class="form-group">   
                               <span>Show Profile</span> 
                                  </div> 
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group"> 
                                                    <asp:DropDownList ID="ddlshowProfile" runat="server" CssClass="form-control">
         <asp:ListItem>--Select--</asp:ListItem>
                                                         <asp:ListItem>With Photo</asp:ListItem>
        <asp:ListItem>Without Photo </asp:ListItem>
       </asp:DropDownList>
                                             </div>
                                        </div>
             </div>
          <div class="row"> 
                         <div class="col-md-4"> 
                                
                          </div> 
                                     <div class="col-md-8">
                                            <div class="form-group">  
                                                <asp:Button ID="btnSearch" runat="server" Text="Search Now" OnClientClick="myFunction()"  CssClass="loginbtn" OnClick="btnSearch_Click" />
                                             </div>
                                        </div>
             </div>

        </div></div></div>
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
