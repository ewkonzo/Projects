﻿using System;
using System.IO;
using System.Data.SqlClient;
using Bandari_Sacco.controller;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Bandari_Sacco
{
    public partial class CombinedStatement : System.Web.UI.Page
    {
        #region Variables

        Font TitleReport = FontFactory.GetFont("Arial", 9, Font.BOLD, Color.BLACK);
        Font tableTh = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);
        Font tableTd = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK);
        Font tableTd_ = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);
        Font fnttableHeader = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLUE);

        Font tableTdLabel = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK);
        Font tableTddata = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);

        Color RowTh = new Color(217, 237, 247);
        Color EvenTd = new Color(217, 237, 247);
        Color OddTd = new Color(255, 255, 255);

       // string CompanyName = "Bandari Test";
        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
          

        }

        #endregion


       

        void LoadShareCapital(Document doc_MY_LOANS_RPT, string Member_No_)
        {

            DateTime startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime enddate = Convert.ToDateTime(txtEndDate.Text);
            string Document_No_ = "", Description = "-", Reversed = "0";
            double Amount_ = 0, Closing_Balance = 0, Credit_Amount = 0, Debit_Amount = 0, Total_Credit_Amount = 0, TotalClosing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;

            PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            float[] widthsBody = new float[] { 20, 90, 90, 90, 90, 90, 90 };
            tableBody.SetWidths(widthsBody);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;



            #region Share Capital

            Document_No_ = ""; Description = "-"; Reversed = "0";
            Amount_ = 0; Closing_Balance = 0; Credit_Amount = 0; Debit_Amount = 0; Total_Credit_Amount = 0; TotalClosing_Balance = 0;
            Posting_Date = DateTime.Now;

            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                //string s = "SELECT [Posting Date],[Document No_],[Description],Amount,[Debit Amount],[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                //           "WHERE [Transaction Types]=14 AND [Customer No_]=@Member_No AND Reversed=@Reversed AND [Posting Date] BETWEEN @StartDate AND @EndDate " +
                //           "ORDER BY [Posting Date] asc";

                string s = "SELECT a.[Posting Date],a.[Document No_],a.[Description],a.[Amount],a.[Debit Amount],a.[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                           "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=1 AND Reversed=@Reversed AND a.[Posting Date] BETWEEN @StartDate AND @EndDate " +
                           "ORDER BY a.[Posting Date] asc";

                SqlCommand command = new SqlCommand(s, conn);
                command.Parameters.AddWithValue("@Member_No", Member_No_);
                command.Parameters.AddWithValue("@Reversed", Reversed);
                command.Parameters.AddWithValue("@StartDate", startdate);
                command.Parameters.AddWithValue("@EndDate", enddate);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {

                        PdfPCell cell_Loans = new PdfPCell(new Phrase("Share Capital", tableTh)) { Colspan = 7, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = RowTh };
                        tableBody.AddCell(cell_Loans);

                        #region CREATE TABLE TH

                        PdfPCell cellPeriod = new PdfPCell(new Phrase("#", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPeriod);

                        PdfPCell cellMonthYear = new PdfPCell(new Phrase("Posting Date", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellMonthYear);

                        PdfPCell cellLoanType = new PdfPCell(new Phrase("Document No.", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanType);

                        PdfPCell cellPrinciple = new PdfPCell(new Phrase("Description", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPrinciple);

                        PdfPCell cellLoanRepayment = new PdfPCell(new Phrase("Debit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanRepayment);

                        PdfPCell cellInterest = new PdfPCell(new Phrase("Credit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellInterest);

                        PdfPCell cellLoanBalance = new PdfPCell(new Phrase("Balance", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanBalance);


                        #endregion

                        int i = 0;
                        while (dr.Read())
                        {
                            i++;

                            Posting_Date = Convert.ToDateTime(dr["Posting Date"].ToString().Trim());
                            Document_No_ = dr["Document No_"].ToString().Trim();
                            Description = dr["Description"].ToString().Trim();
                            Amount_ = -Convert.ToDouble(dr["Amount"].ToString().Trim());

                            Debit_Amount = Convert.ToDouble(dr["Debit Amount"].ToString().Trim());
                            Credit_Amount = Convert.ToDouble(dr["Credit Amount"].ToString().Trim());

                            Closing_Balance += (Credit_Amount - Debit_Amount);

                            Total_Credit_Amount += Credit_Amount;
                            TotalClosing_Balance += Closing_Balance;

                            if (i % 2 == 0)
                            {

                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellLoanNo_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellLoanNo_);

                                PdfPCell cellLoan_DocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellLoan_DocNo_);

                                PdfPCell cellLoan_Type_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellLoan_Type_);



                                PdfPCell cellIssueDate_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellIssueDate_);

                                PdfPCell cellTerm_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellTerm_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }
                            else
                            {
                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellLoan_No_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellLoan_No_);

                                PdfPCell cellLoan_Type_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellLoan_Type_);

                                PdfPCell cellIssueDate_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellIssueDate_);

                                PdfPCell cellTerm_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellTerm_);

                                PdfPCell cellEndDate_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellEndDate_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }


                        }
                        PdfPCell cellPeriodTotal = new PdfPCell(new Phrase("Total", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellPeriodTotal);

                        PdfPCell cellTotal = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellTotal);

                        PdfPCell cellEmptyOne = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyOne);

                        PdfPCell cellEmptyTwo = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyTwo);

                        PdfPCell cellEmptyThree = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyThree);

                        PdfPCell cellEmptyFour = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyFour);

                        PdfPCell cellOutstaLoanBalance = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellOutstaLoanBalance);

                    }
                }
                conn.Close();
            }

            #endregion

            doc_MY_LOANS_RPT.Add(tableBody);
        }
        void LoadDepositsContributions(Document doc_MY_LOANS_RPT, string Member_No_)
        {
            string Document_No_ = "", Description = "-", Reversed = "0";
            double Amount_ = 0, Closing_Balance = 0, Credit_Amount = 0, Debit_Amount = 0, Total_Credit_Amount = 0, TotalClosing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;

            PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            float[] widthsBody = new float[] { 20, 90, 90, 90, 90, 90, 90 };
            tableBody.SetWidths(widthsBody);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;


            #region Deposit Contributions
            DateTime startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime enddate = Convert.ToDateTime(txtEndDate.Text);
            Document_No_ = ""; Description = "-"; Reversed = "0";
            Amount_ = 0; Closing_Balance = 0; Credit_Amount = 0; Debit_Amount = 0; Total_Credit_Amount = 0; TotalClosing_Balance = 0;
            Posting_Date = DateTime.Now;

            using (SqlConnection conn = CRUD.getconnToNAV())
            {
             //   string s = "SELECT [Posting Date],[Document No_],[Description],Amount,[Debit Amount],[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
             //"WHERE [Transaction Types]=8 AND [Customer No_]=@Member_No AND Reversed=@Reversed AND [Posting Date] BETWEEN @StartDate AND @EndDate " +
             //"ORDER BY [Posting Date] asc";

                string s = "SELECT a.[Posting Date],a.[Document No_],a.[Description],a.[Amount],a.[Debit Amount],a.[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                           "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=0 AND Reversed=@Reversed AND a.[Posting Date] BETWEEN @StartDate AND @EndDate " +
                           "ORDER BY a.[Posting Date] asc";
 
                SqlCommand command = new SqlCommand(s, conn);
                command.Parameters.AddWithValue("@Member_No", Member_No_);
                command.Parameters.AddWithValue("@Reversed", Reversed);
                command.Parameters.AddWithValue("@StartDate", startdate);
                command.Parameters.AddWithValue("@EndDate", enddate);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {

                        PdfPCell cell_Loans = new PdfPCell(new Phrase("Deposit Contributions", tableTh)) { Colspan = 7, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = RowTh };
                        tableBody.AddCell(cell_Loans);

                        #region CREATE TABLE TH

                        PdfPCell cellPeriod = new PdfPCell(new Phrase("#", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPeriod);

                        PdfPCell cellMonthYear = new PdfPCell(new Phrase("Posting Date", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellMonthYear);

                        PdfPCell cellLoanType = new PdfPCell(new Phrase("Document No.", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanType);

                        PdfPCell cellPrinciple = new PdfPCell(new Phrase("Description", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPrinciple);

                        PdfPCell cellLoanRepayment = new PdfPCell(new Phrase("Debit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanRepayment);

                        PdfPCell cellInterest = new PdfPCell(new Phrase("Credit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellInterest);

                        PdfPCell cellLoanBalance = new PdfPCell(new Phrase("Balance", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanBalance);


                        #endregion

                        int i = 0;
                        while (dr.Read())
                        {
                            i++;

                            Posting_Date = Convert.ToDateTime(dr["Posting Date"].ToString().Trim());
                            Document_No_ = dr["Document No_"].ToString().Trim();
                            Description = dr["Description"].ToString().Trim();
                            Amount_ = -Convert.ToDouble(dr["Amount"].ToString().Trim());

                            Debit_Amount = Convert.ToDouble(dr["Debit Amount"].ToString().Trim());
                            Credit_Amount = Convert.ToDouble(dr["Credit Amount"].ToString().Trim());

                            Closing_Balance += (Credit_Amount - Debit_Amount);

                            Total_Credit_Amount += Credit_Amount;
                            TotalClosing_Balance += Closing_Balance;

                            if (i % 2 == 0)
                            {

                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }
                            else
                            {
                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }


                        }

                        PdfPCell cellPeriodTotal = new PdfPCell(new Phrase("Total", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellPeriodTotal);

                        PdfPCell cellTotal = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellTotal);

                        PdfPCell cellEmptyOne = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyOne);

                        PdfPCell cellEmptyTwo = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyTwo);

                        PdfPCell cellEmptyThree = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyThree);

                        PdfPCell cellEmptyFour = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyFour);

                        PdfPCell cellOutstaLoanBalance = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellOutstaLoanBalance);

                    }
                }
                conn.Close();
            }

            #endregion

            doc_MY_LOANS_RPT.Add(tableBody);
        }

        void LoadBenevolentContributions(Document doc_MY_LOANS_RPT, string Member_No_)
        {
            string Document_No_ = "", Description = "-", Reversed = "0";
            double Amount_ = 0, Closing_Balance = 0, Credit_Amount = 0, Debit_Amount = 0, Total_Credit_Amount = 0, TotalClosing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;

            PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            float[] widthsBody = new float[] { 20, 90, 90, 90, 90, 90, 90 };
            tableBody.SetWidths(widthsBody);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;


            #region Deposit Contributions
            DateTime startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime enddate = Convert.ToDateTime(txtEndDate.Text);
            Document_No_ = ""; Description = "-"; Reversed = "0";
            Amount_ = 0; Closing_Balance = 0; Credit_Amount = 0; Debit_Amount = 0; Total_Credit_Amount = 0; TotalClosing_Balance = 0;
            Posting_Date = DateTime.Now;

            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                //   string s = "SELECT [Posting Date],[Document No_],[Description],Amount,[Debit Amount],[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                //"WHERE [Transaction Types]=8 AND [Customer No_]=@Member_No AND Reversed=@Reversed AND [Posting Date] BETWEEN @StartDate AND @EndDate " +
                //"ORDER BY [Posting Date] asc";

                string s = "SELECT a.[Posting Date],a.[Document No_],a.[Description],a.[Amount],a.[Debit Amount],a.[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                           "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=2 AND Reversed=@Reversed AND a.[Posting Date] BETWEEN @StartDate AND @EndDate " +
                           "ORDER BY a.[Posting Date] asc";

                SqlCommand command = new SqlCommand(s, conn);
                command.Parameters.AddWithValue("@Member_No", Member_No_);
                command.Parameters.AddWithValue("@Reversed", Reversed);
                command.Parameters.AddWithValue("@StartDate", startdate);
                command.Parameters.AddWithValue("@EndDate", enddate);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {

                        PdfPCell cell_Loans = new PdfPCell(new Phrase("Benevolent Contributions", tableTh)) { Colspan = 7, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = RowTh };
                        tableBody.AddCell(cell_Loans);

                        #region CREATE TABLE TH

                        PdfPCell cellPeriod = new PdfPCell(new Phrase("#", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPeriod);

                        PdfPCell cellMonthYear = new PdfPCell(new Phrase("Posting Date", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellMonthYear);

                        PdfPCell cellLoanType = new PdfPCell(new Phrase("Document No.", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanType);

                        PdfPCell cellPrinciple = new PdfPCell(new Phrase("Description", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPrinciple);

                        PdfPCell cellLoanRepayment = new PdfPCell(new Phrase("Debit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanRepayment);

                        PdfPCell cellInterest = new PdfPCell(new Phrase("Credit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellInterest);

                        PdfPCell cellLoanBalance = new PdfPCell(new Phrase("Balance", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanBalance);


                        #endregion

                        int i = 0;
                        while (dr.Read())
                        {
                            i++;

                            Posting_Date = Convert.ToDateTime(dr["Posting Date"].ToString().Trim());
                            Document_No_ = dr["Document No_"].ToString().Trim();
                            Description = dr["Description"].ToString().Trim();
                            Amount_ = -Convert.ToDouble(dr["Amount"].ToString().Trim());

                            Debit_Amount = Convert.ToDouble(dr["Debit Amount"].ToString().Trim());
                            Credit_Amount = Convert.ToDouble(dr["Credit Amount"].ToString().Trim());

                            Closing_Balance += (Credit_Amount - Debit_Amount);

                            Total_Credit_Amount += Credit_Amount;
                            TotalClosing_Balance += Closing_Balance;

                            if (i % 2 == 0)
                            {

                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }
                            else
                            {
                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }


                        }

                        PdfPCell cellPeriodTotal = new PdfPCell(new Phrase("Total", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellPeriodTotal);

                        PdfPCell cellTotal = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellTotal);

                        PdfPCell cellEmptyOne = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyOne);

                        PdfPCell cellEmptyTwo = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyTwo);

                        PdfPCell cellEmptyThree = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyThree);

                        PdfPCell cellEmptyFour = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyFour);

                        PdfPCell cellOutstaLoanBalance = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellOutstaLoanBalance);

                    }
                }
                conn.Close();
            }

            #endregion

            doc_MY_LOANS_RPT.Add(tableBody);
        }

        void LoadLoansPortfolio(Document doc_MY_LOANS_RPT, string Member_No_)
        {
            string Document_No_ = "", Description = "-", Reversed = "0";
            double Amount_ = 0, Closing_Balance = 0, Credit_Amount = 0, Debit_Amount = 0, Total_Credit_Amount = 0, TotalClosing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;

            PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            float[] widthsBody = new float[] { 20, 90, 90, 90, 90, 90, 90 };
            tableBody.SetWidths(widthsBody);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;


            #region Deposit Contributions
            DateTime startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime enddate = Convert.ToDateTime(txtEndDate.Text);
            Document_No_ = ""; Description = "-"; Reversed = "0";
            Amount_ = 0; Closing_Balance = 0; Credit_Amount = 0; Debit_Amount = 0; Total_Credit_Amount = 0; TotalClosing_Balance = 0;
            Posting_Date = DateTime.Now;

            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                //   string s = "SELECT [Posting Date],[Document No_],[Description],Amount,[Debit Amount],[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                //"WHERE [Transaction Types]=8 AND [Customer No_]=@Member_No AND Reversed=@Reversed AND [Posting Date] BETWEEN @StartDate AND @EndDate " +
                //"ORDER BY [Posting Date] asc";

                string s = "SELECT a.[Posting Date],a.[Document No_],a.[Description],a.[Amount],a.[Debit Amount],a.[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                           "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=3 AND Reversed=@Reversed AND a.[Posting Date] BETWEEN @StartDate AND @EndDate " +
                           "ORDER BY a.[Posting Date] asc";

                SqlCommand command = new SqlCommand(s, conn);
                command.Parameters.AddWithValue("@Member_No", Member_No_);
                command.Parameters.AddWithValue("@Reversed", Reversed);
                command.Parameters.AddWithValue("@StartDate", startdate);
                command.Parameters.AddWithValue("@EndDate", enddate);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {

                        PdfPCell cell_Loans = new PdfPCell(new Phrase("Loans Portfolio", tableTh)) { Colspan = 7, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = RowTh };
                        tableBody.AddCell(cell_Loans);

                        #region CREATE TABLE TH

                        PdfPCell cellPeriod = new PdfPCell(new Phrase("#", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPeriod);

                        PdfPCell cellMonthYear = new PdfPCell(new Phrase("Posting Date", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellMonthYear);

                        PdfPCell cellLoanType = new PdfPCell(new Phrase("Document No.", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanType);

                        PdfPCell cellPrinciple = new PdfPCell(new Phrase("Description", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPrinciple);

                        PdfPCell cellLoanRepayment = new PdfPCell(new Phrase("Debit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanRepayment);

                        PdfPCell cellInterest = new PdfPCell(new Phrase("Credit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellInterest);

                        PdfPCell cellLoanBalance = new PdfPCell(new Phrase("Balance", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanBalance);


                        #endregion

                        int i = 0;
                        while (dr.Read())
                        {
                            i++;

                            Posting_Date = Convert.ToDateTime(dr["Posting Date"].ToString().Trim());
                            Document_No_ = dr["Document No_"].ToString().Trim();
                            Description = dr["Description"].ToString().Trim();
                            Amount_ = -Convert.ToDouble(dr["Amount"].ToString().Trim());

                            Debit_Amount = Convert.ToDouble(dr["Debit Amount"].ToString().Trim());
                            Credit_Amount = Convert.ToDouble(dr["Credit Amount"].ToString().Trim());

                            Closing_Balance += (Credit_Amount - Debit_Amount);

                            Total_Credit_Amount += Credit_Amount;
                            TotalClosing_Balance += Closing_Balance;

                            if (i % 2 == 0)
                            {

                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }
                            else
                            {
                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }


                        }
                        PdfPCell cellPeriodTotal = new PdfPCell(new Phrase("Total", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellPeriodTotal);

                        PdfPCell cellTotal = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellTotal);

                        PdfPCell cellEmptyOne = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyOne);

                        PdfPCell cellEmptyTwo = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyTwo);

                        PdfPCell cellEmptyThree = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyThree);

                        PdfPCell cellEmptyFour = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyFour);

                        PdfPCell cellOutstaLoanBalance = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellOutstaLoanBalance);

                    }
                }
                conn.Close();
            }

            #endregion

            doc_MY_LOANS_RPT.Add(tableBody);
        }

        void LoadLoansRepayment(Document doc_MY_LOANS_RPT, string Member_No_)
        {
            string Document_No_ = "", Description = "-", Reversed = "0";
            double Amount_ = 0, Closing_Balance = 0, Credit_Amount = 0, Debit_Amount = 0, Total_Credit_Amount = 0, TotalClosing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;

            PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            float[] widthsBody = new float[] { 20, 90, 90, 90, 90, 90, 90 };
            tableBody.SetWidths(widthsBody);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;


            #region Loans Repayment
            DateTime startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime enddate = Convert.ToDateTime(txtEndDate.Text);
            Document_No_ = ""; Description = "-"; Reversed = "0";
            Amount_ = 0; Closing_Balance = 0; Credit_Amount = 0; Debit_Amount = 0; Total_Credit_Amount = 0; TotalClosing_Balance = 0;
            Posting_Date = DateTime.Now;

            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                //   string s = "SELECT [Posting Date],[Document No_],[Description],Amount,[Debit Amount],[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                //"WHERE [Transaction Types]=8 AND [Customer No_]=@Member_No AND Reversed=@Reversed AND [Posting Date] BETWEEN @StartDate AND @EndDate " +
                //"ORDER BY [Posting Date] asc";

                string s = "SELECT a.[Posting Date],a.[Document No_],a.[Description],a.[Amount],a.[Debit Amount],a.[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                           "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=4 AND Reversed=@Reversed AND a.[Posting Date] BETWEEN @StartDate AND @EndDate " +
                           "ORDER BY a.[Posting Date] asc";

                SqlCommand command = new SqlCommand(s, conn);
                command.Parameters.AddWithValue("@Member_No", Member_No_);
                command.Parameters.AddWithValue("@Reversed", Reversed);
                command.Parameters.AddWithValue("@StartDate", startdate);
                command.Parameters.AddWithValue("@EndDate", enddate);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {

                        PdfPCell cell_Loans = new PdfPCell(new Phrase("Loans Repayment", tableTh)) { Colspan = 7, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = RowTh };
                        tableBody.AddCell(cell_Loans);

                        #region CREATE TABLE TH

                        PdfPCell cellPeriod = new PdfPCell(new Phrase("#", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPeriod);

                        PdfPCell cellMonthYear = new PdfPCell(new Phrase("Posting Date", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellMonthYear);

                        PdfPCell cellLoanType = new PdfPCell(new Phrase("Document No.", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanType);

                        PdfPCell cellPrinciple = new PdfPCell(new Phrase("Description", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPrinciple);

                        PdfPCell cellLoanRepayment = new PdfPCell(new Phrase("Debit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanRepayment);

                        PdfPCell cellInterest = new PdfPCell(new Phrase("Credit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellInterest);

                        PdfPCell cellLoanBalance = new PdfPCell(new Phrase("Balance", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanBalance);


                        #endregion

                        int i = 0;
                        while (dr.Read())
                        {
                            i++;

                            Posting_Date = Convert.ToDateTime(dr["Posting Date"].ToString().Trim());
                            Document_No_ = dr["Document No_"].ToString().Trim();
                            Description = dr["Description"].ToString().Trim();
                            Amount_ = -Convert.ToDouble(dr["Amount"].ToString().Trim());

                            Debit_Amount = Convert.ToDouble(dr["Debit Amount"].ToString().Trim());
                            Credit_Amount = Convert.ToDouble(dr["Credit Amount"].ToString().Trim());

                            Closing_Balance += (Credit_Amount - Debit_Amount);

                            Total_Credit_Amount += Credit_Amount;
                            TotalClosing_Balance += Closing_Balance;

                            if (i % 2 == 0)
                            {

                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }
                            else
                            {
                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }


                        }
                        PdfPCell cellPeriodTotal = new PdfPCell(new Phrase("Total", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellPeriodTotal);

                        PdfPCell cellTotal = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellTotal);

                        PdfPCell cellEmptyOne = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyOne);

                        PdfPCell cellEmptyTwo = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyTwo);

                        PdfPCell cellEmptyThree = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyThree);

                        PdfPCell cellEmptyFour = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyFour);

                        PdfPCell cellOutstaLoanBalance = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellOutstaLoanBalance);

                    }
                }
                conn.Close();
            }

            #endregion

            doc_MY_LOANS_RPT.Add(tableBody);
        }

        void LoadInterestDue(Document doc_MY_LOANS_RPT, string Member_No_)
        {
            string Document_No_ = "", Description = "-", Reversed = "0";
            double Amount_ = 0, Closing_Balance = 0, Credit_Amount = 0, Debit_Amount = 0, Total_Credit_Amount = 0, TotalClosing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;

            PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            float[] widthsBody = new float[] { 20, 90, 90, 90, 90, 90, 90 };
            tableBody.SetWidths(widthsBody);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;


            #region Interest Due
            DateTime startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime enddate = Convert.ToDateTime(txtEndDate.Text);
            Document_No_ = ""; Description = "-"; Reversed = "0";
            Amount_ = 0; Closing_Balance = 0; Credit_Amount = 0; Debit_Amount = 0; Total_Credit_Amount = 0; TotalClosing_Balance = 0;
            Posting_Date = DateTime.Now;

            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                //   string s = "SELECT [Posting Date],[Document No_],[Description],Amount,[Debit Amount],[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                //"WHERE [Transaction Types]=8 AND [Customer No_]=@Member_No AND Reversed=@Reversed AND [Posting Date] BETWEEN @StartDate AND @EndDate " +
                //"ORDER BY [Posting Date] asc";

                string s = "SELECT a.[Posting Date],a.[Document No_],a.[Description],a.[Amount],a.[Debit Amount],a.[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                           "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=5 AND Reversed=@Reversed AND a.[Posting Date] BETWEEN @StartDate AND @EndDate " +
                           "ORDER BY a.[Posting Date] asc";

                SqlCommand command = new SqlCommand(s, conn);
                command.Parameters.AddWithValue("@Member_No", Member_No_);
                command.Parameters.AddWithValue("@Reversed", Reversed);
                command.Parameters.AddWithValue("@StartDate", startdate);
                command.Parameters.AddWithValue("@EndDate", enddate);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {

                        PdfPCell cell_Loans = new PdfPCell(new Phrase("Interest Due", tableTh)) { Colspan = 7, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = RowTh };
                        tableBody.AddCell(cell_Loans);

                        #region CREATE TABLE TH

                        PdfPCell cellPeriod = new PdfPCell(new Phrase("#", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPeriod);

                        PdfPCell cellMonthYear = new PdfPCell(new Phrase("Posting Date", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellMonthYear);

                        PdfPCell cellLoanType = new PdfPCell(new Phrase("Document No.", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanType);

                        PdfPCell cellPrinciple = new PdfPCell(new Phrase("Description", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPrinciple);

                        PdfPCell cellLoanRepayment = new PdfPCell(new Phrase("Debit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanRepayment);

                        PdfPCell cellInterest = new PdfPCell(new Phrase("Credit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellInterest);

                        PdfPCell cellLoanBalance = new PdfPCell(new Phrase("Balance", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanBalance);


                        #endregion

                        int i = 0;
                        while (dr.Read())
                        {
                            i++;

                            Posting_Date = Convert.ToDateTime(dr["Posting Date"].ToString().Trim());
                            Document_No_ = dr["Document No_"].ToString().Trim();
                            Description = dr["Description"].ToString().Trim();
                            Amount_ = -Convert.ToDouble(dr["Amount"].ToString().Trim());

                            Debit_Amount = Convert.ToDouble(dr["Debit Amount"].ToString().Trim());
                            Credit_Amount = Convert.ToDouble(dr["Credit Amount"].ToString().Trim());

                            Closing_Balance += (Credit_Amount - Debit_Amount);

                            Total_Credit_Amount += Credit_Amount;
                            TotalClosing_Balance += Closing_Balance;

                            if (i % 2 == 0)
                            {

                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }
                            else
                            {
                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }


                        }
                        PdfPCell cellPeriodTotal = new PdfPCell(new Phrase("Total", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellPeriodTotal);

                        PdfPCell cellTotal = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellTotal);

                        PdfPCell cellEmptyOne = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyOne);

                        PdfPCell cellEmptyTwo = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyTwo);

                        PdfPCell cellEmptyThree = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyThree);

                        PdfPCell cellEmptyFour = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyFour);

                        PdfPCell cellOutstaLoanBalance = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellOutstaLoanBalance);

                    }
                }
                conn.Close();
            }

            #endregion

            doc_MY_LOANS_RPT.Add(tableBody);
        }
        void LoadInterestPaid(Document doc_MY_LOANS_RPT, string Member_No_)
        {
            string Document_No_ = "", Description = "-", Reversed = "0";
            double Amount_ = 0, Closing_Balance = 0, Credit_Amount = 0, Debit_Amount = 0, Total_Credit_Amount = 0, TotalClosing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;

            PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            float[] widthsBody = new float[] { 20, 90, 90, 90, 90, 90, 90 };
            tableBody.SetWidths(widthsBody);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;


            #region Interest Due
            DateTime startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime enddate = Convert.ToDateTime(txtEndDate.Text);
            Document_No_ = ""; Description = "-"; Reversed = "0";
            Amount_ = 0; Closing_Balance = 0; Credit_Amount = 0; Debit_Amount = 0; Total_Credit_Amount = 0; TotalClosing_Balance = 0;
            Posting_Date = DateTime.Now;

            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                //   string s = "SELECT [Posting Date],[Document No_],[Description],Amount,[Debit Amount],[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                //"WHERE [Transaction Types]=8 AND [Customer No_]=@Member_No AND Reversed=@Reversed AND [Posting Date] BETWEEN @StartDate AND @EndDate " +
                //"ORDER BY [Posting Date] asc";

                string s = "SELECT a.[Posting Date],a.[Document No_],a.[Description],a.[Amount],a.[Debit Amount],a.[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                           "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=6 AND Reversed=@Reversed AND a.[Posting Date] BETWEEN @StartDate AND @EndDate " +
                           "ORDER BY a.[Posting Date] asc";

                SqlCommand command = new SqlCommand(s, conn);
                command.Parameters.AddWithValue("@Member_No", Member_No_);
                command.Parameters.AddWithValue("@Reversed", Reversed);
                command.Parameters.AddWithValue("@StartDate", startdate);
                command.Parameters.AddWithValue("@EndDate", enddate);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {

                        PdfPCell cell_Loans = new PdfPCell(new Phrase("Interest Paid", tableTh)) { Colspan = 7, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = RowTh };
                        tableBody.AddCell(cell_Loans);

                        #region CREATE TABLE TH

                        PdfPCell cellPeriod = new PdfPCell(new Phrase("#", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPeriod);

                        PdfPCell cellMonthYear = new PdfPCell(new Phrase("Posting Date", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellMonthYear);

                        PdfPCell cellLoanType = new PdfPCell(new Phrase("Document No.", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanType);

                        PdfPCell cellPrinciple = new PdfPCell(new Phrase("Description", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPrinciple);

                        PdfPCell cellLoanRepayment = new PdfPCell(new Phrase("Debit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanRepayment);

                        PdfPCell cellInterest = new PdfPCell(new Phrase("Credit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellInterest);

                        PdfPCell cellLoanBalance = new PdfPCell(new Phrase("Balance", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanBalance);


                        #endregion

                        int i = 0;
                        while (dr.Read())
                        {
                            i++;

                            Posting_Date = Convert.ToDateTime(dr["Posting Date"].ToString().Trim());
                            Document_No_ = dr["Document No_"].ToString().Trim();
                            Description = dr["Description"].ToString().Trim();
                            Amount_ = -Convert.ToDouble(dr["Amount"].ToString().Trim());

                            Debit_Amount = Convert.ToDouble(dr["Debit Amount"].ToString().Trim());
                            Credit_Amount = Convert.ToDouble(dr["Credit Amount"].ToString().Trim());

                            Closing_Balance += (Credit_Amount - Debit_Amount);

                            Total_Credit_Amount += Credit_Amount;
                            TotalClosing_Balance += Closing_Balance;

                            if (i % 2 == 0)
                            {

                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }
                            else
                            {
                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }


                        }
                        PdfPCell cellPeriodTotal = new PdfPCell(new Phrase("Total", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellPeriodTotal);

                        PdfPCell cellTotal = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellTotal);

                        PdfPCell cellEmptyOne = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyOne);

                        PdfPCell cellEmptyTwo = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyTwo);

                        PdfPCell cellEmptyThree = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyThree);

                        PdfPCell cellEmptyFour = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyFour);

                        PdfPCell cellOutstaLoanBalance = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellOutstaLoanBalance);

                    }
                }
                conn.Close();
            }

            #endregion

            doc_MY_LOANS_RPT.Add(tableBody);
        }

        void LoadUnallocatedAmount(Document doc_MY_LOANS_RPT, string Member_No_)
        {
            string Document_No_ = "", Description = "-", Reversed = "0";
            double Amount_ = 0, Closing_Balance = 0, Credit_Amount = 0, Debit_Amount = 0, Total_Credit_Amount = 0, TotalClosing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;

            PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            float[] widthsBody = new float[] { 20, 90, 90, 90, 90, 90, 90 };
            tableBody.SetWidths(widthsBody);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;


            #region Unallocated Amount
            DateTime startdate = Convert.ToDateTime(txtStartDate.Text);
            DateTime enddate = Convert.ToDateTime(txtEndDate.Text);
            Document_No_ = ""; Description = "-"; Reversed = "0";
            Amount_ = 0; Closing_Balance = 0; Credit_Amount = 0; Debit_Amount = 0; Total_Credit_Amount = 0; TotalClosing_Balance = 0;
            Posting_Date = DateTime.Now;

            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                //   string s = "SELECT [Posting Date],[Document No_],[Description],Amount,[Debit Amount],[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                //"WHERE [Transaction Types]=8 AND [Customer No_]=@Member_No AND Reversed=@Reversed AND [Posting Date] BETWEEN @StartDate AND @EndDate " +
                //"ORDER BY [Posting Date] asc";

                string s = "SELECT a.[Posting Date],a.[Document No_],a.[Description],a.[Amount],a.[Debit Amount],a.[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                           "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=7 AND Reversed=@Reversed AND a.[Posting Date] BETWEEN @StartDate AND @EndDate " +
                           "ORDER BY a.[Posting Date] asc";

                SqlCommand command = new SqlCommand(s, conn);
                command.Parameters.AddWithValue("@Member_No", Member_No_);
                command.Parameters.AddWithValue("@Reversed", Reversed);
                command.Parameters.AddWithValue("@StartDate", startdate);
                command.Parameters.AddWithValue("@EndDate", enddate);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {

                        PdfPCell cell_Loans = new PdfPCell(new Phrase("Unallocated Amount", tableTh)) { Colspan = 7, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = RowTh };
                        tableBody.AddCell(cell_Loans);

                        #region CREATE TABLE TH

                        PdfPCell cellPeriod = new PdfPCell(new Phrase("#", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPeriod);

                        PdfPCell cellMonthYear = new PdfPCell(new Phrase("Posting Date", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellMonthYear);

                        PdfPCell cellLoanType = new PdfPCell(new Phrase("Document No.", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanType);

                        PdfPCell cellPrinciple = new PdfPCell(new Phrase("Description", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellPrinciple);

                        PdfPCell cellLoanRepayment = new PdfPCell(new Phrase("Debit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanRepayment);

                        PdfPCell cellInterest = new PdfPCell(new Phrase("Credit Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellInterest);

                        PdfPCell cellLoanBalance = new PdfPCell(new Phrase("Balance", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                        tableBody.AddCell(cellLoanBalance);


                        #endregion

                        int i = 0;
                        while (dr.Read())
                        {
                            i++;

                            Posting_Date = Convert.ToDateTime(dr["Posting Date"].ToString().Trim());
                            Document_No_ = dr["Document No_"].ToString().Trim();
                            Description = dr["Description"].ToString().Trim();
                            Amount_ = -Convert.ToDouble(dr["Amount"].ToString().Trim());

                            Debit_Amount = Convert.ToDouble(dr["Debit Amount"].ToString().Trim());
                            Credit_Amount = Convert.ToDouble(dr["Credit Amount"].ToString().Trim());

                            Closing_Balance += (Credit_Amount - Debit_Amount);

                            Total_Credit_Amount += Credit_Amount;
                            TotalClosing_Balance += Closing_Balance;

                            if (i % 2 == 0)
                            {

                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }
                            else
                            {
                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellPostingDate_);

                                PdfPCell cellDocNo_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDocNo_);

                                PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDesc_);

                                PdfPCell cellDebitAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellDebitAmount_);

                                PdfPCell cellCreditAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellCreditAmount_);

                                PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                tableBody.AddCell(cellOutstaLoanBalance_);

                            }


                        }
                        PdfPCell cellPeriodTotal = new PdfPCell(new Phrase("Total", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellPeriodTotal);

                        PdfPCell cellTotal = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellTotal);

                        PdfPCell cellEmptyOne = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyOne);

                        PdfPCell cellEmptyTwo = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyTwo);

                        PdfPCell cellEmptyThree = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyThree);

                        PdfPCell cellEmptyFour = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellEmptyFour);

                        PdfPCell cellOutstaLoanBalance = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                        tableBody.AddCell(cellOutstaLoanBalance);

                    }
                }
                conn.Close();
            }

            #endregion

            doc_MY_LOANS_RPT.Add(tableBody);
        }
        void LoadFooter(Document doc_MY_LOANS_RPT, string Member_No_)
        {
            string Document_No_ = "", Description = "-", Reversed = "0";
            double Amount_ = 0, Closing_Balance = 0, Credit_Amount = 0, Debit_Amount = 0, Total_Credit_Amount = 0, TotalClosing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;

            PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            float[] widthsBody = new float[] { 20, 90, 90, 90, 90, 90, 90 };
            tableBody.SetWidths(widthsBody);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;

            #region Footer

            PdfPCell cellEnd = new PdfPCell(new Phrase("END OF COMBINED STATEMENT", tableTh)) { Colspan = 7, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
            tableBody.AddCell(cellEnd);

            PdfPCell cellVerify = new PdfPCell(new Phrase("Please verify your statement, for any discrepancies contact Bandari Sacco Society Ltd. info@bandarisacco.co.ke", tableTd)) { Colspan = 7, PaddingTop = 15f, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
            tableBody.AddCell(cellVerify);

            Font copyRight = FontFactory.GetFont("Arial", 6, Font.ITALIC, Color.BLACK);

            DateTime Yr = DateTime.Now;
            PdfPCell cellCopyRight = new PdfPCell(new Phrase(String.Format("Copyright © {0} - Bandari Sacco Society Ltd", Yr.Year), copyRight)) { Colspan = 7, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
            tableBody.AddCell(cellCopyRight);

            #endregion

            doc_MY_LOANS_RPT.Add(tableBody);
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string firstdatebox = txtStartDate.Text;
            string seconddatebox = txtEndDate.Text;
            if (firstdatebox == string.Empty || seconddatebox == string.Empty)
            {
                lblError.Text = "Kindly Select the Date Range";
 
            }
            else if (firstdatebox != string.Empty || seconddatebox != string.Empty)
            {
                if (MyClass.EvaluateDate(firstdatebox, seconddatebox) == false)
                {
                    lblError.Text = string.Empty;
                    lblError.Text = "Please Enter the Date in the Format MM/DD/YYYY";
                }
                else
                {


                    #region CREATE REPORT

                    lblError.Text = string.Empty;

                    string Member_No_ = "";
                    Member_No_ = Session["Member_No"].ToString();
                    string rptpath = MyClass.ReportsPath();
                    string ImagePath = MyClass.ImagesPath();

                    #region =============================== CREATE PDF  ===============================

                    string fileName = String.Format("COMBINED_STATEMENT_{0}.pdf", Member_No_);
                    string filenamePath = String.Format("{0}\\{1}", rptpath, fileName);

                    #region Check If File exist

                    if (File.Exists(filenamePath))
                    {
                        File.Delete(filenamePath);
                    }

                    #endregion

                    Document doc_MY_LOANS_RPT = new Document(PageSize.A4);
                    doc_MY_LOANS_RPT.SetMargins(20f, 10f, 20f, 10f); // Left, Bottom,Top,Right

                    MemoryStream pdfStream = new MemoryStream();
                    PdfWriter pdfWriter = PdfWriter.GetInstance(doc_MY_LOANS_RPT, new FileStream(filenamePath, FileMode.Create));

                    doc_MY_LOANS_RPT.Open();

                    #endregion

                    #region ++++++++++++++++++ REPORT TABLE Logo++++++++++++++++++++++++++++++++++


                    string Logo_Path = String.Format("{0}/bandari_logo.jpg", ImagePath);

                    PdfPTable tableFirstApplicationLogo = new PdfPTable(3) { TotalWidth = 560f, LockedWidth = true };
                    float[] widthsLogo = new float[] { 225f, 110f, 225f };
                    tableFirstApplicationLogo.SetWidths(widthsLogo);
                    tableFirstApplicationLogo.DefaultCell.Border = PdfPCell.NO_BORDER;


                    PdfPCell Logo_a6 = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)))
                    {
                        Border = 0
                    };
                    tableFirstApplicationLogo.AddCell(Logo_a6);

                    iTextSharp.text.Image Logo_jpg = iTextSharp.text.Image.GetInstance(Logo_Path);
                    Logo_jpg.ScaleToFit(80f, 60f);
                    Logo_jpg.Border = 0;
                    Logo_jpg.BorderWidth = 0;
                    Logo_jpg.UseVariableBorders = false;
                    Logo_jpg.Alignment = Element.ALIGN_CENTER;

                    tableFirstApplicationLogo.AddCell(Logo_jpg);

                    DateTime dt = DateTime.Now;
                    string daydatetome = String.Format("{0:f}", dt);

                    PdfPCell Logo_c =
                        new PdfPCell(new Phrase("" + daydatetome, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)))
                        {
                            Border = 0,
                            HorizontalAlignment = Element.ALIGN_RIGHT
                        };
                    tableFirstApplicationLogo.AddCell(Logo_c);

                    PdfPCell Title2 =
                        new PdfPCell(new Phrase("COMBINED STATEMENT", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)))
                        {
                            Colspan = 3,
                            BorderWidthRight = 0f,
                            BorderWidthLeft = 0f,
                            BorderWidthTop = 0f,
                            HorizontalAlignment = Element.ALIGN_CENTER
                        };
                    tableFirstApplicationLogo.AddCell(Title2);


                    doc_MY_LOANS_RPT.Add(tableFirstApplicationLogo);


                    #endregion

                    #region CREATE REPORT BODY

                    PdfPTable tableHeaderBody = new PdfPTable(4) { TotalWidth = 448f, LockedWidth = true, SpacingBefore = 5f };
                    float[] widthBody = new float[] { 112f, 112f, 112f, 112f };
                    tableHeaderBody.SetWidths(widthBody);
                    tableHeaderBody.DefaultCell.Border = PdfPCell.NO_BORDER;

                    #region Get Data

                    double CurrentDeposits = Convert.ToDouble(MyClass.FormatNumber(MyClass.CurrentShares(Member_No_)));

                    double MothlySharesContribution = 0, TotalOutstandingLoan = 0;


                    string E_Mail = "", Idno_ = "", Gender = "", DoB = "", Name = "", PhoneNo = "", Branch = "", StaffNo = "", MemberNo="";
                    using (SqlConnection conn = CRUD.getconnToNAV())
                    {
                        string s =
                            String.Format(
                                "SELECT [Payroll No__Check No_], [No_], [E-Mail],[First Name],[Second Name],[Last Name],[ID No_],[Gender], [Phone No_],[Mobile Phone No] FROM [{0}$Member] WHERE [No_]=@Member_No",
                                MyClass.CompanyName);
                        SqlCommand command = new SqlCommand(s, conn);
                        command.Parameters.AddWithValue("@Member_No", Member_No_);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                StaffNo = dr["Payroll No__Check No_"].ToString();
                                MemberNo = dr["No_"].ToString();
                                E_Mail = dr["E-Mail"].ToString();
                                Idno_ = dr["ID No_"].ToString();
                                Name = dr["First Name"].ToString() + " " + dr["Second Name"].ToString() + " " + dr["Last Name"].ToString();
                                Gender = dr["Gender"].ToString();
                                PhoneNo = dr["Mobile Phone No"].ToString() + " " + dr["Phone No_"].ToString();
                                if (Gender == "1")
                                {
                                    Gender = "Female";
                                }
                                else
                                {
                                    Gender = "Male";
                                }


                            }
                        }

                        conn.Close();
                    }

                    #endregion

                    #region CREATE REPORT HEADER

                    PdfPCell cellPDetails = new PdfPCell(new Phrase("PERSONAL DETAILS", tableTh))
                    {
                        Colspan = 4,
                        BorderWidthBottom = 0f,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = RowTh
                    };
                    tableHeaderBody.AddCell(cellPDetails);

                    PdfPCell cellNames = new PdfPCell(new Phrase("Names:", tableTdLabel)) { BorderWidthRight = 0f };
                    tableHeaderBody.AddCell(cellNames);

                    PdfPCell cellEmpty2 = new PdfPCell(new Phrase("", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthLeft = 0f
                    };
                    tableHeaderBody.AddCell(cellEmpty2);

                    PdfPCell cellNames_ = new PdfPCell(new Phrase(Name, tableTddata))
                    {
                        BorderWidthLeft = 0f,
                        BorderWidthRight = 0f
                    };
                    tableHeaderBody.AddCell(cellNames_);

                    PdfPCell cellEmpty_2 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f };
                    tableHeaderBody.AddCell(cellEmpty_2);

                    PdfPCell cellMemberNo = new PdfPCell(new Phrase("Member No:", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellMemberNo);

                    PdfPCell cellEmpty9 = new PdfPCell(new Phrase("", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthLeft = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellEmpty9);

                    PdfPCell cellMemberNo_ = new PdfPCell(new Phrase(MemberNo, tableTddata))
                    {
                        BorderWidthLeft = 0f,
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellMemberNo_);

                    PdfPCell cellEmpty_9 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                    tableHeaderBody.AddCell(cellEmpty_9);

                    PdfPCell cellStaffNo = new PdfPCell(new Phrase("Staff/Payroll No:", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellStaffNo);

                    PdfPCell cellEmpty10 = new PdfPCell(new Phrase("", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthLeft = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellEmpty10);

                    PdfPCell cellStaffNo_ = new PdfPCell(new Phrase(StaffNo, tableTddata))
                    {
                        BorderWidthLeft = 0f,
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellStaffNo_);

                    PdfPCell cellEmpty_10 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                    tableHeaderBody.AddCell(cellEmpty_10);

                    PdfPCell cellIDNo = new PdfPCell(new Phrase("National ID No:", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellIDNo);

                    PdfPCell cellEmpty3 = new PdfPCell(new Phrase("", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthLeft = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellEmpty3);

                    PdfPCell cellIDNo_ = new PdfPCell(new Phrase(Idno_, tableTddata))
                    {
                        BorderWidthLeft = 0f,
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellIDNo_);

                    PdfPCell cellEmpty_3 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                    tableHeaderBody.AddCell(cellEmpty_3);

                    PdfPCell cellEmail = new PdfPCell(new Phrase("E-mail:", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellEmail);

                    PdfPCell cellEmpty4 = new PdfPCell(new Phrase("", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthLeft = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellEmpty4);

                    PdfPCell cellEmail_ = new PdfPCell(new Phrase(E_Mail, tableTddata))
                    {
                        BorderWidthLeft = 0f,
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellEmail_);

                    PdfPCell cellEmpty_4 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                    tableHeaderBody.AddCell(cellEmpty_4);

                    //PdfPCell cellGender = new PdfPCell(new Phrase("Gender:", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthTop = 0f };
                    //tableHeaderBody.AddCell(cellGender);

                    //PdfPCell cellEmpty5 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                    //tableHeaderBody.AddCell(cellEmpty5);

                    //PdfPCell cellGender_ = new PdfPCell(new Phrase(Gender, tableTddata)) { BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f };
                    //tableHeaderBody.AddCell(cellGender_);

                    //PdfPCell cellEmpty_5 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                    //tableHeaderBody.AddCell(cellEmpty_5);

                    PdfPCell cellPhoneNo = new PdfPCell(new Phrase("Mobile Phone No:", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellPhoneNo);

                    PdfPCell cellEmpty6 = new PdfPCell(new Phrase("", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthLeft = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellEmpty6);

                    PdfPCell cellPhoneNo_ = new PdfPCell(new Phrase(PhoneNo, tableTddata))
                    {
                        BorderWidthLeft = 0f,
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellPhoneNo_);

                    PdfPCell cellEmpty_6 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                    tableHeaderBody.AddCell(cellEmpty_6);


                    doc_MY_LOANS_RPT.Add(tableHeaderBody);

                    #endregion

                    #region CREATE REPORTBODY

                    PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
                    float[] widthsBody = new float[] { 20, 90, 90, 90, 90, 90, 90 };
                    tableBody.SetWidths(widthsBody);
                    tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;

                    #region CREATE TABLE TH

                    PdfPCell cellMyLoans = new PdfPCell(new Phrase("COMBINED STATEMENT", tableTh))
                    {
                        Colspan = 8,
                        BorderWidthBottom = 0f,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = RowTh
                    };
                    tableBody.AddCell(cellMyLoans);

                    doc_MY_LOANS_RPT.Add(tableBody);


                    #endregion

                    LoadShareCapital(doc_MY_LOANS_RPT, Member_No_);
                    LoadDepositsContributions(doc_MY_LOANS_RPT, Member_No_);
                    LoadBenevolentContributions(doc_MY_LOANS_RPT, Member_No_);
                    LoadLoansPortfolio(doc_MY_LOANS_RPT, Member_No_);
                    LoadLoansRepayment(doc_MY_LOANS_RPT, Member_No_);
                    LoadInterestDue(doc_MY_LOANS_RPT, Member_No_);
                    LoadInterestPaid(doc_MY_LOANS_RPT, Member_No_);
                    LoadUnallocatedAmount(doc_MY_LOANS_RPT, Member_No_);
                    LoadFooter(doc_MY_LOANS_RPT, Member_No_);



                    #endregion

                    #endregion

                    pdfWriter.CloseStream = true;
                    doc_MY_LOANS_RPT.Close();

                    //#region ========================== Download ============================


                    //try
                    //{



                    //    Stream stream = null;
                    //    Response.Write(filenamePath);

                    //    try
                    //    {

                    //        if (null != filenamePath)
                    //        {
                    //            if (File.Exists(filenamePath))
                    //            {
                    //                String FileName = Path.GetFileName(filenamePath);

                    //                Response.Clear();
                    //                Response.ContentType = "Application/octet-stream";
                    //                Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
                    //                Response.WriteFile(filenamePath);
                    //                Response.End();
                    //            }
                    //        }

                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        // Response.Write(ex.Message);
                    //    }
                    //    finally
                    //    {
                    //        if (stream != null)
                    //        {
                    //            stream.Close();
                    //        }
                    //    }

                    //}
                    //catch (Exception ex)
                    //{
                    //    ex.Data.Clear();
                    //}

                    //#endregion
                    pdfLoans.Attributes.Add("src",
                        ResolveUrl("~/Downloads/" + String.Format("COMBINED_STATEMENT_{0}.pdf", Session["Member_No"].ToString())));

                    #endregion
                }
            }

    }
    }
}