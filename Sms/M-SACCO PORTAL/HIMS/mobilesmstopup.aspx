<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true"
    CodeBehind="mobilesmstopup.aspx.cs" Inherits="HIMS.mobilesmstopup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Home_Master" runat="server">

    <div style="text-align: left; width: 100%;">
        <%--<br />
        <br />
        <br />--%>
        <table style="width: 100%" class="displaytable">
            <tr>
                <td colspan="3">
                    
        <asp:LinkButton ID="btnNewMap" runat="server" Height="30px" OnClick="btnNewMap_Click"
            Width="120px"><asp:Image ID="Image1" runat="server" ImageUrl="../App_Images/add-32.png" ToolTip="Add" /></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvTopup" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        AllowSorting="True" CellPadding="2" CellSpacing="1" Width="100%" ForeColor="#333333"
                        GridLines="None" EmptyDataText="No Records." DataKeyNames="ID,Sacco"
                        OnPageIndexChanging="gvTopup_PageIndexChanging" OnSelectedIndexChanged="gvTopup_SelectedIndexChanged"
                        OnSorting="gvTopup_Sorting" OnRowDeleting="gvTopup_RowDeleting" EnableModelValidation="True"
                        OnRowCommand="gvTopup_RowCommand" OnRowDataBound="gvTopup_RowDataBound" ShowFooter="False"
                        PageSize="20" ShowHeader="true" Font-Size="x-small" BackColor="#E6D9BD" OnDataBound="gvTopup_DataBound">
                        <AlternatingRowStyle BackColor="#FFFFE1" />
                        <Columns>
                            <asp:CommandField SelectText="Select" ShowSelectButton="True">
                                <ItemStyle ForeColor="Green" Font-Bold="True" Width="40px" />
                            </asp:CommandField>
                                               
                            <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Center" SortExpression="Datetime">
                                <ItemStyle Width="110px" HorizontalAlign="Center"  />
                                <ItemTemplate>
                                    <asp:Label ID="lblDatetime" runat="server" Text='<%# string.Format("{0:dd-MMM-yyyy HH:mm:ss}",DataBinder.Eval(Container.DataItem,"[Datetime]")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                                    
                            <asp:TemplateField HeaderText="Corporate #" HeaderStyle-HorizontalAlign="Center" SortExpression="Sacco">
                                <ItemStyle Width="65px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSacco" runat="server" Text='<%# Bind("[Sacco]") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                                                       
                            <asp:TemplateField HeaderText="Sacco" SortExpression="Sacco">
                                <ItemStyle/>
                                <ItemTemplate>
                                    <asp:Label ID="lblSaccoName" runat="server" Text='<%# Bind("[SaccoName]") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SmsCount" HeaderStyle-HorizontalAlign="Right" SortExpression="SmsCount">
                                <ItemStyle Width="70px" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSmsCount" runat="server" Text='<%# Bind("[SmsCount]") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Comments" SortExpression="Comments">
                                <ItemStyle />
                                <ItemTemplate>
                                    <asp:Label ID="lblComments" runat="server" Text='<%# Bind("[Comments]") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="User ID" SortExpression="UserID">
                                <ItemStyle />
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%# Bind("[UserID]") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <PagerTemplate>
                            <table id="pagerOuterTable" class="pagerOuterTable" runat="server">
                                <tr>
                                    <td>
                                        <table id="pagerInnerTable" cellpadding="2" cellspacing="1" runat="server">
                                            <tr>
                                                <td class="pageCounter">
                                                    <asp:Label ID="lblPageCounter" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td class="pageFirstLast">
                                                    <img src="../App_Images/firstpage.gif" align="absmiddle" />&nbsp;<asp:LinkButton ID="lnkFirstPage"
                                                        CssClass="pagerLink" runat="server" CommandName="Page" CommandArgument="First">First</asp:LinkButton>
                                                </td>
                                                <td class="pagePrevNextNumber">
                                                    <asp:ImageButton ID="imgPrevPage" runat="server" ImageAlign="AbsMiddle" ImageUrl="../App_Images/prevpage.gif"
                                                        CommandName="Page" CommandArgument="Prev" />
                                                </td>
                                                <td class="pagePrevNextNumber">
                                                    <asp:ImageButton ID="imgNextPage" runat="server" ImageAlign="AbsMiddle" ImageUrl="../App_Images/nextpage.gif"
                                                        CommandName="Page" CommandArgument="Next" />
                                                </td>
                                                <td class="pageFirstLast">
                                                    <asp:LinkButton ID="lnkLastPage" CssClass="pagerLink" CommandName="Page" CommandArgument="Last"
                                                        runat="server">Last</asp:LinkButton>&nbsp;<img src="../App_Images/lastpage.gif" align="absmiddle" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td visible="false" class="pageGroups">
                                        Pages:&nbsp;<asp:DropDownList ID="ddlPageGroups" runat="server" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlPageGroups_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </PagerTemplate>
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#2461BF" />
                        <EmptyDataRowStyle ForeColor="Red" />
                        <FooterStyle BackColor="#D6C094" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#D6C094" Font-Bold="True" ForeColor="White" />
                        <%--<PagerStyle BackColor="#D6C094" ForeColor="White" HorizontalAlign="Center" />--%>
                        <RowStyle BorderColor="#D6C094" />
                        <SelectedRowStyle BackColor="#c5c48d" Font-Bold="True" ForeColor="#333333" BorderColor="Red" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Label ID="lblErrorCaption" runat="server" Text="" ForeColor="Red" />
        <br />
        <br />
        <br />
    </div>
    
</asp:Content>
<asp:Content ID="Content_Sidebar" ContentPlaceHolderID="SideBar_Master" runat="server">

</asp:Content>