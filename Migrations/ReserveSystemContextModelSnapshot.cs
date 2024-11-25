﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
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
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReserveSystem.Models.Staff", b =>
            modelBuilder.Entity("ReserveSystem.Models.RoomServiceBooking", b =>
                {
                    b.Property<int>("StaffID")
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");
                        .HasColumnType("INTEGER");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffID"));
                    b.Property<bool>("BookedState")
                        .HasColumnType("bit");

                    b.Property<int>("DaysOffVacation")
                        .HasColumnType("int");
                    b.Property<int>("ClientFeedback")
                        .HasColumnType("INTEGER(1)");

                    b.Property<DateTime?>("EndFunctionsDate")
                        .HasColumnType("datetime2");
                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER(11)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");
                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool>("PaymentDone")
                        .HasColumnType("bit");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StaffEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<int>("RoomServiceId")
                        .HasColumnType("INTEGER(11)");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");
                    b.Property<bool>("StaffConfirmation")
                        .HasColumnType("bit");

                    b.Property<string>("StaffPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");
                    b.Property<int>("StaffId")
                        .HasColumnType("INTEGER(11)");

                    b.Property<string>("StaffPhone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");
                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("StartFunctionsDate")
                        .HasColumnType("datetime2");
                    b.Property<decimal>("ValueToPay")
                        .HasColumnType("decimal(8, 2)");

                    b.HasKey("StaffID");
                    b.HasKey("Id");

                    b.ToTable("Staff");
                    b.ToTable("RoomServiceBooking");
                });
#pragma warning restore 612, 618
        }
    }
}
