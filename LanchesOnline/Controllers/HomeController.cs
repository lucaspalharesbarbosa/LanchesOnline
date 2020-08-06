using LanchesOnline.Repositories.Interfaces;
using LanchesOnline.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LanchesOnline.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILogger<HomeController> logger, ILancheRepository lancheRepository) {
            _logger = logger;
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index() {
            return View(new HomeViewModel {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            }); ;
        }

        public IActionResult Privacy() {
            return View();
        }
    }
}