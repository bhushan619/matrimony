<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SuccessStoryold.aspx.cs" Inherits="SuccessStory" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" /> <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" /><link rel="icon" href="images/favicon.ico" type="image/x-icon" />
</head>
<body oncontextmenu="return false;" >
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="Label38" runat="server" Text="Post your success story" 
            Font-Bold="True"></asp:Label>
        <br />
        <asp:Label ID="Label41" runat="server" Text="Your Member Id"></asp:Label>
        <asp:TextBox ID="txtMembetId" runat="server" 
            ontextchanged="txtMembetId_TextChanged" AutoPostBack="True" required="required"></asp:TextBox>
        <br /> 
        <asp:Label ID="Label39" runat="server" Text="Your Name"></asp:Label>
        <asp:TextBox ID="txtMemberName" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Label ID="Label42" runat="server" Text="Your Partner's Member Id"></asp:Label>
        <asp:TextBox ID="txtPartnerMemberId" runat="server" required="required"
            ontextchanged="txtPartnerMemberId_TextChanged" AutoPostBack="True"></asp:TextBox>
        <br />
       
        <asp:Label ID="Label40" runat="server" Text="Partner Name "></asp:Label>
        <asp:TextBox ID="txtPartnerName" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Label ID="Label43" runat="server" Text="E-mail "></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" required="required"></asp:TextBox>
        <br />
        <asp:Label ID="Label44" runat="server" Text="Engagement Date "></asp:Label>
        <asp:TextBox ID="txtEngagementDate" runat="server" required="required"></asp:TextBox>
        <cc1:CalendarExtender ID="txtEngagementDate_CalendarExtender" runat="server" 
          Format="dd-MM-yyyy"  Enabled="True" TargetControlID="txtEngagementDate">
        </cc1:CalendarExtender>
        <br />
        <asp:Label ID="Label45" runat="server" Text="Marriage Date "></asp:Label>
        <asp:TextBox ID="txtMarriageDate" runat="server" required="required"></asp:TextBox>
        <cc1:CalendarExtender ID="txtMarriageDate_CalendarExtender" runat="server" 
          Format="dd-MM-yyyy"  Enabled="True" TargetControlID="txtMarriageDate">
        </cc1:CalendarExtender>
        <br />
        <asp:Label ID="Label47" runat="server" Text="Wedding Location "></asp:Label>
        <asp:TextBox ID="txtWeddingLocation" runat="server" required="required"></asp:TextBox>
        <br />
        <asp:Label ID="Label48" runat="server" Text="Living Address"></asp:Label>
        <asp:TextBox ID="txtLivingAddress" runat="server" TextMode="MultiLine" required="required"></asp:TextBox>
        <br />
        <asp:Label ID="Label49" runat="server" Text="Country Living In"></asp:Label>
        <asp:DropDownList ID="ddlCountry" runat="server">
        <asp:ListItem>--Select Country--</asp:ListItem>
       <%--     <asp:ListItem>	Afghanistan	</asp:ListItem>
