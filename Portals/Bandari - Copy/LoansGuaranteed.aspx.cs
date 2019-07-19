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
    public partial class LoansGuaranteed : System.Web.UI.Page
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
            #region CREATE REPORT
            string Member_No_ = "";
            Member_No_ = Session["Member_No"].ToString();
            string rptpath = MyClass.ReportsPath();
            string ImagePath = MyClass.ImagesPath();

            #region =============================== CREATE PDF  ===============================

            string fileName = String.Format("LOANS_GUARANTEED_{0}.pdf", Member_No_);
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
                new PdfPCell(new Phrase("LOANS GUARANTEED STATEMENT",
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

            MothlySharesContribution = MyClass.MothlySharesContribution(Member_No_);
            TotalOutstandingLoan = MyClass.OutstandingLoanBalance(Member_No_);
            DateTime LastSharePayDate = MyClass.GetLastSharesPayDate(Member_No_);

            string E_Mail = "", Idno_ = "", Gender = "", DoB = "", Name = "", PhoneNo = "", Branch = "", StaffNo = "", MemberNo = "";
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

            PdfPTable tableBody = new PdfPTable(9) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
            // float[] width_Body = new float[] { 50f, 70f, 70f, 70f, 70f, 70f, 70f, 90f };
            // tableBody.SetWidths(width_Body);
            tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;

            #region CREATE TABLE TH

            PdfPCell cellMyLoans = new PdfPCell(new Phrase("LOANS GUARANTEED", tableTh))
            {
                Colspan = 9,
                BorderWidthBottom = 0f,
                HorizontalAlignment = Element.ALIGN_CENTER,
                BackgroundColor = RowTh
            };
            tableBody.AddCell(cellMyLoans);

            PdfPCell cellMonthYear = new PdfPCell(new Phrase("Loan No", tableTh))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                BorderWidthRight = 0f,
                BackgroundColor = RowTh
            };
            tableBody.AddCell(cellMonthYear);

            PdfPCell cellLoanType = new PdfPCell(new Phrase("Loan Type", tableTh))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                BorderWidthRight = 0f,
                BorderWidthLeft = 0f,
                BackgroundColor = RowTh
            };
            tableBody.AddCell(cellLoanType);

            PdfPCell cellMemberName = new PdfPCell(new Phrase("Member Name", tableTh))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                BorderWidthRight = 0f,
                BorderWidthLeft = 0f,
                BackgroundColor = RowTh
            };
            tableBody.AddCell(cellMemberName);

          

            PdfPCell cellTotalDeduction = new PdfPCell(new Phrase("Approved Amount", tableTh))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                BorderWidthRight = 0f,
                BorderWidthLeft = 0f,
                BackgroundColor = RowTh
            };
            tableBody.AddCell(cellTotalDeduction);

            PdfPCell cellOutsatandingBal = new PdfPCell(new Phrase("Outstanding Balance", tableTh))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                BorderWidthRight = 0f,
                BorderWidthLeft = 0f,
                BackgroundColor = RowTh
            };
            tableBody.AddCell(cellOutsatandingBal);

            PdfPCell cellLastPayDate = new PdfPCell(new Phrase("Last Pay Date", tableTh))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                BorderWidthRight = 0f,
                BorderWidthLeft = 0f,
                BackgroundColor = RowTh
            };
            tableBody.AddCell(cellLastPayDate);

            PdfPCell cellInitialObligation = new PdfPCell(new Phrase("Initial Obligation", tableTh))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                BorderWidthRight = 0f,
                BorderWidthLeft = 0f,
                BackgroundColor = RowTh
            };
            tableBody.AddCell(cellInitialObligation);

            PdfPCell cellObligationPercentage = new PdfPCell(new Phrase("Obligation (%) ", tableTh))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                BorderWidthRight = 0f,
                BorderWidthLeft = 0f,
                BackgroundColor = RowTh
            };
            tableBody.AddCell(cellObligationPercentage);

            PdfPCell cellLoanCurrentObligation = new PdfPCell(new Phrase("Current Obligation", tableTh))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                BorderWidthLeft = 0f,
                BackgroundColor = RowTh
            };
            tableBody.AddCell(cellLoanCurrentObligation);

            #endregion

            #region Values


            string Loan_No_ = "", Loan_Type = "", Issue_Date = "", Term = "", End_Date = "";
            string MemberName_ = "";
            double Amont_Guaranteed = 0;
            DateTime End_Date_ = DateTime.Now, Last_Pay_Date = DateTime.Now;

            double Approved_Amount_ = 0, Outstanding_Balance_ = 0, Obligation = 0, Current_Obligation = 0;

            using (SqlConnection conn = CRUD.getconnToNAV())
            {
              

                string s =
                   "SELECT TOP 20 a.[Loan  No_],a.[Loan Disbursement Date],a.[Application Date],a.Installments,a.[Approved Amount],b.[Product Description],d.[Name],c.[Amount Guaranteed]" +
                   " FROM [" + MyClass.CompanyName + "$Loans] a,[" + MyClass.CompanyName + "$Product Factory] b," +
                   " [" + MyClass.CompanyName + "$Loan Guarantors] c,[" + MyClass.CompanyName + "$Member] d" +
                   " WHERE  a.[Loan  No_]=c.[Loan No] " +
                   " AND c.[Member Guaranteed]=@Member_No " +
                   " AND a.[Member No_]=d.[No_] " +
                   " AND a.[Approved Amount] > 0 " +
                   " AND c.[Amount Guaranteed]>0" +
                   " AND a.[Loan Status] <> 6 " +
                   " ORDER BY [Application Date] DESC";

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

                            Loan_No_ = dr["Loan  No_"].ToString();
                            //  DateTime dt = DateTime.Now;

                            Last_Pay_Date = MyClass.GetLoanLastPayDateWithConnection(Loan_No_, conn);

                            MemberName_ = dr["Name"].ToString();

                            //if (dr["Issued Date"] != null)
                            //{
                            //    dt = Convert.ToDateTime(dr["Issued Date"]);
                            //}

                            if (dr["Loan Disbursement Date"] != null)
                            {
                                dt = Convert.ToDateTime(dr["Loan Disbursement Date"]);
                            }
                            else if (dr["Application Date"] != null)
                            {
                                dt = Convert.ToDateTime(dr["Application Date"]);
                            }
                            Loan_Type = dr["Product Description"].ToString().ToUpper();
                            Issue_Date = dt.ToString("dd-MM-yyyy");
                            Term = dr["Installments"].ToString();
                            End_Date_ =
                                Convert.ToDateTime(dt.AddMonths(Convert.ToInt32(dr["Installments"])).ToShortDateString());
                            End_Date = End_Date_.ToString("dd-MM-yyyy");
                            Approved_Amount_ = Convert.ToDouble(dr["Approved Amount"].ToString());
                            Amont_Guaranteed = Convert.ToDouble(dr["Amount Guaranteed"].ToString());
                           // Outstanding_Balance_ = MyClass.OutstandingSpecificLoanBalanceWithConnection(Loan_No_, conn);
                            Outstanding_Balance_ = GetOustandingBalance(Loan_No_, conn);
                            Obligation = ((Amont_Guaranteed / Approved_Amount_) * 100);
                            Current_Obligation = ((Obligation * Outstanding_Balance_) / 100);

                            if (Outstanding_Balance_ > 0.1)
                            {
                                lblError.Text = string.Empty;
                                if (i % 2 == 0)
                                {


                                    PdfPCell cellLoanNo_ = new PdfPCell(new Phrase(Loan_No_, tableTd))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = EvenTd
                                    };
                                    tableBody.AddCell(cellLoanNo_);

                                    PdfPCell cellLoan_Type_ = new PdfPCell(new Phrase(Loan_Type, tableTd))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = EvenTd
                                    };
                                    tableBody.AddCell(cellLoan_Type_);

                                    PdfPCell cellMemberName_ = new PdfPCell(new Phrase(MemberName_, tableTd))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = EvenTd
                                    };
                                    tableBody.AddCell(cellMemberName_);



                                    PdfPCell cellApprovedAmount_ =
                                        new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Approved_Amount_), tableTd))
                                        {
                                            HorizontalAlignment = Element.ALIGN_LEFT,
                                            BorderWidthRight = 0f,
                                            BorderWidthLeft = 0f,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = EvenTd
                                        };
                                    tableBody.AddCell(cellApprovedAmount_);

                                    PdfPCell cellOutsatandingBal_ =
                                        new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Outstanding_Balance_), tableTd))
                                        {
                                            HorizontalAlignment = Element.ALIGN_LEFT,
                                            BorderWidthRight = 0f,
                                            BorderWidthLeft = 0f,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = EvenTd
                                        };
                                    tableBody.AddCell(cellOutsatandingBal_);

                                    PdfPCell cellLastPayDate_ =
                                        new PdfPCell(new Phrase(Last_Pay_Date.ToString("dd-MM-yyyy"), tableTd))
                                        {
                                            HorizontalAlignment = Element.ALIGN_LEFT,
                                            BorderWidthRight = 0f,
                                            BorderWidthLeft = 0f,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = EvenTd
                                        };
                                    tableBody.AddCell(cellLastPayDate_);

                                    PdfPCell cellInitialObligation_ =
                                        new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Amont_Guaranteed), tableTd))
                                        {
                                            HorizontalAlignment = Element.ALIGN_LEFT,
                                            BorderWidthRight = 0f,
                                            BorderWidthLeft = 0f,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = EvenTd
                                        };
                                    tableBody.AddCell(cellInitialObligation_);

                                    PdfPCell cellObligationPercentage_ =
                                        new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Obligation), tableTd))
                                        {
                                            HorizontalAlignment = Element.ALIGN_LEFT,
                                            BorderWidthRight = 0f,
                                            BorderWidthLeft = 0f,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = EvenTd
                                        };
                                    tableBody.AddCell(cellObligationPercentage_);

                                    PdfPCell cellCurrent_Obligation_ =
                                        new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Current_Obligation), tableTd))
                                        {
                                            HorizontalAlignment = Element.ALIGN_LEFT,
                                            BorderWidthLeft = 0f,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = EvenTd
                                        };
                                    tableBody.AddCell(cellCurrent_Obligation_);


                                }
                                else
                                {
                                    PdfPCell cellLoanNo_ = new PdfPCell(new Phrase(Loan_No_, tableTd))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = OddTd
                                    };
                                    tableBody.AddCell(cellLoanNo_);

                                    PdfPCell cellLoan_Type_ = new PdfPCell(new Phrase(Loan_Type, tableTd))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = OddTd
                                    };
                                    tableBody.AddCell(cellLoan_Type_);

                                    PdfPCell cellMemberName_ = new PdfPCell(new Phrase(MemberName_, tableTd))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = OddTd
                                    };
                                    tableBody.AddCell(cellMemberName_);

                                    PdfPCell cellIssueDate_ = new PdfPCell(new Phrase(Issue_Date, tableTd))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = OddTd
                                    };
                                    tableBody.AddCell(cellIssueDate_);

                                    PdfPCell cellTerm_ = new PdfPCell(new Phrase(Term, tableTd))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = OddTd
                                    };
                                    tableBody.AddCell(cellTerm_);

                                    PdfPCell cellEndDate_ = new PdfPCell(new Phrase(End_Date, tableTd))
                                    {
                                        HorizontalAlignment = Element.ALIGN_LEFT,
                                        BorderWidthRight = 0f,
                                        BorderWidthLeft = 0f,
                                        BorderWidthTop = 0f,
                                        BackgroundColor = OddTd
                                    };
                                    tableBody.AddCell(cellEndDate_);

                                    PdfPCell cellApprovedAmount_ =
                                        new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Approved_Amount_), tableTd))
                                        {
                                            HorizontalAlignment = Element.ALIGN_LEFT,
                                            BorderWidthRight = 0f,
                                            BorderWidthLeft = 0f,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = OddTd
                                        };
                                    tableBody.AddCell(cellApprovedAmount_);

                                    PdfPCell cellOutsatandingBal_ =
                                        new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Outstanding_Balance_), tableTd))
                                        {
                                            HorizontalAlignment = Element.ALIGN_LEFT,
                                            BorderWidthRight = 0f,
                                            BorderWidthLeft = 0f,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = OddTd
                                        };
                                    tableBody.AddCell(cellOutsatandingBal_);

                                    PdfPCell cellLastPayDate_ =
                                        new PdfPCell(new Phrase(Last_Pay_Date.ToString("dd-MM-yyyy"), tableTd))
                                        {
                                            HorizontalAlignment = Element.ALIGN_LEFT,
                                            BorderWidthRight = 0f,
                                            BorderWidthLeft = 0f,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = OddTd
                                        };
                                    tableBody.AddCell(cellLastPayDate_);

                                    PdfPCell cellInitialObligation_ =
                                        new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Amont_Guaranteed), tableTd))
                                        {
                                            HorizontalAlignment = Element.ALIGN_LEFT,
                                            BorderWidthRight = 0f,
                                            BorderWidthLeft = 0f,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = OddTd
                                        };
                                    tableBody.AddCell(cellInitialObligation_);

                                    PdfPCell cellObligationPercentage_ =
                                        new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Obligation), tableTd))
                                        {
                                            HorizontalAlignment = Element.ALIGN_LEFT,
                                            BorderWidthRight = 0f,
                                            BorderWidthLeft = 0f,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = OddTd
                                        };
                                    tableBody.AddCell(cellObligationPercentage_);

                                    PdfPCell cellCurrent_Obligation_ =
                                        new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Current_Obligation), tableTd))
                                        {
                                            HorizontalAlignment = Element.ALIGN_LEFT,
                                            BorderWidthLeft = 0f,
                                            BorderWidthTop = 0f,
                                            BackgroundColor = OddTd
                                        };
                                    tableBody.AddCell(cellCurrent_Obligation_);

                                }

                            }
                            else
                            {
                                lblError.Text = "No guaranteed loans with outstanding balance";
                            }
                        }
                    }
 
                }
                conn.Close();
            }

            PdfPCell cellEnd = new PdfPCell(new Phrase("END OF LOANS GUARANTEED STATEMENT", tableTh))
            {
                Colspan = 12,
                HorizontalAlignment = Element.ALIGN_CENTER,
                BorderWidthRight = 0f,
                BorderWidthBottom = 0f,
                BorderWidthLeft = 0f,
                BorderWidthTop = 0f
            };
            tableBody.AddCell(cellEnd);

            #region Footer

            PdfPCell cellVerify =
                new PdfPCell(
                    new Phrase(
                        "Please verify your statement, for any discrepancies contact Bandari Sacco Society Ltd. info@bandarisacco.co.ke",
                        tableTd))
                {
                    Colspan = 12,
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
                    Colspan = 12,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BorderWidthRight = 0f,
                    BorderWidthBottom = 0f,
                    BorderWidthLeft = 0f,
                    BorderWidthTop = 0f
                };
            tableBody.AddCell(cellCopyRight);

            #endregion

            #endregion

            doc_MY_LOANS_RPT.Add(tableBody);

            #endregion

            #endregion

            pdfWriter.CloseStream = true;
            doc_MY_LOANS_RPT.Close();

            pdfLoans.Attributes.Add("src",
                ResolveUrl("~/Downloads/" +
                           String.Format("LOANS_GUARANTEED_{0}.pdf", Session["Member_No"].ToString())));

    

            #endregion
        }


        #endregion
        protected double GetOustandingBalance(string loannumber, SqlConnection conn)
        {
            double balance = 0;
            try
            {
                string A = String.Format("SELECT isnull(Sum([Amount]),0) AS [Amount] FROM [{0}$Member Ledger Entry] WHERE [Customer No_]=@LoanNo AND [Transaction Types] in (4,5)", MyClass.CompanyName);
                SqlCommand command = new SqlCommand(A, conn);
                command.Parameters.AddWithValue("@LoanNo", loannumber);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            balance = Convert.ToDouble(dr["Amount"]);

                        }
                }


            }
            catch
            {
                throw;
                Session.Abandon();
                Response.Redirect("Login.aspx");

            }
            return balance;
        }

    }
}