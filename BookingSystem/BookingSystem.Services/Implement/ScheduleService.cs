using BookingSystem.Services.Dto;
using BookingSystem.dal.Interface;
using BookingSystem.Services.Interface;
using BookingSystem.Services.Extensions;


namespace BookingSystem.Services.Implement
{
    public class ScheduleService : IScheduleService
    {
        readonly IBusSchedulesRepository _iBusScheduleRepository;
        readonly ITrainSchedulesRepository _iTrainScheduleRepository;
        readonly IPlaneSchedulesRepository _iPlaneScheduleRepository;
        readonly IRouteService _iRouteService;
        public ScheduleService(IRouteService iRouteService, IBusSchedulesRepository iBusScheduleRepository,
            ITrainSchedulesRepository iTrainScheduleRepository, IPlaneSchedulesRepository iPlaneScheduleRepository)
        {
            _iBusScheduleRepository = iBusScheduleRepository;
            _iTrainScheduleRepository = iTrainScheduleRepository;
            _iPlaneScheduleRepository = iPlaneScheduleRepository;
            _iRouteService = iRouteService;
        }
        public async Task<(bool isSuccess, IEnumerable<SchedulesDto> schedules, string errorMessage)> GetAsync(ScheduleRequestDto scheduleRequest)
        {
            try
            {
                var route = await _iRouteService.GetRouteBySourceAndDestinationAsync(scheduleRequest.SourceId, scheduleRequest.DestinationId);
                if (!route.isSuccess)
                    return (false, null, route.errorMessage);

                IEnumerable<SchedulesDto> schedules = new List<SchedulesDto>();

                switch (scheduleRequest.TicketType)
                {

                    case TicketTypeEnum.Train:
                        var trainSchedule = await _iTrainScheduleRepository.FindAsync(x => x.RouteId == route.routeDto.Id, x => x.Train);
                        schedules = trainSchedule.ConvertToSchedulesDto(route.routeDto, scheduleRequest.DepartureDate);
                        break;
                    case TicketTypeEnum.Plane:
                        var planeSchedule = await _iPlaneScheduleRepository.FindAsync(x => x.RouteId == route.routeDto.Id, x => x.Plane);
                        schedules = planeSchedule.ConvertToSchedulesDto(route.routeDto, scheduleRequest.DepartureDate);
                        break;

                    case TicketTypeEnum.Bus:
                    default:
                        var busSchedule = await _iBusScheduleRepository.FindAsync(x => x.RouteId == route.routeDto.Id, x => x.Bus);
                        schedules = busSchedule.ConvertToSchedulesDto(route.routeDto, scheduleRequest.DepartureDate);
                        break;
                }

                return (true, schedules, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }
    }
}
