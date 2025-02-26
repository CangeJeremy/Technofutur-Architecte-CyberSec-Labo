namespace Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities
{
	public class AppLog
	{
		public int Id { get; set; }
		public string Method { get; set; } = string.Empty;
		public string Error { get; set; } = string.Empty;
		public DateTime Date { get; set; }
	}
}
