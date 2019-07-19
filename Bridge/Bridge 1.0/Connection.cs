using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Connection
    {
        public static int portNumber = 25903;
        public static string Ipaddress = "";
        public static string localIpaddress = "";
        public static bool LiveSwitch = true;
        public static string company = "";
        public Socket clientSocket;

        public static int beepF = 1000;

        string TransactionType = "", BitmapHexa = "", BitmapBinary = "", ProcessingCode = "", CardholderBilling = "", TransmissionDateTime = "",
            ConversionRate = "", SystemTraceAuditNo = "", DateTimeLocal = "", ExpiryDate = "",
            POSEntryMode = "", FunctionCode = "", POSCaptureCode = "", TransactionFee = "",
            SettlementFee = "", SettlementProcessingFee = "", SettlementCurrencyCode = "", AcquiringInstitutionIDCode = "",
            ForwardingInstitutionIDCode = "", Transaction2Data = "", RetrievalReferenceNo = "",
            AuthorisationIDResponse = "", ResponseCode = "", CardAcceptorTerminalID = "", CardAcceptorIDCode = "",
            CardAcceptorName_Location = "", AdditionalDataPrivate = "", TransactionCurrencyCode = "",
            CardholderBillingCurCode = "", ResponseIndicator = "", ServiceIndicator = "", ReplacementAmounts = "",
            ReceivingInstitutionIDCode = "", AccountIdentification2 = "", AccountNo = "";

        string fld26_ = "", fld41_ = "", fld42_ = "", fld94_ = "", fld98_ = "";

        private Thread echoesOnly = null;
        private Semaphore echoRequest;
        private Semaphore atmRequest = new Semaphore(1, 1);
        private int returnCodeFromDB = 0, TransactionTypeX = 0;

        public static bool OpenedDatabase = false;
        public static int OpenedDatabaseFailed = 0;
        public static int CoopBankPortClosed = 0;

        public static string isCoopBank = "0";
        public static enPOSVendor posVendor = enPOSVendor.pvATMLobby;

        /// <summary>
        /// enum for balance types (eg balance, reversal and pos)
        /// </summary>
        enum enBalance
        {
            balBalance,
            balMiniStatement,
            balCashWithdrawalCoop,
            balCashWithdrawalVisa,
            balReversal,
            balUtilityPayment,
            balPOSNormalPurchase,
            balMPesaWithdrawal,
            balAirtimeTopup,
            balPOSSchoolPayment,
            balPOSPurchaseWithCashBack,
            balPOSCashDeposit,
            balPOSBenefitCashWithdrawal,
            balPOSCashDepositToCard,
            balPOSMBanking,
            balPOSCashWithdrawal,
            balPOSBalance,
            balPOSMiniStatement
        }

        /// <summary>
        /// enum for POS Vendors
        /// </summary>
        public enum enPOSVendor
        {
            pvATMLobby,
            pvAgentBanking,
            pvCoopBranch,
            pvSaccoPOS
        }

        //the following transaction details will be saved to the database
        string atmTraceID = "", atmTraceIDRev = "", atmUnitID = "", atmPostingS = "", atmAccountNo = "",
            atmDescription = "", atmTransTime = "", atmLocation = "",
            atmMpesaPhoneNumber = "", atmMpesaTransactionDescription = "", procCode = "", finalReturnValue = "";
        double atmAmount = 0;

        private int totalFields = 0;
        Database cnt = new Database();
        private static int QueryNo = 0;

        public Connection()
        {
            try
            {
                Thread t2 = new Thread(this.AtmRequests);
                t2.IsBackground = true;
                t2.Priority = ThreadPriority.Normal;
                t2.SetApartmentState(ApartmentState.MTA);
                t2.Start();
                t2.Join();
            }
            catch
            {
                Console.WriteLine("\n\nDatabase not found." +
                                  "\nVerify that the database is accessible from this computer." +
                                  "\nContact your system administrator for more help.");

                Logs.LogEntryOnFile("\n\n" + DateTime.Now.ToString() + "\t" +
                                                                "\n\tDatabase not found." +
                                                                "\n\tVerify that the database is accessible from this computer." +
                                                                "\n\tContact your system administrator for more help."
                    );

                throw;
            }
        }

        private void AtmRequests()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            IPEndPoint serverEndPoint = null;
            try
            {
                byte[] buffer;
                ASCIIEncoding encoder = new ASCIIEncoding();
                string s = string.Empty;

                if (LiveSwitch)
                {
                    ////serverEndPoint = new IPEndPoint(IPAddress.Parse("172.16.4.6"), portNumber);
                    serverEndPoint = new IPEndPoint(IPAddress.Parse(Ipaddress), portNumber);
                    //serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), portNumber);
                }
                else
                {
                    //company = "United Nations Sacco LTD";
                    portNumber = 26051;
                    serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), portNumber);
                }

                Console.Title =
                    "[Copyright Iansoft Technologies " + DateTime.Now.Year +" © ATM Bridge®] " +
                    serverEndPoint.ToString();

                if (clientSocket == null)
                {
                    clientSocket =
                        new Socket(
                            AddressFamily.InterNetwork, SocketType.Stream,
                            ProtocolType.Tcp
                            );

                    //EndPoint clientEndPoint = (EndPoint)(new IPEndPoint(IPAddress.Parse("172.17.141.145"), portNumber));
                    EndPoint clientEndPoint = (EndPoint)(new IPEndPoint(IPAddress.Parse(localIpaddress), portNumber));
                    //EndPoint clientEndPoint = (EndPoint)(new IPEndPoint(IPAddress.Parse("127.0.0.1"), portNumber));
                    //EndPoint clientEndPoint = (EndPoint)(new IPEndPoint(IPAddress.Parse("172.30.20.70"), portNumber));
                    try
                    {
                        clientSocket.Bind(clientEndPoint);
                    }
                    catch(Exception ex)
                    {
                        Logs.ReportError(ex);
                    }

                    if (!clientSocket.Connected)
                        clientSocket.Connect(serverEndPoint);

                }
                NetworkStream clientStream =
                    new NetworkStream(clientSocket);

                if (this.Authenticate(clientStream))
                {
                    int bytesRead;
                    byte[] message = new byte[4096];

                    Console.ForegroundColor = ConsoleColor.Green;
                    do
                    {
                        try
                        {
                            if (!System.IO.File.Exists(Logs.LogFileName))
                            {
                                System.IO.File.Create(Logs.LogFileName);
                            }
                        }
                        catch (Exception ex)
                        {
                            ex.Data.Clear();
                        }

                        if (LiveSwitch)
                        {
                            bytesRead = 0;

                            try
                            {
                                // Blocks until a client sends a message                    
                                bytesRead = clientStream.Read(message, 0, 4096);
                            }
                            catch
                            {
                                throw;
                            }

                            if (bytesRead == 0)
                            {
                                // A socket error has occured
                                Console.Beep(Connection.beepF, 2000);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Failed To connect.. Retrying in a few sec...");
                                Logs.LogEntryOnFile("\tFailed To connect.. Retrying in a few sec...\n");
                                Logs.LogEntryOnFile("Bytes 0");
                              
                                return;
                            }

                            s = encoder.GetString(message, 0, bytesRead);
                        }
                        else
                            s = Messages.SampleRequest;

                        QueryNo++;

                        //Console.WriteLine("\nQuery No " + QueryNo.ToString());
                        //Console.WriteLine(s);

                        //send response to switch
                        if (this.EchoRequest(s))
                        {
                            Console.WriteLine("Echo Test Detected: " + s);

                            buffer = encoder.GetBytes(this.EchoReply(s));
                            clientStream.Write(buffer, 0, buffer.Length);
                            clientStream.Flush();

                            //Console.Beep(10000, 1000);
                        }
                        else
                        {
                            if (s == "")
                            {
                                Console.Beep(Connection.beepF, 2000);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Failed To connect.. Retrying in a few sec...");
                                Logs.LogEntryOnFile("\tFailed To connect.. Retrying in a few sec...\n");
                                Logs.LogEntryOnFile( "s null");
                               
                                return;
                            }
                            else
                            {
                                string bridgeResponse = this.EncodeResponse(s);

                                buffer = encoder.GetBytes(bridgeResponse);
                                clientStream.Write(buffer, 0, buffer.Length);
                                clientStream.Flush();

                                this.DecodeRequest(bridgeResponse, false);
                            }
                        }

                    }
                    while (true);
                }
            }
            catch (Exception ex)
            {
                Console.Beep(Connection.beepF, 2000);
                Console.ForegroundColor = ConsoleColor.Red;

                if (clientSocket.Connected)
                    clientSocket.Disconnect(true);

                clientSocket.Close();

                Console.WriteLine("Failed To connect.. Retrying in a few sec...");
                Logs.LogEntryOnFile("\tFailed To connect.. Retrying in a few sec...\n");
                Logs.ReportError(ex) ;
                Logs.LogEntryOnFile(ex.StackTrace);
                ex.Data.Clear();

                return;
            }
        }

        private bool Authenticate(NetworkStream clientStream)
        {
            bool b = false;

            try
            {
                byte[] buffer;
                ASCIIEncoding encoder = new ASCIIEncoding();
                string s = "";

                //(sign on)
                string signon = "004718040030011000000000000002061015053113801" + this.DateToday;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sent signon info to switch:\n" + signon);

                Logs.LogEntryOnFile("\tSent signon info to switch:\n" + signon + "\n");

                //sw.WriteLine(signon);
                //sw.Flush();

                buffer = encoder.GetBytes(signon);
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();

                byte[] message = new byte[4096];
                int bytesRead = 0;

                try
                {
                    //Thread.Sleep(3000);

                    // Blocks until a client sends a message                    
                    //if (clientStream.DataAvailable)
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch(Exception ex)
                {
                    Console.Beep(Connection.beepF, 2000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed To connect.. Retrying in a few sec...");
                    Logs.LogEntryOnFile("\tFailed To connect.. Retrying in a few sec...\n");
                   Logs.ReportError(ex);
                   ;
                    throw;
                }

                if (bytesRead == 0)
                {
                    Console.Beep(Connection.beepF, 2000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed To connect.. Retrying in a few sec.... The Port is Closed. Contact Co-op Bank.");
                    Logs.LogEntryOnFile("\tFailed To connect.. Retrying in a few sec.... The Port is Closed. Contact Co-op Bank.\n");

                    Connection.CoopBankPortClosed++;

                   

                    if (Connection.CoopBankPortClosed >= 20) Connection.CoopBankPortClosed = 0;

                    return b;
                }

                // Message has successfully been received                        
                // Output message and decode
                s = encoder.GetString(message, 0, bytesRead);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Connected to Transmaster");
                Logs.LogEntryOnFile("\tConnected to Transmaster.\n");
                Console.WriteLine("Read signon reply from switch.");
                Logs.LogEntryOnFile("\tRead signon reply from switch.\n");

                Console.WriteLine(s);

                Console.WriteLine("Starting processing of incoming transactions");
                Logs.LogEntryOnFile("\tStarting processing of incoming transactions\n");

                this.echoRequest = new Semaphore(20000, 20000);
                this.echoesOnly = new Thread(this.EchoSender);
                this.echoesOnly.IsBackground = true;
                this.echoesOnly.Priority = ThreadPriority.Normal;
                this.echoesOnly.SetApartmentState(ApartmentState.MTA);
                this.echoesOnly.Start();

                b = true;

            }
            catch(Exception ex)
            {
                Console.Beep(Connection.beepF, 2000);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed To connect.. Retrying in a few sec...");
                Logs.LogEntryOnFile("\tFailed To connect.. Retrying in a few sec...\n");
                      Logs.ReportError(ex) ;
               ;
                throw;
            }
            return b;
        }

        private void ReplyToSocket(StreamWriter sw, string clientQuery)
        {
            try
            {
                string bridgeResponse = this.EncodeResponse(clientQuery);

                sw.WriteLine(bridgeResponse);
                sw.Flush();

                Console.WriteLine("\nBridge Response To Query No " + QueryNo.ToString() + ":");
                Console.WriteLine(bridgeResponse);

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
        }

        private string[,] DecodeRequest(string clientRequest, bool request)
        {
            string[,] s = null;

            Console.ForegroundColor = ConsoleColor.Green;
            string[,] fieldsPresent = null;

            double TransactionAmount = 0;

            try
            {
                //from transmaster request
                if (clientRequest.Length < 60)
                {
                    Logs.LogEntryOnFile( "Received Echo Reply From Transmaster: " + clientRequest + "\n");
                    return s;
                }

                string temp = "";
                int i = 0;

                for (int i2 = 0; i2 < 32; i2++)
                {
                    Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                        "select Binary from [" + company + "$Hexa Binary]" +
                        " where Hexadecimal = '" + clientRequest.Substring(8, 32).Substring(i2, 1) + "'"
                        );
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            i++;
                            if (dr["Binary"] != null)
                                temp += dr["Binary"].ToString();
                        }

                    dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
                }

                BitmapHexa = clientRequest.Substring(8, 32);
                BitmapBinary = temp;

                //Console.WriteLine("FIELDS PRESENT:");
                //for (int kk = 1; kk <= BitmapBinary.Length; kk++)
                //{
                //    if (BitmapBinary.Substring(kk - 1, 1) == "1")
                //        Console.Write("," + kk.ToString());
                //}

                //Console.WriteLine("");

                this.totalFields = 0;
                for (int i2 = 0; i2 < temp.Length; i2++)
                    if (temp.Substring(i2, 1) == "1")
                        this.totalFields++;

                //this.totalFields--;
                fieldsPresent = new string[this.totalFields, 5];
                fieldsPresent[0, 0] = "1";//index
                fieldsPresent[0, 1] = "32";//length
                fieldsPresent[0, 2] = "FALSE";//is variable length
                fieldsPresent[0, 3] = "0";//no. of characters padded
                fieldsPresent[0, 4] = clientRequest.Substring(8, 32);

                int length = 0, k = -1, lastIndex = 40;

                for (int i2 = 1; i2 < temp.Length; i2++)
                {
                    length = 0;
                    string temp2 = temp.Substring(i2, 1);

                    if (temp2 == "1")
                    {
                        k++;
                        if (!this.FieldIsVariable(i2 + 1))
                            length = this.FieldLength(i2 + 1);
                        else
                        {
                            string TEMP = clientRequest.Substring(lastIndex, this.VariableFieldLength(i2 + 1));

                            if (Logs.IsNumberValid(TEMP))
                                length = Convert.ToInt32(TEMP);

                            lastIndex += this.VariableFieldLength(i2 + 1);
                        }

                        //to be removed later
                        //cUtilities.LogEntryOnFile(cUtilities.LogFileName, fieldsPresent[k, 0] = (i2 + 1).ToString());

                        //store in 2-D array
                        fieldsPresent[k, 0] = (i2 + 1).ToString();//index
                        fieldsPresent[k, 1] = length.ToString();//length
                        fieldsPresent[k, 2] = this.FieldIsVariable(Convert.ToInt32(fieldsPresent[k, 0])).ToString();//is variable length
                        fieldsPresent[k, 3] = this.VariableFieldLength(Convert.ToInt32(fieldsPresent[k, 0])).ToString();//no. of characters padded

                        if (clientRequest.Length >= (lastIndex + length))
                        {
                            fieldsPresent[k, 4] = clientRequest.Substring(lastIndex, length);//value

                        }
                        else
                        {
                            fieldsPresent[k, 4] = "";//value
                        }

                        lastIndex += length;
                        s = fieldsPresent;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }
            try
            {
                this.atmTraceID = ""; this.atmUnitID = ""; this.atmPostingS = ""; this.atmAccountNo = "";
                this.atmDescription = ""; this.atmAmount = 0; this.atmTransTime = ""; this.atmLocation = "";
                this.atmMpesaPhoneNumber = ""; this.atmMpesaTransactionDescription = "";

                for (int y = 0; y < this.totalFields; y++)
                {
                    if (fieldsPresent[y, 0] != null)
                    {
                        if (fieldsPresent[y, 0] == "2")
                        {
                            this.atmAccountNo = fieldsPresent[y, 4];
                            //this.atmAccountNo = AccountNo;
                            this.atmDescription = this.atmAccountNo;
                        }

                        if (fieldsPresent[y, 0] == "3")
                        {
                            ProcessingCode = fieldsPresent[y, 4];
                        }

                        if (fieldsPresent[y, 0] == "3")
                            this.procCode = fieldsPresent[y, 4];

                        if (fieldsPresent[y, 0] == "4")
                        {
                            TransactionAmount = Convert.ToDouble(fieldsPresent[y, 4]) / 100;
                            this.atmAmount = TransactionAmount;
                        }

                        if (fieldsPresent[y, 0] == "6")
                        {
                            CardholderBilling = fieldsPresent[y, 4];
                            TransactionAmount = Convert.ToDouble(fieldsPresent[y, 4]) / 100;
                            this.atmAmount = TransactionAmount;
                        }

                        if (fieldsPresent[y, 0] == "7")
                        {
                            TransmissionDateTime = fieldsPresent[y, 4];
                            this.atmPostingS = DateTime.Now.ToString();
                        }

                        if (fieldsPresent[y, 0] == "10") { ConversionRate = fieldsPresent[y, 4]; }

                        if (fieldsPresent[y, 0] == "11")
                        {
                            SystemTraceAuditNo = fieldsPresent[y, 4];
                            this.atmTraceID = SystemTraceAuditNo;
                        }

                        if (fieldsPresent[y, 0] == "56")
                        {
                            this.atmTraceIDRev = fieldsPresent[y, 4].Substring(4, 6);
                        }

                        if (fieldsPresent[y, 0] == "12")
                        {
                            DateTimeLocal = fieldsPresent[y, 4];
                            this.atmTransTime = DateTimeLocal;
                        }

                        if (fieldsPresent[y, 0] == "14") { ExpiryDate = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "22") { POSEntryMode = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "24") { FunctionCode = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "26") { POSCaptureCode = fieldsPresent[y, 4]; fld26_ = POSCaptureCode; }
                        if (fieldsPresent[y, 0] == "28") { TransactionFee = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "29") { SettlementFee = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "31") { SettlementProcessingFee = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "50") { SettlementCurrencyCode = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "32") { AcquiringInstitutionIDCode = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "33") { ForwardingInstitutionIDCode = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "35") { Transaction2Data = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "37") { RetrievalReferenceNo = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "38") { AuthorisationIDResponse = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "39") { ResponseCode = fieldsPresent[y, 4]; }

                        if (fieldsPresent[y, 0] == "41")
                        {
                            CardAcceptorTerminalID = fieldsPresent[y, 4];
                            fld41_ = CardAcceptorTerminalID;
                            this.atmUnitID = "";
                        }

                        if (fieldsPresent[y, 0] == "42")
                        {
                            CardAcceptorIDCode = fieldsPresent[y, 4];
                            fld42_ = CardAcceptorIDCode;

                            //set defaults
                            Connection.isCoopBank = "0";
                            Connection.posVendor = Connection.enPOSVendor.pvATMLobby;

                            if (fld42_.Contains("POSBR"))//BRANCH
                            {
                                Connection.posVendor = Connection.enPOSVendor.pvCoopBranch;
                                Connection.isCoopBank = "1";
                            }
                            else if (fld42_.Contains("POSSA"))//SACCO
                            {
                                Connection.posVendor = Connection.enPOSVendor.pvSaccoPOS;
                                Connection.isCoopBank = "0";
                            }
                            else if (fld42_.Contains("POSAG") || fld42_.Contains("POSMR"))//AGENT
                            {
                                Connection.posVendor = Connection.enPOSVendor.pvAgentBanking;
                                Connection.isCoopBank = "0";
                            }
                        }
                        if (fieldsPresent[y, 0] == "43") { CardAcceptorName_Location = fieldsPresent[y, 4]; this.atmLocation = CardAcceptorName_Location; }
                        if (fieldsPresent[y, 0] == "48") { AdditionalDataPrivate = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "49") { TransactionCurrencyCode = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "51") { CardholderBillingCurCode = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "93") { ResponseIndicator = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "94") { ServiceIndicator = fieldsPresent[y, 4]; fld94_ = ServiceIndicator; }
                        if (fieldsPresent[y, 0] == "95") { ReplacementAmounts = fieldsPresent[y, 4]; }

                        if (fieldsPresent[y, 0] == "98")
                        {
                            //sample: MPESAMBANKING,0712332580
                            this.atmMpesaPhoneNumber = fieldsPresent[y, 4];
                            fld98_ = this.atmMpesaPhoneNumber;

                            char[] c = ",".ToCharArray();
                            string[] phoneNo = this.atmMpesaPhoneNumber.Split(c);

                            if (phoneNo.GetUpperBound(0) == 1)
                                this.atmMpesaPhoneNumber = phoneNo[1];
                            else
                                this.atmMpesaPhoneNumber = "";
                        }

                        if (fieldsPresent[y, 0] == "41") { this.atmMpesaTransactionDescription = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "103") { ReceivingInstitutionIDCode = fieldsPresent[y, 4]; }
                        if (fieldsPresent[y, 0] == "103") { AccountIdentification2 = fieldsPresent[y, 4]; }
                    }

                }

                TransactionType = Messages.MessageTypeNumber(clientRequest.Substring(4, 4), procCode.Substring(0, 2)).ToString();

                //Console.WriteLine(clientRequest);
                Logs.LogEntryOnFile( clientRequest);

                string desc = "Response";
                if (request) desc = "Request";

                if (Messages.MessageType(procCode.Substring(0, 2), fld41_, fld42_, fld94_) != Messages.enMessageType.mtUnknown)
                {
                    Console.WriteLine("\n<Transaction Type=\t\t\"" + Messages.RequestDescription(Messages.MessageType(procCode.Substring(0, 2), fld41_, fld42_, fld94_)) + desc + "\">");
                    Logs.LogEntryOnFile( "\n<Transaction Type=\t\t\"" + Messages.RequestDescription(Messages.MessageType(procCode.Substring(0, 2), fld41_, fld42_, fld94_)) + desc + "\">");
                }
                else
                {
                    Console.WriteLine("\n<Transaction Type=\t\t\"" + Messages.RequestDescription(Messages.MessageType(clientRequest.Substring(4, 4), procCode.Substring(0, 2), fld41_, fld42_, fld94_)) + desc + "\">");
                    Logs.LogEntryOnFile( "\n<Transaction Type=\t\t\"" + Messages.RequestDescription(Messages.MessageType(clientRequest.Substring(4, 4), procCode.Substring(0, 2), fld41_, fld42_, fld94_)) + desc + "\">");
                }

                Console.WriteLine("\n\t<Transaction Date Time=\t\"" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString() + "\"/>");
                Logs.LogEntryOnFile( "\n\t<Transaction Date Time=\t\"" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.TimeOfDay.ToString() + "\"/>");

                Console.WriteLine("\n\t<Account No=\t\t\"" + this.atmAccountNo + "\"/>");
                Logs.LogEntryOnFile( "\n\t<Account No=\t\t\"" + this.atmAccountNo + "\"/>");

                Console.WriteLine("\n\t<Customer No=\t\t\"" + ATM.CustomerNo(this.atmAccountNo) + "/>");
                Logs.LogEntryOnFile( "\n\t<Customer No=\t\t\"" + ATM.CustomerNo(this.atmAccountNo) + "/>");

                Console.WriteLine("\n\t<Customer Names=\t\t\"" + ATM.CustomerNames(this.atmAccountNo) + "\"/>");
                Logs.LogEntryOnFile( "\n\t<Customer Names=\t\t\"" + ATM.CustomerNames(this.atmAccountNo) + "\"/>");

                Console.WriteLine("\n\t<Amount=\t\t\t\"" + this.atmAmount + "\"/>");
                Logs.LogEntryOnFile( "\n\t<Amount=\t\t\t\"" + this.atmAmount + "\"/>");

                Console.WriteLine("\n\t<Fields>");
                Logs.LogEntryOnFile( "\n\t<Fields>");

                for (int y = 0; y < this.totalFields; y++)
                {
                    Console.WriteLine(
                        "\n\t\t<" +
                        "Field= \"" + fieldsPresent[y, 0] + "\"; " +
                        "Value= \"" + fieldsPresent[y, 4] + "\"/>"
                        );

                    Logs.LogEntryOnFile(
                        "\n\t\t<" +
                        "Field= \"" + fieldsPresent[y, 0] + "\"; " +
                        "Value= \"" + fieldsPresent[y, 4] + "\"/>"
                        );
                }

                Console.WriteLine("\n\t<Fields/>");
                Logs.LogEntryOnFile( "\n\t<Fields/>");

                Console.WriteLine("\n<Transaction Type/>\n\n\n");
                Logs.LogEntryOnFile( "\n<Transaction Type/>\n\n\n");

                //transaction audit trail
              


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex.Data.Clear();
            }

            return s;
        }

        private string EncodeResponse(string clientRequest)
        {
            try
            {
                if (clientRequest == "004718040030011000000000000002061015053113831061015")
                    return "004418140030010002000000000002061015053113831800";

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return this.Encode(clientRequest, this.DecodeRequest(clientRequest, true));
        }

        protected string Encode(string clientRequest, string[,] fieldsPresent)
        {
            string results = "";

            try
            {
                if (fieldsPresent == null)
                    return "";

                string s = "";
                int i = 0;

                //convert bitmaps 1 & 2, to binary format
                for (int i2 = 0; i2 < 32; i2++)
                {
                    Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                        "select Binary from [" + company + "$Hexa Binary]" +
                        " where Hexadecimal = '" + clientRequest.Substring(8, 32).Substring(i2, 1) + "'"
                        );

                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            i++;
                            if (dr["Binary"] != null)
                            {
                                s += dr["Binary"].ToString();
                            }
                        }
                    dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
                }

                string field41_ = "", field42_ = "", field94_ = "", field98_ = "";

                for (int kk = 0; kk < fieldsPresent.GetUpperBound(0); kk++)
                {
                    if (fieldsPresent[kk, 0] == "3")
                        this.procCode = fieldsPresent[kk, 4];
                    else if (fieldsPresent[kk, 0] == "41")
                        field41_ = fieldsPresent[kk, 4];
                    else if (fieldsPresent[kk, 0] == "42")
                        field42_ = fieldsPresent[kk, 4];
                    else if (fieldsPresent[kk, 0] == "94")
                        field94_ = fieldsPresent[kk, 4];
                    else if (fieldsPresent[kk, 0] == "98")
                        field98_ = fieldsPresent[kk, 4];
                }

                //check if it's POS transaction
                //added on 09/06/2011
                if (clientRequest.Substring(4, 4) != "1420" && clientRequest.Substring(4, 4) != "1421")
                {
                    if (Messages.MessageType(procCode.Substring(0, 2), field41_, field42_, field94_) != Messages.enMessageType.mtUnknown)
                    {
                        switch (Messages.MessageType(procCode.Substring(0, 2), field41_, field42_, field94_))
                        {
                            case Messages.enMessageType.mtPOSBenefitCashWithdrawal:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balPOSBenefitCashWithdrawal, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtPOSCashDeposit:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balPOSCashDeposit, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtPOSCashDepositToCard:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balPOSCashDepositToCard, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtPOSMBanking:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balPOSMBanking, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtPOSPurchaseWithCashBack:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balPOSPurchaseWithCashBack, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtPOSSchoolPayment:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balPOSSchoolPayment, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtPOSCashWithdrawal:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balPOSCashWithdrawal, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtRequestPOS:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balPOSNormalPurchase, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtPOSBalanceEnquiry:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balPOSBalance, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtPOSMiniStatement:
                            {
                                results = this.ResponseMiniStatement(clientRequest, s, fieldsPresent);
                                break;
                            }
                        }
                    }
                    else
                    {
                        switch (Messages.MessageType(clientRequest.Substring(4, 4), procCode.Substring(0, 2), field41_, field42_, field94_))
                        {
                            case Messages.enMessageType.mtRequestCheckBalance:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balBalance, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtRequestMiniStatement:
                            {
                                this.TransactionTypeX = 1;
                                results = this.ResponseMiniStatement(clientRequest, s, fieldsPresent);
                                break;
                            }

                            case Messages.enMessageType.mtRequestCashWithdrawalCoop:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balCashWithdrawalCoop, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtRequestCashWithdrawalVisa:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balCashWithdrawalVisa, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtRequestPOS:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balPOSNormalPurchase, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtRequestReversal:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balReversal, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtRequestMPesaWD:
                            {
                                if (clientRequest.Contains("MOBILE"))
                                    results = this.ResponseBalance(clientRequest, s, enBalance.balMPesaWithdrawal, fieldsPresent);
                                else
                                    results = this.ResponseBalance(clientRequest, s, enBalance.balUtilityPayment, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtRequestAirtimeTopup:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balAirtimeTopup, fieldsPresent);
                                break;
                            }
                            case Messages.enMessageType.mtUtilityPayment:
                            {
                                results = this.ResponseBalance(clientRequest, s, enBalance.balUtilityPayment, fieldsPresent);
                                break;
                            }
                        }
                    }
                }
                else
                    results = this.ResponseBalance(clientRequest, s, enBalance.balReversal, fieldsPresent);

                switch (finalReturnValue)
                {
                    case "22":
                    {
                        if (clientRequest.Substring(4, 4) == "1420" ||
                            clientRequest.Substring(4, 4) == "1421")
                        {
                            //if (!this.fld41_.Contains("POS"))
                            finalReturnValue = "400";
                            //else
                            //    finalReturnValue = "000";
                        }
                        else
                            finalReturnValue = "000";

                        break;

                    }//approved

                    case "9": { finalReturnValue = "118"; break; }//no records
                    case "23": { finalReturnValue = "118"; break; }//no records
                    case "51": { finalReturnValue = "116"; break; }//insufficient amount
                    case "76": { finalReturnValue = "118"; break; }//blocked account
                    case "96": { finalReturnValue = "111"; break; }//unknown error (probably, dbms generated)
                    default: { finalReturnValue = "111"; break; }//unknown error (probably, dbms generated)
                }

                if (this.finalReturnValue.Length > 0)
                    results = results.Replace("***", this.finalReturnValue);
                else
                    results = results.Replace("***", "118");
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return results;
        }

        private int FieldLength(int fieldNumber)
        {
            int i = 0;

            try
            {
                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "select [Length] from [" + company + "$ISO-Defined Data Elements]" +
                    " where [Data Element] = " + fieldNumber.ToString()
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        if (dr["Length"] != null)
                            i = Convert.ToInt32(dr["Length"]);

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return i;
        }

        private string FieldDescription(int fieldNumber)
        {
            string s = "";

            try
            {

                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "select [Usage] from [" + company + "$ISO-Defined Data Elements]" +
                    " where [Data Element] = " + fieldNumber.ToString()
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        if (dr["Usage"] != null)
                            s = dr["Usage"].ToString();

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return s;
        }

        private string TransactionDescription(int VendorLedgerEntryNo)
        {
            string s = "";

            try
            {

                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "select [Description] from [" + company + "$Vendor Ledger Entry]" +
                    " where [Entry No_] = " + VendorLedgerEntryNo.ToString()
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        if (dr["Description"] != null)
                            s = dr["Description"].ToString();

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return s;
        }

        private bool FieldIsVariable(int fieldNumber)
        {
            bool b = false;
            try
            {

                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "select [Variable Field] from [" + company + "$ISO-Defined Data Elements]" +
                    " where [Data Element] = " + fieldNumber.ToString()
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        if (dr["Variable Field"] != null)
                            b = Convert.ToBoolean(dr["Variable Field"]);

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return b;
        }

        private int VariableFieldLength(int fieldNumber)
        {
            int i = 0;

            try
            {

                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "select [Variable Field Length] from [" + company + "$ISO-Defined Data Elements]" +
                    " where [Data Element] = " + fieldNumber.ToString()
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        if (dr["Variable Field Length"] != null)
                            i = Convert.ToInt32(dr["Variable Field Length"]);

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return i;
        }

        private string ResponseBalance(string request, string oldBinary, enBalance balanceType, string[,] fieldsPresent)
        {
            string hiiTranType = "AW", hiiProcessCode = "2.00";

            if (balanceType == enBalance.balPOSNormalPurchase)
            {
                hiiTranType = "VP";
                hiiProcessCode = "3.00";
                balanceType = enBalance.balCashWithdrawalVisa;
            }

            string s = request.Substring(4, 2) + "10";

            this.procCode = this.procCode.Substring(0, 2);

            if (this.procCode.Length != 2) return "Invalid Process Code";

            string NewBitmap = "";

            finalReturnValue = "";

            string part1 = "";
            try
            {
                switch (balanceType)
                {
                    case enBalance.balCashWithdrawalCoop:
                    {
                        s = Messages.MTIDResponseCashWithdrawalCoop;
                        break;
                    }
                    case enBalance.balCashWithdrawalVisa:
                    {
                        s = Messages.MTIDResponseCashWithdrawalVisa;
                        break;
                    }
                    case enBalance.balBalance:
                    {
                        s = Messages.MTIDResponseCheckBalance;
                        break;
                    }
                    case enBalance.balReversal:
                    {
                        s = Messages.MTIDResponseReversalRequest;
                        break;
                    }
                    case enBalance.balPOSNormalPurchase:
                    {
                        s = Messages.MTIDResponsePOS;
                        break;
                    }
                    case enBalance.balMPesaWithdrawal:
                    {
                        s = Messages.MTIDResponseMPesaWD;
                        break;
                    }
                    case enBalance.balAirtimeTopup:
                    {
                        s = Messages.MTIDResponseAirtimeTopup;
                        break;
                    }
                    case enBalance.balPOSCashDeposit:
                    {
                        s = Messages.MTIDResponseReversalRequest;
                        break;
                    }
                    default:
                    {
                        s = request.Substring(4, 2) + "10";
                        break;
                    }
                }

                part1 = s;
                string temp = oldBinary;

                int fieldNo;

                //add field 54
                fieldNo = 54;
                oldBinary = oldBinary.Substring(0, fieldNo - 1) + "1" + oldBinary.Substring(fieldNo, oldBinary.Length - fieldNo);

                //check if m-pesa or airtime topup, then skip fields 50,98,103,104
                if (balanceType == enBalance.balMPesaWithdrawal || balanceType == enBalance.balAirtimeTopup)
                {
                    //add field 50
                    fieldNo = 50;
                    oldBinary = oldBinary.Substring(0, fieldNo - 1) + "0" + oldBinary.Substring(fieldNo, oldBinary.Length - fieldNo);

                    //add field 98
                    fieldNo = 98;
                    oldBinary = oldBinary.Substring(0, fieldNo - 1) + "0" + oldBinary.Substring(fieldNo, oldBinary.Length - fieldNo);

                    //add field 103
                    fieldNo = 103;
                    oldBinary = oldBinary.Substring(0, fieldNo - 1) + "0" + oldBinary.Substring(fieldNo, oldBinary.Length - fieldNo);

                    //add field 104
                    fieldNo = 104;
                    oldBinary = oldBinary.Substring(0, fieldNo - 1) + "0" + oldBinary.Substring(fieldNo, oldBinary.Length - fieldNo);

                }

                //check if POS then add field 104
                if (balanceType == enBalance.balPOSNormalPurchase)
                {
                    //add field 104
                    fieldNo = 104;
                    oldBinary = oldBinary.Substring(0, fieldNo - 1) + "1" + oldBinary.Substring(fieldNo, oldBinary.Length - fieldNo);

                }

                //Console.Write("\nOld Binary:\t");
                //Console.Write(temp);
                //Console.Write("\nNew Binary:\t");
                //Console.Write(oldBinary);

                temp = "";
                //convert binary back to bitmap
                for (int i = 0; i < oldBinary.Length; i += 4)
                {
                    Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                        "select Hexadecimal from [" + company + "$Hexa Binary]" +
                        " where Binary = '" + oldBinary.Substring(i, 4) + "'"
                        );

                    if (dr.HasRows)
                        while (dr.Read())
                            if (dr["Hexadecimal"] != null)
                                temp += dr["Hexadecimal"].ToString();

                    dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
                }

                //Console.Write("\nOld Bitmap:\t");
                //Console.Write(request.Substring(8, 32));
                //Console.Write("\nNew Bitmap:\t");
                //Console.Write(temp + "\n");
                NewBitmap = temp;

                bool f54 = false;
                //append new fields to response.
                string accountNo = "";
                string accountType = "";
                string currency = "";
                string DR_CR_Flag1 = "";
                string DR_CR_Flag2 = "";
                string DR_CR_Flag3 = "";
                string amountCleared = "";
                string amountAvailable = "";
                string amountOverdraft = "";//todo: evaluate
                double amountTransaction = 0, amountTransactionCharges = 0, conversionFactor = 0;

                double balanceCleared = 0, balanceAvailable = 0, availAmt = 0, ledgerAmt = 0;

                string narrative = "";

                for (int i = 0; i < fieldsPresent.GetUpperBound(0); i++)
                {
                    narrative = "";

                    if (fieldsPresent[i, 0] == "2") accountNo = fieldsPresent[i, 4];
                    if (fieldsPresent[i, 0] == "3") accountType = fieldsPresent[i, 4].Substring(2, 2);
                    if (fieldsPresent[i, 0] == "4") amountTransaction = Convert.ToDouble(fieldsPresent[i, 4]);
                    if (fieldsPresent[i, 0] == "6") amountTransactionCharges = Convert.ToDouble(fieldsPresent[i, 4]);
                    if (fieldsPresent[i, 0] == "10") conversionFactor = Convert.ToDouble(fieldsPresent[i, 4]);
                    if (fieldsPresent[i, 0] == "39") fieldsPresent[i, 4] = "***";//mark for later update
                    if (fieldsPresent[i, 0] == "49") currency = fieldsPresent[i, 4];

                    if (Convert.ToInt32(fieldsPresent[i, 0]) > 54 && !f54)//insert field 54 first
                    {
                        int errCode = 0, retCode = 0;
                        string errorMsg = "";

                        {
                            switch (balanceType)
                            {
                                case enBalance.balUtilityPayment:
                                {
                                    ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(2,this.atmAmount),
                                        "AW", "1.00", this.DateToday2, this.TimeToday2,
                                        this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                        this.atmAccountNo.ToUpper(), "", "UTILITY PAYMENT", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                        ref availAmt, ref ledgerAmt,
                                        ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balUtilityPayment, this.RetrievalReferenceNo
                                        );

                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);
                                    TransactionTypeX = 2;

                                    balanceCleared = ledgerAmt * 100;
                                    balanceAvailable = availAmt * 100;

                                    break;
                                }

                                case enBalance.balCashWithdrawalCoop:
                                {
                                    ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(2, this.atmAmount),
                                        "AW", "1.00", this.DateToday2, this.TimeToday2,
                                        this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                        this.atmAccountNo.ToUpper(), "", "CASH W/D - COOP BANK", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                        ref availAmt, ref ledgerAmt,
                                        ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balCashWithdrawalCoop, this.RetrievalReferenceNo
                                        );

                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);
                                    TransactionTypeX = 2;

                                    balanceCleared = ledgerAmt * 100;
                                    balanceAvailable = availAmt * 100;

                                    break;
                                }

                                case enBalance.balCashWithdrawalVisa:
                                {
                                    if (hiiProcessCode == "3.00")//supermarket
                                    {
                                        ATM.transaction(ATM.MinimumBalance,
                                            hiiTranType, hiiProcessCode, this.DateToday2, this.TimeToday2,
                                            this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                            this.atmAccountNo.ToUpper(), "", "POS Normal Purchase".ToUpper(), this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                            ref availAmt, ref ledgerAmt,
                                            ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balPOSNormalPurchase, this.RetrievalReferenceNo
                                            );
                                        TransactionTypeX = 6;
                                    }
                                    else//visa w/d
                                    {
                                        ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(3, this.atmAmount),
                                            hiiTranType, hiiProcessCode, this.DateToday2, this.TimeToday2,
                                            this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                            this.atmAccountNo.ToUpper(), "", "CASH W/D - VISA ATM", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                            ref availAmt, ref ledgerAmt,
                                            ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balCashWithdrawalVisa, this.RetrievalReferenceNo
                                            );
                                        TransactionTypeX = 3;

                                    }
                                    finalReturnValue = retCode.ToString();

                                    this.returnCodeFromDB = Convert.ToInt32(retCode);

                                    balanceCleared = ledgerAmt * 100;
                                    balanceAvailable = availAmt * 100;

                                    break;
                                }

                                case enBalance.balReversal:
                                {
                                    ATM.transaction(ATM.MinimumBalance,
                                        "AW", "2.00", this.DateToday2, this.TimeToday2,
                                        this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                        this.atmAccountNo.ToUpper(), "", "REVERSAL", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                        ref availAmt, ref ledgerAmt,
                                        ref narrative, ref retCode, ref errCode, ref errorMsg, true, (int)enBalance.balReversal, this.RetrievalReferenceNo
                                        );

                                    TransactionTypeX = 4;
                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);

                                    balanceCleared = ledgerAmt * 100;
                                    balanceAvailable = availAmt * 100;

                                    break;
                                }
                                case enBalance.balPOSNormalPurchase:
                                {
                                    switch (procCode)
                                    {
                                        case "00":
                                        {
                                            this.atmMpesaTransactionDescription = "PS-Purchase".ToUpper();
                                            break;
                                        }
                                        case "01":
                                        {
                                            this.atmMpesaTransactionDescription = "PS-Cash W/D".ToUpper();
                                            break;
                                        }
                                        case "09":
                                        {
                                            this.atmMpesaTransactionDescription = "PS-Cashback".ToUpper();
                                            break;
                                        }
                                        case "20":
                                        {
                                            this.atmMpesaTransactionDescription = "PS-Cash Pur.".ToUpper();
                                            break;
                                        }
                                        case "21":
                                        {
                                            this.atmMpesaTransactionDescription = "PS-Cash Dep.".ToUpper();
                                            break;
                                        }
                                        case "31":
                                        {
                                            this.atmMpesaTransactionDescription = "PS-Bal Enq.".ToUpper();
                                            break;
                                        }
                                        default:
                                        {
                                            this.atmMpesaTransactionDescription = "PS-UNKNOWN".ToUpper();
                                            break;
                                        }
                                    }
                                    ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(2, this.atmAmount),
                                        "VP", "3.00", this.DateToday2, this.TimeToday2,
                                        this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                        this.atmAccountNo.ToUpper(), "", this.atmMpesaTransactionDescription, this.atmAmount, this.CardAcceptorTerminalID,
                                        this.atmLocation, ref availAmt, ref ledgerAmt,
                                        ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balPOSNormalPurchase, this.RetrievalReferenceNo
                                        );

                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);
                                    TransactionTypeX = 6;

                                    balanceCleared = Convert.ToDouble(ledgerAmt) * 100;
                                    balanceAvailable = Convert.ToDouble(availAmt) * 100;

                                    break;
                                }

                                case enBalance.balMPesaWithdrawal://or airtime topup or utility
                                {
                                    if (this.atmMpesaTransactionDescription == "MPMOBILE")
                                        ATM.WithdrawMpesa(ATM.MinimumBalance + ATM.ChargesTotalAmount(7, this.atmAmount),
                                            "MW", "6.00", this.DateToday2, this.TimeToday2,
                                            this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                            this.atmAccountNo.ToUpper(), "", "M-PESA W/D", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID, this.atmMpesaPhoneNumber,
                                            ref availAmt, ref ledgerAmt,
                                            ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balMPesaWithdrawal, this.RetrievalReferenceNo
                                            );
                                    else
                                    {
                                        if (this.atmMpesaTransactionDescription.Substring(0, 6) == "MOBILE")
                                            ATM.WithdrawMpesa(ATM.MinimumBalance + ATM.ChargesTotalAmount(8, this.atmAmount),
                                                "AT", "7.00", this.DateToday2, this.TimeToday2,
                                                this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                                this.atmAccountNo.ToUpper(), "", "AIRTIME PURCHASE", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID, this.atmMpesaPhoneNumber,
                                                ref availAmt, ref ledgerAmt,
                                                ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balAirtimeTopup, this.RetrievalReferenceNo
                                                );
                                        else
                                            ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(5, this.atmAmount),
                                                "UT", "4.00", this.DateToday2, this.TimeToday2,
                                                this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                                this.atmAccountNo.ToUpper(), "", "UTILITY PAYMENT", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                                ref availAmt, ref ledgerAmt,
                                                ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balUtilityPayment, this.RetrievalReferenceNo
                                                );
                                    }

                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);
                                    TransactionTypeX = 5;

                                    balanceCleared = Convert.ToDouble(ledgerAmt) * 100;
                                    balanceAvailable = Convert.ToDouble(availAmt) * 100;

                                    break;
                                }
                                case enBalance.balPOSBenefitCashWithdrawal:
                                {
                                    ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(12, this.atmAmount),
                                        "AW", "1.00", this.DateToday2, this.TimeToday2,
                                        this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                        this.atmAccountNo.ToUpper(), "", "POS-BENEFICIAL CASH W/D", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                        ref availAmt, ref ledgerAmt,
                                        ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balPOSBenefitCashWithdrawal, this.RetrievalReferenceNo
                                        );

                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);
                                    TransactionTypeX = 2;

                                    balanceCleared = ledgerAmt * 100;
                                    balanceAvailable = availAmt * 100;

                                    break;
                                }

                                case enBalance.balPOSCashDeposit:
                                {
                                    ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(11, this.atmAmount),
                                        "AW", "1.00", this.DateToday2, this.TimeToday2,
                                        this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                        this.atmAccountNo.ToUpper(), "", "POS-CASH DEPOSIT", -this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                        ref availAmt, ref ledgerAmt,
                                        ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balPOSCashDeposit, this.RetrievalReferenceNo
                                        );

                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);
                                    TransactionTypeX = 2;

                                    balanceCleared = ledgerAmt * 100;
                                    balanceAvailable = availAmt * 100;

                                    break;
                                }

                                case enBalance.balPOSCashDepositToCard:
                                {
                                    ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(13, this.atmAmount),
                                        "AW", "1.00", this.DateToday2, this.TimeToday2,
                                        this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                        this.atmAccountNo.ToUpper(), "", "POS-CASH DEPOSIT CARD", -this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                        ref availAmt, ref ledgerAmt,
                                        ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balPOSCashDepositToCard, this.RetrievalReferenceNo
                                        );

                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);
                                    TransactionTypeX = 2;

                                    balanceCleared = ledgerAmt * 100;
                                    balanceAvailable = availAmt * 100;

                                    break;
                                }

                                case enBalance.balPOSCashWithdrawal:
                                {
                                    ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(15, this.atmAmount),
                                        "AW", "1.00", this.DateToday2, this.TimeToday2,
                                        this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                        this.atmAccountNo.ToUpper(), "", "POS-CASH WITHDRAWAL", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                        ref availAmt, ref ledgerAmt,
                                        ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balPOSCashWithdrawal, this.RetrievalReferenceNo
                                        );

                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);
                                    TransactionTypeX = 2;

                                    balanceCleared = ledgerAmt * 100;
                                    balanceAvailable = availAmt * 100;

                                    break;
                                }

                                case enBalance.balPOSMBanking:
                                {
                                    ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(14, this.atmAmount),
                                        "AW", "1.00", this.DateToday2, this.TimeToday2,
                                        this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                        this.atmAccountNo.ToUpper(), "", "POS-MBANKING", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                        ref availAmt, ref ledgerAmt,
                                        ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balPOSMBanking, this.RetrievalReferenceNo
                                        );

                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);
                                    TransactionTypeX = 2;

                                    balanceCleared = ledgerAmt * 100;
                                    balanceAvailable = availAmt * 100;

                                    break;
                                }

                                case enBalance.balPOSPurchaseWithCashBack:
                                {
                                    ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(10, this.atmAmount),
                                        "AW", "1.00", this.DateToday2, this.TimeToday2,
                                        this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                        this.atmAccountNo.ToUpper(), "", "POS-PURCH W CASHBACK", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                        ref availAmt, ref ledgerAmt,
                                        ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balPOSPurchaseWithCashBack, this.RetrievalReferenceNo
                                        );

                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);
                                    TransactionTypeX = 2;

                                    balanceCleared = ledgerAmt * 100;
                                    balanceAvailable = availAmt * 100;

                                    break;
                                }

                                case enBalance.balPOSSchoolPayment:
                                {
                                    ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(9, this.atmAmount),
                                        "AW", "1.00", this.DateToday2, this.TimeToday2,
                                        this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                        this.atmAccountNo.ToUpper(), "", "POS-SCHOOL FEES", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                        ref availAmt, ref ledgerAmt,
                                        ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balPOSSchoolPayment, this.RetrievalReferenceNo
                                        );

                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);
                                    TransactionTypeX = 2;

                                    balanceCleared = ledgerAmt * 100;
                                    balanceAvailable = availAmt * 100;

                                    break;
                                }

                                default:
                                {
                                    if (this.fld94_.Contains("40401PISO"))
                                    {
                                        balanceType = enBalance.balPOSBalance;

                                        ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(10, this.atmAmount),
                                            "AW", "1.00", this.DateToday2, this.TimeToday2,
                                            this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                                            this.atmAccountNo.ToUpper(), "", "POS-BALANCE ENQUIRY", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                                            ref availAmt, ref ledgerAmt,
                                            ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balPOSBalance, this.RetrievalReferenceNo
                                            );

                                        ATM.BalanceEnquiry(
                                            "AW", "1.00", this.DateToday2, this.TimeToday2,
                                            this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceID.ToUpper(),
                                            this.atmAccountNo.ToUpper(), "", "POS-BALANCE ENQUIRY", this.atmAmount, this.atmLocation,
                                            ref availAmt, ref ledgerAmt,
                                            ref narrative, ref retCode, ref errCode, ref errorMsg, false
                                            );
                                    }
                                    else
                                    {
                                        ATM.BalanceEnquiry(
                                            "AW", "1.00", this.DateToday2, this.TimeToday2,
                                            this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceID.ToUpper(),
                                            this.atmAccountNo.ToUpper(), "", "BALANCE ENQUIRY", this.atmAmount, this.atmLocation,
                                            ref availAmt, ref ledgerAmt,
                                            ref narrative, ref retCode, ref errCode, ref errorMsg, false
                                            );
                                    }

                                    finalReturnValue = retCode.ToString();
                                    this.returnCodeFromDB = Convert.ToInt32(retCode);
                                    TransactionTypeX = 0;

                                    balanceCleared = Convert.ToDouble(ledgerAmt) * 100;
                                    balanceAvailable = Convert.ToDouble(availAmt) * 100;

                                    break;
                                }
                            }
                        }

                        string successCode = "";

                        switch (this.returnCodeFromDB)
                        {
                            case 22:
                            {
                                successCode = "0";
                                break;
                            }
                            case 51:
                            {
                                successCode = "1";
                                break;
                            }
                            case 23:
                            {
                                successCode = "2";
                                break;
                            }
                            case 76:
                            {
                                successCode = "3";
                                break;
                            }
                            case 96:
                            {
                                successCode = "4";
                                break;
                            }
                        }

                        if (balanceType != enBalance.balReversal)
                            new Database().WriteDB(
                                "INSERT INTO [" + company + "$ATM Log Entries]" +
                                " ([Date Time], [Account No], Amount, [ATM No]," +
                                " [ATM Location], [Transaction Type], [Return Code]," +
                                "[Trace ID],[Card No_],[Account No_],[ATM Amount],[Withdrawal Location],[Reference No]) VALUES (" +
                                "'" + Logs.FormatDate(DateTime.Now) + "'," +
                                " '" + Logs.ValidateEntry(this.atmAccountNo.ToUpper()) + "'," +
                                " " + this.atmAmount.ToString() + "," +
                                " '" + Logs.ValidateEntry(this.atmUnitID.ToUpper()) + "'," +
                                " '" + Logs.ValidateEntry(this.atmLocation.ToUpper()) + "'," +
                                " " + Convert.ToInt32(balanceType).ToString() + "," + successCode + ",'" +
                                this.atmTraceID.ToUpper() + "','" + this.atmAccountNo.ToUpper() + "','" +
                                ATM.CustomerNo(this.atmAccountNo.ToUpper()) + "'," + this.atmAmount.ToString() + ",'" +
                                this.atmLocation + "','" + Logs.ValidateEntry(RetrievalReferenceNo) + "')"
                                //this.CardAcceptorTerminalID + "')"
                                );
                        else
                            if (ATM.TraceIDExists(this.atmTraceID.ToUpper(), ATM.CustomerNo(this.atmAccountNo.ToUpper()), this.atmAmount) &&
                                !ATM.ReversalTraceIDExists(this.atmTraceIDRev.ToUpper(), ATM.CustomerNo(this.atmAccountNo.ToUpper()), this.atmAmount))
                                new Database().WriteDB(
                                    "INSERT INTO [" + company + "$ATM Log Entries]" +
                                    " ([Date Time], [Account No], Amount, [ATM No]," +
                                    " [ATM Location], [Transaction Type], [Return Code],[Reference No]," +
                                    "[Trace ID],[Card No_],[Account No_],[ATM Amount],[Withdrawal Location],[Reference No]) VALUES (" +
                                    "CONVERT(DATETIME, '" + Logs.FormatDate(DateTime.Now) + "', 102)," +
                                    " '" + Logs.ValidateEntry(this.atmAccountNo.ToUpper()) + "'," +
                                    " " + this.atmAmount.ToString() + "," +
                                    " '" + Logs.ValidateEntry(this.atmUnitID.ToUpper()) + "'," +
                                    " '" + Logs.ValidateEntry(this.atmLocation.ToUpper()) + "'," +
                                    " " + this.TransactionTypeX + "," + successCode + ",'" +
                                    this.atmTraceID.ToUpper() + "','" + this.atmAccountNo.ToUpper() + "','" +
                                    ATM.CustomerNo(this.atmAccountNo.ToUpper()) + "'," + this.atmAmount.ToString() + ",'" +
                                    this.atmLocation + "','" + Logs.ValidateEntry(RetrievalReferenceNo) + "')"
                                    );

                        if (balanceAvailable < 0)
                            amountOverdraft = (balanceAvailable * (-1)).ToString();
                        else
                            amountOverdraft = "0";

                        if (balanceCleared < 0) DR_CR_Flag1 = "D"; else DR_CR_Flag1 = "C";
                        if (balanceAvailable < 0) DR_CR_Flag2 = "D"; else DR_CR_Flag2 = "C";
                        if (balanceAvailable < 0) DR_CR_Flag3 = "D"; else DR_CR_Flag3 = "C";

                        if (balanceCleared < 0)
                            balanceCleared *= (-1);

                        if (balanceAvailable < 0)
                            balanceAvailable *= (-1);

                        char[] c = "-".ToCharArray();

                        //trim decimals
                        if (balanceCleared.ToString().Contains("."))
                            balanceCleared = Convert.ToDouble(balanceCleared.ToString().Substring(0, balanceCleared.ToString().IndexOf(".")));

                        //ensure amount is 12 characters long
                        if (balanceCleared.ToString().Trim(c).Length < 12)
                            for (int n = 0; n < (12 - balanceCleared.ToString().Trim(c).Length); n++)
                                amountCleared += "0";
                        amountCleared += balanceCleared.ToString();

                        //trim decimals
                        if (balanceAvailable.ToString().Contains("."))
                            balanceAvailable = Convert.ToDouble(balanceAvailable.ToString().Substring(0, balanceAvailable.ToString().IndexOf(".")));

                        //ensure amount is 12 characters long
                        if (balanceAvailable.ToString().Trim(c).Length < 12)
                            for (int n = 0; n < (12 - balanceAvailable.ToString().Trim(c).Length); n++)
                                amountAvailable += "0";
                        amountAvailable += balanceAvailable.ToString();

                        //trim decimals
                        if (amountOverdraft.ToString().Contains("."))
                            amountOverdraft = amountOverdraft.ToString().Substring(0, amountOverdraft.ToString().IndexOf("."));

                        int l = amountOverdraft.Length;
                        //ensure amount is 12 characters long
                        if (l < 12)
                            for (int n = 0; n < (12 - l); n++)
                                amountOverdraft = "0" + amountOverdraft;

                        temp += "060";//variable length of 60 xters.

                        if (balanceType == enBalance.balCashWithdrawalCoop || balanceType == enBalance.balCashWithdrawalVisa)
                        {
                            temp += accountType + "11" + currency + DR_CR_Flag1 + amountCleared +
                                    accountType + "12" + currency + DR_CR_Flag2 + amountAvailable +
                                    accountType + "13" + currency + DR_CR_Flag3 + amountOverdraft;
                        }
                        else
                        {
                            //if (balanceType == enBalance.balPOS)
                            //    temp += accountType + "02" + currency + DR_CR_Flag1 + amountCleared +
                            //        accountType + "01" + currency + DR_CR_Flag2 + amountAvailable;
                            //else
                            //    temp += accountType + "01" + currency + DR_CR_Flag1 + amountCleared +
                            //        accountType + "02" + currency + DR_CR_Flag2 + amountAvailable +
                            //        accountType + "03" + currency + DR_CR_Flag3 + amountOverdraft;
                            temp += accountType + "01" + currency + DR_CR_Flag1 + amountCleared +
                                    accountType + "02" + currency + DR_CR_Flag2 + amountAvailable +
                                    accountType + "03" + currency + DR_CR_Flag3 + amountOverdraft;
                        }

                        f54 = !f54;
                    }

                    //check if m-pesa or airtime topup, then skip fields 50,98,103,104
                    if (balanceType == enBalance.balMPesaWithdrawal || balanceType == enBalance.balAirtimeTopup)
                    {
                        if (fieldsPresent[i, 0] != "50" &&
                            fieldsPresent[i, 0] != "98" &&
                            fieldsPresent[i, 0] != "103" &&
                            fieldsPresent[i, 0] != "104")
                        {
                            //check if variable field, then pad with length
                            if (Convert.ToBoolean(fieldsPresent[i, 2]))
                            {
                                int y = fieldsPresent[i, 1].Length;//length no. of digits
                                int z = Convert.ToInt32(fieldsPresent[i, 3]);//padding length
                                if (z > y)
                                    for (int x = 0; x < (z - y); x++)
                                        temp += "0";

                                temp += fieldsPresent[i, 1];
                            }

                            //trim decimals
                            if (availAmt.ToString().Contains("."))
                                availAmt = Convert.ToDouble(availAmt.ToString().Substring(0, availAmt.ToString().IndexOf(".")));

                            //trim decimals
                            if (ledgerAmt.ToString().Contains("."))
                                ledgerAmt = Convert.ToDouble(ledgerAmt.ToString().Substring(0, ledgerAmt.ToString().IndexOf(".")));

                            if (fieldsPresent[i, 0] == "44")
                                fieldsPresent[i, 4] =
                                    "Balance Available: " + availAmt +
                                    "\nLedger Amount: " + ledgerAmt;

                            temp += fieldsPresent[i, 4];
                        }
                    }
                    else
                    {
                        //check if variable field, then pad with length
                        if (Convert.ToBoolean(fieldsPresent[i, 2]))
                        {
                            int y = fieldsPresent[i, 1].Length;//length no. of digits
                            int z = Convert.ToInt32(fieldsPresent[i, 3]);//padding length
                            if (z > y)
                                for (int x = 0; x < (z - y); x++)
                                    temp += "0";

                            temp += fieldsPresent[i, 1];
                        }

                        //trim decimals
                        if (availAmt.ToString().Contains("."))
                            availAmt = Convert.ToDouble(availAmt.ToString().Substring(0, availAmt.ToString().IndexOf(".")));

                        //trim decimals
                        if (ledgerAmt.ToString().Contains("."))
                            ledgerAmt = Convert.ToDouble(ledgerAmt.ToString().Substring(0, ledgerAmt.ToString().IndexOf(".")));

                        if (fieldsPresent[i, 0] == "44")
                            fieldsPresent[i, 4] =
                                "Balance Available: " + availAmt +
                                "\nLedger Amount: " + ledgerAmt;

                        temp += fieldsPresent[i, 4];
                    }
                }

                s += temp;
                string messageLength = s.Length.ToString();

                if (messageLength.Length < 4)
                    for (int i3 = 0; i3 < (4 - messageLength.Length); i3++)
                        messageLength = "0" + messageLength;

                s = messageLength + s;

                //if (balanceType==enBalance.balCashWithdrawalVisa)
                //    s += "20IDENTIFICATION CODE.";

                //s = part1 +NewBitmap+ temp;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return s;
        }

        private string ResponseMiniStatement(string request, string oldBinary, string[,] fieldsPresent)
        {
            string s = Messages.MTIDResponseMiniStatement;

            try
            {
                string amount = "", description = "", temp3 = "";

                int aLen, dLen, k;

                #region Decode Request

                string temp = oldBinary;

                int fieldNo;

                //add field 124
                fieldNo = 124;
                oldBinary = oldBinary.Substring(0, fieldNo - 1) + "1" + oldBinary.Substring(fieldNo, oldBinary.Length - fieldNo);

                //Console.Write("Old Binary:\t");
                //Console.Write(temp);
                //Console.Write("\nNew Binary:\t");
                //Console.Write(oldBinary);

                temp = "";
                //convert binary back to bitmap
                for (int i = 0; i < oldBinary.Length; i += 4)
                {
                    Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                        "select Hexadecimal from [" + company + "$Hexa Binary]" +
                        " where Binary = '" + oldBinary.Substring(i, 4) + "'"
                        );

                    if (dr.HasRows)
                        while (dr.Read())
                            if (dr["Hexadecimal"] != null)
                                temp += dr["Hexadecimal"].ToString();

                    dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
                }

                //Console.Write("\nOld Bitmap:\t");
                //Console.Write(request.Substring(8, 32));
                //Console.Write("\nNew Bitmap:\t");
                //Console.Write(temp + "\n");


                string transactionType = "";
                string accountNo = "";
                string currency = "KES";
                int ub = fieldsPresent.GetUpperBound(0);
                for (int i = 0; i < ub; i++)
                {
                    //get account number
                    if (fieldsPresent[i, 0] == "2")
                        accountNo = fieldsPresent[i, 4];

                    ////get transaction type
                    //if (fieldsPresent[i, 0] == "3")
                    //    transactionType = fieldsPresent[i, 4].Substring(0, 2);

                    //check if variable field, then pad with length
                    if (Convert.ToBoolean(fieldsPresent[i, 2]))
                    {
                        int y = fieldsPresent[i, 1].Length;//length no. of digits
                        int z = Convert.ToInt32(fieldsPresent[i, 3]);//padding length
                        if (z > y)
                            for (int x = 0; x < (z - y); x++)
                                temp += "0";

                        temp += fieldsPresent[i, 1];
                    }
                    temp += fieldsPresent[i, 4];
                }

                #endregion

                //construct mini statement
                int p = 0;

                double availableAmount =
                    ATM.AvailableAmount(ATM.CustomerNo(accountNo)) -
                    ATM.AtmTransactions(ATM.CustomerNo(accountNo)) -
                    ATM.UnclearedCheques(ATM.CustomerNo(accountNo));

                System.Data.SqlClient.SqlDataReader dr2 = new Database().ReadDB(
                    "select top 8 * from [" + company + "$Detailed Vendor Ledg_ Entry]" +
                    " where [Vendor No_] = '" + Logs.ValidateEntry(this.VendorNo(accountNo)) + "'" +
                    " order by [Posting Date] desc;"
                    );

                string miniStatement = "";
                string miniStatementFinal = "";
                if (dr2.HasRows)
                {
                    #region Mini Statement Transactions
                    while (dr2.Read())
                    {
                        temp3 = "";

                        int amountTemp = Convert.ToInt32(dr2["Amount"]);

                        amount = amountTemp.ToString() + ".00";

                        if (amount.Contains("-"))
                            amount = amount.Substring(1);

                        description = this.TransactionDescription(
                            Convert.ToInt32(dr2["Vendor Ledger Entry No_"]));

                        //get transaction type
                        if (Convert.ToDouble(dr2["Amount"]) < 0)
                            transactionType = "21";
                        else
                            transactionType = "01";

                        aLen = amount.ToString().Length;
                        if (aLen < 12)
                            for (int m = 0; m < (12 - aLen); m++)
                                amount = amount + " ";

                        if (description.Length > 40) description = description.Substring(0, 40);

                        dLen = description.ToString().Length;
                        if (dLen < 40)
                            for (int m = 0; m < (40 - dLen); m++)
                                description = description + " ";

                        miniStatement = Logs.FormatDateWithoutSymbols(
                            Convert.ToDateTime(dr2["Posting Date"])
                            ).ToString() +
                                        "|" + transactionType +
                                        "|" + amount +
                                        "|" + currency +
                                        "|" + description +
                                        "|F|T" +
                                        "|" + amount +
                                        "|" + currency;

                        k = miniStatement.Length.ToString().Length;

                        if (k < 3)
                            for (int m = 0; m < (3 - k); m++)
                                temp3 += "0";

                        temp3 += miniStatement.Length.ToString();

                        miniStatement = temp3 + miniStatement;

                        temp3 = "";
                        if (p.ToString().Length < 2)
                            for (int m = 0; m < (2 - p.ToString().Length); m++)
                                temp3 += "0";

                        temp3 += p.ToString();

                        miniStatement = "M" + temp3 + miniStatement;

                        miniStatementFinal += miniStatement;

                        p++;
                    }

                    temp3 = "";

                    #endregion

                    #region Mini Statement Balance

                    //if (!availableAmount.ToString().Contains("."))
                    //    amount = availableAmount.ToString() + ".00";
                    //else
                    //    amount = availableAmount.ToString();

                    //if (amount.Contains("-"))
                    //    amount = amount.Substring(1);

                    //description = "BALANCE";

                    ////get transaction type
                    //if (availableAmount < 0)
                    //    transactionType = "21";
                    //else
                    //    transactionType = "01";

                    //aLen = amount.ToString().Length;
                    //if (aLen < 12)
                    //    for (int m = 0; m < (12 - aLen); m++)
                    //        amount = amount + " ";

                    //if (description.Length > 15) description = description.Substring(0, 15);

                    //dLen = description.ToString().Length;
                    //if (dLen < 15)
                    //    for (int m = 0; m < (15 - dLen); m++)
                    //        description = description + " ";

                    //miniStatement = cUtilities.FormatDateWithoutSymbols(DateTime.Now).ToString()+
                    //    "|" + transactionType +
                    //    "|" + amount +
                    //    "|" + currency +
                    //    "|" + description +
                    //    "|F|T" +
                    //    "|" + amount +
                    //    "|" + currency;

                    //k = miniStatement.Length.ToString().Length;

                    //temp3 = "";
                    //if (k < 3)
                    //    for (int m = 0; m < (3 - k); m++)
                    //        temp3 += "0";

                    //temp3 += miniStatement.Length.ToString();

                    //miniStatement = temp3 + miniStatement;

                    //temp3 = "";
                    //if (p.ToString().Length < 2)
                    //    for (int m = 0; m < (2 - p.ToString().Length); m++)
                    //        temp3 += "0";

                    //temp3 += p.ToString();

                    //miniStatement = "M" + temp3 + miniStatement;

                    //miniStatementFinal += miniStatement;

                    //p++;

                    #endregion

                    #region Get Balance
                    //add OTB (Open To Buy) i.e. balance after the last n number of transactions
                    miniStatementFinal += "OTB016";

                    double ledgerAmount = ATM.AvailableAmount(VendorNo(accountNo)) -
                                          ATM.AtmTransactions(VendorNo(accountNo));

                    availableAmount = ledgerAmount -
                                      (ATM.MinimumBalance + (ATM.UnclearedCheques(VendorNo(accountNo))));

                    //convert to cents
                    amount = Convert.ToInt32(availableAmount).ToString() + "00";

                    aLen = amount.ToString().Length;
                    if (aLen < 12)
                        for (int m = 0; m < (12 - aLen); m++)
                            amount = "0" + amount;

                    //add currency
                    miniStatementFinal += amount + "|KES";

                    #endregion

                    string temp4 = "";
                    temp4 = "";
                    if (miniStatementFinal.Length.ToString().Length < 5)
                        for (int m = 0; m < (5 - miniStatementFinal.Length.ToString().Length); m++)
                            temp4 += "0";

                    temp4 += miniStatementFinal.Length.ToString();

                    //miniStatementFinal = "CNT" + temp4 + miniStatementFinal;
                    miniStatementFinal = "CNT00208" + miniStatementFinal;

                    temp4 = "";
                    if (miniStatementFinal.Length.ToString().Length < 3)
                        for (int m = 0; m < (3 - miniStatementFinal.Length.ToString().Length); m++)
                            temp4 += "0";

                    miniStatementFinal = temp4 + miniStatementFinal.Length.ToString() + miniStatementFinal;

                }

                dr2.Close();

                temp += miniStatementFinal;

                s += temp;

                string sLength = s.Length.ToString();

                if (sLength.Length < 4)
                    for (int sl = 0; sl < (4 - sLength.Length); sl++)
                        sLength = "0" + sLength;

                s = sLength + s;

                this.TransactionTypeX = 1;

                if (this.fld94_.Contains("40401PISO"))
                {
                    this.TransactionTypeX = 17;

                    double availAmt = 0, ledgerAmt = 0;

                    int errCode = 0, retCode = 0;
                    string errorMsg = "";

                    string narrative = "";

                    ATM.transaction(ATM.MinimumBalance + ATM.ChargesTotalAmount(18, this.atmAmount),
                        "AW", "1.00", this.DateToday2, this.TimeToday2,
                        this.atmUnitID.ToUpper(), this.atmTraceID.ToUpper(), this.atmTraceIDRev.ToUpper(),
                        this.atmAccountNo.ToUpper(), "", "POS-MINI STATEMENT", this.atmAmount, this.atmLocation, this.CardAcceptorTerminalID,
                        ref availAmt, ref ledgerAmt,
                        ref narrative, ref retCode, ref errCode, ref errorMsg, false, (int)enBalance.balPOSMiniStatement, this.RetrievalReferenceNo
                        );

                }

                new Database().WriteDB(
                    "INSERT INTO [" + company + "$ATM Log Entries]" +
                    " ([Date Time], [Account No], Amount, [ATM No]," +
                    " [ATM Location], [Transaction Type], [Return Code]," +
                    "[Trace ID],[Card No_],[Account No_],[ATM Amount],[Withdrawal Location],[Reference No]) VALUES (" +
                    "CONVERT(DATETIME, '" + Logs.FormatDate(DateTime.Now) + "', 102)," +
                    " '" + Logs.ValidateEntry(this.atmAccountNo.ToUpper()) + "'," +
                    " " + this.atmAmount.ToString() + "," +
                    " '" + Logs.ValidateEntry(this.atmUnitID.ToUpper()) + "'," +
                    " '" + Logs.ValidateEntry(this.atmLocation.ToUpper()) + "'," +
                    " " + this.TransactionTypeX + ",0,'" +
                    this.atmTraceID.ToUpper() + "','" + this.atmAccountNo.ToUpper() + "','" +
                    ATM.CustomerNo(this.atmAccountNo.ToUpper()) + "'," + this.atmAmount.ToString() + ",'" +
                    this.atmLocation + "','" + Logs.ValidateEntry(RetrievalReferenceNo) + "')"
                    );

            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return s;
        }

        private bool SignOnRequest(string signOnRequest)
        {
            bool b = false;

            try
            {
                b = (signOnRequest.Substring(4, 4) == "1804" &&
                     signOnRequest.Substring(signOnRequest.Length - 9, 3) == "801");
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return b;
        }

        private string SignOnReply(string signOnRequest)
        {
            string s = "";

            try
            {
                s = "00441814" +
                    signOnRequest.Substring(8, signOnRequest.Length - 17) +
                    "800" +
                    signOnRequest.Substring(signOnRequest.Length - 6);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return s;
        }

        private bool EchoRequest(string echoRequest)
        {
            bool b = false;

            try
            {
                b = (echoRequest.Substring(4, 4) == "1804" &&
                     echoRequest.Substring(echoRequest.Length - 9, 3) == "831");
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return b;
        }

        private string EchoReply(string echoRequest)
        {
            string s = "";

            try
            {
                s = "00441814" +
                    echoRequest.Substring(8, echoRequest.Length - 17) +
                    "830" +
                    echoRequest.Substring(echoRequest.Length - 6);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return s;
        }

        //private string CustomerNo(string accountNo)
        //{
        //    string s = "";

        //    try
        //    {

        //        cConnect cnt = new cConnect();SQL_DB.SqlDataReader dr = cnt.ReadDB(
        //            "select [No_] from [" + company + "$Customer]" +
        //            " where [ATM Account No] = '" + cUtilities.ValidateEntry(accountNo) + "'"
        //            );

        //        if (dr.HasRows)
        //            while (dr.Read())
        //                if (dr["No_"] != null)
        //                    s = dr["No_"].ToString();

        //        dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Clear();
        //    }
        //    return s;
        //}

        private string VendorNo(string accountNo)
        {
            string s = "";

            try
            {

                Database cnt = new Database(); System.Data.SqlClient.SqlDataReader dr = cnt.ReadDB(
                    "select [No_] from [" + company + "$Vendor]" +
                    " where [ATM No_] = '" + Logs.ValidateEntry(accountNo) + "'"
                    );

                if (dr.HasRows)
                    while (dr.Read())
                        if (dr["No_"] != null)
                            s = dr["No_"].ToString();

                dr.Close(); //dr.Dispose(); dr = null; cnt.Dispose(); cnt = null;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return s;
        }

        private string DateToday
        {
            get
            {
                string dateToday = "";

                try
                {
                    string y, m, d;

                    y = DateTime.Now.Year.ToString().Substring(2, 2);

                    m = DateTime.Now.Month.ToString();

                    if (m.Length == 1)
                        m = "0" + m;

                    d = DateTime.Now.Day.ToString();

                    if (d.Length == 1)
                        d = "0" + d;

                    dateToday = y + m + d;
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
                return dateToday;
            }
        }

        private string DateToday2
        {
            get
            {
                string dateToday = "";

                try
                {
                    string y, m, d;

                    y = DateTime.Now.Year.ToString();

                    m = DateTime.Now.Month.ToString();

                    if (m.Length == 1)
                        m = "0" + m;

                    d = DateTime.Now.Day.ToString();

                    if (d.Length == 1)
                        d = "0" + d;

                    dateToday = d + m + y;
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
                return dateToday;
            }
        }

        private string TimeToday2
        {
            get
            {
                string timeToday = "";

                try
                {
                    string h, m, s;

                    h = DateTime.Now.Hour.ToString();

                    if (h.Length == 1)
                        h = "0" + h;

                    m = DateTime.Now.Minute.ToString();

                    if (m.Length == 1)
                        m = "0" + m;

                    s = DateTime.Now.Second.ToString();

                    if (s.Length == 1)
                        s = "0" + s;

                    timeToday = h + ":" + m + ":" + s;
                }
                catch (Exception ex)
                {
                    ex.Data.Clear();
                }
                return timeToday;
            }
        }

        private void EchoSender()
        {
            while (true)
            {
                try
                {
                    NetworkStream clientStream =
                        new NetworkStream(clientSocket);

                    ASCIIEncoding encoder = new ASCIIEncoding();
                    byte[] buffer; ;

                    while (true)
                    {

                        this.echoRequest.WaitOne();

                        //(echo)
                        string echoNow = "004718040030011000000000000002061015053113831" + this.DateToday;

                        buffer = encoder.GetBytes(echoNow);
                        clientStream.Write(buffer, 0, buffer.Length);
                        clientStream.Flush();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Sent echo to switch\n" + echoNow);
                        Logs.LogEntryOnFile("\tSent echo to switch\n");

                        this.echoRequest.Release();

                        Thread.Sleep(30000);//wait for 30 seconds before sending echo again
                    }

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed To connect.. Retrying in a few sec...");
                    Logs.LogEntryOnFile("\tFailed To connect.. Retrying in a few sec...\n");
                    Logs.ReportError(ex);
                  
                    Thread.Sleep(2000);
                    ex.Data.Clear();

                    this.echoRequest.Close();
                    this.echoesOnly.Abort();
                    this.echoesOnly = null;

                }
            }
        }

    }
}