using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : DbContext(options)
    {

        // https://stackoverflow.com/questions/46526230/disable-cascade-delete-on-ef-core-2-globally
        /* protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Conventions.Remove(typeof(CascadeDeleteConvention));
            configurationBuilder.Conventions.Remove(typeof(SqlServerOnDeleteConvention));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.Categories)
                .HasForeignKey(bc => bc.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(b => b.Books)
                .HasForeignKey(bc => bc.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        } */

        public DbSet<ReserveSystem.Models.Client> Client { get; set; } = default!;
        public DbSet<Room> Room { get; set; } = default!;
        public DbSet<Job> Job { get; set; } = default!;
        public DbSet<RoomService> RoomService { get; set; } = default!;
        public DbSet<Staff> Staff { get; set; } = default!;
        public DbSet<Schedule> Schedule { get; set; } = default!;
        public DbSet<RoomServiceBooking> RoomServiceBooking { get; set; } = default!;
    }
}
