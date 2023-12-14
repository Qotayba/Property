using Property.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Interfaces
{
    public  interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetUsersEntityAsync();
        Task<UserEntity?> GetUserEntityByIdAsync(int id , bool includeProperties);
        
        Task<bool> UserExists(int id);
        
        Task<bool> EmailExists(string email);
        Task<UserEntity?> GetUserByEmailAndPassword(string email, string password);
        void AddUser(UserEntity user);
        Task<bool> SaveChangesAsync();


    }
}
