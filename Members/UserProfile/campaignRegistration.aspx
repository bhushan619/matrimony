<%@ Page MaintainScrollPositionOnPostback="true"   Language="C#" AutoEventWireup="true"  CodeFile="campaignRegistration.aspx.cs" Inherits="campaignRegistration" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>
<title>Swapnpurti Matrimony | Enter Details</title>     <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />  <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
<link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="../../js/jquery-1.11.0.min.js"></script>
<!-- Custom Theme files -->
<link href="../../css/style.css" rel="stylesheet" type="text/css" media="all"/>
     <link href="../../css/font-awesome.min.css" rel="stylesheet" />
     <link href="../../css/font-awesome.css" rel="stylesheet" />
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
		<link href="../../css/animate.css" rel="stylesheet" type="text/css" media="all">
		<script src="../../js/wow.min.js"></script>
		<script>
		    new WOW().init();
		</script>
<!-- animated-css --> 
</head>
<body >
    <form id="form1" runat="server">
        <div class="bann-two">
	<div class="header">
			<div class="container">
		      <div class="header-main">
				<div class="logo">
					<a href="campaignRegistration.aspx"><img src="../../images/lo.png" alt=""/></a>
				</div>
				 <div class="head-right-member">
					<ul> 
<li> <asp:Image ID="imgMemberPhoto"  runat="server"  Height="60px" Width="60px"/></li>
                   <li>    <asp:HyperLink ID="lblMemberName" runat="server" Text=""  NavigateUrl="~/Members/SearchMatches/Default.aspx"></asp:HyperLink><br />
    <asp:Label ID="lblMemberId" runat="server" Text="" Font-Size="Small"></asp:Label><br /> 
                   </li>  
      <li><asp:LinkButton ID="lnkLogout" CssClass="logout" runat="server" OnClick="lnkLogout_Click"></asp:LinkButton></li>
                        </ul>
				</div> 
			  <div class="clearfix"> </div>
			</div>  
		</div>
	</div>
</div>
    <div class="services">
	<div class="container"> 
     
		<div class="services-main">   
             <h2>Please Fill all fields.</h2>
			<div class="service-bottom text-justify">	
           
                <div class="col-lg-3"></div>			
				<div class="col-md-6">
   <h3>   <i class="fa fa-user iconcolor"></i>&nbsp;&nbsp; Personal Information</h3><br />
                    <div class="row">
  <div class="col-md-3">
				 <div class="form-group"> 
                     <span> Date of birth </span></div>
                       </div>
                    <div class="col-md-3">
				 <div class="form-group">
                        
        <asp:DropDownList CssClass="form-control" ID="ddlDay" runat="server" required="required"  >
        <asp:ListItem Value="">--Day--</asp:ListItem>
          <asp:ListItem>1</asp:ListItem> 
     <asp:ListItem>2</asp:ListItem> 
     <asp:ListItem>3</asp:ListItem>
     <asp:ListItem>4</asp:ListItem>
     <asp:ListItem>5</asp:ListItem>
     <asp:ListItem>6</asp:ListItem>
     <asp:ListItem>7</asp:ListItem>
     <asp:ListItem>8</asp:ListItem>
     <asp:ListItem>9</asp:ListItem>
     <asp:ListItem>10</asp:ListItem>
     <asp:ListItem>11</asp:ListItem>
     <asp:ListItem>12</asp:ListItem>
     <asp:ListItem>13</asp:ListItem>
     <asp:ListItem>14</asp:ListItem>
     <asp:ListItem>15</asp:ListItem>
     <asp:ListItem>16</asp:ListItem>
     <asp:ListItem>17</asp:ListItem>
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

        </asp:DropDownList>
                     </div>
                        </div>
                           <div class="col-md-3">
				 <div class="form-group">
        <asp:DropDownList CssClass="form-control" ID="ddlMonth" runat="server" required="required" >
        <asp:ListItem Value="">--Month--</asp:ListItem>
         <asp:ListItem>January</asp:ListItem>
        
      <asp:ListItem>February</asp:ListItem>
      <asp:ListItem>March</asp:ListItem>
      <asp:ListItem>April</asp:ListItem> 
      <asp:ListItem>May</asp:ListItem>
      <asp:ListItem>June</asp:ListItem>
      <asp:ListItem>July</asp:ListItem>
      <asp:ListItem>August</asp:ListItem>
      <asp:ListItem>September</asp:ListItem>
      <asp:ListItem>October</asp:ListItem>
      <asp:ListItem>November </asp:ListItem>
      <asp:ListItem>December</asp:ListItem>

        </asp:DropDownList>
                     </div></div>
                                  <div class="col-md-3">
				 <div class="form-group">
        <asp:DropDownList CssClass="form-control" ID="ddlYear" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Year --</asp:ListItem>
 
           <asp:ListItem>1971</asp:ListItem>
         <asp:ListItem>1972</asp:ListItem>
         <asp:ListItem>1973</asp:ListItem>
         <asp:ListItem>1974</asp:ListItem>
         <asp:ListItem>1975</asp:ListItem>
         <asp:ListItem>1976</asp:ListItem>
         <asp:ListItem>1977</asp:ListItem>
         <asp:ListItem>1978</asp:ListItem>
         <asp:ListItem>1979</asp:ListItem>
         <asp:ListItem>1980</asp:ListItem>
         <asp:ListItem>1981</asp:ListItem>
         <asp:ListItem>1982</asp:ListItem>
         <asp:ListItem>1983</asp:ListItem>
         <asp:ListItem>1984</asp:ListItem>
         <asp:ListItem>1985</asp:ListItem>
         <asp:ListItem>1986</asp:ListItem>
         <asp:ListItem>1987</asp:ListItem>
         <asp:ListItem>1988</asp:ListItem>
         <asp:ListItem>1989</asp:ListItem>
         <asp:ListItem>1990</asp:ListItem>
         <asp:ListItem>1991</asp:ListItem>
         <asp:ListItem>1992</asp:ListItem>
         <asp:ListItem>1993</asp:ListItem>
         <asp:ListItem>1994</asp:ListItem>
         <asp:ListItem>1995</asp:ListItem>
         <asp:ListItem>1996</asp:ListItem>
         <asp:ListItem>1997</asp:ListItem>
        

        </asp:DropDownList>
				 </div></div>
                    </div>
                 
                    <div class="row">
                          <div class="col-md-3">
                      <div class="form-group">    
                          <span>Marital status</span>
                          </div>
                              </div>
                         <div class="col-md-9">
                      <div class="form-group">    
        
        <asp:RadioButton ID="rgbWidow" runat="server" GroupName="rgbMstatus" 
            Text="Widow" AutoPostBack="True" 
            oncheckedchanged="rgbWidow_CheckedChanged" />&nbsp;
        <asp:RadioButton ID="rgbDivorced" runat="server" GroupName="rgbMstatus" 
            Text="Divorced" AutoPostBack="True" 
            oncheckedchanged="rgbDivorced_CheckedChanged" />&nbsp;
        <asp:RadioButton ID="rgbAwaitingDivorce" runat="server" GroupName="rgbMstatus" 
            Text="Annuled" AutoPostBack="True" 
            oncheckedchanged="rgbAwaitingDivorce_CheckedChanged" />&nbsp;
                          <asp:RadioButton ID="rgbNeverMarrided" runat="server" GroupName="rgbMstatus"  required="required" 
            Text="Never Married" AutoPostBack="True" 
            oncheckedchanged="rgbNeverMarrided_CheckedChanged" />
                    </div></div></div>
                  
