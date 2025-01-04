using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data.Migrations
{
    public class ReserveSystemContext : DbContext
    {

        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }
        public DbSet<Job> Job { get; set; } = default!;
        public DbSet<Staff> Staff { get; set; } = default!;
        public DbSet<Schedules> Schedules { get; set; } = default!;
        public DbSet<TypeOfSchedule> TypeOfSchedule { get; set; } = default!;
        public DbSet<Booking> Booking { get; set; } = default!;
        public DbSet<Room_Booking> Room_Booking { get; set; } = default!;
        public DbSet<Room> Room { get; set; } = default!;
        public DbSet<Room_Type> Room_Type { get; set; } = default!;
        public DbSet<Item_Room> Item_Room { get; set; } = default!;
        public DbSet<Items> Items { get; set; } = default!;
        public DbSet<Consumptions> Consumptions { get; set; } = default!;
        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<Cleaning_Schedule> Cleaning_Schedule { get; set; } = default!;
    }
}
