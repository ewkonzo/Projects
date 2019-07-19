<%@ Page Title="Members Dashboard" Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" MasterPageFile="~/Site.master" Inherits="Bandari_Sacco.Dashboard" %>
 <asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     <!-- /.row 1 -->
            <div class="row">
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-university fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="medium"><label id="TotalDeposits">KES <%=TotalDeposits() %></label></div>
                                    <div>Total Non-Withdrawable Deposits</div>
                                </div>
                            </div>
                        </div>
                        <a href="DepositView.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Detail</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-bars fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="medium"><label id="TotalShares">KES <%=TotalShareCapital() %> </label></div>
                                    <div> Total Share Capital</div>
                                </div>
                            </div>
                        </div>
                        <a href="ShareCapitalView.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Detail</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-credit-card fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="medium"><label id="TotalRepayments">KES <%=TotalLoanRepayments() %></label></div>
                                    <div>Total Loan Repayments</div>
                                </div>
                            </div>
                        </div>
                        <a href="LoanRepaymentView.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Detail</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-credit-card fa-5x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                   <div class="medium"><label id="Tab3">KES <%=TotalLoans() %></label></div>
                                    <div>Total Loans</div>
                                </div>
                            </div>
                        </div>
                        <a href="LoanView.aspx">
                            <div class="panel-footer">
                                <span class="pull-left">View Detail</span>
                                <span class="pull-right"><i class="fa fa-arrow-circle-right"></i></span>
                                <div class="clearfix"></div>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
            <!-- /.row 1 -->
    
<%--    /.row 2 --%>
    <div class="row">
        <div class="col-lg-3 col-md-6">
            <div class="panel panel-info">
               <div class="panel-heading"><i class="fa fa-pie-chart"></i> Performance Summary</div>
               <div class="panel-body"><div id="canvas-holder">
                <canvas id="chart-area2" width="200" height="150"></canvas>
             </div></div> 
            </div>
        </div>
        <div class="col-md-6">
         <div class="panel panel-info">
            <div class="panel-heading"><i class="fa fa-bar-chart"></i> Progress Analysis</div>
            <div class="panel-body"><canvas id="canvas" width="200" height="60"></canvas></div>
          </div>
         </div>
        <div class="col-lg-3 col-md-6">
          <div class="panel panel-info">
			<div class="panel-heading"><i class="fa fa-leaf"></i> Legend</div>
                <div class="panel-body">
                   <ul class="doughnut-legend">
                      <%--  <li><span style="background-color:#16A086"></span>Total Deposits</li>--%>
                        <li><span style="background-color:#1A3586"></span>Total Repayments</li>
                        <li><span style="background-color:#FFA583"></span>Total Loans</li>
                        <%--<li><span style="background-color:#73A354"></span>Total Loans</li>--%>
                    </ul> 
                    

		 </div>
      </div>
    </div>
  </div>
    
    <div class="row">
         <div class="col-md-6">
             <div class="panel panel-info">
                 <div class="panel-heading"><i class="fa fa-list-alt"></i> My Balance Listings</div>
                 <div class="panel-body"><table class="table table-condensed table-responsive">
        <thead>
            <tr>
               
                <th class="small">Product Name</th>
                <th class="small">Type</th>
                <th class="small">Balance</th>
            </tr>
        </thead>
        <tbody>           
        <%=LatestTransactions()%>
        </tbody>
    </table>

                 </div>
             </div>
             
         </div>
        <div class="col-md-6">
             <div class="panel panel-info">
                 <div class="panel-heading"><i class="fa fa-list-alt"></i> Savings Account Statement</div>
                 <div class="panel-body"><table class="table table-condensed table-responsive">
       <thead>
            <tr>
                <th class="small">Date</th>
                <th class="small">Description</th>
                <th class="small">Debit</th>
                <th class="small">Credit</th>
                 <th class="small">Balance</th>
            </tr>
        </thead>
        <tbody>
             <%=SavingsAccountStatement()%>
        </tbody>
    </table></div>
             </div>
             
         </div>
    </div>
    
 
    
<%--    /. row --%>
</asp:Content>