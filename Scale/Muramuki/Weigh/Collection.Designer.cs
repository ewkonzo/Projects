namespace Weigh
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.viewcummulative = new System.Windows.Forms.Label();
            this.txtfarmer = new System.Windows.Forms.TextBox();
            this.txttotal = new System.Windows.Forms.Label();
            this.viewfarmername = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtkg = new System.Windows.Forms.TextBox();
            this.btnprocess = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnopenport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Processed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.farmersNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.farmersNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collectionsDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collectiontimeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collectionNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coffeeTypeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgCollectedDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cummDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.collectionsDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collectiontimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collectionNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coffeeTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kgCollectedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daily_Collections_DetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.daily_Collections_DetailsBindingSource)).BeginInit();
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
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.viewcummulative);
            this.groupBox1.Controls.Add(this.txtfarmer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 228);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Farmer Details";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.collectionsDateDataGridViewTextBoxColumn,
            this.collectiontimeDataGridViewTextBoxColumn,
            this.collectionNumberDataGridViewTextBoxColumn,
            this.coffeeTypeDataGridViewTextBoxColumn,
            this.kgCollectedDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.daily_Collections_DetailsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(349, 135);
            this.dataGridView1.TabIndex = 7;
            // 
            // viewcummulative
            // 
            this.viewcummulative.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewcummulative.Location = new System.Drawing.Point(182, 206);
            this.viewcummulative.Name = "viewcummulative";
            this.viewcummulative.Size = new System.Drawing.Size(175, 20);
            this.viewcummulative.TabIndex = 5;
            this.viewcummulative.Text = "Cummulative";
            this.viewcummulative.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // txttotal
            // 
            this.txttotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotal.Location = new System.Drawing.Point(515, 392);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(178, 20);
            this.txttotal.TabIndex = 2;
            this.txttotal.Text = "Total";
            this.txttotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // viewfarmername
            // 
            this.viewfarmername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewfarmername.Location = new System.Drawing.Point(417, 12);
            this.viewfarmername.Name = "viewfarmername";
            this.viewfarmername.Size = new System.Drawing.Size(276, 39);
            this.viewfarmername.TabIndex = 2;
            this.viewfarmername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(418, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "KG";
            // 
            // txtkg
            // 
            this.txtkg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtkg.Location = new System.Drawing.Point(420, 103);
            this.txtkg.Name = "txtkg";
            this.txtkg.Size = new System.Drawing.Size(273, 30);
            this.txtkg.TabIndex = 1;
            this.txtkg.TextChanged += new System.EventHandler(this.txtkg_TextChanged);
            this.txtkg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtkg_KeyPress);
            this.txtkg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OtherControl_KeyUp);
            this.txtkg.Leave += new System.EventHandler(this.txtkg_Leave);
            // 
            // btnprocess
            // 
            this.btnprocess.BackColor = System.Drawing.SystemColors.Control;
            this.btnprocess.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprocess.Location = new System.Drawing.Point(420, 168);
            this.btnprocess.Name = "btnprocess";
            this.btnprocess.Size = new System.Drawing.Size(273, 72);
            this.btnprocess.TabIndex = 2;
            this.btnprocess.Text = "Post";
            this.btnprocess.UseVisualStyleBackColor = false;
            this.btnprocess.Click += new System.EventHandler(this.button2_Click);
            this.btnprocess.Enter += new System.EventHandler(this.btnprocess_Enter);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnopenport
            // 
            this.btnopenport.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.btnopenport.Location = new System.Drawing.Point(617, 77);
            this.btnopenport.Name = "btnopenport";
            this.btnopenport.Size = new System.Drawing.Size(76, 23);
            this.btnopenport.TabIndex = 4;
            this.btnopenport.Text = "Open port";
            this.btnopenport.UseVisualStyleBackColor = true;
            this.btnopenport.Click += new System.EventHandler(this.btnopenport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 189);
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
            this.button2.Location = new System.Drawing.Point(472, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(10, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Zero";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Processed,
            this.farmersNumberDataGridViewTextBoxColumn,
            this.farmersNameDataGridViewTextBoxColumn,
            this.collectionsDateDataGridViewTextBoxColumn1,
            this.collectiontimeDataGridViewTextBoxColumn1,
            this.collectionNumberDataGridViewTextBoxColumn1,
            this.coffeeTypeDataGridViewTextBoxColumn1,
            this.kgCollectedDataGridViewTextBoxColumn1,
            this.sentDataGridViewTextBoxColumn,
            this.cummDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.bindingSource1;
            this.dataGridView2.Location = new System.Drawing.Point(21, 261);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(672, 125);
            this.dataGridView2.TabIndex = 6;
            // 
            // Processed
            // 
            this.Processed.DataPropertyName = "Cancelled";
            this.Processed.HeaderText = "Cancelled";
            this.Processed.Name = "Processed";
            this.Processed.ReadOnly = true;
            this.Processed.Width = 50;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(21, 392);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Reprint Receipt";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Reprint);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(254, 392);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(157, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Cancel Receipt";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(617, 139);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(75, 23);
            this.btnManual.TabIndex = 8;
            this.btnManual.Text = "Manual";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // farmersNumberDataGridViewTextBoxColumn
            // 
            this.farmersNumberDataGridViewTextBoxColumn.DataPropertyName = "Farmers_Number";
            this.farmersNumberDataGridViewTextBoxColumn.HeaderText = "Farmers No";
            this.farmersNumberDataGridViewTextBoxColumn.Name = "farmersNumberDataGridViewTextBoxColumn";
            this.farmersNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // farmersNameDataGridViewTextBoxColumn
            // 
            this.farmersNameDataGridViewTextBoxColumn.DataPropertyName = "Farmers_Name";
            this.farmersNameDataGridViewTextBoxColumn.HeaderText = "Farmers_Name";
            this.farmersNameDataGridViewTextBoxColumn.Name = "farmersNameDataGridViewTextBoxColumn";
            this.farmersNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // collectionsDateDataGridViewTextBoxColumn1
            // 
            this.collectionsDateDataGridViewTextBoxColumn1.DataPropertyName = "Collections_Date";
            this.collectionsDateDataGridViewTextBoxColumn1.HeaderText = "Date";
            this.collectionsDateDataGridViewTextBoxColumn1.Name = "collectionsDateDataGridViewTextBoxColumn1";
            this.collectionsDateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // collectiontimeDataGridViewTextBoxColumn1
            // 
            this.collectiontimeDataGridViewTextBoxColumn1.DataPropertyName = "Collection_time";
            this.collectiontimeDataGridViewTextBoxColumn1.HeaderText = "Time";
            this.collectiontimeDataGridViewTextBoxColumn1.Name = "collectiontimeDataGridViewTextBoxColumn1";
            this.collectiontimeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // collectionNumberDataGridViewTextBoxColumn1
            // 
            this.collectionNumberDataGridViewTextBoxColumn1.DataPropertyName = "Collection_Number";
            this.collectionNumberDataGridViewTextBoxColumn1.HeaderText = "Collection_No";
            this.collectionNumberDataGridViewTextBoxColumn1.Name = "collectionNumberDataGridViewTextBoxColumn1";
            this.collectionNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // coffeeTypeDataGridViewTextBoxColumn1
            // 
            this.coffeeTypeDataGridViewTextBoxColumn1.DataPropertyName = "Coffee_Type";
            this.coffeeTypeDataGridViewTextBoxColumn1.HeaderText = "Coffee Type";
            this.coffeeTypeDataGridViewTextBoxColumn1.Name = "coffeeTypeDataGridViewTextBoxColumn1";
            this.coffeeTypeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // kgCollectedDataGridViewTextBoxColumn1
            // 
            this.kgCollectedDataGridViewTextBoxColumn1.DataPropertyName = "Kg__Collected";
            this.kgCollectedDataGridViewTextBoxColumn1.HeaderText = "Kg";
            this.kgCollectedDataGridViewTextBoxColumn1.Name = "kgCollectedDataGridViewTextBoxColumn1";
            this.kgCollectedDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // sentDataGridViewTextBoxColumn
            // 
            this.sentDataGridViewTextBoxColumn.DataPropertyName = "Sent";
            this.sentDataGridViewTextBoxColumn.HeaderText = "Sent";
            this.sentDataGridViewTextBoxColumn.Name = "sentDataGridViewTextBoxColumn";
            this.sentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cummDataGridViewTextBoxColumn
            // 
            this.cummDataGridViewTextBoxColumn.DataPropertyName = "Cumm";
            this.cummDataGridViewTextBoxColumn.HeaderText = "Cumm";
            this.cummDataGridViewTextBoxColumn.Name = "cummDataGridViewTextBoxColumn";
            this.cummDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Weigh.Daily_Collections_Detail);
            // 
            // collectionsDateDataGridViewTextBoxColumn
            // 
            this.collectionsDateDataGridViewTextBoxColumn.DataPropertyName = "Collections_Date";
            this.collectionsDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.collectionsDateDataGridViewTextBoxColumn.Name = "collectionsDateDataGridViewTextBoxColumn";
            this.collectionsDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.collectionsDateDataGridViewTextBoxColumn.Width = 70;
            // 
            // collectiontimeDataGridViewTextBoxColumn
            // 
            this.collectiontimeDataGridViewTextBoxColumn.DataPropertyName = "Collection_time";
            this.collectiontimeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.collectiontimeDataGridViewTextBoxColumn.Name = "collectiontimeDataGridViewTextBoxColumn";
            this.collectiontimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.collectiontimeDataGridViewTextBoxColumn.Width = 60;
            // 
            // collectionNumberDataGridViewTextBoxColumn
            // 
            this.collectionNumberDataGridViewTextBoxColumn.DataPropertyName = "Collection_Number";
            this.collectionNumberDataGridViewTextBoxColumn.HeaderText = "Collection No";
            this.collectionNumberDataGridViewTextBoxColumn.Name = "collectionNumberDataGridViewTextBoxColumn";
            this.collectionNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // coffeeTypeDataGridViewTextBoxColumn
            // 
            this.coffeeTypeDataGridViewTextBoxColumn.DataPropertyName = "Coffee_Type";
            this.coffeeTypeDataGridViewTextBoxColumn.HeaderText = "Coffee";
            this.coffeeTypeDataGridViewTextBoxColumn.Name = "coffeeTypeDataGridViewTextBoxColumn";
            this.coffeeTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.coffeeTypeDataGridViewTextBoxColumn.Width = 70;
            // 
            // kgCollectedDataGridViewTextBoxColumn
            // 
            this.kgCollectedDataGridViewTextBoxColumn.DataPropertyName = "Kg__Collected";
            this.kgCollectedDataGridViewTextBoxColumn.HeaderText = "Kg";
            this.kgCollectedDataGridViewTextBoxColumn.Name = "kgCollectedDataGridViewTextBoxColumn";
            this.kgCollectedDataGridViewTextBoxColumn.ReadOnly = true;
            this.kgCollectedDataGridViewTextBoxColumn.Width = 50;
            // 
            // daily_Collections_DetailsBindingSource
            // 
            this.daily_Collections_DetailsBindingSource.DataSource = typeof(Weigh.Daily_Collections_Detail);
            // 
            // Collection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 432);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.btnopenport);
            this.Controls.Add(this.viewfarmername);
            this.Controls.Add(this.btnprocess);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtkg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "Collection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Collection_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Collection_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.daily_Collections_DetailsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label viewcummulative;
        private System.Windows.Forms.Label viewfarmername;
        private System.Windows.Forms.Label txttotal;
        private System.Windows.Forms.TextBox txtfarmer;
        private System.Windows.Forms.BindingSource daily_Collections_DetailsBindingSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtkg;
        private System.Windows.Forms.Button btnprocess;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnopenport;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectionsDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectiontimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectionNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coffeeTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgCollectedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Processed;
        private System.Windows.Forms.DataGridViewTextBoxColumn farmersNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn farmersNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectionsDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectiontimeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectionNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn coffeeTypeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kgCollectedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cummDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnManual;
    }
}