using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
namespace AGENCY
{
    public class Settings
    {
        public string Serverip = string.Empty;
        public string domain = string.Empty;
        public string Instance = string.Empty;
        public int Port = 0;
        public string Username = string.Empty;
        public string pass = string.Empty;
        public string Companyname = string.Empty;
        public int PostIntervalinsec = 2;
        public int Reconnectintervalinsec = 10;
        public string logpath = string.Empty;
        public  Settings getsettings(string path)
        {
            Settings s = new Settings();
            using (StreamReader sr = new StreamReader(path))
            {
              s. Serverip = sr.ReadLine();
              s.Port = int.Parse(sr.ReadLine());
                sr.ReadLine();
                s.Username = sr.ReadLine();
                s.pass = sr.ReadLine();
                s.domain = sr.ReadLine();
                s.Companyname = sr.ReadLine();
                s.Instance = sr.ReadLine();
                CUtilities.logpath = sr.ReadLine();
            }
            return s;
        }
      
    }
}
