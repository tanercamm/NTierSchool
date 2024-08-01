using Microsoft.EntityFrameworkCore;
using NTierSchool.DAL.Repositories;
using NTierSchool.Entity.Context;
using NTierSchool.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.DAL.Concrete
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        private readonly DbSet<Class> _dbSet;

        public ClassRepository(SchoolContext context) : base(context)
        {
            _dbSet = context.Set<Class>();
        }

        public async Task<bool> Any(int id)
        {
            return await _dbSet.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Class>> GetAllWithDetails()
        {
            return await _dbSet.
                            Include(x => x.School)
                            .Include(x => x.Teachers)
                            .Include(x => x.Students)
                            .ToListAsync();
        }
    }
}
