using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;

namespace Technofutur_Architecte_CyberSec_Labo.DAL.Interfaces
{
	public interface IPasswordRepository
	{
		IEnumerable<WebsitePwdModel> GetAllUserPwd(int userId);
		WebsitePwdModel GetById(int id);
		WebsitePwdModel? Create(WebsitePwdModel websitePwdModel);
		WebsitePwdModel? Update(WebsitePwdModel websitePwdModel);
		bool Delete(int id);
	}
}
