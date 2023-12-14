using AutoMapper;
using Property.API.Models.AppatmentDtos;
using Property.Domain.Entities;

namespace Property.API.Profiles
{
    public class AppartmentProfile: Profile
    {
        public AppartmentProfile() {

            CreateMap<AppartmentForCreationDto, AppartmentEntity>();
            CreateMap<AppartmentEntity, AppartmentGenralInfoDto>();
            
        }  
    }
}
