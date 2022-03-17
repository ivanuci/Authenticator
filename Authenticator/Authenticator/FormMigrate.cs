using QRCoder;
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
    public partial class FormMigrate : Form
    {
        public FormMigrate()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }


        private static Bitmap GenerateQRCode(string migrationData)
        {
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(migrationData, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(2);

            return qrCodeImage;
        }


        public void SetMigrate(string name, string migrationData) {

            this.Text = "Migrate - " + name;

            pictureBoxQRMigrate.Image = GenerateQRCode(migrationData);

            textBoxOTPMigrate.Text = migrationData;

        }


        private void FormMigrate_Load(object sender, EventArgs e)
        {

        }
    }
}
