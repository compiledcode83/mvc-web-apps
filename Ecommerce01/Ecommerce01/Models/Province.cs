using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace Ecommerce01.Models
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "Questo campo {0} è necessario!")]
        [MaxLength(50, ErrorMessage = "Questo campo {0} deve essere lungo {1} caratteri!")]
        [Display(Name = "Provincia")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Questo campo {0} è necessario!")]
        [MaxLength(2, ErrorMessage = "Questo campo {0} deve essere lungo {1} caratteri!")]
        [Display(Name = "Sigla")]
        public string TwoInitial { get; set; }

        [Display(Name = "Longitudine")]
        public decimal? Longitude { get; set; }

        [Display(Name = "Latitudine")]
        public decimal? Latitude { get; set; }

        //side one
        [Display(Name = "Regione")]
        public int DepartamentId { get; set; }

        ////side one to many
        public virtual ICollection<City> Cities { get; set; }

    }
}