<%@ Page Title="Total Loans View" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoanView.aspx.cs" Inherits="Bandari_Sacco.LoanView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="panel panel-info">
            <div class="panel-body">
                <table class="table table-condensed table-responsive">
                    <thead>
                        <tr>
                             <th class="small">#</th>
                            <th class="small">Loan Number</th>
                            <th class="small">Oustanding Balance</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%=TotalLoans()%>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
