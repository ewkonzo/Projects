using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;


namespace Banking
{

    public class Routing_Table
    {
        public Routing_Table() { }

        private long _id = 0;
        private string _Telephone_No = string.Empty;
        private string _Corporate_No = string.Empty;
        private int _PIN_No_Changed = 0;
        private decimal _Withdrawal_Limit = 0;
        private int _Status = 0;
        private string _Comments = string.Empty;
        private DateTime _Dateregistered = Convert.ToDateTime("1754-Jan-01");
        private int _Subscribed = 0;

        public long id { get { return _id; } set { _id = value; } }
        public string Telephone_No { get { return _Telephone_No; } set { _Telephone_No = value; } }
        public string Corporate_No { get { return _Corporate_No; } set { _Corporate_No = value; } }
        public int PIN_No_Changed { get { return _PIN_No_Changed; } set { _PIN_No_Changed = value; } }
        public decimal Withdrawal_Limit { get { return _Withdrawal_Limit; } set { _Withdrawal_Limit = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public string Comments { get { return _Comments; } set { _Comments = value; } }
        public DateTime Dateregistered { get { return _Dateregistered; } set { _Dateregistered = value; } }
        public int Subscribed { get { return _Subscribed; } set { _Subscribed = value; } }
    }
    public class Routing_TableData
    {
        public Routing_TableData()
        {
        }


        public Routing_Table GetRouting_Table(long id)
        {
            Routing_Table thisRouting_Table = new Routing_Table();
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [id],[Telephone No],[Corporate No],[PIN No Changed],[Withdrawal Limit],[Status],[Comments],[Dateregistered],[Subscribed] ";
                    stringSQL += " FROM [Routing Table] WHERE (1=1) AND([id]=@id)";
                    cmd.CommandText = stringSQL;

                    cmd.Parameters.Add("@id", SqlDbType.BigInt);
                    cmd.Parameters["@id"].Value = id;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["myTblName"].Rows[0];
                            thisRouting_Table = DatabaseToRouting_Table(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return thisRouting_Table;
        }
        
        public Routing_Table GetRouting_Table(string Telephone_No)
        {
            Routing_Table thisRouting_Table = new Routing_Table();
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [id],[Telephone No],[Corporate No],[PIN No Changed],[Withdrawal Limit],[Status],[Comments],[Dateregistered],[Subscribed] ";
                    stringSQL += " FROM [Routing Table] WHERE (1=1) AND([Telephone No]=@Telephone_No)";
                    cmd.CommandText = stringSQL;

                    cmd.Parameters.Add("@Telephone_No", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Telephone_No"].Value = Telephone_No;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables["myTblName"].Rows[0];
                            thisRouting_Table = DatabaseToRouting_Table(dr);
                            dr = null;
                        }
                    }
                }
                mConn.Close();
            }
            return thisRouting_Table;
        }





        public DataTable GetTableRouting_Table(long id)
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [id],[Telephone No],[Corporate No],[PIN No Changed],[Withdrawal Limit],[Status],[Comments],[Dateregistered],[Subscribed] FROM [Routing Table] WHERE (1=1) AND([id]=@id)";
                    cmd.CommandText = stringSQL;

                    cmd.Parameters.Add("@id", SqlDbType.BigInt);
                    cmd.Parameters["@id"].Value = id;

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





        private Routing_Table DatabaseToRouting_Table(DataRow dr)
        {
            Routing_Table thisRouting_Table = new Routing_Table();
            if (dr.Table.Columns.Contains("id")) { thisRouting_Table.id = long.Parse(dr["id"].ToString()); }
            if (dr.Table.Columns.Contains("Telephone No")) { thisRouting_Table.Telephone_No = dr["Telephone No"].ToString(); }
            if (dr.Table.Columns.Contains("Corporate No")) { thisRouting_Table.Corporate_No = dr["Corporate No"].ToString(); }
            if (dr.Table.Columns.Contains("PIN No Changed")) { thisRouting_Table.PIN_No_Changed = int.Parse(dr["PIN No Changed"].ToString()); }
            if (dr.Table.Columns.Contains("Withdrawal Limit")) { thisRouting_Table.Withdrawal_Limit = decimal.Parse(dr["Withdrawal Limit"].ToString()); }
            if (dr.Table.Columns.Contains("Status")) { thisRouting_Table.Status = int.Parse(dr["Status"].ToString()); }
            if (dr.Table.Columns.Contains("Comments")) { thisRouting_Table.Comments = dr["Comments"].ToString(); }
            if (dr.Table.Columns.Contains("Dateregistered")) { thisRouting_Table.Dateregistered = DateTime.Parse(dr["Dateregistered"].ToString()); }
            if (dr.Table.Columns.Contains("Subscribed")) { thisRouting_Table.Subscribed = int.Parse(dr["Subscribed"].ToString()); }
            dr = null;
            return thisRouting_Table;
        }

