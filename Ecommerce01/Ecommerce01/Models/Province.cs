using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Index("Province_Name_Index", 2, IsUnique = true)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Questo campo {0} è necessario!")]
        [StringLength(5, MinimumLength = 5)]
        [Display(Name = "CAP")]
        public string SigCap { get; set; }

        //[Required(ErrorMessage = "Questo campo {0} è necessario!")]
        [Required(ErrorMessage = "Questo campo {0} è necessario!"), StringLength(2, MinimumLength = 2)]
        [MaxLength(2, ErrorMessage = "Questo campo {0} deve essere lungo {1} caratteri!")]
        [Display(Name = "Sigla")]
        public string TwoInitial { get; set; }

        [DisplayFormat(DataFormatString = "{0:N6}", ApplyFormatInEditMode = true)]
        [Range(1, double.MaxValue, ErrorMessage = "Entrare un valore {0} fra {1} e {2}")]
        [Display(Name = "Latitudine")]
        public decimal? Latitud { get; set; }


        [DisplayFormat(DataFormatString = "{0:N6}", ApplyFormatInEditMode = true)]
        [Range(1, double.MaxValue, ErrorMessage = "Entrare un valore {0} fra {1} e {2}")]
        [Display(Name = "Longitudine")]
        public decimal? Longitud { get; set; }


        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "Regione")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        [Index("Province_Name_Index", 1, IsUnique = true)]
        public int DepartamentId { get; set; }


        public virtual Departament Departament { get; set; }
        //////side one to many
        //public virtual ICollection<City> Cities { get; set; }
    }
}
