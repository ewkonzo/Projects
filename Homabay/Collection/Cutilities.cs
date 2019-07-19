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

    }
  
    }
namespace Collection.DataCollection
{
    public class Results
    {
        public int Code;
        public string desc;
    }
    public partial class Collection : Results
    {


    }
}