using FootballLeague.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IBaseEntity
    {
        Task<List<TEntity>> FindAllAsync();
        Task<Guid> CreateAsync(TEntity entity);
        Task<TEntity> ReadAsync(Guid id);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(Guid id);

    }
}
