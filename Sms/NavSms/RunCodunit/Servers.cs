
using System.IO;
using System;
using System.Xml.Serialization;

namespace RunCodunit
{
    public class settings
    {

        public string Serverip = string.Empty;
        public string domain = string.Empty;
        public string Instance = string.Empty;
        public int Port = 0;
        public string database = string.Empty;
        public bool IntegratedSecurity = true;
        public string Username = string.Empty;
        public string pass = string.Empty;
        public string Companyname = string.Empty;
        public  int PostIntervalinsec = 2;
        public int Reconnectintervalinsec = 10;
        public string logpath = string.Empty;
        public string certpath = string.Empty;
        public string client = string.Empty;
        
 public static string clientcode = string.Empty;
        public settings loadsettings(string file)
        {
            settings s = new settings();
            try
            {

                XmlSerializer xs = new XmlSerializer(typeof(settings));
                using (var sr = new StreamReader(file))
                {
                    s = (settings)xs.Deserialize(sr);
                    clientcode = s.client;
                    Logging.Logging.logpath = s.logpath;
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.logpath = @"C:\Logs\";
                Logging.Logging.ReportError(ex);
                throw;
            }


            return s;
        }
    }
}