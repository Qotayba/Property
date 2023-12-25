using Property.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Interfaces
{
    public interface IPropertyRepository
    {
        Task<PropertyEntity?> AddPropertyWithAppartmentEntity(PropertyEntity propertyEntity);
        Task<bool> PropertyExistsAsync(int id);
        Task<PropertyEntity?> AddPropertyAsync(PropertyEntity propertyEntity);
    }
}
