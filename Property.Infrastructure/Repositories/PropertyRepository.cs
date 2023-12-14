using Property.Domain.Entities;
using Property.Domain.Interfaces;
using Property.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly PropertyContext _context;
        public PropertyRepository(PropertyContext context) {
            _context= context ??throw new ArgumentNullException(nameof(context));
        }
        public async Task<PropertyEntity?> AddPropertyEntity(PropertyEntity propertyEntity)
        {
            _context.Properties.Add(propertyEntity);

            if (await _context.SaveChangesAsync() > 0)
            {
                return propertyEntity;
            }
            return null;
        }
    }
}