<div id="MStatusz" runat="server"> 
                    <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>No. of children</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">     
                               
        <asp:DropDownList CssClass="form-control" ID="ddlNoOfChild" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select --</asp:ListItem>
          <asp:ListItem>None</asp:ListItem>
          <asp:ListItem>1 </asp:ListItem>
          <asp:ListItem>2</asp:ListItem>
          <asp:ListItem>3</asp:ListItem>
          <asp:ListItem>4 and Above</asp:ListItem>
        </asp:DropDownList>
 </div>
                             </div>

     </div>
     <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Living with children</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                           <asp:RadioButton ID="rgbCLive" runat="server" GroupName="rgbChildStatus" 
            Text="Yes" />&nbsp;
        <asp:RadioButton ID="rgbCNotLive" runat="server" GroupName="rgbChildStatus" 
            Text="No" />  
                    </div> 
       </div>   </div>

 </div>
 
                      <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>About myself</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">     
                           <asp:TextBox CssClass="form-control" ID="txtAboutMyself" runat="server" TextMode="MultiLine"></asp:TextBox>
                          </div>
                     </div>
				</div>
         <br />
                    <h3>   <i class="fa fa-recycle  iconcolor"></i>&nbsp;&nbsp;Religious Information</h3>
                    <br />
            <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Mother Tongue</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">     
                        <asp:DropDownList CssClass="form-control" ID="ddlMotherTongue" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select Mother Tongue--</asp:ListItem>
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

        </asp:DropDownList>  </div>
         </div>
                </div>     
                    
                     <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Religion</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">  
                     <asp:DropDownList CssClass="form-control" ID="ddlReligion" runat="server" required="required" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlReligion_SelectedIndexChanged" AutoPostBack="True">
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

        </asp:DropDownList>     </div>
         </div>
                         </div>
                  
                     <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Caste/Division</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">  
                       <asp:DropDownList CssClass="form-control" ID="ddlCaste" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select--</asp:ListItem>
      </asp:DropDownList>   </div>
         </div>
                         </div>
              
                    <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Sub Caste</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">  
                          <asp:TextBox CssClass="form-control" ID="txtSubCaste" runat="server"></asp:TextBox> </div>
         </div>
                        </div>
                          
                    
                    <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Gothra</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">  
                          <asp:TextBox CssClass="form-control" ID="txtGotra" runat="server"></asp:TextBox>

                      </div>
         </div>
                        </div>
                  
                    
                      
                    <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Manglik</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">  
                   <asp:RadioButton ID="rgbManglikYes" runat="server" GroupName="rgbManglik" 
            Text="Yes" />&nbsp;
        <asp:RadioButton ID="rgbManglikNo" runat="server" GroupName="rgbManglik" 
            Text="No" />&nbsp;
        <asp:RadioButton ID="rgbManglikNotKnow" runat="server" GroupName="rgbManglik" 
            Text="Do not know" />     </div>         
         </div>
                        </div>
                    <br />
              <h3>   <img src="../../images/physical.jpg" height="25" width="25" />&nbsp;&nbsp;Physical Appearance</h3>
                    <br />
                     <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Height</span>
                          </div>
                             </div>
     <div class="col-md-4">
                      <div class="form-group">  
                       <asp:DropDownList CssClass="form-control" ID="ddlHeighFtIn" runat="server" AutoPostBack="true"
         required="required" OnSelectedIndexChanged="ddlHeighFtIn_SelectedIndexChanged"  >
<asp:ListItem Value="0">--Feet/Inches--</asp:ListItem>
             <asp:ListItem   >4ft 6in</asp:ListItem>
        <asp:ListItem   >4ft 7in</asp:ListItem>
        <asp:ListItem  >4ft 8in</asp:ListItem>
        <asp:ListItem >4ft 9in</asp:ListItem>
        <asp:ListItem  >4ft 10in</asp:ListItem>
        <asp:ListItem  >4ft 11in</asp:ListItem>
        <asp:ListItem >5ft</asp:ListItem>
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
        <asp:ListItem  >6ft</asp:ListItem>
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
        <asp:ListItem >7ft</asp:ListItem> 

        </asp:DropDownList>
                          </div>
         </div>
                           <div class="col-md-4">
                      <div class="form-group">  
        <asp:DropDownList CssClass="form-control" ID="ddlHeightCms" runat="server" AutoPostBack="true"
  required="required" OnSelectedIndexChanged="ddlHeightCms_SelectedIndexChanged">
         <asp:ListItem Value="0"></asp:ListItem>
<asp:ListItem>137Cms</asp:ListItem>
<asp:ListItem>138Cms</asp:ListItem>
<asp:ListItem>139Cms</asp:ListItem>
<asp:ListItem>140Cms</asp:ListItem>
<asp:ListItem>141Cms</asp:ListItem>
<asp:ListItem>142Cms</asp:ListItem>
<asp:ListItem>143Cms</asp:ListItem>
<asp:ListItem>144Cms</asp:ListItem>
<asp:ListItem>145Cms</asp:ListItem>
<asp:ListItem>146Cms</asp:ListItem>
<asp:ListItem>147Cms</asp:ListItem>
<asp:ListItem>148Cms</asp:ListItem>
<asp:ListItem>149Cms</asp:ListItem>
<asp:ListItem>150Cms</asp:ListItem>
<asp:ListItem>151Cms</asp:ListItem>
<asp:ListItem>152Cms</asp:ListItem>
<asp:ListItem>153Cms</asp:ListItem>
<asp:ListItem>154Cms</asp:ListItem>
<asp:ListItem>155Cms</asp:ListItem>
<asp:ListItem>156Cms</asp:ListItem>
<asp:ListItem>157Cms</asp:ListItem>
<asp:ListItem>158Cms</asp:ListItem>
<asp:ListItem>159Cms</asp:ListItem>
<asp:ListItem>160Cms</asp:ListItem>
<asp:ListItem>161Cms</asp:ListItem>
<asp:ListItem>162Cms</asp:ListItem>
<asp:ListItem>163Cms</asp:ListItem>
<asp:ListItem>164Cms</asp:ListItem>
<asp:ListItem>165Cms</asp:ListItem>
<asp:ListItem>166Cms</asp:ListItem>
<asp:ListItem>167Cms</asp:ListItem>
<asp:ListItem>168Cms</asp:ListItem>
<asp:ListItem>169Cms</asp:ListItem>
<asp:ListItem>170Cms</asp:ListItem>
<asp:ListItem>171Cms</asp:ListItem>
<asp:ListItem>172Cms</asp:ListItem>
<asp:ListItem>173Cms</asp:ListItem>
<asp:ListItem>174Cms</asp:ListItem>
<asp:ListItem>175Cms</asp:ListItem>
<asp:ListItem>176Cms</asp:ListItem>
<asp:ListItem>177Cms</asp:ListItem>
<asp:ListItem>178Cms</asp:ListItem>
<asp:ListItem>179Cms</asp:ListItem>
<asp:ListItem>180Cms</asp:ListItem>
<asp:ListItem>181Cms</asp:ListItem>
<asp:ListItem>182Cms</asp:ListItem>
<asp:ListItem>183Cms</asp:ListItem>
<asp:ListItem>184Cms</asp:ListItem>
<asp:ListItem>185Cms</asp:ListItem>
<asp:ListItem>186Cms</asp:ListItem>
<asp:ListItem>187Cms</asp:ListItem>
<asp:ListItem>188Cms</asp:ListItem>
<asp:ListItem>189Cms</asp:ListItem>
<asp:ListItem>190Cms</asp:ListItem>
<asp:ListItem>191Cms</asp:ListItem>
<asp:ListItem>192Cms</asp:ListItem>
<asp:ListItem>193Cms</asp:ListItem>
<asp:ListItem>194Cms</asp:ListItem>
<asp:ListItem>195Cms</asp:ListItem>
<asp:ListItem>196Cms</asp:ListItem>
<asp:ListItem>197Cms</asp:ListItem>
<asp:ListItem>198Cms</asp:ListItem>
<asp:ListItem>199Cms</asp:ListItem>
<asp:ListItem>200Cms</asp:ListItem>
<asp:ListItem>201Cms</asp:ListItem>
<asp:ListItem>202Cms</asp:ListItem>
<asp:ListItem>203Cms</asp:ListItem>
<asp:ListItem>204Cms</asp:ListItem>
<asp:ListItem>205Cms</asp:ListItem>
<asp:ListItem>206Cms</asp:ListItem>
<asp:ListItem>207Cms</asp:ListItem>
<asp:ListItem>208Cms</asp:ListItem>
<asp:ListItem>209Cms</asp:ListItem>
<asp:ListItem>210Cms</asp:ListItem>
<asp:ListItem>211Cms</asp:ListItem>
<asp:ListItem>212Cms</asp:ListItem>
<asp:ListItem>213Cms</asp:ListItem>

        </asp:DropDownList>  
                     </div>
                               </div>
                           </div>
       
                            <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Weight</span>
                          </div>
                             </div>
     <div class="col-md-4">
                      <div class="form-group">  
                        <asp:DropDownList ID="ddlWeight" runat="server" required="required" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlWeight_SelectedIndexChanged">
        <asp:ListItem Value="">--Select Weight--</asp:ListItem>

