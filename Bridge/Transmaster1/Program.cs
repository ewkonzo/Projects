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
        private static int portNumber = 25924;

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
                            string msg = "ok";
 string clientmessage = "";
                                clientmessage = Console.ReadLine();
                            if (clientmessage != "")
                            {
                                switch (clientmessage)
                                {

                                    case "1"://balance
                                        clientmessage = "02881100E0340541AEE1A0000000000C1000000016429933051323265531000098444218080712562022075111015131461086011084407820006RTPSID374299330513232655=22072211709459600000821912984442173713000ATM0108 00500108       40digo003>MOMBASA                       KE009AT01O2222KESKES05SACCO10RTPSID966605SACCO";
                                        break;
                                    case "2"://pos balance
                                        clientmessage = "02851100E03405C1AEE100000000000C10000000164299330529282744370000987713180807125944191251010151314410815086010084407820006RTPSID374299330529282744D19122211000018300000821913987713839657000POS03589POSAG003210    40PAYBOX INVESTMENTS LTD>NAIROBI        KE009PT01O222205SACCO0940401PISO05SACCO";
                                        break;
  case "3"://pos cash Withdrawal
                                        clientmessage = "04121200F67405D9AEE1E0000000000E12000000164299330529282744010000000000050000000000050000080711023961000000989938180807130212191251010151314420015066010180807  1084407820006RTPSID374299330529282744D19122211000018300000821913989938693173000POS03589POSAG003210    40PAYBOX INVESTMENTS LTD>NAIROBI        KE009PT01O2222KESKESKES05SACCO0940401PISO4500030212744POSAG003210693173ROWN010231498993805SACCO18011991614129000044";
                                        break;
  case "4"://pos cash deposit
                                        clientmessage = "04061200F67405598EE1E0000000000E5300000016429933052928274421000000000005000000000005000008071103436100000099088518080713034319122101010541442006010180806  0084407820006RTPSID821913990885421968000POS035890002P001       40CASH DEPOSIT TO CARD>NAIROBI          KE009PT01O222 KESKESKES05SACCO10RTPSID990042000301827440002P001421968ROWN0102314990885CASH DEPOSIT2CARD        05SACCO1801X900000096980096011POSAG003210";
                                        break;

  case "5"://pos mpesa withdrawal
                                        clientmessage = "04661200F6740559AEE1E0000000000E5300000016429933052928274400000000000001000000000001000008071110576100000099687818080713105719125101015131442005999180806  0084407820006RTPSID374299330529282744D19122211000018300000821913996878255123000POS03589WPOS0001       40POS WATER>NAIROBI                     KE009PT01O2222KESKESKES05SACCO10RTPSID99004200030182744WPOS0001255123ROWN01023149968781275707                  05SACCO18011360013614030007032821907130908 1275707 POSAG003210";
                                        break;

  case "6"://pos coop atm withdrawal
                                        clientmessage = "04221200F674055BAEE1E0000000000E1200000016429933052928274401000000000010000000000010000008071004406100000093981018080712044019125111015131462006011180806  01420180724125305084407820006RTPSID374299330529282744=19122211000018300000821912939810951366000ATM0001 00020001       40Coop Trust ATM 1>Nairobi              KE009AT01O2222KESKESKES05SACCO10RTPSID9666420003018274400020001951366ROWN010231493981005SACCO18015030000002610002";
                                        break;


  case "7"://pos Visa
                                        clientmessage = "03731100F4740541AEE1A0000000000E1000000016429933052928274401000000000010000000000010000061000000541671180807094454191251120151300C10060110641736306RTPSID374299330529282744=1912221100001830000082190154167142647300003010034I&M BANK       40CHASE BANK>MADARAKA                   KE009AF01O2222KESKES05SACCO10RTPSVISDIF5300030154682193438295580006007VISADMSROWN010231496340405SACCO";
                                        break;

                                    case "10":
                                        clientmessage = "02951100E0340541AEE100000000000E1000000016429933160407786837000013492818121716123122015111015131461086011084407820006RTPSID374299331604077868=22012211943532700000835116134928241344000ATM0500 00530500       40AWENDO001>MIGORI                      KE009AT01O222205SACCO10RTPSID9666112425134928 05SACCO";
                                        break;


                                    default:
                                        clientmessage = "";
                                        break;
                                }
                                if (clientmessage != "") {
                                    //send transaction
                                    Console.WriteLine("Sending Request:\n" + clientmessage + "\n\n\n");
                                    buffer = encoder.GetBytes(clientmessage);
                                    clientStream.Write(buffer, 0, buffer.Length);
                                    clientStream.Flush();
                                    //read reply
                                    bytesRead = clientStream.Read(message, 0, 4096);
                                    Console.WriteLine(encoder.GetString(message, 0, bytesRead) + "\n\n\n");
                                }
                                else
                                {
                                    Console.Write("Invalid transaction");
                                }
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
