using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.dal.Entity
{
    [Table("Tickets")]
    public class Tickets
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        [Required]
        public int TicketType { get; set; }

        [Required]
        public int SourceId { get; set; }

        public Location Source { get; set; }

        public Location Destination { get; set; }

        [Required]
        public int DestinationId { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public int TotalPassengers { get; set; }
        [Required]
        public int Adult { get; set; }
        public int Children { get; set; }

        public DateTime ReturnDate { get; set; }

        public int UserId { get; set; }     // Foreign key property
        public Users User { get; set; }     // Navigation property

       

    }
}
