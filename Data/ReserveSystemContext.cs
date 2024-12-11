using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) 
            : base(options) 
        {
        }
        
        public DbSet<RoomServiceBooking> RoomServiceBooking { get; set; } = default!;
        
        public DbSet<RoomService> RoomService { get; set; } = default!;
        
        public DbSet<Staff> Staff { get; set; } = default!;
        
        public DbSet<Client> Client { get; set; } = default!;
        
        public DbSet<Room> Room { get; set; } = default!;

        public DbSet<Job> Job { get; set; } = default!;

        public DbSet<Schedule> Schedule { get; set; } = default!;

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomServiceBooking>()
                .HasOne(rsb => rsb.RoomService)
                .WithMany(rs => rs.RoomServiceBookings)
                .HasForeignKey(rsb => rsb.RoomServiceId)
                .HasForeignKey(rsb => rsb.StaffId)
                .HasForeignKey(rsb => rsb.ClientId)
                .HasForeignKey(rsb => rsb.RoomId);
            
            modelBuilder.Entity<RoomServiceBooking>()
                .HasOne(rsb => rsb.Staff)
                .WithMany(s => s.RoomServiceBookings)
                .HasForeignKey(rsb => rsb.StaffId);
            
            modelBuilder.Entity<RoomServiceBooking>()
                .HasOne(rsb => rsb.Client)
                .WithMany(c => c.RoomServiceBookings)
                .HasForeignKey(rsb => rsb.ClientId);
            
            modelBuilder.Entity<RoomServiceBooking>()
                .HasOne(rsb => rsb.Room)
                .WithMany(r => r.RoomServiceBookings)
                .HasForeignKey(rsb => rsb.RoomId);
            
            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Staff)
                .WithMany(s => s.Schedules)
                .HasForeignKey(s => s.StaffId);
            
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Job)
                .WithMany(j => j.Staffs)
                .HasForeignKey(s => s.JobId);
        } */
    }
}
