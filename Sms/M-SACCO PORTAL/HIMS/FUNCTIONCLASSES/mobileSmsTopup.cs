using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace admindesk.FUNCTIONCLASSES
{
    public class mobileSmsTopup
    {
        public mobileSmsTopup() { }

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
        public mobileSmsTopup GetmobileSmsTopup()
        {
            return new mobileSmsTopupData().GetmobileSmsTopup();
        }
        public mobileSmsTopup GetmobileSmsTopup(long ID)
        {
            return new mobileSmsTopupData().GetmobileSmsTopup(ID);
        }
        public DataTable GetTablemobileSmsTopup()
        {
            return new mobileSmsTopupData().GetTablemobileSmsTopup();
        }
        public DataTable GetTablemobileSmsTopup(long ID)
        {
            return new mobileSmsTopupData().GetTablemobileSmsTopup(ID);
        } 
        public DataTable GetTablemobileSmsTopup(string saccoCode)
        {
            return new mobileSmsTopupData().GetTablemobileSmsTopup(saccoCode);
        }
        public bool InsertRecord()
        {
            return new mobileSmsTopupData().InsertRecord(this);
        }
        public bool UpdateRecord()
        {
            return new mobileSmsTopupData().UpdateRecord(this);
        }
        public bool DeleteRecord(long ID)
        {
            return new mobileSmsTopupData().DeleteRecord(ID);
        }
        #endregion Public Methods
    }


    public class mobileSmsTopupData
    {
        public mobileSmsTopupData()
        {
        }
        
        public mobileSmsTopup GetmobileSmsTopup()
        {
            mobileSmsTopup obj = new mobileSmsTopup();
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spMobileSMSTopupList";

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
                            obj = DatabaseTomobileSmsTopup(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return obj;
        }        
        public mobileSmsTopup GetmobileSmsTopup(long ID)
        {
            mobileSmsTopup obj = new mobileSmsTopup();
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spMobileSMSTopupByID";
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
                            obj = DatabaseTomobileSmsTopup(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return obj;
        }
        public DataTable GetTablemobileSmsTopup()
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spMobileSMSTopupList";

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
        public DataTable GetTablemobileSmsTopup(long ID)
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spMobileSMSTopupByID";

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
        public DataTable GetTablemobileSmsTopup(string  saccoCode)
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spMobileSMSTopupList";

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
        
        public bool InsertRecord(mobileSmsTopup obj)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "spMobileSMSTopup";

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
        public bool UpdateRecord(mobileSmsTopup obj)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "spMobileSMSTopup_Update";

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
                        string stringSQL = "spMobileSMSTopup_Delete";
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

        private mobileSmsTopup DatabaseTomobileSmsTopup(DataRow dr)
        {
            mobileSmsTopup obj = new mobileSmsTopup();
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