﻿// <auto-generated />
using System;
using GulfVillas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GulfVillas.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250413181908_AddAmenityToDB")]
    partial class AddAmenityToDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GulfVillas.Domain.Entites.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VillaId");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Private Pool",
                            VillaId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Microwave",
                            VillaId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Private Balcony",
                            VillaId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "1 king bed and 1 sofa bed",
                            VillaId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Private Plunge Pool",
                            VillaId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "Microwave and Mini Refrigerator",
                            VillaId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "Private Balcony",
                            VillaId = 2
                        },
                        new
                        {
                            Id = 8,
                            Name = "king bed or 2 double beds",
                            VillaId = 2
                        },
                        new
                        {
                            Id = 9,
                            Name = "Private Pool",
                            VillaId = 3
                        },
                        new
                        {
                            Id = 10,
                            Name = "Jacuzzi",
                            VillaId = 3
                        },
                        new
                        {
                            Id = 11,
                            Name = "Private Balcony",
                            VillaId = 3
                        });
                });

            modelBuilder.Entity("GulfVillas.Domain.Entites.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fusce 11 tincidunt  maximusleosedscelerisquemassa    auctor sit   amet.Donecexmauris,hendreritquis   nibh   ac,efficiturfringilla enim.",
                            ImageURL = "https:/placehold.co/600x400",
                            Name = "Royal Villa",
                            Occupancy = 4,
                            Price = 200.0,
                            Sqft = 550
                        },
                        new
                        {
                            Id = 2,
                            Description = "Fusce 11 tinciduntmaximus   leo,   sedscelerisque   massa     auctor sitamet.   Donec  exmauris,    hendrerit quis  nibh      ac,  efficiturfringillaenim.",
                            ImageURL = "https:/placehold.co/600x401",
                            Name = "Premium Pool Villa",
                            Occupancy = 4,
                            Price = 300.0,
                            Sqft = 550
                        },
                        new
                        {
                            Id = 3,
                            Description = "Fusce 11 tinciduntmaximus   leo,   sedscelerisque   massa     auctor sitamet.   Donec  exmauris,    hendrerit quis  nibh      ac,  efficiturfringillaenim.",
                            ImageURL = "https:/placehold.co/600x402",
                            Name = "Luxury Pool Villa",
                            Occupancy = 4,
                            Price = 400.0,
                            Sqft = 750
                        });
                });

            modelBuilder.Entity("GulfVillas.Domain.Entites.VillaNumber", b =>
                {
                    b.Property<int>("Villa_Number")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("Villa_Number");

                    b.HasIndex("VillaId");

                    b.ToTable("VillaNumbers");

                    b.HasData(
                        new
                        {
                            Villa_Number = 101,
                            VillaId = 1
                        },
                        new
                        {
                            Villa_Number = 102,
                            VillaId = 1
                        },
                        new
                        {
                            Villa_Number = 103,
                            VillaId = 1
                        },
                        new
                        {
                            Villa_Number = 104,
                            VillaId = 1
                        },
                        new
                        {
                            Villa_Number = 201,
                            VillaId = 2
                        },
                        new
                        {
                            Villa_Number = 202,
                            VillaId = 2
                        },
                        new
                        {
                            Villa_Number = 203,
                            VillaId = 2
                        },
                        new
                        {
                            Villa_Number = 301,
                            VillaId = 3
                        },
                        new
                        {
                            Villa_Number = 302,
                            VillaId = 3
                        });
                });

            modelBuilder.Entity("GulfVillas.Domain.Entites.Amenity", b =>
                {
                    b.HasOne("GulfVillas.Domain.Entites.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });

            modelBuilder.Entity("GulfVillas.Domain.Entites.VillaNumber", b =>
                {
                    b.HasOne("GulfVillas.Domain.Entites.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });
#pragma warning restore 612, 618
        }
    }
}
