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
                PopulateDropDownList(membernumber);
            }

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

                throw;
   
            }
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                string membernumber = ddlAccount.SelectedItem.Text;
                string filename = cSite.Bandari_WebService.LoanGuarantors(membernumber);
                //string sourcefile = @"\\172.17.1.3\Statements\Loan Guarantors Statements\" + membernumber + ".pdf";
                //string destinationfile = @"C:\Portal\LIVE2\App_Temp_Reports\Loan Guarantors Statements\" + membernumber + ".pdf";

                string sourcefile = @"\\172.17.1.3\Statements\Account Statements\" + membernumber + ".pdf";
                string destinationfile = @"C:\Portal\LIVE2\App_Temp_Reports\Account Statements\" + membernumber + ".pdf";
                //string destinationfile = @"Portal\BandariSacco\App_Temp_Reports\Loan Guarantors Statements\" + membernumber + ".pdf";

                if (System.IO.File.Exists(destinationfile) == true)
                {
                    System.IO.File.Delete(destinationfile);
                    System.IO.File.Move(sourcefile, destinationfile);
                }
                if (System.IO.File.Exists(destinationfile) == false)
                {
                    System.IO.File.Move(sourcefile, destinationfile);
                }

                pdfLoans.Attributes.Add("src",
                    ResolveUrl("~/App_Temp_Reports/Account Statements/" + String.Format("{0}.pdf", membernumber)));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}