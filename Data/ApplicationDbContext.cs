using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ReserveSystem.Models.Reserva> Reserva { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Prato> Prato { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Mesa> Mesa { get; set; } = default!;
    }
}
