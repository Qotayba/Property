using AutoMapper;
using Property.API.Models.RoomDtos;
using Property.Domain.Entities;

namespace Property.API.Profiles
{
    public class RoomProfile:Profile
    {
        public RoomProfile() 
        {
            CreateMap<RoomForCreationDto, RoomEntity>();
            CreateMap<RoomEntity, RoomGeneralInfoDto>();
        }
    }
}
