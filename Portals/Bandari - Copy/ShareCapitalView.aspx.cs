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
    public partial class ShareCapitalView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
        public string TotalShareCapital()
        {
            string membernumber = Session["Member_No"].ToString();
            string sharenumber = "";
            string documentnumber = "";
            double amount = 0;
            string amount1 = "";
            string htmlStr = "";


            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                string s = "SELECT a.[Posting Date],  a.[Customer No_], a.[Description], a.[Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b " +
                           " WHERE [Member No_]=@Member_No AND a.[Customer No_] = b.[No_] AND [Transaction Types]=2 ORDER BY a.[Posting Date] DESC";
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
                            sharenumber = dr["Customer No_"].ToString();
                            documentnumber = dr["Description"].ToString();
                            
                            amount = -Convert.ToDouble(dr["Amount"]);
                            amount1 = amount.ToString("N"); 
                            htmlStr += string.Format(@"<tr>
                                                            <td class='small'>{0}</td>
                                                            <td class='small'>{1}</td>
                                                            <td class='small'>KSH.{2}</td>
                                                            </tr>", i, sharenumber, amount1);
                        }
                    }
                }

            }
            return htmlStr;
        }
    }
}