using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bandari_Sacco.controller;

namespace Bandari_Sacco
{
    public partial class GuarantorsStatement : System.Web.UI.Page
    {
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
               // PopulateDropDownList(membernumber);
            }

            try
            {

                
                string path1 = HttpRuntime.AppDomainAppPath;
                string path2 = string.Format(@"App_Temp_Reports\Account Statement\{1}{2}.pdf", path1, membernumber, DateTime.Now.Second);
                string path = path1 + path2;

                Global.mBranch.LoanGuarantors(membernumber, path);

                //string sourcefile = @"\\172.17.1.3\Statements\Account Statements\" + accountnumber + ".pdf";
                //string destinationfile = @"C:\Portal\LIVE\App_Temp_Reports\Account Statements\" + accountnumber + ".pdf";

                //string sourcefile = @"\\172.17.1.3\Statements\Account Statements\" + accountnumber + ".pdf";
                //string destinationfile = @"C:\Portal\LIVE2\App_Temp_Reports\Account Statements\" + accountnumber + ".pdf";
                ////string destinationfile = @"C:\Portal\BandariSacco\App_Temp_Reports\Account Statements\" + accountnumber + ".pdf";

                //if (System.IO.File.Exists(destinationfile) == true)
                //{
                //    System.IO.File.Delete(destinationfile);
                //    System.IO.File.Move(sourcefile, destinationfile);
                //}
                //if (System.IO.File.Exists(destinationfile) == false)
                //{
                //    System.IO.File.Move(sourcefile, destinationfile);
                //}

                // pdfLoans.Attributes.Add("src",
                // ResolveUrl("~/App_Temp_Reports/Account Statements/" + String.Format("{0}.pdf", accountnumber)));
                pdfLoans.Attributes.Add("src", ResolveUrl("~/" + path2));
            }
            catch (Exception ex)
            {

                throw;
            }

        }
 //       private void PopulateDropDownList(string membernumber)
 //       {
 //           try
 //           {
 //               System.Web.UI.WebControls.ListItem li = null;
 //               ddlAccount.Items.Clear();
 //               var loans = Global.loan_Service.ReadMultiple(new Mobile_Loan.Mobile_Loan_Filter[] { new Mobile_Loan.Mobile_Loan_Filter { Criteria = membernumber, Field = Mobile_Loan.Mobile_Loan_Fields.Member_No } }, null, 0);

 //               foreach (var loan in loans)
                   
 //               {
 //                   if (loan.Loan_Balance>0)
 //                   {

 //li = new System.Web.UI.WebControls.ListItem(loan.Loan_Name.ToString());
 //                               ddlAccount.Items.Add(li);
 //                   }
 //               }

 //               // using (SqlConnection conn = MyClass.getconnToNAV())
 //               //{
 //               //    string A = "SELECT [Loan Account] FROM [" + MyClass.CompanyName + "$Loans] WHERE [Member No_]=@MemberNo ";
 //               //    SqlCommand command = new SqlCommand(A, conn);
 //               //    command.Parameters.AddWithValue("@MemberNo", membernumber);

 //               //    using (SqlDataReader dr = command.ExecuteReader())
 //               //    {
 //               //        if (dr.HasRows)
 //               //        {
 //               //            while (dr.Read())
 //               //            {
 //               //                li = new System.Web.UI.WebControls.ListItem(dr["Loan Account"].ToString());
 //               //                ddlAccount.Items.Add(li);
 //               //            }
 //               //        }
 //               //    }
 //               //    conn.Close();

 //               //}
 //           }
 //           catch (Exception ex)
 //           {

 //               //throw;
   
 //           }
 //       }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
          
        }
    }
}