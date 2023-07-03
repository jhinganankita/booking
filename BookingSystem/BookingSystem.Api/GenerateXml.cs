using BookingSystem.Api.Controllers;
using BookingSystem.dal.Entity;
using BookingSystem.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace BookingSystem.Api
{
    public class GenerateXml
    {
        //private readonly IUserService _iUserService;
        //private readonly ILogger<UserController> _logger;
        //public GenerateXml(ILogger<GenerateXml> logger, IUserService iUserService)
        //{
        //    _iUserService = iUserService;
        //    _logger = logger;
        //}

        //public async void BookingConfirmation(TicketsDto ticket)
        //{
        //    var result = await _iUserService.GetByUserId(ticket.UserId);
        //    ticket.User = result.userDto;
        //    // Generate XML file
        //    var xmlSerializer = new XmlSerializer(typeof(TicketsDto));
        //    var xmlStringWriter = new StringWriter();
        //    xmlSerializer.Serialize(xmlStringWriter, ticket);

        //    // Return XML file as response
        //    return content(xmlStringWriter.ToString(), "application/xml");
        //}
    }
}
