using BookingSystem.Services.Dto;
using BookingSystem.dal.Interface;
using BookingSystem.Services.Interface;
using BookingSystem.Services.Extensions;
using Microsoft.Extensions.Logging;
using BookingSystem.dal.Entity;
using BookingSystem.dal.Implement;

namespace BookingSystem.Services.Implement
{
    public class TicketService : ITicketService
    {
        private readonly ITicketsRepository _iTicketsRepository;
        private readonly ILogger<ITicketService> _logger;
        public TicketService(ILogger<ITicketService> logger, ITicketsRepository iTicketsRepository)
        {
            _iTicketsRepository = iTicketsRepository;
            _logger = logger;
        }
        public async Task<(bool isSuccess, TicketsDto ticketsDto, string errorMessage)> AddAsync(TicketsDto ticketsDto)
        {
            try
            {
                _logger.LogInformation("About to convert ticket model to ticket dto");

                var ticket = ticketsDto.ConvertToTicket();
                await _iTicketsRepository.AddAsync(ticket); // add the object into the database
                await _iTicketsRepository.CommitAsync(); // commit once everything is done.

                _logger.LogDebug("Ticket data has been committed into the database.");

                ticketsDto.Id = ticket.Id;
                return (true, ticketsDto, null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} | {ex.StackTrace}");
                return (false, null, ex.Message);
            }
        }


        public async Task<(bool isSuccess, IEnumerable<TicketsDto> ticketsDto, string errorMessage)> GetTicketsByUserId(int id)
        {
            var tickets = await _iTicketsRepository.FindAsync(x => x.UserId == id, x => x.Source, x => x.Destination);
            return (true, tickets.ConvertToTicketsDto(), null);
        }

        public async Task<(bool isSuccess, IEnumerable<TicketsDto> ticketsDto, string errorMessage)> GetUserTickets()
        {
            var tickets = await _iTicketsRepository.GetAllAsync(x => x.Source, x => x.Destination, x=> x.User);
            return (true, tickets.ConvertToTicketsDto(), null);
        }
    }
}
