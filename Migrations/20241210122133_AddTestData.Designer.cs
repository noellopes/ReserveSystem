﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReserveSystem.Data;

#nullable disable

namespace ReserveSystem.Migrations
{
    [DbContext(typeof(ReserveSystemContext))]
    [Migration("20241210122133_AddTestData")]
    partial class AddTestData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReserveSystem.Models.ClienteTestModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("ClienteTestModel");

                    b.HasData(
                        new
                        {
                            ClienteId = 21,
                            DataNascimento = new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "carlos.silva@email.com",
                            Nome = "Carlos Silva",
                            Telefone = "923412453"
                        },
                        new
                        {
                            ClienteId = 22,
                            DataNascimento = new DateTime(1990, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ana.oliveira@email.com",
                            Nome = "Ana Oliveira",
                            Telefone = "998765432"
                        },
                        new
                        {
                            ClienteId = 23,
                            DataNascimento = new DateTime(1982, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "joao.pereira@email.com",
                            Nome = "João Pereira",
                            Telefone = "987654321"
                        },
                        new
                        {
                            ClienteId = 24,
                            DataNascimento = new DateTime(1978, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "maria.souza@email.com",
                            Nome = "Maria Souza",
                            Telefone = "996543210"
                        },
                        new
                        {
                            ClienteId = 25,
                            DataNascimento = new DateTime(1993, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lucas.costa@email.com",
                            Nome = "Lucas Costa",
                            Telefone = "934567890"
                        },
                        new
                        {
                            ClienteId = 26,
                            DataNascimento = new DateTime(1989, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "isabela.almeida@email.com",
                            Nome = "Isabela Almeida",
                            Telefone = "945678901"
                        },
                        new
                        {
                            ClienteId = 27,
                            DataNascimento = new DateTime(1995, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "felipe.rocha@email.com",
                            Nome = "Felipe Rocha",
                            Telefone = "923456789"
                        },
                        new
                        {
                            ClienteId = 28,
                            DataNascimento = new DateTime(1983, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "carla.martins@email.com",
                            Nome = "Carla Martins",
                            Telefone = "911223344"
                        },
                        new
                        {
                            ClienteId = 29,
                            DataNascimento = new DateTime(1990, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "fernando.gomes@email.com",
                            Nome = "Fernando Gomes",
                            Telefone = "997654321"
                        },
                        new
                        {
                            ClienteId = 30,
                            DataNascimento = new DateTime(1988, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "beatriz.santos@email.com",
                            Nome = "Beatriz Santos",
                            Telefone = "968754321"
                        },
                        new
                        {
                            ClienteId = 31,
                            DataNascimento = new DateTime(1992, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ricardo.ferreira@email.com",
                            Nome = "Ricardo Ferreira",
                            Telefone = "954321098"
                        },
                        new
                        {
                            ClienteId = 32,
                            DataNascimento = new DateTime(1994, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "juliana.silva@email.com",
                            Nome = "Juliana Silva",
                            Telefone = "924567890"
                        },
                        new
                        {
                            ClienteId = 33,
                            DataNascimento = new DateTime(1987, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "gabriel.lima@email.com",
                            Nome = "Gabriel Lima",
                            Telefone = "917654321"
                        },
                        new
                        {
                            ClienteId = 34,
                            DataNascimento = new DateTime(1991, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mariana.costa@email.com",
                            Nome = "Mariana Costa",
                            Telefone = "935678902"
                        },
                        new
                        {
                            ClienteId = 35,
                            DataNascimento = new DateTime(1980, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "vitor.hugo@email.com",
                            Nome = "Vitor Hugo",
                            Telefone = "945678901"
                        },
                        new
                        {
                            ClienteId = 36,
                            DataNascimento = new DateTime(1994, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "larissa.oliveira@email.com",
                            Nome = "Larissa Oliveira",
                            Telefone = "923456788"
                        },
                        new
                        {
                            ClienteId = 37,
                            DataNascimento = new DateTime(1993, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "rafael.souza@email.com",
                            Nome = "Rafael Souza",
                            Telefone = "999887777"
                        },
                        new
                        {
                            ClienteId = 38,
                            DataNascimento = new DateTime(1986, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "paula.dias@email.com",
                            Nome = "Paula Dias",
                            Telefone = "912345678"
                        },
                        new
                        {
                            ClienteId = 39,
                            DataNascimento = new DateTime(1992, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "eduardo.rocha@email.com",
                            Nome = "Eduardo Rocha",
                            Telefone = "923456788"
                        },
                        new
                        {
                            ClienteId = 40,
                            DataNascimento = new DateTime(1984, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tatiane.santos@email.com",
                            Nome = "Tatiane Santos",
                            Telefone = "943567890"
                        });
                });

            modelBuilder.Entity("ReserveSystem.Models.ExcursaoModel", b =>
                {
                    b.Property<int>("Excursao_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Excursao_Id"));

                    b.Property<DateTime>("Data_Fim")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("Data_Inicio")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Preco")
                        .HasColumnType("FLOAT");

                    b.Property<int>("Staff_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Excursao_Id");

                    b.ToTable("ExcursaoModel");

                    b.HasData(
                        new
                        {
                            Excursao_Id = 20,
                            Data_Fim = new DateTime(2024, 12, 12, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(786),
                            Data_Inicio = new DateTime(2024, 12, 11, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(771),
                            Descricao = "Exploração cultural pela cidade",
                            Preco = 50.0,
                            Staff_Id = 1,
                            Titulo = "Tour pela Cidade"
                        },
                        new
                        {
                            Excursao_Id = 21,
                            Data_Fim = new DateTime(2024, 12, 13, 16, 21, 33, 510, DateTimeKind.Utc).AddTicks(788),
                            Data_Inicio = new DateTime(2024, 12, 13, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(787),
                            Descricao = "Passeio pelas águas tranquilas",
                            Preco = 80.0,
                            Staff_Id = 2,
                            Titulo = "Passeio de Barco"
                        },
                        new
                        {
                            Excursao_Id = 22,
                            Data_Fim = new DateTime(2024, 12, 15, 18, 21, 33, 510, DateTimeKind.Utc).AddTicks(790),
                            Data_Inicio = new DateTime(2024, 12, 15, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(789),
                            Descricao = "Uma aventura entre as montanhas",
                            Preco = 120.0,
                            Staff_Id = 3,
                            Titulo = "Caminhada na Montanha"
                        },
                        new
                        {
                            Excursao_Id = 23,
                            Data_Fim = new DateTime(2024, 12, 16, 15, 21, 33, 510, DateTimeKind.Utc).AddTicks(792),
                            Data_Inicio = new DateTime(2024, 12, 16, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(791),
                            Descricao = "Caminhada e observação da fauna e flora do parque",
                            Preco = 40.0,
                            Staff_Id = 4,
                            Titulo = "Passeio no Parque"
                        },
                        new
                        {
                            Excursao_Id = 24,
                            Data_Fim = new DateTime(2024, 12, 17, 17, 21, 33, 510, DateTimeKind.Utc).AddTicks(793),
                            Data_Inicio = new DateTime(2024, 12, 17, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(793),
                            Descricao = "Exploração subaquática em recifes de corais",
                            Preco = 150.0,
                            Staff_Id = 5,
                            Titulo = "Aventura Subaquática"
                        },
                        new
                        {
                            Excursao_Id = 25,
                            Data_Fim = new DateTime(2024, 12, 18, 15, 21, 33, 510, DateTimeKind.Utc).AddTicks(795),
                            Data_Inicio = new DateTime(2024, 12, 18, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(795),
                            Descricao = "Uma experiência única para ver o mundo de cima",
                            Preco = 200.0,
                            Staff_Id = 6,
                            Titulo = "Passeio de Balão"
                        },
                        new
                        {
                            Excursao_Id = 26,
                            Data_Fim = new DateTime(2024, 12, 19, 18, 21, 33, 510, DateTimeKind.Utc).AddTicks(798),
                            Data_Inicio = new DateTime(2024, 12, 19, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(798),
                            Descricao = "Tour por vinícolas e degustação de vinhos finos",
                            Preco = 120.0,
                            Staff_Id = 7,
                            Titulo = "Rota dos Vinhos"
                        },
                        new
                        {
                            Excursao_Id = 27,
                            Data_Fim = new DateTime(2024, 12, 20, 20, 21, 33, 510, DateTimeKind.Utc).AddTicks(802),
                            Data_Inicio = new DateTime(2024, 12, 20, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(802),
                            Descricao = "Aventura no deserto com passeio de camelo e visita a oásis",
                            Preco = 250.0,
                            Staff_Id = 8,
                            Titulo = "Expedição ao Deserto"
                        },
                        new
                        {
                            Excursao_Id = 28,
                            Data_Fim = new DateTime(2024, 12, 22, 0, 21, 33, 510, DateTimeKind.Utc).AddTicks(804),
                            Data_Inicio = new DateTime(2024, 12, 21, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(804),
                            Descricao = "Safari em reserva natural com guia especializado",
                            Preco = 500.0,
                            Staff_Id = 9,
                            Titulo = "Safari na África"
                        },
                        new
                        {
                            Excursao_Id = 29,
                            Data_Fim = new DateTime(2024, 12, 22, 22, 21, 33, 510, DateTimeKind.Utc).AddTicks(806),
                            Data_Inicio = new DateTime(2024, 12, 22, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(805),
                            Descricao = "Aventura no Ártico para ver as luzes do norte",
                            Preco = 350.0,
                            Staff_Id = 10,
                            Titulo = "Expedição Polar"
                        },
                        new
                        {
                            Excursao_Id = 30,
                            Data_Fim = new DateTime(2024, 12, 23, 21, 21, 33, 510, DateTimeKind.Utc).AddTicks(810),
                            Data_Inicio = new DateTime(2024, 12, 23, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(809),
                            Descricao = "Exploração pela floresta amazônica com guias especializados",
                            Preco = 180.0,
                            Staff_Id = 11,
                            Titulo = "Trekking na Amazônia"
                        },
                        new
                        {
                            Excursao_Id = 31,
                            Data_Fim = new DateTime(2024, 12, 24, 17, 21, 33, 510, DateTimeKind.Utc).AddTicks(812),
                            Data_Inicio = new DateTime(2024, 12, 24, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(811),
                            Descricao = "Passeio pelas trilhas que levam às maiores cataratas do mundo",
                            Preco = 90.0,
                            Staff_Id = 12,
                            Titulo = "Trilha das Cataratas"
                        },
                        new
                        {
                            Excursao_Id = 32,
                            Data_Fim = new DateTime(2024, 12, 25, 16, 21, 33, 510, DateTimeKind.Utc).AddTicks(813),
                            Data_Inicio = new DateTime(2024, 12, 25, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(813),
                            Descricao = "Aventura subaquática com mergulho em recifes de corais",
                            Preco = 130.0,
                            Staff_Id = 13,
                            Titulo = "Mergulho em Recife"
                        },
                        new
                        {
                            Excursao_Id = 33,
                            Data_Fim = new DateTime(2024, 12, 26, 17, 21, 33, 510, DateTimeKind.Utc).AddTicks(815),
                            Data_Inicio = new DateTime(2024, 12, 26, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(815),
                            Descricao = "Tour pelas principais atrações históricas da cidade",
                            Preco = 60.0,
                            Staff_Id = 14,
                            Titulo = "Passeio Histórico"
                        },
                        new
                        {
                            Excursao_Id = 34,
                            Data_Fim = new DateTime(2024, 12, 27, 18, 21, 33, 510, DateTimeKind.Utc).AddTicks(817),
                            Data_Inicio = new DateTime(2024, 12, 27, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(816),
                            Descricao = "Tour histórico pelas antigas missões dos Jesuítas",
                            Preco = 80.0,
                            Staff_Id = 15,
                            Titulo = "Caminho dos Jesuítas"
                        },
                        new
                        {
                            Excursao_Id = 35,
                            Data_Fim = new DateTime(2024, 12, 28, 16, 21, 33, 510, DateTimeKind.Utc).AddTicks(818),
                            Data_Inicio = new DateTime(2024, 12, 28, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(818),
                            Descricao = "Passeio de bicicleta pelas trilhas montanhosas",
                            Preco = 70.0,
                            Staff_Id = 16,
                            Titulo = "Ciclismo nas Montanhas"
                        },
                        new
                        {
                            Excursao_Id = 36,
                            Data_Fim = new DateTime(2024, 12, 29, 17, 21, 33, 510, DateTimeKind.Utc).AddTicks(820),
                            Data_Inicio = new DateTime(2024, 12, 29, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(820),
                            Descricao = "Aventura de rafting em um dos rios mais desafiadores",
                            Preco = 110.0,
                            Staff_Id = 17,
                            Titulo = "Rafting no Rio"
                        },
                        new
                        {
                            Excursao_Id = 37,
                            Data_Fim = new DateTime(2024, 12, 30, 19, 21, 33, 510, DateTimeKind.Utc).AddTicks(823),
                            Data_Inicio = new DateTime(2024, 12, 30, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(823),
                            Descricao = "Experiência gastronômica por diferentes restaurantes locais",
                            Preco = 150.0,
                            Staff_Id = 18,
                            Titulo = "Tour Gastronômico"
                        },
                        new
                        {
                            Excursao_Id = 38,
                            Data_Fim = new DateTime(2024, 12, 31, 21, 21, 33, 510, DateTimeKind.Utc).AddTicks(825),
                            Data_Inicio = new DateTime(2024, 12, 31, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(824),
                            Descricao = "Caminhada até a cratera de um vulcão ativo",
                            Preco = 180.0,
                            Staff_Id = 19,
                            Titulo = "Aventura no Vulcão"
                        },
                        new
                        {
                            Excursao_Id = 39,
                            Data_Fim = new DateTime(2025, 1, 1, 20, 21, 33, 510, DateTimeKind.Utc).AddTicks(826),
                            Data_Inicio = new DateTime(2025, 1, 1, 12, 21, 33, 510, DateTimeKind.Utc).AddTicks(826),
                            Descricao = "Uma experiência no globo de neve para explorar as regiões geladas",
                            Preco = 220.0,
                            Staff_Id = 20,
                            Titulo = "Aventura no Globo de Neve"
                        });
                });

            modelBuilder.Entity("ReserveSystem.Models.JobTestModel", b =>
                {
                    b.Property<int>("Job_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Job_ID"));

                    b.Property<string>("Job_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Job_ID");

                    b.ToTable("JobTestModel");
                });

            modelBuilder.Entity("ReserveSystem.Models.ReservaExcursaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("DATETIME");

                    b.Property<int>("ExcursaoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumPessoas")
                        .HasColumnType("int");

                    b.Property<int>("ValorTotal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ExcursaoId");

                    b.ToTable("ReservaExcursaoModel");
                });

            modelBuilder.Entity("ReserveSystem.Models.StaffTestModel", b =>
                {
                    b.Property<int>("Staff_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Staff_Id"));

                    b.Property<int>("Job_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Staff_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Staff_Id");

                    b.ToTable("StaffTestModel");
                });

            modelBuilder.Entity("ReserveSystem.Models.ReservaExcursaoModel", b =>
                {
                    b.HasOne("ReserveSystem.Models.ClienteTestModel", "Cliente")
                        .WithMany("ReservaExcursoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.ExcursaoModel", "Excursao")
                        .WithMany("ReservaExcursoes")
                        .HasForeignKey("ExcursaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Excursao");
                });

            modelBuilder.Entity("ReserveSystem.Models.ClienteTestModel", b =>
                {
                    b.Navigation("ReservaExcursoes");
                });

            modelBuilder.Entity("ReserveSystem.Models.ExcursaoModel", b =>
                {
                    b.Navigation("ReservaExcursoes");
                });
#pragma warning restore 612, 618
        }
    }
}