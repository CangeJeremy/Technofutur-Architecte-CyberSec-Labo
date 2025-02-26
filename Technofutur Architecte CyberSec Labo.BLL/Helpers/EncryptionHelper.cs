using System.Security.Cryptography;
using System.Text;

namespace Technofutur_Architecte_CyberSec_Labo.BLL.Helpers
{
	public static class EncryptionHelper
	{
		public static string Encrypt(string plainText, byte[] key)
		{
			using (Aes aes = Aes.Create())
			{
				aes.Key = key;
				aes.GenerateIV();
				byte[] iv = aes.IV;

				using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
				{
					byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
					byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

					byte[] result = new byte[iv.Length + encryptedBytes.Length];
					Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
					Buffer.BlockCopy(encryptedBytes, 0, result, iv.Length, encryptedBytes.Length);

					return Convert.ToBase64String(result);
				}
			}
		}


		public static string Decrypt(string cipherText, byte[] key)
		{
			byte[] fullCipher = Convert.FromBase64String(cipherText);

			using (Aes aes = Aes.Create())
			{
				aes.Key = key;

				byte[] iv = new byte[aes.BlockSize / 8];
				byte[] cipherBytes = new byte[fullCipher.Length - iv.Length];

				Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
				Buffer.BlockCopy(fullCipher, iv.Length, cipherBytes, 0, cipherBytes.Length);

				aes.IV = iv;

				using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
				{
					byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
					return Encoding.UTF8.GetString(decryptedBytes);
				}
			}
		}

	}
}
