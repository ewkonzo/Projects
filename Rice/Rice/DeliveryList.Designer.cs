namespace Rice
{
    partial class DeliveryList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryList));
            this.paddy_DetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paddy_DetailGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCollections_Date = new Rice.Gridcolumn();
            this.colCollection_Number = new Rice.Gridcolumn();
            this.colFarmers_Number = new Rice.Gridcolumn();
            this.colFarmers_Name = new Rice.Gridcolumn();
            this.colGross_kg = new Rice.Gridcolumn();
            this.colCrop = new Rice.Gridcolumn();
            this.colCollected_by = new Rice.Gridcolumn();
            this.colCollect_type = new Rice.Gridcolumn();
            this.collecttyperepository = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colCollections_Time = new Rice.Gridcolumn();
            this.colVariety = new Rice.Gridcolumn();
            this.varietyrepository = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colRecovery = new Rice.Gridcolumn();
            this.colMoisture = new Rice.Gridcolumn();
            this.colNet_kg = new Rice.Gridcolumn();
            this.colBag_weight = new Rice.Gridcolumn();
            this.colType = new Rice.Gridcolumn();
            this.typerepository = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBag_type = new Rice.Gridcolumn();
            this.colNo_of_bags = new Rice.Gridcolumn();
            this.colStatus = new Rice.Gridcolumn();
            this.statusrepository = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colTotalBagsWeighed = new Rice.Gridcolumn();
            this.colTotalBagsDelivered = new Rice.Gridcolumn();
            this.colUnweighedbags = new Rice.Gridcolumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnpostprint = new DevExpress.XtraBars.BarButtonItem();
            this.btnpost = new DevExpress.XtraBars.BarButtonItem();
            this.btnprintdelivery = new DevExpress.XtraBars.BarButtonItem();
            this.btnprintweigh = new DevExpress.XtraBars.BarButtonItem();
            this.btndelivery = new DevExpress.XtraBars.BarButtonItem();
            this.btnweigh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.paddy_DetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddy_DetailGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collecttyperepository)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varietyrepository)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typerepository)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusrepository)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // paddy_DetailBindingSource
            // 
            this.paddy_DetailBindingSource.DataSource = typeof(Rice.Paddy_Detail);
            // 
            // paddy_DetailGridControl
            // 
            this.paddy_DetailGridControl.DataSource = this.paddy_DetailBindingSource;
            this.paddy_DetailGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paddy_DetailGridControl.Location = new System.Drawing.Point(0, 139);
            this.paddy_DetailGridControl.MainView = this.gridView1;
            this.paddy_DetailGridControl.Name = "paddy_DetailGridControl";
            this.paddy_DetailGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.typerepository,
            this.collecttyperepository,
            this.varietyrepository,
            this.statusrepository});
            this.paddy_DetailGridControl.Size = new System.Drawing.Size(884, 249);
            this.paddy_DetailGridControl.TabIndex = 1;
            this.paddy_DetailGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCollections_Date,
            this.colCollection_Number,
            this.colFarmers_Number,
            this.colFarmers_Name,
            this.colGross_kg,
            this.colCrop,
            this.colCollected_by,
            this.colCollect_type,
            this.colCollections_Time,
            this.colVariety,
            this.colRecovery,
            this.colMoisture,
            this.colNet_kg,
            this.colBag_weight,
            this.colType,
            this.colBag_type,
            this.colNo_of_bags,
            this.colStatus,
            this.colTotalBagsWeighed,
            this.colTotalBagsDelivered,
            this.colUnweighedbags});
            this.gridView1.GridControl = this.paddy_DetailGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowCsvFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowExcelFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowHtmlFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowRtfFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.AllowTxtFormat = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted;
            this.gridView1.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsCustomization.AllowRowSizing = true;
            this.gridView1.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.gridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView1.OptionsLayout.StoreAllOptions = true;
            this.gridView1.OptionsLayout.StoreAppearance = true;
            this.gridView1.OptionsLayout.StoreFormatRules = true;
            this.gridView1.OptionsMenu.ShowConditionalFormattingItem = true;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsPrint.PrintDetails = true;
            this.gridView1.OptionsPrint.PrintFilterInfo = true;
            this.gridView1.OptionsPrint.PrintPreview = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            // 
            // colCollections_Date
            // 
            this.colCollections_Date.Caption = "Date";
            this.colCollections_Date.FieldName = "Collections_Date";
            this.colCollections_Date.Name = "colCollections_Date";
            this.colCollections_Date.Showinlist = true;
            this.colCollections_Date.Visible = true;
            this.colCollections_Date.VisibleIndex = 2;
            this.colCollections_Date.Width = 47;
            // 
            // colCollection_Number
            // 
            this.colCollection_Number.Caption = "Reference";
            this.colCollection_Number.FieldName = "Collection_Number";
            this.colCollection_Number.Name = "colCollection_Number";
            this.colCollection_Number.Showinlist = true;
            this.colCollection_Number.Visible = true;
            this.colCollection_Number.VisibleIndex = 0;
            this.colCollection_Number.Width = 85;
            // 
            // colFarmers_Number
            // 
            this.colFarmers_Number.Caption = "Farmer";
            this.colFarmers_Number.FieldName = "Farmers_Number";
            this.colFarmers_Number.Name = "colFarmers_Number";
            this.colFarmers_Number.Showinlist = true;
            this.colFarmers_Number.Visible = true;
            this.colFarmers_Number.VisibleIndex = 4;
            this.colFarmers_Number.Width = 43;
            // 
            // colFarmers_Name
            // 
            this.colFarmers_Name.Caption = "Name";
            this.colFarmers_Name.FieldName = "Farmers_Name";
            this.colFarmers_Name.Name = "colFarmers_Name";
            this.colFarmers_Name.Showinlist = true;
            this.colFarmers_Name.Visible = true;
            this.colFarmers_Name.VisibleIndex = 5;
            this.colFarmers_Name.Width = 54;
            // 
            // colGross_kg
            // 
            this.colGross_kg.FieldName = "Gross_kg";
            this.colGross_kg.Name = "colGross_kg";
            this.colGross_kg.Showinlist = false;
            this.colGross_kg.Visible = true;
            this.colGross_kg.VisibleIndex = 8;
            this.colGross_kg.Width = 47;
            // 
            // colCrop
            // 
            this.colCrop.FieldName = "Crop";
            this.colCrop.Name = "colCrop";
            this.colCrop.Showinlist = false;
            this.colCrop.Visible = true;
            this.colCrop.VisibleIndex = 6;
            this.colCrop.Width = 35;
            // 
            // colCollected_by
            // 
            this.colCollected_by.FieldName = "Collected_by";
            this.colCollected_by.Name = "colCollected_by";
            this.colCollected_by.Showinlist = false;
            this.colCollected_by.Visible = true;
            this.colCollected_by.VisibleIndex = 17;
            this.colCollected_by.Width = 33;
            // 
            // colCollect_type
            // 
            this.colCollect_type.Caption = "Collect Type";
            this.colCollect_type.ColumnEdit = this.collecttyperepository;
            this.colCollect_type.FieldName = "Collect_type";
            this.colCollect_type.Name = "colCollect_type";
            this.colCollect_type.Showinlist = true;
            this.colCollect_type.Visible = true;
            this.colCollect_type.VisibleIndex = 1;
            this.colCollect_type.Width = 107;
            // 
            // collecttyperepository
            // 
            this.collecttyperepository.AutoHeight = false;
            this.collecttyperepository.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.collecttyperepository.Name = "collecttyperepository";
            // 
            // colCollections_Time
            // 
            this.colCollections_Time.Caption = "Time";
            this.colCollections_Time.DisplayFormat.FormatString = "t";
            this.colCollections_Time.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCollections_Time.FieldName = "Collections_Time";
            this.colCollections_Time.Name = "colCollections_Time";
            this.colCollections_Time.Showinlist = false;
            this.colCollections_Time.Visible = true;
            this.colCollections_Time.VisibleIndex = 3;
            this.colCollections_Time.Width = 38;
            // 
            // colVariety
            // 
            this.colVariety.ColumnEdit = this.varietyrepository;
            this.colVariety.FieldName = "Variety";
            this.colVariety.Name = "colVariety";
            this.colVariety.Showinlist = false;
            this.colVariety.Visible = true;
            this.colVariety.VisibleIndex = 7;
            this.colVariety.Width = 43;
            // 
            // varietyrepository
            // 
            this.varietyrepository.AutoHeight = false;
            this.varietyrepository.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.varietyrepository.Name = "varietyrepository";
            // 
            // colRecovery
            // 
            this.colRecovery.FieldName = "Recovery";
            this.colRecovery.Name = "colRecovery";
            this.colRecovery.Showinlist = false;
            this.colRecovery.Visible = true;
            this.colRecovery.VisibleIndex = 10;
            this.colRecovery.Width = 28;
            // 
            // colMoisture
            // 
            this.colMoisture.FieldName = "Moisture";
            this.colMoisture.Name = "colMoisture";
            this.colMoisture.Showinlist = false;
            this.colMoisture.Visible = true;
            this.colMoisture.VisibleIndex = 9;
            this.colMoisture.Width = 47;
            // 
            // colNet_kg
            // 
            this.colNet_kg.FieldName = "Net_kg";
            this.colNet_kg.Name = "colNet_kg";
            this.colNet_kg.Showinlist = false;
            this.colNet_kg.Visible = true;
            this.colNet_kg.VisibleIndex = 15;
            this.colNet_kg.Width = 28;
            // 
            // colBag_weight
            // 
            this.colBag_weight.FieldName = "Bag_weight";
            this.colBag_weight.Name = "colBag_weight";
            this.colBag_weight.Showinlist = false;
            this.colBag_weight.Visible = true;
            this.colBag_weight.VisibleIndex = 11;
            this.colBag_weight.Width = 66;
            // 
            // colType
            // 
            this.colType.ColumnEdit = this.typerepository;
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Showinlist = false;
            this.colType.Visible = true;
            this.colType.VisibleIndex = 12;
            this.colType.Width = 35;
            // 
            // typerepository
            // 
            this.typerepository.AutoHeight = false;
            this.typerepository.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.typerepository.Name = "typerepository";
            // 
            // colBag_type
            // 
            this.colBag_type.Caption = "Bag Type";
            this.colBag_type.FieldName = "Bag_type";
            this.colBag_type.Name = "colBag_type";
            this.colBag_type.Showinlist = false;
            this.colBag_type.Visible = true;
            this.colBag_type.VisibleIndex = 13;
            this.colBag_type.Width = 58;
            // 
            // colNo_of_bags
            // 
            this.colNo_of_bags.Caption = "No of bags";
            this.colNo_of_bags.FieldName = "No_of_bags";
            this.colNo_of_bags.Name = "colNo_of_bags";
            this.colNo_of_bags.Showinlist = false;
            this.colNo_of_bags.Visible = true;
            this.colNo_of_bags.VisibleIndex = 14;
            this.colNo_of_bags.Width = 35;
            // 
            // colStatus
            // 
            this.colStatus.ColumnEdit = this.statusrepository;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Showinlist = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 16;
            this.colStatus.Width = 37;
            // 
            // statusrepository
            // 
            this.statusrepository.AutoHeight = false;
            this.statusrepository.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.statusrepository.Name = "statusrepository";
            // 
            // colTotalBagsWeighed
            // 
            this.colTotalBagsWeighed.Caption = "Bags Weighed";
            this.colTotalBagsWeighed.FieldName = "TotalBagsWeighed";
            this.colTotalBagsWeighed.Name = "colTotalBagsWeighed";
            this.colTotalBagsWeighed.Showinlist = true;
            this.colTotalBagsWeighed.Visible = true;
            this.colTotalBagsWeighed.VisibleIndex = 19;
            // 
            // colTotalBagsDelivered
            // 
            this.colTotalBagsDelivered.Caption = "Bags Delivered";
            this.colTotalBagsDelivered.FieldName = "TotalBagsDelivered";
            this.colTotalBagsDelivered.Name = "colTotalBagsDelivered";
            this.colTotalBagsDelivered.Showinlist = true;
            this.colTotalBagsDelivered.Visible = true;
            this.colTotalBagsDelivered.VisibleIndex = 18;
            // 
            // colUnweighedbags
            // 
            this.colUnweighedbags.Caption = "Bal";
            this.colUnweighedbags.FieldName = "Unweighedbags";
            this.colUnweighedbags.Name = "colUnweighedbags";
            this.colUnweighedbags.Showinlist = true;
            this.colUnweighedbags.Visible = true;
            this.colUnweighedbags.VisibleIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 388);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 44);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(348, 11);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(97, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "CANCEL";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(217, 11);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(97, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "OK";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
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
            this.btnweigh});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(884, 139);
            this.ribbonControl1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ribbonControl1_ItemClick);
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
            // btnweigh
            // 
            this.btnweigh.Caption = "New Weigh";
            this.btnweigh.Id = 6;
            this.btnweigh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnweigh.ImageOptions.Image")));
            this.btnweigh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnweigh.ImageOptions.LargeImage")));
            this.btnweigh.Name = "btnweigh";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btndelivery);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "New";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnprintdelivery);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Delivery";
            // 
            // DeliveryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 432);
            this.Controls.Add(this.paddy_DetailGridControl);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.panel1);
            this.Name = "DeliveryList";
            this.Text = "Paddy_list";
            ((System.ComponentModel.ISupportInitialize)(this.paddy_DetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddy_DetailGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.collecttyperepository)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varietyrepository)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typerepository)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusrepository)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource paddy_DetailBindingSource;
        private DevExpress.XtraGrid.GridControl paddy_DetailGridControl;
        private Gridcolumn colCollections_Date;
        private Gridcolumn colCollection_Number;
        private Gridcolumn colFarmers_Number;
        private Gridcolumn colFarmers_Name;
        private Gridcolumn colGross_kg;
        private Gridcolumn colCrop;
        private Gridcolumn colCollected_by;
        private Gridcolumn colCollect_type;
        private Gridcolumn colCollections_Time;
        private Gridcolumn colVariety;
        private Gridcolumn colRecovery;
        private Gridcolumn colMoisture;
        private Gridcolumn colNet_kg;
        private Gridcolumn colBag_weight;
        private Gridcolumn colType;
        private Gridcolumn colBag_type;
        private Gridcolumn colNo_of_bags;
        private Gridcolumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox collecttyperepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox varietyrepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox typerepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox statusrepository;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Gridcolumn colTotalBagsWeighed;
        private Gridcolumn colTotalBagsDelivered;
        private Gridcolumn colUnweighedbags;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnpostprint;
        private DevExpress.XtraBars.BarButtonItem btnpost;
        private DevExpress.XtraBars.BarButtonItem btnprintdelivery;
        private DevExpress.XtraBars.BarButtonItem btnprintweigh;
        private DevExpress.XtraBars.BarButtonItem btndelivery;
        private DevExpress.XtraBars.BarButtonItem btnweigh;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}