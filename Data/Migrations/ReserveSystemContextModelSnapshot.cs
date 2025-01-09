﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReserveSystem.Data;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    [DbContext(typeof(ReserveSystemContext))]
    partial class ReserveSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReserveSystem.Models.ClientModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoradaCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NIF")
                        .HasColumnType("int");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("ClientModel");
                });

            modelBuilder.Entity("ReserveSystem.Models.Equipamento", b =>
                {
                    b.Property<long>("IdEquipamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdEquipamento"));

                    b.Property<long>("IdTipoEquipamento")
                        .HasColumnType("bigint");

                    b.Property<string>("NomeEquipamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<long?>("TipoEquipamentoIdTipoEquipamento")
                        .HasColumnType("bigint");

                    b.HasKey("IdEquipamento");

                    b.HasIndex("TipoEquipamentoIdTipoEquipamento");

                    b.ToTable("Equipamento");
                });

            modelBuilder.Entity("ReserveSystem.Models.Reserva", b =>
                {
                    b.Property<long>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdReserva"));

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEstado")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("datetime2");

                    b.Property<long?>("EquipamentoIdEquipamento")
                        .HasColumnType("bigint");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdEquipamento")
                        .HasColumnType("bigint");

                    b.Property<long>("IdTipoReserva")
                        .HasColumnType("bigint");

                    b.Property<long>("NumeroCliente")
                        .HasColumnType("bigint");

                    b.Property<double>("PrecoTotal")
                        .HasColumnType("float");

                    b.Property<int>("TotalParticipantes")
                        .HasColumnType("int");

                    b.HasKey("IdReserva");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EquipamentoIdEquipamento");

                    b.HasIndex("IdTipoReserva");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("ReserveSystem.Models.Sala", b =>
                {
                    b.Property<long>("IdSala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdSala"));

                    b.Property<TimeOnly>("HoraFim")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<long>("IdTipoSala")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan>("TempoPreparação")
                        .HasColumnType("time");

                    b.HasKey("IdSala");

                    b.HasIndex("IdTipoSala");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("ReserveSystem.Models.TipoEquipamento", b =>
                {
                    b.Property<long>("IdTipoEquipamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdTipoEquipamento"));

                    b.Property<string>("NomeTipoEquipamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipoEquipamento");

                    b.ToTable("TipoEquipamento");
                });

            modelBuilder.Entity("ReserveSystem.Models.TipoReserva", b =>
                {
                    b.Property<long>("idTipoReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("idTipoReserva"));

                    b.Property<string>("NomeReserva")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idTipoReserva");

                    b.ToTable("TipoReserva");
                });

            modelBuilder.Entity("ReserveSystem.Models.TipoSala", b =>
                {
                    b.Property<long>("IdTipoSala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdTipoSala"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<string>("NomeSala")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("PreçoHora")
                        .HasColumnType("float");

                    b.Property<int>("TamanhoSala")
                        .HasColumnType("int");

                    b.HasKey("IdTipoSala");

                    b.ToTable("TipoSala");
                });

            modelBuilder.Entity("ReserveSystem.Models.Equipamento", b =>
                {
                    b.HasOne("ReserveSystem.Models.TipoEquipamento", "TipoEquipamento")
                        .WithMany("Equipamento")
                        .HasForeignKey("TipoEquipamentoIdTipoEquipamento");

                    b.Navigation("TipoEquipamento");
                });

            modelBuilder.Entity("ReserveSystem.Models.Reserva", b =>
                {
                    b.HasOne("ReserveSystem.Models.ClientModel", "Client")
                        .WithMany("Reserva")
                        .HasForeignKey("ClienteId");

                    b.HasOne("ReserveSystem.Models.Equipamento", "Equipamento")
                        .WithMany()
                        .HasForeignKey("EquipamentoIdEquipamento");

                    b.HasOne("ReserveSystem.Models.TipoReserva", "TipoReserva")
                        .WithMany()
                        .HasForeignKey("IdTipoReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Equipamento");

                    b.Navigation("TipoReserva");
                });

            modelBuilder.Entity("ReserveSystem.Models.Sala", b =>
                {
                    b.HasOne("ReserveSystem.Models.TipoSala", "TipoSala")
                        .WithMany("Salas")
                        .HasForeignKey("IdTipoSala")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoSala");
                });

            modelBuilder.Entity("ReserveSystem.Models.ClientModel", b =>
                {
                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("ReserveSystem.Models.TipoEquipamento", b =>
                {
                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("ReserveSystem.Models.TipoSala", b =>
                {
                    b.Navigation("Salas");
                });
#pragma warning restore 612, 618
        }
    }
}
