using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }
        public DbSet<ClientModel> Client { get; set; } = default!;
        public DbSet<Employee> Employee { get; set; } = default!;
        public DbSet<BookingModel> Booking { get; set; }
        public DbSet<RoomModel> Room { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientModel>()
                .HasIndex(c => c.Identification)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
