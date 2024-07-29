using NTierSchool.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.Services
{
    public class SchoolService<TEntity> : BaseService<TEntity> where TEntity : class
    {
        public SchoolService(IRepository<TEntity> repository) : base(repository)
        {
        }
    }
}
