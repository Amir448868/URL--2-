﻿using System.ComponentModel.DataAnnotations;

namespace AcortURL.Models
{
    public class AuthenticationRequestDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
