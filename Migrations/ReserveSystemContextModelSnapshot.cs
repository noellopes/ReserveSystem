﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReserveSystem.Data;

#nullable disable

namespace ReserveSystem.Migrations
{
    [DbContext(typeof(ReserveSystemContext))]
    partial class ReserveSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ReserveSystem.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<bool>("Login")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("VARCHAR(9)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR(15)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("ReserveSystem.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("ReserveSystem.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.Property<int>("JobId")
                        .HasColumnType("INTEGER(11)");

                    b.Property<TimeSpan>("LimitHour")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("RoomService");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomServiceBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BookedState")
                        .HasColumnType("bit");

                    b.Property<int?>("ClientFeedback")
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
                        .HasColumnType("INTEGER(11)");

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

                    b.HasIndex("ClientId");

                    b.HasIndex("RoomId");

                    b.HasIndex("RoomServiceId");

                    b.HasIndex("StaffId");

                    b.ToTable("RoomServiceBooking");
                });

            modelBuilder.Entity("ReserveSystem.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("EndShiftTime")
                        .HasColumnType("time");

                    b.Property<bool>("Present")
                        .HasColumnType("bit");

                    b.Property<int>("StaffId")
                        .HasColumnType("INTEGER(11)");

                    b.Property<TimeSpan>("StartShiftTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("ReserveSystem.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DaysOffVacation")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndFunctionsDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("JobId")
                        .HasColumnType("INTEGER(11)");

                    b.Property<string>("StaffEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StaffPhone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartFunctionsDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomService", b =>
                {
                    b.HasOne("ReserveSystem.Models.Job", "Job")
                        .WithMany("RoomServices")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomServiceBooking", b =>
                {
                    b.HasOne("ReserveSystem.Models.Client", "Client")
                        .WithMany("RoomServiceBookings")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Room", "Room")
                        .WithMany("RoomServiceBookings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.RoomService", "RoomService")
                        .WithMany("RoomServiceBookings")
                        .HasForeignKey("RoomServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Staff", "Staff")
                        .WithMany("RoomServiceBookings")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Room");

                    b.Navigation("RoomService");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("ReserveSystem.Models.Schedule", b =>
                {
                    b.HasOne("ReserveSystem.Models.Staff", "Staff")
                        .WithMany("Schedules")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("ReserveSystem.Models.Staff", b =>
                {
                    b.HasOne("ReserveSystem.Models.Job", "Job")
                        .WithMany("Staffs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("ReserveSystem.Models.Client", b =>
                {
                    b.Navigation("RoomServiceBookings");
                });

            modelBuilder.Entity("ReserveSystem.Models.Job", b =>
                {
                    b.Navigation("RoomServices");

                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("ReserveSystem.Models.Room", b =>
                {
                    b.Navigation("RoomServiceBookings");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomService", b =>
                {
                    b.Navigation("RoomServiceBookings");
                });

            modelBuilder.Entity("ReserveSystem.Models.Staff", b =>
                {
                    b.Navigation("RoomServiceBookings");

                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
