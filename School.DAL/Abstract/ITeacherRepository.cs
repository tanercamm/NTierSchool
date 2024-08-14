using NTierSchool.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.DAL.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<List<Teacher>> GetAllWithDetails();

        Task<Teacher> GetByIdWithDetails(int id);

        Task<List<Teacher>> GetAllByClassIdWithDetails(int classId);
    }
}
