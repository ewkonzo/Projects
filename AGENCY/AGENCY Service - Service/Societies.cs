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
