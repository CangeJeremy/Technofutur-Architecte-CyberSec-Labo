using System.ComponentModel.DataAnnotations;

namespace Technofutur_Architecte_CyberSec_Labo.MVC.Models.FormModel.Password
{
	public class CreatePwdModel
	{
		[Required]
		[MinLength(3)]
		public string Name { get; set; } = string.Empty;

		[Required]
		[Url]
		public string Website { get; set; } = string.Empty;

		[Required]
		[RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=!]).{8,64}$", ErrorMessage = "Password must contains 1 Uppercase, 1 Lowercase, 1 number, 1 special character.")]
		public string Password { get; set; } = string.Empty;
	}
}
