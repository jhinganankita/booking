using BookingSystem.Services.Dto;

namespace BookingSystem.Services.Interface
{
    public interface IUserService
    {
        Task<(bool isSuccess, UserDto user, string errorMessage)> AddAsync(UserDto user);
        Task<(bool isSuccess, UserDto user, string errorMessage)> Authenticate(AuthenticateDto user);
        Task<(bool isSuccess, UserDto user, string errorMessage)> GetAsync(int id);
        Task<(bool isSuccess, IEnumerable<UserDto> users, string errorMessage)> GetAsync();
    }
}
