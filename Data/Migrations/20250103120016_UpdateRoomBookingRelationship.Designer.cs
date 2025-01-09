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
    [Migration("20250103120016_UpdateRoomBookingRelationship")]
    partial class UpdateRoomBookingRelationship
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

                    b.Property<bool>("Login")
                        .HasColumnType("bit");

                    b.Property<string>("NIF")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ClienteId");

                    b.HasIndex("NIF")
                        .IsUnique()
                        .HasFilter("[NIF] IS NOT NULL");

                    b.ToTable("Client");
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

            modelBuilder.Entity("ReserveSystem.Models.RoomBooking", b =>
                {
                    b.Property<int>("ID_ROOM_BOOKING")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_ROOM_BOOKING"));

                    b.Property<int>("ID_BOOKING")
                        .HasColumnType("int");

                    b.Property<int>("ID_ROOM")
                        .HasColumnType("int");

                    b.Property<int>("PERSON_NUMBER")
                        .HasColumnType("int");

                    b.HasKey("ID_ROOM_BOOKING");

                    b.HasIndex("ID_BOOKING");

                    b.HasIndex("ID_ROOM");

                    b.ToTable("RoomBooking");
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

            modelBuilder.Entity("ReserveSystem.Models.RoomBooking", b =>
                {
                    b.HasOne("ReserveSystem.Models.Booking", "Booking")
                        .WithMany()
                        .HasForeignKey("ID_BOOKING")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.RoomModel", "RoomModel")
                        .WithMany()
                        .HasForeignKey("ID_ROOM")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("RoomModel");
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

            modelBuilder.Entity("ReserveSystem.Models.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
