using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.dal.Entity
{

    public class TrainDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Capacity { get; set; }

        public decimal Fare { get; set; }
    }
}
