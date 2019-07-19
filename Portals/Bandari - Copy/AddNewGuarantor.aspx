<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewGuarantor.aspx.cs" Inherits="Bandari_Sacco.AddNewGuarantor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css" >
 p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:10.0pt;
	font-family:"Times New Roman","serif";
	    margin-left: 0in;
        margin-right: 0in;
        margin-top: 0in;
    }
p.MsoBodyTextIndent
	{margin-bottom:.0001pt;
	font-size:12.0pt;
	font-family:"Garamond","serif";
	    margin-left: 0in;
        margin-right: 0in;
        margin-top: 0in;
    }
p.MsoBodyTextIndent3
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	text-align:justify;
	font-size:12.0pt;
	font-family:"Garamond","serif";
	}
    .style1
    {
        text-align: left;
    }
        .style2
        {
            text-align: center;
        }
        .style3
        {
            color: #6699FF;
        }
        .style4
        {
            text-decoration: underline;
        }
    .style5
    {
        color: red;
        font-size: larger;
    }
        .style6
        {
            font-family: "Palatino Linotype";
        }
        .style7
        {
            background-color: #0066FF;
        }
        .style8
        {
            color: white;
        }
        .style11
        {
            background-color: #33CC33;
            color: #FFFFFF;
        }
        .style12
        {
            background-color: #FFCC00;
        }
        .style13
        {
            font-size: medium;
        }
        .style14
        {
            color: red;
        }
    </style>
    <fieldset>
<legend >::.. Add New Guarantor ..::</legend>
 <div class="homecontentTenderDoc"> 

 <div class="signingup">

 <table width="100%">
<tr>
<td colspan="2" class="submitButton" >
<asp:Button style="float:left;margin-left:50px;" ID="Back" runat="server" CssClass="btn btn-primary" 
CommandName="Back" Text="<< Back" 
Width="95px" onclick="Back_Click" />
</td>

</tr>
</table>

     <span style="padding-left:300px;color:Black">Please enter the Guarantor Membership No</span>

    <div class="errorlbl"> <asp:Label ID="lblError" runat="server" Text=""></asp:Label></div>

<table class="regTable" width="100%"  style="border: thin ridge #C0C0C0;">
<tr  style="border: thin ridge #C0C0C0;">
<td style="padding-left:30px;"> <asp:Label ID="lblPartnerName" runat="server" AssociatedControlID="GuarantorMemberNo"><span class="label">
<span style="color:red;">*</span>Member No:</span></asp:Label></td>
<td> <asp:TextBox ID="GuarantorMemberNo" runat="server"
CssClass="btn btn-primary"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="GuarantorMemberNo" 
CssClass="failureNotification" ErrorMessage="Partner Name is required." ToolTip="Partner Name is required." 
ValidationGroup="LoginUserValidationGroup"><span style="color:red">*</span></asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="GuarantorMemberNo" 
ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^[ a-zA-Z0-9.-@\s]{1,50}$">
<span style="color:red;">Invalid</span></asp:RegularExpressionValidator>
</td>
</tr>


<tr>
<td></td>
<td  >
<asp:Button style="" ID="Save" runat="server" CssClass="btn btn-primary"
CommandName="Save" Text="Save" 
ValidationGroup="LoginUserValidationGroup"  
Width="65px" onclick="Save_Click"  />
</td>
</tr>

</table>
   
 </div>
 </div>
 </fieldset>
</asp:Content>
