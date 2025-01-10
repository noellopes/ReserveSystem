using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace ReserveSystem.Data
{
    public class ReserveSystemUsersDbContext : IdentityDbContext
    {
        public ReserveSystemUsersDbContext(DbContextOptions<ReserveSystemUsersDbContext> options)
            : base(options)
        {
        }
        public DbSet<ReserveSystem.Models.TQePreco> TQePreco { get; set; } = default!;
        
        
        public DbSet<ReserveSystem.Models.Events> Events { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Sazonalidade> Sazonalidade { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Booking> Booking { get; set; } = default!;
        public DbSet<ReserveSystem.Models.RoomBooking> RoomBooking { get; set; } = default!;
    }
}
