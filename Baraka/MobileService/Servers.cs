using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using System.Net.Security;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml.Serialization;


namespace MobiService
{
    public class settings
    {
        public string Remoteip = string.Empty;
        public int RemotePort = 0;
        public string Localip = string.Empty;
        public int localPort = 0;
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


        public settings loadsettings(string file)
        {
            settings s = new settings();
            XmlSerializer xs = new XmlSerializer(typeof(settings));
            using (var sr = new StreamReader(file))
            {
                s = (settings)xs.Deserialize(sr);
                Logging.Logging.logpath = s.logpath;
            }

            return s;
        }
    }
}