using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<BookingModel> Booking { get; set; }
        //public DbSet<Rooms> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Enforce unique constraint on NIF
            modelBuilder.Entity<ClientModel>()
                .HasIndex(c => c.NIF)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ReserveSystem.Models.ClientModel> ClientModel { get; set; } = default!;
    }
}
