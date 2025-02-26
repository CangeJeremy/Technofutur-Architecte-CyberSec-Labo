using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;

namespace Technofutur_Architecte_CyberSec_Labo.MVC.Models.Mappers
{
	public static class PasswordMapper
	{
		public static PasswordViewModel WebsitePwdModelToViewModel(WebsitePwdModel websitePwdModel)
		{
			return new PasswordViewModel
			{
				Name = websitePwdModel.Name,
				Website = websitePwdModel.Website,
				Password = websitePwdModel.Password
			};
		}
	}
}
