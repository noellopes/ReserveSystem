using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<Equipamento> Equipamento { get; set; } = default!;
        
        public DbSet<ReservaModel> ReservaModel { get; set; } = default!; 
        
        public DbSet<Sala> Sala { get; set; } = default!;
        
        public DbSet<TipoSala> TipoSala { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between Reserva and Equipamento
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Equipamento) // Reserva has one Equipamento
                .WithMany() // Equipamento can have many Reservas (or use .WithOne() for one-to-one)
                .HasForeignKey(r => r.IdEquipamento);// Foreign key in Reserva
        }
        public void ClearReservaTable() 
        { 
            this.Database.ExecuteSqlRaw("DELETE FROM Reserva"); 
        }

        public DbSet<ClientModel> ClientModel { get; set; }
        
        //public DbSet<Cliente> Cliente { get; set; } = default!;
        //public DbSet<Reserva> Reserva { get; set; } = default!;
        
        //public DbSet<Sala> Salas { get; set; } = default!;
        
        //public DbSet<TipoSala> TipoSalas { get; set; } = default!;

        

    }
}
