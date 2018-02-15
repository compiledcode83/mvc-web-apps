using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce01.Models
{
    public class Tax
    {
        [Key]
        public int TaxId { get; set; }

        [Required(ErrorMessage = "Questo campo {0} è necessario!")]
        [MaxLength(50, ErrorMessage = "Questo campo {0} deve essere lungo {1} caratteri!")]
        //[Index("Tax_CompanyId_Description_Index", 2, IsUnique = true)]
        [Display(Name = "Tassa")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Questo campo {0} è necessario!")]
        [DisplayFormat(ApplyFormatInEditMode = false,
        ConvertEmptyStringToNull = false, DataFormatString = "{0:P2}")]
        [Display(Name = "Aliquota")]
        public decimal Rate { get; set; }
        //[DisplayFormat(DataFormatString = "{0:N0}%", ApplyFormatInEditMode = true)]


        [Required(ErrorMessage = "Questo campo {0} è necessario")]
        [Range(1, double.MaxValue, ErrorMessage = "Devi selezzionare una {0}")]
        //[Index("Tax_CompanyId_Description_Index", 1, IsUnique = true)]
        [Display(Name = "Azienda")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
    }
}

//[DisplayFormat(ApplyFormatInEditMode = true,
//                       ConvertEmptyStringToNull = false,
//                       DataFormatString = "{0:P2}",
//                       NullDisplayText = "State tax amount is not provided.")]
//[Required(AllowEmptyStrings = false,
//                  ErrorMessage = null,
//                  ErrorMessageResourceName = "FieldRequired",
//                  ErrorMessageResourceType = typeof(SysMsg))]
//public decimal StateTaxPct { get; set; }