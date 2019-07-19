<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="UtilityPayment.aspx.cs" Inherits="HIMS.UtilityPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SideBar_Master" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Home_Master" runat="server">
<center>

<div class="style1">
<h6 class="style2" style="text-transform:uppercase;"> <b> UTILITY PAYMENTS </b> </h6>
</div>

 <table>  
  <tr>
  <td> Enter Telephone No:</td>
  <td> <asp:TextBox ID="txtNo" Width="150px" runat="server"></asp:TextBox> </td>
  <td><asp:Button ID="btnLogin" runat="server"  OnClick="SearchButton_Click" Text="Search" /> </td>
  </tr>
  </table>
  </center>


  <asp:GridView ID="gvutility" runat="server" AutoGenerateColumns="False" AllowPaging="True"
             AllowSorting="False" CellPadding="2" CellSpacing="1" Width="100%" ForeColor="#333333"
             GridLines="None" EmptyDataText="No Records." OnPageIndexChanging="gvutility_PageIndexChanging" 
             EnableModelValidation="True"  OnRowDataBound="gvutility_RowDataBound" ShowFooter="true"
             PageSize="20" ShowHeader="true" Font-Size="x-small" BackColor="#E6D9BD">
             <AlternatingRowStyle BackColor="#FFFFE1" />
             <Columns>
              <asp:TemplateField HeaderText="Telephone No" SortExpression="Telephone No" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="Green">
              <HeaderStyle ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>
                     <ItemStyle Width="90px" HorizontalAlign="Center" />
                     <ItemTemplate>
                         <%# Eval("[Telephone No]")%>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Date" SortExpression="Date" HeaderStyle-ForeColor="Green">
                 <HeaderStyle ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>
                     <ItemStyle Width="90px" HorizontalAlign="Center" />
                     <ItemTemplate>
                        <%# string.Format("{0:dd-MMM-yyyy hh:mm}",Eval("[Date Created]")) %>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Utility Payment Type" SortExpression="Message Body" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="Green">
                 <HeaderStyle ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>
                     <ItemStyle Width="120px" />
                     <ItemTemplate>
                         <%# Eval("[Utility Payment Type]")%>
                     </ItemTemplate>
                 </asp:TemplateField>  
                 <asp:TemplateField HeaderText="Utility Payment Account" SortExpression="State" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="Green">
                 <HeaderStyle ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>
                     <ItemStyle Width="90px" HorizontalAlign="Center" />
                     <ItemTemplate>
                         <%# Eval("[Utility Payment Account]")%>
                     </ItemTemplate>
                 </asp:TemplateField>  
                  <asp:TemplateField HeaderText="Amount" SortExpression="State" HeaderStyle-HorizontalAlign="Left"
                         HeaderStyle-ForeColor="Green">
                         <HeaderStyle ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>
                    <ItemStyle Width="90px" HorizontalAlign="Center" />
                     <ItemTemplate>
                         <%# Eval("[Amount]")%>
                     </ItemTemplate>
                 </asp:TemplateField>   
                  <asp:TemplateField HeaderText="Status" SortExpression="State" HeaderStyle-HorizontalAlign="Left"
                         HeaderStyle-ForeColor="Green">
                         <HeaderStyle ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>
                      <ItemStyle Width="90px" HorizontalAlign="Center" />
                     <ItemTemplate>
                         <%# Eval("[Status]")%>
                     </ItemTemplate>
                 </asp:TemplateField>   
                  <asp:TemplateField HeaderText="Remarks" SortExpression="State" HeaderStyle-HorizontalAlign="Left"
                         HeaderStyle-ForeColor="Green">
                         <HeaderStyle ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>
                    <ItemStyle Width="90px" HorizontalAlign="Center" />
                     <ItemTemplate>
                         <%# Eval("[Remarks]")%>
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
