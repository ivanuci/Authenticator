using System.Runtime.InteropServices;

namespace Authenticator
{

    [ClassInterface(ClassInterfaceType.None)]
    [ComVisible(true)]
    public class NativeMethods
    {

        public void EditRecord(string id)
        {
            OTPRecord? record = GlobalClass.AuDataBase.GetRecord(id);

            if (record != null) {

                FormEditRecordName formERName = new();

                formERName.NameEditor = record.Name;

                if (formERName.ShowDialog() == DialogResult.OK && formERName.NameEditor != record.Name) {

                    record.Name = formERName.NameEditor;
                    GlobalClass.AuDataBase.RecordsChanged();
                }

            }
        }


        public void MigrateRecord(string id)
        {
            OTPRecord? record = GlobalClass.AuDataBase.GetRecord(id);

            if (record != null) {

                FormMigrate fm = new();

                fm.SetMigrate(record.Name, OTPMigrate.Migration(record));

                fm.Show();

            }

        }


        public void DeleteRecord(string id)
        {
           
            OTPRecord? record = GlobalClass.AuDataBase.GetRecord(id);

            if (record != null) {

                FormConfirm frmC = new();

                frmC.SetMessage("Delete key with name '" + record.Name + "'?");

                if (frmC.ShowDialog() == DialogResult.Yes)
                {

                    GlobalClass.AuDataBase.RemoveRecord(record);
                }

            }

        }

        public void CopyToClipboard(string text) 
        {
            Clipboard.SetText(text);
        }

        public void OrderItems(string firstId, string secondId)
        {
            GlobalClass.AuDataBase.OrderItems(firstId, secondId);
        }

    }

}
