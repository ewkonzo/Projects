namespace Rice
{
    partial class Reversal
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
            this.item_ReversalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.item_ReversalGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReversal_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReversed_By = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationname = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.item_ReversalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_ReversalGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // item_ReversalBindingSource
            // 
            this.item_ReversalBindingSource.DataSource = typeof(Rice.Item_Reversal);
            // 
            // item_ReversalGridControl
            // 
            this.item_ReversalGridControl.DataSource = this.item_ReversalBindingSource;
            this.item_ReversalGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.item_ReversalGridControl.Location = new System.Drawing.Point(0, 0);
            this.item_ReversalGridControl.MainView = this.gridView1;
            this.item_ReversalGridControl.Name = "item_ReversalGridControl";
            this.item_ReversalGridControl.Size = new System.Drawing.Size(621, 381);
            this.item_ReversalGridControl.TabIndex = 1;
            this.item_ReversalGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colTime,
            this.colReversal_Id,
            this.colLocationname,
            this.colReversed_By,
            this.colItem_Type});
            this.gridView1.GridControl = this.item_ReversalGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
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
            this.colTime.VisibleIndex = 1;
            // 
            // colReversal_Id
            // 
            this.colReversal_Id.Caption = "Item Reversed";
            this.colReversal_Id.FieldName = "Reversal_Id";
            this.colReversal_Id.Name = "colReversal_Id";
            this.colReversal_Id.Visible = true;
            this.colReversal_Id.VisibleIndex = 2;
            // 
            // colReversed_By
            // 
            this.colReversed_By.Caption = "Reversed By";
            this.colReversed_By.FieldName = "Reversed_By";
            this.colReversed_By.Name = "colReversed_By";
            this.colReversed_By.Visible = true;
            this.colReversed_By.VisibleIndex = 4;
            // 
            // colItem_Type
            // 
            this.colItem_Type.Caption = "Item Type";
            this.colItem_Type.FieldName = "Item_Type";
            this.colItem_Type.Name = "colItem_Type";
            this.colItem_Type.Visible = true;
            this.colItem_Type.VisibleIndex = 5;
            // 
            // colLocationname
            // 
            this.colLocationname.Caption = "Location";
            this.colLocationname.FieldName = "Locationname";
            this.colLocationname.Name = "colLocationname";
            this.colLocationname.Visible = true;
            this.colLocationname.VisibleIndex = 3;
            // 
            // Reversal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 381);
            this.Controls.Add(this.item_ReversalGridControl);
            this.Name = "Reversal";
            this.Text = "Reversals";
            ((System.ComponentModel.ISupportInitialize)(this.item_ReversalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item_ReversalGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource item_ReversalBindingSource;
        private DevExpress.XtraGrid.GridControl item_ReversalGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTime;
        private DevExpress.XtraGrid.Columns.GridColumn colReversal_Id;
        private DevExpress.XtraGrid.Columns.GridColumn colReversed_By;
        private DevExpress.XtraGrid.Columns.GridColumn colItem_Type;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationname;
    }
}