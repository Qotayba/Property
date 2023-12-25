using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property.Domain.Models.PropertyDtos;
using Property.Domain.Services;
using Property.Domain.Interfaces;

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

        //[HttpPut("updateProperty")]
        
    }
}
