using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Technofutur_Architecte_CyberSec_Labo.BLL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.MVC.Models;
using Technofutur_Architecte_CyberSec_Labo.MVC.Models.FormModel.Password;
using Technofutur_Architecte_CyberSec_Labo.MVC.Models.Mappers;
using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;

namespace Technofutur_Architecte_CyberSec_Labo.MVC.Controllers
{
	public class PasswordController : Controller
	{
		private readonly IPasswordService _passwordService;

		public PasswordController(IPasswordService passwordService)
		{
			_passwordService = passwordService;
		}

		[Authorize]
		[HttpGet]
		public IActionResult Index()
		{
			if (!HttpContext.Session.TryGetValue("UserEncryptionKey", out byte[] keyBytes)){
				HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
				return RedirectToAction("", "Login");
			}

			bool isLoggedUserIdInt = int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int loggedUserId);

			if (isLoggedUserIdInt)
			{
				List<PasswordViewModel> pvm = new List<PasswordViewModel>();

				foreach (var p in _passwordService.GetAllUserPwd(loggedUserId, keyBytes))
				{
					pvm.Add(PasswordMapper.WebsitePwdModelToViewModel(p));
				}

				return View(pvm);
			}

			return BadRequest();
		}

		[Authorize]
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		public IActionResult Create(CreatePwdModel createPwdModel)
		{
			bool isLoggedUserIdInt = int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int loggedUserId);

			if (!HttpContext.Session.TryGetValue("UserEncryptionKey", out byte[] keyBytes))
			{
				HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
				return RedirectToAction("", "Login");
			}

			WebsitePwdModel newWpm = new WebsitePwdModel
			{
				UserId = loggedUserId,
				Name = createPwdModel.Name,
				Website = createPwdModel.Website,
				Password = createPwdModel.Password
			};

			Console.WriteLine(loggedUserId);

			if (isLoggedUserIdInt && ModelState.IsValid)
			{
				WebsitePwdModel? websitePwdModel = _passwordService.Create(newWpm, keyBytes);
				return RedirectToAction("Index");
			}

			return BadRequest();
		}
	}
}
