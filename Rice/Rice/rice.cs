using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Rice
{
    public class rice
    {
        public RiceEntities db;
        public bool stop = false;
        public static Setting setup;
        public static settings setting;
        public static settings s;
        public static User user = null;
        public static string Factory_Name;
        public static Statusbar status;
        public static List<Dimension> dimensions = null;
        public static List<Paddy_Bag> bags = null;
        public static List<Unit> units = null;
        public static List<Farmer> farmers = null;
        public static Items_Services_List[] itemsservices = null;
        public static Items_Services[] items = null;
        public static Sales_Price[] prices = null;
        public static Outlet[] outlets = null;
        public static Vendor[] vendor = null;
        public static Item_Balance[] itembalances = null;
        public static Items_Services_List[] sales = null;
        public static Company company = null;
        public static User[] users = null;
        public static User_outlet[] useroutlets = null;
        public static List<Variant> variants = null;
        public static Item_Movement[] item_movement = null;
        public static List<outlet_vendors> Location_Vendors = null;
        public rice(string logpath)
        {
            Logging.Logging.logpath = logpath;
            Logging.Logging.LogEntryOnFile("Application Started");
        }
        public rice()
        {
            db = new RiceEntities(ConnectionString());
            setup = db.Settings.FirstOrDefault();
            outlets = db.Outlets.ToArray();
            if (user == null)
                user = db.Users.FirstOrDefault();
            populatelists();
        }
        public enum Stockcalculation {
          Global,   local,
               
        }
        public static void populatelists()
        {
            Task task = Task.Factory.StartNew(() =>
               {
                   try
                   {
                       using (var db = new RiceEntities(ConnectionString()))
                       {
                           setup = db.Settings.FirstOrDefault();
                           users = db.Users.ToArray();
                           prices = db.Sales_Prices.ToArray();
                           itemsservices = db.Items_Services_List.ToArray();
                           dimensions = db.Dimensions.ToList();
                           units = db.Units.ToList();
                           farmers = db.Farmers.ToList();
                           items = db.Items_Services.ToArray();
                           item_movement = db.Item_Movements.ToArray();
                           variants = db.Variants.ToList();
                           outlets = db.Outlets.ToArray();
                           company = db.Companies.FirstOrDefault();
                           vendor = db.Vendors.ToArray();
                         
                           sales = db.Items_Services_List.ToArray();
                        
                            Location_Vendors = (from x in outlets select new outlet_vendors { code = x.Code, Name = x.Name }).ToList();
Location_Vendors.AddRange(from l in vendor select new outlet_vendors { code = l.No, Name = l.Name }) ;

                         bags = db.Paddy_Bags.ToList();

  itembalances = db.Item_Balances.ToArray(); 
                       }
                   }
                   catch (Exception ex)
                   {

                       Logging.Logging.ReportError(ex);
                   }

               });

        }
        public static string formatfilter(string filter) {

          return  filter
                .Replace("[", "")
                .Replace("]", "")
                .Replace("Outlet_Name", "Outlet")
                .Replace("Movement_Type","Movement Type");
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
        public static Results login(User User)
        {
            Results r = new Results();
            using (var db = new RiceEntities(rice.ConnectionString()))
            {
                var user = rice.users.FirstOrDefault(o => o.Name == User.Name && o.Password == User.Password);
                if (user != null)
                {
                    rice.user = user;
                    var d = db.Settings.FirstOrDefault();
                    if (d == null)
                    {
                        d = new Setting();
                        d.POS_Outlet = User.Outlet;
                        db.Settings.Add(d);
                    } d.POS_Outlet = User.Outlet;
                        db.SaveChanges();
                        populatelists();
                    if (user.Password_Changed == false)
                        using (var f = new FrmchangePass())
                        {
                            f.StartPosition = FormStartPosition.CenterScreen;
                            var result = f.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                if (f.Passwordchanged == false)
                                {
                                    r.Code = -1;
                                    r.Desc = "Password must be changed before first login";
                                    return r;
                                }
                            }
                        }
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
        public static double Itembalance(string item, string variant, string location)
        {
            if ((Stockcalculation) (rice.setup.Stock_Calculation??0) == Stockcalculation.Global)
            return balance(item, variant, location);
            else
                return balancelocal(item, variant, location);
            //double bal = 0;
            //double dbal = 0;
            //double lb = 0;
            //double sb = 0;
            //using (var db = new RiceEntities(rice.ConnectionString()))
            //{
            //    var d = db.Item_Balances.Where(o => o.Item == item && o.Variant == variant && o.Location == location);
            //    if (d.Count() > 0)
            //    {
            //        dbal = (double)d.Sum(o => o.Balance);
            //    }
            //    var lbal = db.Item_Movements.Where(o => o.Item == item && o.Variant == variant && o.Location == location && (o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString())) && (o.Reversed == false || string.IsNullOrEmpty(o.Reversed.ToString())));
            //    if (lbal.Count() > 0)
            //    {
            //        lb = Convert.ToDouble( lbal.Select(l => l.Qty)
            //             .DefaultIfEmpty(0)
            //             .Sum());
            //    }
            //    var sbal = db.Items_Services_List.Where(o => o.Item == item && o.Variant == variant && o.Outlet == location && (o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString())) && (o.Reversed == false || string.IsNullOrEmpty(o.Reversed.ToString())));
            //    if (sbal.Count() > 0)
            //    {
            //        sb =Convert.ToDouble( sbal
            //            .Select(l => l.Qty)
            //             .DefaultIfEmpty(0)
            //             .Sum());
                        
                       
            //    }
            //}
            //bal = dbal + lb - sb;
            //return bal;
        }
        public static double balance(string item, string variant, string location)
        {
            double bal = 0;
            double dbal = 0;
            double lb = 0;
            double sb = 0;
            using (var db = new RiceEntities(rice.ConnectionString()))
            {
                var d = db.Item_Balances.Where(o => o.Item == item && o.Variant == variant && o.Location == location);
                if (d.Count() > 0)
                {
                    dbal = (double)d.Sum(o => o.Balance);
                }
                var lbal = db.Item_Movements.Where(o => o.Item == item && o.Variant == variant && o.Location == location && (o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString())) && (o.Reversed == false || string.IsNullOrEmpty(o.Reversed.ToString())));
                if (lbal.Count() > 0)
                {
                    lb = Convert.ToDouble(lbal.Select(l => l.Qty)
                         .DefaultIfEmpty(0)
                         .Sum());
                }
                var sbal = db.Items_Services_List.Where(o => o.Item == item && o.Variant == variant && o.Outlet == location && (o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString())) && (o.Reversed == false || string.IsNullOrEmpty(o.Reversed.ToString())));
                if (sbal.Count() > 0)
                {
                    sb = Convert.ToDouble(sbal
                        .Select(l => l.Qty)
                         .DefaultIfEmpty(0)
                         .Sum());
                }
            }
            bal = dbal + lb - sb;
            return bal;
        }
        public static double balancelocal(string item, string variant, string location)
        {
            double bal = 0;
            double dbal = 0;
            double lb = 0;
            double sb = 0;
            using (var db = new RiceEntities(rice.ConnectionString()))
            {

                var lbal = db.Item_Movements.Where(o => o.Item == item && o.Variant == variant && o.Location == location);
                if (lbal.Count() > 0)
                {
                    lb = Convert.ToDouble(lbal.Select(l => l.Qty)
                         .DefaultIfEmpty(0)
                         .Sum());
                }
                var sbal = db.Items_Services_List.Where(o => o.Item == item && o.Variant == variant && o.Outlet == location  );
                if (sbal.Count() > 0)
                {
                    sb = Convert.ToDouble(sbal
                        .Select(l => l.Qty)
                         .DefaultIfEmpty(0)
                         .Sum());
                }
            }
            bal = dbal + lb - sb;
            return bal;
        }
        public static double totalbal(string item)
        {
            double bal = 0;
            double dbal = 0;
            double lb = 0;
            double sb = 0;
         
                var d = rice.itembalances.Where(o => o.Item == item && o.Location == rice.setup.POS_Outlet);
                if (d.Count() > 0)
                {
                    dbal = (double)d.Sum(o => o.Balance);
                }
                var lbal = rice.item_movement.Where(o => o.Item == item && o.Location == rice.setup.POS_Outlet && (o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString())));
                if (lbal.Count() > 0)
                {
                    lb = (double)lbal.Sum(o => o.Qty);
                }
                var sbal = rice.sales.Where(o => o.Item == item  && o.Outlet == rice.setup.POS_Outlet && (o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString())));
                if (sbal.Count() > 0)
                {
                    sb = (double)sbal.Sum(o => o.Qty);
                }
            
            bal = dbal + lb - sb;
            return bal;
        }

        #region grid functions
        #endregion


        #region lists
        public static List<Dimension> varieties()
        {
            return new RiceEntities(rice.ConnectionString()).Dimensions.Where(o => o.Dimension_Code == "VARIETY").ToList();

        }
        public static List<Dimension> sections()
        {
            return new RiceEntities(rice.ConnectionString()).Dimensions.Where(o => o.Dimension_Code == "SECTION").ToList();

        }
        public static void Testfields(Control f)
        {

        }
        #endregion
        #region Update server
        #endregion
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
            sqlBuilder.DataSource = string.Concat(rice.s.Server, @"\", rice.s.Instance);
            sqlBuilder.InitialCatalog = rice.s.database;
            sqlBuilder.IntegratedSecurity = rice.s.IntegratedSecurity;
            sqlBuilder.MultipleActiveResultSets = true;
            if (rice.s.IntegratedSecurity == false)
            {
                sqlBuilder.UserID = rice.s.Username;
                sqlBuilder.Password = rice.s.pass;
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

    public class outlet_vendors
    {
        public string code { get; set; }
        public string Name { get; set; }

    }
    public static class client
    {
        public static string Db;
        public static string Server;
        public static string instance;
        public static string user;
        public static string password;
        public static bool IntegratedSecurity;
    }
    #region Extensions

    public partial class RiceEntities : DbContext
    {
        public RiceEntities(string Connectionstring)
            : base(Connectionstring)
        {
        }

        public enum Savetype
        {
            Updatestatus, ShowMessage, None,

        }

        public int SaveChanges(Savetype savetype)
        {
            int s = 0;
            try
            {
                switch (savetype)
                {
                    case Savetype.None:
                        s = base.SaveChanges();
                        break;
                    case Savetype.ShowMessage:
                        s = base.SaveChanges();
                        if (s != 0)
                            System.Windows.Forms.MessageBox.Show("Changes saved successfully");

                        break;

                    case Savetype.Updatestatus:
                        var itementity1 = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added);
                        var itementity = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
                        foreach (var entry in itementity)
                        {
                            var d = entry.Entity.GetType();
                            switch (d.Name)
                            {
                                case "Items_Services_List":
                                    var entity = entry.Entity as Items_Services_List;
                                    entry.Property("Sent").IsModified = true;
                                    entity.Sent = false;
                                    break;

                                case "Contact":
                                    var contact = entry.Entity as Contact;
                                    entry.Property("Sent").IsModified = true;
                                    contact.Sent = false;
                                    break;
                                case "Paddy_Bag":
                                    var paddybags = entry.Entity as Paddy_Bag;
                                    entry.Property("Sent").IsModified = true;
                                    paddybags.Sent = false;
                                    break;
                                case "Paddy_Detail":
                                    var paddydetails = entry.Entity as Paddy_Detail;
                                    entry.Property("Sent").IsModified = true;
                                    paddydetails.Sent = false;
                                    break;
                                case "Farmer":
                                    var farmer = entry.Entity as Farmer;
                                    entry.Property("Updated").IsModified = true;
                                    farmer.Updated = true;
                                    break;
                            }

                        }

                        s = base.SaveChanges();
                        break;
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);

            }

            return s;
        }
    }

    public partial class Item_Conversion_Matrix
    {
        public string Item_Name
        {
            get
            {
                if (Item != null)
                    return rice.items.FirstOrDefault(o => o.Code == Item).Name;
                else
                    return "";
            }
        }
        public string To_Item_Name
        {
            get
            {
                if (Item != null)
                    return rice.items.FirstOrDefault(o => o.Code == To_Item).Name;
                else
                    return "";
            }
        }
    }
    public partial class Item_Movement_Header
    {

        public string itemname
        {
            get
            {
                if (Item != null)
                {
                    var l = rice.items.FirstOrDefault(o => o.Code == Item);
                    if (l != null)
                        return l.Name;
                    else return string.Empty;
                }
                else
                    return string.Empty;
            }
        }
        public string itemDescription
        {
            get
            {
                if (Item != null)
                    return String.Format("{0} {1}", itemname, Variant);
                else
                    return string.Empty;
            }
        }
        public string To_itemname
        {
            get
            {
                if (To_Item != null)
                {
                    var l = rice.items.FirstOrDefault(o => o.Code == To_Item);
                    if (l != null)
                        return l.Name;
                    else return string.Empty;
                }
                else
                    return string.Empty;
            }
        }
        public string To_itemDescription
        {
            get
            {
                if (To_Item != null)

                    return String.Format("{0} {1}", To_itemname, To_Variant);

                else
                    return string.Empty;
            }
        }
        public string vendorname
        {
            get
            {
                if (Location_To != null)
                {
                    var l = rice.vendor.FirstOrDefault(o => o.No == Location_To);
                    if (l != null)
                        return l.Name;
                    else return string.Empty;
                }
                else
                    return string.Empty;
            }
        }
        public Item_Movement[] lines
        {
            get
            {
                if (Reference != null)
                    return new RiceEntities(rice.ConnectionString()).Item_Movements.Where(o => o.Reference == Reference).ToArray();
                else return null;
            }
        }
        public Transferred_Item[] Transfered
        {
            get
            {
                if (Reference != null)
                    return new RiceEntities(rice.ConnectionString()).Transferred_Items.Where(o => o.Reference == Reference).ToArray();
                else return null;
            }
        }
        public string outletname
        {
            get
            {
                return rice.outlets.FirstOrDefault(o => o.Code == Location).Name;
            }
        }
        public string To_outletname
        {
            get
            {
                return rice.outlets.FirstOrDefault(o => o.Code == Location_To).Name;
            }
        }
    }
    public partial class Item_Reversal
    {
        public string Item_Type
        {
            get
            { return (Entry_Type != null ? ((Reversals.Entry_Type)Entry_Type).ToString() : ""); }
        }
        public string Locationname
        {
            get
            {
                return rice.outlets.FirstOrDefault(o => o.Code == Location).Name;
            }
        }
    }
    public partial class Transferred_Item
    {
        public string Item_Name
        {
            get
            {
                if (Item != null)
                    return rice.items.FirstOrDefault(o => o.Code == Item).Name;
                else
                    return "";
            }
        }
        public string Item_Description
        {
            get
            {
                if (Item != null)
                    return string.Format("{0} {1}", Item_Name, Variant);
                else
                    return "";
            }
        }
    }
    public partial class Item_Movement
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public Company company
        {
            get
            {

                return rice.company;
            }
        }
        public string Location_Name
        {
            get
            {
                if (Location != null)
                {
                    var l = rice.Location_Vendors.FirstOrDefault(o => o.code == Location);
                    if (l != null)
                        return l.Name;
                    else return string.Empty;
                }
                else
                    return string.Empty;
            }
        }

        public string Item_Name
        {
            get
            {
                if (Item != null)
                {
                    var i = rice.items.FirstOrDefault(o => o.Code == Item);
                    if (i != null)
                        return rice.items.FirstOrDefault(o => o.Code == Item).Name;
                    else return "";
                }
                else
                    return "";
            }
        }
        public Movement.Movement_Type moveType
        {
            get
            {
                return (Movement.Movement_Type)Movement_Type;
            }
        }
        public string Item_Description
        {
            get
            {
                if (Item != null)
                    return string.Format("{0} {1}", Item_Name, Variant);
                else
                    return "";
            }
        }
        public string grn
        {

            get
            {
                if (Reference != null)
                {
                    using (var db = new RiceEntities(rice.ConnectionString()))
                    {
                        var h = db.Item_Movement_Headers.FirstOrDefault(o => o.Reference == Reference);
                        if (h != null)

                            return h.Grn_No;
                        else
                            return string.Empty;

                    }
                }
                else return string.Empty;
            }
        }
        public string invoice
        {

            get
            {
                if (Reference != null)
                {
                    using (var db = new RiceEntities(rice.ConnectionString()))
                    {
                        var h = db.Item_Movement_Headers.FirstOrDefault(o => o.Reference == Reference);
                        if (h != null)

                            return h.Invoice;
                        else
                            return string.Empty;

                    }
                }
                else return string.Empty;
            }
        }
    }
    public partial class Variant
    {
        public string item
        {
            get
            {
                return rice.items.FirstOrDefault(o => o.Code == Item_Code).Name;


            }
        }
        public double balance
        {
            get
            {
              return  rice.Itembalance(Item_Code, Code, rice.setup.POS_Outlet);
              
            }
        }
    }
    public partial class Items_Services
    {
      public double TotalBal
        {
            get
            {
                return rice.totalbal(Code);
              
            }
        }
    }
    public partial class User_outlet
    {
        public string outlet_name
        {
            get
            {
                string name = "";
                if (!string.IsNullOrEmpty(Active_Outlet))
                {
                    var d = rice.outlets.FirstOrDefault(o => o.Code == Active_Outlet);
                    if (d != null)
                    {
                        name = d.Name;
                    }
                }
                return name;
            }
        }
    }
    public partial class Items_Header
    {
        public User user
        {
            get
            {
                User u =null;
                if ((rice.users!= null) && (!String.IsNullOrEmpty( User_Name )))
                    u = rice.users.FirstOrDefault(o=> o.Name == User_Name);
                return u;
            }

        }
        public string paymentmode
        {
            get
            {

                return ((ItemList.Payment_Mode)Payment_Mode).ToString();

            }
        }
        public string customerinfo
        {
            get
            {


                return string.Format("{0}-({1})", Customer, Phone_No);



            }
        }
        public string salestype
        {
            get
            {
                switch ((ItemList.Payment_Mode)Payment_Mode)
                {


                    case ItemList.Payment_Mode.Credit:
                        return "INVOICE";

                    default:
                        return "CASH SALE";


                }



            }
        }
        public string userphone
        {
            get
            {
                return string.Format("{0}({1})", User_Name, (string.IsNullOrEmpty( rice.user.Phone)?string.Empty: rice.user.Phone));
                //return rice.outlets.FirstOrDefault(o => o.Code == Outlet).Name;

            }
        }
        public string outletname
        {
            get
            {

                return rice.outlets.FirstOrDefault(o => o.Code == Outlet).Name;

            }
        }
        public Farmer Farmerrecord
        {
            get
            {
                if (Farmer != null)
                    return rice.farmers.FirstOrDefault(o => o.No == Farmer);
                else
                    return null;
            }
        }
        public List<Items_Services_List> Lines
        {
            get
            {
                return new RiceEntities(rice.ConnectionString()).Items_Services_List.Where(o => o.Receipt_No == Collection_No).ToList();
            }
        }
    }
    public partial class Items_Services_List
    {        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public string Farmer_Name
        {
            get
            {
                var name = string.Empty;
                if (Farmer != null)
                {
                    var f = rice.farmers.FirstOrDefault(o => o.No == Farmer);
                    if (f != null)
                        name = f.Name;
                }
                return name;
            }
        }
        public DateTime datetime
        {
            get
            {

                return new DateTime(Date.Value.Year, Date.Value.Month, Date.Value.Day, Time.Value.Hour, Time.Value.Minute, Time.Value.Second);
            }
        }
        public string Item_Name
        {
            get
            {
                if (Item != null)
                {
                    var i = rice.items.FirstOrDefault(o => o.Code == Item);
                    if (i != null)
                        return i.Name;
                    else
                        return "";
                }
                else
                    return "";
            }
        }
        public string Item_Description
        {
            get
            {
                if (Item != null)
                    return string.Format("{0} {1}", Item_Name, Variant);
                else
                    return "";
            }
        }
        public string CategoryName
        {
            get
            {
                if (Machine_Cagegory != null)
                    return ((ItemHeader.Machine_Cagegory)Machine_Cagegory).ToString();
                else
                    return string.Empty;
            }
        }
        public string paymentmode
        {
            get
            {
                if (Payment_Mode != null)
                    return ((ItemList.Payment_Mode)Payment_Mode).ToString();
                else
                    return string.Empty;
            }
        }
        public string Price_Category
        {
            get
            {
                if (Sales_Type != null)
                    return ((ItemList.Sales_Type)Sales_Type).ToString();
                else
                    return string.Empty;
            }
        }
        public string customerinfo
        {
            get
            {



                return string.Format("{0}-({1})", Customer, Phone_No);
            }
        }
        public string salestype
        {
            get
            {
                switch ((ItemList.Payment_Mode)Payment_Mode)
                {


                    case ItemList.Payment_Mode.Credit:
                        return "INVOICE";

                    default:
                        return "CASH SALE";


                }



            }
        }
        public string Outlet_Name
        {
            get
            {
                if (Outlet != null)
                {
                    var outle = rice.outlets.FirstOrDefault(o => o.Code == Outlet);
                    if (outle != null)
                        return outle.Name;
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
        } public string Location_Name
        {
            get
            {
                if (Outlet != null)
                {
                    var outle = rice.outlets.FirstOrDefault(o => o.Code == Outlet);
                    if (outle != null)
                        return outle.Name;

                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
        }
        public Company company
        {
            get
            {

                return rice.company;
            }
        }
    }
    public partial class Company
    { public void load()
        {

            var c = rice.company;// new RiceEntities(rice.ConnectionString()).Companies.FirstOrDefault();
            Entry = c.Entry;
            Name = c.Name;
            Address = c.Address;
            City = c.City;
            Phone_No_ = c.Phone_No_;
            Telex_No_ = c.Telex_No_;
            Fax_No_ = c.Fax_No_;
            VAT_Registration_No_ = c.VAT_Registration_No_;
            Registration_No_ = c.Registration_No_;
            Picture = c.Picture;
            Post_Code = c.Post_Code;
            County = c.County;
            E_Mail = c.E_Mail;
            Company_P_I_N = c.Company_P_I_N;
            Company_code = c.Company_code;
            Company_Watermark = c.Company_Watermark;
            PIN_No = c.PIN_No;
            Home_Page = c.Home_Page;
            Mission = c.Mission;
            Vision = c.Vision;
            Location = c.Location;
            Branch_Location = c.Branch_Location;
            Managers_Phone_No = c.Managers_Phone_No;
            Operations_Phone_No = c.Operations_Phone_No;
            Sales_Supervisor = c.Sales_Supervisor;

        }
        public string desc_address
        {
            get
            { return String.Format("P.O BOX {0}", Address); }
        }
        public string desc_Tel
        {
            get
            { return String.Format("Tel: {0}", Managers_Phone_No); }
        }
        public string desc_location
        {
            get
            { return String.Format("Location: {0}", Location); }
        }
        public string desc_email
        {
            get
            { return String.Format("E-Mail: {0}", E_Mail); }
        }
        public string desc_Webpage
        {
            get
            { return String.Format("Website: {0}", Home_Page); }
        }
       
    }
    public partial class Farmer
    {
        public Company company
        {
            get
            {

                return rice.company;
            }
        }
        public Paddy_Detail[] collections
        {
            get
            {
                return new RiceEntities(rice.ConnectionString()).Paddy_Details.Where(o => o.Farmers_Number == No).ToArray();
            }
        }
        public string Sectionname
        {

            get
            {
                if (Section != null)
                    return rice.dimensions.FirstOrDefault(o => o.Dimension_Code == "SECTION" && o.Code == Section).Name;
                else
                    return "";
            }
        }
        public string Bank_Name
        {

            get
            {
                return new RiceEntities(rice.ConnectionString()).Bank_Accounts.FirstOrDefault(o => o.No_ == Bank_Name).Name;
            }
        }

    }
    public partial class Paddy_Detail
    {
        public Company company
        {
            get
            {

                return rice.company;
            }
        }
        public string Variety_name
        {

            get
            {
                if (!String.IsNullOrEmpty(Variety))
                    return rice.items.FirstOrDefault(o => o.Code == Variety).Name;
                else
                    return string.Empty;
            }
        }
        public double Moisture_Weight
        {
            get
            {
                return (double) rice.bags.Where(o =>  o.Paddy == Collection_Number)                  .Select(l => l.Moisture_Weight)
                            .DefaultIfEmpty(0)
                            .Sum();
            }
        }
        public double Bags_Weight
        {
            get
            {
                return (double)rice.bags.Where(o => o.Paddy == Collection_Number).Select(l => l.Bag_weight)
                            .DefaultIfEmpty(0)
                            .Sum();
            }
        }     
        public double Gross
        {
            get
            {
                return (double)rice.bags.Where(o => o.Paddy == Collection_Number).Select(l => l.Gross_kg)
                            .DefaultIfEmpty(0)
                            .Sum();
            }
        }   
        public double Net
        {
            get
            {
                return (double)rice.bags.Where(o =>  o.Paddy == Collection_Number ).Select(l => l.Net_kg)
                            .DefaultIfEmpty(0)
                            .Sum();
            }
        }     
        public List<Paddy_Bag> BagsWeighed
        {
            get
            {
                return rice.bags.Where(o => o.Paddy == Collection_Number && (o.Reversed == false || string.IsNullOrEmpty(o.Reversed.ToString()))).ToList();
            }       
        }      
        public double TotalBagsWeighed
        {
            get
            {
                    return (double)rice.bags.Where(o => o.Paddy == Collection_Number).Select(l => l.No_of_bags).DefaultIfEmpty(0).Sum();
            }
        }


        public double Unweighedbags
        {
            get
            {
                return (double )((No_of_bags_Delivered??0) - TotalBagsWeighed);
            }
        }
        public string Transport
        {
            get
            {

                return ((Collections.Transport_Mode)Transport_Mode).ToString(); ;
            }
        }
        public Farmer farmer
        {
            get
            {
                var f = rice.farmers.FirstOrDefault(o => o.No == Farmers_Number.ToUpper());

                return f;
            }
        }
    }
    public partial class Paddy_Bag
    {
        public string BagtypeName
        {
            get { return ((PaddyBags.Bag_type)Bag_type).ToString(); }
        }
    }
    public partial class Setting
    {
        public string outletname { get { return rice.outlets.FirstOrDefault(o => o.Code == POS_Outlet).Name; } }

        public Outlet outlet
        {
            get { return rice.outlets.FirstOrDefault(o => o.Code == POS_Outlet); }
        }
    }



    #endregion
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
        public string Server = string.Empty;
        public string domain = string.Empty;
        public string Instance = string.Empty;
        public string EInstance = string.Empty;
        public int Port = 0;
        public string database = string.Empty;
        public bool IntegratedSecurity = true;
        public string Username = string.Empty;
        public string pass = string.Empty;
        public string EUsername = string.Empty;
        public string Epass = string.Empty;
        public string Companyname = string.Empty;
        public int PostIntervalinsec = 2;
        public int Reconnectintervalinsec = 10;
        public string logpath = string.Empty;

        public settings loadsettings(string file)
        {
            settings s = new settings();
            XmlSerializer xs = new XmlSerializer(typeof(settings));
            using (var sr = new StreamReader(file))
            {
                s = (settings)xs.Deserialize(sr);
                rice.s = s;
                Logging.Logging.logpath = s.logpath;
            }

            return s;
        }
    }
    public class reports
    {
        public enum source 
        {
            Farmers,
            Pos,
            Purchase,
            stocks,
            paddy,
            Machineexpenditure


        }
        public enum report
        {
            Sales,
            salessummary,
            Purchasereport,
            Purchasecumm,
            stockanalysis,
            salescummulative,
            farmers,
            Paddy,
            Machineexpenduture

        }

    }
    public class zreport
    {
        public double cash;
        public double Mpesa;
        public double Credit;
        public double Cheques;
        public double Deposits;
        public double Bank_slip;
        public double AdvPay;
    }

    public class itemstatistics:Company
    {
        public Summary[] summary { get; set; }
        public MovementList[] movementlist { get; set; }
        public itemstatistics()
        {

            

        }

    }
    public class Summary
        {
            public string Date { get; set; }
            public string item { get; set; }
            public string Variant { get; set; }
            public double Price { get; set; }
            public double Stock_value { get; set; }
            public string Location { get; set; }
            public double OpeningBalance { get; set; } 
        public double StockTake { get; set; }
            public double Received { get; set; }
            public double Converted { get; set; }
            public double Returned { get; set; }
            public double Transfered { get; set; }
            public double Sold { get; set; }
            public double Balance { get; set; }  
        public string Category { get; set; }
            public string item_desc
            {
                get
                {
                    if (item != null && Variant != null)
                    {
                        var i = rice.items.FirstOrDefault(o => o.Code == item);

                        return string.Format("{0} {1}", i.Name, Variant);
                    }
                    else return string.Empty;
                }

            }
        }
    public class MovementList
        {
        public Nullable<System.DateTime> Date { get; set; }
        public string item { get; set; }
        public string Variant { get; set; }
        public string location { get; set; }
public string Location_Name { get{

    if (location != null)
    {
        var l = rice.outlets.FirstOrDefault(o => o.Code == location);
        if (l != null)
            return l.Name;
        else return string.Empty;
    }
    else
        return string.Empty;
}  }

        public Movetype Movement_type { get; set; }
        public double qty { get; set; }
            public string item_desc
            {
                get
                {
                    if (item != null && Variant != null)
                    {
                        var i = rice.items.FirstOrDefault(o => o.Code == item);

                        return string.Format("{0} {1}", i.Name, Variant);
                    }
                    else return string.Empty;
                }

            }

            public enum Movetype
            {
                Stock_Take,

                /// <remarks/>
                Receive,

                /// <remarks/>
                Transfer,

                /// <remarks/>
                Return,

                /// <remarks/>
                Convert,
                Sale,
            }
            public MovementList[] getlist()
            {
            if ((rice.Stockcalculation)(rice.setup.Stock_Calculation ?? 0) == rice.Stockcalculation.Global)
                return getlistglobal();
            else
                return getlistlocal();
            }
        public MovementList[] getlistglobal()
        {
            List<MovementList> m = new List<MovementList>();
            using (var db = new RiceEntities(rice.ConnectionString()))
            {
                var d = db.Item_Balances.ToArray();
                foreach (var item in d)
                {
                    MovementList ml = new MovementList();
                    ml.Date = item.Date;
                    ml.item = item.Item;
                    ml.Variant = item.Variant;
                    ml.qty = (double)item.Balance;
                    ml.location = item.Location;
                    ml.Movement_type = (Movetype)(item.Move_Type ?? 5);
                    m.Add(ml);
                }
                var lbal = db.Item_Movements.Where(o => (o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString())) && (o.Reversed == false || string.IsNullOrEmpty(o.Reversed.ToString())));
                foreach (var item in lbal)
                {
                    MovementList ml = new MovementList();
                    ml.Date = item.Date;
                    ml.item = item.Item;
                    ml.Variant = item.Variant;
                    ml.qty = (double)(item.Qty ?? 0);
                    ml.location = item.Location;
                    ml.Movement_type = (Movetype)item.Movement_Type;
                    m.Add(ml);
                }
                var sbal = db.Items_Services_List.Where(o => (o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString())) && (o.Reversed == false || string.IsNullOrEmpty(o.Reversed.ToString())));
                foreach (var item in sbal)
                {
                    MovementList ml = new MovementList();
                    ml.Date = item.Date;
                    ml.item = item.Item;
                    ml.Variant = item.Variant;
                    ml.qty = -(double)(item.Qty ?? 0);
                    ml.location = item.Outlet;
                    ml.Movement_type = Movetype.Sale;
                    m.Add(ml);
                }
                var h = m.Where(o => o.qty > 0);
                return m.ToArray();

            }
        }
        public MovementList[] getlistlocal()
        {
            List<MovementList> m = new List<MovementList>();
            using (var db = new RiceEntities(rice.ConnectionString()))
            {
              
                           var lbal = db.Item_Movements;
                foreach (var item in lbal)
                {
                    MovementList ml = new MovementList();
                    ml.Date = item.Date;
                    ml.item = item.Item;
                    ml.Variant = item.Variant;
                    ml.qty = (double)(item.Qty ?? 0);
                    ml.location = item.Location;
                    ml.Movement_type = (Movetype)item.Movement_Type;
                    m.Add(ml);
                }
                var sbal = db.Items_Services_List;
                foreach (var item in sbal)
                {
                    MovementList ml = new MovementList();
                    ml.Date = item.Date;
                    ml.item = item.Item;
                    ml.Variant = item.Variant;
                    ml.qty = -(double)(item.Qty ?? 0);
                    ml.location = item.Outlet;
                    ml.Movement_type = Movetype.Sale;
                    m.Add(ml);
                }
                var h = m.Where(o => o.qty > 0);
                return m.ToArray();

            }
        }

    }
}
