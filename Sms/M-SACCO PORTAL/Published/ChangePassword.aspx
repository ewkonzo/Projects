<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="HIMS.ChangePassword" %>
<%@ import namespace="Global.HIMS" %>
<%@Import Namespace="System.Web"%>
<%@Import Namespace="System.Web.UI"%>
<%@Import Namespace="System.Data"%>
<%@Import Namespace="System.Data.SqlClient"%>

<asp:Content ID="Content1" ContentPlaceHolderID="Home_Master" runat="server">


<style type="text/css">
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

<div class="errorlbl"> <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
</div>

<div class="style1">
<h6 class="style2" style="text-transform:uppercase;"> <b> Change Password </b> </h6>
</div>

<br/>
<center>
<table class="regTable2" width="60%"  style="border: thin ridge #C0C0C0;">

<tr  style="border: thin ridge #C0C0C0;" >
<td style="padding-left:30px;"> <asp:Label ID="lblNameOfBank" runat="server"><span class="label">
 Current Password:</span></asp:Label></td>
<td> <asp:TextBox ID="txtCurrentPswd" runat="server" Height="20" TextMode="Password" BorderColor="#999999" BorderStyle="Solid"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCurrentPswd" 
ErrorMessage="First Name is required." ToolTip="First name is required." 
ValidationGroup="LoginUserValidationGroup"><span style="color:red;">*</span></asp:RequiredFieldValidator>
</td>
</tr>
<tr  style="border: thin ridge #C0C0C0;">
<td style="padding-left:30px;">
<asp:Label ID="lblAccountName" runat="server"><span class="label">
 New Password:</span></asp:Label>
</td>
<td>
<asp:TextBox ID="txtNewPswd" runat="server" Height="20" TextMode="Password" BorderColor="#999999" BorderStyle="Solid"></asp:TextBox> 
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewPswd" 
ErrorMessage="Last Name is required." ToolTip="Last name is required." 
ValidationGroup="LoginUserValidationGroup"><span style="color:red;">*</span></asp:RequiredFieldValidator>     
</td>
</tr>
<tr  style="border: thin ridge #C0C0C0;">
<td style="padding-left:30px;">
<asp:Label ID="Label1" runat="server"><span class="label">
 Confirm New Password:</span></asp:Label>
</td>
<td>
<asp:TextBox ID="txtConfirmPswd" runat="server" Height="20" TextMode="Password" BorderColor="#999999" BorderStyle="Solid"></asp:TextBox> 
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirmPswd" 
ErrorMessage="Username is required." ToolTip="Username is required." 
ValidationGroup="LoginUserValidationGroup"><span style="color:red;">*</span></asp:RequiredFieldValidator>      
</td>
</tr>
<tr>
<td></td>
<td class="submitButton2">
<asp:Button style="" ID="Save" runat="server" 
CommandName="Save" Text="Save" Width="65px"   ValidationGroup="LoginUserValidationGroup" onclick="save_Click"/>
</td>
</tr>
</table>
</center>
</asp:Content>
