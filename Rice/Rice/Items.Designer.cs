namespace Rice
{
    partial class Items
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Items));
            this.paddy_DetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paddy_DetailGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCollection_Number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCollections_Date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCollections_Time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnpostprint = new DevExpress.XtraBars.BarButtonItem();
            this.btnreprint = new DevExpress.XtraBars.BarButtonItem();
            this.btnprint = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.filterByThisValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.paddy_DetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddy_DetailGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.paddy_DetailGridControl.Size = new System.Drawing.Size(750, 356);
            this.paddy_DetailGridControl.TabIndex = 1;
            this.paddy_DetailGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCollection_Number,
            this.colCollections_Date,
            this.colCollections_Time});
            this.gridView1.GridControl = this.paddy_DetailGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colCollection_Number
            // 
            this.colCollection_Number.FieldName = "Collection_Number";
            this.colCollection_Number.Name = "colCollection_Number";
            this.colCollection_Number.Visible = true;
            this.colCollection_Number.VisibleIndex = 0;
            // 
            // colCollections_Date
            // 
            this.colCollections_Date.FieldName = "Collections_Date";
            this.colCollections_Date.Name = "colCollections_Date";
            this.colCollections_Date.Visible = true;
            this.colCollections_Date.VisibleIndex = 1;
            // 
            // colCollections_Time
            // 
            this.colCollections_Time.FieldName = "Collections_Time";
            this.colCollections_Time.Name = "colCollections_Time";
            this.colCollections_Time.Visible = true;
            this.colCollections_Time.VisibleIndex = 2;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnpostprint,
            this.btnreprint,
            this.btnprint});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(750, 139);
            // 
            // btnpostprint
            // 
            this.btnpostprint.Caption = "Post && Print Delivery";
            this.btnpostprint.Id = 1;
            this.btnpostprint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnpostprint.ImageOptions.Image")));
            this.btnpostprint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnpostprint.ImageOptions.LargeImage")));
            this.btnpostprint.Name = "btnpostprint";
            // 
            // btnreprint
            // 
            this.btnreprint.Caption = "Reprint Supply Note";
            this.btnreprint.Id = 2;
            this.btnreprint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnreprint.ImageOptions.Image")));
            this.btnreprint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnreprint.ImageOptions.LargeImage")));
            this.btnreprint.Name = "btnreprint";
            // 
            // btnprint
            // 
            this.btnprint.Caption = "Print Delivery";
            this.btnprint.Id = 3;
            this.btnprint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.ImageOptions.Image")));
            this.btnprint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnprint.ImageOptions.LargeImage")));
            this.btnprint.Name = "btnprint";
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
            this.ribbonPageGroup1.ItemLinks.Add(this.btnreprint);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Delivery";
            // 
            // filterByThisValueToolStripMenuItem
            // 
            this.filterByThisValueToolStripMenuItem.Image = global::Rice.Properties.Resources.stock_advanced_filter;
            this.filterByThisValueToolStripMenuItem.Name = "filterByThisValueToolStripMenuItem";
            this.filterByThisValueToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.filterByThisValueToolStripMenuItem.Text = "Filter by this value";
            // 
            // reverseToolStripMenuItem
            // 
            this.reverseToolStripMenuItem.Image = global::Rice.Properties.Resources.back_2;
            this.reverseToolStripMenuItem.Name = "reverseToolStripMenuItem";
            this.reverseToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.reverseToolStripMenuItem.Text = "Reverse";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterByThisValueToolStripMenuItem,
            this.reverseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 48);
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 495);
            this.Controls.Add(this.paddy_DetailGridControl);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Items";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Items";
            ((System.ComponentModel.ISupportInitialize)(this.paddy_DetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paddy_DetailGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource paddy_DetailBindingSource;
        private DevExpress.XtraGrid.GridControl paddy_DetailGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnpostprint;
        private DevExpress.XtraBars.BarButtonItem btnreprint;
        private DevExpress.XtraBars.BarButtonItem btnprint;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn colCollection_Number;
        private DevExpress.XtraGrid.Columns.GridColumn colCollections_Date;
        private DevExpress.XtraGrid.Columns.GridColumn colCollections_Time;
        private System.Windows.Forms.ToolStripMenuItem filterByThisValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reverseToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}