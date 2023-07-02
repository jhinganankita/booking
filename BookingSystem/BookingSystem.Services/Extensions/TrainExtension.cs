
using BookingSystem.dal.Entity;

namespace BookingSystem.Services.Extensions
{
    public static class TrainExtension
    {
        public static TrainDto ConvertToTrainDto(this Trains train)
        {

            return new TrainDto
            {
                Id = train.Id,
                Name = train.Name,
                Capacity = train.Capacity,
                Fare = train.Fare
            };

        }
    }
}
