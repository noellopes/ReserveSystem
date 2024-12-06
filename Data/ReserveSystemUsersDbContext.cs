using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ReserveSystem.Data
{
    public class ReserveSystemUsersDbContext : IdentityDbContext
    {
        public ReserveSystemUsersDbContext(DbContextOptions<ReserveSystemUsersDbContext> options)
            : base(options)
        {
        }
        public DbSet<ReserveSystem.Models.PersonalTrainerModel> PersonalTrainer { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ClientModel> Client { get; set; } = default!;
        public DbSet<ReserveSystem.Models.SpaceModel> Spaces { get; set; } = default!;

        public DbSet<ReserveSystem.Models.ReservaModel> Reserva { get; set; } = default!;
    }
}
