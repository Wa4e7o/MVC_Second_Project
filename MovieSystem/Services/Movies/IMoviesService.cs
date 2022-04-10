namespace MovieSystem.Services.Movies
{
    using MovieSystem.Data.Models;
    using MovieSystem.Models.Base;
    using MovieSystem.Models.Movies;
    using System.Threading.Tasks;

    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<DropdownViewModel> GetMovieDropDownValues();

        Task AddNewMovieAsync(NewMoviesViewModel dataMovie);

        Task UpdateMovieAsync(NewMoviesViewModel dataMovie);
    }
}
