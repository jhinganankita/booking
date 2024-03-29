﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.dal.Entity
{
    [Table("Location")]
    public class Location
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
