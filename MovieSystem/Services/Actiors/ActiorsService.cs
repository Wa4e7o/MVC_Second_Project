
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

        public async Task<IEnumerable<Actior>> GetAll()
        {
            var result = await _data.Actiors.ToListAsync();

            return result;
        }

        //Get one actior
        public Actior GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Actior actior) 
        {
            
        }

        public Actior Update(int id, Actior newActior)
        {
            throw new System.NotImplementedException();
        }
        
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }


    }
}
