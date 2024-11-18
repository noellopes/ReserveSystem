using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemUsersDbContext : IdentityDbContext
    {
        public ReserveSystemUsersDbContext(DbContextOptions<ReserveSystemUsersDbContext> options)
            : base(options)
        {
        }
        public DbSet<ReserveSystem.Models.PrecoTipoQuarto> PrecoTipoQuarto { get; set; } = default!;

        /*
        public DbSet<TipoQuarto> TipoQuartos { get; set; } = default!;
        public DbSet<PrecoTipoQuarto> PrecoTipoQuartos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Keeps Identity configurations intact

            // Seed data for TipoQuarto
            modelBuilder.Entity<TipoQuarto>().HasData(
                new TipoQuarto { TipoQuartoId = 1, type = "Single Room", capacity = 1, RoomQuantity = 10, AcessibilityRoom = true, View = false },
                new TipoQuarto { TipoQuartoId = 2, type = "Double Room", capacity = 2, RoomQuantity = 15, AcessibilityRoom = true, View = true }
            );

            // Configure relationships
            modelBuilder.Entity<TipoQuarto>()
                .HasOne(tq => tq.PrecoTipoQuarto)
                .WithOne(ptq => ptq.TipoQuarto)
                .HasForeignKey<PrecoTipoQuarto>(ptq => ptq.TipoQuartoId);
        }
        */
    }
}
