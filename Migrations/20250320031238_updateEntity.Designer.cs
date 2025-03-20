﻿// <auto-generated />
using System;
using ImenikApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImenikApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250320031238_updateEntity")]
    partial class updateEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ImenikApp.Models.Drzava", b =>
                {
                    b.Property<int>("DrzavaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrzavaId"));

                    b.Property<string>("NazivDrzava")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DrzavaId");

                    b.ToTable("Drzava", (string)null);

                    b.HasData(
                        new
                        {
                            DrzavaId = 1,
                            NazivDrzava = "Bosna i Hercegovina"
                        },
                        new
                        {
                            DrzavaId = 2,
                            NazivDrzava = "Hrvatska"
                        },
                        new
                        {
                            DrzavaId = 3,
                            NazivDrzava = "Srbija"
                        },
                        new
                        {
                            DrzavaId = 4,
                            NazivDrzava = "Spanija"
                        },
                        new
                        {
                            DrzavaId = 5,
                            NazivDrzava = "Njemacka"
                        });
                });

            modelBuilder.Entity("ImenikApp.Models.Grad", b =>
                {
                    b.Property<int>("GradId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradId"));

                    b.Property<int>("DrzavaId")
                        .HasColumnType("int");

                    b.Property<string>("NazivGrad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("GradId");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Grad", (string)null);

                    b.HasData(
                        new
                        {
                            GradId = 1,
                            DrzavaId = 1,
                            NazivGrad = "Sarajevo"
                        },
                        new
                        {
                            GradId = 2,
                            DrzavaId = 1,
                            NazivGrad = "Tuzla"
                        },
                        new
                        {
                            GradId = 3,
                            DrzavaId = 1,
                            NazivGrad = "Banja Luka"
                        },
                        new
                        {
                            GradId = 4,
                            DrzavaId = 1,
                            NazivGrad = "Mostar"
                        },
                        new
                        {
                            GradId = 5,
                            DrzavaId = 1,
                            NazivGrad = "Sarajevo"
                        },
                        new
                        {
                            GradId = 6,
                            DrzavaId = 2,
                            NazivGrad = "Zagreb"
                        },
                        new
                        {
                            GradId = 7,
                            DrzavaId = 2,
                            NazivGrad = "Split"
                        },
                        new
                        {
                            GradId = 8,
                            DrzavaId = 2,
                            NazivGrad = "Rijeka"
                        },
                        new
                        {
                            GradId = 9,
                            DrzavaId = 3,
                            NazivGrad = "Beograd"
                        },
                        new
                        {
                            GradId = 10,
                            DrzavaId = 3,
                            NazivGrad = "Nis"
                        },
                        new
                        {
                            GradId = 11,
                            DrzavaId = 3,
                            NazivGrad = "Novi Sad"
                        },
                        new
                        {
                            GradId = 12,
                            DrzavaId = 4,
                            NazivGrad = "Madrid"
                        },
                        new
                        {
                            GradId = 13,
                            DrzavaId = 4,
                            NazivGrad = "Barcelona"
                        },
                        new
                        {
                            GradId = 14,
                            DrzavaId = 5,
                            NazivGrad = "Minhen"
                        },
                        new
                        {
                            GradId = 15,
                            DrzavaId = 5,
                            NazivGrad = "Berlin"
                        },
                        new
                        {
                            GradId = 16,
                            DrzavaId = 5,
                            NazivGrad = "Frankfurt"
                        });
                });

            modelBuilder.Entity("ImenikApp.Models.Osoba", b =>
                {
                    b.Property<int>("OsobaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OsobaId"));

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DatumRodjenja")
                        .HasColumnType("date");

                    b.Property<int>("DrzavaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradId")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OsobaId");

                    b.HasIndex("DrzavaId");

                    b.HasIndex("GradId");

                    b.ToTable("Osobe");
                });

            modelBuilder.Entity("ImenikApp.Models.Grad", b =>
                {
                    b.HasOne("ImenikApp.Models.Drzava", "Drzava")
                        .WithMany("Gradovi")
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Drzava");
                });

            modelBuilder.Entity("ImenikApp.Models.Osoba", b =>
                {
                    b.HasOne("ImenikApp.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ImenikApp.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drzava");

                    b.Navigation("Grad");
                });

            modelBuilder.Entity("ImenikApp.Models.Drzava", b =>
                {
                    b.Navigation("Gradovi");
                });
#pragma warning restore 612, 618
        }
    }
}
