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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly DbSet<Student> _dbSet;

        public StudentRepository(SchoolContext context) : base(context)
        {
            _dbSet = context.Set<Student>();
        }

        public async Task<List<Student>> GetAllWithDetails()
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

        public async Task<Student> GetByIdWithDetails(int id)
        {
            return await _dbSet
                            .Include(x => x.Class)
                            .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
