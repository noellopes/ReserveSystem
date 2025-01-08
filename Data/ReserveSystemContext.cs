using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;
using System.Globalization;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {

        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) {}
        
        public DbSet<ReserveSystem.Models.ClienteTestModel> ClienteTestModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ReservaExcursaoModel> ReservaExcursaoModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ExcursaoModel> ExcursaoModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.StaffModel> StaffModel { get; set; } = default!;
		    public DbSet<ReserveSystem.Models.PrecarioModel> PrecarioModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ExcursaoFavoritaModel> ExcursaoFavoritaModel { get; set; } = default!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		/*	modelBuilder.Entity<StaffModel>().HasData(
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
	);*/


		}
	}





            /*  modelBuilder.Entity<ClienteTestModel>().HasData(

                 new ClienteTestModel
                 {
                     ClienteId = 21,
                     Nome = "Carlos Silva",
                     Email = "carlos.silva@email.com",
                     Telefone = "923412453",
                     DataNascimento = new DateTime(1985, 5, 15),
                 },
 new ClienteTestModel
 {
     ClienteId = 22,
     Nome = "Ana Oliveira",
     Email = "ana.oliveira@email.com",
     Telefone = "998765432",
     DataNascimento = new DateTime(1990, 8, 20),
 },
 new ClienteTestModel
 {
     ClienteId = 23,
     Nome = "João Pereira",
     Email = "joao.pereira@email.com",
     Telefone = "987654321",
     DataNascimento = new DateTime(1982, 3, 12),
 },
 new ClienteTestModel
 {
     ClienteId = 24,
     Nome = "Maria Souza",
     Email = "maria.souza@email.com",
     Telefone = "996543210",
     DataNascimento = new DateTime(1978, 11, 2),
 },
 new ClienteTestModel
 {
     ClienteId = 25,
     Nome = "Lucas Costa",
     Email = "lucas.costa@email.com",
     Telefone = "934567890",
     DataNascimento = new DateTime(1993, 7, 25),
 },
 new ClienteTestModel
 {
     ClienteId = 26,
     Nome = "Isabela Almeida",
     Email = "isabela.almeida@email.com",
     Telefone = "945678901",
     DataNascimento = new DateTime(1989, 10, 18),
 },
 new ClienteTestModel
 {
     ClienteId = 27,
     Nome = "Felipe Rocha",
     Email = "felipe.rocha@email.com",
     Telefone = "923456789",
     DataNascimento = new DateTime(1995, 2, 3),
 },
 new ClienteTestModel
 {
     ClienteId = 28,
     Nome = "Carla Martins",
     Email = "carla.martins@email.com",
     Telefone = "911223344",
     DataNascimento = new DateTime(1983, 4, 28),
 },
 new ClienteTestModel
 {
     ClienteId = 29,
     Nome = "Fernando Gomes",
     Email = "fernando.gomes@email.com",
     Telefone = "997654321",
     DataNascimento = new DateTime(1990, 12, 5),
 },
 new ClienteTestModel
 {
     ClienteId = 30,
     Nome = "Beatriz Santos",
     Email = "beatriz.santos@email.com",
     Telefone = "968754321",
     DataNascimento = new DateTime(1988, 9, 22),
 },
 new ClienteTestModel
 {
     ClienteId = 31,
     Nome = "Ricardo Ferreira",
     Email = "ricardo.ferreira@email.com",
     Telefone = "954321098",
     DataNascimento = new DateTime(1992, 1, 14),
 },
 new ClienteTestModel
 {
     ClienteId = 32,
     Nome = "Juliana Silva",
     Email = "juliana.silva@email.com",
     Telefone = "924567890",
     DataNascimento = new DateTime(1994, 6, 30),
 },
 new ClienteTestModel
 {
     ClienteId = 33,
     Nome = "Gabriel Lima",
     Email = "gabriel.lima@email.com",
     Telefone = "917654321",
     DataNascimento = new DateTime(1987, 5, 7),
 },
 new ClienteTestModel
 {
     ClienteId = 34,
     Nome = "Mariana Costa",
     Email = "mariana.costa@email.com",
     Telefone = "935678902",
     DataNascimento = new DateTime(1991, 11, 23),
 },
 new ClienteTestModel
 {
     ClienteId = 35,
     Nome = "Vitor Hugo",
     Email = "vitor.hugo@email.com",
     Telefone = "945678901",
     DataNascimento = new DateTime(1980, 2, 17),
 },
 new ClienteTestModel
 {
     ClienteId = 36,
     Nome = "Larissa Oliveira",
     Email = "larissa.oliveira@email.com",
     Telefone = "923456788",
     DataNascimento = new DateTime(1994, 12, 9),
 },
 new ClienteTestModel
 {
     ClienteId = 37,
     Nome = "Rafael Souza",
     Email = "rafael.souza@email.com",
     Telefone = "999887777",
     DataNascimento = new DateTime(1993, 1, 11),
 },
 new ClienteTestModel
 {
     ClienteId = 38,
     Nome = "Paula Dias",
     Email = "paula.dias@email.com",
     Telefone = "912345678",
     DataNascimento = new DateTime(1986, 4, 6),
 },
 new ClienteTestModel
 {
     ClienteId = 39,
     Nome = "Eduardo Rocha",
     Email = "eduardo.rocha@email.com",
     Telefone = "923456788",
     DataNascimento = new DateTime(1992, 8, 16),
 },
 new ClienteTestModel
 {
     ClienteId = 40,
     Nome = "Tatiane Santos",
     Email = "tatiane.santos@email.com",
     Telefone = "943567890",
     DataNascimento = new DateTime(1984, 10, 30),
 }

                 );


             modelBuilder.Entity<ReservaExcursaoModel>().HasData(


     new ReservaExcursaoModel { Id = 41 ,ClienteId = 22, ExcursaoId = 23, DataReserva = DateTime.UtcNow.AddDays(2), NumPessoas = 1, ValorTotal = 50 },
     new ReservaExcursaoModel { Id = 42,ClienteId = 33, ExcursaoId = 21, DataReserva = DateTime.UtcNow.AddDays(3), NumPessoas = 4, ValorTotal = 200 },
     new ReservaExcursaoModel { Id = 43, ClienteId = 24, ExcursaoId = 25, DataReserva = DateTime.UtcNow.AddDays(4), NumPessoas = 3, ValorTotal = 150 },
     new ReservaExcursaoModel { Id = 44, ClienteId = 35, ExcursaoId = 26, DataReserva = DateTime.UtcNow.AddDays(5), NumPessoas = 5, ValorTotal = 250 },
     new ReservaExcursaoModel { Id = 45, ClienteId = 36, ExcursaoId =34, DataReserva = DateTime.UtcNow.AddDays(6), NumPessoas = 2, ValorTotal = 120 },
     new ReservaExcursaoModel { Id = 46, ClienteId = 27, ExcursaoId = 27, DataReserva = DateTime.UtcNow.AddDays(7), NumPessoas = 1, ValorTotal = 60 },
     new ReservaExcursaoModel { Id = 47, ClienteId = 28, ExcursaoId = 38, DataReserva = DateTime.UtcNow.AddDays(8), NumPessoas = 6, ValorTotal = 300 },
     new ReservaExcursaoModel { Id = 48, ClienteId = 29, ExcursaoId = 39, DataReserva = DateTime.UtcNow.AddDays(9), NumPessoas = 3, ValorTotal = 180 },
     new ReservaExcursaoModel { Id = 49, ClienteId = 31, ExcursaoId = 32, DataReserva = DateTime.UtcNow.AddDays(10), NumPessoas = 2, ValorTotal = 110 },
     new ReservaExcursaoModel { Id = 50, ClienteId = 21, ExcursaoId = 25, DataReserva = DateTime.UtcNow.AddDays(11), NumPessoas = 4, ValorTotal = 200 },
     new ReservaExcursaoModel { Id = 51, ClienteId = 32, ExcursaoId = 21, DataReserva = DateTime.UtcNow.AddDays(12), NumPessoas = 1, ValorTotal = 50 },
     new ReservaExcursaoModel { Id = 52, ClienteId = 33, ExcursaoId = 33, DataReserva = DateTime.UtcNow.AddDays(13), NumPessoas = 5, ValorTotal = 250 },
     new ReservaExcursaoModel { Id = 53, ClienteId = 34, ExcursaoId = 26, DataReserva = DateTime.UtcNow.AddDays(14), NumPessoas = 2, ValorTotal = 120 },
     new ReservaExcursaoModel { Id = 54, ClienteId = 35, ExcursaoId = 24, DataReserva = DateTime.UtcNow.AddDays(15), NumPessoas = 3, ValorTotal = 150 },
     new ReservaExcursaoModel { Id = 55, ClienteId = 23, ExcursaoId = 37, DataReserva = DateTime.UtcNow.AddDays(16), NumPessoas = 2, ValorTotal = 100 },
     new ReservaExcursaoModel { Id = 56, ClienteId = 21, ExcursaoId = 28, DataReserva = DateTime.UtcNow.AddDays(17), NumPessoas = 4, ValorTotal = 200 },
     new ReservaExcursaoModel { Id = 57, ClienteId = 28, ExcursaoId = 29, DataReserva = DateTime.UtcNow.AddDays(18), NumPessoas = 6, ValorTotal = 300 },
     new ReservaExcursaoModel { Id = 58, ClienteId = 29, ExcursaoId = 22, DataReserva = DateTime.UtcNow.AddDays(19), NumPessoas = 2, ValorTotal = 110 },
     new ReservaExcursaoModel { Id = 59, ClienteId = 40, ExcursaoId = 33, DataReserva = DateTime.UtcNow.AddDays(20), NumPessoas = 3, ValorTotal = 150 },
      new ReservaExcursaoModel { Id = 60, ClienteId = 21, ExcursaoId = 22, DataReserva = DateTime.UtcNow.AddDays(1), NumPessoas = 2, ValorTotal = 100 }
                 );

            modelBuilder.Entity<ExcursaoFavoritaModel>().HasData(
    new ExcursaoFavoritaModel { Id = 71, ClienteId = 30, ExcursaoId = 20, Comentario = "Passeio encantador, perfeito para relaxar." },
    new ExcursaoFavoritaModel { Id = 72, ClienteId = 21, ExcursaoId = 21, Comentario = "Guias excelentes e vistas incríveis!" },
    new ExcursaoFavoritaModel { Id = 73, ClienteId = 22, ExcursaoId = 22, Comentario = "Muito divertido, meus filhos adoraram." },
    new ExcursaoFavoritaModel { Id = 74, ClienteId = 23, ExcursaoId = 23, Comentario = "O transporte poderia ser melhor, mas o local era incrível." },
    new ExcursaoFavoritaModel { Id = 75, ClienteId = 24, ExcursaoId = 24, Comentario = "Excelente organização e atenção aos detalhes." },
    new ExcursaoFavoritaModel { Id = 76, ClienteId = 25, ExcursaoId = 25, Comentario = "Lugar deslumbrante, recomendo para casais." },
    new ExcursaoFavoritaModel { Id = 77, ClienteId = 26, ExcursaoId = 26, Comentario = "Um pouco caro, mas valeu a pena." },
    new ExcursaoFavoritaModel { Id = 78, ClienteId = 27, ExcursaoId = 27, Comentario = "Paisagens de tirar o fôlego!" },
    new ExcursaoFavoritaModel { Id = 79, ClienteId = 28, ExcursaoId = 28, Comentario = "Foi uma aventura inesquecível." },
    new ExcursaoFavoritaModel { Id = 80, ClienteId = 29, ExcursaoId = 29, Comentario = "Gostei da flexibilidade no roteiro." },
    new ExcursaoFavoritaModel { Id = 81, ClienteId = 30, ExcursaoId = 30, Comentario = "Bom para grupos grandes, bastante espaço." },
    new ExcursaoFavoritaModel { Id = 82, ClienteId = 31, ExcursaoId = 31, Comentario = "Adorei a comida servida durante o passeio." },
    new ExcursaoFavoritaModel { Id = 83, ClienteId = 32, ExcursaoId = 32, Comentario = "O tempo estava ótimo e tudo saiu como planejado." },
    new ExcursaoFavoritaModel { Id = 84, ClienteId = 33, ExcursaoId = 33, Comentario = "Poderiam ter mais informações sobre o local, mas gostei." },
    new ExcursaoFavoritaModel { Id = 85, ClienteId = 34, ExcursaoId = 34, Comentario = "O guia era muito simpático e experiente." },
    new ExcursaoFavoritaModel { Id = 86, ClienteId = 35, ExcursaoId = 35, Comentario = "Recomendo para quem gosta de aprender sobre história." },
    new ExcursaoFavoritaModel { Id = 87, ClienteId = 36, ExcursaoId = 36, Comentario = "Ótimo custo-benefício." },
    new ExcursaoFavoritaModel { Id = 88, ClienteId = 37, ExcursaoId = 37, Comentario = "Muito bem organizado e pontual." },
    new ExcursaoFavoritaModel { Id = 89, ClienteId = 38, ExcursaoId = 38, Comentario = "Lugar paradisíaco, voltarei com certeza!" },
    new ExcursaoFavoritaModel { Id = 90, ClienteId = 39, ExcursaoId = 39, Comentario = "Fiquei encantado com o serviço personalizado." }*/
);



        }
        
    }

}
