using System.ComponentModel.DataAnnotations;

namespace CallCenter.Utils.UtilModels
{
    public class EmailConfirmModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
