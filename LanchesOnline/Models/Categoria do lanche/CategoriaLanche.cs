using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesOnline.Models {
    [Table("CategoriasLanches")]
    public class CategoriaLanche {
        public int Id { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }

        public IEnumerable<Lanche> Lanches { get; set; }
    }
}