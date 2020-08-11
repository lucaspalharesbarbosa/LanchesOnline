using LanchesOnline.Models;
using LanchesOnline.Repositories.Interfaces;
using LanchesOnline.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LanchesOnline.Controllers {
    public class CarrinhoCompraController : Controller {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra) {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index() {
            var itens = _carrinhoCompra.ObterListaItens();
            _carrinhoCompra.Itens = itens;

            return View(new CarrinhoCompraViewModel {
                CarrinhoCompra = _carrinhoCompra,
                ValorTotal = _carrinhoCompra.ObterValorTotal()
            });
        }

        public RedirectToActionResult AdicionarItem(int idLanche) {
            var lancheAdicionar = _lancheRepository
                .Lanches
                .FirstOrDefault(lanche => lanche.Id == idLanche);

            _carrinhoCompra.AdicionarItem(lancheAdicionar, 1);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoverItem(int idLanche) {
            var lancheRemover = _lancheRepository
                .Lanches
                .FirstOrDefault(lanche => lanche.Id == idLanche);

            _carrinhoCompra.RemoverItem(lancheRemover);

            return RedirectToAction("Index");
        }
    }
}