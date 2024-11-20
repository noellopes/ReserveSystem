using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<ClienteModel> Cliente { get; set; } 
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<ReservaModel> ReservaModel { get; set; }
    }
}
