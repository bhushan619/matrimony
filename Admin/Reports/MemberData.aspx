﻿<%@ Page MaintainScrollPositionOnPostback="true"  Language="C#" AutoEventWireup="true" CodeFile="MemberData.aspx.cs" Inherits="Admin_Reports_MemberData" %>

<!DOCTYPE html>
 <html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Swapnpurti Matrimony | Member Data</title>  <link rel="alternate" href="http://swapnpurti.in" hreflang="en-in" />   <link rel="shortcut icon" href="../../images/favicon.ico" type="image/x-icon" /><link rel="icon" href="../../images/favicon.ico" type="image/x-icon" />
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
		<link href="../../css/animate.css" rel="stylesheet" type="text/css" media="all">
		<script src="../../js/wow.min.js"></script>
		<script>
		    new WOW().init();
		</script>
<!-- animated-css --> 
    <script type = "text/javascript">
function Check_Click(objRef)
{
    //Get the Row based on checkbox
    var row = objRef.parentNode.parentNode;
    if(objRef.checked)
    {
        //If checked change color to Aqua
        row.style.backgroundColor = "aqua";
    }
    else
    {    
        //If not checked change back to original color
        if(row.rowIndex % 2 == 0)
        {
           //Alternating Row Color
           row.style.backgroundColor = "#C2D69B";
        }
        else
        {
           row.style.backgroundColor = "white";
        }
    }
    
    //Get the reference of GridView
    var GridView = row.parentNode;
    
    //Get all input elements in Gridview
    var inputList = GridView.getElementsByTagName("input");
    
    for (var i=0;i<inputList.length;i++)
    {
        //The First element is the Header Checkbox
        var headerCheckBox = inputList[0];
        
        //Based on all or none checkboxes
        //are checked check/uncheck Header Checkbox
        var checked = true;
        if(inputList[i].type == "checkbox" && inputList[i] != headerCheckBox)
        {
            if(!inputList[i].checked)
            {
                checked = false;
                break;
            }
        }
    }
    headerCheckBox.checked = checked;
    
}
</script>
<script type = "text/javascript">
function checkAll(objRef)
{
    var GridView = objRef.parentNode.parentNode.parentNode;
    var inputList = GridView.getElementsByTagName("input");
    for (var i=0;i<inputList.length;i++)
    {
        //Get the Cell To find out ColumnIndex
        var row = inputList[i].parentNode.parentNode;
        if(inputList[i].type == "checkbox"  && objRef != inputList[i])
        {
            if (objRef.checked)
            {
                //If the header checkbox is checked
                //check all checkboxes
                //and highlight all rows
                row.style.backgroundColor = "aqua";
                inputList[i].checked=true;
            }
            else
            {
                //If the header checkbox is checked
                //uncheck all checkboxes
                //and change rowcolor back to original 
                if(row.rowIndex % 2 == 0)
                {
                   //Alternating Row Color
                   row.style.backgroundColor = "#C2D69B";
                }
                else
                {
                   row.style.backgroundColor = "white";
                }
                inputList[i].checked=false;
            }
        }
    }
}
</script>
<script type = "text/javascript">
function MouseEvents(objRef, evt)
{
    var checkbox = objRef.getElementsByTagName("input")[0];
   if (evt.type == "mouseover")
   {
        objRef.style.backgroundColor = "orange";
   }
   else
   {
        if (checkbox.checked)
        {
            objRef.style.backgroundColor = "aqua";
        }
        else if(evt.type == "mouseout")
        {
            if(objRef.rowIndex % 2 == 0)
            {
               //Alternating Row Color
               objRef.style.backgroundColor = "#C2D69B";
            }
            else
            {
               objRef.style.backgroundColor = "white";
            }
        }
   }
}
</script>   
</head>
<body >

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
                                <li ><a href="../Franchisee/ViewFranchisee.aspx">View Franchisee </a></li>                             

                        
	                            </ul>
                        	</li> 
                       <li class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown"href="#" >Package<b class="caret"></b></a>
                               <ul class="dropdown-menu">
                                <li ><a href="PackageRegister.aspx">Add Package</a></li>
                                <li ><a href="ViewPackage.aspx">View Package</a></li> 
                               
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
                       <li ><a href="ViewReports.aspx">Report</a></li> 
                    <li ><a href="MemberData.aspx">Member Data</a></li> 
                     
                </ul>   
		</div></div>
                </div>
	<div class="container">	 
      
        <br />
     <div class="row"> <div class="col-lg-7 "> </div>
      <div class="col-lg-2"><asp:Button ID="btnimages" runat="server"  OnClick="btnimages_Click"  Text="Download Images In Zip" CssClass=" btn btn-primary" />

      </div>
            <div class="col-lg-3 "></div>
      <asp:Button ID="btnExportUnpaid" runat="server"  OnClick="btnExportUnpaid_Click"  Text="Download Data In Excel" CssClass=" btn btn-primary" />
    </div><br />
        <div class="row"> 
                <div class="col-lg-1 "> </div>
            <div class="col-lg-10  table-responsive">
