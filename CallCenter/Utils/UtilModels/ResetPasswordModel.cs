﻿using System.ComponentModel.DataAnnotations;

namespace CallCenter.Utils.UtilModels
{
    public class ResetPasswordModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ResetPasswordToken { get; set; }
    }
}
