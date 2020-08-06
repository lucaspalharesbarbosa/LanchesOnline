using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesOnline.Models {
    [Table("CarrinhosCompras")]
    public class CarrinhoCompra {
        public int Id { get; set; }

        public IEnumerable<ItemCarrinhoCompra> Itens { get; set; }
    }
}