using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CallCenter.Models
{
    [ModelMetadataType(typeof(ComplaintValidate))]
    public partial class Complaint { }
    public class ComplaintValidate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int? StaffId { get; set; }
        [ValidateNever]
        public virtual Account Staff { get; set; } = null!;
        [ValidateNever]
        public virtual Order Order { get; set; } = null!;
    }
}
