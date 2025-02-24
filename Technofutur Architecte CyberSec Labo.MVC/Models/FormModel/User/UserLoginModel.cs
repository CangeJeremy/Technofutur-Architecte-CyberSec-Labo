using System.ComponentModel.DataAnnotations;

namespace Technofutur_Architecte_CyberSec_Labo.MVC.Models.FormModel.User
{
	public class UserLoginModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		[RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=!]).{8,64}$", ErrorMessage = "Password must contains 1 Uppercase, 1 Lowercase, 1 number, 1 special character.")]
		public string Password { get; set; } = string.Empty;
	}
}