<asp:ListItem>41Kg</asp:ListItem>
<asp:ListItem>42Kg</asp:ListItem>
<asp:ListItem>43Kg</asp:ListItem>
<asp:ListItem>44Kg</asp:ListItem>
<asp:ListItem>45Kg</asp:ListItem>
<asp:ListItem>46Kg</asp:ListItem>
<asp:ListItem>47Kg</asp:ListItem>
<asp:ListItem>48Kg</asp:ListItem>
<asp:ListItem>49Kg</asp:ListItem>
<asp:ListItem>50Kg</asp:ListItem>
<asp:ListItem>51Kg</asp:ListItem>
<asp:ListItem>52Kg</asp:ListItem>
<asp:ListItem>53Kg</asp:ListItem>
<asp:ListItem>54Kg</asp:ListItem>
<asp:ListItem>55Kg</asp:ListItem>
<asp:ListItem>56Kg</asp:ListItem>
<asp:ListItem>57Kg</asp:ListItem>
<asp:ListItem>58Kg</asp:ListItem>
<asp:ListItem>59Kg</asp:ListItem>
<asp:ListItem>60Kg</asp:ListItem>
<asp:ListItem>61Kg</asp:ListItem>
<asp:ListItem>62Kg</asp:ListItem>
<asp:ListItem>63Kg</asp:ListItem>
<asp:ListItem>64Kg</asp:ListItem>
<asp:ListItem>65Kg</asp:ListItem>
<asp:ListItem>66Kg</asp:ListItem>
<asp:ListItem>67Kg</asp:ListItem>
<asp:ListItem>68Kg</asp:ListItem>
<asp:ListItem>69Kg</asp:ListItem>
<asp:ListItem>70Kg</asp:ListItem>
<asp:ListItem>71Kg</asp:ListItem>
<asp:ListItem>72Kg</asp:ListItem>
<asp:ListItem>73Kg</asp:ListItem>
<asp:ListItem>74Kg</asp:ListItem>
<asp:ListItem>75Kg</asp:ListItem>
<asp:ListItem>76Kg</asp:ListItem>
<asp:ListItem>77Kg</asp:ListItem>
<asp:ListItem>78Kg</asp:ListItem>
<asp:ListItem>79Kg</asp:ListItem>
<asp:ListItem>80Kg</asp:ListItem>
<asp:ListItem>81Kg</asp:ListItem>
<asp:ListItem>82Kg</asp:ListItem>
<asp:ListItem>83Kg</asp:ListItem>
<asp:ListItem>84Kg</asp:ListItem>
<asp:ListItem>85Kg</asp:ListItem>
<asp:ListItem>86Kg</asp:ListItem>
<asp:ListItem>87Kg</asp:ListItem>
<asp:ListItem>88Kg</asp:ListItem>
<asp:ListItem>89Kg</asp:ListItem>
<asp:ListItem>90Kg</asp:ListItem>
<asp:ListItem>91Kg</asp:ListItem>
<asp:ListItem>92Kg</asp:ListItem>
<asp:ListItem>93Kg</asp:ListItem>
<asp:ListItem>94Kg</asp:ListItem>
<asp:ListItem>95Kg</asp:ListItem>
<asp:ListItem>96Kg</asp:ListItem>
<asp:ListItem>97Kg</asp:ListItem>
<asp:ListItem>98Kg</asp:ListItem>
<asp:ListItem>99Kg</asp:ListItem>
<asp:ListItem>100Kg</asp:ListItem>
<asp:ListItem>101Kg</asp:ListItem>
<asp:ListItem>102Kg</asp:ListItem>
<asp:ListItem>103Kg</asp:ListItem>
<asp:ListItem>104Kg</asp:ListItem>
<asp:ListItem>105Kg</asp:ListItem>
<asp:ListItem>106Kg</asp:ListItem>
<asp:ListItem>107Kg</asp:ListItem>
<asp:ListItem>108Kg</asp:ListItem>
<asp:ListItem>109Kg</asp:ListItem>
<asp:ListItem>110Kg</asp:ListItem>
<asp:ListItem>111Kg</asp:ListItem>
<asp:ListItem>112Kg</asp:ListItem>
<asp:ListItem>113Kg</asp:ListItem>
<asp:ListItem>114Kg</asp:ListItem>
<asp:ListItem>115Kg</asp:ListItem>
<asp:ListItem>116Kg</asp:ListItem>
<asp:ListItem>117Kg</asp:ListItem>
<asp:ListItem>118Kg</asp:ListItem>
<asp:ListItem>119Kg</asp:ListItem>
<asp:ListItem>120Kg</asp:ListItem>
<asp:ListItem>121Kg</asp:ListItem>
<asp:ListItem>122Kg</asp:ListItem>
<asp:ListItem>123Kg</asp:ListItem>
<asp:ListItem>124Kg</asp:ListItem>
<asp:ListItem>125Kg</asp:ListItem>
<asp:ListItem>126Kg</asp:ListItem>
<asp:ListItem>127Kg</asp:ListItem>
<asp:ListItem>128Kg</asp:ListItem>
<asp:ListItem>129Kg</asp:ListItem>
<asp:ListItem>130Kg</asp:ListItem>
<asp:ListItem>131Kg</asp:ListItem>
<asp:ListItem>132Kg</asp:ListItem>
<asp:ListItem>133Kg</asp:ListItem>
<asp:ListItem>134Kg</asp:ListItem>
<asp:ListItem>135Kg</asp:ListItem>
<asp:ListItem>136Kg</asp:ListItem>
<asp:ListItem>137Kg</asp:ListItem>
        </asp:DropDownList>   </div>
         </div>
                                <div class="col-md-4">
                      <div class="form-group">
                          <asp:DropDownList ID="ddlWeightLbs" runat="server" CssClass="form-control" required="required" OnSelectedIndexChanged="ddlWeightLbs_SelectedIndexChanged" AutoPostBack="true">
                              <asp:ListItem Value="">--Lbs--</asp:ListItem>  
                              <asp:ListItem>91Lbs</asp:ListItem>
