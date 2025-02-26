using System.Security.Cryptography;
using System.Text;

namespace Technofutur_Architecte_CyberSec_Labo.MVC.Helpers
{
	public static class CryptoHelper
	{
		public static byte[] DeriveKey(string password, string salt, int keySize = 32)
		{
			using (var pbkdf2 = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt), 100000, HashAlgorithmName.SHA256))
			{
				return pbkdf2.GetBytes(keySize);
			}
		}
	}
}
