using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CallCenter.Models
{
    [ModelMetadataType(typeof(OrderClientValidate))]
    public partial class OrderClient { }
    public class OrderClientValidate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int? StaffId { get; set; }
        [Required]
        public int? OrderId { get; set; }
        [ValidateNever]
        public virtual Account Staff { get; set; } = null!;
        [ValidateNever]
        public virtual Order Order { get; set; } = null!;
    }
}
