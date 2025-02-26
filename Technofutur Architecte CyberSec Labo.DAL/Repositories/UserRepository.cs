using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using Technofutur_Architecte_CyberSec_Labo.DAL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;

namespace Technofutur_Architecte_CyberSec_Labo.DAL.Repositories
{
	public class UserRepository : IUserRepository
	{
		private SqlConnection _sqlConnection;

		public UserRepository(SqlConnection sqlConnection)
		{
			_sqlConnection = sqlConnection;
		}

		public IEnumerable<UserModel> GetUsers()
		{
			List<UserModel> users = new List<UserModel>();

			using (_sqlConnection)
			{
				using (SqlCommand command = _sqlConnection.CreateCommand())
				{
					command.CommandText = "SELECT Id, Email, Perms, Created, Updated, Deactivated FROM Users";
					command.CommandType = CommandType.Text;

					_sqlConnection.Open();

					try
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.HasRows)
							{
								while (reader.Read())
								{
									users.Add(new UserModel
									{
										Id = reader.GetInt32("Id"),
										Email = reader.GetString("Email"),
										Password = "REDACTED",
										Role = reader.GetString("Perms"),
										Created = reader.GetDateTime("Created"),
										Updated = reader.GetDateTime("Updated"),
										Deactivated = reader.GetBoolean("Deactivated")
									});
								}
							}
						}
					}
					catch (Exception ex)
					{
						LoggerDbRepository logger = new LoggerDbRepository(_sqlConnection);
						logger.Create("GetUsers in UserRepository", ex.Message);
					}


					_sqlConnection.Close();
				}
			}

			return users;
		}

		public UserModel? GetUserById(int? id)
		{
			UserModel? user = null;

			using (_sqlConnection)
			{
				using (SqlCommand command = _sqlConnection.CreateCommand())
				{
					command.CommandText = "SELECT Id, Email, Perms, Created, Updated, Deactivated FROM Users WHERE Id = @Id";
					command.CommandType = CommandType.Text;

					command.Parameters.AddWithValue("Id", id);

					_sqlConnection.Open();

					try
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.HasRows)
							{
								while (reader.Read())
								{
									user = new UserModel
									{
										Id = reader.GetInt32("Id"),
										Email = reader.GetString("Email"),
										Password = "REDACTED",
										Role = reader.GetString("Perms"),
										Created = reader.GetDateTime("Created"),
										Updated = reader.GetDateTime("Updated"),
										Deactivated = reader.GetBoolean("Deactivated")
									};
								}
							}
						}
					}
					catch (Exception ex)
					{
						LoggerDbRepository logger = new LoggerDbRepository(_sqlConnection);
						logger.Create("GetUserById in UserRepository", ex.Message);
					}


					_sqlConnection.Close();
				}
			}

			return user;
		}

		public UserModel? GetUserByEmail(string email)
		{
			UserModel? user = null;

			using (_sqlConnection)
			{
				using (SqlCommand command = _sqlConnection.CreateCommand())
				{
					command.CommandText = "SELECT Id, Email, Perms, Created, Updated, Deactivated FROM Users WHERE Email = @Email";
					command.CommandType = CommandType.Text;

					command.Parameters.AddWithValue("Email", email);

					_sqlConnection.Open();

					try
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.HasRows)
							{
								if (reader.Read())
								{
									user = new UserModel
									{
										Id = reader.GetInt32("Id"),
										Email = reader.GetString("Email"),
										Password = "REDACTED",
										Role = reader.GetString("Perms"),
										Created = reader.GetDateTime("Created"),
										Updated = reader.GetDateTime("Updated"),
										Deactivated = reader.GetBoolean("Deactivated")
									};
								}
							}
						}
					}
					catch (Exception ex)
					{
						LoggerDbRepository logger = new LoggerDbRepository(_sqlConnection);
						logger.Create("GetUserByEmail in UserRepository", ex.Message);
					}


					_sqlConnection.Close();
				}
			}

			return user;
		}

		public UserModel Create(UserModel userToCreate)
		{
			UserModel partialUserForConfirmation = new UserModel();

			using (_sqlConnection)
			{
				using (SqlCommand command = _sqlConnection.CreateCommand())
				{
					command.CommandText = "[AppUser].[Register]";
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("Email", userToCreate.Email);
					command.Parameters.AddWithValue("Pwd", userToCreate.Password);

					_sqlConnection.Open();

					try
					{
						int? insertedId = 0;

						insertedId = (int?)command.ExecuteScalar();

						if (insertedId > 0)
						{
							partialUserForConfirmation = new UserModel
							{
								Email = userToCreate.Email
							};
						}
					}
					catch (Exception ex)
					{
						LoggerDbRepository logger = new LoggerDbRepository(_sqlConnection);
						logger.Create("Create in UserRepository", ex.Message);
					}

					_sqlConnection.Close();
				}
			}

			return partialUserForConfirmation;
		}

		public UserModel? Update(UserModel userToUpdate)
		{
			throw new NotImplementedException();
		}

		public bool Delete(int userToDeleteFromId)
		{
			bool userDeleted = false;

			using (_sqlConnection)
			{
				using (SqlCommand command = _sqlConnection.CreateCommand())
				{
					command.CommandText = "[Admin].[DeleteUserAccount]";
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("Id", userToDeleteFromId);

					_sqlConnection.Open();

					try
					{
						int res = command.ExecuteNonQuery();

						if (res > 0)
						{
							userDeleted = true;
						}
					}
					catch (Exception ex)
					{
						Debug.WriteLine(ex.Message);
					}

					_sqlConnection.Close();
				}
			}

			return userDeleted;
		}

		public UserModel? Login(string email, string password)
		{
			UserModel? user = null;

			using (_sqlConnection)
			{
				using (SqlCommand command = _sqlConnection.CreateCommand())
				{
					command.CommandText = "[AppUser].[Login]";
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.AddWithValue("Email", email);
					command.Parameters.AddWithValue("Pwd", password);

					_sqlConnection.Open();

					try
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.HasRows)
							{
								if (reader.Read())
								{
									user = new UserModel
									{
										Id = reader.GetInt32("Id"),
										Email = reader.GetString("Email"),
										Role = reader.GetString("Perms"),
										Deactivated = reader.GetBoolean("Deactivated")
									};
								}
							}
						}
					}
					catch (Exception ex)
					{
						LoggerDbRepository logger = new LoggerDbRepository(_sqlConnection);
						logger.Create("Login in UserRepository", ex.Message);
					}

					_sqlConnection.Close();
				}
			}

			return user;
		}
	}
}
