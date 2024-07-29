using NTierSchool.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.Services
{
    public class TeacherService<TEntity> : BaseService<TEntity> where TEntity : class
    {
        public TeacherService(IRepository<TEntity> repository) : base(repository)
        {
        }
    }
}
