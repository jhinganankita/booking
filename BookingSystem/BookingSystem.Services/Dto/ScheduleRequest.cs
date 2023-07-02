
namespace BookingSystem.Services.Dto
{
    public class ScheduleRequestDto
    {
        public int SourceId { get; set; }
        public int DestinationId { get; set; }
        public TicketTypeEnum TicketType { get; set; }
        
    }
}
