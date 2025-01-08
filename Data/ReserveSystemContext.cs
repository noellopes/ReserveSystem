using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;
using System.Globalization;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {
        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }


        public DbSet<ReserveSystem.Models.JobTestModel> JobTestModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.StaffTestModel> StaffTestModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ExcursaoModel> ExcursaoModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ClienteTestModel> ClienteTestModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ReservaExcursaoModel> ReservaExcursaoModel { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* _ = modelBuilder.Entity<ExcursaoModel>().HasData(


    new ExcursaoModel
    {
        Excursao_Id = 20,
        Titulo = "Tour pela Cidade",
        Descricao = "Exploração cultural pela cidade",
        Data_Inicio = DateTime.UtcNow.AddDays(1).ToUniversalTime(), // Especificando o tipo UTC
        Data_Fim = DateTime.UtcNow.AddDays(2).ToUniversalTime(),   // Especificando o tipo UTC
        Preco = 50.0m,
        Staff_Id = 1
    },
     new ExcursaoModel
     {
         Excursao_Id = 21,
         Titulo = "Passeio de Barco",
         Descricao = "Passeio pelas águas tranquilas",
         Data_Inicio = DateTime.UtcNow.AddDays(3).ToUniversalTime(),
         Data_Fim = DateTime.UtcNow.AddDays(3).AddHours(4).ToUniversalTime(),
         Preco = 80.0m,
         Staff_Id = 2
     },
     new ExcursaoModel
     {
         Excursao_Id = 22,
         Titulo = "Caminhada na Montanha",
         Descricao = "Uma aventura entre as montanhas",
         Data_Inicio = DateTime.UtcNow.AddDays(5).ToUniversalTime(),
         Data_Fim = DateTime.UtcNow.AddDays(5).AddHours(6).ToUniversalTime(),
         Preco = 120.0m,
         Staff_Id = 3
     },
    new ExcursaoModel
    {
        Excursao_Id = 23,
        Titulo = "Passeio no Parque",
        Descricao = "Caminhada e observação da fauna e flora do parque",
        Data_Inicio = DateTime.UtcNow.AddDays(6).ToUniversalTime(),
        Data_Fim = DateTime.UtcNow.AddDays(6).AddHours(3).ToUniversalTime(),
        Preco = 40.0m,
        Staff_Id = 4
    },
 new ExcursaoModel
 {
     Excursao_Id = 24,
     Titulo = "Aventura Subaquática",
     Descricao = "Exploração subaquática em recifes de corais",
     Data_Inicio = DateTime.UtcNow.AddDays(7).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(7).AddHours(5).ToUniversalTime(),
     Preco = 150.0m,
     Staff_Id = 5
 },
 new ExcursaoModel
 {
     Excursao_Id = 25,
     Titulo = "Passeio de Balão",
     Descricao = "Uma experiência única para ver o mundo de cima",
     Data_Inicio = DateTime.UtcNow.AddDays(8).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(8).AddHours(3).ToUniversalTime(),
     Preco = 200.0m,
     Staff_Id = 6
 },
 new ExcursaoModel
 {
     Excursao_Id = 26,
     Titulo = "Rota dos Vinhos",
     Descricao = "Tour por vinícolas e degustação de vinhos finos",
     Data_Inicio = DateTime.UtcNow.AddDays(9).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(9).AddHours(6).ToUniversalTime(),
     Preco = 120.0m,
     Staff_Id = 7
 },
 new ExcursaoModel
 {
     Excursao_Id = 27,
     Titulo = "Expedição ao Deserto",
     Descricao = "Aventura no deserto com passeio de camelo e visita a oásis",
     Data_Inicio = DateTime.UtcNow.AddDays(10).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(10).AddHours(8).ToUniversalTime(),
     Preco = 250.0m,
     Staff_Id = 8
 },
 new ExcursaoModel
 {
     Excursao_Id = 28,
     Titulo = "Safari na África",
     Descricao = "Safari em reserva natural com guia especializado",
     Data_Inicio = DateTime.UtcNow.AddDays(11).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(11).AddHours(12).ToUniversalTime(),
     Preco = 500.00m,
     Staff_Id = 9
 },
 new ExcursaoModel
 {
     Excursao_Id = 29,
     Titulo = "Expedição Polar",
     Descricao = "Aventura no Ártico para ver as luzes do norte",
     Data_Inicio = DateTime.UtcNow.AddDays(12).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(12).AddHours(10).ToUniversalTime(),
     Preco = 350.0m,
     Staff_Id = 10
 },
 new ExcursaoModel
 {
     Excursao_Id = 30,
     Titulo = "Trekking na Amazônia",
     Descricao = "Exploração pela floresta amazônica com guias especializados",
     Data_Inicio = DateTime.UtcNow.AddDays(13).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(13).AddHours(9).ToUniversalTime(),
     Preco = 180.0m,
     Staff_Id = 11
 },
 new ExcursaoModel
 {
     Excursao_Id = 31,
     Titulo = "Trilha das Cataratas",
     Descricao = "Passeio pelas trilhas que levam às maiores cataratas do mundo",
     Data_Inicio = DateTime.UtcNow.AddDays(14).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(14).AddHours(5).ToUniversalTime(),
     Preco = 90.0m,
     Staff_Id = 12
 },
 new ExcursaoModel
 {
     Excursao_Id = 32,
     Titulo = "Mergulho em Recife",
     Descricao = "Aventura subaquática com mergulho em recifes de corais",
     Data_Inicio = DateTime.UtcNow.AddDays(15).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(15).AddHours(4).ToUniversalTime(),
     Preco = 130.0m,
     Staff_Id = 13
 },
 new ExcursaoModel
 {
     Excursao_Id = 33,
     Titulo = "Passeio Histórico",
     Descricao = "Tour pelas principais atrações históricas da cidade",
     Data_Inicio = DateTime.UtcNow.AddDays(16).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(16).AddHours(5).ToUniversalTime(),
     Preco = 60.0m,
     Staff_Id = 14
 },
 new ExcursaoModel
 {
     Excursao_Id = 34,
     Titulo = "Caminho dos Jesuítas",
     Descricao = "Tour histórico pelas antigas missões dos Jesuítas",
     Data_Inicio = DateTime.UtcNow.AddDays(17).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(17).AddHours(6).ToUniversalTime(),
     Preco = 80.0m,
     Staff_Id = 15
 },
 new ExcursaoModel
 {
     Excursao_Id = 35,
     Titulo = "Ciclismo nas Montanhas",
     Descricao = "Passeio de bicicleta pelas trilhas montanhosas",
     Data_Inicio = DateTime.UtcNow.AddDays(18).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(18).AddHours(4).ToUniversalTime(),
     Preco = 70.0m,
     Staff_Id = 16
 },
 new ExcursaoModel
 {
     Excursao_Id = 36,
     Titulo = "Rafting no Rio",
     Descricao = "Aventura de rafting em um dos rios mais desafiadores",
     Data_Inicio = DateTime.UtcNow.AddDays(19).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(19).AddHours(5).ToUniversalTime(),
     Preco = 110.0m,
     Staff_Id = 17
 },
 new ExcursaoModel
 {
     Excursao_Id = 37,
     Titulo = "Tour Gastronômico",
     Descricao = "Experiência gastronômica por diferentes restaurantes locais",
     Data_Inicio = DateTime.UtcNow.AddDays(20).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(20).AddHours(7).ToUniversalTime(),
     Preco = 150.0m,
     Staff_Id = 18
 }, new ExcursaoModel
 {
     Excursao_Id = 38,
     Titulo = "Aventura no Vulcão",
     Descricao = "Caminhada até a cratera de um vulcão ativo",
     Data_Inicio = DateTime.UtcNow.AddDays(21).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(21).AddHours(9).ToUniversalTime(),
     Preco = 180.0m,
     Staff_Id = 19
 },
 new ExcursaoModel
 {
     Excursao_Id = 39,
     Titulo = "Aventura no Globo de Neve",
     Descricao = "Uma experiência no globo de neve para explorar as regiões geladas",
     Data_Inicio = DateTime.UtcNow.AddDays(22).ToUniversalTime(),
     Data_Fim = DateTime.UtcNow.AddDays(22).AddHours(8).ToUniversalTime(),
     Preco = 220.0m,
     Staff_Id = 20
 }



             );

            modelBuilder.Entity<ClienteTestModel>().HasData(

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
                 );*/

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
    new ExcursaoFavoritaModel { Id = 90, ClienteId = 39, ExcursaoId = 39, Comentario = "Fiquei encantado com o serviço personalizado." }
);



        }
        public DbSet<ReserveSystem.Models.ExcursaoFavoritaModel> ExcursaoFavoritaModel { get; set; } = default!;
    }
}
