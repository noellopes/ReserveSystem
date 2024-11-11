using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemUsersDbContext : IdentityDbContext
    {
        public ReserveSystemUsersDbContext(DbContextOptions<ReserveSystemUsersDbContext> options)
            : base(options)
        {
        }
        public DbSet<ReserveSystem.Models.JobModel> JobModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.DepModel> DepModel { get; set; } = default!;
    }
}
