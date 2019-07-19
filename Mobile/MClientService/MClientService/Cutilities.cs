using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading;

namespace MClientService
{
    class CUtilities
    {
        public static string logpath;
        private CUtilities()
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
        public static void ReportError(Exception ex)
        {
            LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.Message));
            if (ex.InnerException != null)
                LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.InnerException.Message));
            LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.StackTrace));
            LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.Source));
        }

    }
}

