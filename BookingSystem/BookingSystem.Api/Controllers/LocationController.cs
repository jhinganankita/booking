using BookingSystem.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _iLocationService;

        public LocationController(ILogger<LocationController> logger, ILocationService iLocationService)
        {
            _logger = logger;
            _iLocationService = iLocationService;
        }

        [HttpGet]
        [Route("locations")]
        public async Task<IActionResult> Get()
        {
            var result = await _iLocationService.GetAsync();

            if (result.isSuccess)
                return Ok(result.locations);

            return StatusCode(500, "Internal Server Error");

        }

    }
}
