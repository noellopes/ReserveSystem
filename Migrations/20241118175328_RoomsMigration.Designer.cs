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
    [Migration("20241118175328_RoomsMigration")]
    partial class RoomsMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReserveSystem.Models.ClienteModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Login")
                        .HasColumnType("bit");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ReserveSystem.Models.ReservaModel", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCheckOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstadoPagamento")
                        .HasColumnType("bit");

                    b.Property<int>("NumeroPessoas")
                        .HasColumnType("int");

                    b.HasKey("ReservaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("ReserveSystem.Models.Rooms", b =>
                {
                    b.Property<int>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomTypeId"));

                    b.Property<string>("AdaptedRoom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<bool>("HasView")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfRooms")
                        .HasColumnType("int");

                    b.Property<int>("RoomType")
                        .HasColumnType("int");

                    b.HasKey("RoomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("ReserveSystem.Models.ReservaModel", b =>
                {
                    b.HasOne("ReserveSystem.Models.ClienteModel", "Cliente")
                        .WithMany("Reserva")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ReserveSystem.Models.ClienteModel", b =>
                {
                    b.Navigation("Reserva");
                });
#pragma warning restore 612, 618
        }
    }
}