<%--                <asp:GridView ID="GridView2" runat="server"
AutoGenerateColumns = "false" Font-Names = "Arial"
Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B" 
HeaderStyle-BackColor = "green" AllowPaging ="true"  
OnPageIndexChanging = "OnPaging" DataKeyNames = "CustomerID" >
<Columns>
<asp:TemplateField>
<HeaderTemplate>
  <asp:CheckBox ID="chkAll" runat="server" onclick = "checkAll(this)" />
</HeaderTemplate>
<ItemTemplate>
 <asp:CheckBox ID="CheckBox1" runat="server" onclick = "Check_Click(this)" />
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField ItemStyle-Width = "150px" DataField = "CustomerID"
 HeaderText = "CustomerID" />
<asp:BoundField ItemStyle-Width = "150px" DataField = "City"
 HeaderText = "City"/>
<asp:BoundField ItemStyle-Width = "150px" DataField = "Country"
 HeaderText = "Country"/>
<asp:BoundField ItemStyle-Width = "150px" DataField = "PostalCode"
 HeaderText = "PostalCode"/>
</Columns>
</asp:GridView>--%>
        <asp:GridView ID="grdUpdaidMember" runat="server" AllowPaging="True" CssClass="table table-bordered" 
             AutoGenerateColumns="False"   PageSize="15" OnPageIndexChanging="grdUpdaidMember_PageIndexChanging"  
           >
            <Columns>
                             
            <asp:BoundField DataField="varMemberId" HeaderText="Member ID" SortExpression="varMemberId" />            
            <asp:BoundField DataField="varMembershipType" HeaderText="MemberShip Type" SortExpression="varMembershipType" />            
           <%-- <asp:BoundField DataField="varMemberFor" HeaderText="Profile for" SortExpression="varMemberFor" />  --%>          
            <asp:BoundField DataField="varMemberName" HeaderText="Member Name" SortExpression="varMemberName" />            
            <asp:BoundField DataField="varGender" HeaderText="Gender" SortExpression="varGender" />            
            <asp:BoundField DataField="varMobile" HeaderText="Mobile No." SortExpression="varMobile" />  
                     <asp:BoundField DataField="varEmail" HeaderText="EmailId" SortExpression="varEmail" />              
            <asp:BoundField DataField="varMemberStatus" HeaderText="Member Status" SortExpression="varMemberStatus" />
            <asp:BoundField DataField="varCreatorDesignation" HeaderText="Creator Designation" SortExpression="varCreatorDesignation" />  
           
                   <asp:TemplateField>
                <HeaderTemplate>Image </HeaderTemplate>
         <ItemTemplate>
               
            <asp:Image  ImageUrl='<%# "~/Members/media/"+Eval("varPhoto") %>' runat="server"   CssClass="img-thumbnail" Height="50px"  Width="50px"></asp:Image>
              
         </ItemTemplate> 
               
                </asp:TemplateField>  
            <asp:TemplateField>
                <HeaderTemplate><asp:CheckBox ID="chkAll" runat="server" onclick = "checkAll(this)" /> </HeaderTemplate>
         <ItemTemplate>
              <asp:CheckBox ID="CheckBox1" runat="server" onclick = "Check_Click(this)" />   
          <%--  <asp:Image  ImageUrl='<%# "~/Members/media/"+Eval("varPhoto") %>' runat="server"   CssClass="img-thumbnail" Height="50px"  Width="50px"></asp:Image>
             --%> 
         </ItemTemplate> 
               
                </asp:TemplateField> 
                 
                
        </Columns>
              <EmptyDataTemplate>

              No Data Found.  

        </EmptyDataTemplate> <PagerSettings Mode="Numeric" />
        </asp:GridView>
              
                  <asp:GridView ID="GridView1" runat="server" ShowHeader="false" AutoGenerateColumns="false" EmptyDataText="No files available">
        <Columns>
           <asp:BoundField DataField="varPhoto"   /> 
        </Columns>
    </asp:GridView>

                
    </div>
      </div></div>   
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
