using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AGENCY
{
    public class Societies
    {
        public String name;
        public String code;
        public String memberid = null;

        public static List<Societies> GetSocieties()
        {
            List<Societies> l = new List<Societies>();
            try
            {
                using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    if (db.mDB.State == ConnectionState.Open)
                    {
                        DataTable dt = db.Getdatatable(String.Format("SELECT Distinct [Society Code]  FROM [dbo].[Capital SACCO Society Ltd$Societies]"));
                        foreach (DataRow row in dt.Rows)
                        {
                            Societies s = new Societies();
                            s.code = row["Society Code"].ToString();
                            s.name = societyname(s.code);
                            l.Add(s);
                        }
                    }
                    db.mDB.Close();
                }
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);

            }

            return l;

        }
        private static String societyname(string societycode)
        {
            String name = String.Empty;
            SqlDataReader r;
            try
            {
                using (var db = new SaccoData(ServerSetting.server, ServerSetting.db, ServerSetting.user, ServerSetting.pass))
                {
                    if (db.mDB.State == ConnectionState.Open)
                    {
                        r = db.ReadDB(String.Format("SELECT Top(1)  [Name]  FROM [dbo].[Capital SACCO Society Ltd$Societies] where [Society Code] = '{0}' and [Name] <>'' ", societycode));
                        if (r.HasRows)
                        {
                            r.Read();
                            name = r["Name"].ToString();
                        }
                      
                    }
                    db.mDB.Close();
                }
            }
            catch (Exception ex)
            {
                CUtilities.LogEntryOnFile(ex.Message);
                CUtilities.LogEntryOnFile(ex.StackTrace);
            }

            return name;

        }
    }
}
