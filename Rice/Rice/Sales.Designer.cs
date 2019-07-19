namespace Rice
{
    partial class Sales
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
            System.Windows.Forms.Label payment_ModeLabel;
            System.Windows.Forms.Label referenceLabel;
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales));
            this.colReversed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.items_Services_ListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.items_Services_ListGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayment_Mode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.paymoderepo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colReceipt_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit_Cost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal_Cost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSales_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.salestyperipo = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterByThisValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePayModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payment_ModeImageComboBoxEdit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.referenceTextBox = new System.Windows.Forms.TextBox();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.reprintReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            payment_ModeLabel = new System.Windows.Forms.Label();
            referenceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.items_Services_ListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.items_Services_ListGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymoderepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestyperipo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.payment_ModeImageComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // payment_ModeLabel
            // 
            payment_ModeLabel.AutoSize = true;
            payment_ModeLabel.Location = new System.Drawing.Point(8, 48);
            payment_ModeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            payment_ModeLabel.Name = "payment_ModeLabel";
            payment_ModeLabel.Size = new System.Drawing.Size(119, 19);
            payment_ModeLabel.TabIndex = 2;
            payment_ModeLabel.Text = "Payment Mode:";
            // 
            // referenceLabel
            // 
            referenceLabel.AutoSize = true;
            referenceLabel.Location = new System.Drawing.Point(8, 83);
            referenceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            referenceLabel.Name = "referenceLabel";
            referenceLabel.Size = new System.Drawing.Size(84, 19);
            referenceLabel.TabIndex = 4;
            referenceLabel.Text = "Reference:";
            // 
            // colReversed
            // 
            this.colReversed.FieldName = "Reversed";
            this.colReversed.Name = "colReversed";
            this.colReversed.Visible = true;
            this.colReversed.VisibleIndex = 10;
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
            this.items_Services_ListGridControl.Location = new System.Drawing.Point(0, 0);
            this.items_Services_ListGridControl.MainView = this.gridView1;
            this.items_Services_ListGridControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.items_Services_ListGridControl.Name = "items_Services_ListGridControl";
            this.items_Services_ListGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.paymoderepo,
            this.salestyperipo});
            this.items_Services_ListGridControl.Size = new System.Drawing.Size(1173, 688);
            this.items_Services_ListGridControl.TabIndex = 0;
            this.items_Services_ListGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colTime,
            this.colPayment_Mode,
            this.colReceipt_No,
            this.colItem,
            this.colItem_Description,
            this.colQty,
            this.colUnit_Cost,
            this.colTotal_Cost,
            this.colSales_Type,
            this.colUser,
            this.colBalance,
            this.colReversed,
            this.colRecid,
            this.colSent});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colReversed;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue1.Appearance.Options.UseFont = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = true;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.items_Services_ListGridControl;
            this.gridView1.GroupCount = 2;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Cost", null, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", null, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowChildrenInGroupPanel = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDate, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUser, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // colDate
            // 
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            this.colDate.Width = 83;
            // 
            // colTime
            // 
            this.colTime.DisplayFormat.FormatString = "t";
            this.colTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTime.FieldName = "Time";
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 0;
            this.colTime.Width = 87;
            // 
            // colPayment_Mode
            // 
            this.colPayment_Mode.Caption = "Payment Mode";
            this.colPayment_Mode.ColumnEdit = this.paymoderepo;
            this.colPayment_Mode.FieldName = "Payment_Mode";
            this.colPayment_Mode.Name = "colPayment_Mode";
            this.colPayment_Mode.Visible = true;
            this.colPayment_Mode.VisibleIndex = 2;
            this.colPayment_Mode.Width = 94;
            // 
            // paymoderepo
            // 
            this.paymoderepo.AutoHeight = false;
            this.paymoderepo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.paymoderepo.Name = "paymoderepo";
            // 
            // colReceipt_No
            // 
            this.colReceipt_No.Caption = "Receipt No";
            this.colReceipt_No.FieldName = "Receipt_No";
            this.colReceipt_No.Name = "colReceipt_No";
            this.colReceipt_No.Visible = true;
            this.colReceipt_No.VisibleIndex = 1;
            this.colReceipt_No.Width = 83;
            // 
            // colItem
            // 
            this.colItem.FieldName = "Item";
            this.colItem.Name = "colItem";
            this.colItem.Visible = true;
            this.colItem.VisibleIndex = 4;
            // 
            // colItem_Description
            // 
            this.colItem_Description.Caption = "Item Description";
            this.colItem_Description.FieldName = "Item_Description";
            this.colItem_Description.Name = "colItem_Description";
            this.colItem_Description.OptionsColumn.ReadOnly = true;
            this.colItem_Description.Visible = true;
            this.colItem_Description.VisibleIndex = 5;
            this.colItem_Description.Width = 127;
            // 
            // colQty
            // 
            this.colQty.DisplayFormat.FormatString = "n1";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "Total={0:n1}")});
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 6;
            this.colQty.Width = 41;
            // 
            // colUnit_Cost
            // 
            this.colUnit_Cost.Caption = "Unit Price";
            this.colUnit_Cost.DisplayFormat.FormatString = "N2";
            this.colUnit_Cost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnit_Cost.FieldName = "Unit_Cost";
            this.colUnit_Cost.Name = "colUnit_Cost";
            this.colUnit_Cost.Visible = true;
            this.colUnit_Cost.VisibleIndex = 7;
            this.colUnit_Cost.Width = 71;
            // 
            // colTotal_Cost
            // 
            this.colTotal_Cost.Caption = "Total";
            this.colTotal_Cost.DisplayFormat.FormatString = "N2";
            this.colTotal_Cost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal_Cost.FieldName = "Total_Cost";
            this.colTotal_Cost.Name = "colTotal_Cost";
            this.colTotal_Cost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Cost", "Total={0:N2}")});
            this.colTotal_Cost.Visible = true;
            this.colTotal_Cost.VisibleIndex = 8;
            this.colTotal_Cost.Width = 87;
            // 
            // colSales_Type
            // 
            this.colSales_Type.Caption = "Sales Type";
            this.colSales_Type.ColumnEdit = this.salestyperipo;
            this.colSales_Type.FieldName = "Sales_Type";
            this.colSales_Type.Name = "colSales_Type";
            this.colSales_Type.Visible = true;
            this.colSales_Type.VisibleIndex = 3;
            this.colSales_Type.Width = 76;
            // 
            // salestyperipo
            // 
            this.salestyperipo.AutoHeight = false;
            this.salestyperipo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.salestyperipo.Name = "salestyperipo";
            // 
            // colUser
            // 
            this.colUser.FieldName = "User";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 3;
            this.colUser.Width = 78;
            // 
            // colBalance
            // 
            this.colBalance.FieldName = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.Visible = true;
            this.colBalance.VisibleIndex = 9;
            // 
            // colRecid
            // 
            this.colRecid.FieldName = "Recid";
            this.colRecid.Name = "colRecid";
            this.colRecid.Visible = true;
            this.colRecid.VisibleIndex = 11;
            // 
            // colSent
            // 
            this.colSent.FieldName = "Sent";
            this.colSent.Name = "colSent";
            this.colSent.Visible = true;
            this.colSent.VisibleIndex = 12;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterByThisValueToolStripMenuItem,
            this.reverseToolStripMenuItem,
            this.changePayModeToolStripMenuItem,
            this.reprintReceiptToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(237, 124);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // filterByThisValueToolStripMenuItem
            // 
            this.filterByThisValueToolStripMenuItem.Image = global::Rice.Properties.Resources.stock_advanced_filter;
            this.filterByThisValueToolStripMenuItem.Name = "filterByThisValueToolStripMenuItem";
            this.filterByThisValueToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.filterByThisValueToolStripMenuItem.Text = "Filter by this value";
            // 
            // reverseToolStripMenuItem
            // 
            this.reverseToolStripMenuItem.Image = global::Rice.Properties.Resources.back_2;
            this.reverseToolStripMenuItem.Name = "reverseToolStripMenuItem";
            this.reverseToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.reverseToolStripMenuItem.Text = "Reverse";
            // 
            // changePayModeToolStripMenuItem
            // 
            this.changePayModeToolStripMenuItem.Image = global::Rice.Properties.Resources.document_revert;
            this.changePayModeToolStripMenuItem.Name = "changePayModeToolStripMenuItem";
            this.changePayModeToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.changePayModeToolStripMenuItem.Text = "Change Pay Mode";
            this.changePayModeToolStripMenuItem.Click += new System.EventHandler(this.changePayModeToolStripMenuItem_Click);
            // 
            // payment_ModeImageComboBoxEdit
            // 
            this.payment_ModeImageComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.items_Services_ListBindingSource, "Payment_Mode", true));
            this.payment_ModeImageComboBoxEdit.Location = new System.Drawing.Point(138, 43);
            this.payment_ModeImageComboBoxEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.payment_ModeImageComboBoxEdit.Name = "payment_ModeImageComboBoxEdit";
            this.payment_ModeImageComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.payment_ModeImageComboBoxEdit.Size = new System.Drawing.Size(330, 28);
            this.payment_ModeImageComboBoxEdit.TabIndex = 3;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(referenceLabel);
            this.groupControl1.Controls.Add(this.referenceTextBox);
            this.groupControl1.Controls.Add(this.simpleButton2);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(payment_ModeLabel);
            this.groupControl1.Controls.Add(this.payment_ModeImageComboBoxEdit);
            this.groupControl1.Location = new System.Drawing.Point(342, 265);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(488, 175);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Payment Mode";
            this.groupControl1.Visible = false;
            // 
            // referenceTextBox
            // 
            this.referenceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.items_Services_ListBindingSource, "Reference", true));
            this.referenceTextBox.Location = new System.Drawing.Point(140, 78);
            this.referenceTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.referenceTextBox.Name = "referenceTextBox";
            this.referenceTextBox.Size = new System.Drawing.Size(326, 27);
            this.referenceTextBox.TabIndex = 5;
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(140, 120);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(130, 43);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "Cancel";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(338, 120);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(130, 43);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Change";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // reprintReceiptToolStripMenuItem
            // 
            this.reprintReceiptToolStripMenuItem.Image = global::Rice.Properties.Resources.Print;
            this.reprintReceiptToolStripMenuItem.Name = "reprintReceiptToolStripMenuItem";
            this.reprintReceiptToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.reprintReceiptToolStripMenuItem.Text = "Reprint Receipt";
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 688);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.items_Services_ListGridControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Sales";
            this.Text = "Sales";
            this.Load += new System.EventHandler(this.Sales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.items_Services_ListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.items_Services_ListGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymoderepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salestyperipo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.payment_ModeImageComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource items_Services_ListBindingSource;
        private DevExpress.XtraGrid.GridControl items_Services_ListGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colPayment_Mode;
        private DevExpress.XtraGrid.Columns.GridColumn colReceipt_No;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_Description;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit_Cost;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal_Cost;
        private DevExpress.XtraGrid.Columns.GridColumn colSales_Type;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox paymoderepo;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox salestyperipo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filterByThisValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reverseToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colReversed;
        private DevExpress.XtraEditors.ImageComboBoxEdit payment_ModeImageComboBoxEdit;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ToolStripMenuItem changePayModeToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.TextBox referenceTextBox;
        private DevExpress.XtraGrid.Columns.GridColumn colRecid;
        private DevExpress.XtraGrid.Columns.GridColumn colSent;
        private System.Windows.Forms.ToolStripMenuItem reprintReceiptToolStripMenuItem;
    }
}