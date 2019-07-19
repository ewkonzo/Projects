namespace Rice
{
    partial class Farmers
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Farmers));
            this.farmerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.farmerGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNo = new Rice.Gridcolumn();
            this.colName = new Rice.Gridcolumn();
            this.colID_No = new Rice.Gridcolumn();
            this.colGender = new Rice.Gridcolumn();
            this.genderrepos = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colPhone = new Rice.Gridcolumn();
            this.colSectionname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new Rice.Gridcolumn();
            this.unitrepos = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBank = new Rice.Gridcolumn();
            this.bankrepos = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBank_Account = new Rice.Gridcolumn();
            this.colClass = new Rice.Gridcolumn();
            this.Classrepo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colAcreage = new Rice.Gridcolumn();
            this.colServiced_Acres = new DevExpress.XtraGrid.Columns.GridColumn();
            this.categoryrepos = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.maritalrepository = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.Sectionrepo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.unitlookup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.picturerepos = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.cellcontext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterWithThisValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnpostprint = new DevExpress.XtraBars.BarButtonItem();
            this.btnpost = new DevExpress.XtraBars.BarButtonItem();
            this.btnprintdelivery = new DevExpress.XtraBars.BarButtonItem();
            this.btnprintweigh = new DevExpress.XtraBars.BarButtonItem();
            this.btndelivery = new DevExpress.XtraBars.BarButtonItem();
            this.btnfarmer = new DevExpress.XtraBars.BarButtonItem();
            this.btnviewdelivery = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnservice = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.farmerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.farmerGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.genderrepos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitrepos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankrepos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Classrepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryrepos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maritalrepository)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sectionrepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitlookup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturerepos)).BeginInit();
            this.cellcontext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // farmerBindingSource
            // 
            this.farmerBindingSource.DataSource = typeof(Rice.Farmer);
            this.farmerBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.farmerBindingSource_AddingNew);
            this.farmerBindingSource.CurrentItemChanged += new System.EventHandler(this.farmerBindingSource_CurrentItemChanged);
            // 
            // farmerGridControl
            // 
            this.farmerGridControl.DataSource = this.farmerBindingSource;
            this.farmerGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.farmerGridControl.Location = new System.Drawing.Point(0, 141);
            this.farmerGridControl.MainView = this.gridView1;
            this.farmerGridControl.Name = "farmerGridControl";
            this.farmerGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.categoryrepos,
            this.maritalrepository,
            this.genderrepos,
            this.Sectionrepo,
            this.Classrepo,
            this.unitrepos,
            this.bankrepos,
            this.unitlookup,
            this.picturerepos});
            this.farmerGridControl.Size = new System.Drawing.Size(662, 333);
            this.farmerGridControl.TabIndex = 2;
            this.farmerGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.farmerGridControl.Click += new System.EventHandler(this.farmerGridControl_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNo,
            this.colName,
            this.colID_No,
            this.colGender,
            this.colPhone,
            this.colSectionname,
            this.colUnit,
            this.colBank,
            this.colBank_Account,
            this.colClass,
            this.colAcreage,
            this.colServiced_Acres});
            this.gridView1.GridControl = this.farmerGridControl;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Serviced_Acres", null, "(Service acres: SUM={0:0.##})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cum_Mbuni", null, "(Mbuni Cummulative: SUM={0:0.##})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Enter new farmer";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsEditForm.ActionOnModifiedRowChange = DevExpress.XtraGrid.Views.Grid.EditFormModifiedAction.Save;
            this.gridView1.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNo, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gridView1_CustomColumnSort);
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            // 
            // colNo
            // 
            this.colNo.FieldName = "No";
            this.colNo.Name = "colNo";
        
            this.colNo.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colNo.Visible = true;
            this.colNo.VisibleIndex = 0;
            this.colNo.Width = 42;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
          
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 152;
            // 
            // colID_No
            // 
            this.colID_No.Caption = "ID No";
            this.colID_No.FieldName = "ID_No";
            this.colID_No.Name = "colID_No";
        
            this.colID_No.Visible = true;
            this.colID_No.VisibleIndex = 3;
            this.colID_No.Width = 47;
            // 
            // colGender
            // 
            this.colGender.ColumnEdit = this.genderrepos;
            this.colGender.FieldName = "Gender";
            this.colGender.Name = "colGender";
        
            this.colGender.Visible = true;
            this.colGender.VisibleIndex = 2;
            this.colGender.Width = 47;
            // 
            // genderrepos
            // 
            this.genderrepos.AutoHeight = false;
            this.genderrepos.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.genderrepos.Name = "genderrepos";
            // 
            // colPhone
            // 
            this.colPhone.FieldName = "Phone";
            this.colPhone.Name = "colPhone";
           
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 4;
            this.colPhone.Width = 40;
            // 
            // colSectionname
            // 
            this.colSectionname.FieldName = "Sectionname";
            this.colSectionname.Name = "colSectionname";
            this.colSectionname.Visible = true;
            this.colSectionname.VisibleIndex = 8;
            this.colSectionname.Width = 56;
            // 
            // colUnit
            // 
            this.colUnit.ColumnEdit = this.unitrepos;
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
       
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 5;
            this.colUnit.Width = 28;
            // 
            // unitrepos
            // 
            this.unitrepos.AutoHeight = false;
            this.unitrepos.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.unitrepos.Name = "unitrepos";
            // 
            // colBank
            // 
            this.colBank.ColumnEdit = this.bankrepos;
            this.colBank.FieldName = "Bank";
            this.colBank.Name = "colBank";
           
            this.colBank.Visible = true;
            this.colBank.VisibleIndex = 6;
            this.colBank.Width = 31;
            // 
            // bankrepos
            // 
            this.bankrepos.AutoHeight = false;
            this.bankrepos.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bankrepos.Name = "bankrepos";
            // 
            // colBank_Account
            // 
            this.colBank_Account.Caption = "Bank Accont";
            this.colBank_Account.FieldName = "Bank_Account";
            this.colBank_Account.Name = "colBank_Account";
       
            this.colBank_Account.Visible = true;
            this.colBank_Account.VisibleIndex = 7;
            this.colBank_Account.Width = 59;
            // 
            // colClass
            // 
            this.colClass.ColumnEdit = this.Classrepo;
            this.colClass.FieldName = "Class";
            this.colClass.Name = "colClass";
           
            this.colClass.Visible = true;
            this.colClass.VisibleIndex = 9;
            this.colClass.Width = 33;
            // 
            // Classrepo
            // 
            this.Classrepo.AutoHeight = false;
            this.Classrepo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Classrepo.Name = "Classrepo";
            // 
            // colAcreage
            // 
            this.colAcreage.FieldName = "Acreage";
            this.colAcreage.Name = "colAcreage";
   
            this.colAcreage.Visible = true;
            this.colAcreage.VisibleIndex = 10;
            this.colAcreage.Width = 44;
            // 
            // colServiced_Acres
            // 
            this.colServiced_Acres.FieldName = "Serviced_Acres";
            this.colServiced_Acres.Name = "colServiced_Acres";
            this.colServiced_Acres.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Serviced_Acres", "SUM={0:0.##}")});
            this.colServiced_Acres.Visible = true;
            this.colServiced_Acres.VisibleIndex = 11;
            this.colServiced_Acres.Width = 65;
            // 
            // categoryrepos
            // 
            this.categoryrepos.AutoHeight = false;
            this.categoryrepos.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.categoryrepos.Name = "categoryrepos";
            // 
            // maritalrepository
            // 
            this.maritalrepository.AutoHeight = false;
            this.maritalrepository.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.maritalrepository.Name = "maritalrepository";
            // 
            // Sectionrepo
            // 
            this.Sectionrepo.AutoHeight = false;
            this.Sectionrepo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Sectionrepo.Name = "Sectionrepo";
            this.Sectionrepo.SelectedValueChanged += new System.EventHandler(this.Sectionrepo_SelectedValueChanged);
            // 
            // unitlookup
            // 
            this.unitlookup.AutoHeight = false;
            this.unitlookup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.unitlookup.Name = "unitlookup";
            // 
            // picturerepos
            // 
            this.picturerepos.Name = "picturerepos";
            this.picturerepos.PictureStoreMode = DevExpress.XtraEditors.Controls.PictureStoreMode.ByteArray;
            this.picturerepos.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            // 
            // cellcontext
            // 
            this.cellcontext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterWithThisValueToolStripMenuItem});
            this.cellcontext.Name = "cellcontext";
            this.cellcontext.Size = new System.Drawing.Size(139, 26);
            this.cellcontext.Opening += new System.ComponentModel.CancelEventHandler(this.cellcontext_Opening);
            this.cellcontext.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cellcontext_ItemClicked);
            // 
            // filterWithThisValueToolStripMenuItem
            // 
            this.filterWithThisValueToolStripMenuItem.Name = "filterWithThisValueToolStripMenuItem";
            this.filterWithThisValueToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.filterWithThisValueToolStripMenuItem.Text = "Show report";
            this.filterWithThisValueToolStripMenuItem.Click += new System.EventHandler(this.filterWithThisValueToolStripMenuItem_Click);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnpostprint,
            this.btnpost,
            this.btnprintdelivery,
            this.btnprintweigh,
            this.btndelivery,
            this.btnfarmer,
            this.btnviewdelivery,
            this.barButtonItem1,
            this.btnservice});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 10;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(662, 141);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            this.ribbonControl1.Visible = false;
            // 
            // btnpostprint
            // 
            this.btnpostprint.Caption = "Post && Print Delivery";
            this.btnpostprint.Id = 1;
            this.btnpostprint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnpostprint.ImageOptions.Image")));
            this.btnpostprint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnpostprint.ImageOptions.LargeImage")));
            this.btnpostprint.Name = "btnpostprint";
            // 
            // btnpost
            // 
            this.btnpost.Caption = "Post Delivery";
            this.btnpost.Id = 2;
            this.btnpost.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnpost.ImageOptions.Image")));
            this.btnpost.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnpost.ImageOptions.LargeImage")));
            this.btnpost.Name = "btnpost";
            // 
            // btnprintdelivery
            // 
            this.btnprintdelivery.Caption = "Print Delivery";
            this.btnprintdelivery.Id = 3;
            this.btnprintdelivery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnprintdelivery.ImageOptions.Image")));
            this.btnprintdelivery.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnprintdelivery.ImageOptions.LargeImage")));
            this.btnprintdelivery.Name = "btnprintdelivery";
            // 
            // btnprintweigh
            // 
            this.btnprintweigh.Caption = "Print Weigh Slip";
            this.btnprintweigh.Id = 4;
            this.btnprintweigh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnprintweigh.ImageOptions.Image")));
            this.btnprintweigh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnprintweigh.ImageOptions.LargeImage")));
            this.btnprintweigh.Name = "btnprintweigh";
            // 
            // btndelivery
            // 
            this.btndelivery.Caption = "New Delivery";
            this.btndelivery.Id = 5;
            this.btndelivery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btndelivery.ImageOptions.Image")));
            this.btndelivery.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btndelivery.ImageOptions.LargeImage")));
            this.btndelivery.Name = "btndelivery";
            // 
            // btnfarmer
            // 
            this.btnfarmer.Caption = "New Farmer";
            this.btnfarmer.Id = 6;
            this.btnfarmer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnfarmer.ImageOptions.Image")));
            this.btnfarmer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnfarmer.ImageOptions.LargeImage")));
            this.btnfarmer.Name = "btnfarmer";
            this.btnfarmer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnfarmer_ItemClick);
            // 
            // btnviewdelivery
            // 
            this.btnviewdelivery.Caption = "View Delivery";
            this.btnviewdelivery.Id = 7;
            this.btnviewdelivery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnviewdelivery.ImageOptions.Image")));
            this.btnviewdelivery.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnviewdelivery.ImageOptions.LargeImage")));
            this.btnviewdelivery.Name = "btnviewdelivery";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnservice
            // 
            this.btnservice.Caption = "Service Report";
            this.btnservice.Id = 9;
            this.btnservice.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnservice.ImageOptions.Image")));
            this.btnservice.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnservice.ImageOptions.LargeImage")));
            this.btnservice.Name = "btnservice";
            this.btnservice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnservice_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnfarmer);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "New";
            // 
            // Farmers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 474);
            this.Controls.Add(this.farmerGridControl);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Farmers";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farmers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Farmers_FormClosing);
            this.Load += new System.EventHandler(this.Farmers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.farmerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.farmerGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.genderrepos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitrepos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankrepos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Classrepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryrepos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maritalrepository)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sectionrepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitlookup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturerepos)).EndInit();
            this.cellcontext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource farmerBindingSource;
        private DevExpress.XtraGrid.GridControl farmerGridControl;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private System.Windows.Forms.ContextMenuStrip cellcontext;
        private System.Windows.Forms.ToolStripMenuItem filterWithThisValueToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colID_No;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox categoryrepos;
        private DevExpress.XtraGrid.Columns.GridColumn colGender;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colBank;
        private DevExpress.XtraGrid.Columns.GridColumn colBank_Account;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colClass;
        private DevExpress.XtraGrid.Columns.GridColumn colAcreage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox genderrepos;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox maritalrepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox Sectionrepo;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox Classrepo;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox unitrepos;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox bankrepos;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit unitlookup;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit picturerepos;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnpostprint;
        private DevExpress.XtraBars.BarButtonItem btnpost;
        private DevExpress.XtraBars.BarButtonItem btnprintdelivery;
        private DevExpress.XtraBars.BarButtonItem btnprintweigh;
        private DevExpress.XtraBars.BarButtonItem btndelivery;
        private DevExpress.XtraBars.BarButtonItem btnfarmer;
        private DevExpress.XtraBars.BarButtonItem btnviewdelivery;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraGrid.Columns.GridColumn colSectionname;
        private DevExpress.XtraGrid.Columns.GridColumn colServiced_Acres;
        private DevExpress.XtraBars.BarButtonItem btnservice;
    }
}