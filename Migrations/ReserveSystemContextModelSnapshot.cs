﻿// <auto-generated />
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

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReserveSystem.Models.RoomService", b =>
                {
                    b.Property<int>("ID_RoomService")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_RoomService"));

                    b.Property<bool>("Room_Service_Active")
                        .HasColumnType("bit");

                    b.Property<string>("Room_Service_Description")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int>("Room_Service_Limit_Hour")
                        .HasColumnType("int");

                    b.Property<string>("Room_Service_Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("Room_Service_Price")
                        .HasColumnType("float");

                    b.Property<int>("TypeService_ID")
                        .HasColumnType("int");

                    b.HasKey("ID_RoomService");

                    b.HasIndex("TypeService_ID");

                    b.ToTable("RoomService");
                });

            modelBuilder.Entity("ReserveSystem.Models.TypeService", b =>
                {
                    b.Property<int>("TypeService_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeService_ID"));

                    b.Property<string>("TypeService_Decription")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("TypeService_Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("TypeService_ID");

                    b.ToTable("TypeService");
                });

            modelBuilder.Entity("ReserveSystem.Models.RoomService", b =>
                {
                    b.HasOne("ReserveSystem.Models.TypeService", "TypeService")
                        .WithMany()
                        .HasForeignKey("TypeService_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeService");
                });
#pragma warning restore 612, 618
        }
    }
}