<asp:ListItem>	Åland Islands	</asp:ListItem>
<asp:ListItem>	Albania	</asp:ListItem>
<asp:ListItem>	Algeria	</asp:ListItem>
<asp:ListItem>	American Samoa	</asp:ListItem>
<asp:ListItem>	Andorra	</asp:ListItem>
<asp:ListItem>	Angola	</asp:ListItem>
<asp:ListItem>	Anguilla	</asp:ListItem>
<asp:ListItem>	Antarctica	</asp:ListItem>
<asp:ListItem>	Antigua and Barbuda	</asp:ListItem>
<asp:ListItem>	Argentina	</asp:ListItem>
<asp:ListItem>	Armenia	</asp:ListItem>
<asp:ListItem>	Aruba	</asp:ListItem>
<asp:ListItem>	Australia	</asp:ListItem>
<asp:ListItem>	Austria	</asp:ListItem>
<asp:ListItem>	Azerbaijan	</asp:ListItem>
<asp:ListItem>	Bahamas	</asp:ListItem>
<asp:ListItem>	Bahrain	</asp:ListItem>
<asp:ListItem>	Bangladesh	</asp:ListItem>
<asp:ListItem>	Barbados	</asp:ListItem>
<asp:ListItem>	Belarus	</asp:ListItem>
<asp:ListItem>	Belgium	</asp:ListItem>
<asp:ListItem>	Belize	</asp:ListItem>
<asp:ListItem>	Benin	</asp:ListItem>
<asp:ListItem>	Bermuda	</asp:ListItem>
<asp:ListItem>	Bhutan	</asp:ListItem>
<asp:ListItem>	Bolivia, Plurinational State of	</asp:ListItem>
<asp:ListItem>	Bonaire, Sint Eustatius and Saba	</asp:ListItem>
<asp:ListItem>	Bosnia and Herzegovina	</asp:ListItem>
<asp:ListItem>	Botswana	</asp:ListItem>
<asp:ListItem>	Bouvet Island	</asp:ListItem>
<asp:ListItem>	Brazil	</asp:ListItem>
<asp:ListItem>	British Indian Ocean Territory	</asp:ListItem>
<asp:ListItem>	Brunei Darussalam	</asp:ListItem>
<asp:ListItem>	Bulgaria	</asp:ListItem>
<asp:ListItem>	Burkina Faso	</asp:ListItem>
<asp:ListItem>	Burundi	</asp:ListItem>
<asp:ListItem>	Cabo Verde	</asp:ListItem>
<asp:ListItem>	Cambodia	</asp:ListItem>
<asp:ListItem>	Cameroon	</asp:ListItem>
<asp:ListItem>	Canada	</asp:ListItem>
<asp:ListItem>	Cayman Islands	</asp:ListItem>
<asp:ListItem>	Central African Republic	</asp:ListItem>
<asp:ListItem>	Chad	</asp:ListItem>
<asp:ListItem>	Chile	</asp:ListItem>
<asp:ListItem>	China	</asp:ListItem>
<asp:ListItem>	Christmas Island	</asp:ListItem>
<asp:ListItem>	Cocos (Keeling) Islands	</asp:ListItem>
<asp:ListItem>	Colombia	</asp:ListItem>
<asp:ListItem>	Comoros	</asp:ListItem>
<asp:ListItem>	Congo	</asp:ListItem>
<asp:ListItem>	Congo, Democratic Republic of the	</asp:ListItem>
<asp:ListItem>	Cook Islands	</asp:ListItem>
<asp:ListItem>	Costa Rica	</asp:ListItem>
<asp:ListItem>	Côte D'Ivoire	</asp:ListItem>
<asp:ListItem>	Croatia	</asp:ListItem>
<asp:ListItem>	Cuba	</asp:ListItem>
<asp:ListItem>	Curaço	</asp:ListItem>
<asp:ListItem>	Cyprus	</asp:ListItem>
<asp:ListItem>	Czech Republic	</asp:ListItem>
<asp:ListItem>	Denmark	</asp:ListItem>
<asp:ListItem>	Djibouti	</asp:ListItem>
<asp:ListItem>	Dominica	</asp:ListItem>
<asp:ListItem>	Dominican Republic	</asp:ListItem>
<asp:ListItem>	Ecuador	</asp:ListItem>
<asp:ListItem>	Egypt	</asp:ListItem>
<asp:ListItem>	El Salvador	</asp:ListItem>
<asp:ListItem>	Equatorial Guinea	</asp:ListItem>
<asp:ListItem>	Eritrea	</asp:ListItem>
<asp:ListItem>	Estonia	</asp:ListItem>
<asp:ListItem>	Ethiopia	</asp:ListItem>
<asp:ListItem>	European Economic and Monetary Union area	</asp:ListItem>
<asp:ListItem>	Falkland Islands (Malvinas)	</asp:ListItem>
<asp:ListItem>	Faroe Islands	</asp:ListItem>
<asp:ListItem>	Fiji	</asp:ListItem>
<asp:ListItem>	Finland	</asp:ListItem>
<asp:ListItem>	France	</asp:ListItem>
<asp:ListItem>	French Guiana	</asp:ListItem>
<asp:ListItem>	French Polynesia	</asp:ListItem>
<asp:ListItem>	French Southern Territories	</asp:ListItem>
<asp:ListItem>	Gabon	</asp:ListItem>
<asp:ListItem>	Gambia	</asp:ListItem>
<asp:ListItem>	Georgia	</asp:ListItem>
<asp:ListItem>	Germany	</asp:ListItem>
<asp:ListItem>	Ghana	</asp:ListItem>
<asp:ListItem>	Gibraltar	</asp:ListItem>
<asp:ListItem>	Greece	</asp:ListItem>
<asp:ListItem>	Greenland	</asp:ListItem>
<asp:ListItem>	Grenada	</asp:ListItem>
<asp:ListItem>	Guadeloupe	</asp:ListItem>
<asp:ListItem>	Guam	</asp:ListItem>
<asp:ListItem>	Guatemala	</asp:ListItem>
<asp:ListItem>	Guernsey	</asp:ListItem>
<asp:ListItem>	Guinea	</asp:ListItem>
<asp:ListItem>	Guinea-Bissau	</asp:ListItem>
<asp:ListItem>	Guyana	</asp:ListItem>
<asp:ListItem>	Haiti	</asp:ListItem>
<asp:ListItem>	Heard Island and McDonald Islands	</asp:ListItem>
<asp:ListItem>	Holy See (Vatican City State)	</asp:ListItem>
<asp:ListItem>	Honduras	</asp:ListItem>
<asp:ListItem>	Hong Kong	</asp:ListItem>
<asp:ListItem>	Hungary	</asp:ListItem>
<asp:ListItem>	Iceland	</asp:ListItem>--%>
<asp:ListItem>	India	</asp:ListItem>
<%--
<asp:ListItem>	Indonesia	</asp:ListItem>
<asp:ListItem>	Iran, Islamic Republic Of	</asp:ListItem>
<asp:ListItem>	Iraq	</asp:ListItem>
<asp:ListItem>	Ireland	</asp:ListItem>
<asp:ListItem>	Isle of Man	</asp:ListItem>
<asp:ListItem>	Israel	</asp:ListItem>
<asp:ListItem>	Italy	</asp:ListItem>
<asp:ListItem>	Jamaica	</asp:ListItem>
<asp:ListItem>	Japan	</asp:ListItem>
<asp:ListItem>	Jersey	</asp:ListItem>
<asp:ListItem>	Jordan	</asp:ListItem>
<asp:ListItem>	Kazakhstan	</asp:ListItem>
<asp:ListItem>	Kenya	</asp:ListItem>
<asp:ListItem>	Kiribati	</asp:ListItem>
<asp:ListItem>	Korea, Democratic People's Republic of	</asp:ListItem>
<asp:ListItem>	Korea, Republic of	</asp:ListItem>
<asp:ListItem>	Kuwait	</asp:ListItem>
<asp:ListItem>	Kyrgyzstan	</asp:ListItem>
<asp:ListItem>	Lao People's Democratic Republic	</asp:ListItem>
<asp:ListItem>	Latvia	</asp:ListItem>
<asp:ListItem>	Lebanon	</asp:ListItem>
<asp:ListItem>	Lesotho	</asp:ListItem>
<asp:ListItem>	Liberia	</asp:ListItem>
<asp:ListItem>	Libya	</asp:ListItem>
<asp:ListItem>	Liechtenstein	</asp:ListItem>
<asp:ListItem>	Lithuania	</asp:ListItem>
<asp:ListItem>	Luxembourg	</asp:ListItem>
<asp:ListItem>	Macao	</asp:ListItem>
<asp:ListItem>	Macedonia, The Former Yugoslav Republic of	</asp:ListItem>
<asp:ListItem>	Madagascar	</asp:ListItem>
<asp:ListItem>	Malawi	</asp:ListItem>
<asp:ListItem>	Malaysia	</asp:ListItem>
<asp:ListItem>	Maldives	</asp:ListItem>
<asp:ListItem>	Mali	</asp:ListItem>
<asp:ListItem>	Malta	</asp:ListItem>
<asp:ListItem>	Marshall Islands	</asp:ListItem>
<asp:ListItem>	Martinique	</asp:ListItem>
<asp:ListItem>	Mauritania	</asp:ListItem>
<asp:ListItem>	Mauritius	</asp:ListItem>
<asp:ListItem>	Mayotte	</asp:ListItem>
<asp:ListItem>	Mexico	</asp:ListItem>
<asp:ListItem>	Micronesia, Federated States of	</asp:ListItem>
<asp:ListItem>	Moldova, Republic of	</asp:ListItem>
<asp:ListItem>	Monaco	</asp:ListItem>
<asp:ListItem>	Mongolia	</asp:ListItem>
<asp:ListItem>	Montenegro	</asp:ListItem>
<asp:ListItem>	Montserrat	</asp:ListItem>
<asp:ListItem>	Morocco	</asp:ListItem>
<asp:ListItem>	Mozambique	</asp:ListItem>
<asp:ListItem>	Myanmar	</asp:ListItem>
<asp:ListItem>	Namibia	</asp:ListItem>
<asp:ListItem>	Nauru	</asp:ListItem>
<asp:ListItem>	Nepal	</asp:ListItem>
<asp:ListItem>	Netherlands	</asp:ListItem>
<asp:ListItem>	Netherlands Antilles	</asp:ListItem>
<asp:ListItem>	New Caledonia	</asp:ListItem>
<asp:ListItem>	New Zealand	</asp:ListItem>
<asp:ListItem>	Nicaragua	</asp:ListItem>
<asp:ListItem>	Niger	</asp:ListItem>
<asp:ListItem>	Nigeria	</asp:ListItem>
<asp:ListItem>	Niue	</asp:ListItem>
<asp:ListItem>	Norfolk Island	</asp:ListItem>
<asp:ListItem>	Northern Mariana Islands	</asp:ListItem>
<asp:ListItem>	Norway	</asp:ListItem>
<asp:ListItem>	Oman	</asp:ListItem>
<asp:ListItem>	Pakistan	</asp:ListItem>
<asp:ListItem>	Palau	</asp:ListItem>
<asp:ListItem>	Palestine, State of	</asp:ListItem>
<asp:ListItem>	Panama	</asp:ListItem>
<asp:ListItem>	Papua New Guinea	</asp:ListItem>
<asp:ListItem>	Paraguay	</asp:ListItem>
<asp:ListItem>	Peru	</asp:ListItem>
<asp:ListItem>	Philippines	</asp:ListItem>
<asp:ListItem>	Pitcairn	</asp:ListItem>
<asp:ListItem>	Poland	</asp:ListItem>
<asp:ListItem>	Portugal	</asp:ListItem>
<asp:ListItem>	Puerto Rico	</asp:ListItem>
<asp:ListItem>	Qatar	</asp:ListItem>
<asp:ListItem>	Réunion	</asp:ListItem>
<asp:ListItem>	Romania	</asp:ListItem>
<asp:ListItem>	Russian Federation	</asp:ListItem>
<asp:ListItem>	Rwanda	</asp:ListItem>
<asp:ListItem>	Saint Barthélemy	</asp:ListItem>
<asp:ListItem>	Saint Helena, Ascension and Tristan Da Cunha	</asp:ListItem>
<asp:ListItem>	Saint Kitts and Nevis	</asp:ListItem>
<asp:ListItem>	Saint Lucia	</asp:ListItem>
<asp:ListItem>	Saint Martin (French part)	</asp:ListItem>
<asp:ListItem>	Saint Pierre and Miquelon	</asp:ListItem>
<asp:ListItem>	Saint Vincent and The Grenadines	</asp:ListItem>
<asp:ListItem>	Samoa	</asp:ListItem>
<asp:ListItem>	San Marino	</asp:ListItem>
<asp:ListItem>	Sao Tome and Principe	</asp:ListItem>
<asp:ListItem>	Saudi Arabia	</asp:ListItem>
<asp:ListItem>	Senegal	</asp:ListItem>
<asp:ListItem>	Serbia	</asp:ListItem>
<asp:ListItem>	Seychelles	</asp:ListItem>
<asp:ListItem>	Sierra Leone	</asp:ListItem>
<asp:ListItem>	Singapore	</asp:ListItem>
<asp:ListItem>	Sint Maarten (Dutch part)	</asp:ListItem>
<asp:ListItem>	Slovakia	</asp:ListItem>
<asp:ListItem>	Slovenia	</asp:ListItem>
<asp:ListItem>	Solomon Islands	</asp:ListItem>
<asp:ListItem>	Somalia	</asp:ListItem>
<asp:ListItem>	South Africa	</asp:ListItem>
<asp:ListItem>	South Georgia and the South Sandwich Islands	</asp:ListItem>
<asp:ListItem>	South Sudan	</asp:ListItem>
<asp:ListItem>	Spain	</asp:ListItem>
<asp:ListItem>	Sri Lanka	</asp:ListItem>
<asp:ListItem>	Sudan	</asp:ListItem>
<asp:ListItem>	Suriname	</asp:ListItem>
<asp:ListItem>	Svalbard and Jan Mayen	</asp:ListItem>
<asp:ListItem>	Swaziland	</asp:ListItem>
<asp:ListItem>	Sweden	</asp:ListItem>
<asp:ListItem>	Switzerland	</asp:ListItem>
<asp:ListItem>	Syrian Arab Republic	</asp:ListItem>
<asp:ListItem>	Taiwan, Province of China	</asp:ListItem>
<asp:ListItem>	Tajikistan	</asp:ListItem>
<asp:ListItem>	Tanzania, United Republic of	</asp:ListItem>
<asp:ListItem>	Thailand	</asp:ListItem>
<asp:ListItem>	Timor-Leste	</asp:ListItem>
<asp:ListItem>	Togo	</asp:ListItem>
<asp:ListItem>	Tokelau	</asp:ListItem>
<asp:ListItem>	Tonga	</asp:ListItem>
<asp:ListItem>	Trinidad and Tobago	</asp:ListItem>
<asp:ListItem>	Tunisia	</asp:ListItem>
<asp:ListItem>	Turkey	</asp:ListItem>
<asp:ListItem>	Turkmenistan	</asp:ListItem>
<asp:ListItem>	Turks and Caicos Islands	</asp:ListItem>
<asp:ListItem>	Tuvalu	</asp:ListItem>
<asp:ListItem>	Uganda	</asp:ListItem>
<asp:ListItem>	Ukraine	</asp:ListItem>
<asp:ListItem>	United Arab Emirates	</asp:ListItem>
<asp:ListItem>	United Kingdom	</asp:ListItem>
<asp:ListItem>	United States	</asp:ListItem>
<asp:ListItem>	United States Minor Outlying Islands	</asp:ListItem>
<asp:ListItem>	Uruguay	</asp:ListItem>
<asp:ListItem>	Uzbekistan	</asp:ListItem>
<asp:ListItem>	Vanuatu	</asp:ListItem>
<asp:ListItem>	Venezuela, Bolivarian Republic of	</asp:ListItem>
<asp:ListItem>	Viet Nam	</asp:ListItem>
<asp:ListItem>	Virgin Islands, British	</asp:ListItem>
<asp:ListItem>	Virgin Islands, U.S.	</asp:ListItem>
<asp:ListItem>	Wallis And Futuna	</asp:ListItem>
<asp:ListItem>	Western Sahara	</asp:ListItem>
<asp:ListItem>	Yemen	</asp:ListItem>
<asp:ListItem>	Zambia	</asp:ListItem>
<asp:ListItem>	Zimbabwe	</asp:ListItem>--%>
        </asp:DropDownList>
     <br />
        <asp:Label ID="Label11" runat="server" Text="State"></asp:Label>
          <asp:DropDownList ID="cmbstate" runat="server" 
                        onselectedindexchanged="state_SelectedIndexChanged" AutoPostBack="True" 
                         CssClass="form-control" AppendDataBoundItems="true">
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
                    </asp:DropDownList>
        <br />
        <asp:Label ID="Label12" runat="server" Text="City"></asp:Label>
       <asp:DropDownList ID="cmbcity" runat="server"    class="form-control" >
                                <asp:ListItem>--Select City--</asp:ListItem>
                                </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Mobile No."></asp:Label>
         <asp:TextBox ID="txtMobile" runat="server" required="required"></asp:TextBox>
         <br />
        <asp:Label ID="Label3" runat="server" Text="Success Story"></asp:Label>
        
        <asp:TextBox ID="txtStory" runat="server" TextMode="MultiLine" required="required"></asp:TextBox>
        <br />
        <asp:Label ID="Label46" runat="server" Text="Upload Photo"></asp:Label>
        <asp:FileUpload ID="fupProPic" runat="server" />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" />
        
    </div>
    </form>
</body>
</html>
