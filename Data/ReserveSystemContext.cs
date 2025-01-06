using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {

        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }
        public DbSet<ReserveSystem.Models.Transporte> Transporte { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Staff> Staff { get; set; } = default!;
        public DbSet<ReserveSystem.Models.MotoristaTransporte> MotoristaTransporte { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Staff>().HasData(
 new Staff { StaffId = 26, Staff_Name = "João Silva", Job_Name = "Motorista", TipoCarta = "C" },
new Staff { StaffId = 27, Staff_Name = "Maria Ferreira", Job_Name = "Guia Turístico" },
new Staff { StaffId = 28, Staff_Name = "Carlos Mendes", Job_Name = "Motorista", TipoCarta = "D" },
new Staff { StaffId = 29, Staff_Name = "Ana Costa", Job_Name = "Gestor de Excursão" },
new Staff { StaffId = 30, Staff_Name = "Luís Pereira", Job_Name = "Motorista", TipoCarta = "C+E" },
new Staff { StaffId = 31, Staff_Name = "Rita Oliveira", Job_Name = "Guia Turístico" },
new Staff { StaffId = 32, Staff_Name = "Pedro Santos", Job_Name = "Motorista", TipoCarta = "B" },
new Staff { StaffId = 33, Staff_Name = "Marta Lopes", Job_Name = "Gestor de Excursão" },
new Staff { StaffId = 34, Staff_Name = "Fernando Gomes", Job_Name = "Motorista", TipoCarta = "D+E" },
new Staff { StaffId = 35, Staff_Name = "Cláudia Neves", Job_Name = "Guia Turístico" },
new Staff { StaffId = 36, Staff_Name = "António Silva", Job_Name = "Motorista", TipoCarta = "C" },
new Staff { StaffId = 37, Staff_Name = "Beatriz Sousa", Job_Name = "Gestor de Excursão" },
new Staff { StaffId = 38, Staff_Name = "Ricardo Teixeira", Job_Name = "Motorista", TipoCarta = "D" },
new Staff { StaffId = 39, Staff_Name = "Joana Martins", Job_Name = "Guia Turístico" },
new Staff { StaffId = 40, Staff_Name = "Tiago Rocha", Job_Name = "Motorista", TipoCarta = "C+E" },
new Staff { StaffId = 41, Staff_Name = "Helena Ribeiro", Job_Name = "Gestor de Excursão" },
new Staff { StaffId = 42, Staff_Name = "José Almeida", Job_Name = "Motorista", TipoCarta = "B" },
new Staff { StaffId = 43, Staff_Name = "Sofia Silva", Job_Name = "Guia Turístico" },
new Staff { StaffId = 44, Staff_Name = "Vítor Pinto", Job_Name = "Motorista", TipoCarta = "C" },
new Staff { StaffId = 45, Staff_Name = "Catarina Azevedo", Job_Name = "Gestor de Excursão" },
new Staff { StaffId = 46, Staff_Name = "André Matos", Job_Name = "Motorista", TipoCarta = "D+E" },
new Staff { StaffId = 47, Staff_Name = "Patrícia Lima", Job_Name = "Guia Turístico" },
new Staff { StaffId = 48, Staff_Name = "Eduardo Nunes", Job_Name = "Motorista", TipoCarta = "B" },
new Staff { StaffId = 49, Staff_Name = "Carla Moreira", Job_Name = "Gestor de Excursão" },
new Staff { StaffId = 50, Staff_Name = "Bruno Tavares", Job_Name = "Motorista", TipoCarta = "C" }







            );
            modelBuilder.Entity<Transporte>().HasData(

        }

    }
}


