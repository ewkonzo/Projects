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
using Bandari_Sacco.controller;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

namespace Bandari_Sacco
{
    public partial class LoansStatement : System.Web.UI.Page
    {
        #region Variables

        Font TitleReport = FontFactory.GetFont("Arial", 9, Font.BOLD, Color.BLACK);
        Font tableTh = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);
        Font tableTd = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK);
        Font fnttableHeader = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLUE);

        Font tableTdLabel = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK);
        Font tableTddata = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);

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
                #region CREATE REPORT

                string Member_No_ = "";
                Member_No_ = Session["Member_No"].ToString();
                string rptpath = MyClass.ReportsPath();
                string ImagePath = MyClass.ImagesPath();

                #region =============================== CREATE PDF  ===============================

                string fileName = String.Format("MY_LOANS_{0}.pdf", Member_No_);
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


                string Logo_Path = String.Format("{0}/logo.png", ImagePath);

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

                PdfPCell Title2 = new PdfPCell(new Phrase("LOAN BALANCES SUMMARY", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK))) { Colspan = 3, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_CENTER };
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


                string E_Mail = "", Idno_ = "", Gender = "", DoB = "", Name = "", PhoneNo="", Branch="";
                using (SqlConnection conn = CRUD.getconnToNAV())
                {
                    string s = String.Format("SELECT [E-Mail],[Name],[ID No_],[Gender], [Mobile Phone No]  FROM [{0}$Member] WHERE [No_]=@Member_No", MyClass.CompanyName);
                    SqlCommand command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@Member_No", Member_No_);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();

                            E_Mail = dr["E-Mail"].ToString();
                            Idno_ = dr["ID No_"].ToString();
                            Name = dr["Name"].ToString();
                            Gender = dr["Gender"].ToString();
                            PhoneNo = dr["Mobile Phone No"].ToString();
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

                PdfPCell cellPDetails = new PdfPCell(new Phrase("PERSONAL DETAILS", tableTh)) { Colspan = 4, BorderWidthBottom = 0f, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = RowTh };
                tableHeaderBody.AddCell(cellPDetails);
  
                PdfPCell cellNames = new PdfPCell(new Phrase("Names:", tableTdLabel)) { BorderWidthRight = 0f };
                tableHeaderBody.AddCell(cellNames);

                PdfPCell cellEmpty2 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmpty2);

                PdfPCell cellNames_ = new PdfPCell(new Phrase(Name, tableTddata)) { BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellNames_);

                PdfPCell cellEmpty_2 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmpty_2);

                PdfPCell cellIDNo = new PdfPCell(new Phrase("National ID No:", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellIDNo);

                PdfPCell cellEmpty3 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmpty3);

                PdfPCell cellIDNo_ = new PdfPCell(new Phrase(Idno_, tableTddata)) { BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellIDNo_);

                PdfPCell cellEmpty_3 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmpty_3);

                PdfPCell cellEmail = new PdfPCell(new Phrase("E-mail:", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmail);

                PdfPCell cellEmpty4 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmpty4);

                PdfPCell cellEmail_ = new PdfPCell(new Phrase(E_Mail, tableTddata)) { BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f };
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

                PdfPCell cellPhoneNo = new PdfPCell(new Phrase("Mobile Phone No:", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellPhoneNo);

                PdfPCell cellEmpty6 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmpty6);

                PdfPCell cellPhoneNo_ = new PdfPCell(new Phrase(PhoneNo, tableTddata)) { BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellPhoneNo_);

                PdfPCell cellEmpty_6 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmpty_6);

                PdfPCell cellWorkstation = new PdfPCell(new Phrase("Branch/Workstation:", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellWorkstation);

                PdfPCell cellEmpty7 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmpty7);

                PdfPCell cellWorkstation_ = new PdfPCell(new Phrase(Branch, tableTddata)) { BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellWorkstation_);

                PdfPCell cellEmpty_7 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmpty_7);

                PdfPCell cellCurrentDeposits = new PdfPCell(new Phrase("Total Current Deposits:", tableTdLabel))
                {
                    BorderWidthRight = 0f, BorderWidthTop = 0f
                };
                tableHeaderBody.AddCell(cellCurrentDeposits);

                PdfPCell cellEmpty8 = new PdfPCell(new Phrase("", tableTdLabel))
                {
                    BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f
                };
                tableHeaderBody.AddCell(cellEmpty8);

                PdfPCell cellCurrentDeposits_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", CurrentDeposits),tableTdLabel))
                {
                    BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f
                };
                tableHeaderBody.AddCell(cellCurrentDeposits_);

                PdfPCell cellEmpty_8 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmpty_8);



                doc_MY_LOANS_RPT.Add(tableHeaderBody);

                #endregion

                #region CREATE REPORTBODY

                PdfPTable tableBody = new PdfPTable(8) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
                float[] width_Body = new float[] { 50f, 70f, 70f, 70f, 70f, 70f, 70f, 90f };
                tableBody.SetWidths(width_Body);
                tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;

                #region CREATE TABLE TH

                PdfPCell cellMyLoans = new PdfPCell(new Phrase("Loan Balances Summary", tableTh)) { Colspan = 8, BorderWidthBottom = 0f, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = RowTh };
                tableBody.AddCell(cellMyLoans);

                PdfPCell cellPeriod = new PdfPCell(new Phrase("#", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellPeriod);

                PdfPCell cellMonthYear = new PdfPCell(new Phrase("Loan No", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellMonthYear);

                PdfPCell cellLoanType = new PdfPCell(new Phrase("Loan Type", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellLoanType);

                PdfPCell cellPrinciple = new PdfPCell(new Phrase("Issue Date", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellPrinciple);

                PdfPCell cellLoanRepayment = new PdfPCell(new Phrase("Term (Months)", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellLoanRepayment);

                PdfPCell cellInterest = new PdfPCell(new Phrase("End Date", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellInterest);

                PdfPCell cellTotalDeduction = new PdfPCell(new Phrase("Approved Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellTotalDeduction);

                PdfPCell cellLoanBalance = new PdfPCell(new Phrase("Outstanding Balance", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellLoanBalance);

                #endregion

                #region Values

                string Loan_No_ = "", Issue_Date = "", Term = "", End_Date = "", Loan_Type = "";
                DateTime End_Date_ = DateTime.Now;
                DateTime dt_;
                double Approved_Amount_ = 0, Outstanding_Balance_ = 0;

                using (SqlConnection conn = CRUD.getconnToNAV())
                {
                    //string s = "SELECT a.[Loan  No_],a.[Issued Date],a.[Application Date],a.Installments,a.[Approved Amount],b.[Product Description]" +
                    //                " FROM [" + CompanyName + "$Loans] a,[" + CompanyName + "$Loan Product Types] b" +
                    //                " WHERE [Member No_]=@Member_No AND a.[Loan Product Type]=b.[Code] ORDER BY [Application Date] DESC"; SqlCommand command = new SqlCommand(s, conn);

                    string s = "SELECT a.[Loan  No_],a.[Loan Disbursement Date],a.[Application Date],a.Installments,a.[Approved Amount],b.[Product Description]" +
                                   " FROM [" + MyClass.CompanyName + "$Loans] a,[" + MyClass.CompanyName + "$Loan Product Types] b" +
                                   " WHERE [Member No_]=@Member_No ORDER BY [Application Date] DESC"; SqlCommand command = new SqlCommand(s, conn);

                    command.Parameters.AddWithValue("@Member_No", Member_No_);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            int i = 0;
                            while (dr.Read())
                            {
                                i++;

                                Loan_No_ = dr["Loan  No_"].ToString();
                               

                                //if (dr["Issued Date"] != null)
                                //{
                                //    dt_ = Convert.ToDateTime(dr["Issued Date"]);
                                //    Issue_Date = dt_.ToString("dd-MM-yyyy");
                                //    End_Date_ = Convert.ToDateTime(dt_.AddMonths(Convert.ToInt32(dr["Installments"])).ToShortDateString());
                                //    End_Date = End_Date_.ToString("dd-MM-yyyy");
                                //}

                                if (dr["Loan Disbursement Date"] != null)
                                {
                                    dt_ = Convert.ToDateTime(dr["Loan Disbursement Date"]);
                                    Issue_Date = dt_.ToString("dd-MM-yyyy");
                                    End_Date_ = Convert.ToDateTime(dt_.AddMonths(Convert.ToInt32(dr["Installments"])).ToShortDateString());
                                    End_Date = End_Date_.ToString("dd-MM-yyyy");
                                }
                                else if (dr["Application Date"] != null)
                                {
                                    dt_ = Convert.ToDateTime(dr["Application Date"]);
                                    Issue_Date = dt_.ToString("dd-MM-yyyy");
                                    End_Date_ = Convert.ToDateTime(dt_.AddMonths(Convert.ToInt32(dr["Installments"])).ToShortDateString());
                                    End_Date = End_Date_.ToString("dd-MM-yyyy");
                                }

                                Loan_Type = dr["Product Description"].ToString().ToUpper();

                                
                                Term = dr["Installments"].ToString();
                                
                                Approved_Amount_ = Convert.ToDouble(dr["Approved Amount"].ToString());
                                Outstanding_Balance_ = MyClass.OutstandingSpecificLoanBalanceWithConnection(Loan_No_, conn);

                                if (i % 2 == 0)
                                {

                                    PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellPeriod_);

                                    //Loan_Type

                                    PdfPCell cellLoanNo_ = new PdfPCell(new Phrase(Loan_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellLoanNo_);

                                    PdfPCell cellLoan_Type_ = new PdfPCell(new Phrase(Loan_Type, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellLoan_Type_);

                                    PdfPCell cellIssueDate_ = new PdfPCell(new Phrase(Issue_Date, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellIssueDate_);

                                    PdfPCell cellTerm_ = new PdfPCell(new Phrase(Term, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellTerm_);

                                    PdfPCell cellEndDate_ = new PdfPCell(new Phrase(End_Date, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellEndDate_);

                                    PdfPCell cellApprovedAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Approved_Amount_), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellApprovedAmount_);

                                    PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Outstanding_Balance_), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellOutstaLoanBalance_);

                                }
                                else
                                {
                                    PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellPeriod_);

                                    PdfPCell cellLoan_No_ = new PdfPCell(new Phrase(Loan_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellLoan_No_);

                                    PdfPCell cellLoan_Type_ = new PdfPCell(new Phrase(Loan_Type, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellLoan_Type_);

                                    PdfPCell cellIssueDate_ = new PdfPCell(new Phrase(Issue_Date, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellIssueDate_);

                                    PdfPCell cellTerm_ = new PdfPCell(new Phrase(Term, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellTerm_);

                                    PdfPCell cellEndDate_ = new PdfPCell(new Phrase(End_Date, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellEndDate_);

                                    PdfPCell cellApprovedAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Approved_Amount_), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellApprovedAmount_);

                                    PdfPCell cellOutstaLoanBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Outstanding_Balance_), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellOutstaLoanBalance_);
                                }


                            }
                        }
                    }
                    conn.Close();
                }

                PdfPCell cellEnd = new PdfPCell(new Phrase("END OF MY LOANS REPORT", tableTh)) { Colspan = 8, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellEnd);

                #region Footer

                PdfPCell cellVerify = new PdfPCell(new Phrase("Please verify your statement, for any discrepancies contact PostBank Sacco Society Ltd. sacco@postbank.co.ke", tableTd)) { Colspan = 8, PaddingTop = 15f, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellVerify);

                Font copyRight = FontFactory.GetFont("Arial", 6, Font.ITALIC, Color.BLACK);

                DateTime Yr = DateTime.Now;
                PdfPCell cellCopyRight = new PdfPCell(new Phrase(String.Format("Copyright © {0} - PostBank Sacco Society Ltd", Yr.Year), copyRight)) { Colspan = 8, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellCopyRight);

                #endregion

                #endregion

                doc_MY_LOANS_RPT.Add(tableBody);

                #endregion

                #endregion

                pdfWriter.CloseStream = true;
                doc_MY_LOANS_RPT.Close();

                //#region ========================== Download ============================


                //try
                //{

                //    //    HELB.Attributes.Add("src", filenamePath);

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
pdfLoans.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("MY_LOANS_{0}.pdf", Session["Member_No"].ToString())));
                #endregion

            }

            string path = MyClass.ReportsPath();
            
        }

        

    }
}