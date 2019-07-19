<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="Ads_Portal.Contacts" MasterPageFile="~/Site.master" %>

<asp:Content ContentPlaceHolderID="Content" runat="server">
    <script>
    function onFilesUploadStart(s, e) {
        dxbsDemo.uploadedFilesContainer.hide();
    }
    function onFileUploadComplete(s, e) {
        if (e.callbackData) {
            var fileData = e.callbackData.split('|');
            var fileName = fileData[0],
                fileUrl = fileData[1],
                fileSize = fileData[2];
            dxbsDemo.uploadedFilesContainer.addFile(s, fileName, fileUrl, fileSize);
        }
        }
        function selectionChanged(s, e) {
            dropDownEdit.SetValue(employeesGridView.GetSelectedKeysOnPage()[0]);
            dropDownEdit.HideDropDown();
        }
        function selectionChangedlanguage(s, e) {
            dropDownlanguage.SetValue(LanguageGridView.GetSelectedKeysOnPage()[0]);
            dropDownlanguage.HideDropDown();
        }
</script>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="contacts" OnInserting="LinqDataSource1_Inserting" OrderBy="id desc">
 </asp:LinqDataSource>
<dx:BootstrapPopupControl ID="uploadf" ClientInstanceName="uploadf" runat="server" ShowOnPageLoad="false" PopupElementCssSelector="#default-popup-control-1"
    PopupHorizontalAlign="Center" PopupVerticalAlign="Middle" Width="500px" CloseAction="CloseButton" ShowFooter="True" ShowHeader="true" ShowCloseButton="False"
    HeaderText="Upload Contacts" FooterText="Footer text" Modal="true">
         <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter"
        FixedHeader="true" FixedFooter="true" />
         <ContentCollection>
        <dx:ContentControl>
            <small>Allowed file extensions: .xls,.xlsx</small>
<br />
            <dx:BootstrapUploadControl runat="server" 
                ShowUploadButton="true" ClientInstanceName="uploadcc"
                ID="uploadc" 
                OnFileUploadComplete="uploadc_FileUploadComplete1" NullText="Nothing to upload" ShowProgressPanel="True" UploadMode="Advanced" UploadStorage="FileSystem" > 
                 <ClientSideEvents FileUploadComplete="onFileUploadComplete" FilesUploadStart="onFilesUploadStart" />
    <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".xls,.xlsx" />
                 <FileSystemSettings UploadFolder="Files" />
            </dx:BootstrapUploadControl>
            
            <footer>
                  <dx:BootstrapButton runat="server"  Text="OK" AutoPostBack="false" UseSubmitBehavior="false">
            <ClientSideEvents Click="function(s, e) { uploadf.Hide(); }" />
        </dx:BootstrapButton>
            </footer>
        </dx:ContentControl>
             
    </ContentCollection>
    </dx:BootstrapPopupControl>
    <dx:BootstrapButton ID="Upload" Text="Upload Contacts" runat="server">
        <ClientSideEvents Click="function(s, e) {
            uploadf.Show();
}" />
    </dx:BootstrapButton>
    
    <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EntityTypeName="" TableName="groups">
    </asp:LinqDataSource>
    
    <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="Ads_Portal.DataDataContext" EntityTypeName="" TableName="Languages">
    </asp:LinqDataSource>
        <dx:BootstrapButton runat="server" Text="XLS" ID="ButtonXLS1" OnClick="ButtonXLS1_Click">
    <CssClasses Icon="fa fa-file-excel-o" />
</dx:BootstrapButton>
<dx:BootstrapButton runat="server" Text="XLSX" ID="ButtonXLSX1" OnClick="ButtonXLSX1_Click">
    <CssClasses Icon="fa fa-file-excel-o" />
