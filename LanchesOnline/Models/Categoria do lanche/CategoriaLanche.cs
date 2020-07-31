using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesOnline.Models {
    [Table("CategoriasLanches")]
    public class CategoriaLanche {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Lanche> Lanches { get; set; }
    }
}