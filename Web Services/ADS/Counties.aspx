<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Counties.aspx.cs" Inherits="Ads_Portal.Counties" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="Counties">
</asp:LinqDataSource>
<dx:BootstrapGridView ID="BootstrapGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" KeyFieldName="Id">
    <Settings ShowFilterRow="True" />
    <SettingsEditing Mode="PopupEditForm">
    </SettingsEditing>
    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
    <Columns>
        <dx:BootstrapGridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
        </dx:BootstrapGridViewCommandColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Id" ReadOnly="True" Visible="False" VisibleIndex="1">
            <SettingsEditForm Visible="False" />
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewTextColumn Caption="County" FieldName="County1" VisibleIndex="2">
        </dx:BootstrapGridViewTextColumn>
    </Columns>
</dx:BootstrapGridView>
</asp:Content>
