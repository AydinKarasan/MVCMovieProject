﻿// <auto-generated />
using System;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(MovieProjectContext))]
    [Migration("20220521184754_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DataAccess.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Aciklamasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ImdbPuanı")
                        .HasColumnType("float");

                    b.Property<DateTime?>("VizyonTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("YonetmenId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("YonetmenId");

                    b.ToTable("Filmler");
                });

            modelBuilder.Entity("DataAccess.Entities.FilmTur", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("TurId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("FilmId", "TurId");

                    b.HasIndex("TurId");

                    b.ToTable("FilmTur");
                });

            modelBuilder.Entity("DataAccess.Entities.Tur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Turler");
                });

            modelBuilder.Entity("DataAccess.Entities.Yonetmen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Yonetmen");
                });

            modelBuilder.Entity("DataAccess.Entities.Film", b =>
                {
                    b.HasOne("DataAccess.Entities.Yonetmen", "Yonetmen")
                        .WithMany("Filmler")
                        .HasForeignKey("YonetmenId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Yonetmen");
                });

            modelBuilder.Entity("DataAccess.Entities.FilmTur", b =>
                {
                    b.HasOne("DataAccess.Entities.Film", "Film")
                        .WithMany("FilmTurler")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccess.Entities.Tur", "Tur")
                        .WithMany("FilmTurler")
                        .HasForeignKey("TurId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Tur");
                });

            modelBuilder.Entity("DataAccess.Entities.Film", b =>
                {
                    b.Navigation("FilmTurler");
                });

            modelBuilder.Entity("DataAccess.Entities.Tur", b =>
                {
                    b.Navigation("FilmTurler");
                });

            modelBuilder.Entity("DataAccess.Entities.Yonetmen", b =>
                {
                    b.Navigation("Filmler");
                });
#pragma warning restore 612, 618
        }
    }
}
