using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace AgencyClientService
{
    public class Transactions
    {

        public static bool InsertTransactions(string AccNo, string transDesc, string Amount, int transactionType, string AgentCode, string loanNo, string AccountName, string telNo, string IdNo, string accTo){
           bool b = false;
            string ottn = string.Concat(DateTime.Now.Minute.ToString().PadLeft(2, '0'), DateTime.Now.Second.ToString().PadLeft(2, '0')).PadRight(4, '0');
          Int32 OTTN =  Convert.ToInt32(ottn.PadRight(4, '0'));
         // string docNo = getDocumentNo(OTTN);
          string mydocNo = DateTime.Now.ToString("yyyyMMddhhss");
          string defaultTime = "1753-01-01 00:00:00.000";
            
            try {
                using (SqlConnection connToNAV = Cutilities.getconnToNAV())
                {
                    string time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format( "INSERT INTO [" + Cutilities.Company_Name + "$Agent Transactions]  ([Document No_] ,[Description] ,[Transaction Date] ,[Account No_] ,[Amount] ,[Posted] ,[Transaction Time] ,[Bal_ Account No_] ,[Document Date] ,[Date Posted] ,[Time Posted] ,[Account Status] ,"+ // 12
                       " [Messages] ,[Needs Change] ,[Change Transaction No] ,[Old Account No] ,[Changed] ,[Date Changed] ,[Time Changed] ,[Changed By] ,[Approved By] ,[Original Account No] ,[Account Balance] ,[Branch Code] ,[Activity Code] ,"+ //25
                       "[Global Dimension 1 Filter] ,[Global Dimension 2 Filter] ,[Transaction Type] ,[Account No 2] ,[OTTN] ,[Transaction Location] ,[Transaction By] ,[Agent Code],[Loan No],[Account Name],[Telephone],[Id No],[Society],[Member No], [Zone Code])" + // 39
                        "VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}' ,{4} ,1 ,GETDATE() ,'' ,'{17}','{17}' ,'{17}' ,'' ,'' ,'' ,'' ,'' ,0 ,'{17}' ,'{17}' ,'' ,'' ,'' ,0 ,'' ,'' ,'' ,'' ,{7} ,'{8}' ,'{9}' ,'' ,'' ,'{10}','{11}','{12}','{13}','{14}','{15}','{16}', '')",  // ottn  -9
                        mydocNo, transDesc, DateTime.Now.Date.ToString("yyyy/MM/dd"), AccNo, Amount, "", gettime(), transactionType, accTo, "", AgentCode, loanNo, AccountName, telNo, IdNo, "", "", defaultTime);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    //cmdRt.Parameters.AddWithValue("@idnumber", IdNumber);
                    cmdRt.ExecuteNonQuery();
                    b = true;

                }
            
            }catch(Exception ex){
                ex.Data.Clear();
            }
            return b;
        }

        public static bool InsertOperation(string transDesc, string Amount, int transactionType, string AgentCode, string AccountName, string telNo, string IdNo, string Society, string MemberNo)
        {
            bool b = false;
            string ottn = string.Concat(DateTime.Now.Minute.ToString().PadLeft(2, '0'), DateTime.Now.Second.ToString().PadLeft(2, '0')).PadRight(4, '0');
            Int32 OTTN = Convert.ToInt32(ottn.PadRight(4, '0'));
            // yyyyMMddHHmmss
            string mydocNo = DateTime.Now.ToString("yyyyMMddhhss");
          //  string docNo = getDocumentNo(OTTN);
            string defaultTime = "1753-01-01 00:00:00.000";
            // DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            try
            {
                using (SqlConnection connToNAV = Cutilities.getconnToNAV())
                {
                    string time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("INSERT INTO [" + Cutilities.Company_Name + "$Agent Transactions]  ([Document No_] ,[Description] ,[Transaction Date] ,[Account No_] ,[Amount] ,[Posted] ,[Transaction Time] ,[Bal_ Account No_] ,[Document Date] ,[Date Posted] ,[Time Posted] ,[Account Status] ," + // 12
                       " [Messages] ,[Needs Change] ,[Change Transaction No] ,[Old Account No] ,[Changed] ,[Date Changed] ,[Time Changed] ,[Changed By] ,[Approved By] ,[Original Account No] ,[Account Balance] ,[Branch Code] ,[Activity Code] ," + //25
                       "[Global Dimension 1 Filter] ,[Global Dimension 2 Filter] ,[Transaction Type] ,[Account No 2] ,[OTTN] ,[Transaction Location] ,[Transaction By] ,[Agent Code],[Loan No],[Account Name],[Telephone],[Id No],[Society],[Member No], [Zone Code])" + // 39
                        "VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}' ,{4} ,1 ,GETDATE() ,'' ,'{17}','{17}' ,'{17}' ,'' ,'' ,'' ,'' ,'' ,0 ,'{17}' ,'{17}' ,'' ,'' ,'' ,0 ,'' ,'' ,'' ,'' ,{7} ,'{8}' ,'{9}' ,'' ,'' ,'{10}','{11}','{12}','{13}','{14}','{15}','{16}', '')",  // ottn  -9
                        mydocNo, transDesc, DateTime.Now.Date.ToString("yyyy/MM/dd"), "", Amount, "", gettime(), transactionType, "", "", AgentCode, "", AccountName, telNo, IdNo, Society, MemberNo, defaultTime);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;
                    //cmdRt.Parameters.AddWithValue("@idnumber", IdNumber);
                    cmdRt.ExecuteNonQuery();
                    b = true;

                }

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return b;
        }
       
        
        public static string gettime()
        {
            return "1754-01-01 " + DateTime.Now.ToString("HH:mm:ss tt");
        }
        public static string getDocumentNo(Int32 ottn)
        {
            string docno = "";string lastDocNo = "";
            try {
                using (SqlConnection connToNAV = Cutilities.getconnToNAV())
                {

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL = String.Format("SELECT  TOP 1 [Document No_] FROM [{0}$Agent Transactions]  order by [Transaction Time] desc", Cutilities.Company_Name);
                    cmdRt.CommandText = SQL;
                    cmdRt.Connection = connToNAV;
                    cmdRt.CommandType = CommandType.Text;                    
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            lastDocNo = dr["Document No_"].ToString();
                            lastDocNo = lastDocNo.Remove(lastDocNo.Length - 4);
                          int  sd = Int32.Parse(lastDocNo) + 1;
                            docno = string.Concat(sd, ottn);
                        }

                    }

                }
            
            }catch(Exception ex){
                Cutilities.LogEntryOnFile(ex.Message);
            }

            return docno;
        }
    }
}