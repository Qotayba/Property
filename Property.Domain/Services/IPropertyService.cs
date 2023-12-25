using Property.Domain.Models.PropertyDtos;

namespace Property.Domain.Services
{
    public interface IPropertyService
    {
        Task<PropertyAppartmentRoomsDto?> CreateAppartment(PropertyForCreatAppartmentDto forCreatAppartmentDto);
    }
}