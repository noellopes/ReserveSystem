using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {

        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }
        public DbSet<ReserveSystem.Models.Job> Job { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Staff> Staff { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Schedules> Schedules { get; set; } = default!;
        public DbSet<ReserveSystem.Models.TypeOfSchedule> TypeOfSchedule { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Booking> Booking { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Room_Booking> Room_Booking { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Room> Room { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Room_Type> Room_Type { get; set; } = default!;
    }
}
