using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;
using Technofutur_Architecte_CyberSec_Labo.MVC.Models.FormModel.User;

namespace Technofutur_Architecte_CyberSec_Labo.MVC.Models.Mappers;

public static class UserMapper
{
	public static UserModel userLoginToUserModel (UserLoginModel loginModel)
	{
		return new UserModel
		{
			Email = loginModel.Email,
			Password = loginModel.Password
		};
	}

	public static UserViewModel userModelToViewModel (UserModel userModel)
	{
		return new UserViewModel
		{
			Email = userModel.Email,
			FirstName = userModel.FirstName,
			LastName = userModel.LastName,
			City = userModel.City,
			Created = userModel.Created,
			Updated = userModel.Updated
		};
	}
}