        public bool InsertRecord(Routing_Table thisRouting_Table)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "INSERT INTO [Routing Table] ( " +
    "[Telephone No],[Corporate No],[PIN No Changed],[Withdrawal Limit],[Status],[Comments],[Dateregistered],[Subscribed]" +
    ") VALUES(" +
    "@Telephone_No,@Corporate_No,@PIN_No_Changed,@Withdrawal_Limit,@Status,@Comments,@Dateregistered,@Subscribed" +
    ")";
                        cmd.CommandText = stringSQL;

                        cmd.Parameters.Add("@Telephone_No", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Telephone_No"].Value = thisRouting_Table.Telephone_No;

                        cmd.Parameters.Add("@Corporate_No", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Corporate_No"].Value = thisRouting_Table.Corporate_No;

                        cmd.Parameters.Add("@PIN_No_Changed", SqlDbType.Bit);
                        cmd.Parameters["@PIN_No_Changed"].Value = thisRouting_Table.PIN_No_Changed;

                        cmd.Parameters.Add("@Withdrawal_Limit", SqlDbType.Decimal);
                        cmd.Parameters["@Withdrawal_Limit"].Value = thisRouting_Table.Withdrawal_Limit;

                        cmd.Parameters.Add("@Status", SqlDbType.Int);
                        cmd.Parameters["@Status"].Value = thisRouting_Table.Status;

                        cmd.Parameters.Add("@Comments", SqlDbType.NVarChar, 200);
                        cmd.Parameters["@Comments"].Value = thisRouting_Table.Comments;

                        cmd.Parameters.Add("@Dateregistered", SqlDbType.DateTime);
                        cmd.Parameters["@Dateregistered"].Value = thisRouting_Table.Dateregistered;

                        cmd.Parameters.Add("@Subscribed", SqlDbType.Bit);
                        cmd.Parameters["@Subscribed"].Value = thisRouting_Table.Subscribed;

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

        public bool UpdateRecord(Routing_Table newRouting_Table, Routing_Table oldRouting_Table)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "UPDATE [Routing Table] SET " +
    " [Telephone No]= @Telephone_No,[Corporate No]= @Corporate_No,[PIN No Changed]= @PIN_No_Changed,[Withdrawal Limit]= @Withdrawal_Limit,[Status]= @Status,[Comments]= @Comments" +
    ",[Dateregistered]= @Dateregistered,[Subscribed]= @Subscribed";
                        stringSQL += " WHERE (1=1) AND([id]=@id)";
                        cmd.CommandText = stringSQL;

                        cmd.Parameters.Add("@Telephone_No", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Telephone_No"].Value = newRouting_Table.Telephone_No;

                        cmd.Parameters.Add("@Corporate_No", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Corporate_No"].Value = newRouting_Table.Corporate_No;

                        cmd.Parameters.Add("@PIN_No_Changed", SqlDbType.Bit);
                        cmd.Parameters["@PIN_No_Changed"].Value = newRouting_Table.PIN_No_Changed;

                        cmd.Parameters.Add("@Withdrawal_Limit", SqlDbType.Decimal);
                        cmd.Parameters["@Withdrawal_Limit"].Value = newRouting_Table.Withdrawal_Limit;

                        cmd.Parameters.Add("@Status", SqlDbType.Int);
                        cmd.Parameters["@Status"].Value = newRouting_Table.Status;

                        cmd.Parameters.Add("@Comments", SqlDbType.NVarChar, 200);
                        cmd.Parameters["@Comments"].Value = newRouting_Table.Comments;

                        cmd.Parameters.Add("@Dateregistered", SqlDbType.DateTime);
                        cmd.Parameters["@Dateregistered"].Value = newRouting_Table.Dateregistered;

                        cmd.Parameters.Add("@Subscribed", SqlDbType.Bit);
                        cmd.Parameters["@Subscribed"].Value = newRouting_Table.Subscribed;

                        cmd.Parameters.Add("@id", SqlDbType.BigInt);
                        cmd.Parameters["@id"].Value = newRouting_Table.id;


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

        public bool DeleteRecord(long id)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "DELETE FROM [Routing Table] WHERE (1=1) AND([id]=@id)";
                        cmd.CommandText = stringSQL;

                        cmd.Parameters.Add("@id", SqlDbType.Float);
                        cmd.Parameters["@id"].Value = id;

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
