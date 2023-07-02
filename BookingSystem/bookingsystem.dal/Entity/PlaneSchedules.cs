using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.dal.Entity
{
    [Table("PlaneSchedules")]
    public class PlaneSchedules
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Arrival time is required")]
        public string ArrivalTime { get; set; }

        [Required(ErrorMessage = "Departure time is required")]
        public string DepartureTime { get; set; }

        public int RouteId { get; set; }
        public int PlaneId { get; set; }
        public Planes Plane { get; set; }
    }
}
