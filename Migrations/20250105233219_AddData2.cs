using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExcursaoModel",
                columns: new[] { "ExcursaoId", "Data_Fim", "Data_Inicio", "Descricao", "Preco", "StaffId", "Titulo" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Descubra os principais pontos históricos de Lisboa.", 50.0, 1, "Tour Histórico de Lisboa" },
                    { 2, new DateTime(2025, 1, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 12, 8, 30, 0, 0, DateTimeKind.Unspecified), "Explore as melhores vinícolas da região do Douro.", 75.0, 2, "Rota dos Vinhos do Douro" },
                    { 3, new DateTime(2025, 1, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 7, 0, 0, 0, DateTimeKind.Unspecified), "Aproveite uma trilha guiada na Serra da Estrela.", 60.0, 3, "Caminhada na Serra da Estrela" },
                    { 4, new DateTime(2025, 1, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Uma experiência relaxante navegando pelo Rio Tejo.", 40.0, 4, "Passeio de Barco no Rio Tejo" },
                    { 5, new DateTime(2025, 1, 20, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 9, 30, 0, 0, DateTimeKind.Unspecified), "Conheça a história do Mosteiro da Batalha.", 35.0, 5, "Visita ao Mosteiro da Batalha" },
                    { 6, new DateTime(2025, 1, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), "Uma excursão pelos monumentos históricos de Évora.", 65.0, 6, "Exploração de Évora" },
                    { 7, new DateTime(2025, 1, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), "Capture as vistas incríveis da Serra da Arrábida.", 80.0, 7, "Safari Fotográfico na Arrábida" },
                    { 8, new DateTime(2025, 1, 28, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 28, 9, 30, 0, 0, DateTimeKind.Unspecified), "Explore os palácios e paisagens de Sintra.", 70.0, 8, "Passeio Cultural em Sintra" },
                    { 9, new DateTime(2025, 1, 30, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), "Descubra a culinária local do Porto.", 50.0, 9, "Tour Gastronômico em Porto" },
                    { 10, new DateTime(2025, 2, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "Um passeio pelas águas e ilhas da Ria Formosa.", 60.0, 10, "Exploração da Ria Formosa" },
                    { 11, new DateTime(2025, 2, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), "Descubra a magia de Lisboa à noite.", 45.0, 11, "Tour Noturno em Lisboa" },
                    { 12, new DateTime(2025, 2, 7, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), "Visite as Grutas de Mira de Aire e suas formações únicas.", 30.0, 12, "Exploração Subterrânea em Mira de Aire" },
                    { 13, new DateTime(2025, 2, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Explore a natureza e a beleza do Parque Nacional Peneda-Gerês.", 85.0, 13, "Aventura em Peneda-Gerês" },
                    { 14, new DateTime(2025, 2, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "Conheça as aldeias encantadoras e cheias de história.", 95.0, 14, "Passeio pelas Aldeias Históricas de Portugal" },
                    { 15, new DateTime(2025, 2, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), "Um passeio inesquecível pelo Rio Douro.", 55.0, 15, "Cruzeiro no Rio Douro" },
                    { 16, new DateTime(2025, 2, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), "Descubra o Alentejo sobre duas rodas.", 40.0, 16, "Passeio de Bicicleta no Alentejo" },
                    { 17, new DateTime(2025, 2, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), "Siga os passos do grande poeta em Lisboa.", 25.0, 17, "Roteiro Literário de Fernando Pessoa" },
                    { 18, new DateTime(2025, 2, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), "Uma jornada pelos castelos mais icônicos do país.", 70.0, 18, "Passeio pelos Castelos de Portugal" },
                    { 19, new DateTime(2025, 2, 25, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 9, 30, 0, 0, DateTimeKind.Unspecified), "Viva uma experiência única no Algarve.", 50.0, 19, "Observação de Golfinhos no Algarve" },
                    { 20, new DateTime(2025, 2, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), "Descubra a vibrante arte de rua de Lisboa.", 35.0, 20, "Tour de Arte Urbana em Lisboa" },
                    { 21, new DateTime(2025, 3, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Encante-se com as paisagens da amendoeira em flor.", 75.0, 21, "Rota da Amendoeira em Flor" },
                    { 22, new DateTime(2025, 3, 3, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 3, 8, 30, 0, 0, DateTimeKind.Unspecified), "Relaxe nas praias deslumbrantes do Alentejo.", 65.0, 22, "Passeio pelas Praias do Alentejo" },
                    { 23, new DateTime(2025, 3, 5, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 9, 30, 0, 0, DateTimeKind.Unspecified), "Explore a rica história e cultura de Coimbra.", 40.0, 23, "Tour Histórico em Coimbra" },
                    { 24, new DateTime(2025, 3, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), "Uma experiência nas furnas vulcânicas de São Miguel.", 50.0, 24, "Visita às Furnas de São Miguel" },
                    { 25, new DateTime(2025, 3, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "Uma excursão marítima inesquecível nas Berlengas.", 80.0, 25, "Jornada pelas Ilhas Berlengas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "ExcursaoId",
                keyValue: 22);

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
        }
    }
}