<asp:ListItem>93Lbs</asp:ListItem>
<asp:ListItem>94Lbs</asp:ListItem>
<asp:ListItem>95Lbs</asp:ListItem>
<asp:ListItem>96Lbs</asp:ListItem>
<asp:ListItem>97Lbs</asp:ListItem>
<asp:ListItem>98Lbs</asp:ListItem>
<asp:ListItem>99Lbs</asp:ListItem>
<asp:ListItem>100Lbs</asp:ListItem>
<asp:ListItem>101Lbs</asp:ListItem>
<asp:ListItem>102Lbs</asp:ListItem>
<asp:ListItem>103Lbs</asp:ListItem>
<asp:ListItem>104Lbs</asp:ListItem>
<asp:ListItem>105Lbs</asp:ListItem>
<asp:ListItem>106Lbs</asp:ListItem>
<asp:ListItem>107Lbs</asp:ListItem>
<asp:ListItem>108Lbs</asp:ListItem>
<asp:ListItem>109Lbs</asp:ListItem>
<asp:ListItem>110Lbs</asp:ListItem>
<asp:ListItem>111Lbs</asp:ListItem>
<asp:ListItem>112Lbs</asp:ListItem>
<asp:ListItem>113Lbs</asp:ListItem>
<asp:ListItem>114Lbs</asp:ListItem>
<asp:ListItem>115Lbs</asp:ListItem>
<asp:ListItem>116Lbs</asp:ListItem>
<asp:ListItem>117Lbs</asp:ListItem>
<asp:ListItem>118Lbs</asp:ListItem>
<asp:ListItem>119Lbs</asp:ListItem>
<asp:ListItem>120Lbs</asp:ListItem>
<asp:ListItem>121Lbs</asp:ListItem>
<asp:ListItem>122Lbs</asp:ListItem>
<asp:ListItem>123Lbs</asp:ListItem>
<asp:ListItem>124Lbs</asp:ListItem>
<asp:ListItem>125Lbs</asp:ListItem>
<asp:ListItem>126Lbs</asp:ListItem>
<asp:ListItem>127Lbs</asp:ListItem>
<asp:ListItem>128Lbs</asp:ListItem>
<asp:ListItem>129Lbs</asp:ListItem>
<asp:ListItem>130Lbs</asp:ListItem>
<asp:ListItem>131Lbs</asp:ListItem>
<asp:ListItem>132Lbs</asp:ListItem>
<asp:ListItem>133Lbs</asp:ListItem>
<asp:ListItem>134Lbs</asp:ListItem>
<asp:ListItem>135Lbs</asp:ListItem>
<asp:ListItem>136Lbs</asp:ListItem>
<asp:ListItem>137Lbs</asp:ListItem>
<asp:ListItem>138Lbs</asp:ListItem>
<asp:ListItem>139Lbs</asp:ListItem>
<asp:ListItem>140Lbs</asp:ListItem>
<asp:ListItem>141Lbs</asp:ListItem>
<asp:ListItem>142Lbs</asp:ListItem>
<asp:ListItem>143Lbs</asp:ListItem>
<asp:ListItem>144Lbs</asp:ListItem>
<asp:ListItem>145Lbs</asp:ListItem>
<asp:ListItem>146Lbs</asp:ListItem>
<asp:ListItem>147Lbs</asp:ListItem>
<asp:ListItem>148Lbs</asp:ListItem>
<asp:ListItem>149Lbs</asp:ListItem>
<asp:ListItem>150Lbs</asp:ListItem>
<asp:ListItem>151Lbs</asp:ListItem>
<asp:ListItem>152Lbs</asp:ListItem>
<asp:ListItem>153Lbs</asp:ListItem>
<asp:ListItem>154Lbs</asp:ListItem>
<asp:ListItem>155Lbs</asp:ListItem>
<asp:ListItem>156Lbs</asp:ListItem>
<asp:ListItem>157Lbs</asp:ListItem>
<asp:ListItem>158Lbs</asp:ListItem>
<asp:ListItem>159Lbs</asp:ListItem>
<asp:ListItem>160Lbs</asp:ListItem>
<asp:ListItem>161Lbs</asp:ListItem>
<asp:ListItem>162Lbs</asp:ListItem>
<asp:ListItem>163Lbs</asp:ListItem>
<asp:ListItem>164Lbs</asp:ListItem>
<asp:ListItem>165Lbs</asp:ListItem>
<asp:ListItem>166Lbs</asp:ListItem>
<asp:ListItem>167Lbs</asp:ListItem>
<asp:ListItem>168Lbs</asp:ListItem>
<asp:ListItem>169Lbs</asp:ListItem>
<asp:ListItem>170Lbs</asp:ListItem>
<asp:ListItem>171Lbs</asp:ListItem>
<asp:ListItem>172Lbs</asp:ListItem>
<asp:ListItem>173Lbs</asp:ListItem>
<asp:ListItem>174Lbs</asp:ListItem>
<asp:ListItem>175Lbs</asp:ListItem>
<asp:ListItem>176Lbs</asp:ListItem>
<asp:ListItem>177Lbs</asp:ListItem>
<asp:ListItem>178Lbs</asp:ListItem>
<asp:ListItem>179Lbs</asp:ListItem>
<asp:ListItem>180Lbs</asp:ListItem>
<asp:ListItem>181Lbs</asp:ListItem>
<asp:ListItem>182Lbs</asp:ListItem>
<asp:ListItem>183Lbs</asp:ListItem>
<asp:ListItem>184Lbs</asp:ListItem>
<asp:ListItem>185Lbs</asp:ListItem>
<asp:ListItem>186Lbs</asp:ListItem>
<asp:ListItem>187Lbs</asp:ListItem>
<asp:ListItem>188Lbs</asp:ListItem>
<asp:ListItem>189Lbs</asp:ListItem>
<asp:ListItem>190Lbs</asp:ListItem>
<asp:ListItem>191Lbs</asp:ListItem>
<asp:ListItem>192Lbs</asp:ListItem>
<asp:ListItem>193Lbs</asp:ListItem>
<asp:ListItem>194Lbs</asp:ListItem>
<asp:ListItem>195Lbs</asp:ListItem>
<asp:ListItem>196Lbs</asp:ListItem>
<asp:ListItem>197Lbs</asp:ListItem>
<asp:ListItem>198Lbs</asp:ListItem>
<asp:ListItem>199Lbs</asp:ListItem>
<asp:ListItem>200Lbs</asp:ListItem>
<asp:ListItem>201Lbs</asp:ListItem>
<asp:ListItem>202Lbs</asp:ListItem>
<asp:ListItem>203Lbs</asp:ListItem>
<asp:ListItem>204Lbs</asp:ListItem>
<asp:ListItem>205Lbs</asp:ListItem>
<asp:ListItem>206Lbs</asp:ListItem>
<asp:ListItem>207Lbs</asp:ListItem>
<asp:ListItem>208Lbs</asp:ListItem>
<asp:ListItem>209Lbs</asp:ListItem>
<asp:ListItem>210Lbs</asp:ListItem>
<asp:ListItem>211Lbs</asp:ListItem>
<asp:ListItem>212Lbs</asp:ListItem>
<asp:ListItem>213Lbs</asp:ListItem>
<asp:ListItem>214Lbs</asp:ListItem>
<asp:ListItem>215Lbs</asp:ListItem>
<asp:ListItem>216Lbs</asp:ListItem>
<asp:ListItem>217Lbs</asp:ListItem>
<asp:ListItem>218Lbs</asp:ListItem>
<asp:ListItem>219Lbs</asp:ListItem>
<asp:ListItem>220Lbs</asp:ListItem>
<asp:ListItem>221Lbs</asp:ListItem>
<asp:ListItem>222Lbs</asp:ListItem>
<asp:ListItem>223Lbs</asp:ListItem>
<asp:ListItem>224Lbs</asp:ListItem>
<asp:ListItem>225Lbs</asp:ListItem>
<asp:ListItem>226Lbs</asp:ListItem>
<asp:ListItem>227Lbs</asp:ListItem>
<asp:ListItem>228Lbs</asp:ListItem>
<asp:ListItem>229Lbs</asp:ListItem>
<asp:ListItem>230Lbs</asp:ListItem>
<asp:ListItem>231Lbs</asp:ListItem>
<asp:ListItem>232Lbs</asp:ListItem>
<asp:ListItem>233Lbs</asp:ListItem>
<asp:ListItem>234Lbs</asp:ListItem>
<asp:ListItem>235Lbs</asp:ListItem>
<asp:ListItem>236Lbs</asp:ListItem>
<asp:ListItem>237Lbs</asp:ListItem>
<asp:ListItem>238Lbs</asp:ListItem>
<asp:ListItem>239Lbs</asp:ListItem>
<asp:ListItem>240Lbs</asp:ListItem>
<asp:ListItem>241Lbs</asp:ListItem>
<asp:ListItem>242Lbs</asp:ListItem>
<asp:ListItem>243Lbs</asp:ListItem>
<asp:ListItem>244Lbs</asp:ListItem>
<asp:ListItem>245Lbs</asp:ListItem>
<asp:ListItem>246Lbs</asp:ListItem>
<asp:ListItem>247Lbs</asp:ListItem>
<asp:ListItem>248Lbs</asp:ListItem>
<asp:ListItem>249Lbs</asp:ListItem>
<asp:ListItem>250Lbs</asp:ListItem>
<asp:ListItem>251Lbs</asp:ListItem>
<asp:ListItem>252Lbs</asp:ListItem>
<asp:ListItem>253Lbs</asp:ListItem>
<asp:ListItem>254Lbs</asp:ListItem>
<asp:ListItem>255Lbs</asp:ListItem>
<asp:ListItem>256Lbs</asp:ListItem>
<asp:ListItem>257Lbs</asp:ListItem>
<asp:ListItem>258Lbs</asp:ListItem>
<asp:ListItem>259Lbs</asp:ListItem>
<asp:ListItem>260Lbs</asp:ListItem>
<asp:ListItem>261Lbs</asp:ListItem>
<asp:ListItem>262Lbs</asp:ListItem>
<asp:ListItem>263Lbs</asp:ListItem>
<asp:ListItem>264Lbs</asp:ListItem>
<asp:ListItem>265Lbs</asp:ListItem>
<asp:ListItem>266Lbs</asp:ListItem>
<asp:ListItem>267Lbs</asp:ListItem>
<asp:ListItem>268Lbs</asp:ListItem>
<asp:ListItem>269Lbs</asp:ListItem>
<asp:ListItem>270Lbs</asp:ListItem>
<asp:ListItem>271Lbs</asp:ListItem>
<asp:ListItem>272Lbs</asp:ListItem>
<asp:ListItem>273Lbs</asp:ListItem>
<asp:ListItem>274Lbs</asp:ListItem>
<asp:ListItem>275Lbs</asp:ListItem>
<asp:ListItem>276Lbs</asp:ListItem>
<asp:ListItem>277Lbs</asp:ListItem>
<asp:ListItem>278Lbs</asp:ListItem>
<asp:ListItem>279Lbs</asp:ListItem>
<asp:ListItem>280Lbs</asp:ListItem>
<asp:ListItem>281Lbs</asp:ListItem>
<asp:ListItem>282Lbs</asp:ListItem>
<asp:ListItem>283Lbs</asp:ListItem>
<asp:ListItem>284Lbs</asp:ListItem>
<asp:ListItem>285Lbs</asp:ListItem>
<asp:ListItem>286Lbs</asp:ListItem>
<asp:ListItem>287Lbs</asp:ListItem>
<asp:ListItem>288Lbs</asp:ListItem>
<asp:ListItem>289Lbs</asp:ListItem>
<asp:ListItem>290Lbs</asp:ListItem>
<asp:ListItem>291Lbs</asp:ListItem>
<asp:ListItem>292Lbs</asp:ListItem>
<asp:ListItem>293Lbs</asp:ListItem>
<asp:ListItem>294Lbs</asp:ListItem>
<asp:ListItem>295Lbs</asp:ListItem>
<asp:ListItem>296Lbs</asp:ListItem>
<asp:ListItem>297Lbs</asp:ListItem>
<asp:ListItem>298Lbs</asp:ListItem>
<asp:ListItem>299Lbs</asp:ListItem>
<asp:ListItem>300Lbs</asp:ListItem>

                          </asp:DropDownList>
                          </div>
                                    </div>
                         </div>
                    
                    <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Blood Group</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">  
                       <asp:DropDownList CssClass="form-control" ID="ddlBloodgroup" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select Bloodgroup--</asp:ListItem>
          <asp:ListItem>A+</asp:ListItem>
