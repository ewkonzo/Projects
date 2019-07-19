using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;


namespace RunCodunit
{
    class RunThem
    {        public static Sms.Sms_Service Sservice = new Sms.Sms_Service();
        public static mbranch.MBranch mbranch = new mbranch.MBranch();
        private Thread _thread;
        public static bool stop = false;
            public void onstart()
        {
            _thread = new Thread(start);
            _thread.IsBackground = false; // true;
            _thread.Priority = ThreadPriority.Normal;
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }
        public void start()
            
        {
            try
            {
                string path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\Settings.xml";
             settings ss = new settings(). loadsettings(path);
                while (stop == false)
                {
                    try
                    {
                       Logging.Logging.LogEntryOnFile(String.Format("{0}:Start", DateTime.Now));
                       sendsms();
                        mbranch.Post();
                       Logging.Logging.LogEntryOnFile(String.Format("{0}:End", DateTime.Now));
                    }
                    catch (Exception ex)
                    {
                        Logging.Logging.ReportError(ex);
                    }

                    Thread.Sleep(ss.PostIntervalinsec * 1000);
                }
            }
            catch (Exception)
            {


            }
        }
        private void sendsms()
        {
            ServicePointManager.ServerCertificateValidationCallback = (object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => (true);
            try
            {
                Sendsms.Sms ss = new Sendsms.Sms();

                Logging.Logging.LogEntryOnFile(Sservice.Url);


                var sms = Sservice.ReadMultiple(new Sms.Sms_Filter[] { new Sms.Sms_Filter { Criteria = "No", Field = Sms.Sms_Fields.Sent_To_Server } }, null, 1000);
                foreach (var ssave in sms)
                {
                    var s = ssave;
                    try
                    {

                        if (!string.IsNullOrEmpty(s.Telephone_No))
                        {
                            string r = ss.Sendsms(s.Entry_No.ToString(), s.Telephone_No, s.SMS_Message.Replace(@"\n", Environment.NewLine), settings.clientcode);
                            Logging.Logging.LogEntryOnFile(r);
                            string[] res = r.Split(new char[] { '|' });

                            if (res[0] == "OK")
                            {
                                s.Sent_To_Server = Sms.Sent_To_Server.Yes;
                                s.Sent_To_ServerSpecified = true;
                                s.Date_Sent_to_Server = DateTime.Now.Date;
                                s.Date_Sent_to_ServerSpecified = true;
                                s.Time_Sent_To_Server = DateTime.Now;
                                s.Time_Sent_To_ServerSpecified = true;
                                s.Bulk_SMS_Balance = Convert.ToDecimal(res[1]);
                            }
                            else
                            {
                                s.Sent_To_Server = Sms.Sent_To_Server.Failed;
                                s.Sent_To_ServerSpecified = true;
                                s.Date_Sent_to_Server = DateTime.Now.Date;
                                s.Date_Sent_to_ServerSpecified = true;
                                s.Time_Sent_To_Server = DateTime.Now;
                                s.Time_Sent_To_ServerSpecified = true;
                                s.Comments = (res[1]);
                            }
                                                   }
                        else
                        {
                            s.Sent_To_Server = Sms.Sent_To_Server.Failed;
                            s.Sent_To_ServerSpecified = true;
                            s.Date_Sent_to_Server = DateTime.Now.Date;
                            s.Date_Sent_to_ServerSpecified = true;
                            s.Time_Sent_To_Server = DateTime.Now;
                            s.Time_Sent_To_ServerSpecified = true;
                            s.Comments = "Invalid telephone";
                        }
                        Sservice.Update(ref s);
                    }
                    catch (Exception ex)
                    {
                        try {
                             Logging.Logging.LogEntryOnFile(ex.Message);
                             Logging.Logging.LogEntryOnFile(ex.StackTrace);
                             Logging.Logging.LogEntryOnFile(ex.Source);
                            s.Comments = ex.Message.Substring(0, (ex.Message.Length > 200 ? 200 : ex.Message.Length));
                            Sservice.Update(ref s);
                           
                        }catch(Exception e)
                        { }
                        }
                }
            }
            catch (Exception ex)
            {
                 Logging.Logging.LogEntryOnFile(ex.Message);
                 Logging.Logging.LogEntryOnFile(ex.StackTrace);
   Logging.Logging.LogEntryOnFile(ex.Source);
            }


        }
        
    }
}
