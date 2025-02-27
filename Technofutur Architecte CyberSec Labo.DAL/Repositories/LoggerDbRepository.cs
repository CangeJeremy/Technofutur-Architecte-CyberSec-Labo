using Microsoft.Data.SqlClient;
using System.Data;
using Technofutur_Architecte_CyberSec_Labo.DAL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Technofutur_Architecte_CyberSec_Labo.DAL.Repositories
{
	public class LoggerDbRepository : ILoggerDbRepository
	{
		private readonly SqlConnection _sqlConnection;

		public LoggerDbRepository(SqlConnection sqlConnection)
		{
			_sqlConnection = sqlConnection;
		}

		public void Create(string method, string error)
		{
			using (_sqlConnection)
			{
				using (SqlCommand command = _sqlConnection.CreateCommand())
				{
					command.CommandText = "INSERT INTO AppLogs (Method, Error) VALUES (@Method, @Error)";
					command.CommandType = CommandType.Text;

					command.Parameters.AddWithValue("Method", method);
					command.Parameters.AddWithValue("Error", error);

					if(_sqlConnection.State == ConnectionState.Closed)
					{
						_sqlConnection.Open();
					}
					
					try
					{
						command.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						this.Create("Create in LoggerDbRepository", ex.Message);
					}


					_sqlConnection.Close();
				}
			}
		}

		public IEnumerable<AppLog> GetAll()
		{
			List<AppLog> logs = new List<AppLog>();

			using (_sqlConnection)
			{
				using (SqlCommand command = _sqlConnection.CreateCommand())
				{
					command.CommandText = "SELECT * FROM AppLogs";
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
									logs.Add(new AppLog
									{
										Id = reader.GetInt32("Id"),
										Method = reader.GetString("Method"),
										Error = reader.GetString("Error"),
										Date = reader.GetDateTime("Date")
									});
								}
							}
						}
					}
					catch (Exception ex)
					{
						this.Create("GetAll in LoggerDbRepository", ex.Message);
					}


					_sqlConnection.Close();
				}
			}

			return logs;
		}
	}
}
