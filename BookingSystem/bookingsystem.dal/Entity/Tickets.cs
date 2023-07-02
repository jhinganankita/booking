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
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int TicketType { get; set; }

        [Required]
        public int SourceId { get; set; }

        [Required]
        public int DestinationId { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }
        
        public DateTime ReturnDate { get; set; }

    }
}
