using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;

namespace BookingSystem.Services.Extensions
{
    public static class LocationExtension
    {
        public static IEnumerable<LocationDto> ConvertToLocationDto(this IEnumerable<Location> locations)
        {

            return locations.Select(location => new LocationDto
            {
                Id = location.Id,
                Name = location.Name,
            });
        }


        public static LocationDto ConvertToLocationDto(this Location location)
        {

            return new LocationDto
            {
                Id = location.Id,
                Name = location.Name,
            };
        }
    }
}
