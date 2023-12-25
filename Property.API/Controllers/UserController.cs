using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Property.Domain.Models.UserDtos;
using Property.Domain.Services;
using Property.Domain.Interfaces;

namespace Property.API.Controllers
{
    [ApiController]
    [Route("api/users/")]
    public class UserController:ControllerBase
    {
        private readonly UserServices _userServices;
        private readonly IMapper _mapper;
        public UserController(UserServices userServices, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userServices = userServices ?? throw new ArgumentNullException(nameof(userServices));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers() { 
            return Ok(await _userServices.GetUsersAsync());
        }

        [HttpGet("{userId}",Name ="GetUser")]
        public async Task<ActionResult<UserDto>> GetUser(int userId)  { 
            
            var userDto= await _userServices.GetUserDtoAsync(userId);
            if (userDto == null)
            {
                return NotFound("User Not Found");
            }
            return userDto;

        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserForCreationDto userForCreationDto)
        {
            var userDtoCreated = await _userServices.CreateUser(userForCreationDto);
            if (userDtoCreated == null) {
                return BadRequest("Faild to create user ");

            }
            return CreatedAtRoute("GetUser",
                new
                {
                    userId = userDtoCreated.Id
                },
                userDtoCreated
                ) ; 

        }

        [HttpPut("updateUser/{userId}")]
        public async Task <ActionResult<UserDto>> updateUser(int userId, UserForUpdateDto user)
        {
            var userDto = await _userServices.UpdateUser(user, userId);

            if (userDto == null)
            {
                return NotFound("User dose not exist");
            }
            return Ok(userDto); 
        }
        



    }
}
