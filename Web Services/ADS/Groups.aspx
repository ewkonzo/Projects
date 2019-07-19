<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="Ads_Portal.Groups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="groups">
</asp:LinqDataSource>
<dx:BootstrapGridView ID="BootstrapGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" KeyFieldName="id">
    <SettingsEditing Mode="PopupEditForm">
    </SettingsEditing>
    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
    <Columns>
        <dx:BootstrapGridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
        </dx:BootstrapGridViewCommandColumn>
        <dx:BootstrapGridViewTextColumn FieldName="timestamp" VisibleIndex="1" Visible="False">
            <SettingsEditForm Visible="False" />
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewTextColumn FieldName="id" ReadOnly="True" VisibleIndex="2" Visible="False">
            <SettingsEditForm Visible="False" />
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Name" VisibleIndex="3">
        </dx:BootstrapGridViewTextColumn>
    </Columns>
</dx:BootstrapGridView>
</asp:Content>
