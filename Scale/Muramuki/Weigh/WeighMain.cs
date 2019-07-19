using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Weigh
{

    public partial class WeighMain : Form
    {
        public bool stop = false;
        public server.Collect service = new Weigh.server.Collect();
        private int childFormNumber = 0;

        public WeighMain()
        {
            InitializeComponent();
            if (AutoweighEntities.user.Type != "Admin")
            {
                usersToolStripMenuItem.Visible = false;

            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

     
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Weigh_Load(object sender, EventArgs e)
        {
            Logging.Logging.logpath= @"D:\Logs\";
            service.Url = AutoweighEntities.setup.Server_url;
            System.Threading.Thread t = new System.Threading.Thread(updatedata);
            t.IsBackground = true;
            t.Start();
            AutoweighEntities.Factory_Name = "MURAMUKI FCS LIMITED";
            toolStripStatusLabel2.Text = AutoweighEntities.user.Name;
            todaysCollectionToolStripMenuItem.Text = "Todays (" + DateTime.Now.Date.ToShortDateString() + ") Collections.";
            this.Text = AutoweighEntities.Factory_Name + " " + AutoweighEntities.setup.Current_crop;
            //Allcollections ac = new Allcollections();
            //ac.MdiParent = this;
            //ac.WindowState = FormWindowState.Maximized;
            //ac.Show();

        }
       
        public void updatedata()
        {
            try
            {
                while (stop == false)
                {
                    if (done)
                    {
                        SetText("Updating Farmers");
                        done = false;
                        if ((bool)AutoweighEntities.setup.Pick_factory_farmers == true)
                        {
                            service.FarmersbyfactoryCompleted += new Weigh.server.FarmersbyfactoryCompletedEventHandler(farmersbyfactory);

                            service.FarmersbyfactoryAsync(AutoweighEntities.setup.Branch);
                        }
                        else
                        {
                            service.FarmersCompleted += new Weigh.server.FarmersCompletedEventHandler(farmers);
                            service.FarmersAsync(null);
                        }

                    }
                    System.Threading.Thread.Sleep(30000);
                }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
            }
        }
        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
      
            //if (this.statusStrip1.InvokeRequired)
            //{
            //    SetTextCallback d = new SetTextCallback(SetText);
            //    this.Invoke(d, new object[] { text });
            //}
            //else
            //{
            //    this.toolStripStatusLabel1.Text = text;
            //}
        }
        protected void farmers(object sender, server.FarmersCompletedEventArgs e)

        {
            try
            {
                if (e.Result != null)
                    if (e.Result.Count() > 0)
                        foreach (var farmer in e.Result)
                        {
                            using (var db = new AutoweighEntities())
                            {
                                Farmer f = db.Farmers.FirstOrDefault(o => o.No == farmer.No);
                                if (f == null)
                                {
                                    SetText(farmer.Name + " Not found)");
                                    f = new Farmer();
                                    f.No = farmer.No;
                                    db.Farmers.Add(f);
                                }
                                SetText("Farmers(" + farmer.Name + ")");
                                f.Name = farmer.Name;
                                f.Phone = farmer.Phone_No;
                                //f.Cum_Cherry = (double)farmer.Cummulative;
                                //f.Cum_Mbuni = (double)farmer.Cummulative_Mbuni;
                                SetText("Saving");
                                db.SaveChanges();
                                SetText("Saved");
                            }
                        }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
                SetText(ex.Message);
            }
            collect();
        }
       
          protected void farmersbyfactory(object sender, server.FarmersbyfactoryCompletedEventArgs e)

        {
            try
            {
                if (e.Result != null)
                    if (e.Result.Count() > 0)
                        foreach (var farmer in e.Result)
                        {
                            using (var db = new AutoweighEntities())
                            {
                                Farmer f = db.Farmers.FirstOrDefault(o => o.No == farmer.No);
                                if (f == null)
                                {
                                    SetText(farmer.Name + " Not found)");
                                    f = new Farmer();
                                    f.No = farmer.No;
                                    db.Farmers.Add(f);
                                }
                                SetText("Farmers(" + farmer.Name + ")");
                                f.Name = farmer.Name;
                                f.Phone = farmer.Phone_No;
                                //f.Cum_Cherry = (double)farmer.Cummulative;
                                //f.Cum_Mbuni = (double)farmer.Cummulative_Mbuni;
                                SetText("Saving");
                                db.SaveChanges();
                                SetText("Saved");
                            }
                        }
            }
            catch (Exception ex)
            {
                Logging.Logging.ReportError(ex);
                SetText(ex.Message);
            }
            collect();
        }
        
        bool done = true;

        private void collect()
        { 
         try
            {
                service.CollectionsCompleted += new Weigh.server.CollectionsCompletedEventHandler(collections);
                List<server.Collection> ncc = new List<server.Collection>();
                using (var db = new AutoweighEntities())
                {
                    var cc = db.Daily_Collections_Details.Where(o => o.Sent == false);
                    foreach (Daily_Collections_Detail c in cc)
                    {
                        server.Collection nc = new server.Collection();
                        nc.Collection_Number = c.Collection_Number;
                        nc.Collections_Date = c.Collections_Date;
                        nc.Collections_DateSpecified = true;
                        nc.Kg_Collected = (decimal)c.Kg__Collected;
                        nc.Kg_CollectedSpecified = true;
                        nc.Farmers_Number = c.Farmers_Number;
                        nc.Farmers_Name = c.Farmers_Name;
                        nc.Factory = c.Factory;
                        nc.Collections_Time =(DateTime) c.Collection_time;
                        nc.Collections_TimeSpecified = true;
                        nc.Coffee_Type = c.Coffee_Type;
                        nc.Collected_by = c.User;
                        nc.Collect_type = c.Collect_type;
                        nc.Crop = c.Crop;
                        ncc.Add(nc);
                        SetText("KG(" + nc.Farmers_Name + " - " + c.Kg__Collected + ")");
                    }
                }
                service.CollectionsAsync(ncc.ToArray());
            }catch(Exception ex) { Logging.Logging.ReportError(ex);
                SetText(ex.Message);
            }
        }
        protected void collections(object sender, server.CollectionsCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                    if (e.Result.Count() > 0)
                       using (var db = new AutoweighEntities())
                            {  foreach (var c in e.Result)
                        {                           
                                var cc = db.Daily_Collections_Details.FirstOrDefault(o => o.Collection_Number == c.Collection_Number);
                                if (cc != null)
                                    if (c.Code == 0)
                                    {                                        
                                        cc.Sent = true;
                                        cc.Comments = "";
                                   
                                    }
                                    else
                                    {
                                        cc.Comments = c.desc;
                                        Logging.Logging.LogEntryOnFile(c.desc);
                                        SetText(c.desc);
                                    }
                            }
 db.SaveChanges();
                        }
                SetText("Transactions Successfully sent");
            }catch(Exception ex) { Logging.Logging.ReportError(ex); }
            finally { done = true; }
        }

        private void WeighMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop = true;
            if (AutoweighEntities. Db.ChangeTracker.Entries().Any(ee => ee.State == EntityState.Added
                                                 || ee.State == EntityState.Modified
                                                 || ee.State == EntityState.Deleted))
            {
                DialogResult result1 = MessageBox.Show("There are changes made to your data, do you want to save them?", "Save Changes", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                    AutoweighEntities. Db.SaveChanges(true);
            }
            Application.Exit();
        }

        private void farmersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Farmers f = new Farmers();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void collectToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Collection c = new Collection();
          c.ShowDialog();
        }

        private void collectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Allcollections ac = new Allcollections();
            ac.MdiParent = this;
            ac.WindowState = FormWindowState.Maximized;
            ac.Show();
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Coffee.Settings s = new Coffee.Settings();
            //s.ShowDialog();

            Settings s = new Settings();
            s.StartPosition = FormStartPosition.CenterScreen;
            s.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users s = new Users();
            s.StartPosition = FormStartPosition.CenterScreen;
            s.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmchangePass s = new FrmchangePass();
            s.StartPosition = FormStartPosition.CenterScreen;
            s.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Login l = new Login();
            l.Show();
        }

        private void dailyCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports r = new Reports(Reports.reports.Dailycollection);
            r.MdiParent = this;
            r.WindowState = FormWindowState.Maximized;
            r.Show();
        }

        private void todaysCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports r = new Reports(Reports.reports.Dailycollection);
            r.MdiParent = this;
            r.WindowState = FormWindowState.Maximized;
            r.Show();
        }

        private void farmersDeliveryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports r = new Reports(Reports.reports.Farmerdailycollection);
            r.MdiParent = this;
            r.WindowState = FormWindowState.Maximized;
            r.Show();
        }

        private void cummulativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports r = new Reports(Reports.reports.cummulative);
            r.MdiParent = this;
            r.WindowState = FormWindowState.Maximized;
            r.Show();
        }
    }
}
