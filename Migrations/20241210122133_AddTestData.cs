using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddTestData : Migration
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

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 20,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 12, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(786), new DateTime(2024, 12, 11, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(771) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 21,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 13, 16, 21, 33, 510, DateTimeKind.Utc).AddTicks(788), new DateTime(2024, 12, 13, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(787) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 22,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 15, 18, 21, 33, 510, DateTimeKind.Utc).AddTicks(790), new DateTime(2024, 12, 15, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(789) });

            migrationBuilder.InsertData(
                table: "ExcursaoModel",
                columns: new[] { "Excursao_Id", "Data_Fim", "Data_Inicio", "Descricao", "Preco", "Staff_Id", "Titulo" },
                values: new object[,]
                {
                    { 23, new DateTime(2024, 12, 16, 15, 21, 33, 510, DateTimeKind.Utc).AddTicks(792), new DateTime(2024, 12, 16, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(791), "Caminhada e observação da fauna e flora do parque", 40.0, 4, "Passeio no Parque" },
                    { 24, new DateTime(2024, 12, 17, 17, 21, 33, 510, DateTimeKind.Utc).AddTicks(793), new DateTime(2024, 12, 17, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(793), "Exploração subaquática em recifes de corais", 150.0, 5, "Aventura Subaquática" },
                    { 25, new DateTime(2024, 12, 18, 15, 21, 33, 510, DateTimeKind.Utc).AddTicks(795), new DateTime(2024, 12, 18, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(795), "Uma experiência única para ver o mundo de cima", 200.0, 6, "Passeio de Balão" },
                    { 26, new DateTime(2024, 12, 19, 18, 21, 33, 510, DateTimeKind.Utc).AddTicks(798), new DateTime(2024, 12, 19, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(798), "Tour por vinícolas e degustação de vinhos finos", 120.0, 7, "Rota dos Vinhos" },
                    { 27, new DateTime(2024, 12, 20, 20, 21, 33, 510, DateTimeKind.Utc).AddTicks(802), new DateTime(2024, 12, 20, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(802), "Aventura no deserto com passeio de camelo e visita a oásis", 250.0, 8, "Expedição ao Deserto" },
                    { 28, new DateTime(2024, 12, 22, 0, 21, 33, 510, DateTimeKind.Utc).AddTicks(804), new DateTime(2024, 12, 21, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(804), "Safari em reserva natural com guia especializado", 500.0, 9, "Safari na África" },
                    { 29, new DateTime(2024, 12, 22, 22, 21, 33, 510, DateTimeKind.Utc).AddTicks(806), new DateTime(2024, 12, 22, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(805), "Aventura no Ártico para ver as luzes do norte", 350.0, 10, "Expedição Polar" },
                    { 30, new DateTime(2024, 12, 23, 21, 21, 33, 510, DateTimeKind.Utc).AddTicks(810), new DateTime(2024, 12, 23, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(809), "Exploração pela floresta amazônica com guias especializados", 180.0, 11, "Trekking na Amazônia" },
                    { 31, new DateTime(2024, 12, 24, 17, 21, 33, 510, DateTimeKind.Utc).AddTicks(812), new DateTime(2024, 12, 24, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(811), "Passeio pelas trilhas que levam às maiores cataratas do mundo", 90.0, 12, "Trilha das Cataratas" },
                    { 32, new DateTime(2024, 12, 25, 16, 21, 33, 510, DateTimeKind.Utc).AddTicks(813), new DateTime(2024, 12, 25, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(813), "Aventura subaquática com mergulho em recifes de corais", 130.0, 13, "Mergulho em Recife" },
                    { 33, new DateTime(2024, 12, 26, 17, 21, 33, 510, DateTimeKind.Utc).AddTicks(815), new DateTime(2024, 12, 26, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(815), "Tour pelas principais atrações históricas da cidade", 60.0, 14, "Passeio Histórico" },
                    { 34, new DateTime(2024, 12, 27, 18, 21, 33, 510, DateTimeKind.Utc).AddTicks(817), new DateTime(2024, 12, 27, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(816), "Tour histórico pelas antigas missões dos Jesuítas", 80.0, 15, "Caminho dos Jesuítas" },
                    { 35, new DateTime(2024, 12, 28, 16, 21, 33, 510, DateTimeKind.Utc).AddTicks(818), new DateTime(2024, 12, 28, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(818), "Passeio de bicicleta pelas trilhas montanhosas", 70.0, 16, "Ciclismo nas Montanhas" },
                    { 36, new DateTime(2024, 12, 29, 17, 21, 33, 510, DateTimeKind.Utc).AddTicks(820), new DateTime(2024, 12, 29, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(820), "Aventura de rafting em um dos rios mais desafiadores", 110.0, 17, "Rafting no Rio" },
                    { 37, new DateTime(2024, 12, 30, 19, 21, 33, 510, DateTimeKind.Utc).AddTicks(823), new DateTime(2024, 12, 30, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(823), "Experiência gastronômica por diferentes restaurantes locais", 150.0, 18, "Tour Gastronômico" },
                    { 38, new DateTime(2024, 12, 31, 21, 21, 33, 510, DateTimeKind.Utc).AddTicks(825), new DateTime(2024, 12, 31, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(824), "Caminhada até a cratera de um vulcão ativo", 180.0, 19, "Aventura no Vulcão" },
                    { 39, new DateTime(2025, 1, 1, 20, 21, 33, 510, DateTimeKind.Utc).AddTicks(826), new DateTime(2025, 1, 1, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(826), "Uma experiência no globo de neve para explorar as regiões geladas", 220.0, 20, "Aventura no Globo de Neve" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyColumn: "Excursao_Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 39);

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 20,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 12, 12, 1, 19, 438, DateTimeKind.Utc).AddTicks(3702), new DateTime(2024, 12, 11, 12, 1, 19, 438, DateTimeKind.Utc).AddTicks(3687) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 21,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 13, 16, 1, 19, 438, DateTimeKind.Utc).AddTicks(3705), new DateTime(2024, 12, 13, 12, 1, 19, 438, DateTimeKind.Utc).AddTicks(3705) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 22,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 15, 18, 1, 19, 438, DateTimeKind.Utc).AddTicks(3707), new DateTime(2024, 12, 15, 12, 1, 19, 438, DateTimeKind.Utc).AddTicks(3707) });
        }
    }
}
