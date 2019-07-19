
using System.IO;

namespace RunCodunits
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
          
           }
       }
    }
}