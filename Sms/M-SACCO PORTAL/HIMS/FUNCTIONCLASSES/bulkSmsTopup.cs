using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace admindesk.FUNCTIONCLASSES
{
    public class bulkSmsTopup
    {
        public bulkSmsTopup() { }

        #region Private Properties
        private long _id = 0;
        private string _sacco = string.Empty;
        private string _saccoName = string.Empty;
        private long _smscount = 0;
        private DateTime  _datetime = DateTime.Now;
		private string _comments = string.Empty;
        private string _userid = string.Empty;
        #endregion Private Properties

        #region Public Properties
        public long ID { get { return _id; } set { _id = value; } }
        public string sacco { get { return _sacco; } set { _sacco = value; } }
        public string saccoName { get { return _saccoName; } set { _saccoName = value; } }
        public long smscount { get { return _smscount; } set { _smscount = value; } }
        public DateTime datetime { get { return _datetime; } set { _datetime = value; } }
        public string comments { get { return _comments; } set { _comments = value; } }
        public string userid { get { return _userid; } set { _userid = value; } }
        #endregion Public Properties

        #region Public Methods
        public bulkSmsTopup GetbulkSmsTopup()
        {
            return new bulkSmsTopupData().GetbulkSmsTopup();
        }
        public bulkSmsTopup GetbulkSmsTopup(long ID)
        {
            return new bulkSmsTopupData().GetbulkSmsTopup(ID);
        }
        public DataTable GetTablebulkSmsTopup()
        {
            return new bulkSmsTopupData().GetTablebulkSmsTopup();
        }
        public DataTable GetTablebulkSmsTopup(long ID)
        {
            return new bulkSmsTopupData().GetTablebulkSmsTopup(ID);
        } 
        public DataTable GetTablebulkSmsTopup(string saccoCode)
        {
            return new bulkSmsTopupData().GetTablebulkSmsTopup(saccoCode);
        }
        public bool InsertRecord()
        {
            return new bulkSmsTopupData().InsertRecord(this);
        }
        public bool UpdateRecord()
        {
            return new bulkSmsTopupData().UpdateRecord(this);
        }
        public bool DeleteRecord(long ID)
        {
            return new bulkSmsTopupData().DeleteRecord(ID);
        }
        #endregion Public Methods
    }


    public class bulkSmsTopupData
    {
        public bulkSmsTopupData()
        {
        }
        
        public bulkSmsTopup GetbulkSmsTopup()
        {
            bulkSmsTopup obj = new bulkSmsTopup();
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spBulkSMSTopupList";

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = stringSQL;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["myTblName"].Rows[0];
                            obj = DatabaseTobulkSmsTopup(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return obj;
        }        
        public bulkSmsTopup GetbulkSmsTopup(long ID)
        {
            bulkSmsTopup obj = new bulkSmsTopup();
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spBulkSMSTopupByID";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = stringSQL;
                    cmd.Parameters.AddWithValue("@ID", ID);

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["myTblName"].Rows[0];
                            obj = DatabaseTobulkSmsTopup(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return obj;
        }
        public DataTable GetTablebulkSmsTopup()
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spBulkSMSTopupList";

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = stringSQL;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();

                        int numberOfRows = da.Fill(ds, "myTblName");

                        rt = ds.Tables["myTblName"];
                    }
                }
                mConn.Close();
            }
            return rt;
        }
        public DataTable GetTablebulkSmsTopup(long ID)
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spBulkSMSTopupByID";

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = stringSQL;

                    cmd.Parameters.AddWithValue("@ID", ID);

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();

                        int numberOfRows = da.Fill(ds, "myTblName");

                        rt = ds.Tables["myTblName"];
                    }
                }
                mConn.Close();
            }
            return rt;
        }        
        public DataTable GetTablebulkSmsTopup(string  saccoCode)
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spBulkSMSTopupList";

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = stringSQL;

                    cmd.Parameters.AddWithValue("@SaccoCorporateNo", saccoCode );

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();

                        int numberOfRows = da.Fill(ds, "myTblName");

                        rt = ds.Tables["myTblName"];
                    }
                }
                mConn.Close();
            }
            return rt;
        }
        
        public bool InsertRecord(bulkSmsTopup obj)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "spBulkSMSTopup";

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = stringSQL;

                        cmd.Parameters.AddWithValue("@SaccoCorporateNo", obj.sacco);
                        cmd.Parameters.AddWithValue("@TopupFigure", obj.smscount);
                        cmd.Parameters.AddWithValue("@Comments", obj.comments);
                        cmd.Parameters.AddWithValue("@UserID", obj.userid);
                        
                        int result = (int)cmd.ExecuteNonQuery();

                        cmd.Dispose();

                        if (result > 0)
                        { rtVal = true; }
                        else
                        { rtVal = false; }
                    }
                    mConn.Close();
                }
            }
            catch (Exception ex) { return false; }

            return rtVal;
        }
        public bool UpdateRecord(bulkSmsTopup obj)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "spBulkSMSTopup_Update";

                        cmd.CommandText = stringSQL;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TopupFigure", obj.smscount);
                        cmd.Parameters.AddWithValue("@Comments", obj.comments);
                        
                        cmd.Parameters.AddWithValue("@ID", obj.ID);


                        int result = (int)cmd.ExecuteNonQuery();

                        cmd.Dispose();

                        if (result > 0)
                        { rtVal = true; }
                        else
                        { rtVal = false; }
                    }
                    mConn.Close();
                }
            }
            catch (Exception ex) { return false; }
            return rtVal;
        }

        public bool DeleteRecord(long ID)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "spBulkSMSTopup_Delete";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = stringSQL;

                        cmd.Parameters.AddWithValue("@ID", ID);

                        int result = (int)cmd.ExecuteNonQuery();

                        cmd.Dispose();

                        if (result > 0)
                        { rtVal = true; }
                        else
                        { rtVal = false; }
                    }
                    mConn.Close();
                }
            }
            catch (Exception ex) { return false; }
            return rtVal;
        }

        private bulkSmsTopup DatabaseTobulkSmsTopup(DataRow dr)
        {
            bulkSmsTopup obj = new bulkSmsTopup();
            if (dr.Table.Columns.Contains("ID")) { obj.ID = long.Parse(dr["ID"].ToString()); }
            if (dr.Table.Columns.Contains("Sacco")) { obj.sacco = dr["Sacco"].ToString(); }
            if (dr.Table.Columns.Contains("SaccoName")) { obj.saccoName = dr["SaccoName"].ToString(); }
            if (dr.Table.Columns.Contains("SmsCount")) { obj.smscount = long.Parse(dr["SmsCount"].ToString()); }
            if (dr.Table.Columns.Contains("Datetime")) { obj.datetime = DateTime.Parse(dr["Datetime"].ToString()); }            
            if (dr.Table.Columns.Contains("Comments")) { obj.comments = dr["Comments"].ToString(); }
            if (dr.Table.Columns.Contains("UserID")) { obj.comments = dr["UserID"].ToString(); }
                        
            dr = null;
            return obj;
        }

    }
}