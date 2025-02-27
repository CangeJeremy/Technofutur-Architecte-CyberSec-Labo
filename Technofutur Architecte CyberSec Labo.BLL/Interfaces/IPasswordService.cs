using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;

namespace Technofutur_Architecte_CyberSec_Labo.BLL.Interfaces
{
	public interface IPasswordService
	{
		IEnumerable<WebsitePwdModel> GetAllUserPwd(int userId, byte[] deriveKey);
		WebsitePwdModel GetById(int id, byte[] deriveKey);
		WebsitePwdModel? Create(WebsitePwdModel websitePwdModel, byte[] deriveKey);
		WebsitePwdModel? Update(WebsitePwdModel websitePwdModel, byte[] deriveKey);
		bool Delete(int id);
	}
}
