using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }
        public DbSet<ReserveSystem.Models.Booking> Booking { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Cleaning> Cleaning { get; set; } = default!;
        public DbSet<ReserveSystem.Models.CleaningShedule> CleaningShedule { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Client> Client { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Consumptions> Consumptions { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ItemRoom> ItemRoom { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Items> Items { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Job> Job { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Room> Room { get; set; } = default!;
        public DbSet<ReserveSystem.Models.RoomBooking> RoomBooking { get; set; } = default!;
        public DbSet<ReserveSystem.Models.RoomType> RoomType { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Staff> Staff { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento entre CleaningShedule e Cleaning
            modelBuilder.Entity<CleaningShedule>()
                .HasOne(cs => cs.cleaning)
                .WithMany()
                .HasForeignKey(cs => cs.CleaningId)
                .OnDelete(DeleteBehavior.NoAction);  // Evita múltiplos caminhos de cascata

            // Relacionamento entre CleaningShedule e RoomBooking
            modelBuilder.Entity<CleaningShedule>()
                .HasOne(cs => cs.roomBooking)
                .WithMany()
                .HasForeignKey(cs => cs.RoomBookingId)
                .OnDelete(DeleteBehavior.NoAction); // Evita múltiplos caminhos de cascata

            // Relacionamento entre CleaningShedule e Staff
            modelBuilder.Entity<CleaningShedule>()
                .HasOne(cs => cs.staff)
                .WithMany()
                .HasForeignKey(cs => cs.StaffId)
                .OnDelete(DeleteBehavior.NoAction);  // Evita múltiplos caminhos de cascata

            // Relacionamento entre Consumptions e Client
            modelBuilder.Entity<Consumptions>()
                .HasOne(c => c.client)
                .WithMany()
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.NoAction);  // Evita múltiplos caminhos de cascata

            // Relacionamento entre Consumptions e ItemRoom
            modelBuilder.Entity<Consumptions>()
                .HasOne(c => c.itemRoom)
                .WithMany()
                .HasForeignKey(c => c.ItemRoomId)
                .OnDelete(DeleteBehavior.NoAction);  // Evita múltiplos caminhos de cascata

            base.OnModelCreating(modelBuilder);
        }
    }
}
