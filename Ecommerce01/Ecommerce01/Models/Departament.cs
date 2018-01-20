using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce01.Models
{
    public class Departament
    {
        [Key]
        public int DepartamentId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} must be maximum {1} characters length")]
        [Display(Name = "Regione")]
        [Index("Departament_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:N6}", ApplyFormatInEditMode = true)]
        [Range(1, double.MaxValue, ErrorMessage = "Entrare un valore {0} fra {1} e {2}")]
        [Display(Name = "Latitudine")]
        public decimal? Latitud { get; set; }


        [DisplayFormat(DataFormatString = "{0:N6}", ApplyFormatInEditMode = true)]
        [Range(1, double.MaxValue, ErrorMessage = "Entrare un valore {0} fra {1} e {2}")]
        [Display(Name = "Longitudine")]
        public decimal? Longitud { get; set; }


        //side one to many
        public virtual ICollection<Province> Provinces { get; set; }
    }
}