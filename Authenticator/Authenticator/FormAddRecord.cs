using Newtonsoft.Json.Linq;
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
    public partial class FormAddRecord : Form
    {
        public FormAddRecord()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public string InputData() {

            return textBoxOTP.Text;
        }

        private void FormAddKey_Load(object sender, EventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxOTP.Text) || !GlobalClass.AuDataBase.AddOTPURL(textBoxOTP.Text))
            {
                this.DialogResult = DialogResult.None;
                textBoxOTP.BackColor = Color.LightCoral;
                textBoxOTP.Focus();
            }
        }

        private void TextBoxOTP_TextChanged(object sender, EventArgs e)
        {
            textBoxOTP.BackColor = Color.White;
        }
    }

}
