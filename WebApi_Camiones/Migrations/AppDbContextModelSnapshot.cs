﻿// <auto-generated />
using System;
using Api_Camiones.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApi_Camiones.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi_Camiones.Datos.Models.Camion_Ruta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CamionId")
                        .HasColumnType("int");

                    b.Property<int>("IdRuta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CamionId");

                    b.HasIndex("IdRuta");

                    b.ToTable("camion_Rutas");
                });

            modelBuilder.Entity("WebApi_Camiones.Datos.Models.Camionero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido_Materno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Apellido_Paterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero_telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("camioneros");
                });

            modelBuilder.Entity("WebApi_Camiones.Datos.Models.Camionero_Camiones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CamionId")
                        .HasColumnType("int");

                    b.Property<int>("CamioneroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CamionId");

                    b.HasIndex("CamioneroId");

                    b.ToTable("camionero_Camiones");
                });

            modelBuilder.Entity("WebApi_Camiones.Datos.Models.Camiones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placas")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("camiones");
                });

            modelBuilder.Entity("WebApi_Camiones.Datos.Models.Ruta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad_estimada")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad_maxima")
                        .HasColumnType("int");

                    b.Property<DateTime>("Hora_llegada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Hora_salida")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("rutas");
                });

            modelBuilder.Entity("WebApi_Camiones.Datos.Models.Camion_Ruta", b =>
                {
                    b.HasOne("WebApi_Camiones.Datos.Models.Camiones", "Camion")
                        .WithMany()
                        .HasForeignKey("CamionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_Camiones.Datos.Models.Ruta", "ruta")
                        .WithMany("Camion_Ruta")
                        .HasForeignKey("IdRuta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camion");

                    b.Navigation("ruta");
                });

            modelBuilder.Entity("WebApi_Camiones.Datos.Models.Camionero_Camiones", b =>
                {
                    b.HasOne("WebApi_Camiones.Datos.Models.Camiones", "Camion")
                        .WithMany("Camionero_Camion")
                        .HasForeignKey("CamionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi_Camiones.Datos.Models.Camionero", "Camionero")
                        .WithMany("Camionero_Camion")
                        .HasForeignKey("CamioneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camion");

                    b.Navigation("Camionero");
                });

            modelBuilder.Entity("WebApi_Camiones.Datos.Models.Camionero", b =>
                {
                    b.Navigation("Camionero_Camion");
                });

            modelBuilder.Entity("WebApi_Camiones.Datos.Models.Camiones", b =>
                {
                    b.Navigation("Camionero_Camion");
                });

            modelBuilder.Entity("WebApi_Camiones.Datos.Models.Ruta", b =>
                {
                    b.Navigation("Camion_Ruta");
                });
#pragma warning restore 612, 618
        }
    }
}
