using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using System.Web;


namespace DataSyncService
{
    public class Message
    {
        public Message() { }

        #region -- private properties --

        private int _ID = 0;
        private int _Direction = 0;
        private int _Type = 0;
        private int _Status = 0;
        private int _StatusDetails = 0;
        private long _ChannelID = 0;
        private string _BillingID = string.Empty;
        private string _MessageReference = string.Empty;
        private int _ScheduledTimeSecs = 0;
        private int _SentTimeSecs = 0;
        private int _ReceivedTimeSecs = 0;
        private int _LastUpdateSecs = 0;
        private string _FromAddress = string.Empty;
        private int _Priority = 0;
        private int _ReadReceipt = 0;
        private string _Subject = string.Empty;
        private int _BodyFormat = 0;
        private int _CustomField1 = 0;
        private string _CustomField2 = string.Empty;
        private int _sysLock = 0;
        private string _sysHash = string.Empty;
        private int _sysForwarded = 0;
        private string _sysGwReference = string.Empty;
        private int _sysCreator = 0;
        private int _sysArchive = 0;
        private string _ToAddress = string.Empty;
        private string _Header = string.Empty;
        private string _Body = string.Empty;
        private string _Trace = string.Empty;
        private string _Attachments = string.Empty;
        private DateTime _SMS_Date = Convert.ToDateTime("1754-Jan-01");
        private string _Corporate_No = string.Empty;
        private int _Bulk_SMS_ID = 0;
        private int _Bulk_SMS = 0;
        private DateTime _Bulk_SMS_Date = Convert.ToDateTime("1754-Jan-01");
        private DateTime _Bulk_SMS_Time = Convert.ToDateTime("1754-Jan-01");
        private string _Source = string.Empty;
        private int _Payment_Processed = 0;
        private DateTime _Date_Payment_Processed = Convert.ToDateTime("1754-Jan-01");
        private DateTime _Time_Payment_Processed = Convert.ToDateTime("1754-Jan-01");
        private string _Processed_By = string.Empty;
        private string _Bulk_SMS_No = string.Empty;
        private string _SMS_Sent = string.Empty;
        private string _Back_Up_SMS = string.Empty;
        private int _Message_Type_ID = 0;
        private int _E_Mail_Sent = 0;
        private int _Marked_For_E_mail = 0;
        private DateTime _Datetime = Convert.ToDateTime("1754-Jan-01");
        private int _Reply_Sent = 0;
        private int _TotalSmsTrace = 0;
        private DateTime _CDateTime = Convert.ToDateTime("1754-Jan-01");
        private string _Sender = string.Empty;
        private long _spID = 0;
        private long _serviceID = 0;
        private long _AccessNo = 0;
        private long _Correlator = 0;
        private long _TimeStamp = 0;
        private string _HashedPassword = string.Empty;

        #endregion -- private properties --

        #region -- public properties --

