using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Property.API.Models;
using Property.API.Services;
using Property.Domain.Interfaces;

namespace Property.API.Controllers
{
    [ApiController]
    [Route("api/users")]
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


    }
}
