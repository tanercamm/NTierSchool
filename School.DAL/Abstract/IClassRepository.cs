using NTierSchool.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.DAL.Repositories
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<List<Class>> GetAllWithDetails();

        Task<bool> Any(int id);
    }
}
