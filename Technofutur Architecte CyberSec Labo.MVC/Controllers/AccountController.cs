using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Technofutur_Architecte_CyberSec_Labo.BLL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;
using Technofutur_Architecte_CyberSec_Labo.MVC.Models.Mappers;

namespace Technofutur_Architecte_CyberSec_Labo.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            UserModel? userModel = _userService.GetUserById(id);

            if (userModel is null)
            {
                return NotFound();
            }

            return View(UserMapper.userModelToViewModel(userModel));
        }
    }
}
