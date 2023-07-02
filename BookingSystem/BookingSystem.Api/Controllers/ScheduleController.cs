using BookingSystem.Services.Dto;
using BookingSystem.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly IScheduleService _iScheduleService;

        public ScheduleController(ILogger<ScheduleController> logger, IScheduleService iScheduleService)
        {
            _logger = logger;
            _iScheduleService = iScheduleService;
        }

        [HttpPost]
        [Route("schedules")]
        public async Task<IActionResult> Get([FromBody] ScheduleRequestDto scheduleRequest)
        {
            var result = await _iScheduleService.GetAsync(scheduleRequest);

            if (result.isSuccess)
                return Ok(result.schedules);

            return StatusCode(500, "Internal Server Error");

        }

    }
}
