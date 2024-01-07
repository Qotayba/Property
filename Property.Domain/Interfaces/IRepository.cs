using Property.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Interfaces
{
    public interface IRepository<T> where T : ParentEntity
    {
        Task<T> Insert(T item);
        Task<T> Update(T item);
        Task<T> Remove(T item);
        
        Task<ICollection<T>> Get(List<Expression<Func<T, bool>>> filters = null);
        IQueryable<T> GetAsQueryable(List<Expression<Func<T, bool>>> filters = null);
        Task<T?> GetByIdAsync(int id);
        Task<bool> EntityExsist(int Id);
    }
}
