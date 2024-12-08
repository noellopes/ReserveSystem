using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        public DbSet<ReserveSystem.Models.Ingredient> Ingredient { get; set; } = default!;

        public DbSet<ReserveSystem.Models.Stock> Stock { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Prato> Prato { get; set; } = default!;


      /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Ingredient)
                .WithMany(i => i.Stocks)
                .HasForeignKey(s => s.IngredientID);
        }*/
    }
}
