
namespace BookingSystem.Services.Dto
{
    public class RouteDto
    {
        public int Id { get; set; }

        public int SourceId { get; set; }

        public int DestinationId { get; set; }

        public decimal JourneyTime { get; set; }
        public int Stops { get; set; }

    }
}
