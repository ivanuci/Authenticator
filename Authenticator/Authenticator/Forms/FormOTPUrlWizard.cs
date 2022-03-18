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
    public partial class FormOTPUrlWizard : Form
    {
        public FormOTPUrlWizard()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public string getOTPURL() {

            return $"otpauth://totp/{textBoxName.Text}?issuer={textBoxIssuer.Text}&secret={textBoxSecret.Text}";
        }

        private void FormOTPUrlWizard_Load(object sender, EventArgs e)
        {

        }
    }
}
