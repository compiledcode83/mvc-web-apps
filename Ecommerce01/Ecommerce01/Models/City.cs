using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce01.Models
{
    public class City
    { 
        //side many of the relation one to many
        //city has a relation one Departament to many Cities
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "This field {0} is requiered !")]
        [MaxLength(50, ErrorMessage = "This field {0} must be {1} characters length!")]
        [Display(Name = "Città")]
        public string Name { get; set; }
        
        //the relation
        [Required(ErrorMessage = "This field {0} is requiered !")]
        public int DepartamentId { get; set; }

        //side one of relation one to many
        public virtual Departament Departament { get; set; }

    }
}