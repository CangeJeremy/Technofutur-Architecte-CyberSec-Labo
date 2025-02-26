using Technofutur_Architecte_CyberSec_Labo.BLL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DAL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;

namespace Technofutur_Architecte_CyberSec_Labo.BLL.Services
{
	public class LoggerDbService : ILoggerDbService
	{
		private readonly ILoggerDbRepository _loggerDbRepository;

		public LoggerDbService(ILoggerDbRepository loggerDbRepository)
		{
			_loggerDbRepository = loggerDbRepository;
		}

		public void Create(string method, string error)
		{
			 _loggerDbRepository.Create(method, error);
		}

		public IEnumerable<AppLog> GetAll()
		{
			return _loggerDbRepository.GetAll();
		}
	}
}
