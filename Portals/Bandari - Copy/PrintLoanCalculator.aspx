﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrintLoanCalculator.aspx.cs" Inherits="Bandari_Sacco.PrintLoansCalculator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <iframe runat="server" id="pdfLoans" src="" 
        style="border: silver thin ridge;width:100%; height: 450px;"></iframe>

</asp:Content>
