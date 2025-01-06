using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDataTransporte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Transporte",
                keyColumn: "TransporteId",
                keyValue: 50);
        }
    }
}
