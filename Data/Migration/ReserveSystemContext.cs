using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        // Construtor que utiliza opções do DbContext
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }

        // DbSet para a entidade Client
        public DbSet<Client> Clients { get; set; }
    }
}
