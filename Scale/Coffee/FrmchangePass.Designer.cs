namespace Coffee
{
    partial class FrmchangePass
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
            this.btnchange = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnew = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtconfirm = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnchange
            // 
            this.btnchange.Location = new System.Drawing.Point(150, 76);
            this.btnchange.Name = "btnchange";
            this.btnchange.Size = new System.Drawing.Size(75, 23);
            this.btnchange.TabIndex = 2;
            this.btnchange.Text = "Change Pass";
            this.btnchange.UseVisualStyleBackColor = true;
            this.btnchange.Click += new System.EventHandler(this.btnchange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Password";
            // 
            // txtnew
            // 
            this.txtnew.Location = new System.Drawing.Point(92, 24);
            this.txtnew.Name = "txtnew";
            this.txtnew.PasswordChar = '*';
            this.txtnew.Size = new System.Drawing.Size(133, 20);
            this.txtnew.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirm";
            // 
            // txtconfirm
            // 
            this.txtconfirm.Location = new System.Drawing.Point(92, 50);
            this.txtconfirm.Name = "txtconfirm";
            this.txtconfirm.PasswordChar = '*';
            this.txtconfirm.Size = new System.Drawing.Size(133, 20);
            this.txtconfirm.TabIndex = 1;
            // 
            // FrmchangePass
            // 
            this.AcceptButton = this.btnchange;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 143);
            this.Controls.Add(this.txtconfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtnew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnchange);
            this.Name = "FrmchangePass";
            this.Text = "ChangePass";
            this.Load += new System.EventHandler(this.FrmchangePass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnchange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtconfirm;
    }
}