namespace Authenticator
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelDash = new System.Windows.Forms.Panel();
            this.buttonOptions = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.panelWeb = new System.Windows.Forms.Panel();
            this.timerChange = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelDash.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDash
            // 
            this.panelDash.Controls.Add(this.buttonOptions);
            this.panelDash.Controls.Add(this.buttonAdd);
            this.panelDash.Controls.Add(this.buttonSave);
            this.panelDash.Controls.Add(this.buttonOpen);
            this.panelDash.Controls.Add(this.textBoxFilter);
            this.panelDash.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDash.Location = new System.Drawing.Point(0, 0);
            this.panelDash.Name = "panelDash";
            this.panelDash.Size = new System.Drawing.Size(484, 75);
            this.panelDash.TabIndex = 0;
            // 
            // buttonOptions
            // 
            this.buttonOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOptions.Image = global::Authenticator.Resource1.dots_32x;
            this.buttonOptions.Location = new System.Drawing.Point(436, 10);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(36, 36);
            this.buttonOptions.TabIndex = 5;
            this.buttonOptions.UseVisualStyleBackColor = true;
            this.buttonOptions.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonOptions_MouseUp);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Image = global::Authenticator.Resource1.Add_32x;
            this.buttonAdd.Location = new System.Drawing.Point(394, 10);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(36, 36);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Image = global::Authenticator.Resource1.Save_32x;
            this.buttonSave.Location = new System.Drawing.Point(54, 11);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(36, 36);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Image = global::Authenticator.Resource1.OpenFileDialog_32x;
            this.buttonOpen.Location = new System.Drawing.Point(12, 10);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(36, 36);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxFilter.Location = new System.Drawing.Point(0, 52);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(484, 23);
            this.textBoxFilter.TabIndex = 3;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.TextBoxFilter_TextChanged);
            // 
            // panelWeb
            // 
            this.panelWeb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWeb.Location = new System.Drawing.Point(0, 75);
            this.panelWeb.Name = "panelWeb";
            this.panelWeb.Size = new System.Drawing.Size(484, 486);
            this.panelWeb.TabIndex = 6;
            // 
            // timerChange
            // 
            this.timerChange.Enabled = true;
            this.timerChange.Interval = 500;
            this.timerChange.Tick += new System.EventHandler(this.TimerChange_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.panelWeb);
            this.Controls.Add(this.panelDash);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "FormMain";
            this.Text = "Authenticator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelDash.ResumeLayout(false);
            this.panelDash.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelDash;
        private Panel panelWeb;
        private System.Windows.Forms.Timer timerChange;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textBoxFilter;
        private Button buttonOpen;
        private Button buttonSave;
        private Button buttonOptions;
        private Button buttonAdd;
    }
}