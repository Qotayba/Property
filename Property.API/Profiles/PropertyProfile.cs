using AutoMapper;

using Property.Domain.Entities;
using Property.Domain.Models.PropertyDtos;

namespace Property.API.Profiles
{
    public class PropertyProfile :Profile
    {
        public PropertyProfile() 
        {
            CreateMap<PropertyEntity, PropertyDto>();
            CreateMap<PropertyDto, PropertyEntity>();
            CreateMap<PropertyForCreatAppartmentDto, PropertyEntity>();
            CreateMap <PropertyAppartmentRoomsDto, PropertyEntity>();
            CreateMap<PropertyEntity, PropertyAppartmentRoomsDto>();
            CreateMap<PropertyForCreationDto, PropertyEntity>();
            CreateMap<PropertyEntity, PropertyForUpdateDto>();
            CreateMap<PropertyForUpdateDto, PropertyEntity>();
        }
    }
}
