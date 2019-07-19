using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Linq;
//using System.Threading.Tasks;
using System.Xml;
using HIMS;
using System.Xml.Serialization;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;

namespace Global.HIMS
{
    public static class CommonUtilities
    {
        //public static string ConnectionString = @"Data Source=SERVER\SQL2008;Initial Catalog=Sacco;MultipleActiveResultSets=true;User ID=oldmutual;Password=oldmutual;";
        public static string ConnectionString = @"Data Source=.\;Initial Catalog=Mobile;MultipleActiveResultSets=true;User ID=paul;Password=;";
        public static string ConnectionStringMessages = @"Data Source=.\;Initial Catalog=Mobile;MultipleActiveResultSets=true;User ID=paul;Password=;";
        
        #region check_link_status
        public static int smsbalance() {
            int bal = 0;
            return bal;
        }


        public static BulkSm[] Getsms(string client) {
            List<BulkSm> s = new List<BulkSm>();
            using (var db = new PortalEntities(settings.Connection()))
            {
                s = db.BulkSms.Where(o => o.Client == client).OrderByDescending(o=> o.Id).ToList();

            }
            return s.ToArray();
        }
        public static string check_link_status(string MyGroup, string FildName)
        {

            string field_val = "1";

            //using (SqlConnection mConn = new SqlConnection(CommonUtilities.ConnectionString))
            //{

            //    string A = String.Format("SELECT [" + FildName + "] FROM [Access] WHERE [User Type]=" + "'" + MyGroup + "'" + "");
            //    SqlCommand cmds = new SqlCommand() { CommandType = CommandType.Text, Connection = mConn, CommandText = A };
            //    mConn.Open();
            //    using (SqlDataReader rdr = cmds.ExecuteReader())
            //    {
            //        if (rdr.HasRows)
            //        {
            //            rdr.Read();
            //            field_val = rdr[0].ToString();
            //        }
            //    }
            //    mConn.Close();
            //}

            return field_val;

        }
        #endregion

        public static string getListingPerPage()
        {

            string returnfieldvalue = "15";

            return returnfieldvalue;
        }

        #region Send SMS

