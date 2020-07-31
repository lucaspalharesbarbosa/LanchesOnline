using LanchesOnline.Models;
using System.Collections.Generic;

namespace LanchesOnline.Repositories.Interfaces {
    public interface ICategoriaLancheRepository {
        IEnumerable<CategoriaLanche> Categorias { get; }
    }
}