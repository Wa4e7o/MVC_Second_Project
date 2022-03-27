namespace MovieSystem.Services.Actiors
{
    using MovieSystem.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IActiorsService
    {
        Task<IEnumerable<Actior>> GetAll();
        
        Actior GetById(int id);

        void Add(Actior actior);

        Actior Update(int id, Actior newActior);

        void Delete(int id);
    }
}
