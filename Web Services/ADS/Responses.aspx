<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Responses.aspx.cs" Inherits="Ads_Portal.Responses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    
    <script>
        function selectionChanged(s, e) {
            dropDownlanguage.SetValue(LanguageGridView.GetSelectedKeysOnPage()[0]);
            dropDownlanguage.HideDropDown();
        }
    </script>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="Responses" OnInserting="LinqDataSource1_Inserting">
</asp:LinqDataSource>
    <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EntityTypeName="" TableName="Languages">
    </asp:LinqDataSource>
    <dx:BootstrapButton runat="server" Text="XLS" ID="ButtonXLS1" OnClick="ButtonXLS1_Click">
    <CssClasses Icon="fa fa-file-excel-o" />
</dx:BootstrapButton>
<dx:BootstrapButton runat="server" Text="XLSX" ID="ButtonXLSX1" OnClick="ButtonXLSX1_Click">
    <CssClasses Icon="fa fa-file-excel-o" />
</dx:BootstrapButton>
<dx:BootstrapGridView ID="BootstrapGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" KeyFieldName="Code">
    <SettingsEditing Mode="PopupEditForm">
    </SettingsEditing>
    <SettingsDataSecurity AllowDelete="True" AllowEdit="True" AllowInsert="True" />
    <Columns>
        <dx:BootstrapGridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
        </dx:BootstrapGridViewCommandColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Id" Visible="False" VisibleIndex="1">
            <SettingsEditForm Visible="False" />
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Code" VisibleIndex="2">
        </dx:BootstrapGridViewTextColumn>
        <dx:BootstrapGridViewDateColumn FieldName="Date" VisibleIndex="5" Visible="False">
        </dx:BootstrapGridViewDateColumn>
        <dx:BootstrapGridViewTextColumn FieldName="Created_By" VisibleIndex="6" Visible="False">
        </dx:BootstrapGridViewTextColumn>
                
            <dx:BootstrapGridViewDropDownEditColumn FieldName="Language_code" Caption="Language" VisibleIndex="3">
                 <PropertiesDropDownEdit ClientInstanceName="dropDownlanguage">
                <DropDownWindowTemplate>
                    <dx:BootstrapGridView runat="server" ClientInstanceName="LanguageGridView"
                        DataSourceID="LinqDataSource2" KeyFieldName="Language_Code">
                        <ClientSideEvents SelectionChanged="selectionChanged" />
                        <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
                        <Columns>
                            <dx:BootstrapGridViewDataColumn FieldName="Language_Code" Caption="Code" />
                            <dx:BootstrapGridViewDataColumn FieldName="Language_Name" Caption="Name"/>
                           
                        </Columns>
                    </dx:BootstrapGridView>
                </DropDownWindowTemplate>
            </PropertiesDropDownEdit>
            </dx:BootstrapGridViewDropDownEditColumn>
        <dx:BootstrapGridViewMemoColumn Caption="Reply Message" FieldName="Reply" VisibleIndex="4">
            <PropertiesMemoEdit Columns="12" Rows="5">
            </PropertiesMemoEdit>
            <SettingsEditForm ColumnSpan="12" />
        </dx:BootstrapGridViewMemoColumn>
    </Columns>
    <SettingsSearchPanel Visible="True" />
</dx:BootstrapGridView>
</asp:Content>
