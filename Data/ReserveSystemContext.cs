using Microsoft.EntityFrameworkCore;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
<<<<<<< HEAD

=======
<<<<<<< Updated upstream
=======
        public DbSet<ReserveSystem.Models.PersonalTrainerModel> PersonalTrainer { get; set; } = default!;
>>>>>>> Stashed changes
>>>>>>> a63cfa9949389b21f4bf574611a4a1543a965846
    }
}
