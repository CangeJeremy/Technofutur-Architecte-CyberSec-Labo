using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Technofutur_Architecte_CyberSec_Labo.BLL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;
using Technofutur_Architecte_CyberSec_Labo.MVC.Models.FormModel.User;

namespace Technofutur_Architecte_CyberSec_Labo.MVC.Controllers.Auth
{
	public class LoginController : Controller
	{
		private readonly IUserService _userService;

		public LoginController(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Login(UserLoginModel userLogin)
		{
			if (ModelState.IsValid)
			{
				UserModel? userModel = _userService.Login(userLogin.Email, userLogin.Password);

				if (userModel is null)
				{
					return NotFound(new { Message = "This account doesn't exist." });
				}

				List<Claim> claims = new List<Claim>()
				{
					new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString()),
					new Claim(ClaimTypes.Email, userModel.Email),
					new Claim(ClaimTypes.Role, userModel.Role)
				};

				ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				AuthenticationProperties authenticationProperties = new AuthenticationProperties
				{
					IsPersistent = true,
					ExpiresUtc = DateTime.UtcNow.AddDays(1)
				};

				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity)).Wait();
			}

			return RedirectToAction("Index", "Home");
		}
	}
}
