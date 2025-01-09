﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReserveSystem.Data;

#nullable disable

namespace ReserveSystem.Migrations
{
    [DbContext(typeof(ReserveSystemContext))]
    [Migration("20250104211130_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ReserveSystem.Models.ClientModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MoradaCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NIF")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("ClientModel");
                });

            modelBuilder.Entity("ReserveSystem.Models.Equipamento", b =>
                {
                    b.Property<long>("IdEquipamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdTipoEquipamento")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeEquipamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("TipoEquipamentoIdTipoEquipamento")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdEquipamento");

                    b.HasIndex("TipoEquipamentoIdTipoEquipamento");

                    b.ToTable("Equipamento");
                });

            modelBuilder.Entity("ReserveSystem.Models.Reserva", b =>
                {
                    b.Property<long>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataEstado")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("TEXT");

                    b.Property<long?>("EquipamentoIdEquipamento")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("IdEquipamento")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdTipoReserva")
                        .HasColumnType("INTEGER");

                    b.Property<long>("NumeroCliente")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PrecoTotal")
                        .HasColumnType("REAL");

                    b.Property<int>("TotalParticipantes")
                        .HasColumnType("INTEGER");

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
                        .HasColumnType("INTEGER");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER");

                    b.Property<TimeOnly>("HoraFim")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("HoraInicio")
                        .HasColumnType("TEXT");

                    b.Property<long>("IdTipoSala")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("TempoPreparação")
                        .HasColumnType("TEXT");

                    b.HasKey("IdSala");

                    b.HasIndex("IdTipoSala");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("ReserveSystem.Models.TipoEquipamento", b =>
                {
                    b.Property<long>("IdTipoEquipamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeTipoEquipamento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdTipoEquipamento");

                    b.ToTable("TipoEquipamento");
                });

            modelBuilder.Entity("ReserveSystem.Models.TipoReserva", b =>
                {
                    b.Property<long>("idTipoReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeReserva")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idTipoReserva");

                    b.ToTable("TipoReserva");
                });

            modelBuilder.Entity("ReserveSystem.Models.TipoSala", b =>
                {
                    b.Property<long>("IdTipoSala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacidade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeSala")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<double>("PreçoHora")
                        .HasColumnType("REAL");

                    b.Property<int>("TamanhoSala")
                        .HasColumnType("INTEGER");

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
