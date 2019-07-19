namespace Coffee
{
    partial class Menu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bfarmers = new DevExpress.XtraBars.BarButtonItem();
            this.bnewfarmer = new DevExpress.XtraBars.BarButtonItem();
            this.bcollect = new DevExpress.XtraBars.BarButtonItem();
            this.bcollections = new DevExpress.XtraBars.BarButtonItem();
            this.bsetup = new DevExpress.XtraBars.BarButtonItem();
            this.busers = new DevExpress.XtraBars.BarButtonItem();
            this.bdebts = new DevExpress.XtraBars.BarButtonItem();
            this.bstores = new DevExpress.XtraBars.BarButtonItem();
            this.bposteddebts = new DevExpress.XtraBars.BarButtonItem();
            this.rptfarmers = new DevExpress.XtraBars.BarButtonItem();
            this.rptcategory = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.rptcollections = new DevExpress.XtraBars.BarButtonItem();
            this.rptdailysummary = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.bchangepass = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.menuribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // menuribbon
            // 
            this.menuribbon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuribbon.ExpandCollapseItem.Id = 0;
            this.menuribbon.ExpandCollapseItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.menuribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.menuribbon.ExpandCollapseItem,
            this.bfarmers,
            this.bnewfarmer,
            this.bcollect,
            this.bcollections,
            this.bsetup,
            this.busers,
            this.bdebts,
            this.bstores,
            this.bposteddebts,
            this.rptfarmers,
            this.rptcategory,
            this.barButtonItem4,
            this.rptcollections,
            this.rptdailysummary,
            this.barSubItem1,
            this.bchangepass});
            this.menuribbon.Location = new System.Drawing.Point(0, 0);
            this.menuribbon.MaxItemId = 17;
            this.menuribbon.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.menuribbon.Name = "menuribbon";
            this.menuribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.menuribbon.QuickToolbarItemLinks.Add(this.bcollect);
            this.menuribbon.QuickToolbarItemLinks.Add(this.bcollections);
            this.menuribbon.QuickToolbarItemLinks.Add(this.bdebts);
            this.menuribbon.QuickToolbarItemLinks.Add(this.bposteddebts);
            this.menuribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.menuribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.menuribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
            this.menuribbon.ShowToolbarCustomizeItem = false;
            this.menuribbon.Size = new System.Drawing.Size(660, 140);
            this.menuribbon.Toolbar.ShowCustomizeItem = false;
            this.menuribbon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ribbonControl1_ItemClick);
            // 
            // bfarmers
            // 
            this.bfarmers.Caption = "Farmers";
            this.bfarmers.Id = 1;
            this.bfarmers.ImageOptions.Image = global::Coffee.Properties.Resources.farmer;
            this.bfarmers.Name = "bfarmers";
            this.bfarmers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bfarmers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bfarmers_ItemClick);
            // 
            // bnewfarmer
            // 
            this.bnewfarmer.Caption = "New";
            this.bnewfarmer.Id = 2;
            this.bnewfarmer.ImageOptions.Image = global::Coffee.Properties.Resources.farmer_add;
            this.bnewfarmer.Name = "bnewfarmer";
            this.bnewfarmer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bnewfarmer.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bcollect
            // 
            this.bcollect.Caption = "Collect";
            this.bcollect.Id = 3;
            this.bcollect.ImageOptions.Image = global::Coffee.Properties.Resources.weigh;
            this.bcollect.Name = "bcollect";
            this.bcollect.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // bcollections
            // 
            this.bcollections.Caption = "Collections";
            this.bcollections.Id = 4;
            this.bcollections.ImageOptions.Image = global::Coffee.Properties.Resources.collection_list;
            this.bcollections.Name = "bcollections";
            this.bcollections.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // bsetup
            // 
            this.bsetup.Caption = "Setup";
            this.bsetup.Id = 5;
            this.bsetup.ImageOptions.Image = global::Coffee.Properties.Resources.setup;
            this.bsetup.Name = "bsetup";
            this.bsetup.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // busers
            // 
            this.busers.Caption = "Users";
            this.busers.Id = 6;
            this.busers.ImageOptions.Image = global::Coffee.Properties.Resources.login;
            this.busers.Name = "busers";
            this.busers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // bdebts
            // 
            this.bdebts.Caption = "New Debts";
            this.bdebts.Id = 7;
            this.bdebts.ImageOptions.Image = global::Coffee.Properties.Resources._new;
            this.bdebts.Name = "bdebts";
            this.bdebts.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bdebts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bdebts_ItemClick);
            // 
            // bstores
            // 
            this.bstores.Caption = "Stores";
            this.bstores.Id = 8;
            this.bstores.ImageOptions.Image = global::Coffee.Properties.Resources.stores;
            this.bstores.Name = "bstores";
            this.bstores.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // bposteddebts
            // 
            this.bposteddebts.Caption = "Posted Debts";
            this.bposteddebts.Id = 9;
            this.bposteddebts.ImageOptions.Image = global::Coffee.Properties.Resources.store;
            this.bposteddebts.Name = "bposteddebts";
            this.bposteddebts.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // rptfarmers
            // 
            this.rptfarmers.Caption = "Farmer list";
            this.rptfarmers.Id = 10;
            this.rptfarmers.ImageOptions.ImageUri.Uri = "ListBullets";
            this.rptfarmers.ImageOptions.LargeImage = global::Coffee.Properties.Resources.collection_list;
            this.rptfarmers.Name = "rptfarmers";
            this.rptfarmers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // rptcategory
            // 
            this.rptcategory.Caption = "Farmer category";
            this.rptcategory.Id = 11;
            this.rptcategory.ImageOptions.ImageUri.Uri = "ListBullets";
            this.rptcategory.Name = "rptcategory";
            this.rptcategory.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 12;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // rptcollections
            // 
            this.rptcollections.Caption = "Collection list";
            this.rptcollections.Id = 13;
            this.rptcollections.ImageOptions.ImageUri.Uri = "ListBullets";
            this.rptcollections.Name = "rptcollections";
            this.rptcollections.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // rptdailysummary
            // 
            this.rptdailysummary.Caption = "Daily Summary";
            this.rptdailysummary.Id = 14;
            this.rptdailysummary.ImageOptions.ImageUri.Uri = "ListBullets";
            this.rptdailysummary.Name = "rptdailysummary";
            this.rptdailysummary.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 15;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // bchangepass
            // 
            this.bchangepass.Caption = "Change Password";
            this.bchangepass.Id = 16;
            this.bchangepass.ImageOptions.LargeImage = global::Coffee.Properties.Resources.Key;
            this.bchangepass.Name = "bchangepass";
            this.bchangepass.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup5,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bfarmers);
            this.ribbonPageGroup1.ItemLinks.Add(this.bnewfarmer);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Farmers";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bcollect);
            this.ribbonPageGroup2.ItemLinks.Add(this.bcollections);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Collection";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.bstores);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Stores";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.bdebts);
            this.ribbonPageGroup4.ItemLinks.Add(this.bposteddebts);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Debts";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Settings";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bsetup);
            this.ribbonPageGroup3.ItemLinks.Add(this.busers);
            this.ribbonPageGroup3.ItemLinks.Add(this.bchangepass);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Setup";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6,
            this.ribbonPageGroup7});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Reports";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.rptfarmers);
            this.ribbonPageGroup6.ItemLinks.Add(this.rptcategory);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Farmers";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.rptcollections);
            this.ribbonPageGroup7.ItemLinks.Add(this.rptdailysummary);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "Collection";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Farmer list";
            this.barButtonItem1.Id = 10;
            this.barButtonItem1.ImageOptions.ImageUri.Uri = "ListBullets";
            this.barButtonItem1.ImageOptions.LargeImage = global::Coffee.Properties.Resources.collection_list;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Farmer list";
            this.barButtonItem2.Id = 10;
            this.barButtonItem2.ImageOptions.ImageUri.Uri = "ListBullets";
            this.barButtonItem2.ImageOptions.LargeImage = global::Coffee.Properties.Resources.collection_list;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // Menu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.Controls.Add(this.menuribbon);
            this.Name = "Menu";
            this.Size = new System.Drawing.Size(660, 140);
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.menuribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bfarmers;
        private DevExpress.XtraBars.BarButtonItem bnewfarmer;
        private DevExpress.XtraBars.BarButtonItem bcollect;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bcollections;
        private DevExpress.XtraBars.BarButtonItem bsetup;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem busers;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.BarButtonItem bdebts;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem bstores;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem bposteddebts;
        private DevExpress.XtraBars.BarButtonItem rptfarmers;
        private DevExpress.XtraBars.BarButtonItem rptcategory;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem rptcollections;
        private DevExpress.XtraBars.BarButtonItem rptdailysummary;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem bchangepass;
        public DevExpress.XtraBars.Ribbon.RibbonControl menuribbon;
    }
}
