using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CallCenter.Models
{
    [ModelMetadataType(typeof(ProductClientValidate))]
    public partial class ProductClient { }
    public class ProductClientValidate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int? ClientId { get; set; }
        [Required]
        public int? ProductId { get; set; }
        [ValidateNever]
        public virtual Product Product { get; set; } = null!;
        [ValidateNever]
        public virtual Client Client { get; set; } = null!;
    }
}
