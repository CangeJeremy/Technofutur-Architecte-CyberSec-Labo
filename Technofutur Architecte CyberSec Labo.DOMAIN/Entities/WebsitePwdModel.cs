namespace Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities
{
	public class WebsitePwdModel
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Website { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
