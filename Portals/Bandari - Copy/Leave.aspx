<%@ Page Title="Leave" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leave.aspx.cs" Inherits="Bandari_Sacco.Leave" %>
<%--<%@ Register TagPrefix="anthem" Namespace="System.Threading" Assembly="mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" %>--%>
<%@ Register Assembly="Anthem" Namespace="Anthem" TagPrefix="anthem" %>
<%@ Register Assembly="SlimeeLibrary" Namespace="SlimeeLibrary" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">
    
    
    
   
   
   
  

    <div class="panel panel-success">
   
            <table class="table table-condensed table-responsive table-bordered">
                 <tr>
                    <td>
                      
                         <asp:Button ID="lbNew" runat="server" Text="New Application" CssClass="btn btn-info" OnClick="lbNew_Click"/>
                    </td>
                    
                    <td>
                         
                         <asp:Button ID="LinkButton2" runat="server" Text="Pending Applications" CssClass="btn btn-info"  OnClick="lbPending_Click" />
                    </td>
                    
                     <td>
                           <asp:Button ID="LinkButton3" runat="server" Text="Approved Applications" CssClass="btn btn-info"  OnClick="lbApproved_Click" />
                    </td>
                      <td>
                           <asp:Button ID="LinkButton4" runat="server" Text="Rejected Applications" CssClass="btn btn-info"  OnClick="lbRejected_Click" />
                    </td>
                     <td>
                           <asp:Button ID="LinkButton5" runat="server" Text="Approve Applications" CssClass="btn btn-info"  OnClick="lbApprove2_Click" />
                    </td>
                </tr>
            </table>
        </div>

    <br />
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="View1" runat="server">
            <table class="table table-condensed table-responsive table-bordered">
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="New Leave Application"></asp:Label>  
                        <%--<asp:Label ID="lblInvalid" runat="server" Text="Label"></asp:Label>--%>
                    </td>
                    <td colspan="4">
                        <asp:Label ID="lblInfo" runat="server" Width="100%"></asp:Label>                   
                    </td>
                </tr>
                <tr>
                    <td id="testing1">
                        <asp:Label ID="Label3" runat="server" Text="Employee No:" Width="91px"></asp:Label>
                    </td>
                    <td id="testing2">
                        <asp:Label ID="lblNo" runat="server" Width="180px"></asp:Label>
                    </td>
                    <td id="testing3">
                        <asp:Label ID="Label1" runat="server" Width="16px"></asp:Label>
                    </td>
                    <td id="testing4">
                        <asp:Label ID="Label8" runat="server" Text="Employee Names:" Width="165px"></asp:Label>
                    </td>
                    <td id="testing5">
                        <asp:Label ID="lblNames" runat="server" Width="250px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td id="testing6">
                        Application Code:
                    </td>
                    <td id="testing7">
                        <asp:Label ID="lblApplicationCode" runat="server" Width="100%"></asp:Label>
                    </td>
                    <td id="testing8">
                    </td>
                    <td id="testing9">
                        Leave Type:
                    </td>
                    <td id="testing11">
                        <asp:DropDownList ID="ddlLeaveTypes" runat="server" Width="100%" AutoPostBack="True"
                            OnTextChanged="ddlLeaveTypes_TextChanged" OnSelectedIndexChanged="ddlLeaveTypes_SelectedIndexChanged1">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td id="Td1">
                        Require Leave Allowance?
                    </td>
                    <td id="Td2">
                        <span>
                            <asp:CheckBox ID="cbLeaveAllowance" runat="server" />
                        </span>
                    </td>
                    <td id="Td20">
                    </td>
                    <td id="Td18">
                        Days Applied:
                    </td>
                    <td id="Td19">
                        <asp:DropDownList ID="ddlDaysApplied" runat="server" Width="73px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td id="Td4">
                        Comments:
                    </td>
                    <td id="Td5">
                        <asp:TextBox ID="txtComments" runat="server" Height="50px" TextMode="MultiLine" Width="98%">Kindly Approve</asp:TextBox>
                    </td>
                    <td id="Td3">
                    </td>
                    <td id="Td23">
                        Start Date:
                    </td>
                    <td id="Td24">
                        <cc1:DatePicker ID="calStartDate" runat="server" AutoPostBack="true" OnSelectedDateChanged="calStartDate_SelectionChanged"
                            PaneWidth="150px" Width="100px">
                            <PaneTableStyle BorderColor="#707070" BorderStyle="Solid" BorderWidth="1px" />
                            <PaneHeaderStyle BackColor="#0099FF" />
                            <TitleStyle Font-Bold="true" ForeColor="White" />
                            <NextPrevMonthStyle Font-Bold="true" ForeColor="White" />
                            <NextPrevYearStyle Font-Bold="true" ForeColor="#E0E0E0" />
                            <DayHeaderStyle BackColor="#E8E8E8" />
                            <TodayStyle BackColor="#FFFFCC" BorderColor="#FFCC99" Font-Underline="false" ForeColor="#000000" />
                            <AlternateMonthStyle BackColor="#F0F0F0" Font-Underline="false" ForeColor="#707070" />
                            <MonthStyle BackColor="" Font-Underline="false" ForeColor="#000000" />
                        </cc1:DatePicker>
                        <span style="color: blue">Return Date:</span>
                        <br />
                        <anthem:Timer ID="Timer1" runat="server" Enabled="True" Interval="500" OnTick="Timer1_Tick">
                            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </anthem:Timer>
                        <anthem:Panel ID="Panel1" runat="server">
                            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblReturnDate" runat="server" ForeColor="Red" Width="100%"></asp:Label></anthem:Panel>
                    </td>
                </tr>
                <tr>
                    <td id="Td6" >
                        <%--Approver:--%>
                        Responsibility Center:
                    </td>
                    <td id="Td7">
                        <b>
                            <asp:DropDownList ID="ddlAppraisers" runat="server" Width="100%" Visible="false">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlresponibilitycentres" runat="server" Width="250px">
                            </asp:DropDownList>
                        </b>
                    </td>
                    <td id="Td8">
                    </td>
                    <td id="Td9">
                        <%--Reliever:--%>
                    </td>
                    <td id="Td10">
                        <asp:DropDownList ID="ddlReliever" runat="server" Visible="false" AutoPostBack="True"
                            Width="100%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <b>Add relievers if necessary: </b>
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        <asp:GridView ID="Gridview1" runat="server" ShowFooter="True" AutoGenerateColumns="False"
                            Width="770px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            AllowSorting="True" CellPadding="4" Font-Size="X-Small" ForeColor="#333333" PageSize="20"
                            OnRowDeleting="Gridview1_RowDeleting">
                            <RowStyle BackColor="#EFF3FB" />
                            <EmptyDataRowStyle ForeColor="Red" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="No.">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EmployeeNo" HeaderText="EmployeeNo.">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Pending Assignmnets">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Width="350"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Reliever">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="TextBox3" runat="server" Height="21px" Width="250px" DataSourceID="relieverData1"
                                            DataTextField="Names" DataValueField="No_">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <FooterStyle HorizontalAlign="Right" BackColor="White" ForeColor="#000066" />
                                    <FooterTemplate>
                                        <asp:Button ID="ButtonAdd" runat="server" Text="Add" OnClick="ButtonAdd_Click" />
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True">
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 132px">
                        <asp:SqlDataSource ID="relieverData2" runat="server"></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:SqlDataSource ID="relieverData1" runat="server"></asp:SqlDataSource>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                    </td>
                </tr>
                <tr>
                    <td style="width: 132px">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnSubmit" runat="server" Height="33px" CssClass="btn btn-info"  OnClick="btnSubmit_Click"
                            Text="Submit" Width="138px" />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table class="table table-condensed table-responsive table-bordered">
                <tr>
                    <td id="Td11">
                        <asp:Label ID="Label4" runat="server" Text="Pending Leave Applications"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td id="Td12">
                        <asp:GridView ID="gvPending" runat="server" AllowPaging="True" AllowSorting="True"                            
                            EmptyDataText="You have no pending leave application(s)." AutoGenerateColumns="false"
                            Font-Size="X-Small" OnPageIndexChanging="gvPending_PageIndexChanging" DataKeyNames="Application Code"
                            OnSelectedIndexChanged="gvPending_SelectedIndexChanged" OnRowCommand="gvPending_RowCommand"
                            OnRowDataBound="gvPending_RowDataBound" OnSorting="gvPending_Sorting" PageSize="30"
                            Width="100%" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                            <EmptyDataRowStyle ForeColor="Red" />
                            <Columns>
                                <asp:ButtonField CommandName="btncancel" Text="Cancel" ButtonType="Image" ImageUrl="~/images/cancel.png">
                                    <ItemStyle Width="60px" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="Application Code" HeaderText="Doc No." />
                                <asp:BoundField DataField="Leave Type" HeaderText="Leave Type" />
                                <asp:BoundField DataField="Days Applied" DataFormatString="{0:n2}" HeaderText="Days Applied" />
                                <asp:BoundField DataField="Start Date" DataFormatString="{0:d}" HeaderText="Start Date" />
                                <asp:BoundField DataField="End Date" DataFormatString="{0:d}" HeaderText="End Date" />
                                <asp:BoundField DataField="Status Description" HeaderText="Status" />
                            </Columns>
                            <HeaderStyle ForeColor="White" />
                            <PagerStyle />
                            <AlternatingRowStyle />
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsPending" runat="server" ConnectionString="<%$ ConnectionStrings:Constr %>"
                            ProviderName="<%$ ConnectionStrings:Constr.ProviderName %>"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <table class="table table-condensed table-responsive table-bordered">
                <tr>
                    <td id="Td13">
                        <asp:Label ID="Label5" runat="server" Text="Approved Leave Applications&#13;&#10;"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td id="Td14">
                        <asp:GridView ID="gvApproved" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="false" EmptyDataText="You have no approved leave application(s)."
                            Font-Size="X-Small" OnPageIndexChanging="gvApproved_PageIndexChanging" OnSorting="gvApproved_Sorting"
                            PageSize="5" Width="100%" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                            <EmptyDataRowStyle ForeColor="Red" />
                            <Columns>
                                <asp:BoundField DataField="Application Code" HeaderText="Doc No." />
                                <asp:BoundField DataField="Leave Type" HeaderText="Leave Type" />
                                <asp:BoundField DataField="Days Applied" DataFormatString="{0:n2}" HeaderText="Days Applied" />
                                <asp:BoundField DataField="Start Date" DataFormatString="{0:d}" HeaderText="Start Date" />
                                <asp:BoundField DataField="End Date" DataFormatString="{0:d}" HeaderText="End Date" />
                                <asp:BoundField DataField="Status Description" HeaderText="Status" />
                            </Columns>
                            <HeaderStyle ForeColor="White" />
                            <PagerStyle />
                            <AlternatingRowStyle />
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsApproved" runat="server" ConnectionString="<%$ ConnectionStrings:Constr %>"
                            ProviderName="<%$ ConnectionStrings:Constr.ProviderName %>"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View4" runat="server">
            <table class="table table-condensed table-responsive table-bordered">
                <tr>
                    <td id="Td15" colspan="3">
                        <asp:Label ID="Label6" runat="server" Text="Rejected Leave Applications"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td id="Td16">
                        <asp:GridView ID="gvRejected" runat="server" AllowPaging="True" AllowSorting="True"
                            EmptyDataText="You have no rejected leave application(s)." AutoGenerateColumns="false"
                            Font-Size="X-Small" OnPageIndexChanging="gvRejected_PageIndexChanging" OnSorting="gvApproved_Sorting"
                            PageSize="5" Width="100%" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                            <AlternatingRowStyle CssClass="alt" />
                            <EmptyDataRowStyle ForeColor="Red" />
                            <Columns>
                                <asp:BoundField DataField="Application Code" HeaderText="Doc No." />
                                <asp:BoundField DataField="Leave Type" HeaderText="Leave Type" />
                                <asp:BoundField DataField="Days Applied" DataFormatString="{0:n2}" HeaderText="Days Applied" />
                                <asp:BoundField DataField="Start Date" DataFormatString="{0:d}" HeaderText="Start Date" />
                                <asp:BoundField DataField="End Date" DataFormatString="{0:d}" HeaderText="End Date" />
                                <asp:BoundField DataField="Status Description" HeaderText="Status" />
                            </Columns>
                            <HeaderStyle ForeColor="White" />
                            <PagerStyle CssClass="pgr" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsRejected" runat="server" ConnectionString="<%$ ConnectionStrings:Constr %>"
                            ProviderName="<%$ ConnectionStrings:Constr.ProviderName %>"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View5" runat="server">
            <table class="table table-condensed table-responsive table-bordered">
                <tr>
                    <td id="Td25">
                        <asp:Label ID="Label9" runat="server" Text="Approve Leave Applications"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td id="Td26">
                        <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" Width="780">
                            <asp:GridView ID="gvApprove2" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" DataSourceID="dsApprove2" DataKeyNames="Entry No"
                                EmptyDataText="You have no leaves awaiting your approval." Font-Size="X-Small"
                                OnPageIndexChanging="gvApprove2_PageIndexChanging" OnSorting="gvApprove2_Sorting"
                                PageSize="5" Width="100%" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt">
                                <EmptyDataRowStyle ForeColor="Red" />
                                <AlternatingRowStyle CssClass="alt" />
                                <Columns>
                                    <asp:BoundField DataField="Application Code" HeaderText="Doc No" SortExpression="Application Code">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Names" HeaderText="Names" SortExpression="Names">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Leave Type" SortExpression="Description">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Application Date" HeaderText="App. Date" ReadOnly="True"
                                        SortExpression="Application Date">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Days Applied" HeaderText="No. Days" ReadOnly="True" SortExpression="Days Applied">
                                        <HeaderStyle Wrap="False" />
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Start Date" HeaderText="Start Date" ReadOnly="True" SortExpression="Start Date">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Return Date" HeaderText="Return Date" ReadOnly="True"
                                        SortExpression="Return Date">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments">
                                        <ItemStyle Wrap="False" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Approve/Reject" SortExpression="Approve_Reject">
                                        <ItemTemplate>
                                            <asp:RadioButtonList ID="rblApprove" runat="server" ForeColor="White" RepeatDirection="Horizontal">
                                                <asp:ListItem>Approve</asp:ListItem>
                                                <asp:ListItem>Reject</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </ItemTemplate>
                                        <ItemStyle Font-Bold="True" ForeColor="White" Wrap="False"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approval/Rejection Comments">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtcomments" runat="server" Width="200"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle ForeColor="White" />
                                <PagerStyle CssClass="pgr" />
                            </asp:GridView>
                        </asp:Panel>
                        <asp:SqlDataSource ID="dsApprove2" runat="server" ConnectionString="<%$ ConnectionStrings:Constr %>"
                            ProviderName="<%$ ConnectionStrings:Constr.ProviderName %>"></asp:SqlDataSource>
                        <asp:Button ID="btnApprove" runat="server" Height="33px" CssClass="btn btn-info"  OnClick="btnApprove_Click"
                            Text="Approve/Reject" Width="138px" />
                        <br />
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View6" runat="server">
            <br />
            <b>Leave requests for my approval</b>
            <br />
            <asp:GridView ID="gvLeaveApprovals" runat="server" AllowPaging="False" CellPadding="3"
                EmptyDataText="No Leave Applications found." Font-Size="X-Small" Width="100%"
                AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None"
                BorderWidth="1px" OnPageIndexChanging="gvLeaveApprovals_PageIndexChanging" DataKeyNames="Entry No"
                OnRowCommand="gvLeaveApprovals_RowCommand">
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Left" VerticalAlign="Middle" />
                <Columns>
                    <asp:ButtonField CommandName="btnView" Text="View" ImageUrl="~/images/cancel.png">
                        <ItemStyle Width="40px" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="Entry No" HeaderText="No" Visible="false" InsertVisible="False"
                        ReadOnly="True" />
                    <asp:BoundField DataField="Document No_" HeaderText="Document No." />
                    <asp:BoundField DataField="Employee Name" HeaderText="Employee Name" Visible="True" />
                    <asp:BoundField DataField="Status Description" HeaderText="Status" ReadOnly="True" />
                </Columns>
                <EmptyDataRowStyle ForeColor="Red" />
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Constr %>">
            </asp:SqlDataSource>
        </asp:View>
        <asp:View ID="View7" runat="server">
            <asp:Literal runat="server" ID="litViewTraining"></asp:Literal>
            <table id="controls" class="table table-condensed table-responsive table-bordered">
                <tr>
                    <td colspan="3">
                        <b>Leave Relievers' List </b>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="gvRelieverView" runat="server" AllowPaging="False" CellPadding="3"
                            EmptyDataText="No Leave Relievers found." Font-Size="X-Small" Width="100%" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
                            OnPageIndexChanging="gvRelieverView_PageIndexChanging" DataKeyNames="Line No">
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Left" VerticalAlign="Middle" />
                            <Columns>
                                <asp:BoundField DataField="Line no" HeaderText="No" Visible="false" InsertVisible="False"
                                    ReadOnly="True" />
                                <asp:BoundField DataField="Document No" HeaderText="Document No" Visible="false" />
                                <asp:BoundField DataField="Reliever Name" HeaderText="Reliever Name" Visible="True">
                                    <ItemStyle Width="250px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="Pending Assignment" HeaderText="Pending Assignment" ReadOnly="True" />
                            </Columns>
                            <EmptyDataRowStyle ForeColor="Red" />
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <b>Approver Comments: </b>
                        <br />
                        <asp:TextBox ID="txtApproverComment" runat="server" Width="98%" TextMode="MultiLine">
                        </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnApproveLeave" runat="server" CssClass="btn btn-info"  Text="Approve Leave Request"
                            OnClick="btnApproveLeave_Click" OnClientClick="return confirm('Are you certain you want to approve this leave application?');" />
                    </td>
                    <td width='10px'>
                        &nbsp; &nbsp; &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnRejectLeave" runat="server" CssClass="btn btn-info"  Text="Reject Leave Request"
                            OnClick="btnRejectLeave_Click" OnClientClick="return confirm('Are you certain you want to <span style='color: RED;'> reject </span> this leave application?');" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="100%"></asp:Label>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
