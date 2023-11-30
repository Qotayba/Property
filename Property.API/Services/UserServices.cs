using AutoMapper;
using Property.API.Models;
using Property.Domain.Entities;
using Property.Domain.Interfaces;


namespace Property.API.Services
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserServices(IUserRepository userRepository ,IMapper mapper) 
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository?? throw new ArgumentNullException( nameof( userRepository ) );
        }
        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var usersEntites = await _userRepository.GetUsersEntityAsync();
            return _mapper.Map<IEnumerable<UserDto>>(usersEntites);   
        }
        public async Task<UserDto?> GetUserDtoAsync(int id) {

            var userEntity = await _userRepository.GetUserEntityByIdAsync(id, false);
            return _mapper.Map<UserDto?>(userEntity);
        
        }
        public async Task<UserWtihPropertiesDto?> GetUserWithPropertyDtoAsync(int id)
        {

            var userEntity = await _userRepository.GetUserEntityByIdAsync(id, true);
            return _mapper.Map<UserWtihPropertiesDto?>(userEntity);

        }

        public async Task<UserDto> GetUserFromEmailPassword(UserCredentialsForLoginDto userCredentials) {

            var userEntity= await _userRepository.GetUserByEmailAndPassword(userCredentials.Email, userCredentials.Password);
            return _mapper.Map<UserDto>(userEntity);
        }
        public async Task<UserDto?> CreateUser(UserForCreationDto userForCreationDto) 
        {
            var userEntityForCreate = _mapper.Map<UserEntity>(userForCreationDto);
            _userRepository.AddUser(userEntityForCreate);
            if (await _userRepository.SaveChangesAsync()==false) 
            {

                return null;
            }
            var userDto = _mapper.Map<UserDto>(userEntityForCreate);
            return userDto;
        
        }




    }
}
