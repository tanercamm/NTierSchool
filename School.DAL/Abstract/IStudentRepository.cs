using NTierSchool.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.DAL.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetAllWithIncludes();
    }
}
