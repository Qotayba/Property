using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Property.Domain.Entities;
using Property.Domain.Enum;
using Property.Domain.Interfaces;
using Property.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        DatabaseContext _context;
        private readonly ILogger<IRepository<T>> _logger;
        public Repository(DatabaseContext context, ILogger<IRepository<T>> logger) { 
            _context = context;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<ICollection<T>> Get(List<Expression<Func<T, bool>>> filters = null)
        {
            var _table = _context.Set<T>();
            var query = _table.AsQueryable();
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }
        

        public IQueryable<T> GetAsQueryable(List<Expression<Func<T, bool>>> filters = null)
        {
           var _table=_context.Set<T>();
           var query=_table.AsQueryable();
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }
            return query.AsNoTracking().AsQueryable();
        }
        public async Task <T?> GetByIdAsync(int id) { 
            var _table=_context.Set<T>();
            var query= await _table.FirstOrDefaultAsync(t=>t.Id == id);
            return query;    
        }
        public async Task<T> Insert(T item)
        {
            var _table = _context.Set<T>();
            item.UpdatedAt = DateTime.Now;
            item.CreatedAt = DateTime.Now;
            await _table.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> Update(T item)
        {
            var _table = _context.Set<T>(); 
            item.UpdatedAt = DateTime.Now;
            _table.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> Remove(T item)
        {
            var _table = _context.Set<T>();
            item.UpdatedAt = DateTime.Now;
            item.Status = ItemStatus.NotActive;
            _table.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }


       
    } 
    
}
