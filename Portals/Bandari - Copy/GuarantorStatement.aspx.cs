﻿using System;
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
    public partial class GuarantorStatement : System.Web.UI.Page
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

        protected void btnGenerate_Click(object sender, EventArgs e)
        {

            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }

                    #region CREATE REPORT

                    lblError.Text = string.Empty;
                    string Member_No_ = "";
                    Member_No_ = Session["Member_No"].ToString();
                    string rptpath = MyClass.ReportsPath();
                    string ImagePath = MyClass.ImagesPath();

                    #region =============================== CREATE PDF  ===============================

                    string fileName = String.Format("GUARONTORS_STATEMENT_{0}.pdf", Member_No_);
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
                    PdfWriter pdfWriter = PdfWriter.GetInstance(doc_MY_LOANS_RPT,
                        new FileStream(filenamePath, FileMode.Create));

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
                        new PdfPCell(new Phrase("GUARANTORS STATEMENT",
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
                                "SELECT [Payroll No__Check No_], [No_],[E-Mail],[First Name],[Second Name],[Last Name],[ID No_],[Gender], [Phone No_],[Mobile Phone No] FROM [{0}$Member] WHERE [No_]=@Member_No",
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


                    PdfPCell cellMemberNumber = new PdfPCell(new Phrase("Member No:", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellMemberNumber);

                    PdfPCell cellEmpty9 = new PdfPCell(new Phrase("", tableTdLabel))
                    {
                        BorderWidthRight = 0f,
                        BorderWidthLeft = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellEmpty9);

                    PdfPCell cellMemberNumber_ = new PdfPCell(new Phrase(MemberNo, tableTddata))
                    {
                        BorderWidthLeft = 0f,
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellMemberNumber_);

                    PdfPCell cellEmpty_9 = new PdfPCell(new Phrase("", tableTddata)) { BorderWidthLeft = 0f, BorderWidthTop = 0f };
                    tableHeaderBody.AddCell(cellEmpty_9);

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

                    PdfPCell cellEmpty_3 = new PdfPCell(new Phrase("", tableTddata))
                    {
                        BorderWidthLeft = 0f,
                        BorderWidthTop = 0f
                    };
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

                    PdfPCell cellEmpty_4 = new PdfPCell(new Phrase("", tableTddata))
                    {
                        BorderWidthLeft = 0f,
                        BorderWidthTop = 0f
                    };
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

                    PdfPCell cellEmpty_6 = new PdfPCell(new Phrase("", tableTddata))
                    {
                        BorderWidthLeft = 0f,
                        BorderWidthTop = 0f
                    };
                    tableHeaderBody.AddCell(cellEmpty_6);

                  

                    doc_MY_LOANS_RPT.Add(tableHeaderBody);

                    #endregion

                    #region CREATE REPORTBODY

                    PdfPTable tableBody = new PdfPTable(5) { TotalWidth = 560f, LockedWidth = true, SpacingBefore = 5f };
                    float[] width_Body = new float[] { 50f, 70f, 70f, 70f, 90f };
                    tableBody.SetWidths(width_Body);
                    tableBody.DefaultCell.Border = PdfPCell.NO_BORDER;

                    #region CREATE TABLE TH

                    PdfPCell cellMyLoans = new PdfPCell(new Phrase("GUARANTORS", tableTh))
                    {
                        Colspan = 5,
                        BorderWidthBottom = 0f,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = RowTh
                    };
                    tableBody.AddCell(cellMyLoans);

                    PdfPCell cellPeriod = new PdfPCell(new Phrase("#", tableTh))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        BorderWidthRight = 0f,
                        BackgroundColor = RowTh
                    };
                    tableBody.AddCell(cellPeriod);

                    PdfPCell cellMonthYear = new PdfPCell(new Phrase("Loan Account", tableTh))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        BorderWidthRight = 0f,
                        BorderWidthLeft = 0f,
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

                   
                    PdfPCell cellApproved = new PdfPCell(new Phrase("Approved Amount", tableTh))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        BorderWidthRight = 0f,
                        BorderWidthLeft = 0f,
                        BackgroundColor = RowTh
                    };
                    tableBody.AddCell(cellApproved);

                    PdfPCell cellLoanBalance = new PdfPCell(new Phrase("Outstanding Balance", tableTh))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        BorderWidthLeft = 0f,
                        BackgroundColor = RowTh
                    };
                    tableBody.AddCell(cellLoanBalance);

                    #endregion

                    #region Values

 
                    string Loan_No_ = "", Loan_Type = "", Loans_Number = "", Approved_Amount = "0", Outstanding_Balance = "0";
                    string MemberNo_ = "", GuarantorName = "";
                    double Amont_Guaranteed = 0;
                    DateTime End_Date_ = DateTime.Now;
                    DateTime dt_;
                    double Approved_Amount_ = 0, Outstanding_Balance_ = 0;
                    string loannumber = ddlAccount.SelectedItem.Text;
                    if (loannumber == string.Empty)
                    {
                        loannumber = "1";
                    }

                    using (SqlConnection conn = CRUD.getconnToNAV())
                    {
   
                        string s =
                           "SELECT a.[Loan  No_],a.[Approved Amount], a.[Loan Product Type Name]" +
                           " FROM [" + MyClass.CompanyName + "$Loans] a " +
                           " WHERE [Loan Account]=@LoanNo " +
                           " ORDER BY [Application Date] DESC";

                        SqlCommand command = new SqlCommand(s, conn);
                        command.Parameters.AddWithValue("@LoanNo", loannumber);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            
                            if (dr.HasRows)
                            {
                                int i = 0;
                                while (dr.Read())
                                {
                                    i++;
                                    Loan_No_ = ddlAccount.SelectedItem.Text;
                                    Loans_Number = dr["Loan  No_"].ToString().ToUpper();
                                    Loan_Type = dr["Loan Product Type Name"].ToString().ToUpper();
                                    Approved_Amount_ = Convert.ToDouble(dr["Approved Amount"].ToString());

                                    Outstanding_Balance_ = GetOustandingBalance(loannumber, conn);
                                   

                                    if (Outstanding_Balance_ > 0.1)
                                    {
                                        lblError.Text = string.Empty;
                                        if (i % 2 == 0)
                                        {

                                            PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd))
                                            {
                                                HorizontalAlignment = Element.ALIGN_LEFT,
                                                BorderWidthRight = 0f,
                                                BorderWidthTop = 0f,
                                                BackgroundColor = EvenTd
                                            };
                                            tableBody.AddCell(cellPeriod_);

                                            //Loan_Type

                                            PdfPCell cellLoanNo_ = new PdfPCell(new Phrase(Loan_No_, tableTd))
                                            {
                                                HorizontalAlignment = Element.ALIGN_LEFT,
                                                BorderWidthRight = 0f,
                                                BorderWidthLeft = 0f,
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

                                           
                                            PdfPCell cellApprovedAmount_ =
                                                new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Approved_Amount_),
                                                    tableTd))
                                                {
                                                    HorizontalAlignment = Element.ALIGN_LEFT,
                                                    BorderWidthRight = 0f,
                                                    BorderWidthLeft = 0f,
                                                    BorderWidthTop = 0f,
                                                    BackgroundColor = EvenTd
                                                };
                                            tableBody.AddCell(cellApprovedAmount_);

                                            PdfPCell cellOutstaLoanBalance_ =
                                                new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Outstanding_Balance_),
                                                    tableTd))
                                                {
                                                    HorizontalAlignment = Element.ALIGN_LEFT,
                                                    BorderWidthLeft = 0f,
                                                    BorderWidthTop = 0f,
                                                    BackgroundColor = EvenTd
                                                };
                                            tableBody.AddCell(cellOutstaLoanBalance_);

                                            #region Guaraontors Header

                                            PdfPCell cellEmpty1 = new PdfPCell(new Phrase("", tableTd))
                                            {
                                                HorizontalAlignment = Element.ALIGN_LEFT,
                                                BorderWidthTop = 0f,
                                                BackgroundColor = EvenTd
                                            };
                                            tableBody.AddCell(cellEmpty1);

                                            PdfPTable tableGuarontor = new PdfPTable(3)
                                            {
                                                TotalWidth = 420f,
                                                LockedWidth = true,
                                                SpacingBefore = 5f
                                            };
                                            float[] width_G = new float[]
                                        {
                                            130f, 130f, 130f
                                        };
                                            tableGuarontor.SetWidths(width_G);
                                            tableGuarontor.DefaultCell.Border = PdfPCell.NO_BORDER;

                                            PdfPCell cellEmpty1_ = new PdfPCell(tableGuarontor)
                                            {
                                                Colspan = 3,
                                                BorderWidthTop = 0f,
                                                BorderWidthLeft = 0f,
                                                BorderWidthRight = 0f,
                                            };

                                            #region CREATE TABLE TH


                                            PdfPCell cellMyGua =
                                                new PdfPCell(new Phrase(String.Format("LOAN {0} GUARANTORS", Loans_Number),
                                                    tableTh))
                                                {
                                                    Colspan = 3,
                                                    BorderWidthBottom = 0f,
                                                    HorizontalAlignment = Element.ALIGN_CENTER,
                                                    BackgroundColor = EvenTd
                                                };
                                            tableGuarontor.AddCell(cellMyGua);

                                            PdfPCell cellNo = new PdfPCell(new Phrase("#", tableTh))
                                            {
                                                BorderWidthBottom = 0f,
                                                BorderWidthRight = 0f,
                                                BorderWidthLeft = 0,
                                                BackgroundColor = EvenTd
                                            };
                                            tableGuarontor.AddCell(cellNo);

                                            PdfPCell cellMemberNo = new PdfPCell(new Phrase("Member No", tableTh))
                                            {
                                                BorderWidthBottom = 0f,
                                                BorderWidthRight = 0f,
                                                BorderWidthLeft = 0,
                                                BackgroundColor = EvenTd
                                            };
                                            tableGuarontor.AddCell(cellMemberNo);

                                            PdfPCell cellMemberName = new PdfPCell(new Phrase("Member Name", tableTh))
                                            {
                                                BorderWidthBottom = 0f, BorderWidthRight = 0f, BorderWidthLeft = 0, BackgroundColor = EvenTd
                                            };
                                            tableGuarontor.AddCell(cellMemberName);

                                            PdfPCell cellAmountGuaranteed = new PdfPCell(new Phrase("Amount Guaranteed", tableTh))
                                            { 
                                                BorderWidthBottom = 0f, BorderWidthRight = 0f, BorderWidthLeft = 0, BackgroundColor = EvenTd 
                                            };
                                            tableGuarontor.AddCell(cellAmountGuaranteed);

                                            #endregion

                                           
                                                string A = "SELECT  [Member No], [Name], [Amount Guaranteed] " +
                                                           " FROM [" + MyClass.CompanyName + "$Loan Guarantors] " +
                                                           " WHERE [Loan No] = @LoanNumber AND [Amount Guaranteed]>0";
                                                SqlCommand command_ = new SqlCommand(A, conn);
                                                command_.Parameters.AddWithValue("@LoanNumber", Loans_Number);
                                                
                                                using (SqlDataReader dr_ = command_.ExecuteReader())
                                                {
                                                    if (dr_.HasRows)
                                                    {
                                                        int b = 0;
                                                        while (dr_.Read())
                                                        {
                                                            b++;
                                                            MemberNo_ = dr_["Member No"].ToString();
                                                            GuarantorName = dr_["Name"].ToString();

                                                            #region Values

                                                            PdfPCell cellNo_ = new PdfPCell(new Phrase(b.ToString(), tableTd))
                                                            {
                                                                BorderWidthBottom = 0f,
                                                                BorderWidthLeft = 0,
                                                                BackgroundColor = EvenTd
                                                            };
                                                            tableGuarontor.AddCell(cellNo_);

                                                            PdfPCell cellMemberNo_ = new PdfPCell(new Phrase(MemberNo_, tableTd))
                                                            {
                                                                BorderWidthBottom = 0f,
                                                                BorderWidthRight = 0f,
                                                                BorderWidthLeft = 0,
                                                                BackgroundColor = EvenTd
                                                            };
                                                            tableGuarontor.AddCell(cellMemberNo_);

                                                            PdfPCell cellMemberName_ =
                                                                new PdfPCell(new Phrase(GuarantorName, tableTd))
                                                                {
                                                                    BorderWidthBottom = 0f,
                                                                    BorderWidthRight = 0f,
                                                                    BorderWidthLeft = 0,
                                                                    BackgroundColor = EvenTd
                                                                };
                                                            tableGuarontor.AddCell(cellMemberName_);

                                                            PdfPCell cellAmountGuaranteed_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Amont_Guaranteed), tableTd)) { BorderWidthBottom = 0f, BorderWidthRight = 0f, BorderWidthLeft = 0, BackgroundColor = EvenTd };
                                                            tableGuarontor.AddCell(cellAmountGuaranteed_);

                                                            #endregion
                                                        }
                                                    }
                                                }
 

                                            tableBody.AddCell(cellEmpty1_);

                                            PdfPCell cellEmpty10 = new PdfPCell(new Phrase("", tableTd))
                                            {
                                                HorizontalAlignment = Element.ALIGN_LEFT,
                                                BorderWidthTop = 0f,
                                                BackgroundColor = EvenTd
                                            };
                                            tableBody.AddCell(cellEmpty10);



                                            #endregion

                                        }
                                        else
                                        {
                                            PdfPCell cellPeriod_ = new PdfPCell(new Phrase(i.ToString(), tableTd))
                                            {
                                                HorizontalAlignment = Element.ALIGN_LEFT,
                                                BorderWidthRight = 0f,
                                                BorderWidthTop = 0f,
                                                BackgroundColor = OddTd
                                            };
                                            tableBody.AddCell(cellPeriod_);

                                            PdfPCell cellLoan_No_ = new PdfPCell(new Phrase(Loan_No_, tableTd))
                                            {
                                                HorizontalAlignment = Element.ALIGN_LEFT,
                                                BorderWidthRight = 0f,
                                                BorderWidthLeft = 0f,
                                                BorderWidthTop = 0f,
                                                BackgroundColor = OddTd
                                            };
                                            tableBody.AddCell(cellLoan_No_);

                                            PdfPCell cellLoan_Type_ = new PdfPCell(new Phrase(Loan_Type, tableTd))
                                            {
                                                HorizontalAlignment = Element.ALIGN_LEFT,
                                                BorderWidthRight = 0f,
                                                BorderWidthLeft = 0f,
                                                BorderWidthTop = 0f,
                                                BackgroundColor = OddTd
                                            };
                                            tableBody.AddCell(cellLoan_Type_);

                                           
                                            PdfPCell cellApprovedAmount_ =
                                                new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Approved_Amount_),
                                                    tableTd))
                                                {
                                                    HorizontalAlignment = Element.ALIGN_LEFT,
                                                    BorderWidthRight = 0f,
                                                    BorderWidthLeft = 0f,
                                                    BorderWidthTop = 0f,
                                                    BackgroundColor = OddTd
                                                };
                                            tableBody.AddCell(cellApprovedAmount_);

                                            PdfPCell cellOutstaLoanBalance_ =
                                                new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Outstanding_Balance_),
                                                    tableTd))
                                                {
                                                    HorizontalAlignment = Element.ALIGN_LEFT,
                                                    BorderWidthLeft = 0f,
                                                    BorderWidthTop = 0f,
                                                    BackgroundColor = OddTd
                                                };
                                            tableBody.AddCell(cellOutstaLoanBalance_);

                                            #region Guaraontors Header

                                            PdfPCell cellEmpty1 = new PdfPCell(new Phrase("", tableTd))
                                            {
                                                HorizontalAlignment = Element.ALIGN_LEFT,
                                                BorderWidthTop = 0f,
                                                BackgroundColor = OddTd
                                            };
                                            tableBody.AddCell(cellEmpty1);

                                            PdfPTable tableGuarontor = new PdfPTable(3)
                                            {
                                                TotalWidth = 420f,
                                                LockedWidth = true,
                                                SpacingBefore = 5f
                                            };
                                            float[] width_G = new float[] { 130f, 130f, 130f };
                                            tableGuarontor.SetWidths(width_G);
                                            tableGuarontor.DefaultCell.Border = PdfPCell.NO_BORDER;

                                            PdfPCell cellEmpty1_ = new PdfPCell(tableGuarontor)
                                            {
                                                Colspan = 3,
                                                BorderWidthTop = 0f,
                                                BorderWidthLeft = 0f,
                                                BorderWidthRight = 0f,
                                            };

                                            #region CREATE TABLE TH


                                            PdfPCell cellMyGua =
                                                new PdfPCell(new Phrase(String.Format("LOAN {0} GUARANTORS", Loans_Number),
                                                    tableTh))
                                                {
                                                    Colspan = 3,
                                                    BorderWidthBottom = 0f,
                                                    HorizontalAlignment = Element.ALIGN_CENTER,
                                                    BackgroundColor = OddTd
                                                };
                                            tableGuarontor.AddCell(cellMyGua);

                                            PdfPCell cellNo = new PdfPCell(new Phrase("#", tableTh))
                                            {
                                                BorderWidthBottom = 0f,
                                                BorderWidthLeft = 0,
                                                BackgroundColor = OddTd
                                            };
                                            tableGuarontor.AddCell(cellNo);

                                            PdfPCell cellMemberNo = new PdfPCell(new Phrase("Member No", tableTh))
                                            {
                                                BorderWidthBottom = 0f,
                                                BorderWidthRight = 0f,
                                                BorderWidthLeft = 0,
                                                BackgroundColor = OddTd
                                            };
                                            tableGuarontor.AddCell(cellMemberNo);

                                            PdfPCell cellMemberName = new PdfPCell(new Phrase("Member Name", tableTh))
                                            {
                                                BorderWidthBottom = 0f,
                                                BorderWidthRight = 0f,
                                                BorderWidthLeft = 0,
                                                BackgroundColor = OddTd
                                            };
                                            tableGuarontor.AddCell(cellMemberName);

                                            PdfPCell cellAmountGuaranteed = new PdfPCell(new Phrase("Amount Guaranteed", tableTh)) { BorderWidthBottom = 0f, BorderWidthRight = 0f, BorderWidthLeft = 0, BackgroundColor = OddTd };
                                            tableGuarontor.AddCell(cellAmountGuaranteed);

                                            #endregion
                                       
                                                string A = "SELECT [Member No], [Name], [Amount Guaranteed] " +
                                                           " FROM [" + MyClass.CompanyName + "$Loan Guarantors] " +
                                                           "  WHERE [Loan No] = @LoanNumber AND [Amount Guaranteed]>0";
                                                SqlCommand command_ = new SqlCommand(A, conn);
                                                command_.Parameters.AddWithValue("@LoanNumber", Loans_Number);

                                                using (SqlDataReader dr_ = command_.ExecuteReader())
                                                {
                                                    if (dr_.HasRows)
                                                    {
                                                        int b = 0;
                                                        while (dr_.Read())
                                                        {
                                                            b++;
                                                            MemberNo_ = dr_["Member No"].ToString();
                                                            GuarantorName = dr_["Name"].ToString();
                                                            Amont_Guaranteed = Convert.ToDouble(dr_["Amount Guaranteed"].ToString());

                                                            #region Values

                                                            PdfPCell cellNo_ = new PdfPCell(new Phrase(b.ToString(), tableTd))
                                                            {
                                                                BorderWidthBottom = 0f,
                                                                BorderWidthLeft = 0,
                                                                BackgroundColor = OddTd
                                                            };
                                                            tableGuarontor.AddCell(cellNo_);

                                                            PdfPCell cellMemberNo_ = new PdfPCell(new Phrase(MemberNo_, tableTd))
                                                            {
                                                                BorderWidthBottom = 0f,
                                                                BorderWidthRight = 0f,
                                                                BorderWidthLeft = 0,
                                                                BackgroundColor = OddTd
                                                            };
                                                            tableGuarontor.AddCell(cellMemberNo_);

                                                            PdfPCell cellMemberName_ =
                                                                new PdfPCell(new Phrase(GuarantorName, tableTd))
                                                                {
                                                                    BorderWidthBottom = 0f,
                                                                    BorderWidthRight = 0f,
                                                                    BorderWidthLeft = 0,
                                                                    BackgroundColor = OddTd
                                                                };
                                                            tableGuarontor.AddCell(cellMemberName_);

                                                            PdfPCell cellAmountGuaranteed_ = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Amont_Guaranteed), tableTd)) { BorderWidthBottom = 0f, BorderWidthRight = 0f, BorderWidthLeft = 0, BackgroundColor = OddTd };
                                                            tableGuarontor.AddCell(cellAmountGuaranteed_);

                                                            #endregion
                                                        }
                                                    }

                                                }
                                                
                                            tableBody.AddCell(cellEmpty1_);

                                            PdfPCell cellEmpty11 = new PdfPCell(new Phrase("", tableTd))
                                            {
                                                HorizontalAlignment = Element.ALIGN_LEFT,
                                                BorderWidthTop = 0f,
                                                BackgroundColor = OddTd
                                            };
                                            tableBody.AddCell(cellEmpty1);

                                            #endregion
                                        }
                                    }
                                    else
                                    {
                                        i--;
                                        lblError.Text = "You have no oustanding balance for Loan No. "+ Loans_Number+" ";
                                    }


                                }
                            }
                        }
                        conn.Close();
                    }

                    PdfPCell cellEnd = new PdfPCell(new Phrase("END OF GUARANTORS STATEMENT", tableTh))
                    {
                        Colspan = 5,
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
                            Colspan = 5,
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
                        new PdfPCell(new Phrase(String.Format("Copyright © {0} -Bandari Sacco Society Ltd", Yr.Year),
                            copyRight))
                        {
                            Colspan = 5,
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
                        ResolveUrl("~/Downloads/" + String.Format("GUARONTORS_STATEMENT_{0}.pdf", Session["Member_No"].ToString())));

      

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
                    string A = "SELECT [Loan Account] FROM [" + MyClass.CompanyName + "$Loans] WHERE [Member No_]=@MemberNo ";
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