namespace Rice
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtuser = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtstatus,
            this.txtuser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(563, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtstatus
            // 
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.Size = new System.Drawing.Size(50, 17);
            this.txtstatus.Text = "Loading";
            this.txtstatus.Click += new System.EventHandler(this.txtstatus_Click);
            // 
            // txtuser
            // 
            this.txtuser.Image = global::Rice.Properties.Resources.login;
            this.txtuser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(46, 17);
            this.txtuser.Text = "User";
            this.txtuser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtuser.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // Statusbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Name = "Statusbar";
            this.Size = new System.Drawing.Size(563, 23);
            this.Load += new System.EventHandler(this.Statusbar_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel txtstatus;
        public System.Windows.Forms.ToolStripStatusLabel txtuser;

    }
}
