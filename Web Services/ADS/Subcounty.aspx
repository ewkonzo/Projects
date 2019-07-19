<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Subcounty.aspx.cs" Inherits="Ads_Portal.Subcounty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script> function selectionChangedcounty(s, e) {
            dropDowncounty.SetValue(countyGridView.GetSelectedKeysOnPage()[0]);
            dropDowncounty.HideDropDown();
        }</script>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="SubCounties">
    </asp:LinqDataSource>
    <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EntityTypeName="" TableName="Counties">
    </asp:LinqDataSource>
    <dx:BootstrapGridView ID="BootstrapGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" KeyFieldName="Id">
        <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
        <Columns>
            <dx:BootstrapGridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:BootstrapGridViewCommandColumn>
            <dx:BootstrapGridViewTextColumn FieldName="Id" ReadOnly="True" Visible="False" VisibleIndex="1">
                <SettingsEditForm Visible="False" />
            </dx:BootstrapGridViewTextColumn>
            <dx:BootstrapGridViewTextColumn Caption="Sub County" FieldName="subcounties" VisibleIndex="2">
            </dx:BootstrapGridViewTextColumn>
            <dx:BootstrapGridViewDropDownEditColumn FieldName="County" VisibleIndex="4" Caption="County">
                 <PropertiesDropDownEdit ClientInstanceName="dropDowncounty">
                <DropDownWindowTemplate>
                    <dx:BootstrapGridView runat="server" ClientInstanceName="countyGridView"
                        DataSourceID="LinqDataSource2" KeyFieldName="County">
                        <ClientSideEvents SelectionChanged="selectionChangedcounty" />
                        <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
                        <Columns>
                            <dx:BootstrapGridViewDataColumn FieldName="Language_Code" Caption="County" />
                           
                        </Columns>
                    </dx:BootstrapGridView>
                </DropDownWindowTemplate>
            </PropertiesDropDownEdit>
            </dx:BootstrapGridViewDropDownEditColumn>
        </Columns>
    </dx:BootstrapGridView>
</asp:Content>
