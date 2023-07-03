using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Services.Dto
{
    public class TicketXmlResponseDto
    {
        public int TicketId { get; set; }

        public string UserName { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public DateTime DepartureDate { get; set; }

        public int TotalPassengers { get; set; }

        public int Adult { get; set; }

        public int children { get; set; }

    }
}
