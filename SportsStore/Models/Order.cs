using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID {get; set;}

        [BindNever]
        public ICollection<CartLine> CartLines {get; set;} = new List<CartLine>();

        [Required(ErrorMessage = "Please enter a Name")]
        public string? Name {get; set;}

        [Required(ErrorMessage = "Please enter a City name")]
        public string? City {get; set;}

        [Required(ErrorMessage = "Please enter the first Address line")]
        public string? Line1 {get; set;}   
        public string? Line2 {get; set;}   
        public string? Line3 {get; set;}   

        [Required(ErrorMessage = "Please enter your Country name")]
        public string? Country {get; set;}

        public string? Zip {get; set;}
        public bool GiftWrap {get; set;}
        [BindNever]
        public bool Shipped {get; set;}
    }
}