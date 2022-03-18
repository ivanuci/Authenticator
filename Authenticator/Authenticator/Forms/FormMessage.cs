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
    public partial class FormMessage : Form
    {
        public FormMessage()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        public void SetMessage(string text) { 
        
                labMessage.Text = text;
        }

        private void Confirm_Load(object sender, EventArgs e)
        {

        }

        private void FormMessage_Load(object sender, EventArgs e)
        {

        }
    }

}
