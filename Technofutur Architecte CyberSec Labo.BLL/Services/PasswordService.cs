using Technofutur_Architecte_CyberSec_Labo.BLL.Helpers;
using Technofutur_Architecte_CyberSec_Labo.BLL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DAL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;

namespace Technofutur_Architecte_CyberSec_Labo.BLL.Services
{
	public class PasswordService : IPasswordService
	{
		private readonly IPasswordRepository _passwordRepository;

		public PasswordService(IPasswordRepository passwordRepository)
		{
			_passwordRepository = passwordRepository;
		}

		public WebsitePwdModel? Create(WebsitePwdModel websitePwdModel, byte[] deriveKey)
		{
			WebsitePwdModel newWpm = new WebsitePwdModel
			{
				UserId = websitePwdModel.UserId,
				Name = websitePwdModel.Name,
				Website = websitePwdModel.Website,
				Password = EncryptionHelper.Encrypt(websitePwdModel.Password, deriveKey)
			};

			return _passwordRepository.Create(newWpm);
		}

		public bool Delete(int id)
		{
			return _passwordRepository.Delete(id);
		}

		public IEnumerable<WebsitePwdModel> GetAllUserPwd(int userId, byte[] deriveKey)
		{
			List<WebsitePwdModel> wpm = new List<WebsitePwdModel>();

			foreach (var p in _passwordRepository.GetAllUserPwd(userId))
			{
				wpm.Add(new WebsitePwdModel
				{
					Id = p.Id,
					UserId = p.UserId,
					Name = p.Name,
					Website = p.Website,
					Password = EncryptionHelper.Decrypt(p.Password, deriveKey)
				});
			}

			return wpm;
		}


		public WebsitePwdModel? Update(WebsitePwdModel websitePwdModel, byte[] deriveKey)
		{
			WebsitePwdModel newWpm = new WebsitePwdModel
			{
				Name = websitePwdModel.Name,
				Website = websitePwdModel.Website,
				Password = EncryptionHelper.Encrypt(websitePwdModel.Password, deriveKey)
			};

			return _passwordRepository.Update(newWpm);
		}
	}
}