<asp:ListItem>A-</asp:ListItem>
<asp:ListItem>B+</asp:ListItem>
<asp:ListItem>B-</asp:ListItem>
<asp:ListItem>AB+</asp:ListItem>
<asp:ListItem>AB-</asp:ListItem>
<asp:ListItem>O+</asp:ListItem>
<asp:ListItem>O-</asp:ListItem>	

        </asp:DropDownList> 

                      </div>
         </div>
                        </div>
                
                     
                    <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Body Type</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">     
                   <asp:RadioButton    ID="rgbBTSlim" runat="server" Text="Slim"  GroupName="rgbBodyType" />&nbsp;
        <asp:RadioButton ID="rgbBTAverage" runat="server" Text="Average"  GroupName="rgbBodyType"/>&nbsp;
        <asp:RadioButton ID="rgbBTAthletic" runat="server" Text="Athletic" GroupName="rgbBodyType"/>&nbsp;
        <asp:RadioButton ID="rgbBTHeavy" runat="server" Text="Heavy" GroupName="rgbBodyType"/>   </div>
                         </div>

                      </div>  

                         
                    <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Complexion</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">     
                          <asp:RadioButton ID="rgbFair" runat="server" Text="Fair"  GroupName="rgbComplexion"/>&nbsp;
        <asp:RadioButton ID="rgbWheatish" runat="server" Text="Wheatish" GroupName="rgbComplexion"/>&nbsp;
        <asp:RadioButton ID="rgbWheatishMedium" runat="server" Text="Wheatish Medium" GroupName="rgbComplexion"/>&nbsp;
         <asp:RadioButton ID="rgbDark" runat="server" Text="Dark" GroupName="rgbComplexion"/>
                          </div>
         </div>
                        </div>

                      <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Special Case</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">     
                          <asp:DropDownList CssClass="form-control" ID="ddlSpecialCase" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select Special Case(if Any)--</asp:ListItem> 
 <asp:ListItem>None </asp:ListItem>

   <asp:ListItem>Physically challenged from birth</asp:ListItem> 
      <asp:ListItem>Hiv positive</asp:ListItem> 
 <asp:ListItem>Mentally challenged from birth  </asp:ListItem>         
     <asp:ListItem>Accidental / Physical abnormality affecting only looks</asp:ListItem>
 <asp:ListItem>Physical abnormality affecting bodily functions due to accident</asp:ListItem>
 <asp:ListItem>Physically challenged due to accident </asp:ListItem>
 <asp:ListItem>Medically challenged condition of one or more vital organs </asp:ListItem>
        </asp:DropDownList></div></div></div>
			<br />
                     <h3> <img src="../../images/proffessional.jpg"  height="25" width="25" />&nbsp;&nbsp;Professional Information</h3>
                  
                    <br />     <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Highest Qualification</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">     
                    	<asp:DropDownList CssClass="form-control" ID="ddlQualification" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select Highest qualification--</asp:ListItem>
        <asp:ListItem disabled="true" style="color:#CC3300">--Any Bachelors in Engineering/Computers--</asp:ListItem>
       
