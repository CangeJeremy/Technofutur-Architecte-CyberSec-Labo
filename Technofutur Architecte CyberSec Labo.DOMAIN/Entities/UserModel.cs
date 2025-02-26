namespace Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities
{
	public class UserModel
	{
		public int Id { get; set; }
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Role { get; set; } = string.Empty;
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public bool Deactivated { get; set; }
	}
}
