namespace Authenticator
{
    partial class FormAddRecord
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBoxOTP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonUrlWizard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point(419, 162);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 24);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // textBoxOTP
            // 
            this.textBoxOTP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOTP.Location = new System.Drawing.Point(12, 39);
            this.textBoxOTP.Multiline = true;
            this.textBoxOTP.Name = "textBoxOTP";
            this.textBoxOTP.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOTP.Size = new System.Drawing.Size(488, 117);
            this.textBoxOTP.TabIndex = 1;
            this.textBoxOTP.TextChanged += new System.EventHandler(this.TextBoxOTP_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter URL of otpauth or otpauth-migration:";
            // 
            // buttonUrlWizard
            // 
            this.buttonUrlWizard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUrlWizard.Location = new System.Drawing.Point(12, 162);
            this.buttonUrlWizard.Name = "buttonUrlWizard";
            this.buttonUrlWizard.Size = new System.Drawing.Size(97, 24);
            this.buttonUrlWizard.TabIndex = 4;
            this.buttonUrlWizard.Text = "URL Wizard ...";
            this.buttonUrlWizard.UseVisualStyleBackColor = true;
            this.buttonUrlWizard.Click += new System.EventHandler(this.ButtonUrlWizard_Click);
            // 
            // FormAddRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 198);
            this.Controls.Add(this.buttonUrlWizard);
            this.Controls.Add(this.textBoxOTP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormAddRecord";
            this.Load += new System.EventHandler(this.FormAddKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnAdd;
        private TextBox textBoxOTP;
        private Label label2;
        private Button buttonUrlWizard;
    }
}