<asp:ListItem>Aeronautical Engineering</asp:ListItem>
<asp:ListItem>B.Arch</asp:ListItem>
<asp:ListItem>BCA</asp:ListItem>
<asp:ListItem>BE</asp:ListItem>
<asp:ListItem>B.Plan</asp:ListItem>
<asp:ListItem>B.Sc IT/ Computer Science</asp:ListItem>
<asp:ListItem>B.Tech.</asp:ListItem>
<asp:ListItem>Other Bachelor Degree in Engineering / Computers</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--Any Masters in Engineering/Computers--</asp:ListItem>
<asp:ListItem>M.Arch.</asp:ListItem>
<asp:ListItem>MCA</asp:ListItem>
<asp:ListItem>ME</asp:ListItem>
<asp:ListItem>M.Sc. IT/Computer Science</asp:ListItem>
<asp:ListItem>M.S.(Engg.)</asp:ListItem>
<asp:ListItem>M.Tech.</asp:ListItem>
<asp:ListItem>PGDCA</asp:ListItem>
<asp:ListItem>Other Masters Degree in Engineering / Computers</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--Any Bachelors in Arts/Science/Commerce--</asp:ListItem>
<asp:ListItem>Aviation Degree</asp:ListItem>
<asp:ListItem>B.A.</asp:ListItem>
<asp:ListItem>B.Com.</asp:ListItem>
<asp:ListItem>B.Ed.</asp:ListItem>
<asp:ListItem>BFA</asp:ListItem>
<asp:ListItem>BFT</asp:ListItem>
<asp:ListItem>BLIS</asp:ListItem>
<asp:ListItem>B.M.M.</asp:ListItem>
<asp:ListItem>B.Sc.</asp:ListItem>
<asp:ListItem>B.S.W</asp:ListItem>
<asp:ListItem>B.Phil.</asp:ListItem>
<asp:ListItem>Other Bachelor Degree in Arts / Science / Commerce</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyMastersinArts/Science/Commerce--</asp:ListItem>
<asp:ListItem>M.A.</asp:ListItem>
<asp:ListItem>MCom</asp:ListItem>
<asp:ListItem>M.Ed.</asp:ListItem>
<asp:ListItem>MFA</asp:ListItem>
<asp:ListItem>MLIS</asp:ListItem>
<asp:ListItem>M.Sc.</asp:ListItem>
<asp:ListItem>MSW</asp:ListItem>
<asp:ListItem>M.Phil.</asp:ListItem>
<asp:ListItem>Other Master Degree in Arts / Science / Commerce</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyBachelorsinManagement--</asp:ListItem>
<asp:ListItem>BBA</asp:ListItem>
<asp:ListItem>BFM (Financial Management)</asp:ListItem>
<asp:ListItem>BHM (Hotel Management)</asp:ListItem>
<asp:ListItem>Other Bachelor Degree in Management</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyMastersinManagement--</asp:ListItem>
<asp:ListItem>MBA</asp:ListItem>
<asp:ListItem>MFM (Financial Management)</asp:ListItem>
<asp:ListItem>MHM (Hotel Management)</asp:ListItem>
<asp:ListItem>MHRM (Human Resource Management)</asp:ListItem>
<asp:ListItem>PGDM</asp:ListItem>
<asp:ListItem>Other Master Degree in Management</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyBachelorsinMedicineinGeneral/Dental/Surgeon--</asp:ListItem>
<asp:ListItem>B.A.M.S.</asp:ListItem>
<asp:ListItem>BDS</asp:ListItem>
<asp:ListItem>BHMS</asp:ListItem>
<asp:ListItem>BSMS</asp:ListItem>
<asp:ListItem>BPharm</asp:ListItem>
<asp:ListItem>BPT</asp:ListItem>
<asp:ListItem>BUMS</asp:ListItem>
<asp:ListItem>BVSc</asp:ListItem>
<asp:ListItem>MBBS</asp:ListItem>
<asp:ListItem>B.Sc.Nursing</asp:ListItem>
<asp:ListItem>Other Bachelor Degree in Medicine</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyMastersinMedicine-General/Dental/Surgeon--</asp:ListItem>
<asp:ListItem>MDS</asp:ListItem>
<asp:ListItem>MD/MS (Medical)</asp:ListItem>
<asp:ListItem>M.Pharm</asp:ListItem>
<asp:ListItem>MPT</asp:ListItem>
<asp:ListItem>MVSc</asp:ListItem>
<asp:ListItem>Other Master Degree in Medicine</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyBachelorsinLegal--</asp:ListItem>
<asp:ListItem>BGL</asp:ListItem>
<asp:ListItem>B.L.</asp:ListItem>
<asp:ListItem>LL.B.</asp:ListItem>
<asp:ListItem>Other Bachelor Degree in Legal</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyMastersinLegal--</asp:ListItem>
<asp:ListItem>LL.M.</asp:ListItem>
<asp:ListItem>M.L.</asp:ListItem>
<asp:ListItem>Other Master Degree in Legal</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyFinancialQualification-ICWAI/CA/CS/CFA--</asp:ListItem>
<asp:ListItem>CA</asp:ListItem>
<asp:ListItem>CFA (Chartered Financial Analyst)</asp:ListItem>
<asp:ListItem>CS</asp:ListItem>
<asp:ListItem>ICWA</asp:ListItem>
<asp:ListItem>Other Degree in Finance</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--Service-IAS/IPS/IRS/IES/IFS--</asp:ListItem>
<asp:ListItem>IAS</asp:ListItem>
<asp:ListItem>IES</asp:ListItem>
<asp:ListItem>IFS</asp:ListItem>
<asp:ListItem>IRS</asp:ListItem>
<asp:ListItem>IPS</asp:ListItem>
<asp:ListItem>Other Degree in Service</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--Ph.D.--</asp:ListItem>
<asp:ListItem>Ph.D.</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AnyDiploma--</asp:ListItem>
<asp:ListItem>Diploma</asp:ListItem>
<asp:ListItem>Polytechnic</asp:ListItem>
<asp:ListItem>TradeSchool</asp:ListItem>
<asp:ListItem>Others in Diploma</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--HigherSecondary/Secondary--</asp:ListItem>
<asp:ListItem>Higher Secondary School</asp:ListItem>
<asp:ListItem>High School</asp:ListItem>
<asp:ListItem>Not Educated</asp:ListItem>

        </asp:DropDownList></div>
         </div>
                           </div>
              
                    
                     <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Additional Degree</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">     
                         <asp:TextBox CssClass="form-control" ID="txtAdditional" runat="server"></asp:TextBox>  </div>
         </div>
                         </div>

                    <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Employee In</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                     <asp:DropDownList CssClass="form-control" ID="ddlEmployeeIn" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select Employee In--</asp:ListItem>
        <asp:ListItem>Central Government </asp:ListItem>
        <asp:ListItem>State Government </asp:ListItem>
        <asp:ListItem>Private Sector </asp:ListItem>
        <asp:ListItem>Public Sector </asp:ListItem>
        <asp:ListItem>Self Employed </asp:ListItem>
        <asp:ListItem>Not Working </asp:ListItem>
        <asp:ListItem>Other</asp:ListItem>
        </asp:DropDownList>     </div>
         </div>
                        </div>
       
                      <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Occupation</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                        <asp:DropDownList CssClass="form-control" ID="ddlOccupation" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select Occupation--</asp:ListItem>

