namespace MovieSystem.Services.Movies
{
    using Microsoft.EntityFrameworkCore;
    using MovieSystem.Data;
    using MovieSystem.Data.Models;
    using MovieSystem.Models.Base;
    using MovieSystem.Models.Movies;
    using System.Linq;
    using System.Threading.Tasks;

    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {

        private readonly MovieSystemDbContext _data;

        public MoviesService(MovieSystemDbContext data) : base(data)
        {
            this._data = data;
        }

        public async Task AddNewMovieAsync(NewMoviesViewModel dataMovie)
        {
            var newMovieObj = new Movie()
            {
                Name = dataMovie.Name,
                Description = dataMovie.Description,
                Price = dataMovie.Price,
                ImgUrl = dataMovie.ImgUrl,
                CinemaId = dataMovie.CinemaId,
                StartDate = dataMovie.StartDate,
                EndDate = dataMovie.EndDate,
                MovieCategory = dataMovie.MovieCategory,
                ProducerId = dataMovie.ProducerId
            };

            await _data.AddAsync(newMovieObj);

            await _data.SaveChangesAsync();

            foreach (var actorId in dataMovie.ActiorIds)
            {
                var newConnectionTable = new ConnectionTable()
                {
                    MovieId = newMovieObj.Id,
                    ActiorId = actorId
                };

                await _data.ConnectionTables.AddAsync(newConnectionTable);
            }

            await _data.SaveChangesAsync();
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

        public async Task<DropdownViewModel> GetMovieDropDownValues()
        {
            var response = new DropdownViewModel()
            {
                Actiors = await _data.Actiors.OrderBy(a => a.Name).ToListAsync(),
                Cinemas = await _data.Cinemas.OrderBy(c => c.Name).ToListAsync(),
                Producers = await _data.Producers.OrderBy(p => p.Name).ToListAsync()
            };

            return response;
        }
    }
}
