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

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReserveSystem.Models.ComposicaoPrato", b =>
                {
                    b.Property<int>("ComposicaoPratoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComposicaoPratoID"));

                    b.Property<int>("IngredientID")
                        .HasColumnType("int");

                    b.Property<decimal>("IngredientQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PratoID")
                        .HasColumnType("int");

                    b.HasKey("ComposicaoPratoID");

                    b.HasIndex("IngredientID");

                    b.HasIndex("PratoID");

                    b.ToTable("ComposicaoPrato");
                });

            modelBuilder.Entity("ReserveSystem.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientID"));

                    b.Property<DateTime>("LastModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("int");

                    b.Property<int>("StockMin")
                        .HasColumnType("int");

                    b.Property<string>("UnityMeasure")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("UnityRecipe")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("IngredientID");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("ReserveSystem.Models.Prato", b =>
                {
                    b.Property<int>("PratoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PratoId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(900)
                        .HasColumnType("nvarchar(900)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PratoId");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("ReserveSystem.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"));

                    b.Property<string>("SupplierAddress")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("SupplierEmail")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("SupplierPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierID");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("ReserveSystem.Models.ComposicaoPrato", b =>
                {
                    b.HasOne("ReserveSystem.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Prato", "Prato")
                        .WithMany("ComposicaoPratos")
                        .HasForeignKey("PratoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Prato");
                });

            modelBuilder.Entity("ReserveSystem.Models.Prato", b =>
                {
                    b.Navigation("ComposicaoPratos");
                });
#pragma warning restore 612, 618
        }
    }
}
