using System.IO;

namespace MClientService
{
    public static class ServerSetting
    {
       public static  string server, db, user, pass, Companyname, domain, Port, Instance;

       public static  void getsettings(string path)
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