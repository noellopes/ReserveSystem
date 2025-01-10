using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveSystem.Data
{
    public class ReserveSystemUsersDbContext : IdentityDbContext
    {
        public ReserveSystemUsersDbContext(DbContextOptions<ReserveSystemUsersDbContext> options)
            : base(options)
        {
        }

        // DbSets para as entidades
        public DbSet<TQePreco> TQePreco { get; set; } = default!;
        public DbSet<Events> Events { get; set; } = default!;
        public DbSet<Sazonalidade> Sazonalidade { get; set; } = default!;
        public DbSet<Booking> Booking { get; set; } = default!;
        public DbSet<RoomBooking> RoomBooking { get; set; } = default!;
        public DbSet<Promos> Promos { get; set; } = default!;
        public DbSet<PricePerDate> PricePerDate { get; set; } = default!;

        // Configurações personalizadas para os relacionamentos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar o relacionamento unidirecional entre PricePerDate e Events
            modelBuilder.Entity<PricePerDate>()
                .HasMany(p => p.Events)
                .WithOne() // Sem referência de volta em Events
                .OnDelete(DeleteBehavior.Cascade); // Comportamento de exclusão (opcional)

            modelBuilder.Entity<PricePerDate>()
                .HasMany(p => p.Sazonalidades)
                .WithOne() // Sem referência de volta em Events
                .OnDelete(DeleteBehavior.Cascade); // Comportamento de exclusão (opcional)

            // Configurar o restante usando base
            base.OnModelCreating(modelBuilder);
        }

        //SaveChanges para calcular o preço antes de salvar
        public override int SaveChanges()
        {
            var updatedPricePerDates = ChangeTracker.Entries<PricePerDate>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in updatedPricePerDates)
            {
                var pricePerDate = entry.Entity;
                pricePerDate.CalculateNewPrice(); // Recalcular o preço antes de salvar
            }

            return base.SaveChanges();
        }

        //SaveChangesAsync para calcular o preço de forma assíncrona
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var updatedPricePerDates = ChangeTracker.Entries<PricePerDate>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in updatedPricePerDates)
            {
                var pricePerDate = entry.Entity;
                pricePerDate.CalculateNewPrice(); // Recalcular o preço antes de salvar
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}


