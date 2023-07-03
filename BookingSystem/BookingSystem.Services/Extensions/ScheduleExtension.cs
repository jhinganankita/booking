using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;
using static System.Formats.Asn1.AsnWriter;


namespace BookingSystem.Services.Extensions
{
    public static class ScheduleExtension
    {
        public static IEnumerable<SchedulesDto> ConvertToSchedulesDto(this IEnumerable<BusSchedules> busSchedules, RouteDto routeDto, DateTime departureDate)
        {
            return busSchedules.Select(s => new SchedulesDto()
            {
                Id = s.Id,
                TicketType = TicketTypeEnum.Bus,
                ArrivalTime = s.ArrivalTime,
                DepartureTime = s.DepartureTime,
                BusDto = s.Bus?.ConvertToBusDto(),
                SourceId = routeDto.SourceId,
                DestinationId = routeDto.DestinationId,
                SourceName = routeDto.SourceName,
                DestinationName = routeDto.DestinationName,
                DepartureDate = departureDate,
                Fare= s.Fare,
                Stops = routeDto.Stops,
                JourneyTime = routeDto.JourneyTime
            }).ToList();
        }
        public static IEnumerable<SchedulesDto> ConvertToSchedulesDto(this IEnumerable<TrainSchedules> trainSchedules, RouteDto routeDto, DateTime departureDate)
        {
            return trainSchedules.Select(s => new SchedulesDto()
            {
                Id = s.Id,
                TicketType = TicketTypeEnum.Train,
                ArrivalTime = s.ArrivalTime,
                DepartureTime = s.DepartureTime,
                TrainDto = s.Train.ConvertToTrainDto(),
                SourceId = routeDto.SourceId,
                DestinationId = routeDto.DestinationId,
                SourceName = routeDto.SourceName,
                DestinationName = routeDto.DestinationName,
                DepartureDate = departureDate,
                Fare = s.Fare,
                Stops = routeDto.Stops,
                JourneyTime = routeDto.JourneyTime
            }).ToList();
        }
        public static IEnumerable<SchedulesDto> ConvertToSchedulesDto(this IEnumerable<PlaneSchedules> planeSchedules, RouteDto routeDto, DateTime departureDate)
        {
            return planeSchedules.Select(s => new SchedulesDto()
            {
                Id = s.Id,
                TicketType = TicketTypeEnum.Plane,
                ArrivalTime = s.ArrivalTime,
                DepartureTime = s.DepartureTime,
                PlaneDto = s.Plane.ConvertToPlaneDto(),
                SourceId = routeDto.SourceId,
                DestinationId = routeDto.DestinationId,
                SourceName = routeDto.SourceName,
                DestinationName = routeDto.DestinationName,
                DepartureDate = departureDate,
                Fare = s.Fare,
                Stops = routeDto.Stops,
                JourneyTime = routeDto.JourneyTime
            }).ToList();
        }
    }
}
