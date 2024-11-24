using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options)
        {
        }
        public DbSet<Equipamento> Equipamento { get; set; } = default!;
        public DbSet<ClienteModel> ClienteModel { get; set; } = default!;
        public DbSet<ReservaModel> ReservaModel { get; set; } = default!;
        public DbSet<Sala> Sala { get; set; } = default!;
        public DbSet<TipoSala> TipoSala { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure all string properties globally for SQLite
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string))
                    {
                        property.SetMaxLength(8000); // Safe limit for SQLite compatibility
                        property.SetColumnType("TEXT");
                    }
                }
            }
        }

    }
}