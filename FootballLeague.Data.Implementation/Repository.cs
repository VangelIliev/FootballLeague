using FootballLeague.Data.Entities;
using FootballLeague.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Implementation
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class,IBaseEntity
    {
        protected readonly DbContext Context;

        protected Repository(DbContext context)
        {
            this.Context = context;
        }
        public async Task<Guid> CreateAsync(TEntity entity)
        {
            try
            {
                this.Context.Set<TEntity>().Add(entity);
                await this.Context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
            await this.Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await this.Context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.Context.Set<TEntity>().Remove(entity);
            await this.Context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> FindAllAsync()
        {
            return await this.Context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> ReadAsync(Guid id)
        {
            return await this.Context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this.Context.Set<TEntity>().Update(entity);
            await this.Context.SaveChangesAsync();
        }
    }
}
