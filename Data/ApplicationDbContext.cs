using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Definindo o relacionamento entre Reserva e Cliente
        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Cliente) // Reserva tem um Cliente
            .WithMany() // Cliente pode ter muitas Reservas
            .HasForeignKey(r => r.Numerocliente) // A chave estrangeira na tabela Reserva
            .OnDelete(DeleteBehavior.Cascade); // Comportamento de exclusão em cascata
    }
}
