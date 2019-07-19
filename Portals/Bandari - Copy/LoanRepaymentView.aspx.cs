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

namespace Bandari_Sacco
{
    public partial class LoanRepaymentView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
        public string TotalRepayment()
        {
            string membernumber = Session["Member_No"].ToString();
            string loannumber = "";
            string documentnumber = "";
            double amount = 0;
            string amount1 = ""; 
            string htmlStr = "";


            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                string s = "SELECT [Issued Date], [Loan  No_], [Loan Product Type], [Repayment] FROM [" + MyClass.CompanyName + "$Loans] WHERE [Member No_]=@Member_No ORDER BY [Issued Date] DESC";
                var command = new SqlCommand(s, conn);

                command.Parameters.AddWithValue("@Member_No", membernumber);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        int i = 0;
                        while (dr.Read())
                        {
                            i++;
                            loannumber = dr["Loan  No_"].ToString();
                            documentnumber = dr["Loan Product Type"].ToString();
                            amount = Convert.ToDouble(dr["Repayment"]);
                            amount1 = amount.ToString("N");
                            htmlStr += string.Format(@"<tr>
                                                            <td class='small'>{0}</td>
                                                            <td class='small'>{1}</td>
                                                            <td class='small'>KSH.{2}</td>
                                                            </tr>", i, loannumber, amount1);
                        }
                    }
                }

            }
            return htmlStr;
        }
    }
}