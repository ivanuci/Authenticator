using Google.Protobuf;
using System.Collections.Specialized;
using System.Web;

namespace Authenticator
{
    public class OTPMigrate
    {

        public static List<OTPRecord> FromBytes(byte[] dataByte)
        {
            List<OTPRecord> records = new();

            try
            {
                var pd = Payload.Parser.ParseFrom(dataByte);


                if (pd != null && pd.OtpParameters != null) foreach (var otpRec in pd.OtpParameters)
                    {
                        if (otpRec.Type == Payload.Types.OtpType.Totp)
                        {
                            records.Add(new OTPRecord(otpRec.Issuer, otpRec.Name, otpRec.Algorithm, otpRec.Digits, otpRec.Secret));
                        }
                    }
            }
            catch (Exception ex) {

                FormMessage msg = new();
                msg.SetMessage("Migrate FromBytes: " + ex.Message);
                msg.ShowDialog();
            }

            return records;
        }


        public static List<OTPRecord> Migration(string otpMigrationUrl)
        {
            List<OTPRecord> records = new();

            try
            {
                Uri myUri = new(otpMigrationUrl);

                NameValueCollection query = HttpUtility.ParseQueryString(myUri.Query);
                
                string? data = query.Get("data");

                if (data == null) throw new ArgumentException("Migration data cannot be null!");

                string decodedUrl = Encoder.UrlDecode(data);
                byte[] dataByte = Convert.FromBase64String(decodedUrl);

                var pd = Payload.Parser.ParseFrom(dataByte);

                if (pd != null && pd.OtpParameters != null) foreach (var otpRec in pd.OtpParameters)
                {

                    if (otpRec.Type == Payload.Types.OtpType.Totp)
                    {
                        records.Add(new OTPRecord(otpRec.Issuer, otpRec.Name, otpRec.Algorithm, otpRec.Digits, otpRec.Secret));
                    }
                }
            }
            catch (Exception ex) {

                FormMessage msg = new();
                msg.SetMessage("Migration: " + ex.Message);
                msg.ShowDialog();

            }

            return records;
        }


        public static string Migration(OTPRecord record)
        {
            List<OTPRecord> list = new();

            list.Add(record);

            return Migration(list);
        }

        public static string Migration(List<OTPRecord> records) {

            Payload pl = new();

            //pl.Version = 1;
            //pl.BatchSize = 1;
            //pl.BatchId = 123123123;

            foreach (OTPRecord record in records)
            {
                pl.OtpParameters.Add(record.GetProtocolRecord());
            }

            using MemoryStream ms = new();
            pl.WriteTo(ms);

            string mig = Convert.ToBase64String(ms.ToArray());

            mig = Encoder.UrlEncode(mig);

            return $"otpauth-migration://offline?data={mig}";

        }

    }
}
