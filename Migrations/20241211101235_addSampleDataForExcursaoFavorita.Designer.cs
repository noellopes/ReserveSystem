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
    [Migration("20241211101235_addSampleDataForExcursaoFavorita")]
    partial class addSampleDataForExcursaoFavorita
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
                });

            modelBuilder.Entity("ReserveSystem.Models.ExcursaoFavoritaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExcursaoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ExcursaoId");

                    b.ToTable("ExcursaoFavoritaModel");

                    b.HasData(
                        new
                        {
                            Id = 71,
                            ClienteId = 20,
                            Comentario = "Passeio encantador, perfeito para relaxar.",
                            ExcursaoId = 20
                        },
                        new
                        {
                            Id = 72,
                            ClienteId = 21,
                            Comentario = "Guias excelentes e vistas incríveis!",
                            ExcursaoId = 21
                        },
                        new
                        {
                            Id = 73,
                            ClienteId = 22,
                            Comentario = "Muito divertido, meus filhos adoraram.",
                            ExcursaoId = 22
                        },
                        new
                        {
                            Id = 74,
                            ClienteId = 23,
                            Comentario = "O transporte poderia ser melhor, mas o local era incrível.",
                            ExcursaoId = 23
                        },
                        new
                        {
                            Id = 75,
                            ClienteId = 24,
                            Comentario = "Excelente organização e atenção aos detalhes.",
                            ExcursaoId = 24
                        },
                        new
                        {
                            Id = 76,
                            ClienteId = 25,
                            Comentario = "Lugar deslumbrante, recomendo para casais.",
                            ExcursaoId = 25
                        },
                        new
                        {
                            Id = 77,
                            ClienteId = 26,
                            Comentario = "Um pouco caro, mas valeu a pena.",
                            ExcursaoId = 26
                        },
                        new
                        {
                            Id = 78,
                            ClienteId = 27,
                            Comentario = "Paisagens de tirar o fôlego!",
                            ExcursaoId = 27
                        },
                        new
                        {
                            Id = 79,
                            ClienteId = 28,
                            Comentario = "Foi uma aventura inesquecível.",
                            ExcursaoId = 28
                        },
                        new
                        {
                            Id = 80,
                            ClienteId = 29,
                            Comentario = "Gostei da flexibilidade no roteiro.",
                            ExcursaoId = 29
                        },
                        new
                        {
                            Id = 81,
                            ClienteId = 30,
                            Comentario = "Bom para grupos grandes, bastante espaço.",
                            ExcursaoId = 30
                        },
                        new
                        {
                            Id = 82,
                            ClienteId = 31,
                            Comentario = "Adorei a comida servida durante o passeio.",
                            ExcursaoId = 31
                        },
                        new
                        {
                            Id = 83,
                            ClienteId = 32,
                            Comentario = "O tempo estava ótimo e tudo saiu como planejado.",
                            ExcursaoId = 32
                        },
                        new
                        {
                            Id = 84,
                            ClienteId = 33,
                            Comentario = "Poderiam ter mais informações sobre o local, mas gostei.",
                            ExcursaoId = 33
                        },
                        new
                        {
                            Id = 85,
                            ClienteId = 34,
                            Comentario = "O guia era muito simpático e experiente.",
                            ExcursaoId = 34
                        },
                        new
                        {
                            Id = 86,
                            ClienteId = 35,
                            Comentario = "Recomendo para quem gosta de aprender sobre história.",
                            ExcursaoId = 35
                        },
                        new
                        {
                            Id = 87,
                            ClienteId = 36,
                            Comentario = "Ótimo custo-benefício.",
                            ExcursaoId = 36
                        },
                        new
                        {
                            Id = 88,
                            ClienteId = 37,
                            Comentario = "Muito bem organizado e pontual.",
                            ExcursaoId = 37
                        },
                        new
                        {
                            Id = 89,
                            ClienteId = 38,
                            Comentario = "Lugar paradisíaco, voltarei com certeza!",
                            ExcursaoId = 38
                        },
                        new
                        {
                            Id = 90,
                            ClienteId = 39,
                            Comentario = "Fiquei encantado com o serviço personalizado.",
                            ExcursaoId = 39
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

                    b.Property<decimal>("Preco")
                        .HasColumnType("DECIMAL");

                    b.Property<int>("Staff_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Excursao_Id");

                    b.ToTable("ExcursaoModel");
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

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

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

            modelBuilder.Entity("ReserveSystem.Models.ExcursaoFavoritaModel", b =>
                {
                    b.HasOne("ReserveSystem.Models.ClienteTestModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.ExcursaoModel", "Excursao")
                        .WithMany()
                        .HasForeignKey("ExcursaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Excursao");
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