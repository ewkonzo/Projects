using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Microsoft.VisualBasic;
//using System.Text.StringBuilder;
using System.Text;
using Bandari_Sacco.controller;


namespace Bandari_Sacco
{
    public partial class LoansCalculator : System.Web.UI.Page
    {
      
        #region Page Load
        protected void Page_Load(object sender, EventArgs e)
        {
             if (Session["Member_No"] == null)
            {
                
                if (Session["Member_No"] == null)
                {
                    Session["Member_No"] = "OFFLINECALC";
                    Session.Abandon();
                    Response.Redirect("Login.aspx");
                }
            }
            if (!IsPostBack)
            {
                LoadLoanTypes();
                this.ddlLoanTypes_SelectedIndexChanged(null, null);

            }
          

            this.txtBasicPay.ToolTip = MyClass.getMembersNames(Session["Member_No"].ToString()) +
                ", Please enter your BASIC PAY.";
            this.txtLoanAmount.ToolTip = MyClass.getMembersNames(Session["Member_No"].ToString()) +
                ", Please enter the LOAN AMOUNT.";
            this.txtTotalAllowances.ToolTip = MyClass.getMembersNames(Session["Member_No"].ToString()) +
                ", Please enter your TOTAL ALLOWANCES.";
            this.txtTotalDeductions.ToolTip = MyClass.getMembersNames(Session["Member_No"].ToString()) +
                ", Please enter your TOTAL DEDUCTIONS.";

            #region DELETE ONLINE  FOR THIS MEMBER

            using (SqlConnection conn = MyClass.getconnToNAV())
            {
                string AH = "DELETE FROM [" + MyClass.CompanyName + "$Online Loan Calculator New]" +
                " WHERE [User ID] = @Member_No_;";
                SqlCommand command = new SqlCommand(AH, conn);
                command.Parameters.AddWithValue("@Member_No_", Session["Member_No"].ToString());
                command.ExecuteNonQuery();
                conn.Close();
            }
            #endregion


            //if (Session["Member_No"] != null || string.IsNullOrEmpty(Session["Member_No"].ToString()) == false)
            //{
            //    if (!IsPostBack)
            //    {

            //        string ChangedPassword = "";
            //        ChangedPassword = MyClass.CheckIfChangedPassword(Session["Member_No"].ToString());

            //        if (ChangedPassword == "0")
            //        {
            //            Response.Redirect("Change_Password.aspx?action=ChangePassword");
            //        }
            //        else
            //        {

            //            LoadLoanTypes();

            //            this.ddlLoanTypes_SelectedIndexChanged(null, null);

            //            this.txtBasicPay.ToolTip = MyClass.getMembersNames(Session["Member_No"].ToString()) +
            //                ", Please enter your BASIC PAY.";
            //            this.txtLoanAmount.ToolTip = MyClass.getMembersNames(Session["Member_No"].ToString()) +
            //                ", Please enter the LOAN AMOUNT.";
            //            this.txtTotalAllowances.ToolTip = MyClass.getMembersNames(Session["Member_No"].ToString()) +
            //                ", Please enter your TOTAL ALLOWANCES.";
            //            this.txtTotalDeductions.ToolTip = MyClass.getMembersNames(Session["Member_No"].ToString()) +
            //                ", Please enter your TOTAL DEDUCTIONS.";

            //            #region DELETE ONLINE  FOR THIS MEMBER

            //            using (SqlConnection conn = MyClass.getconnToNAV())
            //            {
            //                string AH = "DELETE FROM [" + MyClass.CompanyName + "$Online Loan Calculator]" +
            //                " WHERE [User ID] = @Member_No_;";
            //                SqlCommand command = new SqlCommand(AH, conn);
            //                command.Parameters.AddWithValue("@Member_No_", Session["Member_No"].ToString());
            //                command.ExecuteNonQuery();
            //                conn.Close();
            //            }
            //            #endregion
            //        }
            //    }
            //}
            //else
            //{
            //    Session.Abandon();
            //    Response.Redirect("Login.aspx");
            //}

        }
        #endregion

        #region btn Calculate_Click

