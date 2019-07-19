namespace Rice
{
    partial class Stocktake
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
            System.Windows.Forms.Label created_ByLabel;
            System.Windows.Forms.Label dateLabel;
            System.Windows.Forms.Label locationLabel;
            System.Windows.Forms.Label referenceLabel;
            System.Windows.Forms.Label timeLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stocktake));
            this.item_MovementBindingSource = new System.Windows.Forms.BindingSource();
            this.item_MovementGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoitems = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.itemsServicesBindingSource = new System.Windows.Forms.BindingSource();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVariant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repovariants = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.variantBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.item_Movement_HeaderBindingSource = new System.Windows.Forms.BindingSource();
            this.created_ByLabel1 = new System.Windows.Forms.Label();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.locationLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.outletBindingSource = new System.Windows.Forms.BindingSource();
            this.timeLabel2 = new System.Windows.Forms.Label();
            this.referenceLabel2 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnpostprint = new DevExpress.XtraBars.BarButtonItem();
            this.btnpost = new DevExpress.XtraBars.BarButtonItem();
            this.btnprint = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.vendorBindingSource = new System.Windows.Forms.BindingSource();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            created_ByLabel = new System.Windows.Forms.Label();
            dateLabel = new System.Windows.Forms.Label();
            locationLabel = new System.Windows.Forms.Label();
            referenceLabel = new System.Windows.Forms.Label();
            timeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.item_MovementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_MovementGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoitems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsServicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repovariants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.variantBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_Movement_HeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outletBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // created_ByLabel
            // 
            created_ByLabel.AutoSize = true;
            created_ByLabel.Location = new System.Drawing.Point(-1, 27);
            created_ByLabel.Name = "created_ByLabel";
            created_ByLabel.Size = new System.Drawing.Size(65, 13);
            created_ByLabel.TabIndex = 1;
            created_ByLabel.Text = "Created By:";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new System.Drawing.Point(18, 38);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new System.Drawing.Size(34, 13);
            dateLabel.TabIndex = 3;
            dateLabel.Text = "Date:";
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Location = new System.Drawing.Point(18, 63);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new System.Drawing.Size(41, 13);
            locationLabel.TabIndex = 9;
            locationLabel.Text = "Outlet:";
            // 
            // referenceLabel
            // 
            referenceLabel.AutoSize = true;
            referenceLabel.Location = new System.Drawing.Point(14, 7);
            referenceLabel.Name = "referenceLabel";
            referenceLabel.Size = new System.Drawing.Size(61, 13);
            referenceLabel.TabIndex = 15;
            referenceLabel.Text = "Reference:";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new System.Drawing.Point(-1, 3);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new System.Drawing.Size(33, 13);
            timeLabel.TabIndex = 17;
            timeLabel.Text = "Time:";
            // 
            // item_MovementBindingSource
            // 
            this.item_MovementBindingSource.DataSource = typeof(Rice.Item_Movement);
            this.item_MovementBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.item_MovementBindingSource_AddingNew);
            // 
            // item_MovementGridControl
            // 
            this.item_MovementGridControl.DataSource = this.item_MovementBindingSource;
            this.item_MovementGridControl.Location = new System.Drawing.Point(21, 93);
            this.item_MovementGridControl.MainView = this.gridView1;
            this.item_MovementGridControl.Name = "item_MovementGridControl";
            this.item_MovementGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoitems,
            this.repovariants});
            this.item_MovementGridControl.Size = new System.Drawing.Size(594, 180);
            this.item_MovementGridControl.TabIndex = 1;
            this.item_MovementGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItem,
            this.colVariant,
            this.colQty});
            this.gridView1.GridControl = this.item_MovementGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ShownEditor += new System.EventHandler(this.gridView1_ShownEditor);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // colItem
            // 
            this.colItem.ColumnEdit = this.repoitems;
            this.colItem.FieldName = "Item";
            this.colItem.Name = "colItem";
            this.colItem.Visible = true;
            this.colItem.VisibleIndex = 0;
            // 
            // repoitems
            // 
            this.repoitems.AutoHeight = false;
            this.repoitems.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoitems.DataSource = this.itemsServicesBindingSource;
            this.repoitems.DisplayMember = "Name";
            this.repoitems.Name = "repoitems";
            this.repoitems.NullText = "<Select stock Item>";
            this.repoitems.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.repoitems.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repoitems.ValueMember = "Code";
            // 
            // itemsServicesBindingSource
            // 
            this.itemsServicesBindingSource.DataSource = typeof(Rice.Items_Services);
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemGridLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colCode
            // 
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 104;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 565;
            // 
            // colVariant
            // 
            this.colVariant.ColumnEdit = this.repovariants;
            this.colVariant.FieldName = "Variant";
            this.colVariant.Name = "colVariant";
            this.colVariant.Visible = true;
            this.colVariant.VisibleIndex = 1;
            // 
            // repovariants
            // 
            this.repovariants.AutoHeight = false;
            this.repovariants.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repovariants.DataSource = this.variantBindingSource;
            this.repovariants.DisplayMember = "Code";
            this.repovariants.Name = "repovariants";
            this.repovariants.NullText = "<select variant>";
            this.repovariants.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.repovariants.PopupView = this.gridView2;
            this.repovariants.ValueMember = "Code";
            // 
            // variantBindingSource
            // 
            this.variantBindingSource.DataSource = typeof(Rice.Variant);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode1});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colCode1
            // 
            this.colCode1.FieldName = "Code";
            this.colCode1.Name = "colCode1";
            this.colCode1.Visible = true;
            this.colCode1.VisibleIndex = 0;
            // 
            // colQty
            // 
            this.colQty.DisplayFormat.FormatString = "N2";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 2;
            // 
            // item_Movement_HeaderBindingSource
            // 
            this.item_Movement_HeaderBindingSource.AllowNew = true;
            this.item_Movement_HeaderBindingSource.DataSource = typeof(Rice.Item_Movement_Header);
            this.item_Movement_HeaderBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.item_Movement_HeaderBindingSource_AddingNew);
            this.item_Movement_HeaderBindingSource.CurrentChanged += new System.EventHandler(this.item_Movement_HeaderBindingSource_CurrentChanged);
            // 
            // created_ByLabel1
            // 
            this.created_ByLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.created_ByLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.item_Movement_HeaderBindingSource, "Created_By", true));
            this.created_ByLabel1.Location = new System.Drawing.Point(70, 27);
            this.created_ByLabel1.Name = "created_ByLabel1";
            this.created_ByLabel1.Size = new System.Drawing.Size(214, 21);
            this.created_ByLabel1.TabIndex = 2;
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.item_Movement_HeaderBindingSource, "Date", true));
            this.dateDateTimePicker.Location = new System.Drawing.Point(88, 33);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.Size = new System.Drawing.Size(220, 21);
            this.dateDateTimePicker.TabIndex = 1;
            // 
            // locationLookUpEdit
            // 
            this.locationLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.item_Movement_HeaderBindingSource, "Location", true));
            this.locationLookUpEdit.Location = new System.Drawing.Point(88, 62);
            this.locationLookUpEdit.Name = "locationLookUpEdit";
            this.locationLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.locationLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.locationLookUpEdit.Properties.DataSource = this.outletBindingSource;
            this.locationLookUpEdit.Properties.DisplayMember = "Name";
            this.locationLookUpEdit.Properties.DropDownRows = 10;
            this.locationLookUpEdit.Properties.NullText = "<Select outlet>";
            this.locationLookUpEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.locationLookUpEdit.Properties.ReadOnly = true;
            this.locationLookUpEdit.Properties.ValueMember = "Code";
            this.locationLookUpEdit.Size = new System.Drawing.Size(220, 20);
            this.locationLookUpEdit.TabIndex = 2;
            this.locationLookUpEdit.EditValueChanged += new System.EventHandler(this.locationLookUpEdit_EditValueChanged);
            // 
            // outletBindingSource
            // 
            this.outletBindingSource.DataSource = typeof(Rice.Outlet);
            // 
            // timeLabel2
            // 
            this.timeLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.timeLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.item_Movement_HeaderBindingSource, "Time", true));
            this.timeLabel2.Location = new System.Drawing.Point(70, 3);
            this.timeLabel2.Name = "timeLabel2";
            this.timeLabel2.Size = new System.Drawing.Size(214, 21);
            this.timeLabel2.TabIndex = 18;
            // 
            // referenceLabel2
            // 
            this.referenceLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.referenceLabel2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.item_Movement_HeaderBindingSource, "Reference", true));
            this.referenceLabel2.Location = new System.Drawing.Point(89, 3);
            this.referenceLabel2.Name = "referenceLabel2";
            this.referenceLabel2.Size = new System.Drawing.Size(219, 21);
            this.referenceLabel2.TabIndex = 19;
            this.referenceLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.flowLayoutPanel1);
            this.panelControl1.Controls.Add(this.referenceLabel2);
            this.panelControl1.Controls.Add(dateLabel);
            this.panelControl1.Controls.Add(this.dateDateTimePicker);
            this.panelControl1.Controls.Add(locationLabel);
            this.panelControl1.Controls.Add(this.locationLookUpEdit);
            this.panelControl1.Controls.Add(referenceLabel);
            this.panelControl1.Controls.Add(this.item_MovementGridControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 139);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(656, 280);
            this.panelControl1.TabIndex = 20;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panelControl3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(327, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(288, 79);
            this.flowLayoutPanel1.TabIndex = 27;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.timeLabel2);
            this.panelControl3.Controls.Add(created_ByLabel);
            this.panelControl3.Controls.Add(this.created_ByLabel1);
            this.panelControl3.Controls.Add(timeLabel);
            this.panelControl3.Location = new System.Drawing.Point(3, 3);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(285, 57);
            this.panelControl3.TabIndex = 24;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnpostprint,
            this.btnpost,
            this.btnprint,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(656, 139);
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
            this.btnpost.Caption = "Post && Print";
            this.btnpost.Id = 2;
            this.btnpost.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnpost.ImageOptions.Image")));
            this.btnpost.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnpost.ImageOptions.LargeImage")));
            this.btnpost.Name = "btnpost";
            this.btnpost.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnpost_ItemClick);
            // 
            // btnprint
            // 
            this.btnprint.Caption = "Print Grn";
            this.btnprint.Id = 3;
            this.btnprint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.ImageOptions.Image")));
            this.btnprint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnprint.ImageOptions.LargeImage")));
            this.btnprint.Name = "btnprint";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 4;
            this.barButtonItem1.Name = "barButtonItem1";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnpost);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Items Received";
            // 
            // vendorBindingSource
            // 
            this.vendorBindingSource.DataSource = typeof(Rice.Vendor);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // Stocktake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 419);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Stocktake";
            this.Text = "Stock Take";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Receivestock_FormClosing);
            this.Load += new System.EventHandler(this.Receivestock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.item_MovementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_MovementGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoitems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsServicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repovariants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.variantBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_Movement_HeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outletBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource item_MovementBindingSource;
        private DevExpress.XtraGrid.GridControl item_MovementGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraGrid.Columns.GridColumn colVariant;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private System.Windows.Forms.BindingSource item_Movement_HeaderBindingSource;
        private System.Windows.Forms.Label created_ByLabel1;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private DevExpress.XtraEditors.LookUpEdit locationLookUpEdit;
        private System.Windows.Forms.Label timeLabel2;
        private System.Windows.Forms.Label referenceLabel2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repoitems;
        private System.Windows.Forms.BindingSource itemsServicesBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repovariants;
        private System.Windows.Forms.BindingSource variantBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.BindingSource outletBindingSource;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnpostprint;
        private DevExpress.XtraBars.BarButtonItem btnpost;
        private DevExpress.XtraBars.BarButtonItem btnprint;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode1;
        private System.Windows.Forms.BindingSource vendorBindingSource;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}