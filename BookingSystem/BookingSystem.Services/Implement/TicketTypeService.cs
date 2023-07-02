using BookingSystem.Services.Dto;
using BookingSystem.dal;
using BookingSystem.dal.Interface;
using BookingSystem.Services.Interface;
using BookingSystem.Services.Extensions;
using BookingSystem.dal.Entity;

namespace BookingSystem.Services.Implement
{
    public class TicketTypeService : ITicketTypeService
    {
        readonly ITicketTypeRepository _ticketTypeRepository;
        public TicketTypeService(ITicketTypeRepository ticketTypeRepository)
        {
            _ticketTypeRepository = ticketTypeRepository;
        }
        public async Task<(bool isSuccess, IEnumerable<TicketTypeDto> ticketTypeDto, string errorMessage)> GetAsync()
        {

            var ticketTypes = await _ticketTypeRepository.GetAllAsync();

            return (true, ticketTypes.ConvertToTicketTypeDto(), string.Empty);
        }
    }
}
