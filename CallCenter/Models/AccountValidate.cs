using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CallCenter.Models
{
    [ModelMetadataType(typeof(AccountValidate))]
    public partial class Account { }
    public class AccountValidate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(40, MinimumLength = 9)]
        public string? Email { get; set; }
        [Phone]
        [Required]
        public string? Phone { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string? Role { get; set; }
        [ValidateNever]
        public virtual Department Department { get; set; } = null!;
    }
}
