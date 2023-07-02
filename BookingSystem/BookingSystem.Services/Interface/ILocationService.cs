using BookingSystem.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Services.Interface
{
    public interface ILocationService
    {
        Task<(bool isSuccess, IEnumerable<LocationDto> locations, string errorMessage)> GetAsync();
    }
}
