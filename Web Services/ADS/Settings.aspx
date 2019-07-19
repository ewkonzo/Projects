<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="Ads_Portal.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script>function selectionChangedlanguage(s, e) {
            dropDownlanguage.SetValue(LanguageGridView.GetSelectedKeysOnPage()[0]);
            dropDownlanguage.HideDropDown();
        }</script>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EnableUpdate="True" EntityTypeName="" TableName="Settings">
    </asp:LinqDataSource>
    <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EntityTypeName="" TableName="Languages">
    </asp:LinqDataSource>
    <dx:BootstrapGridView ID="BootstrapGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" KeyFieldName="Id">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <SettingsDataSecurity AllowEdit="True" />
        <Columns>
            <dx:BootstrapGridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
            </dx:BootstrapGridViewCommandColumn>
            <dx:BootstrapGridViewTextColumn FieldName="Id" ReadOnly="True" Visible="False" VisibleIndex="1">
                <SettingsEditForm Visible="False" />
            </dx:BootstrapGridViewTextColumn>
            <dx:BootstrapGridViewDropDownEditColumn FieldName="Default_Language" VisibleIndex="2" Caption="Language">
                 <PropertiesDropDownEdit ClientInstanceName="dropDownlanguage">
                <DropDownWindowTemplate>
                    <dx:BootstrapGridView runat="server" ClientInstanceName="LanguageGridView"
                        DataSourceID="LinqDataSource2" KeyFieldName="Language_Code">
                        <ClientSideEvents SelectionChanged="selectionChangedlanguage" />
                        <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
                        <Columns>
                            <dx:BootstrapGridViewDataColumn FieldName="Language_Code" Caption="Code" />
                            <dx:BootstrapGridViewDataColumn FieldName="Language_Name" Caption="Name" />
                           
                        </Columns>
                    </dx:BootstrapGridView>
                </DropDownWindowTemplate>
            </PropertiesDropDownEdit>
                 <SettingsEditForm ColumnSpan="12" />
            </dx:BootstrapGridViewDropDownEditColumn>
            <dx:BootstrapGridViewMemoColumn FieldName="AutoResponse" VisibleIndex="3">
                <PropertiesMemoEdit Columns="12" Rows="5">
                </PropertiesMemoEdit>
                <SettingsEditForm ColumnSpan="12" />
            </dx:BootstrapGridViewMemoColumn>
            <dx:BootstrapGridViewTextColumn Caption="No Response alerts No" FieldName="No_Response_Alerts" VisibleIndex="4">
            </dx:BootstrapGridViewTextColumn>
            <dx:BootstrapGridViewMemoColumn Caption="Alert Message" FieldName="alert_message" VisibleIndex="5">
                <PropertiesMemoEdit Columns="12" Rows="5">
                </PropertiesMemoEdit>
            </dx:BootstrapGridViewMemoColumn>
        </Columns>
    </dx:BootstrapGridView>
</asp:Content>
