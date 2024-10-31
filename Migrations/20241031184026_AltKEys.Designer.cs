﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WAIGR_Users_Products.Context;

#nullable disable

namespace WAIGR_Users_Products.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241031184026_AltKEys")]
    partial class AltKEys
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("WAIGR_Users_Products.Entities.Producto", b =>
                {
                    b.Property<Guid>("IDproducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaveKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaveSAT")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("PrecioVenta")
                        .HasColumnType("REAL");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IDproducto");

                    b.HasAlternateKey("SKU");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("WAIGR_Users_Products.Entities.User", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("IdUsuario");

                    b.HasAlternateKey("Nombre");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WAIGR_Users_Products.Entities.Venta", b =>
                {
                    b.Property<Guid>("IDVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaVenta")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IDUsuario")
                        .HasColumnType("TEXT");

                    b.Property<float>("IVA")
                        .HasColumnType("REAL");

                    b.Property<float>("Subtotal")
                        .HasColumnType("REAL");

                    b.Property<float>("Total")
                        .HasColumnType("REAL");

                    b.Property<Guid>("UsuarioIdUsuario")
                        .HasColumnType("TEXT");

                    b.HasKey("IDVenta");

                    b.HasIndex("UsuarioIdUsuario");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("WAIGR_Users_Products.Entities.Venta", b =>
                {
                    b.HasOne("WAIGR_Users_Products.Entities.User", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioIdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
