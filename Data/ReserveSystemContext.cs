using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }
        public DbSet<ReserveSystem.Models.Job> Job { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Staff> Staff { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Client> Client { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Booking> Booking { get; set; } = default!;
    }
}
