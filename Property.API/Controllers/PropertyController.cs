using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property.Domain.Models.PropertyDtos;
using Property.Domain.Services;
using Property.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Property.API.Controllers
{
    [Route("api/Property/")]
   
    [ApiController]
    public class PropertyController : ControllerBase
    {
      private  readonly PropertyService _propertyService;
      public PropertyController(PropertyService propertyService) 
      {
            _propertyService = propertyService;
      }

        [HttpPost("createAppartment")]
        public async Task<ActionResult<PropertyAppartmentRoomsDto>> CreateAppartment(PropertyForCreatAppartmentDto appartmentDto) {

            var createdProperty = await _propertyService.CreateAppartment(appartmentDto);
            if (createdProperty == null)
            {
                return BadRequest("can't add ");
            }
            return Ok(createdProperty);
        
        }
        [Authorize]
        [HttpPost("createPropertyForUser/{userId}")]
        public async Task<ActionResult<bool>> CreatePropertyAsync(
            int userId,PropertyForCreationDto propertyCreationDto)
        {
            var UserIdFromToken =  User.Claims.FirstOrDefault(c=>c.Type=="id")?.Value;
            if(UserIdFromToken == null)
            { 
                return Unauthorized();
            }
            int userIdAfterParse=int.Parse(UserIdFromToken);
            propertyCreationDto.CreatedByUserId = userIdAfterParse;
            var propertyDtoToReturn= await _propertyService.CreateProperty(propertyCreationDto);
            
            
            return Ok(propertyDtoToReturn);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<PropertyDto>> GetProperty(int Id)
        { 
            var propertyToRetun=await _propertyService.GetPropertyById(Id);
            if (propertyToRetun == null)
            {
                return NotFound("Property not found");
            }
            return Ok(propertyToRetun);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<PropertyDto>> PutProperty (
            int Id,PropertyForUpdateDto propertyToUpdateDto)
        {
            var propertyDto=await _propertyService.UpdateProperty(Id, propertyToUpdateDto);
            if (propertyDto == null)
            {
                return NotFound();
            }
            return NoContent();
        }
        
    }
}
