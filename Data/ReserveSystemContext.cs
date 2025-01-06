using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }
        public DbSet<ClientModel> Client { get; set; } = default!;
        public DbSet<Employee> Employee { get; set; } = default!;
        public DbSet<Booking> Booking { get; set; } = default!;
        public DbSet<RoomModel> Room { get; set; } = default!;
        public DbSet<RoomType> RoomType { get; set; } = default!;

        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<Mesa> Mesa { get; set; } = default!;
        public DbSet<Prato> Prato { get; set; } = default!;
        public DbSet<Reserva> Reserva { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientModel>()
                .HasIndex(c => c.Identification)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
