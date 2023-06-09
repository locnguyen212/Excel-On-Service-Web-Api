﻿using System.ComponentModel.DataAnnotations;

namespace CallCenter.Utils.UtilModels
{
    public class ChangePasswordModel
    {
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
