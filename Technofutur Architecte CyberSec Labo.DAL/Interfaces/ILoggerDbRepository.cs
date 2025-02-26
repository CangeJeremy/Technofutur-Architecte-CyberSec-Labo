using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;

namespace Technofutur_Architecte_CyberSec_Labo.DAL.Interfaces
{
	public interface ILoggerDbRepository
	{
		public IEnumerable<AppLog> GetAll();
		public void Create(string method, string error);
	}
}
