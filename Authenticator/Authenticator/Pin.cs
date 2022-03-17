using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Authenticator
{
    public class Pin
    {
        static DateTime UnixEpoch = new (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		static string NTPServer = "time.google.com";
		static TimeSpan syncSpan = GetNTPTime() - DateTime.UtcNow;

		public static int SecondsInInterval(int period)
		{
			return (int) (ElapsedSeconds % period);
		}

		private static long ElapsedSeconds
		{
			get
			{
				return (long)Math.Floor((DateTime.UtcNow.AddMilliseconds(syncSpan.TotalMilliseconds) - UnixEpoch).TotalSeconds);
			}
		}

		public static long CurrentInterval(int period)
		{
			return ElapsedSeconds / period;
		}

		public static string Generate(byte[] key, int period, int digits)
		{
			int PinModulo = (int)Math.Pow(10, digits);

			const int SizeOfInt32 = sizeof(Int32);

			byte[] CounterBytes = LongToBytes(CurrentInterval(period));

			byte[] Hash = new HMACSHA1(key).ComputeHash(CounterBytes);
			int Offset = Hash[Hash.Length - 1] & 0xF;

			byte[] SelectedBytes = new byte[SizeOfInt32];
			Buffer.BlockCopy(Hash, Offset, SelectedBytes, 0, SizeOfInt32);

			Int32 SelectedInteger = BytesToInt32(SelectedBytes);

			//remove the most significant bit for interoperability per spec
			Int32 TruncatedHash = SelectedInteger & 0x7FFFFFFF;

			//generate number of digits for given pin length
			Int32 PinNumber = TruncatedHash % PinModulo;

			return PinNumber.ToString(CultureInfo.InvariantCulture).PadLeft(digits, '0');
		}


		private static byte[] LongToBytes(long number)
		{

			byte[] bytes = BitConverter.GetBytes(number);
			if (BitConverter.IsLittleEndian) Array.Reverse(bytes);

			return bytes;
		}


		private static Int32 BytesToInt32(byte[] bytes)
		{
			if (BitConverter.IsLittleEndian) Array.Reverse(bytes);

			return BitConverter.ToInt32(bytes, 0);
		}


		//stackoverflow.com/questions/1193955/how-to-query-an-ntp-server-using-c
		private static DateTime GetNTPTime()
		{
			// NTP message size - 16 bytes of the digest (RFC 2030)
			var ntpData = new byte[48];

			//Setting the Leap Indicator, Version Number and Mode values
			ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

			try
			{
				var addresses = Dns.GetHostEntry(NTPServer).AddressList;

				//The UDP port number assigned to NTP is 123
				var ipEndPoint = new IPEndPoint(addresses[0], 123);

				//NTP uses UDP
				using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
				{
					socket.Connect(ipEndPoint);

					//Stops code hang if NTP is blocked
					socket.ReceiveTimeout = 3000;

					socket.Send(ntpData);
					socket.Receive(ntpData);
					socket.Close();
				}
			}
			catch (Exception) {
				
				return DateTime.UtcNow;
			}

			//Offset to get to the "Transmit Timestamp" field (time at which the reply 
			//departed the server for the client, in 64-bit timestamp format."
			const byte serverReplyTime = 40;

			//Get the seconds part
			ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

			//Get the seconds fraction
			ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

			//Convert From big-endian to little-endian
			intPart = SwapEndianness(intPart);
			fractPart = SwapEndianness(fractPart);

			var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

			//**UTC** time
			var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

			return networkDateTime.ToUniversalTime();
		}

		// stackoverflow.com/a/3294698/162671
		private static uint SwapEndianness(ulong x)
		{
			return (uint)(((x & 0x000000ff) << 24) +
						   ((x & 0x0000ff00) << 8) +
						   ((x & 0x00ff0000) >> 8) +
						   ((x & 0xff000000) >> 24));
		}

	}
}
