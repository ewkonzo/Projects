<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HIMS.Login1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



   <div class="sub">
   </div>

<div class = "contents">  

    <div class="errorlbl"> <asp:Label ID="lblError" runat="server" Text=""></asp:Label></div>


<table>
<tr>
<td rowspan="4">
<img src="images/logo.png" alt="" />
</td>
</tr>
<tr>
<td>	  
    <asp:Label ID="Pin_NoLabel" runat="server" AssociatedControlID="Username"><span style='font-weight:bold;' class="label">Username:</span></asp:Label>
</td>
 <td><asp:TextBox ID="Username" runat="server" Height="22" BorderColor="#999999" BorderStyle="Solid"  CssClass="textEntry"></asp:TextBox>
   </td>
   <td>
    <asp:RequiredFieldValidator ID="Personal_NoRequired" runat="server" ControlToValidate="Username" 
            CssClass="failureNotification" ErrorMessage="Pin_No is required." ToolTip="Pin_No is required." 
            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
</td>
</tr>
 <tr>
 <td>
    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password"><span style='font-weight:bold;' class="label">Password:</span></asp:Label>
 </td> 
 <td>
   <asp:TextBox ID="Password" runat="server" Height="22" BorderColor="#999999" BorderStyle="Solid" CssClass="textEntry" TextMode="Password"></asp:TextBox>
   </td>
   <td>
    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
            ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
 
   </td> 
   </tr>
<tr>
<td></td>
<td>
        <asp:Button ID="LoginButton" runat="server" CssClass="button" CommandName="Login" Text="Login" 
            ValidationGroup="LoginUserValidationGroup" onclick="LoginButton_Click">
                        </asp:Button>
    </td>
</tr>  
<%--<tr>
<td></td>
<td></td>
<td colspan="2"><a href="ForgotPassword.aspx">Forgot Account Details?</a></td>
 </tr>--%>
 </table>

    
</div>

</asp:Content>