        protected void btnCalculate_Click(object sender, EventArgs e)
        {

            lblError.Text = "";
            lblError0.Text = "";

            string Member_No_ = Session["Member_No"].ToString().Trim();

            #region DELETE ONLINE  FOR THIS MEMBER

            using (SqlConnection conn = MyClass.getconnToNAV())
            {
                string AH = "DELETE FROM [" + MyClass.CompanyName + "$Online Loan Calculator New]" +
                " WHERE [User ID] = @Member_No_;";
                SqlCommand command = new SqlCommand(AH, conn);
                command.Parameters.AddWithValue("@Member_No_", Session["Member_No"].ToString());
                command.ExecuteNonQuery();
                conn.Close();
            }
            #endregion

            if (string.IsNullOrEmpty(this.txtLoanAmount.Text.Trim()))
            {
                this.lblError.Text = "Please, enter the Loan Amount.";
                Message(lblError.Text);
                this.txtLoanAmount.Focus();
                return;

            }
            else if (string.IsNullOrEmpty(this.txtBasicPay.Text.Trim()))
            {
                this.lblError.Text = "Please, enter the basic pay.";
                Message(lblError.Text);
                this.txtBasicPay.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(this.txtTotalAllowances.Text.Trim()))
            {
                this.lblError.Text = "Please, enter total allowances.";
                Message(lblError.Text);
                this.txtTotalAllowances.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(this.txtTotalDeductions.Text.Trim()))
            {
                this.lblError.Text = "Please, enter the total deductions.";
                Message(lblError.Text);
                this.txtTotalDeductions.Focus();
                return;
            }
            else if (Convert.ToDouble(this.txtLoanAmount.Text.Trim()) > this.MaximumLoanAmount(this.ddlLoanTypes.SelectedValue) && this.MaximumLoanAmount(this.ddlLoanTypes.SelectedValue) > 0)
            {
                //if (this.MaximumLoanAmount(this.ddlLoanTypes.SelectedValue) > 0)
                //{
                this.lblError.Text = "The maximum loan amount is " +
                MyClass.FormatNumber(this.MaximumLoanAmount(this.ddlLoanTypes.SelectedValue));
                Message(lblError.Text);
                this.txtLoanAmount.Focus();
                return;
                //}
            }
            else
            {
                try
                {


                    double basicPay = 0, totalAllowance = 0, totalDeductions = 0, netIncome = 0;

                    basicPay = Convert.ToDouble(this.txtBasicPay.Text);
                    totalAllowance = Convert.ToDouble(this.txtTotalAllowances.Text);
                    totalDeductions = Convert.ToDouble(this.txtTotalDeductions.Text);

                    netIncome = basicPay + totalAllowance - totalDeductions;

                    if (netIncome <= 0)
                    {
                        this.lblError.Text = "Your net income is less than zero. Make the necessary adjustments.";
                        Message(this.lblError.Text);
                        return;
                    }

                    this.lblNetIncome.Text = MyClass.FormatNumber(netIncome);
                    this.lblThirdBasic.Text = MyClass.FormatNumber(basicPay / 3);
                    this.lblAmountAvailable.Text = MyClass.FormatNumber(netIncome - (basicPay / 3));

                    #region DELETE ONLINE  FOR THIS MEMBER

                    using (SqlConnection conn = MyClass.getconnToNAV())
                    {
                        string AH = "DELETE FROM [" + MyClass.CompanyName + "$Online Loan Calculator New]" +
                        " WHERE [User ID] = @Member_No_;";
                        SqlCommand command = new SqlCommand(AH, conn);
                        command.Parameters.AddWithValue("@Member_No_", Member_No_);
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                    #endregion

                    double loanAmount = 0, repaymentPeriod = 0, interest = 0, pmt = 0,
                    totalInterest = 0;

                   

                    loanAmount = Convert.ToDouble(this.txtLoanAmount.Text);
                    //repaymentPeriod = Convert.ToDouble(RepaymentPeriod());
                    repaymentPeriod = Convert.ToDouble(this.ddlRepaymentPeriod.SelectedItem.Text);
                    interest = Convert.ToDouble(this.lblInterestRate.Text) / 100;

                    if (this.IsAmortisedLoan(this.ddlLoanTypes.SelectedValue))
                    {
                        pmt = Financial.Pmt(interest, repaymentPeriod, -loanAmount, 0, DueDate.EndOfPeriod);
                    }
                    else
                    {
                        pmt = loanAmount / repaymentPeriod;
                    }

                    this.lblMonthlyRepayment.Text = MyClass.FormatNumber(pmt);

                    double interest2 = 0, loanRepayment = 0, loanBalance = 0;

                    int lineNo = 0;

                    DateTime date = DateTime.Now;

                    #region
                    //addition (this.ddlRepaymentPeriod.SelectedItem.Text)
                    for (int i = 1; i <= Convert.ToInt32(this.ddlRepaymentPeriod.SelectedItem.Text); i++)
                    {
                        lineNo = i;
                        interest2 = (interest * loanAmount);
                        totalInterest += interest2;

                        if (this.IsAmortisedLoan(this.ddlLoanTypes.SelectedValue))
                        {
                            loanRepayment = pmt - (interest * loanAmount);
                        }
                        else
                        {
                            loanRepayment = pmt + interest2;
                        }

                        if (netIncome - (basicPay / 3) < 0)
                        {
                            this.lblError.Text = "Your payslip cannot allow any loan deduction.";
                            Message(this.lblError.Text);
                        }

                        if (netIncome - (basicPay / 3) < loanRepayment)
                        {
                            if (netIncome - (basicPay / 3) < 0)
                            {
                                this.lblError.Text = "QUALIFICATIOIN REMARKS:<br><br>You cannot qualify for a loan of " + MyClass.FormatNumber(Convert.ToDouble(this.txtLoanAmount.Text)) +
                                    " because your income available for loan repayment is negative i.e. " + MyClass.FormatNumber(Convert.ToDouble(this.lblAmountAvailable.Text)) + " Please reduce the loan amount.";

                            }
                            else
                            {
                                this.lblError.Text = "QUALIFICATIOIN REMARKS:<br><br>You cannot qualify for a loan of " + MyClass.FormatNumber(Convert.ToDouble(this.txtLoanAmount.Text)) +
                                    " because your income available for loan repayment is only " + MyClass.FormatNumber(Convert.ToDouble(this.lblAmountAvailable.Text)) + " Please reduce the loan amount.";
                            }

                            string Msg_ = String.Format("Your pay slip can only allow a deduction of {0} as loan principal and interest.", MyClass.FormatNumber(Convert.ToDouble(this.lblAmountAvailable.Text)));
                            Message(Msg_);
                            this.txtLoanAmount.Focus();
                        }

                        if (this.IsAmortisedLoan(this.ddlLoanTypes.SelectedValue))
                        {
                            loanBalance = loanAmount - loanRepayment;
                        }
                        else
                        {
                            loanBalance = loanAmount - pmt;
                        }

                        if (loanBalance < 1)
                        {
                            loanBalance = 0;
                        }

                        #region  Save To DB

                        if (this.IsAmortisedLoan(this.ddlLoanTypes.SelectedValue))
                        {
                            using (SqlConnection conn = MyClass.getconnToNAV())
                            {
                                string A = "INSERT INTO [" + MyClass.CompanyName + "$Online Loan Calculator New]" +
                                           "([User ID],[Month],[Principle Amount],[Loan Repayment]," +
                                           "[Interest],[Total Deduction],[Loan Balance],[Period]) VALUES(@Member_No,@Month,@Principle_Amount,@Loan_Repayment,@Interest,@Total_Deduction,@Loan_Balance,@Period)";

                                SqlCommand command = new SqlCommand(A, conn);
                                command.Parameters.AddWithValue("@Member_No", Member_No_);
                                command.Parameters.AddWithValue("@Month", i.ToString());
                                command.Parameters.AddWithValue("@Principle_Amount", MyClass.FormatNumber(loanAmount));
                                command.Parameters.AddWithValue("@Loan_Repayment", MyClass.FormatNumber(pmt));
                                command.Parameters.AddWithValue("@Interest", MyClass.FormatNumber(interest * loanAmount));
                                command.Parameters.AddWithValue("@Total_Deduction", MyClass.FormatNumber(loanRepayment));
                                command.Parameters.AddWithValue("@Loan_Balance", MyClass.FormatNumber(loanBalance));
                                command.Parameters.AddWithValue("@Period", String.Format("{0}-{1}", new DateTimeFormatInfo().GetAbbreviatedMonthName(date.Month), date.Year));
                                command.ExecuteNonQuery();
                                conn.Close();
                            }

                        }
                        else
                        {
                            using (SqlConnection conn = MyClass.getconnToNAV())
                            {
                                string B = "INSERT INTO [" + MyClass.CompanyName + "$Online Loan Calculator New]" +
                                           "([User ID],[Month],[Principle Amount],[Loan Repayment]," +
                                           "[Interest],[Total Deduction],[Loan Balance],[Period]) VALUES(@Member_No,@Month,@Principle_Amount,@Loan_Repayment,@Interest,@Total_Deduction,@Loan_Balance,@Period)";

                                SqlCommand command = new SqlCommand(B, conn);
                                command.Parameters.AddWithValue("@Member_No", Member_No_);
                                command.Parameters.AddWithValue("@Month", i.ToString());
                                command.Parameters.AddWithValue("@Principle_Amount", MyClass.FormatNumber(loanAmount));
                                command.Parameters.AddWithValue("@Loan_Repayment", MyClass.FormatNumber(loanRepayment));
                                command.Parameters.AddWithValue("@Interest", MyClass.FormatNumber(interest * loanAmount));
                                command.Parameters.AddWithValue("@Total_Deduction", MyClass.FormatNumber(pmt));
                                command.Parameters.AddWithValue("@Loan_Balance", MyClass.FormatNumber(loanBalance));
                                command.Parameters.AddWithValue("@Period", String.Format("{0}-{1}", new DateTimeFormatInfo().GetAbbreviatedMonthName(date.Month), date.Year));
                                command.ExecuteNonQuery();

                                conn.Close();
                            }

                        }

                        if (this.IsAmortisedLoan(this.ddlLoanTypes.SelectedValue))
                        {
                            loanAmount -= loanRepayment;
                        }
                        else
                        {
                            loanAmount -= pmt;
                        }

                        date = date.AddMonths(1);
                        #endregion
                    }
                    #endregion

                    lineNo++;
                    //totals

                    #region Save Totals

                    using (SqlConnection conn = MyClass.getconnToNAV())
                    {
                        string A = "INSERT INTO [" + MyClass.CompanyName + "$Online Loan Calculator New]" +
                                   "([User ID],[Month],[Principle Amount],[Loan Repayment]," +
                                   "[Interest],[Total Deduction],[Loan Balance],[Period]) VALUES(@Member_No,@Month,@Principle_Amount,@Loan_Repayment,@Interest,@Total_Deduction,@Loan_Balance,@Period)";

                        SqlCommand command = new SqlCommand(A, conn);
                        command.Parameters.AddWithValue("@Member_No", Member_No_);
                        command.Parameters.AddWithValue("@Month", lineNo); //
                        command.Parameters.AddWithValue("@Principle_Amount", "");
                        command.Parameters.AddWithValue("@Loan_Repayment", MyClass.FormatNumber(this.txtLoanAmount.Text));
                        command.Parameters.AddWithValue("@Interest", MyClass.FormatNumber(totalInterest));
                        command.Parameters.AddWithValue("@Total_Deduction", MyClass.FormatNumber(totalInterest + Convert.ToDouble(this.txtLoanAmount.Text)));
                        command.Parameters.AddWithValue("@Loan_Balance", "");
                        command.Parameters.AddWithValue("@Period", "TOTALS:");
                        // command.ExecuteNonQuery();

                        conn.Close();
                    }
                    #endregion

                    //btnPrint.Visible = true;

                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                    Message(ex.ToString());
                }
            }

        }
        #endregion


        #region ddlLoanTypes_SelectedIndexChanged

        protected void ddlLoanTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Member_No_ = Session["Member_No"].ToString().Trim();
                //this.btnPrint.Enabled = false;
                //this.btnPrint.Visible = false;
                //this.lblTitle.Visible = false;

                this.ddlRepaymentPeriod.Items.Clear();

                for (int i = 1; i <= this.MaximumRepayment(this.ddlLoanTypes.SelectedValue); i++)
                {
                    this.ddlRepaymentPeriod.Items.Add(i.ToString());
                }
                //additions
                this.ddlRepaymentPeriod.SelectedIndex = this.MaximumRepayment(this.ddlLoanTypes.SelectedValue) - 1;

                if (this.MaximumLoanAmount(this.ddlLoanTypes.SelectedValue) > 0)
                {
                    this.lblError.Text = "Maximum loan amount for loan [" + this.ddlLoanTypes.SelectedItem.Text + "] is KSh. " +
                        MyClass.FormatNumber(this.MaximumLoanAmount(this.ddlLoanTypes.SelectedValue));
                }
                else
                {
                    this.lblError.Text =
                        String.Format("Loan [{0}] has no set maximum amount.", this.ddlLoanTypes.SelectedItem.Text);
                }

                //this.lblInterestRate.Text = MyClass.FormatNumber((this.InterestRate(this.ddlLoanTypes.SelectedValue) / 12).ToString());
                this.lblInterestRate.Text = Math.Round((InterestRate(ddlLoanTypes.SelectedValue) / 12), 5).ToString();
                //this.lblInterestRate.Text = (this.InterestRate(this.ddlLoanTypes.SelectedValue) / 12).ToString();

                this.btnCalculate.Visible = true;

                if (this.ddlLoanTypes.SelectedValue != "NORM")
                {
                    //this.lblError0.Text =
                    //    "<br>Current Deposit: " + MyClass.FormatNumber(MyClass.CurrentShares(Member_No_)) +
                    //    "<br>Current Deposit X " + this.LoanMultiplier(this.ddlLoanTypes.SelectedValue) + ": " + MyClass.FormatNumber(MyClass.CurrentShares(Member_No_) * this.LoanMultiplier(this.ddlLoanTypes.SelectedValue)) +
                    //    "<br>Outstanding TOTAL Loan Balance: " + MyClass.FormatNumber(MyClass.OutstandingLoanBalance(Member_No_)) +
                    //    "<br>Qualified Loan Amount: " + MyClass.FormatNumber((MyClass.CurrentShares(Member_No_) * this.LoanMultiplier(this.ddlLoanTypes.SelectedValue)) - MyClass.OutstandingLoanBalance(Member_No_)) +
                    //    "<p><p>";
                }
                else if (this.NormalOutstandingLoanNo(Member_No_) != "")
                {
                    //this.lblError0.Text =
                    //    "<br>Current Deposit: " + MyClass.FormatNumber(MyClass.CurrentShares(Member_No_)) +
                    //    "<br>Current Deposit X " + this.LoanMultiplier(this.ddlLoanTypes.SelectedValue) + ": " + MyClass.FormatNumber(MyClass.CurrentShares(Member_No_) * this.LoanMultiplier(this.ddlLoanTypes.SelectedValue)) +
                    //    "<br>Outstanding TOTAL Loan Balance: " + MyClass.FormatNumber(MyClass.OutstandingLoanBalance(Member_No_)) +
                    //    "<br>Approved NORMAL Loan Amount: " + MyClass.FormatNumber(this.NormalLoanApprovedAmount(this.NormalOutstandingLoanNo(Member_No_))) +
                    //    "<br>Outstanding NORMAL Loan Amount: " + MyClass.FormatNumber(MyClass.OutstandingSpecificLoanBalance(this.NormalOutstandingLoanNo(Member_No_))) +
                    //    "<br>PERCENTAGE Outstanding NORMAL Loan Balance: " + MyClass.FormatNumber(MyClass.OutstandingSpecificLoanBalance(this.NormalOutstandingLoanNo(Member_No_)) * 100 / this.NormalLoanApprovedAmount(this.NormalOutstandingLoanNo(Member_No_))) + "%";


                    //if paid 2/3 then qualify else deny
                    if (MyClass.OutstandingSpecificLoanBalance(this.NormalOutstandingLoanNo(Member_No_)) / this.NormalLoanApprovedAmount(this.NormalOutstandingLoanNo(Member_No_)) <= 2 / 3)
                    {
                        this.lblError0.Text +=
                            "<br>Qualified Loan Amount: " + MyClass.FormatNumber((MyClass.CurrentShares(Member_No_) * this.LoanMultiplier(this.ddlLoanTypes.SelectedValue)) - MyClass.OutstandingLoanBalance(Member_No_)) +
                            "<p><p>";
                    }
                    else
                    {
                        this.btnCalculate.Visible = false;

                        this.lblError.Text =
                            "<br>YOU CANNOT QUALIFY FOR A NORMAL LOAN AS THE PREVIOUS NORMAL LOAN BALANCE IS GREATER THAN 2 THIRDS.".ToLower() +
                            "<br>THE NORMAL LOAN BALANCE SHOULD BE LESS THAN 2 THIRDS OF THE AMOUNT APPROVED I.E.".ToLower() + MyClass.FormatNumber(this.NormalLoanApprovedAmount(this.NormalOutstandingLoanNo(Member_No_)) * 1 / 3);

                        string strScript = null;
                        strScript = "<script>alert('" +
                            "YOU CANNOT QUALIFY FOR A NORMAL LOAN AS THE PREVIOUS NORMAL LOAN BALANCE IS GREATER THAN 2 THIRDS." +
                            " THE NORMAL LOAN BALANCE SHOULD BE LESS THAN 2 THIRDS OF THE AMOUNT APPROVED I.E." + MyClass.FormatNumber(this.NormalLoanApprovedAmount(this.NormalOutstandingLoanNo(Member_No_)) * 1 / 3) +
                            "')</script>";
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "blah", strScript);

                    }

                }




            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        #endregion

