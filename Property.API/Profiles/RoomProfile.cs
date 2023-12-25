using AutoMapper;

using Property.Domain.Entities;
using Property.Domain.Models.RoomDtos;

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
