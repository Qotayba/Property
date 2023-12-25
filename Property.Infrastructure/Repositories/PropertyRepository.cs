using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;
using Property.Domain.Interfaces;
using Property.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DatabaseContext _context;
        public PropertyRepository(DatabaseContext context) {
            _context= context ??throw new ArgumentNullException(nameof(context));
        }


        public async Task<PropertyEntity?> AddPropertyWithAppartmentEntity(PropertyEntity propertyEntity)
        {
            _context.Properties.Add(propertyEntity);

            if (await _context.SaveChangesAsync() > 0)
            {
                return propertyEntity;
            }
            return null;
        }

        public async Task<bool> PropertyExistsAsync(int id)
        {
            return await _context.Properties.AnyAsync(p => p.Id == id);
        }

        public async Task<PropertyEntity?> AddPropertyAsync(PropertyEntity propertyEntity)
        {
            _context.Properties.Add(propertyEntity);
            if (await _context.SaveChangesAsync() > 0) { 
            
                return propertyEntity;
            }
            else { return null; }   

        }


    }
}
