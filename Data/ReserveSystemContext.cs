using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}

        public DbSet<ReserveSystem.Models.Job> Job { get; set; }
        public DbSet<ReserveSystem.Models.Staff> Staff { get; set; }

        public DbSet<ReserveSystem.Models.Client> Client { get; set; }

        public DbSet<ReserveSystem.Models.RoomService> RoomService { get; set; }

        public DbSet<ReserveSystem.Models.Room> Room { get; set; }


        public DbSet<ReserveSystem.Models.RoomServicesBooking> RoomServiceBooking { get; set; } = default!;

    }
}
