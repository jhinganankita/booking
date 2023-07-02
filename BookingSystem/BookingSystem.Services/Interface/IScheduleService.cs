using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Services.Interface
{
    public interface IScheduleService
    {
        Task<(bool isSuccess, IEnumerable<SchedulesDto> schedules, string errorMessage)> GetAsync(ScheduleRequestDto scheduleRequest);
        //Task<(bool isSuccess, IEnumerable<PlaneSchedulesDto> planes, string errorMessage)> GetAsyncPlanes();
        //Task<(bool isSuccess, IEnumerable<TrainSchedulesDto> trains, string errorMessage)> GetAsyncTrains();
    }
}
