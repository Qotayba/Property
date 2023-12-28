using AutoMapper;
using Property.Domain.Entities;
using Property.Domain.Interfaces;
using Property.Domain.Models;
using Property.Domain.Models.UserDtos;

namespace Property.Domain.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var usersEntites = await _userRepository.Get();
            return _mapper.Map<IEnumerable<UserDto>>(usersEntites);
        }
        public async Task<UserDto?> GetUserDtoAsync(int id)
        {

            var userEntity = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDto?>(userEntity);

        }
        public async Task<UserWtihPropertiesDto?> GetUserWithPropertyDtoAsync(int id)
        {

            var userEntity = await _userRepository.GetUserEntityByIdAsync(id, true);
            return _mapper.Map<UserWtihPropertiesDto?>(userEntity);

        }

        public async Task<UserInfoForToken?> GetUserFromEmailPassword(UserCredentialsForLoginDto userCredentials)
        {

            var userEntity = await _userRepository.GetUserByEmailAndPassword(userCredentials.Email, userCredentials.Password);
            return _mapper.Map<UserInfoForToken>(userEntity);
        }
        public async Task<UserDto?> CreateUser(UserForCreationDto userForCreationDto)
        {
            var userEntity = _mapper.Map<UserEntity>(userForCreationDto);
            await _userRepository.Insert(userEntity);
            var userDto = _mapper.Map<UserDto>(userEntity);
            return userDto;

        }

        public async Task<UserDto?> UpdateUser(UserForUpdateDto userForUpdateDto, int userId)
        {
            var userEntity = await _userRepository.GetByIdAsync(userId);
            if (userEntity == null)
            {
                return null;
            }
            _mapper.Map(userForUpdateDto, userEntity);
            var returnedUser = await _userRepository.Update(userEntity);
            return _mapper.Map<UserDto>(returnedUser);

        }




    }
}
