using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
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

    }
}
