<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="HIMS.message" %>

<asp:Content ID="Content_Sidebar" ContentPlaceHolderID="SideBar_Master" runat="server">

</asp:Content>

<asp:Content ID="Content_Main" ContentPlaceHolderID="Home_Master" runat="server">
 
  <table>  
  <tr>
  <td> Enter Telephone No:</td>
  <td> <asp:TextBox ID="txtNo" Width="150px" runat="server"></asp:TextBox> </td>
  <td><asp:Button ID="btnLogin" runat="server"  OnClick="SearchButton_Click" Text="Search" /> </td>
  </tr>
  </table>
  
  <asp:GridView ID="gvmessage" runat="server" AutoGenerateColumns="False" AllowPaging="True"
             AllowSorting="True" CellPadding="2" CellSpacing="1" Width="100%" ForeColor="#333333"
             GridLines="None" EmptyDataText="No Records." OnPageIndexChanging="gvmessage_PageIndexChanging" 
             EnableModelValidation="True"  OnRowDataBound="gvmessage_RowDataBound" ShowFooter="true"
             PageSize="20" ShowHeader="true" Font-Size="x-small" BackColor="#E6D9BD">
             <AlternatingRowStyle BackColor="#FFFFE1" />
             <Columns>
              <asp:TemplateField HeaderText="Telephone No" SortExpression="Telephone No" HeaderStyle-HorizontalAlign="Left"
                         HeaderStyle-ForeColor="Green">
                     <ItemStyle Width="120px" />
                     <ItemTemplate>
                         <%# Eval("[ToAddress]")%>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Date Sent" SortExpression="Date Sent" HeaderStyle-ForeColor="Green">
                     <ItemStyle Width="90px" HorizontalAlign="Center" />
                     <ItemTemplate>
                        <%# string.Format("{0:dd-MMM-yyyy hh:mm}",Eval("[Datetime]")) %>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Message Body" SortExpression="Message Body" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="Green">
                     <ItemStyle Width="120px" />
                     <ItemTemplate>
                         <%# Eval("[Body]")%>
                     </ItemTemplate>
                 </asp:TemplateField>  
                 <asp:TemplateField HeaderText="State" SortExpression="State" HeaderStyle-HorizontalAlign="Left"
                         HeaderStyle-ForeColor="Green">
                     <ItemStyle Width="80px" />
                     <ItemTemplate>
                         <%# Eval("[Trace]")%>
                     </ItemTemplate>
                 </asp:TemplateField>           
               
             </Columns>

             <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
             <EditRowStyle BackColor="#2461BF" />
             <EmptyDataRowStyle ForeColor="Red" />
             <FooterStyle BackColor="#b39f60" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#b39f60" Font-Bold="True" ForeColor="White" />
             <RowStyle BorderColor="#b39f60" />
             <SelectedRowStyle BackColor="#c5c48d" Font-Bold="True" ForeColor="#333333" BorderColor="Red" />
         </asp:GridView>

</asp:Content>

