using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<ReserveSystem.Models.StaffModel> StaffModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.JobModel> JobModel { get; set; } = default!;
    }
}
