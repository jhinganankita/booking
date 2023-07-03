using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;

namespace BookingSystem.Services.Interface
{
    public interface ITicketService
    {
        Task<(bool isSuccess, TicketsDto ticketsDto, string errorMessage)> AddAsync(TicketsDto ticketsDto);
        Task<(bool isSuccess, IEnumerable<TicketsDto> ticketsDto, string errorMessage)> GetTicketsByUserId(int id);
        Task<(bool isSuccess, IEnumerable<TicketsDto> ticketsDto, string errorMessage)> GetUserTickets();
    }
}
