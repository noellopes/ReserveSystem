using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class addSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "StaffId", "Job_Name", "Staff_Name" },
                values: new object[,]
                {
                    { 1, "Motorista", "João Silva" },
                    { 2, "Gestor de Excursão", "Maria Oliveira" },
                    { 3, "Guia Turistico", "Carlos Santos" },
                    { 4, "Motorista", "Ana Souza" },
                    { 5, "Gestor de Excursão", "Pedro Almeida" },
                    { 6, "Guia Turistico", "Luciana Costa" },
                    { 7, "Motorista", "Rafael Gomes" },
                    { 8, "Gestor de Excursão", "Fernanda Carvalho" },
                    { 9, "Guia Turistico", "Ricardo Pereira" },
                    { 10, "Motorista", "Juliana Mendes" },
                    { 11, "Gestor de Excursão", "Gustavo Rocha" },
                    { 12, "Guia Turistico", "Camila Ribeiro" },
                    { 13, "Motorista", "André Lima" },
                    { 14, "Gestor de Excursão", "Patrícia Fonseca" },
                    { 15, "Guia Turistico", "Tiago Martins" },
                    { 16, "Motorista", "Letícia Freitas" },
                    { 17, "Gestor de Excursão", "Bruno Vieira" },
                    { 18, "Guia Turistico", "Sara Fernandes" },
                    { 19, "Motorista", "Rodrigo Lopes" },
                    { 20, "Gestor de Excursão", "Natália Correia" },
                    { 21, "Guia Turistico", "Eduardo Cardoso" },
                    { 22, "Motorista", "Carolina Neves" },
                    { 23, "Gestor de Excursão", "Diego Farias" },
                    { 24, "Guia Turistico", "Vanessa Moreira" },
                    { 25, "Motorista", "Felipe Azevedo" }
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

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ClienteTestModel",
                keyColumn: "ClienteId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 22);
        }
    }
}
