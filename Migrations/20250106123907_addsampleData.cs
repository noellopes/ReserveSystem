using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class addsampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            
        }
    }
}
