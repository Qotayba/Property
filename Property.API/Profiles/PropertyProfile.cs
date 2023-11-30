using AutoMapper;
using Property.API.Models;
using Property.Domain.Entities;

namespace Property.API.Profiles
{
    public class PropertyProfile :Profile
    {
        public PropertyProfile() 
        {
            CreateMap<PropertyEntity, PropertyDto>();
            CreateMap<PropertyDto, PropertyEntity>();
        }
    }
}
