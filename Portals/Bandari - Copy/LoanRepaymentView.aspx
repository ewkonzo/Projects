﻿<%@ Page Title="Total Repayment Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoanRepaymentView.aspx.cs" Inherits="Bandari_Sacco.LoanRepaymentView" %>
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
                            <th class="small">Account Balance</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%=TotalRepayment()%>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
