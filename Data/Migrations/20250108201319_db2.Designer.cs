﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReserveSystem.Data;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    [DbContext(typeof(ReserveSystemContext))]
    [Migration("20250108201319_db2")]
    partial class db2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReserveSystem.Models.Booking", b =>
                {
                    b.Property<int>("ID_BOOKING")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_BOOKING"));

                    b.Property<bool>("BOOKED")
                        .HasColumnType("bit");

                    b.Property<DateTime>("BOOKING_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CHECKIN_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CHECKOUT_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("ID_CLIENT")
                        .HasColumnType("int");

                    b.Property<bool>("PAYMENT_STATUS")
                        .HasColumnType("bit");

                    b.Property<int>("TOTAL_PERSONS_NUMBER")
                        .HasColumnType("int");

                    b.HasKey("ID_BOOKING");

                    b.HasIndex("ID_CLIENT");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("ReserveSystem.Models.ClientModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identification")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdentificationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.HasIndex("Identification")
                        .IsUnique();

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ReserveSystem.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("CC")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ReserveSystem.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.PrimitiveCollection<string>("WorkSchedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ReserveSystem.Models.Mesa", b =>
                {
                    b.Property<int>("IdMesa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMesa"));

                    b.Property<int>("NumeroLugares")
                        .HasColumnType("int");

                    b.Property<bool>("Reservado")
                        .HasColumnType("bit");

                    b.HasKey("IdMesa");

                    b.ToTable("Mesa");
                });

            modelBuilder.Entity("ReserveSystem.Models.Prato", b =>
                {
                    b.Property<int>("IdPrato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrato"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<string>("PratoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Preco")
                        .HasColumnType("int");

                    b.HasKey("IdPrato");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("ReserveSystem.Models.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"));

                    b.Property<bool>("Aprovacao")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("IdMesa")
                        .HasColumnType("int");

                    b.Property<int?>("IdPrato")
                        .HasColumnType("int");

                    b.Property<int?>("NumeroMesa")
                        .HasColumnType("int");

                    b.Property<int>("NumeroPessoas")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("IdReserva");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdPrato");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomModel", b =>
                {
                    b.Property<int>("ID_ROOM")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_ROOM"));

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.HasKey("ID_ROOM");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomType", b =>
                {
                    b.Property<int>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomTypeId"));

                    b.Property<bool>("AcessibilityRoom")
                        .HasColumnType("bit");

                    b.Property<bool>("HasView")
                        .HasColumnType("bit");

                    b.Property<int>("RoomCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomTypeId");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("ReserveSystem.Models.Booking", b =>
                {
                    b.HasOne("ReserveSystem.Models.ClientModel", "Client")
                        .WithMany("Booking")
                        .HasForeignKey("ID_CLIENT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ReserveSystem.Models.Reserva", b =>
                {
                    b.HasOne("ReserveSystem.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Prato", "Prato")
                        .WithMany("Reservas")
                        .HasForeignKey("IdPrato");

                    b.Navigation("Cliente");

                    b.Navigation("Prato");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomModel", b =>
                {
                    b.HasOne("ReserveSystem.Models.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("ReserveSystem.Models.ClientModel", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("ReserveSystem.Models.Prato", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
