using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}

        public DbSet<ReserveSystem.Models.Ingredient> Ingredient { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Prato> Prato { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Buffet> Buffet { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ComposicaoPrato> ComposicaoPrato { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Suppliers> Suppliers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura o relacionamento Buffet-Prato (muitos para muitos)
            modelBuilder.Entity<Buffet>()
                .HasMany(b => b.Pratos)
                .WithMany(); // Configura como uma relação muitos para muitos

            base.OnModelCreating(modelBuilder);

            // Configuração da tabela ComposicaoPrato
            modelBuilder.Entity<ComposicaoPrato>()
                .HasKey(cp => cp.ComposicaoPratoID); // Define a chave primária

            modelBuilder.Entity<ComposicaoPrato>()
                .HasOne(cp => cp.Prato)
                .WithMany(p => p.ComposicaoPratos) // Relacionamento 1:N com Prato
                .HasForeignKey(cp => cp.PratoID)
                .OnDelete(DeleteBehavior.Cascade); // Elimina a composição se o prato for eliminado

            modelBuilder.Entity<ComposicaoPrato>()
                .HasOne(cp => cp.Ingredient)
                .WithMany() // Relacionamento N:N com Ingredient
                .HasForeignKey(cp => cp.IngredientID)
                .OnDelete(DeleteBehavior.Restrict); // Restringe a eliminação de um ingrediente se estiver numa composição

            // Configurar a precisão da quantidade
            modelBuilder.Entity<ComposicaoPrato>()
                .Property(cp => cp.IngredientQuantity)
                .HasColumnType("decimal(18,2)");
        }
    }
}
