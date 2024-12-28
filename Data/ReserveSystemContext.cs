using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : DbContext(options)
    {
        public DbSet<Job> Job { get; set; } = default!;

        public DbSet<Schedule> Schedule { get; set; } = default!;
        
        public DbSet<Client> Client { get; set; } = default!;
        
        public DbSet<Room> Room { get; set; } = default!;
        
        public DbSet<Employee> Employee { get; set; } = default!;

        public DbSet<Staff> Staff { get; set; } = default!;
        
        public DbSet<RoomService> RoomService { get; set; } = default!;

        public DbSet<RoomServiceBooking> RoomServiceBooking { get; set; } = default!;
    }
}
