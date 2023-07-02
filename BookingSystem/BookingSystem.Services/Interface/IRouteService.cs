using BookingSystem.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Services.Interface
{
    public interface IRouteService
    {
        Task<(bool isSuccess, RouteDto routeDto, string errorMessage)> GetRouteBySourceAndDestinationAsync(int sourceId, int destinationId);
    }
}
