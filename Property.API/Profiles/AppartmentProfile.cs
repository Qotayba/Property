﻿using AutoMapper;

using Property.Domain.Entities;
using Property.Domain.Models.AppatmentDtos;

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
