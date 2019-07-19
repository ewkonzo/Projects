<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="mobilesmstopupitem.aspx.cs" Inherits="HIMS.mobilesmstopupitem" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Home_Master" runat="server">
    <div style="text-align: left; width: 100%;">
        <br />
        <table style="width: 100%">
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:FormView ID="fvMap" runat="server" DataKeyNames="ID,Sacco"
                        OnItemDeleting="fvMap_ItemDeleting" OnItemUpdating="fvMap_ItemUpdating" OnModeChanging="fvMap_ModeChanging"
                        OnPageIndexChanging="fvMap_PageIndexChanging" OnItemCommand="fvMap_ItemCommand"
                        OnItemInserting="fvMap_ItemInserting" OnDataBound="fvMap_DataBound" Width="259px">
                        <ItemTemplate>
                            <table class="entryform">
                                <tr>
                                    <td class="flabel">
                                        Sacco Code :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSacco" runat="server" Text='<%# Bind("[Sacco]") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="flabel">
                                        Sacco Name :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSaccoName" runat="server" Text='<%# Bind("[SaccoName]") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="flabel">
                                        Date :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDate" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy HH:mm:ss}",DataBinder.Eval(Container.DataItem,"[Datetime]")) %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="flabel">
                                        SMS Count :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSmsCount" runat="server" Text='<%# Bind("[SmsCount]") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="flabel">
                                        Comments :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblComments" runat="server" Text='<%# Bind("[Comments]") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="flabel">
                                        User ID :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblUserID" runat="server" Text='<%# Bind("[UserID]") %>' />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <asp:LinkButton ID="byn_add" runat="server" CommandName="new">Add</asp:LinkButton>
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="btn_edit" runat="server" CommandName="edit">Edit</asp:LinkButton>
                            &nbsp;&nbsp;
                            <asp:LinkButton ID="btn_delete" runat="server" CommandName="delete">Delete</asp:LinkButton>
                            <br />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <table class="entryform">
                                <tr>
                                    <td class="flabel">
                                        Sacco
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEditSacco" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="flabel">
                                        Date :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEditDate" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy HH:mm:ss}",DataBinder.Eval(Container.DataItem,"[Datetime]")) %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="flabel">
                                        SMS Count :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEditSmsCount" runat="server" Text='<%# Bind("[SmsCount]") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="flabel">
                                        Comments :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtEditComments" runat="server" Text='<%# Bind("[Comments]") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="flabel">
                                        User ID :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEditUserID" runat="server" Text='<%# Bind("[UserID]") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btn_update" runat="server" CommandName="update">
                                            <asp:Image ID="Image2" runat="server" ImageUrl="../App_Images/save-32.png" ToolTip="Save" /></asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton ID="btn_cancel" runat="server" CommandName="cancelupdate">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="../App_Images/cancel-32.png" ToolTip="Cancel" /></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <br />
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <table class="entryform">
                                <tr>
                                    <td class="flabel">
                                        Sacco :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlInsertSacco" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="flabel">
                                        SMS Count :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInsertSmsCount" runat="server" Text='<%# Bind("[SmsCount]") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="flabel">
                                        Comments :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtInsertComments" runat="server" Text='<%# Bind("[Comments]") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btn_update" runat="server" CommandName="Insert">
                                            <asp:Image ID="imgSave" runat="server" ImageUrl="../App_Images/save-32.png" ToolTip="Save" /></asp:LinkButton>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton ID="btn_cancelinsert" runat="server" CommandName="CancelInsert">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="../App_Images/cancel-32.png" ToolTip="Cancel" /></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </InsertItemTemplate>
                    </asp:FormView>
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblErrorCaption" runat="server" Text="" ForeColor="Red" />
        <br />
    </div>
</asp:Content>
