<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="newbulksmstopup.aspx.cs" Inherits="HIMS.newbulksmstopup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Home_Master" runat="server">

<%--<div class="sub">
   <a href="Login.aspx">Login.</a> Click here to login.
   </div>--%>

 <fieldset>
<legend>BULK SMS TOPUP</legend>
   
   <div class="signingup">
    <div class="errorlbl"> <asp:Label ID="lblError" runat="server" Text=""></asp:Label></div>

    <%--<span style="padding-left:300px;color:Black">Please fill all the fields with <span style="color:red;">*</span></span>--%>
	  <table class="regTable">
     
<%--<tr>
<td> <asp:Label ID="lblFirmname" runat="server" AssociatedControlID="LegalFirmName"><span class="label">
<span style="color:red;">*</span>Legal name of firm:</span></asp:Label></td>
<td> <asp:TextBox ID="LegalFirmName" runat="server" Height="22" BorderColor="#999999" BorderStyle="Solid" 
CssClass="textEntry"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LegalFirmName" 
CssClass="failureNotification" ErrorMessage="Firm name is required." ToolTip="Firm name is required." 
ValidationGroup="LoginUserValidationGroup"><span style="color:red;">*</span></asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="LegalFirmName" 
ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^[ a-zA-Z0-9.''-'@\s]{1,50}$">
<span style="color:red;">Invalid</span></asp:RegularExpressionValidator>

</td>
<td></td>
<td></td> 
</tr>--%>


<%--<tr>
<td> <asp:Label ID="lblPoBox" runat="server" AssociatedControlID="PoBox"><span class="label"><span style="color:red;">*</span>P.O. Box:</span></asp:Label></td>
<td> <asp:TextBox ID="PoBox" runat="server" Height="22" BorderColor="#999999" BorderStyle="Solid"  CssClass="textEntry"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PoBox" 
CssClass="failureNotification" ErrorMessage="Po Box is required." ToolTip="Po Box is required." 
ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>


<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PoBox" 
ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^[ a-zA-Z0-9\-,.-@\s]{1,50}$">
<span style="color:red;">Invalid</span></asp:RegularExpressionValidator>
</td>
<td>
<asp:Label ID="lblPostCode" runat="server" AssociatedControlID="PostCode"><span class="label"><span style="color:red;">*</span>Postcode:</span></asp:Label>
</td>
<td>
 <asp:TextBox ID="PostCode" runat="server" Height="22" BorderColor="#999999" BorderStyle="Solid"  CssClass="textEntry"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PostCode" 
CssClass="failureNotification" ErrorMessage="City / Town is required." ToolTip="PoBox is required." 
ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PostCode" 
ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^[0-9-@\s]{1,50}$">
<span style="color:red;">Invalid</span></asp:RegularExpressionValidator>


</td> 
</tr>--%>

<tr>
<td> <asp:Label ID="lbl_Sacco" runat="server" AssociatedControlID="DropSacco"><span class="label"><span style="color:red;">*</span>SACCO:</span></asp:Label></td>
<td>
<asp:DropDownList ID="DropSacco" CssClass="DropdownSel" runat="server" AutoPostBack="false" AppendDataBoundItems="true">
</asp:DropDownList>       
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropSacco" 
CssClass="failureNotification" ErrorMessage="SACCO is required." ToolTip="SACCO is required." 
ValidationGroup="LoginUserValidationGroup"><span style="color:red;">*</span></asp:RequiredFieldValidator>
</td>
<%--<td>
<asp:Label ID="lblDropCountry" runat="server" AssociatedControlID="DropDownCountry">
<span class="label"><span style="color:red;">*</span>Country:</span></asp:Label>
</td>
<td>
<asp:DropDownList ID="DropDownCountry" CssClass="DropdownSel" runat="server" AutoPostBack="false" AppendDataBoundItems="true">
</asp:DropDownList>       
<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDownCountry" 
CssClass="failureNotification" ErrorMessage="Country is required." ToolTip="Country is required." 
ValidationGroup="LoginUserValidationGroup"><span style="color:red;">*</span></asp:RequiredFieldValidator>
</td> --%>     
</tr>

<tr>
<td> <asp:Label ID="lblTopupFigure" runat="server" AssociatedControlID="Topup_Figure"><span class="label">
<span style="color:red;">*</span>Topup Figure:</span></asp:Label></td>
<td> <asp:TextBox ID="Topup_Figure" runat="server" Height="22" BorderColor="#999999" BorderStyle="Solid" 
CssClass="textEntry"></asp:TextBox>
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Topup_Figure" 
CssClass="failureNotification" ErrorMessage="Topup figure is required." ToolTip="Topup figure is required." 
ValidationGroup="LoginUserValidationGroup" ValidationExpression="^[0-9+\s]{1,50}$">*</asp:RequiredFieldValidator>
--%>

<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Topup_Figure" 
ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^[0-9+\s]{1,50}$">
<span style="color:red;">Invalid</span></asp:RegularExpressionValidator>--%>
</td>

</tr>

<tr>
<td> <asp:Label ID="lblComments" runat="server" AssociatedControlID="Comments"><span class="label">
<span style="color:red;">*</span>Comments:</span></asp:Label></td>
<td> <asp:TextBox ID="Comments" runat="server" Height="22" BorderColor="#999999" BorderStyle="Solid" 
CssClass="textEntry"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="Comments" 
CssClass="failureNotification" ErrorMessage="Comments is required." ToolTip="Comments is required." 
ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="Comments" 
ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^[ a-zA-Z0-9.-@\s]{1,50}$">
<span style="color:red;">Invalid</span></asp:RegularExpressionValidator>
</td>
</tr>




    <tr>
    <td></td>
<td class="submitButton">
        <asp:Button ID="SaveButton" runat="server" Text="Save" 
            ValidationGroup="LoginUserValidationGroup" onclick="SaveButton_Click" />
        <asp:Button ID="CancelButton" runat="server" Text="Cancel" onclick="CancelButton_Click" />
    </td>
    </tr>
    </table>
    
 </div>
 </fieldset>

</asp:Content>
 

