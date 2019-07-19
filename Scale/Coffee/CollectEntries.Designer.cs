namespace Coffee
{
    partial class CollectEntries
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
            System.Windows.Forms.Label coffee_TypeLabel;
            System.Windows.Forms.Label collection_NumberLabel;
            System.Windows.Forms.Label collection_timeLabel;
            System.Windows.Forms.Label cropLabel;
            System.Windows.Forms.Label farmers_NameLabel;
            System.Windows.Forms.Label farmers_NumberLabel;
            System.Windows.Forms.Label kg__CollectedLabel;
            System.Windows.Forms.Label userLabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectEntries));
            this.daily_Collections_DetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coffee_TypeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.collection_NumberTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.collection_timeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.cropTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.farmers_NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.farmers_NumberTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.kg__CollectedSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.userTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.farmerlookup = new DevExpress.XtraEditors.LookUpEdit();
            this.farmerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnok = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            coffee_TypeLabel = new System.Windows.Forms.Label();
            collection_NumberLabel = new System.Windows.Forms.Label();
            collection_timeLabel = new System.Windows.Forms.Label();
            cropLabel = new System.Windows.Forms.Label();
            farmers_NameLabel = new System.Windows.Forms.Label();
            farmers_NumberLabel = new System.Windows.Forms.Label();
            kg__CollectedLabel = new System.Windows.Forms.Label();
            userLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.daily_Collections_DetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coffee_TypeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collection_NumberTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collection_timeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collection_timeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cropTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.farmers_NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.farmers_NumberTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kg__CollectedSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.farmerlookup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.farmerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // coffee_TypeLabel
            // 
            coffee_TypeLabel.AutoSize = true;
            coffee_TypeLabel.Location = new System.Drawing.Point(7, 56);
            coffee_TypeLabel.Name = "coffee_TypeLabel";
            coffee_TypeLabel.Size = new System.Drawing.Size(71, 13);
            coffee_TypeLabel.TabIndex = 5;
            coffee_TypeLabel.Text = "Coffee Type:";
            // 
            // collection_NumberLabel
            // 
            collection_NumberLabel.AutoSize = true;
            collection_NumberLabel.Location = new System.Drawing.Point(7, 30);
            collection_NumberLabel.Name = "collection_NumberLabel";
            collection_NumberLabel.Size = new System.Drawing.Size(97, 13);
            collection_NumberLabel.TabIndex = 9;
            collection_NumberLabel.Text = "Collection Number:";
            // 
            // collection_timeLabel
            // 
            collection_timeLabel.AutoSize = true;
            collection_timeLabel.Location = new System.Drawing.Point(7, 82);
            collection_timeLabel.Name = "collection_timeLabel";
            collection_timeLabel.Size = new System.Drawing.Size(80, 13);
            collection_timeLabel.TabIndex = 11;
            collection_timeLabel.Text = "Collection time:";
            // 
            // cropLabel
            // 
            cropLabel.AutoSize = true;
            cropLabel.Location = new System.Drawing.Point(7, 108);
            cropLabel.Name = "cropLabel";
            cropLabel.Size = new System.Drawing.Size(34, 13);
            cropLabel.TabIndex = 17;
            cropLabel.Text = "Crop:";
            // 
            // farmers_NameLabel
            // 
            farmers_NameLabel.AutoSize = true;
            farmers_NameLabel.Location = new System.Drawing.Point(283, 26);
            farmers_NameLabel.Name = "farmers_NameLabel";
            farmers_NameLabel.Size = new System.Drawing.Size(80, 13);
            farmers_NameLabel.TabIndex = 23;
            farmers_NameLabel.Text = "Farmers Name:";
            // 
            // farmers_NumberLabel
            // 
            farmers_NumberLabel.AutoSize = true;
            farmers_NumberLabel.Location = new System.Drawing.Point(283, 52);
            farmers_NumberLabel.Name = "farmers_NumberLabel";
            farmers_NumberLabel.Size = new System.Drawing.Size(90, 13);
            farmers_NumberLabel.TabIndex = 25;
            farmers_NumberLabel.Text = "Farmers Number:";
            // 
            // kg__CollectedLabel
            // 
            kg__CollectedLabel.AutoSize = true;
            kg__CollectedLabel.Location = new System.Drawing.Point(283, 78);
            kg__CollectedLabel.Name = "kg__CollectedLabel";
            kg__CollectedLabel.Size = new System.Drawing.Size(70, 13);
            kg__CollectedLabel.TabIndex = 31;
            kg__CollectedLabel.Text = "Kg Collected:";
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Location = new System.Drawing.Point(283, 107);
            userLabel.Name = "userLabel";
            userLabel.Size = new System.Drawing.Size(33, 13);
            userLabel.TabIndex = 43;
            userLabel.Text = "User:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 26);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 13);
            label1.TabIndex = 18;
            label1.Text = "Farmer No";
            // 
            // daily_Collections_DetailBindingSource
            // 
            this.daily_Collections_DetailBindingSource.DataSource = typeof(Coffee.Daily_Collections_Detail);
            // 
            // coffee_TypeTextEdit
            // 
            this.coffee_TypeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.daily_Collections_DetailBindingSource, "Coffee_Type", true));
            this.coffee_TypeTextEdit.Location = new System.Drawing.Point(109, 53);
            this.coffee_TypeTextEdit.Name = "coffee_TypeTextEdit";
            this.coffee_TypeTextEdit.Size = new System.Drawing.Size(156, 20);
            this.coffee_TypeTextEdit.TabIndex = 6;
            // 
            // collection_NumberTextEdit
            // 
            this.collection_NumberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.daily_Collections_DetailBindingSource, "Collection_Number", true));
            this.collection_NumberTextEdit.Location = new System.Drawing.Point(109, 27);
            this.collection_NumberTextEdit.Name = "collection_NumberTextEdit";
            this.collection_NumberTextEdit.Size = new System.Drawing.Size(156, 20);
            this.collection_NumberTextEdit.TabIndex = 10;
            // 
            // collection_timeDateEdit
            // 
            this.collection_timeDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.daily_Collections_DetailBindingSource, "Collection_time", true));
            this.collection_timeDateEdit.EditValue = null;
            this.collection_timeDateEdit.Location = new System.Drawing.Point(109, 79);
            this.collection_timeDateEdit.Name = "collection_timeDateEdit";
            this.collection_timeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.collection_timeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.collection_timeDateEdit.Size = new System.Drawing.Size(156, 20);
            this.collection_timeDateEdit.TabIndex = 12;
            // 
            // cropTextEdit
            // 
            this.cropTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.daily_Collections_DetailBindingSource, "Crop", true));
            this.cropTextEdit.Location = new System.Drawing.Point(109, 105);
            this.cropTextEdit.Name = "cropTextEdit";
            this.cropTextEdit.Size = new System.Drawing.Size(156, 20);
            this.cropTextEdit.TabIndex = 18;
            // 
            // farmers_NameTextEdit
            // 
            this.farmers_NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.daily_Collections_DetailBindingSource, "Farmers_Name", true));
            this.farmers_NameTextEdit.Location = new System.Drawing.Point(385, 23);
            this.farmers_NameTextEdit.Name = "farmers_NameTextEdit";
            this.farmers_NameTextEdit.Size = new System.Drawing.Size(176, 20);
            this.farmers_NameTextEdit.TabIndex = 24;
            // 
            // farmers_NumberTextEdit
            // 
            this.farmers_NumberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.daily_Collections_DetailBindingSource, "Farmers_Number", true));
            this.farmers_NumberTextEdit.Location = new System.Drawing.Point(385, 49);
            this.farmers_NumberTextEdit.Name = "farmers_NumberTextEdit";
            this.farmers_NumberTextEdit.Size = new System.Drawing.Size(176, 20);
            this.farmers_NumberTextEdit.TabIndex = 26;
            // 
            // kg__CollectedSpinEdit
            // 
            this.kg__CollectedSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.daily_Collections_DetailBindingSource, "Kg__Collected", true));
            this.kg__CollectedSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.kg__CollectedSpinEdit.Location = new System.Drawing.Point(385, 75);
            this.kg__CollectedSpinEdit.Name = "kg__CollectedSpinEdit";
            this.kg__CollectedSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.kg__CollectedSpinEdit.Size = new System.Drawing.Size(176, 20);
            this.kg__CollectedSpinEdit.TabIndex = 32;
            // 
            // userTextEdit
            // 
            this.userTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.daily_Collections_DetailBindingSource, "User", true));
            this.userTextEdit.Location = new System.Drawing.Point(385, 104);
            this.userTextEdit.Name = "userTextEdit";
            this.userTextEdit.Size = new System.Drawing.Size(176, 20);
            this.userTextEdit.TabIndex = 44;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(coffee_TypeLabel);
            this.groupControl1.Controls.Add(this.coffee_TypeTextEdit);
            this.groupControl1.Controls.Add(collection_NumberLabel);
            this.groupControl1.Controls.Add(this.collection_NumberTextEdit);
            this.groupControl1.Controls.Add(collection_timeLabel);
            this.groupControl1.Controls.Add(this.collection_timeDateEdit);
            this.groupControl1.Controls.Add(cropLabel);
            this.groupControl1.Controls.Add(this.cropTextEdit);
            this.groupControl1.Controls.Add(farmers_NameLabel);
            this.groupControl1.Controls.Add(this.farmers_NameTextEdit);
            this.groupControl1.Controls.Add(farmers_NumberLabel);
            this.groupControl1.Controls.Add(this.farmers_NumberTextEdit);
            this.groupControl1.Controls.Add(kg__CollectedLabel);
            this.groupControl1.Controls.Add(this.kg__CollectedSpinEdit);
            this.groupControl1.Controls.Add(userLabel);
            this.groupControl1.Controls.Add(this.userTextEdit);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Enabled = false;
            this.groupControl1.Location = new System.Drawing.Point(0, 141);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(591, 140);
            this.groupControl1.TabIndex = 45;
            this.groupControl1.Text = "Collection to correct";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(label1);
            this.groupControl2.Controls.Add(this.farmerlookup);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl2.Location = new System.Drawing.Point(0, 281);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(591, 61);
            this.groupControl2.TabIndex = 46;
            this.groupControl2.Text = "Correct Details";
            // 
            // farmerlookup
            // 
            this.farmerlookup.Location = new System.Drawing.Point(109, 23);
            this.farmerlookup.Name = "farmerlookup";
            this.farmerlookup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.farmerlookup.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("No", "No", 23, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name", 37, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Cum_Cherry", "Cum Cherry", 70, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Cum_Mbuni", "Cum Mbuni", 65, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.farmerlookup.Properties.DataSource = this.farmerBindingSource;
            this.farmerlookup.Properties.DisplayMember = "Name";
            this.farmerlookup.Properties.NullText = "Select Farmer";
            this.farmerlookup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.farmerlookup.Properties.ValueMember = "No";
            this.farmerlookup.Size = new System.Drawing.Size(156, 20);
            this.farmerlookup.TabIndex = 0;
            // 
            // farmerBindingSource
            // 
            this.farmerBindingSource.DataSource = typeof(Coffee.Farmer);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnok,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(591, 141);
            // 
            // btnok
            // 
            this.btnok.Caption = "&Correct";
            this.btnok.Glyph = ((System.Drawing.Image)(resources.GetObject("btnok.Glyph")));
            this.btnok.Id = 1;
            this.btnok.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnok.LargeGlyph")));
            this.btnok.Name = "btnok";
            this.btnok.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnok_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "&Cancel";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Actions";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnok);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Edit";
            // 
            // CollectEntries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 342);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CollectEntries";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Collect Entries";
            ((System.ComponentModel.ISupportInitialize)(this.daily_Collections_DetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coffee_TypeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.collection_NumberTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.collection_timeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.collection_timeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cropTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.farmers_NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.farmers_NumberTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kg__CollectedSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.farmerlookup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.farmerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource daily_Collections_DetailBindingSource;
        private DevExpress.XtraEditors.TextEdit coffee_TypeTextEdit;
        private DevExpress.XtraEditors.TextEdit collection_NumberTextEdit;
        private DevExpress.XtraEditors.DateEdit collection_timeDateEdit;
        private DevExpress.XtraEditors.TextEdit cropTextEdit;
        private DevExpress.XtraEditors.TextEdit farmers_NameTextEdit;
        private DevExpress.XtraEditors.TextEdit farmers_NumberTextEdit;
        private DevExpress.XtraEditors.SpinEdit kg__CollectedSpinEdit;
        private DevExpress.XtraEditors.TextEdit userTextEdit;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LookUpEdit farmerlookup;
        private System.Windows.Forms.BindingSource farmerBindingSource;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnok;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}