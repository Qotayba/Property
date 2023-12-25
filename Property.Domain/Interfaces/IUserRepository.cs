
using Property.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Interfaces
{
    public  interface IUserRepository: IRepository<UserEntity> 
    {
        Task<IEnumerable<UserEntity>> GetUsersEntitiesAsync();
        Task<UserEntity?> GetUserEntityByIdAsync(int id , bool includeProperties);
        
        Task<bool> UserExists(int id);
        
        Task<bool> EmailExists(string email);
        Task<UserEntity?> GetUserByEmailAndPassword(string email, string password);
        
       


    }
}
