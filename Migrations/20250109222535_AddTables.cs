using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteTestModel",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteTestModel", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "StaffModel",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCarta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffModel", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "Transporte",
                columns: table => new
                {
                    TransporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    TipoTransporte = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CartaTransporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnoFabricacao = table.Column<int>(type: "int", nullable: false),
                    DescricaoTipoTransporte = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporte", x => x.TransporteId);
                });

            migrationBuilder.CreateTable(
                name: "ExcursaoModel",
                columns: table => new
                {
                    ExcursaoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preco = table.Column<float>(type: "real", nullable: false),
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcursaoModel", x => x.ExcursaoId);
                    table.ForeignKey(
                        name: "FK_ExcursaoModel_StaffModel_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffModel",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotoristaTransporte",
                columns: table => new
                {
                    MotoristaTransporteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    TransporteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoristaTransporte", x => x.MotoristaTransporteId);
                    table.ForeignKey(
                        name: "FK_MotoristaTransporte_StaffModel_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffModel",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotoristaTransporte_Transporte_TransporteId",
                        column: x => x.TransporteId,
                        principalTable: "Transporte",
                        principalColumn: "TransporteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExcursaoFavoritaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ExcursaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcursaoFavoritaModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExcursaoFavoritaModel_ClienteTestModel_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteTestModel",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExcursaoFavoritaModel_ExcursaoModel_ExcursaoId",
                        column: x => x.ExcursaoId,
                        principalTable: "ExcursaoModel",
                        principalColumn: "ExcursaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrecarioModel",
                columns: table => new
                {
                    PrecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<float>(type: "real", nullable: false),
                    Data_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExcursaoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecarioModel", x => x.PrecoId);
                    table.ForeignKey(
                        name: "FK_PrecarioModel_ExcursaoModel_ExcursaoId",
                        column: x => x.ExcursaoId,
                        principalTable: "ExcursaoModel",
                        principalColumn: "ExcursaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservaExcursaoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ExcursaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    NumPessoas = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaExcursaoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaExcursaoModel_ClienteTestModel_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteTestModel",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaExcursaoModel_ExcursaoModel_ExcursaoId",
                        column: x => x.ExcursaoId,
                        principalTable: "ExcursaoModel",
                        principalColumn: "ExcursaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClienteTestModel",
                columns: new[] { "ClienteId", "DataNascimento", "Email", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 21, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos.silva@email.com", "Carlos Silva", "923412453" },
                    { 22, new DateTime(1990, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana.oliveira@email.com", "Ana Oliveira", "998765432" },
                    { 23, new DateTime(1982, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao.pereira@email.com", "João Pereira", "987654321" },
                    { 24, new DateTime(1978, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria.souza@email.com", "Maria Souza", "996543210" },
                    { 25, new DateTime(1993, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucas.costa@email.com", "Lucas Costa", "934567890" },
                    { 26, new DateTime(1989, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabela.almeida@email.com", "Isabela Almeida", "945678901" },
                    { 27, new DateTime(1995, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "felipe.rocha@email.com", "Felipe Rocha", "923456789" },
                    { 28, new DateTime(1983, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "carla.martins@email.com", "Carla Martins", "911223344" },
                    { 29, new DateTime(1990, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "fernando.gomes@email.com", "Fernando Gomes", "997654321" },
                    { 30, new DateTime(1988, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "beatriz.santos@email.com", "Beatriz Santos", "968754321" },
                    { 31, new DateTime(1992, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "ricardo.ferreira@email.com", "Ricardo Ferreira", "954321098" },
                    { 32, new DateTime(1994, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "juliana.silva@email.com", "Juliana Silva", "924567890" },
                    { 33, new DateTime(1987, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "gabriel.lima@email.com", "Gabriel Lima", "917654321" },
                    { 34, new DateTime(1991, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariana.costa@email.com", "Mariana Costa", "935678902" },
                    { 35, new DateTime(1980, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "vitor.hugo@email.com", "Vitor Hugo", "945678901" },
                    { 36, new DateTime(1994, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "larissa.oliveira@email.com", "Larissa Oliveira", "923456788" },
                    { 37, new DateTime(1993, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "rafael.souza@email.com", "Rafael Souza", "999887777" },
                    { 38, new DateTime(1986, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "paula.dias@email.com", "Paula Dias", "912345678" },
                    { 39, new DateTime(1992, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "eduardo.rocha@email.com", "Eduardo Rocha", "923456788" },
                    { 40, new DateTime(1984, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "tatiane.santos@email.com", "Tatiane Santos", "943567890" }
                });

            migrationBuilder.InsertData(
                table: "StaffModel",
                columns: new[] { "StaffId", "Job_Name", "Staff_Name", "TipoCarta" },
                values: new object[,]
                {
                    { 1, "Motorista", "João Silva", "C" },
                    { 2, "Guia Turístico", "Maria Ferreira", null },
                    { 3, "Motorista", "Carlos Mendes", "D" },
                    { 4, "Gestor de Excursão", "Ana Costa", null },
                    { 5, "Motorista", "Luís Pereira", "C+E" },
                    { 6, "Guia Turístico", "Rita Oliveira", null },
                    { 7, "Motorista", "Pedro Santos", "B" },
                    { 8, "Gestor de Excursão", "Marta Lopes", null },
                    { 9, "Motorista", "Fernando Gomes", "D+E" },
                    { 10, "Guia Turístico", "Cláudia Neves", null },
                    { 11, "Motorista", "António Silva", "C" },
                    { 12, "Gestor de Excursão", "Beatriz Sousa", null },
                    { 13, "Motorista", "Ricardo Teixeira", "D" },
                    { 14, "Guia Turístico", "Joana Martins", null },
                    { 15, "Motorista", "Tiago Rocha", "C+E" },
                    { 16, "Gestor de Excursão", "Helena Ribeiro", null },
                    { 17, "Motorista", "José Almeida", "B" },
                    { 18, "Guia Turístico", "Sofia Silva", null },
                    { 19, "Motorista", "Vítor Pinto", "C" },
                    { 20, "Gestor de Excursão", "Catarina Azevedo", null },
                    { 21, "Motorista", "André Matos", "D+E" },
                    { 22, "Guia Turístico", "Patrícia Lima", null },
                    { 23, "Motorista", "Eduardo Nunes", "B" },
                    { 24, "Gestor de Excursão", "Carla Moreira", null },
                    { 25, "Motorista", "Bruno Tavares", "C" }
                });

            migrationBuilder.InsertData(
                table: "Transporte",
                columns: new[] { "TransporteId", "AnoFabricacao", "Capacidade", "CartaTransporte", "DescricaoTipoTransporte", "Matricula", "TipoTransporte" },
                values: new object[,]
                {
                    { 26, 2015, 55, "D", "Autocarro confortável para turismo de longa distância", "AA-1234", "Autocarro" },
                    { 27, 2019, 20, "D", "Minibus ideal para grupos pequenos em excursões", "BB-5678", "Minibus" },
                    { 28, 2021, 12, "C", "Van moderna para transporte rápido de passageiros", "CC-9101", "Van" },
                    { 29, 2016, 45, "D", "Autocarro com ar condicionado e Wi-Fi", "DD-1122", "Autocarro" },
                    { 30, 2020, 18, "C", "Van prática para transporte urbano", "EE-3344", "Van" },
                    { 31, 2017, 35, "D", "Minibus económico com espaço para bagagens", "FF-5566", "Minibus" },
                    { 32, 2013, 60, "D", "Autocarro de grande capacidade para excursões escolares", "GG-7788", "Autocarro" },
                    { 33, 2022, 14, "B", "Van recente e equipada para transporte eficiente", "HH-9900", "Van" },
                    { 34, 2014, 50, "D", "Autocarro clássico para transporte turístico", "II-2233", "Autocarro" },
                    { 35, 2018, 22, "D", "Minibus compacto para serviços personalizados", "JJ-4455", "Minibus" },
                    { 36, 2015, 55, "D", "Autocarro espaçoso para grandes eventos", "KK-6677", "Autocarro" },
                    { 37, 2021, 10, "B", "Van ágil para serviços de transporte rápidos", "LL-8899", "Van" },
                    { 38, 2017, 48, "D", "Autocarro ideal para rotas intermunicipais", "MM-0011", "Autocarro" },
                    { 39, 2019, 28, "D", "Minibus com sistema de climatização", "NN-1123", "Minibus" },
                    { 40, 2016, 40, "D", "Autocarro para transporte corporativo", "OO-4456", "Autocarro" },
                    { 41, 2020, 16, "C", "Van prática para pequenas viagens", "PP-7789", "Van" },
                    { 42, 2015, 35, "D", "Minibus económico com bancos confortáveis", "QQ-9901", "Minibus" },
                    { 43, 2013, 60, "D", "Autocarro com assentos reclináveis", "RR-2234", "Autocarro" },
                    { 44, 2022, 12, "B", "Van eficiente para transporte diário", "SS-5567", "Van" },
                    { 45, 2021, 25, "D", "Minibus recente para excursões de lazer", "TT-7789", "Minibus" },
                    { 46, 2016, 45, "D", "Autocarro equipado com Wi-Fi", "UU-9902", "Autocarro" },
                    { 47, 2020, 18, "C", "Van espaçosa para famílias", "VV-2235", "Van" },
                    { 48, 2014, 50, "D", "Autocarro ideal para viagens de longa distância", "WW-4457", "Autocarro" },
                    { 49, 2018, 30, "D", "Minibus para transporte escolar", "XX-6678", "Minibus" },
                    { 50, 2021, 14, "B", "Van para serviços de transporte rápidos e eficientes", "YY-8890", "Van" }
                });

            migrationBuilder.InsertData(
                table: "ExcursaoModel",
                columns: new[] { "ExcursaoId", "Data_Fim", "Data_Inicio", "Descricao", "Preco", "StaffId", "Titulo" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Descubra os principais pontos históricos de Lisboa.", 50f, 1, "Tour Histórico de Lisboa" },
                    { 2, new DateTime(2025, 1, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 12, 8, 30, 0, 0, DateTimeKind.Unspecified), "Explore as melhores vinícolas da região do Douro.", 75f, 2, "Rota dos Vinhos do Douro" },
                    { 3, new DateTime(2025, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 7, 0, 0, 0, DateTimeKind.Unspecified), "Aproveite uma trilha guiada na Serra da Estrela.", 60f, 3, "Caminhada na Serra da Estrela" },
                    { 4, new DateTime(2025, 1, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Uma experiência relaxante navegando pelo Rio Tejo.", 40f, 4, "Passeio de Barco no Rio Tejo" },
                    { 5, new DateTime(2025, 1, 20, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 9, 30, 0, 0, DateTimeKind.Unspecified), "Conheça a história do Mosteiro da Batalha.", 35f, 5, "Visita ao Mosteiro da Batalha" },
                    { 6, new DateTime(2025, 1, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), "Uma excursão pelos monumentos históricos de Évora.", 65f, 6, "Exploração de Évora" },
                    { 7, new DateTime(2025, 1, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "Capture as vistas incríveis da Serra da Arrábida.", 80f, 7, "Safari Fotográfico na Arrábida" },
                    { 8, new DateTime(2025, 1, 28, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 28, 9, 30, 0, 0, DateTimeKind.Unspecified), "Explore os palácios e paisagens de Sintra.", 70f, 8, "Passeio Cultural em Sintra" },
                    { 9, new DateTime(2025, 1, 30, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), "Descubra a culinária local do Porto.", 50f, 9, "Tour Gastronômico em Porto" },
                    { 10, new DateTime(2025, 2, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "Um passeio pelas águas e ilhas da Ria Formosa.", 60f, 10, "Exploração da Ria Formosa" },
                    { 11, new DateTime(2025, 2, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), "Descubra a magia de Lisboa à noite.", 45f, 11, "Tour Noturno em Lisboa" },
                    { 12, new DateTime(2025, 2, 7, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), "Visite as Grutas de Mira de Aire e suas formações únicas.", 30f, 12, "Exploração Subterrânea em Mira de Aire" },
                    { 13, new DateTime(2025, 2, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Explore a natureza e a beleza do Parque Nacional Peneda-Gerês.", 85f, 13, "Aventura em Peneda-Gerês" },
                    { 14, new DateTime(2025, 2, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "Conheça as aldeias encantadoras e cheias de história.", 95f, 14, "Passeio pelas Aldeias Históricas de Portugal" },
                    { 15, new DateTime(2025, 2, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), "Um passeio inesquecível pelo Rio Douro.", 55f, 15, "Cruzeiro no Rio Douro" },
                    { 16, new DateTime(2025, 2, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), "Descubra o Alentejo sobre duas rodas.", 40f, 16, "Passeio de Bicicleta no Alentejo" },
                    { 17, new DateTime(2025, 2, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Siga os passos do grande poeta em Lisboa.", 25f, 17, "Roteiro Literário de Fernando Pessoa" },
                    { 18, new DateTime(2025, 2, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), "Uma jornada pelos castelos mais icônicos do país.", 70f, 18, "Passeio pelos Castelos de Portugal" },
                    { 19, new DateTime(2025, 2, 25, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 9, 30, 0, 0, DateTimeKind.Unspecified), "Viva uma experiência única no Algarve.", 50f, 19, "Observação de Golfinhos no Algarve" },
                    { 20, new DateTime(2025, 2, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), "Descubra a vibrante arte de rua de Lisboa.", 35f, 20, "Tour de Arte Urbana em Lisboa" },
                    { 21, new DateTime(2025, 3, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Encante-se com as paisagens da amendoeira em flor.", 75f, 21, "Rota da Amendoeira em Flor" },
                    { 22, new DateTime(2025, 3, 3, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 3, 8, 30, 0, 0, DateTimeKind.Unspecified), "Relaxe nas praias deslumbrantes do Alentejo.", 65f, 22, "Passeio pelas Praias do Alentejo" },
                    { 23, new DateTime(2025, 3, 5, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), "Explore a rica história e cultura de Coimbra.", 40f, 23, "Tour Histórico em Coimbra" },
                    { 24, new DateTime(2025, 3, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), "Uma experiência nas furnas vulcânicas de São Miguel.", 50f, 24, "Visita às Furnas de São Miguel" },
                    { 25, new DateTime(2025, 3, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "Uma excursão marítima inesquecível nas Berlengas.", 80f, 25, "Jornada pelas Ilhas Berlengas" }
                });

            migrationBuilder.InsertData(
                table: "MotoristaTransporte",
                columns: new[] { "MotoristaTransporteId", "StaffId", "TransporteId" },
                values: new object[,]
                {
                    { 26, 2, 26 },
                    { 27, 1, 27 },
                    { 28, 3, 28 },
                    { 29, 4, 29 },
                    { 30, 5, 30 },
                    { 31, 6, 31 },
                    { 32, 7, 32 },
                    { 33, 8, 33 },
                    { 34, 9, 34 },
                    { 35, 10, 35 },
                    { 36, 11, 36 },
                    { 37, 12, 37 },
                    { 38, 13, 38 },
                    { 39, 14, 39 },
                    { 40, 15, 40 },
                    { 41, 16, 41 },
                    { 42, 17, 42 },
                    { 43, 18, 43 },
                    { 44, 19, 44 },
                    { 45, 20, 45 },
                    { 46, 21, 46 },
                    { 47, 22, 47 },
                    { 48, 23, 48 },
                    { 49, 24, 49 },
                    { 50, 25, 50 }
                });

            migrationBuilder.InsertData(
                table: "ExcursaoFavoritaModel",
                columns: new[] { "Id", "ClienteId", "Comentario", "ExcursaoId" },
                values: new object[,]
                {
                    { 71, 30, "Passeio encantador, perfeito para relaxar.", 1 },
                    { 72, 21, "Guias excelentes e vistas incríveis!", 2 },
                    { 73, 22, "Muito divertido, meus filhos adoraram.", 3 },
                    { 74, 23, "O transporte poderia ser melhor, mas o local era incrível.", 4 },
                    { 75, 24, "Excelente organização e atenção aos detalhes.", 5 },
                    { 76, 25, "Lugar deslumbrante, recomendo para casais.", 6 },
                    { 77, 26, "Um pouco caro, mas valeu a pena.", 7 },
                    { 78, 27, "Paisagens de tirar o fôlego!", 7 },
                    { 79, 28, "Foi uma aventura inesquecível.", 8 },
                    { 80, 29, "Gostei da flexibilidade no roteiro.", 9 },
                    { 81, 30, "Bom para grupos grandes, bastante espaço.", 10 },
                    { 82, 31, "Adorei a comida servida durante o passeio.", 11 },
                    { 83, 32, "O tempo estava ótimo e tudo saiu como planejado.", 12 },
                    { 84, 33, "Poderiam ter mais informações sobre o local, mas gostei.", 13 },
                    { 85, 34, "O guia era muito simpático e experiente.", 14 },
                    { 86, 35, "Recomendo para quem gosta de aprender sobre história.", 15 },
                    { 87, 36, "Ótimo custo-benefício.", 16 },
                    { 88, 37, "Muito bem organizado e pontual.", 17 },
                    { 89, 38, "Lugar paradisíaco, voltarei com certeza!", 18 },
                    { 90, 39, "Fiquei encantado com o serviço personalizado.", 19 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExcursaoFavoritaModel_ClienteId",
                table: "ExcursaoFavoritaModel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcursaoFavoritaModel_ExcursaoId",
                table: "ExcursaoFavoritaModel",
                column: "ExcursaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcursaoModel_StaffId",
                table: "ExcursaoModel",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_MotoristaTransporte_StaffId",
                table: "MotoristaTransporte",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_MotoristaTransporte_TransporteId",
                table: "MotoristaTransporte",
                column: "TransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecarioModel_ExcursaoId",
                table: "PrecarioModel",
                column: "ExcursaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaExcursaoModel_ClienteId",
                table: "ReservaExcursaoModel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaExcursaoModel_ExcursaoId",
                table: "ReservaExcursaoModel",
                column: "ExcursaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcursaoFavoritaModel");

            migrationBuilder.DropTable(
                name: "MotoristaTransporte");

            migrationBuilder.DropTable(
                name: "PrecarioModel");

            migrationBuilder.DropTable(
                name: "ReservaExcursaoModel");

            migrationBuilder.DropTable(
                name: "Transporte");

            migrationBuilder.DropTable(
                name: "ClienteTestModel");

            migrationBuilder.DropTable(
                name: "ExcursaoModel");

            migrationBuilder.DropTable(
                name: "StaffModel");
        }
    }
}
