
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;
using System.Globalization;


namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {

        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }

        public DbSet<ReserveSystem.Models.ClienteTestModel> ClienteTestModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ReservaExcursaoModel> ReservaExcursaoModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ExcursaoModel> ExcursaoModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.StaffModel> StaffModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.PrecarioModel> PrecarioModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.ExcursaoFavoritaModel> ExcursaoFavoritaModel { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Transporte> Transporte { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Staff> Staff { get; set; } = default!;
        public DbSet<ReserveSystem.Models.MotoristaTransporte> MotoristaTransporte { get; set; } = default!;

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
     


           
            modelBuilder.Entity<Transporte>().HasData(
                new Transporte { TransporteId = 26, Matricula = "AA-1234", Capacidade = 55, TipoTransporte = "Autocarro", CartaTransporte = "D", AnoFabricacao = 2015, DescricaoTipoTransporte = "Autocarro confortável para turismo de longa distância" },
new Transporte { TransporteId = 27, Matricula = "BB-5678", Capacidade = 20, TipoTransporte = "Minibus", CartaTransporte = "D", AnoFabricacao = 2019, DescricaoTipoTransporte = "Minibus ideal para grupos pequenos em excursões" },
new Transporte { TransporteId = 28, Matricula = "CC-9101", Capacidade = 12, TipoTransporte = "Van", CartaTransporte = "C", AnoFabricacao = 2021, DescricaoTipoTransporte = "Van moderna para transporte rápido de passageiros" },
new Transporte { TransporteId = 29, Matricula = "DD-1122", Capacidade = 45, TipoTransporte = "Autocarro", CartaTransporte = "D", AnoFabricacao = 2016, DescricaoTipoTransporte = "Autocarro com ar condicionado e Wi-Fi" },
new Transporte { TransporteId = 30, Matricula = "EE-3344", Capacidade = 18, TipoTransporte = "Van", CartaTransporte = "C", AnoFabricacao = 2020, DescricaoTipoTransporte = "Van prática para transporte urbano" },
new Transporte { TransporteId = 31, Matricula = "FF-5566", Capacidade = 35, TipoTransporte = "Minibus", CartaTransporte = "D", AnoFabricacao = 2017, DescricaoTipoTransporte = "Minibus económico com espaço para bagagens" },
new Transporte { TransporteId = 32, Matricula = "GG-7788", Capacidade = 60, TipoTransporte = "Autocarro", CartaTransporte = "D", AnoFabricacao = 2013, DescricaoTipoTransporte = "Autocarro de grande capacidade para excursões escolares" },
new Transporte { TransporteId = 33, Matricula = "HH-9900", Capacidade = 14, TipoTransporte = "Van", CartaTransporte = "B", AnoFabricacao = 2022, DescricaoTipoTransporte = "Van recente e equipada para transporte eficiente" },
new Transporte { TransporteId = 34, Matricula = "II-2233", Capacidade = 50, TipoTransporte = "Autocarro", CartaTransporte = "D", AnoFabricacao = 2014, DescricaoTipoTransporte = "Autocarro clássico para transporte turístico" },
new Transporte { TransporteId = 35, Matricula = "JJ-4455", Capacidade = 22, TipoTransporte = "Minibus", CartaTransporte = "D", AnoFabricacao = 2018, DescricaoTipoTransporte = "Minibus compacto para serviços personalizados" },
new Transporte { TransporteId = 36, Matricula = "KK-6677", Capacidade = 55, TipoTransporte = "Autocarro", CartaTransporte = "D", AnoFabricacao = 2015, DescricaoTipoTransporte = "Autocarro espaçoso para grandes eventos" },
new Transporte { TransporteId = 37, Matricula = "LL-8899", Capacidade = 10, TipoTransporte = "Van", CartaTransporte = "B", AnoFabricacao = 2021, DescricaoTipoTransporte = "Van ágil para serviços de transporte rápidos" },
new Transporte { TransporteId = 38, Matricula = "MM-0011", Capacidade = 48, TipoTransporte = "Autocarro", CartaTransporte = "D", AnoFabricacao = 2017, DescricaoTipoTransporte = "Autocarro ideal para rotas intermunicipais" },
new Transporte { TransporteId = 39, Matricula = "NN-1123", Capacidade = 28, TipoTransporte = "Minibus", CartaTransporte = "D", AnoFabricacao = 2019, DescricaoTipoTransporte = "Minibus com sistema de climatização" },
new Transporte { TransporteId = 40, Matricula = "OO-4456", Capacidade = 40, TipoTransporte = "Autocarro", CartaTransporte = "D", AnoFabricacao = 2016, DescricaoTipoTransporte = "Autocarro para transporte corporativo" },
new Transporte { TransporteId = 41, Matricula = "PP-7789", Capacidade = 16, TipoTransporte = "Van", CartaTransporte = "C", AnoFabricacao = 2020, DescricaoTipoTransporte = "Van prática para pequenas viagens" },
new Transporte { TransporteId = 42, Matricula = "QQ-9901", Capacidade = 35, TipoTransporte = "Minibus", CartaTransporte = "D", AnoFabricacao = 2015, DescricaoTipoTransporte = "Minibus económico com bancos confortáveis" },
new Transporte { TransporteId = 43, Matricula = "RR-2234", Capacidade = 60, TipoTransporte = "Autocarro", CartaTransporte = "D", AnoFabricacao = 2013, DescricaoTipoTransporte = "Autocarro com assentos reclináveis" },
new Transporte { TransporteId = 44, Matricula = "SS-5567", Capacidade = 12, TipoTransporte = "Van", CartaTransporte = "B", AnoFabricacao = 2022, DescricaoTipoTransporte = "Van eficiente para transporte diário" },
new Transporte { TransporteId = 45, Matricula = "TT-7789", Capacidade = 25, TipoTransporte = "Minibus", CartaTransporte = "D", AnoFabricacao = 2021, DescricaoTipoTransporte = "Minibus recente para excursões de lazer" },
new Transporte { TransporteId = 46, Matricula = "UU-9902", Capacidade = 45, TipoTransporte = "Autocarro", CartaTransporte = "D", AnoFabricacao = 2016, DescricaoTipoTransporte = "Autocarro equipado com Wi-Fi" },
new Transporte { TransporteId = 47, Matricula = "VV-2235", Capacidade = 18, TipoTransporte = "Van", CartaTransporte = "C", AnoFabricacao = 2020, DescricaoTipoTransporte = "Van espaçosa para famílias" },
new Transporte { TransporteId = 48, Matricula = "WW-4457", Capacidade = 50, TipoTransporte = "Autocarro", CartaTransporte = "D", AnoFabricacao = 2014, DescricaoTipoTransporte = "Autocarro ideal para viagens de longa distância" },
new Transporte { TransporteId = 49, Matricula = "XX-6678", Capacidade = 30, TipoTransporte = "Minibus", CartaTransporte = "D", AnoFabricacao = 2018, DescricaoTipoTransporte = "Minibus para transporte escolar" },
new Transporte { TransporteId = 50, Matricula = "YY-8890", Capacidade = 14, TipoTransporte = "Van", CartaTransporte = "B", AnoFabricacao = 2021, DescricaoTipoTransporte = "Van para serviços de transporte rápidos e eficientes" }
);

modelBuilder.Entity<MotoristaTransporte>().HasData(
    new MotoristaTransporte { MotoristaTransporteId = 26, StaffId = 26, TransporteId = 26 },
new MotoristaTransporte { MotoristaTransporteId = 27, StaffId = 27, TransporteId = 27 },
new MotoristaTransporte { MotoristaTransporteId = 28, StaffId = 28, TransporteId = 28 },
new MotoristaTransporte { MotoristaTransporteId = 29, StaffId = 29, TransporteId = 29 },
new MotoristaTransporte { MotoristaTransporteId = 30, StaffId = 30, TransporteId = 30 },
new MotoristaTransporte { MotoristaTransporteId = 31, StaffId = 31, TransporteId = 31 },
new MotoristaTransporte { MotoristaTransporteId = 32, StaffId = 32, TransporteId = 32 },
new MotoristaTransporte { MotoristaTransporteId = 33, StaffId = 33, TransporteId = 33 },
new MotoristaTransporte { MotoristaTransporteId = 34, StaffId = 34, TransporteId = 34 },
new MotoristaTransporte { MotoristaTransporteId = 35, StaffId = 35, TransporteId = 35 },
new MotoristaTransporte { MotoristaTransporteId = 36, StaffId = 36, TransporteId = 36 },
new MotoristaTransporte { MotoristaTransporteId = 37, StaffId = 37, TransporteId = 37 },
new MotoristaTransporte { MotoristaTransporteId = 38, StaffId = 38, TransporteId = 38 },
new MotoristaTransporte { MotoristaTransporteId = 39, StaffId = 39, TransporteId = 39 },
new MotoristaTransporte { MotoristaTransporteId = 40, StaffId = 40, TransporteId = 40 },
new MotoristaTransporte { MotoristaTransporteId = 41, StaffId = 41, TransporteId = 41 },
new MotoristaTransporte { MotoristaTransporteId = 42, StaffId = 42, TransporteId = 42 },
new MotoristaTransporte { MotoristaTransporteId = 43, StaffId = 43, TransporteId = 43 },
new MotoristaTransporte { MotoristaTransporteId = 44, StaffId = 44, TransporteId = 44 },
new MotoristaTransporte { MotoristaTransporteId = 45, StaffId = 45, TransporteId = 45 },
new MotoristaTransporte { MotoristaTransporteId = 46, StaffId = 46, TransporteId = 46 },
new MotoristaTransporte { MotoristaTransporteId = 47, StaffId = 47, TransporteId = 47 },
new MotoristaTransporte { MotoristaTransporteId = 48, StaffId = 48, TransporteId = 48 },
new MotoristaTransporte { MotoristaTransporteId = 49, StaffId = 49, TransporteId = 49 },
new MotoristaTransporte { MotoristaTransporteId = 50, StaffId = 50, TransporteId = 50 }
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



modelBuilder.Entity<ExcursaoFavoritaModel>().HasData(
new ExcursaoFavoritaModel { Id = 71, ClienteId = 30, ExcursaoId = 1, Comentario = "Passeio encantador, perfeito para relaxar." },
new ExcursaoFavoritaModel { Id = 72, ClienteId = 21, ExcursaoId = 2, Comentario = "Guias excelentes e vistas incríveis!" },
new ExcursaoFavoritaModel { Id = 73, ClienteId = 22, ExcursaoId = 3, Comentario = "Muito divertido, meus filhos adoraram." },
new ExcursaoFavoritaModel { Id = 74, ClienteId = 23, ExcursaoId = 4, Comentario = "O transporte poderia ser melhor, mas o local era incrível." },
new ExcursaoFavoritaModel { Id = 75, ClienteId = 24, ExcursaoId = 5, Comentario = "Excelente organização e atenção aos detalhes." },
new ExcursaoFavoritaModel { Id = 76, ClienteId = 25, ExcursaoId = 6, Comentario = "Lugar deslumbrante, recomendo para casais." },
new ExcursaoFavoritaModel { Id = 77, ClienteId = 26, ExcursaoId = 7, Comentario = "Um pouco caro, mas valeu a pena." },
new ExcursaoFavoritaModel { Id = 78, ClienteId = 27, ExcursaoId = 7, Comentario = "Paisagens de tirar o fôlego!" },
new ExcursaoFavoritaModel { Id = 79, ClienteId = 28, ExcursaoId = 8, Comentario = "Foi uma aventura inesquecível." },
new ExcursaoFavoritaModel { Id = 80, ClienteId = 29, ExcursaoId = 9, Comentario = "Gostei da flexibilidade no roteiro." },
new ExcursaoFavoritaModel { Id = 81, ClienteId = 30, ExcursaoId = 10, Comentario = "Bom para grupos grandes, bastante espaço." },
new ExcursaoFavoritaModel { Id = 82, ClienteId = 31, ExcursaoId = 11, Comentario = "Adorei a comida servida durante o passeio." },
new ExcursaoFavoritaModel { Id = 83, ClienteId = 32, ExcursaoId = 12, Comentario = "O tempo estava ótimo e tudo saiu como planejado." },
new ExcursaoFavoritaModel { Id = 84, ClienteId = 33, ExcursaoId = 13, Comentario = "Poderiam ter mais informações sobre o local, mas gostei." },
new ExcursaoFavoritaModel { Id = 85, ClienteId = 34, ExcursaoId = 14, Comentario = "O guia era muito simpático e experiente." },
new ExcursaoFavoritaModel { Id = 86, ClienteId = 35, ExcursaoId = 15, Comentario = "Recomendo para quem gosta de aprender sobre história." },
new ExcursaoFavoritaModel { Id = 87, ClienteId = 36, ExcursaoId = 16, Comentario = "Ótimo custo-benefício." },
new ExcursaoFavoritaModel { Id = 88, ClienteId = 37, ExcursaoId = 17, Comentario = "Muito bem organizado e pontual." },
new ExcursaoFavoritaModel { Id = 89, ClienteId = 38, ExcursaoId = 18, Comentario = "Lugar paradisíaco, voltarei com certeza!" },
new ExcursaoFavoritaModel { Id = 90, ClienteId = 39, ExcursaoId = 19, Comentario = "Fiquei encantado com o serviço personalizado." }
);



        }
        

    }

}


