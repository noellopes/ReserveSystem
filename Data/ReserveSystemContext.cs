using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }
        public DbSet<ClientModel> Client { get; set; }
        public DbSet<BookingModel> Booking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientModel>()
                .HasIndex(c => c.Identification)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<RoomModel> Room { get; set; }

    }
}
