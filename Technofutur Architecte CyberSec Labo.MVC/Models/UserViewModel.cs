namespace Technofutur_Architecte_CyberSec_Labo.MVC.Models
{
	public class UserViewModel
	{
		public string Email { get; set; } = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
	}
}
