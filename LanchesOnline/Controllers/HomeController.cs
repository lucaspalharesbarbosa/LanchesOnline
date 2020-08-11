using LanchesOnline.Repositories.Interfaces;
using LanchesOnline.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesOnline.Controllers {
    public class HomeController : Controller {
        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILancheRepository lancheRepository) {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index() {
            return View(new HomeViewModel {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            });
        }
    }
}