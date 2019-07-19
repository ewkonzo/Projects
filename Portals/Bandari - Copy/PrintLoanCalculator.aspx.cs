using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Net;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using Bandari_Sacco.controller;

namespace Bandari_Sacco
{
    public partial class PrintLoansCalculator : System.Web.UI.Page
    {
        #region Variables

        Font TitleReport = FontFactory.GetFont("Arial", 9, Font.BOLD, Color.BLACK);
        Font tableTh = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);
        Font tableTd = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK);
        Font fnttableHeader = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLUE);

        Color RowTh = new Color(217, 237, 247);
        Color EvenTd = new Color(217, 237, 247);
        Color OddTd = new Color(255, 255, 255);
        //string CompanyName = "Bandari Test";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            else
            {
                string Loan_Type = "-", loan_Amount = "-", Repayment_Period = "-", InterestRate = "-", Monthly_Payment = "-";

                if (Request.QueryString["Loan_Type"] != null)
                {
                    Loan_Type = Request.QueryString["Loan_Type"];
                }
                if (Request.QueryString["loan_Amount"] != null)
                {
                    loan_Amount = Request.QueryString["loan_Amount"];
                }
                if (Request.QueryString["Repayment_Period"] != null)
                {
                    Repayment_Period = Request.QueryString["Repayment_Period"];
                }
                if (Request.QueryString["InterestRate"] != null)
                {
                    InterestRate = Request.QueryString["InterestRate"];
                }
                if (Request.QueryString["Monthly_Payment"] != null)
                {
                    Monthly_Payment = Request.QueryString["Monthly_Payment"];
                }

                string Member_No_ = "";

                Member_No_ = Session["Member_No"].ToString();

                string rptpath = MyClass.ReportsPath();

                string ImagePath = MyClass.ImagesPath();


                #region =============================== CREATE PDF  ===============================

                string fileName = String.Format("LOAN_CALCULATOR_{0}.pdf", Member_No_);
                string filenamePath = String.Format("{0}\\{1}", rptpath, fileName);

                #region Check If File exist

                if (File.Exists(filenamePath))
                {
                    File.Delete(filenamePath);
                }

                #endregion

                Document doc_LOAN_CALCULATOR_RPT = new Document(PageSize.A4);
                doc_LOAN_CALCULATOR_RPT.SetMargins(20f, 10f, 20f, 10f); // Left, Bottom,Top,Right
                doc_LOAN_CALCULATOR_RPT.HtmlStyleClass = "background:red";


                MemoryStream pdfStream = new MemoryStream();
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc_LOAN_CALCULATOR_RPT, new FileStream(filenamePath, FileMode.Create));

                doc_LOAN_CALCULATOR_RPT.Open();

                #endregion

                #region ++++++++++++++++++ REPORT TABLE Logo++++++++++++++++++++++++++++++++++


                string Logo_Path = String.Format("{0}/bandari_logo.jpg", ImagePath);

                PdfPTable tableFirstApplicationLogo = new PdfPTable(3) { TotalWidth = 560f, LockedWidth = true };
                float[] widthsLogo = new float[] { 225f, 110f, 225f };
                tableFirstApplicationLogo.SetWidths(widthsLogo);
                tableFirstApplicationLogo.DefaultCell.Border = PdfPCell.NO_BORDER;


                PdfPCell Logo_a6 = new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK))) { Border = 0 };
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

                PdfPCell Logo_c = new PdfPCell(new Phrase("" + daydatetome, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                tableFirstApplicationLogo.AddCell(Logo_c);

                PdfPCell Title2 = new PdfPCell(new Phrase("LOAN CALCULATOR", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK))) { Colspan = 3, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_CENTER };
                tableFirstApplicationLogo.AddCell(Title2);


                doc_LOAN_CALCULATOR_RPT.Add(tableFirstApplicationLogo);


                #endregion

                #region CREATE REPORT BODY

                #region CREATE Header

                PdfPTable tableHeader = new PdfPTable(3) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f, };
                tableHeader.DefaultCell.Border = PdfPCell.NO_BORDER;

                float[] widthsHeader = new float[] { 220f, 120f, 220f };
                tableHeader.SetWidths(widthsHeader);


                #region Loan Type

                PdfPCell cellLoanType = new PdfPCell(new Phrase("Loan Type:  " + Loan_Type, fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellLoanType);

                PdfPCell cellLoanTypeb = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellLoanTypeb);

                PdfPCell cellLoanTypec = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellLoanTypec);
                #endregion

                #region Loan Amount

                //String.Format("{0:0,0.00}", Monthly_Payment)

                PdfPCell cellLoanAmount = new PdfPCell(new Phrase("Loan Amount:  " + String.Format("{0:0,0.00}", loan_Amount), fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellLoanAmount);

                PdfPCell cellLoanAmountb = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellLoanAmountb);

                PdfPCell cellLoanAmountc = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellLoanAmountc);

                #endregion

                #region Repayment Period (in Months)

                PdfPCell cellRepaymentPeriod = new PdfPCell(new Phrase("Repayment Period (in Months):  " + Repayment_Period, fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellRepaymentPeriod);

                PdfPCell cellRepaymentPeriodb = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellRepaymentPeriodb);

                PdfPCell cellRepaymentPeriodc = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellRepaymentPeriodc);

                #endregion

                #region Interest Rate(Per Month)

                PdfPCell cellInterestRate = new PdfPCell(new Phrase("Interest Rate(Per Month):  " + InterestRate, fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellInterestRate);

                PdfPCell cellInterestRateb = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellInterestRateb);

                PdfPCell cellInterestRatec = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellInterestRatec);

                #endregion

                #region Computed monthly Repayment

                PdfPCell cellComputedMothly = new PdfPCell(new Phrase("Computed monthly Repayment:  " + String.Format("{0:0,0.00}", Monthly_Payment), fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellComputedMothly);

                PdfPCell cellComputedMothlyb = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellComputedMothlyb);

                PdfPCell cellComputedMothlyc = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellComputedMothlyc);

                #endregion

                PdfPCell celllShedule = new PdfPCell(new Phrase("LOAN REPAYMENT SCHEDULE", FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK))) { Colspan = 3, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BorderWidthBottom = 0, HorizontalAlignment = Element.ALIGN_CENTER };
                tableHeader.AddCell(celllShedule);

                doc_LOAN_CALCULATOR_RPT.Add(tableHeader);

                #endregion

                #region CREATE Report Body

                //String.Format("{0:0,0.00}", Monthly_Payment)

                PdfPTable tableBody = new PdfPTable(7) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
                float[] widthBody = new float[] { 80f, 80f, 80f, 80f, 80f, 80f, 80f };
                tableBody.SetWidths(widthBody);
                tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;



                #region CREATE REPORT

                PdfPCell cellPeriod = new PdfPCell(new Phrase("Period", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellPeriod);

                PdfPCell cellMonthYear = new PdfPCell(new Phrase("Month-Year", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellMonthYear);

                PdfPCell cellPrinciple = new PdfPCell(new Phrase("Principle", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellPrinciple);

                PdfPCell cellLoanRepayment = new PdfPCell(new Phrase("Principle Repayment", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellLoanRepayment);

                PdfPCell cellInterest = new PdfPCell(new Phrase("Interest Repayment", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellInterest);

                PdfPCell cellTotalDeduction = new PdfPCell(new Phrase("Monthly Repayment", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellTotalDeduction);

                PdfPCell cellLoanBalance = new PdfPCell(new Phrase("Loan Balance", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellLoanBalance);

                #region Values

                double TotalInterest = 0, Total_LoanRepayment = 0, Total_Deduction = 0; ;

                string Period = "", Month_Year = "", Principle = "", Loan_Repayment = "", Interest = "", Total_Deductions = "", Loan_Balance = "";

                using (SqlConnection conn = CRUD.getconnToNAV())
                {
                    string s = String.Format("SELECT Month,Period,[Principle Amount],[Loan Repayment],Interest,[Total Deduction],[Loan Balance] FROM [{0}$Online Loan Calculator New] WHERE [User ID]=@Member_No", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@Member_No", Member_No_);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int i = 0;
                            while (dr.Read())
                            {
                                i++;

                                Period = dr["Month"].ToString();
                                Month_Year = dr["Period"].ToString();
                                Principle = dr["Principle Amount"].ToString();
                                Loan_Repayment = dr["Loan Repayment"].ToString();
                                Interest = dr["Interest"].ToString();
                                Total_Deductions = dr["Total Deduction"].ToString();
                                Loan_Balance = dr["Loan Balance"].ToString();
                                TotalInterest += Convert.ToDouble(Interest);
                                Total_Deduction += Convert.ToDouble(Total_Deductions);
                                Total_LoanRepayment += Convert.ToDouble(Total_Deductions);

                                if (i % 2 == 0)
                                {

                                    PdfPCell cellPeriod_ = new PdfPCell(new Phrase(Period, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellPeriod_);

                                    PdfPCell cellMonthYear_ = new PdfPCell(new Phrase(Month_Year, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellMonthYear_);

                                    PdfPCell cellPrinciple_ = new PdfPCell(new Phrase(Principle, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellPrinciple_);

                                    PdfPCell cellLoanRepayment_ = new PdfPCell(new Phrase(Loan_Repayment, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellLoanRepayment_);

                                    PdfPCell cellInterest_ = new PdfPCell(new Phrase(Interest, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellInterest_);

                                    PdfPCell cellTotalDeduction_ = new PdfPCell(new Phrase(Total_Deductions, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellTotalDeduction_);

                                    PdfPCell cellLoanBalance_ = new PdfPCell(new Phrase(Loan_Balance, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellLoanBalance_);

                                }
                                else
                                {
                                    PdfPCell cellPeriod_ = new PdfPCell(new Phrase(Period, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellPeriod_);

                                    PdfPCell cellMonthYear_ = new PdfPCell(new Phrase(Month_Year, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellMonthYear_);

                                    PdfPCell cellPrinciple_ = new PdfPCell(new Phrase(Principle, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellPrinciple_);

                                    PdfPCell cellLoanRepayment_ = new PdfPCell(new Phrase(Loan_Repayment, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellLoanRepayment_);

                                    PdfPCell cellInterest_ = new PdfPCell(new Phrase(Interest, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellInterest_);

                                    PdfPCell cellTotalDeduction_ = new PdfPCell(new Phrase(Total_Deductions, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellTotalDeduction_);

                                    PdfPCell cellLoanBalance_ = new PdfPCell(new Phrase(Loan_Balance, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellLoanBalance_);
                                }


                            }
                        }
                    }
                    conn.Close();
                }
                PdfPCell cellFooter1 = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellFooter1);

                PdfPCell cellFooter2 = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellFooter2);

                PdfPCell cellFooter3 = new PdfPCell(new Phrase("TOTALS:", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellFooter3);

                PdfPCell cellFooter4 = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Total_LoanRepayment), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellFooter4);

                PdfPCell cellFooter5 = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", TotalInterest), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellFooter5);

                Total_Deduction = Total_LoanRepayment + TotalInterest;

                PdfPCell cellFooter6 = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Total_Deduction), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellFooter6);

                PdfPCell cellFooter7 = new PdfPCell(new Phrase("", tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellFooter7);

                PdfPCell cellEnd = new PdfPCell(new Phrase("END OF LOAN CALCULATOR", tableTh)) { Colspan = 7, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellEnd);

                #region Footer

                PdfPCell cellVerify = new PdfPCell(new Phrase("Please verify your statement, for any discrepancies please contact Bandari Sacco Ltd", tableTd)) { Colspan = 7, PaddingTop = 15f, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellVerify);

                Font copyRight = FontFactory.GetFont("Arial", 6, Font.ITALIC, Color.BLACK);

                DateTime Yr = DateTime.Now;
                PdfPCell cellCopyRight = new PdfPCell(new Phrase(String.Format("Copyright © {0} - Bandari Sacco", Yr.Year), copyRight)) { Colspan = 7, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellCopyRight);

                #endregion

                #endregion

                doc_LOAN_CALCULATOR_RPT.Add(tableBody);

                #endregion

                #endregion

                #endregion

                pdfWriter.CloseStream = true;
                doc_LOAN_CALCULATOR_RPT.Close();
                pdfLoans.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("LOAN_CALCULATOR_{0}.pdf", Session["Member_No"].ToString())));

            }


        }
    }
}