using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;

namespace BookingSystem.Services.Extensions
{
    public static class RouteExtension
    {

        public static RouteDto ConvertToRouteDto(this Routes route)
        {

            return new RouteDto
            {
                Id = route.Id,
                SourceId = route.SourceId,
                DestinationId = route.DestinationId,
                JourneyTime = route.JourneyTime,
                Stops = route.Stops,
                SourceName = route.Source.Name,
                DestinationName = route.Destination.Name
            };

        }
    }
}
