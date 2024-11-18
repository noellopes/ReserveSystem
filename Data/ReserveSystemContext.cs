using Microsoft.EntityFrameworkCore;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
<<<<<<< Updated upstream
=======
        public DbSet<ReserveSystem.Models.PersonalTrainerModel> PersonalTrainer { get; set; } = default!;
>>>>>>> Stashed changes
    }
}
