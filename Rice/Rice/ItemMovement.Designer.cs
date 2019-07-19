namespace Rice
{
    partial class ItemMovement
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
            this.colReversed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.item_Movement_HeaderGridControl = new DevExpress.XtraGrid.GridControl();
            this.itemMovementBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMovement_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colItem_Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgrn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.filterByThisValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colRecid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSent = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.item_Movement_HeaderGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMovementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colReversed
            // 
            this.colReversed.FieldName = "Reversed";
            this.colReversed.Name = "colReversed";
            this.colReversed.Visible = true;
            this.colReversed.VisibleIndex = 7;
            this.colReversed.Width = 95;
            // 
            // item_Movement_HeaderGridControl
            // 
            this.item_Movement_HeaderGridControl.DataSource = this.itemMovementBindingSource;
            this.item_Movement_HeaderGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.item_Movement_HeaderGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.item_Movement_HeaderGridControl.Location = new System.Drawing.Point(0, 0);
            this.item_Movement_HeaderGridControl.MainView = this.gridView1;
            this.item_Movement_HeaderGridControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.item_Movement_HeaderGridControl.Name = "item_Movement_HeaderGridControl";
            this.item_Movement_HeaderGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.item_Movement_HeaderGridControl.Size = new System.Drawing.Size(986, 680);
            this.item_Movement_HeaderGridControl.TabIndex = 0;
            this.item_Movement_HeaderGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // itemMovementBindingSource
            // 
            this.itemMovementBindingSource.DataSource = typeof(Rice.Item_Movement);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colTime,
            this.colMovement_Type,
            this.colItem_Description,
            this.colItem,
            this.colQty,
            this.colUser,
            this.colgrn,
            this.colinvoice,
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
            this.gridView1.GridControl = this.item_Movement_HeaderGridControl;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridMergedColumnSortInfo(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colDate,
                        this.colMovement_Type}, new DevExpress.Data.ColumnSortOrder[] {
                        DevExpress.Data.ColumnSortOrder.Descending,
                        DevExpress.Data.ColumnSortOrder.Ascending}),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTime, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // colDate
            // 
            this.colDate.DisplayFormat.FormatString = "d";
            this.colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            // 
            // colTime
            // 
            this.colTime.DisplayFormat.FormatString = "t";
            this.colTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTime.FieldName = "Time";
            this.colTime.Name = "colTime";
            this.colTime.Visible = true;
            this.colTime.VisibleIndex = 0;
            this.colTime.Width = 105;
            // 
            // colMovement_Type
            // 
            this.colMovement_Type.Caption = "Entry type";
            this.colMovement_Type.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colMovement_Type.FieldName = "Movement_Type";
            this.colMovement_Type.Name = "colMovement_Type";
            this.colMovement_Type.Visible = true;
            this.colMovement_Type.VisibleIndex = 1;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colItem_Description
            // 
            this.colItem_Description.Caption = "Item Description";
            this.colItem_Description.FieldName = "Item_Description";
            this.colItem_Description.Name = "colItem_Description";
            this.colItem_Description.Visible = true;
            this.colItem_Description.VisibleIndex = 2;
            this.colItem_Description.Width = 95;
            // 
            // colItem
            // 
            this.colItem.FieldName = "Item";
            this.colItem.Name = "colItem";
            this.colItem.Visible = true;
            this.colItem.VisibleIndex = 1;
            this.colItem.Width = 95;
            // 
            // colQty
            // 
            this.colQty.DisplayFormat.FormatString = "n2";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Qty", "Total={0:n2}")});
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 3;
            this.colQty.Width = 95;
            // 
            // colUser
            // 
            this.colUser.FieldName = "User";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 4;
            this.colUser.Width = 95;
            // 
            // colgrn
            // 
            this.colgrn.Caption = "Grn";
            this.colgrn.FieldName = "grn";
            this.colgrn.Name = "colgrn";
            this.colgrn.Visible = true;
            this.colgrn.VisibleIndex = 5;
            this.colgrn.Width = 95;
            // 
            // colinvoice
            // 
            this.colinvoice.Caption = "Invoice";
            this.colinvoice.FieldName = "invoice";
            this.colinvoice.Name = "colinvoice";
            this.colinvoice.Visible = true;
            this.colinvoice.VisibleIndex = 6;
            this.colinvoice.Width = 95;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterByThisValueToolStripMenuItem,
            this.reverseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(235, 64);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // filterByThisValueToolStripMenuItem
            // 
            this.filterByThisValueToolStripMenuItem.Image = global::Rice.Properties.Resources.stock_advanced_filter;
            this.filterByThisValueToolStripMenuItem.Name = "filterByThisValueToolStripMenuItem";
            this.filterByThisValueToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.filterByThisValueToolStripMenuItem.Text = "Filter by this value";
            // 
            // reverseToolStripMenuItem
            // 
            this.reverseToolStripMenuItem.Image = global::Rice.Properties.Resources.back_2;
            this.reverseToolStripMenuItem.Name = "reverseToolStripMenuItem";
            this.reverseToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.reverseToolStripMenuItem.Text = "Reverse";
            // 
            // colRecid
            // 
            this.colRecid.FieldName = "Recid";
            this.colRecid.Name = "colRecid";
            this.colRecid.Visible = true;
            this.colRecid.VisibleIndex = 8;
            this.colRecid.Width = 109;
            // 
            // colSent
            // 
            this.colSent.FieldName = "Sent";
            this.colSent.Name = "colSent";
            this.colSent.Visible = true;
            this.colSent.VisibleIndex = 9;
            this.colSent.Width = 84;
            // 
            // ItemMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 680);
            this.Controls.Add(this.item_Movement_HeaderGridControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ItemMovement";
            this.Text = "Stock In & Out";
            ((System.ComponentModel.ISupportInitialize)(this.item_Movement_HeaderGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemMovementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl item_Movement_HeaderGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource itemMovementBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colMovement_Type;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_Description;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraGrid.Columns.GridColumn colgrn;
        private DevExpress.XtraGrid.Columns.GridColumn colinvoice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filterByThisValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reverseToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colReversed;
        private DevExpress.XtraGrid.Columns.GridColumn colRecid;
        private DevExpress.XtraGrid.Columns.GridColumn colSent;
    }
}