        #region Get Load Loan Types
        //protected void LoadLoanTypes()
        //{
        //    try
        //    {
        //        ListItem li = null;
        //        this.ddlLoanTypes.Items.Clear();

        //        using (SqlConnection conn = MyClass.getconnToNAV())
        //        {
        //            string A = String.Format("SELECT [Product Description],Code FROM [{0}$Loan Product Types] WHERE NOT [Product Description] = '' order by [Product Description]", MyClass.CompanyName);
        //            SqlCommand command = new SqlCommand(A, conn);
        //            using (SqlDataReader dr = command.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                    while (dr.Read())
        //                    {
        //                        if (dr["Product Description"].ToString().Trim() != "")
        //                        {
        //                            li = new ListItem(
        //                                dr["Product Description"].ToString(),
        //                                dr["Code"].ToString()
        //                                );
        //                            this.ddlLoanTypes.Items.Add(li);
        //                        }
        //                    }
        //            }

        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Clear();
        //    }
        //}

        protected void LoadLoanTypes()
        {
            try
            {
                ListItem li = null;
                this.ddlLoanTypes.Items.Clear();

                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Product Description],[Product ID], [Product Class Type] FROM [{0}$Product Factory] WHERE [Product Class Type] = 1 AND [Product ID] <> 'A04' AND [Product ID] <> 'A14' order by [Product Description]", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                if (dr["Product Description"].ToString().Trim() != "")
                                {
                                    li = new ListItem(
                                        dr["Product Description"].ToString(),
                                        dr["Product ID"].ToString()
                                        );
                                    this.ddlLoanTypes.Items.Add(li);
                                }
                            }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        #endregion

