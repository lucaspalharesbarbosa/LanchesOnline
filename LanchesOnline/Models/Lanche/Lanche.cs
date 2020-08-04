using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesOnline.Models {
    [Table("Lanches")]
    public class Lanche {
        public int Id { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string DescricaoCurta { get; set; }

        [StringLength(255)]
        public string DescricaoDetalhada { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preco { get; set; }

        [StringLength(200)]
        public string UrlImagem { get; set; }

        [StringLength(200)]
        public string UrlImagemThumbnail { get; set; }

        public bool EhLanchePreferido { get; set; }

        public bool PossuiEstoque { get; set; }

        public int IdCategoria { get; set; }

        public CategoriaLanche Categoria { get; set; }
    }
}