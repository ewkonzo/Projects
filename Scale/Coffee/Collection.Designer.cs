namespace Coffee
{
    partial class Collection
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.daily_Collections_DetailsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCollection_Number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoffee_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKg__Collected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCollection_time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtfarmer = new System.Windows.Forms.TextBox();
            this.viewfarmername = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtkg = new System.Windows.Forms.TextBox();
            this.btnprocess = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.noofbags = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.netkg = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.btnhold = new System.Windows.Forms.Button();
            this.txthold = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.daily_Collections_DetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCollection_Number1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFarmers_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoffee_Type1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKg__Collected1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCancelled = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCollection_time1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCollect_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFarmers_Number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Scalestatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daily_Collections_DetailsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daily_Collections_DetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Farmer No";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridControl1);
            this.groupBox1.Controls.Add(this.txtfarmer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 228);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Farmer Details";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.daily_Collections_DetailsBindingSource1;
            this.gridControl1.Location = new System.Drawing.Point(9, 58);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(372, 155);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // daily_Collections_DetailsBindingSource1
            // 
            this.daily_Collections_DetailsBindingSource1.DataSource = typeof(Coffee.Daily_Collections_Detail);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCollection_Number,
            this.colCoffee_Type,
            this.colKg__Collected,
            this.colCollection_time});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colCollection_Number
            // 
            this.colCollection_Number.Caption = "Receipt No";
            this.colCollection_Number.FieldName = "Collection_Number";
            this.colCollection_Number.Name = "colCollection_Number";
            this.colCollection_Number.Visible = true;
            this.colCollection_Number.VisibleIndex = 1;
            this.colCollection_Number.Width = 96;
            // 
            // colCoffee_Type
            // 
            this.colCoffee_Type.Caption = "Type";
            this.colCoffee_Type.FieldName = "Coffee_Type";
            this.colCoffee_Type.Name = "colCoffee_Type";
            this.colCoffee_Type.Visible = true;
            this.colCoffee_Type.VisibleIndex = 2;
            this.colCoffee_Type.Width = 43;
            // 
            // colKg__Collected
            // 
            this.colKg__Collected.Caption = "KG";
            this.colKg__Collected.FieldName = "Kg__Collected";
            this.colKg__Collected.Name = "colKg__Collected";
            this.colKg__Collected.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Kg__Collected", "Cumm:={0:0.##}")});
            this.colKg__Collected.Visible = true;
            this.colKg__Collected.VisibleIndex = 3;
            this.colKg__Collected.Width = 90;
            // 
            // colCollection_time
            // 
            this.colCollection_time.Caption = "Date";
            this.colCollection_time.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.colCollection_time.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colCollection_time.FieldName = "Collection_time";
            this.colCollection_time.Name = "colCollection_time";
            this.colCollection_time.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Collection_time", "{0}")});
            this.colCollection_time.Visible = true;
            this.colCollection_time.VisibleIndex = 0;
            this.colCollection_time.Width = 125;
            // 
            // txtfarmer
            // 
            this.txtfarmer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfarmer.Location = new System.Drawing.Point(92, 23);
            this.txtfarmer.Name = "txtfarmer";
            this.txtfarmer.Size = new System.Drawing.Size(263, 29);
            this.txtfarmer.TabIndex = 0;
            this.txtfarmer.TextChanged += new System.EventHandler(this.txtfarmer_TextChanged);
            this.txtfarmer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfarmer_KeyPress);
            this.txtfarmer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            this.txtfarmer.Leave += new System.EventHandler(this.txtfarmer_Leave);
            // 
            // viewfarmername
            // 
            this.viewfarmername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewfarmername.Location = new System.Drawing.Point(417, 3);
            this.viewfarmername.Name = "viewfarmername";
            this.viewfarmername.Size = new System.Drawing.Size(276, 39);
            this.viewfarmername.TabIndex = 2;
            this.viewfarmername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(418, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Gross KG";
            // 
            // txtkg
            // 
            this.txtkg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkg.Location = new System.Drawing.Point(420, 70);
            this.txtkg.Name = "txtkg";
            this.txtkg.Size = new System.Drawing.Size(273, 30);
            this.txtkg.TabIndex = 1;
            this.txtkg.TextChanged += new System.EventHandler(this.txtkg_TextChanged);
            this.txtkg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtkg_KeyPress);
            this.txtkg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            this.txtkg.Leave += new System.EventHandler(this.txtkg_Leave);
            // 
            // btnprocess
            // 
            this.btnprocess.BackColor = System.Drawing.SystemColors.Control;
            this.btnprocess.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprocess.Location = new System.Drawing.Point(420, 192);
            this.btnprocess.Name = "btnprocess";
            this.btnprocess.Size = new System.Drawing.Size(273, 39);
            this.btnprocess.TabIndex = 3;
            this.btnprocess.Text = "Post";
            this.btnprocess.UseVisualStyleBackColor = true;
            this.btnprocess.Click += new System.EventHandler(this.button2_Click);
            this.btnprocess.Enter += new System.EventHandler(this.btnprocess_Enter);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Tare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(476, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(10, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Zero";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Coffee.Daily_Collections_Detail);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(21, 466);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Reprint Receipt";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Reprint);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(254, 466);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(157, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Cancel Receipt";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(618, 43);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(75, 23);
            this.btnManual.TabIndex = 8;
            this.btnManual.Text = "Manual(M)";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // noofbags
            // 
            this.noofbags.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noofbags.Location = new System.Drawing.Point(71, 11);
            this.noofbags.Name = "noofbags";
            this.noofbags.Size = new System.Drawing.Size(96, 23);
            this.noofbags.TabIndex = 2;
            this.noofbags.TextChanged += new System.EventHandler(this.noofbags_TextChanged);
            this.noofbags.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.noofbags_KeyPress);
            this.noofbags.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Control_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "No of bags";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // netkg
            // 
            this.netkg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.netkg.Location = new System.Drawing.Point(206, 9);
            this.netkg.Name = "netkg";
            this.netkg.Size = new System.Drawing.Size(68, 25);
            this.netkg.TabIndex = 11;
            this.netkg.Text = "0.0";
            this.netkg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.netkg.Click += new System.EventHandler(this.netkg_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(9, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(65, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Clear(C)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnhold
            // 
            this.btnhold.Location = new System.Drawing.Point(90, 12);
            this.btnhold.Name = "btnhold";
            this.btnhold.Size = new System.Drawing.Size(71, 23);
            this.btnhold.TabIndex = 14;
            this.btnhold.Text = "Hold(H)";
            this.btnhold.UseVisualStyleBackColor = true;
            this.btnhold.Click += new System.EventHandler(this.btnhold_Click);
            // 
            // txthold
            // 
            this.txthold.AutoSize = true;
            this.txthold.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthold.Location = new System.Drawing.Point(236, 9);
            this.txthold.Name = "txthold";
            this.txthold.Size = new System.Drawing.Size(39, 25);
            this.txthold.TabIndex = 13;
            this.txthold.Text = "0.0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.noofbags);
            this.groupBox2.Controls.Add(this.netkg);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(412, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 37);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tare weight";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.txthold);
            this.groupBox3.Controls.Add(this.btnhold);
            this.groupBox3.Location = new System.Drawing.Point(412, 143);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 37);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Super sale";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(21, 237);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(144, 20);
            this.dateEdit1.TabIndex = 18;
            this.dateEdit1.EditValueChanged += new System.EventHandler(this.dateEdit1_EditValueChanged);
            // 
            // daily_Collections_DetailsBindingSource
            // 
            this.daily_Collections_DetailsBindingSource.DataSource = typeof(Coffee.Daily_Collections_Detail);
            // 
            // gridControl2
            // 
            this.gridControl2.DataSource = this.daily_Collections_DetailsBindingSource;
            this.gridControl2.Location = new System.Drawing.Point(21, 263);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(672, 197);
            this.gridControl2.TabIndex = 19;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCollection_Number1,
            this.colFarmers_Name,
            this.colCoffee_Type1,
            this.colKg__Collected1,
            this.colCancelled,
            this.colUser,
            this.colCollection_time1,
            this.colCollect_type,
            this.colFarmers_Number});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCollection_time1, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colCollection_Number1
            // 
            this.colCollection_Number1.Caption = "Receipt No";
            this.colCollection_Number1.DisplayFormat.FormatString = "d";
            this.colCollection_Number1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCollection_Number1.FieldName = "Collection_Number";
            this.colCollection_Number1.Name = "colCollection_Number1";
            this.colCollection_Number1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Collection_Number", "{0}")});
            this.colCollection_Number1.Visible = true;
            this.colCollection_Number1.VisibleIndex = 1;
            this.colCollection_Number1.Width = 80;
            // 
            // colFarmers_Name
            // 
            this.colFarmers_Name.Caption = "Name";
            this.colFarmers_Name.FieldName = "Farmers_Name";
            this.colFarmers_Name.Name = "colFarmers_Name";
            this.colFarmers_Name.Visible = true;
            this.colFarmers_Name.VisibleIndex = 3;
            this.colFarmers_Name.Width = 117;
            // 
            // colCoffee_Type1
            // 
            this.colCoffee_Type1.Caption = "Type";
            this.colCoffee_Type1.FieldName = "Coffee_Type";
            this.colCoffee_Type1.Name = "colCoffee_Type1";
            this.colCoffee_Type1.Visible = true;
            this.colCoffee_Type1.VisibleIndex = 6;
            this.colCoffee_Type1.Width = 67;
            // 
            // colKg__Collected1
            // 
            this.colKg__Collected1.Caption = "Kg";
            this.colKg__Collected1.FieldName = "Kg__Collected";
            this.colKg__Collected1.Name = "colKg__Collected1";
            this.colKg__Collected1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Kg__Collected", "Total:={0:0.##}")});
            this.colKg__Collected1.Visible = true;
            this.colKg__Collected1.VisibleIndex = 4;
            this.colKg__Collected1.Width = 126;
            // 
            // colCancelled
            // 
            this.colCancelled.FieldName = "Cancelled";
            this.colCancelled.Name = "colCancelled";
            this.colCancelled.Visible = true;
            this.colCancelled.VisibleIndex = 5;
            this.colCancelled.Width = 48;
            // 
            // colUser
            // 
            this.colUser.FieldName = "User";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 7;
            this.colUser.Width = 44;
            // 
            // colCollection_time1
            // 
            this.colCollection_time1.Caption = "Date Time";
            this.colCollection_time1.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.colCollection_time1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colCollection_time1.FieldName = "Collection_time";
            this.colCollection_time1.Name = "colCollection_time1";
            this.colCollection_time1.Visible = true;
            this.colCollection_time1.VisibleIndex = 0;
            this.colCollection_time1.Width = 134;
            // 
            // colCollect_type
            // 
            this.colCollect_type.Caption = "C Type";
            this.colCollect_type.FieldName = "Collect_type";
            this.colCollect_type.Name = "colCollect_type";
            this.colCollect_type.Width = 56;
            // 
            // colFarmers_Number
            // 
            this.colFarmers_Number.Caption = "No";
            this.colFarmers_Number.FieldName = "Farmers_Number";
            this.colFarmers_Number.Name = "colFarmers_Number";
            this.colFarmers_Number.Visible = true;
            this.colFarmers_Number.VisibleIndex = 2;
            this.colFarmers_Number.Width = 38;
            // 
            // Scalestatus
            // 
            this.Scalestatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Scalestatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scalestatus.Location = new System.Drawing.Point(0, 492);
            this.Scalestatus.Name = "Scalestatus";
            this.Scalestatus.Size = new System.Drawing.Size(733, 22);
            this.Scalestatus.TabIndex = 20;
            this.Scalestatus.Text = "label3";
            this.Scalestatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Collection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 514);
            this.Controls.Add(this.Scalestatus);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.viewfarmername);
            this.Controls.Add(this.btnprocess);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtkg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Collection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Collection_FormClosing);
            this.Load += new System.EventHandler(this.Collection_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Collection_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daily_Collections_DetailsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daily_Collections_DetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label viewfarmername;
        private System.Windows.Forms.TextBox txtfarmer;
        private System.Windows.Forms.BindingSource daily_Collections_DetailsBindingSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtkg;
        private System.Windows.Forms.Button btnprocess;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Label netkg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox noofbags;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnhold;
        private System.Windows.Forms.Label txthold;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource daily_Collections_DetailsBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colCollection_Number;
        private DevExpress.XtraGrid.Columns.GridColumn colCoffee_Type;
        private DevExpress.XtraGrid.Columns.GridColumn colKg__Collected;
        private DevExpress.XtraGrid.Columns.GridColumn colCollection_time;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colCollection_Number1;
        private DevExpress.XtraGrid.Columns.GridColumn colFarmers_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colCoffee_Type1;
        private DevExpress.XtraGrid.Columns.GridColumn colKg__Collected1;
        private DevExpress.XtraGrid.Columns.GridColumn colCancelled;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colCollection_time1;
        private DevExpress.XtraGrid.Columns.GridColumn colCollect_type;
        private DevExpress.XtraGrid.Columns.GridColumn colFarmers_Number;
        private System.Windows.Forms.Label Scalestatus;
    }
}