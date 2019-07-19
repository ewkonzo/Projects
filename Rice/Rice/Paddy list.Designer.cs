namespace Rice
{
    partial class Paddy_list
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paddy_list));
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statusrepository = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
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
            this.colMoisture_Weight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoisture = new Rice.Gridcolumn();
            this.colNet_kg = new Rice.Gridcolumn();
            this.colBag_weight = new Rice.Gridcolumn();
            this.colType = new Rice.Gridcolumn();
            this.typerepository = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBag_type = new Rice.Gridcolumn();
            this.colNo_of_bags_Delivered = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalBagsWeighed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnweighedbags = new Rice.Gridcolumn();
            this.repositoryItemHypertextLabel1 = new DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.btnpostprint = new DevExpress.XtraBars.BarButtonItem();
            this.btnpost = new DevExpress.XtraBars.BarButtonItem();
            this.btnprintdelivery = new DevExpress.XtraBars.BarButtonItem();
            this.btnprintweigh = new DevExpress.XtraBars.BarButtonItem();
            this.btndelivery = new DevExpress.XtraBars.BarButtonItem();
            this.btnweigh = new DevExpress.XtraBars.BarButtonItem();
            this.btnviewbags = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.printdelivery = new DevExpress.XtraBars.BarButtonItem();
            this.printweighslip = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterByThisValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.statusrepository)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddy_DetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddy_DetailGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collecttyperepository)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.varietyrepository)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typerepository)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colStatus
            // 
            this.colStatus.ColumnEdit = this.statusrepository;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 18;
            this.colStatus.Width = 85;
            // 
            // statusrepository
            // 
            this.statusrepository.AutoHeight = false;
            this.statusrepository.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.statusrepository.Name = "statusrepository";
            // 
            // paddy_DetailBindingSource
            // 
            this.paddy_DetailBindingSource.DataSource = typeof(Rice.Paddy_Detail);
            // 
            // paddy_DetailGridControl
            // 
            this.paddy_DetailGridControl.DataSource = this.paddy_DetailBindingSource;
            this.paddy_DetailGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paddy_DetailGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.paddy_DetailGridControl.Location = new System.Drawing.Point(0, 202);
            this.paddy_DetailGridControl.MainView = this.gridView1;
            this.paddy_DetailGridControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.paddy_DetailGridControl.Name = "paddy_DetailGridControl";
            this.paddy_DetailGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.typerepository,
            this.collecttyperepository,
            this.varietyrepository,
            this.statusrepository,
            this.repositoryItemHypertextLabel1,
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemButtonEdit1});
            this.paddy_DetailGridControl.Size = new System.Drawing.Size(1311, 664);
            this.paddy_DetailGridControl.TabIndex = 1;
            this.paddy_DetailGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.paddy_DetailGridControl.Click += new System.EventHandler(this.paddy_DetailGridControl_Click);
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
            this.colMoisture_Weight,
            this.colMoisture,
            this.colNet_kg,
            this.colBag_weight,
            this.colType,
            this.colBag_type,
            this.colNo_of_bags_Delivered,
            this.colTotalBagsWeighed,
            this.colUnweighedbags,
            this.colStatus});
            this.gridView1.DetailHeight = 538;
            this.gridView1.FixedLineWidth = 3;
            gridFormatRule1.Column = this.colStatus;
            gridFormatRule1.ColumnApplyTo = this.colStatus;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Red;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = ((short)(3));
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.paddy_DetailGridControl;
            this.gridView1.GroupFormat = "      {0}: [#image]{1} {2}";
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "No_of_bags_Delivered", null, "                Delivered: {0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalBagsWeighed", null, "                 Weighed: {0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Unweighedbags", null, "                 Bal:{0:0.##}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Net", null, "                 Net:{0:n2}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.ReadOnly = true;
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
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
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
            this.gridView1.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCollections_Date, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView1.SynchronizeClones = false;
            // 
            // colCollections_Date
            // 
            this.colCollections_Date.Caption = "Date";
            this.colCollections_Date.FieldName = "Collections_Date";
            this.colCollections_Date.MinWidth = 30;
            this.colCollections_Date.Name = "colCollections_Date";
            this.colCollections_Date.Showinlist = false;
            this.colCollections_Date.Visible = true;
            this.colCollections_Date.VisibleIndex = 0;
            this.colCollections_Date.Width = 79;
            // 
            // colCollection_Number
            // 
            this.colCollection_Number.Caption = "Reference";
            this.colCollection_Number.FieldName = "Collection_Number";
            this.colCollection_Number.MinWidth = 30;
            this.colCollection_Number.Name = "colCollection_Number";
            this.colCollection_Number.Showinlist = true;
            this.colCollection_Number.Visible = true;
            this.colCollection_Number.VisibleIndex = 6;
            this.colCollection_Number.Width = 114;
            // 
            // colFarmers_Number
            // 
            this.colFarmers_Number.Caption = "Farmer";
            this.colFarmers_Number.FieldName = "Farmers_Number";
            this.colFarmers_Number.MinWidth = 30;
            this.colFarmers_Number.Name = "colFarmers_Number";
            this.colFarmers_Number.Showinlist = true;
            this.colFarmers_Number.Visible = true;
            this.colFarmers_Number.VisibleIndex = 4;
            this.colFarmers_Number.Width = 79;
            // 
            // colFarmers_Name
            // 
            this.colFarmers_Name.Caption = "Name";
            this.colFarmers_Name.FieldName = "Farmers_Name";
            this.colFarmers_Name.MinWidth = 30;
            this.colFarmers_Name.Name = "colFarmers_Name";
            this.colFarmers_Name.Showinlist = true;
            this.colFarmers_Name.Visible = true;
            this.colFarmers_Name.VisibleIndex = 5;
            this.colFarmers_Name.Width = 152;
            // 
            // colGross_kg
            // 
            this.colGross_kg.DisplayFormat.FormatString = "n2";
            this.colGross_kg.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGross_kg.FieldName = "Gross";
            this.colGross_kg.MinWidth = 30;
            this.colGross_kg.Name = "colGross_kg";
            this.colGross_kg.Showinlist = false;
            this.colGross_kg.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Gross", "{0:n2}")});
            this.colGross_kg.Visible = true;
            this.colGross_kg.VisibleIndex = 10;
            this.colGross_kg.Width = 69;
            // 
            // colCrop
            // 
            this.colCrop.FieldName = "Crop";
            this.colCrop.MinWidth = 30;
            this.colCrop.Name = "colCrop";
            this.colCrop.Showinlist = false;
            this.colCrop.Width = 54;
            // 
            // colCollected_by
            // 
            this.colCollected_by.Caption = "User";
            this.colCollected_by.FieldName = "Collected_by";
            this.colCollected_by.MinWidth = 30;
            this.colCollected_by.Name = "colCollected_by";
            this.colCollected_by.Showinlist = false;
            this.colCollected_by.Visible = true;
            this.colCollected_by.VisibleIndex = 17;
            this.colCollected_by.Width = 84;
            // 
            // colCollect_type
            // 
            this.colCollect_type.Caption = "(Non)Member";
            this.colCollect_type.ColumnEdit = this.collecttyperepository;
            this.colCollect_type.FieldName = "Collect_type";
            this.colCollect_type.MinWidth = 30;
            this.colCollect_type.Name = "colCollect_type";
            this.colCollect_type.Showinlist = true;
            this.colCollect_type.Visible = true;
            this.colCollect_type.VisibleIndex = 3;
            this.colCollect_type.Width = 127;
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
            this.colCollections_Time.MinWidth = 30;
            this.colCollections_Time.Name = "colCollections_Time";
            this.colCollections_Time.Showinlist = false;
            this.colCollections_Time.Visible = true;
            this.colCollections_Time.VisibleIndex = 1;
            this.colCollections_Time.Width = 97;
            // 
            // colVariety
            // 
            this.colVariety.ColumnEdit = this.varietyrepository;
            this.colVariety.FieldName = "Variety";
            this.colVariety.MinWidth = 30;
            this.colVariety.Name = "colVariety";
            this.colVariety.Showinlist = false;
            this.colVariety.Visible = true;
            this.colVariety.VisibleIndex = 2;
            this.colVariety.Width = 97;
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
            this.colRecovery.MinWidth = 30;
            this.colRecovery.Name = "colRecovery";
            this.colRecovery.Showinlist = false;
            this.colRecovery.Visible = true;
            this.colRecovery.VisibleIndex = 9;
            this.colRecovery.Width = 93;
            // 
            // colMoisture_Weight
            // 
            this.colMoisture_Weight.Caption = "M. Weight";
            this.colMoisture_Weight.DisplayFormat.FormatString = "n2";
            this.colMoisture_Weight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMoisture_Weight.FieldName = "Moisture_Weight";
            this.colMoisture_Weight.MinWidth = 30;
            this.colMoisture_Weight.Name = "colMoisture_Weight";
            this.colMoisture_Weight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Moisture_Weight", "{0:n2}")});
            this.colMoisture_Weight.Visible = true;
            this.colMoisture_Weight.VisibleIndex = 11;
            this.colMoisture_Weight.Width = 143;
            // 
            // colMoisture
            // 
            this.colMoisture.FieldName = "Moisture";
            this.colMoisture.MinWidth = 30;
            this.colMoisture.Name = "colMoisture";
            this.colMoisture.Showinlist = false;
            this.colMoisture.Visible = true;
            this.colMoisture.VisibleIndex = 8;
            this.colMoisture.Width = 89;
            // 
            // colNet_kg
            // 
            this.colNet_kg.DisplayFormat.FormatString = "n2";
            this.colNet_kg.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNet_kg.FieldName = "Net";
            this.colNet_kg.MinWidth = 30;
            this.colNet_kg.Name = "colNet_kg";
            this.colNet_kg.Showinlist = false;
            this.colNet_kg.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Net", "{0:n2}")});
            this.colNet_kg.Visible = true;
            this.colNet_kg.VisibleIndex = 13;
            this.colNet_kg.Width = 53;
            // 
            // colBag_weight
            // 
            this.colBag_weight.Caption = "Bag W.";
            this.colBag_weight.DisplayFormat.FormatString = "n2";
            this.colBag_weight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBag_weight.FieldName = "Bags_Weight";
            this.colBag_weight.MinWidth = 30;
            this.colBag_weight.Name = "colBag_weight";
            this.colBag_weight.Showinlist = false;
            this.colBag_weight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bags_Weight", "{0:n2}")});
            this.colBag_weight.Visible = true;
            this.colBag_weight.VisibleIndex = 12;
            this.colBag_weight.Width = 79;
            // 
            // colType
            // 
            this.colType.ColumnEdit = this.typerepository;
            this.colType.FieldName = "Type";
            this.colType.MinWidth = 30;
            this.colType.Name = "colType";
            this.colType.Showinlist = false;
            this.colType.Width = 63;
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
            this.colBag_type.MinWidth = 30;
            this.colBag_type.Name = "colBag_type";
            this.colBag_type.Showinlist = false;
            this.colBag_type.Visible = true;
            this.colBag_type.VisibleIndex = 7;
            this.colBag_type.Width = 95;
            // 
            // colNo_of_bags_Delivered
            // 
            this.colNo_of_bags_Delivered.Caption = "Del.";
            this.colNo_of_bags_Delivered.FieldName = "No_of_bags_Delivered";
            this.colNo_of_bags_Delivered.MinWidth = 30;
            this.colNo_of_bags_Delivered.Name = "colNo_of_bags_Delivered";
            this.colNo_of_bags_Delivered.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "No_of_bags_Delivered", "{0:0.##}")});
            this.colNo_of_bags_Delivered.Visible = true;
            this.colNo_of_bags_Delivered.VisibleIndex = 14;
            this.colNo_of_bags_Delivered.Width = 57;
            // 
            // colTotalBagsWeighed
            // 
            this.colTotalBagsWeighed.Caption = "Weighed";
            this.colTotalBagsWeighed.FieldName = "TotalBagsWeighed";
            this.colTotalBagsWeighed.MinWidth = 30;
            this.colTotalBagsWeighed.Name = "colTotalBagsWeighed";
            this.colTotalBagsWeighed.OptionsColumn.ReadOnly = true;
            this.colTotalBagsWeighed.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalBagsWeighed", "{0:0.##}")});
            this.colTotalBagsWeighed.Visible = true;
            this.colTotalBagsWeighed.VisibleIndex = 15;
            this.colTotalBagsWeighed.Width = 90;
            // 
            // colUnweighedbags
            // 
            this.colUnweighedbags.Caption = "Bal";
            this.colUnweighedbags.FieldName = "Unweighedbags";
            this.colUnweighedbags.MinWidth = 30;
            this.colUnweighedbags.Name = "colUnweighedbags";
            this.colUnweighedbags.Showinlist = true;
            this.colUnweighedbags.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Unweighedbags", "{0:0.##}")});
            this.colUnweighedbags.Visible = true;
            this.colUnweighedbags.VisibleIndex = 16;
            this.colUnweighedbags.Width = 53;
            // 
            // repositoryItemHypertextLabel1
            // 
            this.repositoryItemHypertextLabel1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemHypertextLabel1.Name = "repositoryItemHypertextLabel1";
            this.repositoryItemHypertextLabel1.OpenHyperlink += new DevExpress.Utils.OpenHyperlinkEventHandler(this.repositoryItemHypertextLabel1_OpenHyperlink);
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.repositoryItemHyperLinkEdit1_OpenLink);
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.Click += new System.EventHandler(this.repositoryItemButtonEdit1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 866);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1311, 68);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(522, 17);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(146, 35);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "CANCEL";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(326, 17);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(146, 35);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "OK";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnpostprint,
            this.btnpost,
            this.btnprintdelivery,
            this.btnprintweigh,
            this.btndelivery,
            this.btnweigh,
            this.btnviewbags,
            this.barButtonItem1,
            this.printdelivery,
            this.printweighslip});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1311, 202);
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            this.ribbonControl1.Visible = false;
            this.ribbonControl1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ribbonControl1_ItemClick);
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbonControl1;
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
            // btnviewbags
            // 
            this.btnviewbags.Caption = "View Bags Weighed";
            this.btnviewbags.Id = 7;
            this.btnviewbags.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnviewbags.ImageOptions.Image")));
            this.btnviewbags.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnviewbags.ImageOptions.LargeImage")));
            this.btnviewbags.Name = "btnviewbags";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // printdelivery
            // 
            this.printdelivery.Caption = "Reprint Delivery Slip";
            this.printdelivery.Id = 9;
            this.printdelivery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("printdelivery.ImageOptions.Image")));
            this.printdelivery.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("printdelivery.ImageOptions.LargeImage")));
            this.printdelivery.Name = "printdelivery";
            // 
            // printweighslip
            // 
            this.printweighslip.Caption = "Reprint Weigh slip";
            this.printweighslip.Id = 10;
            this.printweighslip.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("printweighslip.ImageOptions.Image")));
            this.printweighslip.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("printweighslip.ImageOptions.LargeImage")));
            this.printweighslip.Name = "printweighslip";
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
            this.ribbonPageGroup2.ItemLinks.Add(this.btnweigh);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "New";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnviewbags);
            this.ribbonPageGroup1.ItemLinks.Add(this.printdelivery);
            this.ribbonPageGroup1.ItemLinks.Add(this.printweighslip);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Delivery";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterByThisValueToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(235, 34);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // filterByThisValueToolStripMenuItem
            // 
            this.filterByThisValueToolStripMenuItem.Image = global::Rice.Properties.Resources.stock_advanced_filter;
            this.filterByThisValueToolStripMenuItem.Name = "filterByThisValueToolStripMenuItem";
            this.filterByThisValueToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.filterByThisValueToolStripMenuItem.Text = "Filter by this value";
            // 
            // Paddy_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 934);
            this.Controls.Add(this.paddy_DetailGridControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Paddy_list";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paddy List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Paddy_list_FormClosing);
            this.Load += new System.EventHandler(this.Paddy_list_Load);
            this.Enter += new System.EventHandler(this.Paddy_list_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.statusrepository)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddy_DetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddy_DetailGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.collecttyperepository)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.varietyrepository)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typerepository)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHypertextLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox collecttyperepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox varietyrepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox typerepository;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox statusrepository;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Gridcolumn colUnweighedbags;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnpostprint;
        private DevExpress.XtraBars.BarButtonItem btnpost;
        private DevExpress.XtraBars.BarButtonItem btnprintdelivery;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnprintweigh;
        private DevExpress.XtraBars.BarButtonItem btndelivery;
        private DevExpress.XtraBars.BarButtonItem btnweigh;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem btnviewbags;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarButtonItem printdelivery;
        private DevExpress.XtraBars.BarButtonItem printweighslip;
        private DevExpress.XtraGrid.Columns.GridColumn colNo_of_bags_Delivered;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalBagsWeighed;
        private DevExpress.XtraGrid.Columns.GridColumn colMoisture_Weight;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filterByThisValueToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel repositoryItemHypertextLabel1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}