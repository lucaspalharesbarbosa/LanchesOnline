using LanchesOnline.Models;
using System.Collections.Generic;

namespace LanchesOnline.ViewModels {
    public class HomeViewModel {
        public IEnumerable<Lanche> LanchesPreferidos{ get; set; }
    }
}