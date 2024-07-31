﻿using Microsoft.EntityFrameworkCore;
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
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {
        private readonly DbSet<School> _dbSet;

        public SchoolRepository(SchoolContext context) : base(context)
        {
            _dbSet = context.Set<School>();
        }

        public async Task<List<School>> GetAllWithIncludes()
        {
            return await _dbSet
                            .Include(x => x.Classes)
                            .ThenInclude(y => y.School)
                            .Include(x => x.Classes)
                            .ThenInclude(y => y.Teachers)
                            .Include(x => x.Classes)
                            .ThenInclude(y => y.Students)
                            .ToListAsync();
        }
    }
}