<asp:ListItem disabled="true" style="color:#CC3300">--ADMIN--</asp:ListItem>
<asp:ListItem>Manager</asp:ListItem>
<asp:ListItem>Supervisor</asp:ListItem>
<asp:ListItem>Officer</asp:ListItem>
<asp:ListItem>Administrative Professional</asp:ListItem>
<asp:ListItem>Executive</asp:ListItem>
<asp:ListItem>Clerk</asp:ListItem>
<asp:ListItem>Human Resources Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AGRICULTURE--</asp:ListItem>
<asp:ListItem>Agriculture & Farming Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--AIRLINE--</asp:ListItem>
<asp:ListItem>Pilot</asp:ListItem>
<asp:ListItem>Air Hostess</asp:ListItem>
<asp:ListItem>Airline Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--ARCHITECT&DESIGN--</asp:ListItem>
<asp:ListItem>Architect</asp:ListItem>
<asp:ListItem>Interior Designer</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--BANKING&FINANCE--</asp:ListItem>
<asp:ListItem>Chartered Accountant</asp:ListItem>
<asp:ListItem>Company Secretary</asp:ListItem>
<asp:ListItem>Accounts / FinanceProfessional</asp:ListItem>
<asp:ListItem>Banking Service Professional</asp:ListItem>
<asp:ListItem>Auditor</asp:ListItem>
<asp:ListItem>Financia lAccountant</asp:ListItem>
<asp:ListItem>Financial Analyst / Planning</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--BEAUTY&FASHION--</asp:ListItem>
<asp:ListItem>Fashion Designer</asp:ListItem>
<asp:ListItem>Beautician</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--CIVILSERVICES--</asp:ListItem>
<asp:ListItem>Civil Services (IAS/IPS/IRS/IES/IFS)</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--DEFENCE--</asp:ListItem>
<asp:ListItem>Army</asp:ListItem>
<asp:ListItem>Navy</asp:ListItem>
<asp:ListItem>Airforce</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--EDUCATION--</asp:ListItem>
<asp:ListItem>Professor / Lecturer</asp:ListItem>
<asp:ListItem>Teaching / Academician</asp:ListItem>
<asp:ListItem>Education Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--HOSPITALITY--</asp:ListItem>
<asp:ListItem>Hotel / Hospitality Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--IT&ENGINEERING--</asp:ListItem>
<asp:ListItem>Software Professional</asp:ListItem>
<asp:ListItem>Hardware Professional</asp:ListItem>
<asp:ListItem>Engineer -NonIT</asp:ListItem>
<asp:ListItem>Designer -IT&Engineering</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--LEGAL--</asp:ListItem>
<asp:ListItem>Lawyer & Legal Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--LAWENFORCEMENT--</asp:ListItem>
<asp:ListItem>Law Enforcement Officer</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--MEDICAL--</asp:ListItem>
<asp:ListItem>Doctor</asp:ListItem>
<asp:ListItem>Health Care Professional</asp:ListItem>
<asp:ListItem>Paramedical Professional</asp:ListItem>
<asp:ListItem>Nurse</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--MARKETING&SALES--</asp:ListItem>
<asp:ListItem>Marketing Professional</asp:ListItem>
<asp:ListItem>Sales Professional</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--MEDIA&ENTERTAINMENT--</asp:ListItem>
<asp:ListItem>Journalist</asp:ListItem>
<asp:ListItem>Media Professional</asp:ListItem>
<asp:ListItem>Entertainment Professional</asp:ListItem>
<asp:ListItem>Event Management Professional</asp:ListItem>
<asp:ListItem>Advertising / PRProfessional Designer</asp:ListItem>
<asp:ListItem>Media & Entertainment</asp:ListItem>

<asp:ListItem>Mariner / MerchantNavy</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--SCIENTIST--</asp:ListItem>
<asp:ListItem>Scientist / Researcher</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--TOPMANAGEMENT--</asp:ListItem>
<asp:ListItem>CXO / President</asp:ListItem>
<asp:ListItem>Director</asp:ListItem>
<asp:ListItem>Chairman</asp:ListItem>
<asp:ListItem>Business Analyst</asp:ListItem>
<asp:ListItem disabled="true" style="color:#CC3300">--OTHERS--</asp:ListItem>
<asp:ListItem>Consultant</asp:ListItem>
<asp:ListItem>Customer Care Professional</asp:ListItem>
<asp:ListItem>Social Worker</asp:ListItem>
<asp:ListItem>Sportsman</asp:ListItem>
<asp:ListItem>Technician</asp:ListItem>
<asp:ListItem>Arts & Craftsman</asp:ListItem>
<asp:ListItem>Student</asp:ListItem>
<asp:ListItem>Librarian</asp:ListItem>
<asp:ListItem>Not Working</asp:ListItem>
  <asp:ListItem>Farmer</asp:ListItem>
<asp:ListItem>Retired</asp:ListItem>
        </asp:DropDownList>  </div>
         </div>
                          </div>

                      <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Annual Income</span>
                          </div>
                             </div>
     <div class="col-md-4">
                      <div class="form-group">   
                         <asp:TextBox CssClass="form-control" ID="txtAnnualIncome" runat="server" required="required" onkeyup="if (/\D/g.test(this.value)) this.value = this.value.replace(/\D/g,'')"></asp:TextBox>
                          </div>
         </div>
         <div class="col-md-5">
                      <div class="form-group">   
        <asp:DropDownList CssClass="form-control" ID="ddlCurrency" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select Currency--</asp:ListItem>
     
