using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class ReserveSystemContext : DbContext
    {

        public ReserveSystemContext(DbContextOptions<ReserveSystemContext> options) : base(options) { }
        public DbSet<ReserveSystem.Models.Transporte> Transporte { get; set; } = default!;
        public DbSet<ReserveSystem.Models.Staff> Staff { get; set; } = default!;
        public DbSet<ReserveSystem.Models.MotoristaTransporte> MotoristaTransporte { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
        }

    }
}


