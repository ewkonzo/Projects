namespace Rice
{
    partial class Filter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Operand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repooperand = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colfield = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colvalue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repofield = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repooperand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repofield)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(14, 15);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repooperand,
            this.repofield});
            this.gridControl1.Size = new System.Drawing.Size(400, 200);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Operand,
            this.colfield,
            this.colvalue});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Operand
            // 
            this.Operand.Caption = "Operand";
            this.Operand.ColumnEdit = this.repooperand;
            this.Operand.Name = "Operand";
            this.Operand.Visible = true;
            this.Operand.VisibleIndex = 0;
            // 
            // repooperand
            // 
            this.repooperand.AutoHeight = false;
            this.repooperand.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repooperand.Items.AddRange(new object[] {
            "And",
            "Or"});
            this.repooperand.Name = "repooperand";
            // 
            // colfield
            // 
            this.colfield.Caption = "Field";
            this.colfield.Name = "colfield";
            this.colfield.Visible = true;
            this.colfield.VisibleIndex = 1;
            // 
            // colvalue
            // 
            this.colvalue.Caption = "Value";
            this.colvalue.Name = "colvalue";
            this.colvalue.Visible = true;
            this.colvalue.VisibleIndex = 2;
            // 
            // repofield
            // 
            this.repofield.AutoHeight = false;
            this.repofield.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repofield.Name = "repofield";
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "Filter";
            this.Size = new System.Drawing.Size(438, 239);
            this.Load += new System.EventHandler(this.Filter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repooperand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repofield)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Operand;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repooperand;
        private DevExpress.XtraGrid.Columns.GridColumn colfield;
        private DevExpress.XtraGrid.Columns.GridColumn colvalue;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repofield;
    }
}
