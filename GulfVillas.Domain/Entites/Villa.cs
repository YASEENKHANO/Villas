﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfVillas.Domain.Entites
{
    public class Villa
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Price per night")]
        [Range(0,2000)]
        
        public double Price { get; set; }
        public int Sqft { get; set; }

        [Range(0,10)]
        public int Occupancy  { get; set; }

        [NotMapped] //used when we do not want to add this property to Database
        public IFormFile? Image { get; set; }

        [Display(Name = "Image URL")]
        public string? ImageURL { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ValidateNever]
        public IEnumerable<Amenity> VillaAmenity { get; set; }

    }
}
