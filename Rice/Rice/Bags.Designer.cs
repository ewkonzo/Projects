namespace Rice
{
    partial class Bags
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bags));
            this.paddy_BagBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paddy_BagGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFarmer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNo_of_bags = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGross_kg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoisture_Weight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBag_weight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNet_kg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaddy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReversed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeighed_by = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnpostprint = new DevExpress.XtraBars.BarButtonItem();
            this.btnreverse = new DevExpress.XtraBars.BarButtonItem();
            this.btnprint = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnconvert = new DevExpress.XtraBars.BarButtonItem();
            this.btnreverseall = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.paddy_BagBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddy_BagGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // paddy_BagBindingSource
            // 
            this.paddy_BagBindingSource.DataSource = typeof(Rice.Paddy_Bag);
            this.paddy_BagBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.paddy_BagBindingSource_AddingNew);
            // 
            // paddy_BagGridControl
            // 
            this.paddy_BagGridControl.DataSource = this.paddy_BagBindingSource;
            this.paddy_BagGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paddy_BagGridControl.Location = new System.Drawing.Point(0, 139);
            this.paddy_BagGridControl.MainView = this.gridView1;
            this.paddy_BagGridControl.Name = "paddy_BagGridControl";
            this.paddy_BagGridControl.Size = new System.Drawing.Size(846, 246);
            this.paddy_BagGridControl.TabIndex = 1;
            this.paddy_BagGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colFarmer,
            this.colNo_of_bags,
            this.colGross_kg,
            this.colMoisture_Weight,
            this.colBag_weight,
            this.colNet_kg,
            this.colPaddy,
            this.colReversed,
            this.colWeighed_by});
            this.gridView1.GridControl = this.paddy_BagGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colDate
            // 
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 1;
            this.colDate.Width = 61;
            // 
            // colFarmer
            // 
            this.colFarmer.FieldName = "Farmer";
            this.colFarmer.Name = "colFarmer";
            this.colFarmer.Visible = true;
            this.colFarmer.VisibleIndex = 2;
            this.colFarmer.Width = 89;
            // 
            // colNo_of_bags
            // 
            this.colNo_of_bags.Caption = "Bags";
            this.colNo_of_bags.DisplayFormat.FormatString = "n2";
            this.colNo_of_bags.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNo_of_bags.FieldName = "No_of_bags";
            this.colNo_of_bags.Name = "colNo_of_bags";
            this.colNo_of_bags.Visible = true;
            this.colNo_of_bags.VisibleIndex = 3;
            this.colNo_of_bags.Width = 53;
            // 
            // colGross_kg
            // 
            this.colGross_kg.Caption = "Gross";
            this.colGross_kg.DisplayFormat.FormatString = "n2";
            this.colGross_kg.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGross_kg.FieldName = "Gross_kg";
            this.colGross_kg.Name = "colGross_kg";
            this.colGross_kg.Visible = true;
            this.colGross_kg.VisibleIndex = 4;
            this.colGross_kg.Width = 89;
            // 
            // colMoisture_Weight
            // 
            this.colMoisture_Weight.DisplayFormat.FormatString = "n2";
            this.colMoisture_Weight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMoisture_Weight.FieldName = "Moisture_Weight";
            this.colMoisture_Weight.Name = "colMoisture_Weight";
            this.colMoisture_Weight.Visible = true;
            this.colMoisture_Weight.VisibleIndex = 5;
            this.colMoisture_Weight.Width = 89;
            // 
            // colBag_weight
            // 
            this.colBag_weight.DisplayFormat.FormatString = "n2";
            this.colBag_weight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBag_weight.FieldName = "Bag_weight";
            this.colBag_weight.Name = "colBag_weight";
            this.colBag_weight.Visible = true;
            this.colBag_weight.VisibleIndex = 6;
            this.colBag_weight.Width = 89;
            // 
            // colNet_kg
            // 
            this.colNet_kg.Caption = "Net";
            this.colNet_kg.DisplayFormat.FormatString = "n2";
            this.colNet_kg.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNet_kg.FieldName = "Net_kg";
            this.colNet_kg.Name = "colNet_kg";
            this.colNet_kg.Visible = true;
            this.colNet_kg.VisibleIndex = 7;
            this.colNet_kg.Width = 89;
            // 
            // colPaddy
            // 
            this.colPaddy.FieldName = "Paddy";
            this.colPaddy.Name = "colPaddy";
            this.colPaddy.Visible = true;
            this.colPaddy.VisibleIndex = 0;
            this.colPaddy.Width = 59;
            // 
            // colReversed
            // 
            this.colReversed.FieldName = "Reversed";
            this.colReversed.Name = "colReversed";
            this.colReversed.Visible = true;
            this.colReversed.VisibleIndex = 8;
            this.colReversed.Width = 89;
            // 
            // colWeighed_by
            // 
            this.colWeighed_by.Caption = "Weighed by";
            this.colWeighed_by.FieldName = "Weighed_by";
            this.colWeighed_by.Name = "colWeighed_by";
            this.colWeighed_by.Visible = true;
            this.colWeighed_by.VisibleIndex = 9;
            this.colWeighed_by.Width = 121;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnpostprint,
            this.btnreverse,
            this.btnprint,
            this.barButtonItem1,
            this.btnconvert,
            this.btnreverseall});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 7;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(846, 139);
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
            // btnreverse
            // 
            this.btnreverse.Caption = "Reverse Selected";
            this.btnreverse.Id = 2;
            this.btnreverse.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnreverse.ImageOptions.Image")));
            this.btnreverse.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnreverse.ImageOptions.LargeImage")));
            this.btnreverse.Name = "btnreverse";
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
            // btnconvert
            // 
            this.btnconvert.Caption = "Convert && Post";
            this.btnconvert.Id = 5;
            this.btnconvert.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnconvert.ImageOptions.Image")));
            this.btnconvert.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnconvert.ImageOptions.LargeImage")));
            this.btnconvert.Name = "btnconvert";
            // 
            // btnreverseall
            // 
            this.btnreverseall.Caption = "Reverse all";
            this.btnreverseall.Id = 6;
            this.btnreverseall.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnreverseall.ImageOptions.Image")));
            this.btnreverseall.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnreverseall.ImageOptions.LargeImage")));
            this.btnreverseall.Name = "btnreverseall";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnreverse);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnreverseall);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Items Received";
            // 
            // Bags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 385);
            this.Controls.Add(this.paddy_BagGridControl);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Bags";
            this.Text = "Bags";
            ((System.ComponentModel.ISupportInitialize)(this.paddy_BagBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddy_BagGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource paddy_BagBindingSource;
        private DevExpress.XtraGrid.GridControl paddy_BagGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFarmer;
        private DevExpress.XtraGrid.Columns.GridColumn colNo_of_bags;
        private DevExpress.XtraGrid.Columns.GridColumn colGross_kg;
        private DevExpress.XtraGrid.Columns.GridColumn colMoisture_Weight;
        private DevExpress.XtraGrid.Columns.GridColumn colBag_weight;
        private DevExpress.XtraGrid.Columns.GridColumn colNet_kg;
        private DevExpress.XtraGrid.Columns.GridColumn colPaddy;
        private DevExpress.XtraGrid.Columns.GridColumn colReversed;
        private DevExpress.XtraGrid.Columns.GridColumn colWeighed_by;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnpostprint;
        private DevExpress.XtraBars.BarButtonItem btnreverse;
        private DevExpress.XtraBars.BarButtonItem btnprint;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnconvert;
        private DevExpress.XtraBars.BarButtonItem btnreverseall;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}