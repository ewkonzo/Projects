using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Data.SqlClient;
using Bandari_Sacco.controller;

namespace Bandari_Sacco
{
    public partial class PPrint : System.Web.UI.Page
    {
        #region Variables

        Font TitleReport = FontFactory.GetFont("Arial", 9, Font.BOLD, Color.BLACK);
        Font tableTh = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);
        Font tableTd = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK);
        Font fnttableHeader = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLUE);

        Font tableTdLabel = FontFactory.GetFont("Arial", 7, Font.NORMAL, Color.BLACK);
        Font tableTddata = FontFactory.GetFont("Arial", 7, Font.BOLD, Color.BLACK);

        Color RowTh = new Color(191, 219, 255);
        Color EvenTd = new Color(227, 234, 235);
        Color OddTd = new Color(255, 255, 255);
       // string CompanyName = "Bandari Test";
        #endregion


        string Member_No_ = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            showReport();
        }

        private void createPDF()
        {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());//Sets to landscape mode

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(MyClass.ReportsPath() + "My_Payslip_" + Session["Member_No"].ToString() + ".pdf", FileMode.Create));
            doc.Open();
            string Logo_Path = Directory.GetCurrentDirectory()+"\\images\\logo.png";
           // Response.Write(Logo_Path);
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Logo_Path);
            logo.Alignment = 4;
            

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 18, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);

            BaseFont btopTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            iTextSharp.text.Font top_times = new iTextSharp.text.Font(bfTimes, 8, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);

            // Tables Declarations
            int cols = 3;
            PdfPTable table = new PdfPTable(cols);
            //table.TotalWidth = 1000f;
            //table.LockedWidth = true;
            //float[] widths1 = new float[] { 3f, 4f, 3f};
            //table.SetWidths(widths1);
            //PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));

            //cell.Colspan = 3;

            //cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

            //table.AddCell(cell);

            //table.AddCell("Col 1 Row 1");

            //table.AddCell("Col 2 Row 1");

            //table.AddCell("Col 3 Row 1");

            //table.AddCell("Col 1 Row 2");

            //table.AddCell("Col 2 Row 2");

            //table.AddCell("Col 3 Row 2");

            //actual width of table in points

            table.TotalWidth = 1000f;

            //fix the absolute width of the table

            table.LockedWidth = true;



            //relative col widths in proportions - 1/3 and 2/3

            float[] widths = new float[] { 1f, 2f,1f };

            table.SetWidths(widths);

            table.HorizontalAlignment = 0;

            //leave a gap before and after the table

            table.SpacingBefore = 20f;

            table.SpacingAfter = 30f;



            PdfPCell cell = new PdfPCell(new Phrase(new Paragraph("Mwalimu National Sacco Ltd", times)));

            cell.Colspan = 2;

            cell.Border = 0;

            cell.HorizontalAlignment = 1;

            table.AddCell(cell);

            using (SqlConnection conn = MyClass.getconnToNAV())
            {//string query = "SELECT [Application Date],[Interest] FROM [" + Config.companyName + "$Loans]";
                string query = "SELECT DISTINCT [CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[No_],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[First Name],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[Last Name],[Mwalimu Sacco$prPeriod Transactions].[Payroll Period],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[PIN No_],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[Grade],[Transaction Code],[Period Month],[Period Year],[Group Text],[Transaction Name],[Amount],[Balance],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[NSSF No_],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[NHIF No_],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[Branch Bank] ,[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[Bank Account Number] FROM [CoreTEC Sacco].[dbo].[Mwalimu Sacco$prPeriod Transactions] INNER JOIN [CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees] ON [CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[No_] = [CoreTEC Sacco].[dbo].[Mwalimu Sacco$prPeriod Transactions].[Employee Code]  WHERE ([Mwalimu Sacco$prPeriod Transactions].[Employee Code] = '200013')";
                Response.Write(query);
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {

                   // conn.Open();

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        while (rdr.Read())
                        {

                            table.AddCell(rdr[0].ToString());
                            table.AddCell(" ");
                            table.AddCell(rdr[1].ToString());


                        }

                    }

                }

                catch (Exception ex)
                {

                    Response.Write(ex.Message);

                }

                //doc.Add(table);

            }

            
            #region Add Header
           // Paragraph paragraph = new Paragraph("Mwalimu National Sacco Ltd", times);
            //paragraph.IndentationLeft=(100);
            //paragraph.IndentationRight = (100);
            #endregion
            doc.Add(logo);
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph("")); 
            doc.Add(new Paragraph("")); 
            doc.Add(new Paragraph("")); 
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            doc.Add(new Paragraph(""));
            //doc.Add(paragraph);
            doc.Add(table);
            doc.Close();


            pdfPayslip.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("My_Payslip_{0}.pdf", Session["Member_No"].ToString())));
        }

        private void showReport()
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

                string fileName = String.Format("My_Payslip_{0}.pdf", Member_No_);
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

                PdfPCell Title2 = new PdfPCell(new Phrase("Pay Slip", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK))) { Colspan = 3, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_CENTER };
                tableFirstApplicationLogo.AddCell(Title2);


                doc_MY_LOANS_RPT.Add(tableFirstApplicationLogo);


                #endregion

                #region CREATE REPORT BODY

                #region Employee Information Table
                PdfPTable tableEmployeeInformation = new PdfPTable(4) { TotalWidth = 448f, LockedWidth = true, SpacingBefore = 5f };
                float[] widthBody = new float[] { 112f, 112f, 112f, 112f };
                tableEmployeeInformation.SetWidths(widthBody);
                tableEmployeeInformation.DefaultCell.Border = PdfPCell.NO_BORDER;
                #endregion
                #region Staff Information Table
                PdfPTable tableStaffInformation = new PdfPTable(4) { TotalWidth = 448f, LockedWidth = true, SpacingBefore = 5f };
                //float[] widthBody = new float[] { 112f, 112f, 112f, 112f };
                tableStaffInformation.SetWidths(widthBody);
                tableStaffInformation.DefaultCell.Border = PdfPCell.NO_BORDER;


                #endregion

                #region Money Information Table
                PdfPTable tableMoneyInformation = new PdfPTable(4) { TotalWidth = 448f, LockedWidth = true, SpacingBefore = 5f };
                //float[] widthBody = new float[] { 112f, 112f, 112f, 112f };
                tableMoneyInformation.SetWidths(widthBody);
                tableMoneyInformation.DefaultCell.Border = PdfPCell.NO_BORDER;


                #endregion

                #region Get Data

                double CurrentDeposits = Convert.ToDouble(MyClass.FormatNumber(MyClass.CurrentShares(Member_No_)));

                double CurrentDepositsX3 = CurrentDeposits * 3;
                double CurrentDepositsX4 = CurrentDeposits * 4;

                double MothlySharesContribution = 0, TotalOutstandingLoan = 0;

                #region Employee Information
                string employeeNo = "";
                string employeeName = "";
                string period = ""; 
                string PIN = "";
                string grade = "";
                #endregion

                #region Basic Salary
                string basicPay = "";
                
                #endregion

                #region Allowance
                string houseAllowance = "";
                string leaveAllowance = "";
                #endregion

                #region Tax Calculation
                string otherNonTaxableBenefits = "";
                string taxablePay = "";
                string personalRelief = "";
                #endregion


                #region Statutories
                string NHIF = "";
                string NSSF= "";
                #endregion

                #region Net Pay
                string netPay = "";
                #endregion

                #region Staff Information
                string gratuityBalance = "";
                string NSSFNo = "";
                string NHIFNo = "";
                string bankBranch = "";
                string bankName = "";
                string accountNo = "";
                #endregion
                
                MothlySharesContribution = MyClass.MothlySharesContribution(Member_No_);
                TotalOutstandingLoan = MyClass.OutstandingLoanBalance(Member_No_);
                DateTime LastSharePayDate = MyClass.GetLastSharesPayDate(Member_No_);

                //string E_Mail = "", Idno_ = "", Gender = "", DoB = "", Employer_Code = "", Name = "";
                using (SqlConnection conn = CRUD.getconnToNAV())
                {
                    string s = String.Format("SELECT DISTINCT [CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[No_],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[First Name],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[Last Name],[Mwalimu Sacco$prPeriod Transactions].[Payroll Period],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[PIN No_],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[Grade],[Transaction Code],[Period Month],[Period Year],[Group Text],[Transaction Name],[Amount],[Balance],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[NSSF No_],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[NHIF No_],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[Branch Bank] ,[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[Bank Account Number] FROM [CoreTEC Sacco].[dbo].[Mwalimu Sacco$prPeriod Transactions] INNER JOIN [CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees] ON [CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[No_] = [CoreTEC Sacco].[dbo].[Mwalimu Sacco$prPeriod Transactions].[Employee Code]  WHERE ([Mwalimu Sacco$prPeriod Transactions].[Employee Code] =@Member_No)", MyClass.CompanyName);
                    //string s = String.Format("SELECT No_,[E-Mail],Name,[ID No_],Gender,[Date of Birth],[Employer Code] FROM [{0}$Members] WHERE [No_]=@Member_No", CompanyName);
                    SqlCommand command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@Member_No", Member_No_);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while(dr.Read()){
                                
                                employeeNo = dr["No_"].ToString();
                                employeeName = dr["First Name"].ToString() + " " + dr["Last Name"].ToString();
                                period = dr["Payroll Period"].ToString();
                                PIN = dr["PIN No_"].ToString();
                                grade = dr["Grade"].ToString();
                                
                                //basicPay = dr["PIN No_"].ToString();

                                //houseAllowance = dr["PIN No_"].ToString();
                                //leaveAllowance = dr["PIN No_"].ToString();

                                //otherNonTaxableBenefits = dr["PIN No_"].ToString();
                                //taxablePay = dr["PIN No_"].ToString();
                                //personalRelief = dr["PIN No_"].ToString();


                                NHIF = dr["NSSF No_"].ToString();
                                NSSF = dr["NHIF No_"].ToString();


                                netPay = dr["PIN No_"].ToString();

                                gratuityBalance = dr["PIN No_"].ToString();
                                bankBranch = dr["Branch Bank"].ToString();
                                //bankName = dr["PIN No_"].ToString();
                                accountNo = dr["Bank Account Number"].ToString();

                            }

                        }
                    }

                    conn.Close();
                }

                #endregion

                #region Employee Information

               //// PdfPCell cellPDetails = new PdfPCell(new Phrase("PERSONAL DETAILS", tableTh)) { Colspan = 4, BorderWidthBottom = 0f, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = RowTh };
               //// tableHeaderBody.AddCell(cellPDetails);

                PdfPCell cellEmployeeNo = new PdfPCell(new Phrase("Employee No:", tableTdLabel)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellEmployeeNo);

                PdfPCell cellEmployeeNo_ = new PdfPCell(new Phrase(Member_No_, tableTddata)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellEmployeeNo_);

                PdfPCell cellNull0 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellNull0);

                PdfPCell cellNull0_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellNull0_);

                PdfPCell cellEmployeeName = new PdfPCell(new Phrase("Employee Name:", tableTdLabel)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellEmployeeName);

                PdfPCell cellEmployeeName_ = new PdfPCell(new Phrase(employeeName, tableTddata)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellEmployeeName_);

                PdfPCell cellNull1 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellNull1);

                PdfPCell cellNull1_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellNull1_);

                PdfPCell cellPeriod = new PdfPCell(new Phrase("Period:", tableTdLabel)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellPeriod);

                PdfPCell cellPeriod_ = new PdfPCell(new Phrase(period, tableTddata)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellPeriod_);

                PdfPCell cellNull2 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellNull2);

                PdfPCell cellNull2_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellNull2_);

                PdfPCell cellPin = new PdfPCell(new Phrase("RSA PIN:", tableTdLabel)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellPin);

                PdfPCell cellPin_ = new PdfPCell(new Phrase(PIN, tableTddata)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellPin_);


                PdfPCell cellGrade = new PdfPCell(new Phrase("Grade:", tableTdLabel)) { BorderWidth = 0f };
                tableEmployeeInformation.AddCell(cellGrade);

                PdfPCell cellGrade_ = new PdfPCell(new Phrase(grade, tableTddata)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableEmployeeInformation.AddCell(cellGrade_);


                doc_MY_LOANS_RPT.Add(tableEmployeeInformation);

                #endregion

                //#region Basic Pay

                ////PdfPCell cellPDetails = new PdfPCell(new Phrase("Basic Salary", tableTh)) { Colspan = 4, BorderWidthBottom = 0f, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = RowTh };
                ////tableHeaderBody.AddCell(cellPDetails);

                ////PdfPCell cellBasicPay = new PdfPCell(new Phrase("Basic Pay:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellBasicPay);

                ////PdfPCell cellBasicPay_ = new PdfPCell(new Phrase(Member_No_, tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellEmployeeNo_);

                ////PdfPCell cellNullb0 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNullb0);



                ////PdfPCell cellNullb0_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNullb0_);

                ////PdfPCell cellEmployeeName = new PdfPCell(new Phrase("Employee Name:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellEmployeeName);

                ////PdfPCell cellEmployeeName_ = new PdfPCell(new Phrase(employeeName, tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellEmployeeName_);

                ////PdfPCell cellNull1 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull1);

                ////PdfPCell cellNull1_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull1_);

                ////PdfPCell cellPeriod = new PdfPCell(new Phrase("Period:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellPeriod);

                ////PdfPCell cellPeriod_ = new PdfPCell(new Phrase(period, tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellPeriod_);

                ////PdfPCell cellNull2 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull2);

                ////PdfPCell cellNull2_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull2_);

                ////PdfPCell cellPin = new PdfPCell(new Phrase("RSA PIN:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellPin);

                ////PdfPCell cellPin_ = new PdfPCell(new Phrase(PIN, tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellPin_);


                ////PdfPCell cellGrade = new PdfPCell(new Phrase("Grade:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellGrade);

                ////PdfPCell cellGrade_ = new PdfPCell(new Phrase(grade, tableTddata)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                ////tableHeaderBody.AddCell(cellGrade_);


                ////doc_MY_LOANS_RPT.Add(tableHeaderBody);

                //#endregion

                //#region Gross Pay

                //// PdfPCell cellPDetails = new PdfPCell(new Phrase("PERSONAL DETAILS", tableTh)) { Colspan = 4, BorderWidthBottom = 0f, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = RowTh };
                //// tableHeaderBody.AddCell(cellPDetails);

                ////PdfPCell cellEmployeeNo = new PdfPCell(new Phrase("Employee No:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellEmployeeNo);

                ////PdfPCell cellEmployeeNo_ = new PdfPCell(new Phrase(Member_No_, tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellEmployeeNo_);

                ////PdfPCell cellNull0 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull0);

                ////PdfPCell cellNull0_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull0_);

                ////PdfPCell cellEmployeeName = new PdfPCell(new Phrase("Employee Name:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellEmployeeName);

                ////PdfPCell cellEmployeeName_ = new PdfPCell(new Phrase(employeeName, tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellEmployeeName_);

                ////PdfPCell cellNull1 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull1);

                ////PdfPCell cellNull1_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull1_);

                ////PdfPCell cellPeriod = new PdfPCell(new Phrase("Period:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellPeriod);

                ////PdfPCell cellPeriod_ = new PdfPCell(new Phrase(period, tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellPeriod_);

                ////PdfPCell cellNull2 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull2);

                ////PdfPCell cellNull2_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull2_);

                ////PdfPCell cellPin = new PdfPCell(new Phrase("RSA PIN:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellPin);

                ////PdfPCell cellPin_ = new PdfPCell(new Phrase(PIN, tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellPin_);


                ////PdfPCell cellGrade = new PdfPCell(new Phrase("Grade:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellGrade);

                ////PdfPCell cellGrade_ = new PdfPCell(new Phrase(grade, tableTddata)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                ////tableHeaderBody.AddCell(cellGrade_);


                ////doc_MY_LOANS_RPT.Add(tableHeaderBody);

                //#endregion

                //#region Tax Calculations

                //// PdfPCell cellPDetails = new PdfPCell(new Phrase("PERSONAL DETAILS", tableTh)) { Colspan = 4, BorderWidthBottom = 0f, HorizontalAlignment = Element.ALIGN_CENTER, BackgroundColor = RowTh };
                //// tableHeaderBody.AddCell(cellPDetails);

                ////PdfPCell cellEmployeeNo = new PdfPCell(new Phrase("Employee No:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellEmployeeNo);

                ////PdfPCell cellEmployeeNo_ = new PdfPCell(new Phrase(Member_No_, tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellEmployeeNo_);

                ////PdfPCell cellNull0 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull0);

                ////PdfPCell cellNull0_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull0_);

                ////PdfPCell cellEmployeeName = new PdfPCell(new Phrase("Employee Name:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellEmployeeName);

                ////PdfPCell cellEmployeeName_ = new PdfPCell(new Phrase(employeeName, tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellEmployeeName_);

                ////PdfPCell cellNull1 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull1);

                ////PdfPCell cellNull1_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull1_);

                ////PdfPCell cellPeriod = new PdfPCell(new Phrase("Period:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellPeriod);

                ////PdfPCell cellPeriod_ = new PdfPCell(new Phrase(period, tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellPeriod_);

                ////PdfPCell cellNull2 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull2);

                ////PdfPCell cellNull2_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellNull2_);

                ////PdfPCell cellPin = new PdfPCell(new Phrase("RSA PIN:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellPin);

                ////PdfPCell cellPin_ = new PdfPCell(new Phrase(PIN, tableTddata)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellPin_);


                ////PdfPCell cellGrade = new PdfPCell(new Phrase("Grade:", tableTdLabel)) { BorderWidth = 0f };
                ////tableHeaderBody.AddCell(cellGrade);

                ////PdfPCell cellGrade_ = new PdfPCell(new Phrase(grade, tableTddata)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                ////tableHeaderBody.AddCell(cellGrade_);


                ////doc_MY_LOANS_RPT.Add(tableHeaderBody);

                //#endregion

                using (SqlConnection conn = CRUD.getconnToNAV())
                {
                    string s = String.Format("SELECT DISTINCT [CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[No_],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[First Name],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[Last Name],[Mwalimu Sacco$prPeriod Transactions].[Payroll Period],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[PIN No_],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[Grade],[Transaction Code],[Period Month],[Period Year],[Group Text],[Transaction Name],[Amount],[Balance],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[NSSF No_],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[NHIF No_],[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[Branch Bank] ,[CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[Bank Account Number] FROM [CoreTEC Sacco].[dbo].[Mwalimu Sacco$prPeriod Transactions] INNER JOIN [CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees] ON [CoreTEC Sacco].[dbo].[Mwalimu Sacco$HR Employees].[No_] = [CoreTEC Sacco].[dbo].[Mwalimu Sacco$prPeriod Transactions].[Employee Code]  WHERE ([Mwalimu Sacco$prPeriod Transactions].[Employee Code] =@Member_No)", MyClass.CompanyName);
                    //string s = String.Format("SELECT No_,[E-Mail],Name,[ID No_],Gender,[Date of Birth],[Employer Code] FROM [{0}$Members] WHERE [No_]=@Member_No", CompanyName);
                    SqlCommand command = new SqlCommand(s, conn);
                    command.Parameters.AddWithValue("@Member_No", Member_No_);

                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            string transactionName = "";
                            string amount = "";

                            #region Employee Information

                                 PdfPCell cellPDetails = new PdfPCell(new Phrase("OTHER DETAILS", tableTh)) { Colspan = 4, BorderWidth = 0f, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = RowTh };
                                 tableMoneyInformation.AddCell(cellPDetails);
                                 
                            List<string> l = new List<string>();
                            while (dr.Read())
                            {
                                //Add db values to the list

                        l.Add(transactionName = dr["Transaction Name"].ToString());
                        l.Add(amount = dr["Amount"].ToString());
                                PdfPCell cellTransactionName = new PdfPCell(new Phrase(transactionName, tableTdLabel)) { BorderWidth = 0f };
                                tableMoneyInformation.AddCell(cellTransactionName);

                                PdfPCell cellAmount = new PdfPCell(new Phrase(amount, tableTdLabel)) { BorderWidth = 0f };
                                tableMoneyInformation.AddCell(cellAmount);

                                PdfPCell cellTransactionName_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                                tableMoneyInformation.AddCell(cellTransactionName_);



                                PdfPCell cellAmount_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                                tableMoneyInformation.AddCell(cellAmount_);
                             
                            }
                            doc_MY_LOANS_RPT.Add(tableMoneyInformation);

                            

                                #endregion
                                //Response.Write(transactionName + " " + amount);

                        }
                    }

                    conn.Close();
                }




                #region Staff Information
                
                PdfPCell staffInformation = new PdfPCell(new Phrase("Staff Information", tableTh)) { Colspan = 4, BorderWidth = 0f, HorizontalAlignment = Element.ALIGN_LEFT, BackgroundColor = RowTh };
                tableStaffInformation.AddCell(staffInformation);

                PdfPCell cellGratuityBalance = new PdfPCell(new Phrase("Gratuity Bal", tableTdLabel)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellGratuityBalance);

                PdfPCell cellGratuityBalance_ = new PdfPCell(new Phrase(gratuityBalance, tableTddata)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellGratuityBalance_);

                PdfPCell cellNull3 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellNull3);

                PdfPCell cellNull3_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellNull3_);

                PdfPCell cellNSSFNo = new PdfPCell(new Phrase("NSSF No:", tableTdLabel)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellNSSFNo);

                PdfPCell cellNSSFNo_ = new PdfPCell(new Phrase(NSSF, tableTddata)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellNSSFNo_);

                PdfPCell cellNull4 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellNull4);

                PdfPCell cellNull4_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellNull4_);

                PdfPCell cellNHIFNo = new PdfPCell(new Phrase("NHIF No:", tableTdLabel)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellNHIFNo);

                PdfPCell cellNHIFNo_ = new PdfPCell(new Phrase(NHIF, tableTddata)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellNHIFNo_);

                PdfPCell cellNull5 = new PdfPCell(new Phrase("", tableTdLabel)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellNull5);

                PdfPCell cellNull5_ = new PdfPCell(new Phrase("", tableTddata)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellNull5_);

                PdfPCell cellBankBranch = new PdfPCell(new Phrase("Bank Branch:", tableTdLabel)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellBankBranch);

                PdfPCell cellBankBranch_ = new PdfPCell(new Phrase(bankBranch, tableTddata)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellBankBranch_);


                PdfPCell cellAccountNo = new PdfPCell(new Phrase("Account No:", tableTdLabel)) { BorderWidth = 0f };
                tableStaffInformation.AddCell(cellAccountNo);

                PdfPCell cellAccountNo_ = new PdfPCell(new Phrase(accountNo, tableTddata)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableStaffInformation.AddCell(cellAccountNo_);


                doc_MY_LOANS_RPT.Add(tableStaffInformation);

                #endregion

                #region CREATE REPORTBODY

                PdfPTable tableBody = new PdfPTable(8) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
                float[] width_Body = new float[] { 50f, 70f, 70f, 70f, 70f, 70f, 70f, 90f };
                tableBody.SetWidths(width_Body);
                tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;

                
                #region Footer

                PdfPCell cellVerify = new PdfPCell(new Phrase("Please verify your statement, for any discrepancies contact Mwalimu National Sacco Society Ltd. info@mwalimunationalsacco.coop", tableTd)) { Colspan = 8, PaddingTop = 15f, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellVerify);

                Font copyRight = FontFactory.GetFont("Arial", 6, Font.ITALIC, Color.BLACK);

                DateTime Yr = DateTime.Now;
                PdfPCell cellCopyRight = new PdfPCell(new Phrase(String.Format("Copyright © {0} - Mwalimu National Sacco Society Ltd", Yr.Year), copyRight)) { Colspan = 8, HorizontalAlignment = Element.ALIGN_CENTER, BorderWidthRight = 0f, BorderWidthBottom = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f };
                tableBody.AddCell(cellCopyRight);

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
                pdfPayslip.Attributes.Add("src", ResolveUrl("~/Downloads/" + String.Format("My_Payslip_{0}.pdf", Session["Member_No"].ToString())));
                #endregion

            }

            string path = MyClass.ReportsPath();

        }
    
    }
}