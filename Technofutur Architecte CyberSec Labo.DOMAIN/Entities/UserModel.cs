namespace Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities
{
	public class UserModel
	{
		public int Id { get; set; }
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Role { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public bool IsAccountActive { get; set; }
		public bool IsAccountBan { get; set; }
	}
}
