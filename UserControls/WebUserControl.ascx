<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="UserControls_WebUserControl" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>

 <div class="borsolid"></div>
                       <span class="j10font">(<asp:Label ID="lblCountPeople" runat="server" Text="Label"></asp:Label>) People Match Your Search Criteria.</span>    <br />   
                   <span class="j10font"> Search Criteria.</span>    <br /> 
<asp:ListView ID="lstViewedProfiles" runat="server" 
             GroupPlaceholderID="groupPlaceHolder1">
              <EmptyDataTemplate>
                <div class="well-sm"><span>No  Profiles Found.</span></div>  
            </EmptyDataTemplate> 
 <ItemTemplate>
     <div style="border: 1px solid #dfdfdf; background-image: url('../../images/pat.jpg');   padding: 0px 15px 5px;    margin-top: 10px;" >
          <div class="row j10fontAbout " >
         <div class="col-lg-12" >
             <div class="row "> 
                   <br />
                 <div class="col-lg-8 ">
                     <div class="jsideleft">  &nbsp; <asp:Label ID="Label10" runat="server" Text='<%# Eval("IntersestMemName") %>' Font-Bold="true" Font-Size="17px"/>  ( <asp:LinkButton ID="lblCollege" runat="server"    CommandArgument='<%# Eval("IntersestMemId") %>'   OnClick="OpenProfile" Text='<%# Eval("IntersestMemId") %>' Font-Bold="true" Font-Size="17px"></asp:LinkButton> )
  &nbsp;&nbsp; <asp:LinkButton ID="lblname" runat="server"   CssClass="label label-success"    CommandArgument='<%# Eval("IntersestMemId") %>' OnClick="OpenProfile" Text='<%# Eval("IntersestMemPackage") %>'></asp:LinkButton>&nbsp;&nbsp;
   <%--  Shown Interest On: <asp:Label ID="Label7" runat="server" Text='<%# Eval("IntersestMemDate") %>' />&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;--%>
 </div> </div> 
   <div class="col-lg-4 "> 
       <div class="jsideright">
            <asp:LinkButton ID="LinkButton2" runat="server"    CommandArgument='<%# Eval("IntersestMemId") %>'   OnClick="OpenProfile" Text="View  Profile"></asp:LinkButton> <br />
    <br /></div> </div>
             </div>
   <div class="col-lg-2 bsideleft" >
        <asp:ImageButton ID="imgSimilarPic"  runat="server"   CssClass="img-thumbnail" Height="110px" Width="110px" OnClick="imgmember_Click"      CommandArgument='<%# Eval("IntersestMemId")+";"+Eval("IntersestMemPhoto") %>'    ImageUrl='<%# "~/members/media/" + Eval("IntersestMemPhoto") %>' /> 
          
      </div>
   
              <div class="col-lg-3 " > <div >
                  <%-- Shown Interest On:<br /> <asp:Label ID="Label7" runat="server" Text='<%# Eval("IntersestMemDate") %>' /><br /><br />--%>
    About <asp:Label ID="Label11" runat="server" Text='<%# Eval("IntersestMemAccFor") %>' />: 
  <p class="j10fontAbout"> <asp:Label ID="lblDescription" runat="server"  Text='<%# Limit(Eval("IntersestMemAbout"),60) %>'   Tooltip='<%# Eval("IntersestMemAbout") %>'>      </asp:Label>
  <br /> <asp:LinkButton ID="ReadMoreLinkButton" runat="server"    Text="..Read More"  CommandArgument='<%# Eval("IntersestMemId") %>'       OnClick="OpenProfile">      </asp:LinkButton>
 </p>  </div>
                  </div>
<div class="col-lg-7" >
Profile Created For <asp:Label ID="Label9" runat="server" Text='<%# Eval("IntersestMemAccFor") %>' />  <br /> 
Age :<asp:Label ID="AgeLabel" runat="server" Text='<%# Eval("IntersestMemAge") %>' />,
    Height:<asp:Label ID="HeightLabel" runat="server" Text='<%# Eval("IntersestMemHeight") %>' />/ 
           <asp:Label ID="Label6" runat="server" Text='<%# Eval("IntersestMemHeightcm") %>' />, <br />  
Religion :    <asp:Label ID="ReligionLabel" runat="server" Text='<%# Eval("IntersestMemReligion") %>' /><br /> 
 Caste :     <asp:Label ID="CasteLabel" runat="server" Text='<%# Eval("IntersestMemCaste") %>' /> <br /> 
 Subcaste :     <asp:Label ID="Label5" runat="server" Text='<%# Eval("IntersestMemSCaste") %>' />  <br /> 
  Location : <asp:Label ID="Label3" runat="server" Text='<%# Eval("IntersestMemCity") %>' />,  
       <asp:Label ID="Label2" runat="server" Text='<%# Eval("IntersestMemState") %>' /> ,
         <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("IntersestMemCountry") %>' />  <br />
 Education :   <asp:Label ID="EducationLabel" runat="server" Text='<%# Eval("IntersestMemEducation") %>' /> <br />
    Occupation :        <asp:Label ID="Label4" runat="server" Text='<%# Eval("IntersestMemOccupation") %>' />  <br />
  </div>    
             </div>     
         </div> 
      <div class="row " >
   <div class="bordex"></div>  
          <div class="jsideright ">   
        <%--   <asp:LinkButton ID="LinkButton1" runat="server"    CommandArgument='<%# Eval("IntersestMemId") %>'  OnClick="OpenProfile" Text="View Full Profile"></asp:LinkButton>
             --%>
              <asp:LinkButton ID="lnkInterest" runat="server" OnClick="lnkInterest_Click"  CommandArgument='<%# Eval("IntersestMemId") %>' Text="Send Interest" class="btn btn-danger btn-xs"></asp:LinkButton> &nbsp;&nbsp;
        <asp:LinkButton ID="lnkShortlist" runat="server" onclick="lnkShortlist_Click"  CommandArgument='<%# Eval("IntersestMemId") %>' Text="Shortlist" class="btn btn-warning btn-xs"></asp:LinkButton>     
              
            </div></div>
      </div>   </ItemTemplate>
            <LayoutTemplate>  <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
            <div ID="itemPlaceholderContainer" runat="server"  >
                    <span runat="server" id="itemPlaceholder" />
                </div>
</LayoutTemplate>
        </asp:ListView>

<asp:Button ID="LoadMore" runat="server" Width="100%" onclick="LoadMore_Click" 
        Text="Load More..."  CssClass="btn btn-primary" />

          <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
        ClientIDMode="Static">
        <ProgressTemplate>
            <b>Loading Additional Data....</b>
        </ProgressTemplate>
    </asp:UpdateProgress>


<div id="InterestListview" runat="server"> 
<asp:ListView ID="lstviewedProfile" runat="server" >  
           
            <ItemTemplate>
                <table cellpadding="0" cellspacing="0" width="513">
																<tbody>
                                                                    
                                                                    <tr><td>&nbsp;</td></tr>
                                                                    <tr>
																	<td align="left" valign="top" width="15"></td>
																	<td align="left" valign="top" width="102"><asp:Image ID="vimgSimilarPic" runat="server"    ImageUrl='<%# "http://swapnpurti.in/members/media/" + Eval("Photo") %>'  Height="90px" Width="90px" BorderStyle="Solid" BorderWidth="1px" BorderColor="#DFDFDF"  /></td><td align="left" valign="top" width="15"></td>
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