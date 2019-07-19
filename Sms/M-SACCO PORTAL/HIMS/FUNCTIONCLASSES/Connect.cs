using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web;
using System.Net;
using System.Collections.Generic;
using System.Net.Mail;
using System.Web.UI;
using System.Security;
using System.Security.Cryptography;
using System.Threading;
using System.Web.SessionState;

/// <summary>
/// This class is used for all reads/writes to the database. 
/// </summary>
public sealed class CONNECT
{
    //ALL VARIABLE MEMBERS ARE PRIVATE FOR ABSTRACTION IN IMPLEMENTATION PURPOSES
    //private sqlMobile.SqlCeConnection mDB = new sqlMobile.SqlCeConnection(cConnect.mConnectionString);
    //private Access.OleDbConnection mDB = new Access.OleDbConnection(cConnect.mConnectionString);
    private SqlConnection mDB;

    public static string conStr = string.Empty;


    private static string _conStr = string.Empty;
    
    public static string ConnString
    {
        get
        {
            conStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            return conStr;
        }
    }
    /// <summary>
    /// Class Constructor
    /// initializes the connection [opens the database].
    /// </summary>
    public CONNECT()
    {
        try
        {
            //conStr = SiteFunctions.ConnectionString;
            conStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            this.mDB = new SqlConnection(conStr);
            this.mDB.Open();
        }
        catch (Exception ex)
        {
            string y = ex.Message;
            throw; /* bubble the error to the active document, 
                        * where the error is caught and resolved */
        }
    }

    /// <summary>
    /// DR: This method is used for reading purposes only.
    /// NB: Only for reading NOT writing.
    /// The database will have a shared lock.
    /// </summary>
    /// 
    /// <param name="vSQL">SQL statement 2B executed.</param>
    /// <returns>
    /// returns a data reader containing the execution
    /// results of the sql select statement
    /// </returns>
    public SqlDataReader ReadDB(string vSQL)
    {
        SqlDataReader r = null;

        try
        {
            SqlCommand vCMD = new System.Data.SqlClient.SqlCommand(vSQL, this.mDB);
            r = vCMD.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception)
        {
            //string s = ex.Message;
            throw; /* bubble the error to the active document, 
                        * where the error is caught and resolved */
        }
        return r;
    }

    /// <summary>
    /// DA: This method is used for reading purposes only.
    /// NB: Only for reading NOT writing.
    /// The database will have a shared lock.
    /// </summary>
    /// 
    /// <param name="vSQL">SQL statement 2B executed.</param>m>
    /// <returns>
    /// returns a data adapter containing the execution
    /// results of the sql select statement
    /// </returns>
    public SqlDataAdapter ReadDB2(string vSQL)
    {
        SqlDataAdapter r = null;

        try
        {
            r = new SqlDataAdapter(vSQL, this.mDB);
            r.AcceptChangesDuringFill = false;
            r.AcceptChangesDuringUpdate = false;

        }
        catch (Exception)
        {
            //string s = ex.Message;
            throw; /* bubble the error to the active document, 
                        * where the error is caught and resolved */
        }
        return r;
    }

    /// <summary>
    /// This method is used to update/insert/delete
    /// records using the appropriate SQL Statements. 
    /// The database will have an exclusive lock.
    /// 
    /// 
    /// 
    /// </summary>
    /// 
    /// <param name="vSQL">SQL Statement 2B executed</param>
    /// <param name="vCryptographyDetails">
    /// the parameters used to encrypt the sql statement</param>
    public void WriteDB(string vSQL)
    {
        DataSet vDS = new DataSet();

        try
        {
            vDS.EnforceConstraints = true;

            SqlDataAdapter vDA = new SqlDataAdapter
                (vSQL, conStr);

            vDA.AcceptChangesDuringFill = true;
            vDA.Fill(vDS);
        }
        catch (Exception e)
        {
            vDS.RejectChanges();
            vDS.Dispose();
            throw; /* bubble the error to the active document, 
                        * where the error is caught and resolved */

        }
        finally
        {
            this.mDB.Close();
        }
    }
}
