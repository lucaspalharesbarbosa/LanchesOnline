using LanchesOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesOnline.Context {
    public class LanchesOnlineContext : DbContext {
        public LanchesOnlineContext(DbContextOptions<LanchesOnlineContext> options) : base(options) { }

        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CategoriaLanche> CategoriasLanches { get; set; }
        public DbSet<CarrinhoCompra> CarrinhosCompras { get; set; }
        public DbSet<ItemCarrinhoCompra> ItensCarrinhosCompras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Lanche>()
                .HasOne(lanche => lanche.Categoria)
                .WithMany(categoria => categoria.Lanches)
                .HasForeignKey(lanche => lanche.IdCategoria);

            modelBuilder.Entity<ItemCarrinhoCompra>()
                .HasOne(item => item.CarrinhoCompra)
                .WithMany(carrinho => carrinho.Itens)
                .HasForeignKey(item => item.IdCarrinhoCompra);

            modelBuilder.Entity<ItemCarrinhoCompra>()
                .HasOne(item => item.Lanche)
                .WithMany(lanche => lanche.ItensCarrinhosComprasVinculados)
                .HasForeignKey(item => item.IdLanche);
        }
    }
}