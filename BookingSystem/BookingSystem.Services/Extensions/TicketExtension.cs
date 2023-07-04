using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;
using System;
using System.Net.Sockets;

namespace BookingSystem.Services.Extensions
{
    public static class TicketExtension
    {
        public static Tickets ConvertToTicket(this TicketsDto ticketsDto)
        {
            Tickets ticket = new Tickets();
            ticket.UserId = ticketsDto.UserId;
            ticket.SourceId = ticketsDto.SourceId;
            ticket.DestinationId = ticketsDto.DestinationId;
            ticket.DepartureDate = ticketsDto.DepartureDate;
            ticket.TicketType = ticketsDto.TicketType;
            ticket.TotalPassengers = ticketsDto.TotalPassengers;
            ticket.Adult = ticketsDto.Adult;
            ticket.Children = ticketsDto.Children;

            return ticket;
        }


        public static TicketsDto ConvertToTicketDto(this Tickets ticket)
        {
            return new TicketsDto
            {
                Id = ticket.Id,
                UserId = ticket.UserId,
                SourceId = ticket.SourceId,
                DestinationId = ticket.DestinationId,
                DepartureDate = ticket.DepartureDate,
                TicketType = ticket.TicketType,
                TotalPassengers = ticket.TotalPassengers,
                Adult = ticket.Adult,
                Children = ticket.Children
            };
        }

        public static IEnumerable<TicketsDto> ConvertToTicketsDto(this IEnumerable<Tickets> tickets)
        {
            return tickets.Select(ticket => new TicketsDto
            {
                Id = ticket.Id,
                UserId = ticket.UserId,
                SourceId = ticket.SourceId,
                DestinationId = ticket.DestinationId,
                DepartureDate = ticket.DepartureDate,
                TicketType = ticket.TicketType,
                TicketTypeName = Enum.GetName(typeof(TicketTypeEnum), ticket.TicketType),
                TotalPassengers = ticket.TotalPassengers,
                Adult = ticket.Adult,
                Children = ticket.Children,
                SourceName = ticket.Source.Name,
                DestinationName = ticket.Destination.Name,
                FirstName = ticket.User?.FirstName,
                LastName = ticket.User?.LastName,
                Username = ticket.User?.Username,

            });
        }
    }
}

