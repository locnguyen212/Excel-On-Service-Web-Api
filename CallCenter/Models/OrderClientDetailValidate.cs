using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CallCenter.Models
{
    [ModelMetadataType(typeof(OrderClientDetailValidate))]
    public partial class OrderClientDetail { }
    public class OrderClientDetailValidate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int? OrderClientId { get; set; }
        [Required]
        public int? ProductId { get; set; }
        [ValidateNever]
        public virtual Product Product { get; set; } = null!;
        [ValidateNever]
        public virtual OrderClient OrderClient { get; set; } = null!;
    }
}
