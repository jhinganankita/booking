using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;
using BookingSystem.Services.Implement;
using BookingSystem.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _iUserService;
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger, IUserService iUserService) {
            _iUserService = iUserService;
            _logger = logger;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Get() { 
            var result =  await _iUserService.GetAsync();

            if (result.isSuccess)
                return Ok(result.users);

            return StatusCode(500, "Internal Server Error");
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> Add([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                var errorList = ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();
                _logger.LogError("Error: Invalid user");
                return BadRequest($"Invalid user:  {String.Join(" , ", errorList)}");
            }

            var result = await _iUserService.AddAsync(user);
            if (result.isSuccess)
                return Ok(result.user);

            return BadRequest(result.errorMessage);
        }

        [HttpPost]
        [Route("users/authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateDto user)
        {
            var result = await _iUserService.Authenticate(user);

            if (result.isSuccess)
                return Ok(result.user);

            return StatusCode(500, "Internal Server Error");
        }
    }
}
