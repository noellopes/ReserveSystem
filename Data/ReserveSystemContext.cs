using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }
        public DbSet<Job> Job { get; set; } = default!;
        public DbSet<RoomService> RoomService { get; set; } = default!;
        public DbSet<ReserveSystem.Models.RoomServicePrice> RoomServicePrice { get; set; } = default!;

        
    }

}
