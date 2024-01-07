using AutoMapper;
using Property.Domain.Models.PropertyDtos;
using Property.Domain.Entities;
using Property.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<PropertyDto> CreateProperty(PropertyForCreationDto propertyForCreationDto)
        {
            var propertyEntity=_mapper.Map<PropertyEntity>(propertyForCreationDto);
            await _repository.Insert(propertyEntity);
            var propertyDtoToReturn = _mapper.Map<PropertyDto>(propertyEntity);
            return propertyDtoToReturn;
        }
        public async Task<PropertyDto?> GetPropertyById(int id) {
            var propertyEntity= await _repository.GetByIdAsync(id);
            var propertyDtoToReturn =_mapper.Map<PropertyDto>(propertyEntity);
            return propertyDtoToReturn;
        }
        public async Task<bool?> checkIfPropertyHasAlreadyType (int id)
        {
            var propertyEntity = await _repository.GetAsQueryable()
                 .Include(p => p.Appartment)
                 .Include(p => p.Chalet)
                 .Where(p => p.Id == id).FirstOrDefaultAsync();
            
            if (propertyEntity==null) 
            {
                return null;
            }
            if(propertyEntity.Appartment==null&&propertyEntity.Chalet==null) 
            {
                return true;
            }
            return false;

        }
        //public async Task<PropertyAppartmentRoomsDto?> CreateAppartment(PropertyForCreatAppartmentDto forCreatAppartmentDto)
        //{

        //    var propertyEntity = _mapper.Map<PropertyEntity>(forCreatAppartmentDto);
        //    var createdPropertyEntity = await _repository.AddPropertyWithAppartmentEntity(propertyEntity);
        //    if (createdPropertyEntity == null)
        //    {
        //        return null;
        //    }
        //    return _mapper.Map<PropertyAppartmentRoomsDto>(createdPropertyEntity);
        //}
        public async Task<PropertyDto?> UpdateProperty(
          int id ,  PropertyForUpdateDto propertyForUpdateDto)
        {
            var propertyEntity=await _repository.GetByIdAsync(id);
            if (propertyEntity == null)
            {
                return null;
            }
            _mapper.Map(propertyForUpdateDto,propertyEntity); 
            var propertyEntityAfterUpdate=_repository.Update(propertyEntity);
            
            var propertyDto=_mapper.Map<PropertyDto>(propertyEntity);
            return propertyDto;
        
        }
        public async Task<PropertyDto?> DeleteProperty(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity== null)
            {
                return null;
            }
            await _repository.Remove(entity);
            return _mapper.Map<PropertyDto>(entity);


        }

        public async Task<bool> PropertyExists(int id)
        {
            return await _repository.EntityExsist(id);
        }
    }
}
