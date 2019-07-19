namespace Rice
{
    partial class Reportfilters
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
            this.filtersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnprint = new DevExpress.XtraBars.BarButtonItem();
            this.btnpreview = new DevExpress.XtraBars.BarButtonItem();
            this.btncancel = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.outletBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemsServicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filterEditorControl1 = new DevExpress.XtraFilterEditor.FilterEditorControl();
            ((System.ComponentModel.ISupportInitialize)(this.filtersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outletBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsServicesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // filtersBindingSource
            // 
            this.filtersBindingSource.DataSource = typeof(Rice.filters);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnprint,
            this.btnpreview,
            this.btncancel});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(656, 141);
            this.ribbonControl1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ribbonControl1_ItemClick);
            // 
            // btnprint
            // 
            this.btnprint.Caption = "Print";
            this.btnprint.Id = 1;
            this.btnprint.ImageOptions.LargeImage = global::Rice.Properties.Resources.Print;
            this.btnprint.Name = "btnprint";
            // 
            // btnpreview
            // 
            this.btnpreview.Caption = "Preview";
            this.btnpreview.Id = 2;
            this.btnpreview.ImageOptions.LargeImage = global::Rice.Properties.Resources.PrintReport;
            this.btnpreview.Name = "btnpreview";
            this.btnpreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // btncancel
            // 
            this.btncancel.Caption = "Cancel";
            this.btncancel.Id = 3;
            this.btncancel.ImageOptions.LargeImage = global::Rice.Properties.Resources.Cancel;
            this.btncancel.Name = "btncancel";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Report Filters";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnprint);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnpreview);
            this.ribbonPageGroup1.ItemLinks.Add(this.btncancel);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Print Preview";
            // 
            // outletBindingSource
            // 
            this.outletBindingSource.DataSource = typeof(Rice.Outlet);
            // 
            // itemsServicesBindingSource
            // 
            this.itemsServicesBindingSource.DataSource = typeof(Rice.Items_Services);
            // 
            // filterEditorControl1
            // 
            this.filterEditorControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.filterEditorControl1.Appearance.Options.UseFont = true;
            this.filterEditorControl1.AppearanceEmptyValueColor = System.Drawing.Color.Empty;
            this.filterEditorControl1.AppearanceFieldNameColor = System.Drawing.Color.Empty;
            this.filterEditorControl1.AppearanceGroupOperatorColor = System.Drawing.Color.Empty;
            this.filterEditorControl1.AppearanceOperatorColor = System.Drawing.Color.Empty;
            this.filterEditorControl1.AppearanceValueColor = System.Drawing.Color.Empty;
            this.filterEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterEditorControl1.Location = new System.Drawing.Point(0, 141);
            this.filterEditorControl1.Name = "filterEditorControl1";
            this.filterEditorControl1.Size = new System.Drawing.Size(656, 290);
            this.filterEditorControl1.TabIndex = 6;
            this.filterEditorControl1.Text = "filterEditorControl1";
            this.filterEditorControl1.UseMenuForOperandsAndOperators = false;
            this.filterEditorControl1.BeforeShowValueEditor += new DevExpress.XtraEditors.Filtering.ShowValueEditorEventHandler(this.filterControl1_BeforeShowValueEditor);
            this.filterEditorControl1.FilterTextChanged += new DevExpress.XtraEditors.FilterTextChangedEventHandler(this.filterEditorControl1_FilterTextChanged);
            // 
            // Reportfilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 431);
            this.Controls.Add(this.filterEditorControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "Reportfilters";
            this.Text = "Reportfilters";
            this.Load += new System.EventHandler(this.Reportfilters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.filtersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outletBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsServicesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource filtersBindingSource;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnprint;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnpreview;
        private DevExpress.XtraBars.BarButtonItem btncancel;
        private System.Windows.Forms.BindingSource outletBindingSource;
        private System.Windows.Forms.BindingSource itemsServicesBindingSource;
        private DevExpress.XtraFilterEditor.FilterEditorControl filterEditorControl1;
    }
}