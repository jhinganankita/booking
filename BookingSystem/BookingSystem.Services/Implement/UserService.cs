using BookingSystem.dal.Entity;
using BookingSystem.dal.Implement;
using BookingSystem.dal.Interface;
using BookingSystem.Services.Dto;
using BookingSystem.Services.Extensions;
using BookingSystem.Services.Interface;
using Microsoft.Extensions.Logging;

namespace BookingSystem.Services.Implement
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<IUserService> _logger;
        public UserService(ILogger<IUserService> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<(bool isSuccess, UserDto user, string errorMessage)> AddAsync(UserDto userDto)
        {
            try
            {
                _logger.LogInformation("About to convert user model to user dto");

                var user = userDto.ConvertToUser();
                await _userRepository.AddAsync(user); // add the object into the database
                await _userRepository.CommitAsync(); // commit once everything is done.

                _logger.LogDebug("User data has been committed into the database.");

                userDto.Id = user.Id;
                return (true, userDto, null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} | {ex.StackTrace}");
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, UserDto user, string errorMessage)> Authenticate(AuthenticateDto authenticateUser)
        {
            try
            {
                var user = (await _userRepository.FindAsync(x => x.Username == authenticateUser.Username && x.Password == authenticateUser.Password)).FirstOrDefault();
                if (user == null)
                    throw new Exception($"User does not exists.");
                return (true, user.ConvertToUserDto(), null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} | {ex.StackTrace}");
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, UserDto user, string errorMessage)> GetAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Get user by userid: {id}");
                var user = await _userRepository.GetById(id);
                if (user == null)
                    throw new Exception($"User with id {id} not found.");
                return (true, user.ConvertToUserDto(), null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} | {ex.StackTrace}");
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, IEnumerable<UserDto> users, string errorMessage)> GetAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return (true, users.ConvertToUsersDto(), String.Empty);
        }

    }
}
