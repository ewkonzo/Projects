using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PostBank_Sacco.controller;

namespace PostBank_Sacco
{
    public partial class CombinedStatementView : System.Web.UI.Page
    {
            string Document_No_ = "", Description = "-", Reversed = "0";
            double Amount_ = 0, Closing_Balance = 0, Credit_Amount = 0, Debit_Amount = 0, Total_Credit_Amount = 0, TotalClosing_Balance = 0;
            DateTime Posting_Date = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string ShareCapital()
        {

            Document_No_ = ""; Description = "-"; Reversed = "0";
            Amount_ = 0; Closing_Balance = 0; Credit_Amount = 0; Debit_Amount = 0; Total_Credit_Amount = 0; TotalClosing_Balance = 0;
            Posting_Date = DateTime.Now;

            using (SqlConnection conn = CRUD.getconnToNAV())
            {
                string s = "SELECT [Posting Date],[Document No_],[Description],Amount,[Debit Amount],[Credit Amount] FROM [" + CompanyName + "$Member Ledger Entry] " +
            "WHERE [Transaction Type]=14 AND [Customer No_]=@Member_No AND Reversed=@Reversed ORDER BY [Posting Date] asc";

                SqlCommand command = new SqlCommand(s, conn);
                command.Parameters.AddWithValue("@Member_No", Member_No_);
                command.Parameters.AddWithValue("@Reversed", Reversed);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
        }
    }
}