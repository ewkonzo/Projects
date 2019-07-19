using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using System.IO;
using System.Net;
using Bandari_Sacco.controller;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;

namespace Bandari_Sacco
{
    public partial class Payslip : System.Web.UI.Page
    {
        #region Variables
        Font TitleReport = FontFactory.GetFont("Arial", 9, Font.BOLD, Color.BLACK);
        Font tableTh = FontFactory.GetFont("Arial", 10, Font.BOLD, Color.BLACK);
        Font tableTd = FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK);
        Font fnttableHeader = FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK);

        Color RowTh = new Color(191, 219, 255);
        Color EvenTd = new Color(227, 234, 235);
        Color OddTd = new Color(255, 255, 255);

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (!IsPostBack)
                {

                    if (Session["Member_No"] == null)
                    {
                        Response.Redirect("Login.aspx");

                    }
                    LoadYears();
                    LoadMonths();
                   // btnViewPayslip_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        protected void LoadYears()
        {

            try
            {

                using (SqlConnection connToNAV = MyComponents.getconnToNAV())
                {
                    string sqlStmt = null;
                    sqlStmt = "spGetPayslipYears";
                    SqlCommand cmdProgStage = new SqlCommand();
                    cmdProgStage.CommandText = sqlStmt;
                    cmdProgStage.Connection = connToNAV;
                    cmdProgStage.CommandType = CommandType.StoredProcedure;
                    cmdProgStage.Parameters.AddWithValue("@Company_Name", MyComponents.Company_Name);
                    using (SqlDataReader sqlReaderStages = cmdProgStage.ExecuteReader())
                    {
                        if (sqlReaderStages.HasRows)
                        {
                            //ddlStages.DataSource = sqlReaderStages;
                            //ddlStages.DataTextField = "Description";
                            //ddlStages.DataValueField = "Code";
                            //ddlStages.DataBind();
                            ddlYear.DataSource = sqlReaderStages;
                            ddlYear.DataTextField = "Period Year";
                            ddlYear.DataValueField = "Period Year";
                            ddlYear.DataBind();
                        }
                    }

                    connToNAV.Close();
                }
            }
            catch (Exception ex)
            {

                ex.Data.Clear();
            }

        }

        protected void LoadMonths()
        {

            try
            {

                using (SqlConnection connToNAV = MyComponents.getconnToNAV())
                {
                    string sqlStmt = null;
                    sqlStmt = "spGetPayslipMonths";
                    SqlCommand cmdProgStage = new SqlCommand();
                    cmdProgStage.CommandText = sqlStmt;
                    cmdProgStage.Connection = connToNAV;
                    cmdProgStage.CommandType = CommandType.StoredProcedure;
                    cmdProgStage.Parameters.AddWithValue("@Company_Name", MyComponents.Company_Name);
                    using (SqlDataReader sqlReaderStages = cmdProgStage.ExecuteReader())
                    {
                        if (sqlReaderStages.HasRows)
                        {
                            //ddlStages.DataSource = sqlReaderStages;
                            //ddlStages.DataTextField = "Description";
                            //ddlStages.DataValueField = "Code";
                            //ddlStages.DataBind();
                            DdMonth.DataSource = sqlReaderStages;
                            DdMonth.DataTextField = "Period Name";
                            DdMonth.DataValueField = "Period Month";
                            DdMonth.DataBind();
                        }
                    }

                    connToNAV.Close();
                }
            }
            catch (Exception ex)
            {

                ex.Data.Clear();
            }

        }
        protected void btnViewPayslip_Click(object sender, EventArgs e)
        {
            string month = DdMonth.SelectedValue;
            string year = ddlYear.SelectedValue;

            try
            {


                string Member_No_ = Session["Member_No"].ToString();

                string rptpath = MyComponents.ReportsPath();

                string ImagePath = rptpath + "\\Images";

                #region =============================== CREATE PDF  ===============================

                string fileName = String.Format("Payslip_{0}.pdf", Member_No_.Replace("/", "_"));
                string filenamePath = String.Format("{0}\\Payslips\\{1}", rptpath, fileName);

                #region Check If File exist
                try
                {
                    if (File.Exists(filenamePath))
                    {
                        File.Delete(filenamePath);
                    }
                }
                catch (Exception Ex)
                {
                    Ex.Data.Clear();
                }
                #endregion

                Document doc_LOAN_CALCULATOR_RPT = new Document(PageSize.A4);
                doc_LOAN_CALCULATOR_RPT.SetMargins(20f, 10f, 20f, 20f); // Left, Bottom,Top,Right
                doc_LOAN_CALCULATOR_RPT.HtmlStyleClass = "background:red";


                MemoryStream pdfStream = new MemoryStream();
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc_LOAN_CALCULATOR_RPT, new FileStream(filenamePath, FileMode.Create));

                doc_LOAN_CALCULATOR_RPT.Open();

                #endregion

                #region ++++++++++++++++++ REPORT TABLE Logo++++++++++++++++++++++++++++++++++


                string Logo_Path = String.Format("{0}/bandari_logo.jpg", ImagePath);

                PdfPTable tableFirstApplicationLogo = new PdfPTable(3) { TotalWidth = 300f, LockedWidth = true };
                float[] widthsLogo = new float[] { 100, 110f, 90f };
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
                string daydatetome = dt.ToString("dd-MM-yyyy");

                PdfPCell Logo_c = new PdfPCell(new Phrase("" + daydatetome, FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT };
                tableFirstApplicationLogo.AddCell(Logo_c);

                PdfPCell Title2 = new PdfPCell(new Phrase("Employee Payslip", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK))) { Colspan = 3, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_CENTER };
                tableFirstApplicationLogo.AddCell(Title2);


                doc_LOAN_CALCULATOR_RPT.Add(tableFirstApplicationLogo);


                #endregion

                #region CREATE REPORT BODY

                #region CREATE Header

                PdfPTable tableHeader = new PdfPTable(3) { TotalWidth = 300f, LockedWidth = true, SpacingBefore = 5f, };
                tableHeader.DefaultCell.Border = PdfPCell.NO_BORDER;

                float[] widthsHeader = new float[] { 100f, 110f, 90f };
                tableHeader.SetWidths(widthsHeader);


                #region Name

                PdfPCell cellLoanType = new PdfPCell(new Phrase("Employee Name:  ", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellLoanType);

                //PdfPCell cellLoanTypeb = new PdfPCell(new Phrase(Session["StaffName"].ToString(), fnttableHeader)) { Colspan = 2, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                //tableHeader.AddCell(cellLoanTypeb);

                //PdfPCell cellLoanTypec = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                //tableHeader.AddCell(cellLoanTypec);
                #endregion

                #region Staff No

                //String.Format("{0:0,0.00}", Monthly_Payment)

                PdfPCell cellLoanAmount = new PdfPCell(new Phrase("Employee No:  ", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellLoanAmount);

                PdfPCell cellLoanAmountb = new PdfPCell(new Phrase(Session["Member_No"].ToString(), fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellLoanAmountb);

                PdfPCell cellLoanAmountc = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellLoanAmountc);

                #endregion

                #region Department

                PdfPCell cellRepaymentPeriod = new PdfPCell(new Phrase("Department:  ", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellRepaymentPeriod);

                PdfPCell cellRepaymentPeriodb = new PdfPCell(new Phrase("", fnttableHeader)) { Colspan = 2, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(cellRepaymentPeriodb);

                //PdfPCell cellRepaymentPeriodc = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                //tableHeader.AddCell(cellRepaymentPeriodc);

                #endregion
                #region periods

                string myMonth = DdMonth.SelectedItem.Text;
                PdfPCell prPeriods = new PdfPCell(new Phrase("Period:  ", fnttableHeader)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(prPeriods);

                PdfPCell prPeriods2 = new PdfPCell(new Phrase(myMonth + " " + year, fnttableHeader)) { Colspan = 2, PaddingBottom = 10, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(prPeriods2);

                //PdfPCell cellRepaymentPeriodc = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                //tableHeader.AddCell(cellRepaymentPeriodc);

                #endregion

                #region Basics
                //
                double BasicPay = GetBasicPay();
                PdfPCell BasicSal = new PdfPCell(new Phrase("Basic Salary:  ", fnttableHeader)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(BasicSal);

                PdfPCell BasicSal2 = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", BasicPay), fnttableHeader)) { Colspan = 2, PaddingBottom = 10, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(BasicSal2);

                //PdfPCell BasicSal3 = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                //tableHeader.AddCell(BasicSal3);

                #endregion

                #region Allowances
                PdfPCell AllwTitle = new PdfPCell(new Phrase("ALLOWANCES  ", fnttableHeader)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(AllwTitle);

                PdfPCell AllwTitle2 = new PdfPCell(new Phrase("", fnttableHeader)) { Colspan = 2, PaddingBottom = 10, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(AllwTitle2);
                using (SqlConnection conn = MyComponents.getconnToNAV())
                {
                    //select Student Stages

                    string sqlStmt2 = null;
                    sqlStmt2 = "spGetPrAllowances";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sqlStmt2;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Company_Name", MyComponents.Company_Name);
                    cmd.Parameters.AddWithValue("@StaffNo", "'" + Session["Member_No"] + "'");
                    cmd.Parameters.AddWithValue("@Mon", "'" + month + "'");
                    cmd.Parameters.AddWithValue("@Year", "'" + year + "'");
                    //string s2 = "select distinct Stage FROM [WEBPORTAL].[dbo].[CHUKA UNIVERSITY$Student Units] where [Student No_]=@StudentNo and Stage!='' ";
                    //SqlCommand myCommand = new SqlCommand(s2, conn);
                    //myCommand.Parameters.AddWithValue("@StudentNo", Member_No_);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                string transName = dr["Transaction Name"].ToString();
                                double Amount = Convert.ToDouble(dr["Amount"].ToString());
                                PdfPCell prAllowances = new PdfPCell(new Phrase(transName, fnttableHeader)) { Colspan = 2, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                tableHeader.AddCell(prAllowances);

                                PdfPCell prAllowances2 = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Amount), fnttableHeader)) { PaddingBottom = 10, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                tableHeader.AddCell(prAllowances2);
                            }
                        }
                    }
                    conn.Close();
                }
                PdfPCell Border = new PdfPCell(new Phrase("", fnttableHeader)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(Border);

                PdfPCell border3 = new PdfPCell(new Phrase("", fnttableHeader)) { Colspan = 2, PaddingBottom = 10, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(border3);
                #endregion

                #region Gross Pay
                //
                double GrossPay = GetGrossPay();
                PdfPCell GrossPayCell = new PdfPCell(new Phrase("Gross Pay:  ", fnttableHeader)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(GrossPayCell);

                PdfPCell GrossPayCell2 = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", GrossPay), fnttableHeader)) { Colspan = 2, PaddingBottom = 10, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(GrossPayCell2);

                //PdfPCell BasicSal3 = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                //tableHeader.AddCell(BasicSal3);

                #endregion

                #region Tax Calculations

                PdfPCell TaxCell = new PdfPCell(new Phrase("TAX CALCULATIONS  ", fnttableHeader)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(TaxCell);

                PdfPCell TaxCell2 = new PdfPCell(new Phrase("", fnttableHeader)) { Colspan = 2, PaddingBottom = 10, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(TaxCell2);
                using (SqlConnection conn = MyComponents.getconnToNAV())
                {
                    //select Student Stages

                    string sqlStmt2 = null;
                    sqlStmt2 = "spGetPrTaxes";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sqlStmt2;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Company_Name", MyComponents.Company_Name);
                    cmd.Parameters.AddWithValue("@StaffNo", "'" + Session["Member_No"] + "'");
                    cmd.Parameters.AddWithValue("@Mon", "'" + month + "'");
                    cmd.Parameters.AddWithValue("@Year", "'" + year + "'");

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                string transName = dr["Transaction Name"].ToString();
                                double Amount = Convert.ToDouble(dr["Amount"].ToString());
                                PdfPCell PrTax = new PdfPCell(new Phrase(transName, fnttableHeader)) { Colspan = 2, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                tableHeader.AddCell(PrTax);

                                PdfPCell prTax2 = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Amount), fnttableHeader)) { PaddingBottom = 10, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                tableHeader.AddCell(prTax2);
                            }
                        }
                    }
                    conn.Close();
                }
                PdfPCell Border2 = new PdfPCell(new Phrase("", fnttableHeader)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(Border2);

                PdfPCell border4 = new PdfPCell(new Phrase("", fnttableHeader)) { Colspan = 2, PaddingBottom = 10, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(border4);
                #endregion

                #region Statutories

                PdfPCell StatCell = new PdfPCell(new Phrase("STATUTORIES  ", fnttableHeader)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(StatCell);

                PdfPCell StatCell2 = new PdfPCell(new Phrase("", fnttableHeader)) { Colspan = 2, PaddingBottom = 10, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(StatCell2);
                using (SqlConnection conn = MyComponents.getconnToNAV())
                {
                    //select Student Stages

                    string sqlStmt2 = null;
                    sqlStmt2 = "spGetPrStatutories";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sqlStmt2;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Company_Name", MyComponents.Company_Name);
                    cmd.Parameters.AddWithValue("@StaffNo", "'" + Session["Member_No"] + "'");
                    cmd.Parameters.AddWithValue("@Mon", "'" + month + "'");
                    cmd.Parameters.AddWithValue("@Year", "'" + year + "'");

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                string transName = dr["Transaction Name"].ToString();
                                double Amount = Convert.ToDouble(dr["Amount"].ToString());
                                PdfPCell PrStat = new PdfPCell(new Phrase(transName, fnttableHeader)) { Colspan = 2, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                tableHeader.AddCell(PrStat);

                                PdfPCell PrStat2 = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Amount), fnttableHeader)) { PaddingBottom = 10, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                tableHeader.AddCell(PrStat2);
                            }
                        }
                    }
                    conn.Close();
                }
                PdfPCell myborder = new PdfPCell(new Phrase("", fnttableHeader)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(myborder);

                PdfPCell myborder2 = new PdfPCell(new Phrase("", fnttableHeader)) { Colspan = 2, PaddingBottom = 10, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(myborder2);
                #endregion

                #region Deductions

                PdfPCell DedCell = new PdfPCell(new Phrase("DEDUCTIONS  ", fnttableHeader)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(DedCell);

                PdfPCell DedCell2 = new PdfPCell(new Phrase("", fnttableHeader)) { Colspan = 2, PaddingBottom = 10, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(DedCell2);
                using (SqlConnection conn = MyComponents.getconnToNAV())
                {
                    //select Student Stages

                    string sqlStmt2 = null;
                    sqlStmt2 = "spGetPrDeductions";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sqlStmt2;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Company_Name", MyComponents.Company_Name);
                    cmd.Parameters.AddWithValue("@StaffNo", "'" + Session["Member_No"] + "'");
                    cmd.Parameters.AddWithValue("@Mon", "'" + month + "'");
                    cmd.Parameters.AddWithValue("@Year", "'" + year + "'");

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                string transName = dr["Transaction Name"].ToString();
                                double Amount = Convert.ToDouble(dr["Amount"].ToString());
                                PdfPCell PrStat = new PdfPCell(new Phrase(transName, fnttableHeader)) { Colspan = 2, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                tableHeader.AddCell(PrStat);

                                PdfPCell PrStat2 = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", Amount), fnttableHeader)) { PaddingBottom = 10, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                                tableHeader.AddCell(PrStat2);
                            }
                        }
                    }
                    conn.Close();
                }
                PdfPCell Dborder = new PdfPCell(new Phrase("", fnttableHeader)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(Dborder);

                PdfPCell Dborder2 = new PdfPCell(new Phrase("", fnttableHeader)) { Colspan = 2, PaddingBottom = 10, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(Dborder2);
                #endregion

                #region Net Pay
                //
                double NetPay = GetNetPay();
                PdfPCell NetPaycell = new PdfPCell(new Phrase("Net Pay:  ", fnttableHeader)) { BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(NetPaycell);

                PdfPCell NetPaycell2 = new PdfPCell(new Phrase(String.Format("{0:0,0.00}", NetPay), fnttableHeader)) { Colspan = 2, PaddingBottom = 10, BorderWidthRight = 0f, BorderWidthLeft = 0f, BorderWidthTop = 0f, HorizontalAlignment = Element.ALIGN_LEFT };
                tableHeader.AddCell(NetPaycell2);

                //PdfPCell BasicSal3 = new PdfPCell(new Phrase("", fnttableHeader)) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT };
                //tableHeader.AddCell(BasicSal3);

                #endregion

                doc_LOAN_CALCULATOR_RPT.Add(tableHeader);

                #endregion
                #endregion

                pdfWriter.CloseStream = true;
                doc_LOAN_CALCULATOR_RPT.Close();

                myPDF.Attributes.Add("src", "Payslips/" + fileName);


            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
        }
        private double GetBasicPay()
        {
            double BasicPay = 0;
            try
            {
                using (SqlConnection conn = MyComponents.getconnToNAV())
                {

                    string sqlStmt2 = null;
                    sqlStmt2 = "spGetPrBasicPay";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sqlStmt2;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Company_Name", MyComponents.Company_Name);
                    cmd.Parameters.AddWithValue("@StaffNo", "'" + Session["Member_No"] + "'");
                    cmd.Parameters.AddWithValue("@Mon", "'" + DdMonth.SelectedValue + "'");
                    cmd.Parameters.AddWithValue("@Year", "'" + ddlYear.SelectedValue + "'");


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            BasicPay = Convert.ToDouble(dr["Amount"].ToString());
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception Ex)
            {
                Ex.Data.Clear();
            }
            return BasicPay;
        }

        private double GetGrossPay()
        {
            double GrossPay = 0;
            try
            {
                using (SqlConnection conn = MyComponents.getconnToNAV())
                {
                    //select Student Stages

                    string sqlStmt2 = null;
                    sqlStmt2 = "spGetPrGrossPay";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sqlStmt2;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Company_Name", MyComponents.Company_Name);
                    cmd.Parameters.AddWithValue("@StaffNo", "'" + Session["Member_No"] + "'");
                    cmd.Parameters.AddWithValue("@Mon", "'" + DdMonth.SelectedValue + "'");
                    cmd.Parameters.AddWithValue("@Year", "'" + ddlYear.SelectedValue + "'");
                    //string s2 = "select distinct Stage FROM [WEBPORTAL].[dbo].[CHUKA UNIVERSITY$Student Units] where [Student No_]=@StudentNo and Stage!='' ";
                    //SqlCommand myCommand = new SqlCommand(s2, conn);
                    //myCommand.Parameters.AddWithValue("@StudentNo", Member_No_);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            GrossPay = Convert.ToDouble(dr["Amount"].ToString());
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception Ex)
            {
                Ex.Data.Clear();
            }
            return GrossPay;
        }

        private double GetNetPay()
        {
            double NetPay = 0;
            try
            {
                using (SqlConnection conn = MyComponents.getconnToNAV())
                {
                    //select Student Stages

                    string sqlStmt2 = null;
                    sqlStmt2 = "spGetPrNetPay";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sqlStmt2;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Company_Name", MyComponents.Company_Name);
                    cmd.Parameters.AddWithValue("@StaffNo", "'" + Session["Member_No"] + "'");
                    cmd.Parameters.AddWithValue("@Mon", "'" + DdMonth.SelectedValue + "'");
                    cmd.Parameters.AddWithValue("@Year", "'" + ddlYear.SelectedValue + "'");
                    //string s2 = "select distinct Stage FROM [WEBPORTAL].[dbo].[CHUKA UNIVERSITY$Student Units] where [Student No_]=@StudentNo and Stage!='' ";
                    //SqlCommand myCommand = new SqlCommand(s2, conn);
                    //myCommand.Parameters.AddWithValue("@StudentNo", Member_No_);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            NetPay = Convert.ToDouble(dr["Amount"].ToString());
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception Ex)
            {
                Ex.Data.Clear();
            }
            return NetPay;
        }
    }
}