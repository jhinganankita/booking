using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Services.Interface
{
    public interface ITicketTypeService
    {
        Task<(bool isSuccess, IEnumerable<TicketTypeDto> ticketTypeDto, string errorMessage)> GetAsync();
    }
}
