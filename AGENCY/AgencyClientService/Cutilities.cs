using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace AgencyClientService
{
    public class Cutilities
    {

        public static string LogFileName = "C:NewAgency\\logs";
        public static string Company_Name = "CORETEC";
        public static SqlConnection connToNAV;
        public static SqlConnection conntoAgency;
        public static SqlConnection getconnToNAV()
        {
            try
            {
                if (connToNAV == null || connToNAV.State == ConnectionState.Closed)

                    //connToNAV = new SqlConnection(@"Data Source=WIN-FDAN5KNKBKC.SIC.COM;Initial Catalog=SICLTD;MultipleActiveResultSets=true;User ID=coretec_systems;Password=123Team");
                    connToNAV = new SqlConnection(@"Data Source=.;Initial Catalog=CoreBankDB;MultipleActiveResultSets=true;User ID=sa;Password=luke");


                connToNAV.Open();
            }
            catch (Exception es)
            {
                throw es;
                //es.Data.Clear();
            }
            return connToNAV;
        }

        public static SqlConnection getconnToAgencyDB()
        {
            try
            {
                if (conntoAgency == null || conntoAgency.State == ConnectionState.Closed)

                    //connToNAV = new SqlConnection(@"Data Source=WIN-FDAN5KNKBKC.SIC.COM;Initial Catalog=SICLTD;MultipleActiveResultSets=true;User ID=coretec_systems;Password=123Team");
                    conntoAgency = new SqlConnection(@"Data Source=.;Initial Catalog=AGENCY BANKING;MultipleActiveResultSets=true;User ID=sa;Password=luke");


                conntoAgency.Open();
            }
            catch (Exception es)
            {
                throw es;
                //es.Data.Clear();
            }
            return conntoAgency;
        }
       
        public static void LogEntryOnFile(string clientRequest)
        {

            File.AppendAllText(LogFileName, String.Format("{0}: {1}\n", DateTime.Now, clientRequest));

        }

        
    }
}