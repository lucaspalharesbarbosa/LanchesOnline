using LanchesOnline.Context;
using LanchesOnline.Models;
using LanchesOnline.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LanchesOnline.Repositories {
    public class CategoriaLancheRepository : ICategoriaLancheRepository {
        private readonly LanchesOnlineContext _db;

        public CategoriaLancheRepository(LanchesOnlineContext db) {
            _db = db;
        }

        public IEnumerable<CategoriaLanche> ObterCategorias => _db.CategoriasLanches.ToArray();
    }
}