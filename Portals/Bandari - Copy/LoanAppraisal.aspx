<%@ Page Title="One Month Loan Appraisal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoanAppraisal.aspx.cs" Inherits="Bandari_Sacco.LoanAppraisal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-info">
        <div class="panel-heading"><i class="fa fa-calculator"></i>One Month Loan Appraisal</div>
        <div class="panel-body">
            <table class="table table-responsive table-condensed table-bordered">
                <tr>
                    <td><asp:Label ID="lblSalary" runat="server" Text ="Computed Salary (Last 3 Months)"></asp:Label></td>
                    <td><asp:TextBox ID="txtSalary" runat="server" Enabled="false" Width="200px"></asp:TextBox></td>
                </tr>
                
                <tr>
                    <td><asp:Label ID="lblDeduction" runat="server" Text ="Total Deductions"></asp:Label></td>
                    <td><asp:TextBox ID="txtDeduction" runat="server" Enabled="false" Width="200px"></asp:TextBox></td>
                </tr>
                
               
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblQualifyingAmount" runat="server" Text="Amount Qualified"></asp:Label></td>
                    <td><asp:TextBox ID="txtQualifyingAmount" runat="server" Enabled="false" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
                <tr><td><asp:Button ID="Button1" runat="server" Text="Calculate" OnClick="Button1_Click" CssClass="btn btn-info"/></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
