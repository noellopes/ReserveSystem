using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<ReserveSystem.Models.JobTestModel> JobTestModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.StaffTestModel> StaffTestModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ExcursaoModel> ExcursaoModel { get; set; } = default!;
    }
}
