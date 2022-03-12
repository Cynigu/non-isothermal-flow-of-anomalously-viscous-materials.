using Microsoft.EntityFrameworkCore;
using ProgramSystem.Data.Models;
using ProgramSystem.Data.Repository.Interfaces;

namespace ProgramSystem.Data.Repository.Repositories
{
    public class DataBaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity:  class
        where TContext : DbContext
    {
        protected readonly TContext _repositoryContext;
        public DataBaseRepository(TContext context)
        {
            _repositoryContext = context;
        }

        public virtual async Task Add(TEntity item)
        {
            await _repositoryContext.Set<TEntity>().AddAsync(item);
            await SaveAsync();
        }

        public async Task AddRange(ICollection<TEntity> items)
        {
            await _repositoryContext.Set<TEntity>().AddRangeAsync(items);
            await SaveAsync();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _repositoryContext.Set<TEntity>().Where(predicate);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            IEnumerable<TEntity> result = _repositoryContext.Set<TEntity>();

            return result;
        }

        public virtual async Task SaveAsync()
        {

            await _repositoryContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<TEntity>> DeleteRange(Func<TEntity, bool> predicate)
        {
            var entitis = _repositoryContext.Set<TEntity>().Where(predicate);
            if (entitis.Any())
            {
                _repositoryContext.Set<TEntity>().RemoveRange(entitis);
                await SaveAsync();
                return entitis;
            }

            return null;
        }

        public virtual async Task Update(TEntity item)
        {

            _repositoryContext.Entry(item).State = EntityState.Modified;
            await SaveAsync();
        }
    }
}
