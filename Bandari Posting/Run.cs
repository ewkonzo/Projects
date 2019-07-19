using System;
using System.Collections.Generic;
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
    {

        public static PData.MBranchsms.Sms_Service Sservice = new PData.MBranchsms.Sms_Service();
        public static mbranch.MBranch mbranch = new mbranch.MBranch();
        public static Atm.Atm_Service atm_Service = new Atm.Atm_Service();

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
                while (stop == false)
                {
                    try
                    {
                        CUtilities.LogEntryOnFile(String.Format("{0}:Start", DateTime.Now));
                        //sendsms();

                        var unposted = atm_Service.ReadMultiple(new Atm.Atm_Filter[] { }, null, 0);

               

                        var unposted3 = unposted.Where(o => o.Posted == false && o.Source ==Atm.Source.COOP);


                        CUtilities.LogEntryOnFile(string.Format("Unposted: {0}", unposted3.Count()));

                        foreach (var un in unposted3)
                        {
                            var unn = un;
                            try
                            {
                            
                                mbranch.Postentry(un.Entry_No);

                            }
                            catch (Exception e) {
                                un.Customer_Names = e.Message;
                                atm_Service.Update(ref unn);

                                CUtilities.LogEntryOnFile(e.Message);


                            }
                        }

                          


                        //mbranch.Post();



                        CUtilities.LogEntryOnFile(String.Format("{0}:End", DateTime.Now));
                    }
                    catch (Exception ex)
                    {
                        CUtilities.LogEntryOnFile(ex.Message);
                        CUtilities.LogEntryOnFile(ex.StackTrace);
                    }
                    Thread.Sleep(ServerSetting.b * 1000);
                }
            }
            catch (Exception)
            {


            }
        }
        private void sendsms()
        {
            try
            {
                Sendsms.Sms ss = new Sendsms.Sms();

                CUtilities.LogEntryOnFile(Sservice.Url);
                                var sms = Sservice.ReadMultiple(new PData.MBranchsms.Sms_Filter[] { new PData.MBranchsms.Sms_Filter { Criteria = "No", Field = PData.MBranchsms.Sms_Fields.Sent_To_Server } }, null, 1000);
                foreach (var ssave in sms)
                {
                    var s = ssave;
                    try
                    {

                        if (!string.IsNullOrEmpty(s.Telephone_No))
                        {
                            string r = ss.Sendsms(s.Entry_No.ToString(), s.Telephone_No, s.SMS_Message.Replace(@"\n", Environment.NewLine), "LOPHA_SACCO");
                            CUtilities.LogEntryOnFile(r);
                            string[] res = r.Split(new char[] { '|' });

                            if (res[0] == "OK")
                            {
                                s.Sent_To_Server = PData.MBranchsms.Sent_To_Server.Yes;
                                s.Sent_To_ServerSpecified = true;
                                s.Date_Sent_to_Server = DateTime.Now.Date;
                                s.Date_Sent_to_ServerSpecified = true;
                                s.Time_Sent_To_Server = DateTime.Now;
                                s.Time_Sent_To_ServerSpecified = true;
                                s.Bulk_SMS_Balance = Convert.ToDecimal(res[1]);
                            }
                            else
                            {
                                s.Sent_To_Server = PData.MBranchsms.Sent_To_Server.Failed;
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
                            s.Sent_To_Server = PData.MBranchsms.Sent_To_Server.Failed;
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
                            CUtilities.LogEntryOnFile(ex.Message);
                            CUtilities.LogEntryOnFile(ex.StackTrace);
                            CUtilities.LogEntryOnFile(ex.Source);
                            s.Comments = ex.Message.Substring(0, (ex.Message.Length > 200 ? 200 : ex.Message.Length));
                            Sservice.Update(ref s);
                           
                        }catch(Exception e)
                        { }
                        }
                }
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
  CUtilities.LogEntryOnFile(ex.Source);
            }


        }
        
    }
}
