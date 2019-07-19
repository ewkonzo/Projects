using Hangfire;
using Rice.ConversionMatrix;
using Rice.Movement;
using Rice.Resources;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Rice
{
    public class externaldata
    {
        
public static CancellationTokenSource tokenSource = new CancellationTokenSource();
public static CancellationToken token = tokenSource.Token;

        public Collections.Collection_Service collectionservice = new Collections.Collection_Service();
        public Bagweight.BagWeight_Service bagweightservice = new Bagweight.BagWeight_Service();
        public Company_info.Company_Service companyservice = new Company_info.Company_Service();
        public PaddyBags.Paddy_bags_Service bagsservice = new PaddyBags.Paddy_bags_Service();
        public ItemEntries.Itementries_Service itementriesservice = new ItemEntries.Itementries_Service();
        public ItemMovementHeader.ItemMovementHeader_Service itemmovementheader = new ItemMovementHeader.ItemMovementHeader_Service();
        public ItemMovement_Service movementservice = new Movement.ItemMovement_Service();
        public ConversionMatrix_Service matrixservice = new ConversionMatrix.ConversionMatrix_Service();
        public Members.Members_Service memberservice = new Members.Members_Service();
        public Dimensions.Dimensions_Service dimensionsservice = new Dimensions.Dimensions_Service();
        public NewContact.Contact_Service contactsservice = new NewContact.Contact_Service();
        public banks.Banks_Service bankservice = new banks.Banks_Service();
        public Units.Units_Service unitservice = new Units.Units_Service();
        public AUsers.Users_Service usersservice = new AUsers.Users_Service();
        public Alternate.Alternate alternate = new Alternate.Alternate();
        public Vendors.Vendors_Service vendorservice = new Vendors.Vendors_Service();
        public Services.Services_Service service = new Services.Services_Service();
        public NavItems.Items_Service itemservice = new NavItems.Items_Service();
        public ItemList.ItemsList_Service itemlistservice = new ItemList.ItemsList_Service();
        public Prices.Prices_Service priceservice = new Prices.Prices_Service();
        public Outlets.Outlets_Service outletservice = new Outlets.Outlets_Service();
        public Reversals.Reversals_Service reversalservice = new Reversals.Reversals_Service();
        public Setup.Setup_Service setup_Service = new Setup.Setup_Service();
        public Resource_Service resourceservice = new Resource_Service();
        public Trans.Transporter_Service transporter_Service = new Trans.Transporter_Service();
        public static bool stop = false;
        private System.Net.NetworkCredential cd;
        public externaldata()
        {
            ServicePointManager.ServerCertificateValidationCallback = (object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => (true);

            string path = "Settings.xml";

            var s = new settings().loadsettings(path);
        
            cd = new System.Net.NetworkCredential(s.EUsername, s.Epass, s.domain);
            collectionservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Collection", s.Serverip, s.Companyname, s.EInstance, s.Port);
            collectionservice.Credentials = cd;
            collectionservice.PreAuthenticate = true;

            bagweightservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/BagWeight", s.Serverip, s.Companyname, s.EInstance, s.Port);
            bagweightservice.Credentials = cd;
            bagweightservice.PreAuthenticate = true;

            matrixservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/ConversionMatrix", s.Serverip, s.Companyname, s.EInstance, s.Port);
            matrixservice.Credentials = cd;
            matrixservice.PreAuthenticate = true;

            bagsservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Paddy_bags", s.Serverip, s.Companyname, s.EInstance, s.Port);
            bagsservice.Credentials = cd;
            bagsservice.PreAuthenticate = true;

            companyservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Company", s.Serverip, s.Companyname, s.EInstance, s.Port);
            companyservice.Credentials = cd;
            companyservice.PreAuthenticate = true;

            memberservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Members", s.Serverip, s.Companyname, s.EInstance, s.Port);
            memberservice.Credentials = cd;
            memberservice.PreAuthenticate = true;

            dimensionsservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Dimensions", s.Serverip, s.Companyname, s.EInstance, s.Port);
            dimensionsservice.Credentials = cd;
            dimensionsservice.PreAuthenticate = true;

            contactsservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Contact", s.Serverip, s.Companyname, s.EInstance, s.Port);
            contactsservice.Credentials = cd;
            contactsservice.PreAuthenticate = true;

            bankservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Banks", s.Serverip, s.Companyname, s.EInstance, s.Port);
            bankservice.Credentials = cd;
            bankservice.PreAuthenticate = true;

            unitservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Units", s.Serverip, s.Companyname, s.EInstance, s.Port);
            unitservice.Credentials = cd;
            unitservice.PreAuthenticate = true;

            usersservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Users", s.Serverip, s.Companyname, s.EInstance, s.Port);
            usersservice.Credentials = cd;
            usersservice.PreAuthenticate = true;

            //Logging.Logging.LogEntryOnFile(usersservice.Url);
            //NetworkCredential networkCredential = new NetworkCredential(s.EUsername, s.Epass);
            //CredentialCache credentialCaches = new CredentialCache();
            ////msacco codeunit
            //usersservice.Url = string.Format("https://{0}:{3}/{2}/WS/{1}/Page/Users", s.Serverip, s.Companyname, s.EInstance, s.Port);
            //usersservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("E:\\Tray\\cert\\navcert.cer"));
            //usersservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("E:\\Tray\\cert\\navcert.cer"));
            //credentialCaches.Add(new Uri(usersservice.Url), "Basic", networkCredential);
            //usersservice.Credentials = credentialCaches;
            //usersservice.PreAuthenticate = true;



            alternate.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/Alternate", s.Serverip, s.Companyname, s.EInstance, s.Port);
            alternate.Credentials = cd;
            alternate.PreAuthenticate = true;

            itemservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Items", s.Serverip, s.Companyname, s.EInstance, s.Port);
            itemservice.Credentials = cd;
            itemservice.PreAuthenticate = true;

            itemlistservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/ItemsList", s.Serverip, s.Companyname, s.EInstance, s.Port);
            itemlistservice.Credentials = cd;
            itemlistservice.PreAuthenticate = true;

            service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Services", s.Serverip, s.Companyname, s.EInstance, s.Port);
            service.Credentials = cd;
            service.PreAuthenticate = true;

            priceservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Prices", s.Serverip, s.Companyname, s.EInstance, s.Port);
            priceservice.Credentials = cd;
            priceservice.PreAuthenticate = true;

            outletservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Outlets", s.Serverip, s.Companyname, s.EInstance, s.Port);
            outletservice.Credentials = cd;
            outletservice.PreAuthenticate = true;

            vendorservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Vendors", s.Serverip, s.Companyname, s.EInstance, s.Port);
            vendorservice.Credentials = cd;
            vendorservice.PreAuthenticate = true;

            itementriesservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Itementries", s.Serverip, s.Companyname, s.EInstance, s.Port);
            itementriesservice.Credentials = cd;
            itementriesservice.PreAuthenticate = true;

            itemmovementheader.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/ItemMovementHeader", s.Serverip, s.Companyname, s.EInstance, s.Port);
            itemmovementheader.Credentials = cd;
            itemmovementheader.PreAuthenticate = true;

            movementservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/ItemMovement", s.Serverip, s.Companyname, s.EInstance, s.Port);
            movementservice.Credentials = cd;
            movementservice.PreAuthenticate = true;

            reversalservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Reversals", s.Serverip, s.Companyname, s.EInstance, s.Port);
            reversalservice.Credentials = cd;
            reversalservice.PreAuthenticate = true;

            resourceservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Resource", s.Serverip, s.Companyname, s.EInstance, s.Port);
            resourceservice.Credentials = cd;
            resourceservice.PreAuthenticate = true;

            setup_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Setup", s.Serverip, s.Companyname, s.EInstance, s.Port);
            setup_Service.Credentials = cd;
            setup_Service.PreAuthenticate = true;

 transporter_Service.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Transporter", s.Serverip, s.Companyname, s.EInstance, s.Port);
            transporter_Service.Credentials = cd;
            transporter_Service.PreAuthenticate = true;
        }
        //public externaldata()
        //{
        //    string path = "Settings.xml";
        //    var s = new settings().loadsettings(path);


        //    NetworkCredential networkCredential = new NetworkCredential(s.Username, s.pass);
        //    CredentialCache credentialCaches = new CredentialCache();

        //    collectionservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Collection", s.Serverip, s.Companyname, s.EInstance, s.Port);
        //    collectionservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("E:\\CERTS\\NavServiceCert.cer"));
        //    collectionservice.ClientCertificates.Add(X509Certificate.CreateFromCertFile("E:\\CERTS\\RootNavServiceCA.cer"));
        //    credentialCaches.Add(new Uri(collectionservice.Url), "Basic", networkCredential);
        //    collectionservice.Credentials = credentialCaches;
        //    collectionservice.PreAuthenticate = true;

        //    bagweightservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/BagWeight", s.Serverip, s.Companyname, s.EInstance, s.Port);
        //    bagweightservice.Credentials = cd;
        //    bagweightservice.PreAuthenticate = true;

        //    bagsservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Paddy bags", s.Serverip, s.Companyname, s.EInstance, s.Port);
        //    bagsservice.Credentials = cd;
        //    bagsservice.PreAuthenticate = true;

        //    companyservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Company", s.Serverip, s.Companyname, s.EInstance, s.Port);
        //    companyservice.Credentials = cd;
        //    companyservice.PreAuthenticate = true;

        //    memberservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Members", s.Serverip, s.Companyname, s.EInstance, s.Port);
        //    memberservice.Credentials = cd;
        //    memberservice.PreAuthenticate = true;

        //    dimensionsservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Dimensions", s.Serverip, s.Companyname, s.EInstance, s.Port);
        //    dimensionsservice.Credentials = cd;
        //    dimensionsservice.PreAuthenticate = true;

        //    contactsservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Contact", s.Serverip, s.Companyname, s.EInstance, s.Port);
        //    contactsservice.Credentials = cd;
        //    contactsservice.PreAuthenticate = true;

        //    bankservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Banks", s.Serverip, s.Companyname, s.EInstance, s.Port);
        //    bankservice.Credentials = cd;
        //    bankservice.PreAuthenticate = true;

        //    unitservice.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Page/Units", s.Serverip, s.Companyname, s.EInstance, s.Port);
        //    unitservice.Credentials = cd;
        //    unitservice.PreAuthenticate = true;
        //    alternate.Url = string.Format("http://{0}:{3}/{2}/WS/{1}/Codeunit/Alternate", s.Serverip, s.Companyname, s.EInstance, s.Port);
        //    alternate.Credentials = cd;
        //    alternate.PreAuthenticate = true;
        //}
        public void load()
        {
            try
            {
                if (Environment.MachineName != "PAULO")
                {
                    Logging.Logging.LogEntryOnFile("Starting sync");
                    Task.Factory.StartNew(() => InventoryPrices(), TaskCreationOptions.LongRunning);
                    Task.Factory.StartNew(() => customers(), TaskCreationOptions.LongRunning);
                    Task.Factory.StartNew(() => paddy(), TaskCreationOptions.LongRunning);
                    Task.Factory.StartNew(() => Inventory(), TaskCreationOptions.LongRunning);
                    Task.Factory.StartNew(() => ItemMovement(), TaskCreationOptions.LongRunning);
                    Task.Factory.StartNew(() => companyinfo(), TaskCreationOptions.LongRunning);
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
        }
        public void users()
        {          
                try
                {
                    using (var db = new RiceEntities(rice.ConnectionString()))
                    {
                        #region users
                        try
                        {
                            var updatedusers = db.Users.Where(o => o.Updated == true);
                            if (updatedusers.Count() > 0)
                            {
                                foreach (var u in updatedusers)
                                {
                                    var au = usersservice.ReadMultiple(new AUsers.Users_Filter[] { new AUsers.Users_Filter { Criteria = u.Name, Field = AUsers.Users_Fields.User_Name } }, null, 0).FirstOrDefault();

                                    if (au != null)
                                    {
                                        au.Password = u.Password;
                                        au.Password_Changed = true;
                                        au.Date_Password_Changed = (DateTime)u.Date_Password_Changed;
                                        au.Password_ChangedSpecified = true;
                                        au.Date_Password_ChangedSpecified = true;
                                        usersservice.Update(ref au);
                                        u.Updated = false;
                                    }
                                }

                            } db.SaveChanges();

                            var c = usersservice.ReadMultiple(new AUsers.Users_Filter[] { }, null, 0).ToList();
                        foreach (var u in c)
                        {
                            var uu = db.Users.FirstOrDefault(o => o.Name == u.User_Name);
                            if (uu == null)
                            {
                                uu = new User();
                                uu.Name = u.User_Name;
                                uu.Password_Changed = false;
                                
                                db.Users.Add(uu);
                            }
                            uu.Phone = u.Phone_Number;
                            uu.Password = u.Password;
                            //uu.Date_Created = u.Date_Added;
                            uu.Phone = u.Phone_Number;
                            uu.Full_Name = u.Full_Name;
                            uu.Type = ((int)u.Type).ToString();
                            if (u.User_Outlets.Count() > 0)
                            {
                                db.User_outlets.RemoveRange(db.User_outlets.Where(o => o.User_Name == uu.Name));
                                foreach (var item in u.User_Outlets)
                                {
                                    var user = new User_outlet();
                                    user.User_Name = item.User_Name;
                                    user.Active_Outlet = item.Active_Outlet;
                                    db.User_outlets.Add(user);
                                }
                            }
                            if (u.Reset)
                            {
                                uu.Password = u.Password;
                                uu.Password_Changed = false;
                            }
                            if (u.Password_Changed)
                            {
                                uu.Password = u.Password;
                                uu.Password_Changed = true;
                            }

                            u.Reset = false;
                            u.ResetSpecified = true;
                            AUsers.Users ua = u;
                            usersservice.Update(ref ua);

                        } db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Logging.Logging.ReportError(ex);

                        }
                        #endregion
                        #region company info
                        try
                        {
                            var c = companyservice.ReadMultiple(new Company_info.Company_Filter[] { }, null, 0).FirstOrDefault();
                            if (c != null)
                            {
                                var cc = db.Companies.FirstOrDefault();
                                if (cc == null)
                                {
                                    cc = new Company();
                                    db.Companies.Add(cc);
                                }
                                cc.Name = c.Name;
                                cc.Phone_No_ = c.Phone_No;
                                cc.Address = c.Address;
                                cc.City = c.City;
                                cc.Company_P_I_N = c.Company_P_I_N;
                                cc.Post_Code = c.Post_Code;
                                cc.Registration_No_ = c.VAT_Registration_No;
                                cc.VAT_Registration_No_ = c.VAT_Registration_No;
                                cc.Home_Page = c.Home_Page;
                                cc.E_Mail = c.E_Mail;
                                cc.Location = c.Location;
                                cc.Branch_Location = c.Branch_Location;
                                cc.Managers_Phone_No = c.Managers_Phone_No;
                                cc.Operations_Phone_No = c.Operations_Phone_No;
                                cc.Sales_Supervisor = c.Sales_Supervisor;
                                cc.Mission = c.Mission;
                                cc.Vision = c.Vision;
                                string picture = string.Empty;
                                alternate.Companyimages(ref picture);
                                if (picture == string.Empty)
                                    return;
                                byte[] buffer = Convert.FromBase64String(picture);
                                cc.Picture = buffer;
                              var s = db.Settings.FirstOrDefault();
                                if (s != null)
                                    s.Current_crop = c.Season;
                            }
                        }
                        catch (Exception ex)
                        {
                            Logging.Logging.ReportError(ex);
                        }
                        #endregion
                        #region Outlets
                        try
                        {

                            var outlets = outletservice.ReadMultiple(new Outlets.Outlets_Filter[] { }, null, 0).ToList();
                            if (outlets.Count > 0)
                            {
                                db.Category_locations.RemoveRange(db.Category_locations);
                                db.Outlets.RemoveRange(db.Outlets);
                                foreach (var o in outlets)
                                {
                                    Outlet ot = new Outlet();
                                    ot.Code = o.Code;
                                    ot.Name = o.Name;
                                ot.Price =(int) o.Price_Category;
                                    db.Outlets.Add(ot);

                                    foreach (var loc in o.Location_Items)
                                    {
                                        Category_location c = new Category_location();
                                        c.Category = loc.Category;
                                        c.Description = loc.Description;
                                        c.Location = loc.Location;
                                        db.Category_locations.Add(c);
                                    }
                                }

                            } db.SaveChanges();
                        }
                        catch (Exception b)
                        {
                            Logging.Logging.ReportError(b);

                        }
                        #endregion
                        #region Banks
                        try
                        {
                            var c = bankservice.ReadMultiple(new banks.Banks_Filter[] { }, null, 0).ToList();
                            if (c.Count > 0)
                            {
                                foreach (var bank in c)
                                {


                                    var cc = db.Bank_Accounts.FirstOrDefault(o => o.No_ == bank.No);
                                    if (cc == null)
                                    {
                                        cc = new Bank_Account();
                                        cc.No_ = bank.No;
                                        db.Bank_Accounts.Add(cc);
                                    }
                                    cc.Name = bank.Name;

                                    db.SaveChanges();
                                }
                            }

                        }
                        catch (Exception i)
                        {
                            Logging.Logging.ReportError(i);
                        }
                        #endregion
                        #region Dimensions
                        try
                        {

                            var cc = dimensionsservice.ReadMultiple(new Dimensions.Dimensions_Filter[] { }, null, 0);
                            foreach (var c in cc)
                            {
                                var d = db.Dimensions.FirstOrDefault(o => o.Dimension_Code == c.Dimension_Code && o.Code == c.Code);
                                if (d == null)
                                {
                                    d = new Dimension();
                                    d.Code = c.Code;
                                    d.Dimension_Code = c.Dimension_Code;
                                    db.Dimensions.Add(d);
                                }
                                d.Name = c.Name;

                            }


                        }
                        catch (Exception i)
                        {
                            Logging.Logging.ReportError(i);
                        }
                        #endregion
                        #region units
                        try
                        {
                            var c = unitservice.ReadMultiple(new Units.Units_Filter[] { }, null, 0).ToList();
                            if (c.Count > 0)
                            {
                                foreach (var unit in c)
                                {
                                    var cc = db.Units.FirstOrDefault(o => o.Code == unit.Code && o.Section == unit.Section);
                                    if (cc == null)
                                    {
                                        cc = new Unit();
                                        cc.Code = unit.Code;
                                        cc.Section = unit.Section;
                                        db.Units.Add(cc);
                                    }
                                    cc.Name = unit.Name;
                                    db.SaveChanges();
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Logging.Logging.ReportError(e);
                        }
                        #endregion
                        #region bagsweight
                        try
                        {
                            var c = bagweightservice.ReadMultiple(new Bagweight.BagWeight_Filter[] { }, null, 0).ToList();
                            if (c.Count > 0)
                            {
                                db.Bag_Weights.RemoveRange(db.Bag_Weights);
                                foreach (var unit in c)
                                {


                                    var cc = new Bag_Weight();
                                    cc.Bag_Type = (int)unit.Bag_Type;
                                    cc.Weight = unit.Weight;
                                    db.Bag_Weights.Add(cc);
                                } db.SaveChanges();
                            }
                        }
                        catch (Exception e)
                        {
                            Logging.Logging.ReportError(e);
                        }
                        #endregion
                       db.SaveChanges();
                    }
                }
                catch (Exception i)
                {
                    Logging.Logging.ReportError(i);
                }
        }
        public void companyinfo()
        {
            while (stop == false)
            {
                try
                {
                    using (var db = new RiceEntities(rice.ConnectionString()))
                    {
                        #region users
                        try
                        {
                            var updatedusers = db.Users.Where(o => o.Updated == true);
                            if (updatedusers.Count() > 0)
                            {
                                foreach (var u in updatedusers)
                                {
                                    var au = usersservice.ReadMultiple(new AUsers.Users_Filter[] { new AUsers.Users_Filter { Criteria = u.Name, Field = AUsers.Users_Fields.User_Name } }, null, 0).FirstOrDefault();

                                    if (au != null)
                                    {
                                        au.Password = u.Password;
                                        au.Password_Changed = true;
                                        au.Date_Password_Changed = (DateTime)u.Date_Password_Changed;
                                        au.Password_ChangedSpecified = true;
                                        au.Date_Password_ChangedSpecified = true;
                                        usersservice.Update(ref au);
                                        u.Updated = false;
                                    }
                                }

                            }
                            db.SaveChanges();
                            
                            var c = usersservice.ReadMultiple(new AUsers.Users_Filter[] { }, null, 0).ToList();
                            foreach (var u in c)
                            {
                                var uu = db.Users.FirstOrDefault(o => o.Name == u.User_Name);
                                if (uu == null)
                                {
                                    uu = new User();
                                    uu.Name = u.User_Name;
                                  
                                    //uu.Date_Created = u.Date_Added;
                                    uu.Password_Changed = false;
                                   
                                    db.Users.Add(uu);
                                }  uu.Phone = u.Phone_Number;
                                uu.Password = u.Password;
                                uu.Type = ((int) (u.Type)).ToString();
                                uu.Phone = u.Phone_Number;
                                uu.Full_Name = u.Full_Name;
                                if (u.User_Outlets.Count() > 0)
                                {
                                    db.User_outlets.RemoveRange(db.User_outlets.Where(o => o.User_Name == uu.Name));

                                    foreach (var item in u.User_Outlets)
                                    {
                                        var user = new User_outlet();
                                        user.User_Name = item.User_Name;
                                        user.Active_Outlet = item.Active_Outlet;
                                        db.User_outlets.Add(user);
                                    }
                                }
                                if (u.Reset)
                                {
                                    uu.Password = u.Password;
                                    uu.Password_Changed = false;
                                }
                                if (u.Password_Changed)
                                {
                                    uu.Password = u.Password;
                                    uu.Password_Changed = true;
                                }
                                u.Reset = false;
                                u.ResetSpecified = true;
                                AUsers.Users ua = u;
                                usersservice.Update(ref ua);

                            } db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Logging.Logging.ReportError(ex);

                        }
                        #endregion
                        #region company info
                        try
                        {
                            var c = companyservice.ReadMultiple(new Company_info.Company_Filter[] { }, null, 0).FirstOrDefault();
                            if (c != null)
                            {
                                var cc = db.Companies.FirstOrDefault();
                                if (cc == null)
                                {
                                    cc = new Company();
                                    db.Companies.Add(cc);
                                }
                                cc.Name = c.Name;
                                cc.Phone_No_ = c.Phone_No;
                                cc.Address = c.Address;
                                cc.City = c.City;
                                cc.Company_P_I_N = c.Company_P_I_N;
                                cc.Post_Code = c.Post_Code;
                                cc.Registration_No_ = c.VAT_Registration_No;
                                cc.VAT_Registration_No_ = c.VAT_Registration_No;
                                cc.Home_Page = c.Home_Page;
                                cc.E_Mail = c.E_Mail;
                                cc.Location = c.Location;
                                cc.Branch_Location = c.Branch_Location;
                                cc.Managers_Phone_No = c.Managers_Phone_No;
                                cc.Operations_Phone_No = c.Operations_Phone_No;
                                cc.Sales_Supervisor = c.Sales_Supervisor;
                                cc.Mission = c.Mission;
                                cc.Vision = c.Vision;
                                string picture = string.Empty;
                                alternate.Companyimages(ref picture);
                                if (picture == string.Empty)
                                    return;
                                byte[] buffer = Convert.FromBase64String(picture);
                                cc.Picture = buffer;
                                var s = db.Settings.FirstOrDefault();
                                if (s != null)
                                    s.Current_crop = c.Season;
                            }
                            var setup = setup_Service.ReadMultiple(new Setup.Setup_Filter[] { }, null, 0).FirstOrDefault();
                            if (setup !=null){
                              
                                var ss = db.Settings.FirstOrDefault();
                                if (ss.Override_Settings ?? false == false)
                                {
                                    ss.Bags_Weight = (double)setup.Bags_Weight;
                                    ss.Validate_weight = setup.Validate_weight;
                                    ss.Max_moisture = (double)setup.Max_moisture;
                                    ss.Max_Recovery = (double)setup.Max_Recovery;
                                }
                            }
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Logging.Logging.ReportError(ex);
                        }
                        #endregion
                        #region Outlets
                        try
                        {
                           var outlets = outletservice.ReadMultiple(new Outlets.Outlets_Filter[] { }, null, 0).ToList();
                            if (outlets.Count > 0)
                            {
                                db.Category_locations.RemoveRange(db.Category_locations);
                                db.Outlets.RemoveRange(db.Outlets);
                                foreach (var o in outlets)
                                {
                                    Outlet ot = new Outlet();
                                    ot.Code = o.Code;
                                    ot.Name = o.Name;
                                    ot.Price =(int) o.Price_Category;
                                    db.Outlets.Add(ot);

                                    foreach (var loc in o.Location_Items)
                                    {
                                        Category_location c = new Category_location();
                                        c.Category = loc.Category;
                                        c.Description = loc.Description;
                                        c.Location = loc.Location;
                                        db.Category_locations.Add(c);
                                    }
                                }

                            } db.SaveChanges();
                        }
                        catch (Exception b)
                        {
                            Logging.Logging.ReportError(b);

                        }
                        #endregion
                        #region Banks
                        try
                        {


                            var c = bankservice.ReadMultiple(new banks.Banks_Filter[] { }, null, 0).ToList();
                            if (c.Count > 0)
                            {
                                foreach (var bank in c)
                                {


                                    var cc = db.Bank_Accounts.FirstOrDefault(o => o.No_ == bank.No);
                                    if (cc == null)
                                    {
                                        cc = new Bank_Account();
                                        cc.No_ = bank.No;
                                        db.Bank_Accounts.Add(cc);
                                    }
                                    cc.Name = bank.Name;

                                    db.SaveChanges();
                                }
                            }

                        }
                        catch (Exception i)
                        {
                            Logging.Logging.ReportError(i);
                        }
                        #endregion
                        #region Dimensions
                        try
                        {

                            var cc = dimensionsservice.ReadMultiple(new Dimensions.Dimensions_Filter[] { }, null, 0);
                            foreach (var c in cc)
                            {
                                var d = db.Dimensions.FirstOrDefault(o => o.Dimension_Code == c.Dimension_Code && o.Code == c.Code);
                                if (d == null)
                                {
                                    d = new Dimension();
                                    d.Code = c.Code;
                                    d.Dimension_Code = c.Dimension_Code;
                                    db.Dimensions.Add(d);
                                }
                                d.Name = c.Name;

                            }


                        }
                        catch (Exception i)
                        {
                            Logging.Logging.ReportError(i);
                        }
                        #endregion
                        #region units
                        try
                        {
                            var c = unitservice.ReadMultiple(new Units.Units_Filter[] { }, null, 0).ToList();
                            if (c.Count > 0)
                            {
                                foreach (var unit in c)
                                {
                                    var cc = db.Units.FirstOrDefault(o => o.Code == unit.Code && o.Section == unit.Section);
                                    if (cc == null)
                                    {
                                        cc = new Unit();
                                        cc.Code = unit.Code;
                                        cc.Section = unit.Section;
                                        db.Units.Add(cc);
                                    }
                                    cc.Name = unit.Name;
                                    db.SaveChanges();
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Logging.Logging.ReportError(e);
                        }
                        #endregion
                        #region bagsweight
                        try
                        {
                            var c = bagweightservice.ReadMultiple(new Bagweight.BagWeight_Filter[] { }, null, 0).ToList();
                            if (c.Count > 0)
                            {
                                db.Bag_Weights.RemoveRange(db.Bag_Weights);
                                foreach (var unit in c)
                                {
                                  
                                    
                                      var  cc = new Bag_Weight();
                                        cc.Bag_Type =(int) unit.Bag_Type;
                                        cc.Weight = unit.Weight;
                                       db.Bag_Weights .Add(cc);
                                } db.SaveChanges();
                            }
                        }
                        catch (Exception e)
                        {
                            Logging.Logging.ReportError(e);
                        }
                        #endregion
                        db.SaveChanges();
                    }
                }
                catch (Exception i)
                {
                    Logging.Logging.ReportError(i);
                }
                System.Threading.Thread.Sleep(30000);
            }
        }
        public void InventoryPrices()
        {
            while (stop == false)
            {
                try
                {
                    using (var db = new RiceEntities(rice.ConnectionString()))
                    {
                        #region inventory balances
                        try
                        {
                            string no = string.Empty;
                            //var c = itementriesservice.ReadMultiple(new ItemEntries.Itementries_Filter[] { }, null, 0).ToList();
                            //if (c.Count() > 0)

                            //    //db.Item_Balances.RemoveRange(db.Item_Balances.ToList());
                            //    foreach (var u in c)
                            //    {
                            //        var cc = db.Item_Balances.FirstOrDefault(o => o.Entry_No == u.Entry_No.ToString() && o.Location == u.Location_Code);
                            //        if (cc == null)
                            //        {
                            //            cc = new Item_Balance();
                            //            cc.Entry_No = u.Entry_No.ToString();

                            //            db.Item_Balances.Add(cc);
                            //        }
                            //            cc.Item = u.Item_No;
                            //            cc.Variant = u.Variant_Code;
                            //            cc.Location = u.Location_Code;
                            //            cc.Balance = (double)u.Quantity;
                            //            cc.Date = u.Posting_Date;
                            //    }
                            //    db.SaveChanges();

                            var sale = itemlistservice.ReadMultiple(new ItemList.ItemsList_Filter[] { new ItemList.ItemsList_Filter { Criteria = rice.setup.POS_Outlet, Field = ItemList.ItemsList_Fields.Outlet } }, null, 0).ToList();
                            if (sale.Count() > 0)
                            {
                                //db.Item_Balances.RemoveRange(db.Item_Balances.ToList());
                                var bal = db.Item_Balances.ToArray();
                                foreach (var u in sale.OrderByDescending(o=> o.Entry).ToList())
                                {
                                    var cc = bal.FirstOrDefault(o => o.Entry_No == u.Entry.ToString() && o.Type == "sale");
                                    if (cc == null)
                                    {
                                        try
                                        {
                                            if (u.Qty != 0)
                                            {
                                                cc = new Item_Balance();
                                                cc.Entry_No = u.Entry.ToString();
                                                cc.Type = "sale";
                                                cc.Location = u.Outlet;
                                                cc.Balance = ((double)u.Qty) * -1;
                                                cc.Item = u.Item;
                                                cc.Variant = u.Variant;
                                                cc.Date = new DateTime(u.Date.Year, u.Date.Month, u.Date.Day);
                                                cc.Move_Type = 5;
                                                cc.Ref = u.Receipt_No;
                                                db.Item_Balances.Add(cc);
                                                db.SaveChanges();
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Logging.Logging.ReportError(e);
                                            DbEntityEntry entry = db.Entry(cc);
                                            switch (entry.State)
                                            {

                                                case EntityState.Added:
                                                    entry.State = EntityState.Detached;
                                                    break;

                                                default: break;
                                            }
                                        }
                                    }

                                } db.SaveChanges();
                            }
                            var un = movementservice.ReadMultiple(new ItemMovement_Filter[] { new ItemMovement_Filter { Criteria = rice.setup.POS_Outlet, Field = ItemMovement_Fields.Location } }, null, 0).ToList();
                            if (un.Count() > 0)
                            {
                                var bal = db.Item_Balances.ToArray();
                                foreach (var uu in un.OrderByDescending(o => o.Entry).ToList())
                                {
                                    Logging.Logging.LogEntryOnFile(uu.Entry.ToString());
                                    var ccc = bal.FirstOrDefault(o => o.Entry_No == uu.Entry.ToString() && o.Type == "move");
                                    if (ccc == null)
                                    {
                                        try
                                        {
                                            if (uu.Qty != 0) { 
                                            ccc = new Item_Balance();
                                            ccc.Entry_No = uu.Entry.ToString();
                                            ccc.Type = "move";
                                            ccc.Item = uu.Item;
                                            ccc.Variant = uu.Variant;
                                            ccc.Location = uu.Location;
                                            ccc.Balance = (double)uu.Qty;
                                            ccc.Date = new DateTime(uu.Date.Year, uu.Date.Month, uu.Date.Day);
                                            ccc.Ref = uu.Reference;
                                            ccc.Move_Type = (int)uu.Movement_Type;
                                            ccc.From_Location = uu.Location_To;
                                                
                                                db.Item_Balances.Add(ccc);
                                            db.SaveChanges();
                                                Logging.Logging.LogEntryOnFile(uu.Entry.ToString() + "Added");
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Logging.Logging.ReportError(e);
                                            DbEntityEntry entry = db.Entry(ccc);
                                            switch (entry.State)
                                            {

                                                case EntityState.Added:
                                                    entry.State = EntityState.Detached;
                                                    break;

                                                default: break;
                                            }
                                        }
                                    }
                                }
                                db.SaveChanges();
                            }
                        }
                        catch (Exception e)
                        {
                            Logging.Logging.ReportError(e);
                        }
                        #endregion
                        #region matrix
                        try
                        {
                            var p = matrixservice.ReadMultiple(new ConversionMatrix_Filter[] { }, null, 0).ToList();
                            if (p.Count > 0)
                            {
                                db.Item_Conversion_Matrices.RemoveRange(db.Item_Conversion_Matrices.ToList());
                                foreach (var u in p)
                                {

                                    Item_Conversion_Matrix cc = new Item_Conversion_Matrix();
                                    cc.Item = u.Item;
                                    cc.Variant = u.Variant;
                                    cc.To_Item = u.To_Item;
                                    cc.To_Variant = u.To_Variant;
                                    cc.Units = (int)u.Units;

                                    db.Item_Conversion_Matrices.Add(cc);

                                    db.SaveChanges();
                                }
                            } db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Logging.Logging.ReportError(e);
                        }
                        #endregion
                        #region Prices
                        try
                        {
                            var p = priceservice.ReadMultiple(new Prices.Prices_Filter[] { }, null, 0).ToList();
                            if (p.Count > 0)
                            {
                                //db.Sales_Prices.RemoveRange(db.Sales_Prices.ToList());
                                var pr = db.Sales_Prices.ToArray();
                                foreach (var u in p)
                                {
                                    var cc = pr.FirstOrDefault(o => o.Item_No_ == u.Item_No && o.Variant_Code == u.Variant_Code && o.Starting_Date == u.Starting_Date && o.Ending_Date == u.Ending_Date && (Prices.Sales_Type)o.Sales_Type == u.Sales_Type && o.Sales_Code == u.Sales_Code);
                                    if (cc == null)
                                    {
                                        cc = new Sales_Price();
                                        cc.Item_No_ = u.Item_No;
                                        cc.Variant_Code = u.Variant_Code;
                                        cc.Starting_Date = u.Starting_Date;
                                        cc.Ending_Date = u.Ending_Date;
                                        cc.Minimum_Quantity = (double)u.Minimum_Quantity;
                                        cc.Sales_Type = (int)u.Sales_Type;
                                        cc.Sales_Code = u.Sales_Code;

                                        db.Sales_Prices.Add(cc);
                                    }

                                    cc.Unit_Price = (double)u.Unit_Price;

                                }
                            } db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Logging.Logging.ReportError(e);
                        }

                        #endregion
                        #region reversals
                        try
                        {
                            var rev = db.Item_Reversals.Where(o => o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString())).ToList();
                            if (rev.Count() > 0)
                            {
                                foreach (var item in rev.ToList())
                                {
                                    try
                                    {
                                        var cur = reversalservice.Read(((Reversals.Entry_Type)item.Entry_Type).ToString(), item.Reversal_Id, item.Location);
                                        if (cur == null)
                                        {
                                            cur = new Reversals.Reversals();
                                            cur.Reversal_Id = item.Reversal_Id;
                                            cur.Location = item.Location;
                                            reversalservice.Create(ref cur);
                                        }
                                        cur.Entry_Type = (Reversals.Entry_Type)item.Entry_Type;
                                        cur.Comments = item.Comments;
                                        cur.Date = (DateTime)item.Date;
                                        cur.Time = (DateTime)item.Time;
                                        cur.DateSpecified = true;
                                        cur.TimeSpecified = true;
                                        cur.Reversed_By = item.Reversed_By;
                                        cur.Status = (Reversals.Status)item.Status;
                                        reversalservice.Update(ref cur);
                                        item.Comments = "";
                                        item.Sent = true;
                                        db.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        item.Comments = (ex.Message.Length > 100 ? ex.Message.Substring(0, 99) : ex.Message);
                                    }
                                }
                            }
                            rev = db.Item_Reversals.Where(o => o.Sent == true && (o.Reversed == false || string.IsNullOrEmpty(o.Reversed.ToString()))).ToList();
                            if (rev.Count() > 0)
                            {
                                foreach (var item in rev)
                                {
                                    try
                                    {
                                        var app = reversalservice.Read(((Reversals.Entry_Type)item.Entry_Type).ToString(), item.Reversal_Id, item.Location);
                                        if (app != null)
                                            if (app.Status == Reversals.Status.Approved)
                                            {
                                                item.Status = (int)app.Status;

                                                switch ((Reversals.Entry_Type)item.Entry_Type)
                                                {
                                                    case Reversals.Entry_Type.Movement:

                                                        int ent = Convert.ToInt32(item.Reversal_Id);

                                                        if (item.Reverse_document == false)
                                                        {
                                                            var m = db.Item_Movements.FirstOrDefault(o => o.Entry == ent);
                                                            if (m != null)
                                                            {
                                                                m.Reversed = true; db.Entry(m).State = System.Data.Entity.EntityState.Modified;
                                                                Item_Movement i = (Item_Movement)m.Clone();
                                                                i.Qty = m.Qty * -1;
                                                                i.Recid = DateTime.Now.Ticks;
                                                                i.Sent = false;
                                                                i.Reversed = true;
                                                                i.Reversed_by_entry = m.Entry;
                                                                db.Item_Movements.Add(i);

                                                            }
                                                        }
                                                        else
                                                        {
                                                            var m = db.Item_Movements.Where(o => o.Reference == item.Reference && o.Item == item.Item && o.Variant == item.Variant);
                                                            foreach (var i in m.ToList())
                                                            {
                                                                i.Reversed = true; db.Entry(i).State = System.Data.Entity.EntityState.Modified;
                                                                Item_Movement mm = (Item_Movement)i.Clone();
                                                                mm.Qty = i.Qty * -1;
                                                                mm.Sent = false;
                                                                mm.Recid = DateTime.Now.Ticks;
                                                                mm.Reversed = true;
                                                                mm.Reversed_by_entry = i.Entry;
                                                                db.Item_Movements.Add(mm);
                                                            }
                                                        }
                                                        break;
                                                    case Reversals.Entry_Type.Sale:
                                                        ent = Convert.ToInt32(item.Reversal_Id);
                                                        var s = db.Items_Services_List.FirstOrDefault(o => o.Entry == ent);
                                                        if (s != null)
                                                        {
                                                            s.Reversed = true;
                                                            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                                                            Items_Services_List i = (Items_Services_List)s.Clone();
                                                            i.Qty = s.Qty * -1;
                                                            i.Recid = DateTime.Now.Ticks;
                                                            i.Total_Cost = s.Total_Cost * -1;
                                                            i.Sent = false;
                                                            i.Reversed = true;
                                                            db.Items_Services_List.Add(i);
                                                        }
                                                        break;
                                                }
                                                item.Reversed = true;
                                            }
                                    }
                                    catch (Exception e)
                                    {
                                        Logging.Logging.ReportError(e);
                                        item.Comments = (e.Message.Length > 100 ? e.Message.Substring(0, 99) : e.Message);
                                    }
                                }
                            }



                            db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Logging.Logging.ReportError(e);
                        }

                        #endregion
                        #region Resources
                        try
                        {
                            var p = resourceservice.ReadMultiple(new Resource_Filter[] { }, null, 0).ToList();
                            if (p.Count > 0)
                            {
                                db.Resources.RemoveRange(db.Resources.ToList());
                                //var pr = db.Resources.ToArray();
                                foreach (var u in p)
                                {
                                    //var cc = pr.FirstOrDefault(o => o.No == u.No);
                                    //if (cc == null)
                                    //{
                                    Resource cc = new Resource();
                                    cc.No = u.No;
                                    cc.Name = u.Name;
                                    cc.Type = (int)u.Type;
                                    cc.Category = (int)u.Machine_Category;
                                    db.Resources.Add(cc);
                                    //}

                                }
                            } db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Logging.Logging.ReportError(e);
                        }

                        #endregion

                    }
                }
                catch (Exception i)
                {
                    Logging.Logging.ReportError(i);
                }
                System.Threading.Thread.Sleep(30000);
            }
        }
        public void customers()
        {
            while (stop == false)
            {
                try
                {
                    using (var db = new RiceEntities(rice.ConnectionString()))
                    {
                        #region vendors
                        try
                        {
                            var c = vendorservice.ReadMultiple(new Vendors.Vendors_Filter[] { }, null, 0);
                            if (c.Count() > 0)
                            {
                                //  db.Vendors.RemoveRange(db.Vendors.ToList());
                                foreach (var mm in c)
                                {
                                    var v = db.Vendors.FirstOrDefault(o => o.No == mm.No);
                                    if (v == null)
                                    {
                                        v = new Vendor();
                                        v.No = mm.No;
                                        db.Vendors.Add(v);
                                    }
                                    v.Name = mm.Name;
                                    v.Vendor_Posting_Group = mm.Vendor_Posting_Group;
                                }
                            }
                        }
                        catch (Exception ii)
                        {
                            Logging.Logging.ReportError(ii);
                        }
                        db.SaveChanges();

                        #endregion
                        #region Addcustomers
                        try
                        {
                            var cust = db.Customers.ToArray();
                            foreach (var item in cust)
                            {
                                try
                                {
                                    var cus = vendorservice.ReadMultiple(new Vendors.Vendors_Filter[] { new Vendors.Vendors_Filter { Criteria = "CUSTOMERS", Field = Vendors.Vendors_Fields.Vendor_Posting_Group }, new Vendors.Vendors_Filter { Criteria = item.ID, Field = Vendors.Vendors_Fields.No } }, null, 0).FirstOrDefault();
                                    if (cus == null)
                                    {
                                        cus = new Vendors.Vendors();
                                        cus.No = item.ID;
                                        cus.Vendor_Posting_Group = "CUSTOMERS";
                                        cus.Name = item.Name;
                                        cus.Bank = item.Bank;
                                        cus.Bank_Account = item.Bank_Account;
                                        vendorservice.Create(ref cus);
                                    }
                                }
                                catch (Exception i)
                                {
                                    Logging.Logging.ReportError(i);
                                }
                            }

                        }
                        catch (Exception ii)
                        {
                            Logging.Logging.ReportError(ii);
                        }
                        db.SaveChanges();
                        #endregion
                        #region customers
                        try
                        {
                            var c = vendorservice.ReadMultiple(new Vendors.Vendors_Filter[] { new Vendors.Vendors_Filter { Criteria = "CUSTOMERS", Field = Vendors.Vendors_Fields.Vendor_Posting_Group } }, null, 0);
                            if (c.Count() > 0)
                            {
                                foreach (var mm in c)
                                {
                                    var cust = db.Customers.FirstOrDefault(o => o.ID == mm.No);
                                    if (cust == null)
                                    {
                                        cust = new Customer();
                                        cust.ID = mm.No;
                                        db.Customers.Add(cust);
                                    }
                                    cust.Name = mm.Name;
                                    cust.Bank = mm.Bank;
                                    cust.Bank_Account = mm.Bank_Account;
                                    
                                }
                                db.SaveChanges();
                            }
                        }
                        catch (Exception ii)
                        {
                            Logging.Logging.ReportError(ii);
                        }
                        db.SaveChanges();
                        #endregion
                        #region AddTransporters
                        try
                        {
                            var trans = db.Transporters.ToArray();
                            foreach (var item in trans)
                            {
                                try
                                {
                                    var cus = vendorservice.ReadMultiple(new Vendors.Vendors_Filter[] { new Vendors.Vendors_Filter { Criteria = "TRANS", Field = Vendors.Vendors_Fields.Vendor_Posting_Group }, new Vendors.Vendors_Filter { Criteria = item.ID_No, Field = Vendors.Vendors_Fields.No } }, null, 0).FirstOrDefault();
                                    if (cus == null)
                                    {
                                        cus = new Vendors.Vendors();
                                        cus.No = item.ID_No;
                                        cus.Vendor_Posting_Group = "TRANS";
                                        cus.Name = item.Name;
                                        vendorservice.Create(ref cus);
                                    }

                                    var tr = transporter_Service.ReadMultiple(new Trans.Transporter_Filter[] { new Trans.Transporter_Filter { Criteria = item.Vehicle_No, Field = Trans.Transporter_Fields.Vehicle_No } }, null, 0).FirstOrDefault();// item.Vehicle_No);
                                    if (tr == null) {
                                        tr = new Trans.Transporter();
                                        tr.Vehicle_No = item.Vehicle_No;
                                        tr.Phone_No = item.Vehicle_No;
                                        tr.ID_No = item.ID_No;
                                        tr.Name = item.Name;
                                        transporter_Service.Create(ref tr);
                                    }
                                }
                                catch (Exception i)
                                {
                                    Logging.Logging.ReportError(i);
                                }
                            }

                        }
                        catch (Exception ii)
                        {
                            Logging.Logging.ReportError(ii);
                        }
                        db.SaveChanges();
                        #endregion
                        #region Transporters
                        try
                        {
                            var c = transporter_Service.ReadMultiple(new Trans.Transporter_Filter [] {  }, null, 0);
                            if (c.Count() > 0)
                            {
                                foreach (var mm in c)
                                {
                                    var cust = db.Transporters.FirstOrDefault(o => o.Vehicle_No == mm.Vehicle_No);
                                    if (cust == null)
                                    {
                                        cust = new Transporter();
                                        cust.Vehicle_No = mm.Vehicle_No;
                                        cust.ID_No = mm.ID_No;
                                        db.Transporters.Add(cust);
                                    }
                                    cust.Name = mm.Name;
                                    cust.Phone_No = mm.Phone_No;
                                   
                                }
                                db.SaveChanges();
                            }
                        }
                        catch (Exception ii)
                        {
                            Logging.Logging.ReportError(ii);
                        }
                        db.SaveChanges();
                        #endregion
                        #region farmers
                        try
                        {
                            var c = memberservice.ReadMultiple(new Members.Members_Filter[] { }, null, 1000);
                            while (c.Count() > 0)
                            {
                                var f = db.Farmers.ToList();
                                var no = string.Empty;
                                foreach (var mm in c)
                                {
                                    if (mm.No != null)
                                    {
                                        no = mm.Key;
                                        var m = f.FirstOrDefault(o => o.No == mm.No);
                                        if (m == null)
                                        {
                                            m = new Farmer();
                                            m.No = mm.No;
                                            f.Add(m);
                                            db.Farmers.Add(m);
                                        }
                                        m.Name = mm.Name;
                                        m.Phone = mm.Phone_No;
                                        m.Section = mm.Section;
                                        m.Unit = mm.Unit;
                                        m.ID_No = mm.National_ID;
                                        m.Gender = (int)mm.Gender;
                                        m.Bank = mm.Bank;
                                        m.Bank_Account = mm.Bank_Account_No;
                                        m.Class = mm.Membership_Class.ToString();
                                        m.Unit = mm.Unit;
                                        m.Customer_Posting_Group = mm.Customer_Posting_Group;
                                        m.Acreage = (double)mm.Total_Acreage;
                                        m.Serviced_Acres = (double)mm.Serviced_Acres;
                                        m.Status = (int)mm.Status;
                                        string picture = string.Empty;
                                        //alternate.GetCustomerImage(m.No, ref picture);
                                        //if (picture != string.Empty)
                                        //{
                                        //    byte[] buffer = Convert.FromBase64String(picture);
                                        //    m.Photo = buffer;
                                        //}
                                    }
                                }
                                f = null;
                                db.SaveChanges();
                                c = memberservice.ReadMultiple(new Members.Members_Filter[] { }, no, 1000);
                            }

                        }
                        catch (Exception i)
                        {
                            Logging.Logging.ReportError(i);
                        }
                        db.SaveChanges();
                        #endregion
                        #region new customers
                        try
                        {
                            var cc = db.Contacts.Where(o => o.Sent == false);
                            foreach (var c in cc.ToList())
                            {
                                try
                                {
                                    var co = contactsservice.ReadMultiple(new NewContact.Contact_Filter[] { new NewContact.Contact_Filter { Criteria = c.National_ID, Field = NewContact.Contact_Fields.National_ID }, new NewContact.Contact_Filter { Criteria = c.No_, Field = NewContact.Contact_Fields.Farmer_Number } }, null, 0).FirstOrDefault();
                                    if (co == null)
                                    {
                                        co = new NewContact.Contact();
                                        co.National_ID = c.National_ID;
                                        //co.No = c.No_;
                                        contactsservice.Create(ref co);
                                    }
                                    co.Farmer_Number = c.No_;
                                    co.National_ID = c.National_ID;
                                    co.Bank_Name = c.Bank_Name;
                                    co.Bank_Account_No = c.Bank_Account_No;
                                    co.Bank_Branch_Code = c.Bank_Branch_Code;
                                    co.Name = c.Name;
                                    co.Mobile_Phone_No = c.Mobile_Phone_No_;
                                    co.Created_By = c.Created_By;
                                    co.Created_Date = (DateTime)c.Created_Date;
                                    co.Created_DateSpecified = true;
                                    co.Date_of_Join = (DateTime)c.Date_of_Join;
                                    co.Date_of_JoinSpecified = true;
                                    co.E_Mail = c.E_Mail;
                                    co.Gender = (NewContact.Gender)(c.Gender ?? 0);
                                    co.GenderSpecified = true;
                                    co.Marital_Status = (NewContact.Marital_Status)(c.Marital_Status ?? 0);
                                    co.Marital_StatusSpecified = true;
                                    co.Payee_Name = c.Name;
                                    co.Section = c.Section;
                                    co.DOB = (DateTime)(c.DOB_ ?? DateTime.Now.Date);
                                    co.DOBSpecified = true;
                                    co.City = c.City;
                                    co.Main_Section_for_outgrowers = c.Main_Season;
                                    co.Unit = c.Unit;
                                    co.Total_Acreage = (decimal)(c.Total_Acreage ?? 0);
                                    co.Total_AcreageSpecified = true;
                                    co.Account_Types = (NewContact.Account_Types)(c.Account_Types ?? 1);
                                    co.Account_TypesSpecified = true;
                                    contactsservice.Update(ref co);
                                    c.Sent = true;
                                    db.SaveChanges();
                                    //try
                                    //{
                                    //    if (c.Picture != null)
                                    //    {
                                    //        byte[] buffer = c.Picture;
                                    //        string picture = Convert.ToBase64String(buffer);
                                    //        alternate.SetcontactImage(co.No, picture);
                                    //    }
                                    //}
                                    //catch (Exception e) { }
                                }
                                catch (Exception ex)
                                {
                                    Logging.Logging.ReportError(ex);
                                }
                            }
                        }
                        catch (Exception i)
                        {
                            Logging.Logging.ReportError(i);
                        }
                        #endregion
                        db.SaveChanges();
                    }
                }
                catch (Exception i)
                {
                    Logging.Logging.ReportError(i);
                }
                System.Threading.Thread.Sleep(30000);
            }
        }
        public void updatefotos()
        {
            try
            {
                memberservice.Timeout = 600000000;

                var c = memberservice.ReadMultiple(new Members.Members_Filter[] { }, null, 10000);
                foreach (var item in c)
                {
                    if (File.Exists(string.Format("E:\\Tray\\MembersPictures\\{0}.JPG", item.No)))
                    {
                        try
                        {
                            FileStream file = File.OpenRead(string.Format("E:\\Tray\\MembersPictures\\{0}.JPG", item.No));
                            byte[] buffer = new byte[file.Length];
                            file.Read(buffer, 0, buffer.Length);
                            file.Close();
                            string picture = Convert.ToBase64String(buffer);
                            alternate.SetCustomerImage(item.No, picture);
                        }
                        catch (Exception ex)
                        {
                            Logging.Logging.ReportError(ex);
                        }
                    }
                }
            }
            catch (Exception i)
            {
                Logging.Logging.ReportError(i);
            }


        }
        public void Getpaddybags()
        {
            try
            {               
                using (var db = new RiceEntities(rice.ConnectionString()))
                {
                    #region getbags
                    var ccc = bagsservice.ReadMultiple(new PaddyBags.Paddy_bags_Filter[] { }, null, 0);
                    foreach (var cc in ccc)
                    {
                        var p = db.Paddy_Bags.FirstOrDefault(o => o.Id == cc.Id);
                        if (p == null)
                        {
                            p = new Paddy_Bag();
                            p.Id = cc.Id;
                            p.Sent = true;
                            db.Paddy_Bags.Add(p);
                        }
                        if (p.Sent == true)
                        {
                            p.Action = (int)cc.Action;
                            p.Date = new DateTime(cc.Date.Year, cc.Date.Month, cc.Date.Day);
                            p.Time = new DateTime(cc.Date.Year, cc.Date.Month, cc.Date.Day, cc.Time.Hour, cc.Time.Minute, cc.Time.Second);
                            p.Bag_weight = cc.Bag_weight;
                            p.Gross_kg = cc.Gross_kg;
                            p.Net_kg = cc.Net_kg;
                            p.No_of_bags = (double)cc.No_of_bags;
                            p.Weight = cc.Weight;
                            p.Bag_type = (int)cc.Bag_type;
                            p.Farmer = cc.Farmer;
                            p.Paddy = cc.Paddy;
                            p.Moisture_Weight = (double)cc.Moisture_Weight;
                            p.Variety = cc.Variety;
                            p.Reversed = cc.Reversed;
                            
                        } db.SaveChanges();
                    }

                    #endregion
                }
            }
            catch (Exception i)
            {
                Logging.Logging.ReportError(i);

            }
        }
        public void Getpaddy()
        {
            try
            {
                using (var db = new RiceEntities(rice.ConnectionString()))
                {
                    #region getpaddy
                    try
                    {
                        var cg = collectionservice.ReadMultiple(new Collections.Collection_Filter[] { new Collections.Collection_Filter { Criteria = rice.setup.Current_crop, Field = Collections.Collection_Fields.Season } }, null, 0);
                        foreach (var cc in cg)
                        {
                            // Logging.Logging.LogEntryOnFile(cc.Collection_Number);
                            var p = db.Paddy_Details.FirstOrDefault(o => o.Collection_Number == cc.Collection_Number);
                            if (p == null)
                            {
                                p = new Paddy_Detail();
                                p.Collection_Number = cc.Collection_Number;
                                p.Sent = true;
                                db.Paddy_Details.Add(p);
                            }
                            if (p.Sent == true)
                            {
                                p.Collected_by = cc.Collected_by;
                                p.Collections_Date = new DateTime(cc.Collections_Date.Year, cc.Collections_Date.Month, cc.Collections_Date.Day);
                                p.Collect_type = (int)cc.Collect_type;
                                p.Collections_Time = new DateTime(cc.Collections_Date.Year, cc.Collections_Date.Month, cc.Collections_Date.Day, cc.Collections_Time.Hour, cc.Collections_Time.Minute, cc.Collections_Time.Second);
                                p.Crop = cc.Season;
                                p.Recovery = (double)cc.Recovery;
                                p.Moisture = (double)cc.Moisture;
                                p.Member_Number = cc.Member_Number;
                                p.Farmers_Number = cc.Farmers_Number;
                                p.Farmers_Name = cc.Farmers_Name;
                                p.Sent = true;
                                p.Transport_Mode = (int)cc.Transport_Mode;
                                p.Transporter_Name = cc.Transporter_Name;
                                p.Transporter_Number = cc.Transporter_Number;
                                p.Vehicle_No = cc.Vehicle_No;
                                p.Section = cc.Section;
                                p.Weighed_by = cc.Weighed_by;
                                p.Unit = cc.Unit;
                                p.Driver_id = cc.Driver_id;
                                p.Store = cc.Store;
                                p.Variety = cc.Variety;
                                p.Bag_type =(int) cc.Bag_type;
                                p.No_of_bags_Delivered = (double)cc.No_of_bags_Delivered;
                                p.Status = (int)cc.Status;

                            } db.SaveChanges();
                        }
                    }
                    catch (Exception i)
                    {
                        Logging.Logging.ReportError(i);

                    }
                    #endregion
                }
                
            }
            catch (Exception ex) { }
        }
        public void paddy()
        {
            while (stop == false)
            {
                try
                {
                    using (var db = new RiceEntities(rice.ConnectionString()))
                    {
                        #region paddy
                        try
                        {    
                            var cc = db.Paddy_Details.Where(o => o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString()));
                            foreach (var c in cc.ToList())
                            {
                                try
                                {
                                    Collections.Collection col = new Collections.Collection();

                                    col.Collect_type = (Collections.Collect_type)(c.Collect_type ?? 0);
                                    col.Collect_typeSpecified = true;
                                    col.Collected_by = c.Collected_by ?? string.Empty;
                                    col.Collection_Number = c.Collection_Number;
                                    col.Collections_Date = (DateTime)c.Collections_Date;
                                    col.Collections_DateSpecified = true;
                                    col.Collections_Time = (DateTime)c.Collections_Time;
                                    col.Collections_TimeSpecified = true;
                                    col.Season = c.Crop;
                                    col.No_of_bags_Delivered = (decimal)(c.No_of_bags_Delivered ?? 0);
                                    col.No_of_bags_DeliveredSpecified = true;
                                    col.Variety = c.Variety;
                                    col.Farmers_Name = c.Farmers_Name;
                                    col.Farmers_Number = (c.Farmers_Number ?? "");
                                    col.Member_Number = (c.Member_Number ?? "");
                                    col.Moisture = (decimal)(c.Moisture ?? 0);
                                    col.MoistureSpecified = true;
                                    col.Recovery = (decimal)(c.Recovery ?? 0);
                                    col.RecoverySpecified = true;
                                    col.Section = c.Section;
                                    col.Status = (Collections.Status)c.Status;
                                    col.StatusSpecified = true;
                                    col.Transport_Mode = (Collections.Transport_Mode)(c.Transport_Mode ?? 0);
                                    col.Transport_ModeSpecified = true;
                                    col.Transporter_Name = (c.Transporter_Name ?? "");
                                    col.Transporter_Number = (c.Transporter_Number ?? "");
                                    col.Type = (Collections.Type)(c.Type ?? 0);
                                    col.TypeSpecified = true;
                                    col.Vehicle_No = (c.Vehicle_No ?? "");
                                    col.Unit = (c.Unit ?? "");
                                    col.Store = (c.Store ?? "");
                                    col.Weighed_by = (c.Weighed_by ?? "");
                                    col.Driver_id = (c.Driver_id ?? "");
                                    col.Bag_type = (Collections.Bag_type)(c.Bag_type ?? 0);
                                    col.Bag_typeSpecified = true;
                                    col.Status = (Collections.Status)(c.Status ?? 0);
                                    var coll = collectionservice.ReadMultiple(new Collections.Collection_Filter[] { new Collections.Collection_Filter { Criteria = col.Collection_Number, Field = Collections.Collection_Fields.Collection_Number } }, null, 1).FirstOrDefault();

                                    if (coll != null)
                                    {
                                        col.Key = coll.Key;
                                        collectionservice.Update(ref col);

                                    }
                                    else
                                        collectionservice.Create(ref col);
                                    c.Comments = "";
                                    c.Sent = true;

                                }
                                catch (Exception ex)
                                {
                                    c.Comments = ex.Message;
                                    Logging.Logging.ReportError(ex);
                                }

                            } db.SaveChanges();
                        }
                        catch (Exception i)
                        {
                            Logging.Logging.ReportError(i);
                        }
                        #endregion
                        #region paddybags
                        try
                        {
                            var cc = db.Paddy_Bags.Where(o => o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString()));
                            foreach (var c in cc.ToList())
                            {
                                try
                                {
                                    PaddyBags.Paddy_bags col = new PaddyBags.Paddy_bags()
                                    {
                                        Action = (PaddyBags.Action)(c.Action ?? 0),
                                        ActionSpecified = true,
                                        Bag_type = (PaddyBags.Bag_type)(c.Bag_type ?? 0),
                                        Bag_typeSpecified = true,
                                        Bag_weight = (decimal)(c.Bag_weight ?? 0),
                                        Bag_weightSpecified = true,
                                        Gross_kg = (decimal)(c.Gross_kg ?? 0),
                                        Gross_kgSpecified = true,
                                        Net_kg = (decimal)(c.Net_kg ?? 0),
                                        Net_kgSpecified = true,
                                        Paddy = c.Paddy,
                                        No_of_bags = (decimal)(c.No_of_bags ?? 0),
                                        No_of_bagsSpecified = true,
                                        Variety = c.Variety,
                                        Weight = (decimal)(c.Weight ?? 0),
                                        WeightSpecified = true,
                                        Date = (DateTime)(c.Date ?? DateTime.Now.Date),
                                        DateSpecified = true,
                                        Time = (DateTime)(c.Time ?? DateTime.Now),
                                        TimeSpecified = true,
                                        Farmer = c.Farmer,
                                        Entry = (int)c.Entry,
                                        EntrySpecified = true,
                                        Moisture_Weight=(decimal) (c.Moisture_Weight ??0),
                                        Moisture_WeightSpecified= true,
                                        Id = c.Id,
                                        
                                        Reversed =( c.Reversed??false),
                                        ReversedSpecified = true
                                        
                                    };
                                    var coll = bagsservice.ReadMultiple(new PaddyBags.Paddy_bags_Filter[] {  new PaddyBags.Paddy_bags_Filter { Criteria = col.Id.ToString(), Field = PaddyBags.Paddy_bags_Fields.Id } }, null, 1).FirstOrDefault();
                                    if (coll != null)
                                    {
                                        col.Key = coll.Key;
                                        bagsservice.Update(ref col);
                                    }
                                    else
                                        bagsservice.Create(ref col);
                                    c.Comments = "";
                                    c.Sent = true;
                                }
                                catch (Exception ex)
                                {
                                    c.Comments = ex.Message;
                                    Logging.Logging.ReportError(ex);
                                }

                            } db.SaveChanges();
                        }
                        catch (Exception i)
                        {
                            Logging.Logging.ReportError(i);
                        }
                        #endregion
                        Getpaddy();
                        Getpaddybags();
                        
                        db.SaveChanges();
                    }
                }
                catch (Exception i)
                {
                    Logging.Logging.ReportError(i);
                }
                System.Threading.Thread.Sleep(30000);
            }
        }
        public void Inventory()
        {
            while (stop == false)
            {
                try
                {
                    using (var db = new RiceEntities(rice.ConnectionString()))
                    {
                        #region itemlist
                        try
                        {
                            var cc = db.Items_Services_List.Where(o => (o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString())) && (o.Pull_Item == false || string.IsNullOrEmpty(o.Pull_Item.ToString())));
                            foreach (var c in cc.ToList())
                            {
                                try
                                {
                                    ItemList.ItemsList items = new ItemList.ItemsList();
                                    items.Farmer = c.Farmer;
                                    items.Item = c.Item;
                                    items.Qty = (decimal)(c.Qty ?? 0);
                                    items.Unit_Cost = (decimal)(c.Unit_Cost ?? 0);
                                    items.Total_Cost = (decimal)(c.Total_Cost ?? 0);
                                    items.Date = (DateTime)(c.Date ?? DateTime.Today.Date);
                                    items.Time = (DateTime)(c.Time ?? DateTime.Now);
                                    items.User = (c.User ?? string.Empty);
                                    items.Sales_Type = (ItemList.Sales_Type)(c.Sales_Type ?? 0);
                                    items.Receipt_No = (c.Receipt_No ?? string.Empty);
                                    items.Source_no = (int)c.Entry;
                                    items.Variant = (c.Variant ?? string.Empty);
                                    items.Type = (ItemList.Type)(c.Entry_Type ?? 0);
                                    items.Season = (c.Season ?? string.Empty);
                                    items.Outlet = (c.Outlet ?? string.Empty);
                                    items.Payment_Mode = (ItemList.Payment_Mode)(c.Payment_Mode ?? 0);
                                    items.Phone_No = (c.Phone_No ?? string.Empty);
                                    items.Customer = (c.Customer ?? string.Empty);
                                    items.Reference = (c.Reference ?? string.Empty);
                                    items.DateSpecified = true;
                                    items.Payment_ModeSpecified = true;
                                    items.QtySpecified = true;
                                    items.Sales_TypeSpecified = true;
                                    items.Source_noSpecified = true;
                                    items.TimeSpecified = true;
                                    items.Total_CostSpecified = true;
                                    items.TypeSpecified = true;
                                    items.Unit_CostSpecified = true;
                                    items.Balance = (decimal)(c.Balance??0);
                                    items.BalanceSpecified = true;
                                    items.RecId =(long) (c.Recid??c.Entry);
                                    items.RecIdSpecified = true;
                                    items.Category = (c.Category ?? string.Empty);
                                    items.Reversed =(bool) (c.Reversed ?? false) ;
                                    items.Reversed_by =(int) (c.Reversed_by_Entry ?? 0);
                                    items.Machine_Cagegory = (ItemList.Machine_Cagegory)(c.Machine_Cagegory ??0);
                                    items.Machine_CagegorySpecified = true;
                                    items.Machine = c.Machine;
                                    var item = itemlistservice.ReadMultiple(new ItemList.ItemsList_Filter[] { 
                                        new ItemList.ItemsList_Filter { Criteria = items.RecId.ToString(), Field = ItemList.ItemsList_Fields.RecId }, new ItemList.ItemsList_Filter { Criteria = items.Outlet, Field  = ItemList.ItemsList_Fields.Outlet } }, null, 1).FirstOrDefault();
                                    if (item != null)
                                    {
                                        items.Key = item.Key;
                                        itemlistservice.Update(ref items);
                                    }
                                    else
                                    {
                                        itemlistservice.Create(ref items);

                                    }
                                    c.Comments = "";
                                    c.Date_Sent = DateTime.Now;
                                    c.Sent = true;

                                }
                                catch (Exception ex)
                                {
                                    c.Comments = ex.Message;
                                    Logging.Logging.ReportError(ex);
                                }

                            } db.SaveChanges();
                        }
                        catch (Exception ex)
                        {

                            Logging.Logging.ReportError(ex);
                        }
                        #endregion  
                        #region inventory items
                        try
                        {
                            string no = string.Empty;
                            var c = itemservice.ReadMultiple(new NavItems.Items_Filter[] { }, null, 0).ToList();
                            if (c.Count > 0)
                            {
                                //db.Items_Services.RemoveRange(db.Items_Services.ToList());
                                //db.Variants.RemoveRange(db.Variants.ToList());
                                foreach (var u in c)
                                {
                                    //Logging.Logging.LogEntryOnFile(u.No);
                                    no = u.No;
                                    var cc = db.Items_Services.FirstOrDefault(o => o.Code == u.No);
                                    try
                                    {
                                        if (cc == null)
                                        {
                                            cc = new Items_Services();
                                            cc.Code = u.No;
                                            db.Items_Services.Add(cc);
                                        } cc.Name = u.Description;
                                        cc.Category = u.Item_Category_Code;
                                        cc.Type = 0;
                                        if (u.Item_Variants.Count() > 0)
                                            db.Variants.RemoveRange(db.Variants.Where(o => o.Item_Code == cc.Code));
                                        foreach (var item in u.Item_Variants)
                                        {
                                            var ii = new Variant();
                                            ii.Code = item.Code;
                                            ii.Item_Code = item.Item_No;
                                            db.Variants.Add(ii);

                                        }
                                        db.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        Logging.Logging.ReportError(ex);
                                        DbEntityEntry entry = db.Entry(cc);
                                        switch (entry.State)
                                        {
                                            case EntityState.Added:
                                                entry.State = EntityState.Detached;
                                                break;

                                            default: break;
                                        }
                                    }
                                }
                            } db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Logging.Logging.ReportError(e);
                        }
                        #endregion
                        #region services
                        try
                        {
                            var c = service.ReadMultiple(new Services.Services_Filter[] { }, null, 0).ToList();
                            if (c.Count > 0)
                            {
                                foreach (var u in c)
                                {
                                    var cc = db.Items_Services.FirstOrDefault(o => o.Code == u.No);
                                    if (cc == null)
                                    {
                                        cc = new Items_Services();
                                        cc.Code = u.No;
                                        db.Items_Services.Add(cc);
                                    }
                                    cc.Name = u.Description;
                                    cc.Type = 1;
                                    cc.Price = (double)u.Sales_Unit_Price;

                                    db.SaveChanges();
                                }
                            } db.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            Logging.Logging.ReportError(e);
                        }
                        #endregion
                        #region getitemlist
                        try
                        {
                            var itemlist = itemlistservice.ReadMultiple(new ItemList.ItemsList_Filter[] { 
new ItemList.ItemsList_Filter { Criteria = "Items", Field = ItemList.ItemsList_Fields.Type },new ItemList.ItemsList_Filter { Criteria = rice.setup.Current_crop, Field = ItemList.ItemsList_Fields.Season } }, null, 0);

                            var list = db.Items_Services_List;
                            foreach (var item in itemlist)
                            {
                                if (list.FirstOrDefault(o => o.Entry == item.Source_no && o.Receipt_No == item.Receipt_No) == null)
                                {
                                    Items_Services_List i = new Items_Services_List();
                                    i.Source_no = item.Source_no;
                                    i.Farmer = item.Farmer;
                                    i.Item = item.Item;
                                    i.Sent = true;
                                    i.Qty = item.Qty;
                                    i.Unit_Cost = item.Unit_Cost;
                                    i.Total_Cost = item.Total_Cost;
                                    i.Date = item.Date;
                                    i.Time = item.Time;
                                    i.User = item.User;
                                    i.Sales_Type = (int)item.Sales_Type;
                                    i.Receipt_No = item.Receipt_No;
                                    i.Entry = item.Source_no;
                                    i.Variant = item.Variant;
                                    i.Entry_Type = (int)item.Type;
                                    i.Season = item.Season;
                                    i.Outlet = item.Outlet;
                                    i.Payment_Mode = (int)item.Payment_Mode;
                                    i.Phone_No = item.Phone_No;
                                    i.Customer = item.Customer;
                                    i.Reference = item.Reference;
                                    i.Balance = (double)item.Balance;
                                    i.Category = item.Category;
                                    i.Pull_Item = true;
                                    db.Items_Services_List.Add(i);
                                }
                            }
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Logging.Logging.ReportError(ex);
                        }
                        #endregion
                    }
                }
                catch (Exception i)
                {
                    Logging.Logging.ReportError(i);
                }
                System.Threading.Thread.Sleep(30000);
            }
        }
        public void ItemMovement()
        {
            while (stop == false)
            {
                try
                {
                    using (var db = new RiceEntities(rice.ConnectionString()))
                    {
                        var itemh = db.Item_Movement_Headers.Where(o => o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString())).ToArray();
                        foreach (var item in itemh)
                        {
                            try
                            {
                              var i = itemmovementheader.ReadMultiple(new ItemMovementHeader.ItemMovementHeader_Filter[] { new ItemMovementHeader.ItemMovementHeader_Filter { Criteria = item.Reference, Field = ItemMovementHeader.ItemMovementHeader_Fields.Reference } }, null, 0).FirstOrDefault();
                                if (i == null)
                                {
                                    i = new ItemMovementHeader.ItemMovementHeader();
                                    i.Reference = item.Reference;
                                    itemmovementheader.Create(ref i);
                                }
                                i.Created_By = item.Created_By;
                                i.Date = (DateTime)item.Date;
                                i.DateSpecified = true;
                                i.Grn_No = (item.Grn_No ?? string.Empty) ;
                                i.Invoice = item.Invoice ?? string.Empty;
                                i.Movement_Type = (ItemMovementHeader.Movement_Type) item.Movement_Type;
                                i.Movement_TypeSpecified = true;
                                i.Season = item.Season ?? string.Empty;
                                i.Time = (DateTime)item.Time  ;
                                i.TimeSpecified = true;
                                i.Location = item.Location ?? string.Empty;
                                i.Location_To = item.Location_To ?? string.Empty;
                                i.Item = item.Item ?? string.Empty;
                                i.Variant = item.Variant ?? string.Empty;
                                i.To_Item = item.To_Item ?? string.Empty;
                                i.To_Variant = item.To_Variant ?? string.Empty;
                                i.Qty = (int)(item.Qty ?? 0);
                                i.QtySpecified = true;
                                
                                i.Balance = (int)(item.Balance ?? 0);
                                i.BalanceSpecified = true;
                                itemmovementheader.Update(ref i);
                                item.Comments = "";
                                item.Sent = true;
                                
                            }
                            catch (Exception ex)
                            {
                                item.Comments = ex.Message;
                                Logging.Logging.ReportError(ex);
                            }
                        }
                        db.SaveChanges();

                        var itemm = db.Item_Movements.Where(o => o.Sent == false || string.IsNullOrEmpty(o.Sent.ToString())).ToArray();
                        foreach (var item in itemm)
                        {
                            try
                            {
                                var ih = movementservice.ReadMultiple(new Movement.ItemMovement_Filter[] { 
                                    new ItemMovement_Filter { Criteria = item.Reference, Field = ItemMovement_Fields.Reference }, 
                                   new ItemMovement_Filter { Criteria = item.Recid.ToString(), Field = ItemMovement_Fields.RecId }, 
                                    new ItemMovement_Filter { Criteria = item.Location, Field = ItemMovement_Fields.Location } }, null, 0).FirstOrDefault();
                                if (ih == null)
                                {
                                    ih = new Movement.ItemMovement();
                                    //ih.Entry = item.Entry;
                                    //ih.EntrySpecified = true;
                                    ih.Reference = item.Reference ?? string.Empty;
                                    ih.Variant = item.Variant ?? string.Empty;
                                    ih.Item = item.Item ?? string.Empty;
                                    ih.Location = item.Location ?? string.Empty; 
                                    ih.RecId = (long) (item.Recid ?? 0);
                                    ih.RecIdSpecified = true; 
                                    movementservice.Create(ref ih);
                                }
                                ih.Date = (DateTime)item.Date;
                                ih.Time = (DateTime)item.Time;
                                ih.TimeSpecified = true;
                                ih.DateSpecified = true;
                                ih.Variant = item.Variant ?? string.Empty;
                                ih.Item = item.Item ?? string.Empty;
                                ih.Qty = (decimal)(item.Qty ?? 0);
                                ih.QtySpecified = true;
                                ih.User = item.User ?? string.Empty;
                                ih.Convert_to = item.Convert_to ?? string.Empty;
                                ih.Movement_Type = (Movement_Type)(item.Movement_Type ?? 0);
                                ih.Movement_TypeSpecified = true;
                                ih.Location = item.Location ?? string.Empty;
                                ih.Location_To = item.Location_To ?? string.Empty;
                                ih.Reversed =(bool) (item.Reversed ?? false);
                                ih.Reversed_by =(int) (item.Reversed_by_entry ??0);
                                ih.ReversedSpecified = true;
                               
                                movementservice.Update(ref ih);
                                item.Sent = true;
                                item.Comments = "";

                            }
                            catch (Exception ex)
                            {
                                item.Comments = ex.Message;
                                Logging.Logging.ReportError(ex);
                            }
                        }
                        db.SaveChanges();

                    }
                }
                catch (Exception r)
                {

                    Logging.Logging.ReportError(r);
                }
                System.Threading.Thread.Sleep(30000);
            }
        }
    }
}
