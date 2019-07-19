using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.Net;
using Bandari_Sacco.controller;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

namespace Bandari_Sacco
{
    public partial class LoanRepayment : System.Web.UI.Page
    {
        #region Variables



        private Font TitleReport = FontFactory.GetFont("Arial", 9, Font.BOLD, Color.BLACK);
        private Font tableTh = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);
        private Font tableTd = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK);
        private Font tableTd_ = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);
        private Font fnttableHeader = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLUE);

        private Font tableTdLabel = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK);
        private Font tableTddata = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);

        private Color RowTh = new Color(217, 237, 247);
        private Color EvenTd = new Color(217, 237, 247);
        private Color OddTd = new Color(255, 255, 255);
        //private string CompanyName = "Bandari Test";

        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            string membernumber = Session["Member_No"].ToString();
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                PopulateDropDownList(membernumber);
            }


        }

        #endregion

        private void LoadLoans(Document doc_MY_LOANS_RPT, string Member_No_)
        {
            string Document_No_ = "", Description = "-", Reversed = "0";
            double Amount_ = 0,
                Closing_Balance = 0,
                Credit_Amount = 0,
                Debit_Amount = 0,
                Total_Credit_Amount = 0,
                TotalClosing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;

            PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            float[] widthsBody = new float[] { 20, 90, 90, 90, 90, 90, 90 };
            tableBody.SetWidths(widthsBody);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;

            #region  Loans

            Document_No_ = "";
            Description = "-";
            Reversed = "0";
            Amount_ = 0;
            Closing_Balance = 0;
            Credit_Amount = 0;
            Debit_Amount = 0;
            Total_Credit_Amount = 0;
            TotalClosing_Balance = 0;
            Posting_Date = DateTime.Now;

            string Loan_No_ = "", Loan_Product_Type_ = "", Mode_of_Disbursement = "";
            double Approved_Amount = 0;
            int Approved_Repayment = 0;
            string loannumber = ddlAccount.SelectedItem.Text;
            if (loannumber == string.Empty)
            {
                loannumber = "1";
            }


            using (SqlConnection conn = MyClass.getconnToNAV())
            {
                string s =
                    "SELECT a.[Loan  No_],a.[Loan Product Type],a.[Mode of Disbursement],a.[Approved Amount],a.[Repayment],a.[Loan Product Type Name], b.[Product ID], b.[Product Description] " +
                    "FROM [" + MyClass.CompanyName + "$Loans]a,  [" + MyClass.CompanyName + "$Product Factory]b " +
                    "WHERE [Loan Account]=@LoanNo AND a.[Loan Product Type] = b.[Product ID] ORDER BY [Application Date] DESC";

                SqlCommand command = new SqlCommand(s, conn);
                command.Parameters.AddWithValue("@Member_No", Member_No_);
                command.Parameters.AddWithValue("@LoanNo", loannumber);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {

                        #region CREATE TABLE TH

                        PdfPCell cellPeriod = new PdfPCell(new Phrase("#", tableTh))
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            BorderWidthRight = 0f,
                            BackgroundColor = RowTh
                        };
                        tableBody.AddCell(cellPeriod);

                        PdfPCell cellMonthYear = new PdfPCell(new Phrase("Posting Date", tableTh))
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            BorderWidthRight = 0f,
                            BorderWidthLeft = 0f,
                            BackgroundColor = RowTh
                        };
                        tableBody.AddCell(cellMonthYear);

                        PdfPCell cellLoanType = new PdfPCell(new Phrase("Document No.", tableTh))
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            BorderWidthRight = 0f,
                            BorderWidthLeft = 0f,
                            BackgroundColor = RowTh
                        };
                        tableBody.AddCell(cellLoanType);

                        PdfPCell cellPrinciple = new PdfPCell(new Phrase("Description", tableTh))
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            BorderWidthRight = 0f,
                            BorderWidthLeft = 0f,
                            BackgroundColor = RowTh
                        };
                        tableBody.AddCell(cellPrinciple);

                        PdfPCell cellLoanRepayment = new PdfPCell(new Phrase("Debit Amount", tableTh))
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            BorderWidthRight = 0f,
                            BorderWidthLeft = 0f,
                            BackgroundColor = RowTh
                        };
                        tableBody.AddCell(cellLoanRepayment);

                        PdfPCell cellInterest = new PdfPCell(new Phrase("Credit Amount", tableTh))
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            BorderWidthRight = 0f,
                            BorderWidthLeft = 0f,
                            BackgroundColor = RowTh
                        };
                        tableBody.AddCell(cellInterest);

                        PdfPCell cellLoanBalance = new PdfPCell(new Phrase("Balance", tableTh))
                        {
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            BorderWidthLeft = 0f,
                            BackgroundColor = RowTh
                        };
                        tableBody.AddCell(cellLoanBalance);


                        #endregion

                        int i = 0;
                        while (dr.Read())
                        {
                            i++;

                            Amount_ = 0;
                            Closing_Balance = 0;
                            Credit_Amount = 0;
                            Debit_Amount = 0;
                            Total_Credit_Amount = 0;
                            TotalClosing_Balance = 0;


                            //Loan_No_ = dr["Loan  No_"].ToString().Trim();
                            Loan_No_ = ddlAccount.SelectedItem.Text;
                            Mode_of_Disbursement = dr["Mode of Disbursement"].ToString().Trim();
                            Loan_Product_Type_ = dr["Product Description"].ToString().Trim();

                            Approved_Amount = Convert.ToDouble(dr["Approved Amount"].ToString().Trim());

                            if (string.IsNullOrEmpty(dr["Repayment"].ToString()) == false)
                            {
                                Approved_Repayment = Convert.ToInt32(dr["Repayment"]);
                            }

                            switch (Mode_of_Disbursement)
                            {
                                //Individual Cheques,Cheque,Transfer to FOSA,FOSA Loans,M-Pesa,Partial Disbursement
                                case "0":
                                    Mode_of_Disbursement = "Individual Cheques";
                                    break;
                                case "1":
                                    Mode_of_Disbursement = "Cheque";
                                    break;
                                case "2":
                                    Mode_of_Disbursement = "Transfer To FOSA";
                                    break;
                                case "3":
                                    Mode_of_Disbursement = "FOSA Loans";
                                    break;
                                case "4":
                                    Mode_of_Disbursement = "M-Pesa";
                                    break;
                                case "5":
                                    Mode_of_Disbursement = "Partial Disbursement";
                                    break;
                                default:
                                    Mode_of_Disbursement = "";
                                    break;
                            }

                            if (i % 2 == 0)
                            {

                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd_))
                                {
                                    HorizontalAlignment = Element.ALIGN_LEFT,
                                    BorderWidthRight = 0f,
                                    BorderWidthTop = 0f,
                                    BackgroundColor = EvenTd,
                                    BorderWidthBottom = 0f
                                };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellLoanNo_ = new PdfPCell(new Phrase("Number: " + Loan_No_, tableTd_))
                                {
                                    HorizontalAlignment = Element.ALIGN_LEFT,
                                    BorderWidthRight = 0f,
                                    BorderWidthLeft = 0f,
                                    BorderWidthTop = 0f,
                                    BackgroundColor = EvenTd,
                                    BorderWidthBottom = 0f
                                };
                                tableBody.AddCell(cellLoanNo_);

                                PdfPCell cellLoan_Type_ =
                                    new PdfPCell(new Phrase("Mode of Disbursement: " + Mode_of_Disbursement, tableTd_))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = EvenTd,
                                        BorderWidthBottom = 0f
                                    };
                                tableBody.AddCell(cellLoan_Type_);

                                PdfPCell cellIssueDate_ =
                                    new PdfPCell(new Phrase("Product Type: " + Loan_Product_Type_, tableTd_))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = EvenTd,
                                        BorderWidthBottom = 0f
                                    };
                                tableBody.AddCell(cellIssueDate_);

                                PdfPCell cellTerm_ =
                                    new PdfPCell(
                                        new Phrase("Approved Amount:" + String.Format("{0:0,0.00}", Approved_Amount),
                                            tableTd_))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = EvenTd,
                                        BorderWidthBottom = 0f
                                    };
                                tableBody.AddCell(cellTerm_);

                                PdfPCell cellRepayment_ =
                                    new PdfPCell(new Phrase("Repayment:" + Approved_Repayment, tableTd_))
                                    {
                                        Colspan = 2,
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = EvenTd,
                                        BorderWidthBottom = 0f
                                    };
                                tableBody.AddCell(cellRepayment_);


                                #region Loans Header

  
                                //string L_ =
                                //    "SELECT [Posting Date],[Document No_],[Description],Amount,[Debit Amount],[Credit Amount]" +
                                //    " FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                                //    " WHERE [Transaction Types] in (2,3,5,6) AND [Posting Date] BETWEEN @StartDate AND @EndDate " +
                                //    " AND [Customer No_]=@Member_No AND [Loan No]=@Loan_No ORDER BY [Posting Date] asc";

                                string L_ = "SELECT TOP 20 [Posting Date], [Document No_], [Description], [Amount], [Debit Amount], [Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                                            "WHERE [Customer No_]=@LoanNo  " +
                                            "ORDER BY [Posting Date] DESC";

                                SqlCommand command_Loan = new SqlCommand(L_, conn);
                                command_Loan.Parameters.AddWithValue("@LoanNo", Loan_No_);

                                using (SqlDataReader dr_L = command_Loan.ExecuteReader())
                                {
                                    if (dr_L.HasRows)
                                    {
                                        int b = 0;
                                        while (dr_L.Read())
                                        {
                                            b++;
                                            if (string.IsNullOrEmpty(dr_L["Posting Date"].ToString()) == false)
                                            {
                                                Posting_Date = Convert.ToDateTime(dr_L["Posting Date"].ToString().Trim());
                                            }
                                            Document_No_ = dr_L["Document No_"].ToString().Trim();
                                            Description = dr_L["Description"].ToString().Trim();
                                            Amount_ = -Convert.ToDouble(dr_L["Amount"].ToString().Trim());

                                            Debit_Amount = Convert.ToDouble(dr_L["Debit Amount"].ToString().Trim());
                                            Credit_Amount = Convert.ToDouble(dr_L["Credit Amount"].ToString().Trim());

                                            Closing_Balance = Credit_Amount - Debit_Amount;

                                            Total_Credit_Amount += Credit_Amount;
                                            TotalClosing_Balance += Closing_Balance;

                                            #region Values

                                            PdfPCell cellNo_ = new PdfPCell(new Phrase("", tableTd))
                                            {
                                                BorderWidthBottom = 0f,
                                                BorderWidthRight = 0f,
                                                BackgroundColor = OddTd
                                            };
                                            tableBody.AddCell(cellNo_);

                                            PdfPCell cellMemberNo_ =
                                                new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd))
                                                {
                                                    BorderWidthBottom = 0f,
                                                    BorderWidthRight = 0f,
                                                    BorderWidthLeft = 0,
                                                    BackgroundColor = OddTd
                                                };
                                            tableBody.AddCell(cellMemberNo_);

                                            PdfPCell cellMemberName_ = new PdfPCell(new Phrase(Document_No_, tableTd))
                                            {
                                                BorderWidthBottom = 0f,
                                                BorderWidthRight = 0f,
                                                BorderWidthLeft = 0,
                                                BackgroundColor = OddTd
                                            };
                                            tableBody.AddCell(cellMemberName_);

                                            PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd))
                                            {
                                                BorderWidthBottom = 0f,
                                                BorderWidthRight = 0f,
                                                BorderWidthLeft = 0,
                                                BackgroundColor = OddTd
                                            };
                                            tableBody.AddCell(cellDesc_);

                                            PdfPCell cellDebitAmount_ =
                                                new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount),
                                                    tableTd))
                                                {
                                                    BorderWidthBottom = 0f,
                                                    BorderWidthRight = 0f,
                                                    BorderWidthLeft = 0,
                                                    BackgroundColor = OddTd
                                                };
                                            tableBody.AddCell(cellDebitAmount_);

                                            PdfPCell cellCreditAmount__ =
                                                new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount),
                                                    tableTd))
                                                {
                                                    BorderWidthBottom = 0f,
                                                    BorderWidthRight = 0f,
                                                    BorderWidthLeft = 0,
                                                    BackgroundColor = OddTd
                                                };
                                            tableBody.AddCell(cellCreditAmount__);

                                            PdfPCell cellAmountGuaranteed_ =
                                                new PdfPCell(
                                                    new Phrase(String.Format("{0:0,0.00}", -TotalClosing_Balance),
                                                        tableTd))
                                                {
                                                    BorderWidthBottom = 0f,
                                                    BorderWidthLeft = 0,
                                                    BackgroundColor = OddTd
                                                };
                                            tableBody.AddCell(cellAmountGuaranteed_);

                                            #endregion
                                        }

                                        PdfPCell cellEmpty = new PdfPCell(new Phrase("", tableTd))
                                        {
                                            Colspan = 7,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = OddTd
                                        };
                                        tableBody.AddCell(cellEmpty);
                                    }
                                }





                                #endregion

                            }
                            else
                            {
                                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd_))
                                {
                                    HorizontalAlignment = Element.ALIGN_LEFT,
                                    BorderWidthRight = 0f,
                                    BorderWidthTop = 0f,
                                    BackgroundColor = EvenTd,
                                    BorderWidthBottom = 0f
                                };
                                tableBody.AddCell(cellPeriod_);

                                PdfPCell cellLoan_No_ = new PdfPCell(new Phrase("Number: " + Loan_No_, tableTd_))
                                {
                                    HorizontalAlignment = Element.ALIGN_LEFT,
                                    BorderWidthRight = 0f,
                                    BorderWidthLeft = 0f,
                                    BorderWidthTop = 0f,
                                    BackgroundColor = EvenTd,
                                    BorderWidthBottom = 0f
                                };
                                tableBody.AddCell(cellLoan_No_);

                                PdfPCell cellLoan_Type_ =
                                    new PdfPCell(new Phrase("Mode of Disbursement: " + Mode_of_Disbursement, tableTd_))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = EvenTd,
                                        BorderWidthBottom = 0f
                                    };
                                tableBody.AddCell(cellLoan_Type_);

                                PdfPCell cellIssueDate_ =
                                    new PdfPCell(new Phrase("Product Type: " + Loan_Product_Type_, tableTd_))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = EvenTd,
                                        BorderWidthBottom = 0f
                                    };
                                tableBody.AddCell(cellIssueDate_);

                                PdfPCell cellTerm_ =
                                    new PdfPCell(
                                        new Phrase("Approved Amount:" + String.Format("{0:0,0.00}", Approved_Amount),
                                            tableTd_))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = EvenTd,
                                        BorderWidthBottom = 0f
                                    };
                                tableBody.AddCell(cellTerm_);

                                PdfPCell cellEndDate_ =
                                    new PdfPCell(new Phrase("Repayment:" + Approved_Repayment, tableTd_))
                                    {
                                        Colspan = 2,
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = EvenTd,
                                        BorderWidthBottom = 0f
                                    };
                                tableBody.AddCell(cellEndDate_);

                                #region Loans Header

                                //string L_ =
                                //    "SELECT [Posting Date],[Document No_],[Description],Amount,[Debit Amount],[Credit Amount]" +
                                //    " FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                                //    " WHERE [Transaction Types] in (2,3,5,6) AND [Posting Date] BETWEEN @StartDate AND @EndDate " +
                                //    " AND [Customer No_]=@Member_No AND [Loan No]=@Loan_No ORDER BY [Posting Date] asc";

                                string L_ = "SELECT TOP 20 [Posting Date], [Document No_], [Description], [Amount], [Debit Amount], [Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry] " +
                                            "WHERE [Customer No_]=@Loan_No " +
                                            "ORDER BY [Posting Date] DESC";

                                SqlCommand command_Loan = new SqlCommand(L_, conn);
                                //command_Loan.Parameters.AddWithValue("@Member_No", Member_No_);
                                command_Loan.Parameters.AddWithValue("@Loan_No", Loan_No_);

                                using (SqlDataReader dr_L = command_Loan.ExecuteReader())
                                {
                                    if (dr_L.HasRows)
                                    {
                                        int b = 0;
                                        while (dr_L.Read())
                                        {
                                            b++;
                                            if (string.IsNullOrEmpty(dr_L["Posting Date"].ToString()) == false)
                                            {
                                                Posting_Date = Convert.ToDateTime(dr_L["Posting Date"].ToString().Trim());
                                            }
                                            Document_No_ = dr_L["Document No_"].ToString().Trim();
                                            Description = dr_L["Description"].ToString().Trim();
                                            Amount_ = -Convert.ToDouble(dr_L["Amount"].ToString().Trim());

                                            Debit_Amount = Convert.ToDouble(dr_L["Debit Amount"].ToString().Trim());
                                            Credit_Amount = Convert.ToDouble(dr_L["Credit Amount"].ToString().Trim());

                                            Closing_Balance = Credit_Amount - Debit_Amount;

                                            Total_Credit_Amount += Credit_Amount;
                                            TotalClosing_Balance += Closing_Balance;

                                            #region Values

                                            PdfPCell cellNo_ = new PdfPCell(new Phrase("", tableTd))
                                            {
                                                BorderWidthBottom = 0f,
                                                BorderWidthRight = 0f,
                                                BackgroundColor = OddTd
                                            };
                                            tableBody.AddCell(cellNo_);

                                            PdfPCell cellMemberNo_ =
                                                new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd))
                                                {
                                                    BorderWidthBottom = 0f,
                                                    BorderWidthRight = 0f,
                                                    BorderWidthLeft = 0,
                                                    BackgroundColor = OddTd
                                                };
                                            tableBody.AddCell(cellMemberNo_);

                                            PdfPCell cellMemberName_ = new PdfPCell(new Phrase(Document_No_, tableTd))
                                            {
                                                BorderWidthBottom = 0f,
                                                BorderWidthRight = 0f,
                                                BorderWidthLeft = 0,
                                                BackgroundColor = OddTd
                                            };
                                            tableBody.AddCell(cellMemberName_);

                                            PdfPCell cellDesc_ = new PdfPCell(new Phrase(Description, tableTd))
                                            {
                                                BorderWidthBottom = 0f,
                                                BorderWidthRight = 0f,
                                                BorderWidthLeft = 0,
                                                BackgroundColor = OddTd
                                            };
                                            tableBody.AddCell(cellDesc_);

                                            PdfPCell cellDebitAmount_ =
                                                new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Debit_Amount),
                                                    tableTd))
                                                {
                                                    BorderWidthBottom = 0f,
                                                    BorderWidthRight = 0f,
                                                    BorderWidthLeft = 0,
                                                    BackgroundColor = OddTd
                                                };
                                            tableBody.AddCell(cellDebitAmount_);

                                            PdfPCell cellCreditAmount__ =
                                                new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Credit_Amount),
                                                    tableTd))
                                                {
                                                    BorderWidthBottom = 0f,
                                                    BorderWidthRight = 0f,
                                                    BorderWidthLeft = 0,
                                                    BackgroundColor = OddTd
                                                };
                                            tableBody.AddCell(cellCreditAmount__);

                                            PdfPCell cellAmountGuaranteed_ =
                                                new PdfPCell(
                                                    new Phrase(String.Format("{0:0,0.00}", -TotalClosing_Balance),
                                                        tableTd))
                                                {
                                                    BorderWidthBottom = 0f,
                                                    BorderWidthLeft = 0,
                                                    BackgroundColor = OddTd
                                                };
                                            tableBody.AddCell(cellAmountGuaranteed_);

                                            #endregion
                                        }
                                        PdfPCell cellEmpty = new PdfPCell(new Phrase("", tableTd))
                                        {
                                            Colspan = 7,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = OddTd
                                        };
                                        tableBody.AddCell(cellEmpty);
                                    }
                                }







                                #endregion
                            }


                        }
                    }
                }
                conn.Close();
            }



            #endregion

            doc_MY_LOANS_RPT.Add(tableBody);
        }

        private void LoadFooter(Document doc_MY_LOANS_RPT, string Member_No_)
        {
            string Document_No_ = "", Description = "-", Reversed = "0";
            double Amount_ = 0,
                Closing_Balance = 0,
                Credit_Amount = 0,
                Debit_Amount = 0,
                Total_Credit_Amount = 0,
                TotalClosing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;

            PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            float[] widthsBody = new float[] { 20, 90, 90, 90, 90, 90, 90 };
            tableBody.SetWidths(widthsBody);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;

            #region Footer

            PdfPCell cellEnd = new PdfPCell(new Phrase("END OF LOAN STATEMENT", tableTh))
            {
                Colspan = 7,
                HorizontalAlignment = Element.ALIGN_CENTER,
                BorderWidthRight = 0f,
                BorderWidthBottom = 0f,
                BorderWidthLeft = 0f,
                BorderWidthTop = 0f
            };
            tableBody.AddCell(cellEnd);

            PdfPCell cellVerify =
                new PdfPCell(
                    new Phrase(
                        "Please verify your statement, for any discrepancies contact Bandari Sacco Society Ltd. info@bandarisacco.co.ke",
                        tableTd))
                {
                    Colspan = 7,
                    PaddingTop = 15f,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BorderWidthRight = 0f,
                    BorderWidthBottom = 0f,
                    BorderWidthLeft = 0f,
                    BorderWidthTop = 0f
                };
            tableBody.AddCell(cellVerify);

            Font copyRight = FontFactory.GetFont("Arial", 6, Font.ITALIC, Color.BLACK);

            DateTime Yr = DateTime.Now;
            PdfPCell cellCopyRight =
                new PdfPCell(new Phrase(String.Format("Copyright © {0} - Bandari Sacco Society Ltd", Yr.Year),
                    copyRight))
                {
                    Colspan = 7,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BorderWidthRight = 0f,
                    BorderWidthBottom = 0f,
                    BorderWidthLeft = 0f,
                    BorderWidthTop = 0f
                };
            tableBody.AddCell(cellCopyRight);

            #endregion

            doc_MY_LOANS_RPT.Add(tableBody);
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
                    #region CREATE REPORT
                    //clear label
                    lblError.Text = string.Empty;
                    string Member_No_ = "";
                    Member_No_ = Session["Member_No"].ToString();
                    string rptpath = MyClass.ReportsPath();
                    string ImagePath = MyClass.ImagesPath();

                    #region =============================== CREATE PDF  ===============================

                    string fileName = String.Format("LOAN_STATEMENT_{0}.pdf", Member_No_);
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
                        new PdfPCell(new Phrase("LOAN STATEMENT",
                            FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)))
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


                    string E_Mail = "", Idno_ = "", Gender = "", DoB = "", Name = "", PhoneNo = "", Branch = "", StaffNo = "", MemberNo = "";
                    using (SqlConnection conn = CRUD.getconnToNAV())
                    {
                        string s =
                            String.Format(
                                " SELECT [Payroll No__Check No_], [No_],[E-Mail],[First Name],[Second Name],[Last Name],[ID No_],[Gender], [Phone No_],[Mobile Phone No] FROM [{0}$Member] WHERE [No_]=@Member_No",
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

                    PdfPCell cellStaffNo = new PdfPCell(new Phrase("Staff/Payroll No:", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellStaffNo);

                    PdfPCell cellEmpty10_ = new PdfPCell(new Phrase("", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthLeft = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellEmpty10_);

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

                    PdfPCell cellMyLoans = new PdfPCell(new Phrase("LOAN STATEMENT", tableTh))
                    {
                        Colspan = 8,
                        BorderWidthBottom = 0f,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = RowTh
                    };
                    tableBody.AddCell(cellMyLoans);

                    doc_MY_LOANS_RPT.Add(tableBody);


                    #endregion

                    LoadLoans(doc_MY_LOANS_RPT, Member_No_);
                    LoadFooter(doc_MY_LOANS_RPT, Member_No_);

                    #endregion

                    #endregion

                    pdfWriter.CloseStream = true;
                    doc_MY_LOANS_RPT.Close();

                    pdfLoans.Attributes.Add("src",
                        ResolveUrl("~/Downloads/" +
                                   String.Format("LOAN_STATEMENT_{0}.pdf", Session["Member_No"].ToString())));

                   

                    #endregion
                }

        private void PopulateDropDownList(string membernumber)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = null;
                ddlAccount.Items.Clear();

                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = "SELECT [Loan Account] FROM [" + MyClass.CompanyName + "$Loans] WHERE [Member No_]=@MemberNo";
                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@MemberNo", membernumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                li = new System.Web.UI.WebControls.ListItem(dr["Loan Account"].ToString());
                                ddlAccount.Items.Add(li);
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //throw;
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }

    
    }
}