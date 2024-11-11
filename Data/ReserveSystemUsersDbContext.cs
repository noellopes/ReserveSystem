using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemUsersDbContext : IdentityDbContext // Usando IdentityDbContext
    {
        public ReserveSystemUsersDbContext(DbContextOptions<ReserveSystemUsersDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; } // Definindo a DbSet para Cliente
    }
}
