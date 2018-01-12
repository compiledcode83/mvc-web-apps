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

        [Required(ErrorMessage = "This field {0} is requiered !")]
        [MaxLength(50, ErrorMessage = "This field {0} must be {1} characters length!")]
        [Display(Name="Regione")]
        public string Name { get; set; }

        //side one
        public virtual ICollection<City> Cities { get; set; }

    }
}