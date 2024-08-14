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

        public async Task<bool> AnyAsync(int id)
        {
            return await _dbSet.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Class>> GetAllWithDetails()
        {
            return await _dbSet
                            .Include(x => x.School)
                            .Include(x => x.Teachers.Where(t => !t.IsDeleted))
                            .Include(x => x.Students.Where(s => !s.IsDeleted))
                            .Where(c => !c.IsDeleted)
                            .ToListAsync();
        }

        public async Task<Class> GetByIdWithDetails(int id)
        {
            return await _dbSet
                            .Include(x => x.School)
                            .Include(x => x.Teachers.Where(t => !t.IsDeleted))
                            .Include(x => x.Students.Where(s => !s.IsDeleted))
                            .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public async Task<List<Class>> GetAllBySchoolIdWithDetails(int schoolId)
        {
            return await _dbSet
                            .Include(x => x.Teachers.Where(t => !t.IsDeleted))
                            .Include(x => x.Students.Where(s => !s.IsDeleted))
                            .Where(x => x.SchoolId == schoolId && !x.IsDeleted)
                            .ToListAsync();
        }

    }
}
