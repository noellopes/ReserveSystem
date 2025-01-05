using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
       
        public DbSet<ReserveSystem.Models.ExcursaoModel> ExcursaoModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.StaffModel> StaffModel { get; set; } = default!;

		public DbSet<ReserveSystem.Models.PrecarioModel> PrecarioModel { get; set; } = default!;

		/*protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<StaffModel>().HasData(
				new StaffModel { StaffId = 1, Staff_Name = "João Silva", Job_Name = "Motorista" },
				new StaffModel { StaffId = 2, Staff_Name = "Maria Oliveira", Job_Name = "Gestor de Excursão" },
				new StaffModel { StaffId = 3, Staff_Name = "Carlos Santos", Job_Name = "Guia Turistico" },
				new StaffModel { StaffId = 4, Staff_Name = "Ana Souza", Job_Name = "Motorista" },
				new StaffModel { StaffId = 5, Staff_Name = "Pedro Almeida", Job_Name = "Gestor de Excursão" },
				new StaffModel { StaffId = 6, Staff_Name = "Luciana Costa", Job_Name = "Guia Turistico" },
				new StaffModel { StaffId = 7, Staff_Name = "Rafael Gomes", Job_Name = "Motorista" },
				new StaffModel { StaffId = 8, Staff_Name = "Fernanda Carvalho", Job_Name = "Gestor de Excursão" },
				new StaffModel { StaffId = 9, Staff_Name = "Ricardo Pereira", Job_Name = "Guia Turistico" },
				new StaffModel { StaffId = 10, Staff_Name = "Juliana Mendes", Job_Name = "Motorista" },
				new StaffModel { StaffId = 11, Staff_Name = "Gustavo Rocha", Job_Name = "Gestor de Excursão" },
				new StaffModel { StaffId = 12, Staff_Name = "Camila Ribeiro", Job_Name = "Guia Turistico" },
				new StaffModel { StaffId = 13, Staff_Name = "André Lima", Job_Name = "Motorista" },
				new StaffModel { StaffId = 14, Staff_Name = "Patrícia Fonseca", Job_Name = "Gestor de Excursão" },
				new StaffModel { StaffId = 15, Staff_Name = "Tiago Martins", Job_Name = "Guia Turistico" },
				new StaffModel { StaffId = 16, Staff_Name = "Letícia Freitas", Job_Name = "Motorista" },
				new StaffModel { StaffId = 17, Staff_Name = "Bruno Vieira", Job_Name = "Gestor de Excursão" },
				new StaffModel { StaffId = 18, Staff_Name = "Sara Fernandes", Job_Name = "Guia Turistico" },
				new StaffModel { StaffId = 19, Staff_Name = "Rodrigo Lopes", Job_Name = "Motorista" },
				new StaffModel { StaffId = 20, Staff_Name = "Natália Correia", Job_Name = "Gestor de Excursão" },
				new StaffModel { StaffId = 21, Staff_Name = "Eduardo Cardoso", Job_Name = "Guia Turistico" },
				new StaffModel { StaffId = 22, Staff_Name = "Carolina Neves", Job_Name = "Motorista" },
				new StaffModel { StaffId = 23, Staff_Name = "Diego Farias", Job_Name = "Gestor de Excursão" },
				new StaffModel { StaffId = 24, Staff_Name = "Vanessa Moreira", Job_Name = "Guia Turistico" },
				new StaffModel { StaffId = 25, Staff_Name = "Felipe Azevedo", Job_Name = "Motorista" }
			);


		}*/
	}
}
