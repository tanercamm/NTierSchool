using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task AddAsync(T item);

        Task UpdateAsync(T item);

        Task DeleteAsync(T item);

        Task<T> GetByIdAsync(int id);

        Task SaveChangesAsync();
    }
}
