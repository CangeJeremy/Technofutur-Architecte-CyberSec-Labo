using Microsoft.Data.SqlClient;
using System.Data;
using Technofutur_Architecte_CyberSec_Labo.DAL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;

namespace Technofutur_Architecte_CyberSec_Labo.DAL.Repositories
{
	public class PasswordRepository : IPasswordRepository
	{
		private readonly SqlConnection _sqlConnection;

		public PasswordRepository(SqlConnection sqlConnection)
		{
			_sqlConnection = sqlConnection;
		}

		public WebsitePwdModel? Create(WebsitePwdModel websitePwdModel)
		{
			WebsitePwdModel? wpm = null;

			using (_sqlConnection)
			{
				using (SqlCommand command = _sqlConnection.CreateCommand())
				{
					command.CommandText = "INSERT INTO WebsitesPwd (UserId, Name, Website, Pwd) VALUES (@UserId, @Name, @Website, @Password)";
					command.CommandType = CommandType.Text;

					command.Parameters.AddWithValue("UserId", websitePwdModel.UserId);
					command.Parameters.AddWithValue("Name", websitePwdModel.Name);
					command.Parameters.AddWithValue("Website", websitePwdModel.Website);
					command.Parameters.AddWithValue("Password", websitePwdModel.Password);

					_sqlConnection.Open();

					try
					{
						int insertedId = command.ExecuteNonQuery();

						if (insertedId > 0)
						{
							wpm = new WebsitePwdModel
							{
								Name = websitePwdModel.Name
							};
						}
					}
					catch (Exception ex)
					{
						LoggerDbRepository logger = new LoggerDbRepository(_sqlConnection);
						logger.Create("Create in PasswordRepository", ex.Message);
					}


					_sqlConnection.Close();
				}
			}

			return wpm;
		}

		public bool Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<WebsitePwdModel> GetAllUserPwd(int userId)
		{
			List<WebsitePwdModel> wpm = new List<WebsitePwdModel>();

			using (_sqlConnection)
			{
				using (SqlCommand command = _sqlConnection.CreateCommand())
				{
					command.CommandText = "SELECT * FROM WebsitesPwd WHERE UserId = @Id";
					command.CommandType = CommandType.Text;

					command.Parameters.AddWithValue("Id", userId);

					_sqlConnection.Open();

					try
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.HasRows)
							{
								while (reader.Read())
								{
									wpm.Add(new WebsitePwdModel
									{
										Id = reader.GetInt32("Id"),
										UserId = reader.GetInt32("UserId"),
										Name = reader.GetString("Name"),
										Website = reader.GetString("Website"),
										Password = reader.GetString("Pwd")
									});
								}
							}
						}
					}
					catch (Exception ex)
					{
						LoggerDbRepository logger = new LoggerDbRepository(_sqlConnection);
						logger.Create("GetAllUserPwd in PasswordRepository", ex.Message);
					}

					_sqlConnection.Close();
				}
			}

			return wpm;
		}

		public WebsitePwdModel GetById(int id)
		{
			WebsitePwdModel wpm = null;

			using (_sqlConnection)
			{
				using (SqlCommand command = _sqlConnection.CreateCommand())
				{
					command.CommandText = "SELECT * FROM WebsitesPwd WHERE Id = @Id";
					command.CommandType = CommandType.Text;

					command.Parameters.AddWithValue("Id", id);

					_sqlConnection.Open();

					try
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.HasRows)
							{
								if (reader.Read())
								{
									wpm = new WebsitePwdModel
									{
										Id = reader.GetInt32("Id"),
										UserId = reader.GetInt32("UserId"),
										Name = reader.GetString("Name"),
										Website = reader.GetString("Website"),
										Password = reader.GetString("Pwd")
									};
								}
							}
						}
					}
					catch (Exception ex)
					{
						LoggerDbRepository logger = new LoggerDbRepository(_sqlConnection);
						logger.Create("GetById in PasswordRepository", ex.Message);
					}

					_sqlConnection.Close();
				}
			}

			return wpm;
		}

		public WebsitePwdModel? Update(WebsitePwdModel websitePwdModel)
		{
			WebsitePwdModel? wpm = null;

			using (_sqlConnection)
			{
				using (SqlCommand command = _sqlConnection.CreateCommand())
				{
					command.CommandText = "UPDATE WebsitesPwd SET Name = @Name, Website = @Website, Pwd = @Pwd WHERE Id = @Id";
					command.CommandType = CommandType.Text;

					command.Parameters.AddWithValue("Id", websitePwdModel.Id);
					command.Parameters.AddWithValue("Name", websitePwdModel.Name);
					command.Parameters.AddWithValue("Website", websitePwdModel.Website);
					command.Parameters.AddWithValue("Pwd", websitePwdModel.Password);

					_sqlConnection.Open();

					try
					{
						int insertedId = command.ExecuteNonQuery();

						if (insertedId > 0)
						{
							wpm = new WebsitePwdModel
							{
								Name = websitePwdModel.Name
							};
						}
					}
					catch (Exception ex)
					{
						LoggerDbRepository logger = new LoggerDbRepository(_sqlConnection);
						logger.Create("Update in PasswordRepository", ex.Message);
					}


					_sqlConnection.Close();
				}
			}

			return wpm;
		}
	}
}
