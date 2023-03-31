using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CallCenter.Models
{
    [ModelMetadataType(typeof(DepartmentValidate))]
    public partial class Department { }
    public class DepartmentValidate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string? Name { get; set; }
    }
}
