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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
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
			modelBuilder.Entity<ExcursaoModel>().HasData(
		new ExcursaoModel { ExcursaoId = 1, Titulo = "Tour Histórico de Lisboa", Descricao = "Descubra os principais pontos históricos de Lisboa.", Data_Inicio = new DateTime(2025, 1, 10, 9, 0, 0), Data_Fim = new DateTime(2025, 1, 10, 18, 0, 0), Preco = 50.00f, StaffId = 1 },
		new ExcursaoModel { ExcursaoId = 2, Titulo = "Rota dos Vinhos do Douro", Descricao = "Explore as melhores vinícolas da região do Douro.", Data_Inicio = new DateTime(2025, 1, 12, 8, 30, 0), Data_Fim = new DateTime(2025, 1, 12, 17, 0, 0), Preco = 75.00f, StaffId = 2 },
		new ExcursaoModel { ExcursaoId = 3, Titulo = "Caminhada na Serra da Estrela", Descricao = "Aproveite uma trilha guiada na Serra da Estrela.", Data_Inicio = new DateTime(2025, 1, 15, 7, 0, 0), Data_Fim = new DateTime(2025, 1, 15, 16, 0, 0), Preco = 60.00f, StaffId = 3 },
		new ExcursaoModel { ExcursaoId = 4, Titulo = "Passeio de Barco no Rio Tejo", Descricao = "Uma experiência relaxante navegando pelo Rio Tejo.", Data_Inicio = new DateTime(2025, 1, 18, 10, 0, 0), Data_Fim = new DateTime(2025, 1, 18, 13, 0, 0), Preco = 40.00f, StaffId = 4 },
		new ExcursaoModel { ExcursaoId = 5, Titulo = "Visita ao Mosteiro da Batalha", Descricao = "Conheça a história do Mosteiro da Batalha.", Data_Inicio = new DateTime(2025, 1, 20, 9, 30, 0), Data_Fim = new DateTime(2025, 1, 20, 12, 30, 0), Preco = 35.00f, StaffId = 5 },
		new ExcursaoModel { ExcursaoId = 6, Titulo = "Exploração de Évora", Descricao = "Uma excursão pelos monumentos históricos de Évora.", Data_Inicio = new DateTime(2025, 1, 22, 9, 0, 0), Data_Fim = new DateTime(2025, 1, 22, 17, 0, 0), Preco = 65.00f, StaffId = 6 },
		new ExcursaoModel { ExcursaoId = 7, Titulo = "Safari Fotográfico na Arrábida", Descricao = "Capture as vistas incríveis da Serra da Arrábida.", Data_Inicio = new DateTime(2025, 1, 25, 8, 0, 0), Data_Fim = new DateTime(2025, 1, 25, 18, 0, 0), Preco = 80.00f, StaffId = 7 },
		new ExcursaoModel { ExcursaoId = 8, Titulo = "Passeio Cultural em Sintra", Descricao = "Explore os palácios e paisagens de Sintra.", Data_Inicio = new DateTime(2025, 1, 28, 9, 30, 0), Data_Fim = new DateTime(2025, 1, 28, 17, 30, 0), Preco = 70.00f, StaffId = 8 },
		new ExcursaoModel { ExcursaoId = 9, Titulo = "Tour Gastronômico em Porto", Descricao = "Descubra a culinária local do Porto.", Data_Inicio = new DateTime(2025, 1, 30, 11, 0, 0), Data_Fim = new DateTime(2025, 1, 30, 14, 0, 0), Preco = 50.00f, StaffId = 9 },
		new ExcursaoModel { ExcursaoId = 10, Titulo = "Exploração da Ria Formosa", Descricao = "Um passeio pelas águas e ilhas da Ria Formosa.", Data_Inicio = new DateTime(2025, 2, 2, 10, 0, 0), Data_Fim = new DateTime(2025, 2, 2, 15, 0, 0), Preco = 60.00f, StaffId = 10 },
		new ExcursaoModel { ExcursaoId = 11, Titulo = "Tour Noturno em Lisboa", Descricao = "Descubra a magia de Lisboa à noite.", Data_Inicio = new DateTime(2025, 2, 5, 19, 0, 0), Data_Fim = new DateTime(2025, 2, 5, 23, 0, 0), Preco = 45.00f, StaffId = 11 },
		new ExcursaoModel { ExcursaoId = 12, Titulo = "Exploração Subterrânea em Mira de Aire", Descricao = "Visite as Grutas de Mira de Aire e suas formações únicas.", Data_Inicio = new DateTime(2025, 2, 7, 10, 0, 0), Data_Fim = new DateTime(2025, 2, 7, 12, 30, 0), Preco = 30.00f, StaffId = 12 },
		new ExcursaoModel { ExcursaoId = 13, Titulo = "Aventura em Peneda-Gerês", Descricao = "Explore a natureza e a beleza do Parque Nacional Peneda-Gerês.", Data_Inicio = new DateTime(2025, 2, 10, 9, 0, 0), Data_Fim = new DateTime(2025, 2, 10, 18, 0, 0), Preco = 85.00f, StaffId = 13 },
		new ExcursaoModel { ExcursaoId = 14, Titulo = "Passeio pelas Aldeias Históricas de Portugal", Descricao = "Conheça as aldeias encantadoras e cheias de história.", Data_Inicio = new DateTime(2025, 2, 12, 8, 0, 0), Data_Fim = new DateTime(2025, 2, 12, 19, 0, 0), Preco = 95.00f, StaffId = 14 },
		new ExcursaoModel { ExcursaoId = 15, Titulo = "Cruzeiro no Rio Douro", Descricao = "Um passeio inesquecível pelo Rio Douro.", Data_Inicio = new DateTime(2025, 2, 15, 11, 0, 0), Data_Fim = new DateTime(2025, 2, 15, 15, 0, 0), Preco = 55.00f, StaffId = 15 },
		new ExcursaoModel { ExcursaoId = 16, Titulo = "Passeio de Bicicleta no Alentejo", Descricao = "Descubra o Alentejo sobre duas rodas.", Data_Inicio = new DateTime(2025, 2, 18, 9, 0, 0), Data_Fim = new DateTime(2025, 2, 18, 13, 0, 0), Preco = 40.00f, StaffId = 16 },
		new ExcursaoModel { ExcursaoId = 17, Titulo = "Roteiro Literário de Fernando Pessoa", Descricao = "Siga os passos do grande poeta em Lisboa.", Data_Inicio = new DateTime(2025, 2, 20, 10, 0, 0), Data_Fim = new DateTime(2025, 2, 20, 12, 0, 0), Preco = 25.00f, StaffId = 17 },
		new ExcursaoModel { ExcursaoId = 18, Titulo = "Passeio pelos Castelos de Portugal", Descricao = "Uma jornada pelos castelos mais icônicos do país.", Data_Inicio = new DateTime(2025, 2, 23, 9, 0, 0), Data_Fim = new DateTime(2025, 2, 23, 18, 0, 0), Preco = 70.00f, StaffId = 18 },
		new ExcursaoModel { ExcursaoId = 19, Titulo = "Observação de Golfinhos no Algarve", Descricao = "Viva uma experiência única no Algarve.", Data_Inicio = new DateTime(2025, 2, 25, 9, 30, 0), Data_Fim = new DateTime(2025, 2, 25, 12, 30, 0), Preco = 50.00f, StaffId = 19 },
		new ExcursaoModel { ExcursaoId = 20, Titulo = "Tour de Arte Urbana em Lisboa", Descricao = "Descubra a vibrante arte de rua de Lisboa.", Data_Inicio = new DateTime(2025, 2, 27, 10, 0, 0), Data_Fim = new DateTime(2025, 2, 27, 13, 0, 0), Preco = 35.00f, StaffId = 20 },
		new ExcursaoModel { ExcursaoId = 21, Titulo = "Rota da Amendoeira em Flor", Descricao = "Encante-se com as paisagens da amendoeira em flor.", Data_Inicio = new DateTime(2025, 3, 1, 9, 0, 0), Data_Fim = new DateTime(2025, 3, 1, 17, 0, 0), Preco = 75.00f, StaffId = 21 },
		new ExcursaoModel { ExcursaoId = 22, Titulo = "Passeio pelas Praias do Alentejo", Descricao = "Relaxe nas praias deslumbrantes do Alentejo.", Data_Inicio = new DateTime(2025, 3, 3, 8, 30, 0), Data_Fim = new DateTime(2025, 3, 3, 18, 30, 0), Preco = 65.00f, StaffId = 22 },
		new ExcursaoModel { ExcursaoId = 23, Titulo = "Tour Histórico em Coimbra", Descricao = "Explore a rica história e cultura de Coimbra.", Data_Inicio = new DateTime(2025, 3, 5, 9, 30, 0), Data_Fim = new DateTime(2025, 3, 5, 12, 30, 0), Preco = 40.00f, StaffId = 23 },
		new ExcursaoModel { ExcursaoId = 24, Titulo = "Visita às Furnas de São Miguel", Descricao = "Uma experiência nas furnas vulcânicas de São Miguel.", Data_Inicio = new DateTime(2025, 3, 7, 10, 0, 0), Data_Fim = new DateTime(2025, 3, 7, 15, 0, 0), Preco = 50.00f, StaffId = 24 },
		new ExcursaoModel { ExcursaoId = 25, Titulo = "Jornada pelas Ilhas Berlengas", Descricao = "Uma excursão marítima inesquecível nas Berlengas.", Data_Inicio = new DateTime(2025, 3, 10, 8, 0, 0), Data_Fim = new DateTime(2025, 3, 10, 18, 0, 0), Preco = 80.00f, StaffId = 25 }
	);


		}
	}
}
