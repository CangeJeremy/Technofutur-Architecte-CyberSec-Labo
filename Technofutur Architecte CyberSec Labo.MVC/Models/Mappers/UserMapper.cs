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

	public static UserModel userRegisterToUserModel (UserRegisterModel registerModel)
	{
		return new UserModel
		{
			Email = registerModel.Email,
			Password = registerModel.Password
		};
	}

	public static UserViewModel userModelToViewModel (UserModel userModel)
	{
		return new UserViewModel
		{
			Id = userModel.Id,
			Email = userModel.Email,
			Role = userModel.Role,
			Created = userModel.Created,
			Updated = userModel.Updated,
			Deactivated = userModel.Deactivated
		};
	}
}
