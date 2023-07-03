using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.dal.Entity
{
    [Table("BusSchedules")]
    public class BusSchedules
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Arrival time is required")]
        public string ArrivalTime { get; set; }

        [Required(ErrorMessage = "Departure time is required")]
        public string DepartureTime { get; set; }
        public int Fare { get; set; }
        public int RouteId { get; set; }
        public int BusId { get; set; }
        public Buses Bus { get; set; }
    }
}
