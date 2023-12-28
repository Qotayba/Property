using Property.Domain.Models;
using Property.Domain.Models.UserDtos;

namespace Property.Domain.Services
{
    public interface IUserServices
    {
        Task<UserDto?> CreateUser(UserForCreationDto userForCreationDto);
        Task<UserDto?> GetUserDtoAsync(int id);
        Task<UserInfoForToken?> GetUserFromEmailPassword(UserCredentialsForLoginDto userCredentials);
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserWtihPropertiesDto?> GetUserWithPropertyDtoAsync(int id);
        Task<UserDto?> UpdateUser(UserForUpdateDto userForUpdateDto, int userId);
    }
}