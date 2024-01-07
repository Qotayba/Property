using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Property.Domain.Models.AppatmentDtos;
using Property.Domain.Models.PropertyDtos;
using Property.Domain.Services;

namespace Property.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppartmentController : ControllerBase
    {
        private readonly IAppatmentService _appatmentService;
        private readonly IPropertyService _propertyService;
        public AppartmentController(
            IAppatmentService appatmentService,IPropertyService propertyService)
        {
            _propertyService = propertyService;
            _appatmentService = appatmentService;
        }
        [Authorize]
        [HttpPost("CreateAppartment/{propertyId}")]
        public async Task<ActionResult<bool>> CreatePropertyAsync(
            int propertyId, AppartmentForCreationDto appartmentForCreation)
        {
            try
            {
                var UserIdFromToken = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
                if (UserIdFromToken == null)
                {
                    return Unauthorized();
                }
                bool? CanAddOrNotFound = await _propertyService.checkIfPropertyHasAlreadyType(propertyId);
                if (CanAddOrNotFound == null) { 
                    return NotFound();
                }
                if (CanAddOrNotFound == false)
                {
                    return BadRequest("can't the property already  assgined to another type ");
                }
                
                int userIdAfterParse = int.Parse(UserIdFromToken);
                appartmentForCreation.PropertyId = propertyId;
                appartmentForCreation.CreatedByUserId = userIdAfterParse;
                var appartmentDtoToReturn = await _appatmentService.CreateAppartment(appartmentForCreation);


                return Ok(appartmentDtoToReturn);
            }catch(DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException)
                {
                    
                    if (sqlException.Number == 2601)
                    {
                        
                        return BadRequest("A duplicate key violation occurred. in PropertyId");
                    }
                }
                throw;
            }
        }
    }
}
