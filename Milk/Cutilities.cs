using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading;

namespace Collection

{
    class CUtilities
    {

        public static string logpath = @"D:\coretec\Msacco\Logs\";
      
        public static string LogFileName
        {
            get
            {

                if (!Directory.Exists(logpath ))
                    Directory.CreateDirectory(logpath);
                return String.Format("{0}{1}{2}{3}.txt", logpath, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
        }

      
        public static void LogEntryOnFile(string clientRequest)
        {
            File.AppendAllText(LogFileName, String.Format("{0}: {1}\n", DateTime.Now, clientRequest));

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
            


                LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.StackTrace));
                LogEntryOnFile(String.Format("{0}:{1}", DateTime.Now, ex.Source));
            }


            catch (Exception e) { }

        }
    }
}

