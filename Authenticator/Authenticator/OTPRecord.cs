using System.Collections.Specialized;
using System.Globalization;
using System.Web;
using Google.Protobuf;
using Newtonsoft.Json.Linq;

namespace Authenticator
{

	public class OTPRecord
	{
		string issuer = "";
		string name = "";
		Payload.Types.Algorithm algorithm = Payload.Types.Algorithm.Unspecified;
		Payload.Types.DigitCount digits = Payload.Types.DigitCount.Unspecified;
		int period = 30;
		ByteString secret = ByteString.Empty;
        readonly string id = Guid.NewGuid().ToString("N");
		(long interval, string pin) last = (0, "");


		public OTPRecord() {
		}

		public OTPRecord(string _issuer, string _name, Payload.Types.Algorithm _algorithm, Payload.Types.DigitCount _digits, ByteString _secret)
		{

			issuer = _issuer;
			name = _name;
			algorithm = _algorithm;
			digits = _digits;
			secret = _secret;
		}

		public bool SetTo(string otpUrl)
		{
			try
			{
				Uri myUri = new(otpUrl);
				NameValueCollection query = HttpUtility.ParseQueryString(myUri.Query);

				string? _digits = query.Get("digits");
				string? _period = query.Get("period");
				string? _algorithm = query.Get("algorithm");
				string? _secret = query.Get("secret");
				string? _issuer = query.Get("issuer");

				if (_digits != null) digits = _digits == "6" ? Payload.Types.DigitCount.Six : _digits == "8" ? Payload.Types.DigitCount.Eight : Payload.Types.DigitCount.Unspecified;
				if (_period != null) period = Int32.Parse(_period, CultureInfo.InvariantCulture);
				if (_algorithm != null) algorithm = _algorithm == "SHA1" ? Payload.Types.Algorithm.Sha1 : Payload.Types.Algorithm.Unspecified;
				if (_secret != null) secret = ByteString.CopyFrom(Encoder.Base32Decode(_secret));
				if (_issuer != null) issuer = _issuer;

				name = myUri.LocalPath.Trim('/');
			}
			catch (Exception ex)
			{

				FormMessage msg = new();
				msg.SetMessage("OTPAuth URL: " + ex.Message);
				msg.ShowDialog();

				return false;
			}

			return true;
		}

		public override string ToString()
		{
			string otpauth = $"otpauth://totp/{name}?";
			
			List<string> parameters = new();

			if (algorithm != Payload.Types.Algorithm.Unspecified) parameters.Add("algorithm=" + algorithm.ToString());
			if (digits != Payload.Types.DigitCount.Unspecified) parameters.Add("digits=" + (digits == Payload.Types.DigitCount.Six ? 6 : 8));
			if (!String.IsNullOrEmpty(issuer)) parameters.Add("issuer=" + issuer);

			parameters.Add("secret=" + Encoder.Base32Encode(secret.ToByteArray()));

			return otpauth + String.Join("&", parameters.ToArray());
		}

		public string Id() {

			return id;
		}

		public string Name
		{
			get {
				return name;
			}

			set { 
				name = value;
			}
			
		}

		public JObject GetJObject()
		{

			return new JObject(
				new JProperty("name", name),
				new JProperty("id", id),
				new JProperty("pin", GetOTP()),
				new JProperty("period", period * 1000),
				new JProperty("elapsed", Pin.SecondsInInterval(period) * 1000)
			);

		}


		public string GetOTP()
		{
			if (Pin.CurrentInterval(period) == last.interval) return last.pin;

			byte[] key = secret.ToByteArray();
			int _digits = digits == Payload.Types.DigitCount.Eight ? 8 : 6;
			string pin = key.Length > 0 ? Pin.Generate(key, period, _digits) : "".PadLeft(_digits, '0');

			last.interval = Pin.CurrentInterval(period);
			last.pin = pin;

			return pin;
		}


		public Payload.Types.OtpParameters GetProtocolRecord() {

			Payload.Types.OtpParameters otpp = new();

			otpp.Issuer = issuer;
			otpp.Name = name;
			otpp.Digits = digits;
			otpp.Algorithm = algorithm;
			otpp.Type = Payload.Types.OtpType.Totp;
			otpp.Secret = secret;
			//otpp.Counter.

			return otpp;
		}


	}

}
