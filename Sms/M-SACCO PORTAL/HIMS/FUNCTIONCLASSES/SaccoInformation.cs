using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace admindesk.FUNCTIONCLASSES
{
    public class SaccoInformation
    {
        public SaccoInformation() { }

        #region Private Properties
        private string _sacco = string.Empty;
        private string _saccoName = string.Empty;
        #endregion Private Properties

        #region Public Properties
        public string sacco { get { return _sacco; } set { _sacco = value; } }
        public string saccoName { get { return _saccoName; } set { _saccoName = value; } }
        #endregion Public Properties

        #region Public Methods
        public SaccoInformation GetSaccoInformation()
        {
            return new SaccoInformationData().GetSaccoInformation();
        }
        public SaccoInformation GetSaccoInformation(string saccoCode)
        {
            return new SaccoInformationData().GetSaccoInformation(saccoCode);
        }
        public DataTable GetTableSaccoInformation()
        {
            return new SaccoInformationData().GetTableSaccoInformation();
        }
        public DataTable GetTableSaccoInformation(string saccoCode)
        {
            return new SaccoInformationData().GetTableSaccoInformation(saccoCode);
        }
        
        //public bool InsertRecord()
        //{
        //    return new SaccoInformationData().InsertRecord(this);
        //}
        //public bool UpdateRecord()
        //{
        //    return new SaccoInformationData().UpdateRecord(this);
        //}
        //public bool DeleteRecord(long ID)
        //{
        //    return new SaccoInformationData().DeleteRecord(ID);
        //}
        
        #endregion Public Methods
    }


    public class SaccoInformationData
    {
        public SaccoInformationData()
        {
        }

        public SaccoInformation GetSaccoInformation()
        {
            SaccoInformation obj = new SaccoInformation();
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spGetActiveSaccos";
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
                            obj = DatabaseToSaccoInformation(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return obj;
        }        
        public SaccoInformation GetSaccoInformation(string saccoCode)
        {
            SaccoInformation obj = new SaccoInformation();
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spGetSaccoInfo";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = stringSQL;
                    cmd.Parameters.AddWithValue("@SaccoCorporateNo", saccoCode);

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["myTblName"].Rows[0];
                            obj = DatabaseToSaccoInformation(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return obj;
        }
        public DataTable GetTableSaccoInformation()
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spGetActiveSaccos";

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
        public DataTable GetTableSaccoInformation(string saccoCode)
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "spGetSaccoInfo";
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
        
        //public bool InsertRecord(SaccoInformation obj)
        //{
        //    bool rtVal = false;
        //    try
        //    {
        //        using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
        //        {
        //            mConn.Open();
        //            using (SqlCommand cmd = mConn.CreateCommand())
        //            {
        //                string stringSQL = "spBulkSMSTopup";

        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = stringSQL;

        //                cmd.Parameters.AddWithValue("@SaccoCorporateNo", obj.sacco);
        //                cmd.Parameters.AddWithValue("@TopupFigure", obj.smscount);
        //                cmd.Parameters.AddWithValue("@Comments", obj.comments);
        //                cmd.Parameters.AddWithValue("@UserID", obj.userid);
                        
        //                int result = (int)cmd.ExecuteNonQuery();

        //                cmd.Dispose();

        //                if (result > 0)
        //                { rtVal = true; }
        //                else
        //                { rtVal = false; }
        //            }
        //            mConn.Close();
        //        }
        //    }
        //    catch (Exception ex) { return false; }

        //    return rtVal;
        //}
        //public bool UpdateRecord(SaccoInformation obj)
        //{
        //    bool rtVal = false;
        //    try
        //    {
        //        using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
        //        {
        //            mConn.Open();
        //            using (SqlCommand cmd = mConn.CreateCommand())
        //            {
        //                string stringSQL = "spBulkSMSTopup_Update";

        //                cmd.CommandText = stringSQL;
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@TopupFigure", obj.smscount);
        //                cmd.Parameters.AddWithValue("@Comments", obj.comments);
                        
        //                cmd.Parameters.AddWithValue("@ID", obj.ID);


        //                int result = (int)cmd.ExecuteNonQuery();

        //                cmd.Dispose();

        //                if (result > 0)
        //                { rtVal = true; }
        //                else
        //                { rtVal = false; }
        //            }
        //            mConn.Close();
        //        }
        //    }
        //    catch (Exception ex) { return false; }
        //    return rtVal;
        //}
        //public bool DeleteRecord(long ID)
        //{
        //    bool rtVal = false;
        //    try
        //    {
        //        using (SqlConnection mConn = new SqlConnection(CONNECT.ConnString))
        //        {
        //            mConn.Open();
        //            using (SqlCommand cmd = mConn.CreateCommand())
        //            {
        //                string stringSQL = "spBulkSMSTopup_Delete";
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = stringSQL;

        //                cmd.Parameters.AddWithValue("@ID", ID);

        //                int result = (int)cmd.ExecuteNonQuery();

        //                cmd.Dispose();

        //                if (result > 0)
        //                { rtVal = true; }
        //                else
        //                { rtVal = false; }
        //            }
        //            mConn.Close();
        //        }
        //    }
        //    catch (Exception ex) { return false; }
        //    return rtVal;
        //}

        private SaccoInformation DatabaseToSaccoInformation(DataRow dr)
        {
            SaccoInformation obj = new SaccoInformation();
            if (dr.Table.Columns.Contains("Sacco")) { obj.sacco = dr["Sacco"].ToString(); }
            if (dr.Table.Columns.Contains("SaccoName")) { obj.saccoName = dr["SaccoName"].ToString(); }
                        
            dr = null;
            return obj;
        }

    }
}