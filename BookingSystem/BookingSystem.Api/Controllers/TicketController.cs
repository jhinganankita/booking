using BookingSystem.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketTypeService _iTicketTypeService;

        public TicketController(ILogger<TicketController> logger, ITicketTypeService iTicketTypeService)
        {
            _logger = logger;
            _iTicketTypeService = iTicketTypeService;
        }

        [HttpGet]
        [Route("ticketTypes")]
        public async Task<IActionResult> Get()
        {
            var result = await _iTicketTypeService.GetAsync();

            if (result.isSuccess)
                return Ok(result.ticketTypeDto);

            return StatusCode(500, "Internal Server Error");

        }

    }
}
