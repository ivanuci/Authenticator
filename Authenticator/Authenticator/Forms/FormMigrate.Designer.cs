namespace Authenticator
{
    partial class FormMigrate
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
            this.pictureBoxQRMigrate = new System.Windows.Forms.PictureBox();
            this.textBoxOTPMigrate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRMigrate)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxQRMigrate
            // 
            this.pictureBoxQRMigrate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxQRMigrate.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxQRMigrate.Name = "pictureBoxQRMigrate";
            this.pictureBoxQRMigrate.Size = new System.Drawing.Size(392, 342);
            this.pictureBoxQRMigrate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxQRMigrate.TabIndex = 0;
            this.pictureBoxQRMigrate.TabStop = false;
            // 
            // textBoxOTPMigrate
            // 
            this.textBoxOTPMigrate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOTPMigrate.Location = new System.Drawing.Point(12, 385);
            this.textBoxOTPMigrate.Multiline = true;
            this.textBoxOTPMigrate.Name = "textBoxOTPMigrate";
            this.textBoxOTPMigrate.Size = new System.Drawing.Size(392, 109);
            this.textBoxOTPMigrate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter URL of otpauth or otpauth-migration:";
            // 
            // FormMigrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 506);
            this.Controls.Add(this.textBoxOTPMigrate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBoxQRMigrate);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "FormMigrate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormMigrate";
            this.Load += new System.EventHandler(this.FormMigrate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQRMigrate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBoxQRMigrate;
        private TextBox textBoxOTPMigrate;
        private Label label2;
    }
}