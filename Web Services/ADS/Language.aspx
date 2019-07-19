<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Language.aspx.cs" Inherits="Ads_Portal.Language1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="Languages">
</asp:LinqDataSource>
<dx:BootstrapGridView ID="BootstrapGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" KeyFieldName="Id">
    <SettingsEditing Mode="PopupEditForm">
        <FormLayoutProperties>
            <SettingsItemCaptions HorizontalAlign="Left" />
        </FormLayoutProperties>
    </SettingsEditing>
    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
    <Columns>
        <dx:BootstrapGridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
        </dx:BootstrapGridViewCommandColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Id" ReadOnly="True" VisibleIndex="1" Visible="False">
            <SettingsEditForm Visible="False" />
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Language_Code" VisibleIndex="2" Caption="Code">
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Language_Name" VisibleIndex="3" Caption="Name">
        </dx:BootstrapGridViewTextColumn>
    </Columns>
</dx:BootstrapGridView>
</asp:Content>
