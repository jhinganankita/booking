using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Services.Extensions
{
    public static class BusExtension
    {
        public static BusesDto ConvertToBusDto(this Buses bus)
        {

            return new BusesDto
            {
                Id = bus.Id,
                Name = bus.Name,
                Capacity = bus.Capacity,
                Fare = bus.Fare
            };

        }
    }
}
