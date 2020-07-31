using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesOnline.Models {
    [Table("Lanches")]
    public class Lanche {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string DescricaoCurta { get; set; }

        public string DescricaoDetalhada { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        public string UrlImagem { get; set; }

        public string UrlImagemThumbnail { get; set; }

        public bool EhLanchePreferido { get; set; }

        public bool PossuiEstoque { get; set; }

        public int IdCategoria { get; set; }

        public CategoriaLanche Categoria { get; set; }
    }
}