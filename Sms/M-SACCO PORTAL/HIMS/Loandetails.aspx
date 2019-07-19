<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Loandetails.aspx.cs" Inherits="HIMS.loandetails" %>

<asp:Content ID="Content_Sidebar" ContentPlaceHolderID="SideBar_Master" runat="server">

</asp:Content>

<asp:Content ID="Content_Main" ContentPlaceHolderID="Home_Master" runat="server">

 <asp:GridView ID="gvloans" runat="server" AutoGenerateColumns="False" AllowPaging="False"
             AllowSorting="True" CellPadding="2" CellSpacing="1" Width="100%" ForeColor="#333333"
             GridLines="None" EmptyDataText="No Records."
             EnableModelValidation="True"  
             PageSize="10" ShowHeader="true" Font-Size="x-small" BackColor="#E6D9BD">
             <AlternatingRowStyle BackColor="#FFFFE1" />
             <Columns>
              <asp:TemplateField HeaderText=" Loan Applied Tel No" SortExpression="Telephone No" HeaderStyle-HorizontalAlign="Left"
              HeaderStyle-ForeColor="Green">
                     <ItemStyle Width="120px"/>
                     <ItemTemplate>
                         <%# Eval("[Source]")%>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Guarantor Tel No" SortExpression="Application Date" HeaderStyle-ForeColor="Green">
                     <ItemStyle Width="110px" HorizontalAlign="Center" />
                     <ItemTemplate>
                       <%# Eval("[Guarantor]")%>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Loan Type" SortExpression="Loan Type" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="Green">
                     <ItemStyle Width="120px" />
                     <ItemTemplate>
                         <%# Eval("[Loan type]")%>
                     </ItemTemplate>
                 </asp:TemplateField>
               <asp:TemplateField HeaderText="Status" SortExpression="Applied Amount" HeaderStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="Green">
                     <ItemStyle Width="110px" HorizontalAlign="Right" />
                     <ItemTemplate>
                        <%# Eval("[Status]")%> 
                     </ItemTemplate>                   
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Remarks" SortExpression="Guarantors" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="Green">
                     <ItemStyle Width="120px" />
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

