<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Queries.aspx.cs" Inherits="Ads_Portal.Queries" MasterPageFile="~/Site.master"%>

<asp:Content ContentPlaceHolderID="Content" runat="server">


    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EntityTypeName="" TableName="Incomings">
    </asp:LinqDataSource>


<dx:BootstrapGridView ID="BootstrapGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" KeyFieldName="ID">
    <Settings ShowFilterRow="True" ShowFooter="True" ShowGroupPanel="True" />
    <Columns>
        <dx:BootstrapGridViewTextColumn FieldName="ID" ReadOnly="True" Visible="False" VisibleIndex="0">
            <SettingsEditForm Visible="False" />
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Source" VisibleIndex="5" Visible="False">
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Message" VisibleIndex="3">
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewDateColumn FieldName="Datetime" VisibleIndex="1">
        </dx:BootstrapGridViewDateColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Sender" VisibleIndex="2">
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Link_Id" Visible="False" VisibleIndex="6">
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Correlator" Visible="False" VisibleIndex="7">
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewTextColumn FieldName="To" Visible="False" VisibleIndex="8">
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Reply" VisibleIndex="4">
        </dx:BootstrapGridViewTextColumn>
    </Columns>
    <SettingsSearchPanel Visible="True" />
</dx:BootstrapGridView>


</asp:Content>
