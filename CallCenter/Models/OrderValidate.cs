using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CallCenter.Models
{
    [ModelMetadataType(typeof(OrderValidate))]
    public partial class Order { }
    public class OrderValidate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Total price must be a positive number")]
        public double? TotalPrice { get; set; }
        [Required]
        public int? Duration { get; set; }
        [Required]
        public string? Invoice { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        [Required]
        public int? ServiceId { get; set; }
        [ValidateNever]
        public virtual Account Staff { get; set; } = null!;
        [ValidateNever]
        public virtual Account Customer { get; set; } = null!;
        [ValidateNever]
        public virtual Service Service { get; set; } = null!;
    }
}
