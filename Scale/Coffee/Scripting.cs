using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Common;
namespace Coffee
{
    class Scripting
    {
        public static void Createscript()
        {
            String dbName = settings.s.database; // database name  
            ServerConnection sc = new ServerConnection();
            sc.LoginSecure = settings.s.IntegratedSecurity;
            sc.DatabaseName = dbName;
            sc.ServerInstance = string.Format(@"{0}.\{1}", settings.s.Serverip, settings.s.Instance);
            if (!sc.LoginSecure)
            {
                sc.Login = settings.s.Username;
                sc.Password = settings.s.pass;
            }
            // Connect to the local, default instance of SQL Server.   
            Server srv = new Server(sc);
            // Reference the database.    
            Database db = srv.Databases[dbName];

            // Define a Scripter object and set the required scripting options.   
            Scripter scrp = new Scripter(srv);
            scrp.Options.ScriptDrops = false;
            scrp.Options.WithDependencies = true;
            scrp.Options.Indexes = true;   // To include indexes  
            scrp.Options.DriAllConstraints = true;   // to include referential constraints in the script  
            scrp.Options.IncludeIfNotExists = true;
            StringBuilder s = new StringBuilder();
            // Iterate through the tables in database and script each one. Display the script.     
            foreach (Table tb in db.Tables)
            {

                // check if the table is not a system table  
                if (tb.IsSystemObject == false && tb.Schema == "dbo")
                {

                    Console.WriteLine("-- Scripting for table " + tb.Name);

                    // Generating script for table tb  
                    System.Collections.Specialized.StringCollection scc = scrp.Script(new Urn[] { tb.Urn });
                    foreach (string st in scc)
                    {
                        s.AppendLine(st);
                    }
                    Console.WriteLine("--");
                }
            }

            foreach (Table tb in db.Tables)
            {

                // check if the table is not a system table  
                if (tb.IsSystemObject == false && tb.Schema == "dbo")
                {
                    Console.WriteLine("-- Scripting for " + tb.Name + " columns " + tb.Name);
                    foreach (Column st in tb.Columns)
                    {

                        s.AppendLine("IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS");
                        s.AppendLine("WHERE TABLE_NAME = '" + tb.Name + "' AND COLUMN_NAME = '" + st.Name + "')");
                        s.AppendLine("BEGIN");

                        s.AppendLine("ALTER TABLE [" + tb.Name + "]");
                        if (st.DataType.SqlDataType == Microsoft.SqlServer.Management.Smo.SqlDataType.NVarChar)
                            s.AppendLine(string.Format(" ADD [{0}] {1}({2}) NULL ;", st.Name, st.DataType.SqlDataType, st.DataType.MaximumLength));
                        else if (st.DataType.SqlDataType == Microsoft.SqlServer.Management.Smo.SqlDataType.NVarCharMax)
                            s.AppendLine(string.Format(" ADD [{0}] {1}(Max) NULL ;", st.Name, Microsoft.SqlServer.Management.Smo.SqlDataType.NVarChar));
                        else s.AppendLine(string.Format(" ADD [{0}] {1} NULL ;", st.Name, st.DataType.SqlDataType));

                        s.AppendLine("END;");

                    }
                    Console.WriteLine("--");
                }
            }
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"Script.sql");
            file.WriteLine(s.ToString());
            file.Flush();
            file.Dispose();
            file.Close();
        }

    }
}
