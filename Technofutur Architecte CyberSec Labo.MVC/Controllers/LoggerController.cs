using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Technofutur_Architecte_CyberSec_Labo.BLL.Interfaces;

namespace Technofutur_Architecte_CyberSec_Labo.MVC.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILoggerDbService _loggerService;

        public LoggerController(ILoggerDbService loggerDbService)
        {
            _loggerService = loggerDbService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_loggerService.GetAll());
        }
    }
}
