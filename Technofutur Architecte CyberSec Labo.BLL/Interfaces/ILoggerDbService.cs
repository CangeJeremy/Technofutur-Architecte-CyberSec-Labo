using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;

namespace Technofutur_Architecte_CyberSec_Labo.BLL.Interfaces
{
	public interface ILoggerDbService
	{
		public IEnumerable<AppLog> GetAll();
		public void Create(string method, string error);
	}
}
