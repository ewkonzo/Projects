using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks;
namespace Coffee
{
    public class ExternalData
    {
        public server.Collect service = new server.Collect();
        public static bool stop = false;
        

        #region Update server
        public void start()
        {
            if (client.connectedtomain)
            {
                Logging.Logging.LogEntryOnFile("Starting Services");
                Task.Factory.StartNew(() => updatedata(), TaskCreationOptions.LongRunning);
                Task.Factory.StartNew(() => updatecollections(), TaskCreationOptions.LongRunning);
                Task.Factory.StartNew(() => updatestores(), TaskCreationOptions.LongRunning);
            }
        }
        public void updatedata()
        {
            try
            {
                while (stop == false)
                {
                    using (var db = new AutoweighEntities(coffee.ConnectionString()))
                    {
                        try
                        {
                            service.Url = coffee.setup.Server_url;
                            service.Timeout = 600000;
                            List<server.Vendor> vv = new List<server.Vendor>();
                            var updated = db.Farmers.Where(o => o.Updated == true).ToList();
                            foreach (Farmer farmer in updated)
                            {
                                server.Vendor v = new server.Vendor();
                                v.No = farmer.No;
                                v.Phone_No = farmer.Phone;
                                v.Name = farmer.Name;
                                v.ID_No = farmer.ID_No;
                                v.Account_Category = (server.Account_Category)farmer.Account_Category;
                                vv.Add(v);
                            }
                            var updatedfarmers = service.UpdateFarmer(vv.ToArray());
                            foreach (server.Vendor farmer in updatedfarmers)
                            {
                                var f = db.Farmers.FirstOrDefault(o => o.No == farmer.No);
                                if (f != null)
                                {
                                    if (farmer.Code == 0)
                                        f.Updated = false;
                                    else
                                        f.Comments = farmer.desc;
                                    db.SaveChanges();
                                }
                            }
                        }
                        catch (Exception ex)
                        { Logging.Logging.ReportError(ex); }

                        var ff = service.Farmers(null);

                        try
                        {
                            foreach (var farmer in ff)
                            {
                                Farmer f = db.Farmers.FirstOrDefault(o => o.No == farmer.No);
                                if (f == null)
                                {

                                    f = new Farmer();
                                    f.No = farmer.No;
                                    f.Cum_Cherry = 0;
                                    f.Cum_Mbuni = 0;
                                    db.Farmers.Add(f);
                                }
                                f.Name = farmer.Name;
                                f.Phone = farmer.Phone_No;
                                f.ID_No = farmer.ID_No;
                                f.Account_Category = (int)farmer.Account_Category;
                                f.Factory = farmer.Factory;
                                f.Other_Loans = (double)farmer.Outstanding_loans;
                                db.SaveChanges();

                            }
                        }
                        catch (Exception ex)
                        {
                            Logging.Logging.ReportError(ex);
                        }


                    }
                    System.Threading.Thread.Sleep(30000);
                }
            }
            catch (Exception ex)
            { Logging.Logging.ReportError(ex); }
        }
        public void updatecollections()
        {
            try
            {
                while (stop == false)
                {
                    using (var db = new AutoweighEntities(coffee.ConnectionString()))
                    {
                        try
                        {
                            service.Url = coffee.setup.Server_url;
                            service.Timeout = 600000;

                            List<server.Collection> ncc = new List<server.Collection>();
                            var cc = db.Daily_Collections_Details.Where(o => o.Sent == false).Take(400);
                            foreach (Daily_Collections_Detail c in cc)
                            {
                                server.Collection nc = new server.Collection();
                                nc.Collection_Number = c.Collection_Number;
                                nc.Collections_Date = c.Collections_Date;
                                nc.Collections_DateSpecified = true;
                                nc.Kg_Collected = (decimal)(c.Kg__Collected ?? 0);
                                nc.Kg_CollectedSpecified = true;
                                nc.Farmers_Number = c.Farmers_Number;
                                nc.Farmers_Name = c.Farmers_Name;
                                nc.Factory = c.Factory;
                                nc.Collections_Time = (DateTime)c.Collection_time;
                                nc.Collections_TimeSpecified = true;
                                nc.Coffee_Type = c.Coffee_Type;
                                nc.Collected_by = c.User;
                                nc.Collect_type = c.Collect_type;
                                nc.Crop = c.Crop;

                                ncc.Add(nc);
                            }
                            if (ncc.Count > 0)
                            {
                                var col = service.Collections(ncc.ToArray());
                                foreach (var c in col.ToList())
                                {
                                    var ccc = db.Daily_Collections_Details.FirstOrDefault(o => o.Collection_Number == c.Collection_Number);
                                    if (cc != null)
                                        if (c.Code == 0)
                                        {
                                            ccc.Sent = true;
                                            ccc.Comments = "";
                                        }
                                        else
                                        {
                                            ccc.Comments = c.desc;
                                        }
                                    db.SaveChanges();
                                }
                            }
                        }
                        catch (Exception ex)
                        { Logging.Logging.ReportError(ex); }

                    }
                    System.Threading.Thread.Sleep(30000);
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
        }
        public void updatestores()
        {
            try
            {
                while (stop == false)
                {
                    using (var db = new AutoweighEntities(coffee.ConnectionString()))
                    {

                        try
                        {
                            service.Url = coffee.setup.Server_url;

                            var items = service.Items();

                            foreach (var item in items)
                            {
                                Item f = db.Items.FirstOrDefault(o => o.No == item.No);
                                if (f == null)
                                {
                                    f = new Item();
                                    f.No = item.No;
                                    db.Items.Add(f);
                                }
                                f.Description = item.Description;
                                f.Base_Unit_of_Measure = item.Base_Unit_of_Measure;
                                foreach (var variants in item.Item_Variants)
                                {
                                    Item_Variant v = db.Item_Variants.FirstOrDefault(o => o.Code == variants.Code && o.No == variants.Item_No);
                                    if (v == null)
                                    {
                                        v = new Item_Variant();
                                        v.No = variants.Item_No;
                                        v.Code = variants.Code;
                                        db.Item_Variants.Add(v);
                                    }
                                    v.Description = variants.Description;
                                    v.Price = (double)variants.price;
                                }

                                db.SaveChanges();

                            }
                            var entries = service.ItemsEntries().Where(o => o.Location_Code == coffee.setup.Branch).ToList();

                            foreach (var entry in entries)
                            {
                                var d = db.Stocks.FirstOrDefault(o => o.Document_No == entry.Document_No);

                                if (d == null)
                                {
                                    Stock s = new Stock();
                                    s.Document_No = entry.Document_No;
                                    s.Date_Added = entry.Posting_Date;
                                    s.Quantity = (double)entry.Quantity;
                                    s.Item = entry.Item_No;
                                    s.Variant = entry.Variant_Code;
                                    s.Unit_Price = (double)entry.Cost_Amount_Expected;

                                    db.Stocks.Add(s);
                                    db.SaveChanges();
                                }

                            }
                            List<server.Stores> stores = new List<server.Stores>();
                            var unsentstore = db.Stores.Where(o => o.Sent == false).ToList().Take(300);
                            foreach (var store in unsentstore)
                            {
                                server.Stores sstore = new server.Stores();
                                sstore.Farmer = store.Client;
                                sstore.Item = store.Item;
                                sstore.Variant = store.Variant;
                                sstore.Unit_Cost = (decimal)(store.Amount ?? 0);
                                sstore.Unit_CostSpecified = true;
                                sstore.Total_Cost = (decimal)(store.Line_total ?? 0);
                                sstore.Total_CostSpecified = true;
                                sstore.Date = (DateTime)store.Date;
                                sstore.DateSpecified = true;
                                sstore.Time = (DateTime)(store.Time == null ? (DateTime)store.Date : store.Time);
                                sstore.TimeSpecified = true;
                                sstore.Source_no = store.ID;
                                sstore.Source_noSpecified = true;
                                sstore.Receipt_No = store.Entry;
                                sstore.Qty = (decimal)(store.Quantity ?? 0);
                                sstore.QtySpecified = true;
                                sstore.User = store.Served_By;
                                sstore.Factory = store.Factory;
                                sstore.Crop = store.Crop;
                                sstore.Paymode = (server.Paymode)(store.Paymode ?? 0);
                                sstore.PaymodeSpecified = true;
                                stores.Add(sstore);
                            }

                            var sentstore = service.SetStores(stores.ToArray());
                            foreach (var item in sentstore)
                            {
                                var s1 = db.Stores.FirstOrDefault(o => o.ID == item.Source_no);
                                if (s1 != null)
                                {
                                    if (item.Code == 0)
                                    {
                                        s1.Sent = true;
                                        s1.Status = "successfull";
                                        s1.Comments = "";
                                    }
                                    else
                                    {
                                        s1.Status = "Failed";
                                        Logging.Logging.LogEntryOnFile(item.desc);
                                        s1.Comments = item.desc;
                                    }
                                }
                                db.SaveChanges();

                            }

                        }

                        catch (Exception ex)
                        {
                            Logging.Logging.ReportError(ex);
                        }



                    }
                    System.Threading.Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
        }
        #endregion
    }
}