using LanchesOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesOnline.Context {
    public class LanchesOnlineContext : DbContext {
        public LanchesOnlineContext(DbContextOptions<LanchesOnlineContext> options) : base(options) { }

        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CategoriaLanche> CategoriasLanches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Lanche>()
                .HasOne(lanche => lanche.Categoria)
                .WithMany(categoria => categoria.Lanches)
                .HasForeignKey(lanche => lanche.IdCategoria);
        }
    }
}