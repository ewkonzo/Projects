using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
//using System.Web;

namespace DataSyncService
{
    public class tblService
    {
        public tblService() { }

        #region --private property --
        private long _tblServiceID = 0;
        private string _ServiceName = string.Empty;
        private string _ServiceKeyword = string.Empty;
        private long _ServiceID = 0;
        private long _spID = 0;
        private long _ShortCode = 0;
        private string _ShortCodeMask = string.Empty;
        private long _correlator_last_used = 0;
        private string _ServiceType = string.Empty;
        private long _AccessNo = 0;
        private string _productCode = string.Empty;
        private string _Subscription_Lookup = string.Empty;

        #endregion --private property --

        #region --public property --
        public long tblServiceID { get { return _tblServiceID; } set { _tblServiceID = value; } }
        public string ServiceName { get { return _ServiceName; } set { _ServiceName = value; } }
        public string ServiceKeyword { get { return _ServiceKeyword; } set { _ServiceKeyword = value; } }
        public long ServiceID { get { return _ServiceID; } set { _ServiceID = value; } }
        public long spID { get { return _spID; } set { _spID = value; } }
        public long ShortCode { get { return _ShortCode; } set { _ShortCode = value; } }
        public string ShortCodeMask { get { return _ShortCodeMask; } set { _ShortCodeMask = value; } }
        public long correlator_last_used { get { return _correlator_last_used; } set { _correlator_last_used = value; } }
        public string ServiceType { get { return _ServiceType; } set { _ServiceType = value; } }
        public long AccessNo { get { return _AccessNo; } set { _AccessNo = value; } }
        public string productCode { get { return _productCode; } set { _productCode = value; } }
        public string Subscription_Lookup { get { return _Subscription_Lookup; } set { _Subscription_Lookup = value; } }
        #endregion --public property --

        #region --public methods --
        public tblService GettblService_By_Key(long tblServiceID)
        {
            tblService rval = null;
            rval = new tblServiceData().GettblService_By_Key(tblServiceID);
            return rval;
        }
        public tblService GettblService_By_ShortCode(long ShortCode)
        {
            tblService rval = null;
            rval = new tblServiceData().GettblService_By_ShortCode(ShortCode);
            return rval;
        }
        public tblService GettblService_By_Correlator(string Correlator)
        {
            tblService rval = null;
            rval = new tblServiceData().GettblService_By_Correlator(Correlator);
            return rval;
        }
        public tblService GettblService_By_ServiceID(long ServiceID)
        {
            tblService rval = null;
            rval = new tblServiceData().GettblService_By_ServiceID(ServiceID);
            return rval;
        }
        public tblService GettblService_By_AccessNo(long AccessNo)
        {
            tblService rval = null;
            rval = new tblServiceData().GettblService_By_AccessNo(AccessNo);
            return rval;
        }
        public tblService GettblService_By_ProductCode(string producttCode)
        {
            tblService rval = null;
            rval = new tblServiceData().GettblService_By_Product_Code(productCode);
            return rval;
        }
        #endregion --public methods --
    }

    public class tblServiceData
    {
        public tblServiceData()
        {
        }
        
