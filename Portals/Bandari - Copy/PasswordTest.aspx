<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PasswordTest.aspx.cs" Inherits="Bandari_Sacco.PasswordTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        $('#meter').entropizer({ target: '#password' });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td>Please enter password</td>
            <td><input id="password" type="password" name="pwd"/></td>
            <td><div id="meter" ></div></td>
        </tr>
        <tr>
            <td>
                
            </td>
        </tr>
        
        
    </table>
        <%--<label for="pwd">Please enter a password</label>
       <input type="password" id="password" name="pwd" />
        <div id="meter"></div>
    <div class="entropizer-bar"></div>
    <div class="entropizer-text" ></div>
    <div class="entropizer-track" ></div>--%>
</asp:Content>
