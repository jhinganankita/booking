﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Services.Dto
{
    public class AuthenticateDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Must be between 8 and 15 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
