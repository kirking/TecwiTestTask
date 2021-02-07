using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> GetEntitiesAsync();
        Task<TEntity> GetEntityByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
