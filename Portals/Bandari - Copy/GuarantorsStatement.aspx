<%@ Page Title="Guarantor Statement" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GuarantorsStatement.aspx.cs" Inherits="Bandari_Sacco.GuarantorsStatement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div>
        <div class="row">
            <div class="col-md-6">
                <div class=" form-group">
                    <asp:Label ID="Label1" runat="server" CssClass="label label-warning">Select the account for which you want to view the statement</asp:Label>

                </div>

            </div>

        </div>
        <div class="row">
            <div class="col-md-6">

                <div class=" form-group">
                    <asp:DropDownList ID="ddlAccount" runat="server" Width="200px" Height="20px"></asp:DropDownList></div>
            </div>


        </div>

        <div class="row">
            <div class="col-md-6">
                <div class=" form-group">
                    <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" CssClass="btn btn-info btn-large" /></div>
            </div>

        </div>
        <div class="row">
            <div class="col-md-6">
                <div class=" form-group">
                    <asp:Label ID="lblError" runat="server" CssClass="label label-danger"></asp:Label></div>
            </div>

        </div>

    </div>
    <iframe runat="server" id="pdfLoans" src=""
        style="border: silver thin ridge; width: 100%; height: 450px;"></iframe>
</asp:Content>

