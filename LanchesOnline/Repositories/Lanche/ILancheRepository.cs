using LanchesOnline.Models;
using System.Collections.Generic;

namespace LanchesOnline.Repositories.Interfaces {
    public interface ILancheRepository {
        Lanche GetLancheById(int id);
        IEnumerable<Lanche> ObterLanches { get; }
        IEnumerable<Lanche> ObterLanchesPreferidos { get; }
    }
}