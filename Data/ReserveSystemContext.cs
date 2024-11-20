using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Employee> Employee { get; set; } = default!;
    }
}
