namespace Weigh
{
    partial class WeighMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeighMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.farmersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todaysCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.farmersDeliveryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cummulativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.farmersToolStripMenuItem,
            this.collectToolStripMenuItem,
            this.collectionsToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.toolStripSeparator1,
            this.logOutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.fileToolStripMenuItem.Text = "Home";
            // 
            // farmersToolStripMenuItem
            // 
            this.farmersToolStripMenuItem.Name = "farmersToolStripMenuItem";
            this.farmersToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.farmersToolStripMenuItem.Text = "Farmers";
            this.farmersToolStripMenuItem.Click += new System.EventHandler(this.farmersToolStripMenuItem_Click);
            // 
            // collectToolStripMenuItem
            // 
            this.collectToolStripMenuItem.Name = "collectToolStripMenuItem";
            this.collectToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.collectToolStripMenuItem.Text = "Collect";
            this.collectToolStripMenuItem.Click += new System.EventHandler(this.collectToolStripMenuItem_Click);
            // 
            // collectionsToolStripMenuItem
            // 
            this.collectionsToolStripMenuItem.Name = "collectionsToolStripMenuItem";
            this.collectionsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.collectionsToolStripMenuItem.Text = "Collections";
            this.collectionsToolStripMenuItem.Click += new System.EventHandler(this.collectionsToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.usersToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.setupToolStripMenuItem.Text = "Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyCollectionToolStripMenuItem,
            this.todaysCollectionToolStripMenuItem,
            this.farmersDeliveryReportToolStripMenuItem,
            this.cummulativeToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // dailyCollectionToolStripMenuItem
            // 
            this.dailyCollectionToolStripMenuItem.Name = "dailyCollectionToolStripMenuItem";
            this.dailyCollectionToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.dailyCollectionToolStripMenuItem.Text = "Daily Collection";
            this.dailyCollectionToolStripMenuItem.Click += new System.EventHandler(this.dailyCollectionToolStripMenuItem_Click);
            // 
            // todaysCollectionToolStripMenuItem
            // 
            this.todaysCollectionToolStripMenuItem.Name = "todaysCollectionToolStripMenuItem";
            this.todaysCollectionToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.todaysCollectionToolStripMenuItem.Text = "Todays Collection";
            this.todaysCollectionToolStripMenuItem.Click += new System.EventHandler(this.todaysCollectionToolStripMenuItem_Click);
            // 
            // farmersDeliveryReportToolStripMenuItem
            // 
            this.farmersDeliveryReportToolStripMenuItem.Name = "farmersDeliveryReportToolStripMenuItem";
            this.farmersDeliveryReportToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.farmersDeliveryReportToolStripMenuItem.Text = "Farmers delivery report";
            this.farmersDeliveryReportToolStripMenuItem.Click += new System.EventHandler(this.farmersDeliveryReportToolStripMenuItem_Click);
            // 
            // cummulativeToolStripMenuItem
            // 
            this.cummulativeToolStripMenuItem.Name = "cummulativeToolStripMenuItem";
            this.cummulativeToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.cummulativeToolStripMenuItem.Text = "Cummulative";
            this.cummulativeToolStripMenuItem.Click += new System.EventHandler(this.cummulativeToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 298);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(760, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel1.Text = "Loading";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(30, 17);
            this.toolStripStatusLabel2.Text = "User";
            // 
            // WeighMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Weigh.Properties.Resources.logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(760, 320);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "WeighMain";
            this.Text = "Weigh";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WeighMain_FormClosing);
            this.Load += new System.EventHandler(this.Weigh_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem farmersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyCollectionToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem todaysCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem farmersDeliveryReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cummulativeToolStripMenuItem;
    }
}



