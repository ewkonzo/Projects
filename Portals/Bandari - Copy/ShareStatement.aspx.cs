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
    public partial class ShareStatement : System.Web.UI.Page
    {
        #region Variables

        Font TitleReport = FontFactory.GetFont("Arial", 9, Font.BOLD, Color.BLACK);
        Font tableTh = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);
        Font tableTd = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK);
        Font fnttableHeader = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLUE);

        Font tableTdLabel = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK);
        Font tableTddata = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);

        Color RowTh = new Color(217, 237, 247);
        Color EvenTd = new Color(255, 255, 255);
        Color OddTd = new Color(255, 255, 255);
        //string CompanyName = "Bandari Test";
        #endregion

        #region Page_Load

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

                string fileName = String.Format("DEPOSITS_STATEMENT_{0}.pdf", Member_No_);
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

                PdfPCell Title2 = new PdfPCell(new Phrase("DEPOSITS/SHARES STATEMENT", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK))) { Colspan = 3, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_CENTER };
                tableFirstApplicationLogo.AddCell(Title2);


                doc_MY_LOANS_RPT.Add(tableFirstApplicationLogo);


                #endregion

                #region CREATE REPORT

                PdfPTable tableHeaderBody = new PdfPTable(4) { TotalWidth = 448f, LockedWidth = true, SpacingBefore = 5f };
                float[] widthBody = new float[] { 112f, 112f, 112f, 112f };
                tableHeaderBody.SetWidths(widthBody);
                tableHeaderBody.DefaultCell.Border = PdfPCell.NO_BORDER;

                #region Get Data

                double CurrentDeposits = Convert.ToDouble(MyClass.FormatNumber(MyClass.CurrentShares(Member_No_)));

                double CurrentDepositsX3 = CurrentDeposits * 3;
                double CurrentDepositsX4 = CurrentDeposits * 4;

                double MothlySharesContribution = 0, TotalOutstandingLoan = 0;

                MothlySharesContribution = MyClass.MothlySharesContribution(Member_No_);
                TotalOutstandingLoan = MyClass.OutstandingLoanBalance(Member_No_);
                DateTime LastSharePayDate = MyClass.GetLastSharesPayDate(Member_No_);

                string E_Mail = "", Idno_ = "", Gender = "", DoB = "", Employer_Code = "", Name = "";
                using (SqlConnection conn = CRUD.getconnToNAV())
                {
                    string s = String.Format("SELECT No_,[E-Mail],Name,[ID No_],Gender,[Date of Birth],[Employer Code] FROM [{0}$Member] WHERE [No_]=@Member_No", MyClass.CompanyName);
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
                            if (Gender == "1")
                            {
                                Gender = "Female";
                            }
                            else
                            {
                                Gender = "Male";
                            }
                            DoB = dr["Date of Birth"].ToString();
                            Employer_Code = dr["Employer Code"].ToString();
                        }
                    }

                    conn.Close();
                }

                #endregion

                #region CREATE REPORT HEADER

                PdfPCell cellPDetails = new PdfPCell(new Phrase("PERSONAL DETAILS", tableTh)) { Colspan = 4, BorderWidthBottom = 0f, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = RowTh };
                tableHeaderBody.AddCell(cellPDetails);

                PdfPCell cellMembeNo = new PdfPCell(new Phrase("Member No:", tableTdLabel)) { BorderWidthRight = 0f };
                tableHeaderBody.AddCell(cellMembeNo);

                PdfPCell cellMembeNo_ = new PdfPCell(new Phrase(Member_No_, tableTddata)) { BorderWidthRight = 0f, BorderWidthLeft = 0f };
                tableHeaderBody.AddCell(cellMembeNo_);

                PdfPCell cellCurrentDeposits = new PdfPCell(new Phrase("Current Deposits:", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthLeft = 0f };
                tableHeaderBody.AddCell(cellCurrentDeposits);

                PdfPCell cellCurrentDeposits_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", CurrentDeposits), tableTddata)) { BorderWidthLeft = 0f };
                tableHeaderBody.AddCell(cellCurrentDeposits_);

                PdfPCell cellNames = new PdfPCell(new Phrase("Names:", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellNames);

                PdfPCell cellNames_ = new PdfPCell(new Phrase(Name, tableTddata)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellNames_);

                PdfPCell cellCurrentDepX3 = new PdfPCell(new Phrase("Current Deposits X 3:", tableTdLabel)) { BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellCurrentDepX3);

                PdfPCell cellCurrentDepX3_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", CurrentDepositsX3), tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellCurrentDepX3_);

                PdfPCell cellIDNo = new PdfPCell(new Phrase("ID No:", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellIDNo);

                PdfPCell cellIDNo_ = new PdfPCell(new Phrase(Idno_, tableTddata)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellIDNo_);

                PdfPCell cellCurrentDepX4 = new PdfPCell(new Phrase("Current Deposits X 4:", tableTdLabel)) { BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellCurrentDepX4);

                PdfPCell cellCurrentDepX4_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", CurrentDepositsX4), tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellCurrentDepX4_);

                PdfPCell cellEmail = new PdfPCell(new Phrase("E-mail:", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmail);

                PdfPCell cellEmail_ = new PdfPCell(new Phrase(E_Mail, tableTddata)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmail_);

                PdfPCell cellMonthly = new PdfPCell(new Phrase("Monthly Shares Contribution:", tableTdLabel)) { BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellMonthly);

                PdfPCell cellMonthly_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", MothlySharesContribution), tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellMonthly_);

                PdfPCell cellGender = new PdfPCell(new Phrase("Gender:", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellGender);

                PdfPCell cellGender_ = new PdfPCell(new Phrase(Gender, tableTddata)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellGender_);

                PdfPCell cellLastShare = new PdfPCell(new Phrase("Last Share Pay Date:", tableTdLabel)) { BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellLastShare);

                PdfPCell cellLastShare_ = new PdfPCell(new Phrase(LastSharePayDate.ToLongDateString(), tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellLastShare_);

                PdfPCell cellEmpty = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmpty);

                PdfPCell cellEmpty_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellEmpty_);

                PdfPCell cellTotalOuts = new PdfPCell(new Phrase("Total Outstanding Loan:", tableTdLabel)) { BorderWidthLeft = 0f, BorderWidthRight = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellTotalOuts);

                PdfPCell cellTotalOuts_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", TotalOutstandingLoan), tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableHeaderBody.AddCell(cellTotalOuts_);

                doc_MY_LOANS_RPT.Add(tableHeaderBody);

                #endregion

                #region CREATE REPORTBODY

                PdfPTable tableBody = new PdfPTable(6) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
                float[] width_Body = new float[] { 60f, 100f, 100f, 100f, 100f, 100f };
                tableBody.SetWidths(width_Body);
                tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;

                #region CREATE TABLE TH

                PdfPCell cellMyLoans = new PdfPCell(new Phrase("DEPOSITS STATEMENT", tableTh)) { Colspan = 6, BorderWidthBottom = 0f, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = RowTh };
                tableBody.AddCell(cellMyLoans);

                PdfPCell cellNo = new PdfPCell(new Phrase("#", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellNo);

                PdfPCell cellPostingDate = new PdfPCell(new Phrase("Posting Date", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellPostingDate);

                PdfPCell cellDocumentNo = new PdfPCell(new Phrase("Document No.", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellDocumentNo);

                PdfPCell cellDescription = new PdfPCell(new Phrase("Description", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellDescription);

                PdfPCell cellAmount = new PdfPCell(new Phrase("Amount", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellAmount);

                PdfPCell cellClosingBalance = new PdfPCell(new Phrase("Closing Balance", tableTh)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BackgroundColor = RowTh };
                tableBody.AddCell(cellClosingBalance);

                #endregion

                #region Values

                string Document_No_ = "", Description = "-";
                double Amount_ = 0, Closing_Balance = 0;
                DateTime Posting_Date = DateTime.Now;

                using (SqlConnection conn = CRUD.getconnToNAV())
                {
                  //  string s = "SELECT [Posting Date],[Document No_],Amount FROM [" + CompanyName + "$Member Ledger Entry] " +
                  //"WHERE [Transaction Types]=8 AND [Customer No_]=@Member_No ORDER BY [Posting Date] asc";

                    string s = "SELECT a.[Posting Date],a.[Document No_],a.[Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b  " +
                        "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Transaction Types]=1 " +
                        "ORDER BY a.[Posting Date] asc";

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

                                Posting_Date = Convert.ToDateTime(dr["Posting Date"].ToString().Trim());
                                Document_No_ = dr["Document No_"].ToString().Trim();
                                Amount_ = -Convert.ToDouble(dr["Amount"].ToString().Trim());
                                Closing_Balance += Amount_;


                                if (i % 2 == 0)
                                {

                                    PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellPeriod_);

                                    PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellPostingDate_);

                                    PdfPCell cellDocument_No_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellDocument_No_);

                                    PdfPCell cellDescription_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellDescription_);

                                    PdfPCell cellAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Amount_), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellAmount_);

                                    PdfPCell cellClosingBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = EvenTd };
                                    tableBody.AddCell(cellClosingBalance_);

                                }
                                else
                                {
                                    PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellPeriod_);

                                    PdfPCell cellPostingDate_ = new PdfPCell(new Phrase(Posting_Date.ToString("dd-MM-yyyy"), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellPostingDate_);

                                    PdfPCell cellDocument_No_ = new PdfPCell(new Phrase(Document_No_, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellDocument_No_);

                                    PdfPCell cellDescription_ = new PdfPCell(new Phrase(Description, tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellDescription_);

                                    PdfPCell cellAmount_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Amount_), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellAmount_);

                                    PdfPCell cellClosingBalance_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Closing_Balance), tableTd)) { HorizontalAlignment = Element.ALIGN_LEFT, BorderWidthLeft = 0f, BorderWidthTop = 0f, BackgroundColor = OddTd };
                                    tableBody.AddCell(cellClosingBalance_);
                                }


                            }
                        }
                    }
                    conn.Close();
                }

                PdfPCell cellEnd = new PdfPCell(new Phrase("END OF DEPOSITS STATEMENT REPORT", tableTh)) { Colspan = 6, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellEnd);

                #region Footer

                PdfPCell cellVerify = new PdfPCell(new Phrase("Please verify your statement, for any discrepancies contact Bandari Sacco Society Ltd. info@bandarisacco.co.ke", tableTd)) { Colspan = 6, PaddingTop = 15f, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellVerify);

                Font copyRight = FontFactory.GetFont("Arial", 6, Font.ITALIC, Color.BLACK);

                DateTime Yr = DateTime.Now;
                PdfPCell cellCopyRight = new PdfPCell(new Phrase(String.Format("Copyright © {0} - Bandari Sacco Society Ltd", Yr.Year), copyRight)) { Colspan = 6, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellCopyRight);

                #endregion

                #endregion

                doc_MY_LOANS_RPT.Add(tableBody);

                #endregion

                #endregion

                pdfWriter.CloseStream = true;
                doc_MY_LOANS_RPT.Close();

                #region ========================== Download ============================


                try
                {

                    //    HELB.Attributes.Add("src", filenamePath);

                    Stream stream = null;
                    Response.Write(filenamePath);

                    try
                    {

                        if (null != filenamePath)
                        {
                            if (File.Exists(filenamePath))
                            {
                                String FileName = Path.GetFileName(filenamePath);

                                Response.Clear();
                                Response.ContentType = "Application/octet-stream";
                                Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
                                Response.WriteFile(filenamePath);
                                Response.End();
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        // Response.Write(ex.Message);
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                    }

                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }

                #endregion

                #endregion

            }

        }

        #endregion
    }
}