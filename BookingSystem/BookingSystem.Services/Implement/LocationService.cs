using BookingSystem.Services.Dto;
using BookingSystem.dal;
using BookingSystem.dal.Interface;
using BookingSystem.Services.Interface;
using BookingSystem.Services.Extensions;
using BookingSystem.dal.Entity;

namespace BookingSystem.Services.Implement
{
    public class LocationService : ILocationService
    {
        readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<(bool isSuccess, IEnumerable<LocationDto> locations, string errorMessage)> GetAsync()
        {
            try
            {
                var locations = await _locationRepository.GetAllAsync();

                return (true, locations.ConvertToLocationDto(), string.Empty);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }
    }
}
