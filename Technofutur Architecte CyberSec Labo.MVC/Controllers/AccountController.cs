using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Technofutur_Architecte_CyberSec_Labo.BLL.Interfaces;
using Technofutur_Architecte_CyberSec_Labo.DOMAIN.Entities;
using Technofutur_Architecte_CyberSec_Labo.MVC.Models.FormModel.User;
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
        public IActionResult Details()
        {
			bool isLoggedUserIdInt = int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int loggedUserId);

            if (isLoggedUserIdInt)
            {
				UserModel? userModel = _userService.GetUserById(loggedUserId);

				if (userModel is null)
				{
					return NotFound();
				}

				return View(UserMapper.userModelToViewModel(userModel));
			}

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserRegisterModel userRegisterModel)
        {
            if (ModelState.IsValid)
            {
                UserModel? userCreated = _userService.Create(UserMapper.userRegisterToUserModel(userRegisterModel));

                if (userCreated is null)
                {
                    return StatusCode(500);
                }

                return RedirectToAction("Login");
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(UserEditModel userEditModel)
        {
            return BadRequest();
        }
    }
}
