using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;


namespace BookingSystem.Services.Extensions
{
    public static class ScheduleExtension
    {
        public static IEnumerable<SchedulesDto> ConvertToSchedulesDto(this IEnumerable<BusSchedules> busSchedules)
        {
            return busSchedules.Select(s => new SchedulesDto()
            {
                Id = s.Id,
                TicketType = TicketTypeEnum.Bus,
                ArrivalTime = s.ArrivalTime,
                DepartureTime = s.DepartureTime,
                BusDto = s.Bus.ConvertToBusDto(),
            }).ToList();
        }
        public static IEnumerable<SchedulesDto> ConvertToSchedulesDto(this IEnumerable<TrainSchedules> trainSchedules)
        {
            return trainSchedules.Select(s => new SchedulesDto()
            {
                Id = s.Id,
                TicketType = TicketTypeEnum.Bus,
                ArrivalTime = s.ArrivalTime,
                DepartureTime = s.DepartureTime,
                TrainDto = s.Train.ConvertToTrainDto(),
            }).ToList();
        }
        public static IEnumerable<SchedulesDto> ConvertToSchedulesDto(this IEnumerable<PlaneSchedules> planeSchedules)
        {
            return planeSchedules.Select(s => new SchedulesDto()
            {
                Id = s.Id,
                TicketType = TicketTypeEnum.Bus,
                ArrivalTime = s.ArrivalTime,
                DepartureTime = s.DepartureTime,
                PlaneDto = s.Plane.ConvertToPlaneDto(),
            }).ToList();
        }
    }
}
