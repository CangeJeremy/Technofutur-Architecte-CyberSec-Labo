﻿using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;

namespace Technofutur_Architecte_CyberSec_Labo.BLL.Interfaces
{
	public interface IUserService
	{
		IEnumerable<UserModel> GetUsers();
		UserModel? GetUserById(int? id);
		UserModel? GetUserByEmail(string email);
		UserModel Create(UserModel userToCreate);
		UserModel? Update(UserModel userToUpdate);
		bool Delete(int userToDeleteFromId);
		UserModel? Login(string email, string password);
	}
}
