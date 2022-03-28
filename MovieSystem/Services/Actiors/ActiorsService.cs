
namespace MovieSystem.Services.Actiors
{
    using Microsoft.EntityFrameworkCore;
    using MovieSystem.Data;
    using MovieSystem.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ActiorsService : IActiorsService
    {
        private readonly MovieSystemDbContext _data;

        public ActiorsService(MovieSystemDbContext data)
        {
            this._data = data;
        }

        public async Task<IEnumerable<Actior>> GetAllAsync()
        {
            var result = await _data.Actiors.ToListAsync();

            return result;
        }

        //Get one actior
        public async Task<Actior> GetByIdAsync(int id)
        {
            var result = await _data.Actiors.FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task AddAsync(Actior actior) 
        {
            await _data.Actiors.AddAsync(actior);

            await _data.SaveChangesAsync();
        }

        public async  Task<Actior> UpdateAsync(int id, Actior newActior)
        {
            _data.Update(newActior);
            await _data.SaveChangesAsync();
            return newActior;
        }
        
        public async Task DeleteAsync(int id)
        {
            var result = await _data.Actiors.FirstOrDefaultAsync(a => a.Id == id);
             _data.Actiors.Remove(result);
            await _data.SaveChangesAsync();
        }


    }
}
