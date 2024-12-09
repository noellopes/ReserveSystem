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
    [Migration("20241125173104_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReserveSystem.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit");

                    b.Property<int>("TotalPersonsNumber")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("ClientId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("ReserveSystem.Models.Cleaning", b =>
                {
                    b.Property<int>("CleaningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CleaningId"));

                    b.Property<bool>("CleaningService")
                        .HasColumnType("bit");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("CleaningId");

                    b.HasIndex("RoomId");

                    b.ToTable("Cleaning");
                });

            modelBuilder.Entity("ReserveSystem.Models.CleaningShedule", b =>
                {
                    b.Property<int>("CleaningSheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CleaningSheduleId"));

                    b.Property<int>("CleaningId")
                        .HasColumnType("int");

                    b.Property<int?>("CleaningId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateServices")
                        .HasColumnType("datetime2");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("RoomBookingId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomBookingId1")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<int?>("StaffId1")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("CleaningSheduleId");

                    b.HasIndex("CleaningId");

                    b.HasIndex("CleaningId1");

                    b.HasIndex("RoomBookingId");

                    b.HasIndex("RoomBookingId1");

                    b.HasIndex("StaffId");

                    b.HasIndex("StaffId1");

                    b.ToTable("CleaningShedule");
                });

            modelBuilder.Entity("ReserveSystem.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("ClientAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientNIF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ClientStatus")
                        .HasColumnType("bit");

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ReserveSystem.Models.Consumptions", b =>
                {
                    b.Property<int>("ConsumptionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsumptionsId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("ClientId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConsumedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemRoomId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemRoomId1")
                        .HasColumnType("int");

                    b.Property<int>("QuantityConsumed")
                        .HasColumnType("int");

                    b.HasKey("ConsumptionsId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ClientId1");

                    b.HasIndex("ItemRoomId");

                    b.HasIndex("ItemRoomId1");

                    b.ToTable("Consumptions");
                });

            modelBuilder.Entity("ReserveSystem.Models.ItemRoom", b =>
                {
                    b.Property<int>("ItemRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemRoomId"));

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastRestockedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomBookingId")
                        .HasColumnType("int");

                    b.HasKey("ItemRoomId");

                    b.HasIndex("ItemId");

                    b.HasIndex("RoomBookingId");

                    b.ToTable("ItemRoom");
                });

            modelBuilder.Entity("ReserveSystem.Models.Items", b =>
                {
                    b.Property<int>("ItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemsId"));

                    b.Property<int>("MinimumStock")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityStock")
                        .HasColumnType("int");

                    b.HasKey("ItemsId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("ReserveSystem.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.HasKey("JobId");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("ReserveSystem.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomBooking", b =>
                {
                    b.Property<int>("RoomBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomBookingId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<bool>("CleaningOption")
                        .HasColumnType("bit");

                    b.Property<int>("PersonsNumber")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("RoomBookingId");

                    b.HasIndex("BookingId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomBooking");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomType", b =>
                {
                    b.Property<int>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomTypeId"));

                    b.Property<bool>("AccessibilityRoom")
                        .HasColumnType("bit");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

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

            modelBuilder.Entity("ReserveSystem.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("StaffDriverLicense")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StaffDriverLicenseExpiringDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StaffEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffId");

                    b.HasIndex("JobId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("ReserveSystem.Models.Booking", b =>
                {
                    b.HasOne("ReserveSystem.Models.Client", "client")
                        .WithMany("bookings")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");
                });

            modelBuilder.Entity("ReserveSystem.Models.Cleaning", b =>
                {
                    b.HasOne("ReserveSystem.Models.Room", "room")
                        .WithMany("cleanings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("room");
                });

            modelBuilder.Entity("ReserveSystem.Models.CleaningShedule", b =>
                {
                    b.HasOne("ReserveSystem.Models.Cleaning", "cleaning")
                        .WithMany()
                        .HasForeignKey("CleaningId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Cleaning", null)
                        .WithMany("cleaningSchedules")
                        .HasForeignKey("CleaningId1");

                    b.HasOne("ReserveSystem.Models.RoomBooking", "roomBooking")
                        .WithMany()
                        .HasForeignKey("RoomBookingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.RoomBooking", null)
                        .WithMany("cleaningSchedules")
                        .HasForeignKey("RoomBookingId1");

                    b.HasOne("ReserveSystem.Models.Staff", "staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Staff", null)
                        .WithMany("cleaningSchedules")
                        .HasForeignKey("StaffId1");

                    b.Navigation("cleaning");

                    b.Navigation("roomBooking");

                    b.Navigation("staff");
                });

            modelBuilder.Entity("ReserveSystem.Models.Consumptions", b =>
                {
                    b.HasOne("ReserveSystem.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Client", null)
                        .WithMany("consumptions")
                        .HasForeignKey("ClientId1");

                    b.HasOne("ReserveSystem.Models.ItemRoom", "itemRoom")
                        .WithMany()
                        .HasForeignKey("ItemRoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.ItemRoom", null)
                        .WithMany("consumptions")
                        .HasForeignKey("ItemRoomId1");

                    b.Navigation("client");

                    b.Navigation("itemRoom");
                });

            modelBuilder.Entity("ReserveSystem.Models.ItemRoom", b =>
                {
                    b.HasOne("ReserveSystem.Models.Items", "item")
                        .WithMany("itemRooms")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.RoomBooking", "roomBooking")
                        .WithMany("itemRooms")
                        .HasForeignKey("RoomBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("item");

                    b.Navigation("roomBooking");
                });

            modelBuilder.Entity("ReserveSystem.Models.Room", b =>
                {
                    b.HasOne("ReserveSystem.Models.RoomType", "roomType")
                        .WithMany("rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roomType");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomBooking", b =>
                {
                    b.HasOne("ReserveSystem.Models.Booking", "booking")
                        .WithMany("roomBookings")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Room", "room")
                        .WithMany("roomBookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("booking");

                    b.Navigation("room");
                });

            modelBuilder.Entity("ReserveSystem.Models.Staff", b =>
                {
                    b.HasOne("ReserveSystem.Models.Job", "job")
                        .WithMany("staffMembers")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("job");
                });

            modelBuilder.Entity("ReserveSystem.Models.Booking", b =>
                {
                    b.Navigation("roomBookings");
                });

            modelBuilder.Entity("ReserveSystem.Models.Cleaning", b =>
                {
                    b.Navigation("cleaningSchedules");
                });

            modelBuilder.Entity("ReserveSystem.Models.Client", b =>
                {
                    b.Navigation("bookings");

                    b.Navigation("consumptions");
                });

            modelBuilder.Entity("ReserveSystem.Models.ItemRoom", b =>
                {
                    b.Navigation("consumptions");
                });

            modelBuilder.Entity("ReserveSystem.Models.Items", b =>
                {
                    b.Navigation("itemRooms");
                });

            modelBuilder.Entity("ReserveSystem.Models.Job", b =>
                {
                    b.Navigation("staffMembers");
                });

            modelBuilder.Entity("ReserveSystem.Models.Room", b =>
                {
                    b.Navigation("cleanings");

                    b.Navigation("roomBookings");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomBooking", b =>
                {
                    b.Navigation("cleaningSchedules");

                    b.Navigation("itemRooms");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomType", b =>
                {
                    b.Navigation("rooms");
                });

            modelBuilder.Entity("ReserveSystem.Models.Staff", b =>
                {
                    b.Navigation("cleaningSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
