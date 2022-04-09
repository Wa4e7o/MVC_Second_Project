namespace MovieSystem.Models.Base
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using MovieSystem.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly MovieSystemDbContext _data;

        public EntityBaseRepository(MovieSystemDbContext data)
        {
            this._data = data;
        }

        public async Task AddAsync(T entity)
        {
            await _data.Set<T>().AddAsync(entity);

            await _data.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _data.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            EntityEntry entityEntry = _data.Entry<T>(result);
            entityEntry.State = EntityState.Deleted;

            await _data.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _data.Set<T>().ToListAsync();

            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _data.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        //Add one actior
        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _data.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task UpdateAsync(int id, T newEntity)
        {
            EntityEntry entityEntry = _data.Entry<T>(newEntity);
            entityEntry.State = EntityState.Modified;
            await _data.SaveChangesAsync();
        }
    }
}
