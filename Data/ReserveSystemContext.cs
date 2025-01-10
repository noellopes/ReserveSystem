using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data.Migrations;
using ReserveSystem.Models;
using System.IO;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {

        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }
        public DbSet<ReserveSystem.Models.PersonalTrainerModel> PersonalTrainer { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ClientModel> Client { get; set; } = default!;
        public DbSet<ReserveSystem.Models.SpaceModel> Spaces { get; set; } = default!;
        public DbSet<ReserveSystem.Models.HorarioModel> HorarioModel { get; set; } = default!;

        public DbSet<ReserveSystem.Models.ReservaModel> Reserva { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientModel>()
                .HasIndex(c => c.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
