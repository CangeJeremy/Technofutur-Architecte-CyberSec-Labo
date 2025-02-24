using Technofutur_Architecte_CyberSec_Labo.BLL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DAL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;

namespace Technofutur_Architecte_CyberSec_Labo.BLL.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public IEnumerable<UserModel> GetUsers()
		{
			return _userRepository.GetUsers();
		}

		public UserModel? GetUserById(int? id)
		{
			return _userRepository.GetUserById(id);
		}

		public UserModel? GetUserByEmail(string email)
		{
			return _userRepository.GetUserByEmail(email);
		}

		public UserModel Create(UserModel userToCreate)
		{
			return _userRepository.Create(userToCreate);
		}

		public UserModel? Update(UserModel userToUpdate)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int userToDeleteFromId)
		{
			return _userRepository.Delete(userToDeleteFromId);
		}

		public UserModel? Login(string email, string password)
		{
			return _userRepository.Login(email, password);
		}		
	}
}