        public static Boolean sendSms_(string phone, string text, string corporateno, string type, string BatchNo)
        {
            int id = 0;
            Boolean Y = false;

            try
            {

                using (SqlConnection conn = new SqlConnection(CommonUtilities.ConnectionStringMessages))
                {

                    conn.Open();

                    int Direction = 2;
                    int Type = 1;
                    string ChannelID = string.Empty;
                    string BillingID = string.Empty;
                    int Status = 1;
                    int StatusDetails = 200;
                    int CustomField1 = 0;
                    string FromAddress = string.Empty;
                    string ToAddress = string.Empty;
                    string Body = string.Empty;
                    string spID = string.Empty;
                    string serviceID = string.Empty;
                    int correlator = 0;
                    string Corporate_No = string.Empty;
                    int smsId = 0;
                    string Message = string.Empty;
                    DateTime Datetime;


                    SqlCommand cmdRt = new SqlCommand();
                    string SQL_Pin = "SELECT * FROM [tblService] WHERE [Corporate] = @corporateno";
                    cmdRt.CommandText = SQL_Pin;
                    cmdRt.Connection = conn;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@corporateno", corporateno);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            Direction = 2;
                            Type = 1;
                            ChannelID = dr["ServiceID"].ToString();
                            BillingID = dr["spID"].ToString();
                            Status = 1;
                            StatusDetails = 200;
                            CustomField1 = Convert.ToInt32(dr["correlator_last_used"].ToString());
                            FromAddress = dr["AccessNo"].ToString();
                            ToAddress = phone.ToString().Trim();
                            Body = text;
                            spID = dr["spID"].ToString();
                            serviceID = dr["ServiceID"].ToString();
                            correlator = Convert.ToInt32(dr["correlator_last_used"].ToString());
                            Corporate_No = corporateno;
                            Datetime = DateTime.Now;

                        }
                        else
                        {
                            SqlCommand cmdRt2 = new SqlCommand();
                            string SQL_Pin2 = "SELECT * FROM [tblService] WHERE [Corporate] = @corporateno";
                            cmdRt2.CommandText = SQL_Pin2;
                            cmdRt2.Connection = conn;
                            cmdRt2.CommandType = CommandType.Text;
                            cmdRt2.Parameters.AddWithValue("@corporateno", "100");
                            using (SqlDataReader dr_ = cmdRt2.ExecuteReader())
                            {
                                if (dr_.HasRows)
                                {
                                    dr_.Read();
                                    dr.Read();
                                    Direction = 2;
                                    Type = 1;
                                    ChannelID = dr_["ServiceID"].ToString();
                                    BillingID = dr_["spID"].ToString();
                                    Status = 1;
                                    StatusDetails = 200;
                                    CustomField1 = Convert.ToInt32(dr_["correlator_last_used"].ToString());
                                    FromAddress = dr_["AccessNo"].ToString();
                                    ToAddress = phone.ToString().Trim();
                                    Body = text;
                                    spID = dr_["spID"].ToString();
                                    serviceID = dr_["ServiceID"].ToString();
                                    correlator = Convert.ToInt32(dr_["correlator_last_used"].ToString());
                                    Corporate_No = corporateno;
                                    Datetime = DateTime.Now;
                                }
                            }
                        }
                    }



                    #region ==================== PIN RESET ==========================

                    if (type == "Pin Reset")
                    {
                        #region Reset PIN

                        int NextPinNo = 1000;

                        using (SqlConnection mConn = new SqlConnection(CommonUtilities.ConnectionString))
                        {
                            mConn.Open();

                            SqlCommand cmd2_ = new SqlCommand(@"SELECT [Next Pin No] FROM  [Source Information] WHERE [Corporate No]=@Corporate;", mConn);
                            cmd2_.CommandTimeout = 240;
                            cmd2_.CommandType = CommandType.Text;
                            cmd2_.Parameters.AddWithValue("@Corporate", Corporate_No);
                            using (SqlDataReader dr_ = cmd2_.ExecuteReader())
                            {
                                if (dr_.HasRows)
                                {
                                    dr_.Read();
                                    if (string.IsNullOrEmpty(dr_["Next Pin No"].ToString()) == false)
                                        NextPinNo = Convert.ToInt32(dr_["Next Pin No"].ToString()) + 1;

                                }
                                else
                                {
                                    NextPinNo = NextPinNo + 1;
                                }


                                Body = "Your pin was reset successfully. Your new PIN No is " + NextPinNo + ". Dial *346# to change the PIN No.";

                                #region Update Source Information

                                SqlCommand cmd2_1 = new SqlCommand(@"UPDATE [Source Information] SET [Next Pin No]=@NextPinNo WHERE [Corporate No]=@Corporate;", mConn);
                                cmd2_1.CommandTimeout = 240;
                                cmd2_1.CommandType = CommandType.Text;
                                cmd2_1.Parameters.AddWithValue("@Corporate", Corporate_No);
                                cmd2_1.Parameters.AddWithValue("@NextPinNo", NextPinNo);
                                cmd2_1.ExecuteNonQuery();

                                #endregion

                                #region Update Routing Table

                                SqlCommand cmd2_2 = new SqlCommand(@"UPDATE [Routing Table] SET Status=1, [No Pin Attempt]=0 WHERE [Corporate No]=@Corporate AND [Telephone No]=@ToAddress;", mConn);
                                cmd2_2.CommandTimeout = 240;
                                cmd2_2.CommandType = CommandType.Text;
                                cmd2_2.Parameters.AddWithValue("@Corporate", Corporate_No);
                                cmd2_2.Parameters.AddWithValue("@ToAddress", ToAddress);
                                cmd2_2.ExecuteNonQuery();

                                #endregion

                                #region Update New Pin

                                SqlCommand cmd2_3 = new SqlCommand(@"UPDATE [Pin No] SET [PIN No]=@NextPinNo WHERE [Telephone No] =@ToAddress;", mConn);
                                cmd2_3.CommandTimeout = 240;
                                cmd2_3.CommandType = CommandType.Text;
                                cmd2_3.Parameters.AddWithValue("@ToAddress", ToAddress);
                                cmd2_3.Parameters.AddWithValue("@NextPinNo", NextPinNo);
                                cmd2_3.ExecuteNonQuery();

                                #endregion



                                mConn.Close();
                            }

                            #endregion


                        }
                    }
                    #endregion


                    #region Insert SMS

                    if (type == "Pin Reset")
                    {
                        SqlCommand cmd2 = new SqlCommand(@"insert into [Messages2] ([Direction],[Type],[ChannelID],[BillingID],[Status],[StatusDetails],
                        [CustomField1],[FromAddress],[ToAddress],[Body],[spID],[serviceID],[correlator],[Corporate No],[Datetime]) " +
                            "values (@Direction,@Type,@ChannelID,@BillingID,@Status,@StatusDetails," +
                          "  @CustomField1, @FromAddress, @ToAddress, @Body, @spID, @serviceID, @correlator, @Corporate_No, @Datetime);SELECT SCOPE_IDENTITY();", conn);

                        cmd2.CommandTimeout = 240;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Parameters.AddWithValue("@Direction", Direction);
                        cmd2.Parameters.AddWithValue("@Type", Type);
                        cmd2.Parameters.AddWithValue("@ChannelID", ChannelID);
                        cmd2.Parameters.AddWithValue("@BillingID", BillingID);
                        cmd2.Parameters.AddWithValue("@Status", Status);
                        cmd2.Parameters.AddWithValue("@StatusDetails", StatusDetails);
                        cmd2.Parameters.AddWithValue("@CustomField1", CustomField1);
                        cmd2.Parameters.AddWithValue("@FromAddress", FromAddress);
                        cmd2.Parameters.AddWithValue("@ToAddress", ToAddress);
                        cmd2.Parameters.AddWithValue("@Body", Body);
                        cmd2.Parameters.AddWithValue("@spID", spID);
                        cmd2.Parameters.AddWithValue("@serviceID", serviceID);
                        cmd2.Parameters.AddWithValue("@correlator", correlator);
                        cmd2.Parameters.AddWithValue("@Corporate_No", Corporate_No);
                        cmd2.Parameters.AddWithValue("@Datetime", DateTime.Now);
                        id = cmd2.ExecuteNonQuery();
                    }
                    else
                    {

                        SqlCommand cmd2 = new SqlCommand(@"insert into [MessagesBulk] ([Direction],[Type],[ChannelID],[BillingID],[Status],[StatusDetails],
                        [CustomField1],[FromAddress],[ToAddress],[Body],[spID],[serviceID],[correlator],[Corporate No],[Datetime],[From Portal],[Batch No]) " +
                               "values (@Direction,@Type,@ChannelID,@BillingID,@Status,@StatusDetails," +
                             "  @CustomField1, @FromAddress, @ToAddress, @Body, @spID, @serviceID, @correlator, @Corporate_No, @Datetime,1,@BatchNo);SELECT SCOPE_IDENTITY();", conn);
                        cmd2.CommandTimeout = 240;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Parameters.AddWithValue("@Direction", Direction);
                        cmd2.Parameters.AddWithValue("@Type", Type);
                        cmd2.Parameters.AddWithValue("@ChannelID", ChannelID);
                        cmd2.Parameters.AddWithValue("@BillingID", BillingID);
                        cmd2.Parameters.AddWithValue("@Status", Status);
                        cmd2.Parameters.AddWithValue("@StatusDetails", StatusDetails);
                        cmd2.Parameters.AddWithValue("@CustomField1", CustomField1);
                        cmd2.Parameters.AddWithValue("@FromAddress", FromAddress);
                        cmd2.Parameters.AddWithValue("@ToAddress", ToAddress);
                        cmd2.Parameters.AddWithValue("@Body", Body);
                        cmd2.Parameters.AddWithValue("@spID", spID);
                        cmd2.Parameters.AddWithValue("@serviceID", serviceID);
                        cmd2.Parameters.AddWithValue("@correlator", correlator);
                        cmd2.Parameters.AddWithValue("@Corporate_No", Corporate_No);
                        cmd2.Parameters.AddWithValue("@Datetime", DateTime.Now);
                        cmd2.Parameters.AddWithValue("@BatchNo", BatchNo);
                        id = cmd2.ExecuteNonQuery();
                    }

