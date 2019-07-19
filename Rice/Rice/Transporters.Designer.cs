namespace Rice
{
    partial class Transporters
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
            this.transporterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transporterGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVehicle_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone_No = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.transporterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transporterGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // transporterBindingSource
            // 
            this.transporterBindingSource.DataSource = typeof(Rice.Transporter);
            this.transporterBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.transporterBindingSource_AddingNew);
            // 
            // transporterGridControl
            // 
            this.transporterGridControl.DataSource = this.transporterBindingSource;
            this.transporterGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transporterGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.transporterGridControl.Location = new System.Drawing.Point(0, 0);
            this.transporterGridControl.MainView = this.gridView1;
            this.transporterGridControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.transporterGridControl.Name = "transporterGridControl";
            this.transporterGridControl.Size = new System.Drawing.Size(930, 526);
            this.transporterGridControl.TabIndex = 1;
            this.transporterGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.transporterGridControl.Click += new System.EventHandler(this.transporterGridControl_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colVehicle_No,
            this.colID_No,
            this.colPhone_No});
            this.gridView1.DetailHeight = 538;
            this.gridView1.FixedLineWidth = 3;
            this.gridView1.GridControl = this.transporterGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsImageLoad.AsyncLoad = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 30;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 112;
            // 
            // colVehicle_No
            // 
            this.colVehicle_No.Caption = "Vehicle No";
            this.colVehicle_No.FieldName = "Vehicle_No";
            this.colVehicle_No.MinWidth = 30;
            this.colVehicle_No.Name = "colVehicle_No";
            this.colVehicle_No.Visible = true;
            this.colVehicle_No.VisibleIndex = 1;
            this.colVehicle_No.Width = 112;
            // 
            // colID_No
            // 
            this.colID_No.Caption = "ID No";
            this.colID_No.FieldName = "ID_No";
            this.colID_No.MinWidth = 30;
            this.colID_No.Name = "colID_No";
            this.colID_No.Visible = true;
            this.colID_No.VisibleIndex = 2;
            this.colID_No.Width = 112;
            // 
            // colPhone_No
            // 
            this.colPhone_No.Caption = "Phone No";
            this.colPhone_No.FieldName = "Phone_No";
            this.colPhone_No.MinWidth = 30;
            this.colPhone_No.Name = "colPhone_No";
            this.colPhone_No.Visible = true;
            this.colPhone_No.VisibleIndex = 3;
            this.colPhone_No.Width = 112;
            // 
            // Transporters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 526);
            this.Controls.Add(this.transporterGridControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Transporters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transporters";
            ((System.ComponentModel.ISupportInitialize)(this.transporterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transporterGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource transporterBindingSource;
        private DevExpress.XtraGrid.GridControl transporterGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colVehicle_No;
        private DevExpress.XtraGrid.Columns.GridColumn colID_No;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone_No;
    }
}