using System;
//using System.Windows.Forms;
using System.Collections;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataSyncService
{   

    public static class CommonFunctions
    {
        public static int InsertIntoMessages(string spID, string serviceID, int direction, string SenderAddress, string ReceiverAddress, string Correlator, string Body, DateTime smsdate, string StatusDetails, string UserSender)
        {
            int rval = -1;
            try
            {
                Message msg = new Message();

                msg.Direction = direction;
                msg.Type = 1;
                msg.Status = 1;
                msg.StatusDetails = 100;
                msg.ToAddress = ReceiverAddress.Trim().Replace("tel:","");
                msg.Body = Body;
                msg.serviceID = long.Parse(serviceID);// msg.ChannelID = long.Parse(serviceID);
                msg.spID = long.Parse(spID);
                msg.FromAddress = SenderAddress.Replace("tel:","");
                msg.SMS_Date = smsdate;
                msg.Correlator = int.Parse(Correlator);

                msg.ScheduledTimeSecs = Convert.ToInt32((smsdate - new DateTime(1970, 01, 01)).TotalSeconds);
                msg.LastUpdateSecs = Convert.ToInt32((smsdate - new DateTime(1970, 01, 01)).TotalSeconds);

                msg.Sender = SenderAddress;

                bool r = msg.Add();


                //using (SqlConnection Conn = new SqlConnection(CONNECT.conStr))
                //{
                //    Conn.Open();
                //    string sQl = "INSERT INTO [Messages2]";
                //    sQl += "  (Direction, Type, Status, ToAddress,Body,ChannelID,StatusDetails,BillingID,FromAddress,[SMS Date],[CustomField1],[Message Type ID],[Sender])";
                //    sQl += "  VALUES (" + direction.ToString() + ", 1, 1, '" + CommonFunctions.ValidateEntry(ReceiverAddress.Trim()) + "','" + CommonFunctions.ValidateEntry(Body) + "'," + CommonFunctions.ValidateEntry(serviceID) + "," + ValidateEntry(StatusDetails) + "";
                //    sQl += "  ,'" + CommonFunctions.ValidateEntry(spID) + "','" + CommonFunctions.ValidateEntry(SenderAddress) + "','" + smsdate.ToString("yyyyMMMdd HHmmss") + "','" + Correlator + "',4,'" + UserSender.Trim() + "')";
                //    using (SqlCommand cmd = new SqlCommand(sQl, Conn))
                //    {
                //        cmd.CommandTimeout = 0;
                //        rval = cmd.ExecuteNonQuery();
                //    }
                //    Conn.Close();
                //}
            }
            catch (Exception e)
            {
            }
            return rval;
        }


        internal static int UpdateMessage(string statusDetail, string deliveryStatus, string correlator, string recipient)
        {
            int rval = -1;
            try
            {
                using (SqlConnection Conn = new SqlConnection(CONNECT.conStr))
                {
                    Conn.Open();

                    string sQl = "UPDATE Messages.dbo.Messagestest SET [StatusDetail]=" + statusDetail + ", [Trace]='" + deliveryStatus + "'";
                    sQl += " WHERE (1=1) AND ([Direction]=2)AND([CustomField1]='" + correlator + "')AND([ToAddress] like '" + recipient + "')";

                    using (SqlCommand cmd = new SqlCommand(sQl, Conn))
                    {
                        cmd.CommandTimeout = 0;
                        rval = cmd.ExecuteNonQuery();
                    }

                    Conn.Close();
                }
            }
            catch (Exception e)
            {
            }
            return rval;
        }

        internal static void LogActivityToDB(string activity)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(CONNECT.conStr))
                {
                    Conn.Open();

                    using (SqlCommand cmd = Conn.CreateCommand())// new SqlCommand(sQl, Conn))
                    {
                        string sQl = "INSERT INTO ACTIVITYLOG([Activity])VALUES(@Activity)";
                        cmd.CommandText = sQl;

                        cmd.Parameters.Add("@Activity", SqlDbType.NText);
                        cmd.Parameters["@Activity"].Value = activity;

                        cmd.CommandTimeout = 0;
                        int rval = cmd.ExecuteNonQuery();
                    }

                    Conn.Close();
                }
            }
            catch (Exception e)
            {
            }
        }

        public static void LogActivity(string activity)
        {
            //Console.WriteLine ( string.Format("{0:dd-MMM-yyyy HH:mm:ss}", DateTime.Now) + " > " + activity);
            //return;
            //////remove previous u lines


            FileStream fsActivity = null;
            StreamWriter sw = null;

            //string ActivityFile = Application.StartupPath + "//ActivityLog.txt";
            string ActivityFile = @"D:\ActivityLog.txt";
            try
            {
                if (File.Exists(ActivityFile))
                {
                    fsActivity = new FileStream(ActivityFile, FileMode.Append, FileAccess.Write);
                    sw = new StreamWriter(fsActivity);
                    //sw.WriteLine(Environment.NewLine + "------------------------------" + Environment.NewLine);
                    //sw.WriteLine(Process.GetCurrentProcess().ProcessName + " : " + activity);
                    sw.WriteLine(string.Format("{0:dd-MMM-yyyy HH:mm:ss}", DateTime.Now) + " > " + activity);
                }
                else
                {
                    fsActivity = new FileStream(ActivityFile, FileMode.Create, FileAccess.Write);
                    sw = new StreamWriter(fsActivity);
                    //sw.WriteLine(Process.GetCurrentProcess().ProcessName + " : " + activity);
                    sw.WriteLine(string.Format("{0:dd-MMM-yyyy HH:mm:ss}", DateTime.Now) + " > " + activity);
                }
                sw.Flush();
            }
            catch (Exception exc)
            {
                //MessageBox.Show(exc.Message, "Error In Logging", MessageBoxButtons.OK, MessageBoxIcon.Error);
                exc.Data.Clear();
            }
            finally
            {
                sw.Close();
                fsActivity.Close();
                sw.Dispose();
                fsActivity.Dispose();
            }
        }
        
        public static string ValidateDate(string dateString)
        {
            try
            {
                if (dateString.Trim().Length > 0)
                {
                    dateString = CommonFunctions.FormatDate(Convert.ToDateTime(dateString));

                    if (Convert.ToDateTime(dateString) < Convert.ToDateTime("1900-01-01"))
                        dateString = Convert.ToDateTime("1900-01-01").ToShortDateString();
                }
                else
                    dateString = Convert.ToDateTime("1900-01-01").ToShortDateString();
            }
            catch (Exception ex)
            {
                CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
                dateString = Convert.ToDateTime("1900-01-01").ToShortDateString();
            }
            return dateString;
        }

        /// <summary>
        /// Trim all sql illegal characters
        /// </summary>
        /// <param name="Entry"></param>
        /// <returns></returns>
        public static string ValidateEntry(string Entry)
        {
            string r = Entry;
            try
            {
                //if (Entry.Length > 250) Entry = Entry.Substring(1, 250);

                string s = "'";//sql illegal entry characters

                Entry = Entry.Trim();

                foreach (char c in s.ToCharArray())
                    Entry = Entry.Replace(c.ToString(), "'" + c.ToString());

                r = Entry;
            }
            catch (Exception ex)
            {
                //CommonFunctions.SendErrorToDeveloper(ex);
                CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
            }
            return r;
        }

        /// <summary>
        /// Alerts the developers that an error occured,
        /// Includes the source and description of the error
        /// Hence, the developer should come, prepared for changes/maintenance
        /// </summary>
        /// <param name="ex"></param>
        public static void SendErrorToDeveloper(Exception ex)
        {
            try
            {
                if (ex.Message.ToLower().Contains("aborted"))
                {
                    ex.Data.Clear();

                    return;
                }

                if (1 == 1) { return; }//added to avoid email floods : need to reroute to local log file and send once 
                                
                //string s = "<BR>An error occured for Total Kenya Limited - Reports Generator";
                //s += "<P>ERROR DETAILS:";
                //s += "<HR><P>Error Message: " + ex.Message;
                ////s += "<BR>Inner Exception: " + ex.InnerException.Message;
                //s += "<HR><P>Error Source: " + ex.Source;
                //s += "<HR><P>Stack Trace: " + ex.StackTrace;
                //s += "<HR><P>Target Site - Name: " + ex.TargetSite.Name;
                //s += "<HR><P>Target Site - Module: " + ex.TargetSite.Module.FullyQualifiedName;

                //CEmail eml = new CEmail();
                //eml.Body = s;
                //eml.From = "no-reply@total.co.ke";
                //eml.Subject = "Total Kenya Limited - ISSUES IN THE Reports Generator";

                //string[] to = new string[1];
                //to[0] = "onyangofred@ymail.com";

                //eml.To = to;
                //eml.SendMail();

            }
            catch (Exception ex2)
            {
                ex2.Data.Clear();
            }
        }

        public static string FormatNumber(double Number2Format)
        {
            return FormatNumber(Number2Format.ToString());
        }

        public static string FormatNumber(string Number2Format)
        {
            if (Number2Format.Contains("(") || Number2Format.Contains(")"))
                Number2Format = Number2Format.Substring(1, Number2Format.Length - 2);

            double d = Convert.ToDouble(Number2Format);//remove non-numeric characters

            string s = d.ToString();//revert to string

            string wholeNumber = "";
            string decimalPoint = "";

            bool negativeNumber = Number2Format.ToString().Contains("-");

            if (negativeNumber)
                s = s.Substring(1);

            try
            {
                int i, j, k;

                if (s.Contains(".") == false)
                    s += ".00";

                i = s.IndexOf(".");

                decimalPoint = s.Substring(i + 1);

                if (decimalPoint.Length == 1)
                    decimalPoint = decimalPoint + "0";
                else if (decimalPoint.Length > 2)
                    decimalPoint = decimalPoint.Substring(0, 2);

                k = 0;
                for (j = (i - 1); j >= 0; j--)
                {
                    wholeNumber = s.Substring(j, 1) + wholeNumber;

                    k++;
                    if (k == 3)
                    {
                        k = 0;

                        if (j > 0) wholeNumber = "," + wholeNumber;
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
            }

            if (negativeNumber) s = "(" + wholeNumber + "." + decimalPoint + ")";
            else s = wholeNumber + "." + decimalPoint;

            return s;
        }

        public static string FormatNumberInteger(double NumberFormat)
        {
            string Number2Format = NumberFormat.ToString();

            if (Number2Format.Contains("(") || Number2Format.Contains(")"))
                Number2Format = Number2Format.Substring(1, Number2Format.Length - 2);

            double d = Convert.ToDouble(Number2Format);//remove non-numeric characters

            string s = d.ToString();//revert to string

            string wholeNumber = "";
            string decimalPoint = "";

            bool negativeNumber = Number2Format.ToString().Contains("-");

            if (negativeNumber)
                s = s.Substring(1);

            try
            {
                int i, j, k;

                if (s.Contains(".") == false)
                    s += ".00";

                i = s.IndexOf(".");

                decimalPoint = s.Substring(i + 1);

                if (decimalPoint.Length == 1)
                    decimalPoint = decimalPoint + "0";
                else if (decimalPoint.Length > 2)
                    decimalPoint = decimalPoint.Substring(0, 2);

                k = 0;
                for (j = (i - 1); j >= 0; j--)
                {
                    wholeNumber = s.Substring(j, 1) + wholeNumber;

                    k++;
                    if (k == 3)
                    {
                        k = 0;

                        if (j > 0) wholeNumber = "," + wholeNumber;
                    }
                }
            }
            catch (Exception ex)
            {
                SendErrorToDeveloper(ex);
                CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
            }

            if (negativeNumber) s = "(" + wholeNumber + ")";
            else s = wholeNumber;

            return s;
        }

        public static string ToTimeStamp(DateTime Date2Format)
        {
            string s = "";

            try
            {
                string y, m, d, hr, mn, sc;

                y = Date2Format.Year.ToString();

                m = Date2Format.Month.ToString();
                if (m.Length == 1) m = "0" + m;

                d = Date2Format.Day.ToString();
                if (d.Length == 1) d = "0" + d;

                hr = Date2Format.Hour.ToString();
                if (hr.Length == 1) hr = "0" + hr;

                mn = Date2Format.Minute.ToString();
                if (mn.Length == 1) mn = "0" + mn;

                sc = Date2Format.Second.ToString();
                if (sc.Length == 1) sc = "0" + sc;

                s = d + "-" + m + "-" + y + " " + hr + "_" + mn + "_" + sc;
            }
            catch (Exception ex)
            {
                SendErrorToDeveloper(ex);
                CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
            }

            return s;
        }

        public static string FormatDate(DateTime Date2Format)
        {
            string s = "";

            try
            {
                string y, m, d, hr, mn, sc;

                y = Date2Format.Year.ToString();

                m = Date2Format.Month.ToString();
                if (m.Length == 1) m = "0" + m;

                d = Date2Format.Day.ToString();
                if (d.Length == 1) d = "0" + d;

                hr = Date2Format.Hour.ToString();
                if (hr.Length == 1) hr = "0" + hr;

                mn = Date2Format.Minute.ToString();
                if (mn.Length == 1) mn = "0" + mn;

                sc = Date2Format.Second.ToString();
                if (sc.Length == 1) sc = "0" + sc;

                s = y + "-" + m + "-" + d + " " + hr + ":" + mn + ":" + sc;
            }
            catch (Exception ex)
            {
                SendErrorToDeveloper(ex);
                CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
            }

            return s;
        }

        public static string FormatDate(DateTime Date2Format, bool excludeTime)
        {
            string s = "";

            try
            {
                string y, m, d;

                y = Date2Format.Year.ToString();

                m = Date2Format.Month.ToString();
                if (m.Length == 1) m = "0" + m;

                d = Date2Format.Day.ToString();
                if (d.Length == 1) d = "0" + d;

                if (excludeTime)
                    s = y + "-" + m + "-" + d;
                else
                    s = FormatDate(Date2Format);
            }
            catch (Exception ex)
            {
                SendErrorToDeveloper(ex);
                CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
            }

            return s;
        }

        public static string FormatDate(object Date2Format)
        {
            string s = "";

            try
            {
                s = FormatDate((DateTime)Date2Format);
            }
            catch (Exception ex)
            {
                SendErrorToDeveloper(ex);
                CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
            }

            return s;
        }

        public static string FormatDate(object Date2Format, bool excludeTime)
        {
            string s = "";

            try
            {
                s = FormatDate((DateTime)Date2Format, true);
            }
            catch (Exception ex)
            {
                SendErrorToDeveloper(ex);
                CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
            }

            return s;
        }

        public static int FormatDateDifference(string Number2Format)
        {
            int str = 0;

            try
            {
                if (Number2Format.Contains("."))
                    str = Convert.ToInt32(Number2Format.Substring(0, (Number2Format.IndexOf("."))));
            }
            catch (Exception ex)
            {
                SendErrorToDeveloper(ex);
                CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
            }
            //str = str * (1000 * 60 * 60 * 24);//convert to days (default is milli-seconds).

            return str;
        }
        
        public static bool CreateFolder(string strPath, string folderName)
        {
            try
            {
                Directory.CreateDirectory(strPath + "\\" + folderName);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create Folder: " + ex.Source + ": " + ex.Message);
                ex.Data.Clear();
                return false;
            }
        }

        /// <summary>
        /// where reports are temporarily stored before being e-mailed
        /// </summary>
        //public static string ReportsTempPath
        //{
        //    get
        //    {
        //        string s = "";

        //        try
        //        {
        //            SQL_DB.SqlDataReader dr = new CONNECTSqlServer().ReadDB(
        //                "SELECT [settingvalue]" +
        //                " FROM tbl_A_Setup where Code = 'ReportsTempPath';"
        //                );

        //            if (dr.HasRows)
        //                while (dr.Read())
        //                    s = dr["Setting Value"].ToString();

        //            dr.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            //CommonFunctions.SendErrorToDeveloper(ex);
        //            CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
        //        }
        //        return s;
        //    }

        //    set
        //    {
        //        if (CommonFunctions.ReportsTempPath.Trim().Length == 0)
        //            new CONNECTSqlServer().ReadDB(
        //                "insert into tbl_A_Setup(Code,[settingvalue])values(" +
        //                " 'ReportsTempPath','" + CommonFunctions.ValidateEntry(value) + "'" +
        //                " );"
        //                );
        //        else
        //            new CONNECTSqlServer().ReadDB(
        //                "update tbl_A_Setup set [settingvalue] = '" + CommonFunctions.ValidateEntry(value) + "'" +
        //                " where Code = 'ReportsTempPath';"
        //                );

        //    }
        //}

        /// <summary>
        /// when the data was last imported from access to sql
        /// </summary>
        //public static string LastUpdateDateTime
        //{
        //    get
        //    {
        //        string s = "";

        //        try
        //        {
        //            SQL_DB.SqlDataReader dr = new CONNECTSqlServer().ReadDB(
        //                "SELECT [settingvalue]" +
        //                " FROM tbl_A_Setup where settingcode = 'LastUpdateDateTime';"
        //                );

        //            if (dr.HasRows)
        //                while (dr.Read())
        //                    s = dr["settingvalue"].ToString();

        //            dr.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            ex.Data.Clear();
        //        }
        //        return s;
        //    }

        //    set
        //    {
        //        if (CommonFunctions.ReportsTempPath.Trim().Length == 0)
        //            new CONNECTSqlServer().ReadDB(
        //                "insert into tbl_A_Setup(settingcode,[settingvalue])values(" +
        //                " 'LastUpdateDateTime','" + CommonFunctions.ValidateEntry(value) + "'" +
        //                " );"
        //                );
        //        else
        //            new CONNECTSqlServer().ReadDB(
        //                "update tbl_A_Setup set [settingvalue] = '" + CommonFunctions.ValidateEntry(value) + "'" +
        //                " where settingcode = 'LastUpdateDateTime';"
        //                );

        //    }
        //}

        //public static string SmtpServerID
        //{
        //    get
        //    {
        //        string s = "";

        //        try
        //        {
        //            SQL_DB.SqlDataReader dr = new CONNECTSqlServer().ReadDB(
        //                "SELECT [settingvalue]" +
        //                " FROM tbl_A_Setup where Code = 'SmtpServerID';"
        //                );

        //            if (dr.HasRows)
        //                while (dr.Read())
        //                    s = dr["Setting Value"].ToString();

        //            dr.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
        //        }
        //        return s;
        //    }

        //    set
        //    {
        //        if (CommonFunctions.SmtpServerID.Trim().Length == 0)
        //            new CONNECTSqlServer().ReadDB(
        //                "insert into tbl_A_Setup(Code,[settingvalue])values(" +
        //                " 'SmtpServerId','" + CommonFunctions.ValidateEntry(value) + "'" +
        //                " );"
        //                );
        //        else
        //            new CONNECTSqlServer().ReadDB(
        //                "update tbl_A_Setup set [settingvalue] = '" + CommonFunctions.ValidateEntry(value) + "'" +
        //                " where Code = 'SmtpServerID';"
        //                );

        //    }
        //}

        /// <summary>
        /// The Database update time 
        /// </summary>
        //public static string DbUpdateTime
        //{
        //    get
        //    {
        //        string s = "";

        //        try
        //        {
        //            SQL_DB.SqlDataReader dr = new CONNECTSqlServer().ReadDB(
        //                "SELECT [settingvalue]" +
        //                " FROM tbl_A_Setup where settingcode = 'DbUpdateTime';"
        //                );

        //            if (dr.HasRows)
        //                while (dr.Read())
        //                    s = dr["settingvalue"].ToString();

        //            dr.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            ex.Data.Clear();
        //        }
        //        return s;
        //    }

        //    set
        //    {
        //        if (CommonFunctions.DbUpdateTime.Trim().Length == 0)
        //            new CONNECTSqlServer().ReadDB(
        //                "insert into tbl_A_Setup(Code,[settingvalue])values(" +
        //                " 'DbUpdateTime','" + CommonFunctions.ValidateEntry(value) + "'" +
        //                " );"
        //                );
        //        else
        //            new CONNECTSqlServer().ReadDB(
        //                "update tbl_A_Setup set [settingvalue] = '" + CommonFunctions.ValidateEntry(value) + "'" +
        //                " where Code = 'DbUpdateTime';"
        //                );

        //    }
        //}

        /// <summary>
        /// The Email origin account  
        /// </summary>
        //public static string EmailOriginAccount
        //{
        //    get
        //    {
        //        string s = "";

        //        try
        //        {
        //            SQL_DB.SqlDataReader dr = new CONNECTSqlServer().ReadDB(
        //                "SELECT [settingvalue] FROM tbl_A_Setup where settingcode = 'EmailOriginAccount';"
        //                );

        //            if (dr.HasRows)
        //                while (dr.Read())
        //                    s = dr["settingvalue"].ToString();

        //            dr.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
        //        }
        //        return s;
        //    }

        //    set
        //    {
        //        if (CommonFunctions.EmailOriginAccount.Trim().Length == 0)
        //            new CONNECTSqlServer().ReadDB(
        //                "insert into tbl_A_Setup(settingcode,[settingvalue])values(" +
        //                " 'EmailOriginAccount','" + CommonFunctions.ValidateEntry(value) + "'" +
        //                " );"
        //                );
        //        else
        //            new CONNECTSqlServer().ReadDB(
        //                "update tbl_A_Setup set [settingvalue] = '" + CommonFunctions.ValidateEntry(value) + "'" +
        //                " where Code = 'EmailOriginAccount';"
        //                );

        //    }
        //}

        /// <summary>
        /// The Email origin account  
        /// </summary>
        //public static string EmailID
        //{
        //    get
        //    {
        //        string s = "";

        //        try
        //        {
        //            SQL_DB.SqlDataReader dr = new CONNECTSqlServer().ReadDB(
        //                "SELECT [settingvalue]" +
        //                " FROM tbl_A_Setup where Code = 'EmailOriginAccount';"
        //                );

        //            if (dr.HasRows)
        //                while (dr.Read())
        //                    s = dr["Setting Value"].ToString().Substring(0, dr["Setting Value"].ToString().IndexOf("@"));

        //            dr.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
        //        }
        //        return s;
        //    }

        //    set
        //    {
        //        ;
        //        //if (CommonFunctions.EmailOriginAccount.Trim().Length == 0)
        //        //    new cConnect2().ReadDB(
        //        //        "insert into tbl_A_Setup(Code,[settingvalue])values(" +
        //        //        " 'EmailOriginAccount','" + CommonFunctions.ValidateEntry(value) + "'" +
        //        //        " );"
        //        //        );
        //        //else
        //        //    new cConnect2().ReadDB(
        //        //        "update tbl_A_Setup set [settingvalue] = '" + CommonFunctions.ValidateEntry(value) + "'" +
        //        //        " where Code = 'EmailOriginAccount';"
        //        //        );

        //    }
        //}

        /// <summary>
        /// The Email origin account pwd
        /// </summary>
        //public static string EmailOriginAccAuth
        //{
        //    get
        //    {
        //        string s = "";

        //        try
        //        {
        //            SQL_DB.SqlDataReader dr = new CONNECTSqlServer().ReadDB(
        //                "SELECT [settingvalue]" +
        //                " FROM tbl_A_Setup where Code = 'EmailOriginAccAuth';"
        //                );

        //            if (dr.HasRows)
        //                while (dr.Read())
        //                    s = dr["Setting Value"].ToString();

        //            dr.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            CommonFunctions.SendErrorToDeveloper(ex); ex.Data.Clear();
        //        }
        //        return s;
        //    }

        //    set
        //    {
        //        if (CommonFunctions.EmailOriginAccAuth.Trim().Length == 0)
        //            new CONNECTSqlServer().ReadDB(
        //                "insert into tbl_A_Setup(Code,[settingvalue])values(" +
        //                " 'EmailOriginAccAuth','" + CommonFunctions.ValidateEntry(value) + "'" +
        //                " );"
        //                );
        //        else
        //            new CONNECTSqlServer().ReadDB(
        //                "update tbl_A_Setup set [settingvalue] = '" + CommonFunctions.ValidateEntry(value) + "'" +
        //                " where Code = 'EmailOriginAccAuth';"
        //                );

        //    }
        //}

        //public static string SetupsGetAttribute(string attributeName)
        //{
        //    string s = "";

        //    try
        //    {
        //        SQL_DB.SqlDataReader dr = new CONNECTSqlServer().ReadDB(
        //            " SELECT [settingvalue]FROM tbl_A_Setup where settingcode = '" + attributeName.Trim() + "';");

        //        if (dr.HasRows)
        //            while (dr.Read())
        //                s = dr["settingvalue"].ToString();

        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        CommonFunctions.SendErrorToDeveloper(ex);
        //        ex.Data.Clear();
        //    }
        //    return s;
        //}


        //public static void SetupsSetAttribute(string attributeName, string attributeVal)
        //{
        //    if (CommonFunctions.SetupsGetAttribute(attributeName).Length.Equals(0))
        //        new CONNECTSqlServer().ReadDB(
        //            "insert into tbl_A_Setup(settingcode,[settingvalue])values(" +
        //            " '" + attributeName + "','" + CommonFunctions.ValidateEntry(attributeVal) + "'" +
        //            " );" );
        //    else
        //        new CONNECTSqlServer().ReadDB(
        //            " update tbl_A_Setup set [settingvalue] = '" + CommonFunctions.ValidateEntry(attributeVal) + "'" +
        //            " where settingcode = '" + attributeName + "';" );
        //}

        //public static CTableLogOnInfos GetTableLogsInfo()
        //{
        //    CTableLogOnInfos CTLIFOS = null;
        //    try
        //    {
        //        CTLIFOS = new CTableLogOnInfos();

        //        CTLIFOS.Server = SetupsGetAttribute("SQLDBServer");
        //        CTLIFOS.Database = SetupsGetAttribute("SQLDatabase");
        //        CTLIFOS.User = SetupsGetAttribute("SQLDBUser");
        //        CTLIFOS.Pass = SetupsGetAttribute("SQLDBpassword");

        //        string strIntSec = CommonFunctions.SetupsGetAttribute("SQLIntegratedSecurity");
        //        strIntSec = (strIntSec == "" ? "False" : strIntSec);
        //        bool blnIntSec = bool.Parse(strIntSec);
        //        CTLIFOS.IntergrateSecurity = blnIntSec;
        //    }
        //    catch (Exception ex) { Console.WriteLine(ex.Message); }

        //    return CTLIFOS;
        //}

        public static int GetDayOfWeek(DayOfWeek dow)
        {
            int i = 0;
            switch (dow.ToString())
            {
                case "Monday":
                    i = 1;
                    break;
                case "Tuesday":
                    i = 2;
                    break;
                case "Wednesday":
                    i = 3;
                    break;
                case "Thursday":
                    i = 4;
                    break;
                case "Friday":
                    i = 5;
                    break;
                case "Saturday":
                    i = 6;
                    break;
                case "Sunday":
                    i = 7;
                    break;
            }
            return i;
        }

        public static DateTime GetDateOfDayOfCurWeek(int intSchDoW)
        {
            DateTime retDate = DateTime.Now;
            DateTime dtCur = DateTime.Now;

            retDate = dtCur.AddDays(-1 * Convert.ToInt16(intSchDoW)+1);

            return retDate;
        }

        //public static void ShowError(string s)
        //{
        //    MessageBox.Show(s);
        //}


        //internal static void RollbackSetupAttribute(DateTime lastUpdateDate)
        //{
        //    SetupsSetAttribute("DbCurrentDateUpdateStatus", "false");
        //    SetupsSetAttribute("LastUpdateDate", string.Format("{0:dd-MMM-yyyy HH:mm:ss}", lastUpdateDate));
        //    SetupsSetAttribute("PrevDBUpdateStatus", "false");
        //}

        public static void LogEntryOnFile(string clientRequest)
        {
            //D:\SDP\Datasync logs

            //string LogFileName = @"D:\SDP\Logs\Datasync\" + string.Format("{0}{1}{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) + ".txt";
            string LogFileName = @"C:\Mobile\Logs\Sms\" + string.Format("{0}{1}{2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) + ".txt";

            File.AppendAllText(LogFileName, clientRequest + "\n");
        }
    }
}

