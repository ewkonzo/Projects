using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;
namespace CoretecDB.tbl_H_Batch 
{
    public class DataAccess
    {
        private static string _connString;
        public static string ConnString {
            get {
                
                if (string.IsNullOrEmpty(_connString) && ConfigurationManager.ConnectionStrings.Count >0)
                {
                    for (int i = 0; i < ConfigurationManager.ConnectionStrings.Count; i++)
                    {
                        //todo: change the customDefaultConnectionstring name to what you would like your datalayer to use when you don't provide a Connectionstring in your sqlCommand
                        if (ConfigurationManager.ConnectionStrings[i].Name.Contains("CustomDefaultConnectionString")) 
                        {
                            _connString = ConfigurationManager.ConnectionStrings[i].ConnectionString;
                        }
                    }    
                }    
                return _connString;
            }
            set { _connString = value; }
        }

        /// <summary>Returns true if your stored procedure runs and returns no errors.</summary>
        ///   <returns>The stored proc should return 1 to indicate success and 0 to indicate failure
        ///   </returns>
        /// 
        public static bool RunActionCmdReturnBool(SqlCommand cmd)
        {
            bool result = false;

            SqlParameter returnParam = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            returnParam.Direction = ParameterDirection.ReturnValue ;
            cmd.Parameters.Add(returnParam);

            
            if (cmd.Connection == null) 
                cmd.Connection = new SqlConnection(ConnString);
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();

            using (SqlDataReader r = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {

                if (returnParam.Value == DBNull.Value)
                    result = false;
                else if (returnParam.Value.ToString() == "1")
                    result = true;
                else if (returnParam.Value != DBNull.Value)
                    bool.TryParse(returnParam.Value.ToString(), out result);
                r.Close();
            }
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// assumes that one of the parameterDirections is output or inputoutput.  If there are more than one, it returns the first one.  If none, it returns 0.
        /// </summary>
        /// <param name="cmd"></param>
        public static int RunCmdReturn_int(SqlCommand cmd){
            int result = 0;
            SqlParameter returnParam = GetOutputParameter(cmd.Parameters);            

            if (cmd.Connection == null)
                cmd.Connection = new SqlConnection(ConnString);
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();

            int i = cmd.ExecuteNonQuery();
            if (returnParam!=null)
              result = (returnParam.Value == DBNull.Value) ? 0: (int)returnParam.Value;
          
            cmd.Dispose();

            return result;
        }


        private static SqlParameter GetOutputParameter(SqlParameterCollection sqlParameters) {
            SqlParameter returnParam = null;
            SqlParameter inoutParam = null;
            foreach (SqlParameter p in sqlParameters)
            {
                if (p.Direction == ParameterDirection.Output)
                    returnParam = p;
                if (p.Direction == ParameterDirection.InputOutput)
                    inoutParam = p;
            }
            //if the return parameter is not defined but there is an inputoutput parameter present, 
            if (returnParam == null && inoutParam !=null)
                returnParam = inoutParam;
            
            return returnParam;
        }
        /// <summary>
        /// assumes that the key column's parameterDirection has been set to output
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static Guid RunCmdReturn_Guid(SqlCommand cmd){
            Guid result = new Guid();
            SqlParameter returnParam = GetOutputParameter(cmd.Parameters);

            if (cmd.Connection == null)
                cmd.Connection = new SqlConnection(ConnString);
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();

            using (SqlDataReader r = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                if (returnParam != null && returnParam.Value != DBNull.Value)
                    result = (Guid)returnParam.Value;
                r.Close();
            }
            cmd.Dispose();

            return result;
        }

        public static void RunActionCmd(SqlCommand cmd)
        {
            if (cmd.Connection == null)
                cmd.Connection = new SqlConnection(ConnString);
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public static SqlDataReader RunCMDGetDataReader (SqlCommand cmd)
        {
            SqlDataReader result;
            if (cmd.Connection == null)
                cmd.Connection = new SqlConnection(ConnString);
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return result;
        }

        public static DataSet RunCMDGetDataSet (SqlCommand cmd) {
            DataSet result = new DataSet();
            if (cmd.Connection == null)
                cmd.Connection = new SqlConnection(ConnString);
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(result);
            cmd.Dispose();
            return result;
        }

        /// <summary>
        /// under construction
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string DLookup(SqlCommand cmd)
        {
            if (cmd.Connection == null)
                cmd.Connection = new SqlConnection(ConnString);
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            string result= cmd.ExecuteScalar().ToString();
            cmd.Dispose();
            return result;
        }

        /// <summary>gets a string ready for insertion into database by replacing ' with ''</summary>
        public static string StringToDB(string s) {
            return StringToDB(s, SqlDbType.VarChar);
        }

        public static string StringToDB(string s, SqlDbType typ) {
            string result = s;
            switch (typ)
            {
                case SqlDbType.Bit :
                    if (s.ToLower() =="true" || s.ToLower()=="yes")
                        result = "1";
                    else 
                         result = "0";
                    break;
                case SqlDbType.DateTime:
                case SqlDbType.Date:
                    if (s == DateTime.MinValue.ToString())
                        s = "Null";
                    break;
                case SqlDbType.UniqueIdentifier:
                    if (s == new Guid().ToString())
                        s = "Null";
                    break;
                default: //SqlDbType.VarChar | SqlDbType.Text 
                    result = s.Replace("'", "''");
                    break;

            }

            return result;

     
        
        }


        
    }
}
