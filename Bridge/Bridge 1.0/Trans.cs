using System;

namespace Server
{
    static class ATM
    {
        public static void transaction(double Charges,
            string TranType, string processCode, string TranDate, string TranTime,
            string TermId, string Trace, string ReversalTraceID, string accountNo,
            string CustAcctTo, string TransactionDescription, double amount,
            string ATM_Location, string CardAcceptorterminalID, ref double availableAmount, ref double ledgerAmount,
            ref string Narrative, ref int returnCode, ref int RetError,
            ref string ErrorMessage, bool isReversal, int iTransType, string refNum
            )
        {
            try
            {
                string custNo = CustomerNo(accountNo);

                //reject cards without customer number on backend
                if (custNo.Trim().Length == 0)
                {
                    if (isReversal)
                        returnCode = 22;//valid card
                    else
                        returnCode = 23;//invalid card
                    return;
                }
                TransactionDescription = Logs.TitleCase(TransactionDescription);

                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "SELECT [" + Connection.company + "$Vendor].No_, [" + Connection.company + "$Vendor].Name, [" + Connection.company + "$Vendor].Blocked " +
                    " FROM [" + Connection.company + "$Vendor] LEFT JOIN [" + Connection.company + "$Detailed Vendor Ledg_ Entry] ON [" + Connection.company + "$Vendor].No_ = [" + Connection.company + "$Detailed Vendor Ledg_ Entry].[Vendor No_]" +
                    " GROUP BY [" + Connection.company + "$Vendor].No_, [" + Connection.company + "$Vendor].Name, [" + Connection.company + "$Vendor].Blocked " +
                    " HAVING ((([" + Connection.company + "$Vendor].No_)='" + custNo + "'))"
                    );

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["Blocked"].ToString() != "0")
                        {
                            if (isReversal)
                                returnCode = 22;
                            else
                                returnCode = 76;
                        }
                        else
                        {
                            availableAmount= AvailableAmount(custNo) -
                                             AtmTransactions(custNo);

                            ledgerAmount = availableAmount -
                                           (Charges + (UnclearedCheques(custNo)));

                            if (processCode.Substring(0, 2) == "81")
                                Narrative = "Airtime Purchase";
                            else
                                Narrative = "ATM Cash W/D";

                            string postingS = DateTime.Now.ToString("yyyy-MMM-dd");
                            DateTime postingDate = DateTime.Now.Date;
                          
                            string transTime = Logs.FormatDate(DateTime.Now, true);
                         
                            string withdrawalLocation = Logs.ValidateEntry(ATM_Location);
                          
                            string transDescription = Logs.ValidateEntry(TransactionDescription);
                        
                            DateTime transactionTime = DateTime.Parse("1754-Jan-01 " + DateTime.Now.ToString("HH:mm:ss"));
                            DateTime transactionDate = DateTime.Now.Date;
                            int isCoopBank = int.Parse(Connection.isCoopBank);
                            int intPosVendor = Convert.ToInt32(Connection.posVendor);
                            //string Reference_No = refNum;

                            if (ledgerAmount >= amount)
                            {

                                if (isReversal) //is it a reversal?
                                {

                                    if (ATM.TraceIDExists(ReversalTraceID, custNo, amount)) //is it a genuine reversal?
                                    {
                                        if (!ATM.ReversalTraceIDExists(ReversalTraceID, custNo, amount))
                                            //has it been previously reversed?
                                        {
                                            amount *= -1;


                                            new Database().WriteDB(
                                                //[Trace ID],[Posting Date],[Account No],[Description],[Amount],[Posting S],[Posted],[Unit ID],[Transaction Type],[Trans Time],[Transaction Time],[Transaction Date],[Source],[Reversed],[Reversed Posted],[Reversal Trace ID],[Transaction Description],[Withdrawal Location],[Transaction Type Charges],[Card Acceptor Terminal ID],[ATM Card No],[Customer Names],[Process Code],[Reference No],[Is Coop Bank],[POS Vendor]
                                                "INSERT INTO [" + Connection.company + "$ATM Transactions]" +
                                                "([Trace ID],[Posting Date],[Account No],[Description],[Amount],[Posting S],[Posted]" +
                                                ",[Unit ID],[Transaction Type],[Trans Time],[Transaction Time],[Transaction Date]" +
                                                ",[Source],[Reversed],[Reversed Posted],[Reversal Trace ID],[Transaction Description]" +
                                                ",[Withdrawal Location],[Transaction Type Charges],[Card Acceptor Terminal ID]" +
                                                ",[ATM Card No],[Customer Names],[Process Code],[Is Coop Bank],[POS Vendor],[Reference No]" +
                                                ")VALUES('" + Trace + "','" +
                                                Logs.FormatDate(DateTime.Now, true) + "','" + custNo + "','" +
                                                Logs.ValidateEntry(TransactionDescription) + "'," +
                                                amount.ToString() + ",'" +
                                                Logs.FormatDate(DateTime.Now, true) + "',0,'" + TermId + "','" +
                                                TranType + "','" +
                                                Logs.FormatDate(DateTime.Now, true) + "','1753-01-01 " + DateTime.Now.ToString("HH:mm:ss") + "','" +
                                                Logs.FormatDate(DateTime.Now, true) + "',0,1,0,'" + ReversalTraceID + "','" +
                                                Logs.ValidateEntry(TransactionDescription) + "','" + Logs.ValidateEntry(ATM_Location) + "'," +
                                                iTransType.ToString() + ",'" + CardAcceptorterminalID + "','" + accountNo + "','','" + processCode + "'," +
                                                Connection.isCoopBank + "," + Convert.ToInt32(Connection.posVendor).ToString() + ",'" +
                                                refNum + "')"
                                                );


                                        }
                                    }
                                }
                                else
                                {
                                    if (!TraceIDExists(Trace, custNo, amount))
                                    { 
                                       

                                        new Database().WriteDB(
                                            "INSERT INTO [" + Connection.company + "$ATM Transactions]" +
                                            "([Trace ID],[Posting Date],[Account No],[Description],[Amount],[Posting S],[Posted]" +
                                            ",[Unit ID],[Transaction Type],[Trans Time],[Transaction Time],[Transaction Date]" +
                                            ",[Source],[Reversed],[Reversed Posted],[Reversal Trace ID],[Transaction Description]" +
                                            ",[Withdrawal Location],[Transaction Type Charges],[Card Acceptor Terminal ID]" +
                                            ",[ATM Card No],[Customer Names],[Process Code],[Is Coop Bank],[POS Vendor],[Reference No]" +
                                            ")VALUES('" + Trace + "','" +
                                            Logs.FormatDate(DateTime.Now, true) + "','" + custNo + "','" +
                                            Logs.ValidateEntry(TransactionDescription) + "'," +
                                            amount.ToString() + ",'" +
                                            Logs.FormatDate(DateTime.Now, true) + "',0,'" + TermId + "','" +
                                            TranType + "','" +
                                            Logs.FormatDate(DateTime.Now, true) + "','1753-01-01 " + DateTime.Now.ToString("HH:mm:ss") + "','" +
                                            Logs.FormatDate(DateTime.Now, true) + "',0,0,0,'" + ReversalTraceID + "','" +
                                            Logs.ValidateEntry(TransactionDescription) + "','" + Logs.ValidateEntry(ATM_Location) + "'," +
                                            iTransType.ToString() + ",'" + CardAcceptorterminalID + "','" + accountNo + "','','" + processCode + "'," +
                                            Connection.isCoopBank + "," + Convert.ToInt32(Connection.posVendor).ToString() + ",'" +
                                            refNum + "')"
                                            );
                                    }
                                }

                                ledgerAmount -= (amount);
                                availableAmount = ledgerAmount;
                                returnCode = 22;
                            }
                            else
                            {
                                if (isReversal && ATM.TraceIDExists(ReversalTraceID, custNo, amount) &&
                                    !ATM.ReversalTraceIDExists(ReversalTraceID, custNo, amount))
                                {
                                    amount *= -1;

                               

                                    new Database().WriteDB(
                                        "INSERT INTO [" + Connection.company + "$ATM Transactions]" +
                                        "([Trace ID],[Posting Date],[Account No],[Description],[Amount],[Posting S],[Posted]" +
                                        ",[Unit ID],[Transaction Type],[Trans Time],[Transaction Time],[Transaction Date]" +
                                        ",[Source],[Reversed],[Reversed Posted],[Reversal Trace ID],[Transaction Description]" +
                                        ",[Withdrawal Location],[Transaction Type Charges],[Card Acceptor Terminal ID]" +
                                        ",[ATM Card No],[Customer Names],[Process Code],[Is Coop Bank],[POS Vendor],[Reference No]" +
                                        ")VALUES('" + Trace + "','" +
                                        Logs.FormatDate(DateTime.Now, true) + "','" + custNo + "','" +
                                        Logs.ValidateEntry(TransactionDescription) + "'," +
                                        amount.ToString() + ",'" +
                                        Logs.FormatDate(DateTime.Now, true) + "',0,'" + TermId + "','" +
                                        TranType + "','" +
                                        Logs.FormatDate(DateTime.Now, true) + "','1753-01-01 " + DateTime.Now.ToString("HH:mm:ss") + "','" +
                                        Logs.FormatDate(DateTime.Now, true) + "',0,1,0,'" + ReversalTraceID + "','" +
                                        Logs.ValidateEntry(TransactionDescription) + "','" + Logs.ValidateEntry(ATM_Location) + "'," +
                                        iTransType.ToString() + ",'" + CardAcceptorterminalID + "','" + accountNo + "','','" + processCode + "'," +
                                        Connection.isCoopBank + "," + Convert.ToInt32(Connection.posVendor).ToString() + ",'" +
                                        refNum + "')"
                                        );

                                    returnCode = 22;
                                }
                                else returnCode = 51;

                                if (isReversal)
                                    returnCode = 22;
                            }
                        }

                    }
                }
                else
                {
                    if (isReversal)
                        returnCode = 22;
                    else
                        returnCode = 23;

                }

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                returnCode = 96;
                ex.Data.Clear();
            }
        }

        public static void WithdrawMpesa(double Charges,
            string TranType, string processCode, string TranDate, string TranTime,
            string TermId, string Trace, string ReversalTraceID, string accountNo,
            string CustAcctTo, string TransactionDescription, double amount,
            string ATM_Location, string CardAcceptorterminalID, string phoneNumber, 
            ref double availableAmount, ref double ledgerAmount,
            ref string Narrative, ref int returnCode, ref int RetError,
            ref string ErrorMessage, bool isReversal, int iTransType, string refNum
            )
        {
            try
            {
                string custNo = CustomerNo(accountNo);

                //reject cards without customer number on backend
                if (custNo.Trim().Length == 0)
                {
                    if (isReversal)
                        returnCode = 22;//valid card
                    else
                        returnCode = 23;//invalid card

                    return;
                }

                ////reject all POS transactions
                //if (iTransType > 8)
                //{
                //    returnCode = 23;//invalid card
                //    return;
                //}

                TransactionDescription = Logs.TitleCase(TransactionDescription);

                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "SELECT [" + Connection.company + "$Vendor].No_, [" + Connection.company + "$Vendor].Name, [" + Connection.company + "$Vendor].Blocked " +
                    " FROM [" + Connection.company + "$Vendor] LEFT JOIN [" + Connection.company + "$Detailed Vendor Ledg_ Entry] ON [" + Connection.company + "$Vendor].No_ = [" + Connection.company + "$Detailed Vendor Ledg_ Entry].[Vendor No_]" +
                    " GROUP BY [" + Connection.company + "$Vendor].No_, [" + Connection.company + "$Vendor].Name, [" + Connection.company + "$Vendor].Blocked " +
                    " HAVING ((([" + Connection.company + "$Vendor].No_)='" + custNo + "'))"
                    );

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["Blocked"].ToString() != "0")
                        {
                            if (isReversal)
                                returnCode = 22;
                            else
                                returnCode = 76;
                        }
                        else
                        {
                            availableAmount = AvailableAmount(custNo) -
                                              AtmTransactions(custNo);

                            ledgerAmount = availableAmount -
                                           (Charges + (UnclearedCheques(custNo)));

                            if (processCode.Substring(0, 2) == "81")
                                Narrative = "Airtime Purchase";
                            else
                                Narrative = "ATM Cash W/D";

                            if (ledgerAmount >= amount)
                            {
                                if (isReversal)//is it a reversal?
                                {
                                    if (ATM.TraceIDExists(ReversalTraceID, custNo, amount))//is it a genuine reversal?
                                    {
                                        if (!ATM.ReversalTraceIDExists(ReversalTraceID, custNo, amount))//has it been previously reversed?
                                        {
                                            amount *= -1;

                                            //new Database().WriteDB(
                                            //    "INSERT INTO [" + Connection.company + "$ATM Transactions]" +
                                            //    " ([Trace ID],[Reversal Trace ID], [Unit ID], [Transaction Type], [Posting S], [Posting Date], [Account No], Description, Amount,Posted,[Trans Time],[Process Code],[Withdrawal Location],[Card Acceptor Terminal ID],[Transaction Description],Reversed,[Reversed Posted],Source,[Transaction Type Charges],[ATM Card No],[Transaction Date],[Reference No])" +
                                            //    " VALUES('" + Trace + "','" + ReversalTraceID + "','" + TermId + "','" + TranType + "','" + Logs.FormatDate(DateTime.Now, true) + "','" + 
                                            //    Logs.FormatDate(DateTime.Now, true) + "','" + custNo + "','" + Logs.ValidateEntry(TransactionDescription) + "'," + amount + ",0,'" + 
                                            //    Logs.FormatDate(DateTime.Now, true) + "','" + processCode + "','" + Logs.ValidateEntry(ATM_Location) + "','" + 
                                            //    CardAcceptorterminalID + "','" + TransactionDescription + "',1,0,0," + iTransType.ToString() + ",'" + accountNo + "','" + 
                                            //    Logs.FormatDate(DateTime.Now, true) + "','" + refNum + "')"
                                            //    );


                                            new Database().WriteDB(
                                                "INSERT INTO [" + Connection.company + "$ATM Transactions]" +
                                                "([Trace ID],[Posting Date],[Account No],[Description],[Amount],[Posting S],[Posted]" +
                                                ",[Unit ID],[Transaction Type],[Trans Time],[Transaction Time],[Transaction Date]" +
                                                ",[Source],[Reversed],[Reversed Posted],[Reversal Trace ID],[Transaction Description]" +
                                                ",[Withdrawal Location],[Transaction Type Charges],[Card Acceptor Terminal ID]" +
                                                ",[ATM Card No],[Customer Names],[Process Code],[Is Coop Bank],[POS Vendor],[Reference No]" +
                                                ")VALUES('" + Trace + "','" +
                                                Logs.FormatDate(DateTime.Now, true) + "','" + custNo + "','" +
                                                Logs.ValidateEntry(TransactionDescription) + "'," +
                                                amount.ToString() + ",'" +
                                                Logs.FormatDate(DateTime.Now, true) + "',0,'" + TermId + "','" +
                                                TranType + "','" +
                                                Logs.FormatDate(DateTime.Now, true) + "','1753-01-01 " + DateTime.Now.ToString("HH:mm:ss") + "','" +
                                                Logs.FormatDate(DateTime.Now, true) + "',0,0,0,'" + ReversalTraceID + "','" +
                                                Logs.ValidateEntry(TransactionDescription) + "','" + Logs.ValidateEntry(ATM_Location) + "'," +
                                                iTransType.ToString() + ",'" + CardAcceptorterminalID + "','" + accountNo + "','','" + processCode + "'," +
                                                Connection.isCoopBank + "," + Convert.ToInt32(Connection.posVendor).ToString() + ",'" +
                                                refNum + "')"
                                                );
                                        }
                                    }
                                }
                                else
                                {
                                    if (!TraceIDExists(Trace, custNo, amount))
                                    {

                                        //new Database().WriteDB(
                                        //    "INSERT INTO [" + Connection.company + "$ATM Transactions]" +
                                        //    " ([Trace ID],[Reversal Trace ID], [Unit ID], [Transaction Type], [Posting S], [Posting Date], [Account No], Description, Amount,Posted,[Trans Time],[Process Code],[Withdrawal Location],[Card Acceptor Terminal ID],[Transaction Description],Reversed,[Reversed Posted],Source,[Transaction Type Charges],[ATM Card No],[Transaction Date],[Reference No])" +
                                        //    " VALUES('" + Trace + "','" + ReversalTraceID + "','" + TermId + "','" + TranType + "','" + Logs.FormatDate(DateTime.Now, true) + "','" + 
                                        //    Logs.FormatDate(DateTime.Now, true) + "','" + custNo + "','" + Logs.ValidateEntry(TransactionDescription) + "'," + amount + ",0,'" + 
                                        //    Logs.FormatDate(DateTime.Now, true) + "','" + processCode + "','" + Logs.ValidateEntry(ATM_Location) + "','" + 
                                        //    CardAcceptorterminalID + "','" + Logs.ValidateEntry(TransactionDescription) + "',0,0,0," + iTransType.ToString() + ",'" + accountNo + "','" + 
                                        //    Logs.FormatDate(DateTime.Now, true) + "','" + refNum + "')"
                                        //    );

                                        new Database().WriteDB(
                                            "INSERT INTO [" + Connection.company + "$ATM Transactions]" +
                                            "([Trace ID],[Posting Date],[Account No],[Description],[Amount],[Posting S],[Posted]" +
                                            ",[Unit ID],[Transaction Type],[Trans Time],[Transaction Time],[Transaction Date]" +
                                            ",[Source],[Reversed],[Reversed Posted],[Reversal Trace ID],[Transaction Description]" +
                                            ",[Withdrawal Location],[Transaction Type Charges],[Card Acceptor Terminal ID]" +
                                            ",[ATM Card No],[Customer Names],[Process Code],[Is Coop Bank],[POS Vendor],[Reference No]" +
                                            ")VALUES('" + Trace + "','" +
                                            Logs.FormatDate(DateTime.Now, true) + "','" + custNo + "','" +
                                            Logs.ValidateEntry(TransactionDescription) + "'," +
                                            amount.ToString() + ",'" +
                                            Logs.FormatDate(DateTime.Now, true) + "',0,'" + TermId + "','" +
                                            TranType + "','" +
                                            Logs.FormatDate(DateTime.Now, true) + "','1753-01-01 " +
                                            DateTime.Now.ToString("HH:mm:ss") + "','" +
                                            Logs.FormatDate(DateTime.Now, true) + "',0,0,0,'" + ReversalTraceID +
                                            "','" +
                                            Logs.ValidateEntry(TransactionDescription) + "','" +
                                            Logs.ValidateEntry(ATM_Location) + "'," +
                                            iTransType.ToString() + ",'" + CardAcceptorterminalID + "','" + accountNo +
                                            "','','" + processCode + "'," +
                                            Connection.isCoopBank + "," +
                                            Convert.ToInt32(Connection.posVendor).ToString() + ",'" +
                                            refNum + "')"
                                            );
                                    }
                                }

                                ledgerAmount -= (amount);
                                //availableAmount -= 100;
                                returnCode = 22;
                            }
                            else
                            {
                                if (isReversal)
                                {
                                    amount *= -1;

                                    //new Database().WriteDB(
                                    //    "INSERT INTO [" + Connection.company + "$ATM Transactions]" +
                                    //    " ([Trace ID],[Reversal Trace ID], [Unit ID], [Transaction Type], [Posting S], [Posting Date], [Account No], Description, Amount,Posted,[Trans Time],[Process Code],[Withdrawal Location],[Card Acceptor Terminal ID],[Transaction Description],Reversed,[Reversed Posted],Source,[Transaction Type Charges],[ATM Card No],[Transaction Date],[Reference No])" +
                                    //    " VALUES('" + Trace + "','" + ReversalTraceID + "','" + TermId + "','" + TranType + "','" + Logs.FormatDate(DateTime.Now, true) + "','" + 
                                    //    Logs.FormatDate(DateTime.Now, true) + "','" + custNo + "','" + Logs.ValidateEntry(TransactionDescription) + "'," + amount + ",0,'" + 
                                    //    Logs.FormatDate(DateTime.Now, true) + "','" + processCode + "','" + Logs.ValidateEntry(ATM_Location) + "','" + 
                                    //    CardAcceptorterminalID + "','" + Logs.ValidateEntry(TransactionDescription) + "',1,0,0," + iTransType.ToString() + ",'" + accountNo + "','" + 
                                    //    Logs.FormatDate(DateTime.Now, true) + "','" + refNum + "')"
                                    //    );

                                    new Database().WriteDB(
                                        "INSERT INTO [" + Connection.company + "$ATM Transactions]" +
                                        "([Trace ID],[Posting Date],[Account No],[Description],[Amount],[Posting S],[Posted]" +
                                        ",[Unit ID],[Transaction Type],[Trans Time],[Transaction Time],[Transaction Date]" +
                                        ",[Source],[Reversed],[Reversed Posted],[Reversal Trace ID],[Transaction Description]" +
                                        ",[Withdrawal Location],[Transaction Type Charges],[Card Acceptor Terminal ID]" +
                                        ",[ATM Card No],[Customer Names],[Process Code],[Is Coop Bank],[POS Vendor],[Reference No]" +
                                        ")VALUES('" + Trace + "','" +
                                        Logs.FormatDate(DateTime.Now, true) + "','" + custNo + "','" +
                                        Logs.ValidateEntry(TransactionDescription) + "'," +
                                        amount.ToString() + ",'" +
                                        Logs.FormatDate(DateTime.Now, true) + "',0,'" + TermId + "','" +
                                        TranType + "','" +
                                        Logs.FormatDate(DateTime.Now, true) + "','1753-01-01 " + DateTime.Now.ToString("HH:mm:ss") + "','" +
                                        Logs.FormatDate(DateTime.Now, true) + "',0,0,0,'" + ReversalTraceID + "','" +
                                        Logs.ValidateEntry(TransactionDescription) + "','" + Logs.ValidateEntry(ATM_Location) + "'," +
                                        iTransType.ToString() + ",'" + CardAcceptorterminalID + "','" + accountNo + "','','" + processCode + "'," +
                                        Connection.isCoopBank + "," + Convert.ToInt32(Connection.posVendor).ToString() + ",'" +
                                        refNum + "')"
                                        );

                                    returnCode = 22;
                                }
                                else returnCode = 51;
                            }
                        }

                    }
                }
                else
                {
                    if (isReversal)
                        returnCode = 22;
                    else
                        returnCode = 23;
                }

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                returnCode = 96;
                ex.Data.Clear();
            }

            //commented do to tobby's request on Monday 2010-10-18
            //hence; force a denial (i.e. account blocked)
            //returnCode = 76;

        }

        public static void BalanceEnquiry(
            string TranType, string processCode, string TranDate, string TranTime,
            string TermId, string Trace, string ReversalTraceID, string accountNo,
            string CustAcctTo, string TransactionDescription, double amount,
            string ATM_Location, ref double availableAmount, ref double ledgerAmount,
            ref string Narrative, ref int returnCode, ref int RetError,
            ref string ErrorMessage, bool isReversal
            )
        {
            try
            {
                string custNo = CustomerNo(accountNo);

                TransactionDescription = Logs.TitleCase(TransactionDescription);

                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "SELECT [" + Connection.company + "$Vendor].No_, [" + Connection.company + "$Vendor].Name, [" + Connection.company + "$Vendor].Blocked " +
                    " FROM [" + Connection.company + "$Vendor] LEFT JOIN [" + Connection.company + "$Detailed Vendor Ledg_ Entry] ON [" + Connection.company + "$Vendor].No_ = [" + Connection.company + "$Detailed Vendor Ledg_ Entry].[Vendor No_]" +
                    " GROUP BY [" + Connection.company + "$Vendor].No_, [" + Connection.company + "$Vendor].Name, [" + Connection.company + "$Vendor].Blocked " +
                    " HAVING ((([" + Connection.company + "$Vendor].No_)='" + CustomerNo(accountNo) + "'))"
                    );

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (dr["Blocked"].ToString() != "0")
                            returnCode = 76;
                        else
                        {
                            availableAmount = AvailableAmount(custNo) -
                                              AtmTransactions(custNo);

                            ledgerAmount = availableAmount -
                                           (ATM.MinimumBalance + (UnclearedCheques(CustomerNo(accountNo))));

                            if (processCode.Substring(0, 2) == "81")
                                Narrative = "Airtime Purchase";
                            else
                                Narrative = "ATM Cash W/D";

                            returnCode = 22;
                        }
                    }
                }
                else
                {
                    returnCode = 23;
                }

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                returnCode = 96;
                ex.Data.Clear();
            }
        }

        public static string CustomerNo(string accountNo)
        {
            string s = "";

            try
            {
                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "SELECT No_" +
                    " FROM  [" + Connection.company + "$Vendor]" +
                    " WHERE ([ATM No_] = '" + accountNo + "')"
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        s = dr["No_"].ToString();
                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return s;
        }

        public static string CustomerNames(string accountNo)
        {
            string s = "";

            try
            {
                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "SELECT Name" +
                    " FROM  [" + Connection.company + "$Vendor]" +
                    " WHERE ([ATM No_] = '" + accountNo + "')"
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        s = dr["Name"].ToString();
                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return s;
        }
        private static double Bankerschequeamount(string cust)
        {
            double bc = 0;

            try
            {
                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
        "SELECT [Bankers Cheque Amount]" +
        " FROM [" + Connection.company + "$Vendor]" +
        " WHERE No_ = '" + cust + "'"
        );

                if (dr.HasRows)
                    while (dr.Read())
                        bc = Convert.ToDouble(dr["Bankers Cheque Amount"]);

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

            }
            catch (Exception ex) { }
            return bc;
        }
        public static double AvailableAmount(string customerNo)
        {
            double availableAmount = 0;
            try
            {
                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "SELECT [" + Connection.company + "$Detailed Vendor Ledg_ Entry].Amount" +
                    " FROM [" + Connection.company + "$Vendor] LEFT JOIN [" + Connection.company + "$Detailed Vendor Ledg_ Entry]" +
                    " ON [" + Connection.company + "$Vendor].No_ = [" + Connection.company + "$Detailed Vendor Ledg_ Entry].[Vendor No_]" +
                    " where [" + Connection.company + "$Vendor].No_='" + customerNo + "';"
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        availableAmount += Convert.ToDouble(dr["Amount"]);

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            // return (availableAmount * (-1)) - Bankerschequeamount(customerNo) - AmountToHold(customerNo);
            Logs.LogEntryOnFile(String.Format("\n Available amount  {0}{1}\n", customerNo, availableAmount));
            return (availableAmount * (-1)) - AmountToHold(customerNo);
        }

        public static double AtmTransactions(string customerNo)
        {
            double atmTransactions = 0;

            try
            {
                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "SELECT Sum([" + Connection.company + "$ATM Transactions].Amount) AS ATM_Transactions" +
                    " FROM [" + Connection.company + "$Vendor] LEFT JOIN [" + Connection.company + "$ATM Transactions] ON [" +
                    Connection.company + "$Vendor].No_ = [" + Connection.company + "$ATM Transactions].[Account No]" +
                    " WHERE ((([" + Connection.company + "$ATM Transactions].Posted) = 0))" +
                    " GROUP BY [" + Connection.company + "$Vendor].No_, [" +
                    Connection.company + "$Vendor].Name, [" + Connection.company + "$Vendor].Blocked" +
                    " HAVING ((([" + Connection.company + "$Vendor].No_)='" + customerNo + "'))"
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        atmTransactions = Convert.ToDouble(dr["ATM_Transactions"]);

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return atmTransactions;
        }

        public static double AmountToHold(string customerNo)
        {
            double atmTransactions = 0;

            try
            {
                //Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                //    "SELECT [Held Amount]" +//Held Amount
                //    " FROM [" + Connection.company + "$Vendor]" +
                //    " WHERE No_ = '" + Logs.ValidateEntry(customerNo) + "'"
                //    );

                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "select sum([Amount]) as Amount" +//Held Amount
                    " FROM [" + Connection.company + "$Account Holding Amounts]" +
                    " WHERE Reversed = 0 and [Account No_] = '" + Logs.ValidateEntry(customerNo) + "'"
                    );
                if (dr.HasRows)
                    while (dr.Read())
                        atmTransactions = Convert.ToDouble(dr["Amount"]);
                Logs.LogEntryOnFile(String.Format("\nAmount Held {0}{1}\n",customerNo, atmTransactions));

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return atmTransactions;
        }
        public static double UnclearedCheques(string customerNo)
        {
            double unclearedCheques = 0;
            try
            {

                //  Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                // "SELECT   ISNULL(SUM(dbo.[" + Connection.company + "$Cheque Transactions].Amount),0) As Amount" +
                // " FROM  dbo.[" + Connection.company + "$Cheque Transactions]  WHERE (dbo.[" + Connection.company + "$Cheque Transactions].[Destination Account No_] = '"+ customerNo + "') AND" +
                // " (dbo.[" + Connection.company + "$Cheque Transactions].[Status] = 1)"
                // );
                //if (dr.HasRows)
                //    while (dr.Read())
                //        unclearedCheques = Convert.ToDouble(dr["Amount"]);
                //dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
            }
            catch (Exception ex)
            {
                Logs.LogEntryOnFile(ex.Message);
                 ex.Data.Clear();
            }
            Logs.LogEntryOnFile(String.Format("\n Uncleared Amount {0}{1}\n", customerNo, unclearedCheques));
            return unclearedCheques;
        }

        public static bool TraceIDExists(string traceIDX, string customerNo, double amount)
        {
            bool b = false;

            try
            {
                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "SELECT [Trace ID]" +
                    " FROM  dbo.[" + Connection.company + "$ATM Transactions]" +
                    " WHERE [Trace ID] = '" + Logs.ValidateEntry(traceIDX) + "'" +
                    " and [Account No] = '" + Logs.ValidateEntry(customerNo) + "'" +
                    " and [Amount] = " + amount.ToString() + ";"
                    );

                b = dr.HasRows;
                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return b;
        }

        public static bool ReversalTraceIDExists(string reversalTraceIDX, string customerNo, double amount)
        {
            bool b = false;

            try
            {
                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "SELECT [Reversal Trace ID]" +
                    " FROM  dbo.[" + Connection.company + "$ATM Transactions]" +
                    " WHERE [Reversal Trace ID] = '" + Logs.ValidateEntry(reversalTraceIDX) + "'" +
                    " and [Account No] = '" + Logs.ValidateEntry(customerNo) + "'" +
                    " and [Amount] = -" + amount.ToString() + ";"
                    );

                b = dr.HasRows;
                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return b;
        }

        public static double MinimumBalance
        {
            get
            {
                double charges = 0;

                try
                {
                    Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                        "SELECT [Total Amount]" +
                        " FROM  [" + Connection.company + "$ATM Charges]" +
                        " WHERE [Transaction Type] = 18"
                        );

                    if (dr.HasRows)
                        while (dr.Read())
                            charges = Convert.ToInt32(dr["Total Amount"]);

                    dr.Close(); dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }

                return charges;
            }
        }

        //public static double ChargesTotalAmount(int transactionType)
        //{
        //    double charges = 0;

        //    try
        //    {
        //        cConnect cnt = new cConnect(); SQL_DB.SqlDataReader dr = cnt.ReadDB(
        //             "SELECT [Total Amount]" +
        //             " FROM  [" + Connection.company + "$ATM Charges]" +
        //             " WHERE [Transaction Type] = " + transactionType
        //             );

        //        if (dr.HasRows)
        //            while (dr.Read())
        //                charges = Convert.ToInt32(dr["Total Amount"]);

        //        dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Clear();
        //    }

        //    return charges;
        //}
        public static double ChargesTotalAmount(int transactionType, double amount)
        {
            double charges = 0;
            try
            {
                switch (transactionType)
                {
                    case 15:
                        //case 16:
                        //case 17:
                        {
                            Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                                "SELECT [Charge Amount]" +
                                " FROM  [" + Connection.company + "$Pos Commisions]" +
                                " WHERE [Lower Limit] <=  " + amount + " and [Upper Limit] >= " + amount
                                );

                            if (dr.HasRows)
                                while (dr.Read())
                                    charges = Convert.ToInt32(dr["Charge Amount"]);

                            dr.Close(); dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

                            break;
                        }
                    default:
                        {
                            Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                                "SELECT [Total Amount]" +
                                " FROM  [" + Connection.company + "$ATM Charges]" +
                                " WHERE [Transaction Type] = " + transactionType
                                );
                            if (dr.HasRows)
                                while (dr.Read())
                                    charges = Convert.ToInt32(dr["Total Amount"]);

                            dr.Close(); dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return charges;
        }
        public static double ChargesSaccoAmount(int transactionType)
        {
            double charges = 0;

            try
            {
                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "SELECT [Sacco Amount]" +
                    " FROM  [" + Connection.company + "$ATM Charges]" +
                    " WHERE [Transaction Type] = " + transactionType
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        charges = Convert.ToInt32(dr["Sacco Amount"]);

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return charges;
        }

        public static string AccountType(string accountNo)
        {
            string s = "";

            try
            {
                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "SELECT [Account Type]" +
                    " FROM  [" + Connection.company + "$Vendor]" +
                    " WHERE ([ATM No_] = '" + accountNo + "')"
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        s = dr["Account Type"].ToString();
                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return s;
        }


        private static void InsertATMTransaction(string Trace_ID, string Reversal_Trace_ID, string Unit_ID,
            string Transaction_Type, string Posting_S, DateTime Posting_Date, string Account_No,
            string Description, double Amount, int Posted, string Trans_Time, string Process_Code,
            string Withdrawal_Location, string Card_Acceptor_Terminal_ID, string Transaction_Description,
            int Reversed, int Reversed_Posted, int Source, int Transaction_Type_Charges,
            string ATM_Card_No, DateTime Transaction_Time, DateTime Transaction_Date,string Customer_Names, int Is_Coop_Bank, int POS_Vendor,
            string Reference_No)
        {

            new Database().WriteDB(
                "INSERT INTO [" + Connection.company + "$ATM Transactions]" +
                " ([Trace ID],[Reversal Trace ID], [Unit ID], [Transaction Type]," +
                " [Posting S], [Posting Date], [Account No], Description, Amount,Posted," +
                "[Trans Time],[Process Code],[Withdrawal Location],[Card Acceptor Terminal ID],[Transaction Description]," +
                "Reversed,[Reversed Posted],Source,[Transaction Type Charges],[ATM Card No],[Transaction Time],[Transaction Date],"+
                "[Customer Names],[Is Coop Bank],[POS Vendor],[Reference No] )" +
                " VALUES( '" + Trace_ID + "','" + Reversal_Trace_ID + "','" + Unit_ID + "','" + Transaction_Type +
                "','" + Posting_S + "','" + Posting_Date + "','" + Account_No + "','" + Description + "'," +
                Amount.ToString() + "," + Posted + ",'" +Trans_Time + "','" + 
                Process_Code + "','" + Withdrawal_Location + "','" + Card_Acceptor_Terminal_ID +"','" +
                Transaction_Description + "'," + Reversed + "," + Reversed_Posted + "," + Source + "," +
                Transaction_Type_Charges.ToString() + ",'" + ATM_Card_No + "','" +
                "1754-Jan-01 " + Transaction_Time.ToString("HH:mm:ss") + "','" + Transaction_Date.ToString("yyyy-MMM-dd") + "','" +
                Customer_Names +"',"+ Is_Coop_Bank + "," + POS_Vendor.ToString() + ",'" + Reference_No + "')"
                );

        }

    }
}