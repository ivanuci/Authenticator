using Google.Protobuf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Authenticator
{
    public class DataBase
    {
        private List<OTPRecord> Records = new();
        private byte[] MasterPassword = new byte[32];
        private string FileName = "";
        private bool ChangedByUser = false;


        public string DatabaseFilePath
        {
            set
            {
                FileName = value;
            }
        }

        public bool IsChangedByUser
        {
            get
            {
                return ChangedByUser;
            }
        }


        public bool DatabaseFilePathExist()
        {
            return (!String.IsNullOrEmpty(FileName)) && File.Exists(FileName);
        }


        public void LoadData()
        {
            if (!String.IsNullOrEmpty(FileName))
                LoadData(FileName);
        }

        public void LoadData(string fileName)
        {
            if (File.Exists(fileName))
            {
                AskForMasterPassword(true);

                byte[] TNCiphertext = File.ReadAllBytes(fileName);
                byte[]? input = Crypt.Decrypt(TNCiphertext, MasterPassword);
                if (input != null)
                {
                    Records.Clear();
                    Records.AddRange(OTPMigrate.FromBytes(input));
                    
                    FileName = fileName;

                    OnChange();
                }
            
            }

        }


        public void Close()
        {
            Records.Clear();
            FileName = "";
            ChangedByUser = false;
            OnChange();
        }


        public bool SaveData()
        {
            if (!String.IsNullOrEmpty(FileName) && File.Exists(FileName))
            {
                return SaveData(FileName);
            }

            return false;
        }

        public bool SaveData(string fileName)
        {
            try
            {

                Payload pl = new();

                foreach (OTPRecord record in Records)
                {
                    pl.OtpParameters.Add(record.GetProtocolRecord());
                }

                using MemoryStream ms = new();
                pl.WriteTo(ms);
                ms.Seek(0, SeekOrigin.Begin);

                AskForMasterPassword(false);

                byte[] TNCiphertext = Crypt.Encrypt(MasterPassword, ms.ToArray());

                File.WriteAllBytes(fileName, TNCiphertext);
                
                FileName = fileName;

                ChangedByUser = false;

            }
            catch (Exception) {
                
                return false;
            }

            return true;
        }

        public void RecordsChanged() {

            ChangedByUser = true;
            OnChange();

        }

        public bool AddOTPURL(string otpURL)
        {
            int numRecords = Records.Count;
            bool isOffline = otpURL.StartsWith("otpauth-migration://offline");
            bool isTotp = otpURL.StartsWith("otpauth://totp");

            if (isOffline)
            {
                Records.AddRange(OTPMigrate.Migration(otpURL));
            }
            else if (isTotp)
            {
                OTPRecord otpar = new();

                if (otpar.SetTo(otpURL))
                {
                    Records.Add(otpar);
                }

            }
            else return false;

            if (Records.Count == numRecords) return false;
            else RecordsChanged();

            return true;
        }


        public string GetRecordsInJSON(string filter = "")
        {
            JArray jrecords = new();

            foreach (OTPRecord record in Records) {

                if (filter == "" || record.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                    jrecords.Add(record.GetJObject());
            }

            return JsonConvert.SerializeObject(jrecords) ?? "[]";
        }


        public void RemoveRecord(OTPRecord item)
        {
            Records.Remove(item);

            RecordsChanged();
        }


        public void OrderItems(string firstId, string secondId)
        {

            OTPRecord firstItem = Records.First(item => item.Id() == firstId);
            OTPRecord secondItem = Records.First(item => item.Id() == secondId);

            if (firstId != secondId && firstItem != null && secondItem != null) {

                Records.Remove(firstItem);
                int index = Records.IndexOf(secondItem);
                Records.Insert(index, firstItem);

                RecordsChanged();
            }
        }


        public OTPRecord? GetRecord(string id)
        {
            OTPRecord first;

            try
            {
                first = Records.First(item => item.Id() == id);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return first;
        }


        public List<OTPRecord> GetAllRecords() {

            return Records;

        }


        private void AskForMasterPassword(bool forceNew) {
            
            if (forceNew || MasterPassword.Length != 32 || MasterPassword.All(sb => sb == 0) ) {

                FormPassword frmP = new();
                
                if (frmP.ShowDialog() == DialogResult.OK) {
                    
                    string nkey = frmP.GetPassword();
                    if (!String.IsNullOrEmpty(nkey))
                    {
                        MasterPassword = Crypt.CreateSHA256(nkey);
                    }
                    else 
                    {
                        AskForMasterPassword(true);
                    }
                }

            }

        }


        public event EventHandler DataChanged;
        private void OnChange()
        {
            EventHandler handler = DataChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

    }
}
