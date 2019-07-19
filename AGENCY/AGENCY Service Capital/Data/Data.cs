using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQL_DB = System.Data.SqlClient;
using System.Data;
using access_DB =System.Data.OleDb;
using System.IO;

namespace AGENCY
{
    class SaccoData : IDisposable
    {
        public string mConnectionString = "";
        public  SQL_DB.SqlConnection mDB;
        public void Dispose()
        {
            if (mDB != null)
            {
                mDB.Dispose();
                mDB = null;
            }
        }
        public SaccoData(string Server, String Db, string username, string password)
        {
            try
            {
                this.mConnectionString = String.Format(@"Data Source={0};Initial Catalog={1};User ID={2};Password={3};Max Pool Size=100000;Connect Timeout=20;MultipleActiveResultSets=True", Server, Db, username, password);
                              this.mDB = new SQL_DB.SqlConnection(this.mConnectionString);
                this.mDB.Open();
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
            }
        }
        public void close()
        {
            if (this.mDB.State == ConnectionState.Open)
                this.mDB.Close();
        }
        public SQL_DB.SqlDataReader ReadDB(string vSQL)
        {
            CUtilities.LogEntryOnFile(vSQL);
            SQL_DB.SqlDataReader r = null;
            try
            {
                if (this.mDB.State != ConnectionState.Open)
                    this.mDB.Open();
                SQL_DB.SqlCommand vCMD = new System.Data.SqlClient.SqlCommand(vSQL, this.mDB);
                r = vCMD.ExecuteReader(CommandBehavior.CloseConnection);
                vCMD.Dispose();
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(vSQL);
                CUtilities.LogEntryOnFile(ex.Message);
            }
            return r;
        }
        public void WriteDB(string vSQL)
        {
            DataSet vDS = new DataSet();
            try
            {CUtilities.LogEntryOnFile(vSQL);
                vDS.EnforceConstraints = true;

                if (this.mDB.State != ConnectionState.Open)
                    this.mDB.Open();

                SQL_DB.SqlDataAdapter vDA = new SQL_DB.SqlDataAdapter
                    (vSQL, this.mConnectionString);

                vDA.AcceptChangesDuringFill = true;
                vDA.Fill(vDS);
            }
            catch (Exception ex)
            {
                vDS.RejectChanges();
                vDS.Dispose();
                CUtilities.LogEntryOnFile(ex.Message);
                throw ex;
            }
            finally
            {
                this.mDB.Close();
            }
        }
        public DataTable Getdatatable(string sql)
        {
            DataTable dt = null;
            using (SQL_DB.SqlDataAdapter a = new SQL_DB.SqlDataAdapter(sql, mDB))
            {
                dt = new DataTable();
                a.Fill(dt);
            }
            return dt;
        }
    }

}