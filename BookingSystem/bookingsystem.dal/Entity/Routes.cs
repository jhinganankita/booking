using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.dal.Entity
{
    [Table("Routes")]
    public class Routes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Source id is required")]
        public int SourceId { get; set; }

        [Required(ErrorMessage = "Destination id is required")]
        public int DestinationId { get; set; }

        public decimal JourneyTime { get; set; }
        public int Stops { get; set; }

        public Location Source { get; set; }
        public Location Destination { get; set; }
    }
}
