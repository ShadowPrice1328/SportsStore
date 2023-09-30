using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Product
    {
        public long? ProductId {get; set;}
        [Required(ErrorMessage = "Please enter a product Name")]
        public string Name {get; set;} = string.Empty;

        [Required(ErrorMessage = "Please enter a decription")]
        public string Description {get; set;} = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price {get; set;}

        [Required(ErrorMessage = "PLease specify a category")]
        public string Category {get; set;} = string.Empty;
    }
}