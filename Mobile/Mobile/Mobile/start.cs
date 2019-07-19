using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Mobile
{
    class start
    {
        public static CSms.Sms_Service Blkservice = new CSms.Sms_Service();
        private System.Net.NetworkCredential cd;
        public start()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Settings.txt";
                ServerSetting.getsettings(path);
                cd = new System.Net.NetworkCredential(ServerSetting.user, ServerSetting.pass, ServerSetting.domain);

                Blkservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Sms",
               ServerSetting.server, ServerSetting.Companyname, ServerSetting.Instance, ServerSetting.Port);
                Blkservice.PreAuthenticate = true;
                Blkservice.Credentials = (ICredentials)this.cd;
            }
            catch (Exception ex)
            {
                CUtilities.ReportError(ex);
            }
        }
        private Thread _thread;
        public static bool stop = false;
        public void onstart()
        {

            _thread = new Thread(sendsms);
            _thread.IsBackground = false; // true;
            _thread.Priority = ThreadPriority.Normal;
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }
        public void sendsms()
        {
            while (true)
            {
                List<CSms.Sms> blk = new List<CSms.Sms>();
                try
                {
                    using (var db = new Data.HazinaEntities())
                    {
                        //blk = Blkservice.ReadMultiple(new CSms.Sms_Filter[] { new CSms.Sms_Filter() { Criteria = "No", Field = CSms.Sms_Fields.Sent_To_Server } }.ToArray(), null, 100).ToList();
                        var bl = db.Hazina_2016_Live__SMS_Messages.Where(o => o.Sent_To_Server == 0).Take(100) .ToList();
                        BulkSms s = new BulkSms();

                        Sms ss = new Sms();
                        foreach (var item in bl)
                        {
                            //CSms.Sms sm = item;
                            if ((item.Telephone_No != null) && (item.Telephone_No.Length > 8))
                            {
                                ss.Message = item.SMS_Message;
                                ss.Phone = "+254" + item.Telephone_No.Substring(item.Telephone_No.Length - 9);
                                ss.sourceId = item.Entry_No;
                                                               //Blkservice.Update(ref sm);
                                s.Send(ss); 
                                item.Sent_To_Server = 1;
                                db.SaveChanges();
                            }
                            else
                            {
                                item.Sent_To_Server = 1;
                                db.SaveChanges();
                                //sm.Sent_To_Server = CSms.Sent_To_Server.Yes;
                                //sm.Sent_To_ServerSpecified = true;
                                //Blkservice.Update(ref sm);
                            }
                            // break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    CUtilities.ReportError(ex);
                }
                // break;

                Thread.Sleep(30000);
            }
        }
    }
}
