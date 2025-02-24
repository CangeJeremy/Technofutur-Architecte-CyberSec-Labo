using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Technofutur_Architecte_CyberSec_Labo.MVC.Controllers.Auth
{
    public class LogoutController : Controller
    {
		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public IActionResult Logout()
		{
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();

			return RedirectToAction("Index", "Home");
		}
	}
}
