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

namespace Server
{
    sealed class Program
    {
        static void Main(string[] args)
        {
            try
            {
                                Console.Title = "[Copyright Polaris " + DateTime.Now.Year +" © Sacco Link Bridge®]";
            }
            catch (Exception vError)
            {
                vError.Data.Clear();
            }

            while (true)
            {
                try
                {
                    Database.Ip = "172.17.1.3";
                    Database.instance = "NAV2018";
                    Database.Db = "Bandari";
                    Database.user = "ATM";
                    Database.password = "Mbanking12345*";

                    //test

                   

                    Connection.Ipaddress = "172.18.100.6";
                    //Connection.Ipaddress = "127.0.0.1";
                   Connection.localIpaddress = "172.17.1.245";
                   // Connection.localIpaddress = "127.0.0.1";

                    Connection.portNumber = 25906;
                    Connection.company = "BANDARI";
                   
                    new Connection();
                    
                }
                catch (Exception vError)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Beep(2000, 2000);
                    vError.Data.Clear();
                }
            }
        }
    }

}