        public int ID { get { return _ID; } set { _ID = value; } }
        public int Direction { get { return _Direction; } set { _Direction = value; } }
        public int Type { get { return _Type; } set { _Type = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public int StatusDetails { get { return _StatusDetails; } set { _StatusDetails = value; } }
        public long ChannelID { get { return _ChannelID; } set { _ChannelID = value; } }
        public string BillingID { get { return _BillingID; } set { _BillingID = value; } }
        public string MessageReference { get { return _MessageReference; } set { _MessageReference = value; } }
        public int ScheduledTimeSecs { get { return _ScheduledTimeSecs; } set { _ScheduledTimeSecs = value; } }
        public int SentTimeSecs { get { return _SentTimeSecs; } set { _SentTimeSecs = value; } }
        public int ReceivedTimeSecs { get { return _ReceivedTimeSecs; } set { _ReceivedTimeSecs = value; } }
        public int LastUpdateSecs { get { return _LastUpdateSecs; } set { _LastUpdateSecs = value; } }
        public string FromAddress { get { return _FromAddress; } set { _FromAddress = value; } }
        public int Priority { get { return _Priority; } set { _Priority = value; } }
        public int ReadReceipt { get { return _ReadReceipt; } set { _ReadReceipt = value; } }
        public string Subject { get { return _Subject; } set { _Subject = value; } }
        public int BodyFormat { get { return _BodyFormat; } set { _BodyFormat = value; } }
        public int CustomField1 { get { return _CustomField1; } set { _CustomField1 = value; } }
        public string CustomField2 { get { return _CustomField2; } set { _CustomField2 = value; } }
        public int sysLock { get { return _sysLock; } set { _sysLock = value; } }
        public string sysHash { get { return _sysHash; } set { _sysHash = value; } }
        public int sysForwarded { get { return _sysForwarded; } set { _sysForwarded = value; } }
        public string sysGwReference { get { return _sysGwReference; } set { _sysGwReference = value; } }
        public int sysCreator { get { return _sysCreator; } set { _sysCreator = value; } }
        public int sysArchive { get { return _sysArchive; } set { _sysArchive = value; } }

        public string ToAddress { get { return _ToAddress; } set { _ToAddress = value; } }
        public string Header { get { return _Header; } set { _Header = value; } }
        public string Body { get { return _Body; } set { _Body = value; } }
        public string Trace { get { return _Trace; } set { _Trace = value; } }
        public string Attachments { get { return _Attachments; } set { _Attachments = value; } }

        public DateTime SMS_Date { get { return _SMS_Date; } set { _SMS_Date = value; } }
        public string Corporate_No { get { return _Corporate_No; } set { _Corporate_No = value; } }
        public int Bulk_SMS_ID { get { return _Bulk_SMS_ID; } set { _Bulk_SMS_ID = value; } }
        public int Bulk_SMS { get { return _Bulk_SMS; } set { _Bulk_SMS = value; } }
        public DateTime Bulk_SMS_Date { get { return _Bulk_SMS_Date; } set { _Bulk_SMS_Date = value; } }
        public DateTime Bulk_SMS_Time { get { return _Bulk_SMS_Time; } set { _Bulk_SMS_Time = value; } }
        public string Source { get { return _Source; } set { _Source = value; } }
        public int Payment_Processed { get { return _Payment_Processed; } set { _Payment_Processed = value; } }
        public DateTime Date_Payment_Processed { get { return _Date_Payment_Processed; } set { _Date_Payment_Processed = value; } }
        public DateTime Time_Payment_Processed { get { return _Time_Payment_Processed; } set { _Time_Payment_Processed = value; } }
        public string Processed_By { get { return _Processed_By; } set { _Processed_By = value; } }
        public string Bulk_SMS_No { get { return _Bulk_SMS_No; } set { _Bulk_SMS_No = value; } }
        public string SMS_Sent { get { return _SMS_Sent; } set { _SMS_Sent = value; } }
        public string Back_Up_SMS { get { return _Back_Up_SMS; } set { _Back_Up_SMS = value; } }
        public int Message_Type_ID { get { return _Message_Type_ID; } set { _Message_Type_ID = value; } }
        public int E_Mail_Sent { get { return _E_Mail_Sent; } set { _E_Mail_Sent = value; } }
        public int Marked_For_E_mail { get { return _Marked_For_E_mail; } set { _Marked_For_E_mail = value; } }
        public DateTime Datetime { get { return _Datetime; } set { _Datetime = value; } }
        public int Reply_Sent { get { return _Reply_Sent; } set { _Reply_Sent = value; } }
        public int TotalSmsTrace { get { return _TotalSmsTrace; } set { _TotalSmsTrace = value; } }
        public DateTime CDateTime { get { return _CDateTime; } set { _CDateTime = value; } }
        public string Sender { get { return _Sender; } set { _Sender = value; } }
        public long spID { get { return _spID; } set { _spID = value; } }
        public long serviceID { get { return _serviceID; } set { _serviceID = value; } }
        public long AccessNo { get { return _AccessNo; } set { _AccessNo = value; } }
        public long Correlator { get { return _Correlator; } set { _Correlator = value; } }
        public long TimeStamp { get { return _TimeStamp; } set { _TimeStamp = value; } }
        public string HashedPassword { get { return _HashedPassword; } set { _HashedPassword = value; } }

        #endregion -- public properties --

        #region -- public methods --

        public bool Add()
        {
            bool rval = false;
            try
            {
                rval = new MessagesData().InsertRecord(this);
            }
            catch (Exception e)
            {
            }
            return rval;
        }
        public bool Update()
        {
            bool rval = false;
            //try
            //{
                rval = new MessagesData().UpdateRecord(this, this);
            //}
            //catch (Exception e)
            //{
            //}

            return rval;
        }
        public DataTable GetTablePendingMessages()
        {
            DataTable rval = null;
            rval = new MessagesData().GetTablePendingMessages();
            return rval;
        }
        public DataTable GetTableMessages_By_ID(int ID)
        {
            DataTable rval = null;
            rval = new MessagesData().GetTableMessage(ID);
            return rval;
        }
        public Message[] GetPendingMessages()
        {
            Message[] rval = null;

            rval = new MessagesData().GetPendingMessages();
            return rval;
        }
        public Message GetMessage(int ID)
        {
            Message rval = null;
            rval = new MessagesData().GetMessage(ID);            
            return rval;
        }
        
        public Message[] GetSentAwaitingAckMessages()
        {
            Message[] rval = null;

            rval = new MessagesData().GetSentAwaitingAckMessages();
            return rval;
        }

        #endregion -- public methods --

    }

    public class MessagesData
    {
        public MessagesData()
        {
        }

        public Message[] GetPendingMessages()
        {
            Message[] thisMessagestest = null;// new Message();
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT a.[ID],a.[Direction],a.[Type],a.[Status],a.[StatusDetails],a.[ChannelID],a.[BillingID],a.[MessageReference],a.[ScheduledTimeSecs],a.[SentTimeSecs],a.[ReceivedTimeSecs],a.[LastUpdateSecs],a.[FromAddress],a.[Priority],a.[ReadReceipt],a.[Subject],a.[BodyFormat],a.[CustomField1],a.[CustomField2],a.[sysLock],a.[sysHash],a.[sysForwarded],a.[sysGwReference],a.[sysCreator],a.[sysArchive],a.[ToAddress],a.[Header],a.[Body],a.[Trace],a.[Attachments],a.[SMS Date],a.[Corporate No],a.[Bulk SMS ID],a.[Bulk SMS],a.[Bulk SMS Date],a.[Bulk SMS Time],a.[Source],a.[Payment Processed],a.[Date Payment Processed],a.[Time Payment Processed],a.[Processed By],a.[Bulk SMS No],a.[SMS Sent],a.[Back Up SMS],a.[Message Type ID],a.[E-Mail Sent],a.[Marked For E-mail],a.[Datetime],a.[Reply Sent],a.[TotalSmsTrace],a.[CDateTime],a.[Sender] ";
                    stringSQL += " ,a.[spID],a.[serviceID],b.[correlator_last_used] [Correlator], c.[timeStamp], c.[hashedPassword] ";
                    stringSQL += " FROM [Messages2] a ";
                    stringSQL += " INNER JOIN tblService b ON a.[ChannelID]=b.[ServiceID] ";
                    stringSQL += " INNER JOIN tblServiceProvider c ON a.[ChannelID]=c.[ServiceID] ";
                    stringSQL += " WHERE (1=1) AND(a.[Direction]=2)AND(a.[StatusDetails]=200)AND(a.[Status]=1)";

                    cmd.CommandText = stringSQL;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            int i = 0;
                            foreach (DataRow dr in ds.Tables["myTblName"].Rows)//.Rows[0];
                            {
                                thisMessagestest[i] = DatabaseToMessage(dr);
                                i++;
                                //dr = null;
                            }
                        }
                    }
                }
                mConn.Close();
            }
            return thisMessagestest;
        }

        public Message[] GetSentAwaitingAckMessages()
        {
            Message[] thisMessage = null;// new Message();
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT a.[ID],a.[Direction],a.[Type],a.[Status],a.[StatusDetails],a.[ChannelID],a.[BillingID],a.[MessageReference],a.[ScheduledTimeSecs],a.[SentTimeSecs],a.[ReceivedTimeSecs],a.[LastUpdateSecs],a.[FromAddress],a.[Priority],a.[ReadReceipt],a.[Subject],a.[BodyFormat],a.[CustomField1],a.[CustomField2],a.[sysLock],a.[sysHash],a.[sysForwarded],a.[sysGwReference],a.[sysCreator],a.[sysArchive],a.[ToAddress],a.[Header],a.[Body],a.[Trace],a.[Attachments],a.[SMS Date],a.[Corporate No],a.[Bulk SMS ID],a.[Bulk SMS],a.[Bulk SMS Date],a.[Bulk SMS Time],a.[Source],a.[Payment Processed],a.[Date Payment Processed],a.[Time Payment Processed],a.[Processed By],a.[Bulk SMS No],a.[SMS Sent],a.[Back Up SMS],a.[Message Type ID],a.[E-Mail Sent],a.[Marked For E-mail],a.[Datetime],a.[Reply Sent],a.[TotalSmsTrace],a.[CDateTime],a.[Sender] ";
                    stringSQL += " ,a.[spID],a.[serviceID],b.[correlator_last_used] [Correlator], c.[timeStamp], c.[hashedPassword] ";
                    stringSQL += " FROM [Messages2] a ";
                    stringSQL += " INNER JOIN tblService b ON a.[ChannelID]=b.[ServiceID] ";
                    stringSQL += " INNER JOIN tblServiceProvider c ON a.[ChannelID]=c.[ServiceID] ";
                    stringSQL += " WHERE (1=1) AND(a.[Direction]=2)AND(a.[StatusDetails]=203)AND(a.[Status]=1)";

                    cmd.CommandText = stringSQL;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        DataSet ds = new DataSet();
                        int numberOfRows = da.Fill(ds, "myTblName");
                        if (ds.Tables["myTblName"].Rows.Count > 0)
                        {
                            int i = 0;
                            foreach (DataRow dr in ds.Tables["myTblName"].Rows)//.Rows[0];
                            {
                                thisMessage[i] = DatabaseToMessage(dr);
                                i++;
                                //dr = null;
                            }
                        }
                    }
                }
                mConn.Close();
            }
            return thisMessage;
        }

        public Message GetMessage(int ID)
        {

            Message thisMessagestest = new Message();
            string s = string.Empty;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "SELECT [ID],[Direction],[Type],[Status],[StatusDetails],[ChannelID],[BillingID],[MessageReference],[ScheduledTimeSecs],[SentTimeSecs],[ReceivedTimeSecs],[LastUpdateSecs],[FromAddress],[Priority],[ReadReceipt],[Subject],[BodyFormat],[CustomField1],[CustomField2],[sysLock],[sysHash],[sysForwarded],[sysGwReference],[sysCreator],[sysArchive],[ToAddress],[Header],[Body],[Trace],[Attachments],[SMS Date],[Corporate No],[Bulk SMS ID],[Bulk SMS],[Bulk SMS Date],[Bulk SMS Time],[Source],[Payment Processed],[Date Payment Processed],[Time Payment Processed],[Processed By],[Bulk SMS No],[SMS Sent],[Back Up SMS],[Message Type ID],[E-Mail Sent],[Marked For E-mail],[Datetime],[Reply Sent],[TotalSmsTrace],[CDateTime],[Sender] ";
                        stringSQL += " FROM [Messages2] WHERE (1=1) AND([ID]=@ID)";
                        s = cmd.CommandText = stringSQL;

                        cmd.Parameters.Add("@ID", SqlDbType.Int);
                        cmd.Parameters["@ID"].Value = ID;

                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            DataSet ds = new DataSet();
                            int numberOfRows = da.Fill(ds, "myTblName");
                            if (ds.Tables["myTblName"].Rows.Count > 0)
                            {
                                DataRow dr = ds.Tables["myTblName"].Rows[0];
                                thisMessagestest = DatabaseToMessage(dr);
                                dr = null;
                            }
                        }
                    }
                    mConn.Close();
                }
            }
            catch (Exception e)
            {
                CommonFunctions.LogActivityToDB(e.Message + "  ==>  " + e.Source + " ==> " + s);
            }
            return thisMessagestest;
        }

        public DataTable GetTableMessages()
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [ID],[Direction],[Type],[Status],[StatusDetails],[ChannelID],[BillingID]" +
                        ",[MessageReference],[ScheduledTimeSecs],[SentTimeSecs],[ReceivedTimeSecs],[LastUpdateSecs]" +
                        ",[FromAddress],[Priority],[ReadReceipt],[Subject],[BodyFormat],[CustomField1],[CustomField2]" +
                        ",[sysLock],[sysHash],[sysForwarded],[sysGwReference],[sysCreator],[sysArchive],[ToAddress]" +
                        ",[Header],[Body],[Trace],[Attachments],[SMS Date],[Corporate No],[Bulk SMS ID],[Bulk SMS]" +
                        ",[Bulk SMS Date],[Bulk SMS Time],[Source],[Payment Processed],[Date Payment Processed]" +
                        ",[Time Payment Processed],[Processed By],[Bulk SMS No],[SMS Sent],[Back Up SMS],[Message Type ID]" +
                        ",[E-Mail Sent],[Marked For E-mail],[Datetime],[Reply Sent],[TotalSmsTrace],[CDateTime],[Sender] " +
                        " FROM [Messages2] " +
                        " WHERE (1=1) ";
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

        public DataTable GetTablePendingMessages()
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [ID],[Direction],[Type],[Status],[StatusDetails],[ChannelID],[BillingID]" +
                        ",[MessageReference],[ScheduledTimeSecs],[SentTimeSecs],[ReceivedTimeSecs],[LastUpdateSecs]" +
                        ",[FromAddress],[Priority],[ReadReceipt],[Subject],[BodyFormat],[CustomField1],[CustomField2]" +
                        ",[sysLock],[sysHash],[sysForwarded],[sysGwReference],[sysCreator],[sysArchive],[ToAddress]" +
                        ",[Header],[Body],[Trace],[Attachments],[SMS Date],[Corporate No],[Bulk SMS ID],[Bulk SMS]" +
                        ",[Bulk SMS Date],[Bulk SMS Time],[Source],[Payment Processed],[Date Payment Processed]" +
                        ",[Time Payment Processed],[Processed By],[Bulk SMS No],[SMS Sent],[Back Up SMS],[Message Type ID]" +
                        ",[E-Mail Sent],[Marked For E-mail],[Datetime],[Reply Sent],[TotalSmsTrace],[CDateTime],[Sender] " +
                        " FROM [Messages2] " +
                        " WHERE (1=1) AND ([StatusDetails]=200) AND ([Direction]=2)";
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

        public DataTable GetTableMessage(int ID)
        {
            DataTable rt = null;
            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
            {
                mConn.Open();
                using (SqlCommand cmd = mConn.CreateCommand())
                {
                    string stringSQL = "SELECT [ID],[Direction],[Type],[Status],[StatusDetails],[ChannelID],[BillingID],[MessageReference],[ScheduledTimeSecs],[SentTimeSecs],[ReceivedTimeSecs],[LastUpdateSecs],[FromAddress],[Priority],[ReadReceipt],[Subject],[BodyFormat],[CustomField1],[CustomField2],[sysLock],[sysHash],[sysForwarded],[sysGwReference],[sysCreator],[sysArchive],[ToAddress],[Header],[Body],[Trace],[Attachments],[SMS Date],[Corporate No],[Bulk SMS ID],[Bulk SMS],[Bulk SMS Date],[Bulk SMS Time],[Source],[Payment Processed],[Date Payment Processed],[Time Payment Processed],[Processed By],[Bulk SMS No],[SMS Sent],[Back Up SMS],[Message Type ID],[E-Mail Sent],[Marked For E-mail],[Datetime],[Reply Sent],[TotalSmsTrace],[CDateTime],[Sender] FROM [Messages2] WHERE (1=1) AND([ID]=@ID)";
                    cmd.CommandText = stringSQL;

                    cmd.Parameters.Add("@ID", SqlDbType.Int);
                    cmd.Parameters["@ID"].Value = ID;

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

        private Message DatabaseToMessage(DataRow dr)
        {

            Message thisMessage = new Message();
            if (dr.Table.Columns.Contains("ID")) { thisMessage.ID = int.Parse(dr["ID"].ToString()); }
            if (dr.Table.Columns.Contains("Direction")) { thisMessage.Direction = int.Parse(dr["Direction"].ToString()); }
            if (dr.Table.Columns.Contains("Type")) { thisMessage.Type = int.Parse(dr["Type"].ToString()); }
            if (dr.Table.Columns.Contains("Status")) { thisMessage.Status = int.Parse(dr["Status"].ToString()); }
            if (dr.Table.Columns.Contains("StatusDetails")) { thisMessage.StatusDetails = int.Parse(dr["StatusDetails"].ToString()); }
            if (dr.Table.Columns.Contains("ChannelID")) { thisMessage.ChannelID = long.Parse(dr["ChannelID"].ToString()); }
            if (dr.Table.Columns.Contains("BillingID")) { thisMessage.BillingID = dr["BillingID"].ToString(); }
            if (dr.Table.Columns.Contains("MessageReference")) { thisMessage.MessageReference = dr["MessageReference"].ToString(); }
            //if (dr.Table.Columns.Contains("ScheduledTimeSecs")) { thisMessage.ScheduledTimeSecs = int.Parse(dr["ScheduledTimeSecs"].ToString()); }
            //if (dr.Table.Columns.Contains("SentTimeSecs")) { thisMessage.SentTimeSecs = int.Parse(dr["SentTimeSecs"].ToString()); }
            //if (dr.Table.Columns.Contains("ReceivedTimeSecs")) { thisMessage.ReceivedTimeSecs = int.Parse(dr["ReceivedTimeSecs"].ToString()); }
            //if (dr.Table.Columns.Contains("LastUpdateSecs")) { thisMessage.LastUpdateSecs = int.Parse(dr["LastUpdateSecs"].ToString()); }
            if (dr.Table.Columns.Contains("FromAddress")) { thisMessage.FromAddress = dr["FromAddress"].ToString(); }
            //if (dr.Table.Columns.Contains("Priority")) { thisMessage.Priority = int.Parse(dr["Priority"].ToString()); }
            //if (dr.Table.Columns.Contains("ReadReceipt")) { thisMessage.ReadReceipt = int.Parse(dr["ReadReceipt"].ToString()); }
            if (dr.Table.Columns.Contains("Subject")) { thisMessage.Subject = dr["Subject"].ToString(); }
            //if (dr.Table.Columns.Contains("BodyFormat")) { thisMessage.BodyFormat = int.Parse(dr["BodyFormat"].ToString()); }
            if (dr.Table.Columns.Contains("CustomField1")) { thisMessage.CustomField1 = int.Parse(dr["CustomField1"].ToString()); }
            //if (dr.Table.Columns.Contains("CustomField2")) { thisMessage.CustomField2 = dr["CustomField2"].ToString(); }
            //if (dr.Table.Columns.Contains("sysLock")) { thisMessage.sysLock = int.Parse(dr["sysLock"].ToString()); }
            //if (dr.Table.Columns.Contains("sysHash")) { thisMessage.sysHash = dr["sysHash"].ToString(); }
            //if (dr.Table.Columns.Contains("sysForwarded")) { thisMessage.sysForwarded = int.Parse(dr["sysForwarded"].ToString()); }
            //if (dr.Table.Columns.Contains("sysGwReference")) { thisMessage.sysGwReference = dr["sysGwReference"].ToString(); }
            //if (dr.Table.Columns.Contains("sysCreator")) { thisMessage.sysCreator = int.Parse(dr["sysCreator"].ToString()); }
            //if (dr.Table.Columns.Contains("sysArchive")) { thisMessage.sysArchive = int.Parse(dr["sysArchive"].ToString()); }
            if (dr.Table.Columns.Contains("ToAddress")) { thisMessage.ToAddress = dr["ToAddress"].ToString(); }
            if (dr.Table.Columns.Contains("Header")) { thisMessage.Header = dr["Header"].ToString(); }
            if (dr.Table.Columns.Contains("Body")) { thisMessage.Body = dr["Body"].ToString(); }
            //if (dr.Table.Columns.Contains("Trace")) { thisMessage.Trace = dr["Trace"].ToString(); }
            //if (dr.Table.Columns.Contains("Attachments")) { thisMessage.Attachments = dr["Attachments"].ToString(); }
            //if (dr.Table.Columns.Contains("SMS Date")) { thisMessage.SMS_Date = DateTime.Parse(dr["SMS Date"].ToString()); }
            if (dr.Table.Columns.Contains("Corporate No")) { thisMessage.Corporate_No = dr["Corporate No"].ToString(); }
            //if (dr.Table.Columns.Contains("Bulk SMS ID")) { thisMessage.Bulk_SMS_ID = int.Parse(dr["Bulk SMS ID"].ToString()); }
            //if (dr.Table.Columns.Contains("Bulk SMS")) { thisMessage.Bulk_SMS = int.Parse(dr["Bulk SMS"].ToString()); }
            //if (dr.Table.Columns.Contains("Bulk SMS Date")) { thisMessage.Bulk_SMS_Date = DateTime.Parse(dr["Bulk SMS Date"].ToString()); }
            //if (dr.Table.Columns.Contains("Bulk SMS Time")) { thisMessage.Bulk_SMS_Time = DateTime.Parse(dr["Bulk SMS Time"].ToString()); }
            //if (dr.Table.Columns.Contains("Source")) { thisMessage.Source = dr["Source"].ToString(); }
            //if (dr.Table.Columns.Contains("Payment Processed")) { thisMessage.Payment_Processed = int.Parse(dr["Payment Processed"].ToString()); }
            //if (dr.Table.Columns.Contains("Date Payment Processed")) { thisMessage.Date_Payment_Processed = DateTime.Parse(dr["Date Payment Processed"].ToString()); }
            //if (dr.Table.Columns.Contains("Time Payment Processed")) { thisMessage.Time_Payment_Processed = DateTime.Parse(dr["Time Payment Processed"].ToString()); }
            //if (dr.Table.Columns.Contains("Processed By")) { thisMessage.Processed_By = dr["Processed By"].ToString(); }
            //if (dr.Table.Columns.Contains("Bulk SMS No")) { thisMessage.Bulk_SMS_No = dr["Bulk SMS No"].ToString(); }
            //if (dr.Table.Columns.Contains("SMS Sent")) { thisMessage.SMS_Sent = dr["SMS Sent"].ToString(); }
            //if (dr.Table.Columns.Contains("Back Up SMS")) { thisMessage.Back_Up_SMS = dr["Back Up SMS"].ToString(); }
            //if (dr.Table.Columns.Contains("Message Type ID")) { thisMessage.Message_Type_ID = int.Parse(dr["Message Type ID"].ToString()); }
            //if (dr.Table.Columns.Contains("E-Mail Sent")) { thisMessage.E_Mail_Sent = int.Parse(dr["E-Mail Sent"].ToString()); }
            //if (dr.Table.Columns.Contains("Marked For E-mail")) { thisMessage.Marked_For_E_mail = int.Parse(dr["Marked For E-mail"].ToString()); }
            if (dr.Table.Columns.Contains("Datetime")) { thisMessage.Datetime = DateTime.Parse(dr["Datetime"].ToString()); }
            //if (dr.Table.Columns.Contains("Reply Sent")) { thisMessage.Reply_Sent = int.Parse(dr["Reply Sent"].ToString()); }
            //if (dr.Table.Columns.Contains("TotalSmsTrace")) { thisMessage.TotalSmsTrace = int.Parse(dr["TotalSmsTrace"].ToString()); }
            //if (dr.Table.Columns.Contains("CDateTime")) { thisMessage.CDateTime = DateTime.Parse(dr["CDateTime"].ToString()); }
            if (dr.Table.Columns.Contains("Sender")) { thisMessage.Sender = dr["Sender"].ToString(); }

            if (dr.Table.Columns.Contains("spID")) { thisMessage.spID = long.Parse(dr["spID"].ToString()); }
            if (dr.Table.Columns.Contains("serviceID")) { thisMessage.serviceID = long.Parse(dr["serviceID"].ToString()); }

            if (dr.Table.Columns.Contains("AccessNo")) { thisMessage.AccessNo = long.Parse(dr["AccessNo"].ToString()); }
            if (dr.Table.Columns.Contains("Correlator")) { thisMessage.Correlator = long.Parse(dr["Correlator"].ToString()); }
            if (dr.Table.Columns.Contains("timeStamp")) { thisMessage.TimeStamp = long.Parse(dr["timeStamp"].ToString()); }
            if (dr.Table.Columns.Contains("hashedPassword")) { thisMessage.HashedPassword = dr["hashedPassword"].ToString(); }

            dr = null;
            return thisMessage;
        }

        public bool InsertRecord(Message thisMessagestest)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "INSERT INTO [Messages2] ( " +
    "[Direction],[Type],[Status],[StatusDetails],[ChannelID],[BillingID],[MessageReference],[ScheduledTimeSecs],[SentTimeSecs],[ReceivedTimeSecs],[LastUpdateSecs]" +
    ",[FromAddress],[Priority],[ReadReceipt],[Subject],[BodyFormat],[CustomField1],[CustomField2],[sysLock],[sysHash],[sysForwarded],[sysGwReference]" +
    ",[sysCreator],[sysArchive],[ToAddress],[Header],[Body],[Trace],[Attachments],[SMS Date],[Corporate No],[Bulk SMS ID],[Bulk SMS]" +
    ",[Bulk SMS Date],[Bulk SMS Time],[Source],[Payment Processed],[Date Payment Processed],[Time Payment Processed],[Processed By],[Bulk SMS No],[SMS Sent],[Back Up SMS],[Message Type ID]" +
    ",[E-Mail Sent],[Marked For E-mail],[Datetime],[Reply Sent],[TotalSmsTrace],[CDateTime],[Sender],[spID],[serviceID],[correlator]" +
    ") VALUES(" +
    "@Direction,@Type,@Status,@StatusDetails,@ChannelID,@BillingID,@MessageReference,@ScheduledTimeSecs,@SentTimeSecs,@ReceivedTimeSecs,@LastUpdateSecs" +
    ",@FromAddress,@Priority,@ReadReceipt,@Subject,@BodyFormat,@CustomField1,@CustomField2,@sysLock,@sysHash,@sysForwarded,@sysGwReference" +
    ",@sysCreator,@sysArchive,@ToAddress,@Header,@Body,@Trace,@Attachments,@SMS_Date,@Corporate_No,@Bulk_SMS_ID,@Bulk_SMS" +
    ",@Bulk_SMS_Date,@Bulk_SMS_Time,@Source,@Payment_Processed,@Date_Payment_Processed,@Time_Payment_Processed,@Processed_By,@Bulk_SMS_No,@SMS_Sent,@Back_Up_SMS,@Message_Type_ID" +
    ",@E_Mail_Sent,@Marked_For_E_mail,@Datetime,@Reply_Sent,@TotalSmsTrace,@CDateTime,@Sender,@spID,@serviceID,@correlator" +
    ")";
                        cmd.CommandText = stringSQL;

                        cmd.Parameters.Add("@Direction", SqlDbType.Int);
                        cmd.Parameters["@Direction"].Value = thisMessagestest.Direction;

                        cmd.Parameters.Add("@Type", SqlDbType.Int);
                        cmd.Parameters["@Type"].Value = thisMessagestest.Type;

                        cmd.Parameters.Add("@Status", SqlDbType.Int);
                        cmd.Parameters["@Status"].Value = thisMessagestest.Status;

                        cmd.Parameters.Add("@StatusDetails", SqlDbType.Int);
                        cmd.Parameters["@StatusDetails"].Value = thisMessagestest.StatusDetails;

                        cmd.Parameters.Add("@ChannelID", SqlDbType.BigInt);
                        cmd.Parameters["@ChannelID"].Value = thisMessagestest.ChannelID;

                        cmd.Parameters.Add("@BillingID", SqlDbType.VarChar, 255);
                        cmd.Parameters["@BillingID"].Value = thisMessagestest.BillingID;

                        cmd.Parameters.Add("@MessageReference", SqlDbType.VarChar, 50);
                        cmd.Parameters["@MessageReference"].Value = thisMessagestest.MessageReference;

                        cmd.Parameters.Add("@ScheduledTimeSecs", SqlDbType.Int);
                        cmd.Parameters["@ScheduledTimeSecs"].Value = thisMessagestest.ScheduledTimeSecs;

                        cmd.Parameters.Add("@SentTimeSecs", SqlDbType.Int);
                        cmd.Parameters["@SentTimeSecs"].Value = thisMessagestest.SentTimeSecs;

                        cmd.Parameters.Add("@ReceivedTimeSecs", SqlDbType.Int);
                        cmd.Parameters["@ReceivedTimeSecs"].Value = thisMessagestest.ReceivedTimeSecs;

                        cmd.Parameters.Add("@LastUpdateSecs", SqlDbType.Int);
                        cmd.Parameters["@LastUpdateSecs"].Value = thisMessagestest.LastUpdateSecs;

                        cmd.Parameters.Add("@FromAddress", SqlDbType.VarChar, 255);
                        cmd.Parameters["@FromAddress"].Value = thisMessagestest.FromAddress;

                        cmd.Parameters.Add("@Priority", SqlDbType.Int);
                        cmd.Parameters["@Priority"].Value = thisMessagestest.Priority;

                        cmd.Parameters.Add("@ReadReceipt", SqlDbType.Bit);
                        cmd.Parameters["@ReadReceipt"].Value = thisMessagestest.ReadReceipt;

                        cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 255);
                        cmd.Parameters["@Subject"].Value = thisMessagestest.Subject;

                        cmd.Parameters.Add("@BodyFormat", SqlDbType.Int);
                        cmd.Parameters["@BodyFormat"].Value = thisMessagestest.BodyFormat;

                        cmd.Parameters.Add("@CustomField1", SqlDbType.Int);
                        cmd.Parameters["@CustomField1"].Value = thisMessagestest.CustomField1;

                        cmd.Parameters.Add("@CustomField2", SqlDbType.VarChar, 255);
                        cmd.Parameters["@CustomField2"].Value = thisMessagestest.CustomField2;

                        cmd.Parameters.Add("@sysLock", SqlDbType.Bit);
                        cmd.Parameters["@sysLock"].Value = thisMessagestest.sysLock;

                        cmd.Parameters.Add("@sysHash", SqlDbType.VarChar, 50);
                        cmd.Parameters["@sysHash"].Value = thisMessagestest.sysHash;

                        cmd.Parameters.Add("@sysForwarded", SqlDbType.Bit);
                        cmd.Parameters["@sysForwarded"].Value = thisMessagestest.sysForwarded;

                        cmd.Parameters.Add("@sysGwReference", SqlDbType.VarChar, 50);
                        cmd.Parameters["@sysGwReference"].Value = thisMessagestest.sysGwReference;

                        cmd.Parameters.Add("@sysCreator", SqlDbType.Int);
                        cmd.Parameters["@sysCreator"].Value = thisMessagestest.sysCreator;

                        cmd.Parameters.Add("@sysArchive", SqlDbType.Bit);
                        cmd.Parameters["@sysArchive"].Value = thisMessagestest.sysArchive;

                        cmd.Parameters.Add("@ToAddress", SqlDbType.NText);
                        cmd.Parameters["@ToAddress"].Value = thisMessagestest.ToAddress;

                        cmd.Parameters.Add("@Header", SqlDbType.NText);
                        cmd.Parameters["@Header"].Value = thisMessagestest.Header;

                        cmd.Parameters.Add("@Body", SqlDbType.NText);
                        cmd.Parameters["@Body"].Value = thisMessagestest.Body;

                        cmd.Parameters.Add("@Trace", SqlDbType.NText);
                        cmd.Parameters["@Trace"].Value = thisMessagestest.Trace;

                        cmd.Parameters.Add("@Attachments", SqlDbType.NText);
                        cmd.Parameters["@Attachments"].Value = thisMessagestest.Attachments;

                        cmd.Parameters.Add("@SMS_Date", SqlDbType.DateTime);
                        cmd.Parameters["@SMS_Date"].Value = thisMessagestest.SMS_Date;

                        cmd.Parameters.Add("@Corporate_No", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Corporate_No"].Value = thisMessagestest.Corporate_No;

                        cmd.Parameters.Add("@Bulk_SMS_ID", SqlDbType.Int);
                        cmd.Parameters["@Bulk_SMS_ID"].Value = thisMessagestest.Bulk_SMS_ID;

                        cmd.Parameters.Add("@Bulk_SMS", SqlDbType.Int);
                        cmd.Parameters["@Bulk_SMS"].Value = thisMessagestest.Bulk_SMS;

                        cmd.Parameters.Add("@Bulk_SMS_Date", SqlDbType.DateTime);
                        cmd.Parameters["@Bulk_SMS_Date"].Value = thisMessagestest.Bulk_SMS_Date;

                        cmd.Parameters.Add("@Bulk_SMS_Time", SqlDbType.DateTime);
                        cmd.Parameters["@Bulk_SMS_Time"].Value = thisMessagestest.Bulk_SMS_Time;

                        cmd.Parameters.Add("@Source", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Source"].Value = thisMessagestest.Source;

                        cmd.Parameters.Add("@Payment_Processed", SqlDbType.Int);
                        cmd.Parameters["@Payment_Processed"].Value = thisMessagestest.Payment_Processed;

                        cmd.Parameters.Add("@Date_Payment_Processed", SqlDbType.DateTime);
                        cmd.Parameters["@Date_Payment_Processed"].Value = thisMessagestest.Date_Payment_Processed;

                        cmd.Parameters.Add("@Time_Payment_Processed", SqlDbType.DateTime);
                        cmd.Parameters["@Time_Payment_Processed"].Value = thisMessagestest.Time_Payment_Processed;

                        cmd.Parameters.Add("@Processed_By", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Processed_By"].Value = thisMessagestest.Processed_By;

                        cmd.Parameters.Add("@Bulk_SMS_No", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Bulk_SMS_No"].Value = thisMessagestest.Bulk_SMS_No;

                        cmd.Parameters.Add("@SMS_Sent", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@SMS_Sent"].Value = thisMessagestest.SMS_Sent;

                        cmd.Parameters.Add("@Back_Up_SMS", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Back_Up_SMS"].Value = thisMessagestest.Back_Up_SMS;

                        cmd.Parameters.Add("@Message_Type_ID", SqlDbType.Int);
                        cmd.Parameters["@Message_Type_ID"].Value = thisMessagestest.Message_Type_ID;

                        cmd.Parameters.Add("@E_Mail_Sent", SqlDbType.Int);
                        cmd.Parameters["@E_Mail_Sent"].Value = thisMessagestest.E_Mail_Sent;

                        cmd.Parameters.Add("@Marked_For_E_mail", SqlDbType.Int);
                        cmd.Parameters["@Marked_For_E_mail"].Value = thisMessagestest.Marked_For_E_mail;

                        cmd.Parameters.Add("@Datetime", SqlDbType.DateTime);
                        cmd.Parameters["@Datetime"].Value = thisMessagestest.Datetime;

                        cmd.Parameters.Add("@Reply_Sent", SqlDbType.Int);
                        cmd.Parameters["@Reply_Sent"].Value = thisMessagestest.Reply_Sent;

                        cmd.Parameters.Add("@TotalSmsTrace", SqlDbType.Int);
                        cmd.Parameters["@TotalSmsTrace"].Value = thisMessagestest.TotalSmsTrace;

                        cmd.Parameters.Add("@CDateTime", SqlDbType.DateTime);
                        cmd.Parameters["@CDateTime"].Value = thisMessagestest.CDateTime;

                        cmd.Parameters.Add("@Sender", SqlDbType.VarChar, 120);
                        cmd.Parameters["@Sender"].Value = thisMessagestest.Sender;

                        cmd.Parameters.Add("@spID", SqlDbType.BigInt);
                        cmd.Parameters["@spID"].Value = thisMessagestest.spID;

                        cmd.Parameters.Add("@serviceID", SqlDbType.BigInt);
                        cmd.Parameters["@serviceID"].Value = thisMessagestest.serviceID;

                        cmd.Parameters.Add("@correlator", SqlDbType.BigInt);
                        cmd.Parameters["@correlator"].Value = thisMessagestest.Correlator;

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


        public bool UpdateRecord(Message newMessagestest, Message oldMessagestest)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "UPDATE [Messages2] SET " +
                                " [Direction]= @Direction,[Type]= @Type,[Status]= @Status,[StatusDetails]= @StatusDetails,[ChannelID]= @ChannelID,[BillingID]= @BillingID" +
                                ",[MessageReference]= @MessageReference,[ScheduledTimeSecs]= @ScheduledTimeSecs,[SentTimeSecs]= @SentTimeSecs,[ReceivedTimeSecs]= @ReceivedTimeSecs,[LastUpdateSecs]= @LastUpdateSecs,[FromAddress]= @FromAddress" +
                                ",[Priority]= @Priority,[ReadReceipt]= @ReadReceipt,[Subject]= @Subject,[BodyFormat]= @BodyFormat,[CustomField1]= @CustomField1,[CustomField2]= @CustomField2" +
                                ",[sysLock]= @sysLock,[sysHash]= @sysHash,[sysForwarded]= @sysForwarded,[sysGwReference]= @sysGwReference,[sysCreator]= @sysCreator,[sysArchive]= @sysArchive" +
                                ",[ToAddress]= @ToAddress,[Header]= @Header,[Body]= @Body,[Trace]= @Trace,[Attachments]= @Attachments,[SMS Date]= @SMS_Date" +
                                ",[Corporate No]= @Corporate_No,[Bulk SMS ID]= @Bulk_SMS_ID,[Bulk SMS]= @Bulk_SMS,[Bulk SMS Date]= @Bulk_SMS_Date,[Bulk SMS Time]= @Bulk_SMS_Time,[Source]= @Source" +
                                ",[Payment Processed]= @Payment_Processed,[Date Payment Processed]= @Date_Payment_Processed,[Time Payment Processed]= @Time_Payment_Processed,[Processed By]= @Processed_By,[Bulk SMS No]= @Bulk_SMS_No,[SMS Sent]= @SMS_Sent" +
                                ",[Back Up SMS]= @Back_Up_SMS,[Message Type ID]= @Message_Type_ID,[E-Mail Sent]= @E_Mail_Sent,[Marked For E-mail]= @Marked_For_E_mail,[Datetime]= @Datetime,[Reply Sent]= @Reply_Sent" +
                                ",[TotalSmsTrace]= @TotalSmsTrace,[CDateTime]= @CDateTime,[Sender]= @Sender,[spID]=@spID,[serviceID]=@serviceID,[correlator]=@correlator ";
                        stringSQL += " WHERE (1=1) AND([ID]=@ID)";

                        cmd.CommandText = stringSQL;

                        cmd.Parameters.Add("@Direction", SqlDbType.Int);
                        cmd.Parameters["@Direction"].Value = newMessagestest.Direction;

                        cmd.Parameters.Add("@Type", SqlDbType.Int);
                        cmd.Parameters["@Type"].Value = newMessagestest.Type;

                        cmd.Parameters.Add("@Status", SqlDbType.Int);
                        cmd.Parameters["@Status"].Value = newMessagestest.Status;

                        cmd.Parameters.Add("@StatusDetails", SqlDbType.Int);
                        cmd.Parameters["@StatusDetails"].Value = newMessagestest.StatusDetails;

                        cmd.Parameters.Add("@ChannelID", SqlDbType.Float);
                        cmd.Parameters["@ChannelID"].Value = newMessagestest.ChannelID;

                        cmd.Parameters.Add("@BillingID", SqlDbType.VarChar, 255);
                        cmd.Parameters["@BillingID"].Value = newMessagestest.BillingID;

                        cmd.Parameters.Add("@MessageReference", SqlDbType.VarChar, 50);
                        cmd.Parameters["@MessageReference"].Value = newMessagestest.MessageReference;

                        cmd.Parameters.Add("@ScheduledTimeSecs", SqlDbType.Int);
                        cmd.Parameters["@ScheduledTimeSecs"].Value = newMessagestest.ScheduledTimeSecs;

                        cmd.Parameters.Add("@SentTimeSecs", SqlDbType.Int);
                        cmd.Parameters["@SentTimeSecs"].Value = newMessagestest.SentTimeSecs;

                        cmd.Parameters.Add("@ReceivedTimeSecs", SqlDbType.Int);
                        cmd.Parameters["@ReceivedTimeSecs"].Value = newMessagestest.ReceivedTimeSecs;

                        cmd.Parameters.Add("@LastUpdateSecs", SqlDbType.Int);
                        cmd.Parameters["@LastUpdateSecs"].Value = newMessagestest.LastUpdateSecs;

                        cmd.Parameters.Add("@FromAddress", SqlDbType.VarChar, 255);
                        cmd.Parameters["@FromAddress"].Value = newMessagestest.FromAddress;

                        cmd.Parameters.Add("@Priority", SqlDbType.Int);
                        cmd.Parameters["@Priority"].Value = newMessagestest.Priority;

                        cmd.Parameters.Add("@ReadReceipt", SqlDbType.Bit);
                        cmd.Parameters["@ReadReceipt"].Value = newMessagestest.ReadReceipt;

                        cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 255);
                        cmd.Parameters["@Subject"].Value = newMessagestest.Subject;

                        cmd.Parameters.Add("@BodyFormat", SqlDbType.Int);
                        cmd.Parameters["@BodyFormat"].Value = newMessagestest.BodyFormat;

                        cmd.Parameters.Add("@CustomField1", SqlDbType.Int);
                        cmd.Parameters["@CustomField1"].Value = newMessagestest.CustomField1;

                        cmd.Parameters.Add("@CustomField2", SqlDbType.VarChar, 255);
                        cmd.Parameters["@CustomField2"].Value = newMessagestest.CustomField2;

                        cmd.Parameters.Add("@sysLock", SqlDbType.Bit);
                        cmd.Parameters["@sysLock"].Value = newMessagestest.sysLock;

                        cmd.Parameters.Add("@sysHash", SqlDbType.VarChar, 50);
                        cmd.Parameters["@sysHash"].Value = newMessagestest.sysHash;

                        cmd.Parameters.Add("@sysForwarded", SqlDbType.Bit);
                        cmd.Parameters["@sysForwarded"].Value = newMessagestest.sysForwarded;

                        cmd.Parameters.Add("@sysGwReference", SqlDbType.VarChar, 50);
                        cmd.Parameters["@sysGwReference"].Value = newMessagestest.sysGwReference;

                        cmd.Parameters.Add("@sysCreator", SqlDbType.Int);
                        cmd.Parameters["@sysCreator"].Value = newMessagestest.sysCreator;

                        cmd.Parameters.Add("@sysArchive", SqlDbType.Bit);
                        cmd.Parameters["@sysArchive"].Value = newMessagestest.sysArchive;

                        cmd.Parameters.Add("@ToAddress", SqlDbType.NText);
                        cmd.Parameters["@ToAddress"].Value = newMessagestest.ToAddress;

                        cmd.Parameters.Add("@Header", SqlDbType.NText);
                        cmd.Parameters["@Header"].Value = newMessagestest.Header;

                        cmd.Parameters.Add("@Body", SqlDbType.NText);
                        cmd.Parameters["@Body"].Value = newMessagestest.Body;

                        cmd.Parameters.Add("@Trace", SqlDbType.NText);
                        cmd.Parameters["@Trace"].Value = newMessagestest.Trace;

                        cmd.Parameters.Add("@Attachments", SqlDbType.NText);
                        cmd.Parameters["@Attachments"].Value = newMessagestest.Attachments;

                        cmd.Parameters.Add("@SMS_Date", SqlDbType.DateTime);
                        cmd.Parameters["@SMS_Date"].Value = newMessagestest.SMS_Date;

                        cmd.Parameters.Add("@Corporate_No", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Corporate_No"].Value = newMessagestest.Corporate_No;

                        cmd.Parameters.Add("@Bulk_SMS_ID", SqlDbType.Int);
                        cmd.Parameters["@Bulk_SMS_ID"].Value = newMessagestest.Bulk_SMS_ID;

                        cmd.Parameters.Add("@Bulk_SMS", SqlDbType.Int);
                        cmd.Parameters["@Bulk_SMS"].Value = newMessagestest.Bulk_SMS;

                        cmd.Parameters.Add("@Bulk_SMS_Date", SqlDbType.DateTime);
                        cmd.Parameters["@Bulk_SMS_Date"].Value = newMessagestest.Bulk_SMS_Date;

                        cmd.Parameters.Add("@Bulk_SMS_Time", SqlDbType.DateTime);
                        cmd.Parameters["@Bulk_SMS_Time"].Value = newMessagestest.Bulk_SMS_Time;

                        cmd.Parameters.Add("@Source", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Source"].Value = newMessagestest.Source;

                        cmd.Parameters.Add("@Payment_Processed", SqlDbType.Int);
                        cmd.Parameters["@Payment_Processed"].Value = newMessagestest.Payment_Processed;

                        cmd.Parameters.Add("@Date_Payment_Processed", SqlDbType.DateTime);
                        cmd.Parameters["@Date_Payment_Processed"].Value = newMessagestest.Date_Payment_Processed;

                        cmd.Parameters.Add("@Time_Payment_Processed", SqlDbType.DateTime);
                        cmd.Parameters["@Time_Payment_Processed"].Value = newMessagestest.Time_Payment_Processed;

                        cmd.Parameters.Add("@Processed_By", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Processed_By"].Value = newMessagestest.Processed_By;

                        cmd.Parameters.Add("@Bulk_SMS_No", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Bulk_SMS_No"].Value = newMessagestest.Bulk_SMS_No;

                        cmd.Parameters.Add("@SMS_Sent", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@SMS_Sent"].Value = newMessagestest.SMS_Sent;

                        cmd.Parameters.Add("@Back_Up_SMS", SqlDbType.NVarChar, 50);
                        cmd.Parameters["@Back_Up_SMS"].Value = newMessagestest.Back_Up_SMS;

                        cmd.Parameters.Add("@Message_Type_ID", SqlDbType.Int);
                        cmd.Parameters["@Message_Type_ID"].Value = newMessagestest.Message_Type_ID;

                        cmd.Parameters.Add("@E_Mail_Sent", SqlDbType.Int);
                        cmd.Parameters["@E_Mail_Sent"].Value = newMessagestest.E_Mail_Sent;

                        cmd.Parameters.Add("@Marked_For_E_mail", SqlDbType.Int);
                        cmd.Parameters["@Marked_For_E_mail"].Value = newMessagestest.Marked_For_E_mail;

                        cmd.Parameters.Add("@Datetime", SqlDbType.DateTime);
                        cmd.Parameters["@Datetime"].Value = newMessagestest.Datetime;

                        cmd.Parameters.Add("@Reply_Sent", SqlDbType.Int);
                        cmd.Parameters["@Reply_Sent"].Value = newMessagestest.Reply_Sent;

                        cmd.Parameters.Add("@TotalSmsTrace", SqlDbType.Int);
                        cmd.Parameters["@TotalSmsTrace"].Value = newMessagestest.TotalSmsTrace;

                        cmd.Parameters.Add("@CDateTime", SqlDbType.DateTime);
                        cmd.Parameters["@CDateTime"].Value = newMessagestest.CDateTime;

                        cmd.Parameters.Add("@Sender", SqlDbType.VarChar, 120);
                        cmd.Parameters["@Sender"].Value = newMessagestest.Sender;

                        cmd.Parameters.Add("@spID", SqlDbType.BigInt);
                        cmd.Parameters["@spID"].Value = newMessagestest.spID;

                        cmd.Parameters.Add("@serviceID", SqlDbType.BigInt);
                        cmd.Parameters["@serviceID"].Value = newMessagestest.serviceID;

                        cmd.Parameters.Add("@correlator", SqlDbType.Int);
                        cmd.Parameters["@correlator"].Value = newMessagestest.Correlator;

                        cmd.Parameters.Add("@ID", SqlDbType.Int);
                        cmd.Parameters["@ID"].Value = newMessagestest.ID;

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


    //    public bool UpdateRecord(Message newMessagestest, Message oldMessagestest)
    //    {
    //        bool rtVal = false;
    //        try
    //        {
    //            using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
    //            {
    //                mConn.Open();
    //                using (SqlCommand cmd = mConn.CreateCommand())
    //                {
    //                    string stringSQL = "UPDATE [Messages2] SET " +
    //" [Direction]= @Direction,[Type]= @Type,[Status]= @Status,[StatusDetails]= @StatusDetails,[ChannelID]= @ChannelID,[BillingID]= @BillingID" +
    //",[MessageReference]= @MessageReference,[ScheduledTimeSecs]= @ScheduledTimeSecs,[SentTimeSecs]= @SentTimeSecs,[ReceivedTimeSecs]= @ReceivedTimeSecs,[LastUpdateSecs]= @LastUpdateSecs,[FromAddress]= @FromAddress" +
    //",[Priority]= @Priority,[ReadReceipt]= @ReadReceipt,[Subject]= @Subject,[BodyFormat]= @BodyFormat,[CustomField1]= @CustomField1,[CustomField2]= @CustomField2" +
    //",[sysLock]= @sysLock,[sysHash]= @sysHash,[sysForwarded]= @sysForwarded,[sysGwReference]= @sysGwReference,[sysCreator]= @sysCreator,[sysArchive]= @sysArchive" +
    //",[ToAddress]= @ToAddress,[Header]= @Header,[Body]= @Body,[Trace]= @Trace,[Attachments]= @Attachments,[SMS Date]= @SMS_Date" +
    //",[Corporate No]= @Corporate_No,[Bulk SMS ID]= @Bulk_SMS_ID,[Bulk SMS]= @Bulk_SMS,[Bulk SMS Date]= @Bulk_SMS_Date,[Bulk SMS Time]= @Bulk_SMS_Time,[Source]= @Source" +
    //",[Payment Processed]= @Payment_Processed,[Date Payment Processed]= @Date_Payment_Processed,[Time Payment Processed]= @Time_Payment_Processed,[Processed By]= @Processed_By,[Bulk SMS No]= @Bulk_SMS_No,[SMS Sent]= @SMS_Sent" +
    //",[Back Up SMS]= @Back_Up_SMS,[Message Type ID]= @Message_Type_ID,[E-Mail Sent]= @E_Mail_Sent,[Marked For E-mail]= @Marked_For_E_mail,[Datetime]= @Datetime,[Reply Sent]= @Reply_Sent" +
    //",[TotalSmsTrace]= @TotalSmsTrace,[CDateTime]= @CDateTime,[Sender]= @Sender";
    //                    stringSQL += " WHERE (1=1) AND([ID]=@ID)";

    //                    cmd.CommandText = stringSQL;

    //                    cmd.Parameters.Add("@Direction", SqlDbType.Int);
    //                    cmd.Parameters["@Direction"].Value = newMessagestest.Direction;

    //                    cmd.Parameters.Add("@Type", SqlDbType.Int);
    //                    cmd.Parameters["@Type"].Value = newMessagestest.Type;

    //                    cmd.Parameters.Add("@Status", SqlDbType.Int);
    //                    cmd.Parameters["@Status"].Value = newMessagestest.Status;

    //                    cmd.Parameters.Add("@StatusDetails", SqlDbType.Int);
    //                    cmd.Parameters["@StatusDetails"].Value = newMessagestest.StatusDetails;

    //                    cmd.Parameters.Add("@ChannelID", SqlDbType.Float);
    //                    cmd.Parameters["@ChannelID"].Value = newMessagestest.ChannelID;

    //                    cmd.Parameters.Add("@BillingID", SqlDbType.VarChar, 255);
    //                    cmd.Parameters["@BillingID"].Value = newMessagestest.BillingID;

    //                    cmd.Parameters.Add("@MessageReference", SqlDbType.VarChar, 50);
    //                    cmd.Parameters["@MessageReference"].Value = newMessagestest.MessageReference;

    //                    cmd.Parameters.Add("@ScheduledTimeSecs", SqlDbType.Int);
    //                    cmd.Parameters["@ScheduledTimeSecs"].Value = newMessagestest.ScheduledTimeSecs;

    //                    cmd.Parameters.Add("@SentTimeSecs", SqlDbType.Int);
    //                    cmd.Parameters["@SentTimeSecs"].Value = newMessagestest.SentTimeSecs;

    //                    cmd.Parameters.Add("@ReceivedTimeSecs", SqlDbType.Int);
    //                    cmd.Parameters["@ReceivedTimeSecs"].Value = newMessagestest.ReceivedTimeSecs;

    //                    cmd.Parameters.Add("@LastUpdateSecs", SqlDbType.Int);
    //                    cmd.Parameters["@LastUpdateSecs"].Value = newMessagestest.LastUpdateSecs;

    //                    cmd.Parameters.Add("@FromAddress", SqlDbType.VarChar, 255);
    //                    cmd.Parameters["@FromAddress"].Value = newMessagestest.FromAddress;

    //                    cmd.Parameters.Add("@Priority", SqlDbType.Int);
    //                    cmd.Parameters["@Priority"].Value = newMessagestest.Priority;

    //                    cmd.Parameters.Add("@ReadReceipt", SqlDbType.Bit);
    //                    cmd.Parameters["@ReadReceipt"].Value = newMessagestest.ReadReceipt;

    //                    cmd.Parameters.Add("@Subject", SqlDbType.VarChar, 255);
    //                    cmd.Parameters["@Subject"].Value = newMessagestest.Subject;

    //                    cmd.Parameters.Add("@BodyFormat", SqlDbType.Int);
    //                    cmd.Parameters["@BodyFormat"].Value = newMessagestest.BodyFormat;

    //                    cmd.Parameters.Add("@CustomField1", SqlDbType.Int);
    //                    cmd.Parameters["@CustomField1"].Value = newMessagestest.CustomField1;

    //                    cmd.Parameters.Add("@CustomField2", SqlDbType.VarChar, 255);
    //                    cmd.Parameters["@CustomField2"].Value = newMessagestest.CustomField2;

    //                    cmd.Parameters.Add("@sysLock", SqlDbType.Bit);
    //                    cmd.Parameters["@sysLock"].Value = newMessagestest.sysLock;

    //                    cmd.Parameters.Add("@sysHash", SqlDbType.VarChar, 50);
    //                    cmd.Parameters["@sysHash"].Value = newMessagestest.sysHash;

    //                    cmd.Parameters.Add("@sysForwarded", SqlDbType.Bit);
    //                    cmd.Parameters["@sysForwarded"].Value = newMessagestest.sysForwarded;

    //                    cmd.Parameters.Add("@sysGwReference", SqlDbType.VarChar, 50);
    //                    cmd.Parameters["@sysGwReference"].Value = newMessagestest.sysGwReference;

    //                    cmd.Parameters.Add("@sysCreator", SqlDbType.Int);
    //                    cmd.Parameters["@sysCreator"].Value = newMessagestest.sysCreator;

    //                    cmd.Parameters.Add("@sysArchive", SqlDbType.Bit);
    //                    cmd.Parameters["@sysArchive"].Value = newMessagestest.sysArchive;

    //                    cmd.Parameters.Add("@ToAddress", SqlDbType.NText);
    //                    cmd.Parameters["@ToAddress"].Value = newMessagestest.ToAddress;

    //                    cmd.Parameters.Add("@Header", SqlDbType.NText);
    //                    cmd.Parameters["@Header"].Value = newMessagestest.Header;

    //                    cmd.Parameters.Add("@Body", SqlDbType.NText);
    //                    cmd.Parameters["@Body"].Value = newMessagestest.Body;

    //                    cmd.Parameters.Add("@Trace", SqlDbType.NText);
    //                    cmd.Parameters["@Trace"].Value = newMessagestest.Trace;

    //                    cmd.Parameters.Add("@Attachments", SqlDbType.NText);
    //                    cmd.Parameters["@Attachments"].Value = newMessagestest.Attachments;

    //                    cmd.Parameters.Add("@SMS_Date", SqlDbType.DateTime);
    //                    cmd.Parameters["@SMS_Date"].Value = newMessagestest.SMS_Date;

    //                    cmd.Parameters.Add("@Corporate_No", SqlDbType.NVarChar, 50);
    //                    cmd.Parameters["@Corporate_No"].Value = newMessagestest.Corporate_No;

    //                    cmd.Parameters.Add("@Bulk_SMS_ID", SqlDbType.Int);
    //                    cmd.Parameters["@Bulk_SMS_ID"].Value = newMessagestest.Bulk_SMS_ID;

    //                    cmd.Parameters.Add("@Bulk_SMS", SqlDbType.Int);
    //                    cmd.Parameters["@Bulk_SMS"].Value = newMessagestest.Bulk_SMS;

    //                    cmd.Parameters.Add("@Bulk_SMS_Date", SqlDbType.DateTime);
    //                    cmd.Parameters["@Bulk_SMS_Date"].Value = newMessagestest.Bulk_SMS_Date;

    //                    cmd.Parameters.Add("@Bulk_SMS_Time", SqlDbType.DateTime);
    //                    cmd.Parameters["@Bulk_SMS_Time"].Value = newMessagestest.Bulk_SMS_Time;

    //                    cmd.Parameters.Add("@Source", SqlDbType.NVarChar, 50);
    //                    cmd.Parameters["@Source"].Value = newMessagestest.Source;

    //                    cmd.Parameters.Add("@Payment_Processed", SqlDbType.Int);
    //                    cmd.Parameters["@Payment_Processed"].Value = newMessagestest.Payment_Processed;

    //                    cmd.Parameters.Add("@Date_Payment_Processed", SqlDbType.DateTime);
    //                    cmd.Parameters["@Date_Payment_Processed"].Value = newMessagestest.Date_Payment_Processed;

    //                    cmd.Parameters.Add("@Time_Payment_Processed", SqlDbType.DateTime);
    //                    cmd.Parameters["@Time_Payment_Processed"].Value = newMessagestest.Time_Payment_Processed;

    //                    cmd.Parameters.Add("@Processed_By", SqlDbType.NVarChar, 50);
    //                    cmd.Parameters["@Processed_By"].Value = newMessagestest.Processed_By;

    //                    cmd.Parameters.Add("@Bulk_SMS_No", SqlDbType.NVarChar, 50);
    //                    cmd.Parameters["@Bulk_SMS_No"].Value = newMessagestest.Bulk_SMS_No;

    //                    cmd.Parameters.Add("@SMS_Sent", SqlDbType.NVarChar, 50);
    //                    cmd.Parameters["@SMS_Sent"].Value = newMessagestest.SMS_Sent;

    //                    cmd.Parameters.Add("@Back_Up_SMS", SqlDbType.NVarChar, 50);
    //                    cmd.Parameters["@Back_Up_SMS"].Value = newMessagestest.Back_Up_SMS;

    //                    cmd.Parameters.Add("@Message_Type_ID", SqlDbType.Int);
    //                    cmd.Parameters["@Message_Type_ID"].Value = newMessagestest.Message_Type_ID;

    //                    cmd.Parameters.Add("@E_Mail_Sent", SqlDbType.Int);
    //                    cmd.Parameters["@E_Mail_Sent"].Value = newMessagestest.E_Mail_Sent;

    //                    cmd.Parameters.Add("@Marked_For_E_mail", SqlDbType.Int);
    //                    cmd.Parameters["@Marked_For_E_mail"].Value = newMessagestest.Marked_For_E_mail;

    //                    cmd.Parameters.Add("@Datetime", SqlDbType.DateTime);
    //                    cmd.Parameters["@Datetime"].Value = newMessagestest.Datetime;

    //                    cmd.Parameters.Add("@Reply_Sent", SqlDbType.Int);
    //                    cmd.Parameters["@Reply_Sent"].Value = newMessagestest.Reply_Sent;

    //                    cmd.Parameters.Add("@TotalSmsTrace", SqlDbType.Int);
    //                    cmd.Parameters["@TotalSmsTrace"].Value = newMessagestest.TotalSmsTrace;

    //                    cmd.Parameters.Add("@CDateTime", SqlDbType.DateTime);
    //                    cmd.Parameters["@CDateTime"].Value = newMessagestest.CDateTime;

    //                    cmd.Parameters.Add("@Sender", SqlDbType.VarChar, 120);
    //                    cmd.Parameters["@Sender"].Value = newMessagestest.Sender;

    //                    cmd.Parameters.Add("@ID", SqlDbType.Int);
    //                    cmd.Parameters["@ID"].Value = newMessagestest.ID;

    //                    int result = (int)cmd.ExecuteNonQuery();
    //                    cmd.Dispose();
    //                    if (result > 0)
    //                    { rtVal = true; }
    //                    else
    //                    { rtVal = false; }
    //                }
    //                mConn.Close();
    //            }
    //        }
    //        catch (Exception ex) { return false; }
    //        return rtVal;
    //    }

        public bool DeleteRecord(int ID)
        {
            bool rtVal = false;
            try
            {
                using (SqlConnection mConn = new SqlConnection(CONNECT.conStr))
                {
                    mConn.Open();
                    using (SqlCommand cmd = mConn.CreateCommand())
                    {
                        string stringSQL = "DELETE FROM [Messages2] WHERE (1=1) AND([ID]=@ID);";
                        cmd.CommandText = stringSQL;

                        cmd.Parameters.Add("@ID", SqlDbType.Int);
                        cmd.Parameters["@ID"].Value = ID;

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

