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
                            .ThenInclude(y => y.Teachers.Where(t => !t.IsDeleted))
                            .Include(x => x.Class)
                            .ThenInclude(y => y.Students.Where(s => !s.IsDeleted))
                            .Where(s => !s.IsDeleted)
                            .ToListAsync();
        }

        public async Task<Student> GetByIdWithDetails(int id)
        {
            return await _dbSet
                            .Include(x => x.Class)
                            .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task<List<Student>> GetAllByClassIdWithDetails(int classId)
        {
            return await _dbSet
                            .Include(x => x.Class)
                            .Where(x => x.ClassId == classId && !x.IsDeleted)
                            .ToListAsync();
        }
    }
}
