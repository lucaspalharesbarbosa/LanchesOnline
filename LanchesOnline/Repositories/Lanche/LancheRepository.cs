using LanchesOnline.Context;
using LanchesOnline.Models;
using LanchesOnline.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LanchesOnline.Repositories {
    public class LancheRepository : ILancheRepository {
        private readonly LanchesOnlineContext _db;

        public LancheRepository(LanchesOnlineContext db) {
            _db = db;
        }

        public Lanche GetLancheById(int id) {
            return _db.Lanches.FirstOrDefault(lanche => lanche.Id == id);
        }

        public IEnumerable<Lanche> ObterLanches => _db.Lanches.Include(lanche => lanche.Categoria).ToArray();

        public IEnumerable<Lanche> ObterLanchesPreferidos => _db.Lanches.Where(lanche => lanche.EhLanchePreferido).ToArray();
       
    }
}