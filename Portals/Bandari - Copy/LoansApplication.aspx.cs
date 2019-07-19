using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using Bandari_Sacco.controller;


namespace Bandari_Sacco
{
    public partial class LoansApplication : System.Web.UI.Page
    {

        #region Page_Load

        string filePath = "", fileName = "", Description = "", PathToUpload = "", Uploaded_By = "", Pin_No = "", fileExt = "", strPath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null || string.IsNullOrEmpty(Session["Member_No"].ToString()))
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
            else
            {


                string LoanApplicationNo = string.Empty;

                if (Request.QueryString["LNo"] != null)
                {
                    LoanApplicationNo = Request.QueryString["LNo"];
                }



                if (!IsPostBack)
                {

                    string ChangedPassword = "";
                    ChangedPassword = MyClass.CheckIfChangedPassword(Session["Member_No"].ToString());

                    this.txtBasicPay.ToolTip = MyClass.getMembersNames(Session["Member_No"].ToString()) +
                           ", Please enter your BASIC PAY.";
                    this.txtLoanAmount.ToolTip = MyClass.getMembersNames(Session["Member_No"].ToString()) +
                        ", Please enter the LOAN AMOUNT.";
                    this.txtTotalAllowances.ToolTip = MyClass.getMembersNames(Session["Member_No"].ToString()) +
                        ", Please enter your TOTAL ALLOWANCES.";
                    this.txtTotalDeductions.ToolTip = MyClass.getMembersNames(Session["Member_No"].ToString()) +
                        ", Please enter your TOTAL DEDUCTIONS.";









                    if (Request.QueryString["LNo"] != null)
                    {
                        LoanApplicationNo = Request.QueryString["LNo"];

                        using (SqlConnection conn = MyClass.getconnToNAV())
                        {

                            string s_G = String.Format("SELECT [Loan Type],convert(DOUBLE PRECISION,[Interest Rate]) as [Interest Rate],[Repayment Period],convert(DOUBLE PRECISION,[Basic Pay]) as [Basic Pay],convert(DOUBLE PRECISION,[Total Allowances]) as [Total Allowances],convert(DOUBLE PRECISION,[TotalDeduction]) as [TotalDeduction],convert(DOUBLE PRECISION,[Loan Amount]) as [Loan Amount] FROM [{0}$Online Loan Application] WHERE [Application No] = @LoanApplicationNo ", MyClass.CompanyName);
                            SqlCommand command_G = new SqlCommand(s_G, conn);
                            command_G.Parameters.AddWithValue("@LoanApplicationNo", LoanApplicationNo);
                            using (SqlDataReader dr1_G = command_G.ExecuteReader())
                            {

                                if (dr1_G.HasRows)
                                {
                                    string Loan_Type = string.Empty;
                                    string Repayment_Period = string.Empty;
                                    dr1_G.Read();
                                    Loan_Type = dr1_G["Loan Type"].ToString();

                                    LoadLoanTypesByID(Loan_Type, conn);

                                    txtBasicPay.Text = dr1_G["Basic Pay"].ToString();
                                    txtTotalAllowances.Text = dr1_G["Total Allowances"].ToString();
                                    txtTotalDeductions.Text = dr1_G["TotalDeduction"].ToString();
                                    txtLoanAmount.Text = dr1_G["Loan Amount"].ToString();
                                    Repayment_Period = dr1_G["Repayment Period"].ToString();

                                    ddlRepaymentPeriod.Visible = false;
                                    lblRepaymentPeriod.Visible = true;
                                    lblRepaymentPeriod.Text = Repayment_Period;
                                    lblInterestRate.Text = dr1_G["Interest Rate"].ToString();

                                }
                            }

                            conn.Close();
                        }


                    }
                    else
                    {


                        LoadLoanTypes();

                        this.ddlLoanTypes_SelectedIndexChanged(null, null);
                    }



                    //if (ChangedPassword == "0")
                    //{
                    //    Response.Redirect("Change_Password.aspx?action=ChangePassword");
                    //}
                    //else
                    //{


                    //}
                }
            }


        }
        #endregion

        #region btn Calculate_Click

        protected void btnCalculate_Click(object sender, EventArgs e)
        {

            lblError.Text = "";
            //lblError0.Text = "";

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
                    // this.lblThirdBasic.Text = MyClass.FormatNumber(basicPay / 3);
                    //  this.lblAmountAvailable.Text = MyClass.FormatNumber(netIncome - (basicPay / 3));

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

                    // this.lblMonthlyRepayment.Text = MyClass.FormatNumber(pmt);

                    double interest2 = 0, loanRepayment = 0, loanBalance = 0;

                    int lineNo = 0;

                    DateTime date = DateTime.Now;

                    #region

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

                            }
                            else
                            {
                            }


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

                this.ddlRepaymentPeriod.SelectedIndex = this.MaximumRepayment(this.ddlLoanTypes.SelectedValue) - 1;

                if (this.MaximumLoanAmount(this.ddlLoanTypes.SelectedValue) > 0)
                {
                    //this.lblError.Text = "Maximum loan amount for loan [" + this.ddlLoanTypes.SelectedItem.Text + "] is KSh. " +
                    //    MyClass.FormatNumber(this.MaximumLoanAmount(this.ddlLoanTypes.SelectedValue));
                }
                else
                {
                    //this.lblError.Text =
                    //    String.Format("Loan [{0}] has no set maximum amount.", this.ddlLoanTypes.SelectedItem.Text);
                }


                string myLoanType = ddlLoanTypes.SelectedValue;
                string LoanType = CheckLoanType(myLoanType);
                if (LoanType == "1")
                {
                    this.lblInterestRate.Text = MyClass.FormatNumber((this.InterestRate(this.ddlLoanTypes.SelectedValue)).ToString());

                }
                else
                {
                    this.lblInterestRate.Text = MyClass.FormatNumber((this.InterestRate(this.ddlLoanTypes.SelectedValue) / 12).ToString());
                }

                if (this.ddlLoanTypes.SelectedValue != "NORM")
                {

                }
                else if (this.NormalOutstandingLoanNo(Member_No_) != "")
                {


                    //if paid 2/3 then qualify else deny
                    if (MyClass.OutstandingSpecificLoanBalance(this.NormalOutstandingLoanNo(Member_No_)) / this.NormalLoanApprovedAmount(this.NormalOutstandingLoanNo(Member_No_)) <= 2 / 3)
                    {

                    }
                    else
                    {

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

        private string CheckLoanType(string myLoanType)
        {
            string loanType = "";
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {

                    string s = String.Format("SELECT Source FROM [{0}$Loan Product Types] WHERE Code = @myLoanType ;", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@myLoanType", myLoanType);


                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            loanType = dr["Source"].ToString();
                        }

                    }

                }

            }
            catch (Exception Ex)
            {
                Ex.Data.Clear();
            }

            return loanType;
        }


        #endregion

        #region Get Load Loan Types
        protected void LoadLoanTypes()
        {
            try
            {
                ListItem li = null;
                this.ddlLoanTypes.Items.Clear();

                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Product Description],Code FROM [{0}$Loan Product Types] WHERE NOT [Product Description] = '' order by [Product Description]", MyClass.CompanyName);
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
                                        dr["Code"].ToString()
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

        #region Get Load Loan Types
        protected void LoadLoanTypesByID(string Loan_Type, SqlConnection conn)
        {
            try
            {
                ListItem li = null;
                this.ddlLoanTypes.Items.Clear();


                string A = String.Format("SELECT [Product Description],Code FROM [{0}$Loan Product Types] WHERE Code=@Code", MyClass.CompanyName);
                SqlCommand command = new SqlCommand(A, conn);
                command.Parameters.AddWithValue("@Code", Loan_Type);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            if (dr["Product Description"].ToString().Trim() != "")
                            {
                                li = new ListItem(
                                    dr["Product Description"].ToString(),
                                    dr["Code"].ToString()
                                    );
                                this.ddlLoanTypes.Items.Add(li);
                            }
                        }
                }


            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        #endregion

        #region Get Loan Multiplier

        protected int LoanMultiplier(string loanType)
        {
            return 3;
            int i = 0;

            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Loan Multiplier] FROM [{0}$Loan Product Types] WHERE Code=@CODE", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CODE", loanType);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                i = Convert.ToInt32(dr["Loan Multiplier"].ToString().Trim());
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

        protected int MaximumRepayment(string loanType)
        {
            int i = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [No of Installment] FROM [{0}$Loan Product Types] WHERE Code=@CODE", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CODE", loanType);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                i = Convert.ToInt32(dr["No of Installment"].ToString().Trim());
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

        protected double MaximumLoanAmount(string loanType)
        {
            double d = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Max_ Loan Amount] FROM [{0}$Loan Product Types] WHERE Code=@CODE", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CODE", loanType);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                d = Convert.ToDouble(dr["Max_ Loan Amount"].ToString().Trim());
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

        protected double InterestRate(string loanType)
        {
            double d = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Interest rate] FROM [{0}$Loan Product Types] WHERE Code=@CODE", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CODE", loanType);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                d = Convert.ToDouble(dr["Interest rate"].ToString().Trim());
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

        protected double AuthorizedLoanAmount(string loanType)
        {
            double d = 0;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Max_ Loan Amount] FROM [{0}$Loan Product Types] WHERE Code=@CODE", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@CODE", loanType);
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                            while (dr.Read())
                            {
                                d = Convert.ToDouble(dr["Max_ Loan Amount"].ToString().Trim());
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

        protected bool IsAmortisedLoan(string loanType)
        {
            bool b = false;
            return true;
            try
            {
                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = String.Format("SELECT [Is Amortised] FROM [{0}$Loan Product Types] WHERE [Is Amortised]=1 AND Code=@CODE", MyClass.CompanyName);
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
        }

        #endregion

        void SaveLoanDetails()
        {

        }

        protected void BtnAddNewPartner_Click(object sender, EventArgs e)
        {

            string Member_No_ = "0";
            string E_Mail = "0";
            string Phone_No_ = "0";
            string Name = "0";
            string EmploymentNo = "0";
            string Loan_Type = "0";
            string Loan_Amout = "0";
            string Repayment_Period = "0";
            string Interest_Rate = "0";
            string HomeAddress = "0";
            string District = "0";
            string Division = "0";
            string Location = "0";
            string SubLocation = "0";
            string DateOfBirth = "0";
            string EmployerAddress = "0";
            string Station = "0";
            string Designation = "0";
            string Position_Held = "0";
            string BankAccount_No = "0";
            string BankName = "0";
            string BankBranch = "0";

            double GrossSalary = 0;
            string LoanType = "0";
            double Shares_Contribution = 0;
            double BasicPay = 0;
            double Total_Allowances = 0;
            double Total_Deductions = 0;
            string Application_No = "";
            string InterestRate = "";

            Loan_Type = ddlLoanTypes.SelectedItem.Value;
            Loan_Amout = txtLoanAmount.Text.Trim();
            BasicPay = Convert.ToDouble(txtBasicPay.Text.Trim());
            Total_Allowances = Convert.ToDouble(txtTotalAllowances.Text.Trim());

            string LoanApplicationNo = string.Empty;

            if (Request.QueryString["LNo"] != null)
            {
                LoanApplicationNo = Request.QueryString["LNo"];
                Repayment_Period = lblRepaymentPeriod.Text;
            }
            else
            {
                Repayment_Period = ddlRepaymentPeriod.SelectedItem.Value;
            }
            Total_Deductions = Convert.ToDouble(txtTotalDeductions.Text.Trim());

            InterestRate = lblInterestRate.Text.Trim();

            GrossSalary = ((BasicPay + Total_Allowances) - Total_Deductions);


            Member_No_ = Session["Member_No"].ToString().Trim();

            try
            {


                Shares_Contribution = Convert.ToDouble(MyClass.FormatNumber(MyClass.CurrentShares(Member_No_)));

                double basicPay = 0, totalAllowance = 0, totalDeductions = 0, netIncome = 0;
                basicPay = Convert.ToDouble(this.txtBasicPay.Text);
                totalAllowance = Convert.ToDouble(this.txtTotalAllowances.Text);
                totalDeductions = Convert.ToDouble(this.txtTotalDeductions.Text);
                netIncome = basicPay + totalAllowance - totalDeductions;

                double outStandingLoanBalance = MyClass.OutstandingSpecificLoanBalanceWithLoanType(Loan_Type, Member_No_);


                if (netIncome - (basicPay / 3) < 0)
                {
                    this.lblError.Text = "Your pay slip cannot allow any loan deduction.";
                    Message(this.lblError.Text);
                }
                else if (outStandingLoanBalance > 1)
                {
                    this.lblError.Text = "Your has an outstanding loan balance of this loan type.";
                    Message(this.lblError.Text);
                }
                else
                {

                    if (FileUploadDownloads.PostedFile.FileName.Length > 0)
                    {


                        filePath = FileUploadDownloads.PostedFile.FileName;
                        fileName = FileUploadDownloads.FileName;
                        fileExt = Path.GetExtension(fileName).Split('.')[1].ToLower();


                        if (fileExt == "pdf" || fileExt == "rar" || fileExt == "zip")
                        {

                            lblError.Text = "";

                            #region

                            using (SqlConnection conn = MyClass.getconnToNAV())
                            {
                                string s_ = String.Format("SELECT [Application No] FROM [{0}$Online Loan Application] WHERE [Membership No] = @Member_No AND [Approved]=0 AND [Loan Type]=@LoanType;", MyClass.CompanyName);
                                SqlCommand command_ = new SqlCommand(s_, conn);
                                command_.Parameters.AddWithValue("@Member_No", Member_No_);
                                command_.Parameters.AddWithValue("@LoanType", Loan_Type);
                                using (SqlDataReader dr1_ = command_.ExecuteReader())
                                {
                                    if (dr1_.HasRows == false)
                                    {
                                        //   Application_No = dr1_["Application No"].ToString();


                                        string s = String.Format("SELECT * FROM [{0}$Customer] WHERE [No_] = @Member_No;", MyClass.CompanyName);
                                        SqlCommand command = new SqlCommand(s, conn);
                                        command.Parameters.AddWithValue("@Member_No", Member_No_);

                                        using (SqlDataReader dr1 = command.ExecuteReader())
                                        {
                                            if (dr1.HasRows)
                                            {
                                                dr1.Read();
                                                E_Mail = dr1["E-Mail"].ToString();
                                                Phone_No_ = dr1["Phone No_"].ToString();
                                                EmploymentNo = dr1["Staff No1"].ToString();
                                                HomeAddress = dr1["Home  Address"].ToString();
                                                District = dr1["District"].ToString();
                                                Division = dr1["Division_Department"].ToString();
                                                Location = dr1["Location"].ToString();
                                                SubLocation = dr1["Sub-Location"].ToString();
                                                DateOfBirth = dr1["Date of Birth"].ToString();
                                                EmployerAddress = dr1["Employer Code"].ToString();
                                                Station = dr1["Station_Section"].ToString();
                                                Designation = dr1["Designation"].ToString();
                                                //  Position_Held = dr1["Name"].ToString();
                                                Name = dr1["Name"].ToString();
                                            }
                                        }
                                        DateTime applicationDate = DateTime.Today;

                                        string SQL = " INSERT INTO [" + MyClass.CompanyName + "$Online Loan Application] " +
                                   "([Member Names] ,[Home Address] ,[District] ,[Application Date] ,[Membership No] ,[Employment No] ,[Division] ,[Location] ,[Sub Location] ,[Date of Birth]" +
                                   ",[Employer and Address] ,[Station] ,[Designation] ,[Gross Salary]  ,[Position Held]   ,[Telephone]  ,[Email] ,[Bank Account No] ,[Bank Name]" +
                                   ",[Bank Branch]  ,[Loan Type]  ,[Loan Amount]   ,[Repayment Period],[Shares Contribution After],[Approved],[Basic Pay]  ,[Total Allowances]   ,[TotalDeduction],[Interest Rate]" +
                                 " )   VALUES (@Names,@HomeAddress    ,@District ,@Application_Date ,@Membership_No,@Employment_No,@Division ,@Location ,@SubLocation,getdate(),@EmployerAddress" +
                                   ",@Station,@Designation,@GrossSalary ,@Position_Held, @Telephone,@Email ,@BankAccountNo,@BankName,@Bank_Branch,@LoanType,@LoanAmount" +
                                   ",@Repayment_Period ,@Shares_Contribution,0,@BasicPay,@TotalAllowances,@TotalDeduction,@InterestRate)";

                                        SqlCommand cmd = new SqlCommand(SQL, conn);
                                        cmd.Parameters.AddWithValue("@Names", Name);
                                        cmd.Parameters.AddWithValue("@HomeAddress", HomeAddress);
                                        cmd.Parameters.AddWithValue("@District", District);
                                        cmd.Parameters.AddWithValue("@Application_Date", applicationDate.ToString("yyyy-MMM-dd"));
                                        cmd.Parameters.AddWithValue("@Membership_No", Member_No_);
                                        cmd.Parameters.AddWithValue("@Employment_No", EmploymentNo);
                                        cmd.Parameters.AddWithValue("@Division", Division);
                                        cmd.Parameters.AddWithValue("@Location", Location);
                                        cmd.Parameters.AddWithValue("@SubLocation", SubLocation);
                                        cmd.Parameters.AddWithValue("@EmployerAddress", EmployerAddress);
                                        cmd.Parameters.AddWithValue("@Station", Station);
                                        cmd.Parameters.AddWithValue("@Designation", Designation);
                                        cmd.Parameters.AddWithValue("@GrossSalary", GrossSalary);
                                        cmd.Parameters.AddWithValue("@Position_Held", Position_Held);
                                        cmd.Parameters.AddWithValue("@Telephone", Phone_No_);
                                        cmd.Parameters.AddWithValue("@Email", E_Mail);
                                        cmd.Parameters.AddWithValue("@BankAccountNo", BankAccount_No);
                                        cmd.Parameters.AddWithValue("@BankName", BankName);
                                        cmd.Parameters.AddWithValue("@Bank_Branch", BankBranch);
                                        cmd.Parameters.AddWithValue("@LoanType", Loan_Type);
                                        cmd.Parameters.AddWithValue("@LoanAmount", Loan_Amout);
                                        cmd.Parameters.AddWithValue("@Repayment_Period", Repayment_Period);
                                        cmd.Parameters.AddWithValue("@Shares_Contribution", Shares_Contribution);
                                        cmd.Parameters.AddWithValue("@BasicPay", BasicPay);
                                        cmd.Parameters.AddWithValue("@TotalAllowances", Total_Allowances);
                                        cmd.Parameters.AddWithValue("@TotalDeduction", Total_Deductions);
                                        cmd.Parameters.AddWithValue("@InterestRate", InterestRate);
                                        cmd.ExecuteNonQuery();

                                        string s_online = String.Format(" SELECT MAX([Application No]) AS [Last_Application_No] FROM [{0}$Online Loan Application];", MyClass.CompanyName);
                                        SqlCommand command_online = new SqlCommand(s_online, conn);
                                        command_online.Parameters.AddWithValue("@Member_No", Member_No_);
                                        using (SqlDataReader dr1_online = command_online.ExecuteReader())
                                        {
                                            if (dr1_online.HasRows == true)
                                            {
                                                dr1_online.Read();
                                                LoanApplicationNo = dr1_online["Last_Application_No"].ToString();
                                            }
                                        }


                                        #region File Upload


                                        Uploaded_By = Session["Member_No"].ToString();
                                        Pin_No = Session["Member_No"].ToString();

                                        Description = fileName;
                                        Description = MyClass.RemoveSpecialCharacters(Description);

                                        fileName = Description + "." + fileExt;

                                        filePath = fileName;


                                        strPath = Config.sitePath;

                                        if (!System.IO.Directory.Exists(strPath))
                                        {
                                            Directory.CreateDirectory(strPath);
                                        }
                                        PathToUpload = Path.Combine(strPath, fileName);
                                        Path.Combine(PathToUpload, fileName);
                                        this.FileUploadDownloads.SaveAs(PathToUpload);


                                        #region Save To Database

                                        SqlCommand cmds = new SqlCommand();
                                        cmds.CommandType = CommandType.Text;
                                        cmds.Connection = conn;
                                        string SQLm = "INSERT INTO [" + MyClass.CompanyName + "$Online Documents] ([File Name]  ,[File Url],[Uploaded By],[Date Uploaded]" +
                                         " ,[Loan Application No])  VALUES  (@File_Name,@File_Url  ,@Uploaded_By  ,@DateUploaded, @LoanApplicationNo)";
                                        cmds.CommandText = SQLm;
                                        cmds.Parameters.Add("@File_Name", SqlDbType.VarChar).Value = Description;
                                        cmds.Parameters.Add("@File_Url", SqlDbType.VarChar).Value = strPath + filePath;
                                        cmds.Parameters.Add("@Uploaded_By", SqlDbType.VarChar).Value = Uploaded_By;
                                        cmds.Parameters.Add("@DateUploaded", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyy-MMM-dd");
                                        cmds.Parameters.Add("@LoanApplicationNo", SqlDbType.VarChar).Value = LoanApplicationNo;
                                        cmds.ExecuteNonQuery();


                                        #endregion




                                        #endregion


                                    }
                                    else
                                    {

                                        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                                        if (string.IsNullOrEmpty(LoanApplicationNo) == false)
                                        {

                                            SqlCommand cmds_ = new SqlCommand();
                                            cmds_.CommandType = CommandType.Text;
                                            cmds_.Connection = conn;
                                            string SQLm_ = String.Format("SELECT * FROM [{0}$Online Documents] WHERE [Loan Application No]= @LoanApplicationNo", MyClass.CompanyName);
                                            cmds_.CommandText = SQLm_;
                                            cmds_.Parameters.Add("@LoanApplicationNo", SqlDbType.VarChar).Value = LoanApplicationNo;
                                            using (SqlDataReader dr1_online = cmds_.ExecuteReader())
                                            {
                                                if (dr1_online.HasRows == false)
                                                {

                                                    #region File Upload


                                                    Uploaded_By = Session["Member_No"].ToString();
                                                    Pin_No = Session["Member_No"].ToString();

                                                    Description = fileName;
                                                    Description = MyClass.RemoveSpecialCharacters(Description);

                                                    fileName = Description + "." + fileExt;

                                                    filePath = fileName;


                                                    strPath = Config.sitePath;

                                                    if (!System.IO.Directory.Exists(strPath))
                                                    {
                                                        Directory.CreateDirectory(strPath);
                                                    }
                                                    PathToUpload = Path.Combine(strPath, fileName);
                                                    Path.Combine(PathToUpload, fileName);
                                                    this.FileUploadDownloads.SaveAs(PathToUpload);


                                                    #region Save To Database

                                                    SqlCommand cmds = new SqlCommand();
                                                    cmds.CommandType = CommandType.Text;
                                                    cmds.Connection = conn;
                                                    string SQLm = "INSERT INTO [" + MyClass.CompanyName + "$Online Documents] ([File Name]  ,[File Url],[Uploaded By],[Date Uploaded]" +
                                                     " ,[Loan Application No])  VALUES  (@File_Name,@File_Url  ,@Uploaded_By  ,@DateUploaded, @LoanApplicationNo)";
                                                    cmds.CommandText = SQLm;
                                                    cmds.Parameters.Add("@File_Name", SqlDbType.VarChar).Value = Description;
                                                    cmds.Parameters.Add("@File_Url", SqlDbType.VarChar).Value = strPath + filePath;
                                                    cmds.Parameters.Add("@Uploaded_By", SqlDbType.VarChar).Value = Uploaded_By;
                                                    cmds.Parameters.Add("@DateUploaded", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyy-MMM-dd");
                                                    cmds.Parameters.Add("@LoanApplicationNo", SqlDbType.VarChar).Value = LoanApplicationNo;
                                                    cmds.ExecuteNonQuery();


                                                    #endregion




                                                    #endregion
                                                }
                                            }

                                        }

                                        string Msh = string.Empty;
                                        Msh = "Sorry you have a pending loan of this type";
                                        Message(Msh);


                                    }
                                }

                                conn.Close();
                            }

                            #endregion

                            string CurrentPage = "AddNewGuarantor.aspx?option=Add_New_Guarantor&action=LoanApplication&LNo=" + LoanApplicationNo;
                            Response.Redirect(CurrentPage, false);
                            Context.ApplicationInstance.CompleteRequest();

                        }
                        else
                        {

                            this.lblError.Text = "Please select files with the following formats. *.pdf, *.zip, *.rar";
                            Message(this.lblError.Text);

                        }

                    }
                }

            }
            catch (Exception ex)
            {
            }

        }
        protected void btnApplyLoan_Click(object sender, EventArgs e)
        {

        }
    }
}