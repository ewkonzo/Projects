<%@ Page Title="Loans Calculator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoansCalculator.aspx.cs" Inherits="Bandari_Sacco.LoansCalculator" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="Bandari_Sacco.controller" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="panel panel-info">
           <div class="panel-heading"><i class="fa fa-calculator"></i> Loan Calculator</div>
           <div class="panel-body">
              <table class="table table-responsive table-condensed table-bordered">
                    <tr>
                        <td colspan="2">
                            <h4><small><i class="fa fa-list"></i> LOAN DETAILS</small></h4>
                            <p class="lead"><small>Determines if you can qualify for a specified loan amount, based on your current shares/deposits.</small></p></td>
                        <td rowspan="8">
                            <asp:Label ID="Label3" runat="server"></asp:Label>
                        </td>
                        <td colspan="2">
                            <h4><small><i class="fa fa-table"></i> LOAN DETAILS</small></h4>
                            <p class="lead"><small>Determines if you can be able to repay 
                            your loan, based on the monthly deductions from your payslip..</small></p></td>
                    </tr>
                    <tr>
                        <td>Loan Type:</td>
                        <td>
                            <asp:DropDownList ID="ddlLoanTypes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLoanTypes_SelectedIndexChanged" CssClass="form-control">
                            </asp:DropDownList>
                        </td>
                        <td><asp:Label ID="Label4" runat="server" Text="Basic Pay:"></asp:Label></td>
                        <td><asp:TextBox ID="txtBasicPay" runat="server" CssClass="form-control"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBasicPay" 
                            CssClass="failureNotification" ErrorMessage="Basic Pay required." ToolTip="Basic Pay is required." 
                            ValidationGroup="LoginUserValidationGroup"><span style="color:Red;">*</span></asp:RequiredFieldValidator>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtBasicPay" 
                            ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^(((\d{1,3})(,\d{3})*)|(\d+))(.\d+)?$">
                            <span style="color:red;">Invalid</span></asp:RegularExpressionValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Loan Amount:"></asp:Label></td>
                       
                        
                        <td>
                            <asp:TextBox ID="txtLoanAmount" runat="server" CssClass="form-control"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoanAmount" 
            CssClass="failureNotification" ErrorMessage="Loan Amount required." ToolTip="Loan amount is required." 
            ValidationGroup="LoginUserValidationGroup"><span style="color:Red;">*</span></asp:RequiredFieldValidator>
                    
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLoanAmount" 
            ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^(((\d{1,3})(,\d{3})*)|(\d+))(.\d+)?$">
            <span style="color:red;">Invalid</span></asp:RegularExpressionValidator>

                                </td>

                        <td>
                            Total Allowances:</td>
                        <td>
                            <asp:TextBox ID="txtTotalAllowances" runat="server" CssClass="form"></asp:TextBox>

                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTotalAllowances" 
            CssClass="failureNotification" ErrorMessage="Total Allowances required." ToolTip="Total Allowances is required." 
            ValidationGroup="LoginUserValidationGroup"><span style="color:Red;">*</span></asp:RequiredFieldValidator>

                     <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTotalAllowances" 
            ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^(((\d{1,3})(,\d{3})*)|(\d+))(.\d+)?$">
            <span style="color:red;">Invalid</span></asp:RegularExpressionValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            Repayment Period (<em><strong>in months</strong></em>):</td>
                        
                        <td>
                            <asp:DropDownList ID="ddlRepaymentPeriod" runat="server" OnSelectedIndexChanged="ddlRepaymentPeriod_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Total Deductions:</td>
                        <td>
                            <asp:TextBox ID="txtTotalDeductions" runat="server" ></asp:TextBox>

                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTotalDeductions" 
            CssClass="failureNotification" ErrorMessage="Total Deductions required." ToolTip="Total Deductions is required." 
            ValidationGroup="LoginUserValidationGroup"><span style="color:Red;">*</span></asp:RequiredFieldValidator>

                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtTotalDeductions" 
            ValidationGroup="LoginUserValidationGroup" ErrorMessage="Fails" ValidationExpression="^(((\d{1,3})(,\d{3})*)|(\d+))(.\d+)?$">
            <span style="color:red;">Invalid</span></asp:RegularExpressionValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            Interest Rate (<strong><em>per month</em></strong>):</td>
                       
                        <td>
                            <asp:Label ID="lblInterestRate" runat="server" ></asp:Label></td>
                        <td>
                            Net Income:</td>
                        <td>
                            <asp:Label ID="lblNetIncome" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Repayment:</td>
                        
                        <td><asp:Label ID="lblMonthlyRepayment" runat="server"></asp:Label></td>
                        <td>
                            1/3 of Basic Pay:</td>
                        <td>
                            <asp:Label ID="lblThirdBasic" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3">

                            <asp:Label ID="Label5" runat="server"></asp:Label>

                <asp:Label ID="lblError0" runat="server"></asp:Label>
            
                                            <br />
                <asp:Label ID="lblWarn" runat="server"></asp:Label>
               
                <asp:Label ID="lblError" runat="server"></asp:Label>
              
                        </td>

                    <td>Amount Available for Borrowing:</td>
                        <td>
                            <asp:Label ID="lblAmountAvailable" runat="server"></asp:Label>
                          </td>
                    </tr>

              </table>
               <div class="row">
                   <div class="col-xs-4"></div>
                   <div class="col-xs-4"> </div>
                   <div class="col-xs-4"><asp:Button ID="btnCalculate" runat="server" Text="Calculate" CssClass="btn btn-info" ValidationGroup="LoginUserValidationGroup"
                            onclick="btnCalculate_Click" /></div>
               </div>
              
            <%   
                string Member_No_ = Session["Member_No"].ToString();
                double TotalInterest = 0, Total_LoanRepayment = 0, Total_Deduction = 0;
                string Period = "",Month_Year="",Principle="",Loan_Repayment="",Interest="",Total_Deductions="",Loan_Balance="";
                
                var pp =   Bandari_Sacco.Global.loan_Calc_Service.ReadMultiple(new Bandari_Sacco.loan_Calc.Online_Loan_Calc_Filter[] { new Bandari_Sacco.loan_Calc.Online_Loan_Calc_Filter { Criteria = Member_No_, Field = Bandari_Sacco.loan_Calc.Online_Loan_Calc_Fields.User_ID } }, null, 0);


                //using (SqlConnection conn = MyClass.getconnToNAV())
                //{
                //    string s = "SELECT Month,Period,[Principle Amount],[Loan Repayment],Interest,[Total Deduction],[Loan Balance] FROM [" + MyClass.CompanyName + "$Online Loan Calculator New] WHERE [User ID]=@Member_No ORDER BY [Month] ASC";
                //    SqlCommand command = new SqlCommand(s, conn);
                //    command.Parameters.AddWithValue("@Member_No", Member_No_);

                //    using (SqlDataReader dr = command.ExecuteReader())
                //    {
                if (pp.Count()>0)
                {%>

           </div>
  </div>
    <% 
        string Loan_Type=ddlLoanTypes.SelectedItem.Text;
        string loan_Amount = txtLoanAmount.Text;
        string Repayment_Period = ddlRepaymentPeriod.Text;
        string InterestRate = lblInterestRate.Text;
        string Monthly_Payment = lblMonthlyRepayment.Text;
        %>
           <hr style="border: 1px #CCCCCC solid"/>
    <table class="table table-condensed table-bordered table-responsive">
       
        <thead>
             <tr class="text-danger"><th colspan="6" style="border: 0">LOAN REPAYMENT SCHEDULE</th><th style="border: 0; text-align: right" ><span class="right text-danger"><a href="PrintLoanCalculator.aspx?Loan_Type=<%=Loan_Type %>&loan_Amount=<%=loan_Amount %>&Repayment_Period=<%=Repayment_Period %>&InterestRate=<%=InterestRate %>&Monthly_Payment=<%=Monthly_Payment %>"> 
       <i class="fa fa-print fa-2x text-danger"></i>
       </a></span></th></tr>
        <tr>
        <th>Period</th>
        <th>Month-Year</th>
        <th>Principle</th>
        <th>Principle Repayment</th>
        <th>Interest Repayment</th>
        <th>Monthly Repayment</th>
        <th>Loan Balance</th>
        </tr>
        </thead>
        <tbody>
        <% int i = 0;

            foreach (var p in pp)
            {


                i++;
                Period = p.Month.ToString();//  dr["Month"].ToString();
                Month_Year = p.Period.ToString();// dr["Period"].ToString();
                Principle = p.Principle_Amount.ToString();// dr["Principle Amount"].ToString();
                Loan_Repayment = p.Loan_Repayment.ToString();// dr["Loan Repayment"].ToString();
                Interest = p.Interest.ToString();// dr["Interest"].ToString();
                Total_Deductions = p.Total_Deduction.ToString();// dr["Total Deduction"].ToString();
                Loan_Balance = p.Loan_Balance.ToString();// dr["Loan Balance"].ToString();
                TotalInterest += Convert.ToDouble(Interest);
                Total_Deduction += Convert.ToDouble(Total_Deductions);

                Total_LoanRepayment += Convert.ToDouble(Total_Deductions);


                if (i % 2 == 0)
                {
               %>
       <tr>
       <td class="eventd"><%=Period%></td>
        <td class="eventd"><%=Month_Year%></td>
         <td class="eventd"><%=Principle%></td>
          <%--<td class="eventd"><%=Loan_Repayment%></td>--%>
           <td class="eventd"><%=Total_Deductions%></td>
           <td class="eventd"><%=Interest%></td>
            <%--<td class="eventd"><%=Total_Deductions%></td>--%>
            <td class="eventd"><%=Loan_Repayment%></td>
             <td class="eventd"><%=Loan_Balance%></td>
       </tr>
       <%}
    else
    { %>
                   <tr>
       <td class="oddtd"><%=Period%></td>
        <td class="oddtd"><%=Month_Year%></td>
         <td class="oddtd"><%=Principle%></td>
          <%--<td class="oddtd"><%=Loan_Repayment%></td>--%>
           <td class="oddtd"><%=Total_Deductions%></td>
           <td class="oddtd"><%=Interest%></td>
            <%--<td class="oddtd"><%=Total_Deductions%></td>--%>
             <td class="oddtd"><%=Loan_Repayment%></td>
             <td class="oddtd"><%=Loan_Balance%></td>
       </tr>
         <%}
        
    }%>

         <tr>
         <td></td>       
           <td></td>
               <% Total_Deduction = Total_LoanRepayment + TotalInterest;%>
            <td style="font-weight:bold;height:20px;">TOTALS</td>
            <td  style="font-weight:bold;"><%=String.Format("{0:0,0.00}", Total_LoanRepayment)%></td>
             <td style="font-weight:bold;"><%=String.Format("{0:0,0.00}", TotalInterest)%></td>          
              <td style="font-weight:bold;"><%=String.Format("{0:0,0.00}", Total_Deduction)%></td>
               <td></td>
         </tr>

        </tbody>
    </table>
                      
                  <%}
            
            
          %>
</asp:Content>
