namespace MovieSystem.Services.Movies
{
    using Microsoft.EntityFrameworkCore;
    using MovieSystem.Data;
    using MovieSystem.Data.Models;
    using MovieSystem.Models.Base;
    using System.Threading.Tasks;

    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {

        private readonly MovieSystemDbContext _data;

        public MoviesService(MovieSystemDbContext data) : base(data)
        {
            this._data = data;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _data.Movies
                        .Include(c => c.Cinema)
                        .Include(p => p.Producer)
                        .Include(am => am.ConnectionTables).ThenInclude(a => a.Actior)
                        .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }
    }
}
