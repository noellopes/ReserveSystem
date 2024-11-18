using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<Equipamento> Equipamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between ReservaModel and Equipamento
            modelBuilder.Entity<ReservaModel>()
                .HasOne(r => r.Equipamento) // ReservaModel has one Equipamento
                .WithMany() // Equipamento can have many ReservaModels (or use .WithOne() for one-to-one)
                .HasForeignKey(r => r.IdEquipamento);  // Foreign key in ReservaModel

        }
        public DbSet<ReserveSystem.Models.ClienteModel> ClienteModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ReservaModel> ReservaModel { get; set; } = default!;
        
        public DbSet<Sala> Salas { get; set; } = default!;
        
        public DbSet<TipoSala> TipoSalas { get; set; } = default!;
        
    }
}
