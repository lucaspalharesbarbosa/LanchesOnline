using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesOnline.Models {
    [Table("ItensCarrinhosCompras")]
    public class ItemCarrinhoCompra {
        public int Id { get; set; }

        public int IdLanche { get; set; }
        public Lanche Lanche { get; set; }

        public int Quantidade { get; set; }

        public string IdCarrinhoCompra { get; set; }
    }
}