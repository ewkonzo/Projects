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
    public partial class ShareCapital : System.Web.UI.Page
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
            string membernumber = Session["Member_No"].ToString();
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
      
            if(!IsPostBack)
             {                
                PopulateDropDownList(membernumber);
             }
              
            
        }

        #endregion

        private void PopulateDropDownList(string membernumber)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = null;
                ddlAccount.Items.Clear();

                using (SqlConnection conn = MyClass.getconnToNAV())
                {
                    string A = "SELECT [No_] FROM[" + MyClass.CompanyName + "$SACCO Account] WHERE [Member No_] = @MemberNo AND [No_] Like 'S01%' " +
                               "UNION " +
                               "SELECT [No_] FROM[" + MyClass.CompanyName + "$SACCO Account] WHERE [Member No_] = @MemberNo AND [No_] Like 'S02%' " +
                               "UNION " +
                               "SELECT [No_] FROM[" + MyClass.CompanyName + "$SACCO Account] WHERE [Member No_] = @MemberNo AND [No_] Like 'S06%'";

                    SqlCommand command = new SqlCommand(A, conn);
                    command.Parameters.AddWithValue("@MemberNo", membernumber);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                li = new System.Web.UI.WebControls.ListItem(dr["No_"].ToString());
                                ddlAccount.Items.Add(li);
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            #region CREATE REPORT

            string Member_No_ = "";
            Member_No_ = Session["Member_No"].ToString();

            string rptpath = MyClass.ReportsPath();
            string ImagePath = MyClass.ImagesPath();

            #region =============================== CREATE PDF  ===============================

            string fileName = String.Format("NON_WITHDRAWABLE_DEPOSITS_STATEMENT_{0}.pdf", Member_No_);
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

            PdfPCell Title2 = new PdfPCell(new Phrase("NON WITHDRAWABLE DEPOSITS STATEMENT", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK))) { Colspan = 3, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_CENTER };
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

            double MothlySharesContribution = 0, TotalOutstandingLoan = 0;


            string E_Mail = "", Idno_ = "", Gender = "", DoB = "", Name = "", PhoneNo = "", Branch = "", StaffNo = "", MemberNo = "";
            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                string s = String.Format("SELECT [Payroll No__Check No_], [No_],[E-Mail],[Name],[ID No_],[Gender],[Phone No_], [Mobile Phone No]  FROM [{0}$Member] WHERE [No_]=@Member_No", MyClass.CompanyName);
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
                        Name = dr["Name"].ToString();
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

            PdfPCell cellPDetails = new PdfPCell(new Phrase("PERSONAL DETAILS", tableTh)) { Colspan = 4, BorderWidthBottom = 0f, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = RowTh };
            tableHeaderBody.AddCell(cellPDetails);

            PdfPCell cellNames = new PdfPCell(new Phrase("Names:", tableTdLabel)) { BorderWidthRight = 0f };
            tableHeaderBody.AddCell(cellNames);

            PdfPCell cellEmpty2 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidthRight = 0f, BorderWidthLeft = 0f };
            tableHeaderBody.AddCell(cellEmpty2);

            PdfPCell cellNames_ = new PdfPCell(new Phrase(Name, tableTddata)) { BorderWidthLeft = 0f, BorderWidthRight = 0f };
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

            PdfPCell cellAccountType = new PdfPCell(new Phrase("Account Type:", tableTdLabel))
            {
                BorderWidthRight = 0f,
                BorderWidthTop = 0f
            };
            tableHeaderBody.AddCell(cellAccountType);

            PdfPCell cellEmpty11 = new PdfPCell(new Phrase("", tableTdLabel))
            {
                BorderWidthRight = 0f,
                BorderWidthLeft = 0f,
                BorderWidthTop = 0f
            };
            tableHeaderBody.AddCell(cellEmpty11);

            PdfPCell cellAccountType_ = new PdfPCell(new Phrase(ddlAccount.SelectedItem.Text, tableTddata))
            {
                BorderWidthLeft = 0f,
                BorderWidthRight = 0f,
                BorderWidthTop = 0f
            };
            tableHeaderBody.AddCell(cellAccountType_);

            PdfPCell cellEmpty_11 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
            tableHeaderBody.AddCell(cellEmpty_11);


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



            doc_MY_LOANS_RPT.Add(tableHeaderBody);

            #endregion

            #region CREATE REPORTBODY

            PdfPTable tableBody = new PdfPTable(6) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            float[] width_Body = new float[] { 60f, 100f, 100f, 100f, 100f, 100f };
            tableBody.SetWidths(width_Body);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;

            #region CREATE TABLE TH

            PdfPCell cellMyLoans = new PdfPCell(new Phrase("NON WITHDRAWABLE DEPOSITS STATEMENT", tableTh)) { Colspan = 6, BorderWidthBottom = 0f, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = RowTh };
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

            string Document_No_ = "", Description = "";
            double Amount_ = 0, Closing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;
            string accountnumber = ddlAccount.SelectedItem.Text;

            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                //  string s = "SELECT [Posting Date],[Document No_],[Amount],[Description] FROM [" + CompanyName + "$Member Ledger Entry] " +
                //"WHERE [Transaction Types]=14 AND [Customer No_]=@Member_No ORDER BY [Posting Date] asc";

                string s = "SELECT a.[Posting Date],a.[Document No_],a.[Description],a.[Amount],a.[Debit Amount],a.[Credit Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a " +
                    "WHERE a.[Customer No_] =@CustomerNo AND a.[Transaction Types]=1 " +
                    "ORDER BY a.[Posting Date] DESC";

                //   string s = "SELECT a.[Posting Date],a.[Document No_],a.[Description],b.Amount,b.[Debit Amount],b.[Credit Amount] FROM [" + MyClass.CompanyName + "$Cust_ Ledger Entry] a,[" + MyClass.CompanyName + "$Detailed Cust_ Ledg_ Entry] b" +
                //" WHERE a.[Entry No_]=b.[Cust_ Ledger Entry No_] AND a.[Transaction Types]=13 AND a.[Customer No_]=@Member_No  ORDER BY a.[Posting Date] asc";    

                SqlCommand command = new SqlCommand(s, conn);

                command.Parameters.AddWithValue("@CustomerNo", accountnumber);

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
                            Description = dr["Description"].ToString().Trim();
                            Amount_ = -Convert.ToDouble(dr["Amount"].ToString().Trim());
                            Closing_Balance += Amount_;

                            //Posting_Date = Convert.ToDateTime(dr["Posting Date"].ToString().Trim());
                            //Document_No_ = dr["Document No_"].ToString().Trim();
                            //Description = dr["Description"].ToString().Trim();
                            //Amount_ = -Convert.ToDouble(dr["Amount"].ToString().Trim());
                            //Closing_Balance += Amount_;


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

            PdfPCell cellEnd = new PdfPCell(new Phrase("END OF NON WITHDRAWABLE DEPOSITS STATEMENT", tableTh)) { Colspan = 6, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
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
            pdfLoans.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("NON_WITHDRAWABLE_DEPOSITS_STATEMENT_{0}.pdf", Session["Member_No"].ToString())));

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

            #endregion


        }
    }
}