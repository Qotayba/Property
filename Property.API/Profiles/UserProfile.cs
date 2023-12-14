﻿using AutoMapper;

using Property.Domain.Models.UserDtos;
using Property.Domain.Entities;

namespace Property.API.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile() 
        {
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, UserWtihPropertiesDto>();
            CreateMap<UserForCreationDto, UserEntity>();

        }

    }
}
