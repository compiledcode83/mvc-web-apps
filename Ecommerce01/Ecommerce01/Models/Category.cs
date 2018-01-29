using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Settore")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Questo campo {0} è necessario!")]
        [Display(Name = "Azienda")]
        [Range(1, double.MaxValue, ErrorMessage = "Selezionare  un {0}")]
        //[Index("Category_CompanyId_Description_Index", 1, IsUnique = true)]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        //public virtual ICollection<Product> Products { get; set; }

    }
}