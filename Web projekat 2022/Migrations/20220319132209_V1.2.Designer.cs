﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB_backend.Models;

namespace WEB_backend.Migrations
{
    [DbContext(typeof(PozoristeContext))]
    [Migration("20220319132209_V1.2")]
    partial class V12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WEB_backend.Models.Izvedba", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Datum")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Datum");

                    b.Property<int>("Karte")
                        .HasColumnType("int")
                        .HasColumnName("Karte");

                    b.Property<int?>("PredstavaID")
                        .HasColumnType("int");

                    b.Property<int?>("SalaID")
                        .HasColumnType("int");

                    b.Property<string>("Vreme")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Vreme");

                    b.HasKey("ID");

                    b.HasIndex("PredstavaID");

                    b.HasIndex("SalaID");

                    b.ToTable("Izvedba");
                });

            modelBuilder.Entity("WEB_backend.Models.Pozoriste", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("ID");

                    b.ToTable("Pozoriste");
                });

            modelBuilder.Entity("WEB_backend.Models.Predstava", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.Property<string>("Ogranicenje")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ogranicenje");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Opis");

                    b.Property<int?>("PozID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PozID");

                    b.ToTable("Predstava");
                });

            modelBuilder.Entity("WEB_backend.Models.Sala", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<int>("Broj")
                        .HasColumnType("int")
                        .HasColumnName("Broj");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int")
                        .HasColumnName("Kapacitet");

                    b.Property<int?>("PozID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PozID");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("WEB_backend.Models.Izvedba", b =>
                {
                    b.HasOne("WEB_backend.Models.Predstava", "Predstava")
                        .WithMany("Izvedbe")
                        .HasForeignKey("PredstavaID");

                    b.HasOne("WEB_backend.Models.Sala", "Sala")
                        .WithMany("Izvedbe")
                        .HasForeignKey("SalaID");

                    b.Navigation("Predstava");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("WEB_backend.Models.Predstava", b =>
                {
                    b.HasOne("WEB_backend.Models.Pozoriste", "Poz")
                        .WithMany("Predstave")
                        .HasForeignKey("PozID");

                    b.Navigation("Poz");
                });

            modelBuilder.Entity("WEB_backend.Models.Sala", b =>
                {
                    b.HasOne("WEB_backend.Models.Pozoriste", "Poz")
                        .WithMany("Sale")
                        .HasForeignKey("PozID");

                    b.Navigation("Poz");
                });

            modelBuilder.Entity("WEB_backend.Models.Pozoriste", b =>
                {
                    b.Navigation("Predstave");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("WEB_backend.Models.Predstava", b =>
                {
                    b.Navigation("Izvedbe");
                });

            modelBuilder.Entity("WEB_backend.Models.Sala", b =>
                {
                    b.Navigation("Izvedbe");
                });
#pragma warning restore 612, 618
        }
    }
}
