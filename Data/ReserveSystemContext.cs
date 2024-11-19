using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<Equipamento> Equipamento { get; set; } = default!;
        public DbSet<ClienteModel> ClienteModel { get; set; } = default!;
        public DbSet<ReservaModel> ReservaModel { get; set; } = default!; 
        
        public DbSet<Sala> Salas { get; set; } = default!;
        
        public DbSet<TipoSala> TipoSalas { get; set; } = default!;

        public void ClearReservaTable() 
        { 
            this.Database.ExecuteSqlRaw("DELETE FROM Reserva"); 
        }

    }
}
