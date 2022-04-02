namespace MovieSystem.Services.Producers
{
    using MovieSystem.Data;
    using MovieSystem.Data.Models;
    using MovieSystem.Models.Base;

    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(MovieSystemDbContext data) : base(data) { }
    }
}
