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
    [Migration("20250105232604_AddData")]
    partial class AddData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReserveSystem.Models.ExcursaoModel", b =>
                {
                    b.Property<int>("ExcursaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExcursaoId"));

                    b.Property<DateTime>("Data_Fim")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("Data_Inicio")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Preco")
                        .HasColumnType("FLOAT");

                    b.Property<int>("StaffId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ExcursaoId");

                    b.HasIndex("StaffId");

                    b.ToTable("ExcursaoModel");
                });

            modelBuilder.Entity("ReserveSystem.Models.PrecarioModel", b =>
                {
                    b.Property<int>("PrecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrecoId"));

                    b.Property<DateTime>("Data_Inicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExcursaoId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Preco")
                        .HasColumnType("real");

                    b.HasKey("PrecoId");

                    b.HasIndex("ExcursaoId");

                    b.ToTable("PrecarioModel");
                });

            modelBuilder.Entity("ReserveSystem.Models.StaffModel", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<string>("Job_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Staff_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffId");

                    b.ToTable("StaffModel");

                    b.HasData(
                        new
                        {
                            StaffId = 1,
                            Job_Name = "Motorista",
                            Staff_Name = "João Silva"
                        },
                        new
                        {
                            StaffId = 2,
                            Job_Name = "Gestor de Excursão",
                            Staff_Name = "Maria Oliveira"
                        },
                        new
                        {
                            StaffId = 3,
                            Job_Name = "Guia Turistico",
                            Staff_Name = "Carlos Santos"
                        },
                        new
                        {
                            StaffId = 4,
                            Job_Name = "Motorista",
                            Staff_Name = "Ana Souza"
                        },
                        new
                        {
                            StaffId = 5,
                            Job_Name = "Gestor de Excursão",
                            Staff_Name = "Pedro Almeida"
                        },
                        new
                        {
                            StaffId = 6,
                            Job_Name = "Guia Turistico",
                            Staff_Name = "Luciana Costa"
                        },
                        new
                        {
                            StaffId = 7,
                            Job_Name = "Motorista",
                            Staff_Name = "Rafael Gomes"
                        },
                        new
                        {
                            StaffId = 8,
                            Job_Name = "Gestor de Excursão",
                            Staff_Name = "Fernanda Carvalho"
                        },
                        new
                        {
                            StaffId = 9,
                            Job_Name = "Guia Turistico",
                            Staff_Name = "Ricardo Pereira"
                        },
                        new
                        {
                            StaffId = 10,
                            Job_Name = "Motorista",
                            Staff_Name = "Juliana Mendes"
                        },
                        new
                        {
                            StaffId = 11,
                            Job_Name = "Gestor de Excursão",
                            Staff_Name = "Gustavo Rocha"
                        },
                        new
                        {
                            StaffId = 12,
                            Job_Name = "Guia Turistico",
                            Staff_Name = "Camila Ribeiro"
                        },
                        new
                        {
                            StaffId = 13,
                            Job_Name = "Motorista",
                            Staff_Name = "André Lima"
                        },
                        new
                        {
                            StaffId = 14,
                            Job_Name = "Gestor de Excursão",
                            Staff_Name = "Patrícia Fonseca"
                        },
                        new
                        {
                            StaffId = 15,
                            Job_Name = "Guia Turistico",
                            Staff_Name = "Tiago Martins"
                        },
                        new
                        {
                            StaffId = 16,
                            Job_Name = "Motorista",
                            Staff_Name = "Letícia Freitas"
                        },
                        new
                        {
                            StaffId = 17,
                            Job_Name = "Gestor de Excursão",
                            Staff_Name = "Bruno Vieira"
                        },
                        new
                        {
                            StaffId = 18,
                            Job_Name = "Guia Turistico",
                            Staff_Name = "Sara Fernandes"
                        },
                        new
                        {
                            StaffId = 19,
                            Job_Name = "Motorista",
                            Staff_Name = "Rodrigo Lopes"
                        },
                        new
                        {
                            StaffId = 20,
                            Job_Name = "Gestor de Excursão",
                            Staff_Name = "Natália Correia"
                        },
                        new
                        {
                            StaffId = 21,
                            Job_Name = "Guia Turistico",
                            Staff_Name = "Eduardo Cardoso"
                        },
                        new
                        {
                            StaffId = 22,
                            Job_Name = "Motorista",
                            Staff_Name = "Carolina Neves"
                        },
                        new
                        {
                            StaffId = 23,
                            Job_Name = "Gestor de Excursão",
                            Staff_Name = "Diego Farias"
                        },
                        new
                        {
                            StaffId = 24,
                            Job_Name = "Guia Turistico",
                            Staff_Name = "Vanessa Moreira"
                        },
                        new
                        {
                            StaffId = 25,
                            Job_Name = "Motorista",
                            Staff_Name = "Felipe Azevedo"
                        });
                });

            modelBuilder.Entity("ReserveSystem.Models.ExcursaoModel", b =>
                {
                    b.HasOne("ReserveSystem.Models.StaffModel", "Staff")
                        .WithMany("Excursao")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("ReserveSystem.Models.PrecarioModel", b =>
                {
                    b.HasOne("ReserveSystem.Models.ExcursaoModel", "Excursao")
                        .WithMany("Precario")
                        .HasForeignKey("ExcursaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Excursao");
                });

            modelBuilder.Entity("ReserveSystem.Models.ExcursaoModel", b =>
                {
                    b.Navigation("Precario");
                });

            modelBuilder.Entity("ReserveSystem.Models.StaffModel", b =>
                {
                    b.Navigation("Excursao");
                });
#pragma warning restore 612, 618
        }
    }
}