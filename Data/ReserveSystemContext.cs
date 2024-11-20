using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<ClienteModel> Cliente { get; set; } 
<<<<<<< HEAD
        public DbSet<ReservaModel> Reserva { get; set; }

        public DbSet<Rooms> Rooms { get; set; }
=======
        public DbSet<ReservaModel> ReservaModel { get; set; }
>>>>>>> b29d626a672cb51f7812c108ab4327b4e71e48e1
    }
}