                    #endregion

                    //
                    Y = true;



                    conn.Close();


                }

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return Y;
        }

        #endregion

        #region Float

        public static double GetMpesaFloat(string corporateno)
        {
            int id = 0;
            double Y = 0;

            try
            {

                using (SqlConnection conn = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmdRt = new SqlCommand();
                    string SQL_Pin = "SELECT TOP 1 [MPESA Float Amount] FROM [Mobile Withdrawals] WHERE [Corporate No] = @corporateno AND [MPESA Result Type] IS NOT NULL ORDER BY [Entry No] DESC";
                    cmdRt.CommandText = SQL_Pin;
                    cmdRt.Connection = conn;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@corporateno", corporateno);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            if (string.IsNullOrEmpty(dr["MPESA Float Amount"].ToString()) == false)
                            {
                                Y = Convert.ToDouble(dr["MPESA Float Amount"].ToString());
                            } else
                            {
                                Y = 0;
                            }
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                Y = 0;
            }

            return Y;



        }

        #endregion

        #region Float

        public static double GetMobileSMSFloat(string corporateno)
        {
            int id = 0;
            double Y = 0;

            try
            {

                using (SqlConnection conn = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmdRt = new SqlCommand();
                    //string SQL_Pin = "SELECT TOP 1 [MPESA Float Amount] FROM [Mobile Withdrawals] WHERE [Corporate No] = @corporateno AND [MPESA Result Type] IS NOT NULL ORDER BY [Entry No] DESC";
                    string SQL_Pin = "select " +
                                    "(SELECT ISNULL(SUM(SmsCount),0)TotalSmsCount FROM Sacco.dbo.[MSacco TopUp] where (CorporateNo=@corporateno)) - " +
                                    "(select isnull(sum([Count]),0)TotalNoofsms from Sacco.dbo.[Msacco Transactions] where (CorporateNo=@corporateno)) SmsBalance";
                    cmdRt.CommandText = SQL_Pin;
                    cmdRt.Connection = conn;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@corporateno", corporateno);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            if (string.IsNullOrEmpty(dr["SmsBalance"].ToString()) == false)
                            {
                                Y = Convert.ToDouble(dr["SmsBalance"].ToString());
                            }
                            else
                            {
                                Y = 0;
                            }
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                Y = 0;
            }

            return Y;



        }

        #endregion

        #region Float

        public static double GetBulkSMSFloat(string corporateno)
        {
            int id = 0;
            double Y = 0;

            try
            {

                using (SqlConnection conn = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmdRt = new SqlCommand();

                    string SQL_Pin = "SELECT (SELECT ISNULL(SUM(SmsCount),0)TotalSmsCount FROM Sacco.dbo.[Sacco Bulksms Topup] WHERE (Sacco=@corporateno) )" +
                                    "-" +
                                    "(SELECT ISNULL(SUM(Noofsms),0)TotalNoofsms FROM Sacco.dbo.BulkSms WHERE (Corporate=@corporateno)) SmsBalance";
                    cmdRt.CommandText = SQL_Pin;
                    cmdRt.Connection = conn;
                    cmdRt.CommandType = CommandType.Text;
                    cmdRt.Parameters.AddWithValue("@corporateno", corporateno);
                    using (SqlDataReader dr = cmdRt.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            if (string.IsNullOrEmpty(dr["SmsBalance"].ToString()) == false)
                            {
                                Y = Convert.ToDouble(dr["SmsBalance"].ToString());
                            }
                            else
                            {
                                Y = 0;
                            }
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                Y = 0;
            }

            return Y;



        }

        #endregion

        #region Cancel Pending Loans

        public static Boolean CancelPendingLoans(string EntryNo, string SessionId, Boolean GuarantorsLoan) {
            Boolean respose = false;

            try
            {

                using (SqlConnection conn = new SqlConnection(CommonUtilities.ConnectionString))
                {
                    conn.Open();

                    if (GuarantorsLoan)
                    {
                        SqlCommand cmdRt = new SqlCommand();
                        string SQL_Pin = "SELECT * FROM [Guarantors] WHERE [Session] = @Session";
                        cmdRt.CommandText = SQL_Pin;
                        cmdRt.Connection = conn;
                        cmdRt.CommandType = CommandType.Text;
                        cmdRt.Parameters.AddWithValue("@Session", SessionId);
                        using (SqlDataReader dr = cmdRt.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                SqlCommand cmdRt2 = new SqlCommand();
                                string SQL_ = "UPDATE [Guarantors] SET Status='CANCELLED' WHERE [Session] = @Session";
                                cmdRt2.CommandText = SQL_;
                                cmdRt2.Connection = conn;
                                cmdRt2.CommandType = CommandType.Text;
                                cmdRt2.Parameters.AddWithValue("@Session", SessionId);
                                cmdRt2.ExecuteNonQuery();
                            }
                        }
                    }

                    SqlCommand cmdRt3 = new SqlCommand();
                    string SQL_2 = "UPDATE [MSaccoSalaryAdvance] SET Status='Failed' WHERE [SESSION_ID] = @Session";
                    cmdRt3.CommandText = SQL_2;
                    cmdRt3.Connection = conn;
                    cmdRt3.CommandType = CommandType.Text;
                    cmdRt3.Parameters.AddWithValue("@Session", SessionId);
                    cmdRt3.ExecuteNonQuery();

                    conn.Close();

                    respose = true;
                }
            } catch (Exception ex)
            {
                respose = false;
            }

            return respose;
        }
        #endregion



    }
}
namespace HIMS
{
    public partial class PortalEntities :
 DbContext

    {
        public PortalEntities(string Connectionstring)
                : base(Connectionstring)
        {
        }

    }
}
public class settings
{
    public string Serverip = string.Empty;
    public string Server = string.Empty;
    public string domain = string.Empty;
    public string Instance = string.Empty;
    public string EInstance = string.Empty;
    public int Port = 0;
    public string database = string.Empty;
    public bool IntegratedSecurity = true;
    public string Username = string.Empty;
    public string pass = string.Empty;
    public string EUsername = string.Empty;
    public string Epass = string.Empty;
    public string Companyname = string.Empty;
    public int PostIntervalinsec = 2;
    public int Reconnectintervalinsec = 10;
    public string logpath = string.Empty;
    public static settings s;
    public settings loadsettings(string file)
    {
        settings s = new settings();
        XmlSerializer xs = new XmlSerializer(typeof(settings));
        using (var sr = new StreamReader(file))
        {
            s = (settings)xs.Deserialize(sr);
            settings.s = s;
            Logging.Logging.logpath = s.logpath;
        }

        return s;
    }


    public static string Connection()
    {
        // Specify the provider name, server and database.
        string providerName = "System.Data.SqlClient";
        //string serverName = "Server\\sql2008";
        //string databaseName = client.Db;
        // Initialize the connection string builder for the
        // underlying provider.
        SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
        // Set the properties for the data source.
        sqlBuilder.DataSource = string.Concat(s.Server, @"\", s.Instance);
        sqlBuilder.InitialCatalog = s.database;
        sqlBuilder.IntegratedSecurity = s.IntegratedSecurity;
        sqlBuilder.MultipleActiveResultSets = true;
        if (s.IntegratedSecurity == false)
        {
            sqlBuilder.UserID = s.Username;
            sqlBuilder.Password = s.pass;
        }

        // Build the SqlConnection connection string.
        string providerString = sqlBuilder.ToString();
        // Initialize the EntityConnectionStringBuilder.
        EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
        //Set the provider name.
        entityBuilder.Provider = providerName;

        // Set the provider-specific connection string.
        entityBuilder.ProviderConnectionString = providerString;
        // Set the Metadata location.
        entityBuilder.Metadata = "res://*/";
        return entityBuilder.ToString();

    }
}


