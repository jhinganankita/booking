using BookingSystem.dal.Entity;
using BookingSystem.Services.Dto;

namespace BookingSystem.Services.Extensions
{
    public static class UserExtension
    {
        public static Users ConvertToUser(this UserDto userDto)
        {
            Users user = new Users();
            user.Username = userDto.Username;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Password = userDto.Password;
            //user.Address = userDto.Address;
            //user.City = userDto.City;
            //user.PostalCode = userDto.PostalCode;
            //user.Phone = userDto.Phone;
            user.Mobile = userDto.Mobile;
            user.RoleName = userDto.RoleName;
            //user.Token = userDto.Token;
            return user;
        }

        public static UserDto ConvertToUserDto(this Users user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                //Address = user.Address,
                //City = user.City,
                //PostalCode = user.PostalCode,
                //Phone = user.Phone,
                Mobile = user.Mobile,
                RoleName = user.RoleName,
                //Token = user.Token
            };
        }

        public static IEnumerable<UserDto> ConvertToUsersDto(this IEnumerable<Users> users)
        {
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                //Address = user.Address,
                //City = user.City,
                //PostalCode = user.PostalCode,
                //Phone = user.Phone,
                Mobile = user.Mobile,
                RoleName = user.RoleName,
                //Token = user.Token
            });
        }
    }
}
