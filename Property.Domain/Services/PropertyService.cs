﻿using AutoMapper;
using Property.Domain.Models.PropertyDtos;
using Property.Domain.Entities;
using Property.Domain.Interfaces;

namespace Property.Domain.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;
        public PropertyService(IPropertyRepository repository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<PropertyAppartmentRoomsDto?> CreateAppartment(PropertyForCreatAppartmentDto forCreatAppartmentDto)
        {

            var propertyEntity = _mapper.Map<PropertyEntity>(forCreatAppartmentDto);
            var createdPropertyEntity = await _repository.AddPropertyWithAppartmentEntity(propertyEntity);
            if (createdPropertyEntity == null)
            {
                return null;
            }
            return _mapper.Map<PropertyAppartmentRoomsDto>(createdPropertyEntity);
        }

    }
}
