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

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ID_CLIENT")
                        .HasColumnType("int");

                    b.Property<bool>("PAYMENT_STATUS")
                        .HasColumnType("bit");

                    b.Property<int>("TOTAL_PERSONS_NUMBER")
                        .HasColumnType("int");

                    b.HasKey("ID_BOOKING");

                    b.HasIndex("ClienteId");

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
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Login")
                        .HasColumnType("bit");

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ClienteId");

                    b.HasIndex("NIF")
                        .IsUnique();

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

            modelBuilder.Entity("ReserveSystem.Models.RoomServiceBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("BookedState")
                        .HasColumnType("bit");

                    b.Property<int?>("BookingID_BOOKING")
                        .HasColumnType("int");

                    b.Property<int>("ClientFeedback")
                        .HasColumnType("INTEGER(1)");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER(11)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool>("PaymentDone")
                        .HasColumnType("bit");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomModelID_ROOM")
                        .HasColumnType("int");

                    b.Property<int>("RoomServiceId")
                        .HasColumnType("INTEGER(11)");

                    b.Property<bool>("StaffConfirmation")
                        .HasColumnType("bit");

                    b.Property<int>("StaffId")
                        .HasColumnType("INTEGER(11)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<decimal>("ValueToPay")
                        .HasColumnType("decimal(8, 2)");

                    b.HasKey("Id");

                    b.HasIndex("BookingID_BOOKING");

                    b.HasIndex("RoomModelID_ROOM");

                    b.ToTable("RoomServiceBooking");
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
                        .HasForeignKey("ClienteId");

                    b.Navigation("Client");
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

            modelBuilder.Entity("ReserveSystem.Models.RoomServiceBooking", b =>
                {
                    b.HasOne("ReserveSystem.Models.Booking", null)
                        .WithMany("RoomServiceBookings")
                        .HasForeignKey("BookingID_BOOKING");

                    b.HasOne("ReserveSystem.Models.RoomModel", null)
                        .WithMany("RoomServiceBookings")
                        .HasForeignKey("RoomModelID_ROOM");
                });

            modelBuilder.Entity("ReserveSystem.Models.Booking", b =>
                {
                    b.Navigation("RoomServiceBookings");
                });

            modelBuilder.Entity("ReserveSystem.Models.ClientModel", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomModel", b =>
                {
                    b.Navigation("RoomServiceBookings");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
