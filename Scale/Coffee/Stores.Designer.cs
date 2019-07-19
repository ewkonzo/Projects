namespace Coffee
{
    partial class Stores
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
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label noLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stores));
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.variantsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descriptionTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.noTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.variantsGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colquantity_in = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QtyinLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colquantity_out = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QtyoutLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colquantity_Bal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Pricelink = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.stockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            descriptionLabel = new System.Windows.Forms.Label();
            noLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variantsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variantsGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtyinLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtyoutLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pricelink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(343, 47);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(63, 13);
            descriptionLabel.TabIndex = 2;
            descriptionLabel.Text = "Description:";
            // 
            // noLabel
            // 
            noLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            noLabel.AutoSize = true;
            noLabel.Location = new System.Drawing.Point(36, 49);
            noLabel.Name = "noLabel";
            noLabel.Size = new System.Drawing.Size(24, 13);
            noLabel.TabIndex = 6;
            noLabel.Text = "No:";
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataSource = typeof(Coffee.Item);
            this.itemsBindingSource.CurrentChanged += new System.EventHandler(this.itemsBindingSource_CurrentChanged);
            // 
            // variantsBindingSource
            // 
            this.variantsBindingSource.DataMember = "Variants";
            this.variantsBindingSource.DataSource = this.itemsBindingSource;
            // 
            // descriptionTextEdit
            // 
            this.descriptionTextEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.descriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemsBindingSource, "Description", true));
            this.descriptionTextEdit.Enabled = false;
            this.descriptionTextEdit.Location = new System.Drawing.Point(427, 44);
            this.descriptionTextEdit.Name = "descriptionTextEdit";
            this.descriptionTextEdit.Properties.ReadOnly = true;
            this.descriptionTextEdit.Size = new System.Drawing.Size(284, 20);
            this.descriptionTextEdit.TabIndex = 3;
            // 
            // noTextEdit
            // 
            this.noTextEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.noTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.itemsBindingSource, "No", true));
            this.noTextEdit.Enabled = false;
            this.noTextEdit.Location = new System.Drawing.Point(79, 46);
            this.noTextEdit.Name = "noTextEdit";
            this.noTextEdit.Properties.ReadOnly = true;
            this.noTextEdit.Size = new System.Drawing.Size(208, 20);
            this.noTextEdit.TabIndex = 7;
            // 
            // variantsGridControl
            // 
            this.variantsGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.variantsGridControl.DataSource = this.variantsBindingSource;
            this.variantsGridControl.Location = new System.Drawing.Point(49, 88);
            this.variantsGridControl.MainView = this.gridView1;
            this.variantsGridControl.Name = "variantsGridControl";
            this.variantsGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.QtyoutLinkEdit1,
            this.QtyinLinkEdit1,
            this.Pricelink});
            this.variantsGridControl.Size = new System.Drawing.Size(770, 208);
            this.variantsGridControl.TabIndex = 8;
            this.variantsGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colNo,
            this.colCode,
            this.colDescription,
            this.colquantity_in,
            this.colquantity_out,
            this.colquantity_Bal,
            this.colPrice});
            this.gridView1.GridControl = this.variantsGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colNo
            // 
            this.colNo.FieldName = "No";
            this.colNo.Name = "colNo";
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.ReadOnly = true;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            // 
            // colquantity_in
            // 
            this.colquantity_in.AppearanceCell.Options.UseTextOptions = true;
            this.colquantity_in.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colquantity_in.Caption = "Qty In";
            this.colquantity_in.ColumnEdit = this.QtyinLinkEdit1;
            this.colquantity_in.DisplayFormat.FormatString = "N1";
            this.colquantity_in.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colquantity_in.FieldName = "quantity_in";
            this.colquantity_in.Name = "colquantity_in";
            this.colquantity_in.Visible = true;
            this.colquantity_in.VisibleIndex = 2;
            // 
            // QtyinLinkEdit1
            // 
            this.QtyinLinkEdit1.AutoHeight = false;
            this.QtyinLinkEdit1.Name = "QtyinLinkEdit1";
            this.QtyinLinkEdit1.Click += new System.EventHandler(this.QtyinLinkEdit1_Click);
            // 
            // colquantity_out
            // 
            this.colquantity_out.AppearanceCell.Options.UseTextOptions = true;
            this.colquantity_out.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colquantity_out.Caption = "Qty out";
            this.colquantity_out.ColumnEdit = this.QtyoutLinkEdit1;
            this.colquantity_out.DisplayFormat.FormatString = "N1";
            this.colquantity_out.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colquantity_out.FieldName = "quantity_out";
            this.colquantity_out.Name = "colquantity_out";
            this.colquantity_out.Visible = true;
            this.colquantity_out.VisibleIndex = 3;
            // 
            // QtyoutLinkEdit1
            // 
            this.QtyoutLinkEdit1.AutoHeight = false;
            this.QtyoutLinkEdit1.Name = "QtyoutLinkEdit1";
            this.QtyoutLinkEdit1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.QtyoutLinkEdit1_OpenLink);
            this.QtyoutLinkEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.QtyoutLinkEdit1_ButtonClick);
            this.QtyoutLinkEdit1.Click += new System.EventHandler(this.QtyoutLinkEdit1_Click);
            // 
            // colquantity_Bal
            // 
            this.colquantity_Bal.AppearanceCell.Options.UseTextOptions = true;
            this.colquantity_Bal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colquantity_Bal.Caption = "Qty Bal";
            this.colquantity_Bal.DisplayFormat.FormatString = "N1";
            this.colquantity_Bal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colquantity_Bal.FieldName = "quantity_Bal";
            this.colquantity_Bal.Name = "colquantity_Bal";
            this.colquantity_Bal.Visible = true;
            this.colquantity_Bal.VisibleIndex = 4;
            // 
            // colPrice
            // 
            this.colPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPrice.ColumnEdit = this.Pricelink;
            this.colPrice.DisplayFormat.FormatString = "N2";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 5;
            // 
            // Pricelink
            // 
            this.Pricelink.AutoHeight = false;
            this.Pricelink.Name = "Pricelink";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.itemsBindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 342);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(873, 25);
            this.bindingNavigator1.TabIndex = 9;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // stockBindingSource
            // 
            this.stockBindingSource.DataSource = typeof(Coffee.Stock);
            // 
            // Stores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 367);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.variantsGridControl);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(this.descriptionTextEdit);
            this.Controls.Add(noLabel);
            this.Controls.Add(this.noTextEdit);
            this.Name = "Stores";
            this.Text = "Stores";
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variantsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variantsGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtyinLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtyoutLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pricelink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource itemsBindingSource;
        private System.Windows.Forms.BindingSource variantsBindingSource;
        private DevExpress.XtraEditors.TextEdit descriptionTextEdit;
        private DevExpress.XtraEditors.TextEdit noTextEdit;
        private DevExpress.XtraGrid.GridControl variantsGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingSource stockBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colquantity_in;
        private DevExpress.XtraGrid.Columns.GridColumn colquantity_out;
        private DevExpress.XtraGrid.Columns.GridColumn colquantity_Bal;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit QtyinLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit QtyoutLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit Pricelink;
    }
}