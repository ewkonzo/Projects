<%@ Page Title="Combined Statement" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CombinedStatement.aspx.cs" Inherits="Bandari_Sacco.CombinedStatement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript">
         $(function () {
             $('#datetimepicker1').datetimepicker({
                 locale: 'ru'
             });
             $('#datetimepicker2').datetimepicker({
                 locale: 'ru'
             });
         });
        </script>
    <div>
        
        <div class="row">
            <div class="col-md-6">
                <div class=" form-group"><asp:Label ID="lblMessage" runat="server" CssClass="label label-warning">Click on the icon to select the period for which you want to view your statement, or type in the date in the format MM/DD/YYYY</asp:Label></div> 
            </div> 
            
        </div>
        <div class="row">
            
        <div class='col-sm-6'>
           
           
            <div class="form-group">
                <div class='input-group date' id='datetimepicker1'>
                    
                     <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" placeholder="Select your Start Date (MM/DD/YYYY)"></asp:TextBox>
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
            </div>
        </div>
        <div class='col-sm-6'>
            <div class="form-group">
                <div class='input-group date' id='datetimepicker2'>
                     <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" placeholder="Select your End Date (MM/DD/YYYY)"></asp:TextBox>
                    <span class="input-group-addon">
                        <span class="glyphicon glyphicon-calendar"></span>
                    </span>
                </div>
               
            </div>
            
         
        </div>
            
         
    </div>
        <div class="row">
            <div class="col-md-6">
                <div class=" form-group"><asp:Button ID="btnGenerate" runat="server" Text="Generate" CssClass="btn btn-info btn-large" OnClick="btnGenerate_Click"/></div> 
            </div> 
            
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class=" form-group"><asp:Label ID="lblError" runat="server" CssClass="label label-danger"></asp:Label></div> 
            </div> 
            
        </div>
        
        </div>
<iframe runat="server" id="pdfLoans" 
        style="border: silver thin ridge;width:100%; height: 450px;"></iframe>
</asp:Content>
