using System;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Net;
using System.IO.Ports;

using SQL_DB = System.Data.SqlClient;

namespace Client
{
    public static class cProgram
    {
        private static NetworkStream ns = null;
        private static TcpListener tl = null;
        public static string querySent = "";
        private static StreamReader sr = null;
        private static StreamWriter sw = null;
        public static string ipAddress = "127.0.0.1";
        private static int portNumber = 26019;

        public static void Main(string[] Args)
        {
            while (true) StartServer();
        }

        public static void StartServer()
        {
            while (true)
            {
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer;

                tl = new TcpListener(portNumber);
                tl.ExclusiveAddressUse = false;

                tl.Start(200);

                while (true)
                {
                    try
                    {
                        ns = new NetworkStream(tl.AcceptSocket());

                        sr = new StreamReader(ns);
                        sw = new StreamWriter(ns);
                        sw.AutoFlush = true;

                        NetworkStream clientStream = ns;

                        byte[] message = new byte[4096];
                        int bytesRead = 0;

                        //read sigon from bridge
                        bytesRead = clientStream.Read(message, 0, 4096);
                        Console.WriteLine(encoder.GetString(message, 0, bytesRead) + "\n\n\n");

                        //reply to signon
                        Console.WriteLine("Sending Signon Reply:\n" + encoder.GetString(message, 0, bytesRead) + "\n\n\n");
                        buffer = encoder.GetBytes(encoder.GetString(message, 0, bytesRead));
                        clientStream.Write(buffer, 0, buffer.Length);
                        clientStream.Flush();

                        while (true)
                        {
                            reDo:
                            string msg = "";

                            if (msg != "")
                            {
                                //send transaction
                                buffer = encoder.GetBytes(msg);
                                clientStream.Write(buffer, 0, buffer.Length);
                                clientStream.Flush();

                                //read reply
                                bytesRead = clientStream.Read(message, 0, 4096);
                                Console.WriteLine(encoder.GetString(message, 0, bytesRead) + "\n\n\n");
                            }
                            else { Thread.Sleep(3000); goto reDo; }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                        ex.Data.Clear();
                    }
                }

            }
        }

    }

    //class cConnect
    //{
    //    private string mConnectionString = "";
    //    private SQL_DB.SqlConnection mDB;

    //    /// <summary>
    //    /// Class Constructor
    //    /// initializes the connection [opens the database].
    //    /// </summary>
    //    public cConnect()
    //    {
    //        try
    //        {
    //            this.mConnectionString = @"Data Source=.\OGOLLA;Initial Catalog='ATM Bridge';Persist Security Info=True;User ID='sa'; Password='111111@a'";

    //            this.mDB = new SQL_DB.SqlConnection(this.mConnectionString);

    //            this.mDB.Open();
    //        }
    //        catch
    //        {
    //            /* bubble the error to the active document, 
    //                   * where the error is caught and resolved */
    //            throw;

    //        }
    //    }

    //    /// <summary>
    //    /// This method is used for reading purposes only.
    //    /// NB: Only for reading NOT writing.
    //    /// The database will have a shared lock.
    //    /// </summary>
    //    /// <param name="vSQL">SQL statement 2B executed.</param>
    //    /// <param name="vCryptographyDetails">
    //    /// the parameters used to encrypt the sql statement</param>
    //    /// <returns>
    //    /// returns a data reader containing the execution
    //    /// results of the sql select statement
    //    /// </returns>
    //    public SQL_DB.SqlDataReader ReadDB(string vSQL)
    //    {
    //        SQL_DB.SqlDataReader r = null;

    //        try
    //        {
    //            if (this.mDB.State != ConnectionState.Open)
    //                this.mDB.Open();
    //            SQL_DB.SqlCommand vCMD = new System.Data.SqlClient.SqlCommand(vSQL, this.mDB);
    //            r = vCMD.ExecuteReader(CommandBehavior.CloseConnection);
    //        }
    //        catch (Exception)
    //        {
    //            throw; /* bubble the error to the active document, 
    //                    * where the error is caught and resolved */
    //        }
    //        return r;
    //    }

    //    /// <summary>
    //    /// This method is used to update/insert/delete
    //    /// records using the appropriate SQL Statements. 
    //    /// The database will have an exclusive lock.
    //    /// </summary>
    //    /// <param name="vSQL">SQL Statement 2B executed</param>
    //    /// <param name="vCryptographyDetails">
    //    /// the parameters used to encrypt the sql statement</param>
    //    public void WriteDB(string vSQL)
    //    {
    //        DataSet vDS = new DataSet();

    //        try
    //        {
    //            vDS.EnforceConstraints = true;

    //            if (this.mDB.State != ConnectionState.Open)
    //                this.mDB.Open();

    //            SQL_DB.SqlDataAdapter vDA = new SQL_DB.SqlDataAdapter
    //                (vSQL, this.mConnectionString);

    //            vDA.AcceptChangesDuringFill = true;
    //            vDA.Fill(vDS);
    //        }
    //        catch (Exception)
    //        {
    //            vDS.RejectChanges();
    //            vDS.Dispose();
    //            throw; /* bubble the error to the active document, 
    //                    * where the error is caught and resolved */
    //        }
    //        finally
    //        {
    //            this.mDB.Close();
    //        }
    //    }

    //}

}
