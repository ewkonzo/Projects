<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Loans.aspx.cs" Inherits="HIMS.Guest" %>

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
  

  <asp:GridView ID="gvloans" runat="server" AutoGenerateColumns="False" AllowPaging="True"
             AllowSorting="False" Width="100%" EmptyDataText="No Records." OnSorting="gvloans_Sorting"
             OnPageIndexChanging="gvloans_PageIndexChanging" OnSelectedIndexChanged="gvloans_SelectedIndexChanged"
             EnableModelValidation="True"  OnRowDataBound="gvloans_RowDataBound" ShowFooter="True"
             PageSize="20" Font-Size="X-Small" 
        HeaderStyle-Font-Bold="true" OnRowEditing="gvloans_RowEditing">
             <Columns>
              <asp:TemplateField HeaderText="Telephone No" SortExpression="Telephone No" HeaderStyle-HorizontalAlign="Left"
              HeaderStyle-ForeColor="Green">

<HeaderStyle HorizontalAlign="Left" ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview" ></HeaderStyle>

                     <ItemStyle Width="120px" />
                     <ItemTemplate>
                         <%# Eval("[Telephone No]")%>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Application Date" SortExpression="Application Date" HeaderStyle-ForeColor="Green">

<HeaderStyle ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>

                     <ItemStyle Width="110px" HorizontalAlign="Center" />
                     <ItemTemplate>
                        <%# string.Format("{0:dd-MMM-yyyy hh:mm}",Eval("[Transaction Date]")) %>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Loan Type" SortExpression="Loan Type" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="Green">

<HeaderStyle HorizontalAlign="Left" ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>

                     <ItemStyle Width="120px" />
                     <ItemTemplate>
                         <%# Eval("[Loan type]")%>
                     </ItemTemplate>
                 </asp:TemplateField>
               <asp:TemplateField HeaderText="Applied Amount" SortExpression="Applied Amount" HeaderStyle-HorizontalAlign="Right" HeaderStyle-ForeColor="Green">

<HeaderStyle HorizontalAlign="Right" ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>

                     <ItemStyle Width="90px" HorizontalAlign="Right" />
                     <ItemTemplate>
                         <%# string.Format("{0:#,##0.00}", ((decimal)Eval("[Amount]")))%>
                     </ItemTemplate>                   
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Guarantors" SortExpression="Guarantors" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="Green">

<HeaderStyle HorizontalAlign="Left" ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>

                     <ItemStyle Width="90px" />
                     <ItemTemplate>
                         <%# Eval("[Client Code]")%>
                     </ItemTemplate>
                 </asp:TemplateField>
                  <asp:TemplateField HeaderText="Status" SortExpression="Status" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="Green">
                     <ItemStyle Width="90px" />
                     <ItemTemplate>
                         <%# Eval("[Status]") %>
                     </ItemTemplate>                   

<HeaderStyle HorizontalAlign="Left" ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="View Guarantors" HeaderStyle-ForeColor="Green">
                   <ItemStyle Width="90px" />
                     <ItemTemplate>
                      <asp:ImageButton ID="Image1" runat="server" ImageUrl="../IMAGES/small_writing.png" CommandName="Edit" />
                     </ItemTemplate>                   

<HeaderStyle ForeColor="Black" BackColor="Green" Font-Bold="true" Font-Underline="false" CssClass="gridview"></HeaderStyle>
                 </asp:TemplateField>
             </Columns>

             <EmptyDataRowStyle ForeColor="Red" />
             <RowStyle BorderColor="#b39f60" />
             <SelectedRowStyle 
                 BorderColor="Red" />
         </asp:GridView>



</asp:Content>

