using System;
using System.IO;
using System.Xml.Serialization;

namespace Server
{
    public class settings
    {

        public string Serverip = string.Empty;
        public string Server = string.Empty;
        public string domain = string.Empty;
        public string Instance = string.Empty;
        public string EInstance = string.Empty;
        public int Port = 0;
        public string database = string.Empty;
        public bool IntegratedSecurity = true;
        public string Username = string.Empty;
        public string pass = string.Empty;
        public string EUsername = string.Empty;
        public string Epass = string.Empty;
        public string Companyname = string.Empty;
        public int PostIntervalinsec = 2;
        public int Reconnectintervalinsec = 10;
        public string logpath = string.Empty;

        public settings loadsettings(string file)
        {
            settings s = new settings();
            XmlSerializer xs = new XmlSerializer(typeof(settings));
            using (var sr = new StreamReader(file))
            {
                s = (settings)xs.Deserialize(sr);
               
          
            }

            return s;
        }
    }
}
