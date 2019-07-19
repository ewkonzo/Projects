namespace Rice
{
    partial class Itemlist
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Itemlist));
            this.colReversed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReversed_by_Entry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.items_Services_ListBindingSource = new System.Windows.Forms.BindingSource();
            this.items_Services_ListGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceipt_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFarmer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFarmer_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit_Cost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal_Cost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.itemsServicesBindingSource = new System.Windows.Forms.BindingSource();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnpostprint = new DevExpress.XtraBars.BarButtonItem();
            this.btnpost = new DevExpress.XtraBars.BarButtonItem();
            this.btnprint = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.filterByThisValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reprintSupplyNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colRecid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSent = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.items_Services_ListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.items_Services_ListGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsServicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colReversed
            // 
            this.colReversed.FieldName = "Reversed";
            this.colReversed.MinWidth = 30;
            this.colReversed.Name = "colReversed";
            this.colReversed.Visible = true;
            this.colReversed.VisibleIndex = 9;
            this.colReversed.Width = 72;
            // 
            // colReversed_by_Entry
            // 
            this.colReversed_by_Entry.Caption = "Rev. by Entry";
            this.colReversed_by_Entry.FieldName = "Reversed_by_Entry";
            this.colReversed_by_Entry.MinWidth = 30;
            this.colReversed_by_Entry.Name = "colReversed_by_Entry";
            this.colReversed_by_Entry.Visible = true;
            this.colReversed_by_Entry.VisibleIndex = 10;
            this.colReversed_by_Entry.Width = 72;
            // 
            // items_Services_ListBindingSource
            // 
            this.items_Services_ListBindingSource.DataSource = typeof(Rice.Items_Services_List);
            // 
            // items_Services_ListGridControl
            // 
            this.items_Services_ListGridControl.DataSource = this.items_Services_ListBindingSource;
            this.items_Services_ListGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.items_Services_ListGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.items_Services_ListGridControl.Location = new System.Drawing.Point(0, 200);
            this.items_Services_ListGridControl.MainView = this.gridView1;
            this.items_Services_ListGridControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.items_Services_ListGridControl.Name = "items_Services_ListGridControl";
            this.items_Services_ListGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1});
            this.items_Services_ListGridControl.Size = new System.Drawing.Size(1276, 423);
            this.items_Services_ListGridControl.TabIndex = 1;
            this.items_Services_ListGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colTime,
            this.colReceipt_No,
            this.colReference,
            this.colFarmer,
            this.colFarmer_Name,
            this.colSent,
            this.colItem_Description,
            this.colRecid,
            this.colQty,
            this.colUnit_Cost,
            this.colTotal_Cost,
            this.colPosted,
            this.colUser,
            this.colReversed,
            this.colReversed_by_Entry});
            this.gridView1.DetailHeight = 538;
            this.gridView1.FixedLineWidth = 3;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colReversed;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = true;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colReversed_by_Entry;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            formatConditionRuleValue2.Appearance.Options.UseFont = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual;
            formatConditionRuleValue2.Value1 = "";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.GridControl = this.items_Services_ListGridControl;
            this.gridView1.GroupCount = 2;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUser, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // colDate
            // 
            this.colDate.DisplayFormat.FormatString = "d";
            this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDate.FieldName = "Date";
            this.colDate.MinWidth = 30;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            this.colDate.Width = 78;
            // 
            // colTime
            // 
            this.colTime.DisplayFormat.FormatString = "t";
            this.colTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTime.FieldName = "Time";
            this.colTime.MinWidth = 30;
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 0;
            this.colTime.Width = 84;
            // 
            // colReceipt_No
            // 
            this.colReceipt_No.FieldName = "Receipt_No";
            this.colReceipt_No.MinWidth = 30;
            this.colReceipt_No.Name = "colReceipt_No";
            this.colReceipt_No.Visible = true;
            this.colReceipt_No.VisibleIndex = 1;
            this.colReceipt_No.Width = 100;
            // 
            // colReference
            // 
            this.colReference.FieldName = "Reference";
            this.colReference.MinWidth = 30;
            this.colReference.Name = "colReference";
            this.colReference.Visible = true;
            this.colReference.VisibleIndex = 11;
            this.colReference.Width = 93;
            // 
            // colFarmer
            // 
            this.colFarmer.FieldName = "Farmer";
            this.colFarmer.MinWidth = 30;
            this.colFarmer.Name = "colFarmer";
            this.colFarmer.Visible = true;
            this.colFarmer.VisibleIndex = 2;
            this.colFarmer.Width = 74;
            // 
            // colFarmer_Name
            // 
            this.colFarmer_Name.Caption = "Name";
            this.colFarmer_Name.FieldName = "Farmer_Name";
            this.colFarmer_Name.MinWidth = 30;
            this.colFarmer_Name.Name = "colFarmer_Name";
            this.colFarmer_Name.Visible = true;
            this.colFarmer_Name.VisibleIndex = 3;
            this.colFarmer_Name.Width = 102;
            // 
            // colItem_Description
            // 
            this.colItem_Description.FieldName = "Item_Description";
            this.colItem_Description.MinWidth = 30;
            this.colItem_Description.Name = "colItem_Description";
            this.colItem_Description.Visible = true;
            this.colItem_Description.VisibleIndex = 4;
            this.colItem_Description.Width = 226;
            // 
            // colQty
            // 
            this.colQty.DisplayFormat.FormatString = "N1";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "Qty";
            this.colQty.MinWidth = 30;
            this.colQty.Name = "colQty";
            this.colQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "SUM={0:N1}")});
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 5;
            this.colQty.Width = 49;
            // 
            // colUnit_Cost
            // 
            this.colUnit_Cost.Caption = "Unit cost";
            this.colUnit_Cost.DisplayFormat.FormatString = "N2";
            this.colUnit_Cost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnit_Cost.FieldName = "Unit_Cost";
            this.colUnit_Cost.MinWidth = 30;
            this.colUnit_Cost.Name = "colUnit_Cost";
            this.colUnit_Cost.Visible = true;
            this.colUnit_Cost.VisibleIndex = 6;
            // 
            // colTotal_Cost
            // 
            this.colTotal_Cost.Caption = "Total Cost";
            this.colTotal_Cost.DisplayFormat.FormatString = "N2";
            this.colTotal_Cost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal_Cost.FieldName = "Total_Cost";
            this.colTotal_Cost.MinWidth = 30;
            this.colTotal_Cost.Name = "colTotal_Cost";
            this.colTotal_Cost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Cost", "SUM={0:N2}")});
            this.colTotal_Cost.Visible = true;
            this.colTotal_Cost.VisibleIndex = 7;
            this.colTotal_Cost.Width = 79;
            // 
            // colPosted
            // 
            this.colPosted.FieldName = "Posted";
            this.colPosted.MinWidth = 30;
            this.colPosted.Name = "colPosted";
            this.colPosted.Visible = true;
            this.colPosted.VisibleIndex = 8;
            this.colPosted.Width = 57;
            // 
            // colUser
            // 
            this.colUser.FieldName = "User";
            this.colUser.MinWidth = 30;
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 9;
            this.colUser.Width = 55;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.DataSource = this.itemsServicesBindingSource;
            this.repositoryItemGridLookUpEdit1.DisplayMember = "Name";
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repositoryItemGridLookUpEdit1.ValueMember = "Code";
            // 
            // itemsServicesBindingSource
            // 
            this.itemsServicesBindingSource.DataSource = typeof(Rice.Items_Services);
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnpostprint,
            this.btnpost,
            this.btnprint});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1276, 200);
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
            this.btnpost.Caption = "Post";
            this.btnpost.Id = 2;
            this.btnpost.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnpost.ImageOptions.Image")));
            this.btnpost.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnpost.ImageOptions.LargeImage")));
            this.btnpost.Name = "btnpost";
            // 
            // btnprint
            // 
            this.btnprint.Caption = "Reprint Supply Note";
            this.btnprint.Id = 3;
            this.btnprint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.ImageOptions.Image")));
            this.btnprint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnprint.ImageOptions.LargeImage")));
            this.btnprint.Name = "btnprint";
            this.btnprint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnprint_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnprint);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Items";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterByThisValueToolStripMenuItem,
            this.reverseToolStripMenuItem,
            this.reprintSupplyNoteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(253, 94);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // filterByThisValueToolStripMenuItem
            // 
            this.filterByThisValueToolStripMenuItem.Image = global::Rice.Properties.Resources.stock_advanced_filter;
            this.filterByThisValueToolStripMenuItem.Name = "filterByThisValueToolStripMenuItem";
            this.filterByThisValueToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.filterByThisValueToolStripMenuItem.Text = "Filter by this value";
            // 
            // reverseToolStripMenuItem
            // 
            this.reverseToolStripMenuItem.Image = global::Rice.Properties.Resources.back_2;
            this.reverseToolStripMenuItem.Name = "reverseToolStripMenuItem";
            this.reverseToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.reverseToolStripMenuItem.Text = "Reverse";
            // 
            // reprintSupplyNoteToolStripMenuItem
            // 
            this.reprintSupplyNoteToolStripMenuItem.Image = global::Rice.Properties.Resources.Print;
            this.reprintSupplyNoteToolStripMenuItem.Name = "reprintSupplyNoteToolStripMenuItem";
            this.reprintSupplyNoteToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.reprintSupplyNoteToolStripMenuItem.Text = "Reprint Supply Note";
            // 
            // colRecid
            // 
            this.colRecid.FieldName = "Recid";
            this.colRecid.Name = "colRecid";
            this.colRecid.Visible = true;
            this.colRecid.VisibleIndex = 12;
            this.colRecid.Width = 85;
            // 
            // colSent
            // 
            this.colSent.FieldName = "Sent";
            this.colSent.Name = "colSent";
            this.colSent.Visible = true;
            this.colSent.VisibleIndex = 13;
            this.colSent.Width = 86;
            // 
            // Itemlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 623);
            this.Controls.Add(this.items_Services_ListGridControl);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Itemlist";
            this.Text = "Itemlist";
            ((System.ComponentModel.ISupportInitialize)(this.items_Services_ListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.items_Services_ListGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsServicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource items_Services_ListBindingSource;
        private DevExpress.XtraGrid.GridControl items_Services_ListGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colReceipt_No;
        private DevExpress.XtraGrid.Columns.GridColumn colFarmer;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit_Cost;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal_Cost;
        private DevExpress.XtraGrid.Columns.GridColumn colPosted;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private System.Windows.Forms.BindingSource itemsServicesBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colFarmer_Name;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnpostprint;
        private DevExpress.XtraBars.BarButtonItem btnpost;
        private DevExpress.XtraBars.BarButtonItem btnprint;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_Description;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filterByThisValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reverseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reprintSupplyNoteToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colReversed;
        private DevExpress.XtraGrid.Columns.GridColumn colReversed_by_Entry;
        private DevExpress.XtraGrid.Columns.GridColumn colReference;
        private DevExpress.XtraGrid.Columns.GridColumn colSent;
        private DevExpress.XtraGrid.Columns.GridColumn colRecid;
    }
}