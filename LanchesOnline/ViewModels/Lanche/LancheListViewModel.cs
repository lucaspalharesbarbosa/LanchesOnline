using LanchesOnline.Models;
using System.Collections.Generic;

namespace LanchesOnline.ViewModels {
    public class LancheListViewModel {
        public string Categoria { get; set; }

        public IEnumerable<Lanche> Lanches{ get; set; }
    }
}