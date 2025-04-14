using GulfVillas.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfVillas.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        //this constructor is used to pass the options to the base class and base class is DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        public DbSet<Amenity> Amenities { get; set; }



        //this method is used for seeding data to database without explicitly adding it in DBMS for now 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this will be needed with Identity framework for authentication and authorization
            // base.OnModelCreating(modelBuilder);

            //this data will be added during migration
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Description = "Fusce 11 tincidunt  maximusleosedscelerisquemassa    auctor sit   amet.Donecexmauris,hendreritquis   nibh   ac,efficiturfringilla enim.",
                    ImageURL = "https:/placehold.co/600x400",
                    Occupancy = 4,
                    Price = 200,
                    Sqft = 550,
                },
                new Villa
                {
                    Id = 2,
                    Name = "Premium Pool Villa",
                    Description = "Fusce 11 tinciduntmaximus   leo,   sedscelerisque   massa     auctor sitamet.   Donec  exmauris,    hendrerit quis  nibh      ac,  efficiturfringillaenim.",
                    ImageURL = "https:/placehold.co/600x401",
                    Occupancy = 4,
                    Price = 300,
                    Sqft = 550,
                },
                new Villa
                {
                    Id = 3,
                    Name = "Luxury Pool Villa",
                    Description = "Fusce 11 tinciduntmaximus   leo,   sedscelerisque   massa     auctor sitamet.   Donec  exmauris,    hendrerit quis  nibh      ac,  efficiturfringillaenim.",
                    ImageURL = "https:/placehold.co/600x402",
                    Occupancy = 4,
                    Price = 400,
                    Sqft = 750,
                });


            //for VillaNumber seed
            modelBuilder.Entity<VillaNumber>().HasData(
              new VillaNumber
              {
                  Villa_Number = 101,
                  VillaId = 1,

              },
              new VillaNumber
              {
                  Villa_Number = 102,
                  VillaId = 1,

              },
              new VillaNumber
              {
                  Villa_Number = 103,
                  VillaId = 1,

              },
              new VillaNumber
              {
                  Villa_Number = 104,
                  VillaId = 1,

              },
              new VillaNumber
              {
                  Villa_Number = 201,
                  VillaId = 2,

              },
              new VillaNumber
              {
                  Villa_Number = 202,
                  VillaId = 2,

              },
              new VillaNumber
              {
                  Villa_Number = 203,
                  VillaId = 2,

              },
              new VillaNumber
              {
                  Villa_Number = 301,
                  VillaId = 3,

              },
              new VillaNumber
              {
                  Villa_Number = 302,
                  VillaId = 3,

              });

            modelBuilder.Entity<Amenity>().HasData(
          new Amenity
          {
              Id = 1,
              VillaId = 1,
              Name = "Private Pool"
          }, new Amenity
          {
              Id = 2,
              VillaId = 1,
              Name = "Microwave"
          }, new Amenity
          {
              Id = 3,
              VillaId = 1,
              Name = "Private Balcony"
          }, new Amenity
          {
              Id = 4,
              VillaId = 1,
              Name = "1 king bed and 1 sofa bed"
          },

          new Amenity
          {
              Id = 5,
              VillaId = 2,
              Name = "Private Plunge Pool"
          }, new Amenity
          {
              Id = 6,
              VillaId = 2,
              Name = "Microwave and Mini Refrigerator"
          }, new Amenity
          {
              Id = 7,
              VillaId = 2,
              Name = "Private Balcony"
          }, new Amenity
          {
              Id = 8,
              VillaId = 2,
              Name = "king bed or 2 double beds"
          },

          new Amenity
          {
              Id = 9,
              VillaId = 3,
              Name = "Private Pool"
          }, new Amenity
          {
              Id = 10,
              VillaId = 3,
              Name = "Jacuzzi"
          }, new Amenity
          {
              Id = 11,
              VillaId = 3,
              Name = "Private Balcony"
          });

        }
    }
}
