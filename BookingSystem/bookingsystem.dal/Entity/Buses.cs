using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.dal.Entity
{
    [Table("Buses")]
    public class Buses
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(250, ErrorMessage = "Name cannot be greater than 250 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        public decimal Capacity { get; set; }
        public decimal Fare { get; set; }
    }
}