        public tblService GettblService(long tblServiceID, long ShortCode)
        {
            tblService thistblService = new tblService();
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [tblServiceID],[ServiceName],[ServiceKeyword],[ServiceID],[spID],[ShortCode],[ShortCodeMask],[correlator_last_used],[ServiceType],[Subscription_Lookup],[productCode] ";
                    stringSQL += " FROM [tblService] WHERE (1=1) AND([tblServiceID]=@tblServiceID)AND([ShortCode]=@ShortCode)";
                    cmd.CommandText = stringSQL;

                    cmd.Parameters.Add("@tblServiceID", SqlDbType.BigInt);
                    cmd.Parameters["@tblServiceID"].Value = tblServiceID;

                    cmd.Parameters.Add("@ShortCode", SqlDbType.BigInt);
                    cmd.Parameters["@ShortCode"].Value = ShortCode;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["myTblName"].Rows[0];
                            thistblService = DatabaseTotblService(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return thistblService;
        }

        public tblService GettblService_By_Key(long tblServiceID)
        {
            tblService thistblService = new tblService();
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [tblServiceID],[ServiceName],[ServiceKeyword],[ServiceID],[spID],[ShortCode],[ShortCodeMask],[correlator_last_used],[ServiceType],[Subscription_Lookup],[productCode] ";
                    stringSQL += " FROM [tblService] WHERE (1=1) AND([tblServiceID]=@tblServiceID)";
                    cmd.CommandText = stringSQL;

                    cmd.Parameters.Add("@tblServiceID", SqlDbType.BigInt);
                    cmd.Parameters["@tblServiceID"].Value = tblServiceID;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["myTblName"].Rows[0];
                            thistblService = DatabaseTotblService(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return thistblService;
        }

        public tblService GettblService_By_ShortCode(long ShortCode)
        {
            tblService thistblService = new tblService();
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [tblServiceID],[ServiceName],[ServiceKeyword],[ServiceID],[spID],[ShortCode],[ShortCodeMask],[correlator_last_used],[ServiceType],[Subscription_Lookup],[productCode] ";
                    stringSQL += " FROM [tblService] WHERE (1=1) ([ShortCode]=@ShortCode)";
                    cmd.CommandText = stringSQL;

                    cmd.Parameters.Add("@ShortCode", SqlDbType.BigInt);
                    cmd.Parameters["@ShortCode"].Value = ShortCode;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["myTblName"].Rows[0];
                            thistblService = DatabaseTotblService(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return thistblService;
        }

        public tblService GettblService_By_Correlator(string Correlator)
        {
            tblService thistblService = new tblService();
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [tblServiceID],[ServiceName],[ServiceKeyword],[ServiceID],[spID],[ShortCode],[ShortCodeMask],[correlator_last_used],[ServiceType],[Subscription_Lookup],[productCode] ";
                    stringSQL += " FROM [tblService] WHERE (1=1) AND([correlator_last_used]=@correlator_last_used)";
                    cmd.CommandText = stringSQL;

                    cmd.Parameters.Add("@correlator_last_used", SqlDbType.VarChar, 10);
                    cmd.Parameters["@correlator_last_used"].Value = Correlator;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["myTblName"].Rows[0];
                            thistblService = DatabaseTotblService(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return thistblService;
        }

        public tblService GettblService_By_ServiceID(long ServiceID)
        {
            tblService thistblService = new tblService();
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [tblServiceID],[ServiceName],[ServiceKeyword],[ServiceID],[spID],[ShortCode],[ShortCodeMask],[correlator_last_used],[ServiceType],[Subscription_Lookup],[productCode] ";
                    stringSQL += " FROM [tblService] WHERE (1=1) AND([ServiceID]=@ServiceID)";
                    cmd.CommandText = stringSQL;

                    cmd.Parameters.Add("@ServiceID", SqlDbType.BigInt);
                    cmd.Parameters["@ServiceID"].Value = ServiceID;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["myTblName"].Rows[0];
                            thistblService = DatabaseTotblService(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return thistblService;
        }
        
        public tblService GettblService_By_AccessNo(long AccessNo)
        {
            tblService thistblService = new tblService();
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [tblServiceID],[ServiceName],[ServiceKeyword],[ServiceID],[spID],[ShortCode],[ShortCodeMask],[correlator_last_used],[ServiceType],[AccessNo],[Subscription_Lookup],[productCode] ";
                    stringSQL += " FROM [tblService] WHERE (1=1) ([AccessNo]=@AccessNo)";
                    cmd.CommandText = stringSQL;

                    cmd.Parameters.Add("@AccessNo", SqlDbType.BigInt);
                    cmd.Parameters["@AccessNo"].Value = AccessNo;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["myTblName"].Rows[0];
                            thistblService = DatabaseTotblService(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return thistblService;
        }

        public tblService GettblService_By_Product_Code(string productCode)
        {
            tblService thistblService = new tblService();
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [tblServiceID],[ServiceName],[ServiceKeyword],[ServiceID],[spID],[ShortCode],[ShortCodeMask],[correlator_last_used],[ServiceType],[Subscription_Lookup],[productCode] ";
                    stringSQL += " FROM [tblService] WHERE (1=1) AND([productCode]=@productCode)";
                    cmd.CommandText = stringSQL;

                    cmd.Parameters.Add("@productCode", SqlDbType.VarChar, 10);
                    cmd.Parameters["@productCode"].Value = productCode;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["myTblName"].Rows[0];
                            thistblService = DatabaseTotblService(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return thistblService;
        }



        public DataTable GetTabletblService(long tblServiceID, long ShortCode)
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [tblServiceID],[ServiceName],[ServiceKeyword],[ServiceID],[spID],[ShortCode],[ShortCodeMask],[correlator_last_used],[ServiceType],[Subscription_Lookup],[productCode] FROM [tblService] WHERE (1=1) AND([tblServiceID]=@tblServiceID)AND([ShortCode]=@ShortCode)";
                    cmd.CommandText = stringSQL;

                    cmd.Parameters.Add("@tblServiceID", SqlDbType.BigInt);
                    cmd.Parameters["@tblServiceID"].Value = tblServiceID;

                    cmd.Parameters.Add("@ShortCode", SqlDbType.BigInt);
                    cmd.Parameters["@ShortCode"].Value = ShortCode;

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





        private tblService DatabaseTotblService(DataRow dr)
        {
            tblService thistblService = new tblService();
            if (dr.Table.Columns.Contains("tblServiceID")) { thistblService.tblServiceID = long.Parse(dr["tblServiceID"].ToString()); }
            if (dr.Table.Columns.Contains("ServiceName")) { thistblService.ServiceName = dr["ServiceName"].ToString(); }
            if (dr.Table.Columns.Contains("ServiceKeyword")) { thistblService.ServiceKeyword = dr["ServiceKeyword"].ToString(); }
            if (dr.Table.Columns.Contains("ServiceID")) { thistblService.ServiceID = long.Parse(dr["ServiceID"].ToString()); }
            if (dr.Table.Columns.Contains("spID")) { thistblService.spID = long.Parse(dr["spID"].ToString()); }
            if (dr.Table.Columns.Contains("ShortCode")) { thistblService.ShortCode = long.Parse(dr["ShortCode"].ToString()); }
            if (dr.Table.Columns.Contains("ShortCodeMask")) { thistblService.ShortCodeMask = dr["ShortCodeMask"].ToString(); }
            if (dr.Table.Columns.Contains("correlator_last_used")) { thistblService.correlator_last_used = long.Parse(dr["correlator_last_used"].ToString()); }
            if (dr.Table.Columns.Contains("ServiceType")) { thistblService.ServiceType = dr["ServiceType"].ToString(); }
            if (dr.Table.Columns.Contains("Subscription_Lookup")) { thistblService.Subscription_Lookup = dr["Subscription_Lookup"].ToString(); }
            if (dr.Table.Columns.Contains("AccessNo")) { thistblService.AccessNo = long.Parse(dr["AccessNo"].ToString()); }
            if (dr.Table.Columns.Contains("productCode")) { thistblService.productCode = dr["productCode"].ToString(); }
            dr = null;
            return thistblService;
        }

        public bool InsertRecord(tblService thistblService)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "INSERT INTO [tblService] ( " +
    "[ServiceName],[ServiceKeyword],[ServiceID],[spID],[ShortCode],[ShortCodeMask],[correlator_last_used],[ServiceType],[Subscription_Lookup],[productCode]" +
    ") VALUES(" +
    "@ServiceName,@ServiceKeyword,@ServiceID,@spID,@ShortCode,@ShortCodeMask,@correlator_last_used,@ServiceType" +
    ")";
                        cmd.CommandText = stringSQL;

                        cmd.Parameters.Add("@ServiceName", SqlDbType.VarChar, 150);
                        cmd.Parameters["@ServiceName"].Value = thistblService.ServiceName;

                        cmd.Parameters.Add("@ServiceKeyword", SqlDbType.VarChar, 150);
                        cmd.Parameters["@ServiceKeyword"].Value = thistblService.ServiceKeyword;

                        cmd.Parameters.Add("@ServiceID", SqlDbType.BigInt);
                        cmd.Parameters["@ServiceID"].Value = thistblService.ServiceID;

                        cmd.Parameters.Add("@spID", SqlDbType.BigInt);
                        cmd.Parameters["@spID"].Value = thistblService.spID;

                        cmd.Parameters.Add("@ShortCode", SqlDbType.BigInt);
                        cmd.Parameters["@ShortCode"].Value = thistblService.ShortCode;

                        cmd.Parameters.Add("@ShortCodeMask", SqlDbType.VarChar, 20);
                        cmd.Parameters["@ShortCodeMask"].Value = thistblService.ShortCodeMask;

                        cmd.Parameters.Add("@correlator_last_used", SqlDbType.BigInt);
                        cmd.Parameters["@correlator_last_used"].Value = thistblService.correlator_last_used;

                        cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 60);
                        cmd.Parameters["@ServiceType"].Value = thistblService.ServiceType;

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

        public bool UpdateRecord(tblService newtblService, tblService oldtblService)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "UPDATE [tblService] SET " +
    " [ServiceName]= @ServiceName,[ServiceKeyword]= @ServiceKeyword,[ServiceID]= @ServiceID,[spID]= @spID,[ShortCode]= @ShortCode,[ShortCodeMask]= @ShortCodeMask" +
    ",[correlator_last_used]= @correlator_last_used,[ServiceType],[Subscription_Lookup],[productCode]= @ServiceType";
                        stringSQL += " WHERE (1=1) AND([tblServiceID]=@tblServiceID)AND([ShortCode]=@ShortCode)";
                        cmd.CommandText = stringSQL;
                        cmd.Parameters.Add("@ServiceName", SqlDbType.VarChar, 150);
                        cmd.Parameters["@ServiceName"].Value = newtblService.ServiceName;

                        cmd.Parameters.Add("@ServiceKeyword", SqlDbType.VarChar, 150);
                        cmd.Parameters["@ServiceKeyword"].Value = newtblService.ServiceKeyword;

                        cmd.Parameters.Add("@ServiceID", SqlDbType.Float);
                        cmd.Parameters["@ServiceID"].Value = newtblService.ServiceID;

                        cmd.Parameters.Add("@spID", SqlDbType.Float);
                        cmd.Parameters["@spID"].Value = newtblService.spID;

                        cmd.Parameters.Add("@ShortCode", SqlDbType.Float);
                        cmd.Parameters["@ShortCode"].Value = newtblService.ShortCode;

                        cmd.Parameters.Add("@ShortCodeMask", SqlDbType.VarChar, 20);
                        cmd.Parameters["@ShortCodeMask"].Value = newtblService.ShortCodeMask;

                        cmd.Parameters.Add("@correlator_last_used", SqlDbType.Float);
                        cmd.Parameters["@correlator_last_used"].Value = newtblService.correlator_last_used;

                        cmd.Parameters.Add("@ServiceType", SqlDbType.VarChar, 60);
                        cmd.Parameters["@ServiceType"].Value = newtblService.ServiceType;

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

        public bool DeleteRecord(long tblServiceID, long ShortCode)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "DELETE FROM [tblService] WHERE (1=1) AND([tblServiceID]=@tblServiceID)AND([ShortCode]=@ShortCode);";
                        cmd.CommandText = stringSQL;

                        cmd.Parameters.Add("@tblServiceID", SqlDbType.Float);
                        cmd.Parameters["@tblServiceID"].Value = tblServiceID;

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
    }
}
