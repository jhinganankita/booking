using BookingSystem.dal.Interface;
using BookingSystem.Services.Dto;
using BookingSystem.Services.Extensions;
using BookingSystem.Services.Interface;

namespace BookingSystem.Services.Implement
{
    internal class RouteService : IRouteService
    {
        readonly IRoutesRepository _routesRepository;
        public RouteService(IRoutesRepository routesRepository)
        {
            _routesRepository = routesRepository;
        }
        public async Task<(bool isSuccess, RouteDto routeDto, string errorMessage)> GetRouteBySourceAndDestinationAsync(int sourceId, int destinationId)
        {
            try
            {
                var route = (await _routesRepository.FindAsync(x => x.SourceId == sourceId && x.DestinationId == destinationId)).First();

                return (true, route.ConvertToRouteDto(), string.Empty);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }
    }
}
