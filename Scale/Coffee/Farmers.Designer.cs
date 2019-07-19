namespace Coffee
{
    partial class Farmers
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
            this.farmerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.farmerGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcreage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNo_of_Trees = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccount_Category = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colStore_Total = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOther_Loans = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cellcontext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.filterWithThisValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colCherry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMbuni = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.farmerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.farmerGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).BeginInit();
            this.cellcontext.SuspendLayout();
            this.SuspendLayout();
            // 
            // farmerBindingSource
            // 
            this.farmerBindingSource.DataSource = typeof(Coffee.Farmer);
            this.farmerBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.farmerBindingSource_AddingNew);
            this.farmerBindingSource.CurrentItemChanged += new System.EventHandler(this.farmerBindingSource_CurrentItemChanged);
            // 
            // farmerGridControl
            // 
            this.farmerGridControl.DataSource = this.farmerBindingSource;
            this.farmerGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.farmerGridControl.Location = new System.Drawing.Point(0, 0);
            this.farmerGridControl.MainView = this.gridView1;
            this.farmerGridControl.Name = "farmerGridControl";
            this.farmerGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.farmerGridControl.Size = new System.Drawing.Size(662, 474);
            this.farmerGridControl.TabIndex = 2;
            this.farmerGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.farmerGridControl.Click += new System.EventHandler(this.farmerGridControl_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNo,
            this.colName,
            this.colID_No,
            this.colPhone,
            this.colFactory,
            this.colAcreage,
            this.colNo_of_Trees,
            this.colAccount_Category,
            this.colCherry,
            this.colMbuni,
            this.colStore_Total,
            this.colOther_Loans});
            this.gridView1.GridControl = this.farmerGridControl;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cum_Cherry", null, "(Cherry Cummulative: SUM={0:0.##})"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cum_Mbuni", null, "(Mbuni Cummulative: SUM={0:0.##})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.NewItemRowText = "Enter new farmer";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsEditForm.ActionOnModifiedRowChange = DevExpress.XtraGrid.Views.Grid.EditFormModifiedAction.Save;
            this.gridView1.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNo, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            this.gridView1.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.gridView1_CustomColumnSort);
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            // 
            // colNo
            // 
            this.colNo.FieldName = "No";
            this.colNo.Name = "colNo";
            this.colNo.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.colNo.Visible = true;
            this.colNo.VisibleIndex = 0;
            this.colNo.Width = 59;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 165;
            // 
            // colID_No
            // 
            this.colID_No.Caption = "ID_No";
            this.colID_No.FieldName = "ID_No";
            this.colID_No.Name = "colID_No";
            this.colID_No.Visible = true;
            this.colID_No.VisibleIndex = 3;
            // 
            // colPhone
            // 
            this.colPhone.FieldName = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 4;
            this.colPhone.Width = 103;
            // 
            // colFactory
            // 
            this.colFactory.FieldName = "Factory";
            this.colFactory.Name = "colFactory";
            this.colFactory.OptionsColumn.ReadOnly = true;
            this.colFactory.Visible = true;
            this.colFactory.VisibleIndex = 5;
            // 
            // colAcreage
            // 
            this.colAcreage.FieldName = "Acreage";
            this.colAcreage.Name = "colAcreage";
            this.colAcreage.Visible = true;
            this.colAcreage.VisibleIndex = 2;
            // 
            // colNo_of_Trees
            // 
            this.colNo_of_Trees.FieldName = "No_of_Trees";
            this.colNo_of_Trees.Name = "colNo_of_Trees";
            this.colNo_of_Trees.Visible = true;
            this.colNo_of_Trees.VisibleIndex = 10;
            // 
            // colAccount_Category
            // 
            this.colAccount_Category.Caption = "Account Category";
            this.colAccount_Category.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colAccount_Category.FieldName = "Account_Category";
            this.colAccount_Category.Name = "colAccount_Category";
            this.colAccount_Category.Visible = true;
            this.colAccount_Category.VisibleIndex = 8;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colStore_Total
            // 
            this.colStore_Total.Caption = "Store";
            this.colStore_Total.FieldName = "Store_Total";
            this.colStore_Total.Name = "colStore_Total";
            this.colStore_Total.Visible = true;
            this.colStore_Total.VisibleIndex = 9;
            // 
            // colOther_Loans
            // 
            this.colOther_Loans.Caption = "Other Loans";
            this.colOther_Loans.FieldName = "Other_Loans";
            this.colOther_Loans.Name = "colOther_Loans";
            this.colOther_Loans.OptionsColumn.ReadOnly = true;
            this.colOther_Loans.Visible = true;
            this.colOther_Loans.VisibleIndex = 11;
            // 
            // vendorBindingSource
            // 
            this.vendorBindingSource.DataSource = typeof(Coffee.server.Vendor);
            // 
            // cellcontext
            // 
            this.cellcontext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filterWithThisValueToolStripMenuItem});
            this.cellcontext.Name = "cellcontext";
            this.cellcontext.Size = new System.Drawing.Size(139, 26);
            this.cellcontext.Opening += new System.ComponentModel.CancelEventHandler(this.cellcontext_Opening);
            this.cellcontext.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cellcontext_ItemClicked);
            // 
            // filterWithThisValueToolStripMenuItem
            // 
            this.filterWithThisValueToolStripMenuItem.Name = "filterWithThisValueToolStripMenuItem";
            this.filterWithThisValueToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.filterWithThisValueToolStripMenuItem.Text = "Show report";
            this.filterWithThisValueToolStripMenuItem.Click += new System.EventHandler(this.filterWithThisValueToolStripMenuItem_Click);
            // 
            // colCherry
            // 
            this.colCherry.FieldName = "Cherry";
            this.colCherry.Name = "colCherry";
            this.colCherry.OptionsColumn.ReadOnly = true;
            this.colCherry.Visible = true;
            this.colCherry.VisibleIndex = 6;
            // 
            // colMbuni
            // 
            this.colMbuni.FieldName = "Mbuni";
            this.colMbuni.Name = "colMbuni";
            this.colMbuni.OptionsColumn.ReadOnly = true;
            this.colMbuni.Visible = true;
            this.colMbuni.VisibleIndex = 7;
            // 
            // Farmers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 474);
            this.Controls.Add(this.farmerGridControl);
            this.Name = "Farmers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Farmers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Farmers_FormClosing);
            this.Load += new System.EventHandler(this.Farmers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.farmerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.farmerGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorBindingSource)).EndInit();
            this.cellcontext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource farmerBindingSource;
        private DevExpress.XtraGrid.GridControl farmerGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private System.Windows.Forms.ContextMenuStrip cellcontext;
        private System.Windows.Forms.ToolStripMenuItem filterWithThisValueToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colID_No;
        private DevExpress.XtraGrid.Columns.GridColumn colFactory;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount_Category;
        private System.Windows.Forms.BindingSource vendorBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colStore_Total;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colAcreage;
        private DevExpress.XtraGrid.Columns.GridColumn colNo_of_Trees;
        private DevExpress.XtraGrid.Columns.GridColumn colOther_Loans;
        private DevExpress.XtraGrid.Columns.GridColumn colCherry;
        private DevExpress.XtraGrid.Columns.GridColumn colMbuni;
    }
}