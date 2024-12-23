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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura o relacionamento Buffet-Prato (muitos para muitos)
            modelBuilder.Entity<Buffet>()
                .HasMany(b => b.Pratos)
                .WithMany(); // Configura como uma relação muitos para muitos
        }
    }
}
