using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading;

namespace RunCodunit
{
    class CUtilities
    {
  public   static Collection<string> logs = new Collection<string>();
        public  static string logpath;
        private CUtilities()
        {
        }
        public static string LogFileName
        {
            get
            {
                if (!Directory.Exists(logpath ))
                    Directory.CreateDirectory(logpath);
                return logpath  + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
            }
        }
        public static void LogEntryOnFile(string clientRequest)
        {

            File.AppendAllText(LogFileName, clientRequest + "\n");

        }

  
        }
}

