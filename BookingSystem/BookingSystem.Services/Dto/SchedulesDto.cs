
using BookingSystem.dal.Entity;

namespace BookingSystem.Services.Dto
{
    public class SchedulesDto
    {
        public int Id { get; set; }

        public TicketTypeEnum TicketType { get; set; }

        public string ArrivalTime { get; set; }

        public string DepartureTime { get; set; }

        public decimal JourneyTime { get; set; }
        public int Stops { get; set; }      

        public BusesDto BusDto { get; set; }

        public TrainDto TrainDto { get; set; }

        public PlaneDto PlaneDto { get; set; }
    }
}
