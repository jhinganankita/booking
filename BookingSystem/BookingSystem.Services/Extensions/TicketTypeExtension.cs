using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;
using System.Net.Sockets;

namespace BookingSystem.Services.Extensions
{
    public static class TicketTypeExtension
    {
        public static IEnumerable<TicketTypeDto> ConvertToTicketTypeDto(this IEnumerable<TicketType> ticketTypes)
        {

            return ticketTypes.Select(ticketType => new TicketTypeDto
            {
                Id = ticketType.Id,
                Name = ticketType.Name,
            });
        }


        public static TicketTypeDto ConvertToTicketTypeDto(this TicketType ticketType)
        {

            return new TicketTypeDto
            {
                Id = ticketType.Id,
                Name = ticketType.Name,
            };
        }
    }
}
