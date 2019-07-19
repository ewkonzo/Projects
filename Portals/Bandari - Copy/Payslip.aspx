<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payslip.aspx.cs" Inherits="Bandari_Sacco.Payslip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <span style="font-size: 12pt; color: Black; font-family: Palatino Linotype">
    Please, select the period to view the payslip for that period</span><br />
    <table id="table1" class="table table-condensed table-responsive table-bordered">
        <tr><td>
            <asp:Label ID="Label1" runat="server" Text="Year:"></asp:Label>
            </td>
            <td colspan="3">
                <asp:DropDownList ID="ddlYear" runat="server" Width="233px">
                </asp:DropDownList>&nbsp;
            </td>
            <td>
            <asp:Label ID="Label2" runat="server" Text="Month:"></asp:Label>
            </td>
            <td colspan="3">
                <asp:DropDownList ID="DdMonth" runat="server" Width="233px">  
                    
                </asp:DropDownList>&nbsp;
            </td>            
        </tr>
        <tr>
        <td colspan="8" align="center">
                <asp:Button ID="btnViewPayslip" runat="server" Text="View Payslip" 
                    Width="188px" CssClass="btn btn-info" onclick="btnViewPayslip_Click"  />
            </td>
        </tr>
    </table>

    <iframe runat="server" id="myPDF" src="" width="100%" 
        height="500"/>
</asp:Content>
