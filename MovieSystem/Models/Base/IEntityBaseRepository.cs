using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSystem.Models.Base
{
    // We can make models generic, <T> is class
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(int id, T newEntity);

        Task DeleteAsync(int id);
    }
}
