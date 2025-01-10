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
    [Migration("20250110005543_CriarTabelaFornecedores")]
    partial class CriarTabelaFornecedores
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuffetPrato", b =>
                {
                    b.Property<int>("BuffetId")
                        .HasColumnType("int");

                    b.Property<int>("PratosPratoId")
                        .HasColumnType("int");

                    b.HasKey("BuffetId", "PratosPratoId");

                    b.HasIndex("PratosPratoId");

                    b.ToTable("BuffetPrato");
                });

            modelBuilder.Entity("ReserveSystem.Models.Buffet", b =>
                {
                    b.Property<int>("BuffetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuffetId"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuffetId");

                    b.ToTable("Buffet");
                });

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

            modelBuilder.Entity("ReserveSystem.Models.Suppliers", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"));

                    b.Property<string>("SupplierAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SupplierEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("SupplierPhone")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("BuffetPrato", b =>
                {
                    b.HasOne("ReserveSystem.Models.Buffet", null)
                        .WithMany()
                        .HasForeignKey("BuffetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReserveSystem.Models.Prato", null)
                        .WithMany()
                        .HasForeignKey("PratosPratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
