namespace Rice
{
    partial class Vehicles
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
            this.resourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resourceGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.resourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourceGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // resourceBindingSource
            // 
            this.resourceBindingSource.DataSource = typeof(Rice.Resource);
            // 
            // resourceGridControl
            // 
            this.resourceGridControl.DataSource = this.resourceBindingSource;
            this.resourceGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceGridControl.Location = new System.Drawing.Point(0, 0);
            this.resourceGridControl.MainView = this.gridView1;
            this.resourceGridControl.Name = "resourceGridControl";
            this.resourceGridControl.Size = new System.Drawing.Size(1010, 516);
            this.resourceGridControl.TabIndex = 1;
            this.resourceGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.resourceGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // Vehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 516);
            this.Controls.Add(this.resourceGridControl);
            this.Name = "Vehicles";
            this.Text = "Vehicles";
            ((System.ComponentModel.ISupportInitialize)(this.resourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourceGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource resourceBindingSource;
        private DevExpress.XtraGrid.GridControl resourceGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}