</dx:BootstrapButton>
    <dx:BootstrapGridView ID="contacts" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1" KeyFieldName="id">
        <Settings ShowFilterRow="True" ShowGroupPanel="True" />
        <SettingsBehavior ConfirmDelete="True" />
        <SettingsEditing Mode="PopupEditForm">
            <BatchEditSettings StartEditAction="DblClick" />
        </SettingsEditing>
        <SettingsPopup>
            <EditForm AllowResize="True">
            </EditForm>
        </SettingsPopup>
        <SettingsDataSecurity AllowEdit="True" AllowInsert="True" />
        <Columns>
            <dx:BootstrapGridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:BootstrapGridViewCommandColumn>
            <dx:BootstrapGridViewTextColumn FieldName="id" VisibleIndex="1" ReadOnly="True">
                <SettingsEditForm Visible="False" />
            </dx:BootstrapGridViewTextColumn>
            <dx:BootstrapGridViewTextColumn FieldName="name" VisibleIndex="2">
            </dx:BootstrapGridViewTextColumn>
            <dx:BootstrapGridViewTextColumn FieldName="contact1" VisibleIndex="3" Caption="Phone">
            </dx:BootstrapGridViewTextColumn>
            <dx:BootstrapGridViewTextColumn FieldName="client" VisibleIndex="5" Visible="False">
            </dx:BootstrapGridViewTextColumn>
            <dx:BootstrapGridViewTextColumn FieldName="Email" VisibleIndex="6">
            </dx:BootstrapGridViewTextColumn>
            <dx:BootstrapGridViewTextColumn FieldName="County" VisibleIndex="7">
            </dx:BootstrapGridViewTextColumn>
            <dx:BootstrapGridViewTextColumn FieldName="Gender" VisibleIndex="8">
            </dx:BootstrapGridViewTextColumn>
            <dx:BootstrapGridViewTextColumn FieldName="Age" VisibleIndex="9">
            </dx:BootstrapGridViewTextColumn>
            <dx:BootstrapGridViewDropDownEditColumn FieldName="Language" VisibleIndex="4" Caption="Language">
                 <PropertiesDropDownEdit ClientInstanceName="dropDownlanguage">
                <DropDownWindowTemplate>
                    <dx:BootstrapGridView runat="server" ClientInstanceName="LanguageGridView"
                        DataSourceID="LinqDataSource3" KeyFieldName="Language_Code">
                        <ClientSideEvents SelectionChanged="selectionChangedlanguage" />
                        <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
                        <Columns>
                            <dx:BootstrapGridViewDataColumn FieldName="Language_Code" Caption="Code" />
                            <dx:BootstrapGridViewDataColumn FieldName="Language_Name" Caption="Name" />
                           
                        </Columns>
                    </dx:BootstrapGridView>
                </DropDownWindowTemplate>
            </PropertiesDropDownEdit>
            </dx:BootstrapGridViewDropDownEditColumn>
            <dx:BootstrapGridViewDropDownEditColumn FieldName="Group" VisibleIndex="10">
                <PropertiesDropDownEdit ClientInstanceName="dropDownEdit">
                    <DropDownWindowTemplate>
                        <dx:BootstrapGridView runat="server" ClientInstanceName="employeesGridView" DataSourceID="LinqDataSource2" KeyFieldName="id">
                            <ClientSideEvents SelectionChanged="selectionChanged" />
                            <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
                            <Columns>
                                <dx:BootstrapGridViewDataColumn FieldName="id" />
                                <dx:BootstrapGridViewDataColumn FieldName="Name" />
                            </Columns>
                        </dx:BootstrapGridView>
                    </DropDownWindowTemplate>
                </PropertiesDropDownEdit>
            </dx:BootstrapGridViewDropDownEditColumn>
            
        </Columns>
        <SettingsSearchPanel Visible="True" />
        <SettingsExport EnableClientSideExportAPI="True" ExcelExportMode="WYSIWYG">
        </SettingsExport>
    </dx:BootstrapGridView>
    </asp:Content>


