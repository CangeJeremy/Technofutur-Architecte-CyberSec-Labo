using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using Technofutur_Architecte_CyberSec_Labo.BLL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.BLL.Services;
using Technofutur_Architecte_CyberSec_Labo.DAL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DAL.Repositories;

namespace Technofutur_Architecte_CyberSec_Labo.MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// Add SQL
			builder.Services.AddScoped<SqlConnection>(c => new SqlConnection(builder.Configuration.GetConnectionString("Default")));

			// Add Authentication (Cookie)
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt => opt.LoginPath = "/login");

			// Add Sessions
			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(30);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});
			builder.Services.AddDistributedMemoryCache();

			// Services
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<IPasswordService, PasswordService>();
			builder.Services.AddScoped<ILoggerDbService, LoggerDbService>();

			// Repositories
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();
			builder.Services.AddScoped<ILoggerDbRepository, LoggerDbRepository>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts(); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseSession();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
