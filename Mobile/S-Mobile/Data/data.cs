using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PData
{
    public partial class MobileEntities
    {
        public MobileEntities(string connectionstring)
              : base(connectionstring)
        {
        }
    }
    public class data
    {
        public  MobileEntities Db = new MobileEntities();
        
              public data(string Connectionstring) {

            Db.Database.Connection.ConnectionString = Connectionstring;
        }
        public static string Connectionstring( string serverName, string databaseName) {
            string providerName = "System.Data.SqlClient";
           // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
            new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            
            sqlBuilder.MultipleActiveResultSets = true;
         
                sqlBuilder.IntegratedSecurity = true;
          
            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
            new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            entityBuilder.Metadata = "res://*/";
          
            return entityBuilder.ToString();
        }
   public static string Connectionstring( string serverName, string databaseName,string Userid,string password) {
            string providerName = "System.Data.SqlClient";
           // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder =
            new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            
            sqlBuilder.MultipleActiveResultSets = true;
            if (Userid == null)
                sqlBuilder.IntegratedSecurity = true;
            else
            {
                sqlBuilder.IntegratedSecurity = false;

                sqlBuilder.UserID = Userid;
                sqlBuilder.Password = password;
            }
            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();

            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
            new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;

            // Set the Metadata location.
            entityBuilder.Metadata = "res://*/";
          
            return entityBuilder.ToString();
        }
    }
}
