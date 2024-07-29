using NTierSchool.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.Services
{
    public class ClassService<TEntity> : BaseService<TEntity> where TEntity : class
    {
        public ClassService(IRepository<TEntity> repository) : base(repository)
        {
        }
    }
}
