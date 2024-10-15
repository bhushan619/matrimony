<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="BookletData.aspx.cs" Inherits="Admin_Reports_BookletData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title><link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />   <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
                                    <asp:Button ID="btnExportProduction" runat="server" CssClass=" btn btn-success" Text="Download In Excel" OnClick="btnExportProduction_Click"  />
                           <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:matrimonyConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:matrimonyConnectionString.ProviderName %>" 
        SelectCommand="SELECT DISTINCT tblampackages.varPackageId, tblampackages.varPackageName, tblampackagesdetails.intId ,tblampackagesdetails.varPackageDescription, tblampackagesdetails.varPackageDuration, tblampackagesdetails.varPackagePrice, tblampackagesdetails.varBenifits, tblampackagesdetails.varPackageDurationTime FROM tblampackages INNER JOIN tblampackagesdetails ON tblampackages.varPackageId = tblampackagesdetails.varPackageId">
    </asp:SqlDataSource>
    <asp:ListView ID="lstViewPackage" runat="server" DataSourceID="SqlDataSource1" 
        GroupItemCount="3" onitemcommand="ListView1_ItemCommand">
        
        
        <EmptyDataTemplate>
            <table id="Table1" runat="server" style="">
                <tr>
                    <td>
                        No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        
        <GroupTemplate>
            <tr ID="itemPlaceholderContainer" runat="server">
                <td ID="itemPlaceholder" runat="server">
                </td>
            </tr>
        </GroupTemplate>
        
        <ItemTemplate>
            <td id="Td1" runat="server" style="">
                 <asp:Label ID="Label1" runat="server" 
                    Text='<%# Eval("intId") %>' Visible="false" />
                Package Name:
                <asp:Label ID="varPackageNameLabel" runat="server" 
                    Text='<%# Eval("varPackageName") %>' />
                <br />
               
                Package Duration:
                <asp:Label ID="varPackageDurationLabel" runat="server" 
                    Text='<%# Eval("varPackageDuration") %>' />
                <br /> 
                     Package Duration Time:
                <asp:Label ID="varPackageDurationTimeLabel" runat="server" 
                    Text='<%# Eval("varPackageDurationTime") %>' />
                <br />
                Package Price:
                <asp:Label ID="varPackagePriceLabel" runat="server" 
                    Text='<%# Eval("varPackagePrice") %>' />
                <br /> 
                Package Description:
                <asp:Label ID="varPackageDescriptionLabel" runat="server" 
                    Text='<%# Eval("varPackageDescription") %>' />
                <br />
                Benifits:
                <asp:Label ID="varBenifitsLabel" runat="server" 
                    Text='<%# Eval("varBenifits") %>' />
                <br />
          <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("intId") %>' CommandName="Edit">Edit</asp:LinkButton>
            </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="Table2" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td2" runat="server">
                        <table ID="groupPlaceholderContainer" runat="server" border="0" style="">
                            <tr ID="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr2" runat="server">
                    <td id="Td3" runat="server" style="">
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
         
    </asp:ListView> 
       <%--      <asp:GridView ID="grdStockJalgaon" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-responsive"  AllowPaging="True" PageSize="15" DataKeyNames="intId"                                      
                                     >
                                         <Columns> 
                                     <asp:BoundField DataField="dtDate" HeaderText="Date" 
                                                 SortExpression="dtDate" />
                                        <asp:BoundField DataField="varProName" HeaderText="Product Name" 
                                            SortExpression="varProName" /> 
                                        <asp:BoundField DataField="intSack" HeaderText="Sack" 
                                            SortExpression="intSack" />
                                        <asp:BoundField DataField="intNug" HeaderText="Nug" 
                                            SortExpression="intNug" />
                                                 <asp:BoundField DataField="total" HeaderText="Total" 
                                            SortExpression="total" />                                           
                                           
                                             <asp:BoundField DataField="varReason" HeaderText="Reason" 
                                                 SortExpression="varReason" />
                                    </Columns>
                                </asp:GridView>        --%>                               
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
