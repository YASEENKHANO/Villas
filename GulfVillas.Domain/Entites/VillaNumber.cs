using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulfVillas.Domain.Entites
{
    public class VillaNumber
    {
        //this annotation means that the property is the primary key, without default identity column
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Villa Number")]
        public int Villa_Number { get; set; }

        [ForeignKey("Villa")]
        public int VillaId { get; set; }

        [ValidateNever]
        public Villa Villa { get; set; }

        [DisplayName("Special Details")]
        public string? SpecialDetails { get; set; }
    }
}
