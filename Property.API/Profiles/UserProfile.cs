using AutoMapper;

using Property.Domain.Entities;
using Property.Domain.Models.UserDtos;

namespace Property.API.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile() 
        {
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, UserWtihPropertiesDto>();
            CreateMap<UserForCreationDto, UserEntity>();
            CreateMap<UserForUpdateDto, UserEntity>();

        }

    }
}
