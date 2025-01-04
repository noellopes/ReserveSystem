﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    [DbContext(typeof(ReserveSystemContext))]
    [Migration("20250104192809_Initial")]
    partial class Initial
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
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<bool>("Booked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Booking_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Checkin_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Checkout_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<bool>("Payment_Status")
                        .HasColumnType("bit");

                    b.Property<int?>("Room_BookingRoomBookingId")
                        .HasColumnType("int");

                    b.Property<int>("Total_Persons_Number")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("Room_BookingRoomBookingId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("ReserveSystem.Models.Cleaning_Schedule", b =>
                {
                    b.Property<int>("CleaningScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CleaningScheduleId"));

                    b.Property<bool>("CleaningDone")
                        .HasColumnType("bit");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateServices")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomBookingId")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("room_BookingRoomBookingId")
                        .HasColumnType("int");

                    b.HasKey("CleaningScheduleId");

                    b.HasIndex("ClientId");

                    b.HasIndex("StaffId");

                    b.HasIndex("room_BookingRoomBookingId");

                    b.ToTable("Cleaning_Schedule");
                });

            modelBuilder.Entity("ReserveSystem.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("Client_Adress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Client_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Client_Login")
                        .HasColumnType("bit");

                    b.Property<string>("Client_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Client_Nif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Client_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Client_Status")
                        .HasColumnType("bit");

                    b.HasKey("ClientId");

                    b.HasIndex("BookingId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ReserveSystem.Models.Consumptions", b =>
                {
                    b.Property<int>("ConsumptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsumptionId"));

                    b.Property<DateTime>("ConsumedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("QuantityConsumed")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int?>("itemsItemId")
                        .HasColumnType("int");

                    b.HasKey("ConsumptionId");

                    b.HasIndex("RoomId");

                    b.HasIndex("itemsItemId");

                    b.ToTable("Consumptions");
                });

            modelBuilder.Entity("ReserveSystem.Models.Item_Room", b =>
                {
                    b.Property<int>("ItemRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemRoomId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("RoomQuantity")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("itemsItemId")
                        .HasColumnType("int");

                    b.HasKey("ItemRoomId");

                    b.HasIndex("RoomTypeId");

                    b.HasIndex("itemsItemId");

                    b.ToTable("Item_Room");
                });

            modelBuilder.Entity("ReserveSystem.Models.Items", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("QuantityStock")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

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
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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

            modelBuilder.Entity("ReserveSystem.Models.Room_Booking", b =>
                {
                    b.Property<int>("RoomBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomBookingId"));

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("Persons_Number")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("RoomBookingId");

                    b.HasIndex("BookingId");

                    b.HasIndex("RoomId");

                    b.ToTable("Room_Booking");
                });

            modelBuilder.Entity("ReserveSystem.Models.Room_Type", b =>
                {
                    b.Property<int>("RoomTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomTypeId"));

                    b.Property<bool>("AcessibilityRoom")
                        .HasColumnType("bit");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<bool>("HasView")
                        .HasColumnType("bit");

                    b.Property<int>("RoomCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoomTypeId");

                    b.ToTable("Room_Type");
                });

            modelBuilder.Entity("ReserveSystem.Models.Schedules", b =>
                {
                    b.Property<int>("SchedulesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchedulesId"));

                    b.Property<TimeSpan>("EndShiftTime")
                        .HasColumnType("time");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartShiftTime")
                        .HasColumnType("time");

                    b.Property<int>("TypeOfScheduleId")
                        .HasColumnType("int");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("isPrecense")
                        .HasColumnType("bit");

                    b.HasKey("SchedulesId");

                    b.HasIndex("StaffId");

                    b.HasIndex("TypeOfScheduleId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ReserveSystem.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<int>("DaysOfVacationCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndFunctionsDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StaffDateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("StaffDriversLicense")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StaffDriversLicenseExpiringDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StaffEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StaffPassword")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StaffPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartFunctionsDate")
                        .HasColumnType("datetime2");

                    b.HasKey("StaffId");

                    b.HasIndex("JobId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("ReserveSystem.Models.TypeOfSchedule", b =>
                {
                    b.Property<int>("TypeOfScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeOfScheduleId"));

                    b.Property<string>("TypeOfScheduleDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TypeOfScheduleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TypeOfScheduleId");

                    b.ToTable("TypeOfSchedule");
                });

            modelBuilder.Entity("ReserveSystem.Models.Booking", b =>
                {
                    b.HasOne("ReserveSystem.Models.Room_Booking", null)
                        .WithMany("bookings")
                        .HasForeignKey("Room_BookingRoomBookingId");
                });

            modelBuilder.Entity("ReserveSystem.Models.Cleaning_Schedule", b =>
                {
                    b.HasOne("ReserveSystem.Models.Client", "client")
                        .WithMany("cleaningSchedules")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Staff", "staffMembers")
                        .WithMany("cleaningSchedules")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Room_Booking", "room_Booking")
                        .WithMany()
                        .HasForeignKey("room_BookingRoomBookingId");

                    b.Navigation("client");

                    b.Navigation("room_Booking");

                    b.Navigation("staffMembers");
                });

            modelBuilder.Entity("ReserveSystem.Models.Client", b =>
                {
                    b.HasOne("ReserveSystem.Models.Booking", null)
                        .WithMany("clients")
                        .HasForeignKey("BookingId");
                });

            modelBuilder.Entity("ReserveSystem.Models.Consumptions", b =>
                {
                    b.HasOne("ReserveSystem.Models.Room", "room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Items", "items")
                        .WithMany()
                        .HasForeignKey("itemsItemId");

                    b.Navigation("items");

                    b.Navigation("room");
                });

            modelBuilder.Entity("ReserveSystem.Models.Item_Room", b =>
                {
                    b.HasOne("ReserveSystem.Models.Room_Type", "roomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Items", "items")
                        .WithMany()
                        .HasForeignKey("itemsItemId");

                    b.Navigation("items");

                    b.Navigation("roomType");
                });

            modelBuilder.Entity("ReserveSystem.Models.Room", b =>
                {
                    b.HasOne("ReserveSystem.Models.Room_Type", "roomType")
                        .WithMany("rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roomType");
                });

            modelBuilder.Entity("ReserveSystem.Models.Room_Booking", b =>
                {
                    b.HasOne("ReserveSystem.Models.Booking", "booking")
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Room", "room")
                        .WithMany("room_Bookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("booking");

                    b.Navigation("room");
                });

            modelBuilder.Entity("ReserveSystem.Models.Schedules", b =>
                {
                    b.HasOne("ReserveSystem.Models.Staff", "staff")
                        .WithMany("schedules")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.TypeOfSchedule", "typeOfSchedule")
                        .WithMany("schedules")
                        .HasForeignKey("TypeOfScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("staff");

                    b.Navigation("typeOfSchedule");
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
                    b.Navigation("clients");
                });

            modelBuilder.Entity("ReserveSystem.Models.Client", b =>
                {
                    b.Navigation("cleaningSchedules");
                });

            modelBuilder.Entity("ReserveSystem.Models.Job", b =>
                {
                    b.Navigation("staffMembers");
                });

            modelBuilder.Entity("ReserveSystem.Models.Room", b =>
                {
                    b.Navigation("room_Bookings");
                });

            modelBuilder.Entity("ReserveSystem.Models.Room_Booking", b =>
                {
                    b.Navigation("bookings");
                });

            modelBuilder.Entity("ReserveSystem.Models.Room_Type", b =>
                {
                    b.Navigation("rooms");
                });

            modelBuilder.Entity("ReserveSystem.Models.Staff", b =>
                {
                    b.Navigation("cleaningSchedules");

                    b.Navigation("schedules");
                });

            modelBuilder.Entity("ReserveSystem.Models.TypeOfSchedule", b =>
                {
                    b.Navigation("schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
