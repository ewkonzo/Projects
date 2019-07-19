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


namespace M_SACCO_Webservice
{
    public class ServerSetting
    {
       public  string server, db, user, pass, Companyname, domain, Port, Instance;

       public  void getsettings(string path)
       {
         
           using (StreamReader sr = new StreamReader(path))
           {
               server = sr.ReadLine();
               Port = sr.ReadLine();
               db = sr.ReadLine();
               user = sr.ReadLine();
               pass = sr.ReadLine();
               domain = sr.ReadLine();
               Companyname = sr.ReadLine();
               Instance = sr.ReadLine();
               CUtilities.logpath = sr.ReadLine();
           }
       }
    }
}