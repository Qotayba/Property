using AutoMapper;
using Property.Domain.Models.PropertyDtos;
using Property.Domain.Entities;

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
        }
    }
}
