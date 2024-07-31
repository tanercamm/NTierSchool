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
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly DbSet<Teacher> _dbSet;

        public TeacherRepository(SchoolContext context) : base(context)
        {
            _dbSet = context.Set<Teacher>();
        }

        public async Task<List<Teacher>> GetAllWithIncludes()
        {
            return await _dbSet.
                            Include(x => x.Class)
                            .ThenInclude(y => y.School)
                            .Include(x => x.Class)
                            .ThenInclude(y => y.Teachers)
                            .Include(x => x.Class)
                            .ThenInclude(y => y.Students)
                            .ToListAsync();
        }
    }
}
