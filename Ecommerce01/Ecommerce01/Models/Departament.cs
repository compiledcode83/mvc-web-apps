using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce01.Models
{
    public class Departament
    {
        [Key]
        public int DepartamentId { get; set; }

        [Required(ErrorMessage = "Questo campo {0} è necessario!")]
        [MaxLength(50, ErrorMessage = "Questo campo {0} deve essere lungo {1} caratteri!")]
        [Display(Name="Regione")]
        public string Name { get; set; }

        [Display(Name = "Longitudine")]
        public decimal? Longitude { get; set; }

        [Display(Name = "Latitudine")]
        public decimal? Latitude { get; set; }

        //side one to many
        public virtual ICollection<Province> Provinces { get; set; }
    }
}