using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.Specialized;
using Microsoft.SqlServer.Management.Sdk.Sfc;
namespace Coffee
{
    class Db
    {
        public static void script()
        {
            string path = "Settings.xml";
            Coffee.settings s = new Coffee.settings().loadsettings(path);

            String dbName =s.database; // database name  

            // Connect to the local, default instance of SQL Server.   
            Server srv = new Server();

            // Reference the database.    
            Database db = srv.Databases[dbName];
      
            // Define a Scripter object and set the required scripting options.   
            Scripter scrp = new Scripter(srv);
            scrp.Options.ScriptDrops = false;
            scrp.Options.IncludeIfNotExists = true;
            scrp.Options.TargetServerVersion = SqlServerVersion.Version80;
            scrp.Options.WithDependencies = true;
            scrp.Options.Indexes = true;   // To include indexes  
            scrp.Options.DriAllConstraints = true;   // to include referential constraints in the script  

            // Iterate through the tables in database and script each one. Display the script.     
            foreach (Table tb in db.Tables)
            {
                // check if the table is not a system table  
                if (tb.IsSystemObject == false)
                {
                    Console.WriteLine("-- Scripting for table " + tb.Name);

                    // Generating script for table tb  
                    System.Collections.Specialized.StringCollection sc = scrp.Script(new Urn[] { tb.Urn });
                    foreach (string st in sc)
                    {
                        Console.WriteLine(st);
                    }
                    Console.WriteLine("--");
                }
            }
        }  
    }
}
