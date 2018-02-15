using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce01.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Questo campo {0} è necessario!")]
        [MaxLength(50, ErrorMessage = "Questo campo {0} deve essere lungo {1} caratteri!")]
        //[Index("Category_CompanyId_Description_Index", 2, IsUnique = true)]
        [Display(Name = "Categoria")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Questo campo {0} è necessario!")]
        [Range(1, double.MaxValue, ErrorMessage = "Devi selezionare un {0}")]
        //[Index("Category_CompanyId_Description_Index", 1, IsUnique = true)]
        [Display(Name = "Azienda")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
    }
}
