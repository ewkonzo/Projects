namespace Coffee
{
    partial class Statusbar
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtuser = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.version = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtstatus,
            this.txtuser,
            this.version});
            this.statusStrip1.Location = new System.Drawing.Point(0, 5);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(844, 30);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtstatus
            // 
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.Size = new System.Drawing.Size(76, 25);
            this.txtstatus.Text = "Loading";
            this.txtstatus.Click += new System.EventHandler(this.txtstatus_Click);
            // 
            // txtuser
            // 
            this.txtuser.Image = global::Coffee.Properties.Resources.login;
            this.txtuser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(71, 25);
            this.txtuser.Text = "User";
            this.txtuser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtuser.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(342, 9);
            this.progressBarControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.progressBarControl1.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.progressBarControl1.ShowProgressInTaskBar = true;
            this.progressBarControl1.Size = new System.Drawing.Size(222, 22);
            this.progressBarControl1.TabIndex = 2;
            // 
            // version
            // 
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(74, 25);
            this.version.Text = "[Classic]";
            this.version.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Statusbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Statusbar";
            this.Size = new System.Drawing.Size(844, 35);
            this.Load += new System.EventHandler(this.Statusbar_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel txtstatus;
        public System.Windows.Forms.ToolStripStatusLabel txtuser;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel version;
    }
}
