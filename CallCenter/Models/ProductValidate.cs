using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CallCenter.Models
{
    [ModelMetadataType(typeof(ProductValidate))]
    public partial class Product { }
    public class ProductValidate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public double? Price { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        [ValidateNever]
        public virtual Account Customer { get; set; } = null!;
    }
}
