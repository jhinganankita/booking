using BookingSystem.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.dal.Entity
{
    public class TicketsDto
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
        [Required]
        public int TotalPassengers { get; set; }
        [Required]
        public int Adult { get; set; }
        public int Children { get; set; }

        public DateTime? ReturnDate { get; set; }
        public UserDto? User { get; set; }

        public string SourceName { get; set; }

        public string DestinationName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string TicketTypeName { get; set; }


    }
}
