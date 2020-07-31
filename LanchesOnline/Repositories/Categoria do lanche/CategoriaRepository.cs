using LanchesOnline.Models;
using LanchesOnline.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace LanchesOnline.Repositories {
    public class CategoriaRepository : ICategoriaLancheRepository {
        public CategoriaRepository() {
            
        }

        public IEnumerable<CategoriaLanche> Categorias => throw new NotImplementedException();
    }
}