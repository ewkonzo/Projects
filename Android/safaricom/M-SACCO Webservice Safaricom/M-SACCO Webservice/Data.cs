using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQL_DB = System.Data.SqlClient;
using System.Data;
using access_DB =System.Data.OleDb;
using System.IO;

namespace M_SACCO_Webservice
{
    class Data
    {
        public string mConnectionString = "";
        private SQL_DB.SqlConnection mDB;
        public Data(string Server,String Db,string username,string password)
        {
            try
            {
                this.mConnectionString = @"Data Source=" + Server + ";Initial Catalog=" + Db + ";User ID=" + username + ";Password=" + password + ";Max Pool Size=100000;MultipleActiveResultSets=True";
                //this.mConnectionString =@"Data Source=server;Initial Catalog=" & Db & ";Integrated Security=True;Max Pool Size=100000;MultipleActiveResultSets=True";
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
class Messages 
    {
        public string mConnectionString = "";
        private SQL_DB.SqlConnection mDB;
        public Messages()
        {
            try
            {
                this.mConnectionString = Properties.Settings.Default.Db;
                this.mDB = new SQL_DB.SqlConnection(this.mConnectionString);
                this.mDB.Open();
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
            }
        }
        public SQL_DB.SqlDataReader ReadDB(string vSQL)
        {
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
                CUtilities.LogEntryOnFile(ex.Message);
            }
            return r;
        }
        public void WriteDB(string vSQL)
        {
            DataSet vDS = new DataSet();
            try
            {
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