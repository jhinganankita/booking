using BookingSystem.dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Services.Extensions
{
    public static class PlaneExtension
    {
        public static PlaneDto ConvertToPlaneDto(this Planes plane)
        {

            return new PlaneDto
            {
                Id = plane.Id,
                Name = plane.Name,
                Capacity = plane.Capacity,
                Fare = plane.Fare
            };

        }
    }
}
