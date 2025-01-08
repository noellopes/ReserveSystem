using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class addSampleDataForExcursaoFavorita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.InsertData(
                table: "ExcursaoFavoritaModel",
                columns: new[] { "Id", "ClienteId", "Comentario", "ExcursaoId" },
                values: new object[,]
                {
                    { 71, 30, "Passeio encantador, perfeito para relaxar.", 20 },
                    { 72, 21, "Guias excelentes e vistas incríveis!", 21 },
                    { 73, 22, "Muito divertido, meus filhos adoraram.", 22 },
                    { 74, 23, "O transporte poderia ser melhor, mas o local era incrível.", 23 },
                    { 75, 24, "Excelente organização e atenção aos detalhes.", 24 },
                    { 76, 25, "Lugar deslumbrante, recomendo para casais.", 25 },
                    { 77, 26, "Um pouco caro, mas valeu a pena.", 26 },
                    { 78, 27, "Paisagens de tirar o fôlego!", 27 },
                    { 79, 28, "Foi uma aventura inesquecível.", 28 },
                    { 80, 29, "Gostei da flexibilidade no roteiro.", 29 },
                    { 81, 30, "Bom para grupos grandes, bastante espaço.", 30 },
                    { 82, 31, "Adorei a comida servida durante o passeio.", 31 },
                    { 83, 32, "O tempo estava ótimo e tudo saiu como planejado.", 32 },
                    { 84, 33, "Poderiam ter mais informações sobre o local, mas gostei.", 33 },
                    { 85, 34, "O guia era muito simpático e experiente.", 34 },
                    { 86, 35, "Recomendo para quem gosta de aprender sobre história.", 35 },
                    { 87, 36, "Ótimo custo-benefício.", 36 },
                    { 88, 37, "Muito bem organizado e pontual.", 37 },
                    { 89, 38, "Lugar paradisíaco, voltarei com certeza!", 38 },
                    { 90, 39, "Fiquei encantado com o serviço personalizado.", 39 }
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

            migrationBuilder.InsertData(
                table: "ExcursaoFavoritaModel",
                columns: new[] { "Id", "ClienteId", "Comentario", "ExcursaoId" },
                values: new object[,]
                {
                    { 51, 31, "Um passeio incrível, superou minhas expectativas.", 39 },
                    { 52, 22, "Paisagens maravilhosas e equipe muito atenciosa.", 22 },
                    { 53, 23, "A comida durante o passeio foi ótima!", 23 },
                    { 54, 34, "Perfeito para quem quer relaxar.", 34 },
                    { 55, 25, "O guia era muito experiente, adorei.", 25 },
                    { 56, 36, "Não gostei do transporte, mas o lugar era maravilhoso.", 26 },
                    { 57, 27, "Recomendo para famílias e grupos de amigos.", 27 },
                    { 58, 28, "Os horários foram bem respeitados, muito profissional.", 28 },
                    { 59, 29, "Vista espetacular, vale a pena!", 29 },
                    { 60, 30, "O roteiro foi excelente e bem diversificado.", 30 },
                    { 61, 31, "Faltaram algumas explicações, mas no geral foi bom.", 31 },
                    { 62, 32, "Incrível! Voltarei em breve.", 32 },
                    { 63, 23, "Boa excursão, mas o preço poderia ser mais acessível.", 33 },
                    { 64, 24, "Ótima experiência cultural, adorei aprender mais sobre a história.", 24 },
                    { 65, 29, "A trilha foi um pouco difícil, mas a vista compensou.", 25 },
                    { 66, 26, "Muito bem planejado, recomendo para todos.", 26 },
                    { 67, 37, "Adorei o cuidado com a segurança.", 27 },
                    { 68, 38, "Fui com amigos e nos divertimos muito.", 39 },
                    { 69, 29, "Lugar lindo, mas o passeio foi muito rápido.", 33 },
                    { 70, 26, "Perfeito para quem ama aventura e natureza.", 32 }
                });
        }
    }
}
