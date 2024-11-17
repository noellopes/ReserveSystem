using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<Equipamento> Equipamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.Entity<Equipamento>().ToTable("Equipamento"); 
            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<ReserveSystem.Models.ClienteModel> ClienteModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ReservaModel> ReservaModel { get; set; } = default!;
    }
}
