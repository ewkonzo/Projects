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
    public partial class DepositView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Member_No"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }
        public string TotalDeposits()
        {
            string membernumber = Session["Member_No"].ToString();
            string number = "";
            string documentnumber = "";
            double amount = 0;
            string amount1 = "";
            string htmlStr = "";
            string documentname = "";


            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                var s = "SELECT a.[Posting Date], a.[Customer No_], a.[Customer Posting Group], a.[Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b   " +
                        "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Customer No_] LIKE 'S01%' " +
                        "UNION " +
                        "SELECT a.[Posting Date], a.[Customer No_], a.[Description], a.[Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b   " +
                        "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Customer No_] LIKE 'S02%' " +
                        "UNION " +
                        "SELECT a.[Posting Date], a.[Customer No_], a.[Description], a.[Amount] FROM [" + MyClass.CompanyName + "$Member Ledger Entry]a, [" + MyClass.CompanyName + "$SACCO Account]b   " +
                        "WHERE b.[Member No_] = @Member_No AND a.[Customer No_] = b.[No_] AND a.[Customer No_] LIKE 'S06%' ";
                       

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
                            number = dr["Customer No_"].ToString();
                            documentnumber = dr["Customer Posting Group"].ToString();
                            switch (documentnumber)
                            {
                                case "S01":
                                    documentname = "Non-withdrawable Deposits - Ordinary";
                                    break;
                                case "S02":
                                    documentname = "Non-withdrawable Deposits - Preferential";
                                        break;
                                case "S06":
                                        documentname = "FOSA Non-withdrawable Deposits";
                                        break;
                            }



                            amount = -Convert.ToDouble(dr["Amount"]);
                            amount1 = amount.ToString("N");
                            htmlStr += string.Format(@"<tr>
                                                            <td class='small'>{0}</td>
                                                            <td class='small'>{1}</td>
                                                            <td class='small'>KSH.{2}</td>
                                                            </tr>", i, number, amount1);
                        }
                    }
                }

            }
            return htmlStr;
        }
    }
}