        #region Get Loan Multiplier

        //protected int LoanMultiplier(string loanType)
        //{
        //    return 3;
        //    int i = 0;

        //    try
        //    {
        //        using (SqlConnection conn = MyClass.getconnToNAV())
        //        {
        //            string A = String.Format("SELECT [Loan Multiplier] FROM [{0}$Loan Product Types] WHERE Code=@CODE", MyClass.CompanyName);
        //            SqlCommand command = new SqlCommand(A, conn);
        //            command.Parameters.AddWithValue("@CODE", loanType);

        //            using (SqlDataReader dr = command.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                    while (dr.Read())
        //                    {
        //                        i = Convert.ToInt32(dr["Loan Multiplier"].ToString().Trim());
        //                    }
        //            }

        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Clear();
        //    }

        //    return i;
        //}

        protected int LoanMultiplier(string loanType)
        {
            return 3;
            int i = 0;

            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Shares Multiplier] FROM [{0}$Product Factory] WHERE [Product ID]=@CODE", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CODE", loanType);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                i = Convert.ToInt32(dr["Shares Multiplier"].ToString().Trim());
                            }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return i;
        }
        #endregion

        #region Get Loan Maximum Repayment

        //protected int MaximumRepayment(string loanType)
        //{
        //    int i = 0;
        //    try
        //    {
        //        using (SqlConnection conn = MyClass.getconnToNAV())
        //        {
        //            string A = String.Format("SELECT [No of Installment] FROM [{0}$Loan Product Types] WHERE Code=@CODE", MyClass.CompanyName);
        //            SqlCommand command = new SqlCommand(A, conn);
        //            command.Parameters.AddWithValue("@CODE", loanType);
        //            using (SqlDataReader dr = command.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                    while (dr.Read())
        //                    {
        //                        i = Convert.ToInt32(dr["No of Installment"].ToString().Trim());
        //                    }
        //            }

        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Clear();
        //    }

        //    return i;
        //}

        protected int MaximumRepayment(string loanType)
        {
            int i = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Default Installments] FROM [{0}$Product Factory] WHERE [Product ID]=@CODE", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CODE", loanType);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                i = Convert.ToInt32(dr["Default Installments"].ToString().Trim());
                            }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return i;
        }
        #endregion

        #region Get Maximum Loan Amount

        //protected double MaximumLoanAmount(string loanType)
        //{
        //    double d = 0;
        //    try
        //    {
        //        using (SqlConnection conn = MyClass.getconnToNAV())
        //        {
        //            string A = String.Format("SELECT [Max_ Loan Amount] FROM [{0}$Loan Product Types] WHERE Code=@CODE", MyClass.CompanyName);
        //            SqlCommand command = new SqlCommand(A, conn);
        //            command.Parameters.AddWithValue("@CODE", loanType);
        //            using (SqlDataReader dr = command.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                    while (dr.Read())
        //                    {
        //                        d = Convert.ToDouble(dr["Max_ Loan Amount"].ToString().Trim());
        //                    }
        //            }

        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Clear();
        //    }

        //    return d;
        //}

        protected double MaximumLoanAmount(string loanType)
        {
            double d = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Maximum Loan Amount] FROM [{0}$Product Factory] WHERE [Product ID]=@CODE", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CODE", loanType);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                d = Convert.ToDouble(dr["Maximum Loan Amount"].ToString().Trim());
                            }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return d;
        }
        #endregion

        #region Get InterestRate

        //protected double InterestRate(string loanType)
        //{
        //    double d = 0;
        //    try
        //    {
        //        using (SqlConnection conn = MyClass.getconnToNAV())
        //        {
        //            string A = String.Format("SELECT [Interest rate] FROM [{0}$Loan Product Types] WHERE Code=@CODE", MyClass.CompanyName);
        //            SqlCommand command = new SqlCommand(A, conn);
        //            command.Parameters.AddWithValue("@CODE", loanType);
        //            using (SqlDataReader dr = command.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                    while (dr.Read())
        //                    {
        //                        d = Convert.ToDouble(dr["Interest rate"].ToString().Trim());
        //                    }
        //            }

        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Clear();
        //    }

        //    return d;
        //}

        protected double InterestRate(string loanType)
        {
            double d = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Interest Rate] FROM [{0}$Product Factory] WHERE [Product ID]=@CODE", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CODE", loanType);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                d = Convert.ToDouble(dr["Interest Rate"].ToString().Trim());
                            }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return d;
        }
        #endregion

        #region Get Authorized Loan Amount

        //protected double AuthorizedLoanAmount(string loanType)
        //{
        //    double d = 0;
        //    try
        //    {
        //        using (SqlConnection conn = MyClass.getconnToNAV())
        //        {
        //            string A = String.Format("SELECT [Max_ Loan Amount] FROM [{0}$Loan Product Types] WHERE Code=@CODE", MyClass.CompanyName);
        //            SqlCommand command = new SqlCommand(A, conn);
        //            command.Parameters.AddWithValue("@CODE", loanType);
        //            using (SqlDataReader dr = command.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                    while (dr.Read())
        //                    {
        //                        d = Convert.ToDouble(dr["Max_ Loan Amount"].ToString().Trim());
        //                    }
        //            }

        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Clear();
        //    }

        //    return d;
        //}

        protected double AuthorizedLoanAmount(string loanType)
        {
            double d = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Maximum Loan Amount] FROM [{0}$Product Factory] WHERE [Product ID]=@CODE", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CODE", loanType);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                d = Convert.ToDouble(dr["Maximum Loan Amount"].ToString().Trim());
                            }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return d;
        }
        #endregion

        #region Get Is Amortised Loan

        //protected bool IsAmortisedLoan(string loanType)
        //{
        //    bool b = false;
        //    return true;
        //    try
        //    {
        //        using (SqlConnection conn = MyClass.getconnToNAV())
        //        {
        //            string A = String.Format("SELECT [Is Amortised] FROM [{0}$Loan Product Types] WHERE [Is Amortised]=1 AND Code=@CODE", MyClass.CompanyName);
        //            SqlCommand command = new SqlCommand(A, conn);
        //            command.Parameters.AddWithValue("@CODE", loanType);
        //            using (SqlDataReader dr = command.ExecuteReader())
        //            {
        //                if (dr.HasRows)
        //                {
        //                    b = dr.HasRows;
        //                }
        //            }

        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Clear();
        //    }

        //    return b;
        //}

        protected bool IsAmortisedLoan(string loanType)
        {
            bool b = false;
            //return true;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Interest Calculation Method] FROM [{0}$Product Factory] WHERE [Interest Calculation Method]=0 AND [Product ID]=@CODE", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CODE", loanType);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            b = dr.HasRows;
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return b;
        }
        #endregion

        #region GET Normal Outstanding LoanNo

        private string NormalOutstandingLoanNo(string Member_No_)
        {
            string s = "";
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {

                    string A = "SELECT distinct [" + MyClass.CompanyName + "$Loans].[Loan  No_]" +
                        " FROM [" + MyClass.CompanyName + "$Cust_ Ledger Entry]" +
                        " inner join [" + MyClass.CompanyName + "$Loans]" +
                        " on [" + MyClass.CompanyName + "$Cust_ Ledger Entry].[Loan No]=[" +
                        MyClass.CompanyName + "$Loans].[Loan  No_]" +
                        " where ([Customer No_] = @Member_No_ or" +
                        " [Customer No_] = @Member_No_)" +
                        " and ([Transaction Types] = 2 or [Transaction Types] = 3 or [Transaction Types] = 5)" +
                        " and [" + MyClass.CompanyName + "$Loans].[Loan Product Type] = 'NORM'" +
                        " order by [Loan  No_] ASC ;";

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@Member_No_", Member_No_);
                    using (SqlDataReader dr1 = command.ExecuteReader())
                    {
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            {
                                string loan = dr1["Loan  No_"].ToString();

                                if (MyClass.OutstandingSpecificLoanBalance(loan) > 0)
                                {
                                    return loan;
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return s;
        }

        #endregion

        #region Get Normal Loan Approved Amount

        private double NormalLoanApprovedAmount(string loanNo)
        {
            double d = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = "SELECT [Approved Amount] FROM [" + MyClass.CompanyName + "$Loans]" +
                        " WHERE ([Loan  No_] = @loanNo)";

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@loanNo", loanNo);
                    using (SqlDataReader dr1 = command.ExecuteReader())
                    {
                        if (dr1.HasRows)
                            while (dr1.Read())
                            {
                                d = Convert.ToDouble(dr1["Approved Amount"]);
                            }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return d;
        }

        #endregion

        #region btnPrint_Click

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Message("Print");
        }


        #endregion

        //protected string RepaymentPeriod()
        //{
        //    string returnedperiod = this.ddlRepaymentPeriod.SelectedItem.Text;
        //    return returnedperiod;
        //}


        #region Javascript Message

        public void Message(string strMsg)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(strMsg);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("}");
        }

        #endregion
        }
    }

