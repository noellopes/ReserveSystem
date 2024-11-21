using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<Employee> Employee { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Ingredient> Ingrediente { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Quarto> Quarto { get; set; } = default!;
    }
}
