using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;
using BookingSystem.Services.Implement;
using BookingSystem.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

namespace BookingSystem.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketTypeService _iTicketTypeService;
        private readonly ITicketService _iTicketService;
        private readonly IUserService _iUserService;

        public TicketController(ILogger<TicketController> logger, ITicketTypeService iTicketTypeService, ITicketService iTicketService, IUserService iUserService)
        {
            _logger = logger;
            _iTicketTypeService = iTicketTypeService;
            _iTicketService = iTicketService;
            _iUserService = iUserService;
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

        [HttpPost]
        [Route("tickets")]
        public async Task<IActionResult> Add([FromBody] TicketsDto ticket)
        {
            if (!ModelState.IsValid)
            {
                var errorList = ModelState.Values.SelectMany(m => m.Errors)
                                 .Select(e => e.ErrorMessage)
                                 .ToList();
                _logger.LogError("Error: Invalid user");
                return BadRequest($"Invalid user:  {String.Join(" , ", errorList)}");
            }

            var result = await _iTicketService.AddAsync(ticket);
            if (result.isSuccess)
                return Ok(result.ticketsDto);

            return BadRequest(result.errorMessage);
        }



        [HttpGet]
        [Route("tickets")]
        public async Task<IActionResult> GetTickets([FromQuery] int userId)
        
        
        {
            var result = await _iTicketService.GetTicketsByUserId(userId);

            if (result.isSuccess)
                return Ok(result.ticketsDto);

            return StatusCode(500, "Internal Server Error");

        }

        [HttpGet]
        [Route("admintickets")]
        public async Task<IActionResult> GetUserTickets()

        {
            var result = await _iTicketService.GetUserTickets();

            if (result.isSuccess)
                return Ok(result.ticketsDto);

            return StatusCode(500, "Internal Server Error");

        }
    }
}
