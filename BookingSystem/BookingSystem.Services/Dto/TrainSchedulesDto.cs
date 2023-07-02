using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.dal.Entity
{
    public class TrainSchedulesDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Arrival time is required")]
        public string ArrivalTime { get; set; }

        [Required(ErrorMessage = "Departure time is required")]
        public string DepartureTime { get; set; }

        public decimal JourneyTime { get; set; }
        public int Stops { get; set; }
        public int TrainId { get; set; }
    }
}
