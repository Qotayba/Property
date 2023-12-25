using Microsoft.EntityFrameworkCore;
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
    public class UserRepository :Repository<UserEntity>, IUserRepository
    {
        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context):base(context) {
            
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<UserEntity?> GetUserByEmailAndPassword(string email, string password)
        {
            return await _context.Users
                .Where(u=>u.Email==email && u.Password == password)
                .FirstOrDefaultAsync();    
        }

        public async Task<UserEntity?> GetUserEntityByIdAsync(int id, bool includeProperties) 
        {
            if (includeProperties)
            {
                return await _context.Users
                    .Include(u => u.Properties)
                    .FirstOrDefaultAsync(u => u.Id == id);
            }

            return await _context.Users
                .FirstOrDefaultAsync(u=>u.Id==id);
                        
        }

        public async Task<IEnumerable<UserEntity>> GetUsersEntitiesAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> UserExists(int id)
        {
            return await _context.Users.AnyAsync(u=>u.Id==id);
        }


     
    }
}
