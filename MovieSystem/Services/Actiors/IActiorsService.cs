namespace MovieSystem.Services.Actiors
{
    using MovieSystem.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IActiorsService
    {
        Task<IEnumerable<Actior>> GetAllAsync();
        
        Task<Actior> GetByIdAsync(int id);

        Task AddAsync(Actior actior);

        Task<Actior> UpdateAsync(int id, Actior newActior);

        Task DeleteAsync(int id);
    }
}
