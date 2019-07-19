using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Coffee
{
    public class coffee
    {
        public AutoweighEntities db;
       
        public static Setting setup;
        public static User user = null;
      
        public static string Factory_Name;
        public static List<Store> store;
        public static List<Stores_header> store_header;
        public static List<Stock> stocks;
        public static Item[] inventory;
        public static Statusbar status;
        public static Farmer[] farmers;
        public static Daily_Collections_Detail[] collection;
        public coffee(string logpath)
        {
            Logging.Logging.logpath = logpath;
            Logging.Logging.LogEntryOnFile("Application Started");
        }
        public coffee()
        {
            db = new AutoweighEntities(ConnectionString());
            setup = db.Settings.FirstOrDefault();
            loadlists();

        }
        public static void loadlists() { 
         Task task = Task.Factory.StartNew(() =>
             {
                 try
                 {
                     using (var db = new AutoweighEntities(ConnectionString()))
                     {
                         setup = db.Settings.FirstOrDefault();
                         store = db.Stores.ToList();
                         stocks = db.Stocks.ToList();
                         inventory = db.Items.ToArray();
                         store_header = db.Stores_headers.ToList();
                         farmers = db.Farmers.ToArray();
                         collection = db.Daily_Collections_Details.ToArray();
                     }
                 }
                 catch (Exception ex)
                 {
                     Logging.Logging.ReportError(ex);

                 }
             });
        
        }
        public enum Coffee_Type
        {

            Cherry=0,
            Mbuni = 1,
        }
       public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        public static Results Reversestore(string entry)
        {
            Results r = new Results();
            using (var db = new AutoweighEntities(coffee.ConnectionString()))
            {
                var rr = db.Stores.Where(o => o.Entry == entry && o.Status == "Reversed");
                if (rr.Count() > 0)
                {
                    r.Code = -1;
                    r.Desc = "Store Already Reversed";
                }
                else
                {
                     rr = db.Stores.Where(o => o.Entry == entry);
                     foreach (Store item in rr)
                     {
                     item.Status = "Reversed";
                     }
                     db.SaveChanges();
                    foreach (Store item in rr)
                    {                        
                        Store s = item;
                        s.Amount = s.Amount * -1;
                        s.Quantity = s.Quantity * -1;
                        s.Line_total = s.Line_total * -1;
                        s.Sent = false;
                        s.Status = "Reversed";
                        db.Stores.Add(s);
                    }
                    db.SaveChanges();
                    r.Code = 0;
                    r.Desc = "Store Reversed Successfuly";

                }
            }
            return r;
        }
        public static Results login(User User)
        {
            Results r = new Results();
            using (var db = new AutoweighEntities(coffee.ConnectionString()))
            {
                var user = db.Users.FirstOrDefault(o => o.Name == User.Name && o.Password == User.Password);
                if (user != null)
                {
                    coffee.user = user;

                    r.Code = 0;

                }
                else
                {
                    r.Code = -1;
                    r.Desc = "Invalid Username or password";
                }
            }
            return r;
        }
        
        public static string ConnectionString()
        {
            // Specify the provider name, server and database.
            string providerName = "System.Data.SqlClient";
            //string serverName = "Server\\sql2008";
            //string databaseName = client.Db;
            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            // Set the properties for the data source.
            sqlBuilder.DataSource = string.Concat(settings.s.Serverip, @"\", settings.s.Instance);
            sqlBuilder.InitialCatalog = settings.s.database;
            sqlBuilder.IntegratedSecurity = settings.s.IntegratedSecurity;
            sqlBuilder.MultipleActiveResultSets = true;

            if (client.IntegratedSecurity == false)
            {
                sqlBuilder.UserID = settings.s.Username;
                sqlBuilder.Password = settings.s.pass;
            }

            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();
            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            //Set the provider name.
            entityBuilder.Provider = providerName;

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;
            // Set the Metadata location.
            entityBuilder.Metadata = "res://*/";
            return entityBuilder.ToString();

        }
    }
    public enum coffeetype
    {
        CHERRY = 0,
        MBUNI = 1,
    }
    public static class client
    {
        public static string Db;
        public static string Server;
        public static string instance;
        public static string user;
        public static string password;
        public static bool IntegratedSecurity;
        public static bool connectedtomain = false;

    }
    #region Extensions
    public partial class AutoweighEntities : DbContext
    {
        public AutoweighEntities(string Connectionstring)
            : base(Connectionstring)
        {
        }
        public int SaveChanges(Boolean showmessage)
        {
            int s = 0;
            try
            {
                s = base.SaveChanges();
                if (s != 0)
                    System.Windows.Forms.MessageBox.Show("Changes saved successfully");
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);

            }
            return s;
        }
        public enum Savetype 
        {Farmer
        }
        public  int SaveChanges(Savetype savetype)
        {

            int s;
            try
            {
                switch (savetype)
                {
                    case Savetype.Farmer:
                        var entities = ChangeTracker.Entries().Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));
                        foreach (var entry in entities)
                        {
                            var entity = entry.Entity as Farmer;
                            entity.Updated = true;
                        }
                        break;

                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);

            }
            s = base.SaveChanges();
            return s;
        }
    }
    public partial class Farmer
    {
        public Daily_Collections_Detail[] collections
        {
            get
            {
                return new AutoweighEntities(coffee.ConnectionString()).Daily_Collections_Details.Where(o => o.Farmers_Number == No).ToArray();
            }
        }
     
        public Store[] Store
        {
            get
            {
                var sum = coffee.store.Where(o => o.Client == No).ToArray();
                return sum;
            }
        } 
        public double Cherry
        {
            get
            {
                var sum = (double)coffee.collection.Where(o => o.Farmers_Number == No && o.Crop == coffee.setup.Current_crop && o.Coffee_Type == "CHERRY").Select(l => l.Kg__Collected)
                        .DefaultIfEmpty(0)
                        .Sum(); 
                return sum;
            }
        }
        public double Mbuni
        {
            get
            {
                var sum = (double)coffee.collection.Where(o => o.Farmers_Number == No && o.Crop == coffee.setup.Current_crop && o.Coffee_Type == "MBUNI").Select(l => l.Kg__Collected)
                        .DefaultIfEmpty(0)
                        .Sum();
                return sum;
            }
        }
        public Double Store_Total
        {
            get
            {
                var sum = coffee.store.Where(o => o.Client == No).Sum(o => o.Line_total);
                return (double)(sum == null ? 0 : sum);
            }
        }

    }
    public partial class Item
    {
        public Item_Variant[] Variants
        {
            get
            {
                return new AutoweighEntities(coffee.ConnectionString()).Item_Variants.Where(o => o.No == No).ToArray();
            }
        }
    }
    public partial class Store
    {
        public string Item_name
        {
            get
            {
                string i = "";
                try
                {
                    if (Item != null)
                    {
                        var dd = coffee.inventory.FirstOrDefault(o => o.No == Item);
                        if (dd != null)
                            i = dd.Description;

                    }
                }
                catch (Exception ex) { }
                   
                   return i;
            }
        }
public string Item_description
        {
            get
            {
               
                   
                   return string.Format("{0} {1}",Item_name,Variant );
            }
        }
public string Payment_mode
{
    get
    {
        string p = "STORE INVOICE";
        if (Paymode != null)
        {
            switch ((server.Paymode)Paymode)
            {
                case server.Paymode.Credit:
                    p = "STORE INVOICE";
                    break;
                case server.Paymode.Cash:
                    p = "STORE CASH SALE";
                    break;
            }
        }
        return p;
    }
}
        public string Client_name
        {
            get
            { string c = "";
            try
            {

                if (Client != null)
                {
                    var f = coffee.farmers.FirstOrDefault(o => o.No == Client);
                    if (f != null)
                        c = f.Name;


                }

                else
                    return "";
            }
            catch (Exception e) { }
                return c;
            }

        }
    }
    public partial class Stores_header
    {
        public string Payment_mode
        {
            get
            {
                string p = "STORE INVOICE";
                if (Paymode != null)
                {
                    switch ((server.Paymode)Paymode)
                    {
                        case server.Paymode.Credit:
                            p = "STORE INVOICE";
                            break;
                        case server.Paymode.Cash:
                            p = "STORE CASH SALE";
                            break;
                    }
                }
                return p;
            }
        }
        public List<Store> Store_lines
        {
            get
            {
                List<Store> s = null;
                if (Entry != null)
                {
                    s = new AutoweighEntities(coffee.ConnectionString()).Stores.Where(o => o.Entry == Entry).ToList();
                  
                }
  return s;
            }
        }
        public string Client_name
        {
            get
            {
                string c = "";
                if (Client != null)
                {
                    var f = coffee.farmers.FirstOrDefault(o => o.No == Client);
                    if (f != null)
                       c=f.Name;
                }
                return c;
            }
        }
    }
    public partial class Item_Variant
    {
        public double quantity_in
        {
            get
            {
                return (double)coffee.stocks.Where(o => o.Item == No && o.Variant == Code).Sum(o => o.Quantity);
            }
        }
        public double quantity_out
        {
            get
            {
                return (double)coffee.store.Where(o => o.Item == No && o.Variant == Code).Sum(o => o.Quantity);
            }
        }
        public double quantity_Bal
        {
            get
            {
                return (double)quantity_in - quantity_out;
            }
        }
        public string Item_name
        {
            get
            {
                return coffee.inventory.FirstOrDefault(o => o.No == No).Description;
            }
        }
       
        
    }
    public partial class Stock {
        public double quantity_out
        {
            get
            {
                var q = from s in coffee.store join sh in coffee.store_header on s.Entry equals sh.Entry where sh.Posted == true && s.Item == Item && s.Variant == Variant && s.Stock == Document_No select s.Quantity;
                

                return (double)(q.FirstOrDefault()==null?0:q.FirstOrDefault());
            }
        }
        public double quantity_Bal
        {
            get
            {
                return (double)(Quantity -(double) quantity_out);
            }
        }
    }
    public partial class Daily_Collections_Detail
    {
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", Farmers_Number, Farmers_Name);
            }
        }

    }

    #endregion
    public class Serial
    {
        public static SerialPort mySerialPort = new SerialPort();
        public static SerialPort serial()
        {
            try
            {
                var settings = new AutoweighEntities(coffee.ConnectionString()).Settings.FirstOrDefault();
                mySerialPort.PortName = settings.Com_Port;
                mySerialPort.BaudRate = (int)settings.BaudRate;// 9600;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;
                mySerialPort.RtsEnable = true;
                mySerialPort.DtrEnable = true;
                mySerialPort.Open();
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
                throw;
            }
            return mySerialPort;
        }
    }
    public class Results
    {
        public int Code;
        public string Desc;
    }
    public class filters
    {
        public string field;
        public string filter;
    }

    public class settings
    {

        public string Serverip = string.Empty;
        public string domain = string.Empty;
        public string Instance = string.Empty;
        public static settings s;
        public int Port = 0;
        public string database = string.Empty;
        public bool IntegratedSecurity = true;
        public string Username = string.Empty;
        public string pass = string.Empty;
        public string Companyname = string.Empty;
        public int PostIntervalinsec = 2;
        public int Reconnectintervalinsec = 10;
        public string logpath = string.Empty;
       
        public settings loadsettings(string file)
        {     settings ss = new settings();
            try
            {
           
                XmlSerializer xs = new XmlSerializer(typeof(settings));
                using (var sr = new StreamReader(file))
                {
                    ss = (settings)xs.Deserialize(sr);
                    s = ss;
                    Logging.Logging.logpath = ss.logpath;
                }
            }
            catch (Exception ex) {
                Logging.Logging.logpath = @"C:\Logs\";
                Logging.Logging.ReportError(ex);
                throw; }


            return s;
        }
    }
}
