using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authenticator
{
    public partial class FormEditRecordName : Form
    {
        public FormEditRecordName()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public string NameEditor {
            
            get {
                return textBoxName.Text;
            }

            set { 
                textBoxName.Text = value;
            }

        }

        private void FormEditRecordName_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                this.DialogResult = DialogResult.None;
                textBoxName.Focus();
            }
        }
    }
}