<asp:ListItem>AED - Emirati Dirham</asp:ListItem>
<asp:ListItem>ARS - Argentine Peso</asp:ListItem>
<asp:ListItem>AUD - Australian Dollar</asp:ListItem>
<asp:ListItem>BGN - Bulgarian Lev</asp:ListItem>
<asp:ListItem>BHD - Bahraini Dinar</asp:ListItem>
<asp:ListItem>BND - Bruneian Dollar</asp:ListItem>
<asp:ListItem>BRL - Brazilian Real</asp:ListItem>
<asp:ListItem>BWP - Botswana Pula</asp:ListItem>
<asp:ListItem>CAD - Canadian Dollar</asp:ListItem>
<asp:ListItem>CHF - Swiss Franc</asp:ListItem>
<asp:ListItem>CLP - Chilean Peso</asp:ListItem>
<asp:ListItem>CNY - Chinese Yuan Renminbi</asp:ListItem>
<asp:ListItem>COP - Colombian Peso</asp:ListItem>
<asp:ListItem>CZK - Czech Koruna</asp:ListItem>
<asp:ListItem>DKK - Danish Krone</asp:ListItem>
<asp:ListItem>EUR - Euro</asp:ListItem>
<asp:ListItem>GBP - British Pound</asp:ListItem>
<asp:ListItem>HKD - Hong Kong Dollar</asp:ListItem>
<asp:ListItem>HRK - Croatian Kuna</asp:ListItem>
<asp:ListItem>HUF - Hungarian Forint</asp:ListItem>
<asp:ListItem>IDR - Indonesian Rupiah</asp:ListItem>
<asp:ListItem>ILS - Israeli Shekel</asp:ListItem>
<asp:ListItem>INR - Indian Rupee</asp:ListItem>
<asp:ListItem>IRR - Iranian Rial</asp:ListItem>
<asp:ListItem>ISK - Icelandic Krona</asp:ListItem>
<asp:ListItem>JPY - Japanese Yen</asp:ListItem>
<asp:ListItem>KRW - South Korean Won</asp:ListItem>
<asp:ListItem>KWD - Kuwaiti Dinar</asp:ListItem>
<asp:ListItem>KZT - Kazakhstani Tenge</asp:ListItem>
<asp:ListItem>LKR - Sri Lankan Rupee</asp:ListItem>
<asp:ListItem>LTL - Lithuanian Litas</asp:ListItem>
<asp:ListItem>LVL - Latvian Lat</asp:ListItem>
<asp:ListItem>LYD - Libyan Dinar</asp:ListItem>
<asp:ListItem>MUR - Mauritian Rupee</asp:ListItem>
<asp:ListItem>MXN - Mexican Peso</asp:ListItem>
<asp:ListItem>MYR - Malaysian Ringgit</asp:ListItem>
<asp:ListItem>NOK - Norwegian Krone</asp:ListItem>
<asp:ListItem>NPR - Nepalese Rupee</asp:ListItem>
<asp:ListItem>NZD - New Zealand Dollar</asp:ListItem>
<asp:ListItem>OMR - Omani Rial</asp:ListItem>
<asp:ListItem>PHP - Philippine Peso</asp:ListItem>
<asp:ListItem>PKR - Pakistani Rupee</asp:ListItem>
<asp:ListItem>PLN - Polish Zloty</asp:ListItem>
<asp:ListItem>QAR - Qatari Riyal</asp:ListItem>
<asp:ListItem>RON - Romanian New Leu</asp:ListItem>
<asp:ListItem>RUB - Russian Ruble</asp:ListItem>
<asp:ListItem>SAR - Saudi Arabian Riyal</asp:ListItem>
<asp:ListItem>SEK - Swedish Krona</asp:ListItem>
<asp:ListItem>SGD - Singapore Dollar</asp:ListItem>
<asp:ListItem>THB - Thai Baht</asp:ListItem>
<asp:ListItem>TRY - Turkish Lira</asp:ListItem>
<asp:ListItem>TTD - Trinidadian Dollar</asp:ListItem>
<asp:ListItem>TWD - Taiwan New Dollar</asp:ListItem>
<asp:ListItem>USD - US Dollar</asp:ListItem>
<asp:ListItem>VEF - Venezuelan Bolivar</asp:ListItem>
<asp:ListItem>ZAR - South African Rand</asp:ListItem>

        </asp:DropDownList>  </div>
         </div>
                          </div>
                  <br />
                      <h3>  <i class="fa fa-globe  iconcolor"></i>&nbsp;&nbsp;Living in</h3>
                    <br />
                      <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Country</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                       <asp:DropDownList CssClass="form-control" ID="ddlCountry" runat="server" required="required" AppendDataBoundItems="true">
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
        </asp:DropDownList>   </div>
         </div>
                          </div>

                      <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Citizenship</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                         <asp:DropDownList CssClass="form-control" ID="ddlCitizenShip" runat="server" required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select CitizenShip--</asp:ListItem>
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

        </asp:DropDownList> </div>
         </div>
                          </div>

                      <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>State</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                        <asp:DropDownList CssClass="form-control" ID="cmbstate" runat="server" 
                        onselectedindexchanged="state_SelectedIndexChanged" AutoPostBack="True" 
                           required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select State--</asp:ListItem>
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
                    </asp:DropDownList>  </div>
         </div>
                          </div>
                             
                    <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>City</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                      <asp:DropDownList CssClass="form-control" ID="cmbcity" runat="server"    class="form-control"  required="required" AppendDataBoundItems="true">
        <asp:ListItem Value="">--Select City--</asp:ListItem>
                                </asp:DropDownList>    </div>
         </div>
                        </div>
                       <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Address</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                          <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                              </div>
         </div>
                        </div>
                    <br />
                    <h3><i class="fa fa-users  iconcolor"></i>&nbsp;&nbsp;Family Information</h3>
                    <br />
                      <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Family Status</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                        <asp:Label ID="Label43" runat="server" Text=""></asp:Label>
        <asp:RadioButton ID="rgbMiddleClass" runat="server" GroupName="rgbFStatus" 
            Text="Middle class" />&nbsp;
        <asp:RadioButton ID="rgbUppermiddle" runat="server" GroupName="rgbFStatus" 
            Text="Upper middle class" />&nbsp;
        <asp:RadioButton ID="rgbRich" runat="server" GroupName="rgbFStatus" 
            Text="Rich " />&nbsp;
        <asp:RadioButton ID="rgbAffluent" runat="server" GroupName="rgbFStatus" 
            Text="Affluent" />    </div>
         </div>
                        </div>


                      <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Family Type</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                         <asp:RadioButton ID="rgbJoint" runat="server" GroupName="rgbFType" 
            Text="Joint" />&nbsp;
        <asp:RadioButton ID="rgbNuclear" runat="server" GroupName="rgbFType" 
            Text="Nuclear" />&nbsp;
        <asp:RadioButton ID="rgbOther" runat="server" GroupName="rgbFType" 
            Text="Other" />  </div>
         </div>
                        </div>


                      <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Family Value</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                         <asp:RadioButton ID="rgbOrthodox" runat="server" GroupName="rgbFValue" 
            Text="Orthodox" />&nbsp;
        <asp:RadioButton ID="rgbTraditional" runat="server" GroupName="rgbFValue" 
            Text="Traditional" />&nbsp;
        <asp:RadioButton ID="rgbModerate" runat="server" GroupName="rgbFValue" 
            Text="Moderate" />&nbsp;
        <asp:RadioButton ID="rgbLiberal" runat="server" GroupName="rgbFValue" 
            Text="Liberal" /> </div>
         </div>
                        </div>
                    <br />
                    <h3> <i class="fa fa-building-o  iconcolor"></i>&nbsp;&nbsp;About Your lifestyle</h3>
                   <br />
                       <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Eating habits</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                         <asp:RadioButton ID="rgbVegetarian" runat="server" GroupName="rgbEat" 
            Text="Vegetarian" />&nbsp;
        <asp:RadioButton ID="rgbNonVegetarian" runat="server" GroupName="rgbEat" 
            Text="Non-Vegetarian" />&nbsp;
        <asp:RadioButton ID="rgbEggetarian" runat="server" GroupName="rgbEat" 
            Text="Eggetarian" />&nbsp;
        <asp:RadioButton ID="rgbJain" runat="server" GroupName="rgbEat" Text="Jain" />   </div>
         </div>
                        </div>

                    <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Smoke</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                   <asp:RadioButton ID="rgbSYes" runat="server" GroupName="rgbSmoke" Text="Yes" />
        <asp:RadioButton ID="rgbSNo" runat="server" GroupName="rgbSmoke" Text="No" />
        <asp:RadioButton ID="rgbSOccasionally" runat="server" GroupName="rgbSmoke" 
            Text="Occasionally" />         </div>
         </div>
                        </div>

                    <div class="row"> 
 <div class="col-md-3">  
                      <div class="form-group">    
                          <span>Drink</span>
                          </div>
                             </div>
     <div class="col-md-9">
                      <div class="form-group">   
                         <asp:RadioButton ID="rgbDYes" runat="server" GroupName="rgbDrink" Text="Yes" />
        <asp:RadioButton ID="rgbDNo" runat="server" GroupName="rgbDrink" Text="No" />
        <asp:RadioButton ID="rgbDOccasionally" runat="server" GroupName="rgbDrink" 
            Text="Occasionally" />   </div>
         </div>
                        </div>
                    <div class="form-group">
                           <asp:Button ID="btnSubmit" CssClass="loginbtn"   runat="server" Text="Create Profile For Me" 
            onclick="btnSubmit_Click" />
                    </div>

                        </div>
                </div>
			  <div class="clearfix"> </div>
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
