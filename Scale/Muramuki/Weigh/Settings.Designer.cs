namespace Weigh
{
    partial class Settings
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
            System.Windows.Forms.Label baudRateLabel;
            System.Windows.Forms.Label com_PortLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label current_cropLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.settingBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.settingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.cmbcoffetype = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.current_cropComboBox = new System.Windows.Forms.ComboBox();
            this.txtserver = new System.Windows.Forms.TextBox();
            this.txtfactory = new System.Windows.Forms.TextBox();
            this.cmbprinter = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.baudRateSpinEdit = new System.Windows.Forms.TextBox();
            this.com_PortTextEdit = new System.Windows.Forms.ComboBox();
            baudRateLabel = new System.Windows.Forms.Label();
            com_PortLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            current_cropLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.settingBindingNavigator)).BeginInit();
            this.settingBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // baudRateLabel
            // 
            baudRateLabel.AutoSize = true;
            baudRateLabel.Location = new System.Drawing.Point(6, 104);
            baudRateLabel.Name = "baudRateLabel";
            baudRateLabel.Size = new System.Drawing.Size(61, 13);
            baudRateLabel.TabIndex = 1;
            baudRateLabel.Text = "Baud Rate:";
            // 
            // com_PortLabel
            // 
            com_PortLabel.AutoSize = true;
            com_PortLabel.Location = new System.Drawing.Point(6, 68);
            com_PortLabel.Name = "com_PortLabel";
            com_PortLabel.Size = new System.Drawing.Size(53, 13);
            com_PortLabel.TabIndex = 3;
            com_PortLabel.Text = "Com Port:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(11, 48);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(55, 13);
            label1.TabIndex = 1;
            label1.Text = "Coffe type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(11, 22);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 13);
            label2.TabIndex = 3;
            label2.Text = "Factory";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 31);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(37, 13);
            label3.TabIndex = 1;
            label3.Text = "Printer";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(11, 74);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(52, 13);
            label4.TabIndex = 3;
            label4.Text = "Server url";
            // 
            // current_cropLabel
            // 
            current_cropLabel.AutoSize = true;
            current_cropLabel.Location = new System.Drawing.Point(9, 101);
            current_cropLabel.Name = "current_cropLabel";
            current_cropLabel.Size = new System.Drawing.Size(68, 13);
            current_cropLabel.TabIndex = 9;
            current_cropLabel.Text = "Current crop:";
            // 
            // settingBindingNavigator
            // 
            this.settingBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.settingBindingNavigator.BindingSource = this.settingBindingSource;
            this.settingBindingNavigator.CountItem = null;
            this.settingBindingNavigator.DeleteItem = null;
            this.settingBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.settingBindingNavigatorSaveItem});
            this.settingBindingNavigator.Location = new System.Drawing.Point(0, 351);
            this.settingBindingNavigator.MoveFirstItem = null;
            this.settingBindingNavigator.MoveLastItem = null;
            this.settingBindingNavigator.MoveNextItem = null;
            this.settingBindingNavigator.MovePreviousItem = null;
            this.settingBindingNavigator.Name = "settingBindingNavigator";
            this.settingBindingNavigator.PositionItem = null;
            this.settingBindingNavigator.Size = new System.Drawing.Size(561, 25);
            this.settingBindingNavigator.TabIndex = 0;
            this.settingBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // settingBindingSource
            // 
            this.settingBindingSource.DataSource = typeof(Weigh.Setting);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // settingBindingNavigatorSaveItem
            // 
            this.settingBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("settingBindingNavigatorSaveItem.Image")));
            this.settingBindingNavigatorSaveItem.Name = "settingBindingNavigatorSaveItem";
            this.settingBindingNavigatorSaveItem.Size = new System.Drawing.Size(96, 22);
            this.settingBindingNavigatorSaveItem.Text = "Save Settings";
            this.settingBindingNavigatorSaveItem.Click += new System.EventHandler(this.settingBindingNavigatorSaveItem_Click);
            // 
            // cmbcoffetype
            // 
            this.cmbcoffetype.FormattingEnabled = true;
            this.cmbcoffetype.Items.AddRange(new object[] {
            "Cherry",
            "Mbuni"});
            this.cmbcoffetype.Location = new System.Drawing.Point(78, 45);
            this.cmbcoffetype.Name = "cmbcoffetype";
            this.cmbcoffetype.Size = new System.Drawing.Size(351, 21);
            this.cmbcoffetype.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkEdit1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(current_cropLabel);
            this.groupBox1.Controls.Add(this.current_cropComboBox);
            this.groupBox1.Controls.Add(this.txtserver);
            this.groupBox1.Controls.Add(this.txtfactory);
            this.groupBox1.Controls.Add(this.cmbcoffetype);
            this.groupBox1.Controls.Add(label4);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Location = new System.Drawing.Point(53, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 163);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Factory settings";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(6, 125);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Load factory members only";
            this.checkEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkEdit1.Size = new System.Drawing.Size(156, 19);
            this.checkEdit1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Image = global::Weigh.Properties.Resources.add;
            this.button1.Location = new System.Drawing.Point(431, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // current_cropComboBox
            // 
            this.current_cropComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.settingBindingSource, "Current_crop", true));
            this.current_cropComboBox.DisplayMember = "Crops";
            this.current_cropComboBox.FormattingEnabled = true;
            this.current_cropComboBox.Location = new System.Drawing.Point(78, 98);
            this.current_cropComboBox.Name = "current_cropComboBox";
            this.current_cropComboBox.Size = new System.Drawing.Size(351, 21);
            this.current_cropComboBox.TabIndex = 10;
            this.current_cropComboBox.SelectedIndexChanged += new System.EventHandler(this.current_cropComboBox_SelectedIndexChanged);
            // 
            // txtserver
            // 
            this.txtserver.Location = new System.Drawing.Point(78, 72);
            this.txtserver.Name = "txtserver";
            this.txtserver.Size = new System.Drawing.Size(351, 20);
            this.txtserver.TabIndex = 5;
            // 
            // txtfactory
            // 
            this.txtfactory.Location = new System.Drawing.Point(78, 19);
            this.txtfactory.Name = "txtfactory";
            this.txtfactory.Size = new System.Drawing.Size(351, 20);
            this.txtfactory.TabIndex = 4;
            // 
            // cmbprinter
            // 
            this.cmbprinter.FormattingEnabled = true;
            this.cmbprinter.Location = new System.Drawing.Point(78, 28);
            this.cmbprinter.Name = "cmbprinter";
            this.cmbprinter.Size = new System.Drawing.Size(351, 21);
            this.cmbprinter.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.baudRateSpinEdit);
            this.groupBox2.Controls.Add(this.com_PortTextEdit);
            this.groupBox2.Controls.Add(this.cmbprinter);
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Controls.Add(com_PortLabel);
            this.groupBox2.Controls.Add(baudRateLabel);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(53, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 134);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device settings";
            // 
            // baudRateSpinEdit
            // 
            this.baudRateSpinEdit.Location = new System.Drawing.Point(78, 101);
            this.baudRateSpinEdit.Name = "baudRateSpinEdit";
            this.baudRateSpinEdit.Size = new System.Drawing.Size(351, 20);
            this.baudRateSpinEdit.TabIndex = 5;
            // 
            // com_PortTextEdit
            // 
            this.com_PortTextEdit.FormattingEnabled = true;
            this.com_PortTextEdit.Location = new System.Drawing.Point(78, 65);
            this.com_PortTextEdit.Name = "com_PortTextEdit";
            this.com_PortTextEdit.Size = new System.Drawing.Size(351, 21);
            this.com_PortTextEdit.TabIndex = 4;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 376);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.settingBindingNavigator);
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.settingBindingNavigator)).EndInit();
            this.settingBindingNavigator.ResumeLayout(false);
            this.settingBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource settingBindingSource;
        private System.Windows.Forms.BindingNavigator settingBindingNavigator;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton settingBindingNavigatorSaveItem;
        private System.Windows.Forms.ComboBox cmbcoffetype;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbprinter;
        private System.Windows.Forms.TextBox txtserver;
        private System.Windows.Forms.TextBox txtfactory;
        private System.Windows.Forms.TextBox baudRateSpinEdit;
        private System.Windows.Forms.ComboBox com_PortTextEdit;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox current_cropComboBox;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}