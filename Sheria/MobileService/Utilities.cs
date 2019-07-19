using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading;

namespace MobiService
{
    class Utilities
    {
        
        public static string logpath;
        private Utilities()
        {
        }

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
            File.AppendAllText(LogFileName, clientRequest + "\n");
        }

        public static string[] RemoveDuplicates(string[] s)
        {
            HashSet<string> set = new HashSet<string>(s);
            string[] result = new string[set.Count];
            set.CopyTo(result);
            return result;
        }
    }
}

