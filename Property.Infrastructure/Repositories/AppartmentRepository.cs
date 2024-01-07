using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class AppartmentRepository : Repository<AppartmentEntity>, IApparmentRepository
    {
        private readonly DatabaseContext _context;
        public AppartmentRepository(
            DatabaseContext context, ILogger<IRepository<AppartmentEntity>> logger)
            : base(context, logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
