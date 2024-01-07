using Property.Domain.Models.PropertyDtos;

namespace Property.Domain.Services
{
    public interface IPropertyService
    {
        Task<PropertyDto> CreateProperty(PropertyForCreationDto propertyForCreationDto);
        Task<PropertyDto?> DeleteProperty(int id);
        Task<PropertyDto?> GetPropertyById(int id);
        Task<PropertyDto?> UpdateProperty(int id, PropertyForUpdateDto propertyForUpdateDto);
        Task<bool> PropertyExists(int id);
        Task<bool?> checkIfPropertyHasAlreadyType(int id);
    }
}