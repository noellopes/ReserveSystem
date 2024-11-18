using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<Equipamento> Equipamento { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,5133;Database=ReservesUsers;User Id=sa;Password=P@ssw0rd123;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            
            base.OnModelCreating(modelBuilder);

            // Configure ReservaModel and Equipamento relationship
            modelBuilder.Entity<ReservaModel>()
                .HasOne(r => r.Equipamento) // ReservaModel has one Equipamento
                .WithMany() // Equipamento can have many ReservaModels
                .HasForeignKey(r => r.IdEquipamento); // Foreign key in ReservaModel

        }
        public DbSet<ReserveSystem.Models.ClienteModel> ClienteModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ReservaModel> ReservaModel { get; set; } = default!;
        
        public DbSet<Sala> Salas { get; set; } = default!;
        
        public DbSet<TipoSala> TipoSalas { get; set; } = default!;
        
    }
}
