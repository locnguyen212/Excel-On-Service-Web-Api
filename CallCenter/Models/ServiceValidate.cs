using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CallCenter.Models
{
    [ModelMetadataType(typeof(ServiceValidate))]
    public partial class Service { }
    public class ServiceValidate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public double? Price { get; set; }
    }
}
