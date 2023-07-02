using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Services.Dto
{
    public interface IScheduleEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Capacity { get; set; }

        public decimal Fare { get; set; }
    }
}
