using NTierSchool.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
       
        Task<TEntity> GetEntityAsync(int id);
       
        Task AddAsync(TEntity entity);
    
        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);
    }
}
