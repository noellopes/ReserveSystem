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

        public DbSet<Equipamento> Equipamento { get; set; }
        public DbSet<TipoEquipamento> TipoEquipamento { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<TipoReserva> TipoReserva { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<TipoSala> TipoSala { get; set; }
        public DbSet<ClientModel> ClientModel { get; set; }
    }
}
