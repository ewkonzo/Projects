using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Xml.Serialization;

namespace Logging
{
    public static class Logging
    {
        static Collection<string> logs = new Collection<string>();
        public static string logpath;
    
        public static string LogFileName
        {
            get
            {
                if (!Directory.Exists(logpath))
                    Directory.CreateDirectory(logpath);
                return logpath + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
            }
        }

        public static void LogEntryOnFile(string clientRequest)
        {
            try
            {
                File.AppendAllText(LogFileName, clientRequest + "\n");
            }
            catch (Exception ex)
            {
            }
        }
        public static void ReportError(Exception ex)
        {
            // throw ex;
            try
            {
                LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.StackTrace));
                LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.Source));
                LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.Message));
                if (ex.InnerException != null)
                {
                    LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.InnerException.Message));
                    LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.InnerException.StackTrace));
                    if (ex.InnerException.InnerException != null)
                    {
                        LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.InnerException.InnerException.Message));
                        LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.InnerException.InnerException.StackTrace));
                    }
                }
                try
                {
                    throw ex;

                }
                catch (DbEntityValidationException ee)
                {
                    foreach (var eve in ee.EntityValidationErrors)
                    {
                        LogEntryOnFile(string.Format("Entity of type {0} in state {1} has the following validation errors:",
                             eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            LogEntryOnFile(string.Format("- Property: {0}, Error: {1}",
                                ve.PropertyName, ve.ErrorMessage));
                        }
                    }

                }


                LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.StackTrace));
                LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.Source));
            }


            catch (Exception e) { }

        }
        public static void ReportError(Exception ex, string client)
        {
            try
            {
                LogEntryOnFile(String.Format("{0}:{1}:{2}", DateTime.Now, client, ex.Message));
                if (ex.InnerException != null)
                    LogEntryOnFile(String.Format("{0}:{1}:{2}", DateTime.Now, client, ex.InnerException.Message));
                LogEntryOnFile(String.Format("{0}:{1}:{2}", DateTime.Now, client, ex.StackTrace));
                LogEntryOnFile(String.Format("{0}:{1}:{2}", DateTime.Now, client, ex.Source));
            }
            catch (Exception e) { }

        }
    }
    

    public class settings
    {
        public  nav navsettings;
        public  db dbsettings;
        public  other othersettings;



        public   settings loadsettings(string file)
        {
            settings s = new settings();
            XmlSerializer xs = new XmlSerializer(typeof(settings));
            using (var sr = new StreamReader(file))
            {
                s = (settings)xs.Deserialize(sr);
                Logging.logpath = s. othersettings.logpath;
            }

            return s;
        }
    }
    public class nav
    {
        public string Server = string.Empty;
        public string domain = string.Empty;
        public string Instance = string.Empty;
        public string Companyname = string.Empty;
        public int Port = 0;
        public string Username = string.Empty;
        public string pass = string.Empty;
    }
    public class db
    {
        public string database = string.Empty;
        public bool IntegratedSecurity = true;
        public string EUsername = string.Empty;
        public string Epass = string.Empty;
    }
    public class other
    {
        public int PostIntervalinsec = 2;
        public int Reconnectintervalinsec = 10;
        public string logpath = string.Empty;
    }
}

