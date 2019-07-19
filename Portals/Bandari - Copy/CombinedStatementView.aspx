<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CombinedStatementView.aspx.cs" Inherits="PostBank_Sacco.CombinedStatementView" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <div class="panel panel-info">
            <div class="panel-heading"><a href="LoansStatement.aspx"><i class="fa fa-print fa-2x text-danger"></i></a></div>
                 <div class="panel-body">
    <table class="table table-condensed table-responsive table-striped">
       <thead>
            <tr>
                <th class="small" >#</th>
                <th class="small" >Posting Date</th>
                <th class="small" >Document No.</th>
                <th class="small" >Description</th>
                <th class="small" >Debit Amt</th>
                <th class="small" >Credit Amt</th>
                <th class="small" >Bal</th>
            </tr>
        </thead>
        <tbody>
             <%=LoanStatement()%>
        </tbody>
    </table>
    </div>
            </div>
        </div>
</asp:Content>

