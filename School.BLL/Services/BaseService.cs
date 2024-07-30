using NTierSchool.BLL.Interfaces;
using NTierSchool.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierSchool.BLL.Services
{
    public class BaseService<TEntity>: IBaseService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public BaseService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<TEntity> GetEntityAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
            else
            {
                // Hata durumu: Varlık bulunamadı
                throw new Exception("Entity not found");
            }
        }

    }
}
