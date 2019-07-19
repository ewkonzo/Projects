using Bridge.Atm_Logs;
using Bridge.Atm_Transactions;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.IO.Ports;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Net.Mail;

using SQL_DB = System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Server
{
    sealed class Program
    {
        public static Atm_Transactions_Service AtmTrans = new Atm_Transactions_Service();
        public static Bridge.Atm_Charges.Atm_Charges_Service charges_Service = new Bridge.Atm_Charges.Atm_Charges_Service();
        public static Atm_Logs_Service logs_Service = new Atm_Logs_Service();
        public static Bridge.Pos_Commissions.Pos_Commissions_Service commissions_Service = new Bridge.Pos_Commissions.Pos_Commissions_Service();
        public static Bridge.Accounts.Accounts_Service accounts_Service = new Bridge.Accounts.Accounts_Service();
        public static Bridge.Account_Entries.Account_Entries_Service entries_Service = new Bridge.Account_Entries.Account_Entries_Service();
        public static Bridge.PostAtm.PostAtm postAtm = new Bridge.PostAtm.PostAtm();
        public static settings s;
        private static System.Net.NetworkCredential cd;


        static void Main(string[] args)
        {
           
         

            while (true)
            {
                try
                {
   startservices();
                    //Database.Ip = "172.17.1.3";
                    //Database.instance = ".\NAV";
                    //Database.Db = "Bandari";
                    //Database.user = "ATM";
                    //Database.password = "Mbanking12345*";
                    //test

                    Database.Ip = "localhost";
                    Database.instance = "NAV";
                    Database.Db = "Bandari";
                    Database.user = "Atm";
                    Database.password = "Mbanking12345*";

                    //Connection.Ipaddress = "172.18.100.6";
                    Connection.Ipaddress = "127.0.0.1";
                    //Connection.localIpaddress = "172.17.7.19";
                    Connection.localIpaddress = "127.0.0.1";

                    Connection.portNumber = 25924;
                    Connection.company = "BANDARI";
                   
                    new Connection();
                    
                }
                catch (Exception vError)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    //Console.WriteLine(String.Format("Unable to connect to Database"));
                    Console.Beep(2000, 2000);
                    vError.Data.Clear();
                }
            }
        }


       static void startservices()
        {
            ServicePointManager.ServerCertificateValidationCallback = (object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => (true);

            string path = "Settings.xml";

            s= new settings().loadsettings(path);

            cd = new System.Net.NetworkCredential(s.EUsername, s.Epass, s.domain);
            AtmTrans.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Atm_Transactions", s.Serverip, s.Companyname, s.EInstance, s.Port);
            AtmTrans.Credentials = cd;
            AtmTrans.PreAuthenticate = true;

            logs_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Atm_Logs", s.Serverip, s.Companyname, s.EInstance, s.Port);
            logs_Service.Credentials = cd;
            logs_Service.PreAuthenticate = true;

            charges_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Atm_Charges", s.Serverip, s.Companyname, s.EInstance, s.Port);
            charges_Service.Credentials = cd;
            charges_Service.PreAuthenticate = true;

            commissions_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Pos_Commissions", s.Serverip, s.Companyname, s.EInstance, s.Port);
            commissions_Service.Credentials = cd;
            commissions_Service.PreAuthenticate = true;

            accounts_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Accounts", s.Serverip, s.Companyname, s.EInstance, s.Port);
            accounts_Service.Credentials = cd;
            accounts_Service.PreAuthenticate = true;

            entries_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Account_Entries", s.Serverip, s.Companyname, s.EInstance, s.Port);
            entries_Service.Credentials = cd;
            entries_Service.PreAuthenticate = true;

 postAtm.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/PostAtm", s.Serverip, s.Companyname, s.EInstance, s.Port);
            postAtm.Credentials = cd;
            postAtm.PreAuthenticate = true;
            openconnection();
            

        }
        static void openconnection() {
            try
            {
                charges_Service.ReadMultiple(new Bridge.Atm_Charges.Atm_Charges_Filter[] { }, null, 0);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(String.Format("Database Connected"));
                Connection.OpenedDatabase = true;
                Connection.OpenedDatabaseFailed = 0;

                Thread t = new Thread(posting);
                t.IsBackground = true;
                t.Priority = ThreadPriority.Normal;
                t.SetApartmentState(ApartmentState.MTA);
                t.Start();
               // t.Join();

               
            }
            catch (Exception ex) {
                Logs.ReportError(ex);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("Unable to connect to Database"));
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        static void posting() {

           
            while (true) {
                try
                {
 Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("\t\tPosting"));
                    postAtm.Post();

                }
                catch (Exception e)
                {

                    Logs.ReportError(e);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(string.Format("\t\tUnable to post\n\t\t{0}", e.Message));
                }
                Thread.Sleep(s.PostIntervalinsec * 1000);
            }
        }
    }
}
