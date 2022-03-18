using System.Security.Cryptography;
using System.Text;

namespace Authenticator
{
    public class Crypt
    {

        public static byte[] Encrypt(byte[] key, byte[] inputBytes)
        {
            int tagLength = AesGcm.TagByteSizes.MaxSize;
            int nonceLength = AesGcm.NonceByteSizes.MaxSize;
            
            using AesGcm aes = new AesGcm(key);

            byte[] nonce = new byte[nonceLength]; // Nonce (IV)
            byte[] ciphertext = new byte[inputBytes.Length];
            byte[] tag = new byte[tagLength];

            RandomNumberGenerator.Fill(nonce);

            aes.Encrypt(nonce, inputBytes, ciphertext, tag);

            // Join: tag + nonce + ciphertext
            var TNCiphertext = new byte[tagLength + nonceLength + inputBytes.Length];

            Buffer.BlockCopy(tag, 0, TNCiphertext, 0, tagLength);
            Buffer.BlockCopy(nonce, 0, TNCiphertext, tagLength, nonceLength);
            Buffer.BlockCopy(ciphertext, 0, TNCiphertext, tagLength + nonceLength, inputBytes.Length);

            return TNCiphertext;
        }


        public static byte[]? Decrypt(byte[] TNCiphertext, byte[] key)
        {
            // Parse: tag, nonce, ciphertext
            int tagLength = AesGcm.TagByteSizes.MaxSize;
            int nonceLength = AesGcm.NonceByteSizes.MaxSize;
            int cipherLength = TNCiphertext.Length - nonceLength - tagLength;

            if (cipherLength <= 0) return null;

            byte[] tag = new byte[tagLength];
            byte[] nonce = new byte[nonceLength];
            byte[] ciphertext = new byte[cipherLength];
            
            Buffer.BlockCopy(TNCiphertext, 0, tag , 0, tagLength);
            Buffer.BlockCopy(TNCiphertext, tagLength, nonce, 0, nonceLength);
            Buffer.BlockCopy(TNCiphertext, tagLength + nonceLength, ciphertext, 0, cipherLength);

            using AesGcm aes = new AesGcm(key);
            byte[] outputBytes = new byte[ciphertext.Length];

            try
            {
                aes.Decrypt(nonce, ciphertext, tag, outputBytes);
            }
            catch (Exception) {
                
                return null;
            }
            

            return outputBytes;
        }


        public static byte[] CreateSHA256(string input)
        {
            var message = Encoding.UTF8.GetBytes(input);
            using (var alg = SHA256.Create())
            {
                return alg.ComputeHash(message); ;
            }
        }


    }
}
