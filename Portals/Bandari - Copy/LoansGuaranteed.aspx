<%@ Page Title="Members I Have Guaranteed" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoansGuaranteed.aspx.cs" Inherits="Bandari_Sacco.LoansGuaranteed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
            <div class="col-md-6">
                <div class=" form-group">
                    <asp:Label ID="lblError" runat="server" CssClass="label label-danger"></asp:Label></div>
            </div>

        </div>
    <iframe runat="server" id="pdfLoans" src=""
        style="border: silver thin ridge; width: 100%; height: 450px;"></iframe>
     
</asp:Content>
