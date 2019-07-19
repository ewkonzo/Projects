using System;
using System.Data;

namespace Server
{
    class Database : IDisposable
    {
        private string mConnectionString = string.Empty;
        private System.Data.SqlClient.SqlConnection conn;
        public static string Ip = null;
        public static string instance = null;
        public static string Db = null;
        public static string user = null;
        public static string password = null;

        /// <summary>
        /// Class Constructor
        /// initializes the connection [opens the database].
        /// </summary>
        public Database()
        {
            try
            {
                 
                mConnectionString = @"Data Source='"+Ip + (string.IsNullOrEmpty(instance)?"":@"\"+ instance)  +"';Initial Catalog='"+Db +"'; Persist Security Info=True; User ID='"+user +"'; Password='"+password+"'; Max Pool Size=10000";
                     
                this.conn = new System.Data.SqlClient.SqlConnection(this.mConnectionString);
                this.conn.Open();
                if (!Connection.OpenedDatabase)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Connected to database.");
                    Logs.LogEntryOnFile("\tDatabase successfuly opened.\n");
                    Connection.OpenedDatabase = true;
                    Connection.OpenedDatabaseFailed = 0;
                }
            }
            catch (Exception ex)
            {
                string hh = ex.Message;

                Console.Beep(Connection.beepF, 2000);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Database failed to open.");
                Logs.LogEntryOnFile( DateTime.Now.ToString() + "\tDatabase failed to open.\n");
                              



                if (Connection.OpenedDatabaseFailed >= 20) Connection.OpenedDatabaseFailed = 0;

                /* bubble the error to the active document, 
                       * where the error is caught and resolved */
                throw;

            }
        }

        /// <summary>
        /// This method is used for reading purposes only.
        /// NB: Only for reading NOT writing.
        /// The database will have a shared lock.
        /// </summary>
        /// <param name="vSQL">SQL statement 2B executed.</param>
        /// <param name="vCryptographyDetails">
        /// the parameters used to encrypt the sql statement</param>
        /// <returns>
        /// returns a data reader containing the execution
        /// results of the sql select statement
        /// </returns>
        public System.Data.SqlClient.SqlDataReader ReadDB(string vSQL)
        {
            System.Data.SqlClient.SqlDataReader r = null;

            try
            {
                if (this.conn.State != ConnectionState.Open)
                    this.conn.Open();
                System.Data.SqlClient.SqlCommand vCMD = new System.Data.SqlClient.SqlCommand(vSQL, this.conn);
                r = vCMD.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
                throw; /* bubble the error to the active document, 
                        * where the error is caught and resolved */
            }
            return r;
        }

        /// <summary>
        /// DA: This method is used for reading purposes only.
        /// NB: Only for reading NOT writing.
        /// The database will have a shared lock.
        /// </summary>     
        /// <param name="vSQL">SQL statement 2B executed.</param>m>
        /// <returns>
        /// returns a data adapter containing the execution
        /// results of the sql select statement
        /// </returns>
        public System.Data.SqlClient.SqlDataAdapter ReadDB2(string vSQL)
        {
            System.Data.SqlClient.SqlDataAdapter r = null;

            try
            {
                if (this.conn.State != ConnectionState.Open)
                    this.conn.Open();

                r = new System.Data.SqlClient.SqlDataAdapter(vSQL, this.conn);
                r.AcceptChangesDuringFill = false;
                r.AcceptChangesDuringUpdate = false;

            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
                throw; /* bubble the error to the active document, 
                        * where the error is caught and resolved */
            }
            return r;
        }

        /// <summary>
        /// This method is used to update/insert/delete
        /// records using the appropriate SQL Statements. 
        /// The database will have an exclusive lock.
        /// </summary>
        /// <param name="vSQL">SQL Statement 2B executed</param>
        /// <param name="vCryptographyDetails">
        /// the parameters used to encrypt the sql statement</param>
        public void WriteDB(string vSQL)
        {
            DataSet vDS = new DataSet();

            try
            {
                vDS.EnforceConstraints = true;

                if (this.conn.State != ConnectionState.Open)
                    this.conn.Open();

                System.Data.SqlClient.SqlDataAdapter vDA = new System.Data.SqlClient.SqlDataAdapter
                    (vSQL, this.mConnectionString);

                vDA.AcceptChangesDuringFill = true;
                vDA.Fill(vDS);
            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
                vDS.RejectChanges();
                vDS.Dispose();
                throw; /* bubble the error to the active document, 
                        * where the error is caught and resolved */
            }
            finally
            {
                this.conn.Close();
            }
        }

        public void Dispose()
        {
            try
            {
                if (conn != null)
                    if (conn.State == ConnectionState.Open)
                        conn.Close();

                conn.Dispose();
                conn = null;
            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
            }
        }

    }
}