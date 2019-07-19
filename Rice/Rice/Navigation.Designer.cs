namespace Rice
{
    partial class Navigation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Navigation));
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.navigationribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.navnext = new DevExpress.XtraBars.BarButtonItem();
            this.navprevious = new DevExpress.XtraBars.BarButtonItem();
            this.navfirst = new DevExpress.XtraBars.BarButtonItem();
            this.navlast = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.actionxlsx = new DevExpress.XtraBars.BarButtonItem();
            this.actionxls = new DevExpress.XtraBars.BarButtonItem();
            this.actionpdf = new DevExpress.XtraBars.BarButtonItem();
            this.txtrecord = new DevExpress.XtraBars.BarEditItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.btnexcelx = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.btnexcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnpdf = new DevExpress.XtraBars.BarButtonItem();
            this.btnnew = new DevExpress.XtraBars.BarButtonItem();
            this.btnsave = new DevExpress.XtraBars.BarButtonItem();
            this.btnsavennew = new DevExpress.XtraBars.BarButtonItem();
            this.btnclose = new DevExpress.XtraBars.BarButtonItem();
            this.btnSelect = new DevExpress.XtraBars.BarButtonItem();
            this.btndelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnrefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.selectgroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.IsFloatValue = false;
            this.repositoryItemSpinEdit1.Mask.EditMask = "N00";
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            this.repositoryItemSpinEdit1.SpinStyle = DevExpress.XtraEditors.Controls.SpinStyles.Horizontal;
            // 
            // navigationribbon
            // 
            this.navigationribbon.AutoSizeItems = true;
            this.navigationribbon.ExpandCollapseItem.Id = 0;
            this.navigationribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.navigationribbon.ExpandCollapseItem,
            this.barButtonItem1,
            this.navnext,
            this.navprevious,
            this.navfirst,
            this.navlast,
            this.barButtonItem2,
            this.barSubItem1,
            this.actionxlsx,
            this.actionxls,
            this.actionpdf,
            this.txtrecord,
            this.barHeaderItem1,
            this.btnexcelx,
            this.barButtonItem4,
            this.btnexcel,
            this.btnpdf,
            this.btnnew,
            this.btnsave,
            this.btnsavennew,
            this.btnclose,
            this.btnSelect,
            this.btndelete,
            this.btnrefresh});
            this.navigationribbon.Location = new System.Drawing.Point(0, 0);
            this.navigationribbon.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.navigationribbon.MaxItemId = 17;
            this.navigationribbon.Name = "navigationribbon";
            this.navigationribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.navigationribbon.Size = new System.Drawing.Size(1408, 202);
            this.navigationribbon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ribbonControl1_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // navnext
            // 
            this.navnext.Caption = "Next";
            this.navnext.Id = 2;
            this.navnext.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.navnext.ImageOptions.ImageUri.Uri = "DoubleNext";
            this.navnext.Name = "navnext";
            this.navnext.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // navprevious
            // 
            this.navprevious.Caption = "Previous";
            this.navprevious.Id = 3;
            this.navprevious.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.navprevious.ImageOptions.ImageUri.Uri = "DoublePrev";
            this.navprevious.Name = "navprevious";
            this.navprevious.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // navfirst
            // 
            this.navfirst.Caption = "First";
            this.navfirst.Id = 4;
            this.navfirst.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.navfirst.ImageOptions.ImageUri.Uri = "First";
            this.navfirst.Name = "navfirst";
            this.navfirst.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // navlast
            // 
            this.navlast.Caption = "Last";
            this.navlast.Id = 5;
            this.navlast.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.navlast.ImageOptions.ImageUri.Uri = "Last";
            this.navlast.Name = "navlast";
            this.navlast.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Export";
            this.barButtonItem2.Id = 6;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Export";
            this.barSubItem1.Id = 7;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.actionxlsx),
            new DevExpress.XtraBars.LinkPersistInfo(this.actionxls),
            new DevExpress.XtraBars.LinkPersistInfo(this.actionpdf)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // actionxlsx
            // 
            this.actionxlsx.Caption = "xlsx";
            this.actionxlsx.Id = 8;
            this.actionxlsx.Name = "actionxlsx";
            this.actionxlsx.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // actionxls
            // 
            this.actionxls.Caption = "xls";
            this.actionxls.Id = 9;
            this.actionxls.Name = "actionxls";
            // 
            // actionpdf
            // 
            this.actionpdf.Caption = "Pdf";
            this.actionpdf.Id = 10;
            this.actionpdf.Name = "actionpdf";
            // 
            // txtrecord
            // 
            this.txtrecord.Caption = " of {0}";
            this.txtrecord.CaptionAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtrecord.Edit = this.repositoryItemSpinEdit1;
            this.txtrecord.Id = 11;
            this.txtrecord.Name = "txtrecord";
            this.txtrecord.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            this.txtrecord.EditValueChanged += new System.EventHandler(this.txtrecord_EditValueChanged);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "of {0}";
            this.barHeaderItem1.Id = 12;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // btnexcelx
            // 
            this.btnexcelx.Caption = "XLSX";
            this.btnexcelx.Id = 2;
            this.btnexcelx.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnexcelx.ImageOptions.Image")));
            this.btnexcelx.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnexcelx.ImageOptions.LargeImage")));
            this.btnexcelx.Name = "btnexcelx";
            this.btnexcelx.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // btnexcel
            // 
            this.btnexcel.Caption = "XLS";
            this.btnexcel.Id = 4;
            this.btnexcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnexcel.ImageOptions.Image")));
            this.btnexcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnexcel.ImageOptions.LargeImage")));
            this.btnexcel.Name = "btnexcel";
            // 
            // btnpdf
            // 
            this.btnpdf.Caption = "PDF";
            this.btnpdf.Id = 6;
            this.btnpdf.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnpdf.ImageOptions.Image")));
            this.btnpdf.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnpdf.ImageOptions.LargeImage")));
            this.btnpdf.Name = "btnpdf";
            // 
            // btnnew
            // 
            this.btnnew.Caption = "New";
            this.btnnew.Id = 10;
            this.btnnew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnnew.ImageOptions.Image")));
            this.btnnew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnnew.ImageOptions.LargeImage")));
            this.btnnew.Name = "btnnew";
            // 
            // btnsave
            // 
            this.btnsave.Caption = "Save";
            this.btnsave.Id = 11;
            this.btnsave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.ImageOptions.Image")));
            this.btnsave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnsave.ImageOptions.LargeImage")));
            this.btnsave.Name = "btnsave";
            // 
            // btnsavennew
            // 
            this.btnsavennew.Caption = "Save && New";
            this.btnsavennew.Id = 12;
            this.btnsavennew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnsavennew.ImageOptions.Image")));
            this.btnsavennew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnsavennew.ImageOptions.LargeImage")));
            this.btnsavennew.Name = "btnsavennew";
            // 
            // btnclose
            // 
            this.btnclose.Caption = "Close";
            this.btnclose.Id = 13;
            this.btnclose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnclose.ImageOptions.Image")));
            this.btnclose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnclose.ImageOptions.LargeImage")));
            this.btnclose.Name = "btnclose";
            // 
            // btnSelect
            // 
            this.btnSelect.Caption = "Select";
            this.btnSelect.Id = 14;
            this.btnSelect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.ImageOptions.Image")));
            this.btnSelect.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSelect.ImageOptions.LargeImage")));
            this.btnSelect.Name = "btnSelect";
            // 
            // btndelete
            // 
            this.btndelete.Caption = "Delete";
            this.btndelete.Id = 15;
            this.btndelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btndelete.ImageOptions.Image")));
            this.btndelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btndelete.ImageOptions.LargeImage")));
            this.btndelete.Name = "btndelete";
            // 
            // btnrefresh
            // 
            this.btnrefresh.Caption = "Refresh";
            this.btnrefresh.Id = 16;
            this.btnrefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnrefresh.ImageOptions.Image")));
            this.btnrefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnrefresh.ImageOptions.LargeImage")));
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.selectgroup,
            this.ribbonPageGroup3,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup5,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Actions";
            // 
            // selectgroup
            // 
            this.selectgroup.ItemLinks.Add(this.btnSelect, true);
            this.selectgroup.Name = "selectgroup";
            this.selectgroup.Text = "Select Record";
            this.selectgroup.Visible = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnnew);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnsave);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnsavennew);
            this.ribbonPageGroup3.ItemLinks.Add(this.btndelete);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Edit";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.navfirst);
            this.ribbonPageGroup1.ItemLinks.Add(this.navprevious);
            this.ribbonPageGroup1.ItemLinks.Add(this.txtrecord);
            this.ribbonPageGroup1.ItemLinks.Add(this.navnext);
            this.ribbonPageGroup1.ItemLinks.Add(this.navlast);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Nav";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnexcelx);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnexcel);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnpdf);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Export";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnrefresh);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Refresh";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnclose);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Close";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "To Excel";
            this.barButtonItem5.Id = 2;
            this.barButtonItem5.ImageOptions.Image = global::Rice.Properties.Resources.excel;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "To Excel";
            this.barButtonItem6.Id = 2;
            this.barButtonItem6.ImageOptions.Image = global::Rice.Properties.Resources.excel;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navigationribbon);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Navigation";
            this.Size = new System.Drawing.Size(1408, 199);
            this.Load += new System.EventHandler(this.Navigation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem navnext;
        private DevExpress.XtraBars.BarButtonItem navprevious;
        private DevExpress.XtraBars.BarButtonItem navfirst;
        private DevExpress.XtraBars.BarButtonItem navlast;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem actionxlsx;
        private DevExpress.XtraBars.BarButtonItem actionxls;
        private DevExpress.XtraBars.BarButtonItem actionpdf;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarEditItem txtrecord;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarButtonItem btnexcelx;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem btnexcel;
        private DevExpress.XtraBars.BarButtonItem btnpdf;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem btnnew;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnsave;
        private DevExpress.XtraBars.BarButtonItem btnsavennew;
        private DevExpress.XtraBars.BarButtonItem btnclose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnSelect;
        public DevExpress.XtraBars.Ribbon.RibbonPageGroup selectgroup;
        private DevExpress.XtraBars.BarButtonItem btndelete;
        public DevExpress.XtraBars.Ribbon.RibbonControl navigationribbon;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraBars.BarButtonItem btnrefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
    }
}
