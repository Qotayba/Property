using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;
using Property.Domain.Interfaces;
using Property.Domain.Models.AppatmentDtos;
using Property.Domain.Models.PropertyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Services
{
    public class AppartmentService : IAppatmentService
    {
        private readonly IApparmentRepository _repository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public AppartmentService(
            IApparmentRepository repository,IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<AppartmentDto> CreateAppartment(AppartmentForCreationDto appartmentForCreationDto)
        {
            var appartmentEntity = _mapper.Map<AppartmentEntity>(appartmentForCreationDto);
           var insertedAppartment= await _repository.Insert(appartmentEntity);
            
           var propertyEntity = await _repository.GetAsQueryable()
                .Include(c => c.Property)
                .Where(p => p.Id == insertedAppartment.Id)
                .Select(c => c.Property)
                .FirstOrDefaultAsync();

            propertyEntity!.Type = Enum.PropertyType.Apartment;
           await  _propertyRepository.Update(propertyEntity);
           
            var appartmentToReturn = _mapper.Map<AppartmentDto>(appartmentEntity);
            return appartmentToReturn;
        }

        public async Task<AppartmentDto?> DeleteAppartment(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return null;
            }
            await _repository.Remove(entity);
            return _mapper.Map<AppartmentDto>(entity);
        }

        public async Task<AppartmentDto?> GetAppartmentById(int id)
        {
            var appartmentEntity = await _repository.GetByIdAsync(id);
            var appartmentDtoToReturn = _mapper.Map<AppartmentDto>(appartmentEntity);
            return appartmentDtoToReturn;
        }

        public async Task<AppartmentDto?> UpdateAppartment(int id, AppartmentForUpdateDto appartmentForUpdateDto)
        {
            var appartmentEntity = await _repository.GetByIdAsync(id);
            if (appartmentEntity == null)
            {
                return null;
            }
            _mapper.Map(appartmentForUpdateDto, appartmentEntity);
            var appartmentEntityAfterUpdate = _repository.Update(appartmentEntity);

            var propertyDtoToReturn = _mapper.Map<AppartmentDto>(appartmentEntityAfterUpdate);
            return propertyDtoToReturn;
        }
    }
}
