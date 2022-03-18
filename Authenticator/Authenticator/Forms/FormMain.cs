namespace Authenticator
{
    public partial class FormMain : Form
    {
        static bool timerRefreshExecuted = false;

        public FormMain()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            await GlobalClass.AuWebView.Init(Resource1.view);
            panelWeb.Controls.Add(GlobalClass.AuWebView);

            GlobalClass.AuDataBase.DataChanged += DataChangedCallBack;
            GlobalClass.AuDataBase.LoadData();
        }


        private async void RedrawView()
        {
            string jrecords = GlobalClass.AuDataBase.GetRecordsInJSON(textBoxFilter.Text);

            await GlobalClass.AuWebView.AddRecords(jrecords);

            if (GlobalClass.AuDataBase.IsChangedByUser) buttonSave.Visible = true;
        }


        private void DataChangedCallBack(object sender, EventArgs e)
        {
            RedrawView();
        }


        private async void TimerChange_Tick(object sender, EventArgs e)
        {
            int iseconds = Pin.SecondsInInterval(30);

            if (iseconds == 0 && !timerRefreshExecuted)
            {
                timerRefreshExecuted = true;

                string jrecords = GlobalClass.AuDataBase.GetRecordsInJSON(textBoxFilter.Text);

                await GlobalClass.AuWebView.RefreshRecords(jrecords);
            }

            if (iseconds > 0) timerRefreshExecuted = false;

        }



        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GlobalClass.AuDataBase.IsChangedByUser)
            {

                FormConfirm frmC = new();

                frmC.SetMessage("Save changes?");

                DialogResult dr = frmC.ShowDialog();

                if (dr == DialogResult.Yes)
                {
                    ButtonSave_Click(buttonSave, e);
                }
                else if (dr == DialogResult.No)
                {
                    buttonSave.Visible = false;
                    GlobalClass.AuDataBase.Close();
                }

            }

        }


        private void ButtonSave_Click(object sender, EventArgs e) {
            
            if (GlobalClass.AuDataBase.SaveData())
            {
                buttonSave.Visible = false;

                return;
            }

            SaveFileDialog sfd = new();

            sfd.RestoreDirectory = true;
            sfd.Title = "Save authenticator database";
            sfd.DefaultExt = "acdb";
            sfd.Filter = "Authenticator database (*.acdb)|*.acdb";
            sfd.FilterIndex = 2;
            sfd.CheckPathExists = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                if (GlobalClass.AuDataBase.SaveData(sfd.FileName))
                {

                    buttonSave.Visible = false;

                }

            }

        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            if (GlobalClass.AuDataBase.IsChangedByUser)
            {

                FormConfirm frmC = new();

                frmC.SetMessage("Save changes?");

                DialogResult dr = frmC.ShowDialog();

                if (dr == DialogResult.Yes)
                {
                    ButtonSave_Click(buttonSave, e);

                    return;
                }
                else if (dr == DialogResult.No)
                {
                    buttonSave.Visible = false;

                    GlobalClass.AuDataBase.Close();
                }

            }

            OpenFileDialog ofd = new();

            //ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            ofd.RestoreDirectory = true;
            ofd.Title = "Open authenticator database";
            ofd.DefaultExt = "acdb";
            ofd.Filter = "Authenticator database (*.acdb)|*.acdb";
            ofd.FilterIndex = 2;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                GlobalClass.AuDataBase.LoadData(ofd.FileName);
            }

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            FormAddRecord fAddKey = new();
            fAddKey.ShowDialog();
        }


        private void ButtonOptions_MouseUp(object sender, MouseEventArgs e)
        {
            ContextMenuStrip contexMenu = new();

            ToolStripItem itemMigrate = contexMenu.Items.Add("Migrate All");
            itemMigrate.Click += new EventHandler(Menu_item_migrate_click);

            contexMenu.Items.Add(itemMigrate);

            contexMenu.Show(buttonOptions, new Point(e.X, e.Y));
        }

        private void Menu_item_migrate_click(object sender, EventArgs e)
        {
            FormMigrate fm = new();

            fm.SetMigrate("All", OTPMigrate.Migration(GlobalClass.AuDataBase.GetAllRecords()));

            fm.Show();
        }

        private void TextBoxFilter_TextChanged(object sender, EventArgs e)
        {

            timerTyping.Stop();
            timerTyping.Start();
        }



        private void timerTyping_Tick(object sender, EventArgs e)
        {

            timerTyping.Stop();
            RedrawView();
        }
    }

}