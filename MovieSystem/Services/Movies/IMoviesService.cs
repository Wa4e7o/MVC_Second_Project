namespace MovieSystem.Services.Movies
{
    using MovieSystem.Data.Models;
    using MovieSystem.Models.Base;
    using System.Threading.Tasks;

    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id); 
    }
}
