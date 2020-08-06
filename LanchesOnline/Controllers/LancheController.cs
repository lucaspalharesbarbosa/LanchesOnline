using LanchesOnline.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesOnline.Controllers {
    public class LancheController : Controller {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoriaLancheRepository _cagegoriaRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoriaLancheRepository cagegoriaRepository) {
            _lancheRepository = lancheRepository;
            _cagegoriaRepository = cagegoriaRepository;
        }

        public IActionResult List() {
            ViewBag.Lanche = "Lanches";
            ViewData["Categoria"] = "Categoria";

            var lanches = _lancheRepository.Lanches;

            return View(lanches);
        }
    }
}