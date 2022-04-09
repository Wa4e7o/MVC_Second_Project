namespace MovieSystem.Services.Cinemas
{
    using MovieSystem.Data;
    using MovieSystem.Data.Models;
    using MovieSystem.Models.Base;

    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(MovieSystemDbContext data) : base(data) { }
    }
}
