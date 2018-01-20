using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace Ecommerce01.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Required(ErrorMessage = "Questo campo {0} è necessario!")]
        [MaxLength(50, ErrorMessage = "Questo campo {0} deve essere lungo {1} caratteri!")]
        [Display(Name = "Città")]
        public string Name { get; set; }

        //public DbGeography Location { get; set; }
        [Display(Name = "Longitudine")]
        public decimal? Longitude { get; set; }

        [Display(Name = "Latitudine")]
        public decimal? Latitude { get; set; }

        [Display(Name = "Provincia")]
        public int ProvinceId { get; set; }
    }
}